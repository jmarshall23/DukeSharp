using System.Collections;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Build;
using System.IO;
using FMOD;
using FMODUnity;

public class SoundEngine : MonoBehaviour
{
    public static SoundEngine globalSoundEngine;

    public class AudioEntry
    {
        public FMOD.Sound FMODSound;
        public int volume;
        public int pan;
        public bool isLoaded = false;
    }

    private AudioEntry[] newClips = new AudioEntry[DefineConstants.NUM_SOUNDS];
    private AudioEntry musicClip = null;

    private FMOD.Channel musicChannel;

    public class DukeChannel
    {
        public FMOD.Channel fmodChannel;
        public int soundIndex;
        public int spriteIndex;

        public bool isPlaying
        {
            get
            {
                bool isChannelPlaying;
                fmodChannel.isPlaying(out isChannelPlaying);
                return isChannelPlaying;
            }
        }
    }

    private List<DukeChannel> playingSounds = new List<DukeChannel>();

    void Start()
    {
        globalSoundEngine = this;        
    }

    void OnDestroy()
    {
        StopAllSounds();

        if (musicClip != null && musicClip.FMODSound.handle != System.IntPtr.Zero)
            musicClip.FMODSound.release();

        for (int i = 0; i < newClips.Length; i++)
        {
            newClips[i].FMODSound.release();
        }
    }

    void LoadSoundVOC(string filename, int index)
    {
        kFile fp;

        if (filename == null || filename.Length == 0)
            return;

        filename = filename.Replace(".voc", ".ogg");
        filename = filename.Replace(".VOC", ".ogg");
        WWW www = new WWW(filename);
        while(!www.isDone) {  }

        byte[] buffer = www.bytes;

        if (buffer == null)
            return;

        FMOD.CREATESOUNDEXINFO sInfo = new FMOD.CREATESOUNDEXINFO();
        sInfo.length = (uint)buffer.Length;
        sInfo.cbsize = Marshal.SizeOf(typeof(FMOD.CREATESOUNDEXINFO));

        newClips[index] = new AudioEntry();

        FMOD.RESULT result = RuntimeManager.CoreSystem.createSound(buffer, FMOD.MODE.OPENMEMORY | FMOD.MODE._3D, ref sInfo, out newClips[index].FMODSound);
        if(result != FMOD.RESULT.OK)
        {
            //Logger.("Failed to register sound " + filename);
            return;
        }

        newClips[index].isLoaded = true;
    }

    void LoadSoundMID(string filename, int index1, int index2)
    {
        kFile fp;

        if(musicClip != null)
        {
            musicClip.FMODSound.clearHandle();
        }

        if (filename == null || filename.Length == 0)
            return;

        filename = filename.Replace(".mid", ".ogg");
        filename = filename.Replace(".MID", ".ogg");
        WWW www = new WWW(filename);
        while (!www.isDone) { }

        byte[] buffer = www.bytes;

        if (buffer == null)
            return;

        FMOD.CREATESOUNDEXINFO sInfo = new FMOD.CREATESOUNDEXINFO();
        sInfo.length = (uint)buffer.Length;
        sInfo.cbsize = Marshal.SizeOf(typeof(FMOD.CREATESOUNDEXINFO));

        musicClip = new AudioEntry();

        FMOD.RESULT result = RuntimeManager.CoreSystem.createSound(buffer, FMOD.MODE.OPENMEMORY | FMOD.MODE.LOOP_NORMAL, ref sInfo, out musicClip.FMODSound);
        if (result != FMOD.RESULT.OK)
        {
            //Logger.("Failed to register sound " + filename);
            return;
        }

        musicClip.isLoaded = true;
    }

    public void StopAllSounds()
    {
        //for (int i = 0; i < playingSounds.Count; i++)
        //{
        //    playingSounds[i].stop();
        //}
        //
        //playingSounds.Clear();
    }

