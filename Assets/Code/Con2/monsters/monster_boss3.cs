public partial class ConScript
{

    static ConAction ABOSS3WALK = new ConAction(0, 4, 5, 1, 30);
    static ConAction ABOSS3FROZEN = new ConAction(0, 1, 5);
    static ConAction ABOSS3RUN = new ConAction(0, 4, 5, 1, 15);
    static ConAction ABOSS3LOB = new ConAction(20, 4, 5, 1, 50);
    static ConAction ABOSS3LOBBING = new ConAction(30, 2, 5, 1, 15);
    static ConAction ABOSS3DYING = new ConAction(40, 8, 1, 1, 20);
    static ConAction BOSS3FLINTCH = new ConAction(40, 1, 1, 1, 1);
    static ConAction ABOSS3DEAD = new ConAction(48);
    static MoveAction PALBOSS3SHRUNKRUNVELS = new MoveAction(32);
    static MoveAction PALBOSS3RUNVELS = new MoveAction(84);
    static MoveAction BOSS3WALKVELS = new MoveAction(208);
    static MoveAction BOSS3RUNVELS = new MoveAction(270);
    static MoveAction BOSS3STOPPED = new MoveAction();
    static AIAction AIBOSS3SEEKENEMY = new AIAction(ABOSS3WALK, BOSS3WALKVELS, seekplayer);
    static AIAction AIBOSS3RUNENEMY = new AIAction(ABOSS3RUN, BOSS3RUNVELS, faceplayerslow);
    static AIAction AIBOSS3LOBENEMY = new AIAction(ABOSS3LOB, BOSS3STOPPED, faceplayer);
    static AIAction AIBOSS3DYING = new AIAction(ABOSS3DYING, BOSS3STOPPED, faceplayer);
    static AIAction AIBOSS3PALSHRINK = new AIAction(ABOSS3WALK, PALBOSS3SHRUNKRUNVELS, faceplayer);
    private void boss3palshrunkstate()
    {
        if (traps.ifcount(SHRUNKDONECOUNT))
            traps.Ai(AITROOPSEEKENEMY);
        else
        if (traps.ifcount(SHRUNKCOUNT))
            traps.sizeto(40, 40);
        else
            genericshrunkcode();
    }
    private void checkboss3seekstate()
    {
        traps.Ai(AIBOSS3SEEKENEMY);
        if (traps.ifspritepal(0))
        {
        }
        else
            traps.Move(PALBOSS3RUNVELS, seekplayer);
    }
    private void boss3runenemystate()
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
                    traps.Ai(AIBOSS3SEEKENEMY);
            }
        }
        else
            traps.Ai(AIBOSS3SEEKENEMY);
    }
    private void boss3seekenemystate()
    {
        if (traps.ifrnd(2))
            traps.soundonce(BOS3_ROAM);
        else
        if (traps.ifactioncount(3))
        {
            traps.resetactioncount();
            traps.sound(BOS1_WALK);
        }
        if (traps.ifcansee())
            if (traps.ifcount(32))
                if (traps.ifrnd(48))
                    if (traps.ifcanshoottarget())
                    {
                        if (traps.ifrnd(64))
                            if (traps.ifpdistg(4096))
                            {
                                traps.Ai(AIBOSS3RUNENEMY);
                                if (traps.ifspritepal(0))
                                    return;
                                traps.Move(PALBOSS3RUNVELS, seekplayer);
                                return;
                            }
                        if (traps.ifp(palive))
                            traps.Ai(AIBOSS3LOBENEMY);
                    }
    }
    private void boss3dyingstate()
    {
        if (traps.ifaction(ABOSS3DEAD))
        {
            if (traps.ifspritepal(0))
                return;
            if (traps.ifrespawn())
                if (traps.ifcount(RESPAWNACTORTIME))
                {
                    traps.spawn(TRANSPORTERSTAR);
                    traps.cstat(257);
                    traps.strength(PIGCOPSTRENGTH);
                    checkboss3seekstate();
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
            traps.SetAction(ABOSS3DEAD);
            traps.cstat(0);
            if (traps.ifspritepal(0))
                traps.endofgame(52);
        }
    }
    private void boss3lobbedstate()
    {
        if (traps.ifcansee())
        {
            if (traps.ifaction(ABOSS3LOBBING))
                if (traps.ifactioncount(2))
                {
                    traps.shoot(RPG);
                    traps.resetactioncount();
                    if (traps.ifrnd(8))
                        traps.Ai(AIBOSS3SEEKENEMY);
                }
            if (traps.ifactioncount(3))
            {
                traps.SetAction(ABOSS3LOBBING);
                traps.resetcount();
            }
        }
        else
            checkboss3seekstate();
    }
    private void checkboss3hitstate()
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
                    traps.SetAction(ABOSS3FROZEN);
                    traps.strength(0);
                    return;
                }
            }
            traps.addkills(1);
            traps.Ai(AIBOSS3DYING);
            traps.sound(BOS3_DYING);
            traps.sound(JIBBED_ACTOR9);
        }
        else
        {
            if (traps.ifrnd(32))
            {
                traps.SetAction(BOSS3FLINTCH);
                traps.Move(0);
            }
            if (traps.ifspritepal(0))
            {
            }
            else
            if (traps.ifwasweapon(SHRINKSPARK))
            {
                traps.sound(ACTOR_SHRINKING);
                traps.Ai(AIBOSS3PALSHRINK);
                return;
            }
            traps.soundonce(BOS3_PAIN);
            traps.debris(SCRAP1, 1);
            traps.guts(JIBS6, 1);
        }
    }
    private void boss3code()
    {
        if (traps.ifaction(ABOSS3FROZEN))
        {
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
                traps.Ai(AIBOSS3RUNENEMY);
            else
            {
                traps.strength(1);
                traps.Ai(AIBOSS3LOBENEMY);
            }
        }
        else
        if (traps.ifaction(BOSS3FLINTCH))
        {
            if (traps.ifactioncount(3))
                traps.Ai(AIBOSS3SEEKENEMY);
        }
        else
        if (traps.ifai(AIBOSS3SEEKENEMY))
            boss3seekenemystate();
        else
        if (traps.ifai(AIBOSS3RUNENEMY))
            boss3runenemystate();
        else
        if (traps.ifai(AIBOSS3LOBENEMY))
            boss3lobbedstate();
        else
        if (traps.ifai(AIBOSS3PALSHRINK))
            boss3palshrunkstate();
        if (traps.ifai(AIBOSS3DYING))
            boss3dyingstate();
        else
        {
            if (traps.ifhitweapon())
                checkboss3hitstate();
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
    private void A_BOSS3()
    {
        traps.fall();
        boss3code();
    }
}