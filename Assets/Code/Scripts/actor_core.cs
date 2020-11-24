public partial class ConScript
{
    static ConAction ANULLACTION = new ConAction(0);    
    static MoveAction SHUTTLEVELS = new MoveAction(16);
    private void A_SPACESHUTTLE()
    {
    }
    private void A_SATELLITE()
    {
    }
   
    private void genericshrunkcode()
    {
        if (traps.ifcount(32))
        {
            if (traps.ifpdistl(SQUISHABLEDISTANCE))
                traps.pstomp();
        }
        else
        {
            traps.sizeto(MINXSTRETCH, MINYSTRETCH);
            traps.spawn(FRAMEEFFECT1);
        }
    }
    private void genericgrowcode()
    {
        if (traps.ifcount(32))
        {
            traps.guts(JIBS4, 24);
            traps.guts(JIBS6, 28);
            traps.addkills(1);
            traps.sound(SQUISHED);
            traps.sound(PIPEBOMB_EXPLODE);
            traps.hitradius(2048, 60, 70, 80, 90);
            traps.spawn(BLOODPOOL);
            traps.spawn(EXPLOSION2);
            traps.killit();
        }
        else
        {
            if (traps.ifactor(COMMANDER))
                traps.sizeto(100, 100);
            else
            if (traps.ifactor(SHARK))
                traps.sizeto(84, 84);
            else
                traps.sizeto(MAXXSTRETCH, MAXYSTRETCH);
            return;
        }
    }

   
    private void rats()
    {
        if (traps.ifrnd(128))
            traps.spawn(RAT);
        if (traps.ifrnd(128))
            traps.spawn(RAT);
        if (traps.ifrnd(128))
            traps.spawn(RAT);
        if (traps.ifrnd(128))
            traps.spawn(RAT);
        if (traps.ifrnd(128))
            traps.spawn(RAT);
        if (traps.ifrnd(128))
            traps.spawn(RAT);
        if (traps.ifrnd(128))
            traps.spawn(RAT);
        if (traps.ifrnd(128))
            traps.spawn(RAT);
    }
    static MoveAction RESPAWN_ACTOR_FLAG = new MoveAction();
    static MoveAction MOUSEVELS = new MoveAction(32);
    static ConAction RUBCANDENT = new ConAction(1, 1, 1, 1, 1);
    private void A_RUBBERCAN()
    {
        if (traps.ifaction(RUBCANDENT))
        {
            if (traps.ifactioncount(16))
            {
                traps.strength(0);
                traps.SetAction(ANULLACTION);
                return;
            }
        }
        else
    if (traps.ifhitweapon())
        {
            if (traps.ifwasweapon(RADIUSEXPLOSION))
            {
                rats();
                if (traps.ifrnd(48))
                    traps.spawn(BURNING);
                traps.debris(SCRAP3, 12);
                traps.killit();
            }
            else
                traps.SetAction(RUBCANDENT);
        }
    }
 
 
    private void headhitstate()
    {
    }
    static ConAction EXPBARRELFRAME = new ConAction(0, 2, 1, 1, 15);
    private void A_EXPLODINGBARREL()
    {
        traps.fall();
        if (traps.ifaction(EXPBARRELFRAME))
        {
            if (traps.ifactioncount(2))
            {
                traps.hitradius(1024, WEAKEST, WEAK, MEDIUMSTRENGTH, TOUGH);
                traps.spawn(EXPLOSION2);
                traps.debris(SCRAP2, 2);
                traps.sound(PIPEBOMB_EXPLODE);
                traps.killit();
            }
            return;
        }
        if (traps.ifsquished())
        {
            traps.debris(SCRAP1, 5);
            traps.killit();
            return;
        }
        if (traps.ifhitweapon())
            traps.SetAction(EXPBARRELFRAME);
    }
    static ConAction BURNING_FLAME = new ConAction(0, 12, 1, 1, 2);
    static MoveAction BURNING_VELS = new MoveAction();
    private void burningstate()
    {
        traps.sleeptime(300);
        if (traps.ifspawnedby(BURNING))
        {
            if (traps.ifgapzl(16))
                return;
        }
        else
        if (traps.ifspawnedby(BURNING2))
        {
            if (traps.ifgapzl(16))
                return;
        }
        if (traps.ifpdistg(10240))
            return;
        if (traps.ifcount(128))
        {
            if (traps.ifspawnedby(TIRE))
            {
                if (traps.ifactioncount(512))
                    traps.killit();
                if (traps.ifrnd(16))
                    traps.sizeto(64, 48);
            }
            else
            {
                traps.sizeto(8, 8);
                traps.sizeto(8, 8);
                if (traps.ifcount(192))
                    traps.killit();
            }
        }
        else
        {
            if (traps.ifmove(null))
                traps.Move(BURNING_VELS);
            traps.sizeto(52, 52);
            if (traps.ifp(palive))
                if (traps.ifpdistl(844))
                    if (traps.ifrnd(32))
                        if (traps.ifcansee())
                        {
                            traps.soundonce(DUKE_LONGTERM_PAIN);
                            traps.addphealth(-1);
                            traps.palfrom(24, 16);
                        }
        }
    }
    private void A_BURNING()
    {
        burningstate();
    }
    private void A_BURNING2()
    {
        burningstate();
    }
    
    static ConAction WOODENHORSEFRAME = new ConAction(0, 1, 4);
    static ConAction WOODENFALLFRAME = new ConAction(122, 1, 5);
    private void A_HORSEONSIDE()
    {
        traps.cactor(WOODENHORSE);
        traps.SetAction(WOODENFALLFRAME);
    }
    private void A_WOODENHORSE()
    {
        traps.fall();
        if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                traps.debris(SCRAP1, 4);
                traps.debris(SCRAP2, 3);
                traps.killit();
            }
            else
                traps.SetAction(WOODENFALLFRAME);
        }
    }
    private void steamcode()
    {
        if (traps.ifpdistl(6144))
            traps.soundonce(STEAM_HISSING);
        if (traps.ifcount(20))
        {
            traps.resetcount();
            if (traps.ifp(palive))
                if (traps.ifpdistl(1024))
                {
                    traps.addphealth(-1);
                    traps.palfrom(16, 16);
                }
        }
        else
        {
            if (traps.ifspawnedby(STEAM))
                return;
            else
            if (traps.ifspawnedby(CEILINGSTEAM))
                return;
            traps.sizeto(24, 24);
        }
    }
    static ConAction STEAMFRAMES = new ConAction(0, 5, 1, 1, 1);
    private void A_STEAM()
    {
        steamcode();
    }
    private void A_CEILINGSTEAM()
    {
        steamcode();
    }
    private void A_WATERBUBBLEMAKER()
    {
        if (traps.ifpdistl(3084))
            if (traps.ifrnd(24))
                traps.spawn(WATERBUBBLE);
    }
    static ConAction BUBBLE = new ConAction();
    static ConAction CRACKEDBUBBLE = new ConAction(1);
    static MoveAction BUBMOVE = new MoveAction(-10, -36);
    static MoveAction BUBMOVEFAST = new MoveAction(-10, -52);
    private void A_WATERBUBBLE()
    {
        if (traps.ifaction(CRACKEDBUBBLE))
        {
            if (traps.ifinwater())
                if (traps.ifrnd(192))
                    traps.killit();
            if (traps.ifactioncount(7))
                traps.killit();
        }
        else
        {
            if (traps.ifcount(4))
            {
                if (traps.ifrnd(192))
                    traps.Move(BUBMOVE, getv, geth, randomangle);
                else
                    traps.Move(BUBMOVEFAST, getv, geth, randomangle);
                traps.resetcount();
                if (traps.ifrnd(84))
                    traps.sizeat(8, 10);
                else
                if (traps.ifrnd(84))
                    traps.sizeat(10, 8);
                else
                    traps.sizeat(9, 9);
            }
            if (traps.ifonwater())
            {
                if (traps.iffloordistl(8))
                    traps.SetAction(CRACKEDBUBBLE);
            }
            else
            if (traps.ifactioncount(40))
                traps.SetAction(CRACKEDBUBBLE);
        }
    }
    static MoveAction SMOKEVEL = new MoveAction(8, -16);
    static MoveAction ENGINE_SMOKE = new MoveAction(64, -64);
    static MoveAction SMOKESHOOTOUT = new MoveAction(-192);
    static ConAction SMOKEFRAMES = new ConAction(0, 4, 1, 1, 10);
    private void A_SMALLSMOKE()
    {
        if (traps.ifmove(null))
        {
            if (traps.ifspawnedby(RECON))
                traps.Move(SMOKESHOOTOUT, geth);
            else
            if (traps.ifspawnedby(SECTOREFFECTOR))
                traps.Move(ENGINE_SMOKE, geth, getv);
            else
                traps.Move(SMOKEVEL, geth, getv, faceplayer);
            if (traps.ifspawnedby(RPG))
                traps.cstat(2);
        }
        if (traps.ifpdistl(1596))
            if (traps.ifspawnedby(RPG))
                traps.killit();
        if (traps.ifactioncount(4))
            traps.killit();
    }
    static ConAction BARREL_DENTING = new ConAction(2, 2, 1, 1, 6);
    static ConAction BARREL_DENTED = new ConAction(1);
    static ConAction BARREL_DENTED2 = new ConAction(2);
    static MoveAction SPAWNED_BLOOD = new MoveAction();
    private void A_NUKEBARRELDENTED()
    {
        traps.cactor(NUKEBARREL);
        traps.SetAction(BARREL_DENTED);
    }
    private void A_NUKEBARRELLEAKED()
    {
        traps.cactor(NUKEBARREL);
        traps.SetAction(BARREL_DENTED2);
    }
    private void random_ooz()
    {
        if (traps.ifrnd(128))
            traps.spawn(OOZ2);
        else
            traps.spawn(OOZ);
    }
    private void A_NUKEBARREL()
    {
        if (traps.ifsquished())
        {
            traps.debris(SCRAP1, 32);
            traps.spawn(BLOODPOOL);
            random_ooz();
            traps.killit();
        }
        traps.fall();
        if (traps.ifaction(BARREL_DENTING))
        {
            if (traps.ifactioncount(2))
            {
                traps.debris(SCRAP1, 10);
                if (traps.ifrnd(2))
                    traps.spawn(BLOODPOOL);
                traps.killit();
            }
        }
        else
    if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                traps.sound(VENT_BUST);
                if (traps.ifrnd(128))
                    traps.spawn(BLOODPOOL);
                traps.SetAction(BARREL_DENTING);
            }
            else
            {
                if (traps.ifaction(null))
                    traps.SetAction(BARREL_DENTED);
                else
                if (traps.ifaction(BARREL_DENTED))
                {
                    traps.SetAction(BARREL_DENTED2);
                    traps.spawn(BLOODPOOL);
                }
                else
                if (traps.ifaction(BARREL_DENTED2))
                    traps.SetAction(BARREL_DENTING);
            }
        }
    }
    private void burningbarrelcode()
    {
        traps.fall();
        if (traps.ifcount(32))
        {
            traps.resetcount();
            if (traps.ifp(palive))
                if (traps.ifpdistl(1480))
                    if (traps.ifp(phigher))
                    {
                        traps.addphealth(-1);
                        traps.palfrom(16, 16);
                        if (traps.ifrnd(96))
                            traps.sound(DUKE_LONGTERM_PAIN);
                    }
        }
        if (traps.ifhitweapon())
        {
            traps.sound(VENT_BUST);
            traps.debris(SCRAP1, 10);
            if (traps.ifrnd(128))
                traps.spawn(BURNING);
            else
                traps.spawn(BURNING2);
            traps.killit();
        }
    }
    private void A_FIREBARREL()
    {
        burningbarrelcode();
    }
    private void A_FIREVASE()
    {
        burningbarrelcode();
    }
    static ConAction SHRINKERFRAMES = new ConAction(0, 4, 1, 1, 10);
    private void A_SHRINKEREXPLOSION()
    {
        if (traps.ifactioncount(4))
            traps.killit();
    }
    static ConAction EXPLOSION_FRAMES = new ConAction(0, 20, 1, 1, 4);
    private void A_EXPLOSION2()
    {
        if (traps.ifactioncount(20))
            traps.killit();
    }
    private void A_EXPLOSION2BOT()
    {
        if (traps.ifactioncount(20))
            traps.killit();
    }
    static ConAction FFLAME_FR = new ConAction(0, 16, 1, 1, 1);
    static ConAction FFLAME = new ConAction(0, 1, 1, 1, 1);
    private void A_FLOORFLAME()
    {
        if (traps.ifaction(FFLAME_FR))
        {
            if (traps.ifpdistl(1024))
                traps.hitradius(1024, WEAKEST, WEAKEST, WEAKEST, WEAKEST);
            if (traps.ifactioncount(16))
                traps.SetAction(FFLAME);
        }
        if (traps.ifaction(FFLAME))
            if (traps.ifrnd(4))
            {
                traps.SetAction(FFLAME_FR);
                traps.sound(CAT_FIRE);
                traps.resetactioncount();
            }
    }
    static ConAction ASATNSPIN = new ConAction(0, 5, 1, 1, 4);
    static ConAction ASATSHOOTING = new ConAction(-10, 3, 5, 1, 40);
    static ConAction ASATWAIT = new ConAction(0, 1, 5, 1, 1);
    static MoveAction TURRVEL = new MoveAction();
    private void A_ROTATEGUN()
    {
        if (traps.ifaction(null))
        {
            traps.SetAction(ASATSHOOTING);
            traps.Move(TURRVEL, faceplayer);
        }
        else
        if (traps.ifaction(ASATNSPIN))
        {
            if (traps.ifactioncount(32))
            {
                traps.SetAction(ASATWAIT);
                traps.Move(TURRVEL, faceplayer);
            }
        }
        else
        if (traps.ifaction(ASATSHOOTING))
        {
            if (traps.ifactioncount(12))
                if (traps.ifrnd(32))
                {
                    traps.SetAction(ASATWAIT);
                    traps.Move(0);
                }
            if (traps.ifcount(32))
                traps.resetcount();
            else
            if (traps.ifcount(16))
            {
                if (traps.ifcount(17))
                {
                }
                else
                {
                    traps.sound(PRED_ATTACK);
                    traps.shoot(FIRELASER);
                }
            }
            else
            if (traps.ifcount(4))
            {
                if (traps.ifcount(5))
                {
                }
                else
                {
                    if (traps.ifcansee())
                        if (traps.ifcanshoottarget())
                        {
                            traps.sound(PRED_ATTACK);
                            traps.shoot(FIRELASER);
                        }
                }
            }
        }
        else
        if (traps.ifaction(ASATWAIT))
        {
            if (traps.ifactioncount(64))
                if (traps.ifrnd(32))
                    if (traps.ifp(palive))
                        if (traps.ifcansee())
                        {
                            traps.SetAction(ASATSHOOTING);
                            traps.Move(TURRVEL, faceplayer);
                        }
        }
        if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                traps.addkills(1);
                traps.sound(LASERTRIP_EXPLODE);
                traps.debris(SCRAP1, 15);
                traps.spawn(EXPLOSION2);
                traps.killit();
            }
            else
            {
                traps.SetAction(ASATNSPIN);
                traps.debris(SCRAP1, 4);
            }
            traps.Move(0);
        }
    }
    static ConAction RIP_F = new ConAction(0, 8, 1, 1, 1);
    private void A_FORCERIPPLE()
    {
        if (traps.ifactioncount(8))
            traps.killit();
    }
    static ConAction TRANSFOWARD = new ConAction(0, 6, 1, 1, 2);
    static ConAction TRANSBACK = new ConAction(5, 6, 1, -1, 2);
    private void A_TRANSPORTERSTAR()
    {
        if (traps.ifaction(TRANSFOWARD))
        {
            if (traps.ifactioncount(6))
                traps.SetAction(TRANSBACK);
        }
        else
        if (traps.ifactioncount(6))
            traps.killit();
    }
    static ConAction BEAMFOWARD = new ConAction(0, 4, 1, 1, 9);
    private void A_TRANSPORTERBEAM()
    {
        traps.sizeto(32, 64);
        traps.sizeto(32, 64);
        traps.sizeto(32, 64);
        if (traps.ifactioncount(4))
            traps.killit();
    }
    private void getcode()
    {
        if (traps.ifactor(ATOMICHEALTH))
            traps.globalsound(GETATOMICHEALTH);
        else
            traps.globalsound(DUKE_GET);
        traps.palfrom(16, 0, 32);
        if (traps.ifrespawn())
        {
            traps.Move(RESPAWN_ACTOR_FLAG);
            traps.spawn(RESPAWNMARKERRED);
            traps.cstat(32768);
        }
        else
            traps.killit();
    }
    private void randgetweapsnds()
    {
        if (traps.ifrnd(64))
            traps.globalsound(DUKE_GETWEAPON1);
        else
        if (traps.ifrnd(96))
            traps.globalsound(DUKE_GETWEAPON2);
        else
        if (traps.ifrnd(128))
            traps.globalsound(DUKE_GETWEAPON3);
        else
        if (traps.ifrnd(140))
            traps.globalsound(DUKE_GETWEAPON4);
        else
            traps.globalsound(DUKE_GETWEAPON6);
    }
    private void getweaponcode()
    {
        randgetweapsnds();
        traps.palfrom(32, 0, 32);
        if (traps.ifgotweaponce(1))
            return;
        if (traps.ifrespawn())
        {
            traps.Move(RESPAWN_ACTOR_FLAG);
            traps.spawn(RESPAWNMARKERRED);
            traps.cstat(32768);
        }
        else
            traps.killit();
    }
    private void respawnit()
    {
        if (traps.ifcount(RESPAWNITEMTIME))
        {
            traps.spawn(TRANSPORTERSTAR);
            traps.Move(0);
            traps.cstat(0);
            traps.sound(TELEPORTER);
        }
    }
    private void quikget()
    {
        if (traps.ifactor(ATOMICHEALTH))
            traps.globalsound(GETATOMICHEALTH);
        else
            traps.globalsound(DUKE_GET);
        traps.palfrom(16, 0, 32);
        traps.killit();
    }
    private void quikweaponget()
    {
        randgetweapsnds();
        traps.palfrom(32, 0, 32);
        if (traps.ifgotweaponce(1))
            return;
        traps.killit();
    }
   
    static ConAction FIRE_FRAMES = new ConAction(-1, 14, 1, 1, 1);
    static MoveAction FIREVELS = new MoveAction();
    private void firestate()
    {
        if (traps.ifaction(null))
            if (traps.ifrnd(16))
            {
                traps.SetAction(FIRE_FRAMES);
                traps.cstator(128);
            }
        traps.sleeptime(300);
        if (traps.ifspawnedby(FIRE))
        {
            if (traps.ifgapzl(16))
                return;
        }
        else
        if (traps.ifspawnedby(FIRE2))
        {
            if (traps.ifgapzl(16))
                return;
        }
        if (traps.ifinwater())
            traps.killit();
        if (traps.ifp(palive))
            if (traps.ifpdistl(844))
                if (traps.ifrnd(32))
                    if (traps.ifcansee())
                    {
                        traps.soundonce(DUKE_LONGTERM_PAIN);
                        traps.addphealth(-1);
                        traps.palfrom(32, 32);
                    }
        if (traps.ifactor(FIRE))
        {
            if (traps.ifspawnedby(FIRE))
                return;
        }
        else
        if (traps.ifactor(FIRE2))
            if (traps.ifspawnedby(FIRE2))
                return;
        if (traps.iffloordistl(128))
        {
            if (traps.ifrnd(128))
            {
                if (traps.ifcount(84))
                    traps.killit();
                else
                if (traps.ifcount(42))
                    traps.sizeto(0, 0);
                else
                    traps.sizeto(32, 32);
            }
        }
        else
            traps.killit();
    }
    private void A_FIRE()
    {
        firestate();
    }
    private void A_FIRE2()
    {
        firestate();
    }
    private void A_FECES()
    {
        if (traps.ifcount(24))
        {
            if (traps.ifpdistl(RETRIEVEDISTANCE))
            {
                if (traps.ifrnd(SWEARFREQUENCY))
                    traps.soundonce(DUKE_STEPONFECES);
                traps.sound(STEPNIT);
                traps.spawn(BLOODPOOL);
                traps.killit();
            }
        }
        else
            traps.sizeto(32, 32);
    }
    private void drop_ammo()
    {
        if (traps.ifrnd(SPAWNAMMOODDS))
            traps.spawn(AMMO);
    }
    private void drop_battery()
    {
        if (traps.ifrnd(SPAWNAMMOODDS))
            traps.spawn(BATTERYAMMO);
    }
    private void drop_sgshells()
    {
        if (traps.ifrnd(SPAWNAMMOODDS))
            traps.spawn(SHOTGUNAMMO);
    }
    private void drop_shotgun()
    {
        if (traps.ifrnd(SPAWNAMMOODDS))
            traps.spawn(SHOTGUNSPRITE);
    }
    private void drop_chaingun()
    {
        if (traps.ifrnd(SPAWNAMMOODDS))
        {
            if (traps.ifrnd(32))
                traps.spawn(CHAINGUNSPRITE);
            else
                traps.spawn(BATTERYAMMO);
        }
    }

    private void A_KNEE()
    {
    }
    private void A_SPIT()
    {
    }
    private void A_CHAINGUN()
    {
    }
    private void A_SHOTGUN()
    {
    }
    private void A_FIRELASER()
    {
    }
    private void A_HEAVYHBOMB()
    {
    }
    private void A_BOUNCEMINE()
    {
    }
    private void A_MORTER()
    {
    }
    private void A_SHRINKSPARK()
    {
    }
    private void A_GROWSPARK()
    {
        if (traps.ifcount(18))
            traps.killit();
        else
        if (traps.ifcount(9))
        {
            traps.sizeto(0, 0);
            traps.sizeto(0, 0);
            traps.sizeto(0, 0);
            traps.sizeto(0, 0);
        }
        else
        {
            traps.sizeto(28, 28);
            traps.sizeto(28, 28);
            traps.sizeto(28, 28);
            traps.sizeto(28, 28);
        }
    }
    private void A_RPG()
    {
    }
    private void A_FREEZEBLAST()
    {
    }
    private void A_DEVISTATORBLAST()
    {
    }
    private void A_COOLEXPLOSION1()
    {
    }
    private void A_TRIPBOMB()
    {
    }
    static ConAction WEAP2FRAMES = new ConAction(0, 4, 1, 1, 6);
    private void A_SHOTSPARK1()
    {
        if (traps.ifdead())
            traps.killit();
        if (traps.ifactioncount(4))
            traps.killit();
        else
        {
            if (traps.ifactioncount(3))
            {
                if (traps.ifinwater())
                    traps.spawn(WATERBUBBLE);
            }
            else
            if (traps.ifcount(2))
            {
            }
            else
            if (traps.ifonwater())
                traps.spawn(WATERSPLASH2);
        }
    }

   
    private void A_ORGANTIC()
    {
        if (traps.ifcount(48))
            traps.resetcount();
        else
        {
            if (traps.ifcount(32))
                traps.sizeto(32, 32);
        }
        if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                traps.addkills(1);
                traps.sound(TURR_DYING);
                traps.guts(JIBS5, 10);
                traps.killit();
            }
            traps.sound(TURR_PAIN);
            return;
        }
        if (traps.ifrnd(1))
            traps.soundonce(TURR_ROAM);
    }
    private void rf()
    {
        if (traps.ifrnd(128))
            traps.cstat(4);
        else
            traps.cstat(0);
    }

    public const int CANNONBALLSTRENGTH = 400;
    static MoveAction CANNONBALL1 = new MoveAction(512, 0);
    static MoveAction CANNONBALL2 = new MoveAction(512, 10);
    static MoveAction CANNONBALL3 = new MoveAction(512, 20);
    static MoveAction CANNONBALL4 = new MoveAction(512, 40);
    static MoveAction CANNONBALL5 = new MoveAction(512, 80);
    private void A_CANNONBALL()
    {
        if (traps.ifaction(null))
        {
            traps.sizeat(32, 32);
            traps.cstat(257);
            traps.SetAction(ANULLACTION);
        }
        if (traps.ifactioncount(46))
        {
            if (traps.ifactioncount(47))
            {
            }
            else
                traps.Move(CANNONBALL5, geth, getv);
        }
        else
        if (traps.ifactioncount(44))
        {
            if (traps.ifactioncount(45))
            {
            }
            else
                traps.Move(CANNONBALL4, geth, getv);
        }
        else
        if (traps.ifactioncount(40))
        {
            if (traps.ifactioncount(41))
            {
            }
            else
                traps.Move(CANNONBALL3, geth, getv);
        }
        else
        if (traps.ifactioncount(32))
        {
            if (traps.ifactioncount(33))
            {
            }
            else
                traps.Move(CANNONBALL2, geth, getv);
        }
        else
        if (traps.ifactioncount(16))
        {
            if (traps.ifactioncount(17))
            {
            }
            else
                traps.Move(CANNONBALL1, geth, getv);
        }
        if (traps.ifnotmoving())
        {
            traps.spawn(EXPLOSION2);
            traps.sound(PIPEBOMB_EXPLODE);
            traps.hitradius(4096, WEAKEST, WEAK, MEDIUMSTRENGTH, TOUGH);
            traps.killit();
        }
        if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                traps.spawn(EXPLOSION2);
                traps.hitradius(4096, WEAKEST, WEAK, MEDIUMSTRENGTH, TOUGH);
                traps.killit();
            }
            else
                traps.debris(SCRAP1, 3);
        }
    }
    public const int CANNONBALLS = 1818;
    public const int CANNONBALLSSTRENGTH = 10;
    static MoveAction CANNONBALLSVEL = new MoveAction();
    private void A_CANNONBALLS()
    {
        if (traps.ifaction(null))
        {
            traps.cstator(257);
            traps.SetAction(ANULLACTION);
        }
        if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                traps.spawn(EXPLOSION2);
                traps.hitradius(4096, WEAKEST, WEAK, MEDIUMSTRENGTH, TOUGH);
                traps.killit();
            }
            else
                traps.debris(SCRAP1, 3);
        }
    }
    public const int CANNON = 1810;
    public const int CANNONSTRENGTH = 400;
    static ConAction ACANNONWAIT = new ConAction(0, 1, 7, 1, 1);
    static ConAction ACANNONSHOOTING = new ConAction(0, 1, 7, 1, 1);
    static MoveAction CANNONSTOP = new MoveAction();
    private void A_CANNON()
    {
        if (traps.ifaction(null))
        {
            traps.SetAction(ACANNONWAIT);
        }
        else
        if (traps.ifaction(ACANNONSHOOTING))
        {
            traps.spawn(CANNONBALL);
            traps.SetAction(ACANNONWAIT);
        }
        else
        if (traps.ifaction(ACANNONWAIT))
        {
            if (traps.ifactioncount(64))
            {
                if (traps.ifrnd(128))
                    traps.SetAction(ACANNONSHOOTING);
                else
                    traps.resetactioncount();
            }
        }
        if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                traps.addkills(1);
                traps.hitradius(4096, WEAKEST, WEAK, MEDIUMSTRENGTH, TOUGH);
                traps.spawn(EXPLOSION2);
                traps.killit();
            }
            else
                traps.debris(SCRAP1, 3);
        }
        if (traps.ifpdistl(1024))
            if (traps.ifhitspace())
            {
                if (traps.ifp(pfacing))
                    if (traps.ifcanshoottarget())
                        traps.spawn(CANNONBALL);
                    else
                        return;
            }
    }
    private void A_HOTMEAT()
    {
        if (traps.ifaction(null))
        {
            traps.SetAction(ANULLACTION);
            traps.cstat(257);
        }
        if (traps.ifhitweapon())
        {
            if (traps.ifdead())
            {
                traps.sound(SQUISHED);
                traps.guts(JIBS5, 8);
                traps.guts(JIBS6, 9);
                traps.killit();
            }
            else
                traps.guts(JIBS6, 1);
        }
        if (traps.ifrnd(1))
            traps.spawn(WATERDRIP);
    }
    static ConAction ASPEAKERBROKE = new ConAction(1);
    private void A_SPEAKER()
    {
        if (traps.ifaction(null))
        {
            if (traps.ifhitweapon())
            {
                traps.stopsound(STORE_MUSIC);
                traps.soundonce(STORE_MUSIC_BROKE);
                traps.SetAction(ASPEAKERBROKE);
            }
            else
            {
                if (traps.ifpdistl(10240))
                    traps.soundonce(STORE_MUSIC);
                traps.cstat(289);
            }
        }
    }
    static ConAction ALAVABUBBLE = new ConAction();
    static ConAction ALAVABUBBLEANIM = new ConAction(0, 5, 1, 1, 16);
    private void A_LAVABUBBLE()
    {
        if (traps.ifaction(null))
        {
            traps.cstat(32768);
            traps.SetAction(ALAVABUBBLE);
        }
        else
        if (traps.ifaction(ALAVABUBBLE))
        {
            if (traps.ifcount(72))
                if (traps.ifrnd(2))
                {
                    traps.cstat(0);
                    traps.SetAction(ALAVABUBBLEANIM);
                }
        }
        else
        {
            if (traps.ifactioncount(5))
            {
                traps.cstat(32768);
                traps.SetAction(ALAVABUBBLE);
            }
        }
    }
}
