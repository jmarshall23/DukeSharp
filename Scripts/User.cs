﻿public partial class ConScript
{
    private ConTraps traps;

    public ConScript(ConTraps traps)
    {
        this.traps = traps;

        Init();
        InitVoxels();
        RegisterActors();
    }

    private void Init()
    {
        traps.gamestartup(DEFAULTVISIBILITY, GENERICIMPACTDAMAGE, MAXPLAYERHEALTH, STARTARMORHEALTH, RESPAWNACTORTIME, RESPAWNITEMTIME, RUNNINGSPEED, GRAVITATIONALCONSTANT, RPGBLASTRADIUS, PIPEBOMBRADIUS, SHRINKERBLASTRADIUS, TRIPBOMBBLASTRADIUS, MORTERBLASTRADIUS, BOUNCEMINEBLASTRADIUS, SEENINEBLASTRADIUS, MAXPISTOLAMMO, MAXSHOTGUNAMMO, MAXCHAINGUNAMMO, MAXRPGAMMO, MAXHANDBOMBAMMO, MAXSHRINKERAMMO, MAXDEVISTATORAMMO, MAXTRIPBOMBAMMO, MAXFREEZEAMMO, MAXGROWAMMO, CAMERASDESTRUCTABLE, NUMFREEZEBOUNCES, FREEZERHURTOWNER, QSIZE, TRIPBOMBLASERMODE);

        traps.definequote(0, "AUTO AIMING ");
        traps.definequote(1, "SHOW MAP: OFF ");
        traps.definequote(2, "ACTIVATED ");
        traps.definequote(3, "PORTABLE MEDKIT ");
        traps.definequote(4, "LOCKED ");
        traps.definequote(5, "GIVING EVERYTHING! ");
        traps.definequote(6, "BOOTS ");
        traps.definequote(7, "WASTED! ");
        traps.definequote(8, "UNLOCKED ");
        traps.definequote(9, "A SECRET PLACE! ");
        traps.definequote(10, "SQUISH! ");
        traps.definequote(11, "ALL DOORS UNLOCKED ");
        traps.definequote(12, "USED STEROIDS ");
        traps.definequote(13, "PRESS SPACE TO RESTART LEVEL ");
        traps.definequote(14, "AMMO FOR DEVASTATOR ");
        traps.definequote(15, "DEACTIVATED ");
        traps.definequote(16, "SWITCH OPERATED ONLY! ");
        traps.definequote(17, "GOD MODE: ON ");
        traps.definequote(18, "GOD MODE: OFF ");
        traps.definequote(19, "ATOMIC HEALTH! ");
        traps.definequote(20, "CROSSHAIR: ON ");
        traps.definequote(21, "CROSSHAIR: OFF ");
        traps.definequote(22, "YOU'RE TOO GOOD TO BE CHEATING! ");
        traps.definequote(23, "MESSAGES: ON ");
        traps.definequote(24, "MESSAGES: OFF ");
        traps.definequote(25, "TYPE THE CHEAT CODE: ");
        traps.definequote(26, "DETAIL: LOW ");
        traps.definequote(27, "DETAIL: HIGH ");
        traps.definequote(28, "WILL ALWAYS HAVE NO FUTURE ");
        traps.definequote(29, "BRIGHTNESS LEVEL: ONE ");
        traps.definequote(30, "BRIGHTNESS LEVEL: TWO ");
        traps.definequote(31, "BRIGHTNESS LEVEL: THREE ");
        traps.definequote(32, "BRIGHTNESS LEVEL: FOUR ");
        traps.definequote(33, "BRIGHTNESS LEVEL: FIVE ");
        traps.definequote(34, "SOUND: ON ");
        traps.definequote(35, "SOUND: OFF ");
        traps.definequote(36, "SCREEN CAPTURED ");
        traps.definequote(37, "STEROIDS ");
        traps.definequote(38, "ARMOR ");
        traps.definequote(39, "SCUBA GEAR ");
        traps.definequote(40, "Press F1 for Help ");
        traps.definequote(41, "JETPACK ");
        traps.definequote(42, "BODY SUIT ");
        traps.definequote(43, "ACCESS CARD ");
        traps.definequote(44, "MOUSE AIMING OFF ");
        traps.definequote(45, "MOUSE AIMING ON ");
        traps.definequote(46, "CHEAT CODE: UNRECOGNIZED ");
        traps.definequote(47, "HOLODUKE ON ");
        traps.definequote(48, "HOLODUKE OFF ");
        traps.definequote(49, "HOLODUKE NOT FOUND YET! ");
        traps.definequote(50, "JETPACK NOT FOUND YET! ");
        traps.definequote(51, "HOLODUKE ");
        traps.definequote(52, "JETPACK ON ");
        traps.definequote(53, "JETPACK OFF ");
        traps.definequote(54, "CHAINGUN CANNON! ");
        traps.definequote(55, "PIPEBOMB! ");
        traps.definequote(56, "RPG! ");
        traps.definequote(57, "SHOTGUN ");
        traps.definequote(58, "LASER TRIPBOMB! ");
        traps.definequote(59, "FREEZETHROWER! ");
        traps.definequote(60, "GOT SHRINKER/EXPANDER! ");
        traps.definequote(61, "SMALL MEDKIT: +10 ");
        traps.definequote(62, "LARGE MEDKIT: +30 ");
        traps.definequote(63, "AMMO FOR CHAINGUN CANNON! ");
        traps.definequote(64, "AMMO FOR RPG! ");
        traps.definequote(65, "AMMO FOR PISTOL! ");
        traps.definequote(66, "AMMO FOR FREEZETHROWER! ");
        traps.definequote(67, "BOOTS OFF ");
        traps.definequote(68, "BOOTS ON ");
        traps.definequote(69, "AMMO FOR SHOTGUN ");
        traps.definequote(70, "BLUE ACCESS CARD REQUIRED ");
        traps.definequote(71, "RED ACCESS CARD REQUIRED ");
        traps.definequote(72, "YELLOW ACCESS CARD REQUIRED ");
        traps.definequote(73, "WEAPON LOWERED ");
        traps.definequote(74, "WEAPON RAISED ");
        traps.definequote(75, "PROTECTIVE BOOTS ON ");
        traps.definequote(76, "SCUBA GEAR ON ");
        traps.definequote(77, "SPACE SUIT ON ");
        traps.definequote(78, "AMMO FOR SHRINKER ");
        traps.definequote(79, "BUY MAJOR STRYKER ");
        traps.definequote(80, "MIGHTY FOOT ENGAGED ");
        traps.definequote(81, "WEAPON MODE ON ");
        traps.definequote(82, "WEAPON MODE OFF ");
        traps.definequote(83, "FOLLOW MODE OFF ");
        traps.definequote(84, "FOLLOW MODE ON ");
        traps.definequote(85, "RUN MODE OFF ");
        traps.definequote(86, "RUN MODE ON ");
        traps.definequote(87, "DEVASTATOR WEAPON ");
        traps.definequote(88, "JET PACK ");
        traps.definequote(89, "AIRTANK ");
        traps.definequote(90, "STEROIDS ");
        traps.definequote(91, "HOLODUKE ");
        traps.definequote(92, "MUSIC: ON ");
        traps.definequote(93, "MUSIC: OFF ");
        traps.definequote(94, "SCROLL MODE: ON ");
        traps.definequote(95, "SCROLL MODE: OFF ");
        traps.definequote(96, "BRIGHTNESS LEVEL: SIX ");
        traps.definequote(97, "BRIGHTNESS LEVEL: SEVEN ");
        traps.definequote(98, "BRIGHTNESS LEVEL: EIGHT ");
        traps.definequote(99, "REGISTER COSMO TODAY! ");
        traps.definequote(100, "ALL LOCKS TOGGLED ");
        traps.definequote(101, "NIGHT VISION GOGGLES ");
        traps.definequote(102, "WE'RE GONNA FRY YOUR ASS, NUKEM! ");
        traps.definequote(103, "SCREEN SAVED ");
        traps.definequote(104, "GOT USED ARMOR ");
        traps.definequote(105, "PIRATES SUCK! ");
        traps.definequote(106, "NIGHT VISION ON ");
        traps.definequote(107, "NIGHT VISION OFF ");
        traps.definequote(108, "YOU'RE BURNING! ");
        traps.definequote(109, "VIEW MODE OFF ");
        traps.definequote(110, "VIEW MODE ON ");
        traps.definequote(111, "SHOW MAP: ON ");
        traps.definequote(112, "CLIPPING: ON ");
        traps.definequote(113, "CLIPPING: OFF ");
        traps.definequote(114, "!!! INCORRECT VERSION !!! ");
        traps.definequote(115, "<Please Leave Blank> ");
        traps.definequote(116, "<Please Leave Blank> ");
        traps.definequote(117, "<Please Leave Blank> ");
        traps.definequote(118, "YOU CANNOT QUICK SAVE WHEN DEAD ");
        traps.definequote(119, "GOT ALL WEAPONS/AMMO ");
        traps.definequote(120, "GOT ALL INVENTORY ");
        traps.definequote(121, "GOT ALL KEYS ");
        traps.definequote(122, "<Please Leave Blank> ");
        traps.definequote(123, "AMMO FOR EXPANDER ");
        traps.definequote(124, "MAP HAS A DIFFERENT NUMBER OF PLAYERS ");
        traps.definevolumename(0, "L.A. MELTDOWN ");
        traps.definevolumename(1, "LUNAR APOCALYPSE ");
        traps.definevolumename(2, "SHRAPNEL CITY ");
        traps.definevolumename(3, "THE BIRTH ");
        traps.defineskillname(0, "PIECE OF CAKE ");
        traps.defineskillname(1, "LET'S ROCK ");
        traps.defineskillname(2, "COME GET SOME ");
        traps.defineskillname(3, "DAMN I'M GOOD ");
        traps.definelevelname(0, 0, "E1L1.map", "01:45", "00:53", "HOLLYWOOD HOLOCAUST ");
        traps.definelevelname(0, 1, "E1L2.map", "05:10", "03:21", "RED LIGHT DISTRICT ");
        traps.definelevelname(0, 2, "E1L3.map", "05:35", "03:41", "DEATH ROW ");
        traps.definelevelname(0, 3, "E1L4.map", "07:20", "04:40", "TOXIC DUMP ");
        traps.definelevelname(0, 4, "E1L5.map", "09:10", "05:00", "THE ABYSS ");
        traps.definelevelname(0, 5, "E1L6.map", "05:15", "02:58", "LAUNCH FACILITY ");
        traps.definelevelname(0, 6, "E1L7.map", "00:00", "00:00", "FACES OF DEATH ");
        traps.definelevelname(0, 7, "E1L8.map", "99:99", "99:99", "USER MAP ");
        traps.definelevelname(0, 8, "E1L9.map", "12:48", "16:32", "VOID ZONE ");
        traps.definelevelname(0, 9, "E1L10.map", "0T:HX", "11:38", "ROACH CONDO ");
        traps.definelevelname(0, 10, "E1L11.map", "08:67", "53:09", "ANTIPROFIT ");
        traps.definelevelname(1, 0, "E2L1.map", "02:30", "01:19", "SPACEPORT ");
        traps.definelevelname(1, 1, "E2L2.map", "02:30", "01:26", "INCUBATOR ");
        traps.definelevelname(1, 2, "E2L3.map", "05:00", "02:26", "WARP FACTOR ");
        traps.definelevelname(1, 3, "E2L4.map", "04:30", "02:14", "FUSION STATION ");
        traps.definelevelname(1, 4, "E2L5.map", "03:00", "01:26", "OCCUPIED TERRITORY ");
        traps.definelevelname(1, 5, "E2L6.map", "02:30", "01:04", "TIBERIUS STATION ");
        traps.definelevelname(1, 6, "E2L7.map", "04:45", "02:15", "LUNAR REACTOR ");
        traps.definelevelname(1, 7, "E2L8.map", "11:30", "04:59", "DARK SIDE ");
        traps.definelevelname(1, 8, "E2L9.map", "05:00", "02:26", "OVERLORD ");
        traps.definelevelname(1, 9, "E2L10.map", "03:00", "01:19", "SPIN CYCLE ");
        traps.definelevelname(1, 10, "E2L11.map", "03:00", "00:52", "LUNATIC FRINGE ");
        traps.definelevelname(2, 0, "E3L1.map", "02:30", "01:11", "RAW MEAT ");
        traps.definelevelname(2, 1, "E3L2.map", "04:45", "02:18", "BANK ROLL ");
        traps.definelevelname(2, 2, "E3L3.map", "03:00", "01:57", "FLOOD ZONE ");
        traps.definelevelname(2, 3, "E3L4.map", "03:15", "01:46", "L.A. RUMBLE ");
        traps.definelevelname(2, 4, "E3L5.map", "02:30", "01:04", "MOVIE SET ");
        traps.definelevelname(2, 5, "E3L6.map", "03:30", "01:30", "RABID TRANSIT ");
        traps.definelevelname(2, 6, "E3L7.map", "02:00", "00:55", "FAHRENHEIT ");
        traps.definelevelname(2, 7, "E3L8.map", "02:15", "01:09", "HOTEL HELL ");
        traps.definelevelname(2, 8, "E3L9.map", "02:45", "01:17", "STADIUM ");
        traps.definelevelname(2, 9, "E3L10.map", "00:45", "00:10", "TIER DROPS ");
        traps.definelevelname(2, 10, "E3L11.map", "02:00", "01:07", "FREEWAY ");
        traps.definelevelname(3, 0, "E4L1.map", "03:04", "01:32", "IT'S IMPOSSIBLE ");
        traps.definelevelname(3, 1, "E4L2.map", "04:00", "02:00", "DUKE-BURGER ");
        traps.definelevelname(3, 2, "E4L3.map", "03:30", "01:45", "SHOP-N-BAG ");
        traps.definelevelname(3, 3, "E4L4.map", "06:32", "03:16", "BABE LAND ");
        traps.definelevelname(3, 4, "E4L5.map", "02:02", "01:01", "PIGSTY ");
        traps.definelevelname(3, 5, "E4L6.map", "03:04", "01:52", "GOING POSTAL ");
        traps.definelevelname(3, 6, "E4L7.map", "01:24", "00:42", "XXX-STACY ");
        traps.definelevelname(3, 7, "E4L8.map", "03:18", "01:59", "CRITICAL MASS ");
        traps.definelevelname(3, 8, "E4L9.map", "05:02", "02:51", "DERELICT ");
        traps.definelevelname(3, 9, "E4L10.map", "10:50", "05:25", "THE QUEEN ");
        traps.definelevelname(3, 10, "E4L11.map", "04:20", "02:10", "AREA 51 ");
        traps.definemusic(0, "GRABBAG.MID", "BRIEFING.MID");
        traps.definemusic(1, "stalker.mid", "dethtoll.mid", "streets.mid", "watrwld1.mid", "snake1.mid", "thecall.mid", "ahgeez.mid", "dethtoll.mid", "streets.mid", "watrwld1.mid", "snake1.mid");
        traps.definemusic(2, "futurmil.mid", "storm.mid", "gutwrnch.mid", "robocrep.mid", "stalag.mid", "pizzed.mid", "alienz.mid", "xplasma.mid", "alfredh.mid", "gloomy.mid", "intents.mid");
        traps.definemusic(3, "inhiding.mid", "FATCMDR.mid", "NAMES.MID", "subway.mid", "invader.mid", "gotham.mid", "233c.mid", "lordofla.mid", "urban.mid", "spook.mid", "whomp.mid");
        traps.definemusic(4, "missimp.mid", "prepd.mid", "bakedgds.mid", "cf.mid", "lemchill.mid", "pob.mid", "warehaus.mid", "layers.mid", "floghorn.mid", "depart.mid", "restrict.mid");
        traps.definesound(PRED_ROAM, "roam06.voc", 0, 0, 3, 0, 0);
        traps.definesound(PRED_ROAM2, "roam58.voc", 0, 0, 3, 0, 0);
        traps.definesound(PRED_RECOG, "predrg.voc", 0, 0, 3, 0, 0);
        traps.definesound(PRED_ATTACK, "gblasr01.voc", 256, 256, 3, 0, 7680);
        traps.definesound(PRED_PAIN, "predpn.voc", 200, 500, 3, 0, 0);
        traps.definesound(PRED_DYING, "preddy.voc", 0, 400, 3, 0, 0);
        traps.definesound(CAPT_ROAM, "predrm.voc", 0, 200, 3, 0, 0);
        traps.definesound(CAPT_RECOG, "predrg.voc", -400, 0, 3, 0, 0);
        traps.definesound(CAPT_ATTACK, "chaingun.voc", 0, 0, 3, 0, -200);
        traps.definesound(CAPT_PAIN, "predpn.voc", -200, 100, 3, 0, 0);
        traps.definesound(CAPT_DYING, "preddy.voc", -200, 100, 3, 0, 0);
        traps.definesound(LIZARD_SPIT, "lizspit.voc", 0, 0, 0, 0, 0);
        traps.definesound(LIZARD_BEG, "chokn12.voc", 0, 0, 3, 0, 0);
        traps.definesound(NEWBEAST_ROAM, "blroam2a.voc", -128, 128, 3, 0, 0);
        traps.definesound(NEWBEAST_RECOG, "blrec4b.voc", 1400, 0, 3, 0, 0);
        traps.definesound(NEWBEAST_ATTACK, "blrip1a.voc", -150, 150, 3, 0, 0);
        traps.definesound(NEWBEAST_ATTACKMISS, "blrip1b.voc", -256, 256, 3, 0, 0);
        traps.definesound(NEWBEAST_PAIN, "blpain1b.voc", -256, 256, 3, 0, 0);
        traps.definesound(NEWBEAST_DYING, "bldie3a.voc", 1200, 100, 3, 0, 0);
        traps.definesound(NEWBEAST_SPIT, "blspit1a.voc", -128, 128, 0, 0, 0);
        traps.definesound(PIG_ROAM, "roam29.voc", -200, 400, 3, 0, 0);
        traps.definesound(PIG_ROAM2, "roam67.voc", -200, 400, 3, 0, 0);
        traps.definesound(PIG_ROAM3, "pigrm.voc", -200, 400, 3, 0, 0);
        traps.definesound(PIG_RECOG, "pigrg.voc", -200, 400, 3, 0, 0);
        traps.definesound(PIG_ATTACK, "shotgun7.voc", -256, 256, 4, 0, 0);
        traps.definesound(PIG_PAIN, "pigpn.voc", 100, 800, 3, 0, 0);
        traps.definesound(PIG_DYING, "pigdy.voc", -800, 100, 3, 0, 0);
        traps.definesound(PIG_CAPTURE_DUKE, "!pig.voc", 0, 0, 255, 8, 0);
        traps.definesound(RECO_ROAM, "jetpaki.voc", 0, 0, 3, 0, 0);
        traps.definesound(RECO_RECOG, "pigrg.voc", 0, 0, 3, 0, 0);
        traps.definesound(RECO_ATTACK, "gblasr01.voc", 256, 256, 3, 0, 7680);
        traps.definesound(RECO_PAIN, "pigpn.voc", 0, 0, 3, 0, 0);
        traps.definesound(RECO_DYING, "pigdy.voc", 0, 0, 3, 0, 0);
        traps.definesound(DRON_ROAM, "snakrm.voc", 0, 0, 3, 0, 0);
        traps.definesound(DRON_RECOG, "snakrg.voc", 0, 0, 3, 0, 0);
        traps.definesound(DRON_ATTACK1, "snakatA.voc", 0, 0, 3, 0, 0);
        traps.definesound(DRON_ATTACK2, "snakatB.voc", 0, 0, 3, 0, 0);
        traps.definesound(DRON_PAIN, "snakpn.voc", 0, 0, 3, 0, 0);
        traps.definesound(DRON_DYING, "snakdy.voc", 0, 0, 3, 0, 0);
        traps.definesound(DRON_JETSND, "ENGHUM.VOC", 1300, 1300, 0, 0, 0);
        traps.definesound(COMM_ROAM, "commrm.voc", 0, 0, 3, 0, 0);
        traps.definesound(COMM_RECOG, "commrg.voc", 0, 0, 3, 0, 0);
        traps.definesound(COMM_ATTACK, "commat.voc", 0, 0, 3, 0, 0);
        traps.definesound(COMM_PAIN, "commpn.voc", 0, 0, 3, 0, 0);
        traps.definesound(COMM_DYING, "commdy.voc", 0, 0, 3, 0, 0);
        traps.definesound(COMM_SPIN, "commsp.voc", 0, 0, 3, 0, 0);
        traps.definesound(OCTA_ROAM, "octarm.voc", -200, 0, 3, 0, 0);
        traps.definesound(OCTA_RECOG, "octarg.voc", 0, 0, 3, 0, 0);
        traps.definesound(OCTA_ATTACK1, "octaat1.voc", 0, 0, 3, 0, 0);
        traps.definesound(OCTA_ATTACK2, "octaat2.voc", 0, 600, 3, 0, 0);
        traps.definesound(OCTA_PAIN, "octapn.voc", -400, 0, 3, 0, 0);
        traps.definesound(OCTA_DYING, "octady.voc", -400, -100, 3, 0, 0);
        traps.definesound(WIERDSHOT_FLY, "octaat1.voc", 0, 0, 3, 0, 0);
        traps.definesound(TURR_ROAM, "turrrm.voc", 0, 0, 3, 0, 0);
        traps.definesound(TURR_RECOG, "turrrg.voc", 0, 0, 3, 0, 0);
        traps.definesound(TURR_ATTACK, "turrat.voc", 0, 0, 3, 0, 0);
        traps.definesound(TURR_PAIN, "turrpn.voc", 0, 0, 3, 0, 0);
        traps.definesound(TURR_DYING, "turrdy.voc", 0, 0, 3, 0, 0);
        traps.definesound(SLIM_HATCH, "slhtch01.voc", -256, 256, 3, 0, 0);
        traps.definesound(SLIM_ROAM, "sliroa02.voc", -256, 256, 3, 0, 0);
        traps.definesound(SLIM_RECOG, "slirec06.voc", -256, 256, 3, 0, 0);
        traps.definesound(SLIM_ATTACK, "slimat.voc", -256, 256, 3, 0, 0);
        traps.definesound(SLIM_DYING, "slidie03.voc", -256, 256, 3, 0, 0);
        traps.definesound(BOS2_ROAM, "b2atk01.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS2_RECOG, "b2rec03.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS2_ATTACK, "b2atk02.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS2_PAIN, "b2pain03.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS2_DYING, "b2die03.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS3_ROAM, "b3roam01.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS3_RECOG, "b3pain04.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS3_ATTACK1, "b3atk01.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS3_ATTACK2, "b3atk01.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS3_PAIN, "b3rec03g.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS3_DYING, "b3die03g.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS4_ROAM, "bqroam2a.voc", 1024, 1024, 255, 0, 0);
        traps.definesound(BOS4_RECOG, "bqrec2a.voc", 1024, 1024, 255, 0, 3084);
        traps.definesound(BOS4_ATTACK, "bqshock3.voc", 1024, 1024, 255, 0, 0);
        traps.definesound(BOS4_PAIN, "bqpain2a.voc", 1024, 1024, 255, 0, 0);
        traps.definesound(BOS4_DYING, "bqdie1a.voc", 1024, 1024, 255, 0, 0);
        traps.definesound(BOS4_LAY, "bqegg1a.voc", 1024, 1024, 255, 0, 0);
        traps.definesound(BOS1_ROAM, "bos1rm.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS1_RECOG, "bos1rg.voc", 0, 0, 5, 0, 0);
        traps.definesound(BOS1_ATTACK1, "chaingun.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS1_ATTACK2, "rpgfire.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS1_PAIN, "bos1pn.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS1_DYING, "bos1dy.voc", 0, 0, 3, 0, 0);
        traps.definesound(BOS1_WALK, "thud.voc", 0, 0, 3, 0, 0);
        traps.definesound(KICK_HIT, "kickhit.voc", 0, 0, 4, 0, 0);
        traps.definesound(PISTOL_RICOCHET, "ricochet.voc", 0, 0, 0, 0, 4096);
        traps.definesound(PISTOL_BODYHIT, "bulithit.voc", 0, 0, 0, 0, 0);
        traps.definesound(PISTOL_FIRE, "pistol.voc", -64, 0, 254, 0, 0);
        traps.definesound(EJECT_CLIP, "clipout.voc", 0, 0, 3, 0, 0);
        traps.definesound(INSERT_CLIP, "clipin.voc", 512, 512, 3, 0, 0);
        traps.definesound(CHAINGUN_FIRE, "chaingun.voc", -204, -204, 254, 0, 512);
        traps.definesound(SHOTGUN_FIRE, "shotgun7.voc", 0, 512, 254, 0, 0);
        traps.definesound(SHOTGUN_COCK, "shotgnck.voc", 96, 192, 3, 0, 0);
        traps.definesound(RPG_SHOOT, "rpgfire.voc", -32, 0, 4, 0, 0);
        traps.definesound(FLY_BY, "flyby.voc", -256, 256, 3, 0, 0);
        traps.definesound(RPG_EXPLODE, "bombexpl.voc", -1024, 1024, 128, 0, 0);
        traps.definesound(CAT_FIRE, "catfire.voc", 512, 768, 4, 0, 0);
        traps.definesound(SHRINKER_FIRE, "shrinker.voc", -512, 0, 5, 0, 0);
        traps.definesound(ACTOR_SHRINKING, "shrink.voc", 0, 0, 2, 0, 0);
        traps.definesound(ACTOR_GROWING, "enlarge.voc", 1024, 0, 2, 0, 0);
        traps.definesound(PIPEBOMB_BOUNCE, "pbombbnc.voc", 0, 0, 2, 0, 6144);
        traps.definesound(PIPEBOMB_EXPLODE, "bombexpl.voc", -512, 0, 128, 0, 0);
        traps.definesound(LASERTRIP_ONWALL, "lsrbmbpt.voc", 0, 0, 3, 0, 0);
        traps.definesound(LASERTRIP_ARMING, "lsrbmbwn.voc", 0, 0, 3, 0, 0);
        traps.definesound(LASERTRIP_EXPLODE, "bombexpl.voc", -512, 0, 4, 0, 0);
        traps.definesound(NITEVISION_ONOFF, "goggle12.voc", 0, 0, 0, 0, 0);
        traps.definesound(SELECT_WEAPON, "WPNSEL21.VOC", 128, 128, 3, 0, 0);
        traps.definesound(VENT_BUST, "ventbust.voc", -32, 32, 2, 0, 0);
        traps.definesound(GLASS_BREAKING, "glass.voc", -412, 0, 3, 0, 8192);
        traps.definesound(GLASS_HEAVYBREAK, "glashevy.voc", -412, 0, 3, 0, 8192);
        traps.definesound(SHORT_CIRCUIT, "shorted.voc", 0, 0, 0, 0, 6500);
        traps.definesound(ITEM_SPLASH, "splash.voc", 0, 0, 2, 0, 0);
        traps.definesound(BONUSMUSIC, "bonus.voc", 0, 0, 255, 1, 0);
        traps.definesound(DUKE_BREATHING, "hlminhal.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_EXHALING, "hlmexhal.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_GASP, "gasp.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_URINATE, "pissing.voc", 0, 0, 4, 0, 0);
        traps.definesound(DUKE_CRACK2, "COMEON02.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_CRACK, "WAITIN03.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_TALKTOBOSSFALL, "DIESOB03.voc", 0, 0, 255, 12, 0);
        traps.definesound(DUKE_CRACK_FIRST, "knuckle.voc", 0, 0, 3, 0, 0);
        traps.definesound(DUKE_GET, "getitm19.voc", -64, 64, 255, 0, 0);
        traps.definesound(DUKE_GETWEAPON1, "cool01.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_GETWEAPON2, "getsom1a.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_GETWEAPON3, "groovy02.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_GETWEAPON4, "wansom4a.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_GETWEAPON6, "HAIL01.VOC", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_GOTHEALTHATLOW, "needed03.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_SEARCH, "pain87.VOC", 0, 0, 2, 4, 0);
        traps.definesound(DUKE_SEARCH2, "whrsit05.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_LONGTERM_PAIN, "gasps07.voc", -192, 0, 255, 4, 0);
        traps.definesound(DUKE_LONGTERM_PAIN2, "dscrem15.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_LONGTERM_PAIN3, "dscrem16.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_LONGTERM_PAIN4, "dscrem17.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_LONGTERM_PAIN5, "pain54.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_LONGTERM_PAIN6, "pain75.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_LONGTERM_PAIN7, "pain93.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_LONGTERM_PAIN8, "pain68.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_PISSRELIEF, "ahmuch03.voc", 0, 0, 255, 4, 0);
        traps.definesound(SOMETHINGHITFORCE, "teleport.voc", 0, 0, 2, 0, 8192);
        traps.definesound(DUKE_DRINKING, "drink18.voc", -128, 128, 2, 4, 0);
        traps.definesound(DUKE_KILLED1, "damn03.voc", 0, 0, 255, 12, 0);
        traps.definesound(DUKE_KILLED2, "damnit04.voc", 0, 0, 255, 12, 0);
        traps.definesound(DUKE_KILLED3, "thsuk13a.voc", 0, 0, 255, 12, 0);
        traps.definesound(DUKE_KILLED4, "dscrem18.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_KILLED5, "pisses01.voc", 0, 0, 255, 12, 0);
        traps.definesound(DUKE_GRUNT, "exert.voc", 0, 0, 2, 4, 0);
        traps.definesound(DUKE_DEAD, "DMDEATH.VOC", -64, 64, 255, 4, 0);
        traps.definesound(DUKE_HARTBEAT, "hartbeat.voc", 0, 0, 0, 0, 0);
        traps.definesound(DUKE_STEPONFECES, "happen01.voc", 0, 0, 0, 12, 0);
        traps.definesound(DUKE_ONWATER, "wetfeet.voc", 0, 0, 4, 0, 0);
        traps.definesound(DUKE_LAND, "land02.voc", 0, 0, 2, 0, 0);
        traps.definesound(DUKE_LAND_HURT, "pain39.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_WALKINDUCTS, "ductwlk.voc", -64, 128, 2, 0, 0);
        traps.definesound(DUKE_LOOKINTOMIRROR, "lookin01.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_TIP1, "dance01.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_TIP2, "shake2a.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_BOOBY, "BOOBY04.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_HIT_STRIPPER1, "damnit04.voc", 0, 0, 255, 12, 0);
        traps.definesound(DUKE_HIT_STRIPPER2, "damn03.voc", 0, 0, 255, 12, 0);
        traps.definesound(ALIEN_TALK1, "MUSTDIE.voc", 0, 0, 255, 12, 0);
        traps.definesound(ALIEN_TALK2, "DEFEATED.VOC", 0, 0, 255, 12, 0);
        traps.definesound(BONUS_SPEECH1, "letsrk03.voc", 0, 0, 255, 4, 0);
        traps.definesound(BONUS_SPEECH2, "ready2a.voc", 0, 0, 255, 4, 0);
        traps.definesound(BONUS_SPEECH3, "ripem08.voc", 0, 0, 255, 4, 0);
        traps.definesound(BONUS_SPEECH4, "rockin02.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_YES, "yes.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_USEMEDKIT, "ahh04.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKE_TAKEPILLS, "gulp01.voc", 0, 0, 255, 4, 0);
        traps.definesound(DUKETALKTOBOSS, "duknuk14.voc", 0, 0, 255, 12, 0);
        traps.definesound(BOSSTALKTODUKE, "!boss.voc", 0, 0, 255, 0, 0);
        traps.definesound(SHRINKER_HIT, "thud.voc", 0, 0, 3, 0, 0);
        traps.definesound(SOMETHINGFROZE, "freeze.voc", 0, 0, 3, 0, 0);
        traps.definesound(DUKE_UNDERWATER, "scuba.voc", 0, 0, 2, 0, 0);
        traps.definesound(DUKE_JETPACK_ON, "jetpakon.voc", 0, 0, 4, 0, 0);
        traps.definesound(DUKE_JETPACK_IDLE, "jetpaki.voc", 0, 0, 1, 0, 0);
        traps.definesound(DUKE_JETPACK_OFF, "jetpakof.voc", 0, 0, 2, 0, 0);
        traps.definesound(FLESH_BURNING, "fire09.voc", -256, 0, 0, 0, 6100);
        traps.definesound(THUD, "thud.voc", 0, 0, 0, 0, 0);
        traps.definesound(SQUISHED, "squish.voc", -128, 0, 3, 0, 0);
        traps.definesound(TELEPORTER, "teleport.voc", 0, 0, 0, 0, 0);
        traps.definesound(ELEVATOR_ON, "gbelev01.voc", 0, 0, 0, 0, 0);
        traps.definesound(ELEVATOR_OFF, "gbelev02.voc", 0, 0, 0, 0, 0);
        traps.definesound(ALIEN_ELEVATOR1, "hydro43.voc", 0, 0, 0, 0, 0);
        traps.definesound(SUBWAY, "subway.voc", 0, 0, 0, 0, 0);
        traps.definesound(SWITCH_ON, "switch.voc", 0, 0, 0, 0, 0);
        traps.definesound(FAN, "fan.voc", 0, 0, 0, 0, 0);
        traps.definesound(FLUSH_TOILET, "flush.voc", 0, 0, 3, 2, 0);
        traps.definesound(HOVER_CRAFT, "hover.voc", 0, 0, 0, 0, 0);
        traps.definesound(EARTHQUAKE, "quake.voc", 0, 0, 0, 0, 0);
        traps.definesound(INTRUDER_ALERT, "alert.voc", 0, 0, 0, 0, 0);
        traps.definesound(END_OF_LEVEL_WARN, "monitor.voc", 0, 0, 0, 0, 0);
        traps.definesound(POOLBALLHIT, "poolbal1.voc", 0, 0, 0, 0, 0);
        traps.definesound(ENGINE_OPERATING, "onboard.voc", 0, 0, 0, 2, 0);
        traps.definesound(REACTOR_ON, "reactor.voc", 0, 0, 0, 2, 0);
        traps.definesound(COMPUTER_AMBIENCE, "compamb.voc", 0, 0, 0, 2, 0);
        traps.definesound(GEARS_GRINDING, "geargrnd.voc", 0, 0, 0, 2, 0);
        traps.definesound(BUBBLE_AMBIENCE, "bubblamb.voc", -256, 0, 0, 2, 0);
        traps.definesound(MACHINE_AMBIENCE, "machamb.voc", 0, 0, 0, 2, 0);
        traps.definesound(SEWER_AMBIENCE, "drip3.voc", 0, 0, 0, 0, 0);
        traps.definesound(WIND_AMBIENCE, "wind54.voc", 0, 0, 0, 2, 0);
        traps.definesound(WIND_REPEAT, "wind54.voc", 0, 0, 0, 2, 0);
        traps.definesound(SOMETHING_DRIPPING, "drip3.voc", 0, 0, 0, 0, 9000);
        traps.definesound(STEAM_HISSING, "steamhis.voc", 0, 0, 0, 0, 10240);
        traps.definesound(BAR_MUSIC, "barmusic.voc", 0, 0, 254, 2, 0);
        traps.definesound(STORE_MUSIC, "muzak028.voc", 0, 0, 254, 0, 6144);
        traps.definesound(STORE_MUSIC_BROKE, "muzakdie.voc", 0, 0, 0, 0, 6144);
        traps.definesound(DUKE_SCREAM, "DSCREM04.voc", 0, 0, 0, 0, 0);
        traps.definesound(KILLME, "killme.voc", -128, 0, 0, 0, 0);
        traps.definesound(GETATOMICHEALTH, "teleport.voc", 2048, 2048, 255, 0, 0);
        traps.definesound(DOOR_OPERATE1, "slidoor.voc", -256, 0, 0, 0, 0);
        traps.definesound(DOOR_OPERATE2, "opendoor.voc", -256, 0, 0, 0, 0);
        traps.definesound(DOOR_OPERATE3, "edoor10.voc", -256, 0, 0, 0, 0);
        traps.definesound(DOOR_OPERATE4, "edoor11.voc", -256, 0, 0, 0, 0);
        traps.definesound(BORNTOBEWILDSND, "2bwild.voc", 0, 0, 254, 2, 0);
        traps.definesound(KTIT, "ktitx.voc", 0, 0, 254, 2, 0);
        traps.definesound(LADY_SCREAM, "FSCRM10.voc", -256, 0, 254, 8, 0);
        traps.definesound(MONITOR_ACTIVE, "monitor.voc", 0, 0, 0, 0, 0);
        traps.definesound(WATER_GURGLE, "h2ogrgl2.voc", 0, 0, 1, 2, 9000);
        traps.definesound(EXITMENUSOUND, "item15.voc", 0, 0, 0, 0, 0);
        traps.definesound(RATTY, "mice3.voc", 0, 0, 0, 0, 0);
        traps.definesound(INTO_MENU, "bulithit.voc", 1024, 1024, 0, 0, 0);
        traps.definesound(GENERIC_AMBIENCE1, "grind.voc", 0, 0, 0, 1, 0);
        traps.definesound(GENERIC_AMBIENCE2, "enghum.voc", 0, 0, 0, 2, 0);
        traps.definesound(GENERIC_AMBIENCE3, "lava06.voc", 0, 0, 0, 2, 0);
        traps.definesound(GENERIC_AMBIENCE4, "bubblamb.voc", -256, 0, 0, 2, 0);
        traps.definesound(GENERIC_AMBIENCE5, "phonbusy.voc", 0, 0, 0, 0, 0);
        traps.definesound(GENERIC_AMBIENCE6, "roam22.voc", 0, 0, 0, 2, 0);
        traps.definesound(SECRETLEVELSND, "secret.voc", 0, 0, 255, 0, 0);
        traps.definesound(GENERIC_AMBIENCE8, "amb81b.voc", 0, 0, 0, 2, 0);
        traps.definesound(GENERIC_AMBIENCE9, "roam98b.voc", 0, 0, 0, 2, 0);
        traps.definesound(GENERIC_AMBIENCE10, "h2orush2.voc", 0, 0, 0, 3, 0);
        traps.definesound(GENERIC_AMBIENCE11, "projrun.voc", 0, 0, 0, 3, 0);
        traps.definesound(GENERIC_AMBIENCE12, "drip3.voc", 0, 0, 0, 0, 0);
        traps.definesound(GENERIC_AMBIENCE13, "pay02.voc", 0, 0, 255, 12, 0);
        traps.definesound(GENERIC_AMBIENCE14, "onlyon03.voc", 0, 0, 255, 4, 0);
        traps.definesound(GENERIC_AMBIENCE15, "rides09.voc", 0, 0, 255, 4, 0);
        traps.definesound(GENERIC_AMBIENCE16, "doomed16.voc", 0, 0, 255, 4, 0);
        traps.definesound(GENERIC_AMBIENCE17, "myself3a.voc", 0, 0, 255, 4, 0);
        traps.definesound(GENERIC_AMBIENCE18, "monolith.voc", 0, 0, 0, 2, 0);
        traps.definesound(GENERIC_AMBIENCE19, "hydro50.voc", 0, 0, 0, 2, 0);
        traps.definesound(GENERIC_AMBIENCE20, "con03.voc", 0, 0, 0, 4, 0);
        traps.definesound(GENERIC_AMBIENCE21, "!prison.voc", 0, 0, 255, 4, 0);
        traps.definesound(GENERIC_AMBIENCE22, "vpiss2.voc", 0, 0, 255, 4, 0);
        traps.definesound(GENERIC_AMBIENCE23, "2ride06.voc", 0, 0, 255, 4, 0);
        traps.definesound(SUPERMARKET, "aisle402.voc", 0, 0, 0, 4, 0);
        traps.definesound(FIRE_CRACKLE, "fire09.voc", 0, 0, 254, 2, 0);
        traps.definesound(DUMPSTER_MOVE, "grind.voc", 0, 0, 0, 0, 0);
        traps.definesound(JIBBED_ACTOR1, "AMESS06.voc", 0, 0, 255, 4, 0);
        traps.definesound(JIBBED_ACTOR2, "BITCHN04.voc", 0, 0, 255, 12, 0);
        traps.definesound(JIBBED_ACTOR3, "HOLYCW01.voc", 0, 0, 255, 4, 0);
        traps.definesound(JIBBED_ACTOR4, "HOLYSH02.voc", 0, 0, 255, 12, 0);
        traps.definesound(JIBBED_ACTOR5, "IMGOOD12.voc", 0, 0, 255, 12, 0);
        traps.definesound(JIBBED_ACTOR6, "PIECE02.voc", 0, 0, 255, 4, 0);
        traps.definesound(JIBBED_ACTOR7, "GOTHRT01.voc", 0, 0, 255, 4, 0);
        traps.definesound(JIBBED_ACTOR8, "BLOWIT01.VOC", 0, 0, 255, 12, 0);
        traps.definesound(JIBBED_ACTOR9, "EATSHT01.VOC", 0, 0, 255, 12, 0);
        traps.definesound(JIBBED_ACTOR10, "FACE01.VOC", 0, 0, 255, 12, 0);
        traps.definesound(JIBBED_ACTOR11, "INHELL01.VOC", 0, 0, 255, 12, 0);
        traps.definesound(WHIPYOURASS, "WHIPYU01.VOC", 0, 0, 255, 4, 0);
        traps.definesound(JIBBED_ACTOR12, "SUKIT01.VOC", 0, 0, 255, 4, 0);
        traps.definesound(JIBBED_ACTOR13, "LETGOD01.VOC", 0, 0, 255, 12, 0);
        traps.definesound(JIBBED_ACTOR14, "getcrap1.voc", 0, 0, 0, 12, 0);
        traps.definesound(JIBBED_ACTOR15, "guysuk01.voc", 0, 0, 0, 12, 0);
        traps.definesound(WAR_AMBIENCE1, "WARAMB13.VOC", -512, 0, 255, 16, 0);
        traps.definesound(WAR_AMBIENCE2, "WARAMB21.VOC", -512, 0, 254, 16, 0);
        traps.definesound(WAR_AMBIENCE3, "WARAMB23.VOC", -512, 0, 254, 16, 0);
        traps.definesound(WAR_AMBIENCE4, "WARAMB29.VOC", -512, 0, 254, 16, 0);
        traps.definesound(WAR_AMBIENCE5, "FORCE01.VOC", 0, 0, 0, 4, 0);
        traps.definesound(WAR_AMBIENCE6, "QUAKE06.VOC", 0, 0, 0, 4, 0);
        traps.definesound(WAR_AMBIENCE7, "TERMIN01.VOC", 0, 0, 0, 4, 0);
        traps.definesound(WAR_AMBIENCE8, "BORN01.VOC", 0, 0, 254, 20, 0);
        traps.definesound(WAR_AMBIENCE9, "NOBODY01.VOC", 0, 0, 0, 4, 0);
        traps.definesound(WAR_AMBIENCE10, "CHEW05.VOC", 0, 0, 0, 12, 0);
        traps.definesound(SPACE_DOOR1, "hydro22.voc", 0, 0, 0, 0, 8192);
        traps.definesound(SPACE_DOOR2, "hydro24.voc", 0, 0, 0, 0, 0);
        traps.definesound(SPACE_DOOR3, "hydro27.voc", 0, 0, 0, 0, 8192);
        traps.definesound(SPACE_DOOR4, "hydro34.voc", 0, 0, 0, 0, 0);
        traps.definesound(SPACE_DOOR5, "hydro40.voc", 0, 0, 0, 0, 0);
        traps.definesound(SPACE_AMBIENCE1, "monolith.voc", 0, 0, 0, 16, 0);
        traps.definesound(SPACE_AMBIENCE2, "hydro50.voc", 0, 0, 0, 16, 0);
        traps.definesound(VAULT_DOOR, "vault04.voc", 0, 0, 0, 0, 0);
        traps.definesound(ALIEN_ELEVATOR1, "hydro43.voc", 0, 0, 0, 0, 0);
        traps.definesound(ALIEN_DOOR1, "adoor1.voc", 0, 0, 0, 0, 0);
        traps.definesound(ALIEN_DOOR2, "adoor2.voc", 0, 0, 0, 0, 0);
        traps.definesound(ALIEN_SWITCH1, "aswtch23.voc", 0, 0, 0, 0, 0);
        traps.definesound(COMPANB2, "CTRLRM25.VOC", 0, 0, 0, 2, 0);
        traps.definesound(HELICOP_IDLE, "hlidle03.voc", 0, 0, 255, 3, 0);
        traps.definesound(FOUNDJONES, "jones04.voc", 0, 0, 0, 4, 0);
        traps.definesound(STEPNIT, "LIZSHIT3.VOC", 0, 0, 254, 12, 0);
        traps.definesound(RIPHEADNECK, "rip01.voc", 0, 0, 254, 12, 0);
        traps.definesound(ENDSEQVOL2SND1, "gunhit2.voc", 0, 0, 249, 0, 0);
        traps.definesound(ENDSEQVOL2SND2, "headrip3.VOC", 0, 0, 250, 0, 0);
        traps.definesound(ENDSEQVOL2SND3, "buckle.VOC", 0, 0, 251, 0, 0);
        traps.definesound(ENDSEQVOL2SND4, "jetp2.VOC", 0, 0, 252, 0, 0);
        traps.definesound(ENDSEQVOL2SND5, "zipper2.voc", 0, 0, 253, 0, 0);
        traps.definesound(ENDSEQVOL2SND6, "news.voc", 0, 0, 254, 0, 0);
        traps.definesound(ENDSEQVOL2SND7, "whistle.voc", 0, 0, 255, 0, 0);
        traps.definesound(ENDSEQVOL3SND2, "GMEOVR05.VOC", 0, 0, 254, 0, 0);
        traps.definesound(ENDSEQVOL3SND3, "CHEER.VOC", 0, 0, 254, 0, 0);
        traps.definesound(ENDSEQVOL3SND4, "GRABBAG.VOC", 0, 0, 254, 1, 0);
        traps.definesound(ENDSEQVOL3SND5, "name01.voc", 0, 0, 250, 0, 0);
        traps.definesound(ENDSEQVOL3SND6, "r&r01.voc", 0, 0, 251, 0, 0);
        traps.definesound(ENDSEQVOL3SND7, "lani05.voc", 0, 0, 252, 0, 0);
        traps.definesound(ENDSEQVOL3SND8, "lani08.voc", 0, 0, 253, 0, 0);
        traps.definesound(ENDSEQVOL3SND9, "laniduk2.voc", 0, 0, 254, 0, 0);
        traps.definesound(SUPERMARKET, "aisle402.voc", 0, 0, 0, 4, 0);
        traps.definesound(MOUSEANNOY, "annoy03.voc", 0, 0, 0, 4, 0);
        traps.definesound(BOOKEM, "bookem03.voc", 0, 0, 0, 4, 0);
        traps.definesound(SUPERMARKETCRY, "cry01.voc", 0, 0, 0, 4, 0);
        traps.definesound(DESTRUCT, "detruct2.voc", 0, 0, 255, 0, 0);
        traps.definesound(EATFOOD, "eat08.voc", 0, 0, 0, 12, 0);
        traps.definesound(MAKEMYDAY, "makeday1.voc", 0, 0, 0, 4, 0);
        traps.definesound(WITNESSSTAND, "sohelp02.voc", 0, 0, 0, 4, 0);
        traps.definesound(VACATIONSPEECH, "vacatn01.voc", 0, 0, 0, 12, 0);
        traps.definesound(YIPPEE1, "yippie01.voc", 0, 0, 255, 12, 0);
        traps.definesound(YOHOO1, "yohoho01.voc", 0, 0, 128, 4, 0);
        traps.definesound(YOHOO2, "yohoho09.voc", 0, 0, 128, 4, 0);
        traps.definesound(DOLPHINSND, "dolphin.voc", -512, 512, 0, 0, 0);
        traps.definesound(TOUGHGALSND1, "dom03.voc", 0, 0, 0, 0, 0);
        traps.definesound(TOUGHGALSND2, "dom09.voc", 0, 0, 0, 0, 0);
        traps.definesound(TOUGHGALSND3, "dom11.voc", 0, 0, 0, 0, 0);
        traps.definesound(TOUGHGALSND4, "dom12.voc", 0, 0, 0, 0, 0);
        traps.definesound(TANK_ROAM, "tank3a.voc", 0, 0, 255, 0, 6000);
        traps.definesound(VOL4_1, "jacuzzi2.voc", 0, 0, 0, 1, 0);
        traps.definesound(VOL4_2, "typing.voc", 0, 0, 0, 1, 0);
        traps.definesound(COOKINGDEEPFRIER, "deepfry1.voc", 0, 0, 0, 0, 0);
        traps.definesound(WHINING_DOG, "dogwhine.voc", 0, 0, 0, 0, 0);
        traps.definesound(DEAD_DOG, "dogyelp.voc", 0, 0, 0, 0, 0);
        traps.definesound(LIGHTNING_SLAP, "tclap2a.voc", -256, 256, 0, 0, 0);
        traps.definesound(THUNDER, "trumble.voc", -512, 256, 0, 0, 0);
        traps.definesound(HAPPYMOUSESND1, "sweet03.voc", 0, 0, 0, 0, 0);
        traps.definesound(HAPPYMOUSESND2, "sweet04.voc", 0, 0, 0, 0, 0);
        traps.definesound(HAPPYMOUSESND3, "sweet05.voc", 0, 0, 0, 0, 0);
        traps.definesound(HAPPYMOUSESND4, "sweet16.voc", 0, 0, 0, 0, 0);
        traps.definesound(ALARM, "alarm1a.voc", -128, 128, 255, 2, 0);
        traps.definesound(RAIN, "rain3a.voc", -128, 128, 0, 2, 0);
        traps.definesound(DTAG_GREENRUN, "GRUN.VOC", -128, 128, 255, 128, 0);
        traps.definesound(DTAG_BROWNRUN, "BRUN.VOC", -128, 128, 255, 128, 0);
        traps.definesound(DTAG_GREENSCORE, "GSCORE.VOC", -128, 128, 255, 128, 0);
        traps.definesound(DTAG_BROWNSCORE, "BSCORE.VOC", -128, 128, 255, 128, 0);
        traps.definesound(SCREECH, "skidcr1.voc", -128, 128, 4, 0, 0);
        traps.definesound(INTRO4_1, "intro4h1.voc", 0, 0, 255, 0, 0);
        traps.definesound(INTRO4_B, "intro4h2.voc", 0, 0, 255, 0, 0);
        traps.definesound(INTRO4_2, "typing.voc", 0, 0, 255, 0, 0);
        traps.definesound(INTRO4_3, "introa.voc", 0, 0, 255, 0, 0);
        traps.definesound(INTRO4_4, "introb.voc", 0, 0, 255, 0, 0);
        traps.definesound(INTRO4_5, "clang1.voc", 0, 0, 255, 0, 0);
        traps.definesound(INTRO4_6, "introc.voc", 0, 0, 255, 0, 0);
        traps.definesound(BOSS4_DEADSPEECH, "abort01.voc", 0, 0, 255, 4, 0);
        traps.definesound(BOSS4_FIRSTSEE, "kick01-i.voc", 0, 0, 255, 12, 0);
        traps.definesound(PARTY_SPEECH, "party03.voc", 0, 0, 255, 12, 0);
        traps.definesound(POSTAL_SPEECH, "postal01.voc", 0, 0, 255, 4, 0);
        traps.definesound(TGSPEECH, "vocal02.voc", 0, 0, 254, 8, 0);
        traps.definesound(DOGROOMSPEECH, "meat04-n.voc", 0, 0, 255, 4, 0);
        traps.definesound(SMACKED, "smack02.voc", 0, 0, 255, 12, 0);
        traps.definesound(MDEVSPEECH, "mdevl01.voc", 0, 0, 255, 12, 0);
        traps.definesound(AREA51SPEECH, "indpnc01.voc", 0, 0, 255, 4, 0);
        traps.definesound(JEEPSOUND, "jeep2a.voc", 0, 0, 0, 2, 0);
        traps.definesound(BIGDOORSLAM, "cdoor1b.voc", 0, 0, 129, 0, 0);
        traps.definesound(WAVESOUND, "wave1a.voc", 0, 0, 129, 3, 0);
        traps.definesound(ILLBEBACK, "beback01.voc", 0, 0, 255, 4, 0);
        traps.definesound(VOL4ENDSND1, "sbr1c.voc", 0, 0, 255, 0, 0);
        traps.definesound(VOL4ENDSND2, "squish1a.voc", 0, 0, 254, 0, 0);
        traps.definesound(EXPANDERSHOOT, "exshot3b.voc", -32, 80, 128, 0, 0);
        traps.definesound(EXPANDERHIT, "deepfry1.voc", 0, 0, 128, 0, 0);
        traps.definesound(SNAKESPEECH, "escape01.voc", 0, 0, 255, 4, 0);
        traps.definesound(GETBACKTOWORK, "slacker1.voc", 0, 0, 255, 0, 0);
        traps.definesound(BIGBANG, "bang1.voc", 0, 0, 255, 0, 0);
        traps.definesound(HORNSND, "shorn1.voc", 0, 0, 255, 2, 0);
        traps.definesound(BELLSND, "sbell1a.voc", 0, 0, 255, 2, 0);
        traps.definesound(GOAWAY, "goaway.voc", 0, 0, 4, 0, 0);
        traps.definesound(JOKE, "joke.voc", 0, 0, 128, 0, 0);
        
    }
}