public partial class ConScript
{

    static ConAction DRONEFRAMES = new ConAction(0, 1, 7, 1, 1);
    static ConAction DRONESCREAM = new ConAction(0, 1, 7, 1, 1);
    static MoveAction DRONERUNVELS = new MoveAction(128, 64);
    static MoveAction DRONERUNUPVELS = new MoveAction(128, -64);
    static MoveAction DRONEBULLVELS = new MoveAction(252, -64);
    static MoveAction DRONEBACKWARDS = new MoveAction(-64, -64);
    static MoveAction DRONERISE = new MoveAction(32, -32);
    static MoveAction DRONESTOPPED = new MoveAction(-16);
    static AIAction AIDRONEGETE = new AIAction(DRONESCREAM, DRONERUNVELS, faceplayerslow, getv);
    static AIAction AIDRONEWAIT = new AIAction(DRONEFRAMES, DRONESTOPPED, faceplayerslow);
    static AIAction AIDRONEGETUP = new AIAction(DRONESCREAM, DRONERUNUPVELS, faceplayer, getv);
    static AIAction AIDRONEPULLBACK = new AIAction(DRONEFRAMES, DRONEBACKWARDS, faceplayerslow);
    static AIAction AIDRONEHIT = new AIAction(DRONESCREAM, DRONEBACKWARDS, faceplayer);
    static AIAction AIDRONESHRUNK = new AIAction(DRONEFRAMES, SHRUNKVELS, fleeenemy);
    static AIAction AIDRONEDODGE = new AIAction(DRONEFRAMES, DRONEBULLVELS, dodgebullet, geth);
    static AIAction AIDRONEDODGEUP = new AIAction(DRONEFRAMES, DRONERISE, getv, geth);
    private void dronedead()
    {
        traps.addkills(1);
        traps.debris(SCRAP1, 8);
        traps.debris(SCRAP2, 4);
        traps.debris(SCRAP3, 7);
        traps.spawn(EXPLOSION2);
        traps.sound(RPG_EXPLODE);
        traps.hitradius(2048, 15, 20, 25, 30);
        traps.killit();
    }
    private void checkdronehitstate()
    {
        if (traps.ifdead())
            dronedead();
        else
        if (traps.ifsquished())
            dronedead();
        else
        {
            traps.sound(DRON_PAIN);
            if (traps.ifbulletnear())
            {
                if (traps.ifceilingdistl(64))
                    if (traps.ifrnd(48))
                        traps.Ai(AIDRONEDODGE);
                traps.Ai(AIDRONEDODGEUP);
            }
            else
                traps.Ai(AIDRONEGETE);
        }
    }
    private void droneshrunkstate()
    {
        if (traps.ifcount(24))
            traps.killit();
        else
            traps.sizeto(1, 1);
    }
    private void checkdronenearplayer()
    {
        if (traps.ifp(palive))
            if (traps.ifpdistl(1596))
            {
                if (traps.ifcount(8))
                {
                    traps.addkills(1);
                    traps.sound(DRON_ATTACK2);
                    traps.debris(SCRAP1, 8);
                    traps.debris(SCRAP2, 4);
                    traps.debris(SCRAP3, 7);
                    traps.spawn(EXPLOSION2);
                    traps.sound(RPG_EXPLODE);
                    traps.hitradius(2048, 15, 20, 25, 30);
                    traps.killit();
                }
                else
                if (traps.ifcount(3))
                {
                }
                else
                    traps.sound(LASERTRIP_ARMING);
            }
    }
    private void dronegetstate()
    {
        if (traps.ifrnd(192))
        {
            if (traps.ifcansee())
            {
                if (traps.ifbulletnear())
                {
                    traps.Ai(AIDRONEDODGE);
                    return;
                }
                if (traps.ifmove(DRONEBULLVELS))
                {
                    if (traps.ifcount(64))
                        traps.Ai(AIDRONEPULLBACK);
                    else
                    if (traps.ifnotmoving())
                        if (traps.ifcount(16))
                            traps.Ai(AIDRONEPULLBACK);
                }
                else
                if (traps.ifcount(32))
                {
                    if (traps.ifp(phigher))
                        traps.Move(DRONEBULLVELS, geth, getv);
                    else
                        traps.Move(DRONEBULLVELS, geth);
                }
            }
            else
                if (traps.ifrnd(1))
                traps.operate();
        }
    }
    private void dronedodgestate()
    {
        if (traps.ifai(AIDRONEDODGEUP))
        {
            if (traps.ifcount(8))
                traps.Ai(AIDRONEGETE);
            else
            if (traps.ifnotmoving())
                traps.Ai(AIDRONEGETE);
        }
        else
        {
            if (traps.ifcount(8))
                traps.Ai(AIDRONEGETE);
            else
            if (traps.ifnotmoving())
                traps.Ai(AIDRONEGETE);
        }
    }
    private void A_DRONE()
    {
        checkdronenearplayer();
        if (traps.ifrnd(2))
            traps.fall();
        else
            traps.soundonce(DRON_JETSND);
        if (traps.ifaction(null))
            traps.Ai(AIDRONEGETE);
        else
        if (traps.ifai(AIDRONEWAIT))
        {
            if (traps.ifactioncount(4))
                if (traps.ifrnd(16))
                    if (traps.ifcansee())
                    {
                        traps.sound(DRON_ATTACK1);
                        if (traps.ifp(phigher))
                            traps.Ai(AIDRONEGETUP);
                        else
                            traps.Ai(AIDRONEGETE);
                    }
        }
        else
        if (traps.ifai(AIDRONEGETE))
            dronegetstate();
        else
        if (traps.ifai(AIDRONEGETUP))
            dronegetstate();
        else
        if (traps.ifai(AIDRONEPULLBACK))
        {
            if (traps.ifcount(32))
                traps.Ai(AIDRONEWAIT);
        }
        else
        if (traps.ifai(AIDRONEHIT))
        {
            if (traps.ifcount(8))
                traps.Ai(AIDRONEWAIT);
        }
        else
        if (traps.ifai(AIDRONESHRUNK))
            droneshrunkstate();
        else
        if (traps.ifai(AIDRONEDODGE))
            dronedodgestate();
        else
        if (traps.ifai(AIDRONEDODGEUP))
            dronedodgestate();
        if (traps.ifhitweapon())
            checkdronehitstate();
        if (traps.ifrnd(1))
            traps.soundonce(DRON_ROAM);
    }
}