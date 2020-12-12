public partial class ConScript
{
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