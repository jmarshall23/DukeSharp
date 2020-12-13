public partial class ConScript
{
    public bool wallswitchcheck(int picnum)
    {
        switch (picnum)
        {
            case HANDPRINTSWITCH:
            case HANDPRINTSWITCH + 1:
            case ALIENSWITCH:
            case ALIENSWITCH + 1:
            case MULTISWITCH:
            case MULTISWITCH + 1:
            case MULTISWITCH + 2:
            case MULTISWITCH + 3:
            case ACCESSSWITCH:
            case ACCESSSWITCH2:
            case PULLSWITCH:
            case PULLSWITCH + 1:
            case HANDSWITCH:
            case HANDSWITCH + 1:
            case SLOTDOOR:
            case SLOTDOOR + 1:
            case LIGHTSWITCH:
            case LIGHTSWITCH + 1:
            case SPACELIGHTSWITCH:
            case SPACELIGHTSWITCH + 1:
            case SPACEDOORSWITCH:
            case SPACEDOORSWITCH + 1:
            case FRANKENSTINESWITCH:
            case FRANKENSTINESWITCH + 1:
            case LIGHTSWITCH2:
            case LIGHTSWITCH2 + 1:
            case POWERSWITCH1:
            case POWERSWITCH1 + 1:
            case LOCKSWITCH1:
            case LOCKSWITCH1 + 1:
            case POWERSWITCH2:
            case POWERSWITCH2 + 1:
            case DIPSWITCH:
            case DIPSWITCH + 1:
            case DIPSWITCH2:
            case DIPSWITCH2 + 1:
            case TECHSWITCH:
            case TECHSWITCH + 1:
            case DIPSWITCH3:
            case DIPSWITCH3 + 1:
                return true;
        }
        return false;
    }
    public bool isadoorwall(short dapic)
    {
        switch (dapic)
        {
            case DOORTILE1:
            case DOORTILE2:
            case DOORTILE3:
            case DOORTILE4:
            case DOORTILE5:
            case DOORTILE6:
            case DOORTILE7:
            case DOORTILE8:
            case DOORTILE9:
            case DOORTILE10:
            case DOORTILE11:
            case DOORTILE12:
            case DOORTILE14:
            case DOORTILE15:
            case DOORTILE16:
            case DOORTILE17:
            case DOORTILE18:
            case DOORTILE19:
            case DOORTILE20:
            case DOORTILE21:
            case DOORTILE22:
            case DOORTILE23:
                return true;
        }
        return false;
    }
}