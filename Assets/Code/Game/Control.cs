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
using Build;
using UnityEngine;


//***************************************************************************
//
// TYPEDEFS
//
//***************************************************************************
public enum axisdirection
{
    axis_up,
    axis_down,
    axis_left,
    axis_right
}

public enum analogcontrol
{
    analog_turning = 0,
    analog_strafing = 1,
    analog_lookingupanddown = 2,
    analog_elevation = 3,
    analog_rolling = 4,
    analog_moving = 5,
    analog_maxtype
}

public enum direction
{
    dir_North,
    dir_NorthEast,
    dir_East,
    dir_SouthEast,
    dir_South,
    dir_SouthWest,
    dir_West,
    dir_NorthWest,
    dir_None
}

public class UserInput
{
    public bool button0 = new bool();
    public bool button1 = new bool();
    public direction dir;
}

public class ControlInfo
{
    public int dx = 0;
    public int dy = 0;
    public int dz = 0;
    public int dyaw = 0;
    public int dpitch = 0;
    public int droll = 0;
}

public enum controltype
{
    controltype_keyboard,
    controltype_keyboardandmouse,
    controltype_keyboardandjoystick,
    controltype_keyboardandexternal,
    controltype_keyboardandgamepad,
    controltype_keyboardandflightstick,
    controltype_keyboardandthrustmaster
}

public partial class GlobalMembers
{
    public static bool anyKeyDown = false;
    public static ControlInfo minfo = new ControlInfo();

    public static int CONTROL_GetMouseSensitivity()
    {
        return 0;
    }

    public static void KB_FlushKeyboardQueue()
    {
        anyKeyDown = false;
        for (int i = 0; i < KB_KeyDown.Length; i++)
            KB_KeyDown[i] = false;
    }

    public static void CONTROL_DefineFlag(int which, bool toggle)
    {

    }

    public static int KB_KeyWaiting()
    {
        if (anyKeyDown)
            return 1;

        return 0;
    }
}