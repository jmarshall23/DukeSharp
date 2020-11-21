using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using Build;

public class SoundEngine : MonoBehaviour
{
    public List<AudioSource> channels = new List<AudioSource>();
    public AudioSource musicChannel = new AudioSource();

    public static SoundEngine globalSoundEngine;

    public class AudioEntry
    {
        public AudioClip clip;
        public int volume;
        public int pan;
    }

    private AudioClip[] audioClips = new AudioClip[DefineConstants.NUM_SOUNDS];
    private AudioClip[,] musicClips = new AudioClip[5, 64];

    private List<AudioEntry> newClips = new List<AudioEntry>();

    private AudioClip newMusicClip = null;
    private static Mutex mut = new Mutex();

    void Start()
    {
        globalSoundEngine = this;        
    }

    public void LoadAllSounds()
    {
        string filePath;

        if (Application.platform == RuntimePlatform.IPhonePlayer)
            filePath = "file:///" + Application.dataPath + "/Raw/";
        else if (Application.platform == RuntimePlatform.OSXPlayer)
            filePath = "file:///" + Application.dataPath + "/Data/StreamingAssets/";
        else
            filePath = "file:///" + Application.dataPath + "/StreamingAssets/";

        for (int i = 0; i < DefineConstants.NUM_SOUNDS; i++)
        {
            if (GlobalMembers.sounds[i] == null || GlobalMembers.sounds[i].Length == 0)
                continue;

            string sound_name = filePath + "sound/" + GlobalMembers.sounds[i];
            sound_name = sound_name.Replace(".voc", ".ogg");
            sound_name = sound_name.Replace(".VOC", ".ogg");

            WWW www = new WWW(sound_name);
            while(!www.isDone) {  }

            if (www.error != null)
                Debug.Log(www.error);

            audioClips[i] = www.GetAudioClip(false, true);            
        }

        for (int x = 0; x < 5; x++)
        {
            for(int y = 0; y < 64; y++)
            {
                if (GlobalMembers.music_fn[x, y] == null || GlobalMembers.music_fn[x, y].Length == 0)
                    continue;

                string sound_name = filePath + "music/" + GlobalMembers.music_fn[x, y];
                sound_name = sound_name.Replace(".mid", ".ogg");
                sound_name = sound_name.Replace(".MID", ".ogg");

                WWW www = new WWW(sound_name);
                while (!www.isDone) { }

                if (www.error != null)
                    Debug.Log(www.error);

                musicClips[x, y] = www.GetAudioClip(false, true);
            }
        }
    }

    void Update()
    {
        mut.WaitOne();

        for (int d = 0; d < channels.Count; d++)
        {
            if (!channels[d].isPlaying && channels[d].volume != 0 && channels[d].clip != null)
            {
                for(int x = 0; x < DefineConstants.NUM_SOUNDS; x++)
                {
                    if(audioClips[x] == channels[d].clip)
                    {
                        GlobalMembers.Sound[x].num--;
                        break;
                    }
                }
                channels[d].volume = 0;
            }
        }

        for (int i = 0; i < newClips.Count; i++)
        {
            for(int d = 0; d < channels.Count; d++)
            {
                if (!channels[d].isPlaying)
                {
                    channels[d].clip = newClips[i].clip;
                    channels[d].volume = newClips[i].volume / 255.0f;
                    channels[d].panStereo = newClips[i].pan / 255.0f;
                    channels[d].Play();
                    break;
                }
            }
        }
        
        if(newMusicClip != null)
        {
            musicChannel.clip = newMusicClip;
            musicChannel.loop = true;
            musicChannel.volume = 0.25f;
            musicChannel.Play();
            newMusicClip = null;
        }

        newClips.Clear();
        mut.ReleaseMutex();
    }

    public void PlaySound(int index, int volume = 0, int pan = 0)
    {
        mut.WaitOne();
        AudioEntry entry = new AudioEntry();
        entry.clip = audioClips[index];
        entry.volume = 255 - volume;
        entry.pan = pan;
        newClips.Add(entry);
        GlobalMembers.Sound[index].num++;
        mut.ReleaseMutex();
    }

    public void PlayMusic(int volumeNumber, int levelNumber)
    {
        newMusicClip = musicClips[volumeNumber, levelNumber];
    }
}
