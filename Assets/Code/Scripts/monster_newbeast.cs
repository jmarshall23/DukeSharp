public partial class ConScript
{

    static ConAction ANEWBEASTSTAND = new ConAction(0);
    static ConAction ANEWBEASTWALKING = new ConAction(10, 4, 5, 1, 12);
    static ConAction ANEWBEASTRUNNING = new ConAction(10, 4, 5, 1, 8);
    static ConAction ANEWBEASTTHINK = new ConAction(0, 2, 5, 1, 40);
    static ConAction ANEWBEASTSCRATCHING = new ConAction(30, 3, 5, 1, 20);
    static ConAction ANEWBEASTDYING = new ConAction(72, 8, 1, 1, 15);
    static ConAction ANEWBEASTFLINTCH = new ConAction(71, 1, 1, 1, 1);
    static ConAction ANEWBEASTLYINGDEAD = new ConAction(79, 1, 1);
    static ConAction ANEWBEASTSCREAM = new ConAction(50, 2, 5, 1, 40);
    static ConAction ANEWBEASTJUMP = new ConAction(80, 2, 5, 1, 50);
    static ConAction ANEWBEASTFALL = new ConAction(90, 1, 5);
    static ConAction ANEWBEASTFROZEN = new ConAction(10, 1, 5);
    static ConAction ANEWBEASTHANG = new ConAction(0, 1, 5);
    private void A_NEWBEASTHANG()
    {
        if (traps.ifaction(null))
        {
            traps.SetAction(ANEWBEASTHANG);
            traps.cstator(257);
            traps.sizeat(40, 40);
        }
        else
    if (traps.ifhitweapon())
        {
            traps.cactor(NEWBEAST);
            traps.SetAction(ANEWBEASTSTAND);
            traps.sound(NEWBEAST_PAIN);
        }
        else
        if (traps.ifspawnedby(BOSS4))
            if (traps.ifcount(200))
                if (traps.ifrnd(1))
                {
                    traps.cactor(NEWBEAST);
                    traps.SetAction(ANEWBEASTSTAND);
                    traps.sound(NEWBEAST_PAIN);
                }
    }
    static ConAction ANEWBEASTHANGDEAD = new ConAction(-1, 1, 5);
    private void A_NEWBEASTHANGDEAD()
    {
        if (traps.ifaction(null))
        {
            traps.SetAction(ANEWBEASTHANGDEAD);
            traps.sizeat(40, 40);
            traps.cstator(257);
        }
        else
    if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                standard_jibs();
                traps.spawn(BLOODPOOL);
                traps.sound(SQUISHED);
                traps.killit();
            }
            else
            {
                traps.guts(JIBS6, 1);
                traps.sound(SQUISHED);
            }
        }
    }
    static MoveAction NEWBEASTWALKVEL = new MoveAction(182);
    static MoveAction NEWBEASTRUNVEL = new MoveAction(256);
    static MoveAction NEWBEASTJUMPVEL = new MoveAction(264);
    static MoveAction NEWBEASTSTOP = new MoveAction();
    static AIAction AINEWBEASTGETENEMY = new AIAction(ANEWBEASTWALKING, NEWBEASTWALKVEL, seekplayer);
    static AIAction AINEWBEASTDODGE = new AIAction(ANEWBEASTRUNNING, NEWBEASTRUNVEL, dodgebullet);
    static AIAction AINEWBEASTCHARGEENEMY = new AIAction(ANEWBEASTRUNNING, NEWBEASTRUNVEL, seekplayer);
    static AIAction AINEWBEASTFLEENEMY = new AIAction(ANEWBEASTWALKING, NEWBEASTWALKVEL, fleeenemy);
    static AIAction AINEWBEASTSCRATCHENEMY = new AIAction(ANEWBEASTSCRATCHING, NEWBEASTSTOP, faceplayerslow);
    static AIAction AINEWBEASTJUMPENEMY = new AIAction(ANEWBEASTJUMP, NEWBEASTJUMPVEL, jumptoplayer);
    static AIAction AINEWBEASTTHINK = new AIAction(ANEWBEASTTHINK, NEWBEASTSTOP);
    static AIAction AINEWBEASTGROW = new AIAction(ANEWBEASTSTAND, NEWBEASTSTOP, faceplayerslow);
    static AIAction AINEWBEASTDYING = new AIAction(ANEWBEASTDYING, NEWBEASTSTOP, faceplayer);
    static AIAction AINEWBEASTSHOOT = new AIAction(ANEWBEASTSCREAM, NEWBEASTSTOP, faceplayerslow);
    static AIAction AINEWBEASTFLINTCH = new AIAction(ANEWBEASTFLINTCH, NEWBEASTSTOP, faceplayerslow);
    private void newbeastseekstate()
    {
        if (traps.ifactornotstayput())
        {
            if (traps.ifp(palive))
                if (traps.ifcansee())
                    if (traps.ifpdistl(1596))
                    {
                        traps.Ai(AINEWBEASTSCRATCHENEMY);
                        return;
                    }
            if (traps.ifai(AINEWBEASTCHARGEENEMY))
            {
                if (traps.ifp(palive))
                    if (traps.ifpdistl(1596))
                        if (traps.ifcansee())
                        {
                            traps.Ai(AINEWBEASTSCRATCHENEMY);
                            return;
                        }
                if (traps.ifrnd(1))
                    if (traps.ifpdistg(4096))
                        if (traps.ifp(palive))
                            if (traps.ifcansee())
                            {
                                traps.Ai(AINEWBEASTSHOOT);
                                return;
                            }
            }
            else
        if (traps.ifpdistg(4096))
            {
                traps.Ai(AINEWBEASTCHARGEENEMY);
                return;
            }
            if (traps.iffloordistl(16))
            {
                if (traps.ifcount(32))
                    if (traps.ifrnd(16))
                    {
                        if (traps.ifceilingdistl(96))
                            return;
                        traps.Ai(AINEWBEASTJUMPENEMY);
                    }
                return;
            }
            if (traps.ifrnd(4))
            {
                if (traps.ifnotmoving())
                    traps.operate();
            }
            else
            if (traps.ifrnd(16))
                if (traps.ifbulletnear())
                {
                    if (traps.ifgapzl(128))
                        traps.Ai(AINEWBEASTDODGE);
                    else
                    if (traps.ifactornotstayput())
                    {
                        if (traps.ifrnd(128))
                        {
                            if (traps.ifceilingdistl(96))
                                return;
                            traps.Ai(AINEWBEASTJUMPENEMY);
                        }
                        else
                            traps.Ai(AINEWBEASTDODGE);
                    }
                }
        }
        else
        {
            if (traps.ifactioncount(16))
            {
                if (traps.ifp(palive))
                    if (traps.ifpdistl(1596))
                        if (traps.ifcansee())
                        {
                            traps.Ai(AINEWBEASTSCRATCHENEMY);
                            return;
                        }
            }
            if (traps.ifcount(16))
                if (traps.ifrnd(32))
                    traps.Move(NEWBEASTWALKVEL, randomangle, geth);
        }
    }
    private void newbeastfleestate()
    {
        if (traps.ifcount(8))
        {
            if (traps.ifrnd(64))
                if (traps.ifpdistg(3500))
                    if (traps.ifp(palive))
                        if (traps.ifcansee())
                            traps.Ai(AINEWBEASTSHOOT);
        }
        else
        {
            if (traps.iffloordistl(16))
            {
                if (traps.ifnotmoving())
                    traps.Ai(AINEWBEASTGETENEMY);
            }
            else
                traps.Ai(AINEWBEASTGETENEMY);
            return;
        }
    }
    private void newbeastthinkstate()
    {
        if (traps.ifrnd(8))
            traps.soundonce(NEWBEAST_ROAM);
        if (traps.ifactioncount(3))
        {
            if (traps.ifrnd(128))
            {
                if (traps.ifpdistg(3500))
                    if (traps.ifp(palive))
                        if (traps.ifcansee())
                            traps.Ai(AINEWBEASTSHOOT);
            }
            else
                traps.Ai(AINEWBEASTGETENEMY);
        }
        if (traps.ifrnd(16))
            if (traps.ifbulletnear())
            {
                if (traps.ifgapzl(96))
                    traps.Ai(AINEWBEASTDODGE);
                else
                {
                    if (traps.ifrnd(128))
                    {
                        if (traps.ifceilingdistl(144))
                            return;
                        traps.Ai(AINEWBEASTJUMPENEMY);
                    }
                    else
                        traps.Ai(AINEWBEASTDODGE);
                }
            }
    }
    private void newbeastscratchstate()
    {
        if (traps.ifcount(20))
            if (traps.ifrnd(8))
            {
                if (traps.ifcansee())
                    if (traps.ifpdistl(2048))
                    {
                        if (traps.ifrnd(128))
                            traps.Ai(AINEWBEASTFLEENEMY);
                        return;
                    }
                if (traps.ifrnd(80))
                    traps.Ai(AINEWBEASTTHINK);
                else
                    traps.Ai(AINEWBEASTGETENEMY);
            }
        if (traps.ifactioncount(3))
        {
            if (traps.ifpdistg(1596))
                traps.Ai(AINEWBEASTTHINK);
            else
                if (traps.ifp(palive) && traps.ifcansee())
            {
                traps.palfrom(16, 16);
                traps.addphealth(NEWBEASTSCRATCHAMOUNT);
                traps.sound(DUKE_GRUNT);
                traps.resetactioncount();
                traps.resetcount();
            }
        }
        else
        if (traps.ifcount(15))
        {
        }
        else
        if (traps.ifcount(14))
        {
            if (traps.ifpdistl(1596))
                traps.soundonce(NEWBEAST_ATTACK);
            else
                traps.soundonce(NEWBEAST_ATTACKMISS);
        }
    }
    private void checknewbeasthit()
    {
        traps.spawn(BLOOD);
        if (traps.ifdead())
        {
            if (traps.ifwasweapon(FREEZEBLAST))
            {
                traps.sound(SOMETHINGFROZE);
                traps.spritepal(1);
                traps.Move(0);
                traps.SetAction(ANEWBEASTFROZEN);
                traps.strength(0);
                return;
            }
            if (traps.ifwasweapon(GROWSPARK))
            {
                traps.cstat(0);
                traps.sound(ACTOR_GROWING);
                traps.Ai(AINEWBEASTGROW);
                return;
            }
            traps.addkills(1);
            if (traps.ifwasweapon(RPG))
            {
                traps.sound(SQUISHED);
                liz_body_jibs();
                standard_jibs();
                traps.killit();
            }
            else
            if (traps.ifwasweapon(RADIUSEXPLOSION))
            {
                traps.sound(SQUISHED);
                liz_body_jibs();
                standard_jibs();
                traps.killit();
            }
            else
            {
                rf();
                traps.Ai(AINEWBEASTDYING);
                if (traps.ifrnd(64))
                    traps.spawn(BLOODPOOL);
            }
            traps.sound(NEWBEAST_DYING);
        }
        else
        {
            traps.sound(NEWBEAST_PAIN);
            if (traps.ifwasweapon(GROWSPARK))
                traps.sound(EXPANDERHIT);
            random_wall_jibs();
            if (traps.ifrnd(32))
                traps.Ai(AINEWBEASTFLINTCH);
            else
            if (traps.ifrnd(32))
                if (traps.ifpdistg(3500))
                    if (traps.ifp(palive))
                        if (traps.ifcansee())
                            traps.Ai(AINEWBEASTSHOOT);
        }
    }
    private void newbeastjumpstate()
    {
        if (traps.ifaction(ANEWBEASTFALL))
        {
            if (traps.iffloordistl(16))
                traps.Ai(AINEWBEASTGETENEMY);
        }
        else
        if (traps.ifcount(32))
            traps.SetAction(ANEWBEASTFALL);
    }
    private void newbeastdyingstate()
    {
        if (traps.ifaction(ANEWBEASTLYINGDEAD))
        {
            traps.strength(0);
            if (traps.ifhitweapon())
                if (traps.ifwasweapon(RADIUSEXPLOSION))
                {
                    traps.sound(SQUISHED);
                    standard_jibs();
                    traps.killit();
                }
            if (traps.ifcount(RESPAWNACTORTIME))
                if (traps.ifrespawn())
                {
                    traps.spawn(TRANSPORTERSTAR);
                    traps.cstat(257);
                    traps.strength(NEWBEASTSTRENGTH);
                    traps.Ai(AINEWBEASTGETENEMY);
                }
        }
        else
        if (traps.ifai(AINEWBEASTDYING))
            if (traps.ifactioncount(7))
            {
                if (traps.iffloordistl(8))
                    traps.sound(THUD);
                traps.Move(NEWBEASTSTOP);
                traps.SetAction(ANEWBEASTLYINGDEAD);
            }
    }
    private void newbeastdodgestate()
    {
        if (traps.ifcount(13))
            traps.Ai(AINEWBEASTGETENEMY);
    }
    private void A_NEWBEASTSTAYPUT()
    {
        traps.Ai(AINEWBEASTGETENEMY);
        traps.cstator(257);
        traps.cactor(NEWBEAST);
    }
    private void A_NEWBEASTJUMP()
    {
        traps.Ai(AINEWBEASTJUMPENEMY);
        traps.cstator(257);
        traps.cactor(NEWBEAST);
    }
    private void newbeastcode()
    {
        checksquished();
        if (traps.ifai(null))
        {
            traps.cstator(257);
            traps.Ai(AINEWBEASTGETENEMY);
        }
        else
        if (traps.ifaction(ANEWBEASTLYINGDEAD))
        {
            traps.fall();
            newbeastdyingstate();
            return;
        }
        else
        if (traps.ifaction(ANEWBEASTFROZEN))
        {
            if (traps.ifcount(THAWTIME))
            {
                traps.Ai(AINEWBEASTGETENEMY);
                traps.spritepal(0);
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
        else
        if (traps.ifai(AINEWBEASTJUMPENEMY))
            newbeastjumpstate();
        else
        {
            traps.fall();
            if (traps.ifai(AINEWBEASTGETENEMY))
                newbeastseekstate();
            else
            if (traps.ifai(AINEWBEASTCHARGEENEMY))
                newbeastseekstate();
            else
            if (traps.ifai(AINEWBEASTFLINTCH))
            {
                if (traps.ifcount(8))
                    traps.Ai(AINEWBEASTGETENEMY);
            }
            else
            if (traps.ifai(AINEWBEASTDODGE))
                newbeastdodgestate();
            else
            if (traps.ifai(AINEWBEASTSCRATCHENEMY))
                newbeastscratchstate();
            else
            if (traps.ifai(AINEWBEASTFLEENEMY))
                newbeastfleestate();
            else
            if (traps.ifai(AINEWBEASTTHINK))
                newbeastthinkstate();
            else
            if (traps.ifai(AINEWBEASTGROW))
                genericgrowcode();
            else
            if (traps.ifai(AINEWBEASTDYING))
                newbeastdyingstate();
            else
            if (traps.ifai(AINEWBEASTSHOOT))
            {
                if (traps.ifp(pshrunk))
                    traps.Ai(AINEWBEASTGETENEMY);
                else
                if (traps.ifcount(26))
                    traps.Ai(AINEWBEASTGETENEMY);
                else
                if (traps.ifcount(25))
                    traps.shoot(SHRINKER);
                else
                {
                    if (traps.ifcount(5))
                    {
                    }
                    else
                    if (traps.ifcount(4))
                        traps.sound(NEWBEAST_SPIT);
                }
            }
        }
        if (traps.ifhitweapon())
            checknewbeasthit();
    }
    private void A_NEWBEAST()
    {
        traps.fall();
        if (traps.ifaction(null))
        {
            traps.cstator(257);
            traps.sizeat(40, 40);
            traps.Ai(AINEWBEASTDODGE);
        }
        if (traps.ifaction(ANEWBEASTFROZEN))
            newbeastcode();
        else
        {
            traps.spritepal(6);
            newbeastcode();
            if (traps.ifaction(ANEWBEASTFROZEN))
                return;
            traps.getlastpal();
        }
    }
}