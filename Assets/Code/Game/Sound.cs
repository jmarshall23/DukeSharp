using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class GlobalMembers
{
    public static int SoundToggle = 1;
    public static int AmbienceToggle = 1;
    public static int numenvsnds = 0;
    public static int NumVoices = 32;

    public enum FX_ERRORS
    {
        FX_Warning = -2,
        FX_Error = -1,
        FX_Ok = 0,
        FX_ASSVersion,
        FX_BlasterError,
        FX_SoundCardError,
        FX_InvalidCard,
        FX_MultiVocError,
        FX_DPMI_Error
    }

    public static void testcallback(int index)
    {

    }

    public static void FX_StopSound(int index)
    {

    }

    public static void MUSIC_StopSong()
    {

    }

    public static void spritesound(int index)
    {

    }

    public static short spritesound(int index, int spriteindex)
    {
        return 0;
    }

    public static void stopsound(int index)
    {

    }

    public static int xyzsound(short num, short i, long x, long y, long z)
    {
        return 0;
    }

    public static void sound(int x)
    {

    }

    public static void FX_SetReverb(int reverb)
    {

    }

    public static void FX_SetReverbDelay(int delay)
    {

    }

    public static int FX_VoiceAvailable(int priority)
    {
        return 1;
    }

    public static void stopenvsound(int num, int i)
    {

    }

    public static void FX_StopAllSounds()
    {

    }

    public static void clearsoundlocks()
    {

    }

    public static void playmusic(string s)
    {

    }
}