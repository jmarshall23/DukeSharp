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