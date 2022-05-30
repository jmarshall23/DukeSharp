public partial class ConScript
{

    static ConAction AOCTAWALK = new ConAction(0, 3, 5, 1, 15);
    static ConAction AOCTASTAND = new ConAction(0, 1, 5, 1, 15);
    static ConAction AOCTASCRATCH = new ConAction(0, 4, 5, 1, 15);
    static ConAction AOCTAHIT = new ConAction(30, 1, 1, 1, 10);
    static ConAction AOCTASHOOT = new ConAction(20, 1, 5, 1, 10);
    static ConAction AOCTADYING = new ConAction(30, 8, 1, 1, 17);
    static ConAction AOCTADEAD = new ConAction(38, 1, 1, 1, 1);
    static ConAction AOCTAFROZEN = new ConAction(0, 1, 5);
    static MoveAction OCTAWALKVELS = new MoveAction(96, -30);
    static MoveAction OCTAUPVELS = new MoveAction(96, -70);
    static MoveAction OCTASTOPPED = new MoveAction(0, -30);
    static MoveAction OCTAINWATER = new MoveAction(96, 24);
    static AIAction AIOCTAGETENEMY = new AIAction(AOCTAWALK, OCTAWALKVELS, seekplayer);
    static AIAction AIOCTASHOOTENEMY = new AIAction(AOCTASHOOT, OCTASTOPPED, faceplayer);
    static AIAction AIOCTASCRATCHENEMY = new AIAction(AOCTASCRATCH, OCTASTOPPED, faceplayerslow);
    static AIAction AIOCTAHIT = new AIAction(AOCTAHIT, OCTASTOPPED, faceplayer);
    static AIAction AIOCTASHRUNK = new AIAction(AOCTAWALK, SHRUNKVELS, faceplayer);
    static AIAction AIOCTAGROW = new AIAction(AOCTASTAND, OCTASTOPPED, faceplayerslow);
    static AIAction AIOCTADYING = new AIAction(AOCTADYING, OCTASTOPPED, faceplayer);
    private void octagetenemystate()
    {
        if (traps.ifcansee())
        {
            if (traps.ifactioncount(32))
            {
                if (traps.ifrnd(48))
                    if (traps.ifcanshoottarget())
                    {
                        traps.sound(OCTA_ATTACK1);
                        traps.Ai(AIOCTASHOOTENEMY);
                        return;
                    }
            }
            else
        if (traps.ifpdistl(1280))
                traps.Ai(AIOCTASCRATCHENEMY);
        }
    }
    private void octascratchenemystate()
    {
        if (traps.ifpdistg(1280))
            traps.Ai(AIOCTAGETENEMY);
        else
            if (traps.ifcount(32))
        {
            traps.resetcount();
            traps.sound(OCTA_ATTACK2);
            traps.palfrom(8, 32);
            traps.addphealth(OCTASCRATCHINGPLAYER);
        }
    }
    private void octashootenemystate()
    {
        if (traps.ifcount(25))
        {
            if (traps.ifcount(27))
                traps.Ai(AIOCTAGETENEMY);
        }
        else
        if (traps.ifcount(24))
            traps.shoot(COOLEXPLOSION1);
        else
        if (traps.ifactioncount(6))
            traps.resetactioncount();
    }
    private void checkoctahitstate()
    {
        if (traps.ifwasweapon(SHRINKSPARK))
        {
            traps.sound(ACTOR_SHRINKING);
            traps.Ai(AIOCTASHRUNK);
        }
        else
        {
            if (traps.ifdead())
            {
                if (traps.ifwasweapon(FREEZEBLAST))
                {
                    traps.sound(SOMETHINGFROZE);
                    traps.spritepal(1);
                    traps.Move(0);
                    traps.SetAction(AOCTAFROZEN);
                    traps.strength(0);
                    return;
                }
                traps.addkills(1);
                if (traps.ifwasweapon(RPG))
                {
                    traps.sound(SQUISHED);
                    standard_jibs();
                    traps.killit();
                }
                else
                if (traps.ifwasweapon(RADIUSEXPLOSION))
                {
                    traps.sound(SQUISHED);
                    standard_jibs();
                    traps.killit();
                }
                else
                if (traps.ifwasweapon(GROWSPARK))
                {
                    traps.cstat(0);
                    traps.sound(ACTOR_GROWING);
                    traps.Ai(AIOCTAGROW);
                    return;
                }
                else
                {
                    rf();
                    traps.Ai(AIOCTADYING);
                }
                traps.sound(OCTA_DYING);
            }
            else
            {
                if (traps.ifwasweapon(RPG))
                {
                    traps.sound(OCTA_DYING);
                    traps.addkills(1);
                    standard_jibs();
                    traps.killit();
                }
                else
                if (traps.ifwasweapon(GROWSPARK))
                    traps.sound(EXPANDERHIT);
                traps.sound(OCTA_PAIN);
                traps.spawn(BLOOD);
                if (traps.ifrnd(64))
                    traps.Ai(AIOCTAHIT);
            }
        }
        random_wall_jibs();
    }
    private void octashrunkstate()
    {
        if (traps.ifcount(SHRUNKDONECOUNT))
            traps.Ai(AILIZGETENEMY);
        else
        if (traps.ifcount(SHRUNKCOUNT))
            traps.sizeto(40, 40);
        else
            genericshrunkcode();
    }
    private void octadyingstate()
    {
        if (traps.ifactioncount(8))
        {
            if (traps.ifrnd(64))
                traps.spawn(BLOODPOOL);
            traps.Move(OCTASTOPPED);
            traps.SetAction(AOCTADEAD);
            return;
        }
        else
        if (traps.ifactioncount(5))
        {
        }
        else
        if (traps.ifactioncount(4))
            if (traps.iffloordistl(8))
                traps.sound(THUD);
    }
    private void A_OCTABRAINSTAYPUT()
    {
        traps.Ai(AIOCTAGETENEMY);
        traps.cactor(OCTABRAIN);
    }
    private void A_OCTABRAIN()
    {
        traps.fall();
        checksquished();
        if (traps.ifai(null))
            traps.Ai(AIOCTAGETENEMY);
        else
        if (traps.ifaction(AOCTADEAD))
        {
            traps.strength(0);
            if (traps.ifcount(RESPAWNACTORTIME))
                if (traps.ifrespawn())
                {
                    traps.addkills(-1);
                    traps.spawn(TRANSPORTERSTAR);
                    traps.cstat(257);
                    traps.strength(OCTASTRENGTH);
                    traps.Ai(AIOCTAGETENEMY);
                }
            if (traps.ifhitweapon())
                if (traps.ifwasweapon(RADIUSEXPLOSION))
                {
                    standard_jibs();
                    traps.killit();
                }
            return;
        }
        else
        if (traps.ifaction(AOCTAFROZEN))
        {
            if (traps.ifcount(THAWTIME))
            {
                traps.Ai(AIOCTAGETENEMY);
                traps.getlastpal();
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
                traps.addkills(1);
                if (traps.ifwasweapon(FREEZEBLAST))
                {
                    traps.strength(0);
                    return;
                }
                traps.lotsofglass(30);
                if (traps.ifrnd(84))
                    traps.spawn(BLOODPOOL);
                traps.sound(GLASS_BREAKING);
                traps.killit();
            }
            if (traps.ifp(pfacing))
                if (traps.ifpdistl(FROZENQUICKKICKDIST))
                    traps.pkick();
            return;
        }
        else
        {
            if (traps.ifrnd(1))
                traps.soundonce(OCTA_ROAM);
            if (traps.ifai(AIOCTAGETENEMY))
                octagetenemystate();
            else
            if (traps.ifai(AIOCTAHIT))
            {
                if (traps.ifcount(8))
                    traps.Ai(AIOCTASHOOTENEMY);
            }
            else
            if (traps.ifai(AIOCTADYING))
            {
                octadyingstate();
                return;
            }
            else
            if (traps.ifai(AIOCTASCRATCHENEMY))
                octascratchenemystate();
            else
            if (traps.ifai(AIOCTASHOOTENEMY))
                octashootenemystate();
            else
            if (traps.ifai(AIOCTASHRUNK))
            {
                octashrunkstate();
                return;
            }
            else
            if (traps.ifai(AIOCTAGROW))
                genericgrowcode();
            if (traps.ifmove(OCTAUPVELS))
            {
            }
            else
            if (traps.ifp(phigher))
                traps.Move(OCTAUPVELS, seekplayer);
            else
            if (traps.ifmove(OCTAINWATER))
            {
            }
            else
            if (traps.ifinwater())
                traps.Move(OCTAINWATER, seekplayer);
            if (traps.ifhitweapon())
                checkoctahitstate();
        }
    }
}