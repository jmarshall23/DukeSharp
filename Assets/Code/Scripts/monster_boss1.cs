public partial class ConScript
{

    static ConAction ABOSS1WALK = new ConAction(0, 4, 5, 1, 12);
    static ConAction ABOSS1FROZEN = new ConAction(30, 1, 5);
    static ConAction ABOSS1RUN = new ConAction(0, 6, 5, 1, 5);
    static ConAction ABOSS1SHOOT = new ConAction(30, 2, 5, 1, 4);
    static ConAction ABOSS1LOB = new ConAction(40, 2, 5, 1, 35);
    static ConAction ABOSS1DYING = new ConAction(50, 5, 1, 1, 35);
    static ConAction BOSS1FLINTCH = new ConAction(50, 1, 1, 1, 1);
    static ConAction ABOSS1DEAD = new ConAction(55);
    static MoveAction PALBOSS1SHRUNKRUNVELS = new MoveAction(32);
    static MoveAction PALBOSS1RUNVELS = new MoveAction(128);
    static MoveAction BOSS1WALKVELS = new MoveAction(208);
    static MoveAction BOSS1RUNVELS = new MoveAction(296);
    static MoveAction BOSS1STOPPED = new MoveAction();
    static AIAction AIBOSS1SEEKENEMY = new AIAction(ABOSS1WALK, BOSS1WALKVELS, seekplayer);
    static AIAction AIBOSS1RUNENEMY = new AIAction(ABOSS1RUN, BOSS1RUNVELS, faceplayer);
    static AIAction AIBOSS1SHOOTENEMY = new AIAction(ABOSS1SHOOT, BOSS1STOPPED, faceplayer);
    static AIAction AIBOSS1LOBBED = new AIAction(ABOSS1LOB, BOSS1STOPPED, faceplayer);
    static AIAction AIBOSS1DYING = new AIAction(ABOSS1DYING, BOSS1STOPPED, faceplayer);
    static AIAction AIBOSS1PALSHRINK = new AIAction(ABOSS1WALK, PALBOSS1SHRUNKRUNVELS, furthestdir);
    private void boss1palshrunkstate()
    {
        if (traps.ifcount(SHRUNKDONECOUNT))
            traps.Ai(AITROOPSEEKENEMY);
        else
        if (traps.ifcount(SHRUNKCOUNT))
            traps.sizeto(40, 40);
        else
            genericshrunkcode();
    }
    private void checkboss1seekstate()
    {
        traps.Ai(AIBOSS1SEEKENEMY);
        if (traps.ifspritepal(0))
        {
        }
        else
            traps.Move(PALBOSS1RUNVELS, seekplayer);
    }
    private void boss1runenemystate()
    {
        if (traps.ifpdistl(2048))
        {
            if (traps.ifp(palive))
                traps.Ai(AIBOSS1SHOOTENEMY);
            return;
        }
        else
        if (traps.ifcansee())
        {
            if (traps.ifactioncount(6))
            {
                if (traps.ifcanshoottarget())
                {
                    traps.resetactioncount();
                    traps.sound(BOS1_WALK);
                }
                else
                    traps.Ai(AIBOSS1SEEKENEMY);
            }
        }
        else
            traps.Ai(AIBOSS1SEEKENEMY);
    }
    private void boss1seekenemystate()
    {
        if (traps.ifrnd(2))
            traps.soundonce(BOS1_ROAM);
        else
        if (traps.ifactioncount(6))
        {
            traps.resetactioncount();
            traps.sound(BOS1_WALK);
        }
        if (traps.ifpdistl(2548))
            if (traps.ifp(palive))
            {
                traps.Ai(AIBOSS1SHOOTENEMY);
                return;
            }
        if (traps.ifcansee())
            if (traps.ifcount(32))
            {
                if (traps.ifrnd(32))
                {
                    if (traps.ifp(palive))
                        if (traps.ifcanshoottarget())
                            traps.Ai(AIBOSS1SHOOTENEMY);
                }
                else
            if (traps.ifpdistg(2548))
                    if (traps.ifrnd(192))
                        if (traps.ifcanshoottarget())
                        {
                            if (traps.ifrnd(64))
                            {
                                traps.Ai(AIBOSS1RUNENEMY);
                                if (traps.ifspritepal(0))
                                {
                                }
                                else
                                    traps.Move(PALBOSS1RUNVELS, seekplayer);
                            }
                            else
                                traps.Ai(AIBOSS1LOBBED);
                        }
            }
    }
    private void boss1dyingstate()
    {
        if (traps.ifaction(ABOSS1DEAD))
        {
            if (traps.ifspritepal(0))
                return;
            if (traps.ifrespawn())
                if (traps.ifcount(RESPAWNACTORTIME))
                {
                    traps.spawn(TRANSPORTERSTAR);
                    traps.cstat(257);
                    traps.strength(PIGCOPSTRENGTH);
                    checkboss1seekstate();
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
        if (traps.ifactioncount(5))
        {
            if (traps.iffloordistl(8))
                traps.sound(THUD);
            traps.SetAction(ABOSS1DEAD);
            traps.cstat(0);
            if (traps.ifspritepal(0))
                traps.endofgame(52);
        }
    }
    private void boss1lobbedstate()
    {
        if (traps.ifcansee())
        {
            if (traps.ifactioncount(2))
            {
                traps.resetactioncount();
                traps.sound(BOS1_ATTACK2);
                traps.shoot(MORTER);
            }
            else
            if (traps.ifcount(64))
                if (traps.ifrnd(16))
                    checkboss1seekstate();
        }
        else
            checkboss1seekstate();
    }
    private void boss1shootenemy()
    {
        if (traps.ifcount(72))
            checkboss1seekstate();
        else
        if (traps.ifaction(ABOSS1SHOOT))
            if (traps.ifactioncount(2))
            {
                traps.sound(BOS1_ATTACK1);
                traps.shoot(SHOTSPARK1);
                traps.shoot(SHOTSPARK1);
                traps.shoot(SHOTSPARK1);
                traps.shoot(SHOTSPARK1);
                traps.shoot(SHOTSPARK1);
                traps.shoot(SHOTSPARK1);
                traps.resetactioncount();
            }
    }
    private void checkboss1hitstate()
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
                    traps.SetAction(ABOSS1FROZEN);
                    traps.strength(0);
                    return;
                }
            }
            traps.sound(BOS1_DYING);
            traps.addkills(1);
            traps.Ai(AIBOSS1DYING);
        }
        else
        {
            if (traps.ifrnd(32))
            {
                traps.SetAction(BOSS1FLINTCH);
                traps.Move(0);
            }
            if (traps.ifspritepal(0))
            {
            }
            else
            if (traps.ifwasweapon(SHRINKSPARK))
            {
                traps.sound(ACTOR_SHRINKING);
                traps.Ai(AIBOSS1PALSHRINK);
                traps.cstat(0);
                return;
            }
            traps.soundonce(BOS1_PAIN);
            traps.debris(SCRAP1, 1);
            traps.guts(JIBS6, 1);
        }
    }
    private void boss1code()
    {
        if (traps.ifaction(ABOSS1FROZEN))
        {
            if (traps.ifcount(THAWTIME))
            {
                traps.Ai(AIBOSS1SEEKENEMY);
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
        if (traps.ifai(null))
        {
            if (traps.ifspritepal(0))
                traps.Ai(AIBOSS1RUNENEMY);
            else
            {
                traps.strength(BOSS1PALSTRENGTH);
                traps.Ai(AIBOSS1SHOOTENEMY);
            }
        }
        else
        if (traps.ifaction(BOSS1FLINTCH))
        {
            if (traps.ifactioncount(3))
                traps.Ai(AIBOSS1SHOOTENEMY);
        }
        else
        if (traps.ifai(AIBOSS1SEEKENEMY))
            boss1seekenemystate();
        else
        if (traps.ifai(AIBOSS1RUNENEMY))
            boss1runenemystate();
        else
        if (traps.ifai(AIBOSS1SHOOTENEMY))
            boss1shootenemy();
        else
        if (traps.ifai(AIBOSS1LOBBED))
            boss1lobbedstate();
        else
        if (traps.ifai(AIBOSS1PALSHRINK))
            boss1palshrunkstate();
        if (traps.ifai(AIBOSS1DYING))
            boss1dyingstate();
        else
        {
            if (traps.ifhitweapon())
                checkboss1hitstate();
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
    private void A_BOSS1STAYPUT()
    {
        traps.cactor(BOSS1);
    }
    private void A_BOSS1()
    {
        traps.fall();
        boss1code();
    }
}