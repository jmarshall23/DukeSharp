public partial class ConScript
{
    static ConAction ALIZSTAND = new ConAction(0);
    static ConAction ALIZWALKING = new ConAction(0, 4, 5, 1, 15);
    static ConAction ALIZRUNNING = new ConAction(0, 4, 5, 1, 11);
    static ConAction ALIZTHINK = new ConAction(20, 2, 5, 1, 40);
    static ConAction ALIZSCREAM = new ConAction(30, 1, 5, 1, 2);
    static ConAction ALIZJUMP = new ConAction(45, 3, 5, 1, 20);
    static ConAction ALIZFALL = new ConAction(55, 1, 5);
    static ConAction ALIZSHOOTING = new ConAction(70, 2, 5, 1, 7);
    static ConAction ALIZDYING = new ConAction(60, 6, 1, 1, 15);
    static ConAction ALIZLYINGDEAD = new ConAction(65, 1);
    static ConAction ALIZFROZEN = new ConAction(0, 1, 5);
    static MoveAction LIZWALKVEL = new MoveAction(72);
    static MoveAction LIZRUNVEL = new MoveAction(192);
    static MoveAction LIZJUMPVEL = new MoveAction(184);
    static MoveAction LIZSTOP = new MoveAction();
    static AIAction AILIZGETENEMY = new AIAction(ALIZWALKING, LIZWALKVEL, seekplayer);
    static AIAction AILIZDODGE = new AIAction(ALIZRUNNING, LIZRUNVEL, dodgebullet);
    static AIAction AILIZCHARGEENEMY = new AIAction(ALIZRUNNING, LIZRUNVEL, seekplayer);
    static AIAction AILIZFLEENEMY = new AIAction(ALIZWALKING, LIZWALKVEL, fleeenemy);
    static AIAction AILIZSHOOTENEMY = new AIAction(ALIZSHOOTING, LIZSTOP, faceplayer);
    static AIAction AILIZJUMPENEMY = new AIAction(ALIZJUMP, LIZJUMPVEL, jumptoplayer);
    static AIAction AILIZTHINK = new AIAction(ALIZTHINK, LIZSTOP, faceplayerslow);
    static AIAction AILIZSHRUNK = new AIAction(ALIZWALKING, SHRUNKVELS, fleeenemy);
    static AIAction AILIZGROW = new AIAction(ALIZSTAND, LIZSTOP, faceplayerslow);
    static AIAction AILIZSPIT = new AIAction(ALIZSCREAM, LIZSTOP, faceplayerslow);
    static AIAction AILIZDYING = new AIAction(ALIZDYING, LIZSTOP, faceplayer);
    private void lizseekstate()
    {
        if (traps.ifactornotstayput())
        {
            if (traps.ifcansee())
                if (traps.ifp(palive))
                    if (traps.ifpdistl(2048))
                        if (traps.ifcount(16))
                            if (traps.ifcanshoottarget())
                            {
                                traps.Ai(AILIZSHOOTENEMY);
                                return;
                            }
            if (traps.ifai(AILIZCHARGEENEMY))
            {
                if (traps.ifcount(72))
                    if (traps.ifcanshoottarget())
                    {
                        traps.Ai(AILIZSHOOTENEMY);
                        return;
                    }
                if (traps.ifp(phigher))
                    if (traps.ifpdistg(2048))
                        if (traps.ifrnd(6))
                        {
                            traps.Ai(AILIZJUMPENEMY);
                            return;
                        }
            }
            else
        if (traps.ifpdistg(4096))
            {
                if (traps.ifrnd(92))
                {
                    if (traps.ifcount(48))
                        if (traps.ifcanshoottarget())
                            traps.Ai(AILIZSHOOTENEMY);
                }
                else
                if (traps.ifcount(24))
                {
                    traps.Ai(AILIZCHARGEENEMY);
                    return;
                }
            }
            if (traps.iffloordistl(16))
            {
                if (traps.ifcount(48))
                    if (traps.ifnotmoving())
                        if (traps.ifcansee())
                        {
                            traps.Ai(AILIZJUMPENEMY);
                            return;
                        }
            }
            else
            {
                if (traps.ifpdistg(1280))
                    traps.Ai(AILIZJUMPENEMY);
                return;
            }
            if (traps.ifrnd(4))
                if (traps.ifnotmoving())
                    traps.operate();
                else
                if (traps.ifrnd(1))
                    if (traps.ifbulletnear())
                    {
                        if (traps.ifgapzl(128))
                            traps.Ai(AILIZDODGE);
                        else
                        if (traps.ifactornotstayput())
                        {
                            if (traps.ifrnd(32))
                                traps.Ai(AILIZJUMPENEMY);
                            else
                                traps.Ai(AILIZDODGE);
                        }
                    }
        }
        else
        {
            if (traps.ifactioncount(16))
            {
                if (traps.ifp(palive))
                    if (traps.ifrnd(32))
                        if (traps.ifcansee())
                            if (traps.ifcanshoottarget())
                                traps.Ai(AILIZSHOOTENEMY);
            }
            if (traps.ifcount(16))
                if (traps.ifrnd(32))
                    traps.Move(LIZWALKVEL, randomangle, geth);
        }
    }
    private void lizshrunkstate()
    {
        if (traps.ifcount(SHRUNKDONECOUNT))
            traps.Ai(AILIZGETENEMY);
        else
        if (traps.ifcount(SHRUNKCOUNT))
            traps.sizeto(48, 40);
        else
            genericshrunkcode();
    }
    private void lizfleestate()
    {
        if (traps.ifcount(16))
        {
            if (traps.ifrnd(48))
                if (traps.ifp(palive))
                    if (traps.ifcansee())
                        traps.Ai(AILIZSPIT);
        }
        else
        {
            if (traps.iffloordistl(16))
            {
            }
            else
                traps.Ai(AILIZGETENEMY);
            return;
        }
    }
    private void lizthinkstate()
    {
        if (traps.ifrnd(8))
            traps.soundonce(CAPT_ROAM);
        if (traps.ifactioncount(3))
        {
            if (traps.ifrnd(32))
                if (traps.ifp(palive))
                    if (traps.ifcansee())
                        traps.Ai(AILIZSPIT);
                    else
                        if (traps.ifrnd(96))
                        traps.Ai(AILIZGETENEMY);
        }
        else
        if (traps.ifactioncount(2))
            if (traps.ifrnd(1))
                traps.spawn(FECES);
        if (traps.ifrnd(1))
            if (traps.ifbulletnear())
            {
                if (traps.ifgapzl(96))
                    traps.Ai(AILIZDODGE);
                else
                {
                    if (traps.ifrnd(128))
                        traps.Ai(AILIZJUMPENEMY);
                    else
                        traps.Ai(AILIZDODGE);
                }
            }
    }
    private void lizshootstate()
    {
        if (traps.ifcount(20))
            if (traps.ifrnd(8))
            {
                if (traps.ifcansee())
                    if (traps.ifpdistl(2048))
                    {
                        if (traps.ifrnd(128))
                            traps.Ai(AILIZFLEENEMY);
                        return;
                    }
                if (traps.ifrnd(80))
                    traps.Ai(AILIZTHINK);
                else
                    traps.Ai(AILIZGETENEMY);
            }
        if (traps.ifactioncount(2))
        {
            if (traps.ifcansee())
            {
                if (traps.ifcanshoottarget())
                {
                    traps.sound(CAPT_ATTACK);
                    traps.shoot(SHOTSPARK1);
                    traps.resetactioncount();
                }
                else
                    traps.Ai(AILIZTHINK);
            }
            else
                traps.Ai(AILIZGETENEMY);
        }
    }
    private void checklizhit()
    {
        traps.spawn(BLOOD);
        if (traps.ifai(AILIZSHRUNK))
        {
            traps.addkills(1);
            traps.sound(SQUISHED);
            standard_jibs();
            traps.killit();
        }
        if (traps.ifdead())
        {
            if (traps.ifwasweapon(FREEZEBLAST))
            {
                traps.sound(SOMETHINGFROZE);
                traps.spritepal(1);
                traps.Move(0);
                traps.SetAction(ALIZFROZEN);
                traps.strength(0);
                return;
            }
            drop_chaingun();
            if (traps.ifwasweapon(GROWSPARK))
            {
                traps.cstat(0);
                traps.sound(ACTOR_GROWING);
                traps.Ai(AILIZGROW);
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
                traps.Ai(AILIZDYING);
                if (traps.ifrnd(64))
                    traps.spawn(BLOODPOOL);
            }
            traps.sound(CAPT_DYING);
        }
        else
        {
            traps.sound(CAPT_PAIN);
            if (traps.ifwasweapon(SHRINKSPARK))
            {
                traps.sound(ACTOR_SHRINKING);
                traps.Ai(AILIZSHRUNK);
                return;
            }
            if (traps.ifwasweapon(GROWSPARK))
                traps.sound(EXPANDERHIT);
            random_wall_jibs();
            if (traps.ifp(palive))
                if (traps.ifcansee())
                    if (traps.ifcanshoottarget())
                    {
                        traps.Ai(AILIZSHOOTENEMY);
                        return;
                    }
        }
    }
    private void lizjumpstate()
    {
        if (traps.ifaction(ALIZFALL))
        {
            if (traps.iffloordistl(16))
                traps.Ai(AILIZGETENEMY);
        }
        else
        if (traps.ifactioncount(3))
            traps.SetAction(ALIZFALL);
    }
    private void lizdyingstate()
    {
        if (traps.ifaction(ALIZLYINGDEAD))
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
                    traps.strength(LIZSTRENGTH);
                    traps.Ai(AILIZGETENEMY);
                }
        }
        else
        if (traps.ifai(AILIZDYING))
            if (traps.ifactioncount(6))
            {
                if (traps.iffloordistl(8))
                    traps.sound(THUD);
                traps.Move(LIZSTOP);
                traps.SetAction(ALIZLYINGDEAD);
            }
    }
    private void lizdodgestate()
    {
        if (traps.ifcount(13))
            traps.Ai(AILIZGETENEMY);
    }
    private void A_LIZMANSTAYPUT()
    {
        traps.Ai(AILIZGETENEMY);
        traps.cactor(LIZMAN);
    }
    private void A_LIZMANSPITTING()
    {
        traps.Ai(AILIZSPIT);
        traps.cactor(LIZMAN);
    }
    private void A_LIZMANJUMP()
    {
        traps.Ai(AILIZJUMPENEMY);
        traps.cactor(LIZMAN);
    }
    private void lizcode()
    {
        checksquished();
        if (traps.ifai(null))
            traps.Ai(AILIZGETENEMY);
        else
        if (traps.ifaction(ALIZLYINGDEAD))
        {
            traps.fall();
            lizdyingstate();
            return;
        }
        else
        if (traps.ifaction(ALIZFROZEN))
        {
            if (traps.ifcount(THAWTIME))
            {
                traps.Ai(AILIZGETENEMY);
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
        if (traps.ifai(AILIZJUMPENEMY))
            lizjumpstate();
        else
        {
            traps.fall();
            if (traps.ifai(AILIZGETENEMY))
                lizseekstate();
            else
            if (traps.ifai(AILIZCHARGEENEMY))
                lizseekstate();
            else
            if (traps.ifai(AILIZDODGE))
                lizdodgestate();
            else
            if (traps.ifai(AILIZSHOOTENEMY))
                lizshootstate();
            else
            if (traps.ifai(AILIZFLEENEMY))
                lizfleestate();
            else
            if (traps.ifai(AILIZTHINK))
                lizthinkstate();
            else
            if (traps.ifai(AILIZSHRUNK))
                lizshrunkstate();
            else
            if (traps.ifai(AILIZGROW))
                genericgrowcode();
            else
            if (traps.ifai(AILIZDYING))
                lizdyingstate();
            else
            if (traps.ifai(AILIZSPIT))
            {
                if (traps.ifcount(26))
                    traps.Ai(AILIZGETENEMY);
                else
                if (traps.ifcount(18))
                    if (traps.ifrnd(96))
                    {
                        traps.shoot(SPIT);
                        traps.sound(LIZARD_SPIT);
                    }
            }
        }
        if (traps.ifai(AILIZSHRUNK))
            return;
        if (traps.ifhitweapon())
            checklizhit();
    }
    private void A_LIZMAN()
    {
        traps.fall();
        lizcode();
    }
}