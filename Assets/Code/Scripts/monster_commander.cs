public partial class ConScript
{

    static ConAction ACOMMBREETH = new ConAction(0, 3, 5, 1, 40);
    static ConAction ACOMMFROZEN = new ConAction(0, 1, 5);
    static ConAction ACOMMSPIN = new ConAction(-5, 1, 5, 1, 12);
    static ConAction ACOMMGET = new ConAction(0, 3, 5, 1, 30);
    static ConAction ACOMMSHOOT = new ConAction(20, 1, 5, 1, 35);
    static ConAction ACOMMABOUTTOSHOOT = new ConAction(20, 1, 5, 1, 30);
    static ConAction ACOMMDYING = new ConAction(30, 8, 1, 1, 12);
    static ConAction ACOMMDEAD = new ConAction(38, 1, 1, 1, 1);
    static MoveAction COMMGETUPVELS = new MoveAction(128, -64);
    static MoveAction COMMGETVELS = new MoveAction(128, 64);
    static MoveAction COMMSLOW = new MoveAction(64, 24);
    static MoveAction COMMSTOPPED = new MoveAction();
    static AIAction AICOMMWAIT = new AIAction(ACOMMBREETH, COMMSTOPPED, faceplayerslow);
    static AIAction AICOMMGET = new AIAction(ACOMMGET, COMMGETVELS, seekplayer);
    static AIAction AICOMMSHOOT = new AIAction(ACOMMSHOOT, COMMSTOPPED, faceplayerslow);
    static AIAction AICOMMABOUTTOSHOOT = new AIAction(ACOMMABOUTTOSHOOT, COMMSTOPPED, faceplayerslow);
    static AIAction AICOMMSPIN = new AIAction(ACOMMSPIN, COMMGETVELS, spin);
    static AIAction AICOMMDYING = new AIAction(ACOMMDYING, COMMSTOPPED, faceplayer);
    static AIAction AICOMMSHRUNK = new AIAction(ACOMMGET, COMMSLOW, furthestdir);
    static AIAction AICOMMGROW = new AIAction(ACOMMGET, COMMSTOPPED, furthestdir);
    private void checkcommhitstate()
    {
        if (traps.ifhitweapon())
        {
            traps.guts(JIBS6, 2);
            if (traps.ifdead())
            {
                if (traps.ifwasweapon(FREEZEBLAST))
                {
                    traps.sound(SOMETHINGFROZE);
                    traps.spritepal(1);
                    traps.Move(0);
                    traps.SetAction(ACOMMFROZEN);
                    traps.strength(0);
                    return;
                }
                else
                if (traps.ifwasweapon(GROWSPARK))
                {
                    traps.sound(ACTOR_GROWING);
                    traps.Ai(AICOMMGROW);
                    return;
                }
                traps.addkills(1);
                if (traps.ifwasweapon(RADIUSEXPLOSION))
                {
                    traps.spawn(BLOODPOOL);
                    traps.sound(SQUISHED);
                    standard_jibs();
                    traps.killit();
                }
                else
                if (traps.ifwasweapon(RPG))
                {
                    traps.sound(SQUISHED);
                    traps.spawn(BLOODPOOL);
                    standard_jibs();
                    traps.killit();
                }
                traps.sound(COMM_DYING);
                traps.Ai(AICOMMDYING);
            }
            else
            {
                traps.soundonce(COMM_PAIN);
                if (traps.ifwasweapon(SHRINKSPARK))
                {
                    traps.sound(ACTOR_SHRINKING);
                    traps.Ai(AICOMMSHRUNK);
                }
                else
                if (traps.ifwasweapon(GROWSPARK))
                    traps.sound(EXPANDERHIT);
                else
                if (traps.ifrnd(24))
                    traps.Ai(AICOMMABOUTTOSHOOT);
            }
        }
    }
    private void A_COMMANDERSTAYPUT()
    {
        traps.cactor(COMMANDER);
        traps.Ai(AICOMMABOUTTOSHOOT);
    }
    private void A_COMMANDER()
    {
        checksquished();
        if (traps.ifaction(ACOMMFROZEN))
        {
            traps.fall();
            if (traps.ifcount(THAWTIME))
            {
                traps.getlastpal();
                traps.Ai(AICOMMWAIT);
            }
            else
            if (traps.ifcount(FROZENDRIPTIME))
            {
                if (traps.ifactioncount(26))
                {
                    traps.spawn(WATERDRIP);
                    traps.resetactioncount();
                }
            }
            if (traps.ifhitweapon())
            {
                if (traps.ifwasweapon(FREEZEBLAST))
                {
                    traps.strength(0);
                    return;
                }
                traps.addkills(1);
                if (traps.ifrnd(84))
                    traps.spawn(BLOODPOOL);
                traps.lotsofglass(30);
                traps.sound(GLASS_BREAKING);
                traps.killit();
            }
            if (traps.ifp(pfacing))
                if (traps.ifpdistl(FROZENQUICKKICKDIST))
                    traps.pkick();
            return;
        }
        if (traps.ifai(null))
            traps.Ai(AICOMMSHOOT);
        else
        if (traps.ifai(AICOMMWAIT))
        {
            if (traps.ifcount(20))
            {
                if (traps.ifcansee())
                {
                    if (traps.ifcanshoottarget())
                    {
                        if (traps.ifrnd(96))
                            traps.Ai(AICOMMGET);
                        else
                            traps.Ai(AICOMMABOUTTOSHOOT);
                    }
                }
                else
                    traps.Ai(AICOMMGET);
            }
        }
        else
        if (traps.ifai(AICOMMABOUTTOSHOOT))
        {
            if (traps.ifactioncount(2))
            {
                if (traps.ifcansee())
                    traps.Ai(AICOMMSHOOT);
                else
                {
                    traps.Ai(AICOMMGET);
                    return;
                }
            }
            if (traps.ifrnd(32))
                traps.soundonce(COMM_ATTACK);
        }
        else
        if (traps.ifai(AICOMMSHOOT))
        {
            if (traps.ifcanshoottarget())
            {
                if (traps.ifcount(24))
                    if (traps.ifrnd(16))
                        traps.Ai(AICOMMWAIT);
                if (traps.ifactioncount(2))
                {
                    traps.shoot(RPG);
                    traps.resetactioncount();
                }
            }
            else
                traps.Ai(AICOMMGET);
        }
        else
        if (traps.ifai(AICOMMSHRUNK))
        {
            if (traps.ifcount(SHRUNKDONECOUNT))
                traps.Ai(AICOMMGET);
            else
            if (traps.ifcount(SHRUNKCOUNT))
                traps.sizeto(48, 40);
            else
                genericshrunkcode();
        }
        else
        if (traps.ifai(AICOMMGROW))
            genericgrowcode();
        else
        if (traps.ifai(AICOMMGET))
        {
            if (traps.ifnotmoving())
                if (traps.ifrnd(4))
                    traps.operate();
            if (traps.ifpdistl(1024))
                if (traps.ifp(palive))
                {
                    traps.sound(COMM_SPIN);
                    traps.Ai(AICOMMSPIN);
                    return;
                }
            if (traps.ifcansee())
            {
                if (traps.ifp(phigher))
                    traps.Move(COMMGETUPVELS, getv, geth, faceplayer);
                else
                    traps.Move(COMMGETVELS, getv, geth, faceplayer);
            }
            if (traps.ifactioncount(8))
                if (traps.ifrnd(2))
                    traps.Ai(AICOMMABOUTTOSHOOT);
        }
        else
        if (traps.ifai(AICOMMSPIN))
        {
            traps.soundonce(COMM_SPIN);
            if (traps.ifcount(16))
            {
                if (traps.ifpdistl(1280))
                {
                    traps.addphealth(CAPTSPINNINGPLAYER);
                    traps.sound(DUKE_GRUNT);
                    traps.palfrom(32, 16);
                    traps.resetcount();
                }
                else
                if (traps.ifpdistg(2300))
                    traps.Ai(AICOMMWAIT);
            }
            if (traps.ifactioncount(52))
                traps.Ai(AICOMMWAIT);
            if (traps.ifnotmoving())
                if (traps.ifrnd(32))
                    traps.operate();
        }
        if (traps.ifai(AICOMMDYING))
        {
            traps.fall();
            traps.strength(0);
            if (traps.ifhitweapon())
                if (traps.ifwasweapon(RADIUSEXPLOSION))
                {
                    traps.sound(SQUISHED);
                    traps.spawn(BLOODPOOL);
                    standard_jibs();
                    traps.killit();
                }
            if (traps.ifaction(ACOMMDYING))
                if (traps.ifactioncount(8))
                {
                    if (traps.iffloordistl(8))
                        traps.sound(THUD);
                    traps.cstat(0);
                    traps.SetAction(ACOMMDEAD);
                }
        }
        else
        {
            if (traps.ifrnd(2))
                traps.soundonce(COMM_ROAM);
            checkcommhitstate();
        }
    }
}