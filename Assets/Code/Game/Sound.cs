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

    public static void pan3dsound()
    {

    }

    public static void intomenusounds()
    {

    }

    public static void PlayMusic(string song)
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