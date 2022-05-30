public partial class ConScript
{

    static ConAction APIGWALK = new ConAction(0, 4, 5, 1, 20);
    static ConAction APIGRUN = new ConAction(0, 4, 5, 1, 11);
    static ConAction APIGSHOOT = new ConAction(30, 2, 5, 1, 58);
    static ConAction APIGCOCK = new ConAction(25, 1, 5, 1, 16);
    static ConAction APIGSTAND = new ConAction(30, 1, 5, 1, 1);
    static ConAction APIGDIVE = new ConAction(40, 2, 5, 1, 40);
    static ConAction APIGDIVESHOOT = new ConAction(45, 2, 5, 1, 58);
    static ConAction APIGDYING = new ConAction(55, 5, 1, 1, 15);
    static ConAction APIGHIT = new ConAction(55, 1, 1, 1, 10);
    static ConAction APIGDEAD = new ConAction(60, 1, 1, 1, 1);
    static ConAction APIGFROZEN = new ConAction(0, 1, 5);
    static ConAction APIGGROW = new ConAction(0);
    static MoveAction PIGWALKVELS = new MoveAction(72);
    static MoveAction PIGRUNVELS = new MoveAction(108);
    static MoveAction PIGSTOPPED = new MoveAction();
    static AIAction AIPIGSEEKENEMY = new AIAction(APIGWALK, PIGWALKVELS, seekplayer);
    static AIAction AIPIGSHOOTENEMY = new AIAction(APIGSHOOT, PIGSTOPPED, faceplayer);
    static AIAction AIPIGFLEEENEMY = new AIAction(APIGWALK, PIGWALKVELS, fleeenemy);
    static AIAction AIPIGSHOOT = new AIAction(APIGSHOOT, PIGSTOPPED, faceplayer);
    static AIAction AIPIGDODGE = new AIAction(APIGRUN, PIGRUNVELS, dodgebullet);
    static AIAction AIPIGCHARGE = new AIAction(APIGRUN, PIGRUNVELS, seekplayer);
    static AIAction AIPIGDIVING = new AIAction(APIGDIVE, PIGSTOPPED, faceplayer);
    static AIAction AIPIGDYING = new AIAction(APIGDYING, PIGSTOPPED, faceplayer);
    static AIAction AIPIGSHRINK = new AIAction(APIGWALK, SHRUNKVELS, fleeenemy);
    static AIAction AIPIGGROW = new AIAction(APIGGROW, PIGSTOPPED, faceplayerslow);
    static AIAction AIPIGHIT = new AIAction(APIGHIT, PIGSTOPPED, faceplayer);
    private void pigseekenemystate()
    {
        if (traps.ifai(AIPIGCHARGE))
        {
            if (traps.ifcansee())
                if (traps.ifpdistl(3084))
                {
                    if (traps.ifnotmoving())
                        traps.Ai(AIPIGSEEKENEMY);
                    else
                        traps.Ai(AIPIGDIVING);
                }
            return;
        }
        else
        if (traps.iffloordistl(32))
        {
            if (traps.ifpdistg(4096))
            {
                if (traps.ifactornotstayput())
                    traps.Ai(AIPIGCHARGE);
            }
            if (traps.ifrnd(8))
            {
                if (traps.ifbulletnear())
                    traps.Ai(AIPIGDODGE);
            }
        }
        if (traps.ifrnd(128))
            if (traps.ifcansee())
            {
                if (traps.ifai(AIPIGDODGE))
                {
                    if (traps.ifcount(32))
                        traps.Ai(AIPIGCHARGE);
                    return;
                }
                if (traps.iffloordistl(32))
                {
                    if (traps.ifpdistl(1024))
                        if (traps.ifp(palive))
                            if (traps.ifcanshoottarget())
                            {
                                traps.Ai(AIPIGSHOOTENEMY);
                                return;
                            }
                    if (traps.ifcount(48))
                    {
                        if (traps.ifrnd(8))
                            if (traps.ifp(palive))
                                if (traps.ifcanshoottarget())
                                {
                                    if (traps.ifrnd(192))
                                        traps.Ai(AIPIGSHOOTENEMY);
                                    else
                                        traps.Ai(AIPIGDIVING);
                                    return;
                                }
                    }
                }
            }
    }
    private void pigshootenemystate()
    {
        {
            if (traps.ifcount(12))
            {
            }
            else
            if (traps.ifcount(11))
            {
                if (traps.ifcanshoottarget())
                {
                    traps.sound(PIG_ATTACK);
                    traps.shoot(SHOTGUN);
                    traps.shoot(SHOTGUN);
                    traps.shoot(SHOTGUN);
                    traps.shoot(SHOTGUN);
                    traps.shoot(SHOTGUN);
                }
                else
                    traps.Ai(AIPIGSEEKENEMY);
            }
            if (traps.ifcount(25))
            {
            }
            else
            if (traps.ifcount(24))
            {
                traps.SetAction(APIGCOCK);
                traps.sound(SHOTGUN_COCK);
            }
            if (traps.ifcount(48))
            {
            }
            else
            if (traps.ifcount(47))
            {
                if (traps.ifcanshoottarget())
                {
                    traps.sound(PIG_ATTACK);
                    traps.shoot(SHOTGUN);
                    traps.shoot(SHOTGUN);
                    traps.shoot(SHOTGUN);
                    traps.shoot(SHOTGUN);
                    traps.shoot(SHOTGUN);
                }
                else
                    traps.Ai(AIPIGSEEKENEMY);
            }
            if (traps.ifcount(60))
            {
            }
            else
            if (traps.ifcount(59))
            {
                traps.SetAction(APIGCOCK);
                traps.sound(SHOTGUN_COCK);
            }
            if (traps.ifcount(72))
            {
                if (traps.ifrnd(64))
                    traps.resetcount();
                else
                {
                    if (traps.ifpdistl(768))
                        traps.Ai(AIPIGFLEEENEMY);
                    else
                        traps.Ai(AIPIGSEEKENEMY);
                }
            }
            if (traps.ifaction(APIGCOCK))
                if (traps.ifactioncount(2))
                    traps.SetAction(APIGSHOOT);
        }
    }
    private void pigfleeenemystate()
    {
        if (traps.ifactioncount(8))
            traps.Ai(AIPIGSEEKENEMY);
        else
        if (traps.ifnotmoving())
            traps.Ai(AIPIGSEEKENEMY);
    }
    private void pigdivestate()
    {
        if (traps.ifaction(APIGDIVESHOOT))
        {
            if (traps.ifcansee())
            {
                if (traps.ifcount(12))
                {
                }
                else
                if (traps.ifcount(11))
                {
                    if (traps.ifcanshoottarget())
                    {
                        traps.sound(PIG_ATTACK);
                        traps.shoot(SHOTGUN);
                        traps.shoot(SHOTGUN);
                        traps.shoot(SHOTGUN);
                        traps.shoot(SHOTGUN);
                    }
                    else
                        traps.Ai(AIPIGSEEKENEMY);
                }
                if (traps.ifcount(25))
                {
                }
                else
                if (traps.ifcount(24))
                    traps.sound(SHOTGUN_COCK);
                if (traps.ifcount(48))
                {
                }
                else
                if (traps.ifcount(47))
                {
                    if (traps.ifcanshoottarget())
                    {
                        traps.sound(PIG_ATTACK);
                        traps.shoot(SHOTGUN);
                        traps.shoot(SHOTGUN);
                        traps.shoot(SHOTGUN);
                        traps.shoot(SHOTGUN);
                    }
                    else
                        traps.Ai(AIPIGSEEKENEMY);
                }
                if (traps.ifcount(60))
                {
                }
                else
                if (traps.ifcount(59))
                {
                    traps.sound(SHOTGUN_COCK);
                    if (traps.ifgapzl(32))
                        traps.Ai(AIPIGDIVING);
                    else
                    {
                        if (traps.ifpdistl(4096))
                            traps.Ai(AIPIGFLEEENEMY);
                        else
                            traps.Ai(AIPIGSEEKENEMY);
                    }
                }
            }
            else
                if (traps.ifgapzl(32))
                traps.Ai(AIPIGDIVING);
            else
                traps.Ai(AIPIGSEEKENEMY);
        }
        else
        if (traps.ifactioncount(2))
            if (traps.ifp(palive))
            {
                traps.resetcount();
                traps.SetAction(APIGDIVESHOOT);
            }
    }
    private void checkpighitstate()
    {
        traps.spawn(BLOOD);
        if (traps.ifdead())
        {
            random_wall_jibs();
            if (traps.ifrnd(16))
                traps.spawn(SHIELD);
            else
                drop_shotgun();
            if (traps.ifwasweapon(GROWSPARK))
            {
                traps.sound(ACTOR_GROWING);
                traps.Ai(AIPIGGROW);
                return;
            }
            traps.addkills(1);
            if (traps.ifwasweapon(FREEZEBLAST))
            {
                traps.sound(SOMETHINGFROZE);
                traps.spritepal(1);
                traps.Move(0);
                traps.SetAction(APIGFROZEN);
                traps.strength(0);
                return;
            }
            if (traps.ifwasweapon(RADIUSEXPLOSION))
            {
                traps.sound(SQUISHED);
                standard_jibs();
                traps.killit();
            }
            else
            if (traps.ifwasweapon(RPG))
            {
                traps.sound(SQUISHED);
                standard_jibs();
                traps.killit();
            }
            else
                traps.Ai(AIPIGDYING);
            traps.sound(PIG_DYING);
        }
        else
        {
            traps.sound(PIG_PAIN);
            random_wall_jibs();
            if (traps.ifwasweapon(SHRINKSPARK))
            {
                traps.sound(ACTOR_SHRINKING);
                traps.Ai(AIPIGSHRINK);
            }
            else
            if (traps.ifwasweapon(GROWSPARK))
                traps.sound(EXPANDERHIT);
            else
            if (traps.ifrnd(32))
                traps.Ai(AIPIGHIT);
            else
            if (traps.ifrnd(64))
                traps.Ai(AIPIGSHOOTENEMY);
            else
            if (traps.ifrnd(64))
            {
                traps.Ai(AIPIGDIVING);
                traps.SetAction(APIGDIVESHOOT);
            }
        }
    }
    private void pigshrinkstate()
    {
        if (traps.ifcount(SHRUNKDONECOUNT))
            traps.Ai(AIPIGSEEKENEMY);
        else
        if (traps.ifcount(SHRUNKCOUNT))
            traps.sizeto(48, 40);
        else
            genericshrunkcode();
    }
    private void pigdyingstate()
    {
        if (traps.ifactioncount(5))
        {
            if (traps.ifrnd(64))
                traps.spawn(BLOODPOOL);
            rf();
            if (traps.iffloordistl(8))
                traps.sound(THUD);
            traps.SetAction(APIGDEAD);
            traps.Move(PIGSTOPPED);
            return;
        }
    }
    private void A_PIGCOPDIVE()
    {
        traps.Ai(AIPIGDIVING);
        traps.SetAction(APIGDIVESHOOT);
        traps.cactor(PIGCOP);
    }
    private void A_PIGCOPSTAYPUT()
    {
        traps.Ai(AIPIGSEEKENEMY);
        traps.cactor(PIGCOP);
    }
    private void A_PIGCOP()
    {
        traps.fall();
        checksquished();
        if (traps.ifaction(APIGSTAND))
            traps.Ai(AIPIGSEEKENEMY);
        else
        if (traps.ifaction(APIGDEAD))
        {
            if (traps.ifrespawn())
                if (traps.ifcount(RESPAWNACTORTIME))
                {
                    traps.spawn(TRANSPORTERSTAR);
                    traps.cstat(257);
                    traps.strength(PIGCOPSTRENGTH);
                    traps.Ai(AIPIGSEEKENEMY);
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
        else
        if (traps.ifaction(APIGFROZEN))
        {
            if (traps.ifcount(THAWTIME))
            {
                traps.Ai(AIPIGSEEKENEMY);
                traps.getlastpal();
            }
            else
            if (traps.ifcount(FROZENDRIPTIME))
                if (traps.ifrnd(8))
                    traps.spawn(WATERDRIP);
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
        else
        if (traps.ifai(AIPIGDYING))
            pigdyingstate();
        else
        if (traps.ifai(AIPIGHIT))
        {
            if (traps.ifactioncount(3))
                traps.Ai(AIPIGSEEKENEMY);
        }
        else
        if (traps.ifai(AIPIGSHRINK))
            pigshrinkstate();
        else
        {
            if (traps.ifai(AIPIGSEEKENEMY))
                pigseekenemystate();
            else
            if (traps.ifai(AIPIGDODGE))
                pigseekenemystate();
            else
            if (traps.ifai(AIPIGSHOOTENEMY))
                pigshootenemystate();
            else
            if (traps.ifai(AIPIGGROW))
                genericgrowcode();
            else
            if (traps.ifai(AIPIGFLEEENEMY))
                pigfleeenemystate();
            else
            if (traps.ifai(AIPIGDIVING))
                pigdivestate();
            else
            if (traps.ifai(AIPIGCHARGE))
                pigseekenemystate();
            if (traps.ifhitweapon())
                checkpighitstate();
            if (traps.ifrnd(1))
            {
                if (traps.ifrnd(32))
                    traps.soundonce(PIG_ROAM);
                else
                if (traps.ifrnd(64))
                    traps.soundonce(PIG_ROAM2);
                else
                    traps.soundonce(PIG_ROAM3);
            }
        }
    }
}