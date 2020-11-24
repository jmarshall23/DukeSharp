public partial class ConScript
{

    public const int TANKSTRENGTH = 500;
    static ConAction ATANKSPIN = new ConAction(0, 1, 7, 1, 4);
    static ConAction ATANKSHOOTING = new ConAction(7, 2, 7, 1, 10);
    static ConAction ATANKWAIT = new ConAction(0, 1, 7, 1, 1);
    static ConAction ATANKDESTRUCT = new ConAction(0, 1, 7, 1, 1);
    static ConAction ATANKDEAD = new ConAction(0, 1, 7, 1, 1);
    static MoveAction TANKFORWARD = new MoveAction(100);
    static MoveAction TANKSTOP = new MoveAction();
    private void A_TANK()
    {
        traps.fall();
        if (traps.ifaction(null))
        {
            traps.sizeat(60, 60);
            traps.SetAction(ATANKWAIT);
            traps.cstat(257);
            traps.clipdist(100);
        }
        else
        if (traps.ifaction(ATANKSPIN))
        {
            traps.soundonce(TANK_ROAM);
            if (traps.ifactioncount(20))
            {
                if (traps.ifrnd(16))
                    if (traps.ifcansee())
                        if (traps.ifcanshoottarget())
                        {
                            traps.Move(TANKSTOP, geth);
                            traps.SetAction(ATANKSHOOTING);
                            traps.stopsound(TANK_ROAM);
                        }
            }
            if (traps.ifrnd(16))
                traps.Move(TANKFORWARD, seekplayer);
        }
        else
        if (traps.ifaction(ATANKSHOOTING))
        {
            if (traps.ifactioncount(22))
            {
                if (traps.ifpdistg(8192))
                {
                    traps.sound(BOS1_ATTACK2);
                    traps.shoot(MORTER);
                }
                traps.resetcount();
                traps.Move(0);
                traps.SetAction(ATANKWAIT);
            }
            else
            if (traps.ifactioncount(2))
            {
                if (traps.ifcansee())
                {
                    if (traps.ifpdistl(16384))
                    {
                        if (traps.ifrnd(128))
                        {
                            traps.sound(PISTOL_FIRE);
                            traps.shoot(SHOTSPARK1);
                        }
                    }
                    else
                        if (traps.ifrnd(128))
                    {
                        traps.sound(PRED_ATTACK);
                        traps.shoot(FIRELASER);
                    }
                }
                else
                {
                    traps.Move(TANKFORWARD, seekplayer);
                    traps.SetAction(ATANKSPIN);
                }
            }
            if (traps.ifrnd(16))
            {
                traps.stopsound(TANK_ROAM);
                traps.Move(TANKSTOP, faceplayerslow);
            }
        }
        else
        if (traps.ifaction(ATANKWAIT))
        {
            if (traps.ifactioncount(32))
            {
                traps.Move(TANKFORWARD, seekplayer);
                traps.SetAction(ATANKSPIN);
            }
        }
        else
        if (traps.ifaction(ATANKDESTRUCT))
        {
            if (traps.ifactioncount(64))
                traps.SetAction(ATANKDEAD);
            else
            if (traps.ifactioncount(56))
                traps.sound(LASERTRIP_ARMING);
            else
            if (traps.ifactioncount(48))
                traps.sound(LASERTRIP_ARMING);
            else
            if (traps.ifactioncount(32))
                traps.sound(LASERTRIP_ARMING);
            else
            if (traps.ifactioncount(16))
                traps.sound(LASERTRIP_ARMING);
            return;
        }
        else
        if (traps.ifaction(ATANKDEAD))
        {
            traps.addkills(1);
            traps.hitradius(6144, TOUGH, TOUGH, TOUGH, TOUGH);
            traps.sound(LASERTRIP_EXPLODE);
            traps.debris(SCRAP1, 15);
            traps.spawn(EXPLOSION2);
            if (traps.ifrnd(128))
                traps.spawn(PIGCOP);
            traps.killit();
        }
        if (traps.ifhitweapon())
        {
            if (traps.ifdead())
                traps.SetAction(ATANKDEAD);
            else
            {
                traps.debris(SCRAP1, 1);
                if (traps.ifaction(ATANKSHOOTING))
                    return;
                if (traps.ifrnd(192))
                {
                    traps.Move(TANKSTOP, geth);
                    traps.SetAction(ATANKSHOOTING);
                    traps.stopsound(TANK_ROAM);
                }
            }
        }
        if (traps.ifpdistl(1280))
            if (traps.ifhitspace())
                if (traps.ifp(pfacing))
                    if (traps.ifangdiffl(512))
                        traps.SetAction(ATANKDESTRUCT);
    }
}