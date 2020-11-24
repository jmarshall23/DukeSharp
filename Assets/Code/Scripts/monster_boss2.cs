public partial class ConScript
{

    static ConAction ABOSS2WALK = new ConAction(0, 4, 5, 1, 30);
    static ConAction ABOSS2FROZEN = new ConAction(0, 1, 5);
    static ConAction ABOSS2RUN = new ConAction(0, 4, 5, 1, 15);
    static ConAction ABOSS2SHOOT = new ConAction(20, 2, 5, 1, 15);
    static ConAction ABOSS2LOB = new ConAction(30, 2, 5, 1, 105);
    static ConAction ABOSS2DYING = new ConAction(40, 8, 1, 1, 35);
    static ConAction BOSS2FLINTCH = new ConAction(40, 1, 1, 1, 1);
    static ConAction ABOSS2DEAD = new ConAction(48);
    static MoveAction PALBOSS2SHRUNKRUNVELS = new MoveAction(32);
    static MoveAction PALBOSS2RUNVELS = new MoveAction(84);
    static MoveAction BOSS2WALKVELS = new MoveAction(192);
    static MoveAction BOSS2RUNVELS = new MoveAction(256);
    static MoveAction BOSS2STOPPED = new MoveAction();
    static AIAction AIBOSS2SEEKENEMY = new AIAction(ABOSS2WALK, BOSS2WALKVELS, seekplayer);
    static AIAction AIBOSS2RUNENEMY = new AIAction(ABOSS2RUN, BOSS2RUNVELS, faceplayer);
    static AIAction AIBOSS2SHOOTENEMY = new AIAction(ABOSS2SHOOT, BOSS2STOPPED, faceplayer);
    static AIAction AIBOSS2LOBBED = new AIAction(ABOSS2LOB, BOSS2STOPPED, faceplayer);
    static AIAction AIBOSS2DYING = new AIAction(ABOSS2DYING, BOSS2STOPPED, faceplayer);
    static AIAction AIBOSS2PALSHRINK = new AIAction(ABOSS2WALK, PALBOSS2SHRUNKRUNVELS, furthestdir);
    private void boss2palshrunkstate()
    {
        if (traps.ifcount(SHRUNKDONECOUNT))
        {
            traps.cstat(257);
            traps.Ai(AITROOPSEEKENEMY);
        }
        else
        if (traps.ifcount(SHRUNKCOUNT))
            traps.sizeto(40, 40);
        else
            genericshrunkcode();
    }
    private void checkboss2seekstate()
    {
        traps.Ai(AIBOSS2SEEKENEMY);
        if (traps.ifspritepal(0))
        {
        }
        else
            traps.Move(PALBOSS2RUNVELS, seekplayer);
    }
    private void boss2runenemystate()
    {
        if (traps.ifcansee())
        {
            if (traps.ifactioncount(3))
            {
                if (traps.ifcanshoottarget())
                {
                    traps.resetactioncount();
                    traps.sound(BOS1_WALK);
                }
                else
                    traps.Ai(AIBOSS2SEEKENEMY);
            }
            if (traps.ifcount(48))
                if (traps.ifrnd(2))
                {
                    if (traps.ifp(palive))
                    {
                        traps.sound(BOS2_ATTACK);
                        traps.Ai(AIBOSS2SHOOTENEMY);
                    }
                    return;
                }
        }
        else
            traps.Ai(AIBOSS2SEEKENEMY);
    }
    private void boss2seekenemystate()
    {
        if (traps.ifrnd(2))
            traps.soundonce(BOS2_ROAM);
        else
        if (traps.ifactioncount(3))
        {
            traps.resetactioncount();
            traps.sound(BOS1_WALK);
        }
        if (traps.ifcansee())
            if (traps.ifcount(32))
                if (traps.ifp(palive))
                    if (traps.ifrnd(48))
                        if (traps.ifcanshoottarget())
                        {
                            if (traps.ifrnd(64))
                                if (traps.ifpdistg(4096))
                                {
                                    traps.Ai(AIBOSS2RUNENEMY);
                                    if (traps.ifspritepal(0))
                                    {
                                    }
                                    else
                                        traps.Move(PALBOSS2RUNVELS, seekplayer);
                                    return;
                                }
                            if (traps.ifpdistl(10240))
                            {
                                if (traps.ifrnd(128))
                                {
                                    traps.sound(BOS2_ATTACK);
                                    traps.Ai(AIBOSS2LOBBED);
                                }
                            }
                            else
                            {
                                traps.sound(BOS2_ATTACK);
                                traps.Ai(AIBOSS2SHOOTENEMY);
                            }
                        }
    }
    private void boss2dyingstate()
    {
        if (traps.ifaction(ABOSS2DEAD))
        {
            if (traps.ifspritepal(0))
                return;
            if (traps.ifrespawn())
                if (traps.ifcount(RESPAWNACTORTIME))
                {
                    traps.spawn(TRANSPORTERSTAR);
                    traps.cstat(257);
                    traps.strength(PIGCOPSTRENGTH);
                    checkboss2seekstate();
                }
                else
                {
                    traps.strength(0);
                    if (traps.ifhitweapon())
                        if (traps.ifwasweapon(RADIUSEXPLOSION))
                        {
                            traps.sound(SQUISHED);
                            standard_jibs();
                            traps.killit();
                        }
                    return;
                }
        }
        if (traps.ifactioncount(8))
        {
            if (traps.iffloordistl(8))
                traps.sound(THUD);
            traps.SetAction(ABOSS2DEAD);
            traps.cstat(0);
            if (traps.ifspritepal(0))
                traps.endofgame(52);
        }
    }
    private void boss2lobbedstate()
    {
        if (traps.ifcansee())
        {
            if (traps.ifactioncount(2))
                traps.resetactioncount();
            else
            if (traps.ifactioncount(1))
            {
                if (traps.ifrnd(128))
                    traps.shoot(COOLEXPLOSION1);
            }
            else
            if (traps.ifcount(64))
                if (traps.ifrnd(16))
                    checkboss2seekstate();
        }
        else
            checkboss2seekstate();
    }
    private void boss2shootenemy()
    {
        if (traps.ifcount(72))
            checkboss2seekstate();
        else
        if (traps.ifaction(ABOSS2SHOOT))
            if (traps.ifactioncount(2))
            {
                traps.shoot(RPG);
                traps.resetactioncount();
            }
    }
    private void checkboss2hitstate()
    {
        if (traps.ifrnd(2))
            traps.spawn(BLOODPOOL);
        if (traps.ifdead())
        {
            if (traps.ifspritepal(0))
                traps.globalsound(DUKE_TALKTOBOSSFALL);
            else
            {
                if (traps.ifrnd(64))
                    traps.globalsound(DUKE_TALKTOBOSSFALL);
                if (traps.ifwasweapon(FREEZEBLAST))
                {
                    traps.sound(SOMETHINGFROZE);
                    traps.spritepal(1);
                    traps.Move(0);
                    traps.SetAction(ABOSS2FROZEN);
                    traps.strength(0);
                    return;
                }
            }
            traps.sound(BOS2_DYING);
            traps.addkills(1);
            traps.Ai(AIBOSS2DYING);
        }
        else
        {
            if (traps.ifrnd(144))
            {
                if (traps.ifrnd(32))
                {
                    traps.SetAction(BOSS2FLINTCH);
                    traps.Move(0);
                }
                else
                {
                    traps.sound(BOS2_ATTACK);
                    traps.Ai(AIBOSS2SHOOTENEMY);
                }
            }
            if (traps.ifspritepal(0))
            {
            }
            else
            if (traps.ifwasweapon(SHRINKSPARK))
            {
                traps.sound(ACTOR_SHRINKING);
                traps.Ai(AIBOSS2PALSHRINK);
                return;
            }
            traps.soundonce(BOS2_PAIN);
            traps.debris(SCRAP1, 1);
            traps.guts(JIBS6, 1);
        }
    }
    private void boss2code()
    {
        if (traps.ifaction(ABOSS2FROZEN))
        {
            if (traps.ifcount(THAWTIME))
            {
                traps.Ai(AIBOSS2SEEKENEMY);
                traps.spritepal(21);
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
                traps.lotsofglass(30);
                traps.sound(GLASS_BREAKING);
                if (traps.ifrnd(84))
                    traps.spawn(BLOODPOOL);
                traps.killit();
            }
            if (traps.ifp(pfacing))
                if (traps.ifpdistl(FROZENQUICKKICKDIST))
                    traps.pkick();
            return;
        }
        if (traps.ifai(null))
        {
            if (traps.ifspritepal(0))
                traps.Ai(AIBOSS2RUNENEMY);
            else
            {
                traps.strength(1);
                traps.sound(BOS2_ATTACK);
                traps.Ai(AIBOSS2SHOOTENEMY);
            }
        }
        else
        if (traps.ifaction(BOSS2FLINTCH))
        {
            if (traps.ifactioncount(3))
                traps.Ai(AIBOSS2SEEKENEMY);
        }
        else
        if (traps.ifai(AIBOSS2SEEKENEMY))
            boss2seekenemystate();
        else
        if (traps.ifai(AIBOSS2RUNENEMY))
            boss2runenemystate();
        else
        if (traps.ifai(AIBOSS2SHOOTENEMY))
            boss2shootenemy();
        else
        if (traps.ifai(AIBOSS2LOBBED))
            boss2lobbedstate();
        else
        if (traps.ifai(AIBOSS2PALSHRINK))
            boss2palshrunkstate();
        if (traps.ifai(AIBOSS2DYING))
            boss2dyingstate();
        else
        {
            if (traps.ifhitweapon())
                checkboss2hitstate();
            else
                if (traps.ifp(palive))
                if (traps.ifspritepal(0))
                    if (traps.ifpdistl(1280))
                    {
                        traps.addphealth(-1000);
                        traps.palfrom(63, 63);
                    }
        }
    }
    private void A_BOSS2()
    {
        traps.fall();
        boss2code();
    }
}