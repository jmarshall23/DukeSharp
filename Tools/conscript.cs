internal class ConScript
{
    public const int SECTOREFFECTOR = 1;
    public const int ACTIVATOR = 2;
    public const int TOUCHPLATE = 3;
    public const int ACTIVATORLOCKED = 4;
    public const int MUSICANDSFX = 5;
    public const int LOCATORS = 6;
    public const int CYCLER = 7;
    public const int MASTERSWITCH = 8;
    public const int RESPAWN = 9;
    public const int GPSPEED = 10;
    public const int ARROW = 20;
    public const int FIRSTGUNSPRITE = 21;
    public const int CHAINGUNSPRITE = 22;
    public const int RPGSPRITE = 23;
    public const int FREEZESPRITE = 24;
    public const int SHRINKERSPRITE = 25;
    public const int HEAVYHBOMB = 26;
    public const int TRIPBOMBSPRITE = 27;
    public const int SHOTGUNSPRITE = 28;
    public const int DEVISTATORSPRITE = 29;
    public const int HEALTHBOX = 30;
    public const int AMMOBOX = 31;
    public const int GROWSPRITEICON = 32;
    public const int INVENTORYBOX = 33;
    public const int FREEZEAMMO = 37;
    public const int AMMO = 40;
    public const int BATTERYAMMO = 41;
    public const int DEVISTATORAMMO = 42;
    public const int RPGAMMO = 44;
    public const int GROWAMMO = 45;
    public const int CRYSTALAMMO = 46;
    public const int HBOMBAMMO = 47;
    public const int AMMOLOTS = 48;
    public const int SHOTGUNAMMO = 49;
    public const int COLA = 51;
    public const int SIXPAK = 52;
    public const int FIRSTAID = 53;
    public const int SHIELD = 54;
    public const int STEROIDS = 55;
    public const int AIRTANK = 56;
    public const int JETPACK = 57;
    public const int HEATSENSOR = 59;
    public const int ACCESSCARD = 60;
    public const int BOOTS = 61;
    public const int MIRRORBROKE = 70;
    public const int CLOUDYOCEAN = 78;
    public const int CLOUDYSKIES = 79;
    public const int MOONSKY1 = 80;
    public const int MOONSKY2 = 81;
    public const int MOONSKY3 = 82;
    public const int MOONSKY4 = 83;
    public const int BIGORBIT1 = 84;
    public const int BIGORBIT2 = 85;
    public const int BIGORBIT3 = 86;
    public const int BIGORBIT4 = 87;
    public const int BIGORBIT5 = 88;
    public const int LA = 89;
    public const int REDSKY1 = 98;
    public const int REDSKY2 = 99;
    public const int ATOMICHEALTH = 100;
    public const int TECHLIGHT2 = 120;
    public const int TECHLIGHTBUST2 = 121;
    public const int TECHLIGHT4 = 122;
    public const int TECHLIGHTBUST4 = 123;
    public const int WALLLIGHT4 = 124;
    public const int WALLLIGHTBUST4 = 125;
    public const int ACCESSSWITCH = 130;
    public const int SLOTDOOR = 132;
    public const int LIGHTSWITCH = 134;
    public const int SPACEDOORSWITCH = 136;
    public const int SPACELIGHTSWITCH = 138;
    public const int FRANKENSTINESWITCH = 140;
    public const int NUKEBUTTON = 142;
    public const int MULTISWITCH = 146;
    public const int DOORTILE5 = 150;
    public const int DOORTILE6 = 151;
    public const int DOORTILE1 = 152;
    public const int DOORTILE2 = 153;
    public const int DOORTILE3 = 154;
    public const int DOORTILE4 = 155;
    public const int DOORTILE7 = 156;
    public const int DOORTILE8 = 157;
    public const int DOORTILE9 = 158;
    public const int DOORTILE10 = 159;
    public const int DOORSHOCK = 160;
    public const int DIPSWITCH = 162;
    public const int DIPSWITCH2 = 164;
    public const int TECHSWITCH = 166;
    public const int DIPSWITCH3 = 168;
    public const int ACCESSSWITCH2 = 170;
    public const int REFLECTWATERTILE = 180;
    public const int FLOORSLIME = 200;
    public const int BIGFORCE = 230;
    public const int EPISODE = 247;
    public const int MASKWALL9 = 255;
    public const int W_LIGHT = 260;
    public const int SCREENBREAK1 = 263;
    public const int SCREENBREAK2 = 264;
    public const int SCREENBREAK3 = 265;
    public const int SCREENBREAK4 = 266;
    public const int SCREENBREAK5 = 267;
    public const int SCREENBREAK6 = 268;
    public const int SCREENBREAK7 = 269;
    public const int SCREENBREAK8 = 270;
    public const int SCREENBREAK9 = 271;
    public const int SCREENBREAK10 = 272;
    public const int SCREENBREAK11 = 273;
    public const int SCREENBREAK12 = 274;
    public const int SCREENBREAK13 = 275;
    public const int MASKWALL1 = 285;
    public const int W_TECHWALL1 = 293;
    public const int W_TECHWALL2 = 297;
    public const int W_TECHWALL15 = 299;
    public const int W_TECHWALL3 = 301;
    public const int W_TECHWALL4 = 305;
    public const int W_TECHWALL10 = 306;
    public const int W_TECHWALL16 = 307;
    public const int WATERTILE2 = 336;
    public const int BPANNEL1 = 341;
    public const int PANNEL1 = 342;
    public const int PANNEL2 = 343;
    public const int WATERTILE = 344;
    public const int STATIC = 351;
    public const int W_SCREENBREAK = 357;
    public const int W_HITTECHWALL3 = 360;
    public const int W_HITTECHWALL4 = 361;
    public const int W_HITTECHWALL2 = 362;
    public const int W_HITTECHWALL1 = 363;
    public const int MASKWALL10 = 387;
    public const int MASKWALL11 = 391;
    public const int DOORTILE22 = 395;
    public const int FANSPRITE = 407;
    public const int FANSPRITEBROKE = 411;
    public const int FANSHADOW = 412;
    public const int FANSHADOWBROKE = 416;
    public const int DOORTILE18 = 447;
    public const int DOORTILE19 = 448;
    public const int DOORTILE20 = 449;
    public const int SATELLITE = 489;
    public const int VIEWSCREEN2 = 499;
    public const int VIEWSCREENBROKE = 501;
    public const int VIEWSCREEN = 502;
    public const int GLASS = 503;
    public const int GLASS2 = 504;
    public const int STAINGLASS1 = 510;
    public const int MASKWALL5 = 514;
    public const int SATELITE = 516;
    public const int FUELPOD = 517;
    public const int SLIMEPIPE = 538;
    public const int CRACK1 = 546;
    public const int CRACK2 = 547;
    public const int CRACK3 = 548;
    public const int CRACK4 = 549;
    public const int FOOTPRINTS = 550;
    public const int DOMELITE = 551;
    public const int CAMERAPOLE = 554;
    public const int CHAIR1 = 556;
    public const int CHAIR2 = 557;
    public const int BROKENCHAIR = 559;
    public const int MIRROR = 560;
    public const int WATERFOUNTAIN = 563;
    public const int WATERFOUNTAINBROKE = 567;
    public const int FEMMAG1 = 568;
    public const int TOILET = 569;
    public const int STALL = 571;
    public const int STALLBROKE = 573;
    public const int FEMMAG2 = 577;
    public const int REACTOR2 = 578;
    public const int REACTOR2BURNT = 579;
    public const int REACTOR2SPARK = 580;
    public const int GRATE1 = 595;
    public const int BGRATE1 = 596;
    public const int SOLARPANNEL = 602;
    public const int NAKED1 = 603;
    public const int ANTENNA = 607;
    public const int MASKWALL12 = 609;
    public const int TOILETBROKE = 615;
    public const int PIPE2 = 616;
    public const int PIPE1B = 617;
    public const int PIPE3 = 618;
    public const int PIPE1 = 619;
    public const int CAMERA1 = 621;
    public const int BRICK = 626;
    public const int SPLINTERWOOD = 630;
    public const int PIPE2B = 633;
    public const int BOLT1 = 634;
    public const int W_NUMBERS = 640;
    public const int WATERDRIP = 660;
    public const int WATERBUBBLE = 661;
    public const int WATERBUBBLEMAKER = 662;
    public const int W_FORCEFIELD = 663;
    public const int VACUUM = 669;
    public const int FOOTPRINTS2 = 672;
    public const int FOOTPRINTS3 = 673;
    public const int FOOTPRINTS4 = 674;
    public const int EGG = 675;
    public const int SCALE = 678;
    public const int CHAIR3 = 680;
    public const int CAMERALIGHT = 685;
    public const int MOVIECAMERA = 686;
    public const int IVUNIT = 689;
    public const int POT1 = 694;
    public const int POT2 = 695;
    public const int POT3 = 697;
    public const int PIPE3B = 700;
    public const int WALLLIGHT3 = 701;
    public const int WALLLIGHTBUST3 = 702;
    public const int WALLLIGHT1 = 703;
    public const int WALLLIGHTBUST1 = 704;
    public const int WALLLIGHT2 = 705;
    public const int WALLLIGHTBUST2 = 706;
    public const int LIGHTSWITCH2 = 712;
    public const int WAITTOBESEATED = 716;
    public const int DOORTILE14 = 717;
    public const int STATUE = 753;
    public const int MIKE = 762;
    public const int VASE = 765;
    public const int SUSHIPLATE1 = 768;
    public const int SUSHIPLATE2 = 769;
    public const int SUSHIPLATE3 = 774;
    public const int SUSHIPLATE4 = 779;
    public const int DOORTILE16 = 781;
    public const int SUSHIPLATE5 = 792;
    public const int OJ = 806;
    public const int MASKWALL13 = 830;
    public const int HURTRAIL = 859;
    public const int POWERSWITCH1 = 860;
    public const int LOCKSWITCH1 = 862;
    public const int POWERSWITCH2 = 864;
    public const int ATM = 867;
    public const int STATUEFLASH = 869;
    public const int ATMBROKE = 888;
    public const int BIGHOLE2 = 893;
    public const int STRIPEBALL = 901;
    public const int QUEBALL = 902;
    public const int POCKET = 903;
    public const int WOODENHORSE = 904;
    public const int TREE1 = 908;
    public const int TREE2 = 910;
    public const int CACTUS = 911;
    public const int MASKWALL2 = 913;
    public const int MASKWALL3 = 914;
    public const int MASKWALL4 = 915;
    public const int FIREEXT = 916;
    public const int TOILETWATER = 921;
    public const int NEON1 = 925;
    public const int NEON2 = 926;
    public const int CACTUSBROKE = 939;
    public const int BOUNCEMINE = 940;
    public const int BROKEFIREHYDRENT = 950;
    public const int BOX = 951;
    public const int BULLETHOLE = 952;
    public const int BOTTLE1 = 954;
    public const int BOTTLE2 = 955;
    public const int BOTTLE3 = 956;
    public const int BOTTLE4 = 957;
    public const int FEMPIC5 = 963;
    public const int FEMPIC6 = 964;
    public const int FEMPIC7 = 965;
    public const int HYDROPLANT = 969;
    public const int OCEANSPRITE1 = 971;
    public const int OCEANSPRITE2 = 972;
    public const int OCEANSPRITE3 = 973;
    public const int OCEANSPRITE4 = 974;
    public const int OCEANSPRITE5 = 975;
    public const int GENERICPOLE = 977;
    public const int CONE = 978;
    public const int HANGLIGHT = 979;
    public const int HYDRENT = 981;
    public const int MASKWALL14 = 988;
    public const int TIRE = 990;
    public const int PIPE5 = 994;
    public const int PIPE6 = 995;
    public const int PIPE4 = 996;
    public const int PIPE4B = 997;
    public const int BROKEHYDROPLANT = 1003;
    public const int PIPE5B = 1005;
    public const int NEON3 = 1007;
    public const int NEON4 = 1008;
    public const int NEON5 = 1009;
    public const int BOTTLE5 = 1012;
    public const int BOTTLE6 = 1013;
    public const int BOTTLE8 = 1014;
    public const int SPOTLITE = 1020;
    public const int HANGOOZ = 1022;
    public const int MASKWALL15 = 1024;
    public const int BOTTLE7 = 1025;
    public const int HORSEONSIDE = 1026;
    public const int GLASSPIECES = 1031;
    public const int HORSELITE = 1034;
    public const int DONUTS = 1045;
    public const int NEON6 = 1046;
    public const int MASKWALL6 = 1059;
    public const int CLOCK = 1060;
    public const int RUBBERCAN = 1062;
    public const int BROKENCLOCK = 1067;
    public const int PLUG = 1069;
    public const int OOZFILTER = 1079;
    public const int FLOORPLASMA = 1082;
    public const int REACTOR = 1088;
    public const int REACTORSPARK = 1092;
    public const int REACTORBURNT = 1096;
    public const int DOORTILE15 = 1102;
    public const int HANDSWITCH = 1111;
    public const int CIRCLEPANNEL = 1113;
    public const int CIRCLEPANNELBROKE = 1114;
    public const int PULLSWITCH = 1122;
    public const int MASKWALL8 = 1124;
    public const int BIGHOLE = 1141;
    public const int ALIENSWITCH = 1142;
    public const int DOORTILE21 = 1144;
    public const int HANDPRINTSWITCH = 1155;
    public const int BOTTLE10 = 1157;
    public const int BOTTLE11 = 1158;
    public const int BOTTLE12 = 1159;
    public const int BOTTLE13 = 1160;
    public const int BOTTLE14 = 1161;
    public const int BOTTLE15 = 1162;
    public const int BOTTLE16 = 1163;
    public const int BOTTLE17 = 1164;
    public const int BOTTLE18 = 1165;
    public const int BOTTLE19 = 1166;
    public const int DOORTILE17 = 1169;
    public const int MASKWALL7 = 1174;
    public const int JAILBARBREAK = 1175;
    public const int DOORTILE11 = 1178;
    public const int DOORTILE12 = 1179;
    public const int VENDMACHINE = 1212;
    public const int VENDMACHINEBROKE = 1214;
    public const int COLAMACHINE = 1215;
    public const int COLAMACHINEBROKE = 1217;
    public const int CRANEPOLE = 1221;
    public const int CRANE = 1222;
    public const int BARBROKE = 1225;
    public const int BLOODPOOL = 1226;
    public const int NUKEBARREL = 1227;
    public const int NUKEBARRELDENTED = 1228;
    public const int NUKEBARRELLEAKED = 1229;
    public const int CANWITHSOMETHING = 1232;
    public const int MONEY = 1233;
    public const int BANNER = 1236;
    public const int EXPLODINGBARREL = 1238;
    public const int EXPLODINGBARREL2 = 1239;
    public const int FIREBARREL = 1240;
    public const int SEENINE = 1247;
    public const int SEENINEDEAD = 1248;
    public const int STEAM = 1250;
    public const int CEILINGSTEAM = 1255;
    public const int PIPE6B = 1260;
    public const int TRANSPORTERBEAM = 1261;
    public const int RAT = 1267;
    public const int TRASH = 1272;
    public const int FEMPIC1 = 1280;
    public const int FEMPIC2 = 1289;
    public const int BLANKSCREEN = 1293;
    public const int PODFEM1 = 1294;
    public const int FEMPIC3 = 1298;
    public const int FEMPIC4 = 1306;
    public const int FEM1 = 1312;
    public const int FEM2 = 1317;
    public const int FEM3 = 1321;
    public const int FEM5 = 1323;
    public const int BLOODYPOLE = 1324;
    public const int FEM4 = 1325;
    public const int FEM6 = 1334;
    public const int FEM6PAD = 1335;
    public const int FEM8 = 1336;
    public const int HELECOPT = 1346;
    public const int FETUSJIB = 1347;
    public const int HOLODUKE = 1348;
    public const int SPACEMARINE = 1353;
    public const int INDY = 1355;
    public const int FETUS = 1358;
    public const int FETUSBROKE = 1359;
    public const int MONK = 1352;
    public const int LUKE = 1354;
    public const int COOLEXPLOSION1 = 1360;
    public const int WATERSPLASH2 = 1380;
    public const int FIREVASE = 1390;
    public const int SCRATCH = 1393;
    public const int FEM7 = 1395;
    public const int APLAYERTOP = 1400;
    public const int APLAYER = 1405;
    public const int PLAYERONWATER = 1420;
    public const int DUKELYINGDEAD = 1518;
    public const int DUKETORSO = 1520;
    public const int DUKEGUN = 1528;
    public const int DUKELEG = 1536;
    public const int SHARK = 1550;
    public const int BLOOD = 1620;
    public const int FIRELASER = 1625;
    public const int TRANSPORTERSTAR = 1630;
    public const int SPIT = 1636;
    public const int LOOGIE = 1637;
    public const int FIST = 1640;
    public const int FREEZEBLAST = 1641;
    public const int DEVISTATORBLAST = 1642;
    public const int SHRINKSPARK = 1646;
    public const int TONGUE = 1647;
    public const int MORTER = 1650;
    public const int SHRINKEREXPLOSION = 1656;
    public const int RADIUSEXPLOSION = 1670;
    public const int FORCERIPPLE = 1671;
    public const int LIZTROOP = 1680;
    public const int LIZTROOPRUNNING = 1681;
    public const int LIZTROOPSTAYPUT = 1682;
    public const int LIZTOP = 1705;
    public const int LIZTROOPSHOOT = 1715;
    public const int LIZTROOPJETPACK = 1725;
    public const int LIZTROOPDSPRITE = 1734;
    public const int LIZTROOPONTOILET = 1741;
    public const int LIZTROOPJUSTSIT = 1742;
    public const int LIZTROOPDUCKING = 1744;
    public const int HEADJIB1 = 1768;
    public const int ARMJIB1 = 1772;
    public const int LEGJIB1 = 1776;
    public const int CANNONBALL = 1817;
    public const int OCTABRAIN = 1820;
    public const int OCTABRAINSTAYPUT = 1821;
    public const int OCTATOP = 1845;
    public const int OCTADEADSPRITE = 1855;
    public const int INNERJAW = 1860;
    public const int DRONE = 1880;
    public const int EXPLOSION2 = 1890;
    public const int COMMANDER = 1920;
    public const int COMMANDERSTAYPUT = 1921;
    public const int RECON = 1960;
    public const int TANK = 1975;
    public const int PIGCOP = 2000;
    public const int PIGCOPSTAYPUT = 2001;
    public const int PIGCOPDIVE = 2045;
    public const int PIGCOPDEADSPRITE = 2060;
    public const int PIGTOP = 2061;
    public const int LIZMAN = 2120;
    public const int LIZMANSTAYPUT = 2121;
    public const int LIZMANSPITTING = 2150;
    public const int LIZMANFEEDING = 2160;
    public const int LIZMANJUMP = 2165;
    public const int LIZMANDEADSPRITE = 2185;
    public const int FECES = 2200;
    public const int LIZMANHEAD1 = 2201;
    public const int LIZMANARM1 = 2205;
    public const int LIZMANLEG1 = 2209;
    public const int EXPLOSION2BOT = 2219;
    public const int USERWEAPON = 2235;
    public const int HEADERBAR = 2242;
    public const int JIBS1 = 2245;
    public const int JIBS2 = 2250;
    public const int JIBS3 = 2255;
    public const int JIBS4 = 2260;
    public const int JIBS5 = 2265;
    public const int BURNING = 2270;
    public const int FIRE = 2271;
    public const int JIBS6 = 2286;
    public const int BLOODSPLAT1 = 2296;
    public const int BLOODSPLAT3 = 2297;
    public const int BLOODSPLAT2 = 2298;
    public const int BLOODSPLAT4 = 2299;
    public const int OOZ = 2300;
    public const int OOZ2 = 2309;
    public const int WALLBLOOD1 = 2301;
    public const int WALLBLOOD2 = 2302;
    public const int WALLBLOOD3 = 2303;
    public const int WALLBLOOD4 = 2304;
    public const int WALLBLOOD5 = 2305;
    public const int WALLBLOOD6 = 2306;
    public const int WALLBLOOD7 = 2307;
    public const int WALLBLOOD8 = 2308;
    public const int BURNING2 = 2310;
    public const int FIRE2 = 2311;
    public const int CRACKKNUCKLES = 2324;
    public const int SMALLSMOKE = 2329;
    public const int SMALLSMOKEMAKER = 2330;
    public const int FLOORFLAME = 2333;
    public const int ROTATEGUN = 2360;
    public const int GREENSLIME = 2370;
    public const int WATERDRIPSPLASH = 2380;
    public const int SCRAP6 = 2390;
    public const int SCRAP1 = 2400;
    public const int SCRAP2 = 2404;
    public const int SCRAP3 = 2408;
    public const int SCRAP4 = 2412;
    public const int SCRAP5 = 2416;
    public const int ORGANTIC = 2420;
    public const int BETAVERSION = 2440;
    public const int PLAYERISHERE = 2442;
    public const int PLAYERWASHERE = 2443;
    public const int SELECTDIR = 2444;
    public const int F1HELP = 2445;
    public const int NOTCHON = 2446;
    public const int NOTCHOFF = 2447;
    public const int GROWSPARK = 2448;
    public const int DUKEICON = 2452;
    public const int BADGUYICON = 2453;
    public const int FOODICON = 2454;
    public const int GETICON = 2455;
    public const int MENUSCREEN = 2456;
    public const int MENUBAR = 2457;
    public const int KILLSICON = 2458;
    public const int FIRSTAID_ICON = 2460;
    public const int HEAT_ICON = 2461;
    public const int BOTTOMSTATUSBAR = 2462;
    public const int BOOT_ICON = 2463;
    public const int FRAGBAR = 2465;
    public const int JETPACK_ICON = 2467;
    public const int AIRTANK_ICON = 2468;
    public const int STEROIDS_ICON = 2469;
    public const int HOLODUKE_ICON = 2470;
    public const int ACCESS_ICON = 2471;
    public const int DIGITALNUM = 2472;
    public const int DUKECAR = 2491;
    public const int CAMCORNER = 2482;
    public const int CAMLIGHT = 2484;
    public const int LOGO = 2485;
    public const int TITLE = 2486;
    public const int NUKEWARNINGICON = 2487;
    public const int MOUSECURSOR = 2488;
    public const int SLIDEBAR = 2489;
    public const int DREALMS = 2492;
    public const int BETASCREEN = 2493;
    public const int WINDOWBORDER1 = 2494;
    public const int TEXTBOX = 2495;
    public const int WINDOWBORDER2 = 2496;
    public const int DUKENUKEM = 2497;
    public const int THREEDEE = 2498;
    public const int INGAMEDUKETHREEDEE = 2499;
    public const int TENSCREEN = 2500;
    public const int PLUTOPAKSPRITE = 2501;
    public const int DEVISTATOR = 2510;
    public const int KNEE = 2521;
    public const int CROSSHAIR = 2523;
    public const int FIRSTGUN = 2524;
    public const int FIRSTGUNRELOAD = 2528;
    public const int FALLINGCLIP = 2530;
    public const int CLIPINHAND = 2531;
    public const int HAND = 2532;
    public const int SHELL = 2533;
    public const int SHOTGUNSHELL = 2535;
    public const int CHAINGUN = 2536;
    public const int RPGGUN = 2544;
    public const int RPGMUZZLEFLASH = 2545;
    public const int FREEZE = 2548;
    public const int CATLITE = 2552;
    public const int SHRINKER = 2556;
    public const int HANDHOLDINGLASER = 2563;
    public const int TRIPBOMB = 2566;
    public const int LASERLINE = 2567;
    public const int HANDHOLDINGACCESS = 2568;
    public const int HANDREMOTE = 2570;
    public const int HANDTHROW = 2573;
    public const int TIP = 2576;
    public const int GLAIR = 2578;
    public const int SCUBAMASK = 2581;
    public const int SPACEMASK = 2584;
    public const int FORCESPHERE = 2590;
    public const int SHOTSPARK1 = 2595;
    public const int RPG = 2605;
    public const int LASERSITE = 2612;
    public const int SHOTGUN = 2613;
    public const int BOSS1 = 2630;
    public const int BOSS1STAYPUT = 2631;
    public const int BOSS1SHOOT = 2660;
    public const int BOSS1LOB = 2670;
    public const int BOSSTOP = 2696;
    public const int BOSS2 = 2710;
    public const int BOSS3 = 2760;
    public const int SPINNINGNUKEICON = 2813;
    public const int BIGFNTCURSOR = 2820;
    public const int SMALLFNTCURSOR = 2821;
    public const int STARTALPHANUM = 2822;
    public const int ENDALPHANUM = 2915;
    public const int BIGALPHANUM = 2940;
    public const int BIGPERIOD = 3002;
    public const int BIGCOMMA = 3003;
    public const int BIGX = 3004;
    public const int BIGQ = 3005;
    public const int BIGSEMI = 3006;
    public const int BIGCOLIN = 3007;
    public const int THREEBYFIVE = 3010;
    public const int BIGAPPOS = 3022;
    public const int BLANK = 3026;
    public const int MINIFONT = 3072;
    public const int BUTTON1 = 3164;
    public const int GLASS3 = 3187;
    public const int RESPAWNMARKERRED = 3190;
    public const int RESPAWNMARKERYELLOW = 3200;
    public const int RESPAWNMARKERGREEN = 3210;
    public const int BONUSSCREEN = 3240;
    public const int VIEWBORDER = 3250;
    public const int VICTORY1 = 3260;
    public const int ORDERING = 3270;
    public const int TEXTSTORY = 3280;
    public const int LOADSCREEN = 3281;
    public const int BORNTOBEWILDSCREEN = 3370;
    public const int BLIMP = 3400;
    public const int FEM9 = 3450;
    public const int FOOTPRINT = 3701;
    public const int POOP = 4094;
    public const int FRAMEEFFECT1 = 4095;
    public const int PANNEL3 = 4099;
    public const int SCREENBREAK14 = 4120;
    public const int SCREENBREAK15 = 4123;
    public const int SCREENBREAK19 = 4125;
    public const int SCREENBREAK16 = 4127;
    public const int SCREENBREAK17 = 4128;
    public const int SCREENBREAK18 = 4129;
    public const int W_TECHWALL11 = 4130;
    public const int W_TECHWALL12 = 4131;
    public const int W_TECHWALL13 = 4132;
    public const int W_TECHWALL14 = 4133;
    public const int W_TECHWALL5 = 4134;
    public const int W_TECHWALL6 = 4136;
    public const int W_TECHWALL7 = 4138;
    public const int W_TECHWALL8 = 4140;
    public const int W_TECHWALL9 = 4142;
    public const int BPANNEL3 = 4100;
    public const int W_HITTECHWALL16 = 4144;
    public const int W_HITTECHWALL10 = 4145;
    public const int W_HITTECHWALL15 = 4147;
    public const int W_MILKSHELF = 4181;
    public const int W_MILKSHELFBROKE = 4203;
    public const int PURPLELAVA = 4240;
    public const int LAVABUBBLE = 4340;
    public const int DUKECUTOUT = 4352;
    public const int TARGET = 4359;
    public const int GUNPOWDERBARREL = 4360;
    public const int DUCK = 4361;
    public const int HATRACK = 4367;
    public const int DESKLAMP = 4370;
    public const int COFFEEMACHINE = 4372;
    public const int CUPS = 4373;
    public const int GAVALS = 4374;
    public const int GAVALS2 = 4375;
    public const int POLICELIGHTPOLE = 4377;
    public const int FLOORBASKET = 4388;
    public const int PUKE = 4389;
    public const int DOORTILE23 = 4391;
    public const int TOPSECRET = 4396;
    public const int SPEAKER = 4397;
    public const int TEDDYBEAR = 4400;
    public const int ROBOTDOG = 4402;
    public const int ROBOTPIRATE = 4404;
    public const int ROBOTMOUSE = 4407;
    public const int MAIL = 4410;
    public const int MAILBAG = 4413;
    public const int HOTMEAT = 4427;
    public const int COFFEEMUG = 4438;
    public const int DONUTS2 = 4440;
    public const int TRIPODCAMERA = 4444;
    public const int METER = 4453;
    public const int DESKPHONE = 4454;
    public const int GUMBALLMACHINE = 4458;
    public const int GUMBALLMACHINEBROKE = 4459;
    public const int PAPER = 4460;
    public const int MACE = 4464;
    public const int GENERICPOLE2 = 4465;
    public const int XXXSTACY = 4470;
    public const int WETFLOOR = 4495;
    public const int BROOM = 4496;
    public const int MOP = 4497;
    public const int LETTER = 4502;
    public const int PIRATE1A = 4510;
    public const int PIRATE4A = 4511;
    public const int PIRATE2A = 4512;
    public const int PIRATE5A = 4513;
    public const int PIRATE3A = 4514;
    public const int PIRATE6A = 4515;
    public const int PIRATEHALF = 4516;
    public const int CHESTOFGOLD = 4520;
    public const int SIDEBOLT1 = 4525;
    public const int FOODOBJECT1 = 4530;
    public const int FOODOBJECT2 = 4531;
    public const int FOODOBJECT3 = 4532;
    public const int FOODOBJECT4 = 4533;
    public const int FOODOBJECT5 = 4534;
    public const int FOODOBJECT6 = 4535;
    public const int FOODOBJECT7 = 4536;
    public const int FOODOBJECT8 = 4537;
    public const int FOODOBJECT9 = 4538;
    public const int FOODOBJECT10 = 4539;
    public const int FOODOBJECT11 = 4540;
    public const int FOODOBJECT12 = 4541;
    public const int FOODOBJECT13 = 4542;
    public const int FOODOBJECT14 = 4543;
    public const int FOODOBJECT15 = 4544;
    public const int FOODOBJECT16 = 4545;
    public const int FOODOBJECT17 = 4546;
    public const int FOODOBJECT18 = 4547;
    public const int FOODOBJECT19 = 4548;
    public const int FOODOBJECT20 = 4549;
    public const int HEADLAMP = 4550;
    public const int TAMPON = 4557;
    public const int SKINNEDCHICKEN = 4554;
    public const int FEATHEREDCHICKEN = 4555;
    public const int ROBOTDOG2 = 4560;
    public const int JOLLYMEAL = 4569;
    public const int DUKEBURGER = 4570;
    public const int SHOPPINGCART = 4576;
    public const int CANWITHSOMETHING2 = 4580;
    public const int CANWITHSOMETHING3 = 4581;
    public const int CANWITHSOMETHING4 = 4582;
    public const int SNAKEP = 4590;
    public const int DOLPHIN1 = 4591;
    public const int DOLPHIN2 = 4592;
    public const int NEWBEAST = 4610;
    public const int NEWBEASTSTAYPUT = 4611;
    public const int NEWBEASTJUMP = 4690;
    public const int NEWBEASTHANG = 4670;
    public const int NEWBEASTHANGDEAD = 4671;
    public const int BOSS4 = 4740;
    public const int BOSS4STAYPUT = 4741;
    public const int FEM10 = 4864;
    public const int TOUGHGAL = 4866;
    public const int MAN = 4871;
    public const int MAN2 = 4872;
    public const int WOMAN = 4874;
    public const int PLEASEWAIT = 4887;
    public const int NATURALLIGHTNING = 4890;
    public const int WEATHERWARN = 4893;
    public const int DUKETAG = 4900;
    public const int SIGN1 = 4909;
    public const int SIGN2 = 4912;
    public const int JURYGUY = 4943;
    public const int RESERVEDSLOT1 = 6132;
    public const int RESERVEDSLOT2 = 6133;
    public const int RESERVEDSLOT3 = 6134;
    public const int RESERVEDSLOT4 = 6135;
    public const int RESERVEDSLOT5 = 6136;
    public const int RESERVEDSLOT6 = 6132;
    public const int RESERVEDSLOT7 = 6133;
    public const int RESERVEDSLOT8 = 6134;
    public const int RESERVEDSLOT9 = 6135;
    public const int RESERVEDSLOT10 = 6136;
    public const int RESERVEDSLOT11 = 6137;
    public const int RESERVEDSLOT12 = 6138;
    public const int RESERVEDSLOT13 = 6139;
    public const int RESERVEDSLOT14 = 6140;
    public const int RESERVEDSLOT15 = 6141;
    public const int RESERVEDSLOT16 = 6142;
    public const int RESERVEDSLOT17 = 6143;
    public const int KNEE_WEAPON = 0;
    public const int PISTOL_WEAPON = 1;
    public const int SHOTGUN_WEAPON = 2;
    public const int CHAINGUN_WEAPON = 3;
    public const int RPG_WEAPON = 4;
    public const int HANDBOMB_WEAPON = 5;
    public const int SHRINKER_WEAPON = 6;
    public const int DEVISTATOR_WEAPON = 7;
    public const int TRIPBOMB_WEAPON = 8;
    public const int FREEZE_WEAPON = 9;
    public const int HANDREMOTE_WEAPON = 10;
    public const int GROW_WEAPON = 11;
    public const int faceplayer = 1;
    public const int geth = 2;
    public const int getv = 4;
    public const int randomangle = 8;
    public const int faceplayerslow = 16;
    public const int spin = 32;
    public const int faceplayersmart = 64;
    public const int fleeenemy = 128;
    public const int jumptoplayer = 257;
    public const int seekplayer = 512;
    public const int furthestdir = 1024;
    public const int dodgebullet = 4096;
    public const int NO = 0;
    public const int YES = 1;
    public const int notenemy = 0;
    public const int enemy = 1;
    public const int enemystayput = 2;
    public const int pstanding = 1;
    public const int pwalking = 2;
    public const int prunning = 4;
    public const int pducking = 8;
    public const int pfalling = 16;
    public const int pjumping = 32;
    public const int phigher = 64;
    public const int pwalkingback = 128;
    public const int prunningback = 256;
    public const int pkicking = 512;
    public const int pshrunk = 1024;
    public const int pjetpack = 2048;
    public const int ponsteroids = 4096;
    public const int ponground = 8192;
    public const int palive = 16384;
    public const int pdead = 32768;
    public const int pfacing = 65536;
    public const int GET_STEROIDS = 0;
    public const int GET_SHIELD = 1;
    public const int GET_SCUBA = 2;
    public const int GET_HOLODUKE = 3;
    public const int GET_JETPACK = 4;
    public const int GET_ACCESS = 6;
    public const int GET_HEATS = 7;
    public const int GET_FIRSTAID = 9;
    public const int GET_BOOTS = 10;
    public const int KICK_HIT = 0;
    public const int PISTOL_RICOCHET = 1;
    public const int PISTOL_BODYHIT = 2;
    public const int PISTOL_FIRE = 3;
    public const int EJECT_CLIP = 4;
    public const int INSERT_CLIP = 5;
    public const int CHAINGUN_FIRE = 6;
    public const int RPG_SHOOT = 7;
    public const int POOLBALLHIT = 8;
    public const int RPG_EXPLODE = 9;
    public const int CAT_FIRE = 10;
    public const int SHRINKER_FIRE = 11;
    public const int ACTOR_SHRINKING = 12;
    public const int PIPEBOMB_BOUNCE = 13;
    public const int PIPEBOMB_EXPLODE = 14;
    public const int LASERTRIP_ONWALL = 15;
    public const int LASERTRIP_ARMING = 16;
    public const int LASERTRIP_EXPLODE = 17;
    public const int VENT_BUST = 18;
    public const int GLASS_BREAKING = 19;
    public const int GLASS_HEAVYBREAK = 20;
    public const int SHORT_CIRCUIT = 21;
    public const int ITEM_SPLASH = 22;
    public const int DUKE_BREATHING = 23;
    public const int DUKE_EXHALING = 24;
    public const int DUKE_GASP = 25;
    public const int SLIM_RECOG = 26;
    public const int DUKE_URINATE = 28;
    public const int ENDSEQVOL3SND2 = 29;
    public const int ENDSEQVOL3SND3 = 30;
    public const int DUKE_PASSWIND = 32;
    public const int DUKE_CRACK = 33;
    public const int SLIM_ATTACK = 34;
    public const int SOMETHINGHITFORCE = 35;
    public const int DUKE_DRINKING = 36;
    public const int DUKE_KILLED1 = 37;
    public const int DUKE_GRUNT = 38;
    public const int DUKE_HARTBEAT = 39;
    public const int DUKE_ONWATER = 40;
    public const int DUKE_DEAD = 41;
    public const int DUKE_LAND = 42;
    public const int DUKE_WALKINDUCTS = 43;
    public const int DUKE_GLAD = 44;
    public const int DUKE_YES = 45;
    public const int DUKE_HEHE = 46;
    public const int DUKE_SHUCKS = 47;
    public const int DUKE_UNDERWATER = 48;
    public const int DUKE_JETPACK_ON = 49;
    public const int DUKE_JETPACK_IDLE = 50;
    public const int DUKE_JETPACK_OFF = 51;
    public const int LIZTROOP_GROWL = 52;
    public const int LIZTROOP_TALK1 = 53;
    public const int LIZTROOP_TALK2 = 54;
    public const int LIZTROOP_TALK3 = 55;
    public const int DUKETALKTOBOSS = 56;
    public const int LIZCAPT_GROWL = 57;
    public const int LIZCAPT_TALK1 = 58;
    public const int LIZCAPT_TALK2 = 59;
    public const int LIZCAPT_TALK3 = 60;
    public const int LIZARD_BEG = 61;
    public const int LIZARD_PAIN = 62;
    public const int LIZARD_DEATH = 63;
    public const int LIZARD_SPIT = 64;
    public const int DRONE1_HISSRATTLE = 65;
    public const int DRONE1_HISSSCREECH = 66;
    public const int DUKE_TIP2 = 67;
    public const int FLESH_BURNING = 68;
    public const int SQUISHED = 69;
    public const int TELEPORTER = 70;
    public const int ELEVATOR_ON = 71;
    public const int DUKE_KILLED3 = 72;
    public const int ELEVATOR_OFF = 73;
    public const int DOOR_OPERATE1 = 74;
    public const int SUBWAY = 75;
    public const int SWITCH_ON = 76;
    public const int FAN = 77;
    public const int DUKE_GETWEAPON3 = 78;
    public const int FLUSH_TOILET = 79;
    public const int HOVER_CRAFT = 80;
    public const int EARTHQUAKE = 81;
    public const int INTRUDER_ALERT = 82;
    public const int END_OF_LEVEL_WARN = 83;
    public const int ENGINE_OPERATING = 84;
    public const int REACTOR_ON = 85;
    public const int COMPUTER_AMBIENCE = 86;
    public const int GEARS_GRINDING = 87;
    public const int BUBBLE_AMBIENCE = 88;
    public const int MACHINE_AMBIENCE = 89;
    public const int SEWER_AMBIENCE = 90;
    public const int WIND_AMBIENCE = 91;
    public const int SOMETHING_DRIPPING = 92;
    public const int STEAM_HISSING = 93;
    public const int THEATER_BREATH = 94;
    public const int BAR_MUSIC = 95;
    public const int BOS1_ROAM = 96;
    public const int BOS1_RECOG = 97;
    public const int BOS1_ATTACK1 = 98;
    public const int BOS1_PAIN = 99;
    public const int BOS1_DYING = 100;
    public const int BOS2_ROAM = 101;
    public const int BOS2_RECOG = 102;
    public const int BOS2_ATTACK = 103;
    public const int BOS2_PAIN = 104;
    public const int BOS2_DYING = 105;
    public const int GETATOMICHEALTH = 106;
    public const int DUKE_GETWEAPON2 = 107;
    public const int BOS3_DYING = 108;
    public const int SHOTGUN_FIRE = 109;
    public const int PRED_ROAM = 110;
    public const int PRED_RECOG = 111;
    public const int PRED_ATTACK = 112;
    public const int PRED_PAIN = 113;
    public const int PRED_DYING = 114;
    public const int CAPT_ROAM = 115;
    public const int CAPT_ATTACK = 116;
    public const int CAPT_RECOG = 117;
    public const int CAPT_PAIN = 118;
    public const int CAPT_DYING = 119;
    public const int PIG_ROAM = 120;
    public const int PIG_RECOG = 121;
    public const int PIG_ATTACK = 122;
    public const int PIG_PAIN = 123;
    public const int PIG_DYING = 124;
    public const int RECO_ROAM = 125;
    public const int RECO_RECOG = 126;
    public const int RECO_ATTACK = 127;
    public const int RECO_PAIN = 128;
    public const int RECO_DYING = 129;
    public const int DRON_ROAM = 130;
    public const int DRON_RECOG = 131;
    public const int DRON_ATTACK1 = 132;
    public const int DRON_PAIN = 133;
    public const int DRON_DYING = 134;
    public const int COMM_ROAM = 135;
    public const int COMM_RECOG = 136;
    public const int COMM_ATTACK = 137;
    public const int COMM_PAIN = 138;
    public const int COMM_DYING = 139;
    public const int OCTA_ROAM = 140;
    public const int OCTA_RECOG = 141;
    public const int OCTA_ATTACK1 = 142;
    public const int OCTA_PAIN = 143;
    public const int OCTA_DYING = 144;
    public const int TURR_ROAM = 145;
    public const int TURR_RECOG = 146;
    public const int TURR_ATTACK = 147;
    public const int DUMPSTER_MOVE = 148;
    public const int SLIM_DYING = 149;
    public const int BOS3_ROAM = 150;
    public const int BOS3_RECOG = 151;
    public const int BOS3_ATTACK1 = 152;
    public const int BOS3_PAIN = 153;
    public const int BOS1_ATTACK2 = 154;
    public const int COMM_SPIN = 155;
    public const int BOS1_WALK = 156;
    public const int DRON_ATTACK2 = 157;
    public const int THUD = 158;
    public const int OCTA_ATTACK2 = 159;
    public const int WIERDSHOT_FLY = 160;
    public const int TURR_PAIN = 161;
    public const int TURR_DYING = 162;
    public const int SLIM_ROAM = 163;
    public const int LADY_SCREAM = 164;
    public const int DOOR_OPERATE2 = 165;
    public const int DOOR_OPERATE3 = 166;
    public const int DOOR_OPERATE4 = 167;
    public const int BORNTOBEWILDSND = 168;
    public const int SHOTGUN_COCK = 169;
    public const int GENERIC_AMBIENCE1 = 170;
    public const int GENERIC_AMBIENCE2 = 171;
    public const int GENERIC_AMBIENCE3 = 172;
    public const int GENERIC_AMBIENCE4 = 173;
    public const int GENERIC_AMBIENCE5 = 174;
    public const int GENERIC_AMBIENCE6 = 175;
    public const int BOS3_ATTACK2 = 176;
    public const int GENERIC_AMBIENCE17 = 177;
    public const int GENERIC_AMBIENCE18 = 178;
    public const int GENERIC_AMBIENCE19 = 179;
    public const int GENERIC_AMBIENCE20 = 180;
    public const int GENERIC_AMBIENCE21 = 181;
    public const int GENERIC_AMBIENCE22 = 182;
    public const int SECRETLEVELSND = 183;
    public const int GENERIC_AMBIENCE8 = 184;
    public const int GENERIC_AMBIENCE9 = 185;
    public const int GENERIC_AMBIENCE10 = 186;
    public const int GENERIC_AMBIENCE11 = 187;
    public const int GENERIC_AMBIENCE12 = 188;
    public const int GENERIC_AMBIENCE13 = 189;
    public const int GENERIC_AMBIENCE14 = 190;
    public const int GENERIC_AMBIENCE15 = 192;
    public const int GENERIC_AMBIENCE16 = 193;
    public const int FIRE_CRACKLE = 194;
    public const int BONUS_SPEECH1 = 195;
    public const int BONUS_SPEECH2 = 196;
    public const int BONUS_SPEECH3 = 197;
    public const int PIG_CAPTURE_DUKE = 198;
    public const int BONUS_SPEECH4 = 199;
    public const int DUKE_LAND_HURT = 200;
    public const int DUKE_HIT_STRIPPER1 = 201;
    public const int DUKE_TIP1 = 202;
    public const int DUKE_KILLED2 = 203;
    public const int PRED_ROAM2 = 204;
    public const int PIG_ROAM2 = 205;
    public const int DUKE_GETWEAPON1 = 206;
    public const int DUKE_SEARCH2 = 207;
    public const int DUKE_CRACK2 = 208;
    public const int DUKE_SEARCH = 209;
    public const int DUKE_GET = 210;
    public const int DUKE_LONGTERM_PAIN = 211;
    public const int MONITOR_ACTIVE = 212;
    public const int NITEVISION_ONOFF = 213;
    public const int DUKE_HIT_STRIPPER2 = 214;
    public const int DUKE_CRACK_FIRST = 215;
    public const int DUKE_USEMEDKIT = 216;
    public const int DUKE_TAKEPILLS = 217;
    public const int DUKE_PISSRELIEF = 218;
    public const int SELECT_WEAPON = 219;
    public const int WATER_GURGLE = 220;
    public const int DUKE_GETWEAPON4 = 221;
    public const int JIBBED_ACTOR1 = 222;
    public const int JIBBED_ACTOR2 = 223;
    public const int JIBBED_ACTOR3 = 224;
    public const int JIBBED_ACTOR4 = 225;
    public const int JIBBED_ACTOR5 = 226;
    public const int JIBBED_ACTOR6 = 227;
    public const int JIBBED_ACTOR7 = 228;
    public const int DUKE_GOTHEALTHATLOW = 229;
    public const int BOSSTALKTODUKE = 230;
    public const int WAR_AMBIENCE1 = 231;
    public const int WAR_AMBIENCE2 = 232;
    public const int WAR_AMBIENCE3 = 233;
    public const int WAR_AMBIENCE4 = 234;
    public const int WAR_AMBIENCE5 = 235;
    public const int WAR_AMBIENCE6 = 236;
    public const int WAR_AMBIENCE7 = 237;
    public const int WAR_AMBIENCE8 = 238;
    public const int WAR_AMBIENCE9 = 239;
    public const int WAR_AMBIENCE10 = 240;
    public const int ALIEN_TALK1 = 241;
    public const int ALIEN_TALK2 = 242;
    public const int EXITMENUSOUND = 243;
    public const int FLY_BY = 244;
    public const int DUKE_SCREAM = 245;
    public const int SHRINKER_HIT = 246;
    public const int RATTY = 247;
    public const int INTO_MENU = 248;
    public const int BONUSMUSIC = 249;
    public const int DUKE_BOOBY = 250;
    public const int DUKE_TALKTOBOSSFALL = 251;
    public const int DUKE_LOOKINTOMIRROR = 252;
    public const int PIG_ROAM3 = 253;
    public const int KILLME = 254;
    public const int DRON_JETSND = 255;
    public const int SPACE_DOOR1 = 256;
    public const int SPACE_DOOR2 = 257;
    public const int SPACE_DOOR3 = 258;
    public const int SPACE_DOOR4 = 259;
    public const int SPACE_DOOR5 = 260;
    public const int ALIEN_ELEVATOR1 = 261;
    public const int VAULT_DOOR = 262;
    public const int JIBBED_ACTOR13 = 263;
    public const int DUKE_GETWEAPON6 = 264;
    public const int JIBBED_ACTOR8 = 265;
    public const int JIBBED_ACTOR9 = 266;
    public const int JIBBED_ACTOR10 = 267;
    public const int JIBBED_ACTOR11 = 268;
    public const int JIBBED_ACTOR12 = 269;
    public const int DUKE_KILLED4 = 270;
    public const int DUKE_KILLED5 = 271;
    public const int ALIEN_SWITCH1 = 272;
    public const int DUKE_STEPONFECES = 273;
    public const int DUKE_LONGTERM_PAIN2 = 274;
    public const int DUKE_LONGTERM_PAIN3 = 275;
    public const int DUKE_LONGTERM_PAIN4 = 276;
    public const int COMPANB2 = 277;
    public const int KTIT = 278;
    public const int HELICOP_IDLE = 279;
    public const int STEPNIT = 280;
    public const int SPACE_AMBIENCE1 = 281;
    public const int SPACE_AMBIENCE2 = 282;
    public const int SLIM_HATCH = 283;
    public const int RIPHEADNECK = 284;
    public const int FOUNDJONES = 285;
    public const int ALIEN_DOOR1 = 286;
    public const int ALIEN_DOOR2 = 287;
    public const int ENDSEQVOL3SND4 = 288;
    public const int ENDSEQVOL3SND5 = 289;
    public const int ENDSEQVOL3SND6 = 290;
    public const int ENDSEQVOL3SND7 = 291;
    public const int ENDSEQVOL3SND8 = 292;
    public const int ENDSEQVOL3SND9 = 293;
    public const int WHIPYOURASS = 294;
    public const int ENDSEQVOL2SND1 = 295;
    public const int ENDSEQVOL2SND2 = 296;
    public const int ENDSEQVOL2SND3 = 297;
    public const int ENDSEQVOL2SND4 = 298;
    public const int ENDSEQVOL2SND5 = 299;
    public const int ENDSEQVOL2SND6 = 300;
    public const int ENDSEQVOL2SND7 = 301;
    public const int GENERIC_AMBIENCE23 = 302;
    public const int SOMETHINGFROZE = 303;
    public const int DUKE_LONGTERM_PAIN5 = 304;
    public const int DUKE_LONGTERM_PAIN6 = 305;
    public const int DUKE_LONGTERM_PAIN7 = 306;
    public const int DUKE_LONGTERM_PAIN8 = 307;
    public const int WIND_REPEAT = 308;
    public const int MYENEMY_ROAM = 309;
    public const int MYENEMY_HURT = 310;
    public const int MYENEMY_DEAD = 311;
    public const int MYENEMY_SHOOT = 312;
    public const int STORE_MUSIC = 313;
    public const int STORE_MUSIC_BROKE = 314;
    public const int ACTOR_GROWING = 315;
    public const int NEWBEAST_ROAM = 316;
    public const int NEWBEAST_RECOG = 317;
    public const int NEWBEAST_ATTACK = 318;
    public const int NEWBEAST_PAIN = 319;
    public const int NEWBEAST_DYING = 320;
    public const int NEWBEAST_SPIT = 321;
    public const int VOL4_1 = 322;
    public const int SUPERMARKET = 323;
    public const int MOUSEANNOY = 324;
    public const int BOOKEM = 325;
    public const int SUPERMARKETCRY = 326;
    public const int DESTRUCT = 327;
    public const int EATFOOD = 328;
    public const int MAKEMYDAY = 329;
    public const int WITNESSSTAND = 330;
    public const int VACATIONSPEECH = 331;
    public const int YIPPEE1 = 332;
    public const int YOHOO1 = 333;
    public const int YOHOO2 = 334;
    public const int DOLPHINSND = 335;
    public const int TOUGHGALSND1 = 336;
    public const int TOUGHGALSND2 = 337;
    public const int TOUGHGALSND3 = 338;
    public const int TOUGHGALSND4 = 339;
    public const int TANK_ROAM = 340;
    public const int BOS4_ROAM = 341;
    public const int BOS4_RECOG = 342;
    public const int BOS4_ATTACK = 343;
    public const int BOS4_PAIN = 344;
    public const int BOS4_DYING = 345;
    public const int NEWBEAST_ATTACKMISS = 346;
    public const int VOL4_2 = 347;
    public const int COOKINGDEEPFRIER = 348;
    public const int WHINING_DOG = 349;
    public const int DEAD_DOG = 350;
    public const int LIGHTNING_SLAP = 351;
    public const int THUNDER = 352;
    public const int HAPPYMOUSESND1 = 353;
    public const int HAPPYMOUSESND2 = 354;
    public const int HAPPYMOUSESND3 = 355;
    public const int HAPPYMOUSESND4 = 356;
    public const int ALARM = 357;
    public const int RAIN = 358;
    public const int DTAG_GREENRUN = 359;
    public const int DTAG_BROWNRUN = 360;
    public const int DTAG_GREENSCORE = 361;
    public const int DTAG_BROWNSCORE = 362;
    public const int INTRO4_1 = 363;
    public const int INTRO4_2 = 364;
    public const int INTRO4_3 = 365;
    public const int INTRO4_4 = 366;
    public const int INTRO4_5 = 367;
    public const int INTRO4_6 = 368;
    public const int SCREECH = 369;
    public const int BOSS4_DEADSPEECH = 370;
    public const int BOSS4_FIRSTSEE = 371;
    public const int PARTY_SPEECH = 372;
    public const int POSTAL_SPEECH = 373;
    public const int TGSPEECH = 374;
    public const int DOGROOMSPEECH = 375;
    public const int SMACKED = 376;
    public const int MDEVSPEECH = 377;
    public const int AREA51SPEECH = 378;
    public const int JEEPSOUND = 379;
    public const int BIGDOORSLAM = 380;
    public const int BOS4_LAY = 381;
    public const int WAVESOUND = 382;
    public const int ILLBEBACK = 383;
    public const int VOL4ENDSND1 = 384;
    public const int VOL4ENDSND2 = 385;
    public const int EXPANDERHIT = 386;
    public const int SNAKESPEECH = 387;
    public const int EXPANDERSHOOT = 388;
    public const int GETBACKTOWORK = 389;
    public const int JIBBED_ACTOR14 = 390;
    public const int JIBBED_ACTOR15 = 391;
    public const int INTRO4_B = 392;
    public const int BIGBANG = 393;
    public const int HORNSND = 394;
    public const int BELLSND = 395;
    public const int GOAWAY = 396;
    public const int JOKE = 397;
    public const int SWEARFREQUENCY = 100;
    public const int CAMERASDESTRUCTABLE = NO;
    public const int FREEZERHURTOWNER = YES;
    public const int MAXPLAYERHEALTH = 100;
    public const int MAXWATERFOUNTAINHEALTH = 50;
    public const int YELLHURTSOUNDSTRENGTH = 40;
    public const int YELLHURTSOUNDSTRENGTHMP = 50;
    public const int MAXXSTRETCH = 70;
    public const int MAXYSTRETCH = 70;
    public const int MINXSTRETCH = 9;
    public const int MINYSTRETCH = 8;
    public const int MAXPLAYERATOMICHEALTH = 200;
    public const int DOUBLEMAXPLAYERHEALTH = MAXPLAYERATOMICHEALTH;
    public const int STARTARMORHEALTH = 0;
    public const int RETRIEVEDISTANCE = 844;
    public const int SQUISHABLEDISTANCE = 1024;
    public const int DEFAULTVISIBILITY = 512;
    public const int FROZENQUICKKICKDIST = 980;
    public const int GENERICIMPACTDAMAGE = 10;
    public const int MAXPISTOLAMMO = 200;
    public const int MAXSHOTGUNAMMO = 50;
    public const int MAXCHAINGUNAMMO = 200;
    public const int MAXRPGAMMO = 50;
    public const int MAXHANDBOMBAMMO = 50;
    public const int MAXSHRINKERAMMO = 50;
    public const int MAXGROWAMMO = 50;
    public const int MAXDEVISTATORAMMO = 99;
    public const int MAXFREEZEAMMO = 99;
    public const int MAXTRIPBOMBAMMO = 10;
    public const int TRIPBOMBLASERMODE = 0;
    public const int RESPAWNACTORTIME = 768;
    public const int RESPAWNITEMTIME = 768;
    public const int QSIZE = 64;
    public const int BLIMPRESPAWNTIME = 2048;
    public const int NUMFREEZEBOUNCES = 3;
    public const int RUNNINGSPEED = 53200;
    public const int GRAVITATIONALCONSTANT = 176;
    public const int PLAYDEADTIME = 120;
    public const int SHRUNKCOUNT = 270;
    public const int SHRUNKDONECOUNT = 304;
    public const int FROZENDRIPTIME = 90;
    public const int THAWTIME = 138;
    public const int RPGBLASTRADIUS = 1780;
    public const int PIPEBOMBRADIUS = 2500;
    public const int SHRINKERBLASTRADIUS = 680;
    public const int TRIPBOMBBLASTRADIUS = 3880;
    public const int MORTERBLASTRADIUS = 2500;
    public const int BOUNCEMINEBLASTRADIUS = 2500;
    public const int SEENINEBLASTRADIUS = 2048;
    public const int KNEE_WEAPON_STRENGTH = 10;
    public const int PISTOL_WEAPON_STRENGTH = 6;
    public const int HANDBOMB_WEAPON_STRENGTH = 140;
    public const int RPG_WEAPON_STRENGTH = 140;
    public const int SHRINKER_WEAPON_STRENGTH = 0;
    public const int GROWSPARK_WEAPON_STRENGTH = 15;
    public const int SHOTGUN_WEAPON_STRENGTH = 10;
    public const int CHAINGUN_WEAPON_STRENGTH = 9;
    public const int FREEZETHROWER_WEAPON_STRENGTH = 20;
    public const int COOL_EXPLOSION_STRENGTH = 38;
    public const int TRIPBOMB_STRENGTH = 100;
    public const int FIRELASER_WEAPON_STRENGTH = 7;
    public const int MORTER_WEAPON_STRENGTH = 50;
    public const int BOUNCEMINE_WEAPON_STRENGTH = 150;
    public const int SPIT_WEAPON_STRENGTH = 8;
    public const int BULLET_WEAPON_STRENGTH = 30;
    public const int TROOPSTRENGTH = 30;
    public const int PIGCOPSTRENGTH = 100;
    public const int PIG_SHIELD_AMOUNT1 = 75;
    public const int PIG_SHIELD_AMOUNT2 = 50;
    public const int LIZSTRENGTH = 100;
    public const int LIZGETTINGDAZEDAT = 15;
    public const int LIZEATINGPLAYER = -2;
    public const int OCTASTRENGTH = 175;
    public const int OCTASCRATCHINGPLAYER = -11;
    public const int RECONSTRENGTH = 50;
    public const int TURRETSTRENGTH = 30;
    public const int ROTTURRETSTRENGTH = 40;
    public const int DRONESTRENGTH = 150;
    public const int CAPTAINSTRENGTH = 50;
    public const int CAPTSPINNINGPLAYER = -11;
    public const int COMMANDERSTRENGTH = 350;
    public const int SHARKSTRENGTH = 35;
    public const int SHARKBITESTRENGTH = -9;
    public const int NEWBEASTSTRENGTH = 300;
    public const int NEWBEASTSCRATCHAMOUNT = -22;
    public const int DOLPHINSTRENGTH = 50;
    public const int PISTOLAMMOAMOUNT = 12;
    public const int SHOTGUNAMMOAMOUNT = 10;
    public const int CHAINGUNAMMOAMOUNT = 50;
    public const int RPGAMMOBOX = 5;
    public const int CRYSTALAMMOAMOUNT = 5;
    public const int GROWCRYSTALAMMOAMOUNT = 20;
    public const int DEVISTATORAMMOAMOUNT = 15;
    public const int FREEZEAMMOAMOUNT = 25;
    public const int HANDBOMBBOX = 5;
    public const int BOSS1STRENGTH = 4500;
    public const int BOSS1PALSTRENGTH = 1000;
    public const int BOSS2STRENGTH = 4500;
    public const int BOSS3STRENGTH = 4500;
    public const int BOSS4STRENGTH = 6000;
    public const int WEAKEST = 1;
    public const int WEAK = 5;
    public const int MEDIUMSTRENGTH = 10;
    public const int TOUGH = 20;
    public const int REALLYTOUGH = 30;
    public const int ROBOTMOUSESTRENGTH = 45;
    public const int GOTTASMART = 90;
    public const int PIRATEGALSTRENGTH = 200;
    public const int MANWOMANSTRENGTH = 100;
    public const int STEROID_AMOUNT = 400;
    public const int SHIELD_AMOUNT = 100;
    public const int SCUBA_AMOUNT = 6400;
    public const int HOLODUKE_AMOUNT = 2400;
    public const int JETPACK_AMOUNT = 1600;
    public const int HEAT_AMOUNT = 1200;
    public const int FIRSTAID_AMOUNT = MAXPLAYERHEALTH;
    public const int BOOT_AMOUNT = 200;
    public const int SPAWNAMMOODDS = 96;
    GlobalMembers.ConActions.ConAction ANULLACTION = new GlobalMembers.ConActions.ConAction(0);
    public const int SPACESHUTTLE = 487;
    GlobalMembers.ConActions.MoveAction SHUTTLEVELS = new GlobalMembers.ConActions.MoveAction(16);
    private void A_SPACESHUTTLE()
    {
    }
    private void A_SATELLITE()
    {
    }
    private void jib_sounds()
    {
        if (GlobalMembers.ConActions.ifrnd(SWEARFREQUENCY))
        {
            if (GlobalMembers.ConActions.ifrnd(128))
            {
                if (GlobalMembers.ConActions.ifrnd(128))
                {
                    if (GlobalMembers.ConActions.ifrnd(128))
                    {
                        if (GlobalMembers.ConActions.ifrnd(128))
                        {
                            if (GlobalMembers.ConActions.ifrnd(128))
                                GlobalMembers.ConActions.globalsound(JIBBED_ACTOR12);
                            else
                                GlobalMembers.ConActions.globalsound(JIBBED_ACTOR1);
                        }
                        else
                        {
                            if (GlobalMembers.ConActions.ifrnd(128))
                                GlobalMembers.ConActions.globalsound(JIBBED_ACTOR9);
                            else
                                GlobalMembers.ConActions.globalsound(JIBBED_ACTOR14);
                        }
                    }
                    else
                    {
                        if (GlobalMembers.ConActions.ifrnd(128))
                            GlobalMembers.ConActions.globalsound(SMACKED);
                        else
                            GlobalMembers.ConActions.globalsound(JIBBED_ACTOR2);
                    }
                }
                else
                {
                    if (GlobalMembers.ConActions.ifrnd(128))
                        GlobalMembers.ConActions.globalsound(MDEVSPEECH);
                    else
                        GlobalMembers.ConActions.globalsound(JIBBED_ACTOR5);
                }
            }
            else
            {
                if (GlobalMembers.ConActions.ifrnd(128))
                {
                    if (GlobalMembers.ConActions.ifrnd(128))
                    {
                        if (GlobalMembers.ConActions.ifrnd(128))
                            GlobalMembers.ConActions.globalsound(JIBBED_ACTOR11);
                        else
                            GlobalMembers.ConActions.globalsound(JIBBED_ACTOR13);
                    }
                    else
                    {
                        if (GlobalMembers.ConActions.ifrnd(128))
                            GlobalMembers.ConActions.globalsound(JIBBED_ACTOR3);
                        else
                            GlobalMembers.ConActions.globalsound(JIBBED_ACTOR8);
                    }
                }
                else
                {
                    if (GlobalMembers.ConActions.ifrnd(128))
                    {
                        if (GlobalMembers.ConActions.ifrnd(128))
                            GlobalMembers.ConActions.globalsound(JIBBED_ACTOR6);
                        else
                            GlobalMembers.ConActions.globalsound(JIBBED_ACTOR4);
                    }
                    else
                    {
                        if (GlobalMembers.ConActions.ifrnd(128))
                        {
                            if (GlobalMembers.ConActions.ifrnd(128))
                                GlobalMembers.ConActions.globalsound(JIBBED_ACTOR10);
                            else
                                GlobalMembers.ConActions.globalsound(JIBBED_ACTOR15);
                        }
                        else
                            GlobalMembers.ConActions.globalsound(JIBBED_ACTOR7);
                    }
                }
            }
        }
    }
    private void standard_jibs()
    {
        GlobalMembers.ConActions.guts(JIBS2, 1);
        GlobalMembers.ConActions.guts(JIBS3, 2);
        GlobalMembers.ConActions.guts(JIBS4, 3);
        GlobalMembers.ConActions.guts(JIBS5, 2);
        GlobalMembers.ConActions.guts(JIBS6, 3);
        if (GlobalMembers.ConActions.ifrnd(6))
        {
            GlobalMembers.ConActions.guts(JIBS1, 1);
            GlobalMembers.ConActions.spawn(BLOODPOOL);
        }
        jib_sounds();
    }
    private void genericshrunkcode()
    {
        if (GlobalMembers.ConActions.ifcount(32))
        {
            if (GlobalMembers.ConActions.ifpdistl(SQUISHABLEDISTANCE))
                GlobalMembers.ConActions.pstomp();
        }
        else
        {
            GlobalMembers.ConActions.sizeto(MINXSTRETCH, MINYSTRETCH);
            GlobalMembers.ConActions.spawn(FRAMEEFFECT1);
        }
    }
    private void genericgrowcode()
    {
        if (GlobalMembers.ConActions.ifcount(32))
        {
            GlobalMembers.ConActions.guts(JIBS4, 24);
            GlobalMembers.ConActions.guts(JIBS6, 28);
            GlobalMembers.ConActions.addkills(1);
            GlobalMembers.ConActions.sound(SQUISHED);
            GlobalMembers.ConActions.sound(PIPEBOMB_EXPLODE);
            GlobalMembers.ConActions.hitradius(2048, 60, 70, 80, 90);
            GlobalMembers.ConActions.spawn(BLOODPOOL);
            GlobalMembers.ConActions.spawn(EXPLOSION2);
            GlobalMembers.ConActions.killit();
        }
        else
        {
            if (GlobalMembers.ConActions.ifactor(COMMANDER))
                GlobalMembers.ConActions.sizeto(100, 100);
            else
            if (GlobalMembers.ConActions.ifactor(SHARK))
                GlobalMembers.ConActions.sizeto(84, 84);
            else
                GlobalMembers.ConActions.sizeto(MAXXSTRETCH, MAXYSTRETCH);
            return;
        }
    }
    GlobalMembers.ConActions.ConAction ASHARKCRUZING = new GlobalMembers.ConActions.ConAction(0, 8, 5, 1, 24);
    GlobalMembers.ConActions.ConAction ASHARKFLEE = new GlobalMembers.ConActions.ConAction(0, 8, 5, 1, 10);
    GlobalMembers.ConActions.ConAction ASHARKATACK = new GlobalMembers.ConActions.ConAction(0, 8, 5, 1, 6);
    GlobalMembers.ConActions.ConAction ASHARKSHRUNK = new GlobalMembers.ConActions.ConAction(0, 8, 5, 1, 24);
    GlobalMembers.ConActions.ConAction ASHARKGROW = new GlobalMembers.ConActions.ConAction(0, 8, 5, 1, 24);
    GlobalMembers.ConActions.ConAction ASHARKFROZEN = new GlobalMembers.ConActions.ConAction(0, 1, 5, 1, 24);
    GlobalMembers.ConActions.MoveAction SHARKVELS = new GlobalMembers.ConActions.MoveAction(24);
    GlobalMembers.ConActions.MoveAction SHARKFASTVELS = new GlobalMembers.ConActions.MoveAction(72);
    GlobalMembers.ConActions.MoveAction SHARKFLEEVELS = new GlobalMembers.ConActions.MoveAction(40);
    private void A_SHARK()
    {
        if (GlobalMembers.ConActions.ifaction(ASHARKSHRUNK))
        {
            if (GlobalMembers.ConActions.ifcount(SHRUNKDONECOUNT))
                GlobalMembers.ConActions.ConAction ASHARKCRUZING = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifcount(SHRUNKCOUNT))
                GlobalMembers.ConActions.sizeto(60, 60);
            else
                genericshrunkcode();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifaction(ASHARKGROW))
        {
            if (GlobalMembers.ConActions.ifcount(SHRUNKDONECOUNT))
                GlobalMembers.ConActions.ConAction ASHARKCRUZING = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifcount(SHRUNKCOUNT))
                GlobalMembers.ConActions.sizeto(24, 24);
            else
                genericgrowcode();
        }
        else
        if (GlobalMembers.ConActions.ifaction(ASHARKFROZEN))
        {
            GlobalMembers.ConActions.fall();
            if (GlobalMembers.ConActions.ifp(pfacing))
                if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                    GlobalMembers.ConActions.pkick();
            if (GlobalMembers.ConActions.ifcount(THAWTIME))
            {
                GlobalMembers.ConActions.ConAction ASHARKFLEE = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.getlastpal();
                return;
            }
            else
            if (GlobalMembers.ConActions.ifcount(FROZENDRIPTIME))
                if (GlobalMembers.ConActions.ifactioncount(26))
                    GlobalMembers.ConActions.resetactioncount();
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                    return;
                GlobalMembers.ConActions.lotsofglass(30);
                GlobalMembers.ConActions.sound(GLASS_BREAKING);
                GlobalMembers.ConActions.addkills(1);
                GlobalMembers.ConActions.killit();
            }
            return;
        }
        else
        if (GlobalMembers.ConActions.ifaction(ASHARKFLEE))
        {
            if (GlobalMembers.ConActions.ifcount(16))
                if (GlobalMembers.ConActions.ifrnd(48))
                {
                    GlobalMembers.ConActions.ConAction ASHARKCRUZING = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.Move(SHARKVELS, randomangle, geth);
                }
        }
        else
        if (GlobalMembers.ConActions.ifaction(ASHARKCRUZING))
        {
            if (GlobalMembers.ConActions.ifcansee())
                if (GlobalMembers.ConActions.ifcount(48))
                    if (GlobalMembers.ConActions.ifrnd(2))
                        if (GlobalMembers.ConActions.ifcanshoottarget())
                        {
                            GlobalMembers.ConActions.ConAction ASHARKATACK = new GlobalMembers.ConActions.ConAction();
                            GlobalMembers.ConActions.Move(SHARKFASTVELS, faceplayerslow, getv,break);
                        }
            if (GlobalMembers.ConActions.ifcount(32))
                if (GlobalMembers.ConActions.ifnotmoving())
                {
                    if (GlobalMembers.ConActions.ifrnd(128))
                        GlobalMembers.ConActions.Move(SHARKVELS, randomangle, geth);
                    else
                        GlobalMembers.ConActions.Move(SHARKFASTVELS, randomangle, geth);
                }
        }
        else
        if (GlobalMembers.ConActions.ifaction(ASHARKATACK))
        {
            if (GlobalMembers.ConActions.ifcount(4))
            {
                if (GlobalMembers.ConActions.ifpdistl(1280))
                {
                    if (GlobalMembers.ConActions.ifp(palive, ifcanshoottarget))
                    {
                        GlobalMembers.ConActions.sound(DUKE_GRUNT);
                        GlobalMembers.ConActions.palfrom(32, 32);
                        GlobalMembers.ConActions.addphealth(SHARKBITESTRENGTH);
                    }
                    GlobalMembers.ConActions.ConAction ASHARKFLEE = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.Move(SHARKFLEEVELS, fleeenemy);
                }
            }
            else
            if (GlobalMembers.ConActions.ifnotmoving())
            {
                if (GlobalMembers.ConActions.ifcount(32))
                {
                    GlobalMembers.ConActions.ConAction ASHARKCRUZING = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.Move(SHARKVELS, randomangle, geth);
                }
            }
            else
            if (GlobalMembers.ConActions.ifcount(48))
                if (GlobalMembers.ConActions.ifrnd(2))
                {
                    GlobalMembers.ConActions.ConAction ASHARKCRUZING = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.Move(SHARKFASTVELS, randomangle, geth);
                }
        }
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                {
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.cstat(0);
                    GlobalMembers.ConActions.ConAction ASHARKGROW = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.sound(ACTOR_GROWING);
                    return;
                }
                else
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.spritepal(1);
                    GlobalMembers.ConActions.strength(0);
                    GlobalMembers.ConActions.ConAction ASHARKFROZEN = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.sound(SOMETHINGFROZE);
                }
                else
                {
                    GlobalMembers.ConActions.sound(SQUISHED);
                    GlobalMembers.ConActions.guts(JIBS6, 5);
                    GlobalMembers.ConActions.addkills(1);
                    GlobalMembers.ConActions.killit();
                }
            }
            else
            {
                if (GlobalMembers.ConActions.ifwasweapon(SHRINKSPARK))
                {
                    GlobalMembers.ConActions.ConAction ASHARKSHRUNK = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.sound(ACTOR_SHRINKING);
                    GlobalMembers.ConActions.Move(0);
                    return;
                }
                else
                if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                    GlobalMembers.ConActions.sound(EXPANDERHIT);
                GlobalMembers.ConActions.Move(SHARKVELS, randomangle, geth);
            }
        }
    }
    GlobalMembers.ConActions.ConAction BLIMPWAITTORESPAWN = new GlobalMembers.ConActions.ConAction();
    private void blimphitstate()
    {
        GlobalMembers.ConActions.cstat(0);
        GlobalMembers.ConActions.spawn(FIRSTGUNSPRITE);
        GlobalMembers.ConActions.spawn(EXPLOSION2);
        GlobalMembers.ConActions.debris(SCRAP1, 40);
        GlobalMembers.ConActions.debris(SCRAP2, 32);
        GlobalMembers.ConActions.debris(SCRAP3, 32);
        GlobalMembers.ConActions.debris(SCRAP4, 32);
        GlobalMembers.ConActions.debris(SCRAP5, 32);
        GlobalMembers.ConActions.sound(PIPEBOMB_EXPLODE);
        if (GlobalMembers.ConActions.ifrespawn())
        {
            GlobalMembers.ConActions.ConAction BLIMPWAITTORESPAWN = new GlobalMembers.ConActions.ConAction();
            GlobalMembers.ConActions.count(0);
            GlobalMembers.ConActions.cstat(32768);
        }
        else
            GlobalMembers.ConActions.killit();
    }
    private void A_BLIMP()
    {
        if (GlobalMembers.ConActions.ifaction(BLIMPWAITTORESPAWN))
        {
            if (GlobalMembers.ConActions.ifcount(BLIMPRESPAWNTIME))
            {
                GlobalMembers.ConActions.ConAction 0 = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.cstat(0);
            }
            return;
        }
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                blimphitstate();
            if (GlobalMembers.ConActions.ifwasweapon(RPG))
                blimphitstate();
            GlobalMembers.ConActions.strength(1);
        }
    }
    private void rats()
    {
        if (GlobalMembers.ConActions.ifrnd(128))
            GlobalMembers.ConActions.spawn(RAT);
        if (GlobalMembers.ConActions.ifrnd(128))
            GlobalMembers.ConActions.spawn(RAT);
        if (GlobalMembers.ConActions.ifrnd(128))
            GlobalMembers.ConActions.spawn(RAT);
        if (GlobalMembers.ConActions.ifrnd(128))
            GlobalMembers.ConActions.spawn(RAT);
        if (GlobalMembers.ConActions.ifrnd(128))
            GlobalMembers.ConActions.spawn(RAT);
        if (GlobalMembers.ConActions.ifrnd(128))
            GlobalMembers.ConActions.spawn(RAT);
        if (GlobalMembers.ConActions.ifrnd(128))
            GlobalMembers.ConActions.spawn(RAT);
        if (GlobalMembers.ConActions.ifrnd(128))
            GlobalMembers.ConActions.spawn(RAT);
    }
    GlobalMembers.ConActions.MoveAction RESPAWN_ACTOR_FLAG = new GlobalMembers.ConActions.MoveAction();
    GlobalMembers.ConActions.MoveAction MOUSEVELS = new GlobalMembers.ConActions.MoveAction(32);
    GlobalMembers.ConActions.ConAction RUBCANDENT = new GlobalMembers.ConActions.ConAction(1, 1, 1, 1, 1);
    private void A_RUBBERCAN()
    {
        if (GlobalMembers.ConActions.ifaction(RUBCANDENT))
        {
            if (GlobalMembers.ConActions.ifactioncount(16))
            {
                GlobalMembers.ConActions.strength(0);
                GlobalMembers.ConActions.ConAction ANULLACTION = new GlobalMembers.ConActions.ConAction();
                return;
            }
        }
        else
    if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
            {
                rats();
                if (GlobalMembers.ConActions.ifrnd(48))
                    GlobalMembers.ConActions.spawn(BURNING);
                GlobalMembers.ConActions.debris(SCRAP3, 12);
                GlobalMembers.ConActions.killit();
            }
            else
                GlobalMembers.ConActions.ConAction RUBCANDENT = new GlobalMembers.ConActions.ConAction();
        }
    }
    private void toughgalspeech()
    {
        if (GlobalMembers.ConActions.ifrnd(64))
        {
            if (GlobalMembers.ConActions.ifnosounds())
                GlobalMembers.ConActions.soundonce(TOUGHGALSND1);
        }
        else
        if (GlobalMembers.ConActions.ifrnd(64))
        {
            if (GlobalMembers.ConActions.ifnosounds())
                GlobalMembers.ConActions.soundonce(TOUGHGALSND2);
        }
        else
        if (GlobalMembers.ConActions.ifrnd(64))
        {
            if (GlobalMembers.ConActions.ifnosounds())
                GlobalMembers.ConActions.soundonce(TOUGHGALSND3);
        }
        else
        if (GlobalMembers.ConActions.ifnosounds())
            GlobalMembers.ConActions.soundonce(TOUGHGALSND4);
    }
    private void jibfood()
    {
        GlobalMembers.ConActions.sound(SQUISHED);
        GlobalMembers.ConActions.guts(JIBS6, 3);
        GlobalMembers.ConActions.killit();
    }
    private void breakobject()
    {
        if (GlobalMembers.ConActions.ifaction(0))
        {
            GlobalMembers.ConActions.ConAction ANULLACTION = new GlobalMembers.ConActions.ConAction();
            GlobalMembers.ConActions.cstator(257);
            if (GlobalMembers.ConActions.ifactor(ROBOTMOUSE))
                GlobalMembers.ConActions.clipdist(64);
        }
        else
        if (GlobalMembers.ConActions.ifactor(ROBOTMOUSE))
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                if (GlobalMembers.ConActions.ifcount(32))
                {
                    GlobalMembers.ConActions.globalsound(MOUSEANNOY);
                    GlobalMembers.ConActions.killit();
                }
                return;
            }
            if (GlobalMembers.ConActions.ifcount(64))
                if (GlobalMembers.ConActions.ifrnd(6))
                {
                    if (GlobalMembers.ConActions.ifrnd(128))
                        GlobalMembers.ConActions.Move(MOUSEVELS, randomangle, geth);
                    else
                    {
                        if (GlobalMembers.ConActions.ifrnd(64))
                            GlobalMembers.ConActions.soundonce(HAPPYMOUSESND1);
                        else
                        if (GlobalMembers.ConActions.ifrnd(64))
                            GlobalMembers.ConActions.soundonce(HAPPYMOUSESND2);
                        else
                        if (GlobalMembers.ConActions.ifrnd(64))
                            GlobalMembers.ConActions.soundonce(HAPPYMOUSESND3);
                        else
                            GlobalMembers.ConActions.soundonce(HAPPYMOUSESND4);
                    }
                    GlobalMembers.ConActions.resetcount();
                }
        }
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                if (GlobalMembers.ConActions.ifactor(FOODOBJECT6))
                    jibfood();
                else
                if (GlobalMembers.ConActions.ifactor(FOODOBJECT11))
                    jibfood();
                else
                if (GlobalMembers.ConActions.ifactor(FOODOBJECT12))
                    jibfood();
                else
                if (GlobalMembers.ConActions.ifactor(FOODOBJECT13))
                    jibfood();
                else
                if (GlobalMembers.ConActions.ifactor(FOODOBJECT14))
                    jibfood();
                else
                if (GlobalMembers.ConActions.ifactor(FOODOBJECT15))
                    jibfood();
                else
                if (GlobalMembers.ConActions.ifactor(FOODOBJECT16))
                    jibfood();
                else
                if (GlobalMembers.ConActions.ifactor(FOODOBJECT17))
                    jibfood();
                else
                if (GlobalMembers.ConActions.ifactor(SKINNEDCHICKEN))
                    jibfood();
                else
                if (GlobalMembers.ConActions.ifactor(SHOPPINGCART))
                {
                    GlobalMembers.ConActions.debris(SCRAP1, 5);
                    GlobalMembers.ConActions.debris(SCRAP2, 5);
                    GlobalMembers.ConActions.debris(SCRAP3, 5);
                    GlobalMembers.ConActions.sound(GLASS_HEAVYBREAK);
                    GlobalMembers.ConActions.killit();
                }
                else
                if (GlobalMembers.ConActions.ifactor(ROBOTDOG2))
                {
                    GlobalMembers.ConActions.soundonce(DEAD_DOG);
                    GlobalMembers.ConActions.guts(JIBS2, 1);
                    GlobalMembers.ConActions.guts(JIBS3, 2);
                    GlobalMembers.ConActions.guts(JIBS6, 3);
                    GlobalMembers.ConActions.killit();
                }
                else
                if (GlobalMembers.ConActions.ifactor(FEATHEREDCHICKEN))
                    jibfood();
                else
                if (GlobalMembers.ConActions.ifactor(DOLPHIN1))
                {
                    GlobalMembers.ConActions.guts(JIBS2, 1);
                    GlobalMembers.ConActions.guts(JIBS3, 2);
                    GlobalMembers.ConActions.guts(JIBS4, 3);
                    GlobalMembers.ConActions.guts(JIBS5, 2);
                    jibfood();
                }
                else
                if (GlobalMembers.ConActions.ifactor(DOLPHIN2))
                {
                    GlobalMembers.ConActions.guts(JIBS2, 1);
                    GlobalMembers.ConActions.guts(JIBS3, 2);
                    GlobalMembers.ConActions.guts(JIBS4, 3);
                    GlobalMembers.ConActions.guts(JIBS5, 2);
                    jibfood();
                }
                else
                if (GlobalMembers.ConActions.ifactor(SNAKEP))
                {
                    GlobalMembers.ConActions.guts(JIBS2, 1);
                    GlobalMembers.ConActions.guts(JIBS3, 2);
                    GlobalMembers.ConActions.guts(JIBS4, 3);
                    GlobalMembers.ConActions.guts(JIBS5, 2);
                    jibfood();
                }
                else
                if (GlobalMembers.ConActions.ifactor(DONUTS))
                {
                    GlobalMembers.ConActions.spritepal(7);
                    GlobalMembers.ConActions.guts(JIBS6, 2);
                    GlobalMembers.ConActions.killit();
                }
                else
                if (GlobalMembers.ConActions.ifactor(DONUTS2))
                {
                    GlobalMembers.ConActions.debris(SCRAP1, 1);
                    GlobalMembers.ConActions.spritepal(7);
                    GlobalMembers.ConActions.guts(JIBS6, 2);
                    GlobalMembers.ConActions.killit();
                }
                else
                if (GlobalMembers.ConActions.ifactor(MAILBAG))
                {
                    GlobalMembers.ConActions.mail(30);
                    GlobalMembers.ConActions.debris(SCRAP3, 5);
                    GlobalMembers.ConActions.debris(SCRAP4, 3);
                    GlobalMembers.ConActions.killit();
                }
                else
                if (GlobalMembers.ConActions.ifactor(TEDDYBEAR))
                {
                    GlobalMembers.ConActions.debris(SCRAP3, 5);
                    GlobalMembers.ConActions.spritepal(1);
                    GlobalMembers.ConActions.debris(SCRAP3, 6);
                }
                else
                {
                    if (GlobalMembers.ConActions.ifrnd(128))
                        GlobalMembers.ConActions.sound(GLASS_BREAKING);
                    else
                        GlobalMembers.ConActions.sound(GLASS_HEAVYBREAK);
                }
                if (GlobalMembers.ConActions.ifactor(CLOCK))
                {
                    GlobalMembers.ConActions.cactor(BROKENCLOCK);
                    return;
                }
                else
                if (GlobalMembers.ConActions.ifactor(JOLLYMEAL))
                {
                    GlobalMembers.ConActions.spawn(ATOMICHEALTH);
                    GlobalMembers.ConActions.debris(SCRAP3, 1);
                    GlobalMembers.ConActions.debris(SCRAP4, 2);
                }
                else
                if (GlobalMembers.ConActions.ifactor(GUMBALLMACHINE))
                {
                    GlobalMembers.ConActions.cactor(GUMBALLMACHINEBROKE);
                    GlobalMembers.ConActions.strength(1);
                    GlobalMembers.ConActions.debris(SCRAP4, 2);
                    GlobalMembers.ConActions.lotsofglass(10);
                    return;
                }
                else
                if (GlobalMembers.ConActions.ifactor(GUMBALLMACHINEBROKE))
                {
                    GlobalMembers.ConActions.debris(SCRAP3, 3);
                    GlobalMembers.ConActions.debris(SCRAP4, 2);
                    GlobalMembers.ConActions.lotsofglass(10);
                }
                else
                if (GlobalMembers.ConActions.ifactor(DUKEBURGER))
                {
                    GlobalMembers.ConActions.debris(SCRAP3, 14);
                    GlobalMembers.ConActions.debris(SCRAP1, 13);
                    GlobalMembers.ConActions.debris(SCRAP4, 12);
                    GlobalMembers.ConActions.debris(SCRAP2, 12);
                    GlobalMembers.ConActions.debris(SCRAP5, 11);
                }
                else
                if (GlobalMembers.ConActions.ifactor(POLICELIGHTPOLE))
                {
                    GlobalMembers.ConActions.debris(SCRAP3, 4);
                    GlobalMembers.ConActions.debris(SCRAP1, 3);
                    GlobalMembers.ConActions.debris(SCRAP4, 2);
                    GlobalMembers.ConActions.debris(SCRAP2, 2);
                    GlobalMembers.ConActions.debris(SCRAP5, 1);
                }
                else
                if (GlobalMembers.ConActions.ifactor(TOPSECRET))
                    GlobalMembers.ConActions.paper(10);
                else
                if (GlobalMembers.ConActions.ifactor(GUNPOWDERBARREL))
                {
                    GlobalMembers.ConActions.spawn(EXPLOSION2);
                    GlobalMembers.ConActions.sound(PIPEBOMB_EXPLODE);
                    GlobalMembers.ConActions.hitradius(2048, WEAKEST, WEAK, MEDIUMSTRENGTH, TOUGH);
                    if (GlobalMembers.ConActions.ifpdistl(2048))
                        GlobalMembers.ConActions.wackplayer();
                    GlobalMembers.ConActions.debris(SCRAP1, 10);
                    GlobalMembers.ConActions.debris(SCRAP2, 13);
                    GlobalMembers.ConActions.debris(SCRAP3, 4);
                    GlobalMembers.ConActions.debris(SCRAP4, 17);
                    GlobalMembers.ConActions.debris(SCRAP5, 6);
                }
                else
                if (GlobalMembers.ConActions.ifactor(FLOORBASKET))
                {
                    GlobalMembers.ConActions.spawn(PUKE);
                    GlobalMembers.ConActions.debris(SCRAP1, 2);
                    GlobalMembers.ConActions.debris(SCRAP3, 3);
                    GlobalMembers.ConActions.debris(SCRAP4, 2);
                }
                else
                if (GlobalMembers.ConActions.ifactor(ROBOTMOUSE))
                {
                    GlobalMembers.ConActions.debris(SCRAP2, 10);
                    GlobalMembers.ConActions.spritepal(1);
                    GlobalMembers.ConActions.debris(SCRAP3, 4);
                    GlobalMembers.ConActions.resetcount();
                    GlobalMembers.ConActions.cstat(32768);
                    return;
                }
                else
                if (GlobalMembers.ConActions.ifactor(ROBOTPIRATE))
                {
                    GlobalMembers.ConActions.debris(SCRAP2, 10);
                    GlobalMembers.ConActions.debris(SCRAP1, 5);
                    GlobalMembers.ConActions.debris(SCRAP3, 3);
                    GlobalMembers.ConActions.lotsofglass(10);
                }
                else
                if (GlobalMembers.ConActions.ifactor(PIRATE1A))
                {
                    GlobalMembers.ConActions.debris(SCRAP2, 10);
                    GlobalMembers.ConActions.debris(SCRAP1, 5);
                    GlobalMembers.ConActions.debris(SCRAP3, 3);
                    GlobalMembers.ConActions.lotsofglass(10);
                }
                else
                if (GlobalMembers.ConActions.ifactor(MAN))
                {
                    GlobalMembers.ConActions.debris(SCRAP2, 10);
                    GlobalMembers.ConActions.debris(SCRAP1, 5);
                    GlobalMembers.ConActions.debris(SCRAP3, 3);
                    GlobalMembers.ConActions.lotsofglass(10);
                }
                else
                if (GlobalMembers.ConActions.ifactor(MAN2))
                {
                    GlobalMembers.ConActions.debris(SCRAP2, 10);
                    GlobalMembers.ConActions.debris(SCRAP1, 5);
                    GlobalMembers.ConActions.debris(SCRAP3, 3);
                    GlobalMembers.ConActions.lotsofglass(10);
                }
                else
                if (GlobalMembers.ConActions.ifactor(PIRATE2A))
                {
                    GlobalMembers.ConActions.debris(SCRAP2, 10);
                    GlobalMembers.ConActions.debris(SCRAP1, 5);
                    GlobalMembers.ConActions.debris(SCRAP3, 3);
                    GlobalMembers.ConActions.lotsofglass(10);
                }
                else
                if (GlobalMembers.ConActions.ifactor(PIRATE3A))
                {
                    GlobalMembers.ConActions.debris(SCRAP2, 10);
                    GlobalMembers.ConActions.debris(SCRAP1, 5);
                    GlobalMembers.ConActions.debris(SCRAP3, 3);
                    GlobalMembers.ConActions.lotsofglass(10);
                }
                else
                if (GlobalMembers.ConActions.ifactor(PIRATE4A))
                {
                    GlobalMembers.ConActions.debris(SCRAP2, 10);
                    GlobalMembers.ConActions.debris(SCRAP1, 5);
                    GlobalMembers.ConActions.debris(SCRAP3, 3);
                    GlobalMembers.ConActions.lotsofglass(10);
                }
                else
                if (GlobalMembers.ConActions.ifactor(PIRATE4A))
                {
                    GlobalMembers.ConActions.debris(SCRAP2, 10);
                    GlobalMembers.ConActions.debris(SCRAP1, 5);
                    GlobalMembers.ConActions.debris(SCRAP3, 3);
                    GlobalMembers.ConActions.lotsofglass(10);
                }
                else
                if (GlobalMembers.ConActions.ifactor(PIRATE5A))
                {
                    GlobalMembers.ConActions.debris(SCRAP2, 10);
                    GlobalMembers.ConActions.debris(SCRAP1, 5);
                    GlobalMembers.ConActions.debris(SCRAP3, 3);
                    GlobalMembers.ConActions.lotsofglass(10);
                }
                else
                if (GlobalMembers.ConActions.ifactor(PIRATE6A))
                {
                    GlobalMembers.ConActions.debris(SCRAP2, 10);
                    GlobalMembers.ConActions.debris(SCRAP1, 5);
                    GlobalMembers.ConActions.debris(SCRAP3, 3);
                    GlobalMembers.ConActions.lotsofglass(10);
                }
                else
                {
                    GlobalMembers.ConActions.lotsofglass(10);
                    GlobalMembers.ConActions.debris(SCRAP4, 3);
                }
                GlobalMembers.ConActions.killit();
            }
            else
            if (GlobalMembers.ConActions.ifactor(DOLPHIN1))
            {
                GlobalMembers.ConActions.guts(JIBS6, 1);
                GlobalMembers.ConActions.soundonce(DOLPHINSND);
                if (GlobalMembers.ConActions.ifstrength(TOUGH))
                {
                    GlobalMembers.ConActions.cactor(DOLPHIN2);
                    GlobalMembers.ConActions.sound(SQUISHED);
                }
            }
            else
            if (GlobalMembers.ConActions.ifactor(DOLPHIN2))
            {
                GlobalMembers.ConActions.guts(JIBS6, 1);
                GlobalMembers.ConActions.soundonce(DOLPHINSND);
            }
            else
            if (GlobalMembers.ConActions.ifactor(ROBOTDOG2))
            {
                GlobalMembers.ConActions.guts(JIBS6, 1);
                GlobalMembers.ConActions.soundonce(WHINING_DOG);
            }
        }
        else
        {
            if (GlobalMembers.ConActions.ifactor(CLOCK))
// nullop
else
    if (GlobalMembers.ConActions.ifactor(TOPSECRET))
// nullop
else
    if (GlobalMembers.ConActions.ifactor(SKINNEDCHICKEN))
// nullop
else
    if (GlobalMembers.ConActions.ifactor(FEATHEREDCHICKEN))
// nullop
else
    if (GlobalMembers.ConActions.ifactor(FOODOBJECT2))
// nullop
else
    if (GlobalMembers.ConActions.ifactor(FOODOBJECT6))
// nullop
else
    if (GlobalMembers.ConActions.ifactor(DOLPHIN1))
// nullop
else
    if (GlobalMembers.ConActions.ifactor(DOLPHIN2))
// nullop
else
                                                                                GlobalMembers.ConActions.fall();
        }
    }
    GlobalMembers.ConActions.ConAction ABURGERROTS = new GlobalMembers.ConActions.ConAction(0, 1, 5);
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void A_notenemy()
    {
        breakobject();
    }
    private void headhitstate()
    {
    }
    GlobalMembers.ConActions.ConAction EXPBARRELFRAME = new GlobalMembers.ConActions.ConAction(0, 2, 1, 1, 15);
    private void A_EXPLODINGBARREL()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifaction(EXPBARRELFRAME))
        {
            if (GlobalMembers.ConActions.ifactioncount(2))
            {
                GlobalMembers.ConActions.hitradius(1024, WEAKEST, WEAK, MEDIUMSTRENGTH, TOUGH);
                GlobalMembers.ConActions.spawn(EXPLOSION2);
                GlobalMembers.ConActions.debris(SCRAP2, 2);
                GlobalMembers.ConActions.sound(PIPEBOMB_EXPLODE);
                GlobalMembers.ConActions.killit();
            }
            return;
        }
        if (GlobalMembers.ConActions.ifsquished())
        {
            GlobalMembers.ConActions.debris(SCRAP1, 5);
            GlobalMembers.ConActions.killit();
            return;
        }
        if (GlobalMembers.ConActions.ifhitweapon())
            GlobalMembers.ConActions.ConAction EXPBARRELFRAME = new GlobalMembers.ConActions.ConAction();
    }
    GlobalMembers.ConActions.ConAction BURNING_FLAME = new GlobalMembers.ConActions.ConAction(0, 12, 1, 1, 2);
    GlobalMembers.ConActions.MoveAction BURNING_VELS = new GlobalMembers.ConActions.MoveAction();
    private void burningstate()
    {
        GlobalMembers.ConActions.sleeptime(300);
        if (GlobalMembers.ConActions.ifspawnedby(BURNING))
        {
            if (GlobalMembers.ConActions.ifgapzl(16))
                return;
        }
        else
        if (GlobalMembers.ConActions.ifspawnedby(BURNING2))
        {
            if (GlobalMembers.ConActions.ifgapzl(16))
                return;
        }
        if (GlobalMembers.ConActions.ifpdistg(10240))
            return;
        if (GlobalMembers.ConActions.ifcount(128))
        {
            if (GlobalMembers.ConActions.ifspawnedby(TIRE))
            {
                if (GlobalMembers.ConActions.ifactioncount(512))
                    GlobalMembers.ConActions.killit();
                if (GlobalMembers.ConActions.ifrnd(16))
                    GlobalMembers.ConActions.sizeto(64, 48);
            }
            else
            {
                GlobalMembers.ConActions.sizeto(8, 8);
                GlobalMembers.ConActions.sizeto(8, 8);
                if (GlobalMembers.ConActions.ifcount(192))
                    GlobalMembers.ConActions.killit();
            }
        }
        else
        {
            if (GlobalMembers.ConActions.ifmove(0))
                GlobalMembers.ConActions.Move(BURNING_VELS);
            GlobalMembers.ConActions.sizeto(52, 52);
            if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(844))
                    if (GlobalMembers.ConActions.ifrnd(32))
                        if (GlobalMembers.ConActions.ifcansee())
                        {
                            GlobalMembers.ConActions.soundonce(DUKE_LONGTERM_PAIN);
                            GlobalMembers.ConActions.addphealth(-1);
                            GlobalMembers.ConActions.palfrom(24, 16);
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
    GlobalMembers.ConActions.ConAction TOILETWATERFRAMES = new GlobalMembers.ConActions.ConAction(0, 4, 1, 1, 1);
    private void A_TOILETWATER()
    {
        if (GlobalMembers.ConActions.ifpdistl(8192))
        {
            GlobalMembers.ConActions.soundonce(WATER_GURGLE);
            if (GlobalMembers.ConActions.ifspawnedby(TOILET))
                GlobalMembers.ConActions.sizeto(34, 34);
            else
            {
                if (GlobalMembers.ConActions.ifspawnedby(WATERFOUNTAINBROKE))
                    GlobalMembers.ConActions.sizeto(6, 15);
                else
                if (GlobalMembers.ConActions.ifspawnedby(TOILETWATER))
// nullop
else
                            GlobalMembers.ConActions.sizeto(24, 32);
            }
            if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifp(pfacing))
                        if (GlobalMembers.ConActions.ifactioncount(32))
                            if (GlobalMembers.ConActions.ifphealthl(MAXPLAYERHEALTH))
                                if (GlobalMembers.ConActions.ifhitspace())
                                    if (GlobalMembers.ConActions.ifcansee())
                                    {
                                        GlobalMembers.ConActions.addphealth(1);
                                        GlobalMembers.ConActions.globalsound(DUKE_DRINKING);
                                        GlobalMembers.ConActions.resetactioncount();
                                    }
        }
    }
    GlobalMembers.ConActions.ConAction WOODENHORSEFRAME = new GlobalMembers.ConActions.ConAction(0, 1, 4);
    GlobalMembers.ConActions.ConAction WOODENFALLFRAME = new GlobalMembers.ConActions.ConAction(122, 1, 5);
    private void A_HORSEONSIDE()
    {
        GlobalMembers.ConActions.cactor(WOODENHORSE);
        GlobalMembers.ConActions.ConAction WOODENFALLFRAME = new GlobalMembers.ConActions.ConAction();
    }
    private void A_WOODENHORSE()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                GlobalMembers.ConActions.debris(SCRAP1, 4);
                GlobalMembers.ConActions.debris(SCRAP2, 3);
                GlobalMembers.ConActions.killit();
            }
            else
                GlobalMembers.ConActions.ConAction WOODENFALLFRAME = new GlobalMembers.ConActions.ConAction();
        }
    }
    private void steamcode()
    {
        if (GlobalMembers.ConActions.ifpdistl(6144))
            GlobalMembers.ConActions.soundonce(STEAM_HISSING);
        if (GlobalMembers.ConActions.ifcount(20))
        {
            GlobalMembers.ConActions.resetcount();
            if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(1024))
                {
                    GlobalMembers.ConActions.addphealth(-1);
                    GlobalMembers.ConActions.palfrom(16, 16);
                }
        }
        else
        {
            if (GlobalMembers.ConActions.ifspawnedby(STEAM))
                return;
            else
            if (GlobalMembers.ConActions.ifspawnedby(CEILINGSTEAM))
                return;
            GlobalMembers.ConActions.sizeto(24, 24);
        }
    }
    GlobalMembers.ConActions.ConAction STEAMFRAMES = new GlobalMembers.ConActions.ConAction(0, 5, 1, 1, 1);
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
        if (GlobalMembers.ConActions.ifpdistl(3084))
            if (GlobalMembers.ConActions.ifrnd(24))
                GlobalMembers.ConActions.spawn(WATERBUBBLE);
    }
    GlobalMembers.ConActions.ConAction BUBBLE = new GlobalMembers.ConActions.ConAction();
    GlobalMembers.ConActions.ConAction CRACKEDBUBBLE = new GlobalMembers.ConActions.ConAction(1);
    GlobalMembers.ConActions.MoveAction BUBMOVE = new GlobalMembers.ConActions.MoveAction(-10, -36);
    GlobalMembers.ConActions.MoveAction BUBMOVEFAST = new GlobalMembers.ConActions.MoveAction(-10, -52);
    private void A_WATERBUBBLE()
    {
        if (GlobalMembers.ConActions.ifaction(CRACKEDBUBBLE))
        {
            if (GlobalMembers.ConActions.ifinwater())
                if (GlobalMembers.ConActions.ifrnd(192))
                    GlobalMembers.ConActions.killit();
            if (GlobalMembers.ConActions.ifactioncount(7))
                GlobalMembers.ConActions.killit();
        }
        else
        {
            if (GlobalMembers.ConActions.ifcount(4))
            {
                if (GlobalMembers.ConActions.ifrnd(192))
                    GlobalMembers.ConActions.Move(BUBMOVE, getv, geth, randomangle);
                else
                    GlobalMembers.ConActions.Move(BUBMOVEFAST, getv, geth, randomangle);
                GlobalMembers.ConActions.resetcount();
                if (GlobalMembers.ConActions.ifrnd(84))
                    GlobalMembers.ConActions.sizeat(8, 10);
                else
                if (GlobalMembers.ConActions.ifrnd(84))
                    GlobalMembers.ConActions.sizeat(10, 8);
                else
                    GlobalMembers.ConActions.sizeat(9, 9);
            }
            if (GlobalMembers.ConActions.ifonwater())
            {
                if (GlobalMembers.ConActions.iffloordistl(8))
                    GlobalMembers.ConActions.ConAction CRACKEDBUBBLE = new GlobalMembers.ConActions.ConAction();
            }
            else
            if (GlobalMembers.ConActions.ifactioncount(40))
                GlobalMembers.ConActions.ConAction CRACKEDBUBBLE = new GlobalMembers.ConActions.ConAction();
        }
    }
    GlobalMembers.ConActions.MoveAction SMOKEVEL = new GlobalMembers.ConActions.MoveAction(8, -16);
    GlobalMembers.ConActions.MoveAction ENGINE_SMOKE = new GlobalMembers.ConActions.MoveAction(64, -64);
    GlobalMembers.ConActions.MoveAction SMOKESHOOTOUT = new GlobalMembers.ConActions.MoveAction(-192);
    GlobalMembers.ConActions.ConAction SMOKEFRAMES = new GlobalMembers.ConActions.ConAction(0, 4, 1, 1, 10);
    private void A_SMALLSMOKE()
    {
        if (GlobalMembers.ConActions.ifmove(0))
        {
            if (GlobalMembers.ConActions.ifspawnedby(RECON))
                GlobalMembers.ConActions.Move(SMOKESHOOTOUT, geth);
            else
            if (GlobalMembers.ConActions.ifspawnedby(SECTOREFFECTOR))
                GlobalMembers.ConActions.Move(ENGINE_SMOKE, geth, getv);
            else
                GlobalMembers.ConActions.Move(SMOKEVEL, geth, getv, faceplayer);
            if (GlobalMembers.ConActions.ifspawnedby(RPG))
                GlobalMembers.ConActions.cstat(2);
        }
        if (GlobalMembers.ConActions.ifpdistl(1596))
            if (GlobalMembers.ConActions.ifspawnedby(RPG))
                GlobalMembers.ConActions.killit();
        if (GlobalMembers.ConActions.ifactioncount(4))
            GlobalMembers.ConActions.killit();
    }
    GlobalMembers.ConActions.ConAction BARREL_DENTING = new GlobalMembers.ConActions.ConAction(2, 2, 1, 1, 6);
    GlobalMembers.ConActions.ConAction BARREL_DENTED = new GlobalMembers.ConActions.ConAction(1);
    GlobalMembers.ConActions.ConAction BARREL_DENTED2 = new GlobalMembers.ConActions.ConAction(2);
    GlobalMembers.ConActions.MoveAction SPAWNED_BLOOD = new GlobalMembers.ConActions.MoveAction();
    private void A_NUKEBARRELDENTED()
    {
        GlobalMembers.ConActions.cactor(NUKEBARREL);
        GlobalMembers.ConActions.ConAction BARREL_DENTED = new GlobalMembers.ConActions.ConAction();
    }
    private void A_NUKEBARRELLEAKED()
    {
        GlobalMembers.ConActions.cactor(NUKEBARREL);
        GlobalMembers.ConActions.ConAction BARREL_DENTED2 = new GlobalMembers.ConActions.ConAction();
    }
    private void random_ooz()
    {
        if (GlobalMembers.ConActions.ifrnd(128))
            GlobalMembers.ConActions.spawn(OOZ2);
        else
            GlobalMembers.ConActions.spawn(OOZ);
    }
    private void A_NUKEBARREL()
    {
        if (GlobalMembers.ConActions.ifsquished())
        {
            GlobalMembers.ConActions.debris(SCRAP1, 32);
            GlobalMembers.ConActions.spawn(BLOODPOOL);
            random_ooz();
            GlobalMembers.ConActions.killit();
        }
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifaction(BARREL_DENTING))
        {
            if (GlobalMembers.ConActions.ifactioncount(2))
            {
                GlobalMembers.ConActions.debris(SCRAP1, 10);
                if (GlobalMembers.ConActions.ifrnd(2))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.killit();
            }
        }
        else
    if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                GlobalMembers.ConActions.sound(VENT_BUST);
                if (GlobalMembers.ConActions.ifrnd(128))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.ConAction BARREL_DENTING = new GlobalMembers.ConActions.ConAction();
            }
            else
            {
                if (GlobalMembers.ConActions.ifaction(0))
                    GlobalMembers.ConActions.ConAction BARREL_DENTED = new GlobalMembers.ConActions.ConAction();
                else
                if (GlobalMembers.ConActions.ifaction(BARREL_DENTED))
                {
                    GlobalMembers.ConActions.ConAction BARREL_DENTED2 = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                }
                else
                if (GlobalMembers.ConActions.ifaction(BARREL_DENTED2))
                    GlobalMembers.ConActions.ConAction BARREL_DENTING = new GlobalMembers.ConActions.ConAction();
            }
        }
    }
    private void burningbarrelcode()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifcount(32))
        {
            GlobalMembers.ConActions.resetcount();
            if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(1480))
                    if (GlobalMembers.ConActions.ifp(phigher))
                    {
                        GlobalMembers.ConActions.addphealth(-1);
                        GlobalMembers.ConActions.palfrom(16, 16);
                        if (GlobalMembers.ConActions.ifrnd(96))
                            GlobalMembers.ConActions.sound(DUKE_LONGTERM_PAIN);
                    }
        }
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            GlobalMembers.ConActions.sound(VENT_BUST);
            GlobalMembers.ConActions.debris(SCRAP1, 10);
            if (GlobalMembers.ConActions.ifrnd(128))
                GlobalMembers.ConActions.spawn(BURNING);
            else
                GlobalMembers.ConActions.spawn(BURNING2);
            GlobalMembers.ConActions.killit();
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
    GlobalMembers.ConActions.ConAction SHRINKERFRAMES = new GlobalMembers.ConActions.ConAction(0, 4, 1, 1, 10);
    private void A_SHRINKEREXPLOSION()
    {
        if (GlobalMembers.ConActions.ifactioncount(4))
            GlobalMembers.ConActions.killit();
    }
    GlobalMembers.ConActions.ConAction EXPLOSION_FRAMES = new GlobalMembers.ConActions.ConAction(0, 20, 1, 1, 4);
    private void A_EXPLOSION2()
    {
        if (GlobalMembers.ConActions.ifactioncount(20))
            GlobalMembers.ConActions.killit();
    }
    private void A_EXPLOSION2BOT()
    {
        if (GlobalMembers.ConActions.ifactioncount(20))
            GlobalMembers.ConActions.killit();
    }
    GlobalMembers.ConActions.ConAction FFLAME_FR = new GlobalMembers.ConActions.ConAction(0, 16, 1, 1, 1);
    GlobalMembers.ConActions.ConAction FFLAME = new GlobalMembers.ConActions.ConAction(0, 1, 1, 1, 1);
    private void A_FLOORFLAME()
    {
        if (GlobalMembers.ConActions.ifaction(FFLAME_FR))
        {
            if (GlobalMembers.ConActions.ifpdistl(1024))
                GlobalMembers.ConActions.hitradius(1024, WEAKEST, WEAKEST, WEAKEST, WEAKEST);
            if (GlobalMembers.ConActions.ifactioncount(16))
                GlobalMembers.ConActions.ConAction FFLAME = new GlobalMembers.ConActions.ConAction();
        }
        if (GlobalMembers.ConActions.ifaction(FFLAME))
            if (GlobalMembers.ConActions.ifrnd(4))
            {
                GlobalMembers.ConActions.ConAction FFLAME_FR = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.sound(CAT_FIRE);
                GlobalMembers.ConActions.resetactioncount();
            }
    }
    GlobalMembers.ConActions.ConAction ASATNSPIN = new GlobalMembers.ConActions.ConAction(0, 5, 1, 1, 4);
    GlobalMembers.ConActions.ConAction ASATSHOOTING = new GlobalMembers.ConActions.ConAction(-10, 3, 5, 1, 40);
    GlobalMembers.ConActions.ConAction ASATWAIT = new GlobalMembers.ConActions.ConAction(0, 1, 5, 1, 1);
    GlobalMembers.ConActions.MoveAction TURRVEL = new GlobalMembers.ConActions.MoveAction();
    private void A_ROTATEGUN()
    {
        if (GlobalMembers.ConActions.ifaction(0))
        {
            GlobalMembers.ConActions.ConAction ASATSHOOTING = new GlobalMembers.ConActions.ConAction();
            GlobalMembers.ConActions.Move(TURRVEL, faceplayer);
        }
        else
        if (GlobalMembers.ConActions.ifaction(ASATNSPIN))
        {
            if (GlobalMembers.ConActions.ifactioncount(32))
            {
                GlobalMembers.ConActions.ConAction ASATWAIT = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.Move(TURRVEL, faceplayer);
            }
        }
        else
        if (GlobalMembers.ConActions.ifaction(ASATSHOOTING))
        {
            if (GlobalMembers.ConActions.ifactioncount(12))
                if (GlobalMembers.ConActions.ifrnd(32))
                {
                    GlobalMembers.ConActions.ConAction ASATWAIT = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.Move(0);
                }
            if (GlobalMembers.ConActions.ifcount(32))
                GlobalMembers.ConActions.resetcount();
            else
            if (GlobalMembers.ConActions.ifcount(16))
            {
                if (GlobalMembers.ConActions.ifcount(17))
// nullop
else
                        {
                            GlobalMembers.ConActions.sound(PRED_ATTACK);
                            GlobalMembers.ConActions.shoot(FIRELASER);
                        }
            }
            else
            if (GlobalMembers.ConActions.ifcount(4))
            {
                if (GlobalMembers.ConActions.ifcount(5))
// nullop
else
                        {
                            if (GlobalMembers.ConActions.ifcansee())
                                if (GlobalMembers.ConActions.ifcanshoottarget())
                                {
                                    GlobalMembers.ConActions.sound(PRED_ATTACK);
                                    GlobalMembers.ConActions.shoot(FIRELASER);
                                }
                        }
            }
        }
        else
        if (GlobalMembers.ConActions.ifaction(ASATWAIT))
        {
            if (GlobalMembers.ConActions.ifactioncount(64))
                if (GlobalMembers.ConActions.ifrnd(32))
                    if (GlobalMembers.ConActions.ifp(palive))
                        if (GlobalMembers.ConActions.ifcansee())
                        {
                            GlobalMembers.ConActions.ConAction ASATSHOOTING = new GlobalMembers.ConActions.ConAction();
                            GlobalMembers.ConActions.Move(TURRVEL, faceplayer);
                        }
        }
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                GlobalMembers.ConActions.addkills(1);
                GlobalMembers.ConActions.sound(LASERTRIP_EXPLODE);
                GlobalMembers.ConActions.debris(SCRAP1, 15);
                GlobalMembers.ConActions.spawn(EXPLOSION2);
                GlobalMembers.ConActions.killit();
            }
            else
            {
                GlobalMembers.ConActions.ConAction ASATNSPIN = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.debris(SCRAP1, 4);
            }
            GlobalMembers.ConActions.Move(0);
        }
    }
    GlobalMembers.ConActions.ConAction RIP_F = new GlobalMembers.ConActions.ConAction(0, 8, 1, 1, 1);
    private void A_FORCERIPPLE()
    {
        if (GlobalMembers.ConActions.ifactioncount(8))
            GlobalMembers.ConActions.killit();
    }
    GlobalMembers.ConActions.ConAction TRANSFOWARD = new GlobalMembers.ConActions.ConAction(0, 6, 1, 1, 2);
    GlobalMembers.ConActions.ConAction TRANSBACK = new GlobalMembers.ConActions.ConAction(5, 6, 1, -1, 2);
    private void A_TRANSPORTERSTAR()
    {
        if (GlobalMembers.ConActions.ifaction(TRANSFOWARD))
        {
            if (GlobalMembers.ConActions.ifactioncount(6))
                GlobalMembers.ConActions.ConAction TRANSBACK = new GlobalMembers.ConActions.ConAction();
        }
        else
        if (GlobalMembers.ConActions.ifactioncount(6))
            GlobalMembers.ConActions.killit();
    }
    GlobalMembers.ConActions.ConAction BEAMFOWARD = new GlobalMembers.ConActions.ConAction(0, 4, 1, 1, 9);
    private void A_TRANSPORTERBEAM()
    {
        GlobalMembers.ConActions.sizeto(32, 64);
        GlobalMembers.ConActions.sizeto(32, 64);
        GlobalMembers.ConActions.sizeto(32, 64);
        if (GlobalMembers.ConActions.ifactioncount(4))
            GlobalMembers.ConActions.killit();
    }
    private void getcode()
    {
        if (GlobalMembers.ConActions.ifactor(ATOMICHEALTH))
            GlobalMembers.ConActions.globalsound(GETATOMICHEALTH);
        else
            GlobalMembers.ConActions.globalsound(DUKE_GET);
        GlobalMembers.ConActions.palfrom(16, 0, 32);
        if (GlobalMembers.ConActions.ifrespawn())
        {
            GlobalMembers.ConActions.Move(RESPAWN_ACTOR_FLAG);
            GlobalMembers.ConActions.spawn(RESPAWNMARKERRED);
            GlobalMembers.ConActions.cstat(32768);
        }
        else
            GlobalMembers.ConActions.killit();
    }
    private void randgetweapsnds()
    {
        if (GlobalMembers.ConActions.ifrnd(64))
            GlobalMembers.ConActions.globalsound(DUKE_GETWEAPON1);
        else
        if (GlobalMembers.ConActions.ifrnd(96))
            GlobalMembers.ConActions.globalsound(DUKE_GETWEAPON2);
        else
        if (GlobalMembers.ConActions.ifrnd(128))
            GlobalMembers.ConActions.globalsound(DUKE_GETWEAPON3);
        else
        if (GlobalMembers.ConActions.ifrnd(140))
            GlobalMembers.ConActions.globalsound(DUKE_GETWEAPON4);
        else
            GlobalMembers.ConActions.globalsound(DUKE_GETWEAPON6);
    }
    private void getweaponcode()
    {
        randgetweapsnds();
        GlobalMembers.ConActions.palfrom(32, 0, 32);
        if (GlobalMembers.ConActions.ifgotweaponce(1))
            return;
        if (GlobalMembers.ConActions.ifrespawn())
        {
            GlobalMembers.ConActions.Move(RESPAWN_ACTOR_FLAG);
            GlobalMembers.ConActions.spawn(RESPAWNMARKERRED);
            GlobalMembers.ConActions.cstat(32768);
        }
        else
            GlobalMembers.ConActions.killit();
    }
    private void respawnit()
    {
        if (GlobalMembers.ConActions.ifcount(RESPAWNITEMTIME))
        {
            GlobalMembers.ConActions.spawn(TRANSPORTERSTAR);
            GlobalMembers.ConActions.Move(0);
            GlobalMembers.ConActions.cstat(0);
            GlobalMembers.ConActions.sound(TELEPORTER);
        }
    }
    private void quikget()
    {
        if (GlobalMembers.ConActions.ifactor(ATOMICHEALTH))
            GlobalMembers.ConActions.globalsound(GETATOMICHEALTH);
        else
            GlobalMembers.ConActions.globalsound(DUKE_GET);
        GlobalMembers.ConActions.palfrom(16, 0, 32);
        GlobalMembers.ConActions.killit();
    }
    private void quikweaponget()
    {
        randgetweapsnds();
        GlobalMembers.ConActions.palfrom(32, 0, 32);
        if (GlobalMembers.ConActions.ifgotweaponce(1))
            return;
        GlobalMembers.ConActions.killit();
    }
    private void A_STEROIDS()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk))
// nullop
else
    if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                            if (GlobalMembers.ConActions.ifwasweapon(GET_STEROIDS, STEROID_AMOUNT))
                                if (GlobalMembers.ConActions.ifcanseetarget())
                                {
                                    GlobalMembers.ConActions.addinventory(GET_STEROIDS, STEROID_AMOUNT);
                                    GlobalMembers.ConActions.quote(37);
                                    if (GlobalMembers.ConActions.ifspawnedby(STEROIDS))
                                        getcode();
                                    else
                                        quikget();
                                }
    }
    private void A_BOOTS()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk))
// nullop
else
    if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                            if (GlobalMembers.ConActions.ifwasweapon(GET_BOOTS, BOOT_AMOUNT))
                                if (GlobalMembers.ConActions.ifcanseetarget())
                                {
                                    GlobalMembers.ConActions.addinventory(GET_BOOTS, BOOT_AMOUNT);
                                    GlobalMembers.ConActions.quote(6);
                                    if (GlobalMembers.ConActions.ifspawnedby(BOOTS))
                                        getcode();
                                    else
                                        quikget();
                                }
    }
    private void A_HEATSENSOR()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk))
// nullop
else
    if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                            if (GlobalMembers.ConActions.ifwasweapon(GET_HEATS, HEAT_AMOUNT))
                                if (GlobalMembers.ConActions.ifcanseetarget())
                                {
                                    GlobalMembers.ConActions.addinventory(GET_HEATS, HEAT_AMOUNT);
                                    GlobalMembers.ConActions.quote(101);
                                    if (GlobalMembers.ConActions.ifspawnedby(HEATSENSOR))
                                        getcode();
                                    else
                                        quikget();
                                }
    }
    private void A_SHIELD()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifcount(6))
                    if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                        if (GlobalMembers.ConActions.ifwasweapon(GET_SHIELD, SHIELD_AMOUNT))
                            if (GlobalMembers.ConActions.ifcanseetarget())
                            {
                                if (GlobalMembers.ConActions.ifspawnedby(PIGCOP))
                                {
                                    if (GlobalMembers.ConActions.ifrnd(128))
                                        GlobalMembers.ConActions.addinventory(GET_SHIELD, PIG_SHIELD_AMOUNT1);
                                    else
                                        GlobalMembers.ConActions.addinventory(GET_SHIELD, PIG_SHIELD_AMOUNT2);
                                    GlobalMembers.ConActions.quote(104);
                                    GlobalMembers.ConActions.sound(KICK_HIT);
                                    GlobalMembers.ConActions.palfrom(24, 0, 32);
                                    GlobalMembers.ConActions.killit();
                                }
                                else
                                    GlobalMembers.ConActions.addinventory(GET_SHIELD, SHIELD_AMOUNT);
                                GlobalMembers.ConActions.quote(38);
                                if (GlobalMembers.ConActions.ifspawnedby(SHIELD))
                                    getcode();
                                else
                                    quikget();
                            }
    }
    private void A_AIRTANK()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifcount(6))
                    if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                        if (GlobalMembers.ConActions.ifwasweapon(GET_SCUBA, SCUBA_AMOUNT))
                            if (GlobalMembers.ConActions.ifcanseetarget())
                            {
                                GlobalMembers.ConActions.addinventory(GET_SCUBA, SCUBA_AMOUNT);
                                GlobalMembers.ConActions.quote(39);
                                if (GlobalMembers.ConActions.ifspawnedby(AIRTANK))
                                    getcode();
                                else
                                    quikget();
                            }
    }
    GlobalMembers.ConActions.ConAction HOLODUKE_FRAMES = new GlobalMembers.ConActions.ConAction(0, 4, 1, 1, 8);
    private void A_HOLODUKE()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifcount(6))
                    if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                        if (GlobalMembers.ConActions.ifwasweapon(GET_HOLODUKE, HOLODUKE_AMOUNT))
                            if (GlobalMembers.ConActions.ifcanseetarget())
                            {
                                GlobalMembers.ConActions.addinventory(GET_HOLODUKE, HOLODUKE_AMOUNT);
                                GlobalMembers.ConActions.quote(51);
                                if (GlobalMembers.ConActions.ifspawnedby(HOLODUKE))
                                    getcode();
                                else
                                    quikget();
                            }
    }
    private void A_JETPACK()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifwasweapon(GET_JETPACK, JETPACK_AMOUNT))
                            if (GlobalMembers.ConActions.ifcanseetarget())
                            {
                                GlobalMembers.ConActions.addinventory(GET_JETPACK, JETPACK_AMOUNT);
                                GlobalMembers.ConActions.quote(41);
                                if (GlobalMembers.ConActions.ifspawnedby(JETPACK))
                                    getcode();
                                else
                                    quikget();
                            }
    }
    private void A_ACCESSCARD()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            if (GlobalMembers.ConActions.ifwasweapon(GET_ACCESS, 0))
                                return;
                            GlobalMembers.ConActions.addinventory(GET_ACCESS, 1);
                            GlobalMembers.ConActions.quote(43);
                            getcode();
                        }
    }
    private void A_AMMO()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifcount(6))
                    if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            GlobalMembers.ConActions.addammo(PISTOL_WEAPON, PISTOLAMMOAMOUNT);
                            GlobalMembers.ConActions.quote(65);
                            if (GlobalMembers.ConActions.ifspawnedby(AMMO))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_FREEZEAMMO()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifcount(6))
                    if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            GlobalMembers.ConActions.addammo(FREEZE_WEAPON, FREEZEAMMOAMOUNT);
                            GlobalMembers.ConActions.quote(66);
                            if (GlobalMembers.ConActions.ifspawnedby(FREEZEAMMO))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_SHOTGUNAMMO()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifcount(6))
                    if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            GlobalMembers.ConActions.addammo(SHOTGUN_WEAPON, SHOTGUNAMMOAMOUNT);
                            GlobalMembers.ConActions.quote(69);
                            if (GlobalMembers.ConActions.ifspawnedby(SHOTGUNAMMO))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_AMMOLOTS()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifcount(6))
                    if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            GlobalMembers.ConActions.addammo(PISTOL_WEAPON, 48);
                            GlobalMembers.ConActions.quote(65);
                            if (GlobalMembers.ConActions.ifspawnedby(AMMOLOTS))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_CRYSTALAMMO()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            GlobalMembers.ConActions.addammo(SHRINKER_WEAPON, CRYSTALAMMOAMOUNT);
                            GlobalMembers.ConActions.quote(78);
                            if (GlobalMembers.ConActions.ifspawnedby(CRYSTALAMMO))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_GROWAMMO()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            GlobalMembers.ConActions.addammo(GROW_WEAPON, GROWCRYSTALAMMOAMOUNT);
                            GlobalMembers.ConActions.quote(123);
                            if (GlobalMembers.ConActions.ifspawnedby(GROWAMMO))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_BATTERYAMMO()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            GlobalMembers.ConActions.addammo(CHAINGUN_WEAPON, CHAINGUNAMMOAMOUNT);
                            GlobalMembers.ConActions.quote(63);
                            if (GlobalMembers.ConActions.ifspawnedby(BATTERYAMMO))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_DEVISTATORAMMO()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            GlobalMembers.ConActions.addammo(DEVISTATOR_WEAPON, DEVISTATORAMMOAMOUNT);
                            GlobalMembers.ConActions.quote(14);
                            if (GlobalMembers.ConActions.ifspawnedby(DEVISTATORAMMO))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_RPGAMMO()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            GlobalMembers.ConActions.addammo(RPG_WEAPON, RPGAMMOBOX);
                            GlobalMembers.ConActions.quote(64);
                            if (GlobalMembers.ConActions.ifspawnedby(RPGAMMO))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_HBOMBAMMO()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            if (GlobalMembers.ConActions.ifgotweaponce(0))
                                return;
                            GlobalMembers.ConActions.addweapon(HANDBOMB_WEAPON, HANDBOMBBOX);
                            GlobalMembers.ConActions.quote(55);
                            if (GlobalMembers.ConActions.ifspawnedby(HBOMBAMMO))
                                getweaponcode();
                            else
                                quikweaponget();
                        }
    }
    private void A_RPGSPRITE()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            if (GlobalMembers.ConActions.ifgotweaponce(0))
                                return;
                            GlobalMembers.ConActions.addweapon(RPG_WEAPON, RPGAMMOBOX);
                            GlobalMembers.ConActions.quote(56);
                            if (GlobalMembers.ConActions.ifspawnedby(RPGSPRITE))
                                getweaponcode();
                            else
                                quikweaponget();
                        }
    }
    private void A_SHOTGUNSPRITE()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            if (GlobalMembers.ConActions.ifspawnedby(PIGCOP))
                            {
                                GlobalMembers.ConActions.addweapon(SHOTGUN_WEAPON, 0);
                                if (GlobalMembers.ConActions.ifrnd(64))
                                    GlobalMembers.ConActions.addammo(SHOTGUN_WEAPON, 4);
                                else
                                if (GlobalMembers.ConActions.ifrnd(64))
                                    GlobalMembers.ConActions.addammo(SHOTGUN_WEAPON, 3);
                                else
                                if (GlobalMembers.ConActions.ifrnd(64))
                                    GlobalMembers.ConActions.addammo(SHOTGUN_WEAPON, 2);
                                else
                                    GlobalMembers.ConActions.addammo(SHOTGUN_WEAPON, 1);
                            }
                            else
                            {
                                if (GlobalMembers.ConActions.ifgotweaponce(0))
                                    return;
                                GlobalMembers.ConActions.addweapon(SHOTGUN_WEAPON, SHOTGUNAMMOAMOUNT);
                                GlobalMembers.ConActions.quote(57);
                            }
                            if (GlobalMembers.ConActions.ifspawnedby(SHOTGUNSPRITE))
                                getweaponcode();
                            else
                                quikweaponget();
                        }
    }
    private void A_SIXPAK()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifphealthl(MAXPLAYERHEALTH))
                            if (GlobalMembers.ConActions.ifcanseetarget())
                            {
                                GlobalMembers.ConActions.addphealth(30);
                                GlobalMembers.ConActions.quote(62);
                                if (GlobalMembers.ConActions.ifspawnedby(SIXPAK))
                                    getcode();
                                else
                                    quikget();
                            }
    }
    private void A_COLA()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifphealthl(MAXPLAYERHEALTH))
                            if (GlobalMembers.ConActions.ifcanseetarget())
                            {
                                GlobalMembers.ConActions.addphealth(10);
                                GlobalMembers.ConActions.quote(61);
                                if (GlobalMembers.ConActions.ifspawnedby(COLA))
                                    getcode();
                                else
                                    quikget();
                            }
    }
    private void A_ATOMICHEALTH()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifphealthl(MAXPLAYERATOMICHEALTH))
                            if (GlobalMembers.ConActions.ifcanseetarget())
                            {
                                GlobalMembers.ConActions.addphealth(50);
                                GlobalMembers.ConActions.quote(19);
                                if (GlobalMembers.ConActions.ifspawnedby(ATOMICHEALTH))
                                    getcode();
                                else
                                    quikget();
                            }
    }
    private void A_FIRSTAID()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifwasweapon(GET_FIRSTAID, FIRSTAID_AMOUNT))
                            if (GlobalMembers.ConActions.ifcanseetarget())
                            {
                                GlobalMembers.ConActions.addinventory(GET_FIRSTAID, FIRSTAID_AMOUNT);
                                GlobalMembers.ConActions.quote(3);
                                if (GlobalMembers.ConActions.ifspawnedby(FIRSTAID))
                                    getcode();
                                else
                                    quikget();
                            }
    }
    private void A_FIRSTGUNSPRITE()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            if (GlobalMembers.ConActions.ifgotweaponce(0))
                                return;
                            GlobalMembers.ConActions.addweapon(PISTOL_WEAPON, 48);
                            if (GlobalMembers.ConActions.ifspawnedby(FIRSTGUNSPRITE))
                                getweaponcode();
                            else
                                quikweaponget();
                        }
    }
    private void A_TRIPBOMBSPRITE()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            if (GlobalMembers.ConActions.ifgotweaponce(0))
                                return;
                            GlobalMembers.ConActions.addweapon(TRIPBOMB_WEAPON, 1);
                            GlobalMembers.ConActions.quote(58);
                            if (GlobalMembers.ConActions.ifspawnedby(TRIPBOMBSPRITE))
                                getweaponcode();
                            else
                                quikweaponget();
                        }
    }
    private void A_CHAINGUNSPRITE()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            if (GlobalMembers.ConActions.ifgotweaponce(0))
                                return;
                            GlobalMembers.ConActions.addweapon(CHAINGUN_WEAPON, 50);
                            GlobalMembers.ConActions.quote(54);
                            if (GlobalMembers.ConActions.ifspawnedby(CHAINGUNSPRITE))
                                getweaponcode();
                            else
                                quikweaponget();
                        }
    }
    private void A_SHRINKERSPRITE()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            if (GlobalMembers.ConActions.ifgotweaponce(0))
                                return;
                            GlobalMembers.ConActions.addweapon(SHRINKER_WEAPON, 10);
                            GlobalMembers.ConActions.quote(60);
                            if (GlobalMembers.ConActions.ifspawnedby(SHRINKERSPRITE))
                                getweaponcode();
                            else
                                quikweaponget();
                        }
    }
    private void A_FREEZESPRITE()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            if (GlobalMembers.ConActions.ifgotweaponce(0))
                                return;
                            GlobalMembers.ConActions.addweapon(FREEZE_WEAPON, FREEZEAMMOAMOUNT);
                            GlobalMembers.ConActions.quote(59);
                            if (GlobalMembers.ConActions.ifspawnedby(FREEZESPRITE))
                                getweaponcode();
                            else
                                quikweaponget();
                        }
    }
    private void A_DEVISTATORSPRITE()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (GlobalMembers.ConActions.ifp(pshrunk, nullop))
else
    if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
                    if (GlobalMembers.ConActions.ifcount(6))
                        if (GlobalMembers.ConActions.ifcanseetarget())
                        {
                            if (GlobalMembers.ConActions.ifgotweaponce(0))
                                return;
                            GlobalMembers.ConActions.addweapon(DEVISTATOR_WEAPON, DEVISTATORAMMOAMOUNT);
                            GlobalMembers.ConActions.quote(87);
                            if (GlobalMembers.ConActions.ifspawnedby(DEVISTATORSPRITE))
                                getweaponcode();
                            else
                                quikweaponget();
                        }
    }
    GlobalMembers.ConActions.ConAction FIRE_FRAMES = new GlobalMembers.ConActions.ConAction(-1, 14, 1, 1, 1);
    GlobalMembers.ConActions.MoveAction FIREVELS = new GlobalMembers.ConActions.MoveAction();
    private void firestate()
    {
        if (GlobalMembers.ConActions.ifaction(0))
            if (GlobalMembers.ConActions.ifrnd(16))
            {
                GlobalMembers.ConActions.ConAction FIRE_FRAMES = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.cstator(128);
            }
        GlobalMembers.ConActions.sleeptime(300);
        if (GlobalMembers.ConActions.ifspawnedby(FIRE))
        {
            if (GlobalMembers.ConActions.ifgapzl(16))
                return;
        }
        else
        if (GlobalMembers.ConActions.ifspawnedby(FIRE2))
        {
            if (GlobalMembers.ConActions.ifgapzl(16))
                return;
        }
        if (GlobalMembers.ConActions.ifinwater())
            GlobalMembers.ConActions.killit();
        if (GlobalMembers.ConActions.ifp(palive))
            if (GlobalMembers.ConActions.ifpdistl(844))
                if (GlobalMembers.ConActions.ifrnd(32))
                    if (GlobalMembers.ConActions.ifcansee())
                    {
                        GlobalMembers.ConActions.soundonce(DUKE_LONGTERM_PAIN);
                        GlobalMembers.ConActions.addphealth(-1);
                        GlobalMembers.ConActions.palfrom(32, 32);
                    }
        if (GlobalMembers.ConActions.ifactor(FIRE))
        {
            if (GlobalMembers.ConActions.ifspawnedby(FIRE))
                return;
        }
        else
        if (GlobalMembers.ConActions.ifactor(FIRE2))
            if (GlobalMembers.ConActions.ifspawnedby(FIRE2))
                return;
        if (GlobalMembers.ConActions.iffloordistl(128))
        {
            if (GlobalMembers.ConActions.ifrnd(128))
            {
                if (GlobalMembers.ConActions.ifcount(84))
                    GlobalMembers.ConActions.killit();
                else
                if (GlobalMembers.ConActions.ifcount(42))
                    GlobalMembers.ConActions.sizeto(0, 0);
                else
                    GlobalMembers.ConActions.sizeto(32, 32);
            }
        }
        else
            GlobalMembers.ConActions.killit();
    }
    private void A_notenemy()
    {
        firestate();
    }
    private void A_notenemy()
    {
        firestate();
    }
    private void A_FECES()
    {
        if (GlobalMembers.ConActions.ifcount(24))
        {
            if (GlobalMembers.ConActions.ifpdistl(RETRIEVEDISTANCE))
            {
                if (GlobalMembers.ConActions.ifrnd(SWEARFREQUENCY))
                    GlobalMembers.ConActions.soundonce(DUKE_STEPONFECES);
                GlobalMembers.ConActions.sound(STEPNIT);
                GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.killit();
            }
        }
        else
            GlobalMembers.ConActions.sizeto(32, 32);
    }
    private void drop_ammo()
    {
        if (GlobalMembers.ConActions.ifrnd(SPAWNAMMOODDS))
            GlobalMembers.ConActions.spawn(AMMO);
    }
    private void drop_battery()
    {
        if (GlobalMembers.ConActions.ifrnd(SPAWNAMMOODDS))
            GlobalMembers.ConActions.spawn(BATTERYAMMO);
    }
    private void drop_sgshells()
    {
        if (GlobalMembers.ConActions.ifrnd(SPAWNAMMOODDS))
            GlobalMembers.ConActions.spawn(SHOTGUNAMMO);
    }
    private void drop_shotgun()
    {
        if (GlobalMembers.ConActions.ifrnd(SPAWNAMMOODDS))
            GlobalMembers.ConActions.spawn(SHOTGUNSPRITE);
    }
    private void drop_chaingun()
    {
        if (GlobalMembers.ConActions.ifrnd(SPAWNAMMOODDS))
        {
            if (GlobalMembers.ConActions.ifrnd(32))
                GlobalMembers.ConActions.spawn(CHAINGUNSPRITE);
            else
                GlobalMembers.ConActions.spawn(BATTERYAMMO);
        }
    }
    private void random_wall_jibs()
    {
        if (GlobalMembers.ConActions.ifrnd(96))
            GlobalMembers.ConActions.shoot(BLOODSPLAT1);
        if (GlobalMembers.ConActions.ifrnd(96))
            GlobalMembers.ConActions.shoot(BLOODSPLAT2);
        if (GlobalMembers.ConActions.ifrnd(96))
            GlobalMembers.ConActions.shoot(BLOODSPLAT3);
        if (GlobalMembers.ConActions.ifrnd(96))
            GlobalMembers.ConActions.shoot(BLOODSPLAT4);
        if (GlobalMembers.ConActions.ifrnd(96))
            GlobalMembers.ConActions.shoot(BLOODSPLAT1);
    }
    GlobalMembers.ConActions.ConAction FEMSHRUNK = new GlobalMembers.ConActions.ConAction();
    GlobalMembers.ConActions.ConAction FEMFROZEN1 = new GlobalMembers.ConActions.ConAction(1);
    GlobalMembers.ConActions.ConAction FEMGROW = new GlobalMembers.ConActions.ConAction();
    GlobalMembers.ConActions.ConAction FEMFROZEN2 = new GlobalMembers.ConActions.ConAction();
    GlobalMembers.ConActions.ConAction FEMDANCE1 = new GlobalMembers.ConActions.ConAction(19, 1, 1, 1, 16);
    GlobalMembers.ConActions.ConAction FEMDANCE3 = new GlobalMembers.ConActions.ConAction(19, 1, 1, 1, 26);
    GlobalMembers.ConActions.ConAction FEMDANCE2 = new GlobalMembers.ConActions.ConAction(20, 2, 1, 1, 10);
    GlobalMembers.ConActions.ConAction FEMANIMATESLOW = new GlobalMembers.ConActions.ConAction(0, 2, 1, 1, 100);
    GlobalMembers.ConActions.ConAction TOUGHGALANIM = new GlobalMembers.ConActions.ConAction(0, 5, 1, 1, 25);
    GlobalMembers.ConActions.ConAction FEMANIMATE = new GlobalMembers.ConActions.ConAction();
    private void femcode()
    {
        if (GlobalMembers.ConActions.ifactor(NAKED1))
// nullop
else
    if (GlobalMembers.ConActions.ifactor(FEM6))
// nullop
else
                        {
                            GlobalMembers.ConActions.fall();
                            if (GlobalMembers.ConActions.ifactor(BLOODYPOLE))
                                if (GlobalMembers.ConActions.ifhitweapon())
                                    if (GlobalMembers.ConActions.ifdead())
                                    {
                                        standard_jibs();
                                        GlobalMembers.ConActions.killit();
                                    }
                        }
        if (GlobalMembers.ConActions.ifaction(FEMSHRUNK))
        {
            if (GlobalMembers.ConActions.ifcount(SHRUNKDONECOUNT))
            {
                GlobalMembers.ConActions.ConAction FEMANIMATE = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.cstat(257);
            }
            else
            if (GlobalMembers.ConActions.ifcount(SHRUNKCOUNT))
                GlobalMembers.ConActions.sizeto(40, 40);
            else
                genericshrunkcode();
        }
        else
        if (GlobalMembers.ConActions.ifaction(FEMGROW))
        {
            if (GlobalMembers.ConActions.ifcount(32))
            {
                GlobalMembers.ConActions.respawnhitag();
                GlobalMembers.ConActions.guts(JIBS4, 20);
                GlobalMembers.ConActions.guts(JIBS6, 20);
                GlobalMembers.ConActions.spritepal(6);
                GlobalMembers.ConActions.soundonce(LADY_SCREAM);
                if (GlobalMembers.ConActions.ifactor(NAKED1))
                    GlobalMembers.ConActions.debris(SCRAP3, 4);
                else
                if (GlobalMembers.ConActions.ifactor(PODFEM1))
                    GlobalMembers.ConActions.debris(SCRAP3, 4);
                GlobalMembers.ConActions.sound(SQUISHED);
                GlobalMembers.ConActions.killit();
            }
            else
                GlobalMembers.ConActions.sizeto(MAXXSTRETCH, MAXYSTRETCH);
        }
        else
        if (GlobalMembers.ConActions.ifaction(FEMDANCE1))
        {
            if (GlobalMembers.ConActions.ifactioncount(2))
                GlobalMembers.ConActions.ConAction FEMDANCE2 = new GlobalMembers.ConActions.ConAction();
        }
        else
        if (GlobalMembers.ConActions.ifaction(FEMDANCE2))
        {
            if (GlobalMembers.ConActions.ifactioncount(8))
                GlobalMembers.ConActions.ConAction FEMDANCE3 = new GlobalMembers.ConActions.ConAction();
        }
        else
        if (GlobalMembers.ConActions.ifaction(FEMDANCE3))
        {
            if (GlobalMembers.ConActions.ifactioncount(2))
                GlobalMembers.ConActions.ConAction FEMANIMATE = new GlobalMembers.ConActions.ConAction();
        }
        else
        if (GlobalMembers.ConActions.ifaction(FEMFROZEN1))
        {
            if (GlobalMembers.ConActions.ifcount(THAWTIME))
            {
                GlobalMembers.ConActions.ConAction FEMANIMATE = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.getlastpal();
            }
            else
            if (GlobalMembers.ConActions.ifcount(FROZENDRIPTIME))
            {
                if (GlobalMembers.ConActions.ifactioncount(26))
                {
                    GlobalMembers.ConActions.spawn(WATERDRIP);
                    GlobalMembers.ConActions.resetactioncount();
                }
            }
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                GlobalMembers.ConActions.lotsofglass(30);
                GlobalMembers.ConActions.sound(GLASS_BREAKING);
                GlobalMembers.ConActions.respawnhitag();
                if (GlobalMembers.ConActions.ifrnd(84))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.killit();
            }
            else
                if (GlobalMembers.ConActions.ifp(pfacing))
                if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                    GlobalMembers.ConActions.pkick();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifaction(FEMFROZEN2))
        {
            if (GlobalMembers.ConActions.ifcount(THAWTIME))
            {
                if (GlobalMembers.ConActions.ifactor(TOUGHGAL))
                    GlobalMembers.ConActions.ConAction TOUGHGALANIM = new GlobalMembers.ConActions.ConAction();
                else
                if (GlobalMembers.ConActions.ifactor(FEM10))
                    GlobalMembers.ConActions.ConAction FEMANIMATESLOW = new GlobalMembers.ConActions.ConAction();
                else
                    GlobalMembers.ConActions.ConAction FEMANIMATE = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.getlastpal();
            }
            else
            if (GlobalMembers.ConActions.ifcount(FROZENDRIPTIME))
            {
                if (GlobalMembers.ConActions.ifactioncount(26))
                {
                    GlobalMembers.ConActions.spawn(WATERDRIP);
                    GlobalMembers.ConActions.resetactioncount();
                }
            }
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                GlobalMembers.ConActions.lotsofglass(30);
                GlobalMembers.ConActions.sound(GLASS_BREAKING);
                if (GlobalMembers.ConActions.ifrnd(84))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.respawnhitag();
                if (GlobalMembers.ConActions.ifrnd(128))
                    GlobalMembers.ConActions.sound(DUKE_HIT_STRIPPER1);
                else
                    GlobalMembers.ConActions.sound(DUKE_HIT_STRIPPER2);
                GlobalMembers.ConActions.killit();
            }
            else
                if (GlobalMembers.ConActions.ifp(pfacing))
                if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                    GlobalMembers.ConActions.pkick();
            return;
        }
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                {
                    GlobalMembers.ConActions.cstat(0);
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.sound(ACTOR_GROWING);
                    GlobalMembers.ConActions.ConAction FEMGROW = new GlobalMembers.ConActions.ConAction();
                    return;
                }
                else
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    if (GlobalMembers.ConActions.ifaction(FEMSHRUNK))
                        return;
                    if (GlobalMembers.ConActions.ifactor(NAKED1))
                        GlobalMembers.ConActions.ConAction FEMFROZEN2 = new GlobalMembers.ConActions.ConAction();
                    else
                    if (GlobalMembers.ConActions.ifactor(FEM5))
                        GlobalMembers.ConActions.ConAction FEMFROZEN2 = new GlobalMembers.ConActions.ConAction();
                    else
                    if (GlobalMembers.ConActions.ifactor(FEM6))
                        GlobalMembers.ConActions.ConAction FEMFROZEN2 = new GlobalMembers.ConActions.ConAction();
                    else
                    if (GlobalMembers.ConActions.ifactor(FEM8))
                        GlobalMembers.ConActions.ConAction FEMFROZEN2 = new GlobalMembers.ConActions.ConAction();
                    else
                    if (GlobalMembers.ConActions.ifactor(FEM9))
                        GlobalMembers.ConActions.ConAction FEMFROZEN2 = new GlobalMembers.ConActions.ConAction();
                    else
                    if (GlobalMembers.ConActions.ifactor(FEM10))
                        GlobalMembers.ConActions.ConAction FEMFROZEN2 = new GlobalMembers.ConActions.ConAction();
                    else
                    if (GlobalMembers.ConActions.ifactor(TOUGHGAL))
                        GlobalMembers.ConActions.ConAction FEMFROZEN2 = new GlobalMembers.ConActions.ConAction();
                    else
                    if (GlobalMembers.ConActions.ifactor(PODFEM1))
                        GlobalMembers.ConActions.ConAction FEMFROZEN2 = new GlobalMembers.ConActions.ConAction();
                    else
                        GlobalMembers.ConActions.ConAction FEMFROZEN1 = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.spritepal(1);
                    GlobalMembers.ConActions.strength(0);
                    GlobalMembers.ConActions.sound(SOMETHINGFROZE);
                    return;
                }
                if (GlobalMembers.ConActions.ifrnd(128))
                    GlobalMembers.ConActions.sound(DUKE_HIT_STRIPPER1);
                else
                    GlobalMembers.ConActions.sound(DUKE_HIT_STRIPPER2);
                GlobalMembers.ConActions.respawnhitag();
                standard_jibs();
                random_wall_jibs();
                GlobalMembers.ConActions.spawn(BLOODPOOL);
                if (GlobalMembers.ConActions.ifactor(FEM1))
                    GlobalMembers.ConActions.money(5);
                else
                if (GlobalMembers.ConActions.ifactor(FEM2))
                {
                    GlobalMembers.ConActions.money(7);
                    GlobalMembers.ConActions.cactor(BARBROKE);
                    GlobalMembers.ConActions.cstat(0);
                }
                else
                if (GlobalMembers.ConActions.ifactor(FEM3))
                    GlobalMembers.ConActions.money(4);
                else
                if (GlobalMembers.ConActions.ifactor(FEM7))
                    GlobalMembers.ConActions.money(8);
                if (GlobalMembers.ConActions.ifactor(FEM5))
                {
                    GlobalMembers.ConActions.strength(TOUGH);
                    GlobalMembers.ConActions.cactor(BLOODYPOLE);
                }
                else
                if (GlobalMembers.ConActions.ifactor(FEM6))
                {
                    GlobalMembers.ConActions.cstat(0);
                    GlobalMembers.ConActions.cactor(FEM6PAD);
                }
                else
                if (GlobalMembers.ConActions.ifactor(FEM8))
                {
                    GlobalMembers.ConActions.strength(TOUGH);
                    GlobalMembers.ConActions.cactor(BLOODYPOLE);
                }
                else
                {
                    GlobalMembers.ConActions.spritepal(6);
                    GlobalMembers.ConActions.soundonce(LADY_SCREAM);
                    if (GlobalMembers.ConActions.ifactor(NAKED1))
                        GlobalMembers.ConActions.debris(SCRAP3, 18);
                    else
                    if (GlobalMembers.ConActions.ifactor(PODFEM1))
                        GlobalMembers.ConActions.debris(SCRAP3, 18);
                    GlobalMembers.ConActions.killit();
                }
            }
            else
            {
                if (GlobalMembers.ConActions.ifwasweapon(SHRINKSPARK))
                {
                    GlobalMembers.ConActions.sound(ACTOR_SHRINKING);
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.ConAction FEMSHRUNK = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.cstat(0);
                    return;
                }
                else
                if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                    GlobalMembers.ConActions.sound(EXPANDERHIT);
                if (GlobalMembers.ConActions.ifactor(FEM8))
                    return;
                if (GlobalMembers.ConActions.ifactor(TOUGHGAL))
                    toughgalspeech();
                else
                    GlobalMembers.ConActions.sound(SQUISHED);
                GlobalMembers.ConActions.guts(JIBS6, 1);
            }
        }
    }
    private void killme()
    {
        if (GlobalMembers.ConActions.ifinwater())
// nullop
else
    if (GlobalMembers.ConActions.ifp(pfacing))
                    if (GlobalMembers.ConActions.ifpdistl(1280))
                        if (GlobalMembers.ConActions.ifhitspace())
                            GlobalMembers.ConActions.soundonce(KILLME);
    }
    private void tipme()
    {
        if (GlobalMembers.ConActions.ifp(pfacing))
            if (GlobalMembers.ConActions.ifpdistl(1280))
                if (GlobalMembers.ConActions.ifhitspace())
                {
                    GlobalMembers.ConActions.tip();
                    if (GlobalMembers.ConActions.ifrnd(128))
                        GlobalMembers.ConActions.soundonce(DUKE_TIP1);
                    else
                        GlobalMembers.ConActions.soundonce(DUKE_TIP2);
                    if (GlobalMembers.ConActions.ifactor(FEM1))
                        GlobalMembers.ConActions.ConAction FEMDANCE1 = new GlobalMembers.ConActions.ConAction();
                }
    }
    private void toughgaltalk()
    {
        if (GlobalMembers.ConActions.ifp(pfacing))
            if (GlobalMembers.ConActions.ifpdistl(1280))
                if (GlobalMembers.ConActions.ifhitspace())
                    toughgalspeech();
    }
    private void A_FEM1()
    {
        tipme();
        femcode();
    }
    private void A_FEM2()
    {
        tipme();
        femcode();
    }
    private void A_FEM3()
    {
        tipme();
        femcode();
    }
    private void A_FEM4()
    {
        femcode();
    }
    private void A_FEM5()
    {
        killme();
        femcode();
    }
    private void A_FEM6()
    {
        killme();
        femcode();
    }
    private void A_FEM7()
    {
        tipme();
        femcode();
    }
    private void A_FEM8()
    {
        femcode();
    }
    private void A_FEM9()
    {
        femcode();
    }
    private void A_FEM10()
    {
        tipme();
        femcode();
    }
    private void A_TOUGHGAL()
    {
        toughgaltalk();
        femcode();
    }
    private void A_NAKED1()
    {
        killme();
        femcode();
    }
    private void A_PODFEM1()
    {
        killme();
        femcode();
    }
    private void A_BLOODYPOLE()
    {
        femcode();
    }
    private void A_STATUEFLASH()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifcount(32))
            GlobalMembers.ConActions.cactor(STATUE);
    }
    private void A_STATUE()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifp(pfacing))
            if (GlobalMembers.ConActions.ifpdistl(1280))
                if (GlobalMembers.ConActions.ifhitspace())
                {
                    GlobalMembers.ConActions.cactor(STATUEFLASH);
                    GlobalMembers.ConActions.Move(0);
                }
    }
    private void A_MIKE()
    {
        if (GlobalMembers.ConActions.ifp(pfacing))
            if (GlobalMembers.ConActions.ifpdistl(1280))
                if (GlobalMembers.ConActions.ifhitspace())
                    GlobalMembers.ConActions.mikesnd();
    }
    private void troop_body_jibs()
    {
        if (GlobalMembers.ConActions.ifrnd(64))
            GlobalMembers.ConActions.guts(HEADJIB1, 1);
        if (GlobalMembers.ConActions.ifrnd(64))
            GlobalMembers.ConActions.guts(LEGJIB1, 2);
        if (GlobalMembers.ConActions.ifrnd(64))
            GlobalMembers.ConActions.guts(ARMJIB1, 1);
        if (GlobalMembers.ConActions.ifrnd(48))
            GlobalMembers.ConActions.spawn(BLOODPOOL);
    }
    private void liz_body_jibs()
    {
        if (GlobalMembers.ConActions.ifrnd(64))
            GlobalMembers.ConActions.guts(LIZMANHEAD1, 1);
        if (GlobalMembers.ConActions.ifrnd(64))
            GlobalMembers.ConActions.guts(LIZMANLEG1, 2);
        if (GlobalMembers.ConActions.ifrnd(64))
            GlobalMembers.ConActions.guts(LIZMANARM1, 1);
        if (GlobalMembers.ConActions.ifrnd(48))
            GlobalMembers.ConActions.spawn(BLOODPOOL);
    }
    GlobalMembers.ConActions.ConAction BLOODFRAMES = new GlobalMembers.ConActions.ConAction(0, 4, 1, 1, 15);
    private void A_BLOOD()
    {
        GlobalMembers.ConActions.sizeto(72, 72);
        GlobalMembers.ConActions.sizeto(72, 72);
        GlobalMembers.ConActions.sizeto(72, 72);
        if (GlobalMembers.ConActions.ifpdistg(3144))
            GlobalMembers.ConActions.killit();
        if (GlobalMembers.ConActions.ifactioncount(4))
            GlobalMembers.ConActions.killit();
    }
    GlobalMembers.ConActions.ConAction EGGOPEN1 = new GlobalMembers.ConActions.ConAction(1, 1, 1, 1, 4);
    GlobalMembers.ConActions.ConAction EGGOPEN2 = new GlobalMembers.ConActions.ConAction(2, 1, 1, 1, 4);
    GlobalMembers.ConActions.ConAction EGGOPEN3 = new GlobalMembers.ConActions.ConAction(2, 1, 1, 1, 4);
    GlobalMembers.ConActions.ConAction EGGWAIT = new GlobalMembers.ConActions.ConAction(0);
    GlobalMembers.ConActions.ConAction EGGFROZEN = new GlobalMembers.ConActions.ConAction(1);
    GlobalMembers.ConActions.ConAction EGGGROW = new GlobalMembers.ConActions.ConAction(1);
    GlobalMembers.ConActions.ConAction EGGSHRUNK = new GlobalMembers.ConActions.ConAction(1);
    private void A_EGG()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifaction(0))
        {
            if (GlobalMembers.ConActions.ifcount(64))
            {
                if (GlobalMembers.ConActions.ifrnd(128))
                {
                    GlobalMembers.ConActions.ConAction EGGWAIT = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.Move(0);
                }
                else
                {
                    GlobalMembers.ConActions.sound(SLIM_HATCH);
                    GlobalMembers.ConActions.ConAction EGGOPEN1 = new GlobalMembers.ConActions.ConAction();
                }
            }
        }
        else
        if (GlobalMembers.ConActions.ifaction(EGGOPEN1))
            if (GlobalMembers.ConActions.ifactioncount(4))
                GlobalMembers.ConActions.ConAction EGGOPEN2 = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifaction(EGGOPEN2))
                if (GlobalMembers.ConActions.ifactioncount(4))
                {
                    GlobalMembers.ConActions.spawn(GREENSLIME);
                    GlobalMembers.ConActions.ConAction EGGOPEN3 = new GlobalMembers.ConActions.ConAction();
                }
                else
                if (GlobalMembers.ConActions.ifaction(EGGGROW))
                    genericgrowcode();
                else
                if (GlobalMembers.ConActions.ifaction(EGGSHRUNK))
                    genericshrunkcode();
                else
                if (GlobalMembers.ConActions.ifaction(EGGFROZEN))
                {
                    if (GlobalMembers.ConActions.ifcount(THAWTIME))
                    {
                        GlobalMembers.ConActions.ConAction 0 = new GlobalMembers.ConActions.ConAction();
                        GlobalMembers.ConActions.getlastpal();
                    }
                    else
                    if (GlobalMembers.ConActions.ifcount(FROZENDRIPTIME))
                    {
                        if (GlobalMembers.ConActions.ifactioncount(26))
                        {
                            GlobalMembers.ConActions.spawn(WATERDRIP);
                            GlobalMembers.ConActions.resetactioncount();
                        }
                    }
                    if (GlobalMembers.ConActions.ifhitweapon())
                    {
                        if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                        {
                            GlobalMembers.ConActions.strength(0);
                            return;
                        }
                        GlobalMembers.ConActions.lotsofglass(30);
                        GlobalMembers.ConActions.sound(GLASS_BREAKING);
                        if (GlobalMembers.ConActions.ifrnd(84))
                            GlobalMembers.ConActions.spawn(BLOODPOOL);
                        GlobalMembers.ConActions.addkills(1);
                        GlobalMembers.ConActions.killit();
                    }
                    if (GlobalMembers.ConActions.ifp(pfacing))
                        if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                            GlobalMembers.ConActions.pkick();
                    return;
                }
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.sound(SOMETHINGFROZE);
                    GlobalMembers.ConActions.spritepal(1);
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.ConAction EGGFROZEN = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                else
                if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                {
                    GlobalMembers.ConActions.cstat(0);
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.sound(ACTOR_GROWING);
                    GlobalMembers.ConActions.ConAction EGGGROW = new GlobalMembers.ConActions.ConAction();
                    return;
                }
                GlobalMembers.ConActions.addkills(1);
                GlobalMembers.ConActions.sound(SQUISHED);
                standard_jibs();
                GlobalMembers.ConActions.killit();
            }
            else
            if (GlobalMembers.ConActions.ifwasweapon(SHRINKSPARK))
            {
                GlobalMembers.ConActions.Move(0);
                GlobalMembers.ConActions.sound(ACTOR_SHRINKING);
                GlobalMembers.ConActions.ConAction EGGSHRUNK = new GlobalMembers.ConActions.ConAction();
                return;
            }
            if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                GlobalMembers.ConActions.sound(EXPANDERHIT);
        }
        else
            if (GlobalMembers.ConActions.ifaction(EGGWAIT))
        {
            if (GlobalMembers.ConActions.ifcount(512))
                if (GlobalMembers.ConActions.ifrnd(2))
                {
                    if (GlobalMembers.ConActions.ifaction(EGGSHRUNK))
                        return;
                    GlobalMembers.ConActions.sound(SLIM_HATCH);
                    GlobalMembers.ConActions.ConAction EGGOPEN1 = new GlobalMembers.ConActions.ConAction();
                }
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
        if (GlobalMembers.ConActions.ifcount(18))
            GlobalMembers.ConActions.killit();
        else
        if (GlobalMembers.ConActions.ifcount(9))
        {
            GlobalMembers.ConActions.sizeto(0, 0);
            GlobalMembers.ConActions.sizeto(0, 0);
            GlobalMembers.ConActions.sizeto(0, 0);
            GlobalMembers.ConActions.sizeto(0, 0);
        }
        else
        {
            GlobalMembers.ConActions.sizeto(28, 28);
            GlobalMembers.ConActions.sizeto(28, 28);
            GlobalMembers.ConActions.sizeto(28, 28);
            GlobalMembers.ConActions.sizeto(28, 28);
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
    GlobalMembers.ConActions.ConAction WEAP2FRAMES = new GlobalMembers.ConActions.ConAction(0, 4, 1, 1, 6);
    private void A_SHOTSPARK1()
    {
        if (GlobalMembers.ConActions.ifdead())
            GlobalMembers.ConActions.killit();
        if (GlobalMembers.ConActions.ifactioncount(4))
            GlobalMembers.ConActions.killit();
        else
        {
            if (GlobalMembers.ConActions.ifactioncount(3))
            {
                if (GlobalMembers.ConActions.ifinwater())
                    GlobalMembers.ConActions.spawn(WATERBUBBLE);
            }
            else
            if (GlobalMembers.ConActions.ifcount(2))
// nullop
else
    if (GlobalMembers.ConActions.ifonwater())
                        GlobalMembers.ConActions.spawn(WATERSPLASH2);
        }
    }
    private void standard_pjibs()
    {
        GlobalMembers.ConActions.guts(JIBS1, 1);
        GlobalMembers.ConActions.guts(JIBS3, 2);
        GlobalMembers.ConActions.guts(JIBS4, 1);
        GlobalMembers.ConActions.guts(JIBS5, 1);
        GlobalMembers.ConActions.guts(JIBS6, 2);
        GlobalMembers.ConActions.guts(DUKETORSO, 1);
        GlobalMembers.ConActions.guts(DUKELEG, 2);
        GlobalMembers.ConActions.guts(DUKEGUN, 1);
        if (GlobalMembers.ConActions.ifrnd(16))
            GlobalMembers.ConActions.money(1);
    }
    GlobalMembers.ConActions.MoveAction DUKENOTMOVING = new GlobalMembers.ConActions.MoveAction();
    private void handle_dead_dukes()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifmove(0))
        {
            if (GlobalMembers.ConActions.ifrnd(128))
                GlobalMembers.ConActions.cstat(4);
            else
                GlobalMembers.ConActions.cstat(0);
            GlobalMembers.ConActions.Move(DUKENOTMOVING);
        }
        if (GlobalMembers.ConActions.ifsquished())
        {
            GlobalMembers.ConActions.sound(SQUISHED);
            random_ooz();
            GlobalMembers.ConActions.killit();
        }
        else
        if (GlobalMembers.ConActions.ifcount(1024))
            if (GlobalMembers.ConActions.ifpdistg(4096))
                GlobalMembers.ConActions.killit();
            else
            {
                GlobalMembers.ConActions.strength(0);
                if (GlobalMembers.ConActions.ifhitweapon())
                    if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                    {
                        standard_jibs();
                        GlobalMembers.ConActions.killit();
                    }
            }
    }
    GlobalMembers.ConActions.ConAction PLYINGFRAMES = new GlobalMembers.ConActions.ConAction(0, 1, 0, 1, 1);
    private void A_DUKELYINGDEAD()
    {
        handle_dead_dukes();
    }
    GlobalMembers.ConActions.ConAction PGROWING = new GlobalMembers.ConActions.ConAction(0);
    GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction(0, 1, 5, 1, 1);
    GlobalMembers.ConActions.ConAction PEXPLODE = new GlobalMembers.ConActions.ConAction(106, 5, 1, 1, 10);
    GlobalMembers.ConActions.ConAction PEXPLODEAD = new GlobalMembers.ConActions.ConAction(113, 1, 1);
    GlobalMembers.ConActions.ConAction PJPHOUVER = new GlobalMembers.ConActions.ConAction(15, 1, 5, 1);
    GlobalMembers.ConActions.ConAction PWALK = new GlobalMembers.ConActions.ConAction(20, 4, 5, 1, 16);
    GlobalMembers.ConActions.ConAction PRUN = new GlobalMembers.ConActions.ConAction(20, 4, 5, 1, 10);
    GlobalMembers.ConActions.ConAction PWALKBACK = new GlobalMembers.ConActions.ConAction(45, 4, 5, -1, 16);
    GlobalMembers.ConActions.ConAction PRUNBACK = new GlobalMembers.ConActions.ConAction(45, 4, 5, -1, 10);
    GlobalMembers.ConActions.ConAction PJUMPING = new GlobalMembers.ConActions.ConAction(50, 4, 5, 1, 30);
    GlobalMembers.ConActions.ConAction PFALLING = new GlobalMembers.ConActions.ConAction(65, 1, 5);
    GlobalMembers.ConActions.ConAction PDUCKING = new GlobalMembers.ConActions.ConAction(86, 1, 5);
    GlobalMembers.ConActions.ConAction PCRAWLING = new GlobalMembers.ConActions.ConAction(86, 3, 5, 1, 20);
    GlobalMembers.ConActions.ConAction PAKICKING = new GlobalMembers.ConActions.ConAction(40, 2, 5, 1, 25);
    GlobalMembers.ConActions.ConAction PFLINTCHING = new GlobalMembers.ConActions.ConAction(106, 1, 1, 1, 10);
    GlobalMembers.ConActions.ConAction PTHROWNBACK = new GlobalMembers.ConActions.ConAction(106, 5, 1, 1, 18);
    GlobalMembers.ConActions.ConAction PFROZEN = new GlobalMembers.ConActions.ConAction(20, 1, 5);
    GlobalMembers.ConActions.ConAction PLYINGDEAD = new GlobalMembers.ConActions.ConAction(113, 1, 1);
    GlobalMembers.ConActions.ConAction PSWIMMINGGO = new GlobalMembers.ConActions.ConAction(375, 1, 5, 1, 10);
    GlobalMembers.ConActions.ConAction PSWIMMING = new GlobalMembers.ConActions.ConAction(375, 4, 5, 1, 13);
    GlobalMembers.ConActions.ConAction PSWIMMINGWAIT = new GlobalMembers.ConActions.ConAction(395, 1, 5, 1, 13);
    GlobalMembers.ConActions.ConAction PTREDWATER = new GlobalMembers.ConActions.ConAction(395, 2, 5, 1, 17);
    GlobalMembers.ConActions.MoveAction PSTOPED = new GlobalMembers.ConActions.MoveAction();
    GlobalMembers.ConActions.MoveAction PSHRINKING = new GlobalMembers.ConActions.MoveAction();
    private void check_pstandard()
    {
        if (GlobalMembers.ConActions.ifp(pwalking))
            GlobalMembers.ConActions.ConAction PWALK = new GlobalMembers.ConActions.ConAction();
        else
        if (GlobalMembers.ConActions.ifp(pkicking))
            GlobalMembers.ConActions.ConAction PAKICKING = new GlobalMembers.ConActions.ConAction();
        else
        if (GlobalMembers.ConActions.ifp(pwalkingback))
            GlobalMembers.ConActions.ConAction PWALKBACK = new GlobalMembers.ConActions.ConAction();
        else
        if (GlobalMembers.ConActions.ifp(prunning))
            GlobalMembers.ConActions.ConAction PRUN = new GlobalMembers.ConActions.ConAction();
        else
        if (GlobalMembers.ConActions.ifp(prunningback))
            GlobalMembers.ConActions.ConAction PRUNBACK = new GlobalMembers.ConActions.ConAction();
        else
        if (GlobalMembers.ConActions.ifp(pjumping))
            GlobalMembers.ConActions.ConAction PJUMPING = new GlobalMembers.ConActions.ConAction();
        else
        if (GlobalMembers.ConActions.ifp(pducking))
            GlobalMembers.ConActions.ConAction PDUCKING = new GlobalMembers.ConActions.ConAction();
    }
    GlobalMembers.ConActions.MoveAction PGROWINGPOP = new GlobalMembers.ConActions.MoveAction();
    private void A_APLAYER()
    {
        if (GlobalMembers.ConActions.ifaction(0))
            GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
        if (GlobalMembers.ConActions.ifaction(PFROZEN))
        {
            GlobalMembers.ConActions.cstat(257);
            GlobalMembers.ConActions.fall();
            GlobalMembers.ConActions.palfrom(16, 0, 0, 24);
            if (GlobalMembers.ConActions.ifmove(0))
            {
                if (GlobalMembers.ConActions.ifhitweapon())
                {
                    if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                        return;
                    GlobalMembers.ConActions.lotsofglass(60);
                    if (GlobalMembers.ConActions.ifrnd(84))
                        GlobalMembers.ConActions.spawn(BLOODPOOL);
                    GlobalMembers.ConActions.sound(GLASS_BREAKING);
                    GlobalMembers.ConActions.spawn(ATOMICHEALTH);
                    GlobalMembers.ConActions.getlastpal();
                    GlobalMembers.ConActions.Move(1);
                    return;
                }
            }
            else
            {
                GlobalMembers.ConActions.cstat(32768);
                GlobalMembers.ConActions.quote(13);
                if (GlobalMembers.ConActions.ifhitspace())
                {
                    GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.resetplayer();
                }
                return;
            }
            if (GlobalMembers.ConActions.ifactioncount(THAWTIME))
            {
                GlobalMembers.ConActions.getlastpal();
                GlobalMembers.ConActions.strength(1);
                GlobalMembers.ConActions.Move(0);
                GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
            }
            else
            if (GlobalMembers.ConActions.ifactioncount(FROZENDRIPTIME))
            {
                if (GlobalMembers.ConActions.ifrnd(32))
                    GlobalMembers.ConActions.spawn(WATERDRIP);
            }
            if (GlobalMembers.ConActions.ifp(pfacing))
                if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                    GlobalMembers.ConActions.pkick();
            return;
        }
        if (GlobalMembers.ConActions.ifdead())
        {
            if (GlobalMembers.ConActions.ifaction(PGROWING))
            {
                if (GlobalMembers.ConActions.ifmove(PGROWINGPOP))
                {
                    GlobalMembers.ConActions.quote(13);
                    if (GlobalMembers.ConActions.ifhitspace())
                    {
                        GlobalMembers.ConActions.ConAction 0 = new GlobalMembers.ConActions.ConAction();
                        GlobalMembers.ConActions.resetplayer();
                    }
                    return;
                }
                else
                {
                    if (GlobalMembers.ConActions.ifcount(32))
                    {
                        GlobalMembers.ConActions.sound(SQUISHED);
                        GlobalMembers.ConActions.palfrom(48, 64);
                        standard_pjibs();
                        GlobalMembers.ConActions.guts(JIBS4, 20);
                        GlobalMembers.ConActions.guts(JIBS6, 20);
                        GlobalMembers.ConActions.Move(PGROWINGPOP);
                        GlobalMembers.ConActions.cstat(32768);
                        GlobalMembers.ConActions.tossweapon();
                        GlobalMembers.ConActions.hitradius(2048, 60, 70, 80, 90);
                    }
                    else
                        GlobalMembers.ConActions.sizeto(MAXXSTRETCH, MAXYSTRETCH);
                }
                return;
            }
            if (GlobalMembers.ConActions.ifsquished())
                GlobalMembers.ConActions.palfrom(32, 63, 63, 63);
            else
                GlobalMembers.ConActions.fall();
            if (GlobalMembers.ConActions.ifactioncount(7))
                GlobalMembers.ConActions.Move(0);
            else
            if (GlobalMembers.ConActions.ifactioncount(6))
            {
                if (GlobalMembers.ConActions.ifmultiplayer())
// nullop
else
                        {
                            if (GlobalMembers.ConActions.ifrnd(32))
                                GlobalMembers.ConActions.sound(DUKE_KILLED5);
                            else
                            if (GlobalMembers.ConActions.ifrnd(32))
                                GlobalMembers.ConActions.sound(DUKE_KILLED3);
                            else
                            if (GlobalMembers.ConActions.ifrnd(32))
                                GlobalMembers.ConActions.sound(DUKE_KILLED1);
                            else
                            if (GlobalMembers.ConActions.ifrnd(32))
                                GlobalMembers.ConActions.sound(DUKE_KILLED2);
                        }
            }
            if (GlobalMembers.ConActions.ifaction(PLYINGDEAD))
            {
                if (GlobalMembers.ConActions.ifactioncount(3))
                    GlobalMembers.ConActions.Move(PSTOPED);
                GlobalMembers.ConActions.quote(13);
                if (GlobalMembers.ConActions.ifhitspace())
                {
                    GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.spawn(DUKELYINGDEAD);
                    GlobalMembers.ConActions.resetplayer();
                }
                return;
            }
            if (GlobalMembers.ConActions.ifaction(PTHROWNBACK))
            {
                if (GlobalMembers.ConActions.ifactioncount(5))
                {
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                    GlobalMembers.ConActions.ConAction PLYINGDEAD = new GlobalMembers.ConActions.ConAction();
                }
                else
                if (GlobalMembers.ConActions.ifactioncount(1))
                    GlobalMembers.ConActions.Move(0);
                return;
            }
            if (GlobalMembers.ConActions.ifaction(PEXPLODEAD))
            {
                GlobalMembers.ConActions.quote(13);
                if (GlobalMembers.ConActions.ifhitspace())
                {
                    GlobalMembers.ConActions.resetplayer();
                    GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
                }
                return;
            }
            if (GlobalMembers.ConActions.ifaction(PEXPLODE))
            {
                if (GlobalMembers.ConActions.ifactioncount(5))
                {
                    GlobalMembers.ConActions.ConAction PEXPLODEAD = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                }
                return;
            }
            if (GlobalMembers.ConActions.ifp(pshrunk))
            {
                standard_pjibs();
                GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.sound(SQUISHED);
                GlobalMembers.ConActions.sound(DUKE_DEAD);
                GlobalMembers.ConActions.cstat(32768);
                GlobalMembers.ConActions.ConAction PLYINGDEAD = new GlobalMembers.ConActions.ConAction();
            }
            else
            {
                if (GlobalMembers.ConActions.ifinwater())
                {
                    GlobalMembers.ConActions.ConAction PLYINGDEAD = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.spawn(WATERBUBBLE);
                    GlobalMembers.ConActions.spawn(WATERBUBBLE);
                }
                else
                {
                    GlobalMembers.ConActions.ConAction PEXPLODE = new GlobalMembers.ConActions.ConAction();
                    standard_pjibs();
                    GlobalMembers.ConActions.cstat(32768);
                    GlobalMembers.ConActions.sound(SQUISHED);
                    GlobalMembers.ConActions.sound(DUKE_DEAD);
                }
            }
            GlobalMembers.ConActions.tossweapon();
            return;
        }
        if (GlobalMembers.ConActions.ifsquished())
        {
            GlobalMembers.ConActions.strength(-1);
            GlobalMembers.ConActions.sound(SQUISHED);
            random_ooz();
            return;
        }
        if (GlobalMembers.ConActions.ifp(ponsteroids))
        {
            if (GlobalMembers.ConActions.ifp(pstanding, nullop))
else
                    GlobalMembers.ConActions.spawn(FRAMEEFFECT1);
        }
        if (GlobalMembers.ConActions.ifmove(PSHRINKING))
        {
            if (GlobalMembers.ConActions.ifcount(32))
            {
                if (GlobalMembers.ConActions.ifcount(SHRUNKDONECOUNT))
                {
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.cstat(257);
                }
                else
                if (GlobalMembers.ConActions.ifcount(SHRUNKCOUNT))
                {
                    GlobalMembers.ConActions.sizeto(42, 36);
                    if (GlobalMembers.ConActions.ifgapzl(24))
                    {
                        GlobalMembers.ConActions.strength(0);
                        GlobalMembers.ConActions.sound(SQUISHED);
                        GlobalMembers.ConActions.palfrom(48, 64);
                        return;
                    }
                }
                else
                if (GlobalMembers.ConActions.ifp(ponsteroids))
                    GlobalMembers.ConActions.count(SHRUNKCOUNT);
            }
            else
            {
                if (GlobalMembers.ConActions.ifp(ponsteroids))
                    GlobalMembers.ConActions.count(SHRUNKCOUNT);
                else
                {
                    GlobalMembers.ConActions.sizeto(8, 9);
                    GlobalMembers.ConActions.spawn(FRAMEEFFECT1);
                }
            }
        }
        else
    if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                if (GlobalMembers.ConActions.ifmultiplayer())
                    GlobalMembers.ConActions.sound(DUKE_KILLED4);
                if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                {
                    GlobalMembers.ConActions.palfrom(48, 48);
                    GlobalMembers.ConActions.ConAction PGROWING = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.count(0);
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.sound(ACTOR_GROWING);
                    GlobalMembers.ConActions.cstat(0);
                    return;
                }
            }
            else
            {
                if (GlobalMembers.ConActions.ifmultiplayer())
                {
                    if (GlobalMembers.ConActions.ifphealthl(YELLHURTSOUNDSTRENGTHMP))
                    {
                        if (GlobalMembers.ConActions.ifrnd(64))
                            GlobalMembers.ConActions.sound(DUKE_LONGTERM_PAIN2);
                        else
                        if (GlobalMembers.ConActions.ifrnd(64))
                            GlobalMembers.ConActions.sound(DUKE_LONGTERM_PAIN3);
                        else
                        if (GlobalMembers.ConActions.ifrnd(64))
                            GlobalMembers.ConActions.sound(DUKE_LONGTERM_PAIN4);
                        else
                            GlobalMembers.ConActions.sound(DUKE_DEAD);
                    }
                    else
                    {
                        if (GlobalMembers.ConActions.ifrnd(64))
                            GlobalMembers.ConActions.sound(DUKE_LONGTERM_PAIN5);
                        else
                        if (GlobalMembers.ConActions.ifrnd(64))
                            GlobalMembers.ConActions.sound(DUKE_LONGTERM_PAIN6);
                        else
                        if (GlobalMembers.ConActions.ifrnd(64))
                            GlobalMembers.ConActions.sound(DUKE_LONGTERM_PAIN7);
                        else
                            GlobalMembers.ConActions.sound(DUKE_LONGTERM_PAIN8);
                    }
                }
                else
                {
                    if (GlobalMembers.ConActions.ifphealthl(YELLHURTSOUNDSTRENGTH))
                    {
                        if (GlobalMembers.ConActions.ifrnd(74))
                            GlobalMembers.ConActions.sound(DUKE_LONGTERM_PAIN2);
                        else
                        if (GlobalMembers.ConActions.ifrnd(8))
                            GlobalMembers.ConActions.sound(DUKE_LONGTERM_PAIN3);
                        else
                            GlobalMembers.ConActions.sound(DUKE_LONGTERM_PAIN4);
                    }
                    if (GlobalMembers.ConActions.ifrnd(128))
                        GlobalMembers.ConActions.sound(DUKE_LONGTERM_PAIN);
                }
            }
            if (GlobalMembers.ConActions.ifstrength(TOUGH))
            {
                headhitstate();
                GlobalMembers.ConActions.sound(DUKE_GRUNT);
                if (GlobalMembers.ConActions.ifp(pstanding))
                    GlobalMembers.ConActions.ConAction PFLINTCHING = new GlobalMembers.ConActions.ConAction();
            }
            if (GlobalMembers.ConActions.ifwasweapon(RPG))
            {
                if (GlobalMembers.ConActions.ifrnd(32))
                    GlobalMembers.ConActions.spawn(BLOOD);
                if (GlobalMembers.ConActions.ifdead())
                    standard_pjibs();
                GlobalMembers.ConActions.palfrom(48, 52);
                return;
            }
            if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
            {
                if (GlobalMembers.ConActions.ifrnd(32))
                    GlobalMembers.ConActions.spawn(BLOOD);
                if (GlobalMembers.ConActions.ifdead())
                    standard_pjibs();
                GlobalMembers.ConActions.palfrom(48, 52);
                return;
            }
            if (GlobalMembers.ConActions.ifwasweapon(FIREEXT))
            {
                if (GlobalMembers.ConActions.ifrnd(32))
                    GlobalMembers.ConActions.spawn(BLOOD);
                if (GlobalMembers.ConActions.ifdead())
                    standard_pjibs();
                GlobalMembers.ConActions.palfrom(48, 52);
                return;
            }
            if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
            {
                GlobalMembers.ConActions.palfrom(48, 52);
                GlobalMembers.ConActions.sound(EXPANDERHIT);
                return;
            }
            if (GlobalMembers.ConActions.ifwasweapon(SHRINKSPARK))
            {
                GlobalMembers.ConActions.palfrom(48, 0, 48);
                GlobalMembers.ConActions.Move(PSHRINKING);
                GlobalMembers.ConActions.sound(ACTOR_SHRINKING);
                GlobalMembers.ConActions.cstat(0);
                return;
            }
            if (GlobalMembers.ConActions.ifwasweapon(SHOTSPARK1))
                GlobalMembers.ConActions.palfrom(24, 48);
            if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
            {
                GlobalMembers.ConActions.palfrom(48, 0, 0, 48);
                if (GlobalMembers.ConActions.ifdead())
                {
                    GlobalMembers.ConActions.sound(SOMETHINGFROZE);
                    GlobalMembers.ConActions.spritepal(1);
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.ConAction PFROZEN = new GlobalMembers.ConActions.ConAction();
                    return;
                }
            }
            if (GlobalMembers.ConActions.ifwasweapon(COOLEXPLOSION1))
                GlobalMembers.ConActions.palfrom(48, 48, 0, 48);
            if (GlobalMembers.ConActions.ifwasweapon(KNEE))
                GlobalMembers.ConActions.palfrom(16, 32);
            if (GlobalMembers.ConActions.ifwasweapon(FIRELASER))
                GlobalMembers.ConActions.palfrom(32, 32);
            if (GlobalMembers.ConActions.ifdead())
            {
                GlobalMembers.ConActions.ConAction PTHROWNBACK = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.tossweapon();
            }
            random_wall_jibs();
            return;
        }
        if (GlobalMembers.ConActions.ifaction(PFLINTCHING))
        {
            if (GlobalMembers.ConActions.ifactioncount(2))
                GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
            return;
        }
        if (GlobalMembers.ConActions.ifinwater())
        {
            if (GlobalMembers.ConActions.ifaction(PTREDWATER))
            {
                if (GlobalMembers.ConActions.ifp(pwalking, prunning))
                    GlobalMembers.ConActions.ConAction PSWIMMINGGO = new GlobalMembers.ConActions.ConAction();
            }
            else
            if (GlobalMembers.ConActions.ifp(pstanding, pwalkingback, prunningback))
                GlobalMembers.ConActions.ConAction PTREDWATER = new GlobalMembers.ConActions.ConAction();
            else
            {
                if (GlobalMembers.ConActions.ifaction(PSWIMMING))
                {
                    if (GlobalMembers.ConActions.ifrnd(4))
                        GlobalMembers.ConActions.spawn(WATERBUBBLE);
                    if (GlobalMembers.ConActions.ifactioncount(4))
                        GlobalMembers.ConActions.ConAction PSWIMMINGWAIT = new GlobalMembers.ConActions.ConAction();
                }
                else
                if (GlobalMembers.ConActions.ifaction(PSWIMMINGWAIT))
                {
                    if (GlobalMembers.ConActions.ifactioncount(2))
                        GlobalMembers.ConActions.ConAction PSWIMMINGGO = new GlobalMembers.ConActions.ConAction();
                }
                else
                if (GlobalMembers.ConActions.ifaction(PSWIMMINGGO))
                {
                    if (GlobalMembers.ConActions.ifactioncount(2))
                        GlobalMembers.ConActions.ConAction PSWIMMING = new GlobalMembers.ConActions.ConAction();
                }
                else
                    GlobalMembers.ConActions.ConAction PTREDWATER = new GlobalMembers.ConActions.ConAction();
            }
            if (GlobalMembers.ConActions.ifrnd(4))
                GlobalMembers.ConActions.spawn(WATERBUBBLE);
            return;
        }
        else
        if (GlobalMembers.ConActions.ifp(pjetpack))
        {
            if (GlobalMembers.ConActions.ifaction(PJPHOUVER))
            {
                if (GlobalMembers.ConActions.ifactioncount(4))
                    GlobalMembers.ConActions.resetactioncount();
            }
            else
                GlobalMembers.ConActions.ConAction PJPHOUVER = new GlobalMembers.ConActions.ConAction();
            return;
        }
        else
        {
            if (GlobalMembers.ConActions.ifaction(PTREDWATER))
                GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
            if (GlobalMembers.ConActions.ifaction(PSWIMMING))
                GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
            if (GlobalMembers.ConActions.ifaction(PSWIMMINGWAIT))
                GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
            if (GlobalMembers.ConActions.ifaction(PSWIMMINGGO))
                GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
            if (GlobalMembers.ConActions.ifaction(PJPHOUVER))
                GlobalMembers.ConActions.ConAction PFALLING = new GlobalMembers.ConActions.ConAction();
        }
        if (GlobalMembers.ConActions.ifaction(PFALLING))
        {
            if (GlobalMembers.ConActions.ifp(ponground))
                GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
            else
            {
                if (GlobalMembers.ConActions.ifp(pfalling))
                    return;
                else
                    check_pstandard();
            }
        }
        if (GlobalMembers.ConActions.ifaction(PDUCKING))
        {
            if (GlobalMembers.ConActions.ifgapzl(48))
            {
                if (GlobalMembers.ConActions.ifp(pwalking, pwalkingback, prunning, prunningback))
                    GlobalMembers.ConActions.ConAction PCRAWLING = new GlobalMembers.ConActions.ConAction();
            }
            else
            if (GlobalMembers.ConActions.ifp(pducking))
            {
                if (GlobalMembers.ConActions.ifp(pwalking, pwalkingback, prunning, prunningback))
                    GlobalMembers.ConActions.ConAction PCRAWLING = new GlobalMembers.ConActions.ConAction();
            }
            else
            {
                if (GlobalMembers.ConActions.ifp(pstanding))
                    GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
                else
                    check_pstandard();
            }
        }
        else
        if (GlobalMembers.ConActions.ifaction(PCRAWLING))
        {
            if (GlobalMembers.ConActions.ifgapzl(48))
            {
                if (GlobalMembers.ConActions.ifp(pstanding))
                    GlobalMembers.ConActions.ConAction PCRAWLING = new GlobalMembers.ConActions.ConAction();
            }
            else
            if (GlobalMembers.ConActions.ifp(pducking))
            {
                if (GlobalMembers.ConActions.ifp(pstanding))
                    GlobalMembers.ConActions.ConAction PDUCKING = new GlobalMembers.ConActions.ConAction();
            }
            else
            {
                if (GlobalMembers.ConActions.ifp(pstanding))
                    GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
                else
                    check_pstandard();
            }
        }
        else
        if (GlobalMembers.ConActions.ifgapzl(48))
            GlobalMembers.ConActions.ConAction PDUCKING = new GlobalMembers.ConActions.ConAction();
        else
        if (GlobalMembers.ConActions.ifaction(PJUMPING))
        {
            if (GlobalMembers.ConActions.ifp(ponground))
                GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifactioncount(4))
                if (GlobalMembers.ConActions.ifp(pfalling))
                    GlobalMembers.ConActions.ConAction PFALLING = new GlobalMembers.ConActions.ConAction();
        }
        if (GlobalMembers.ConActions.ifp(pfalling))
            GlobalMembers.ConActions.ConAction PFALLING = new GlobalMembers.ConActions.ConAction();
        else
        if (GlobalMembers.ConActions.ifaction(PSTAND))
            check_pstandard();
        else
        if (GlobalMembers.ConActions.ifaction(PAKICKING))
        {
            if (GlobalMembers.ConActions.ifactioncount(2))
                GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifaction(PWALK))
        {
            if (GlobalMembers.ConActions.ifp(pfalling))
                GlobalMembers.ConActions.ConAction PFALLING = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pstanding))
                GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(prunning))
                GlobalMembers.ConActions.ConAction PRUN = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pwalkingback))
                GlobalMembers.ConActions.ConAction PWALKBACK = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(prunningback))
                GlobalMembers.ConActions.ConAction PRUNBACK = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pjumping))
                GlobalMembers.ConActions.ConAction PJUMPING = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pducking))
                GlobalMembers.ConActions.ConAction PDUCKING = new GlobalMembers.ConActions.ConAction();
        }
        else
        if (GlobalMembers.ConActions.ifaction(PRUN))
        {
            if (GlobalMembers.ConActions.ifp(pstanding))
                GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pwalking))
                GlobalMembers.ConActions.ConAction PWALK = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pwalkingback))
                GlobalMembers.ConActions.ConAction PWALKBACK = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(prunningback))
                GlobalMembers.ConActions.ConAction PRUNBACK = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pjumping))
                GlobalMembers.ConActions.ConAction PJUMPING = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pducking))
                GlobalMembers.ConActions.ConAction PDUCKING = new GlobalMembers.ConActions.ConAction();
        }
        else
        if (GlobalMembers.ConActions.ifaction(PWALKBACK))
        {
            if (GlobalMembers.ConActions.ifp(pstanding))
                GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pwalking))
                GlobalMembers.ConActions.ConAction PWALK = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(prunning))
                GlobalMembers.ConActions.ConAction PRUN = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(prunningback))
                GlobalMembers.ConActions.ConAction PRUNBACK = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pjumping))
                GlobalMembers.ConActions.ConAction PJUMPING = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pducking))
                GlobalMembers.ConActions.ConAction PDUCKING = new GlobalMembers.ConActions.ConAction();
        }
        else
        if (GlobalMembers.ConActions.ifaction(PRUNBACK))
        {
            if (GlobalMembers.ConActions.ifp(pstanding))
                GlobalMembers.ConActions.ConAction PSTAND = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pwalking))
                GlobalMembers.ConActions.ConAction PWALK = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(prunning))
                GlobalMembers.ConActions.ConAction PRUN = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pwalkingback))
                GlobalMembers.ConActions.ConAction PWALKBACK = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pjumping))
                GlobalMembers.ConActions.ConAction PJUMPING = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifp(pducking))
                GlobalMembers.ConActions.ConAction PDUCKING = new GlobalMembers.ConActions.ConAction();
        }
    }
    private void A_ORGANTIC()
    {
        if (GlobalMembers.ConActions.ifcount(48))
            GlobalMembers.ConActions.resetcount();
        else
        {
            if (GlobalMembers.ConActions.ifcount(32))
                GlobalMembers.ConActions.sizeto(32, 32);
        }
else
    if (GlobalMembers.ConActions.ifcount(16))
        {
            GlobalMembers.ConActions.sizeto(48, 18);
            if (GlobalMembers.ConActions.ifpdistl(2048))
            {
                GlobalMembers.ConActions.sound(TURR_ATTACK);
                GlobalMembers.ConActions.addphealth(-2);
                GlobalMembers.ConActions.palfrom(32, 16);
            }
        }
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                GlobalMembers.ConActions.addkills(1);
                GlobalMembers.ConActions.sound(TURR_DYING);
                GlobalMembers.ConActions.guts(JIBS5, 10);
                GlobalMembers.ConActions.killit();
            }
            GlobalMembers.ConActions.sound(TURR_PAIN);
            return;
        }
        if (GlobalMembers.ConActions.ifrnd(1))
            GlobalMembers.ConActions.soundonce(TURR_ROAM);
    }
    private void rf()
    {
        if (GlobalMembers.ConActions.ifrnd(128))
            GlobalMembers.ConActions.cstat(4);
        else
            GlobalMembers.ConActions.cstat(0);
    }
    GlobalMembers.ConActions.ConAction ATROOPSTAND = new GlobalMembers.ConActions.ConAction(0, 1, 5, 1, 1);
    GlobalMembers.ConActions.ConAction ATROOPGROW = new GlobalMembers.ConActions.ConAction(0, 1, 5, 1, 1);
    GlobalMembers.ConActions.ConAction ATROOPSTAYSTAND = new GlobalMembers.ConActions.ConAction(-2, 1, 5, 1, 1);
    GlobalMembers.ConActions.ConAction ATROOPWALKING = new GlobalMembers.ConActions.ConAction(0, 4, 5, 1, 12);
    GlobalMembers.ConActions.ConAction ATROOPWALKINGBACK = new GlobalMembers.ConActions.ConAction(15, 4, 5, -1, 12);
    GlobalMembers.ConActions.ConAction ATROOPRUNNING = new GlobalMembers.ConActions.ConAction(0, 4, 5, 1, 8);
    GlobalMembers.ConActions.ConAction ATROOPSHOOT = new GlobalMembers.ConActions.ConAction(35, 1, 5, 1, 30);
    GlobalMembers.ConActions.ConAction ATROOPJETPACK = new GlobalMembers.ConActions.ConAction(40, 1, 5, 1, 1);
    GlobalMembers.ConActions.ConAction ATROOPJETPACKILL = new GlobalMembers.ConActions.ConAction(40, 2, 5, 1, 50);
    GlobalMembers.ConActions.ConAction ATROOPFLINTCH = new GlobalMembers.ConActions.ConAction(50, 1, 1, 1, 6);
    GlobalMembers.ConActions.ConAction ATROOPDYING = new GlobalMembers.ConActions.ConAction(50, 5, 1, 1, 16);
    GlobalMembers.ConActions.ConAction ATROOPDEAD = new GlobalMembers.ConActions.ConAction(54);
    GlobalMembers.ConActions.ConAction ATROOPPLAYDEAD = new GlobalMembers.ConActions.ConAction(54);
    GlobalMembers.ConActions.ConAction ATROOPSUFFERDEAD = new GlobalMembers.ConActions.ConAction(58, 2, 1, -4, 24);
    GlobalMembers.ConActions.ConAction ATROOPSUFFERING = new GlobalMembers.ConActions.ConAction(59, 2, 1, 1, 21);
    GlobalMembers.ConActions.ConAction ATROOPDUCK = new GlobalMembers.ConActions.ConAction(64, 1, 5, 1, 3);
    GlobalMembers.ConActions.ConAction ATROOPDUCKSHOOT = new GlobalMembers.ConActions.ConAction(64, 2, 5, 1, 25);
    GlobalMembers.ConActions.ConAction ATROOPABOUTHIDE = new GlobalMembers.ConActions.ConAction(74, 1, 1, 1, 25);
    GlobalMembers.ConActions.ConAction ATROOPHIDE = new GlobalMembers.ConActions.ConAction(79, 1, 1, 1, 25);
    GlobalMembers.ConActions.ConAction ATROOPREAPPEAR = new GlobalMembers.ConActions.ConAction(74, 1, 1, 1, 25);
    GlobalMembers.ConActions.ConAction ATROOPFROZEN = new GlobalMembers.ConActions.ConAction(0, 1, 5);
    GlobalMembers.ConActions.MoveAction TROOPWALKVELS = new GlobalMembers.ConActions.MoveAction(72);
    GlobalMembers.ConActions.MoveAction TROOPWALKVELSBACK = new GlobalMembers.ConActions.MoveAction(-72);
    GlobalMembers.ConActions.MoveAction TROOPJETPACKVELS = new GlobalMembers.ConActions.MoveAction(64, -84);
    GlobalMembers.ConActions.MoveAction TROOPJETPACKILLVELS = new GlobalMembers.ConActions.MoveAction(192, -38);
    GlobalMembers.ConActions.MoveAction TROOPRUNVELS = new GlobalMembers.ConActions.MoveAction(108);
    GlobalMembers.ConActions.MoveAction TROOPSTOPPED = new GlobalMembers.ConActions.MoveAction();
    GlobalMembers.ConActions.MoveAction DONTGETUP = new GlobalMembers.ConActions.MoveAction();
    GlobalMembers.ConActions.MoveAction SHRUNKVELS = new GlobalMembers.ConActions.MoveAction(32);
    GlobalMembers.ConActions.AIAction AITROOPSEEKENEMY = new GlobalMembers.ConActions.AIAction(ATROOPWALKING, TROOPWALKVELS, seekplayer);
    GlobalMembers.ConActions.AIAction AITROOPSEEKPLAYER = new GlobalMembers.ConActions.AIAction(ATROOPWALKING, TROOPWALKVELS, seekplayer);
    GlobalMembers.ConActions.AIAction AITROOPFLEEING = new GlobalMembers.ConActions.AIAction(ATROOPWALKING, TROOPWALKVELS, fleeenemy);
    GlobalMembers.ConActions.AIAction AITROOPFLEEINGBACK = new GlobalMembers.ConActions.AIAction(ATROOPWALKINGBACK, TROOPWALKVELSBACK, faceplayer);
    GlobalMembers.ConActions.AIAction AITROOPDODGE = new GlobalMembers.ConActions.AIAction(ATROOPWALKING, TROOPRUNVELS, dodgebullet);
    GlobalMembers.ConActions.AIAction AITROOPSHOOTING = new GlobalMembers.ConActions.AIAction(ATROOPSHOOT, TROOPSTOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AITROOPDUCKING = new GlobalMembers.ConActions.AIAction(ATROOPDUCK, TROOPSTOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AITROOPJETPACK = new GlobalMembers.ConActions.AIAction(ATROOPJETPACK, TROOPJETPACKVELS, seekplayer);
    GlobalMembers.ConActions.AIAction AITROOPSHRUNK = new GlobalMembers.ConActions.AIAction(ATROOPWALKING, SHRUNKVELS, fleeenemy);
    GlobalMembers.ConActions.AIAction AITROOPHIDE = new GlobalMembers.ConActions.AIAction(ATROOPABOUTHIDE, TROOPSTOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AITROOPGROW = new GlobalMembers.ConActions.AIAction(ATROOPGROW, DONTGETUP, faceplayerslow);
    private void troophidestate()
    {
        if (GlobalMembers.ConActions.ifaction(ATROOPREAPPEAR))
        {
            if (GlobalMembers.ConActions.ifactioncount(2))
            {
                GlobalMembers.ConActions.sound(TELEPORTER);
                GlobalMembers.ConActions.Ai(AITROOPSHOOTING);
                GlobalMembers.ConActions.cstat(257);
            }
            else
            {
                GlobalMembers.ConActions.sizeto(41, 40);
                GlobalMembers.ConActions.sizeto(41, 40);
                GlobalMembers.ConActions.sizeto(41, 40);
                GlobalMembers.ConActions.sizeto(41, 40);
                GlobalMembers.ConActions.spawn(FRAMEEFFECT1);
            }
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATROOPWALKING))
        {
            if (GlobalMembers.ConActions.ifpdistl(2448))
                if (GlobalMembers.ConActions.ifpdistg(1024))
                {
                    if (GlobalMembers.ConActions.ifceilingdistl(48))
                        return;
                    if (GlobalMembers.ConActions.ifp(pfacing))
                        return;
                    if (GlobalMembers.ConActions.ifgapzl(64))
// nullop
else
    if (GlobalMembers.ConActions.ifawayfromwall())
                            {
                                GlobalMembers.ConActions.spawn(TRANSPORTERSTAR);
                                GlobalMembers.ConActions.ConAction ATROOPREAPPEAR = new GlobalMembers.ConActions.ConAction();
                                GlobalMembers.ConActions.Move(0);
                                return;
                            }
                }
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATROOPHIDE))
        {
            if (GlobalMembers.ConActions.ifactioncount(2))
            {
                GlobalMembers.ConActions.spawn(TRANSPORTERSTAR);
                GlobalMembers.ConActions.sound(TELEPORTER);
                GlobalMembers.ConActions.ConAction ATROOPWALKING = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.Move(TROOPWALKVELS, faceplayer);
                GlobalMembers.ConActions.cstat(32768);
            }
            else
            {
                GlobalMembers.ConActions.sizeto(4, 40);
                GlobalMembers.ConActions.sizeto(4, 40);
                GlobalMembers.ConActions.sizeto(4, 40);
                GlobalMembers.ConActions.sizeto(4, 40);
                GlobalMembers.ConActions.spawn(FRAMEEFFECT1);
            }
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATROOPABOUTHIDE))
            if (GlobalMembers.ConActions.ifactioncount(2))
            {
                GlobalMembers.ConActions.ConAction ATROOPHIDE = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.cstat(0);
            }
    }
    private void troopgunnashoot()
    {
        if (GlobalMembers.ConActions.ifp(palive))
        {
            if (GlobalMembers.ConActions.ifpdistl(1024))
                GlobalMembers.ConActions.Ai(AITROOPSHOOTING);
            else
                if (GlobalMembers.ConActions.ifactornotstayput())
            {
                if (GlobalMembers.ConActions.ifactioncount(12))
                    if (GlobalMembers.ConActions.ifrnd(16))
                        if (GlobalMembers.ConActions.ifcanshoottarget())
                        {
                            if (GlobalMembers.ConActions.ifspritepal(21))
                                if (GlobalMembers.ConActions.ifrnd(4))
                                    if (GlobalMembers.ConActions.ifpdistg(4096))
                                        GlobalMembers.ConActions.Ai(AITROOPHIDE);
                                    else
                                    {
                                        if (GlobalMembers.ConActions.ifpdistl(1100))
                                            GlobalMembers.ConActions.Ai(AITROOPFLEEING);
                                        else
                                        {
                                            if (GlobalMembers.ConActions.ifpdistl(4096))
                                                if (GlobalMembers.ConActions.ifcansee())
                                                    if (GlobalMembers.ConActions.ifcanshoottarget())
                                                        GlobalMembers.ConActions.Ai(AITROOPSHOOTING);
                                                    else
                                                    {
                                                        GlobalMembers.ConActions.Move(TROOPRUNVELS, seekplayer);
                                                        GlobalMembers.ConActions.ConAction ATROOPRUNNING = new GlobalMembers.ConActions.ConAction();
                                                    }
                                        }
                                    }
                        }
            }
            else
                if (GlobalMembers.ConActions.ifcount(26))
                if (GlobalMembers.ConActions.ifrnd(32))
                    GlobalMembers.ConActions.Ai(AITROOPSHOOTING);
        }
    }
    private void troopseekstate()
    {
        troopgunnashoot();
        if (GlobalMembers.ConActions.ifinwater())
        {
            GlobalMembers.ConActions.Ai(AITROOPJETPACK);
            return;
        }
        if (GlobalMembers.ConActions.ifcansee())
        {
            if (GlobalMembers.ConActions.ifmove(TROOPRUNVELS))
                if (GlobalMembers.ConActions.ifpdistl(1596))
                    GlobalMembers.ConActions.Ai(AITROOPDUCKING);
            if (GlobalMembers.ConActions.ifp(phigher))
            {
                if (GlobalMembers.ConActions.ifceilingdistl(128))
// nullop
else
    if (GlobalMembers.ConActions.ifactornotstayput())
                            GlobalMembers.ConActions.Ai(AITROOPJETPACK);
                return;
            }
            else
            if (GlobalMembers.ConActions.ifrnd(2))
            {
                if (GlobalMembers.ConActions.ifspritepal(21))
                    if (GlobalMembers.ConActions.ifpdistg(1596))
                    {
                        GlobalMembers.ConActions.Ai(AITROOPHIDE);
                        return;
                    }
                if (GlobalMembers.ConActions.ifbulletnear())
                {
                    if (GlobalMembers.ConActions.ifrnd(128))
                        GlobalMembers.ConActions.Ai(AITROOPDODGE);
                    else
                        GlobalMembers.ConActions.Ai(AITROOPDUCKING);
                    return;
                }
            }
        }
        if (GlobalMembers.ConActions.ifnotmoving())
        {
            if (GlobalMembers.ConActions.ifrnd(32))
                GlobalMembers.ConActions.operate();
            else
            if (GlobalMembers.ConActions.ifcount(32))
                if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifcansee())
                        if (GlobalMembers.ConActions.ifcanshoottarget())
                            GlobalMembers.ConActions.Ai(AITROOPSHOOTING);
        }
        if (GlobalMembers.ConActions.ifrnd(1))
        {
            if (GlobalMembers.ConActions.ifrnd(128))
                GlobalMembers.ConActions.soundonce(PRED_ROAM);
            else
                GlobalMembers.ConActions.soundonce(PRED_ROAM2);
        }
    }
    private void troopduckstate()
    {
        if (GlobalMembers.ConActions.ifaction(ATROOPDUCK))
        {
            if (GlobalMembers.ConActions.ifactioncount(8))
            {
                if (GlobalMembers.ConActions.ifp(palive))
                {
                    if (GlobalMembers.ConActions.ifrnd(128))
                        GlobalMembers.ConActions.ConAction ATROOPDUCKSHOOT = new GlobalMembers.ConActions.ConAction();
                }
                else
                if (GlobalMembers.ConActions.ifmove(DONTGETUP))
                    return;
                else
                    GlobalMembers.ConActions.Ai(AITROOPSEEKPLAYER);
            }
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATROOPDUCKSHOOT))
        {
            if (GlobalMembers.ConActions.ifcount(64))
            {
                if (GlobalMembers.ConActions.ifmove(DONTGETUP))
                    GlobalMembers.ConActions.resetcount();
                else
                {
                    if (GlobalMembers.ConActions.ifpdistl(1100))
                        GlobalMembers.ConActions.Ai(AITROOPFLEEING);
                    else
                        GlobalMembers.ConActions.Ai(AITROOPSEEKPLAYER);
                }
            }
            else
            if (GlobalMembers.ConActions.ifactioncount(2))
            {
                if (GlobalMembers.ConActions.ifcanshoottarget())
                {
                    GlobalMembers.ConActions.sound(PRED_ATTACK);
                    GlobalMembers.ConActions.resetactioncount();
                    GlobalMembers.ConActions.shoot(FIRELASER);
                }
                else
                    GlobalMembers.ConActions.Ai(AITROOPSEEKPLAYER);
            }
        }
    }
    private void troopshootstate()
    {
        if (GlobalMembers.ConActions.ifactioncount(2))
        {
            if (GlobalMembers.ConActions.ifcanshoottarget())
            {
                GlobalMembers.ConActions.shoot(FIRELASER);
                GlobalMembers.ConActions.sound(PRED_ATTACK);
                GlobalMembers.ConActions.resetactioncount();
                if (GlobalMembers.ConActions.ifrnd(128))
                    GlobalMembers.ConActions.Ai(AITROOPSEEKPLAYER);
                if (GlobalMembers.ConActions.ifcount(24))
                {
                    if (GlobalMembers.ConActions.ifrnd(96))
                        if (GlobalMembers.ConActions.ifpdistg(2048))
                            GlobalMembers.ConActions.Ai(AITROOPSEEKPLAYER);
                        else
                        {
                            if (GlobalMembers.ConActions.ifpdistg(1596))
                                GlobalMembers.ConActions.Ai(AITROOPFLEEING);
                            else
                                GlobalMembers.ConActions.Ai(AITROOPFLEEINGBACK);
                        }
                }
            }
            else
                GlobalMembers.ConActions.Ai(AITROOPSEEKPLAYER);
        }
    }
    private void troopfleestate()
    {
        if (GlobalMembers.ConActions.ifactioncount(7))
        {
            if (GlobalMembers.ConActions.ifpdistg(3084))
            {
                GlobalMembers.ConActions.Ai(AITROOPSEEKPLAYER);
                return;
            }
            else
                if (GlobalMembers.ConActions.ifrnd(32))
                if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifcansee())
                        if (GlobalMembers.ConActions.ifcanshoottarget())
                        {
                            if (GlobalMembers.ConActions.ifrnd(128))
                                GlobalMembers.ConActions.Ai(AITROOPDUCKING);
                            else
                                GlobalMembers.ConActions.Ai(AITROOPSHOOTING);
                            return;
                        }
        }
        if (GlobalMembers.ConActions.ifnotmoving())
        {
            if (GlobalMembers.ConActions.ifrnd(32))
                GlobalMembers.ConActions.operate();
            else
            if (GlobalMembers.ConActions.ifcount(32))
                if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifcansee())
                        if (GlobalMembers.ConActions.ifcanshoottarget())
                        {
                            if (GlobalMembers.ConActions.ifrnd(128))
                                GlobalMembers.ConActions.Ai(AITROOPSHOOTING);
                            else
                                GlobalMembers.ConActions.Ai(AITROOPDUCKING);
                        }
        }
    }
    private void troopdying()
    {
        if (GlobalMembers.ConActions.iffloordistl(32))
        {
            if (GlobalMembers.ConActions.ifactioncount(5))
            {
                GlobalMembers.ConActions.cstat(0);
                if (GlobalMembers.ConActions.iffloordistl(8))
                    GlobalMembers.ConActions.sound(THUD);
                if (GlobalMembers.ConActions.ifrnd(64))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                rf();
                GlobalMembers.ConActions.strength(0);
                GlobalMembers.ConActions.Move(TROOPSTOPPED);
                GlobalMembers.ConActions.ConAction ATROOPDEAD = new GlobalMembers.ConActions.ConAction();
            }
            return;
        }
        else
        {
            rf();
            GlobalMembers.ConActions.Move(0);
            GlobalMembers.ConActions.ConAction ATROOPDYING = new GlobalMembers.ConActions.ConAction();
        }
    }
    private void checktroophit()
    {
        if (GlobalMembers.ConActions.ifaction(ATROOPSUFFERING))
        {
            GlobalMembers.ConActions.stopsound(LIZARD_BEG);
            GlobalMembers.ConActions.sound(PRED_DYING);
            GlobalMembers.ConActions.cstat(0);
            GlobalMembers.ConActions.strength(0);
            GlobalMembers.ConActions.ConAction ATROOPSUFFERDEAD = new GlobalMembers.ConActions.ConAction();
            return;
        }
        if (GlobalMembers.ConActions.ifdead())
        {
            if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
            {
                GlobalMembers.ConActions.sound(SOMETHINGFROZE);
                GlobalMembers.ConActions.spritepal(1);
                GlobalMembers.ConActions.Move(0);
                GlobalMembers.ConActions.ConAction ATROOPFROZEN = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.strength(0);
                return;
            }
            drop_ammo();
            random_wall_jibs();
            if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
            {
                GlobalMembers.ConActions.cstat(0);
                GlobalMembers.ConActions.sound(ACTOR_GROWING);
                GlobalMembers.ConActions.Ai(AITROOPGROW);
                return;
            }
            GlobalMembers.ConActions.addkills(1);
            if (GlobalMembers.ConActions.ifwasweapon(RPG))
            {
                GlobalMembers.ConActions.sound(SQUISHED);
                troop_body_jibs();
                standard_jibs();
                GlobalMembers.ConActions.killit();
            }
            else
            if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
            {
                GlobalMembers.ConActions.sound(SQUISHED);
                troop_body_jibs();
                standard_jibs();
                GlobalMembers.ConActions.killit();
            }
            else
            {
                GlobalMembers.ConActions.sound(PRED_DYING);
                if (GlobalMembers.ConActions.ifrnd(32))
                    if (GlobalMembers.ConActions.iffloordistl(32))
                    {
                        GlobalMembers.ConActions.sound(LIZARD_BEG);
                        GlobalMembers.ConActions.spawn(BLOODPOOL);
                        GlobalMembers.ConActions.strength(0);
                        GlobalMembers.ConActions.Move(0);
                        GlobalMembers.ConActions.ConAction ATROOPSUFFERING = new GlobalMembers.ConActions.ConAction();
                        return;
                    }
                GlobalMembers.ConActions.ConAction ATROOPDYING = new GlobalMembers.ConActions.ConAction();
                return;
            }
        }
        else
        {
            random_wall_jibs();
            GlobalMembers.ConActions.sound(PRED_PAIN);
            if (GlobalMembers.ConActions.ifwasweapon(SHRINKSPARK))
            {
                GlobalMembers.ConActions.sound(ACTOR_SHRINKING);
                GlobalMembers.ConActions.Ai(AITROOPSHRUNK);
            }
            else
            if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                GlobalMembers.ConActions.sound(EXPANDERHIT);
            else
            if (GlobalMembers.ConActions.iffloordistl(32))
                if (GlobalMembers.ConActions.ifrnd(96))
                    GlobalMembers.ConActions.ConAction ATROOPFLINTCH = new GlobalMembers.ConActions.ConAction();
        }
    }
    private void troopjetpackstate()
    {
        if (GlobalMembers.ConActions.ifaction(ATROOPJETPACKILL))
        {
            if (GlobalMembers.ConActions.ifcansee())
                if (GlobalMembers.ConActions.ifactioncount(2))
                {
                    GlobalMembers.ConActions.resetactioncount();
                    GlobalMembers.ConActions.sound(PRED_ATTACK);
                    GlobalMembers.ConActions.shoot(FIRELASER);
                }
            if (GlobalMembers.ConActions.ifp(phigher))
                GlobalMembers.ConActions.Ai(AITROOPJETPACK);
            else
            if (GlobalMembers.ConActions.ifinwater())
                GlobalMembers.ConActions.Ai(AITROOPJETPACK);
            else
            if (GlobalMembers.ConActions.ifcount(26))
                if (GlobalMembers.ConActions.iffloordistl(32))
                    GlobalMembers.ConActions.Ai(AITROOPSEEKPLAYER);
        }
        else
        if (GlobalMembers.ConActions.ifcount(48))
            if (GlobalMembers.ConActions.ifcansee())
            {
                GlobalMembers.ConActions.ConAction ATROOPJETPACKILL = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.Move(TROOPJETPACKILLVELS);
            }
    }
    private void checksquished()
    {
        if (GlobalMembers.ConActions.ifsquished())
        {
            GlobalMembers.ConActions.addkills(1);
            GlobalMembers.ConActions.sound(SQUISHED);
            standard_jibs();
            random_ooz();
            GlobalMembers.ConActions.killit();
        }
    }
    private void troopsufferingstate()
    {
        if (GlobalMembers.ConActions.ifactioncount(2))
        {
            if (GlobalMembers.ConActions.ifrnd(16))
                GlobalMembers.ConActions.spawn(WATERDRIP);
            if (GlobalMembers.ConActions.ifactioncount(14))
            {
                GlobalMembers.ConActions.stopsound(LIZARD_BEG);
                GlobalMembers.ConActions.cstat(0);
                GlobalMembers.ConActions.strength(0);
                GlobalMembers.ConActions.ConAction ATROOPSUFFERDEAD = new GlobalMembers.ConActions.ConAction();
                return;
            }
        }
    }
    private void troopshrunkstate()
    {
        if (GlobalMembers.ConActions.ifcount(SHRUNKDONECOUNT))
            GlobalMembers.ConActions.Ai(AITROOPSEEKENEMY);
        else
        if (GlobalMembers.ConActions.ifcount(SHRUNKCOUNT))
            GlobalMembers.ConActions.sizeto(48, 40);
        else
            genericshrunkcode();
    }
    private void troopcode()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifinwater())
            if (GlobalMembers.ConActions.ifrnd(1))
                GlobalMembers.ConActions.spawn(WATERBUBBLE);
        if (GlobalMembers.ConActions.ifaction(ATROOPSTAND))
        {
            if (GlobalMembers.ConActions.ifrnd(192))
                GlobalMembers.ConActions.Ai(AITROOPSHOOTING);
            else
                GlobalMembers.ConActions.Ai(AITROOPSEEKPLAYER);
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATROOPFROZEN))
        {
            if (GlobalMembers.ConActions.ifcount(THAWTIME))
            {
                GlobalMembers.ConActions.Ai(AITROOPSEEKENEMY);
                GlobalMembers.ConActions.getlastpal();
            }
            else
            if (GlobalMembers.ConActions.ifcount(FROZENDRIPTIME))
            {
                if (GlobalMembers.ConActions.ifactioncount(26))
                {
                    GlobalMembers.ConActions.spawn(WATERDRIP);
                    GlobalMembers.ConActions.resetactioncount();
                }
            }
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                GlobalMembers.ConActions.addkills(1);
                if (GlobalMembers.ConActions.ifrnd(84))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.lotsofglass(30);
                GlobalMembers.ConActions.sound(GLASS_BREAKING);
                GlobalMembers.ConActions.killit();
            }
            if (GlobalMembers.ConActions.ifp(pfacing))
                if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                    GlobalMembers.ConActions.pkick();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATROOPPLAYDEAD))
        {
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                {
                    GlobalMembers.ConActions.sound(SQUISHED);
                    troop_body_jibs();
                    standard_jibs();
                    GlobalMembers.ConActions.killit();
                }
                return;
            }
            else
                checksquished();
            if (GlobalMembers.ConActions.ifcount(PLAYDEADTIME))
            {
                GlobalMembers.ConActions.addkills(-1);
                GlobalMembers.ConActions.soundonce(PRED_ROAM);
                GlobalMembers.ConActions.cstat(257);
                GlobalMembers.ConActions.strength(1);
                GlobalMembers.ConActions.Ai(AITROOPSHOOTING);
            }
            else
            if (GlobalMembers.ConActions.ifp(pfacing))
                GlobalMembers.ConActions.resetcount();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATROOPDEAD))
        {
            GlobalMembers.ConActions.strength(0);
            if (GlobalMembers.ConActions.ifrespawn())
                if (GlobalMembers.ConActions.ifcount(RESPAWNACTORTIME))
                {
                    GlobalMembers.ConActions.spawn(TRANSPORTERSTAR);
                    GlobalMembers.ConActions.cstat(257);
                    GlobalMembers.ConActions.strength(TROOPSTRENGTH);
                    GlobalMembers.ConActions.Ai(AITROOPSEEKENEMY);
                }
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                {
                    GlobalMembers.ConActions.sound(SQUISHED);
                    troop_body_jibs();
                    standard_jibs();
                    GlobalMembers.ConActions.killit();
                }
                return;
            }
            else
                checksquished();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATROOPSUFFERDEAD))
        {
            if (GlobalMembers.ConActions.ifactioncount(2))
            {
                if (GlobalMembers.ConActions.ifrnd(64))
                {
                    GlobalMembers.ConActions.resetcount();
                    GlobalMembers.ConActions.ConAction ATROOPPLAYDEAD = new GlobalMembers.ConActions.ConAction();
                }
                else
                {
                    GlobalMembers.ConActions.soundonce(PRED_DYING);
                    GlobalMembers.ConActions.ConAction ATROOPDEAD = new GlobalMembers.ConActions.ConAction();
                }
            }
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATROOPDYING))
        {
            troopdying();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATROOPSUFFERING))
        {
            troopsufferingstate();
            if (GlobalMembers.ConActions.ifhitweapon())
                checktroophit();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATROOPFLINTCH))
        {
            if (GlobalMembers.ConActions.ifactioncount(4))
                GlobalMembers.ConActions.Ai(AITROOPSEEKENEMY);
        }
        else
        {
            if (GlobalMembers.ConActions.ifai(AITROOPSEEKPLAYER))
                troopseekstate();
            else
            if (GlobalMembers.ConActions.ifai(AITROOPJETPACK))
            {
                troopjetpackstate();
                if (GlobalMembers.ConActions.ifinwater())
// nullop
else
                            GlobalMembers.ConActions.soundonce(DUKE_JETPACK_IDLE);
            }
            else
            if (GlobalMembers.ConActions.ifai(AITROOPSEEKENEMY))
                troopseekstate();
            else
            if (GlobalMembers.ConActions.ifai(AITROOPSHOOTING))
                troopshootstate();
            else
            if (GlobalMembers.ConActions.ifai(AITROOPFLEEING))
                troopfleestate();
            else
            if (GlobalMembers.ConActions.ifai(AITROOPFLEEINGBACK))
                troopfleestate();
            else
            if (GlobalMembers.ConActions.ifai(AITROOPDODGE))
                troopseekstate();
            else
            if (GlobalMembers.ConActions.ifai(AITROOPDUCKING))
                troopduckstate();
            else
            if (GlobalMembers.ConActions.ifai(AITROOPSHRUNK))
                troopshrunkstate();
            else
            if (GlobalMembers.ConActions.ifai(AITROOPGROW))
                genericgrowcode();
            else
            if (GlobalMembers.ConActions.ifai(AITROOPHIDE))
            {
                troophidestate();
                return;
            }
        }
        if (GlobalMembers.ConActions.ifhitweapon())
            checktroophit();
        else
            checksquished();
    }
    private void checktrooppalette()
    {
        if (GlobalMembers.ConActions.ifai(0))
        {
            if (GlobalMembers.ConActions.ifspritepal(0))
// nullop
else
    if (GlobalMembers.ConActions.ifspritepal(21))
                        GlobalMembers.ConActions.addstrength(TROOPSTRENGTH);
        }
    }
    private void A_LIZTROOPJETPACK()
    {
        checktrooppalette();
        GlobalMembers.ConActions.Ai(AITROOPJETPACK);
        GlobalMembers.ConActions.cactor(LIZTROOP);
    }
    private void A_LIZTROOPDUCKING()
    {
        checktrooppalette();
        GlobalMembers.ConActions.Ai(AITROOPDUCKING);
        GlobalMembers.ConActions.cactor(LIZTROOP);
        if (GlobalMembers.ConActions.ifgapzl(48))
            GlobalMembers.ConActions.Move(DONTGETUP);
    }
    private void A_LIZTROOPSHOOT()
    {
        checktrooppalette();
        GlobalMembers.ConActions.Ai(AITROOPSHOOTING);
        GlobalMembers.ConActions.cactor(LIZTROOP);
    }
    private void A_LIZTROOPSTAYPUT()
    {
        checktrooppalette();
        GlobalMembers.ConActions.Ai(AITROOPSEEKPLAYER);
        GlobalMembers.ConActions.cactor(LIZTROOP);
    }
    private void A_LIZTROOPRUNNING()
    {
        checktrooppalette();
        GlobalMembers.ConActions.Ai(AITROOPSEEKPLAYER);
        GlobalMembers.ConActions.cactor(LIZTROOP);
    }
    private void A_LIZTROOPONTOILET()
    {
        if (GlobalMembers.ConActions.ifcount(24))
        {
            GlobalMembers.ConActions.sound(FLUSH_TOILET);
            GlobalMembers.ConActions.operate();
            GlobalMembers.ConActions.Ai(AITROOPSEEKPLAYER);
            GlobalMembers.ConActions.cactor(LIZTROOP);
        }
        else
        if (GlobalMembers.ConActions.ifcount(2))
// nullop
else
                    checktrooppalette();
    }
    private void A_LIZTROOPJUSTSIT()
    {
        if (GlobalMembers.ConActions.ifcount(30))
        {
            GlobalMembers.ConActions.operate();
            GlobalMembers.ConActions.Ai(AITROOPSEEKPLAYER);
            GlobalMembers.ConActions.cactor(LIZTROOP);
        }
        else
        if (GlobalMembers.ConActions.ifcount(2))
// nullop
else
                    checktrooppalette();
    }
    private void A_LIZTROOP()
    {
        checktrooppalette();
        troopcode();
    }
    GlobalMembers.ConActions.ConAction ALIZSTAND = new GlobalMembers.ConActions.ConAction(0);
    GlobalMembers.ConActions.ConAction ALIZWALKING = new GlobalMembers.ConActions.ConAction(0, 4, 5, 1, 15);
    GlobalMembers.ConActions.ConAction ALIZRUNNING = new GlobalMembers.ConActions.ConAction(0, 4, 5, 1, 11);
    GlobalMembers.ConActions.ConAction ALIZTHINK = new GlobalMembers.ConActions.ConAction(20, 2, 5, 1, 40);
    GlobalMembers.ConActions.ConAction ALIZSCREAM = new GlobalMembers.ConActions.ConAction(30, 1, 5, 1, 2);
    GlobalMembers.ConActions.ConAction ALIZJUMP = new GlobalMembers.ConActions.ConAction(45, 3, 5, 1, 20);
    GlobalMembers.ConActions.ConAction ALIZFALL = new GlobalMembers.ConActions.ConAction(55, 1, 5);
    GlobalMembers.ConActions.ConAction ALIZSHOOTING = new GlobalMembers.ConActions.ConAction(70, 2, 5, 1, 7);
    GlobalMembers.ConActions.ConAction ALIZDYING = new GlobalMembers.ConActions.ConAction(60, 6, 1, 1, 15);
    GlobalMembers.ConActions.ConAction ALIZLYINGDEAD = new GlobalMembers.ConActions.ConAction(65, 1);
    GlobalMembers.ConActions.ConAction ALIZFROZEN = new GlobalMembers.ConActions.ConAction(0, 1, 5);
    GlobalMembers.ConActions.MoveAction LIZWALKVEL = new GlobalMembers.ConActions.MoveAction(72);
    GlobalMembers.ConActions.MoveAction LIZRUNVEL = new GlobalMembers.ConActions.MoveAction(192);
    GlobalMembers.ConActions.MoveAction LIZJUMPVEL = new GlobalMembers.ConActions.MoveAction(184);
    GlobalMembers.ConActions.MoveAction LIZSTOP = new GlobalMembers.ConActions.MoveAction();
    GlobalMembers.ConActions.AIAction AILIZGETENEMY = new GlobalMembers.ConActions.AIAction(ALIZWALKING, LIZWALKVEL, seekplayer);
    GlobalMembers.ConActions.AIAction AILIZDODGE = new GlobalMembers.ConActions.AIAction(ALIZRUNNING, LIZRUNVEL, dodgebullet);
    GlobalMembers.ConActions.AIAction AILIZCHARGEENEMY = new GlobalMembers.ConActions.AIAction(ALIZRUNNING, LIZRUNVEL, seekplayer);
    GlobalMembers.ConActions.AIAction AILIZFLEENEMY = new GlobalMembers.ConActions.AIAction(ALIZWALKING, LIZWALKVEL, fleeenemy);
    GlobalMembers.ConActions.AIAction AILIZSHOOTENEMY = new GlobalMembers.ConActions.AIAction(ALIZSHOOTING, LIZSTOP, faceplayer);
    GlobalMembers.ConActions.AIAction AILIZJUMPENEMY = new GlobalMembers.ConActions.AIAction(ALIZJUMP, LIZJUMPVEL, jumptoplayer);
    GlobalMembers.ConActions.AIAction AILIZTHINK = new GlobalMembers.ConActions.AIAction(ALIZTHINK, LIZSTOP, faceplayerslow);
    GlobalMembers.ConActions.AIAction AILIZSHRUNK = new GlobalMembers.ConActions.AIAction(ALIZWALKING, SHRUNKVELS, fleeenemy);
    GlobalMembers.ConActions.AIAction AILIZGROW = new GlobalMembers.ConActions.AIAction(ALIZSTAND, LIZSTOP, faceplayerslow);
    GlobalMembers.ConActions.AIAction AILIZSPIT = new GlobalMembers.ConActions.AIAction(ALIZSCREAM, LIZSTOP, faceplayerslow);
    GlobalMembers.ConActions.AIAction AILIZDYING = new GlobalMembers.ConActions.AIAction(ALIZDYING, LIZSTOP, faceplayer);
    private void lizseekstate()
    {
        if (GlobalMembers.ConActions.ifactornotstayput())
        {
            if (GlobalMembers.ConActions.ifcansee())
                if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifpdistl(2048))
                        if (GlobalMembers.ConActions.ifcount(16))
                            if (GlobalMembers.ConActions.ifcanshoottarget())
                            {
                                GlobalMembers.ConActions.Ai(AILIZSHOOTENEMY);
                                return;
                            }
            if (GlobalMembers.ConActions.ifai(AILIZCHARGEENEMY))
            {
                if (GlobalMembers.ConActions.ifcount(72))
                    if (GlobalMembers.ConActions.ifcanshoottarget())
                    {
                        GlobalMembers.ConActions.Ai(AILIZSHOOTENEMY);
                        return;
                    }
                if (GlobalMembers.ConActions.ifp(phigher))
                    if (GlobalMembers.ConActions.ifpdistg(2048))
                        if (GlobalMembers.ConActions.ifrnd(6))
                        {
                            GlobalMembers.ConActions.Ai(AILIZJUMPENEMY);
                            return;
                        }
            }
            else
        if (GlobalMembers.ConActions.ifpdistg(4096))
            {
                if (GlobalMembers.ConActions.ifrnd(92))
                {
                    if (GlobalMembers.ConActions.ifcount(48))
                        if (GlobalMembers.ConActions.ifcanshoottarget())
                            GlobalMembers.ConActions.Ai(AILIZSHOOTENEMY);
                }
                else
                if (GlobalMembers.ConActions.ifcount(24))
                {
                    GlobalMembers.ConActions.Ai(AILIZCHARGEENEMY);
                    return;
                }
            }
            if (GlobalMembers.ConActions.iffloordistl(16))
            {
                if (GlobalMembers.ConActions.ifcount(48))
                    if (GlobalMembers.ConActions.ifnotmoving())
                        if (GlobalMembers.ConActions.ifcansee())
                        {
                            GlobalMembers.ConActions.Ai(AILIZJUMPENEMY);
                            return;
                        }
            }
            else
            {
                if (GlobalMembers.ConActions.ifpdistg(1280))
                    GlobalMembers.ConActions.Ai(AILIZJUMPENEMY);
                return;
            }
            if (GlobalMembers.ConActions.ifrnd(4))
                if (GlobalMembers.ConActions.ifnotmoving())
                    GlobalMembers.ConActions.operate();
                else
                if (GlobalMembers.ConActions.ifrnd(1))
                    if (GlobalMembers.ConActions.ifbulletnear())
                    {
                        if (GlobalMembers.ConActions.ifgapzl(128))
                            GlobalMembers.ConActions.Ai(AILIZDODGE);
                        else
                        if (GlobalMembers.ConActions.ifactornotstayput())
                        {
                            if (GlobalMembers.ConActions.ifrnd(32))
                                GlobalMembers.ConActions.Ai(AILIZJUMPENEMY);
                            else
                                GlobalMembers.ConActions.Ai(AILIZDODGE);
                        }
                    }
        }
        else
        {
            if (GlobalMembers.ConActions.ifactioncount(16))
            {
                if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifrnd(32))
                        if (GlobalMembers.ConActions.ifcansee())
                            if (GlobalMembers.ConActions.ifcanshoottarget())
                                GlobalMembers.ConActions.Ai(AILIZSHOOTENEMY);
            }
            if (GlobalMembers.ConActions.ifcount(16))
                if (GlobalMembers.ConActions.ifrnd(32))
                    GlobalMembers.ConActions.Move(LIZWALKVEL, randomangle, geth);
        }
    }
    private void lizshrunkstate()
    {
        if (GlobalMembers.ConActions.ifcount(SHRUNKDONECOUNT))
            GlobalMembers.ConActions.Ai(AILIZGETENEMY);
        else
        if (GlobalMembers.ConActions.ifcount(SHRUNKCOUNT))
            GlobalMembers.ConActions.sizeto(48, 40);
        else
            genericshrunkcode();
    }
    private void lizfleestate()
    {
        if (GlobalMembers.ConActions.ifcount(16))
        {
            if (GlobalMembers.ConActions.ifrnd(48))
                if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifcansee())
                        GlobalMembers.ConActions.Ai(AILIZSPIT);
        }
        else
        {
            if (GlobalMembers.ConActions.iffloordistl(16))
// nullop
else
                        GlobalMembers.ConActions.Ai(AILIZGETENEMY);
            return;
        }
    }
    private void lizthinkstate()
    {
        if (GlobalMembers.ConActions.ifrnd(8))
            GlobalMembers.ConActions.soundonce(CAPT_ROAM);
        if (GlobalMembers.ConActions.ifactioncount(3))
        {
            if (GlobalMembers.ConActions.ifrnd(32))
                if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifcansee())
                        GlobalMembers.ConActions.Ai(AILIZSPIT);
                    else
                        if (GlobalMembers.ConActions.ifrnd(96))
                        GlobalMembers.ConActions.Ai(AILIZGETENEMY);
        }
        else
        if (GlobalMembers.ConActions.ifactioncount(2))
            if (GlobalMembers.ConActions.ifrnd(1))
                GlobalMembers.ConActions.spawn(FECES);
        if (GlobalMembers.ConActions.ifrnd(1))
            if (GlobalMembers.ConActions.ifbulletnear())
            {
                if (GlobalMembers.ConActions.ifgapzl(96))
                    GlobalMembers.ConActions.Ai(AILIZDODGE);
                else
                {
                    if (GlobalMembers.ConActions.ifrnd(128))
                        GlobalMembers.ConActions.Ai(AILIZJUMPENEMY);
                    else
                        GlobalMembers.ConActions.Ai(AILIZDODGE);
                }
            }
    }
    private void lizshootstate()
    {
        if (GlobalMembers.ConActions.ifcount(20))
            if (GlobalMembers.ConActions.ifrnd(8))
            {
                if (GlobalMembers.ConActions.ifcansee())
                    if (GlobalMembers.ConActions.ifpdistl(2048))
                    {
                        if (GlobalMembers.ConActions.ifrnd(128))
                            GlobalMembers.ConActions.Ai(AILIZFLEENEMY);
                        return;
                    }
                if (GlobalMembers.ConActions.ifrnd(80))
                    GlobalMembers.ConActions.Ai(AILIZTHINK);
                else
                    GlobalMembers.ConActions.Ai(AILIZGETENEMY);
            }
        if (GlobalMembers.ConActions.ifactioncount(2))
        {
            if (GlobalMembers.ConActions.ifcansee())
            {
                if (GlobalMembers.ConActions.ifcanshoottarget())
                {
                    GlobalMembers.ConActions.sound(CAPT_ATTACK);
                    GlobalMembers.ConActions.shoot(SHOTSPARK1);
                    GlobalMembers.ConActions.resetactioncount();
                }
                else
                    GlobalMembers.ConActions.Ai(AILIZTHINK);
            }
            else
                GlobalMembers.ConActions.Ai(AILIZGETENEMY);
        }
    }
    private void checklizhit()
    {
        GlobalMembers.ConActions.spawn(BLOOD);
        if (GlobalMembers.ConActions.ifai(AILIZSHRUNK))
        {
            GlobalMembers.ConActions.addkills(1);
            GlobalMembers.ConActions.sound(SQUISHED);
            standard_jibs();
            GlobalMembers.ConActions.killit();
        }
        if (GlobalMembers.ConActions.ifdead())
        {
            if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
            {
                GlobalMembers.ConActions.sound(SOMETHINGFROZE);
                GlobalMembers.ConActions.spritepal(1);
                GlobalMembers.ConActions.Move(0);
                GlobalMembers.ConActions.ConAction ALIZFROZEN = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.strength(0);
                return;
            }
            drop_chaingun();
            if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
            {
                GlobalMembers.ConActions.cstat(0);
                GlobalMembers.ConActions.sound(ACTOR_GROWING);
                GlobalMembers.ConActions.Ai(AILIZGROW);
                return;
            }
            GlobalMembers.ConActions.addkills(1);
            if (GlobalMembers.ConActions.ifwasweapon(RPG))
            {
                GlobalMembers.ConActions.sound(SQUISHED);
                liz_body_jibs();
                standard_jibs();
                GlobalMembers.ConActions.killit();
            }
            else
            if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
            {
                GlobalMembers.ConActions.sound(SQUISHED);
                liz_body_jibs();
                standard_jibs();
                GlobalMembers.ConActions.killit();
            }
            else
            {
                rf();
                GlobalMembers.ConActions.Ai(AILIZDYING);
                if (GlobalMembers.ConActions.ifrnd(64))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
            }
            GlobalMembers.ConActions.sound(CAPT_DYING);
        }
        else
        {
            GlobalMembers.ConActions.sound(CAPT_PAIN);
            if (GlobalMembers.ConActions.ifwasweapon(SHRINKSPARK))
            {
                GlobalMembers.ConActions.sound(ACTOR_SHRINKING);
                GlobalMembers.ConActions.Ai(AILIZSHRUNK);
                return;
            }
            if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                GlobalMembers.ConActions.sound(EXPANDERHIT);
            random_wall_jibs();
            if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifcansee())
                    if (GlobalMembers.ConActions.ifcanshoottarget())
                    {
                        GlobalMembers.ConActions.Ai(AILIZSHOOTENEMY);
                        return;
                    }
        }
    }
    private void lizjumpstate()
    {
        if (GlobalMembers.ConActions.ifaction(ALIZFALL))
        {
            if (GlobalMembers.ConActions.iffloordistl(16))
                GlobalMembers.ConActions.Ai(AILIZGETENEMY);
        }
        else
        if (GlobalMembers.ConActions.ifactioncount(3))
            GlobalMembers.ConActions.ConAction ALIZFALL = new GlobalMembers.ConActions.ConAction();
    }
    private void lizdyingstate()
    {
        if (GlobalMembers.ConActions.ifaction(ALIZLYINGDEAD))
        {
            GlobalMembers.ConActions.strength(0);
            if (GlobalMembers.ConActions.ifhitweapon())
                if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                {
                    GlobalMembers.ConActions.sound(SQUISHED);
                    standard_jibs();
                    GlobalMembers.ConActions.killit();
                }
            if (GlobalMembers.ConActions.ifcount(RESPAWNACTORTIME))
                if (GlobalMembers.ConActions.ifrespawn())
                {
                    GlobalMembers.ConActions.spawn(TRANSPORTERSTAR);
                    GlobalMembers.ConActions.cstat(257);
                    GlobalMembers.ConActions.strength(LIZSTRENGTH);
                    GlobalMembers.ConActions.Ai(AILIZGETENEMY);
                }
        }
        else
        if (GlobalMembers.ConActions.ifai(AILIZDYING))
            if (GlobalMembers.ConActions.ifactioncount(6))
            {
                if (GlobalMembers.ConActions.iffloordistl(8))
                    GlobalMembers.ConActions.sound(THUD);
                GlobalMembers.ConActions.Move(LIZSTOP);
                GlobalMembers.ConActions.ConAction ALIZLYINGDEAD = new GlobalMembers.ConActions.ConAction();
            }
    }
    private void lizdodgestate()
    {
        if (GlobalMembers.ConActions.ifcount(13))
            GlobalMembers.ConActions.Ai(AILIZGETENEMY);
    }
    private void A_LIZMANSTAYPUT()
    {
    }
    private void A_LIZMANSPITTING()
    {
    }
    private void A_LIZMANJUMP()
    {
    }
    private void lizcode()
    {
        checksquished();
        if (GlobalMembers.ConActions.ifai(0))
            GlobalMembers.ConActions.Ai(AILIZGETENEMY);
        else
        if (GlobalMembers.ConActions.ifaction(ALIZLYINGDEAD))
        {
            GlobalMembers.ConActions.fall();
            lizdyingstate();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifaction(ALIZFROZEN))
        {
            if (GlobalMembers.ConActions.ifcount(THAWTIME))
            {
                GlobalMembers.ConActions.Ai(AILIZGETENEMY);
                GlobalMembers.ConActions.getlastpal();
            }
            else
            if (GlobalMembers.ConActions.ifcount(FROZENDRIPTIME))
            {
                if (GlobalMembers.ConActions.ifactioncount(26))
                {
                    GlobalMembers.ConActions.spawn(WATERDRIP);
                    GlobalMembers.ConActions.resetactioncount();
                }
            }
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                GlobalMembers.ConActions.addkills(1);
                if (GlobalMembers.ConActions.ifrnd(84))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.lotsofglass(30);
                GlobalMembers.ConActions.sound(GLASS_BREAKING);
                GlobalMembers.ConActions.killit();
            }
            if (GlobalMembers.ConActions.ifp(pfacing))
                if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                    GlobalMembers.ConActions.pkick();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifai(AILIZJUMPENEMY))
            lizjumpstate();
        else
        {
            GlobalMembers.ConActions.fall();
            if (GlobalMembers.ConActions.ifai(AILIZGETENEMY))
                lizseekstate();
            else
            if (GlobalMembers.ConActions.ifai(AILIZCHARGEENEMY))
                lizseekstate();
            else
            if (GlobalMembers.ConActions.ifai(AILIZDODGE))
                lizdodgestate();
            else
            if (GlobalMembers.ConActions.ifai(AILIZSHOOTENEMY))
                lizshootstate();
            else
            if (GlobalMembers.ConActions.ifai(AILIZFLEENEMY))
                lizfleestate();
            else
            if (GlobalMembers.ConActions.ifai(AILIZTHINK))
                lizthinkstate();
            else
            if (GlobalMembers.ConActions.ifai(AILIZSHRUNK))
                lizshrunkstate();
            else
            if (GlobalMembers.ConActions.ifai(AILIZGROW))
                genericgrowcode();
            else
            if (GlobalMembers.ConActions.ifai(AILIZDYING))
                lizdyingstate();
            else
            if (GlobalMembers.ConActions.ifai(AILIZSPIT))
            {
                if (GlobalMembers.ConActions.ifcount(26))
                    GlobalMembers.ConActions.Ai(AILIZGETENEMY);
                else
                if (GlobalMembers.ConActions.ifcount(18))
                    if (GlobalMembers.ConActions.ifrnd(96))
                    {
                        GlobalMembers.ConActions.shoot(SPIT);
                        GlobalMembers.ConActions.sound(LIZARD_SPIT);
                    }
            }
        }
        if (GlobalMembers.ConActions.ifai(AILIZSHRUNK))
            return;
        if (GlobalMembers.ConActions.ifhitweapon())
            checklizhit();
    }
    private void A_LIZMAN()
    {
        GlobalMembers.ConActions.fall();
        lizcode();
    }
    GlobalMembers.ConActions.ConAction DRONEFRAMES = new GlobalMembers.ConActions.ConAction(0, 1, 7, 1, 1);
    GlobalMembers.ConActions.ConAction DRONESCREAM = new GlobalMembers.ConActions.ConAction(0, 1, 7, 1, 1);
    GlobalMembers.ConActions.MoveAction DRONERUNVELS = new GlobalMembers.ConActions.MoveAction(128, 64);
    GlobalMembers.ConActions.MoveAction DRONERUNUPVELS = new GlobalMembers.ConActions.MoveAction(128, -64);
    GlobalMembers.ConActions.MoveAction DRONEBULLVELS = new GlobalMembers.ConActions.MoveAction(252, -64);
    GlobalMembers.ConActions.MoveAction DRONEBACKWARDS = new GlobalMembers.ConActions.MoveAction(-64, -64);
    GlobalMembers.ConActions.MoveAction DRONERISE = new GlobalMembers.ConActions.MoveAction(32, -32);
    GlobalMembers.ConActions.MoveAction DRONESTOPPED = new GlobalMembers.ConActions.MoveAction(-16);
    GlobalMembers.ConActions.AIAction AIDRONEGETE = new GlobalMembers.ConActions.AIAction(DRONESCREAM, DRONERUNVELS, faceplayerslow, getv);
    GlobalMembers.ConActions.AIAction AIDRONEWAIT = new GlobalMembers.ConActions.AIAction(DRONEFRAMES, DRONESTOPPED, faceplayerslow);
    GlobalMembers.ConActions.AIAction AIDRONEGETUP = new GlobalMembers.ConActions.AIAction(DRONESCREAM, DRONERUNUPVELS, faceplayer, getv);
    GlobalMembers.ConActions.AIAction AIDRONEPULLBACK = new GlobalMembers.ConActions.AIAction(DRONEFRAMES, DRONEBACKWARDS, faceplayerslow);
    GlobalMembers.ConActions.AIAction AIDRONEHIT = new GlobalMembers.ConActions.AIAction(DRONESCREAM, DRONEBACKWARDS, faceplayer);
    GlobalMembers.ConActions.AIAction AIDRONESHRUNK = new GlobalMembers.ConActions.AIAction(DRONEFRAMES, SHRUNKVELS, fleeenemy);
    GlobalMembers.ConActions.AIAction AIDRONEDODGE = new GlobalMembers.ConActions.AIAction(DRONEFRAMES, DRONEBULLVELS, dodgebullet, geth);
    GlobalMembers.ConActions.AIAction AIDRONEDODGEUP = new GlobalMembers.ConActions.AIAction(DRONEFRAMES, DRONERISE, getv, geth);
    private void dronedead()
    {
        GlobalMembers.ConActions.addkills(1);
        GlobalMembers.ConActions.debris(SCRAP1, 8);
        GlobalMembers.ConActions.debris(SCRAP2, 4);
        GlobalMembers.ConActions.debris(SCRAP3, 7);
        GlobalMembers.ConActions.spawn(EXPLOSION2);
        GlobalMembers.ConActions.sound(RPG_EXPLODE);
        GlobalMembers.ConActions.hitradius(2048, 15, 20, 25, 30);
        GlobalMembers.ConActions.killit();
    }
    private void checkdronehitstate()
    {
        if (GlobalMembers.ConActions.ifdead())
            dronedead();
        else
        if (GlobalMembers.ConActions.ifsquished())
            dronedead();
        else
        {
            GlobalMembers.ConActions.sound(DRON_PAIN);
            if (GlobalMembers.ConActions.ifbulletnear())
            {
                if (GlobalMembers.ConActions.ifceilingdistl(64))
                    if (GlobalMembers.ConActions.ifrnd(48))
                        GlobalMembers.ConActions.Ai(AIDRONEDODGE);
                GlobalMembers.ConActions.Ai(AIDRONEDODGEUP);
            }
            else
                GlobalMembers.ConActions.Ai(AIDRONEGETE);
        }
    }
    private void droneshrunkstate()
    {
        if (GlobalMembers.ConActions.ifcount(24))
            GlobalMembers.ConActions.killit();
        else
            GlobalMembers.ConActions.sizeto(1, 1);
    }
    private void checkdronenearplayer()
    {
        if (GlobalMembers.ConActions.ifp(palive))
            if (GlobalMembers.ConActions.ifpdistl(1596))
            {
                if (GlobalMembers.ConActions.ifcount(8))
                {
                    GlobalMembers.ConActions.addkills(1);
                    GlobalMembers.ConActions.sound(DRON_ATTACK2);
                    GlobalMembers.ConActions.debris(SCRAP1, 8);
                    GlobalMembers.ConActions.debris(SCRAP2, 4);
                    GlobalMembers.ConActions.debris(SCRAP3, 7);
                    GlobalMembers.ConActions.spawn(EXPLOSION2);
                    GlobalMembers.ConActions.sound(RPG_EXPLODE);
                    GlobalMembers.ConActions.hitradius(2048, 15, 20, 25, 30);
                    GlobalMembers.ConActions.killit();
                }
                else
                if (GlobalMembers.ConActions.ifcount(3))
// nullop
else
                            GlobalMembers.ConActions.sound(LASERTRIP_ARMING);
            }
    }
    private void dronegetstate()
    {
        if (GlobalMembers.ConActions.ifrnd(192))
        {
            if (GlobalMembers.ConActions.ifcansee())
            {
                if (GlobalMembers.ConActions.ifbulletnear())
                {
                    GlobalMembers.ConActions.Ai(AIDRONEDODGE);
                    return;
                }
                if (GlobalMembers.ConActions.ifmove(DRONEBULLVELS))
                {
                    if (GlobalMembers.ConActions.ifcount(64))
                        GlobalMembers.ConActions.Ai(AIDRONEPULLBACK);
                    else
                    if (GlobalMembers.ConActions.ifnotmoving())
                        if (GlobalMembers.ConActions.ifcount(16))
                            GlobalMembers.ConActions.Ai(AIDRONEPULLBACK);
                }
                else
                if (GlobalMembers.ConActions.ifcount(32))
                {
                    if (GlobalMembers.ConActions.ifp(phigher))
                        GlobalMembers.ConActions.Move(DRONEBULLVELS, geth, getv);
                    else
                        GlobalMembers.ConActions.Move(DRONEBULLVELS, geth);
                }
            }
            else
                if (GlobalMembers.ConActions.ifrnd(1))
                GlobalMembers.ConActions.operate();
        }
    }
    private void dronedodgestate()
    {
        if (GlobalMembers.ConActions.ifai(AIDRONEDODGEUP))
        {
            if (GlobalMembers.ConActions.ifcount(8))
                GlobalMembers.ConActions.Ai(AIDRONEGETE);
            else
            if (GlobalMembers.ConActions.ifnotmoving())
                GlobalMembers.ConActions.Ai(AIDRONEGETE);
        }
        else
        {
            if (GlobalMembers.ConActions.ifcount(8))
                GlobalMembers.ConActions.Ai(AIDRONEGETE);
            else
            if (GlobalMembers.ConActions.ifnotmoving())
                GlobalMembers.ConActions.Ai(AIDRONEGETE);
        }
    }
    private void A_DRONE()
    {
        checkdronenearplayer();
        if (GlobalMembers.ConActions.ifrnd(2))
            GlobalMembers.ConActions.fall();
        else
            GlobalMembers.ConActions.soundonce(DRON_JETSND);
        if (GlobalMembers.ConActions.ifaction(0))
            GlobalMembers.ConActions.Ai(AIDRONEGETE);
        else
        if (GlobalMembers.ConActions.ifai(AIDRONEWAIT))
        {
            if (GlobalMembers.ConActions.ifactioncount(4))
                if (GlobalMembers.ConActions.ifrnd(16))
                    if (GlobalMembers.ConActions.ifcansee())
                    {
                        GlobalMembers.ConActions.sound(DRON_ATTACK1);
                        if (GlobalMembers.ConActions.ifp(phigher))
                            GlobalMembers.ConActions.Ai(AIDRONEGETUP);
                        else
                            GlobalMembers.ConActions.Ai(AIDRONEGETE);
                    }
        }
        else
        if (GlobalMembers.ConActions.ifai(AIDRONEGETE))
            dronegetstate();
        else
        if (GlobalMembers.ConActions.ifai(AIDRONEGETUP))
            dronegetstate();
        else
        if (GlobalMembers.ConActions.ifai(AIDRONEPULLBACK))
        {
            if (GlobalMembers.ConActions.ifcount(32))
                GlobalMembers.ConActions.Ai(AIDRONEWAIT);
        }
        else
        if (GlobalMembers.ConActions.ifai(AIDRONEHIT))
        {
            if (GlobalMembers.ConActions.ifcount(8))
                GlobalMembers.ConActions.Ai(AIDRONEWAIT);
        }
        else
        if (GlobalMembers.ConActions.ifai(AIDRONESHRUNK))
            droneshrunkstate();
        else
        if (GlobalMembers.ConActions.ifai(AIDRONEDODGE))
            dronedodgestate();
        else
        if (GlobalMembers.ConActions.ifai(AIDRONEDODGEUP))
            dronedodgestate();
        if (GlobalMembers.ConActions.ifhitweapon())
            checkdronehitstate();
        if (GlobalMembers.ConActions.ifrnd(1))
            GlobalMembers.ConActions.soundonce(DRON_ROAM);
    }
    GlobalMembers.ConActions.ConAction AOCTAWALK = new GlobalMembers.ConActions.ConAction(0, 3, 5, 1, 15);
    GlobalMembers.ConActions.ConAction AOCTASTAND = new GlobalMembers.ConActions.ConAction(0, 1, 5, 1, 15);
    GlobalMembers.ConActions.ConAction AOCTASCRATCH = new GlobalMembers.ConActions.ConAction(0, 4, 5, 1, 15);
    GlobalMembers.ConActions.ConAction AOCTAHIT = new GlobalMembers.ConActions.ConAction(30, 1, 1, 1, 10);
    GlobalMembers.ConActions.ConAction AOCTASHOOT = new GlobalMembers.ConActions.ConAction(20, 1, 5, 1, 10);
    GlobalMembers.ConActions.ConAction AOCTADYING = new GlobalMembers.ConActions.ConAction(30, 8, 1, 1, 17);
    GlobalMembers.ConActions.ConAction AOCTADEAD = new GlobalMembers.ConActions.ConAction(38, 1, 1, 1, 1);
    GlobalMembers.ConActions.ConAction AOCTAFROZEN = new GlobalMembers.ConActions.ConAction(0, 1, 5);
    GlobalMembers.ConActions.MoveAction OCTAWALKVELS = new GlobalMembers.ConActions.MoveAction(96, -30);
    GlobalMembers.ConActions.MoveAction OCTAUPVELS = new GlobalMembers.ConActions.MoveAction(96, -70);
    GlobalMembers.ConActions.MoveAction OCTASTOPPED = new GlobalMembers.ConActions.MoveAction(0, -30);
    GlobalMembers.ConActions.MoveAction OCTAINWATER = new GlobalMembers.ConActions.MoveAction(96, 24);
    GlobalMembers.ConActions.AIAction AIOCTAGETENEMY = new GlobalMembers.ConActions.AIAction(AOCTAWALK, OCTAWALKVELS, seekplayer);
    GlobalMembers.ConActions.AIAction AIOCTASHOOTENEMY = new GlobalMembers.ConActions.AIAction(AOCTASHOOT, OCTASTOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIOCTASCRATCHENEMY = new GlobalMembers.ConActions.AIAction(AOCTASCRATCH, OCTASTOPPED, faceplayerslow);
    GlobalMembers.ConActions.AIAction AIOCTAHIT = new GlobalMembers.ConActions.AIAction(AOCTAHIT, OCTASTOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIOCTASHRUNK = new GlobalMembers.ConActions.AIAction(AOCTAWALK, SHRUNKVELS, faceplayer);
    GlobalMembers.ConActions.AIAction AIOCTAGROW = new GlobalMembers.ConActions.AIAction(AOCTASTAND, OCTASTOPPED, faceplayerslow);
    GlobalMembers.ConActions.AIAction AIOCTADYING = new GlobalMembers.ConActions.AIAction(AOCTADYING, OCTASTOPPED, faceplayer);
    private void octagetenemystate()
    {
        if (GlobalMembers.ConActions.ifcansee())
        {
            if (GlobalMembers.ConActions.ifactioncount(32))
            {
                if (GlobalMembers.ConActions.ifrnd(48))
                    if (GlobalMembers.ConActions.ifcanshoottarget())
                    {
                        GlobalMembers.ConActions.sound(OCTA_ATTACK1);
                        GlobalMembers.ConActions.Ai(AIOCTASHOOTENEMY);
                        return;
                    }
            }
            else
        if (GlobalMembers.ConActions.ifpdistl(1280))
                GlobalMembers.ConActions.Ai(AIOCTASCRATCHENEMY);
        }
    }
    private void octascratchenemystate()
    {
        if (GlobalMembers.ConActions.ifpdistg(1280))
            GlobalMembers.ConActions.Ai(AIOCTAGETENEMY);
        else
            if (GlobalMembers.ConActions.ifcount(32))
        {
            GlobalMembers.ConActions.resetcount();
            GlobalMembers.ConActions.sound(OCTA_ATTACK2);
            GlobalMembers.ConActions.palfrom(8, 32);
            GlobalMembers.ConActions.addphealth(OCTASCRATCHINGPLAYER);
        }
    }
    private void octashootenemystate()
    {
        if (GlobalMembers.ConActions.ifcount(25))
        {
            if (GlobalMembers.ConActions.ifcount(27))
                GlobalMembers.ConActions.Ai(AIOCTAGETENEMY);
        }
        else
        if (GlobalMembers.ConActions.ifcount(24))
            GlobalMembers.ConActions.shoot(COOLEXPLOSION1);
        else
        if (GlobalMembers.ConActions.ifactioncount(6))
            GlobalMembers.ConActions.resetactioncount();
    }
    private void checkoctahitstate()
    {
        if (GlobalMembers.ConActions.ifwasweapon(SHRINKSPARK))
        {
            GlobalMembers.ConActions.sound(ACTOR_SHRINKING);
            GlobalMembers.ConActions.Ai(AIOCTASHRUNK);
        }
        else
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.sound(SOMETHINGFROZE);
                    GlobalMembers.ConActions.spritepal(1);
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.ConAction AOCTAFROZEN = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                GlobalMembers.ConActions.addkills(1);
                if (GlobalMembers.ConActions.ifwasweapon(RPG))
                {
                    GlobalMembers.ConActions.sound(SQUISHED);
                    standard_jibs();
                    GlobalMembers.ConActions.killit();
                }
                else
                if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                {
                    GlobalMembers.ConActions.sound(SQUISHED);
                    standard_jibs();
                    GlobalMembers.ConActions.killit();
                }
                else
                if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                {
                    GlobalMembers.ConActions.cstat(0);
                    GlobalMembers.ConActions.sound(ACTOR_GROWING);
                    GlobalMembers.ConActions.Ai(AIOCTAGROW);
                    return;
                }
                else
                {
                    rf();
                    GlobalMembers.ConActions.Ai(AIOCTADYING);
                }
                GlobalMembers.ConActions.sound(OCTA_DYING);
            }
            else
            {
                if (GlobalMembers.ConActions.ifwasweapon(RPG))
                {
                    GlobalMembers.ConActions.sound(OCTA_DYING);
                    GlobalMembers.ConActions.addkills(1);
                    standard_jibs();
                    GlobalMembers.ConActions.killit();
                }
                else
                if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                    GlobalMembers.ConActions.sound(EXPANDERHIT);
                GlobalMembers.ConActions.sound(OCTA_PAIN);
                GlobalMembers.ConActions.spawn(BLOOD);
                if (GlobalMembers.ConActions.ifrnd(64))
                    GlobalMembers.ConActions.Ai(AIOCTAHIT);
            }
        }
        random_wall_jibs();
    }
    private void octashrunkstate()
    {
        if (GlobalMembers.ConActions.ifcount(SHRUNKDONECOUNT))
            GlobalMembers.ConActions.Ai(AILIZGETENEMY);
        else
        if (GlobalMembers.ConActions.ifcount(SHRUNKCOUNT))
            GlobalMembers.ConActions.sizeto(40, 40);
        else
            genericshrunkcode();
    }
    private void octadyingstate()
    {
        if (GlobalMembers.ConActions.ifactioncount(8))
        {
            if (GlobalMembers.ConActions.ifrnd(64))
                GlobalMembers.ConActions.spawn(BLOODPOOL);
            GlobalMembers.ConActions.Move(OCTASTOPPED);
            GlobalMembers.ConActions.ConAction AOCTADEAD = new GlobalMembers.ConActions.ConAction();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifactioncount(5))
// nullop
else
    if (GlobalMembers.ConActions.ifactioncount(4))
                    if (GlobalMembers.ConActions.iffloordistl(8))
                        GlobalMembers.ConActions.sound(THUD);
    }
    private void A_OCTABRAINSTAYPUT()
    {
        GlobalMembers.ConActions.Ai(AIOCTAGETENEMY);
        GlobalMembers.ConActions.cactor(OCTABRAIN);
    }
    private void A_OCTABRAIN()
    {
        GlobalMembers.ConActions.fall();
        checksquished();
        if (GlobalMembers.ConActions.ifai(0))
            GlobalMembers.ConActions.Ai(AIOCTAGETENEMY);
        else
        if (GlobalMembers.ConActions.ifaction(AOCTADEAD))
        {
            GlobalMembers.ConActions.strength(0);
            if (GlobalMembers.ConActions.ifcount(RESPAWNACTORTIME))
                if (GlobalMembers.ConActions.ifrespawn())
                {
                    GlobalMembers.ConActions.addkills(-1);
                    GlobalMembers.ConActions.spawn(TRANSPORTERSTAR);
                    GlobalMembers.ConActions.cstat(257);
                    GlobalMembers.ConActions.strength(OCTASTRENGTH);
                    GlobalMembers.ConActions.Ai(AIOCTAGETENEMY);
                }
            if (GlobalMembers.ConActions.ifhitweapon())
                if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                {
                    standard_jibs();
                    GlobalMembers.ConActions.killit();
                }
            return;
        }
        else
        if (GlobalMembers.ConActions.ifaction(AOCTAFROZEN))
        {
            if (GlobalMembers.ConActions.ifcount(THAWTIME))
            {
                GlobalMembers.ConActions.Ai(AIOCTAGETENEMY);
                GlobalMembers.ConActions.getlastpal();
            }
            else
            if (GlobalMembers.ConActions.ifcount(FROZENDRIPTIME))
            {
                if (GlobalMembers.ConActions.ifactioncount(26))
                {
                    GlobalMembers.ConActions.spawn(WATERDRIP);
                    GlobalMembers.ConActions.resetactioncount();
                }
            }
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                GlobalMembers.ConActions.addkills(1);
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                GlobalMembers.ConActions.lotsofglass(30);
                if (GlobalMembers.ConActions.ifrnd(84))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.sound(GLASS_BREAKING);
                GlobalMembers.ConActions.killit();
            }
            if (GlobalMembers.ConActions.ifp(pfacing))
                if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                    GlobalMembers.ConActions.pkick();
            return;
        }
        else
        {
            if (GlobalMembers.ConActions.ifrnd(1))
                GlobalMembers.ConActions.soundonce(OCTA_ROAM);
            if (GlobalMembers.ConActions.ifai(AIOCTAGETENEMY))
                octagetenemystate();
            else
            if (GlobalMembers.ConActions.ifai(AIOCTAHIT))
            {
                if (GlobalMembers.ConActions.ifcount(8))
                    GlobalMembers.ConActions.Ai(AIOCTASHOOTENEMY);
            }
            else
            if (GlobalMembers.ConActions.ifai(AIOCTADYING))
            {
                octadyingstate();
                return;
            }
            else
            if (GlobalMembers.ConActions.ifai(AIOCTASCRATCHENEMY))
                octascratchenemystate();
            else
            if (GlobalMembers.ConActions.ifai(AIOCTASHOOTENEMY))
                octashootenemystate();
            else
            if (GlobalMembers.ConActions.ifai(AIOCTASHRUNK))
            {
                octashrunkstate();
                return;
            }
            else
            if (GlobalMembers.ConActions.ifai(AIOCTAGROW))
                genericgrowcode();
            if (GlobalMembers.ConActions.ifmove(OCTAUPVELS))
// nullop
else
    if (GlobalMembers.ConActions.ifp(phigher))
                        GlobalMembers.ConActions.Move(OCTAUPVELS, seekplayer);
                    else
    if (GlobalMembers.ConActions.ifmove(OCTAINWATER))
// nullop
else
    if (GlobalMembers.ConActions.ifinwater())
                                GlobalMembers.ConActions.Move(OCTAINWATER, seekplayer);
            if (GlobalMembers.ConActions.ifhitweapon())
                checkoctahitstate();
        }
    }
    GlobalMembers.ConActions.ConAction APIGWALK = new GlobalMembers.ConActions.ConAction(0, 4, 5, 1, 20);
    GlobalMembers.ConActions.ConAction APIGRUN = new GlobalMembers.ConActions.ConAction(0, 4, 5, 1, 11);
    GlobalMembers.ConActions.ConAction APIGSHOOT = new GlobalMembers.ConActions.ConAction(30, 2, 5, 1, 58);
    GlobalMembers.ConActions.ConAction APIGCOCK = new GlobalMembers.ConActions.ConAction(25, 1, 5, 1, 16);
    GlobalMembers.ConActions.ConAction APIGSTAND = new GlobalMembers.ConActions.ConAction(30, 1, 5, 1, 1);
    GlobalMembers.ConActions.ConAction APIGDIVE = new GlobalMembers.ConActions.ConAction(40, 2, 5, 1, 40);
    GlobalMembers.ConActions.ConAction APIGDIVESHOOT = new GlobalMembers.ConActions.ConAction(45, 2, 5, 1, 58);
    GlobalMembers.ConActions.ConAction APIGDYING = new GlobalMembers.ConActions.ConAction(55, 5, 1, 1, 15);
    GlobalMembers.ConActions.ConAction APIGHIT = new GlobalMembers.ConActions.ConAction(55, 1, 1, 1, 10);
    GlobalMembers.ConActions.ConAction APIGDEAD = new GlobalMembers.ConActions.ConAction(60, 1, 1, 1, 1);
    GlobalMembers.ConActions.ConAction APIGFROZEN = new GlobalMembers.ConActions.ConAction(0, 1, 5);
    GlobalMembers.ConActions.ConAction APIGGROW = new GlobalMembers.ConActions.ConAction(0);
    GlobalMembers.ConActions.MoveAction PIGWALKVELS = new GlobalMembers.ConActions.MoveAction(72);
    GlobalMembers.ConActions.MoveAction PIGRUNVELS = new GlobalMembers.ConActions.MoveAction(108);
    GlobalMembers.ConActions.MoveAction PIGSTOPPED = new GlobalMembers.ConActions.MoveAction();
    GlobalMembers.ConActions.AIAction AIPIGSEEKENEMY = new GlobalMembers.ConActions.AIAction(APIGWALK, PIGWALKVELS, seekplayer);
    GlobalMembers.ConActions.AIAction AIPIGSHOOTENEMY = new GlobalMembers.ConActions.AIAction(APIGSHOOT, PIGSTOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIPIGFLEEENEMY = new GlobalMembers.ConActions.AIAction(APIGWALK, PIGWALKVELS, fleeenemy);
    GlobalMembers.ConActions.AIAction AIPIGSHOOT = new GlobalMembers.ConActions.AIAction(APIGSHOOT, PIGSTOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIPIGDODGE = new GlobalMembers.ConActions.AIAction(APIGRUN, PIGRUNVELS, dodgebullet);
    GlobalMembers.ConActions.AIAction AIPIGCHARGE = new GlobalMembers.ConActions.AIAction(APIGRUN, PIGRUNVELS, seekplayer);
    GlobalMembers.ConActions.AIAction AIPIGDIVING = new GlobalMembers.ConActions.AIAction(APIGDIVE, PIGSTOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIPIGDYING = new GlobalMembers.ConActions.AIAction(APIGDYING, PIGSTOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIPIGSHRINK = new GlobalMembers.ConActions.AIAction(APIGWALK, SHRUNKVELS, fleeenemy);
    GlobalMembers.ConActions.AIAction AIPIGGROW = new GlobalMembers.ConActions.AIAction(APIGGROW, PIGSTOPPED, faceplayerslow);
    GlobalMembers.ConActions.AIAction AIPIGHIT = new GlobalMembers.ConActions.AIAction(APIGHIT, PIGSTOPPED, faceplayer);
    private void pigseekenemystate()
    {
        if (GlobalMembers.ConActions.ifai(AIPIGCHARGE))
        {
            if (GlobalMembers.ConActions.ifcansee())
                if (GlobalMembers.ConActions.ifpdistl(3084))
                {
                    if (GlobalMembers.ConActions.ifnotmoving())
                        GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
                    else
                        GlobalMembers.ConActions.Ai(AIPIGDIVING);
                }
            return;
        }
        else
        if (GlobalMembers.ConActions.iffloordistl(32))
        {
            if (GlobalMembers.ConActions.ifpdistg(4096))
            {
                if (GlobalMembers.ConActions.ifactornotstayput())
                    GlobalMembers.ConActions.Ai(AIPIGCHARGE);
            }
            if (GlobalMembers.ConActions.ifrnd(8))
            {
                if (GlobalMembers.ConActions.ifbulletnear())
                    GlobalMembers.ConActions.Ai(AIPIGDODGE);
            }
        }
        if (GlobalMembers.ConActions.ifrnd(128))
            if (GlobalMembers.ConActions.ifcansee())
            {
                if (GlobalMembers.ConActions.ifai(AIPIGDODGE))
                {
                    if (GlobalMembers.ConActions.ifcount(32))
                        GlobalMembers.ConActions.Ai(AIPIGCHARGE);
                    return;
                }
                if (GlobalMembers.ConActions.iffloordistl(32))
                {
                    if (GlobalMembers.ConActions.ifpdistl(1024))
                        if (GlobalMembers.ConActions.ifp(palive))
                            if (GlobalMembers.ConActions.ifcanshoottarget())
                            {
                                GlobalMembers.ConActions.Ai(AIPIGSHOOTENEMY);
                                return;
                            }
                    if (GlobalMembers.ConActions.ifcount(48))
                    {
                        if (GlobalMembers.ConActions.ifrnd(8))
                            if (GlobalMembers.ConActions.ifp(palive))
                                if (GlobalMembers.ConActions.ifcanshoottarget())
                                {
                                    if (GlobalMembers.ConActions.ifrnd(192))
                                        GlobalMembers.ConActions.Ai(AIPIGSHOOTENEMY);
                                    else
                                        GlobalMembers.ConActions.Ai(AIPIGDIVING);
                                    return;
                                }
                    }
                }
            }
    }
    private void pigshootenemystate()
    {
        {
            if (GlobalMembers.ConActions.ifcount(12))
// nullop
else
    if (GlobalMembers.ConActions.ifcount(11))
                    {
                        if (GlobalMembers.ConActions.ifcanshoottarget())
                        {
                            GlobalMembers.ConActions.sound(PIG_ATTACK);
                            GlobalMembers.ConActions.shoot(SHOTGUN);
                            GlobalMembers.ConActions.shoot(SHOTGUN);
                            GlobalMembers.ConActions.shoot(SHOTGUN);
                            GlobalMembers.ConActions.shoot(SHOTGUN);
                            GlobalMembers.ConActions.shoot(SHOTGUN);
                        }
                        else
                            GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
                    }
            if (GlobalMembers.ConActions.ifcount(25))
// nullop
else
    if (GlobalMembers.ConActions.ifcount(24))
                    {
                        GlobalMembers.ConActions.ConAction APIGCOCK = new GlobalMembers.ConActions.ConAction();
                        GlobalMembers.ConActions.sound(SHOTGUN_COCK);
                    }
            if (GlobalMembers.ConActions.ifcount(48))
// nullop
else
    if (GlobalMembers.ConActions.ifcount(47))
                    {
                        if (GlobalMembers.ConActions.ifcanshoottarget())
                        {
                            GlobalMembers.ConActions.sound(PIG_ATTACK);
                            GlobalMembers.ConActions.shoot(SHOTGUN);
                            GlobalMembers.ConActions.shoot(SHOTGUN);
                            GlobalMembers.ConActions.shoot(SHOTGUN);
                            GlobalMembers.ConActions.shoot(SHOTGUN);
                            GlobalMembers.ConActions.shoot(SHOTGUN);
                        }
                        else
                            GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
                    }
            if (GlobalMembers.ConActions.ifcount(60))
// nullop
else
    if (GlobalMembers.ConActions.ifcount(59))
                    {
                        GlobalMembers.ConActions.ConAction APIGCOCK = new GlobalMembers.ConActions.ConAction();
                        GlobalMembers.ConActions.sound(SHOTGUN_COCK);
                    }
            if (GlobalMembers.ConActions.ifcount(72))
            {
                if (GlobalMembers.ConActions.ifrnd(64))
                    GlobalMembers.ConActions.resetcount();
                else
                {
                    if (GlobalMembers.ConActions.ifpdistl(768))
                        GlobalMembers.ConActions.Ai(AIPIGFLEEENEMY);
                    else
                        GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
                }
            }
            if (GlobalMembers.ConActions.ifaction(APIGCOCK))
                if (GlobalMembers.ConActions.ifactioncount(2))
                    GlobalMembers.ConActions.ConAction APIGSHOOT = new GlobalMembers.ConActions.ConAction();
        }
else
            GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
    }
    private void pigfleeenemystate()
    {
        if (GlobalMembers.ConActions.ifactioncount(8))
            GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
        else
        if (GlobalMembers.ConActions.ifnotmoving())
            GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
    }
    private void pigdivestate()
    {
        if (GlobalMembers.ConActions.ifaction(APIGDIVESHOOT))
        {
            if (GlobalMembers.ConActions.ifcansee())
            {
                if (GlobalMembers.ConActions.ifcount(12))
// nullop
else
    if (GlobalMembers.ConActions.ifcount(11))
                        {
                            if (GlobalMembers.ConActions.ifcanshoottarget())
                            {
                                GlobalMembers.ConActions.sound(PIG_ATTACK);
                                GlobalMembers.ConActions.shoot(SHOTGUN);
                                GlobalMembers.ConActions.shoot(SHOTGUN);
                                GlobalMembers.ConActions.shoot(SHOTGUN);
                                GlobalMembers.ConActions.shoot(SHOTGUN);
                            }
                            else
                                GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
                        }
                if (GlobalMembers.ConActions.ifcount(25))
// nullop
else
    if (GlobalMembers.ConActions.ifcount(24))
                            GlobalMembers.ConActions.sound(SHOTGUN_COCK);
                if (GlobalMembers.ConActions.ifcount(48))
// nullop
else
    if (GlobalMembers.ConActions.ifcount(47))
                        {
                            if (GlobalMembers.ConActions.ifcanshoottarget())
                            {
                                GlobalMembers.ConActions.sound(PIG_ATTACK);
                                GlobalMembers.ConActions.shoot(SHOTGUN);
                                GlobalMembers.ConActions.shoot(SHOTGUN);
                                GlobalMembers.ConActions.shoot(SHOTGUN);
                                GlobalMembers.ConActions.shoot(SHOTGUN);
                            }
                            else
                                GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
                        }
                if (GlobalMembers.ConActions.ifcount(60))
// nullop
else
    if (GlobalMembers.ConActions.ifcount(59))
                        {
                            GlobalMembers.ConActions.sound(SHOTGUN_COCK);
                            if (GlobalMembers.ConActions.ifgapzl(32))
                                GlobalMembers.ConActions.Ai(AIPIGDIVING);
                            else
                            {
                                if (GlobalMembers.ConActions.ifpdistl(4096))
                                    GlobalMembers.ConActions.Ai(AIPIGFLEEENEMY);
                                else
                                    GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
                            }
                        }
            }
            else
                if (GlobalMembers.ConActions.ifgapzl(32))
                GlobalMembers.ConActions.Ai(AIPIGDIVING);
            else
                GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
        }
        else
        if (GlobalMembers.ConActions.ifactioncount(2))
            if (GlobalMembers.ConActions.ifp(palive))
            {
                GlobalMembers.ConActions.resetcount();
                GlobalMembers.ConActions.ConAction APIGDIVESHOOT = new GlobalMembers.ConActions.ConAction();
            }
    }
    private void checkpighitstate()
    {
        GlobalMembers.ConActions.spawn(BLOOD);
        if (GlobalMembers.ConActions.ifdead())
        {
            random_wall_jibs();
            if (GlobalMembers.ConActions.ifrnd(16))
                GlobalMembers.ConActions.spawn(SHIELD);
            else
                drop_shotgun();
            if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
            {
                GlobalMembers.ConActions.sound(ACTOR_GROWING);
                GlobalMembers.ConActions.Ai(AIPIGGROW);
                return;
            }
            GlobalMembers.ConActions.addkills(1);
            if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
            {
                GlobalMembers.ConActions.sound(SOMETHINGFROZE);
                GlobalMembers.ConActions.spritepal(1);
                GlobalMembers.ConActions.Move(0);
                GlobalMembers.ConActions.ConAction APIGFROZEN = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.strength(0);
                return;
            }
            if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
            {
                GlobalMembers.ConActions.sound(SQUISHED);
                standard_jibs();
                GlobalMembers.ConActions.killit();
            }
            else
            if (GlobalMembers.ConActions.ifwasweapon(RPG))
            {
                GlobalMembers.ConActions.sound(SQUISHED);
                standard_jibs();
                GlobalMembers.ConActions.killit();
            }
            else
                GlobalMembers.ConActions.Ai(AIPIGDYING);
            GlobalMembers.ConActions.sound(PIG_DYING);
        }
        else
        {
            GlobalMembers.ConActions.sound(PIG_PAIN);
            random_wall_jibs();
            if (GlobalMembers.ConActions.ifwasweapon(SHRINKSPARK))
            {
                GlobalMembers.ConActions.sound(ACTOR_SHRINKING);
                GlobalMembers.ConActions.Ai(AIPIGSHRINK);
            }
            else
            if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                GlobalMembers.ConActions.sound(EXPANDERHIT);
            else
            if (GlobalMembers.ConActions.ifrnd(32))
                GlobalMembers.ConActions.Ai(AIPIGHIT);
            else
            if (GlobalMembers.ConActions.ifrnd(64))
                GlobalMembers.ConActions.Ai(AIPIGSHOOTENEMY);
            else
            if (GlobalMembers.ConActions.ifrnd(64))
            {
                GlobalMembers.ConActions.Ai(AIPIGDIVING);
                GlobalMembers.ConActions.ConAction APIGDIVESHOOT = new GlobalMembers.ConActions.ConAction();
            }
        }
    }
    private void pigshrinkstate()
    {
        if (GlobalMembers.ConActions.ifcount(SHRUNKDONECOUNT))
            GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
        else
        if (GlobalMembers.ConActions.ifcount(SHRUNKCOUNT))
            GlobalMembers.ConActions.sizeto(48, 40);
        else
            genericshrunkcode();
    }
    private void pigdyingstate()
    {
        if (GlobalMembers.ConActions.ifactioncount(5))
        {
            if (GlobalMembers.ConActions.ifrnd(64))
                GlobalMembers.ConActions.spawn(BLOODPOOL);
            rf();
            if (GlobalMembers.ConActions.iffloordistl(8))
                GlobalMembers.ConActions.sound(THUD);
            GlobalMembers.ConActions.ConAction APIGDEAD = new GlobalMembers.ConActions.ConAction();
            GlobalMembers.ConActions.Move(PIGSTOPPED);
            return;
        }
    }
    private void A_PIGCOPDIVE()
    {
        GlobalMembers.ConActions.Ai(AIPIGDIVING);
        GlobalMembers.ConActions.ConAction APIGDIVESHOOT = new GlobalMembers.ConActions.ConAction();
        GlobalMembers.ConActions.cactor(PIGCOP);
    }
    private void A_PIGCOPSTAYPUT()
    {
        GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
        GlobalMembers.ConActions.cactor(PIGCOP);
    }
    private void A_PIGCOP()
    {
        GlobalMembers.ConActions.fall();
        checksquished();
        if (GlobalMembers.ConActions.ifaction(APIGSTAND))
            GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
        else
        if (GlobalMembers.ConActions.ifaction(APIGDEAD))
        {
            if (GlobalMembers.ConActions.ifrespawn())
                if (GlobalMembers.ConActions.ifcount(RESPAWNACTORTIME))
                {
                    GlobalMembers.ConActions.spawn(TRANSPORTERSTAR);
                    GlobalMembers.ConActions.cstat(257);
                    GlobalMembers.ConActions.strength(PIGCOPSTRENGTH);
                    GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
                }
                else
                {
                    GlobalMembers.ConActions.strength(0);
                    if (GlobalMembers.ConActions.ifhitweapon())
                        if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                        {
                            GlobalMembers.ConActions.sound(SQUISHED);
                            standard_jibs();
                            GlobalMembers.ConActions.killit();
                        }
                    return;
                }
        }
        else
        if (GlobalMembers.ConActions.ifaction(APIGFROZEN))
        {
            if (GlobalMembers.ConActions.ifcount(THAWTIME))
            {
                GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
                GlobalMembers.ConActions.getlastpal();
            }
            else
            if (GlobalMembers.ConActions.ifcount(FROZENDRIPTIME))
                if (GlobalMembers.ConActions.ifrnd(8))
                    GlobalMembers.ConActions.spawn(WATERDRIP);
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                GlobalMembers.ConActions.addkills(1);
                GlobalMembers.ConActions.lotsofglass(30);
                if (GlobalMembers.ConActions.ifrnd(84))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.sound(GLASS_BREAKING);
                GlobalMembers.ConActions.killit();
            }
            if (GlobalMembers.ConActions.ifp(pfacing))
                if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                    GlobalMembers.ConActions.pkick();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifai(AIPIGDYING))
            pigdyingstate();
        else
        if (GlobalMembers.ConActions.ifai(AIPIGHIT))
        {
            if (GlobalMembers.ConActions.ifactioncount(3))
                GlobalMembers.ConActions.Ai(AIPIGSEEKENEMY);
        }
        else
        if (GlobalMembers.ConActions.ifai(AIPIGSHRINK))
            pigshrinkstate();
        else
        {
            if (GlobalMembers.ConActions.ifai(AIPIGSEEKENEMY))
                pigseekenemystate();
            else
            if (GlobalMembers.ConActions.ifai(AIPIGDODGE))
                pigseekenemystate();
            else
            if (GlobalMembers.ConActions.ifai(AIPIGSHOOTENEMY))
                pigshootenemystate();
            else
            if (GlobalMembers.ConActions.ifai(AIPIGGROW))
                genericgrowcode();
            else
            if (GlobalMembers.ConActions.ifai(AIPIGFLEEENEMY))
                pigfleeenemystate();
            else
            if (GlobalMembers.ConActions.ifai(AIPIGDIVING))
                pigdivestate();
            else
            if (GlobalMembers.ConActions.ifai(AIPIGCHARGE))
                pigseekenemystate();
            if (GlobalMembers.ConActions.ifhitweapon())
                checkpighitstate();
            if (GlobalMembers.ConActions.ifrnd(1))
            {
                if (GlobalMembers.ConActions.ifrnd(32))
                    GlobalMembers.ConActions.soundonce(PIG_ROAM);
                else
                if (GlobalMembers.ConActions.ifrnd(64))
                    GlobalMembers.ConActions.soundonce(PIG_ROAM2);
                else
                    GlobalMembers.ConActions.soundonce(PIG_ROAM3);
            }
        }
    }
    GlobalMembers.ConActions.ConAction ABOSS1WALK = new GlobalMembers.ConActions.ConAction(0, 4, 5, 1, 12);
    GlobalMembers.ConActions.ConAction ABOSS1FROZEN = new GlobalMembers.ConActions.ConAction(30, 1, 5);
    GlobalMembers.ConActions.ConAction ABOSS1RUN = new GlobalMembers.ConActions.ConAction(0, 6, 5, 1, 5);
    GlobalMembers.ConActions.ConAction ABOSS1SHOOT = new GlobalMembers.ConActions.ConAction(30, 2, 5, 1, 4);
    GlobalMembers.ConActions.ConAction ABOSS1LOB = new GlobalMembers.ConActions.ConAction(40, 2, 5, 1, 35);
    GlobalMembers.ConActions.ConAction ABOSS1DYING = new GlobalMembers.ConActions.ConAction(50, 5, 1, 1, 35);
    GlobalMembers.ConActions.ConAction BOSS1FLINTCH = new GlobalMembers.ConActions.ConAction(50, 1, 1, 1, 1);
    GlobalMembers.ConActions.ConAction ABOSS1DEAD = new GlobalMembers.ConActions.ConAction(55);
    GlobalMembers.ConActions.MoveAction PALBOSS1SHRUNKRUNVELS = new GlobalMembers.ConActions.MoveAction(32);
    GlobalMembers.ConActions.MoveAction PALBOSS1RUNVELS = new GlobalMembers.ConActions.MoveAction(128);
    GlobalMembers.ConActions.MoveAction BOSS1WALKVELS = new GlobalMembers.ConActions.MoveAction(208);
    GlobalMembers.ConActions.MoveAction BOSS1RUNVELS = new GlobalMembers.ConActions.MoveAction(296);
    GlobalMembers.ConActions.MoveAction BOSS1STOPPED = new GlobalMembers.ConActions.MoveAction();
    GlobalMembers.ConActions.AIAction AIBOSS1SEEKENEMY = new GlobalMembers.ConActions.AIAction(ABOSS1WALK, BOSS1WALKVELS, seekplayer);
    GlobalMembers.ConActions.AIAction AIBOSS1RUNENEMY = new GlobalMembers.ConActions.AIAction(ABOSS1RUN, BOSS1RUNVELS, faceplayer);
    GlobalMembers.ConActions.AIAction AIBOSS1SHOOTENEMY = new GlobalMembers.ConActions.AIAction(ABOSS1SHOOT, BOSS1STOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIBOSS1LOBBED = new GlobalMembers.ConActions.AIAction(ABOSS1LOB, BOSS1STOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIBOSS1DYING = new GlobalMembers.ConActions.AIAction(ABOSS1DYING, BOSS1STOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIBOSS1PALSHRINK = new GlobalMembers.ConActions.AIAction(ABOSS1WALK, PALBOSS1SHRUNKRUNVELS, furthestdir);
    private void boss1palshrunkstate()
    {
        if (GlobalMembers.ConActions.ifcount(SHRUNKDONECOUNT))
            GlobalMembers.ConActions.Ai(AITROOPSEEKENEMY);
        else
        if (GlobalMembers.ConActions.ifcount(SHRUNKCOUNT))
            GlobalMembers.ConActions.sizeto(40, 40);
        else
            genericshrunkcode();
    }
    private void checkboss1seekstate()
    {
        GlobalMembers.ConActions.Ai(AIBOSS1SEEKENEMY);
        if (GlobalMembers.ConActions.ifspritepal(0))
// nullop
else
                    GlobalMembers.ConActions.Move(PALBOSS1RUNVELS, seekplayer);
    }
    private void boss1runenemystate()
    {
        if (GlobalMembers.ConActions.ifpdistl(2048))
        {
            if (GlobalMembers.ConActions.ifp(palive))
                GlobalMembers.ConActions.Ai(AIBOSS1SHOOTENEMY);
            return;
        }
        else
        if (GlobalMembers.ConActions.ifcansee())
        {
            if (GlobalMembers.ConActions.ifactioncount(6))
            {
                if (GlobalMembers.ConActions.ifcanshoottarget())
                {
                    GlobalMembers.ConActions.resetactioncount();
                    GlobalMembers.ConActions.sound(BOS1_WALK);
                }
                else
                    GlobalMembers.ConActions.Ai(AIBOSS1SEEKENEMY);
            }
        }
        else
            GlobalMembers.ConActions.Ai(AIBOSS1SEEKENEMY);
    }
    private void boss1seekenemystate()
    {
        if (GlobalMembers.ConActions.ifrnd(2))
            GlobalMembers.ConActions.soundonce(BOS1_ROAM);
        else
        if (GlobalMembers.ConActions.ifactioncount(6))
        {
            GlobalMembers.ConActions.resetactioncount();
            GlobalMembers.ConActions.sound(BOS1_WALK);
        }
        if (GlobalMembers.ConActions.ifpdistl(2548))
            if (GlobalMembers.ConActions.ifp(palive))
            {
                GlobalMembers.ConActions.Ai(AIBOSS1SHOOTENEMY);
                return;
            }
        if (GlobalMembers.ConActions.ifcansee())
            if (GlobalMembers.ConActions.ifcount(32))
            {
                if (GlobalMembers.ConActions.ifrnd(32))
                {
                    if (GlobalMembers.ConActions.ifp(palive))
                        if (GlobalMembers.ConActions.ifcanshoottarget())
                            GlobalMembers.ConActions.Ai(AIBOSS1SHOOTENEMY);
                }
                else
            if (GlobalMembers.ConActions.ifpdistg(2548))
                    if (GlobalMembers.ConActions.ifrnd(192))
                        if (GlobalMembers.ConActions.ifcanshoottarget())
                        {
                            if (GlobalMembers.ConActions.ifrnd(64))
                            {
                                GlobalMembers.ConActions.Ai(AIBOSS1RUNENEMY);
                                if (GlobalMembers.ConActions.ifspritepal(0))
// nullop
else
                                            GlobalMembers.ConActions.Move(PALBOSS1RUNVELS, seekplayer);
                            }
                            else
                                GlobalMembers.ConActions.Ai(AIBOSS1LOBBED);
                        }
            }
    }
    private void boss1dyingstate()
    {
        if (GlobalMembers.ConActions.ifaction(ABOSS1DEAD))
        {
            if (GlobalMembers.ConActions.ifspritepal(0))
                return;
            if (GlobalMembers.ConActions.ifrespawn())
                if (GlobalMembers.ConActions.ifcount(RESPAWNACTORTIME))
                {
                    GlobalMembers.ConActions.spawn(TRANSPORTERSTAR);
                    GlobalMembers.ConActions.cstat(257);
                    GlobalMembers.ConActions.strength(PIGCOPSTRENGTH);
                    checkboss1seekstate();
                }
                else
                {
                    GlobalMembers.ConActions.strength(0);
                    if (GlobalMembers.ConActions.ifhitweapon())
                        if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                        {
                            GlobalMembers.ConActions.sound(SQUISHED);
                            standard_jibs();
                            GlobalMembers.ConActions.killit();
                        }
                    return;
                }
        }
        if (GlobalMembers.ConActions.ifactioncount(5))
        {
            if (GlobalMembers.ConActions.iffloordistl(8))
                GlobalMembers.ConActions.sound(THUD);
            GlobalMembers.ConActions.ConAction ABOSS1DEAD = new GlobalMembers.ConActions.ConAction();
            GlobalMembers.ConActions.cstat(0);
            if (GlobalMembers.ConActions.ifspritepal(0))
                GlobalMembers.ConActions.endofgame(52);
        }
    }
    private void boss1lobbedstate()
    {
        if (GlobalMembers.ConActions.ifcansee())
        {
            if (GlobalMembers.ConActions.ifactioncount(2))
            {
                GlobalMembers.ConActions.resetactioncount();
                GlobalMembers.ConActions.sound(BOS1_ATTACK2);
                GlobalMembers.ConActions.shoot(MORTER);
            }
            else
            if (GlobalMembers.ConActions.ifcount(64))
                if (GlobalMembers.ConActions.ifrnd(16))
                    checkboss1seekstate();
        }
        else
            checkboss1seekstate();
    }
    private void boss1shootenemy()
    {
        if (GlobalMembers.ConActions.ifcount(72))
            checkboss1seekstate();
        else
        if (GlobalMembers.ConActions.ifaction(ABOSS1SHOOT))
            if (GlobalMembers.ConActions.ifactioncount(2))
            {
                GlobalMembers.ConActions.sound(BOS1_ATTACK1);
                GlobalMembers.ConActions.shoot(SHOTSPARK1);
                GlobalMembers.ConActions.shoot(SHOTSPARK1);
                GlobalMembers.ConActions.shoot(SHOTSPARK1);
                GlobalMembers.ConActions.shoot(SHOTSPARK1);
                GlobalMembers.ConActions.shoot(SHOTSPARK1);
                GlobalMembers.ConActions.shoot(SHOTSPARK1);
                GlobalMembers.ConActions.resetactioncount();
            }
    }
    private void checkboss1hitstate()
    {
        if (GlobalMembers.ConActions.ifrnd(2))
            GlobalMembers.ConActions.spawn(BLOODPOOL);
        if (GlobalMembers.ConActions.ifdead())
        {
            if (GlobalMembers.ConActions.ifspritepal(0))
                GlobalMembers.ConActions.globalsound(DUKE_TALKTOBOSSFALL);
            else
            {
                if (GlobalMembers.ConActions.ifrnd(64))
                    GlobalMembers.ConActions.globalsound(DUKE_TALKTOBOSSFALL);
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.sound(SOMETHINGFROZE);
                    GlobalMembers.ConActions.spritepal(1);
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.ConAction ABOSS1FROZEN = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
            }
            GlobalMembers.ConActions.sound(BOS1_DYING);
            GlobalMembers.ConActions.addkills(1);
            GlobalMembers.ConActions.Ai(AIBOSS1DYING);
        }
        else
        {
            if (GlobalMembers.ConActions.ifrnd(32))
            {
                GlobalMembers.ConActions.ConAction BOSS1FLINTCH = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.Move(0);
            }
            if (GlobalMembers.ConActions.ifspritepal(0))
// nullop
else
    if (GlobalMembers.ConActions.ifwasweapon(SHRINKSPARK))
                    {
                        GlobalMembers.ConActions.sound(ACTOR_SHRINKING);
                        GlobalMembers.ConActions.Ai(AIBOSS1PALSHRINK);
                        GlobalMembers.ConActions.cstat(0);
                        return;
                    }
            GlobalMembers.ConActions.soundonce(BOS1_PAIN);
            GlobalMembers.ConActions.debris(SCRAP1, 1);
            GlobalMembers.ConActions.guts(JIBS6, 1);
        }
    }
    private void boss1code()
    {
        if (GlobalMembers.ConActions.ifaction(ABOSS1FROZEN))
        {
            if (GlobalMembers.ConActions.ifcount(THAWTIME))
            {
                GlobalMembers.ConActions.Ai(AIBOSS1SEEKENEMY);
                GlobalMembers.ConActions.spritepal(21);
            }
            else
            if (GlobalMembers.ConActions.ifcount(FROZENDRIPTIME))
            {
                if (GlobalMembers.ConActions.ifactioncount(26))
                {
                    GlobalMembers.ConActions.spawn(WATERDRIP);
                    GlobalMembers.ConActions.resetactioncount();
                }
            }
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                GlobalMembers.ConActions.addkills(1);
                GlobalMembers.ConActions.lotsofglass(30);
                if (GlobalMembers.ConActions.ifrnd(84))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.sound(GLASS_BREAKING);
                GlobalMembers.ConActions.killit();
            }
            if (GlobalMembers.ConActions.ifp(pfacing))
                if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                    GlobalMembers.ConActions.pkick();
            return;
        }
        if (GlobalMembers.ConActions.ifai(0))
        {
            if (GlobalMembers.ConActions.ifspritepal(0))
                GlobalMembers.ConActions.Ai(AIBOSS1RUNENEMY);
            else
            {
                GlobalMembers.ConActions.strength(BOSS1PALSTRENGTH);
                GlobalMembers.ConActions.Ai(AIBOSS1SHOOTENEMY);
            }
        }
        else
        if (GlobalMembers.ConActions.ifaction(BOSS1FLINTCH))
        {
            if (GlobalMembers.ConActions.ifactioncount(3))
                GlobalMembers.ConActions.Ai(AIBOSS1SHOOTENEMY);
        }
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS1SEEKENEMY))
            boss1seekenemystate();
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS1RUNENEMY))
            boss1runenemystate();
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS1SHOOTENEMY))
            boss1shootenemy();
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS1LOBBED))
            boss1lobbedstate();
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS1PALSHRINK))
            boss1palshrunkstate();
        if (GlobalMembers.ConActions.ifai(AIBOSS1DYING))
            boss1dyingstate();
        else
        {
            if (GlobalMembers.ConActions.ifhitweapon())
                checkboss1hitstate();
            else
                if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifspritepal(0))
                    if (GlobalMembers.ConActions.ifpdistl(1280))
                    {
                        GlobalMembers.ConActions.addphealth(-1000);
                        GlobalMembers.ConActions.palfrom(63, 63);
                    }
        }
    }
    private void A_BOSS1STAYPUT()
    {
    }
    private void A_BOSS1()
    {
        boss1code();
    }
    GlobalMembers.ConActions.ConAction ABOSS2WALK = new GlobalMembers.ConActions.ConAction(0, 4, 5, 1, 30);
    GlobalMembers.ConActions.ConAction ABOSS2FROZEN = new GlobalMembers.ConActions.ConAction(0, 1, 5);
    GlobalMembers.ConActions.ConAction ABOSS2RUN = new GlobalMembers.ConActions.ConAction(0, 4, 5, 1, 15);
    GlobalMembers.ConActions.ConAction ABOSS2SHOOT = new GlobalMembers.ConActions.ConAction(20, 2, 5, 1, 15);
    GlobalMembers.ConActions.ConAction ABOSS2LOB = new GlobalMembers.ConActions.ConAction(30, 2, 5, 1, 105);
    GlobalMembers.ConActions.ConAction ABOSS2DYING = new GlobalMembers.ConActions.ConAction(40, 8, 1, 1, 35);
    GlobalMembers.ConActions.ConAction BOSS2FLINTCH = new GlobalMembers.ConActions.ConAction(40, 1, 1, 1, 1);
    GlobalMembers.ConActions.ConAction ABOSS2DEAD = new GlobalMembers.ConActions.ConAction(48);
    GlobalMembers.ConActions.MoveAction PALBOSS2SHRUNKRUNVELS = new GlobalMembers.ConActions.MoveAction(32);
    GlobalMembers.ConActions.MoveAction PALBOSS2RUNVELS = new GlobalMembers.ConActions.MoveAction(84);
    GlobalMembers.ConActions.MoveAction BOSS2WALKVELS = new GlobalMembers.ConActions.MoveAction(192);
    GlobalMembers.ConActions.MoveAction BOSS2RUNVELS = new GlobalMembers.ConActions.MoveAction(256);
    GlobalMembers.ConActions.MoveAction BOSS2STOPPED = new GlobalMembers.ConActions.MoveAction();
    GlobalMembers.ConActions.AIAction AIBOSS2SEEKENEMY = new GlobalMembers.ConActions.AIAction(ABOSS2WALK, BOSS2WALKVELS, seekplayer);
    GlobalMembers.ConActions.AIAction AIBOSS2RUNENEMY = new GlobalMembers.ConActions.AIAction(ABOSS2RUN, BOSS2RUNVELS, faceplayer);
    GlobalMembers.ConActions.AIAction AIBOSS2SHOOTENEMY = new GlobalMembers.ConActions.AIAction(ABOSS2SHOOT, BOSS2STOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIBOSS2LOBBED = new GlobalMembers.ConActions.AIAction(ABOSS2LOB, BOSS2STOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIBOSS2DYING = new GlobalMembers.ConActions.AIAction(ABOSS2DYING, BOSS2STOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIBOSS2PALSHRINK = new GlobalMembers.ConActions.AIAction(ABOSS2WALK, PALBOSS2SHRUNKRUNVELS, furthestdir);
    private void boss2palshrunkstate()
    {
        if (GlobalMembers.ConActions.ifcount(SHRUNKDONECOUNT))
        {
            GlobalMembers.ConActions.cstat(257);
            GlobalMembers.ConActions.Ai(AITROOPSEEKENEMY);
        }
        else
        if (GlobalMembers.ConActions.ifcount(SHRUNKCOUNT))
            GlobalMembers.ConActions.sizeto(40, 40);
        else
            genericshrunkcode();
    }
    private void checkboss2seekstate()
    {
        GlobalMembers.ConActions.Ai(AIBOSS2SEEKENEMY);
        if (GlobalMembers.ConActions.ifspritepal(0))
// nullop
else
                    GlobalMembers.ConActions.Move(PALBOSS2RUNVELS, seekplayer);
    }
    private void boss2runenemystate()
    {
        if (GlobalMembers.ConActions.ifcansee())
        {
            if (GlobalMembers.ConActions.ifactioncount(3))
            {
                if (GlobalMembers.ConActions.ifcanshoottarget())
                {
                    GlobalMembers.ConActions.resetactioncount();
                    GlobalMembers.ConActions.sound(BOS1_WALK);
                }
                else
                    GlobalMembers.ConActions.Ai(AIBOSS2SEEKENEMY);
            }
            if (GlobalMembers.ConActions.ifcount(48))
                if (GlobalMembers.ConActions.ifrnd(2))
                {
                    if (GlobalMembers.ConActions.ifp(palive))
                    {
                        GlobalMembers.ConActions.sound(BOS2_ATTACK);
                        GlobalMembers.ConActions.Ai(AIBOSS2SHOOTENEMY);
                    }
                    return;
                }
        }
        else
            GlobalMembers.ConActions.Ai(AIBOSS2SEEKENEMY);
    }
    private void boss2seekenemystate()
    {
        if (GlobalMembers.ConActions.ifrnd(2))
            GlobalMembers.ConActions.soundonce(BOS2_ROAM);
        else
        if (GlobalMembers.ConActions.ifactioncount(3))
        {
            GlobalMembers.ConActions.resetactioncount();
            GlobalMembers.ConActions.sound(BOS1_WALK);
        }
        if (GlobalMembers.ConActions.ifcansee())
            if (GlobalMembers.ConActions.ifcount(32))
                if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifrnd(48))
                        if (GlobalMembers.ConActions.ifcanshoottarget())
                        {
                            if (GlobalMembers.ConActions.ifrnd(64))
                                if (GlobalMembers.ConActions.ifpdistg(4096))
                                {
                                    GlobalMembers.ConActions.Ai(AIBOSS2RUNENEMY);
                                    if (GlobalMembers.ConActions.ifspritepal(0))
// nullop
else
                                                GlobalMembers.ConActions.Move(PALBOSS2RUNVELS, seekplayer);
                                    return;
                                }
                            if (GlobalMembers.ConActions.ifpdistl(10240))
                            {
                                if (GlobalMembers.ConActions.ifrnd(128))
                                {
                                    GlobalMembers.ConActions.sound(BOS2_ATTACK);
                                    GlobalMembers.ConActions.Ai(AIBOSS2LOBBED);
                                }
                            }
                            else
                            {
                                GlobalMembers.ConActions.sound(BOS2_ATTACK);
                                GlobalMembers.ConActions.Ai(AIBOSS2SHOOTENEMY);
                            }
                        }
    }
    private void boss2dyingstate()
    {
        if (GlobalMembers.ConActions.ifaction(ABOSS2DEAD))
        {
            if (GlobalMembers.ConActions.ifspritepal(0))
                return;
            if (GlobalMembers.ConActions.ifrespawn())
                if (GlobalMembers.ConActions.ifcount(RESPAWNACTORTIME))
                {
                    GlobalMembers.ConActions.spawn(TRANSPORTERSTAR);
                    GlobalMembers.ConActions.cstat(257);
                    GlobalMembers.ConActions.strength(PIGCOPSTRENGTH);
                    checkboss2seekstate();
                }
                else
                {
                    GlobalMembers.ConActions.strength(0);
                    if (GlobalMembers.ConActions.ifhitweapon())
                        if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                        {
                            GlobalMembers.ConActions.sound(SQUISHED);
                            standard_jibs();
                            GlobalMembers.ConActions.killit();
                        }
                    return;
                }
        }
        if (GlobalMembers.ConActions.ifactioncount(8))
        {
            if (GlobalMembers.ConActions.iffloordistl(8))
                GlobalMembers.ConActions.sound(THUD);
            GlobalMembers.ConActions.ConAction ABOSS2DEAD = new GlobalMembers.ConActions.ConAction();
            GlobalMembers.ConActions.cstat(0);
            if (GlobalMembers.ConActions.ifspritepal(0))
                GlobalMembers.ConActions.endofgame(52);
        }
    }
    private void boss2lobbedstate()
    {
        if (GlobalMembers.ConActions.ifcansee())
        {
            if (GlobalMembers.ConActions.ifactioncount(2))
                GlobalMembers.ConActions.resetactioncount();
            else
            if (GlobalMembers.ConActions.ifactioncount(1))
            {
                if (GlobalMembers.ConActions.ifrnd(128))
                    GlobalMembers.ConActions.shoot(COOLEXPLOSION1);
            }
            else
            if (GlobalMembers.ConActions.ifcount(64))
                if (GlobalMembers.ConActions.ifrnd(16))
                    checkboss2seekstate();
        }
        else
            checkboss2seekstate();
    }
    private void boss2shootenemy()
    {
        if (GlobalMembers.ConActions.ifcount(72))
            checkboss2seekstate();
        else
        if (GlobalMembers.ConActions.ifaction(ABOSS2SHOOT))
            if (GlobalMembers.ConActions.ifactioncount(2))
            {
                GlobalMembers.ConActions.shoot(RPG);
                GlobalMembers.ConActions.resetactioncount();
            }
    }
    private void checkboss2hitstate()
    {
        if (GlobalMembers.ConActions.ifrnd(2))
            GlobalMembers.ConActions.spawn(BLOODPOOL);
        if (GlobalMembers.ConActions.ifdead())
        {
            if (GlobalMembers.ConActions.ifspritepal(0))
                GlobalMembers.ConActions.globalsound(DUKE_TALKTOBOSSFALL);
            else
            {
                if (GlobalMembers.ConActions.ifrnd(64))
                    GlobalMembers.ConActions.globalsound(DUKE_TALKTOBOSSFALL);
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.sound(SOMETHINGFROZE);
                    GlobalMembers.ConActions.spritepal(1);
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.ConAction ABOSS2FROZEN = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
            }
            GlobalMembers.ConActions.sound(BOS2_DYING);
            GlobalMembers.ConActions.addkills(1);
            GlobalMembers.ConActions.Ai(AIBOSS2DYING);
        }
        else
        {
            if (GlobalMembers.ConActions.ifrnd(144))
            {
                if (GlobalMembers.ConActions.ifrnd(32))
                {
                    GlobalMembers.ConActions.ConAction BOSS2FLINTCH = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.Move(0);
                }
                else
                {
                    GlobalMembers.ConActions.sound(BOS2_ATTACK);
                    GlobalMembers.ConActions.Ai(AIBOSS2SHOOTENEMY);
                }
            }
            if (GlobalMembers.ConActions.ifspritepal(0))
// nullop
else
    if (GlobalMembers.ConActions.ifwasweapon(SHRINKSPARK))
                    {
                        GlobalMembers.ConActions.sound(ACTOR_SHRINKING);
                        GlobalMembers.ConActions.Ai(AIBOSS2PALSHRINK);
                        return;
                    }
            GlobalMembers.ConActions.soundonce(BOS2_PAIN);
            GlobalMembers.ConActions.debris(SCRAP1, 1);
            GlobalMembers.ConActions.guts(JIBS6, 1);
        }
    }
    private void boss2code()
    {
        if (GlobalMembers.ConActions.ifaction(ABOSS2FROZEN))
        {
            if (GlobalMembers.ConActions.ifcount(THAWTIME))
            {
                GlobalMembers.ConActions.Ai(AIBOSS2SEEKENEMY);
                GlobalMembers.ConActions.spritepal(21);
            }
            else
            if (GlobalMembers.ConActions.ifcount(FROZENDRIPTIME))
            {
                if (GlobalMembers.ConActions.ifactioncount(26))
                {
                    GlobalMembers.ConActions.spawn(WATERDRIP);
                    GlobalMembers.ConActions.resetactioncount();
                }
            }
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                GlobalMembers.ConActions.addkills(1);
                GlobalMembers.ConActions.lotsofglass(30);
                GlobalMembers.ConActions.sound(GLASS_BREAKING);
                if (GlobalMembers.ConActions.ifrnd(84))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.killit();
            }
            if (GlobalMembers.ConActions.ifp(pfacing))
                if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                    GlobalMembers.ConActions.pkick();
            return;
        }
        if (GlobalMembers.ConActions.ifai(0))
        {
            if (GlobalMembers.ConActions.ifspritepal(0))
                GlobalMembers.ConActions.Ai(AIBOSS2RUNENEMY);
            else
            {
                GlobalMembers.ConActions.strength(1);
                GlobalMembers.ConActions.sound(BOS2_ATTACK);
                GlobalMembers.ConActions.Ai(AIBOSS2SHOOTENEMY);
            }
        }
        else
        if (GlobalMembers.ConActions.ifaction(BOSS2FLINTCH))
        {
            if (GlobalMembers.ConActions.ifactioncount(3))
                GlobalMembers.ConActions.Ai(AIBOSS2SEEKENEMY);
        }
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS2SEEKENEMY))
            boss2seekenemystate();
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS2RUNENEMY))
            boss2runenemystate();
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS2SHOOTENEMY))
            boss2shootenemy();
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS2LOBBED))
            boss2lobbedstate();
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS2PALSHRINK))
            boss2palshrunkstate();
        if (GlobalMembers.ConActions.ifai(AIBOSS2DYING))
            boss2dyingstate();
        else
        {
            if (GlobalMembers.ConActions.ifhitweapon())
                checkboss2hitstate();
            else
                if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifspritepal(0))
                    if (GlobalMembers.ConActions.ifpdistl(1280))
                    {
                        GlobalMembers.ConActions.addphealth(-1000);
                        GlobalMembers.ConActions.palfrom(63, 63);
                    }
        }
    }
    private void A_BOSS2()
    {
        boss2code();
    }
    GlobalMembers.ConActions.ConAction ABOSS3WALK = new GlobalMembers.ConActions.ConAction(0, 4, 5, 1, 30);
    GlobalMembers.ConActions.ConAction ABOSS3FROZEN = new GlobalMembers.ConActions.ConAction(0, 1, 5);
    GlobalMembers.ConActions.ConAction ABOSS3RUN = new GlobalMembers.ConActions.ConAction(0, 4, 5, 1, 15);
    GlobalMembers.ConActions.ConAction ABOSS3LOB = new GlobalMembers.ConActions.ConAction(20, 4, 5, 1, 50);
    GlobalMembers.ConActions.ConAction ABOSS3LOBBING = new GlobalMembers.ConActions.ConAction(30, 2, 5, 1, 15);
    GlobalMembers.ConActions.ConAction ABOSS3DYING = new GlobalMembers.ConActions.ConAction(40, 8, 1, 1, 20);
    GlobalMembers.ConActions.ConAction BOSS3FLINTCH = new GlobalMembers.ConActions.ConAction(40, 1, 1, 1, 1);
    GlobalMembers.ConActions.ConAction ABOSS3DEAD = new GlobalMembers.ConActions.ConAction(48);
    GlobalMembers.ConActions.MoveAction PALBOSS3SHRUNKRUNVELS = new GlobalMembers.ConActions.MoveAction(32);
    GlobalMembers.ConActions.MoveAction PALBOSS3RUNVELS = new GlobalMembers.ConActions.MoveAction(84);
    GlobalMembers.ConActions.MoveAction BOSS3WALKVELS = new GlobalMembers.ConActions.MoveAction(208);
    GlobalMembers.ConActions.MoveAction BOSS3RUNVELS = new GlobalMembers.ConActions.MoveAction(270);
    GlobalMembers.ConActions.MoveAction BOSS3STOPPED = new GlobalMembers.ConActions.MoveAction();
    GlobalMembers.ConActions.AIAction AIBOSS3SEEKENEMY = new GlobalMembers.ConActions.AIAction(ABOSS3WALK, BOSS3WALKVELS, seekplayer);
    GlobalMembers.ConActions.AIAction AIBOSS3RUNENEMY = new GlobalMembers.ConActions.AIAction(ABOSS3RUN, BOSS3RUNVELS, faceplayerslow);
    GlobalMembers.ConActions.AIAction AIBOSS3LOBENEMY = new GlobalMembers.ConActions.AIAction(ABOSS3LOB, BOSS3STOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIBOSS3DYING = new GlobalMembers.ConActions.AIAction(ABOSS3DYING, BOSS3STOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIBOSS3PALSHRINK = new GlobalMembers.ConActions.AIAction(ABOSS3WALK, PALBOSS3SHRUNKRUNVELS, faceplayer);
    private void boss3palshrunkstate()
    {
        if (GlobalMembers.ConActions.ifcount(SHRUNKDONECOUNT))
            GlobalMembers.ConActions.Ai(AITROOPSEEKENEMY);
        else
        if (GlobalMembers.ConActions.ifcount(SHRUNKCOUNT))
            GlobalMembers.ConActions.sizeto(40, 40);
        else
            genericshrunkcode();
    }
    private void checkboss3seekstate()
    {
        GlobalMembers.ConActions.Ai(AIBOSS3SEEKENEMY);
        if (GlobalMembers.ConActions.ifspritepal(0))
// nullop
else
                    GlobalMembers.ConActions.Move(PALBOSS3RUNVELS, seekplayer);
    }
    private void boss3runenemystate()
    {
        if (GlobalMembers.ConActions.ifcansee())
        {
            if (GlobalMembers.ConActions.ifactioncount(3))
            {
                if (GlobalMembers.ConActions.ifcanshoottarget())
                {
                    GlobalMembers.ConActions.resetactioncount();
                    GlobalMembers.ConActions.sound(BOS1_WALK);
                }
                else
                    GlobalMembers.ConActions.Ai(AIBOSS3SEEKENEMY);
            }
        }
        else
            GlobalMembers.ConActions.Ai(AIBOSS3SEEKENEMY);
    }
    private void boss3seekenemystate()
    {
        if (GlobalMembers.ConActions.ifrnd(2))
            GlobalMembers.ConActions.soundonce(BOS3_ROAM);
        else
        if (GlobalMembers.ConActions.ifactioncount(3))
        {
            GlobalMembers.ConActions.resetactioncount();
            GlobalMembers.ConActions.sound(BOS1_WALK);
        }
        if (GlobalMembers.ConActions.ifcansee())
            if (GlobalMembers.ConActions.ifcount(32))
                if (GlobalMembers.ConActions.ifrnd(48))
                    if (GlobalMembers.ConActions.ifcanshoottarget())
                    {
                        if (GlobalMembers.ConActions.ifrnd(64))
                            if (GlobalMembers.ConActions.ifpdistg(4096))
                            {
                                GlobalMembers.ConActions.Ai(AIBOSS3RUNENEMY);
                                if (GlobalMembers.ConActions.ifspritepal(0))
                                    return;
                                GlobalMembers.ConActions.Move(PALBOSS3RUNVELS, seekplayer);
                                return;
                            }
                        if (GlobalMembers.ConActions.ifp(palive))
                            GlobalMembers.ConActions.Ai(AIBOSS3LOBENEMY);
                    }
    }
    private void boss3dyingstate()
    {
        if (GlobalMembers.ConActions.ifaction(ABOSS3DEAD))
        {
            if (GlobalMembers.ConActions.ifspritepal(0))
                return;
            if (GlobalMembers.ConActions.ifrespawn())
                if (GlobalMembers.ConActions.ifcount(RESPAWNACTORTIME))
                {
                    GlobalMembers.ConActions.spawn(TRANSPORTERSTAR);
                    GlobalMembers.ConActions.cstat(257);
                    GlobalMembers.ConActions.strength(PIGCOPSTRENGTH);
                    checkboss3seekstate();
                }
                else
                {
                    GlobalMembers.ConActions.strength(0);
                    if (GlobalMembers.ConActions.ifhitweapon())
                        if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                        {
                            GlobalMembers.ConActions.sound(SQUISHED);
                            standard_jibs();
                            GlobalMembers.ConActions.killit();
                        }
                    return;
                }
        }
        if (GlobalMembers.ConActions.ifactioncount(8))
        {
            if (GlobalMembers.ConActions.iffloordistl(8))
                GlobalMembers.ConActions.sound(THUD);
            GlobalMembers.ConActions.ConAction ABOSS3DEAD = new GlobalMembers.ConActions.ConAction();
            GlobalMembers.ConActions.cstat(0);
            if (GlobalMembers.ConActions.ifspritepal(0))
                GlobalMembers.ConActions.endofgame(52);
        }
    }
    private void boss3lobbedstate()
    {
        if (GlobalMembers.ConActions.ifcansee())
        {
            if (GlobalMembers.ConActions.ifaction(ABOSS3LOBBING))
                if (GlobalMembers.ConActions.ifactioncount(2))
                {
                    GlobalMembers.ConActions.shoot(RPG);
                    GlobalMembers.ConActions.resetactioncount();
                    if (GlobalMembers.ConActions.ifrnd(8))
                        GlobalMembers.ConActions.Ai(AIBOSS3SEEKENEMY);
                }
            if (GlobalMembers.ConActions.ifactioncount(3))
            {
                GlobalMembers.ConActions.ConAction ABOSS3LOBBING = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.resetcount();
            }
        }
        else
            checkboss3seekstate();
    }
    private void checkboss3hitstate()
    {
        if (GlobalMembers.ConActions.ifrnd(2))
            GlobalMembers.ConActions.spawn(BLOODPOOL);
        if (GlobalMembers.ConActions.ifdead())
        {
            if (GlobalMembers.ConActions.ifspritepal(0))
                GlobalMembers.ConActions.globalsound(DUKE_TALKTOBOSSFALL);
            else
            {
                if (GlobalMembers.ConActions.ifrnd(64))
                    GlobalMembers.ConActions.globalsound(DUKE_TALKTOBOSSFALL);
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.sound(SOMETHINGFROZE);
                    GlobalMembers.ConActions.spritepal(1);
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.ConAction ABOSS3FROZEN = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
            }
            GlobalMembers.ConActions.addkills(1);
            GlobalMembers.ConActions.Ai(AIBOSS3DYING);
            GlobalMembers.ConActions.sound(BOS3_DYING);
            GlobalMembers.ConActions.sound(JIBBED_ACTOR9);
        }
        else
        {
            if (GlobalMembers.ConActions.ifrnd(32))
            {
                GlobalMembers.ConActions.ConAction BOSS3FLINTCH = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.Move(0);
            }
            if (GlobalMembers.ConActions.ifspritepal(0))
// nullop
else
    if (GlobalMembers.ConActions.ifwasweapon(SHRINKSPARK))
                    {
                        GlobalMembers.ConActions.sound(ACTOR_SHRINKING);
                        GlobalMembers.ConActions.Ai(AIBOSS3PALSHRINK);
                        return;
                    }
            GlobalMembers.ConActions.soundonce(BOS3_PAIN);
            GlobalMembers.ConActions.debris(SCRAP1, 1);
            GlobalMembers.ConActions.guts(JIBS6, 1);
        }
    }
    private void boss3code()
    {
        if (GlobalMembers.ConActions.ifaction(ABOSS3FROZEN))
        {
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                GlobalMembers.ConActions.addkills(1);
                GlobalMembers.ConActions.lotsofglass(30);
                if (GlobalMembers.ConActions.ifrnd(84))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.sound(GLASS_BREAKING);
                GlobalMembers.ConActions.killit();
            }
            if (GlobalMembers.ConActions.ifp(pfacing))
                if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                    GlobalMembers.ConActions.pkick();
            return;
        }
        if (GlobalMembers.ConActions.ifai(0))
        {
            if (GlobalMembers.ConActions.ifspritepal(0))
                GlobalMembers.ConActions.Ai(AIBOSS3RUNENEMY);
            else
            {
                GlobalMembers.ConActions.strength(1);
                GlobalMembers.ConActions.Ai(AIBOSS3LOBENEMY);
            }
        }
        else
        if (GlobalMembers.ConActions.ifaction(BOSS3FLINTCH))
        {
            if (GlobalMembers.ConActions.ifactioncount(3))
                GlobalMembers.ConActions.Ai(AIBOSS3SEEKENEMY);
        }
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS3SEEKENEMY))
            boss3seekenemystate();
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS3RUNENEMY))
            boss3runenemystate();
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS3LOBENEMY))
            boss3lobbedstate();
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS3PALSHRINK))
            boss3palshrunkstate();
        if (GlobalMembers.ConActions.ifai(AIBOSS3DYING))
            boss3dyingstate();
        else
        {
            if (GlobalMembers.ConActions.ifhitweapon())
                checkboss3hitstate();
            else
                if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifspritepal(0))
                    if (GlobalMembers.ConActions.ifpdistl(1280))
                    {
                        GlobalMembers.ConActions.addphealth(-1000);
                        GlobalMembers.ConActions.palfrom(63, 63);
                    }
        }
    }
    private void A_BOSS3()
    {
        boss3code();
    }
    GlobalMembers.ConActions.ConAction ACOMMBREETH = new GlobalMembers.ConActions.ConAction(0, 3, 5, 1, 40);
    GlobalMembers.ConActions.ConAction ACOMMFROZEN = new GlobalMembers.ConActions.ConAction(0, 1, 5);
    GlobalMembers.ConActions.ConAction ACOMMSPIN = new GlobalMembers.ConActions.ConAction(-5, 1, 5, 1, 12);
    GlobalMembers.ConActions.ConAction ACOMMGET = new GlobalMembers.ConActions.ConAction(0, 3, 5, 1, 30);
    GlobalMembers.ConActions.ConAction ACOMMSHOOT = new GlobalMembers.ConActions.ConAction(20, 1, 5, 1, 35);
    GlobalMembers.ConActions.ConAction ACOMMABOUTTOSHOOT = new GlobalMembers.ConActions.ConAction(20, 1, 5, 1, 30);
    GlobalMembers.ConActions.ConAction ACOMMDYING = new GlobalMembers.ConActions.ConAction(30, 8, 1, 1, 12);
    GlobalMembers.ConActions.ConAction ACOMMDEAD = new GlobalMembers.ConActions.ConAction(38, 1, 1, 1, 1);
    GlobalMembers.ConActions.MoveAction COMMGETUPVELS = new GlobalMembers.ConActions.MoveAction(128, -64);
    GlobalMembers.ConActions.MoveAction COMMGETVELS = new GlobalMembers.ConActions.MoveAction(128, 64);
    GlobalMembers.ConActions.MoveAction COMMSLOW = new GlobalMembers.ConActions.MoveAction(64, 24);
    GlobalMembers.ConActions.MoveAction COMMSTOPPED = new GlobalMembers.ConActions.MoveAction();
    GlobalMembers.ConActions.AIAction AICOMMWAIT = new GlobalMembers.ConActions.AIAction(ACOMMBREETH, COMMSTOPPED, faceplayerslow);
    GlobalMembers.ConActions.AIAction AICOMMGET = new GlobalMembers.ConActions.AIAction(ACOMMGET, COMMGETVELS, seekplayer);
    GlobalMembers.ConActions.AIAction AICOMMSHOOT = new GlobalMembers.ConActions.AIAction(ACOMMSHOOT, COMMSTOPPED, faceplayerslow);
    GlobalMembers.ConActions.AIAction AICOMMABOUTTOSHOOT = new GlobalMembers.ConActions.AIAction(ACOMMABOUTTOSHOOT, COMMSTOPPED, faceplayerslow);
    GlobalMembers.ConActions.AIAction AICOMMSPIN = new GlobalMembers.ConActions.AIAction(ACOMMSPIN, COMMGETVELS, spin);
    GlobalMembers.ConActions.AIAction AICOMMDYING = new GlobalMembers.ConActions.AIAction(ACOMMDYING, COMMSTOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AICOMMSHRUNK = new GlobalMembers.ConActions.AIAction(ACOMMGET, COMMSLOW, furthestdir);
    GlobalMembers.ConActions.AIAction AICOMMGROW = new GlobalMembers.ConActions.AIAction(ACOMMGET, COMMSTOPPED, furthestdir);
    private void checkcommhitstate()
    {
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            GlobalMembers.ConActions.guts(JIBS6, 2);
            if (GlobalMembers.ConActions.ifdead())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.sound(SOMETHINGFROZE);
                    GlobalMembers.ConActions.spritepal(1);
                    GlobalMembers.ConActions.Move(0);
                    GlobalMembers.ConActions.ConAction ACOMMFROZEN = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                else
                if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                {
                    GlobalMembers.ConActions.sound(ACTOR_GROWING);
                    GlobalMembers.ConActions.Ai(AICOMMGROW);
                    return;
                }
                GlobalMembers.ConActions.addkills(1);
                if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                {
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                    GlobalMembers.ConActions.sound(SQUISHED);
                    standard_jibs();
                    GlobalMembers.ConActions.killit();
                }
                else
                if (GlobalMembers.ConActions.ifwasweapon(RPG))
                {
                    GlobalMembers.ConActions.sound(SQUISHED);
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                    standard_jibs();
                    GlobalMembers.ConActions.killit();
                }
                GlobalMembers.ConActions.sound(COMM_DYING);
                GlobalMembers.ConActions.Ai(AICOMMDYING);
            }
            else
            {
                GlobalMembers.ConActions.soundonce(COMM_PAIN);
                if (GlobalMembers.ConActions.ifwasweapon(SHRINKSPARK))
                {
                    GlobalMembers.ConActions.sound(ACTOR_SHRINKING);
                    GlobalMembers.ConActions.Ai(AICOMMSHRUNK);
                }
                else
                if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                    GlobalMembers.ConActions.sound(EXPANDERHIT);
                else
                if (GlobalMembers.ConActions.ifrnd(24))
                    GlobalMembers.ConActions.Ai(AICOMMABOUTTOSHOOT);
            }
        }
    }
    private void A_COMMANDERSTAYPUT()
    {
        GlobalMembers.ConActions.cactor(COMMANDER);
        GlobalMembers.ConActions.Ai(AICOMMABOUTTOSHOOT);
    }
    private void A_COMMANDER()
    {
        checksquished();
        if (GlobalMembers.ConActions.ifaction(ACOMMFROZEN))
        {
            GlobalMembers.ConActions.fall();
            if (GlobalMembers.ConActions.ifcount(THAWTIME))
            {
                GlobalMembers.ConActions.getlastpal();
                GlobalMembers.ConActions.Ai(AICOMMWAIT);
            }
            else
            if (GlobalMembers.ConActions.ifcount(FROZENDRIPTIME))
            {
                if (GlobalMembers.ConActions.ifactioncount(26))
                {
                    GlobalMembers.ConActions.spawn(WATERDRIP);
                    GlobalMembers.ConActions.resetactioncount();
                }
            }
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                GlobalMembers.ConActions.addkills(1);
                if (GlobalMembers.ConActions.ifrnd(84))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.lotsofglass(30);
                GlobalMembers.ConActions.sound(GLASS_BREAKING);
                GlobalMembers.ConActions.killit();
            }
            if (GlobalMembers.ConActions.ifp(pfacing))
                if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                    GlobalMembers.ConActions.pkick();
            return;
        }
        if (GlobalMembers.ConActions.ifai(0))
            GlobalMembers.ConActions.Ai(AICOMMSHOOT);
        else
        if (GlobalMembers.ConActions.ifai(AICOMMWAIT))
        {
            if (GlobalMembers.ConActions.ifcount(20))
            {
                if (GlobalMembers.ConActions.ifcansee())
                {
                    if (GlobalMembers.ConActions.ifcanshoottarget())
                    {
                        if (GlobalMembers.ConActions.ifrnd(96))
                            GlobalMembers.ConActions.Ai(AICOMMGET);
                        else
                            GlobalMembers.ConActions.Ai(AICOMMABOUTTOSHOOT);
                    }
                }
                else
                    GlobalMembers.ConActions.Ai(AICOMMGET);
            }
        }
        else
        if (GlobalMembers.ConActions.ifai(AICOMMABOUTTOSHOOT))
        {
            if (GlobalMembers.ConActions.ifactioncount(2))
            {
                if (GlobalMembers.ConActions.ifcansee())
                    GlobalMembers.ConActions.Ai(AICOMMSHOOT);
                else
                {
                    GlobalMembers.ConActions.Ai(AICOMMGET);
                    return;
                }
            }
            if (GlobalMembers.ConActions.ifrnd(32))
                GlobalMembers.ConActions.soundonce(COMM_ATTACK);
        }
        else
        if (GlobalMembers.ConActions.ifai(AICOMMSHOOT))
        {
            if (GlobalMembers.ConActions.ifcanshoottarget())
            {
                if (GlobalMembers.ConActions.ifcount(24))
                    if (GlobalMembers.ConActions.ifrnd(16))
                        GlobalMembers.ConActions.Ai(AICOMMWAIT);
                if (GlobalMembers.ConActions.ifactioncount(2))
                {
                    GlobalMembers.ConActions.shoot(RPG);
                    GlobalMembers.ConActions.resetactioncount();
                }
            }
            else
                GlobalMembers.ConActions.Ai(AICOMMGET);
        }
        else
        if (GlobalMembers.ConActions.ifai(AICOMMSHRUNK))
        {
            if (GlobalMembers.ConActions.ifcount(SHRUNKDONECOUNT))
                GlobalMembers.ConActions.Ai(AICOMMGET);
            else
            if (GlobalMembers.ConActions.ifcount(SHRUNKCOUNT))
                GlobalMembers.ConActions.sizeto(48, 40);
            else
                genericshrunkcode();
        }
        else
        if (GlobalMembers.ConActions.ifai(AICOMMGROW))
            genericgrowcode();
        else
        if (GlobalMembers.ConActions.ifai(AICOMMGET))
        {
            if (GlobalMembers.ConActions.ifnotmoving())
                if (GlobalMembers.ConActions.ifrnd(4))
                    GlobalMembers.ConActions.operate();
            if (GlobalMembers.ConActions.ifpdistl(1024))
                if (GlobalMembers.ConActions.ifp(palive))
                {
                    GlobalMembers.ConActions.sound(COMM_SPIN);
                    GlobalMembers.ConActions.Ai(AICOMMSPIN);
                    return;
                }
            if (GlobalMembers.ConActions.ifcansee())
            {
                if (GlobalMembers.ConActions.ifp(phigher))
                    GlobalMembers.ConActions.Move(COMMGETUPVELS, getv, geth, faceplayer);
                else
                    GlobalMembers.ConActions.Move(COMMGETVELS, getv, geth, faceplayer);
            }
            if (GlobalMembers.ConActions.ifactioncount(8))
                if (GlobalMembers.ConActions.ifrnd(2))
                    GlobalMembers.ConActions.Ai(AICOMMABOUTTOSHOOT);
        }
        else
        if (GlobalMembers.ConActions.ifai(AICOMMSPIN))
        {
            GlobalMembers.ConActions.soundonce(COMM_SPIN);
            if (GlobalMembers.ConActions.ifcount(16))
            {
                if (GlobalMembers.ConActions.ifpdistl(1280))
                {
                    GlobalMembers.ConActions.addphealth(CAPTSPINNINGPLAYER);
                    GlobalMembers.ConActions.sound(DUKE_GRUNT);
                    GlobalMembers.ConActions.palfrom(32, 16);
                    GlobalMembers.ConActions.resetcount();
                }
                else
                if (GlobalMembers.ConActions.ifpdistg(2300))
                    GlobalMembers.ConActions.Ai(AICOMMWAIT);
            }
            if (GlobalMembers.ConActions.ifactioncount(52))
                GlobalMembers.ConActions.Ai(AICOMMWAIT);
            if (GlobalMembers.ConActions.ifnotmoving())
                if (GlobalMembers.ConActions.ifrnd(32))
                    GlobalMembers.ConActions.operate();
        }
        if (GlobalMembers.ConActions.ifai(AICOMMDYING))
        {
            GlobalMembers.ConActions.fall();
            GlobalMembers.ConActions.strength(0);
            if (GlobalMembers.ConActions.ifhitweapon())
                if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                {
                    GlobalMembers.ConActions.sound(SQUISHED);
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                    standard_jibs();
                    GlobalMembers.ConActions.killit();
                }
            if (GlobalMembers.ConActions.ifaction(ACOMMDYING))
                if (GlobalMembers.ConActions.ifactioncount(8))
                {
                    if (GlobalMembers.ConActions.iffloordistl(8))
                        GlobalMembers.ConActions.sound(THUD);
                    GlobalMembers.ConActions.cstat(0);
                    GlobalMembers.ConActions.ConAction ACOMMDEAD = new GlobalMembers.ConActions.ConAction();
                }
        }
        else
        {
            if (GlobalMembers.ConActions.ifrnd(2))
                GlobalMembers.ConActions.soundonce(COMM_ROAM);
            checkcommhitstate();
        }
    }
    public const int CANNONBALLSTRENGTH = 400;
    GlobalMembers.ConActions.MoveAction CANNONBALL1 = new GlobalMembers.ConActions.MoveAction(512, 0);
    GlobalMembers.ConActions.MoveAction CANNONBALL2 = new GlobalMembers.ConActions.MoveAction(512, 10);
    GlobalMembers.ConActions.MoveAction CANNONBALL3 = new GlobalMembers.ConActions.MoveAction(512, 20);
    GlobalMembers.ConActions.MoveAction CANNONBALL4 = new GlobalMembers.ConActions.MoveAction(512, 40);
    GlobalMembers.ConActions.MoveAction CANNONBALL5 = new GlobalMembers.ConActions.MoveAction(512, 80);
    private void A_notenemy()
    {
        if (GlobalMembers.ConActions.ifaction(0))
        {
            GlobalMembers.ConActions.sizeat(32, 32);
            GlobalMembers.ConActions.cstat(257);
            GlobalMembers.ConActions.ConAction ANULLACTION = new GlobalMembers.ConActions.ConAction();
        }
        if (GlobalMembers.ConActions.ifactioncount(46))
        {
            if (GlobalMembers.ConActions.ifactioncount(47))
// nullop
else
                        GlobalMembers.ConActions.Move(CANNONBALL5, geth, getv);
        }
        else
        if (GlobalMembers.ConActions.ifactioncount(44))
        {
            if (GlobalMembers.ConActions.ifactioncount(45))
// nullop
else
                        GlobalMembers.ConActions.Move(CANNONBALL4, geth, getv);
        }
        else
        if (GlobalMembers.ConActions.ifactioncount(40))
        {
            if (GlobalMembers.ConActions.ifactioncount(41))
// nullop
else
                        GlobalMembers.ConActions.Move(CANNONBALL3, geth, getv);
        }
        else
        if (GlobalMembers.ConActions.ifactioncount(32))
        {
            if (GlobalMembers.ConActions.ifactioncount(33))
// nullop
else
                        GlobalMembers.ConActions.Move(CANNONBALL2, geth, getv);
        }
        else
        if (GlobalMembers.ConActions.ifactioncount(16))
        {
            if (GlobalMembers.ConActions.ifactioncount(17))
// nullop
else
                        GlobalMembers.ConActions.Move(CANNONBALL1, geth, getv);
        }
        if (GlobalMembers.ConActions.ifnotmoving())
        {
            GlobalMembers.ConActions.spawn(EXPLOSION2);
            GlobalMembers.ConActions.sound(PIPEBOMB_EXPLODE);
            GlobalMembers.ConActions.hitradius(4096, WEAKEST, WEAK, MEDIUMSTRENGTH, TOUGH);
            GlobalMembers.ConActions.killit();
        }
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                GlobalMembers.ConActions.spawn(EXPLOSION2);
                GlobalMembers.ConActions.hitradius(4096, WEAKEST, WEAK, MEDIUMSTRENGTH, TOUGH);
                GlobalMembers.ConActions.killit();
            }
            else
                GlobalMembers.ConActions.debris(SCRAP1, 3);
        }
    }
    public const int CANNONBALLS = 1818;
    public const int CANNONBALLSSTRENGTH = 10;
    GlobalMembers.ConActions.MoveAction CANNONBALLSVEL = new GlobalMembers.ConActions.MoveAction();
    private void A_notenemy()
    {
        if (GlobalMembers.ConActions.ifaction(0))
        {
            GlobalMembers.ConActions.cstator(257);
            GlobalMembers.ConActions.ConAction ANULLACTION = new GlobalMembers.ConActions.ConAction();
        }
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                GlobalMembers.ConActions.spawn(EXPLOSION2);
                GlobalMembers.ConActions.hitradius(4096, WEAKEST, WEAK, MEDIUMSTRENGTH, TOUGH);
                GlobalMembers.ConActions.killit();
            }
            else
                GlobalMembers.ConActions.debris(SCRAP1, 3);
        }
    }
    public const int CANNON = 1810;
    public const int CANNONSTRENGTH = 400;
    GlobalMembers.ConActions.ConAction ACANNONWAIT = new GlobalMembers.ConActions.ConAction(0, 1, 7, 1, 1);
    GlobalMembers.ConActions.ConAction ACANNONSHOOTING = new GlobalMembers.ConActions.ConAction(0, 1, 7, 1, 1);
    GlobalMembers.ConActions.MoveAction CANNONSTOP = new GlobalMembers.ConActions.MoveAction();
    private void A_enemy()
    {
        if (GlobalMembers.ConActions.ifaction(0))
        {
            GlobalMembers.ConActions.ConAction ACANNONWAIT = new GlobalMembers.ConActions.ConAction();
        }
        else
        if (GlobalMembers.ConActions.ifaction(ACANNONSHOOTING))
        {
            GlobalMembers.ConActions.spawn(CANNONBALL);
            GlobalMembers.ConActions.ConAction ACANNONWAIT = new GlobalMembers.ConActions.ConAction();
        }
        else
        if (GlobalMembers.ConActions.ifaction(ACANNONWAIT))
        {
            if (GlobalMembers.ConActions.ifactioncount(64))
            {
                if (GlobalMembers.ConActions.ifrnd(128))
                    GlobalMembers.ConActions.ConAction ACANNONSHOOTING = new GlobalMembers.ConActions.ConAction();
                else
                    GlobalMembers.ConActions.resetactioncount();
            }
        }
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                GlobalMembers.ConActions.addkills(1);
                GlobalMembers.ConActions.hitradius(4096, WEAKEST, WEAK, MEDIUMSTRENGTH, TOUGH);
                GlobalMembers.ConActions.spawn(EXPLOSION2);
                GlobalMembers.ConActions.killit();
            }
            else
                GlobalMembers.ConActions.debris(SCRAP1, 3);
        }
        if (GlobalMembers.ConActions.ifpdistl(1024))
            if (GlobalMembers.ConActions.ifhitspace())
            {
                if (GlobalMembers.ConActions.ifp(pfacing))
                    if (GlobalMembers.ConActions.ifcanshoottarget())
                        GlobalMembers.ConActions.spawn(CANNONBALL);
                    else
                        return;
            }
    }
    private void A_notenemy()
    {
        if (GlobalMembers.ConActions.ifaction(0))
        {
            GlobalMembers.ConActions.ConAction ANULLACTION = new GlobalMembers.ConActions.ConAction();
            GlobalMembers.ConActions.cstat(257);
        }
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                GlobalMembers.ConActions.sound(SQUISHED);
                GlobalMembers.ConActions.guts(JIBS5, 8);
                GlobalMembers.ConActions.guts(JIBS6, 9);
                GlobalMembers.ConActions.killit();
            }
            else
                GlobalMembers.ConActions.guts(JIBS6, 1);
        }
        if (GlobalMembers.ConActions.ifrnd(1))
            GlobalMembers.ConActions.spawn(WATERDRIP);
    }
    GlobalMembers.ConActions.ConAction ASPEAKERBROKE = new GlobalMembers.ConActions.ConAction(1);
    private void A_notenemy()
    {
        if (GlobalMembers.ConActions.ifaction(0))
        {
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                GlobalMembers.ConActions.stopsound(STORE_MUSIC);
                GlobalMembers.ConActions.soundonce(STORE_MUSIC_BROKE);
                GlobalMembers.ConActions.ConAction ASPEAKERBROKE = new GlobalMembers.ConActions.ConAction();
            }
            else
            {
                if (GlobalMembers.ConActions.ifpdistl(10240))
                    GlobalMembers.ConActions.soundonce(STORE_MUSIC);
                GlobalMembers.ConActions.cstat(289);
            }
        }
    }
    GlobalMembers.ConActions.ConAction ALAVABUBBLE = new GlobalMembers.ConActions.ConAction();
    GlobalMembers.ConActions.ConAction ALAVABUBBLEANIM = new GlobalMembers.ConActions.ConAction(0, 5, 1, 1, 16);
    private void A_notenemy()
    {
        if (GlobalMembers.ConActions.ifaction(0))
        {
            GlobalMembers.ConActions.cstat(32768);
            GlobalMembers.ConActions.ConAction ALAVABUBBLE = new GlobalMembers.ConActions.ConAction();
        }
        else
        if (GlobalMembers.ConActions.ifaction(ALAVABUBBLE))
        {
            if (GlobalMembers.ConActions.ifcount(72))
                if (GlobalMembers.ConActions.ifrnd(2))
                {
                    GlobalMembers.ConActions.cstat(0);
                    GlobalMembers.ConActions.ConAction ALAVABUBBLEANIM = new GlobalMembers.ConActions.ConAction();
                }
        }
        else
        {
            if (GlobalMembers.ConActions.ifactioncount(5))
            {
                GlobalMembers.ConActions.cstat(32768);
                GlobalMembers.ConActions.ConAction ALAVABUBBLE = new GlobalMembers.ConActions.ConAction();
            }
        }
    }
    public const int TANKSTRENGTH = 500;
    GlobalMembers.ConActions.ConAction ATANKSPIN = new GlobalMembers.ConActions.ConAction(0, 1, 7, 1, 4);
    GlobalMembers.ConActions.ConAction ATANKSHOOTING = new GlobalMembers.ConActions.ConAction(7, 2, 7, 1, 10);
    GlobalMembers.ConActions.ConAction ATANKWAIT = new GlobalMembers.ConActions.ConAction(0, 1, 7, 1, 1);
    GlobalMembers.ConActions.ConAction ATANKDESTRUCT = new GlobalMembers.ConActions.ConAction(0, 1, 7, 1, 1);
    GlobalMembers.ConActions.ConAction ATANKDEAD = new GlobalMembers.ConActions.ConAction(0, 1, 7, 1, 1);
    GlobalMembers.ConActions.MoveAction TANKFORWARD = new GlobalMembers.ConActions.MoveAction(100);
    GlobalMembers.ConActions.MoveAction TANKSTOP = new GlobalMembers.ConActions.MoveAction();
    private void A_enemy()
    {
        if (GlobalMembers.ConActions.ifaction(0))
        {
            GlobalMembers.ConActions.sizeat(60, 60);
            GlobalMembers.ConActions.ConAction ATANKWAIT = new GlobalMembers.ConActions.ConAction();
            GlobalMembers.ConActions.cstat(257);
            GlobalMembers.ConActions.clipdist(100);
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATANKSPIN))
        {
            GlobalMembers.ConActions.soundonce(TANK_ROAM);
            if (GlobalMembers.ConActions.ifactioncount(20))
            {
                if (GlobalMembers.ConActions.ifrnd(16))
                    if (GlobalMembers.ConActions.ifcansee())
                        if (GlobalMembers.ConActions.ifcanshoottarget())
                        {
                            GlobalMembers.ConActions.Move(TANKSTOP, geth);
                            GlobalMembers.ConActions.ConAction ATANKSHOOTING = new GlobalMembers.ConActions.ConAction();
                            GlobalMembers.ConActions.stopsound(TANK_ROAM);
                        }
            }
            if (GlobalMembers.ConActions.ifrnd(16))
                GlobalMembers.ConActions.Move(TANKFORWARD, seekplayer);
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATANKSHOOTING))
        {
            if (GlobalMembers.ConActions.ifactioncount(22))
            {
                if (GlobalMembers.ConActions.ifpdistg(8192))
                {
                    GlobalMembers.ConActions.sound(BOS1_ATTACK2);
                    GlobalMembers.ConActions.shoot(MORTER);
                }
                GlobalMembers.ConActions.resetcount();
                GlobalMembers.ConActions.Move(0, action, ATANKWAIT);
            }
            else
            if (GlobalMembers.ConActions.ifactioncount(2))
            {
                if (GlobalMembers.ConActions.ifcansee())
                {
                    if (GlobalMembers.ConActions.ifpdistl(16384))
                    {
                        if (GlobalMembers.ConActions.ifrnd(128))
                        {
                            GlobalMembers.ConActions.sound(PISTOL_FIRE);
                            GlobalMembers.ConActions.shoot(SHOTSPARK1);
                        }
                    }
                    else
                        if (GlobalMembers.ConActions.ifrnd(128))
                    {
                        GlobalMembers.ConActions.sound(PRED_ATTACK);
                        GlobalMembers.ConActions.shoot(FIRELASER);
                    }
                }
                else
                {
                    GlobalMembers.ConActions.Move(TANKFORWARD, seekplayer);
                    GlobalMembers.ConActions.ConAction ATANKSPIN = new GlobalMembers.ConActions.ConAction();
                }
            }
            if (GlobalMembers.ConActions.ifrnd(16))
            {
                GlobalMembers.ConActions.stopsound(TANK_ROAM);
                GlobalMembers.ConActions.Move(TANKSTOP, faceplayerslow);
            }
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATANKWAIT))
        {
            if (GlobalMembers.ConActions.ifactioncount(32))
            {
                GlobalMembers.ConActions.Move(TANKFORWARD, seekplayer);
                GlobalMembers.ConActions.ConAction ATANKSPIN = new GlobalMembers.ConActions.ConAction();
            }
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATANKDESTRUCT))
        {
            if (GlobalMembers.ConActions.ifactioncount(64))
                GlobalMembers.ConActions.ConAction ATANKDEAD = new GlobalMembers.ConActions.ConAction();
            else
            if (GlobalMembers.ConActions.ifactioncount(56))
                GlobalMembers.ConActions.sound(LASERTRIP_ARMING);
            else
            if (GlobalMembers.ConActions.ifactioncount(48))
                GlobalMembers.ConActions.sound(LASERTRIP_ARMING);
            else
            if (GlobalMembers.ConActions.ifactioncount(32))
                GlobalMembers.ConActions.sound(LASERTRIP_ARMING);
            else
            if (GlobalMembers.ConActions.ifactioncount(16))
                GlobalMembers.ConActions.sound(LASERTRIP_ARMING);
            return;
        }
        else
        if (GlobalMembers.ConActions.ifaction(ATANKDEAD))
        {
            GlobalMembers.ConActions.addkills(1);
            GlobalMembers.ConActions.hitradius(6144, TOUGH, TOUGH, TOUGH, TOUGH);
            GlobalMembers.ConActions.sound(LASERTRIP_EXPLODE);
            GlobalMembers.ConActions.debris(SCRAP1, 15);
            GlobalMembers.ConActions.spawn(EXPLOSION2);
            if (GlobalMembers.ConActions.ifrnd(128))
                GlobalMembers.ConActions.spawn(PIGCOP);
            GlobalMembers.ConActions.killit();
        }
        if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
                GlobalMembers.ConActions.ConAction ATANKDEAD = new GlobalMembers.ConActions.ConAction();
            else
            {
                GlobalMembers.ConActions.debris(SCRAP1, 1);
                if (GlobalMembers.ConActions.ifaction(ATANKSHOOTING))
                    return;
                if (GlobalMembers.ConActions.ifrnd(192))
                {
                    GlobalMembers.ConActions.Move(TANKSTOP, geth);
                    GlobalMembers.ConActions.ConAction ATANKSHOOTING = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.stopsound(TANK_ROAM);
                }
            }
        }
        if (GlobalMembers.ConActions.ifpdistl(1280))
            if (GlobalMembers.ConActions.ifhitspace())
                if (GlobalMembers.ConActions.ifp(pfacing))
                    if (GlobalMembers.ConActions.ifangdiffl(512))
                        GlobalMembers.ConActions.ConAction ATANKDESTRUCT = new GlobalMembers.ConActions.ConAction();
    }
    GlobalMembers.ConActions.ConAction ABOSS4WALK = new GlobalMembers.ConActions.ConAction(0, 4, 5, 1, 30);
    GlobalMembers.ConActions.ConAction ABOSS4DYING = new GlobalMembers.ConActions.ConAction(40, 9, 1, 1, 20);
    GlobalMembers.ConActions.ConAction ABOSS4ABOUTTOSHOOT = new GlobalMembers.ConActions.ConAction(20, 1, 5, 1, 40);
    GlobalMembers.ConActions.ConAction ABOSS4SHOOT = new GlobalMembers.ConActions.ConAction(25, 2, 5, 1, 10);
    GlobalMembers.ConActions.ConAction ABOSS4LAYIT = new GlobalMembers.ConActions.ConAction(50, 3, 5, 1, 120);
    GlobalMembers.ConActions.ConAction BOSS4FLINTCH = new GlobalMembers.ConActions.ConAction(40, 1, 1, 1, 1);
    GlobalMembers.ConActions.ConAction ABOSS4DEAD = new GlobalMembers.ConActions.ConAction(49);
    GlobalMembers.ConActions.MoveAction BOSS4WALKVELS = new GlobalMembers.ConActions.MoveAction(128);
    GlobalMembers.ConActions.MoveAction BOSS4STOPPED = new GlobalMembers.ConActions.MoveAction();
    GlobalMembers.ConActions.AIAction AIBOSS4LAYEGGS = new GlobalMembers.ConActions.AIAction(ABOSS4WALK, BOSS4WALKVELS, randomangle, geth);
    GlobalMembers.ConActions.AIAction AIBOSS4SHOOT = new GlobalMembers.ConActions.AIAction(ABOSS4ABOUTTOSHOOT, BOSS4STOPPED, faceplayer);
    GlobalMembers.ConActions.AIAction AIBOSS4DYING = new GlobalMembers.ConActions.AIAction(ABOSS4DYING, BOSS4STOPPED, faceplayer);
    private void boss4shootstate()
    {
        if (GlobalMembers.ConActions.ifaction(ABOSS4ABOUTTOSHOOT))
            if (GlobalMembers.ConActions.ifactioncount(3))
                GlobalMembers.ConActions.ConAction ABOSS4SHOOT = new GlobalMembers.ConActions.ConAction();
        if (GlobalMembers.ConActions.ifaction(ABOSS4SHOOT))
        {
            if (GlobalMembers.ConActions.ifcount(48))
            {
                if (GlobalMembers.ConActions.ifrnd(4))
                    GlobalMembers.ConActions.Ai(AIBOSS4LAYEGGS);
            }
            if (GlobalMembers.ConActions.ifcount(26))
                if (GlobalMembers.ConActions.ifrnd(32))
                {
                    if (GlobalMembers.ConActions.ifrnd(128))
                    {
                        GlobalMembers.ConActions.sound(SHORT_CIRCUIT);
                        GlobalMembers.ConActions.addphealth(-2);
                    }
                    else
                    {
                        GlobalMembers.ConActions.sound(DUKE_GRUNT);
                        GlobalMembers.ConActions.addphealth(-1);
                    }
                    GlobalMembers.ConActions.palfrom(32, 32, 0, 0);
                }
        }
    }
    private void boss4layeggs()
    {
        if (GlobalMembers.ConActions.ifrnd(2))
            GlobalMembers.ConActions.sound(BOS4_ROAM);
        if (GlobalMembers.ConActions.ifaction(ABOSS4LAYIT))
        {
            if (GlobalMembers.ConActions.ifactioncount(3))
                if (GlobalMembers.ConActions.ifcount(32))
                {
                    GlobalMembers.ConActions.Ai(AIBOSS4LAYEGGS);
                    if (GlobalMembers.ConActions.ifrnd(32))
                        GlobalMembers.ConActions.Move(BOSS4WALKVELS, furthestdir, geth);
                    GlobalMembers.ConActions.spawn(NEWBEASTHANG);
                }
        }
        else
        if (GlobalMembers.ConActions.ifcount(64))
            if (GlobalMembers.ConActions.ifrnd(4))
            {
                GlobalMembers.ConActions.Move(0);
                if (GlobalMembers.ConActions.ifrnd(88))
                {
                    GlobalMembers.ConActions.ConAction ABOSS4LAYIT = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.sound(BOS4_LAY);
                }
                else
                if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifcansee())
                    {
                        GlobalMembers.ConActions.Ai(AIBOSS4SHOOT);
                        GlobalMembers.ConActions.sound(BOS4_ATTACK);
                    }
            }
    }
    private void boss4dyingstate()
    {
        if (GlobalMembers.ConActions.ifaction(ABOSS4DEAD))
            return;
        else
        if (GlobalMembers.ConActions.ifactioncount(9))
        {
            if (GlobalMembers.ConActions.iffloordistl(8))
                GlobalMembers.ConActions.sound(THUD);
            GlobalMembers.ConActions.endofgame(52);
            GlobalMembers.ConActions.ConAction ABOSS4DEAD = new GlobalMembers.ConActions.ConAction();
            GlobalMembers.ConActions.cstat(0);
        }
    }
    private void checkboss4hitstate()
    {
        if (GlobalMembers.ConActions.ifrnd(2))
            GlobalMembers.ConActions.spawn(BLOODPOOL);
        if (GlobalMembers.ConActions.ifdead())
        {
            GlobalMembers.ConActions.globalsound(DUKE_TALKTOBOSSFALL);
            GlobalMembers.ConActions.addkills(1);
            GlobalMembers.ConActions.Ai(AIBOSS4DYING);
            GlobalMembers.ConActions.sound(BOS4_DYING);
            GlobalMembers.ConActions.sound(BOSS4_DEADSPEECH);
        }
        else
        {
            GlobalMembers.ConActions.soundonce(BOS4_PAIN);
            GlobalMembers.ConActions.debris(SCRAP1, 1);
            GlobalMembers.ConActions.guts(JIBS6, 1);
            if (GlobalMembers.ConActions.ifaction(ABOSS4LAYIT))
                return;
            if (GlobalMembers.ConActions.ifrnd(16))
            {
                GlobalMembers.ConActions.ConAction BOSS4FLINTCH = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.Move(0);
            }
        }
    }
    private void boss4code()
    {
        if (GlobalMembers.ConActions.ifai(0))
            GlobalMembers.ConActions.Ai(AIBOSS4LAYEGGS);
        else
        if (GlobalMembers.ConActions.ifaction(BOSS4FLINTCH))
        {
            if (GlobalMembers.ConActions.ifactioncount(3))
                GlobalMembers.ConActions.Ai(AIBOSS4LAYEGGS);
        }
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS4LAYEGGS))
            boss4layeggs();
        else
        if (GlobalMembers.ConActions.ifai(AIBOSS4SHOOT))
            boss4shootstate();
        if (GlobalMembers.ConActions.ifai(AIBOSS4DYING))
            boss4dyingstate();
        else
        {
            if (GlobalMembers.ConActions.ifhitweapon())
                checkboss4hitstate();
            else
                if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifpdistl(1280))
                {
                    GlobalMembers.ConActions.addphealth(-1000);
                    GlobalMembers.ConActions.palfrom(63, 63);
                }
        }
    }
    private void A_BOSS4STAYPUT()
    {
        GlobalMembers.ConActions.fall();
        GlobalMembers.ConActions.cactor(BOSS4);
        GlobalMembers.ConActions.spritepal(6);
        boss4code();
        GlobalMembers.ConActions.getlastpal();
    }
    private void A_BOSS4()
    {
        GlobalMembers.ConActions.fall();
        GlobalMembers.ConActions.cactor(BOSS4);
        GlobalMembers.ConActions.spritepal(6);
        boss4code();
        GlobalMembers.ConActions.getlastpal();
    }
    GlobalMembers.ConActions.ConAction ANEWBEASTSTAND = new GlobalMembers.ConActions.ConAction(0);
    GlobalMembers.ConActions.ConAction ANEWBEASTWALKING = new GlobalMembers.ConActions.ConAction(10, 4, 5, 1, 12);
    GlobalMembers.ConActions.ConAction ANEWBEASTRUNNING = new GlobalMembers.ConActions.ConAction(10, 4, 5, 1, 8);
    GlobalMembers.ConActions.ConAction ANEWBEASTTHINK = new GlobalMembers.ConActions.ConAction(0, 2, 5, 1, 40);
    GlobalMembers.ConActions.ConAction ANEWBEASTSCRATCHING = new GlobalMembers.ConActions.ConAction(30, 3, 5, 1, 20);
    GlobalMembers.ConActions.ConAction ANEWBEASTDYING = new GlobalMembers.ConActions.ConAction(72, 8, 1, 1, 15);
    GlobalMembers.ConActions.ConAction ANEWBEASTFLINTCH = new GlobalMembers.ConActions.ConAction(71, 1, 1, 1, 1);
    GlobalMembers.ConActions.ConAction ANEWBEASTLYINGDEAD = new GlobalMembers.ConActions.ConAction(79, 1, 1);
    GlobalMembers.ConActions.ConAction ANEWBEASTSCREAM = new GlobalMembers.ConActions.ConAction(50, 2, 5, 1, 40);
    GlobalMembers.ConActions.ConAction ANEWBEASTJUMP = new GlobalMembers.ConActions.ConAction(80, 2, 5, 1, 50);
    GlobalMembers.ConActions.ConAction ANEWBEASTFALL = new GlobalMembers.ConActions.ConAction(90, 1, 5);
    GlobalMembers.ConActions.ConAction ANEWBEASTFROZEN = new GlobalMembers.ConActions.ConAction(10, 1, 5);
    GlobalMembers.ConActions.ConAction ANEWBEASTHANG = new GlobalMembers.ConActions.ConAction(0, 1, 5);
    private void A_enemy()
    {
        if (GlobalMembers.ConActions.ifaction(0))
        {
            GlobalMembers.ConActions.ConAction ANEWBEASTHANG = new GlobalMembers.ConActions.ConAction();
            GlobalMembers.ConActions.cstator(257);
            GlobalMembers.ConActions.sizeat(40, 40);
        }
        else
    if (GlobalMembers.ConActions.ifhitweapon())
        {
            GlobalMembers.ConActions.cactor(NEWBEAST);
            GlobalMembers.ConActions.ConAction ANEWBEASTSTAND = new GlobalMembers.ConActions.ConAction();
            GlobalMembers.ConActions.sound(NEWBEAST_PAIN);
        }
        else
        if (GlobalMembers.ConActions.ifspawnedby(BOSS4))
            if (GlobalMembers.ConActions.ifcount(200))
                if (GlobalMembers.ConActions.ifrnd(1))
                {
                    GlobalMembers.ConActions.cactor(NEWBEAST);
                    GlobalMembers.ConActions.ConAction ANEWBEASTSTAND = new GlobalMembers.ConActions.ConAction();
                    GlobalMembers.ConActions.sound(NEWBEAST_PAIN);
                }
    }
    GlobalMembers.ConActions.ConAction ANEWBEASTHANGDEAD = new GlobalMembers.ConActions.ConAction(-1, 1, 5);
    private void A_enemy()
    {
        if (GlobalMembers.ConActions.ifaction(0))
        {
            GlobalMembers.ConActions.ConAction ANEWBEASTHANGDEAD = new GlobalMembers.ConActions.ConAction();
            GlobalMembers.ConActions.sizeat(40, 40);
            GlobalMembers.ConActions.cstator(257);
        }
        else
    if (GlobalMembers.ConActions.ifhitweapon())
        {
            if (GlobalMembers.ConActions.ifdead())
            {
                standard_jibs();
                GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.sound(SQUISHED);
                GlobalMembers.ConActions.killit();
            }
            else
            {
                GlobalMembers.ConActions.guts(JIBS6, 1);
                GlobalMembers.ConActions.sound(SQUISHED);
            }
        }
    }
    GlobalMembers.ConActions.MoveAction NEWBEASTWALKVEL = new GlobalMembers.ConActions.MoveAction(182);
    GlobalMembers.ConActions.MoveAction NEWBEASTRUNVEL = new GlobalMembers.ConActions.MoveAction(256);
    GlobalMembers.ConActions.MoveAction NEWBEASTJUMPVEL = new GlobalMembers.ConActions.MoveAction(264);
    GlobalMembers.ConActions.MoveAction NEWBEASTSTOP = new GlobalMembers.ConActions.MoveAction();
    GlobalMembers.ConActions.AIAction AINEWBEASTGETENEMY = new GlobalMembers.ConActions.AIAction(ANEWBEASTWALKING, NEWBEASTWALKVEL, seekplayer);
    GlobalMembers.ConActions.AIAction AINEWBEASTDODGE = new GlobalMembers.ConActions.AIAction(ANEWBEASTRUNNING, NEWBEASTRUNVEL, dodgebullet);
    GlobalMembers.ConActions.AIAction AINEWBEASTCHARGEENEMY = new GlobalMembers.ConActions.AIAction(ANEWBEASTRUNNING, NEWBEASTRUNVEL, seekplayer);
    GlobalMembers.ConActions.AIAction AINEWBEASTFLEENEMY = new GlobalMembers.ConActions.AIAction(ANEWBEASTWALKING, NEWBEASTWALKVEL, fleeenemy);
    GlobalMembers.ConActions.AIAction AINEWBEASTSCRATCHENEMY = new GlobalMembers.ConActions.AIAction(ANEWBEASTSCRATCHING, NEWBEASTSTOP, faceplayerslow);
    GlobalMembers.ConActions.AIAction AINEWBEASTJUMPENEMY = new GlobalMembers.ConActions.AIAction(ANEWBEASTJUMP, NEWBEASTJUMPVEL, jumptoplayer);
    GlobalMembers.ConActions.AIAction AINEWBEASTTHINK = new GlobalMembers.ConActions.AIAction(ANEWBEASTTHINK, NEWBEASTSTOP);
    GlobalMembers.ConActions.AIAction AINEWBEASTGROW = new GlobalMembers.ConActions.AIAction(ANEWBEASTSTAND, NEWBEASTSTOP, faceplayerslow);
    GlobalMembers.ConActions.AIAction AINEWBEASTDYING = new GlobalMembers.ConActions.AIAction(ANEWBEASTDYING, NEWBEASTSTOP, faceplayer);
    GlobalMembers.ConActions.AIAction AINEWBEASTSHOOT = new GlobalMembers.ConActions.AIAction(ANEWBEASTSCREAM, NEWBEASTSTOP, faceplayerslow);
    GlobalMembers.ConActions.AIAction AINEWBEASTFLINTCH = new GlobalMembers.ConActions.AIAction(ANEWBEASTFLINTCH, NEWBEASTSTOP, faceplayerslow);
    private void newbeastseekstate()
    {
        if (GlobalMembers.ConActions.ifactornotstayput())
        {
            if (GlobalMembers.ConActions.ifp(palive))
                if (GlobalMembers.ConActions.ifcansee())
                    if (GlobalMembers.ConActions.ifpdistl(1596))
                    {
                        GlobalMembers.ConActions.Ai(AINEWBEASTSCRATCHENEMY);
                        return;
                    }
            if (GlobalMembers.ConActions.ifai(AINEWBEASTCHARGEENEMY))
            {
                if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifpdistl(1596))
                        if (GlobalMembers.ConActions.ifcansee())
                        {
                            GlobalMembers.ConActions.Ai(AINEWBEASTSCRATCHENEMY);
                            return;
                        }
                if (GlobalMembers.ConActions.ifrnd(1))
                    if (GlobalMembers.ConActions.ifpdistg(4096))
                        if (GlobalMembers.ConActions.ifp(palive))
                            if (GlobalMembers.ConActions.ifcansee())
                            {
                                GlobalMembers.ConActions.Ai(AINEWBEASTSHOOT);
                                return;
                            }
            }
            else
        if (GlobalMembers.ConActions.ifpdistg(4096))
            {
                GlobalMembers.ConActions.Ai(AINEWBEASTCHARGEENEMY);
                return;
            }
            if (GlobalMembers.ConActions.iffloordistl(16))
            {
                if (GlobalMembers.ConActions.ifcount(32))
                    if (GlobalMembers.ConActions.ifrnd(16))
                    {
                        if (GlobalMembers.ConActions.ifceilingdistl(96))
                            return;
                        GlobalMembers.ConActions.Ai(AINEWBEASTJUMPENEMY);
                    }
                return;
            }
            if (GlobalMembers.ConActions.ifrnd(4))
            {
                if (GlobalMembers.ConActions.ifnotmoving())
                    GlobalMembers.ConActions.operate();
            }
            else
            if (GlobalMembers.ConActions.ifrnd(16))
                if (GlobalMembers.ConActions.ifbulletnear())
                {
                    if (GlobalMembers.ConActions.ifgapzl(128))
                        GlobalMembers.ConActions.Ai(AINEWBEASTDODGE);
                    else
                    if (GlobalMembers.ConActions.ifactornotstayput())
                    {
                        if (GlobalMembers.ConActions.ifrnd(128))
                        {
                            if (GlobalMembers.ConActions.ifceilingdistl(96))
                                return;
                            GlobalMembers.ConActions.Ai(AINEWBEASTJUMPENEMY);
                        }
                        else
                            GlobalMembers.ConActions.Ai(AINEWBEASTDODGE);
                    }
                }
        }
        else
        {
            if (GlobalMembers.ConActions.ifactioncount(16))
            {
                if (GlobalMembers.ConActions.ifp(palive))
                    if (GlobalMembers.ConActions.ifpdistl(1596))
                        if (GlobalMembers.ConActions.ifcansee())
                        {
                            GlobalMembers.ConActions.Ai(AINEWBEASTSCRATCHENEMY);
                            return;
                        }
            }
            if (GlobalMembers.ConActions.ifcount(16))
                if (GlobalMembers.ConActions.ifrnd(32))
                    GlobalMembers.ConActions.Move(NEWBEASTWALKVEL, randomangle, geth);
        }
    }
    private void newbeastfleestate()
    {
        if (GlobalMembers.ConActions.ifcount(8))
        {
            if (GlobalMembers.ConActions.ifrnd(64))
                if (GlobalMembers.ConActions.ifpdistg(3500))
                    if (GlobalMembers.ConActions.ifp(palive))
                        if (GlobalMembers.ConActions.ifcansee())
                            GlobalMembers.ConActions.Ai(AINEWBEASTSHOOT);
        }
        else
        {
            if (GlobalMembers.ConActions.iffloordistl(16))
            {
                if (GlobalMembers.ConActions.ifnotmoving())
                    GlobalMembers.ConActions.Ai(AINEWBEASTGETENEMY);
            }
            else
                GlobalMembers.ConActions.Ai(AINEWBEASTGETENEMY);
            return;
        }
    }
    private void newbeastthinkstate()
    {
        if (GlobalMembers.ConActions.ifrnd(8))
            GlobalMembers.ConActions.soundonce(NEWBEAST_ROAM);
        if (GlobalMembers.ConActions.ifactioncount(3))
        {
            if (GlobalMembers.ConActions.ifrnd(128))
            {
                if (GlobalMembers.ConActions.ifpdistg(3500))
                    if (GlobalMembers.ConActions.ifp(palive))
                        if (GlobalMembers.ConActions.ifcansee())
                            GlobalMembers.ConActions.Ai(AINEWBEASTSHOOT);
            }
            else
                GlobalMembers.ConActions.Ai(AINEWBEASTGETENEMY);
        }
        if (GlobalMembers.ConActions.ifrnd(16))
            if (GlobalMembers.ConActions.ifbulletnear())
            {
                if (GlobalMembers.ConActions.ifgapzl(96))
                    GlobalMembers.ConActions.Ai(AINEWBEASTDODGE);
                else
                {
                    if (GlobalMembers.ConActions.ifrnd(128))
                    {
                        if (GlobalMembers.ConActions.ifceilingdistl(144))
                            return;
                        GlobalMembers.ConActions.Ai(AINEWBEASTJUMPENEMY);
                    }
                    else
                        GlobalMembers.ConActions.Ai(AINEWBEASTDODGE);
                }
            }
    }
    private void newbeastscratchstate()
    {
        if (GlobalMembers.ConActions.ifcount(20))
            if (GlobalMembers.ConActions.ifrnd(8))
            {
                if (GlobalMembers.ConActions.ifcansee())
                    if (GlobalMembers.ConActions.ifpdistl(2048))
                    {
                        if (GlobalMembers.ConActions.ifrnd(128))
                            GlobalMembers.ConActions.Ai(AINEWBEASTFLEENEMY);
                        return;
                    }
                if (GlobalMembers.ConActions.ifrnd(80))
                    GlobalMembers.ConActions.Ai(AINEWBEASTTHINK);
                else
                    GlobalMembers.ConActions.Ai(AINEWBEASTGETENEMY);
            }
        if (GlobalMembers.ConActions.ifactioncount(3))
        {
            if (GlobalMembers.ConActions.ifpdistg(1596))
                GlobalMembers.ConActions.Ai(AINEWBEASTTHINK);
            else
                if (GlobalMembers.ConActions.ifp(palive, ifcansee))
            {
                GlobalMembers.ConActions.palfrom(16, 16);
                GlobalMembers.ConActions.addphealth(NEWBEASTSCRATCHAMOUNT);
                GlobalMembers.ConActions.sound(DUKE_GRUNT);
                GlobalMembers.ConActions.resetactioncount();
                GlobalMembers.ConActions.resetcount();
            }
        }
        else
        if (GlobalMembers.ConActions.ifcount(15))
// nullop
else
    if (GlobalMembers.ConActions.ifcount(14))
                {
                    if (GlobalMembers.ConActions.ifpdistl(1596))
                        GlobalMembers.ConActions.soundonce(NEWBEAST_ATTACK);
                    else
                        GlobalMembers.ConActions.soundonce(NEWBEAST_ATTACKMISS);
                }
    }
    private void checknewbeasthit()
    {
        GlobalMembers.ConActions.spawn(BLOOD);
        if (GlobalMembers.ConActions.ifdead())
        {
            if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
            {
                GlobalMembers.ConActions.sound(SOMETHINGFROZE);
                GlobalMembers.ConActions.spritepal(1);
                GlobalMembers.ConActions.Move(0);
                GlobalMembers.ConActions.ConAction ANEWBEASTFROZEN = new GlobalMembers.ConActions.ConAction();
                GlobalMembers.ConActions.strength(0);
                return;
            }
            if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
            {
                GlobalMembers.ConActions.cstat(0);
                GlobalMembers.ConActions.sound(ACTOR_GROWING);
                GlobalMembers.ConActions.Ai(AINEWBEASTGROW);
                return;
            }
            GlobalMembers.ConActions.addkills(1);
            if (GlobalMembers.ConActions.ifwasweapon(RPG))
            {
                GlobalMembers.ConActions.sound(SQUISHED);
                liz_body_jibs();
                standard_jibs();
                GlobalMembers.ConActions.killit();
            }
            else
            if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
            {
                GlobalMembers.ConActions.sound(SQUISHED);
                liz_body_jibs();
                standard_jibs();
                GlobalMembers.ConActions.killit();
            }
            else
            {
                rf();
                GlobalMembers.ConActions.Ai(AINEWBEASTDYING);
                if (GlobalMembers.ConActions.ifrnd(64))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
            }
            GlobalMembers.ConActions.sound(NEWBEAST_DYING);
        }
        else
        {
            GlobalMembers.ConActions.sound(NEWBEAST_PAIN);
            if (GlobalMembers.ConActions.ifwasweapon(GROWSPARK))
                GlobalMembers.ConActions.sound(EXPANDERHIT);
            random_wall_jibs();
            if (GlobalMembers.ConActions.ifrnd(32))
                GlobalMembers.ConActions.Ai(AINEWBEASTFLINTCH);
            else
            if (GlobalMembers.ConActions.ifrnd(32))
                if (GlobalMembers.ConActions.ifpdistg(3500))
                    if (GlobalMembers.ConActions.ifp(palive))
                        if (GlobalMembers.ConActions.ifcansee())
                            GlobalMembers.ConActions.Ai(AINEWBEASTSHOOT);
        }
    }
    private void newbeastjumpstate()
    {
        if (GlobalMembers.ConActions.ifaction(ANEWBEASTFALL))
        {
            if (GlobalMembers.ConActions.iffloordistl(16))
                GlobalMembers.ConActions.Ai(AINEWBEASTGETENEMY);
        }
        else
        if (GlobalMembers.ConActions.ifcount(32))
            GlobalMembers.ConActions.ConAction ANEWBEASTFALL = new GlobalMembers.ConActions.ConAction();
    }
    private void newbeastdyingstate()
    {
        if (GlobalMembers.ConActions.ifaction(ANEWBEASTLYINGDEAD))
        {
            GlobalMembers.ConActions.strength(0);
            if (GlobalMembers.ConActions.ifhitweapon())
                if (GlobalMembers.ConActions.ifwasweapon(RADIUSEXPLOSION))
                {
                    GlobalMembers.ConActions.sound(SQUISHED);
                    standard_jibs();
                    GlobalMembers.ConActions.killit();
                }
            if (GlobalMembers.ConActions.ifcount(RESPAWNACTORTIME))
                if (GlobalMembers.ConActions.ifrespawn())
                {
                    GlobalMembers.ConActions.spawn(TRANSPORTERSTAR);
                    GlobalMembers.ConActions.cstat(257);
                    GlobalMembers.ConActions.strength(NEWBEASTSTRENGTH);
                    GlobalMembers.ConActions.Ai(AINEWBEASTGETENEMY);
                }
        }
        else
        if (GlobalMembers.ConActions.ifai(AINEWBEASTDYING))
            if (GlobalMembers.ConActions.ifactioncount(7))
            {
                if (GlobalMembers.ConActions.iffloordistl(8))
                    GlobalMembers.ConActions.sound(THUD);
                GlobalMembers.ConActions.Move(NEWBEASTSTOP);
                GlobalMembers.ConActions.ConAction ANEWBEASTLYINGDEAD = new GlobalMembers.ConActions.ConAction();
            }
    }
    private void newbeastdodgestate()
    {
        if (GlobalMembers.ConActions.ifcount(13))
            GlobalMembers.ConActions.Ai(AINEWBEASTGETENEMY);
    }
    private void A_enemystayput()
    {
    }
    private void A_enemy()
    {
    }
    private void newbeastcode()
    {
        checksquished();
        if (GlobalMembers.ConActions.ifai(0))
        {
            GlobalMembers.ConActions.cstator(257);
            GlobalMembers.ConActions.Ai(AINEWBEASTGETENEMY);
        }
        else
        if (GlobalMembers.ConActions.ifaction(ANEWBEASTLYINGDEAD))
        {
            GlobalMembers.ConActions.fall();
            newbeastdyingstate();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifaction(ANEWBEASTFROZEN))
        {
            if (GlobalMembers.ConActions.ifcount(THAWTIME))
            {
                GlobalMembers.ConActions.Ai(AINEWBEASTGETENEMY);
                GlobalMembers.ConActions.spritepal(0);
            }
            else
            if (GlobalMembers.ConActions.ifcount(FROZENDRIPTIME))
            {
                if (GlobalMembers.ConActions.ifactioncount(26))
                {
                    GlobalMembers.ConActions.spawn(WATERDRIP);
                    GlobalMembers.ConActions.resetactioncount();
                }
            }
            if (GlobalMembers.ConActions.ifhitweapon())
            {
                if (GlobalMembers.ConActions.ifwasweapon(FREEZEBLAST))
                {
                    GlobalMembers.ConActions.strength(0);
                    return;
                }
                GlobalMembers.ConActions.addkills(1);
                if (GlobalMembers.ConActions.ifrnd(84))
                    GlobalMembers.ConActions.spawn(BLOODPOOL);
                GlobalMembers.ConActions.lotsofglass(30);
                GlobalMembers.ConActions.sound(GLASS_BREAKING);
                GlobalMembers.ConActions.killit();
            }
            if (GlobalMembers.ConActions.ifp(pfacing))
                if (GlobalMembers.ConActions.ifpdistl(FROZENQUICKKICKDIST))
                    GlobalMembers.ConActions.pkick();
            return;
        }
        else
        if (GlobalMembers.ConActions.ifai(AINEWBEASTJUMPENEMY))
            newbeastjumpstate();
        else
        {
            GlobalMembers.ConActions.fall();
            if (GlobalMembers.ConActions.ifai(AINEWBEASTGETENEMY))
                newbeastseekstate();
            else
            if (GlobalMembers.ConActions.ifai(AINEWBEASTCHARGEENEMY))
                newbeastseekstate();
            else
            if (GlobalMembers.ConActions.ifai(AINEWBEASTFLINTCH))
            {
                if (GlobalMembers.ConActions.ifcount(8))
                    GlobalMembers.ConActions.Ai(AINEWBEASTGETENEMY);
            }
            else
            if (GlobalMembers.ConActions.ifai(AINEWBEASTDODGE))
                newbeastdodgestate();
            else
            if (GlobalMembers.ConActions.ifai(AINEWBEASTSCRATCHENEMY))
                newbeastscratchstate();
            else
            if (GlobalMembers.ConActions.ifai(AINEWBEASTFLEENEMY))
                newbeastfleestate();
            else
            if (GlobalMembers.ConActions.ifai(AINEWBEASTTHINK))
                newbeastthinkstate();
            else
            if (GlobalMembers.ConActions.ifai(AINEWBEASTGROW))
                genericgrowcode();
            else
            if (GlobalMembers.ConActions.ifai(AINEWBEASTDYING))
                newbeastdyingstate();
            else
            if (GlobalMembers.ConActions.ifai(AINEWBEASTSHOOT))
            {
                if (GlobalMembers.ConActions.ifp(pshrunk))
                    GlobalMembers.ConActions.Ai(AINEWBEASTGETENEMY);
                else
                if (GlobalMembers.ConActions.ifcount(26))
                    GlobalMembers.ConActions.Ai(AINEWBEASTGETENEMY);
                else
                if (GlobalMembers.ConActions.ifcount(25))
                    GlobalMembers.ConActions.shoot(SHRINKER);
                else
                {
                    if (GlobalMembers.ConActions.ifcount(5))
// nullop
else
    if (GlobalMembers.ConActions.ifcount(4))
                                GlobalMembers.ConActions.sound(NEWBEAST_SPIT);
                }
            }
        }
        if (GlobalMembers.ConActions.ifhitweapon())
            checknewbeasthit();
    }
    private void A_enemy()
    {
        GlobalMembers.ConActions.fall();
        if (GlobalMembers.ConActions.ifaction(0))
        {
            GlobalMembers.ConActions.cstator(257);
            GlobalMembers.ConActions.sizeat(40, 40);
            GlobalMembers.ConActions.Ai(AINEWBEASTDODGE);
        }
        if (GlobalMembers.ConActions.ifaction(ANEWBEASTFROZEN))
            newbeastcode();
        else
        {
            GlobalMembers.ConActions.spritepal(6);
            newbeastcode();
            if (GlobalMembers.ConActions.ifaction(ANEWBEASTFROZEN))
                return;
            GlobalMembers.ConActions.getlastpal();
        }
    }
    public ConScript()
    {
        GlobalMembers.ConActions.gamestartup(DEFAULTVISIBILITY, GENERICIMPACTDAMAGE, MAXPLAYERHEALTH, STARTARMORHEALTH, RESPAWNACTORTIME, RESPAWNITEMTIME, RUNNINGSPEED, GRAVITATIONALCONSTANT, RPGBLASTRADIUS, PIPEBOMBRADIUS, SHRINKERBLASTRADIUS, TRIPBOMBBLASTRADIUS, MORTERBLASTRADIUS, BOUNCEMINEBLASTRADIUS, SEENINEBLASTRADIUS, MAXPISTOLAMMO, MAXSHOTGUNAMMO, MAXCHAINGUNAMMO, MAXRPGAMMO, MAXHANDBOMBAMMO, MAXSHRINKERAMMO, MAXDEVISTATORAMMO, MAXTRIPBOMBAMMO, MAXFREEZEAMMO, MAXGROWAMMO, CAMERASDESTRUCTABLE, NUMFREEZEBOUNCES, FREEZERHURTOWNER, QSIZE, TRIPBOMBLASERMODE);
        GlobalMembers.ConActions.definequote(0, "AUTO AIMING ");
        GlobalMembers.ConActions.definequote(1, "SHOW MAP: OFF ");
        GlobalMembers.ConActions.definequote(2, "ACTIVATED ");
        GlobalMembers.ConActions.definequote(3, "PORTABLE MEDKIT ");
        GlobalMembers.ConActions.definequote(4, "LOCKED ");
        GlobalMembers.ConActions.definequote(5, "GIVING EVERYTHING! ");
        GlobalMembers.ConActions.definequote(6, "BOOTS ");
        GlobalMembers.ConActions.definequote(7, "WASTED! ");
        GlobalMembers.ConActions.definequote(8, "UNLOCKED ");
        GlobalMembers.ConActions.definequote(9, "A SECRET PLACE! ");
        GlobalMembers.ConActions.definequote(10, "SQUISH! ");
        GlobalMembers.ConActions.definequote(11, "ALL DOORS UNLOCKED ");
        GlobalMembers.ConActions.definequote(12, "USED STEROIDS ");
        GlobalMembers.ConActions.definequote(13, "PRESS SPACE TO RESTART LEVEL ");
        GlobalMembers.ConActions.definequote(14, "AMMO FOR DEVASTATOR ");
        GlobalMembers.ConActions.definequote(15, "DEACTIVATED ");
        GlobalMembers.ConActions.definequote(16, "SWITCH OPERATED ONLY! ");
        GlobalMembers.ConActions.definequote(17, "GOD MODE: ON ");
        GlobalMembers.ConActions.definequote(18, "GOD MODE: OFF ");
        GlobalMembers.ConActions.definequote(19, "ATOMIC HEALTH! ");
        GlobalMembers.ConActions.definequote(20, "CROSSHAIR: ON ");
        GlobalMembers.ConActions.definequote(21, "CROSSHAIR: OFF ");
        GlobalMembers.ConActions.definequote(22, "YOU'RE TOO GOOD TO BE CHEATING! ");
        GlobalMembers.ConActions.definequote(23, "MESSAGES: ON ");
        GlobalMembers.ConActions.definequote(24, "MESSAGES: OFF ");
        GlobalMembers.ConActions.definequote(25, "TYPE THE CHEAT CODE: ");
        GlobalMembers.ConActions.definequote(26, "DETAIL: LOW ");
        GlobalMembers.ConActions.definequote(27, "DETAIL: HIGH ");
        GlobalMembers.ConActions.definequote(28, "WILL ALWAYS HAVE NO FUTURE ");
        GlobalMembers.ConActions.definequote(29, "BRIGHTNESS LEVEL: ONE ");
        GlobalMembers.ConActions.definequote(30, "BRIGHTNESS LEVEL: TWO ");
        GlobalMembers.ConActions.definequote(31, "BRIGHTNESS LEVEL: THREE ");
        GlobalMembers.ConActions.definequote(32, "BRIGHTNESS LEVEL: FOUR ");
        GlobalMembers.ConActions.definequote(33, "BRIGHTNESS LEVEL: FIVE ");
        GlobalMembers.ConActions.definequote(34, "SOUND: ON ");
        GlobalMembers.ConActions.definequote(35, "SOUND: OFF ");
        GlobalMembers.ConActions.definequote(36, "SCREEN CAPTURED ");
        GlobalMembers.ConActions.definequote(37, "STEROIDS ");
        GlobalMembers.ConActions.definequote(38, "ARMOR ");
        GlobalMembers.ConActions.definequote(39, "SCUBA GEAR ");
        GlobalMembers.ConActions.definequote(40, "Press F1 for Help ");
        GlobalMembers.ConActions.definequote(41, "JETPACK ");
        GlobalMembers.ConActions.definequote(42, "BODY SUIT ");
        GlobalMembers.ConActions.definequote(43, "ACCESS CARD ");
        GlobalMembers.ConActions.definequote(44, "MOUSE AIMING OFF ");
        GlobalMembers.ConActions.definequote(45, "MOUSE AIMING ON ");
        GlobalMembers.ConActions.definequote(46, "CHEAT CODE: UNRECOGNIZED ");
        GlobalMembers.ConActions.definequote(47, "HOLODUKE ON ");
        GlobalMembers.ConActions.definequote(48, "HOLODUKE OFF ");
        GlobalMembers.ConActions.definequote(49, "HOLODUKE NOT FOUND YET! ");
        GlobalMembers.ConActions.definequote(50, "JETPACK NOT FOUND YET! ");
        GlobalMembers.ConActions.definequote(51, "HOLODUKE ");
        GlobalMembers.ConActions.definequote(52, "JETPACK ON ");
        GlobalMembers.ConActions.definequote(53, "JETPACK OFF ");
        GlobalMembers.ConActions.definequote(54, "CHAINGUN CANNON! ");
        GlobalMembers.ConActions.definequote(55, "PIPEBOMB! ");
        GlobalMembers.ConActions.definequote(56, "RPG! ");
        GlobalMembers.ConActions.definequote(57, "SHOTGUN ");
        GlobalMembers.ConActions.definequote(58, "LASER TRIPBOMB! ");
        GlobalMembers.ConActions.definequote(59, "FREEZETHROWER! ");
        GlobalMembers.ConActions.definequote(60, "GOT SHRINKER/EXPANDER! ");
        GlobalMembers.ConActions.definequote(61, "SMALL MEDKIT: +10 ");
        GlobalMembers.ConActions.definequote(62, "LARGE MEDKIT: +30 ");
        GlobalMembers.ConActions.definequote(63, "AMMO FOR CHAINGUN CANNON! ");
        GlobalMembers.ConActions.definequote(64, "AMMO FOR RPG! ");
        GlobalMembers.ConActions.definequote(65, "AMMO FOR PISTOL! ");
        GlobalMembers.ConActions.definequote(66, "AMMO FOR FREEZETHROWER! ");
        GlobalMembers.ConActions.definequote(67, "BOOTS OFF ");
        GlobalMembers.ConActions.definequote(68, "BOOTS ON ");
        GlobalMembers.ConActions.definequote(69, "AMMO FOR SHOTGUN ");
        GlobalMembers.ConActions.definequote(70, "BLUE ACCESS CARD REQUIRED ");
        GlobalMembers.ConActions.definequote(71, "RED ACCESS CARD REQUIRED ");
        GlobalMembers.ConActions.definequote(72, "YELLOW ACCESS CARD REQUIRED ");
        GlobalMembers.ConActions.definequote(73, "WEAPON LOWERED ");
        GlobalMembers.ConActions.definequote(74, "WEAPON RAISED ");
        GlobalMembers.ConActions.definequote(75, "PROTECTIVE BOOTS ON ");
        GlobalMembers.ConActions.definequote(76, "SCUBA GEAR ON ");
        GlobalMembers.ConActions.definequote(77, "SPACE SUIT ON ");
        GlobalMembers.ConActions.definequote(78, "AMMO FOR SHRINKER ");
        GlobalMembers.ConActions.definequote(79, "BUY MAJOR STRYKER ");
        GlobalMembers.ConActions.definequote(80, "MIGHTY FOOT ENGAGED ");
        GlobalMembers.ConActions.definequote(81, "WEAPON MODE ON ");
        GlobalMembers.ConActions.definequote(82, "WEAPON MODE OFF ");
        GlobalMembers.ConActions.definequote(83, "FOLLOW MODE OFF ");
        GlobalMembers.ConActions.definequote(84, "FOLLOW MODE ON ");
        GlobalMembers.ConActions.definequote(85, "RUN MODE OFF ");
        GlobalMembers.ConActions.definequote(86, "RUN MODE ON ");
        GlobalMembers.ConActions.definequote(87, "DEVASTATOR WEAPON ");
        GlobalMembers.ConActions.definequote(88, "JET PACK ");
        GlobalMembers.ConActions.definequote(89, "AIRTANK ");
        GlobalMembers.ConActions.definequote(90, "STEROIDS ");
        GlobalMembers.ConActions.definequote(91, "HOLODUKE ");
        GlobalMembers.ConActions.definequote(92, "MUSIC: ON ");
        GlobalMembers.ConActions.definequote(93, "MUSIC: OFF ");
        GlobalMembers.ConActions.definequote(94, "SCROLL MODE: ON ");
        GlobalMembers.ConActions.definequote(95, "SCROLL MODE: OFF ");
        GlobalMembers.ConActions.definequote(96, "BRIGHTNESS LEVEL: SIX ");
        GlobalMembers.ConActions.definequote(97, "BRIGHTNESS LEVEL: SEVEN ");
        GlobalMembers.ConActions.definequote(98, "BRIGHTNESS LEVEL: EIGHT ");
        GlobalMembers.ConActions.definequote(99, "REGISTER COSMO TODAY! ");
        GlobalMembers.ConActions.definequote(100, "ALL LOCKS TOGGLED ");
        GlobalMembers.ConActions.definequote(101, "NIGHT VISION GOGGLES ");
        GlobalMembers.ConActions.definequote(102, "WE'RE GONNA FRY YOUR ASS, NUKEM! ");
        GlobalMembers.ConActions.definequote(103, "SCREEN SAVED ");
        GlobalMembers.ConActions.definequote(104, "GOT USED ARMOR ");
        GlobalMembers.ConActions.definequote(105, "PIRATES SUCK! ");
        GlobalMembers.ConActions.definequote(106, "NIGHT VISION ON ");
        GlobalMembers.ConActions.definequote(107, "NIGHT VISION OFF ");
        GlobalMembers.ConActions.definequote(108, "YOU'RE BURNING! ");
        GlobalMembers.ConActions.definequote(109, "VIEW MODE OFF ");
        GlobalMembers.ConActions.definequote(110, "VIEW MODE ON ");
        GlobalMembers.ConActions.definequote(111, "SHOW MAP: ON ");
        GlobalMembers.ConActions.definequote(112, "CLIPPING: ON ");
        GlobalMembers.ConActions.definequote(113, "CLIPPING: OFF ");
        GlobalMembers.ConActions.definequote(114, "!!! INCORRECT VERSION !!! ");
        GlobalMembers.ConActions.definequote(115, "<Please Leave Blank> ");
        GlobalMembers.ConActions.definequote(116, "<Please Leave Blank> ");
        GlobalMembers.ConActions.definequote(117, "<Please Leave Blank> ");
        GlobalMembers.ConActions.definequote(118, "YOU CANNOT "QUICK SAVE" WHEN DEAD ");
        GlobalMembers.ConActions.definequote(119, "GOT ALL WEAPONS/AMMO ");
        GlobalMembers.ConActions.definequote(120, "GOT ALL INVENTORY ");
        GlobalMembers.ConActions.definequote(121, "GOT ALL KEYS ");
        GlobalMembers.ConActions.definequote(122, "<Please Leave Blank> ");
        GlobalMembers.ConActions.definequote(123, "AMMO FOR EXPANDER ");
        GlobalMembers.ConActions.definequote(124, "MAP HAS A DIFFERENT NUMBER OF PLAYERS ");
        GlobalMembers.ConActions.definevolumename(0, "L.A. MELTDOWN ");
        GlobalMembers.ConActions.definevolumename(1, "LUNAR APOCALYPSE ");
        GlobalMembers.ConActions.definevolumename(2, "SHRAPNEL CITY ");
        GlobalMembers.ConActions.definevolumename(3, "THE BIRTH ");
        GlobalMembers.ConActions.defineskillname(0, "PIECE OF CAKE ");
        GlobalMembers.ConActions.defineskillname(1, "LET'S ROCK ");
        GlobalMembers.ConActions.defineskillname(2, "COME GET SOME ");
        GlobalMembers.ConActions.defineskillname(3, "DAMN I'M GOOD ");
        GlobalMembers.ConActions.definelevelname(0, 0, "E1L1.map", "01:45", "00:53", "HOLLYWOOD HOLOCAUST ");
        GlobalMembers.ConActions.definelevelname(0, 1, "E1L2.map", "05:10", "03:21", "RED LIGHT DISTRICT ");
        GlobalMembers.ConActions.definelevelname(0, 2, "E1L3.map", "05:35", "03:41", "DEATH ROW ");
        GlobalMembers.ConActions.definelevelname(0, 3, "E1L4.map", "07:20", "04:40", "TOXIC DUMP ");
        GlobalMembers.ConActions.definelevelname(0, 4, "E1L5.map", "09:10", "05:00", "THE ABYSS ");
        GlobalMembers.ConActions.definelevelname(0, 5, "E1L6.map", "05:15", "02:58", "LAUNCH FACILITY ");
        GlobalMembers.ConActions.definelevelname(0, 6, "E1L7.map", "00:00", "00:00", "FACES OF DEATH ");
        GlobalMembers.ConActions.definelevelname(0, 7, "E1L8.map", "99:99", "99:99", "USER MAP ");
        GlobalMembers.ConActions.definelevelname(0, 8, "E1L9.map", "12:48", "16:32", "VOID ZONE ");
        GlobalMembers.ConActions.definelevelname(0, 9, "E1L10.map", "0T:HX", "11:38", "ROACH CONDO ");
        GlobalMembers.ConActions.definelevelname(0, 10, "E1L11.map", "08:67", "53:09", "ANTIPROFIT ");
        GlobalMembers.ConActions.definelevelname(1, 0, "E2L1.map", "02:30", "01:19", "SPACEPORT ");
        GlobalMembers.ConActions.definelevelname(1, 1, "E2L2.map", "02:30", "01:26", "INCUBATOR ");
        GlobalMembers.ConActions.definelevelname(1, 2, "E2L3.map", "05:00", "02:26", "WARP FACTOR ");
        GlobalMembers.ConActions.definelevelname(1, 3, "E2L4.map", "04:30", "02:14", "FUSION STATION ");
        GlobalMembers.ConActions.definelevelname(1, 4, "E2L5.map", "03:00", "01:26", "OCCUPIED TERRITORY ");
        GlobalMembers.ConActions.definelevelname(1, 5, "E2L6.map", "02:30", "01:04", "TIBERIUS STATION ");
        GlobalMembers.ConActions.definelevelname(1, 6, "E2L7.map", "04:45", "02:15", "LUNAR REACTOR ");
        GlobalMembers.ConActions.definelevelname(1, 7, "E2L8.map", "11:30", "04:59", "DARK SIDE ");
        GlobalMembers.ConActions.definelevelname(1, 8, "E2L9.map", "05:00", "02:26", "OVERLORD ");
        GlobalMembers.ConActions.definelevelname(1, 9, "E2L10.map", "03:00", "01:19", "SPIN CYCLE ");
        GlobalMembers.ConActions.definelevelname(1, 10, "E2L11.map", "03:00", "00:52", "LUNATIC FRINGE ");
        GlobalMembers.ConActions.definelevelname(2, 0, "E3L1.map", "02:30", "01:11", "RAW MEAT ");
        GlobalMembers.ConActions.definelevelname(2, 1, "E3L2.map", "04:45", "02:18", "BANK ROLL ");
        GlobalMembers.ConActions.definelevelname(2, 2, "E3L3.map", "03:00", "01:57", "FLOOD ZONE ");
        GlobalMembers.ConActions.definelevelname(2, 3, "E3L4.map", "03:15", "01:46", "L.A. RUMBLE ");
        GlobalMembers.ConActions.definelevelname(2, 4, "E3L5.map", "02:30", "01:04", "MOVIE SET ");
        GlobalMembers.ConActions.definelevelname(2, 5, "E3L6.map", "03:30", "01:30", "RABID TRANSIT ");
        GlobalMembers.ConActions.definelevelname(2, 6, "E3L7.map", "02:00", "00:55", "FAHRENHEIT ");
        GlobalMembers.ConActions.definelevelname(2, 7, "E3L8.map", "02:15", "01:09", "HOTEL HELL ");
        GlobalMembers.ConActions.definelevelname(2, 8, "E3L9.map", "02:45", "01:17", "STADIUM ");
        GlobalMembers.ConActions.definelevelname(2, 9, "E3L10.map", "00:45", "00:10", "TIER DROPS ");
        GlobalMembers.ConActions.definelevelname(2, 10, "E3L11.map", "02:00", "01:07", "FREEWAY ");
        GlobalMembers.ConActions.definelevelname(3, 0, "E4L1.map", "03:04", "01:32", "IT'S IMPOSSIBLE ");
        GlobalMembers.ConActions.definelevelname(3, 1, "E4L2.map", "04:00", "02:00", "DUKE-BURGER ");
        GlobalMembers.ConActions.definelevelname(3, 2, "E4L3.map", "03:30", "01:45", "SHOP-N-BAG ");
        GlobalMembers.ConActions.definelevelname(3, 3, "E4L4.map", "06:32", "03:16", "BABE LAND ");
        GlobalMembers.ConActions.definelevelname(3, 4, "E4L5.map", "02:02", "01:01", "PIGSTY ");
        GlobalMembers.ConActions.definelevelname(3, 5, "E4L6.map", "03:04", "01:52", "GOING POSTAL ");
        GlobalMembers.ConActions.definelevelname(3, 6, "E4L7.map", "01:24", "00:42", "XXX-STACY ");
        GlobalMembers.ConActions.definelevelname(3, 7, "E4L8.map", "03:18", "01:59", "CRITICAL MASS ");
        GlobalMembers.ConActions.definelevelname(3, 8, "E4L9.map", "05:02", "02:51", "DERELICT ");
        GlobalMembers.ConActions.definelevelname(3, 9, "E4L10.map", "10:50", "05:25", "THE QUEEN ");
        GlobalMembers.ConActions.definelevelname(3, 10, "E4L11.map", "04:20", "02:10", "AREA 51 ");
        GlobalMembers.ConActions.definemusic(0, "GRABBAG.MID", "BRIEFING.MID");
        GlobalMembers.ConActions.definemusic(1, "stalker.mid", "dethtoll.mid", "streets.mid", "watrwld1.mid", "snake1.mid", "thecall.mid", "ahgeez.mid", "dethtoll.mid", "streets.mid", "watrwld1.mid", "snake1.mid");
        GlobalMembers.ConActions.definemusic(2, "futurmil.mid", "storm.mid", "gutwrnch.mid", "robocrep.mid", "stalag.mid", "pizzed.mid", "alienz.mid", "xplasma.mid", "alfredh.mid", "gloomy.mid", "intents.mid");
        GlobalMembers.ConActions.definemusic(3, "inhiding.mid", "FATCMDR.mid", "NAMES.MID", "subway.mid", "invader.mid", "gotham.mid", "233c.mid", "lordofla.mid", "urban.mid", "spook.mid", "whomp.mid");
        GlobalMembers.ConActions.definemusic(4, "missimp.mid", "prepd.mid", "bakedgds.mid", "cf.mid", "lemchill.mid", "pob.mid", "warehaus.mid", "layers.mid", "floghorn.mid", "depart.mid", "restrict.mid");
        GlobalMembers.ConActions.definesound(PRED_ROAM, "roam06.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(PRED_ROAM2, "roam58.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(PRED_RECOG, "predrg.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(PRED_ATTACK, "gblasr01.voc", 256, 256, 3, 0, 7680);
        GlobalMembers.ConActions.definesound(PRED_PAIN, "predpn.voc", 200, 500, 3, 0, 0);
        GlobalMembers.ConActions.definesound(PRED_DYING, "preddy.voc", 0, 400, 3, 0, 0);
        GlobalMembers.ConActions.definesound(CAPT_ROAM, "predrm.voc", 0, 200, 3, 0, 0);
        GlobalMembers.ConActions.definesound(CAPT_RECOG, "predrg.voc", -400, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(CAPT_ATTACK, "chaingun.voc", 0, 0, 3, 0, -200);
        GlobalMembers.ConActions.definesound(CAPT_PAIN, "predpn.voc", -200, 100, 3, 0, 0);
        GlobalMembers.ConActions.definesound(CAPT_DYING, "preddy.voc", -200, 100, 3, 0, 0);
        GlobalMembers.ConActions.definesound(LIZARD_SPIT, "lizspit.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(LIZARD_BEG, "chokn12.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(NEWBEAST_ROAM, "blroam2a.voc", -128, 128, 3, 0, 0);
        GlobalMembers.ConActions.definesound(NEWBEAST_RECOG, "blrec4b.voc", 1400, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(NEWBEAST_ATTACK, "blrip1a.voc", -150, 150, 3, 0, 0);
        GlobalMembers.ConActions.definesound(NEWBEAST_ATTACKMISS, "blrip1b.voc", -256, 256, 3, 0, 0);
        GlobalMembers.ConActions.definesound(NEWBEAST_PAIN, "blpain1b.voc", -256, 256, 3, 0, 0);
        GlobalMembers.ConActions.definesound(NEWBEAST_DYING, "bldie3a.voc", 1200, 100, 3, 0, 0);
        GlobalMembers.ConActions.definesound(NEWBEAST_SPIT, "blspit1a.voc", -128, 128, 0, 0, 0);
        GlobalMembers.ConActions.definesound(PIG_ROAM, "roam29.voc", -200, 400, 3, 0, 0);
        GlobalMembers.ConActions.definesound(PIG_ROAM2, "roam67.voc", -200, 400, 3, 0, 0);
        GlobalMembers.ConActions.definesound(PIG_ROAM3, "pigrm.voc", -200, 400, 3, 0, 0);
        GlobalMembers.ConActions.definesound(PIG_RECOG, "pigrg.voc", -200, 400, 3, 0, 0);
        GlobalMembers.ConActions.definesound(PIG_ATTACK, "shotgun7.voc", -256, 256, 4, 0, 0);
        GlobalMembers.ConActions.definesound(PIG_PAIN, "pigpn.voc", 100, 800, 3, 0, 0);
        GlobalMembers.ConActions.definesound(PIG_DYING, "pigdy.voc", -800, 100, 3, 0, 0);
        GlobalMembers.ConActions.definesound(PIG_CAPTURE_DUKE, "!pig.voc", 0, 0, 255, 8, 0);
        GlobalMembers.ConActions.definesound(RECO_ROAM, "jetpaki.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(RECO_RECOG, "pigrg.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(RECO_ATTACK, "gblasr01.voc", 256, 256, 3, 0, 7680);
        GlobalMembers.ConActions.definesound(RECO_PAIN, "pigpn.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(RECO_DYING, "pigdy.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(DRON_ROAM, "snakrm.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(DRON_RECOG, "snakrg.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(DRON_ATTACK1, "snakatA.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(DRON_ATTACK2, "snakatB.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(DRON_PAIN, "snakpn.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(DRON_DYING, "snakdy.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(DRON_JETSND, "ENGHUM.VOC", 1300, 1300, 0, 0, 0);
        GlobalMembers.ConActions.definesound(COMM_ROAM, "commrm.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(COMM_RECOG, "commrg.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(COMM_ATTACK, "commat.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(COMM_PAIN, "commpn.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(COMM_DYING, "commdy.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(COMM_SPIN, "commsp.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(OCTA_ROAM, "octarm.voc", -200, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(OCTA_RECOG, "octarg.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(OCTA_ATTACK1, "octaat1.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(OCTA_ATTACK2, "octaat2.voc", 0, 600, 3, 0, 0);
        GlobalMembers.ConActions.definesound(OCTA_PAIN, "octapn.voc", -400, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(OCTA_DYING, "octady.voc", -400, -100, 3, 0, 0);
        GlobalMembers.ConActions.definesound(WIERDSHOT_FLY, "octaat1.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(TURR_ROAM, "turrrm.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(TURR_RECOG, "turrrg.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(TURR_ATTACK, "turrat.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(TURR_PAIN, "turrpn.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(TURR_DYING, "turrdy.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(SLIM_HATCH, "slhtch01.voc", -256, 256, 3, 0, 0);
        GlobalMembers.ConActions.definesound(SLIM_ROAM, "sliroa02.voc", -256, 256, 3, 0, 0);
        GlobalMembers.ConActions.definesound(SLIM_RECOG, "slirec06.voc", -256, 256, 3, 0, 0);
        GlobalMembers.ConActions.definesound(SLIM_ATTACK, "slimat.voc", -256, 256, 3, 0, 0);
        GlobalMembers.ConActions.definesound(SLIM_DYING, "slidie03.voc", -256, 256, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS2_ROAM, "b2atk01.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS2_RECOG, "b2rec03.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS2_ATTACK, "b2atk02.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS2_PAIN, "b2pain03.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS2_DYING, "b2die03.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS3_ROAM, "b3roam01.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS3_RECOG, "b3pain04.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS3_ATTACK1, "b3atk01.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS3_ATTACK2, "b3atk01.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS3_PAIN, "b3rec03g.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS3_DYING, "b3die03g.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS4_ROAM, "bqroam2a.voc", 1024, 1024, 255, 0, 0);
        GlobalMembers.ConActions.definesound(BOS4_RECOG, "bqrec2a.voc", 1024, 1024, 255, 0, 3084);
        GlobalMembers.ConActions.definesound(BOS4_ATTACK, "bqshock3.voc", 1024, 1024, 255, 0, 0);
        GlobalMembers.ConActions.definesound(BOS4_PAIN, "bqpain2a.voc", 1024, 1024, 255, 0, 0);
        GlobalMembers.ConActions.definesound(BOS4_DYING, "bqdie1a.voc", 1024, 1024, 255, 0, 0);
        GlobalMembers.ConActions.definesound(BOS4_LAY, "bqegg1a.voc", 1024, 1024, 255, 0, 0);
        GlobalMembers.ConActions.definesound(BOS1_ROAM, "bos1rm.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS1_RECOG, "bos1rg.voc", 0, 0, 5, 0, 0);
        GlobalMembers.ConActions.definesound(BOS1_ATTACK1, "chaingun.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS1_ATTACK2, "rpgfire.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS1_PAIN, "bos1pn.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS1_DYING, "bos1dy.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(BOS1_WALK, "thud.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(KICK_HIT, "kickhit.voc", 0, 0, 4, 0, 0);
        GlobalMembers.ConActions.definesound(PISTOL_RICOCHET, "ricochet.voc", 0, 0, 0, 0, 4096);
        GlobalMembers.ConActions.definesound(PISTOL_BODYHIT, "bulithit.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(PISTOL_FIRE, "pistol.voc", -64, 0, 254, 0, 0);
        GlobalMembers.ConActions.definesound(EJECT_CLIP, "clipout.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(INSERT_CLIP, "clipin.voc", 512, 512, 3, 0, 0);
        GlobalMembers.ConActions.definesound(CHAINGUN_FIRE, "chaingun.voc", -204, -204, 254, 0, 512);
        GlobalMembers.ConActions.definesound(SHOTGUN_FIRE, "shotgun7.voc", 0, 512, 254, 0, 0);
        GlobalMembers.ConActions.definesound(SHOTGUN_COCK, "shotgnck.voc", 96, 192, 3, 0, 0);
        GlobalMembers.ConActions.definesound(RPG_SHOOT, "rpgfire.voc", -32, 0, 4, 0, 0);
        GlobalMembers.ConActions.definesound(FLY_BY, "flyby.voc", -256, 256, 3, 0, 0);
        GlobalMembers.ConActions.definesound(RPG_EXPLODE, "bombexpl.voc", -1024, 1024, 128, 0, 0);
        GlobalMembers.ConActions.definesound(CAT_FIRE, "catfire.voc", 512, 768, 4, 0, 0);
        GlobalMembers.ConActions.definesound(SHRINKER_FIRE, "shrinker.voc", -512, 0, 5, 0, 0);
        GlobalMembers.ConActions.definesound(ACTOR_SHRINKING, "shrink.voc", 0, 0, 2, 0, 0);
        GlobalMembers.ConActions.definesound(ACTOR_GROWING, "enlarge.voc", 1024, 0, 2, 0, 0);
        GlobalMembers.ConActions.definesound(PIPEBOMB_BOUNCE, "pbombbnc.voc", 0, 0, 2, 0, 6144);
        GlobalMembers.ConActions.definesound(PIPEBOMB_EXPLODE, "bombexpl.voc", -512, 0, 128, 0, 0);
        GlobalMembers.ConActions.definesound(LASERTRIP_ONWALL, "lsrbmbpt.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(LASERTRIP_ARMING, "lsrbmbwn.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(LASERTRIP_EXPLODE, "bombexpl.voc", -512, 0, 4, 0, 0);
        GlobalMembers.ConActions.definesound(NITEVISION_ONOFF, "goggle12.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(SELECT_WEAPON, "WPNSEL21.VOC", 128, 128, 3, 0, 0);
        GlobalMembers.ConActions.definesound(VENT_BUST, "ventbust.voc", -32, 32, 2, 0, 0);
        GlobalMembers.ConActions.definesound(GLASS_BREAKING, "glass.voc", -412, 0, 3, 0, 8192);
        GlobalMembers.ConActions.definesound(GLASS_HEAVYBREAK, "glashevy.voc", -412, 0, 3, 0, 8192);
        GlobalMembers.ConActions.definesound(SHORT_CIRCUIT, "shorted.voc", 0, 0, 0, 0, 6500);
        GlobalMembers.ConActions.definesound(ITEM_SPLASH, "splash.voc", 0, 0, 2, 0, 0);
        GlobalMembers.ConActions.definesound(BONUSMUSIC, "bonus.voc", 0, 0, 255, 1, 0);
        GlobalMembers.ConActions.definesound(DUKE_BREATHING, "hlminhal.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_EXHALING, "hlmexhal.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_GASP, "gasp.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_URINATE, "pissing.voc", 0, 0, 4, 0, 0);
        GlobalMembers.ConActions.definesound(DUKE_CRACK2, "COMEON02.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_CRACK, "WAITIN03.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_TALKTOBOSSFALL, "DIESOB03.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(DUKE_CRACK_FIRST, "knuckle.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(DUKE_GET, "getitm19.voc", -64, 64, 255, 0, 0);
        GlobalMembers.ConActions.definesound(DUKE_GETWEAPON1, "cool01.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_GETWEAPON2, "getsom1a.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_GETWEAPON3, "groovy02.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_GETWEAPON4, "wansom4a.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_GETWEAPON6, "HAIL01.VOC", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_GOTHEALTHATLOW, "needed03.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_SEARCH, "pain87.VOC", 0, 0, 2, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_SEARCH2, "whrsit05.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_LONGTERM_PAIN, "gasps07.voc", -192, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_LONGTERM_PAIN2, "dscrem15.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_LONGTERM_PAIN3, "dscrem16.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_LONGTERM_PAIN4, "dscrem17.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_LONGTERM_PAIN5, "pain54.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_LONGTERM_PAIN6, "pain75.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_LONGTERM_PAIN7, "pain93.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_LONGTERM_PAIN8, "pain68.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_PISSRELIEF, "ahmuch03.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(SOMETHINGHITFORCE, "teleport.voc", 0, 0, 2, 0, 8192);
        GlobalMembers.ConActions.definesound(DUKE_DRINKING, "drink18.voc", -128, 128, 2, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_KILLED1, "damn03.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(DUKE_KILLED2, "damnit04.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(DUKE_KILLED3, "thsuk13a.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(DUKE_KILLED4, "dscrem18.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_KILLED5, "pisses01.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(DUKE_GRUNT, "exert.voc", 0, 0, 2, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_DEAD, "DMDEATH.VOC", -64, 64, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_HARTBEAT, "hartbeat.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(DUKE_STEPONFECES, "happen01.voc", 0, 0, 0, 12, 0);
        GlobalMembers.ConActions.definesound(DUKE_ONWATER, "wetfeet.voc", 0, 0, 4, 0, 0);
        GlobalMembers.ConActions.definesound(DUKE_LAND, "land02.voc", 0, 0, 2, 0, 0);
        GlobalMembers.ConActions.definesound(DUKE_LAND_HURT, "pain39.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_WALKINDUCTS, "ductwlk.voc", -64, 128, 2, 0, 0);
        GlobalMembers.ConActions.definesound(DUKE_LOOKINTOMIRROR, "lookin01.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_TIP1, "dance01.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_TIP2, "shake2a.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_BOOBY, "BOOBY04.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_HIT_STRIPPER1, "damnit04.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(DUKE_HIT_STRIPPER2, "damn03.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(ALIEN_TALK1, "MUSTDIE.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(ALIEN_TALK2, "DEFEATED.VOC", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(BONUS_SPEECH1, "letsrk03.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(BONUS_SPEECH2, "ready2a.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(BONUS_SPEECH3, "ripem08.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(BONUS_SPEECH4, "rockin02.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_YES, "yes.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_USEMEDKIT, "ahh04.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKE_TAKEPILLS, "gulp01.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(DUKETALKTOBOSS, "duknuk14.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(BOSSTALKTODUKE, "!boss.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(SHRINKER_HIT, "thud.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(SOMETHINGFROZE, "freeze.voc", 0, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(DUKE_UNDERWATER, "scuba.voc", 0, 0, 2, 0, 0);
        GlobalMembers.ConActions.definesound(DUKE_JETPACK_ON, "jetpakon.voc", 0, 0, 4, 0, 0);
        GlobalMembers.ConActions.definesound(DUKE_JETPACK_IDLE, "jetpaki.voc", 0, 0, 1, 0, 0);
        GlobalMembers.ConActions.definesound(DUKE_JETPACK_OFF, "jetpakof.voc", 0, 0, 2, 0, 0);
        GlobalMembers.ConActions.definesound(FLESH_BURNING, "fire09.voc", -256, 0, 0, 0, 6100);
        GlobalMembers.ConActions.definesound(THUD, "thud.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(SQUISHED, "squish.voc", -128, 0, 3, 0, 0);
        GlobalMembers.ConActions.definesound(TELEPORTER, "teleport.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(ELEVATOR_ON, "gbelev01.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(ELEVATOR_OFF, "gbelev02.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(ALIEN_ELEVATOR1, "hydro43.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(SUBWAY, "subway.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(SWITCH_ON, "switch.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(FAN, "fan.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(FLUSH_TOILET, "flush.voc", 0, 0, 3, 2, 0);
        GlobalMembers.ConActions.definesound(HOVER_CRAFT, "hover.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(EARTHQUAKE, "quake.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(INTRUDER_ALERT, "alert.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(END_OF_LEVEL_WARN, "monitor.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(POOLBALLHIT, "poolbal1.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(ENGINE_OPERATING, "onboard.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(REACTOR_ON, "reactor.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(COMPUTER_AMBIENCE, "compamb.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(GEARS_GRINDING, "geargrnd.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(BUBBLE_AMBIENCE, "bubblamb.voc", -256, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(MACHINE_AMBIENCE, "machamb.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(SEWER_AMBIENCE, "drip3.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(WIND_AMBIENCE, "wind54.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(WIND_REPEAT, "wind54.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(SOMETHING_DRIPPING, "drip3.voc", 0, 0, 0, 0, 9000);
        GlobalMembers.ConActions.definesound(STEAM_HISSING, "steamhis.voc", 0, 0, 0, 0, 10240);
        GlobalMembers.ConActions.definesound(BAR_MUSIC, "barmusic.voc", 0, 0, 254, 2, 0);
        GlobalMembers.ConActions.definesound(STORE_MUSIC, "muzak028.voc", 0, 0, 254, 0, 6144);
        GlobalMembers.ConActions.definesound(STORE_MUSIC_BROKE, "muzakdie.voc", 0, 0, 0, 0, 6144);
        GlobalMembers.ConActions.definesound(DUKE_SCREAM, "DSCREM04.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(KILLME, "killme.voc", -128, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(GETATOMICHEALTH, "teleport.voc", 2048, 2048, 255, 0, 0);
        GlobalMembers.ConActions.definesound(DOOR_OPERATE1, "slidoor.voc", -256, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(DOOR_OPERATE2, "opendoor.voc", -256, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(DOOR_OPERATE3, "edoor10.voc", -256, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(DOOR_OPERATE4, "edoor11.voc", -256, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(BORNTOBEWILDSND, "2bwild.voc", 0, 0, 254, 2, 0);
        GlobalMembers.ConActions.definesound(KTIT, "ktitx.voc", 0, 0, 254, 2, 0);
        GlobalMembers.ConActions.definesound(LADY_SCREAM, "FSCRM10.voc", -256, 0, 254, 8, 0);
        GlobalMembers.ConActions.definesound(MONITOR_ACTIVE, "monitor.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(WATER_GURGLE, "h2ogrgl2.voc", 0, 0, 1, 2, 9000);
        GlobalMembers.ConActions.definesound(EXITMENUSOUND, "item15.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(RATTY, "mice3.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(INTO_MENU, "bulithit.voc", 1024, 1024, 0, 0, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE1, "grind.voc", 0, 0, 0, 1, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE2, "enghum.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE3, "lava06.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE4, "bubblamb.voc", -256, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE5, "phonbusy.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE6, "roam22.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(SECRETLEVELSND, "secret.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE8, "amb81b.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE9, "roam98b.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE10, "h2orush2.voc", 0, 0, 0, 3, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE11, "projrun.voc", 0, 0, 0, 3, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE12, "drip3.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE13, "pay02.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE14, "onlyon03.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE15, "rides09.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE16, "doomed16.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE17, "myself3a.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE18, "monolith.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE19, "hydro50.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE20, "con03.voc", 0, 0, 0, 4, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE21, "!prison.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE22, "vpiss2.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(GENERIC_AMBIENCE23, "2ride06.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(SUPERMARKET, "aisle402.voc", 0, 0, 0, 4, 0);
        GlobalMembers.ConActions.definesound(FIRE_CRACKLE, "fire09.voc", 0, 0, 254, 2, 0);
        GlobalMembers.ConActions.definesound(DUMPSTER_MOVE, "grind.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR1, "AMESS06.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR2, "BITCHN04.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR3, "HOLYCW01.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR4, "HOLYSH02.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR5, "IMGOOD12.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR6, "PIECE02.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR7, "GOTHRT01.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR8, "BLOWIT01.VOC", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR9, "EATSHT01.VOC", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR10, "FACE01.VOC", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR11, "INHELL01.VOC", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(WHIPYOURASS, "WHIPYU01.VOC", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR12, "SUKIT01.VOC", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR13, "LETGOD01.VOC", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR14, "getcrap1.voc", 0, 0, 0, 12, 0);
        GlobalMembers.ConActions.definesound(JIBBED_ACTOR15, "guysuk01.voc", 0, 0, 0, 12, 0);
        GlobalMembers.ConActions.definesound(WAR_AMBIENCE1, "WARAMB13.VOC", -512, 0, 255, 16, 0);
        GlobalMembers.ConActions.definesound(WAR_AMBIENCE2, "WARAMB21.VOC", -512, 0, 254, 16, 0);
        GlobalMembers.ConActions.definesound(WAR_AMBIENCE3, "WARAMB23.VOC", -512, 0, 254, 16, 0);
        GlobalMembers.ConActions.definesound(WAR_AMBIENCE4, "WARAMB29.VOC", -512, 0, 254, 16, 0);
        GlobalMembers.ConActions.definesound(WAR_AMBIENCE5, "FORCE01.VOC", 0, 0, 0, 4, 0);
        GlobalMembers.ConActions.definesound(WAR_AMBIENCE6, "QUAKE06.VOC", 0, 0, 0, 4, 0);
        GlobalMembers.ConActions.definesound(WAR_AMBIENCE7, "TERMIN01.VOC", 0, 0, 0, 4, 0);
        GlobalMembers.ConActions.definesound(WAR_AMBIENCE8, "BORN01.VOC", 0, 0, 254, 20, 0);
        GlobalMembers.ConActions.definesound(WAR_AMBIENCE9, "NOBODY01.VOC", 0, 0, 0, 4, 0);
        GlobalMembers.ConActions.definesound(WAR_AMBIENCE10, "CHEW05.VOC", 0, 0, 0, 12, 0);
        GlobalMembers.ConActions.definesound(SPACE_DOOR1, "hydro22.voc", 0, 0, 0, 0, 8192);
        GlobalMembers.ConActions.definesound(SPACE_DOOR2, "hydro24.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(SPACE_DOOR3, "hydro27.voc", 0, 0, 0, 0, 8192);
        GlobalMembers.ConActions.definesound(SPACE_DOOR4, "hydro34.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(SPACE_DOOR5, "hydro40.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(SPACE_AMBIENCE1, "monolith.voc", 0, 0, 0, 16, 0);
        GlobalMembers.ConActions.definesound(SPACE_AMBIENCE2, "hydro50.voc", 0, 0, 0, 16, 0);
        GlobalMembers.ConActions.definesound(VAULT_DOOR, "vault04.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(ALIEN_ELEVATOR1, "hydro43.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(ALIEN_DOOR1, "adoor1.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(ALIEN_DOOR2, "adoor2.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(ALIEN_SWITCH1, "aswtch23.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(COMPANB2, "CTRLRM25.VOC", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(HELICOP_IDLE, "hlidle03.voc", 0, 0, 255, 3, 0);
        GlobalMembers.ConActions.definesound(FOUNDJONES, "jones04.voc", 0, 0, 0, 4, 0);
        GlobalMembers.ConActions.definesound(STEPNIT, "LIZSHIT3.VOC", 0, 0, 254, 12, 0);
        GlobalMembers.ConActions.definesound(RIPHEADNECK, "rip01.voc", 0, 0, 254, 12, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL2SND1, "gunhit2.voc", 0, 0, 249, 0, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL2SND2, "headrip3.VOC", 0, 0, 250, 0, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL2SND3, "buckle.VOC", 0, 0, 251, 0, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL2SND4, "jetp2.VOC", 0, 0, 252, 0, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL2SND5, "zipper2.voc", 0, 0, 253, 0, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL2SND6, "news.voc", 0, 0, 254, 0, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL2SND7, "whistle.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL3SND2, "GMEOVR05.VOC", 0, 0, 254, 0, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL3SND3, "CHEER.VOC", 0, 0, 254, 0, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL3SND4, "GRABBAG.VOC", 0, 0, 254, 1, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL3SND5, "name01.voc", 0, 0, 250, 0, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL3SND6, "r&r01.voc", 0, 0, 251, 0, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL3SND7, "lani05.voc", 0, 0, 252, 0, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL3SND8, "lani08.voc", 0, 0, 253, 0, 0);
        GlobalMembers.ConActions.definesound(ENDSEQVOL3SND9, "laniduk2.voc", 0, 0, 254, 0, 0);
        GlobalMembers.ConActions.definesound(SUPERMARKET, "aisle402.voc", 0, 0, 0, 4, 0);
        GlobalMembers.ConActions.definesound(MOUSEANNOY, "annoy03.voc", 0, 0, 0, 4, 0);
        GlobalMembers.ConActions.definesound(BOOKEM, "bookem03.voc", 0, 0, 0, 4, 0);
        GlobalMembers.ConActions.definesound(SUPERMARKETCRY, "cry01.voc", 0, 0, 0, 4, 0);
        GlobalMembers.ConActions.definesound(DESTRUCT, "detruct2.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(EATFOOD, "eat08.voc", 0, 0, 0, 12, 0);
        GlobalMembers.ConActions.definesound(MAKEMYDAY, "makeday1.voc", 0, 0, 0, 4, 0);
        GlobalMembers.ConActions.definesound(WITNESSSTAND, "sohelp02.voc", 0, 0, 0, 4, 0);
        GlobalMembers.ConActions.definesound(VACATIONSPEECH, "vacatn01.voc", 0, 0, 0, 12, 0);
        GlobalMembers.ConActions.definesound(YIPPEE1, "yippie01.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(YOHOO1, "yohoho01.voc", 0, 0, 128, 4, 0);
        GlobalMembers.ConActions.definesound(YOHOO2, "yohoho09.voc", 0, 0, 128, 4, 0);
        GlobalMembers.ConActions.definesound(DOLPHINSND, "dolphin.voc", -512, 512, 0, 0, 0);
        GlobalMembers.ConActions.definesound(TOUGHGALSND1, "dom03.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(TOUGHGALSND2, "dom09.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(TOUGHGALSND3, "dom11.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(TOUGHGALSND4, "dom12.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(TANK_ROAM, "tank3a.voc", 0, 0, 255, 0, 6000);
        GlobalMembers.ConActions.definesound(VOL4_1, "jacuzzi2.voc", 0, 0, 0, 1, 0);
        GlobalMembers.ConActions.definesound(VOL4_2, "typing.voc", 0, 0, 0, 1, 0);
        GlobalMembers.ConActions.definesound(COOKINGDEEPFRIER, "deepfry1.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(WHINING_DOG, "dogwhine.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(DEAD_DOG, "dogyelp.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(LIGHTNING_SLAP, "tclap2a.voc", -256, 256, 0, 0, 0);
        GlobalMembers.ConActions.definesound(THUNDER, "trumble.voc", -512, 256, 0, 0, 0);
        GlobalMembers.ConActions.definesound(HAPPYMOUSESND1, "sweet03.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(HAPPYMOUSESND2, "sweet04.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(HAPPYMOUSESND3, "sweet05.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(HAPPYMOUSESND4, "sweet16.voc", 0, 0, 0, 0, 0);
        GlobalMembers.ConActions.definesound(ALARM, "alarm1a.voc", -128, 128, 255, 2, 0);
        GlobalMembers.ConActions.definesound(RAIN, "rain3a.voc", -128, 128, 0, 2, 0);
        GlobalMembers.ConActions.definesound(DTAG_GREENRUN, "GRUN.VOC", -128, 128, 255, 128, 0);
        GlobalMembers.ConActions.definesound(DTAG_BROWNRUN, "BRUN.VOC", -128, 128, 255, 128, 0);
        GlobalMembers.ConActions.definesound(DTAG_GREENSCORE, "GSCORE.VOC", -128, 128, 255, 128, 0);
        GlobalMembers.ConActions.definesound(DTAG_BROWNSCORE, "BSCORE.VOC", -128, 128, 255, 128, 0);
        GlobalMembers.ConActions.definesound(SCREECH, "skidcr1.voc", -128, 128, 4, 0, 0);
        GlobalMembers.ConActions.definesound(INTRO4_1, "intro4h1.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(INTRO4_B, "intro4h2.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(INTRO4_2, "typing.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(INTRO4_3, "introa.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(INTRO4_4, "introb.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(INTRO4_5, "clang1.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(INTRO4_6, "introc.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(BOSS4_DEADSPEECH, "abort01.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(BOSS4_FIRSTSEE, "kick01-i.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(PARTY_SPEECH, "party03.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(POSTAL_SPEECH, "postal01.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(TGSPEECH, "vocal02.voc", 0, 0, 254, 8, 0);
        GlobalMembers.ConActions.definesound(DOGROOMSPEECH, "meat04-n.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(SMACKED, "smack02.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(MDEVSPEECH, "mdevl01.voc", 0, 0, 255, 12, 0);
        GlobalMembers.ConActions.definesound(AREA51SPEECH, "indpnc01.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(JEEPSOUND, "jeep2a.voc", 0, 0, 0, 2, 0);
        GlobalMembers.ConActions.definesound(BIGDOORSLAM, "cdoor1b.voc", 0, 0, 129, 0, 0);
        GlobalMembers.ConActions.definesound(WAVESOUND, "wave1a.voc", 0, 0, 129, 3, 0);
        GlobalMembers.ConActions.definesound(ILLBEBACK, "beback01.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(VOL4ENDSND1, "sbr1c.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(VOL4ENDSND2, "squish1a.voc", 0, 0, 254, 0, 0);
        GlobalMembers.ConActions.definesound(EXPANDERSHOOT, "exshot3b.voc", -32, 80, 128, 0, 0);
        GlobalMembers.ConActions.definesound(EXPANDERHIT, "deepfry1.voc", 0, 0, 128, 0, 0);
        GlobalMembers.ConActions.definesound(SNAKESPEECH, "escape01.voc", 0, 0, 255, 4, 0);
        GlobalMembers.ConActions.definesound(GETBACKTOWORK, "slacker1.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(BIGBANG, "bang1.voc", 0, 0, 255, 0, 0);
        GlobalMembers.ConActions.definesound(HORNSND, "shorn1.voc", 0, 0, 255, 2, 0);
        GlobalMembers.ConActions.definesound(BELLSND, "sbell1a.voc", 0, 0, 255, 2, 0);
        GlobalMembers.ConActions.definesound(GOAWAY, "goaway.voc", 0, 0, 4, 0, 0);
        GlobalMembers.ConActions.definesound(JOKE, "joke.voc", 0, 0, 128, 0, 0);
        GlobalMembers.ConActions.RegisterActor(A_SPACESHUTTLE, SPACESHUTTLE, TOUGH);
        GlobalMembers.ConActions.RegisterActor(A_SATELLITE, SATELLITE, TOUGH);
        GlobalMembers.ConActions.RegisterActor(A_SHARK, SHARK, SHARKSTRENGTH, ASHARKCRUZING, SHARKVELS, randomangle, geth);
        GlobalMembers.ConActions.RegisterActor(A_BLIMP, BLIMP, 1);
        GlobalMembers.ConActions.RegisterActor(A_RUBBERCAN, RUBBERCAN, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, DUKEBURGER, PIRATEGALSTRENGTH, ABURGERROTS);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, MOP, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, BROOM, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, WETFLOOR, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, DESKLAMP, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, HATRACK, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, GUNPOWDERBARREL, TOUGH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, COFFEEMACHINE, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, TEDDYBEAR, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, TOPSECRET, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, ROBOTMOUSE, ROBOTMOUSESTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, MAN, PIRATEGALSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, MAN2, PIRATEGALSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, WOMAN, PIRATEGALSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, PIRATE1A, PIRATEGALSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, PIRATE2A, PIRATEGALSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, PIRATE3A, PIRATEGALSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, PIRATE4A, PIRATEGALSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, PIRATE5A, PIRATEGALSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, PIRATE6A, PIRATEGALSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, ROBOTPIRATE, PIRATEGALSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, PIRATEHALF, TOUGH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, CHESTOFGOLD, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, ROBOTDOG, PIRATEGALSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, ROBOTDOG2, TOUGH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, PLEASEWAIT);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT1, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT2, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT3, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT4, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT5, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT6, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT7, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT8, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT9, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT10, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT11, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT12, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT13, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT14, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT15, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT16, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT17, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT18, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT19, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FOODOBJECT20, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, JOLLYMEAL, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, GUMBALLMACHINE, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, GUMBALLMACHINEBROKE, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, POLICELIGHTPOLE, TOUGH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, CLOCK, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, MAILBAG, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FEATHEREDCHICKEN, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, SKINNEDCHICKEN, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, HEADLAMP, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, DOLPHIN1, DOLPHINSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, DOLPHIN2, DOLPHINSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, SNAKEP, MEDIUMSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, DONUTS, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, GAVALS, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, GAVALS2, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, CUPS, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, DONUTS2, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FLOORBASKET, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, METER, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, DESKPHONE, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, MACE, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, SHOPPINGCART, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, COFFEEMUG, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_EXPLODINGBARREL, EXPLODINGBARREL, 26);
        GlobalMembers.ConActions.RegisterActor(A_BURNING, BURNING, WEAK, BURNING_FLAME);
        GlobalMembers.ConActions.RegisterActor(A_BURNING2, BURNING2, WEAK, BURNING_FLAME);
        GlobalMembers.ConActions.RegisterActor(A_TOILETWATER, TOILETWATER, 0, TOILETWATERFRAMES);
        GlobalMembers.ConActions.RegisterActor(A_HORSEONSIDE, HORSEONSIDE, WEAKEST);
        GlobalMembers.ConActions.RegisterActor(A_WOODENHORSE, WOODENHORSE, WEAK, WOODENHORSEFRAME);
        GlobalMembers.ConActions.RegisterActor(A_STEAM, STEAM, 0, STEAMFRAMES);
        GlobalMembers.ConActions.RegisterActor(A_CEILINGSTEAM, CEILINGSTEAM, 0, STEAMFRAMES);
        GlobalMembers.ConActions.RegisterActor(A_WATERBUBBLEMAKER, WATERBUBBLEMAKER, 0, 0, randomangle);
        GlobalMembers.ConActions.RegisterActor(A_WATERBUBBLE, WATERBUBBLE, 0, BUBBLE, BUBMOVE, getv, geth, randomangle);
        GlobalMembers.ConActions.RegisterActor(A_SMALLSMOKE, SMALLSMOKE, 0, SMOKEFRAMES);
        GlobalMembers.ConActions.RegisterActor(A_NUKEBARRELDENTED, NUKEBARRELDENTED, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_NUKEBARRELLEAKED, NUKEBARRELLEAKED, WEAK);
        GlobalMembers.ConActions.RegisterActor(A_NUKEBARREL, NUKEBARREL, MEDIUMSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_FIREBARREL, FIREBARREL);
        GlobalMembers.ConActions.RegisterActor(A_FIREVASE, FIREVASE);
        GlobalMembers.ConActions.RegisterActor(A_SHRINKEREXPLOSION, SHRINKEREXPLOSION, 0, SHRINKERFRAMES);
        GlobalMembers.ConActions.RegisterActor(A_EXPLOSION2, EXPLOSION2, 1, EXPLOSION_FRAMES);
        GlobalMembers.ConActions.RegisterActor(A_EXPLOSION2BOT, EXPLOSION2BOT, 1, EXPLOSION_FRAMES);
        GlobalMembers.ConActions.RegisterActor(A_FLOORFLAME, FLOORFLAME, 0, FFLAME_FR);
        GlobalMembers.ConActions.RegisterActor(A_ROTATEGUN, ROTATEGUN, ROTTURRETSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_FORCERIPPLE, FORCERIPPLE, 0, RIP_F);
        GlobalMembers.ConActions.RegisterActor(A_TRANSPORTERSTAR, TRANSPORTERSTAR, 0, TRANSFOWARD);
        GlobalMembers.ConActions.RegisterActor(A_TRANSPORTERBEAM, TRANSPORTERBEAM, 0, BEAMFOWARD);
        GlobalMembers.ConActions.RegisterActor(A_STEROIDS, STEROIDS);
        GlobalMembers.ConActions.RegisterActor(A_BOOTS, BOOTS);
        GlobalMembers.ConActions.RegisterActor(A_HEATSENSOR, HEATSENSOR);
        GlobalMembers.ConActions.RegisterActor(A_SHIELD, SHIELD);
        GlobalMembers.ConActions.RegisterActor(A_AIRTANK, AIRTANK);
        GlobalMembers.ConActions.RegisterActor(A_HOLODUKE, HOLODUKE, 0, HOLODUKE_FRAMES);
        GlobalMembers.ConActions.RegisterActor(A_JETPACK, JETPACK);
        GlobalMembers.ConActions.RegisterActor(A_ACCESSCARD, ACCESSCARD);
        GlobalMembers.ConActions.RegisterActor(A_AMMO, AMMO);
        GlobalMembers.ConActions.RegisterActor(A_FREEZEAMMO, FREEZEAMMO);
        GlobalMembers.ConActions.RegisterActor(A_SHOTGUNAMMO, SHOTGUNAMMO);
        GlobalMembers.ConActions.RegisterActor(A_AMMOLOTS, AMMOLOTS);
        GlobalMembers.ConActions.RegisterActor(A_CRYSTALAMMO, CRYSTALAMMO);
        GlobalMembers.ConActions.RegisterActor(A_GROWAMMO, GROWAMMO);
        GlobalMembers.ConActions.RegisterActor(A_BATTERYAMMO, BATTERYAMMO);
        GlobalMembers.ConActions.RegisterActor(A_DEVISTATORAMMO, DEVISTATORAMMO);
        GlobalMembers.ConActions.RegisterActor(A_RPGAMMO, RPGAMMO);
        GlobalMembers.ConActions.RegisterActor(A_HBOMBAMMO, HBOMBAMMO);
        GlobalMembers.ConActions.RegisterActor(A_RPGSPRITE, RPGSPRITE);
        GlobalMembers.ConActions.RegisterActor(A_SHOTGUNSPRITE, SHOTGUNSPRITE);
        GlobalMembers.ConActions.RegisterActor(A_SIXPAK, SIXPAK);
        GlobalMembers.ConActions.RegisterActor(A_COLA, COLA);
        GlobalMembers.ConActions.RegisterActor(A_ATOMICHEALTH, ATOMICHEALTH);
        GlobalMembers.ConActions.RegisterActor(A_FIRSTAID, FIRSTAID);
        GlobalMembers.ConActions.RegisterActor(A_FIRSTGUNSPRITE, FIRSTGUNSPRITE);
        GlobalMembers.ConActions.RegisterActor(A_TRIPBOMBSPRITE, TRIPBOMBSPRITE);
        GlobalMembers.ConActions.RegisterActor(A_CHAINGUNSPRITE, CHAINGUNSPRITE);
        GlobalMembers.ConActions.RegisterActor(A_SHRINKERSPRITE, SHRINKERSPRITE);
        GlobalMembers.ConActions.RegisterActor(A_FREEZESPRITE, FREEZESPRITE);
        GlobalMembers.ConActions.RegisterActor(A_DEVISTATORSPRITE, DEVISTATORSPRITE);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FIRE, WEAK, 0, FIREVELS);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, FIRE2, WEAK, 0, FIREVELS);
        GlobalMembers.ConActions.RegisterActor(A_FECES, FECES);
        GlobalMembers.ConActions.RegisterActor(A_FEM1, FEM1, TOUGH, FEMANIMATE);
        GlobalMembers.ConActions.RegisterActor(A_FEM2, FEM2, TOUGH, FEMANIMATE);
        GlobalMembers.ConActions.RegisterActor(A_FEM3, FEM3, TOUGH, FEMANIMATE);
        GlobalMembers.ConActions.RegisterActor(A_FEM4, FEM4, TOUGH, FEMANIMATE);
        GlobalMembers.ConActions.RegisterActor(A_FEM5, FEM5, TOUGH, FEMANIMATE);
        GlobalMembers.ConActions.RegisterActor(A_FEM6, FEM6, TOUGH, FEMANIMATE);
        GlobalMembers.ConActions.RegisterActor(A_FEM7, FEM7, TOUGH, FEMANIMATE);
        GlobalMembers.ConActions.RegisterActor(A_FEM8, FEM8, TOUGH, FEMANIMATE);
        GlobalMembers.ConActions.RegisterActor(A_FEM9, FEM9, TOUGH, FEMANIMATE);
        GlobalMembers.ConActions.RegisterActor(A_FEM10, FEM10, TOUGH, FEMANIMATESLOW);
        GlobalMembers.ConActions.RegisterActor(A_TOUGHGAL, TOUGHGAL, MANWOMANSTRENGTH, TOUGHGALANIM);
        GlobalMembers.ConActions.RegisterActor(A_NAKED1, NAKED1, TOUGH, FEMANIMATE);
        GlobalMembers.ConActions.RegisterActor(A_PODFEM1, PODFEM1, TOUGH, FEMANIMATE);
        GlobalMembers.ConActions.RegisterActor(A_BLOODYPOLE, BLOODYPOLE, TOUGH);
        GlobalMembers.ConActions.RegisterActor(A_STATUEFLASH, STATUEFLASH);
        GlobalMembers.ConActions.RegisterActor(A_STATUE, STATUE);
        GlobalMembers.ConActions.RegisterActor(A_MIKE, MIKE);
        GlobalMembers.ConActions.RegisterActor(A_BLOOD, BLOOD, 0, BLOODFRAMES);
        GlobalMembers.ConActions.RegisterActor(A_EGG, EGG, TOUGH);
        GlobalMembers.ConActions.RegisterActor(A_KNEE, KNEE, KNEE_WEAPON_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_SPIT, SPIT, SPIT_WEAPON_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_CHAINGUN, CHAINGUN, CHAINGUN_WEAPON_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_SHOTGUN, SHOTGUN, SHOTGUN_WEAPON_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_FIRELASER, FIRELASER, FIRELASER_WEAPON_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_HEAVYHBOMB, HEAVYHBOMB, HANDBOMB_WEAPON_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_BOUNCEMINE, BOUNCEMINE, BOUNCEMINE_WEAPON_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_MORTER, MORTER, MORTER_WEAPON_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_SHRINKSPARK, SHRINKSPARK, SHRINKER_WEAPON_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_GROWSPARK, GROWSPARK, GROWSPARK_WEAPON_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_RPG, RPG, RPG_WEAPON_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_FREEZEBLAST, FREEZEBLAST, FREEZETHROWER_WEAPON_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_DEVISTATORBLAST, DEVISTATORBLAST, FREEZETHROWER_WEAPON_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_COOLEXPLOSION1, COOLEXPLOSION1, COOL_EXPLOSION_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_TRIPBOMB, TRIPBOMB, TRIPBOMB_STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_SHOTSPARK1, SHOTSPARK1, PISTOL_WEAPON_STRENGTH, WEAP2FRAMES);
        GlobalMembers.ConActions.RegisterActor(A_DUKELYINGDEAD, DUKELYINGDEAD, 0, PLYINGFRAMES);
        GlobalMembers.ConActions.RegisterActor(A_APLAYER, APLAYER, MAXPLAYERHEALTH, PSTAND, 0, 0);
        GlobalMembers.ConActions.RegisterActor(A_ORGANTIC, ORGANTIC, TURRETSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_LIZTROOPJETPACK, LIZTROOPJETPACK, TROOPSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_LIZTROOPDUCKING, LIZTROOPDUCKING, TROOPSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_LIZTROOPSHOOT, LIZTROOPSHOOT, TROOPSTRENGTH, ATROOPSTAND);
        GlobalMembers.ConActions.RegisterActor(A_LIZTROOPSTAYPUT, LIZTROOPSTAYPUT, TROOPSTRENGTH, ATROOPSTAYSTAND);
        GlobalMembers.ConActions.RegisterActor(A_LIZTROOPRUNNING, LIZTROOPRUNNING, TROOPSTRENGTH, ATROOPSTAND);
        GlobalMembers.ConActions.RegisterActor(A_LIZTROOPONTOILET, LIZTROOPONTOILET, TROOPSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_LIZTROOPJUSTSIT, LIZTROOPJUSTSIT, TROOPSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_LIZTROOP, LIZTROOP, TROOPSTRENGTH, ATROOPSTAND);
        GlobalMembers.ConActions.RegisterActor(A_LIZMANSTAYPUT, LIZMANSTAYPUT, LIZSTRENGTH, ai, AILIZGETENEMY, cactor, LIZMAN);
        GlobalMembers.ConActions.RegisterActor(A_LIZMANSPITTING, LIZMANSPITTING, LIZSTRENGTH, ai, AILIZSPIT, cactor, LIZMAN);
        GlobalMembers.ConActions.RegisterActor(A_LIZMANJUMP, LIZMANJUMP, LIZSTRENGTH, ai, AILIZJUMPENEMY, cactor, LIZMAN);
        GlobalMembers.ConActions.RegisterActor(A_LIZMAN, LIZMAN, LIZSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_DRONE, DRONE, DRONESTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_OCTABRAINSTAYPUT, OCTABRAINSTAYPUT, OCTASTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_OCTABRAIN, OCTABRAIN, OCTASTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_PIGCOPDIVE, PIGCOPDIVE, PIGCOPSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_PIGCOPSTAYPUT, PIGCOPSTAYPUT, PIGCOPSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_PIGCOP, PIGCOP, PIGCOPSTRENGTH, APIGSTAND);
        GlobalMembers.ConActions.RegisterActor(A_BOSS1STAYPUT, BOSS1STAYPUT, BOSS1STRENGTH, cactor, BOSS1);
        GlobalMembers.ConActions.RegisterActor(A_BOSS1, BOSS1, BOSS1STRENGTH, fall);
        GlobalMembers.ConActions.RegisterActor(A_BOSS2, BOSS2, BOSS2STRENGTH, fall);
        GlobalMembers.ConActions.RegisterActor(A_BOSS3, BOSS3, BOSS3STRENGTH, fall);
        GlobalMembers.ConActions.RegisterActor(A_COMMANDERSTAYPUT, COMMANDERSTAYPUT, COMMANDERSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_COMMANDER, COMMANDER, COMMANDERSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, CANNONBALL, CANNONBALLSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, CANNONBALLS, CANNONBALLSSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_enemy, enemy, CANNON, CANNONSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, HOTMEAT, TOUGH);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, SPEAKER);
        GlobalMembers.ConActions.RegisterActor(A_notenemy, notenemy, LAVABUBBLE);
        GlobalMembers.ConActions.RegisterActor(A_enemy, enemy, TANK, TANKSTRENGTH, fall);
        GlobalMembers.ConActions.RegisterActor(A_BOSS4STAYPUT, BOSS4STAYPUT, BOSS4STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_BOSS4, BOSS4, BOSS4STRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_enemy, enemy, NEWBEASTHANG, NEWBEASTSTRENGTH);
        GlobalMembers.ConActions.RegisterActor(A_enemy, enemy, NEWBEASTHANGDEAD, TOUGH);
        GlobalMembers.ConActions.RegisterActor(A_enemystayput, enemystayput, NEWBEASTSTAYPUT, NEWBEASTSTRENGTH, ai, AINEWBEASTGETENEMY, cstator, 257, cactor, NEWBEAST);
        GlobalMembers.ConActions.RegisterActor(A_enemy, enemy, NEWBEASTJUMP, NEWBEASTSTRENGTH, ai, AINEWBEASTJUMPENEMY, cstator, 257, cactor, NEWBEAST);
        GlobalMembers.ConActions.RegisterActor(A_enemy, enemy, NEWBEAST, NEWBEASTSTRENGTH);
    }
}