    public void LoadAllSounds()
    {
        string filePath;
        filePath = Engine.GetStreamingAssetsPath();

        for (int i = 0; i < DefineConstants.NUM_SOUNDS; i++)
        {
            if (GlobalMembers.sounds[i] == null || GlobalMembers.sounds[i].Length == 0)
                continue;

            string sound_name = filePath + "sound/" + GlobalMembers.sounds[i];

            LoadSoundVOC(sound_name, i);
        }
    }

    void Update()
    {
        for(int i = 0; i < playingSounds.Count; i++)
        {
            if (playingSounds[i].spriteIndex != -1)
            {
                ATTRIBUTES_3D fmodLocation = FMODUnity.RuntimeUtils.To3DAttributes(Engine.board.sprite[playingSounds[i].spriteIndex].currentRenderGameObject);
                playingSounds[i].fmodChannel.set3DAttributes(ref fmodLocation.position, ref fmodLocation.velocity);
            }

            if (!playingSounds[i].isPlaying)
            {
                GlobalMembers.Sound[playingSounds[i].soundIndex].num--;

                if (GlobalMembers.Sound[playingSounds[i].soundIndex].num < 0)
                    GlobalMembers.Sound[playingSounds[i].soundIndex].num = 0;

                playingSounds.RemoveAt(i);
            }
        }
    }

    public void PlaySound3D(int index, int spriteindex)
    {
        if (!newClips[index].isLoaded)
            return;

        if (Engine.board.sprite[spriteindex].currentRenderGameObject == null)
        {
            PlaySound(index);
            return;
        }

        DukeChannel channel = new DukeChannel();
        FMOD.ChannelGroup masterChannelGroup;
        RuntimeManager.CoreSystem.getMasterChannelGroup(out masterChannelGroup);

        RuntimeManager.CoreSystem.playSound(newClips[index].FMODSound, masterChannelGroup, false, out channel.fmodChannel);

        ATTRIBUTES_3D fmodLocation = FMODUnity.RuntimeUtils.To3DAttributes(Engine.board.sprite[spriteindex].currentRenderGameObject);
        channel.fmodChannel.set3DAttributes(ref fmodLocation.position, ref fmodLocation.velocity);
        channel.fmodChannel.set3DMinMaxDistance(20.0f, 100.0f);
        channel.fmodChannel.setUserData((System.IntPtr)index);

        channel.soundIndex = index;
        channel.spriteIndex = spriteindex;

        playingSounds.Add(channel);

        GlobalMembers.Sound[index].num++;
    }

    public void PlaySound(int index, int volume = 105, int pan = 0)
    {
        if (!newClips[index].isLoaded)
            return;

        DukeChannel channel = new DukeChannel();
        FMOD.ChannelGroup masterChannelGroup;
        RuntimeManager.CoreSystem.getMasterChannelGroup(out masterChannelGroup);

        RuntimeManager.CoreSystem.playSound(newClips[index].FMODSound, masterChannelGroup, false, out channel.fmodChannel);

        if (volume > 105)
            volume = 105;

        float vol = ((float)volume) / ((float)105.0f);

        channel.fmodChannel.setVolume(vol);
        channel.fmodChannel.setUserData((System.IntPtr)index);

        channel.soundIndex = index;
        channel.spriteIndex = -1;

        playingSounds.Add(channel);
        GlobalMembers.Sound[index].num++;
    }

    public void PlayMusic(int volumeNumber, int levelNumber)
    {
        int x = volumeNumber;
        int y = levelNumber;

        string filePath;
        filePath = Engine.GetStreamingAssetsPath();


        if (GlobalMembers.music_fn[x, y] == null || GlobalMembers.music_fn[x, y].Length == 0)
            return;

        if(musicClip != null && musicClip.FMODSound.handle != System.IntPtr.Zero)
            musicClip.FMODSound.release();

        string music_name = filePath + "music/" + GlobalMembers.music_fn[x, y];
        LoadSoundMID(music_name, x, y);
     
        musicChannel.stop();

        FMOD.ChannelGroup masterChannelGroup;
        RuntimeManager.CoreSystem.getMasterChannelGroup(out masterChannelGroup);

        RuntimeManager.CoreSystem.playSound(musicClip.FMODSound, masterChannelGroup, false, out musicChannel);
    }
}
