//-------------------------------------------------------------------------
/*
Copyright (c) 2020 - Blackenmace Studios LLC
Copyright (C) 1996, 2003 - 3D Realms Entertainment

This file is part of the Duke Nukem 3D C# Source Port
This file is part of Duke Nukem 3D version 1.5 - Atomic Edition

Duke Nukem 3D is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  

See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

C# Port Conversion: 2020 - Justin Marshall
Original Source: 1996 - Todd Replogle
Prepared for public release: 03/21/2003 - Charlie Wiederhold, 3D Realms
*/
//-------------------------------------------------------------------------

using UnityEngine;
using Build;

public partial class GlobalMembers 
{
    public static int SoundToggle = 1;
    public static int AmbienceToggle = 1;
    public static int numenvsnds = 0;
    public static int NumVoices = 32;

    internal static int LOUDESTVOLUME = 150;

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

    public static void pan3dsound()
    {

    }

    public static void intomenusounds()
    {

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
        SoundEngine.globalSoundEngine.PlaySound(index);
    }

    public static short spritesound(int index, int spriteindex)
    {
        xyzsound((short)index, (short)spriteindex, Engine.board.sprite[spriteindex].x, Engine.board.sprite[spriteindex].y, Engine.board.sprite[spriteindex].z);
        return 0;
    }

    public static void stopsound(int index)
    {

    }

    public static int xyzsound(short num, short i, long x, long y, long z)
    {
        int sndist, cx, cy, cz, j, k;
        short pitche, pitchs, cs;
        int voice, sndang, ca, pitch;

        cx = ps[screenpeek].oposx;
        cy = ps[screenpeek].oposy;
        cz = ps[screenpeek].oposz;
        cs = ps[screenpeek].cursectnum;
        ca = ps[screenpeek].ang + ps[screenpeek].look_ang;

        sndist = Engine.FindDistance3D((int)(cx - x), (int)(cy - y), (int)((cz - z) >> 4));

        if (i >= 0 && (soundm[num] & 16) == 0 && Engine.board.sprite[i].picnum == ConScript.MUSICANDSFX && Engine.board.sprite[i].lotag < 999 && (Engine.board.sector[Engine.board.sprite[i].sectnum].lotag & 0xff) < 9)
            sndist = pragmas.divscale14(sndist, (Engine.board.sprite[i].hitag + 1));

        pitchs = soundps[num];
        pitche = soundpe[num];
        cx = pragmas.klabs(pitche - pitchs);

        if (cx != 0)
        {
            if (pitchs < pitche)
                pitch = (int)(pitchs + (Engine.krand() % cx));
            else pitch = (int)(pitche + (Engine.krand() % cx));
        }
        else pitch = pitchs;

        sndist += soundvo[num];
        if (sndist < 0) sndist = 0;
        if (sndist != 0 && Engine.board.sprite[i].picnum != ConScript.MUSICANDSFX && !Engine.board.cansee(cx, cy, cz - (24 << 8), cs, Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].z - (24 << 8), Engine.board.sprite[i].sectnum))
            sndist += sndist >> 5;

        switch (num)
        {
            case ConScript.PIPEBOMB_EXPLODE:
            case ConScript.LASERTRIP_EXPLODE:
            case ConScript.RPG_EXPLODE:
                if (sndist > (6144))
                    sndist = 6144;
                if (Engine.board.sector[ps[screenpeek].cursectnum].lotag == 2)
                    pitch -= 1024;
                break;
            default:
                if (Engine.board.sector[ps[screenpeek].cursectnum].lotag == 2 && (soundm[num] & 4) == 0)
                    pitch = -768;
                if (sndist > 31444 && Engine.board.sprite[i].picnum != ConScript.MUSICANDSFX)
                    return -1;
                break;
        }


        if (Sound[num].num > 0 && Engine.board.sprite[i].picnum != ConScript.MUSICANDSFX)
        {
            if (SoundOwner[num, 0] != null && SoundOwner[num,0].i == i) stopsound(num);
            else if (Sound[num].num > 1) stopsound(num);
            else if (badguy(Engine.board.sprite[i]) != 0 && Engine.board.sprite[i].extra <= 0) stopsound(num);
        }

        if (Engine.board.sprite[i].picnum == ConScript.APLAYER && Engine.board.sprite[i].yvel == screenpeek)
        {
            sndang = 0;
            sndist = 0;
        }
        else
        {
            sndang = 2048 + ca - Engine.getangle((int)(cx - x), (int)(cy - y));
            sndang &= 2047;
        }

        if ((soundm[num] & 16) != 0) sndist = 0;

        if (sndist < ((255 - LOUDESTVOLUME) << 6))
            sndist = ((255 - LOUDESTVOLUME) << 6);

        SoundEngine.globalSoundEngine.PlaySound(num, sndist >> 6, sndang >> 6);
        return 0;
    }

    public static void sound(int x)
    {
        SoundEngine.globalSoundEngine.PlaySound(x);
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
        SoundEngine.globalSoundEngine.StopAllSounds();
    }

    public static void clearsoundlocks()
    {

    }

    public static void playmusic(int volumeNumber, int levelNumber)
    {
        SoundEngine.globalSoundEngine.PlayMusic(volumeNumber, levelNumber);
    }
}