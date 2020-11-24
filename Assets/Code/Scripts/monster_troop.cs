public partial class ConScript
{

    static ConAction ATROOPSTAND = new ConAction(0, 1, 5, 1, 1);
    static ConAction ATROOPGROW = new ConAction(0, 1, 5, 1, 1);
    static ConAction ATROOPSTAYSTAND = new ConAction(-2, 1, 5, 1, 1);
    static ConAction ATROOPWALKING = new ConAction(0, 4, 5, 1, 12);
    static ConAction ATROOPWALKINGBACK = new ConAction(15, 4, 5, -1, 12);
    static ConAction ATROOPRUNNING = new ConAction(0, 4, 5, 1, 8);
    static ConAction ATROOPSHOOT = new ConAction(35, 1, 5, 1, 30);
    static ConAction ATROOPJETPACK = new ConAction(40, 1, 5, 1, 1);
    static ConAction ATROOPJETPACKILL = new ConAction(40, 2, 5, 1, 50);
    static ConAction ATROOPFLINTCH = new ConAction(50, 1, 1, 1, 6);
    static ConAction ATROOPDYING = new ConAction(50, 5, 1, 1, 16);
    static ConAction ATROOPDEAD = new ConAction(54);
    static ConAction ATROOPPLAYDEAD = new ConAction(54);
    static ConAction ATROOPSUFFERDEAD = new ConAction(58, 2, 1, -4, 24);
    static ConAction ATROOPSUFFERING = new ConAction(59, 2, 1, 1, 21);
    static ConAction ATROOPDUCK = new ConAction(64, 1, 5, 1, 3);
    static ConAction ATROOPDUCKSHOOT = new ConAction(64, 2, 5, 1, 25);
    static ConAction ATROOPABOUTHIDE = new ConAction(74, 1, 1, 1, 25);
    static ConAction ATROOPHIDE = new ConAction(79, 1, 1, 1, 25);
    static ConAction ATROOPREAPPEAR = new ConAction(74, 1, 1, 1, 25);
    static ConAction ATROOPFROZEN = new ConAction(0, 1, 5);
    static MoveAction TROOPWALKVELS = new MoveAction(72);
    static MoveAction TROOPWALKVELSBACK = new MoveAction(-72);
    static MoveAction TROOPJETPACKVELS = new MoveAction(64, -84);
    static MoveAction TROOPJETPACKILLVELS = new MoveAction(192, -38);
    static MoveAction TROOPRUNVELS = new MoveAction(108);
    static MoveAction TROOPSTOPPED = new MoveAction();
    static MoveAction DONTGETUP = new MoveAction();
    static MoveAction SHRUNKVELS = new MoveAction(32);
    static AIAction AITROOPSEEKENEMY = new AIAction(ATROOPWALKING, TROOPWALKVELS, seekplayer);
    static AIAction AITROOPSEEKPLAYER = new AIAction(ATROOPWALKING, TROOPWALKVELS, seekplayer);
    static AIAction AITROOPFLEEING = new AIAction(ATROOPWALKING, TROOPWALKVELS, fleeenemy);
    static AIAction AITROOPFLEEINGBACK = new AIAction(ATROOPWALKINGBACK, TROOPWALKVELSBACK, faceplayer);
    static AIAction AITROOPDODGE = new AIAction(ATROOPWALKING, TROOPRUNVELS, dodgebullet);
    static AIAction AITROOPSHOOTING = new AIAction(ATROOPSHOOT, TROOPSTOPPED, faceplayer);
    static AIAction AITROOPDUCKING = new AIAction(ATROOPDUCK, TROOPSTOPPED, faceplayer);
    static AIAction AITROOPJETPACK = new AIAction(ATROOPJETPACK, TROOPJETPACKVELS, seekplayer);
    static AIAction AITROOPSHRUNK = new AIAction(ATROOPWALKING, SHRUNKVELS, fleeenemy);
    static AIAction AITROOPHIDE = new AIAction(ATROOPABOUTHIDE, TROOPSTOPPED, faceplayer);
    static AIAction AITROOPGROW = new AIAction(ATROOPGROW, DONTGETUP, faceplayerslow);
    private void troophidestate()
    {
        if (traps.ifaction(ATROOPREAPPEAR))
        {
            if (traps.ifactioncount(2))
            {
                traps.sound(TELEPORTER);
                traps.Ai(AITROOPSHOOTING);
                traps.cstat(257);
            }
            else
            {
                traps.sizeto(41, 40);
                traps.sizeto(41, 40);
                traps.sizeto(41, 40);
                traps.sizeto(41, 40);
                traps.spawn(FRAMEEFFECT1);
            }
        }
        else
        if (traps.ifaction(ATROOPWALKING))
        {
            if (traps.ifpdistl(2448))
                if (traps.ifpdistg(1024))
                {
                    if (traps.ifceilingdistl(48))
                        return;
                    if (traps.ifp(pfacing))
                        return;
                    if (traps.ifgapzl(64))
                    {
                    }
                    else
                    if (traps.ifawayfromwall())
                    {
                        traps.spawn(TRANSPORTERSTAR);
                        traps.SetAction(ATROOPREAPPEAR);
                        traps.Move(0);
                        return;
                    }
                }
        }
        else
        if (traps.ifaction(ATROOPHIDE))
        {
            if (traps.ifactioncount(2))
            {
                traps.spawn(TRANSPORTERSTAR);
                traps.sound(TELEPORTER);
                traps.SetAction(ATROOPWALKING);
                traps.Move(TROOPWALKVELS, faceplayer);
                traps.cstat(32768);
            }
            else
            {
                traps.sizeto(4, 40);
                traps.sizeto(4, 40);
                traps.sizeto(4, 40);
                traps.sizeto(4, 40);
                traps.spawn(FRAMEEFFECT1);
            }
        }
        else
        if (traps.ifaction(ATROOPABOUTHIDE))
            if (traps.ifactioncount(2))
            {
                traps.SetAction(ATROOPHIDE);
                traps.cstat(0);
            }
    }
    private void troopgunnashoot()
    {
        if (traps.ifp(palive))
        {
            if (traps.ifpdistl(1024))
                traps.Ai(AITROOPSHOOTING);
            else
                if (traps.ifactornotstayput())
            {
                if (traps.ifactioncount(12))
                    if (traps.ifrnd(16))
                        if (traps.ifcanshoottarget())
                        {
                            if (traps.ifspritepal(21))
                                if (traps.ifrnd(4))
                                    if (traps.ifpdistg(4096))
                                        traps.Ai(AITROOPHIDE);
                                    else
                                    {
                                        if (traps.ifpdistl(1100))
                                            traps.Ai(AITROOPFLEEING);
                                        else
                                        {
                                            if (traps.ifpdistl(4096))
                                                if (traps.ifcansee())
                                                    if (traps.ifcanshoottarget())
                                                        traps.Ai(AITROOPSHOOTING);
                                                    else
                                                    {
                                                        traps.Move(TROOPRUNVELS, seekplayer);
                                                        traps.SetAction(ATROOPRUNNING);
                                                    }
                                        }
                                    }
                        }
            }
            else
                if (traps.ifcount(26))
                if (traps.ifrnd(32))
                    traps.Ai(AITROOPSHOOTING);
        }
    }
    private void troopseekstate()
    {
        troopgunnashoot();
        if (traps.ifinwater())
        {
            traps.Ai(AITROOPJETPACK);
            return;
        }
        if (traps.ifcansee())
        {
            if (traps.ifmove(TROOPRUNVELS))
                if (traps.ifpdistl(1596))
                    traps.Ai(AITROOPDUCKING);
            if (traps.ifp(phigher))
            {
                if (traps.ifceilingdistl(128))
                {
                }
                else
                if (traps.ifactornotstayput())
                    traps.Ai(AITROOPJETPACK);
                return;
            }
            else
            if (traps.ifrnd(2))
            {
                if (traps.ifspritepal(21))
                    if (traps.ifpdistg(1596))
                    {
                        traps.Ai(AITROOPHIDE);
                        return;
                    }
                if (traps.ifbulletnear())
                {
                    if (traps.ifrnd(128))
                        traps.Ai(AITROOPDODGE);
                    else
                        traps.Ai(AITROOPDUCKING);
                    return;
                }
            }
        }
        if (traps.ifnotmoving())
        {
            if (traps.ifrnd(32))
                traps.operate();
            else
            if (traps.ifcount(32))
                if (traps.ifp(palive))
                    if (traps.ifcansee())
                        if (traps.ifcanshoottarget())
                            traps.Ai(AITROOPSHOOTING);
        }
        if (traps.ifrnd(1))
        {
            if (traps.ifrnd(128))
                traps.soundonce(PRED_ROAM);
            else
                traps.soundonce(PRED_ROAM2);
        }
    }
    private void troopduckstate()
    {
        if (traps.ifaction(ATROOPDUCK))
        {
            if (traps.ifactioncount(8))
            {
                if (traps.ifp(palive))
                {
                    if (traps.ifrnd(128))
                        traps.SetAction(ATROOPDUCKSHOOT);
                }
                else
                if (traps.ifmove(DONTGETUP))
                    return;
                else
                    traps.Ai(AITROOPSEEKPLAYER);
            }
        }
        else
        if (traps.ifaction(ATROOPDUCKSHOOT))
        {
            if (traps.ifcount(64))
            {
                if (traps.ifmove(DONTGETUP))
                    traps.resetcount();
                else
                {
                    if (traps.ifpdistl(1100))
                        traps.Ai(AITROOPFLEEING);
                    else
                        traps.Ai(AITROOPSEEKPLAYER);
                }
            }
            else
            if (traps.ifactioncount(2))
            {
                if (traps.ifcanshoottarget())
                {
                    traps.sound(PRED_ATTACK);
                    traps.resetactioncount();
                    traps.shoot(FIRELASER);
                }
                else
                    traps.Ai(AITROOPSEEKPLAYER);
            }
        }
    }
    private void troopshootstate()
    {
        if (traps.ifactioncount(2))
        {
            if (traps.ifcanshoottarget())
            {
                traps.shoot(FIRELASER);
                traps.sound(PRED_ATTACK);
                traps.resetactioncount();
                if (traps.ifrnd(128))
                    traps.Ai(AITROOPSEEKPLAYER);
                if (traps.ifcount(24))
                {
                    if (traps.ifrnd(96))
                        if (traps.ifpdistg(2048))
                            traps.Ai(AITROOPSEEKPLAYER);
                        else
                        {
                            if (traps.ifpdistg(1596))
                                traps.Ai(AITROOPFLEEING);
                            else
                                traps.Ai(AITROOPFLEEINGBACK);
                        }
                }
            }
            else
                traps.Ai(AITROOPSEEKPLAYER);
        }
    }
    private void troopfleestate()
    {
        if (traps.ifactioncount(7))
        {
            if (traps.ifpdistg(3084))
            {
                traps.Ai(AITROOPSEEKPLAYER);
                return;
            }
            else
                if (traps.ifrnd(32))
                if (traps.ifp(palive))
                    if (traps.ifcansee())
                        if (traps.ifcanshoottarget())
                        {
                            if (traps.ifrnd(128))
                                traps.Ai(AITROOPDUCKING);
                            else
                                traps.Ai(AITROOPSHOOTING);
                            return;
                        }
        }
        if (traps.ifnotmoving())
        {
            if (traps.ifrnd(32))
                traps.operate();
            else
            if (traps.ifcount(32))
                if (traps.ifp(palive))
                    if (traps.ifcansee())
                        if (traps.ifcanshoottarget())
                        {
                            if (traps.ifrnd(128))
                                traps.Ai(AITROOPSHOOTING);
                            else
                                traps.Ai(AITROOPDUCKING);
                        }
        }
    }
    private void troopdying()
    {
        if (traps.iffloordistl(32))
        {
            if (traps.ifactioncount(5))
            {
                traps.cstat(0);
                if (traps.iffloordistl(8))
                    traps.sound(THUD);
                if (traps.ifrnd(64))
                    traps.spawn(BLOODPOOL);
                rf();
                traps.strength(0);
                traps.Move(TROOPSTOPPED);
                traps.SetAction(ATROOPDEAD);
            }
            return;
        }
        else
        {
            rf();
            traps.Move(0);
            traps.SetAction(ATROOPDYING);
        }
    }
    private void checktroophit()
    {
        if (traps.ifaction(ATROOPSUFFERING))
        {
            traps.stopsound(LIZARD_BEG);
            traps.sound(PRED_DYING);
            traps.cstat(0);
            traps.strength(0);
            traps.SetAction(ATROOPSUFFERDEAD);
            return;
        }
        if (traps.ifdead())
        {
            if (traps.ifwasweapon(FREEZEBLAST))
            {
                traps.sound(SOMETHINGFROZE);
                traps.spritepal(1);
                traps.Move(0);
                traps.SetAction(ATROOPFROZEN);
                traps.strength(0);
                return;
            }
            drop_ammo();
            random_wall_jibs();
            if (traps.ifwasweapon(GROWSPARK))
            {
                traps.cstat(0);
                traps.sound(ACTOR_GROWING);
                traps.Ai(AITROOPGROW);
                return;
            }
            traps.addkills(1);
            if (traps.ifwasweapon(RPG))
            {
                traps.sound(SQUISHED);
                troop_body_jibs();
                standard_jibs();
                traps.killit();
            }
            else
            if (traps.ifwasweapon(RADIUSEXPLOSION))
            {
                traps.sound(SQUISHED);
                troop_body_jibs();
                standard_jibs();
                traps.killit();
            }
            else
            {
                traps.sound(PRED_DYING);
                if (traps.ifrnd(32))
                    if (traps.iffloordistl(32))
                    {
                        traps.sound(LIZARD_BEG);
                        traps.spawn(BLOODPOOL);
                        traps.strength(0);
                        traps.Move(0);
                        traps.SetAction(ATROOPSUFFERING);
                        return;
                    }
                traps.SetAction(ATROOPDYING);
                return;
            }
        }
        else
        {
            random_wall_jibs();
            traps.sound(PRED_PAIN);
            if (traps.ifwasweapon(SHRINKSPARK))
            {
                traps.sound(ACTOR_SHRINKING);
                traps.Ai(AITROOPSHRUNK);
            }
            else
            if (traps.ifwasweapon(GROWSPARK))
                traps.sound(EXPANDERHIT);
            else
            if (traps.iffloordistl(32))
                if (traps.ifrnd(96))
                    traps.SetAction(ATROOPFLINTCH);
        }
    }
    private void troopjetpackstate()
    {
        if (traps.ifaction(ATROOPJETPACKILL))
        {
            if (traps.ifcansee())
                if (traps.ifactioncount(2))
                {
                    traps.resetactioncount();
                    traps.sound(PRED_ATTACK);
                    traps.shoot(FIRELASER);
                }
            if (traps.ifp(phigher))
                traps.Ai(AITROOPJETPACK);
            else
            if (traps.ifinwater())
                traps.Ai(AITROOPJETPACK);
            else
            if (traps.ifcount(26))
                if (traps.iffloordistl(32))
                    traps.Ai(AITROOPSEEKPLAYER);
        }
        else
        if (traps.ifcount(62)) // jmarshall: was 48 extended jetpack time. 
            if (traps.ifcansee())
            {
                traps.SetAction(ATROOPJETPACKILL);
                traps.Move(TROOPJETPACKILLVELS);
            }
    }
    private void checksquished()
    {
        if (traps.ifsquished())
        {
            traps.addkills(1);
            traps.sound(SQUISHED);
            standard_jibs();
            random_ooz();
            traps.killit();
        }
    }
    private void troopsufferingstate()
    {
        if (traps.ifactioncount(2))
        {
            if (traps.ifrnd(16))
                traps.spawn(WATERDRIP);
            if (traps.ifactioncount(14))
            {
                traps.stopsound(LIZARD_BEG);
                traps.cstat(0);
                traps.strength(0);
                traps.SetAction(ATROOPSUFFERDEAD);
                return;
            }
        }
    }
    private void troopshrunkstate()
    {
        if (traps.ifcount(SHRUNKDONECOUNT))
            traps.Ai(AITROOPSEEKENEMY);
        else
        if (traps.ifcount(SHRUNKCOUNT))
            traps.sizeto(48, 40);
        else
            genericshrunkcode();
    }
    private void troopcode()
    {
        traps.fall();
        if (traps.ifinwater())
            if (traps.ifrnd(1))
                traps.spawn(WATERBUBBLE);
        if (traps.ifaction(ATROOPSTAND))
        {
            if (traps.ifrnd(192))
                traps.Ai(AITROOPSHOOTING);
            else
                traps.Ai(AITROOPSEEKPLAYER);
        }
        else
        if (traps.ifaction(ATROOPFROZEN))
        {
            if (traps.ifcount(THAWTIME))
            {
                traps.Ai(AITROOPSEEKENEMY);
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
        if (traps.ifaction(ATROOPPLAYDEAD))
        {
            if (traps.ifhitweapon())
            {
                if (traps.ifwasweapon(RADIUSEXPLOSION))
                {
                    traps.sound(SQUISHED);
                    troop_body_jibs();
                    standard_jibs();
                    traps.killit();
                }
                return;
            }
            else
                checksquished();
            if (traps.ifcount(PLAYDEADTIME))
            {
                traps.addkills(-1);
                traps.soundonce(PRED_ROAM);
                traps.cstat(257);
                traps.strength(1);
                traps.Ai(AITROOPSHOOTING);
            }
            else
            if (traps.ifp(pfacing))
                traps.resetcount();
            return;
        }
        else
        if (traps.ifaction(ATROOPDEAD))
        {
            traps.strength(0);
            if (traps.ifrespawn())
                if (traps.ifcount(RESPAWNACTORTIME))
                {
                    traps.spawn(TRANSPORTERSTAR);
                    traps.cstat(257);
                    traps.strength(TROOPSTRENGTH);
                    traps.Ai(AITROOPSEEKENEMY);
                }
            if (traps.ifhitweapon())
            {
                if (traps.ifwasweapon(RADIUSEXPLOSION))
                {
                    traps.sound(SQUISHED);
                    troop_body_jibs();
                    standard_jibs();
                    traps.killit();
                }
                return;
            }
            else
                checksquished();
            return;
        }
        else
        if (traps.ifaction(ATROOPSUFFERDEAD))
        {
            if (traps.ifactioncount(2))
            {
                if (traps.ifrnd(64))
                {
                    traps.resetcount();
                    traps.SetAction(ATROOPPLAYDEAD);
                }
                else
                {
                    traps.soundonce(PRED_DYING);
                    traps.SetAction(ATROOPDEAD);
                }
            }
        }
        else
        if (traps.ifaction(ATROOPDYING))
        {
            troopdying();
            return;
        }
        else
        if (traps.ifaction(ATROOPSUFFERING))
        {
            troopsufferingstate();
            if (traps.ifhitweapon())
                checktroophit();
            return;
        }
        else
        if (traps.ifaction(ATROOPFLINTCH))
        {
            if (traps.ifactioncount(4))
                traps.Ai(AITROOPSEEKENEMY);
        }
        else
        {
            if (traps.ifai(AITROOPSEEKPLAYER))
                troopseekstate();
            else
            if (traps.ifai(AITROOPJETPACK))
            {
                troopjetpackstate();
                if (traps.ifinwater())
                {
                }
                else
                    traps.soundonce(DUKE_JETPACK_IDLE);
            }
            else
            if (traps.ifai(AITROOPSEEKENEMY))
                troopseekstate();
            else
            if (traps.ifai(AITROOPSHOOTING))
                troopshootstate();
            else
            if (traps.ifai(AITROOPFLEEING))
                troopfleestate();
            else
            if (traps.ifai(AITROOPFLEEINGBACK))
                troopfleestate();
            else
            if (traps.ifai(AITROOPDODGE))
                troopseekstate();
            else
            if (traps.ifai(AITROOPDUCKING))
                troopduckstate();
            else
            if (traps.ifai(AITROOPSHRUNK))
                troopshrunkstate();
            else
            if (traps.ifai(AITROOPGROW))
                genericgrowcode();
            else
            if (traps.ifai(AITROOPHIDE))
            {
                troophidestate();
                return;
            }
        }
        if (traps.ifhitweapon())
            checktroophit();
        else
            checksquished();
    }
    private void checktrooppalette()
    {
        if (traps.ifai(null))
        {
            if (traps.ifspritepal(0))
            {
            }
            else
            if (traps.ifspritepal(21))
                traps.addstrength(TROOPSTRENGTH);
        }
    }
    private void A_LIZTROOPJETPACK()
    {
        checktrooppalette();
        traps.Ai(AITROOPJETPACK);
        traps.cactor(LIZTROOP);
    }
    private void A_LIZTROOPDUCKING()
    {
        checktrooppalette();
        traps.Ai(AITROOPDUCKING);
        traps.cactor(LIZTROOP);
        if (traps.ifgapzl(48))
            traps.Move(DONTGETUP);
    }
    private void A_LIZTROOPSHOOT()
    {
        checktrooppalette();
        traps.Ai(AITROOPSHOOTING);
        traps.cactor(LIZTROOP);
    }
    private void A_LIZTROOPSTAYPUT()
    {
        checktrooppalette();
        traps.Ai(AITROOPSEEKPLAYER);
        traps.cactor(LIZTROOP);
    }
    private void A_LIZTROOPRUNNING()
    {
        checktrooppalette();
        traps.Ai(AITROOPSEEKPLAYER);
        traps.cactor(LIZTROOP);
    }
    private void A_LIZTROOPONTOILET()
    {
        if (traps.ifcount(24))
        {
            traps.sound(FLUSH_TOILET);
            traps.operate();
            traps.Ai(AITROOPSEEKPLAYER);
            traps.cactor(LIZTROOP);
        }
        else
        if (traps.ifcount(2))
        {
        }
        else
            checktrooppalette();
    }
    private void A_LIZTROOPJUSTSIT()
    {
        if (traps.ifcount(30))
        {
            traps.operate();
            traps.Ai(AITROOPSEEKPLAYER);
            traps.cactor(LIZTROOP);
        }
        else
        if (traps.ifcount(2))
        {
        }
        else
            checktrooppalette();
    }
    private void A_LIZTROOP()
    {
        checktrooppalette();
        troopcode();
    }
}