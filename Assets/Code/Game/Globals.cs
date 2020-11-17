//-------------------------------------------------------------------------
/*
Copyright (c) 2020 - Blackenmace Studios LLC
Copyright (C) 1996, 2003 - 3D Realms Entertainment

This file is part of the Duke Nukem 3D C# Source Port
This file is part of Duke Nukem 3D version 1.5 - Atomic Edition

Duke Nukem 3D is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  

See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

C# Port Conversion: 2020 - Justin Marshall
Original Source: 1996 - Todd Replogle
Prepared for public release: 03/21/2003 - Charlie Wiederhold, 3D Realms
*/
//-------------------------------------------------------------------------
public class SOUNDOWNER
{
    public short i;
    public int voice;
}


public enum USRHOOKS_Errors
{
    USRHOOKS_Warning = -2,
    USRHOOKS_Error = -1,
    USRHOOKS_Ok = 0
}

public class input
{
    public sbyte avel;
    public sbyte horz;
    public short fvel;
    public short svel;
    public uint bits;
}

public struct SAMPLE
{
    public string ptr;
    //C++ TO C# CONVERTER TODO TASK: 'volatile' has a different meaning in C#:
    //ORIGINAL LINE: volatile char lock;
    public char @lock;
    public int length;
    public int num;
}

public class animwalltype
{
    public short wallnum;
    public int tag;
}

public class user_defs
{
    public int god;
    public int warp_on;
    public int cashman;
    public int eog;
    public int showallmap;
    public int show_help;
    public int scrollmode;
    public int clipping;
    public string[] user_name = new string[DefineConstants.MAXPLAYERS];
    public char[,] ridecule = new char[10, 40];
    public string[] savegame = new string[10];
    public string pwlockout = new string(new char[128]);
    public string rtsname = new string(new char[128]);
    public char overhead_on;
    public char last_overhead;
    public char showweapons;

    public short pause_on;
    public short from_bonus;
    public short camerasprite;
    public short last_camsprite;
    public short last_level;
    public short secretlevel;

    public int const_visibility;
    public int uw_framerate;
    public int camera_time;
    public int folfvel;
    public int folavel;
    public int folx;
    public int foly;
    public int fola;
    public int reccnt;

    public int entered_name;
    public int screen_tilting;
    public int shadows;
    public int fta_on;
    public int executions;
    public int auto_run;
    public int coords;
    public int tickrate;
    public int m_coop;
    public int coop;
    public int screen_size;
    public int lockout;
    public int crosshair;
    public int[,] wchoice = new int[DefineConstants.MAXPLAYERS, DefineConstants.MAX_WEAPONS];
    public int playerai;

    public int respawn_monsters;
    public int respawn_items;
    public int respawn_inventory;
    public int recstat;
    public int monsters_off;
    public int brightness;
    public int m_respawn_items;
    public int m_respawn_monsters;
    public int m_respawn_inventory;
    public int m_recstat;
    public int m_monsters_off;
    public int detail;
    public int m_ffire;
    public int ffire;
    public int m_player_skill;
    public int m_level_number;
    public int m_volume_number;
    public int multimode;
    public int player_skill;
    public int level_number;
    public int volume_number;
    public int m_marker;
    public int marker;
    public int mouseflip;

}

public class player_orig
{
    public int ox;
    public int oy;
    public int oz;
    public short oa;
    public short os;
}

public class player_struct
{
    public int zoom;
    public int exitx;
    public int exity;
    public int[] loogiex = new int[64];
    public int[] loogiey = new int[64];
    public int numloogs;
    public int loogcnt;
    public int posx;
    public int posy;
    public int posz;
    public int horiz;
    public int ohoriz;
    public int ohorizoff;
    public int invdisptime;
    public int bobposx;
    public int bobposy;
    public int oposx;
    public int oposy;
    public int oposz;
    public int pyoff;
    public int opyoff;
    public int posxv;
    public int posyv;
    public int poszv;
    public int last_pissed_time;
    public int truefz;
    public int truecz;
    public int player_par;
    public int visibility;
    public int bobcounter;
    public int weapon_sway;
    public int pals_time;
    public int randomflamex;
    public int crack_time;

    public int aim_mode;

    public short ang;
    public short oang;
    public short angvel;
    public short cursectnum;
    public short look_ang;
    public short last_extra;
    public short subweapon;
    public short[] ammo_amount = new short[DefineConstants.MAX_WEAPONS];
    public short wackedbyactor;
    public short frag;
    public short fraggedself;

    public short curr_weapon;
    public short last_weapon;
    public short tipincs;
    public short horizoff;
    public short wantweaponfire;
    public short holoduke_amount;
    public short newowner;
    public short hurt_delay;
    public short hbomb_hold_delay;
    public short jumping_counter;
    public short airleft;
    public short knee_incs;
    public short access_incs;
    public short fta;
    public short ftq;
    public short access_wallnum;
    public short access_spritenum;
    public short kickback_pic;
    public short got_access;
    public short weapon_ang;
    public short firstaid_amount;
    public short somethingonplayer;
    public short on_crane;
    public short i;
    public short one_parallax_sectnum;
    public short over_shoulder_on;
    public short random_club_frame;
    public short fist_incs;
    public short one_eighty_count;
    public short cheat_phase;
    public short dummyplayersprite;
    public short extra_extra8;
    public short quick_kick;
    public short heat_amount;
    public short actorsqu;
    public short timebeforeexit;
    public short customexitsound;

    public short[] weaprecs = new short[16];
    public short weapreccnt;
    public short interface_toggle_flag;

    public short rotscrnang;
    public short dead_flag;
    public short show_empty_weapon;
    public short scuba_amount;
    public short jetpack_amount;
    public short steroids_amount;
    public short shield_amount;
    public short holoduke_on;
    public short pycount;
    public short weapon_pos;
    public short frag_ps;
    public short transporter_hold;
    public short last_full_weapon;
    public short footprintshade;
    public short boot_amount;

    public int scream_voice;

    public int gm;
    public char on_warping_sector;
    public char footprintcount;
    public char hbomb_on;
    public char jumping_toggle;
    public char rapid_fire_hold;
    public char on_ground;
    public string name = new string(new char[32]);
    public char inven_icon;
    public char buttonpalette;

    public char jetpack_on;
    public char spritebridge;
    public char lastrandomspot;
    public char scuba_on;
    public char footprintpal;
    public char heat_on;

    public int holster_weapon;
    public char falling_counter;
    public bool[] gotweapon = new bool[DefineConstants.MAX_WEAPONS];
    public char refresh_inventory;
    public byte[] palette;

    public int toggle_key_flag; // ,select_dir;
    public char knuckle_incs;
    public char walking_snd_toggle;
    public char palookup;
    public char hard_landing;
    public char max_secret_rooms;
    public char secret_rooms;
    public byte[] pals = new byte[3];
    public char max_actors_killed;
    public char actors_killed;
    public char return_to_center;
}

public class scripttemp
{
    public int[] temp_data = new int[6];
    public bool[] script_execute = new bool[6];
    public bool inScriptExecute = false;

    public int this[int index]
    {
        get
        {
            if (index == 0 || script_execute[index] == false)
                return temp_data[index];

            if (index >= temp_data.Length) 
                throw new System.Exception("scripttemp out of bounds!");

            if (temp_data[index] >= GlobalMembers.scriptptr.buffer.Length)
                return 0;

            return GlobalMembers.scriptptr.buffer[temp_data[index]];
        }
        set
        {
            if (inScriptExecute)
                script_execute[index] = true;
            else
                script_execute[index] = false;
            temp_data[index] = value;
        }
    }
}

public class weaponhit
{
    public char cgg;
    public short picnum;
    public short ang;
    public short extra;
    public short owner;
    public short movflag;
    public short tempang;
    public short actorstayput;
    public short dispicnum;
    public short timetosleep;
    public int floorz;
    public int ceilingz;
    public int lastvx;
    public int lastvy;
    public int bposx;
    public int bposy;
    public int bposz;
    public scripttemp temp_data = new scripttemp();
}




//DUKE3D.H:
public class STATUSBARTYPE
{
    public short[] frag = new short[DefineConstants.MAXPLAYERS];
    public short got_access;
    public short last_extra;
    public short shield_amount;
    public short curr_weapon;
    public short[] ammo_amount = new short[DefineConstants.MAX_WEAPONS];
    public short holoduke_on;
    public bool[] gotweapon = new bool[DefineConstants.MAX_WEAPONS];
    public char inven_icon;
    public char jetpack_on;
    public char heat_on;
    public short firstaid_amount;
    public short steroids_amount;
    public short holoduke_amount;
    public short jetpack_amount;
    public short heat_amount;
    public short scuba_amount;
    public short boot_amount;
    public short last_weapon;
    public short weapon_pos;
    public short kickback_pic;

}

public partial class GlobalMembers
{
	public static string mymembuf;
	public static string MusicPtr = new string(new char[72000]);

	public static short global_random;
	public static short neartagsector;
	public static short neartagwall;
	public static short neartagsprite;

    public static int cachedebug = 0;
    public static int automapping = 0;

	public static int gc;
	public static int neartaghitdist;
	public static int lockclock;
	public static int max_player_health;
	public static int max_armour_amount;
	public static int[] max_ammo_amount = new int[DefineConstants.MAX_WEAPONS];

    public static short numplayers, myconnectindex;
    public static short connecthead;
    public static short[] connectpoint2 = new short[DefineConstants.MAXPLAYERS];   //Player linked list variables (indeces, not connection numbers)
    public static short screenpeek;

    // long temp_data[MAXSPRITES][6];
    public static weaponhit[] hittype = new weaponhit[DefineConstants.MAXSPRITES];
	public static short[] spriteq = new short[1024];
	public static short spriteqloc;
	public static short spriteqamount = 64;
	public static short moustat;
	public static animwalltype[] animwall = new animwalltype[DefineConstants.MAXANIMWALLS];
	public static short numanimwalls;
	public static int[] animateptr = new int[DefineConstants.MAXANIMATES];
	public static int[] animategoal = new int[DefineConstants.MAXANIMATES];
	public static int[] animatevel = new int[DefineConstants.MAXANIMATES];
	public static int animatecnt;
	public static short[] animatesect = new short[DefineConstants.MAXANIMATES];
	public static int[] msx = new int[2048];
	public static int[] msy = new int[2048];
	public static short[,] cyclers = new short[DefineConstants.MAXCYCLERS, 6];
	public static short numcyclers;

    public static string[] fta_quotes = new string[DefineConstants.NUMOFFIRSTTIMEACTIVE];

	public static byte[] tempbuf = new byte[2048];
	public static byte[] packbuf = new byte[576];

	public static string buf = new string(new char[80]);

	public static short camsprite;
	public static short[] mirrorwall = new short[64];
	public static short[] mirrorsector = new short[64];
	public static short mirrorcnt;

	public static int current_menu;

    public static string betaname = "";

    public static string[] level_names = new string[44];
    public static string[] level_file_names = new string[44];
	public static int[] partime = new int[44];
	public static int[] designertime = new int[44];
    public static string[] volume_names = new string[4];
    public static string[] skill_names = new string[5];

	public static int checksume;
	public static int[] soundsiz = new int[DefineConstants.NUM_SOUNDS];

	public static short[] soundps = new short[DefineConstants.NUM_SOUNDS];
	public static short[] soundpe = new short[DefineConstants.NUM_SOUNDS];
	public static short[] soundvo = new short[DefineConstants.NUM_SOUNDS];
	public static int[] soundm = new int[DefineConstants.NUM_SOUNDS];
	public static int[] soundpr = new int[DefineConstants.NUM_SOUNDS];
    public static string[] sounds = new string[DefineConstants.NUM_SOUNDS];

	public static short title_zoom;

	//public static fx_device device = new fx_device();

	public static SAMPLE[] Sound = new SAMPLE[DefineConstants.NUM_SOUNDS];
	public static SOUNDOWNER[,] SoundOwner = new SOUNDOWNER[DefineConstants.NUM_SOUNDS, 4];

	public static char numplayersprites;
	public static char loadfromgrouponly;
	public static char earthquaketime;

	public static int fricxv;
	public static int fricyv;
	public static player_orig[] po = new player_orig[DefineConstants.MAXPLAYERS];
	public static player_struct[] ps = new player_struct[DefineConstants.MAXPLAYERS];
	public static user_defs ud = new user_defs();

	public static char pus;
	public static char pub;
	public static char syncstat;
	public static int[,] syncval = new int[DefineConstants.MAXPLAYERS, DefineConstants.MOVEFIFOSIZ];
	public static int[] syncvalhead = new int[DefineConstants.MAXPLAYERS];
	public static int syncvaltail;
	public static int syncvaltottail;

	public static input[] sync = new input[DefineConstants.MAXPLAYERS];
	public static input loc = new input();
	//public static input[] recsync = Arrays.InitializeWithDefaultInstances<input>(DefineConstants.RECSYNCBUFSIZ);
	public static int avgfvel;
	public static int avgsvel;
	public static int avgavel;
	public static int avghorz;
	public static int avgbits;


	public static input[,] inputfifo = new input[DefineConstants.MOVEFIFOSIZ, DefineConstants.MAXPLAYERS];
	public static input[] recsync = new input[DefineConstants.RECSYNCBUFSIZ];

	public static int movefifosendplc;

	  //Multiplayer syncing variables
	public static int[] movefifoend = new int[DefineConstants.MAXPLAYERS];


		//Game recording variables

	public static string playerreadyflag = new string(new char[DefineConstants.MAXPLAYERS]);
	public static char ready2send;
	public static int[] playerquitflag = new int[DefineConstants.MAXPLAYERS];
	public static int vel;
	public static int svel;
	public static int angvel;
	public static int horiz;
    public static int totalclock;
    public static int ototalclock;
	public static int respawnactortime = 768;
	public static int respawnitemtime = 768;
	public static int groupfile;

	//public static int[] script = new int[DefineConstants.MAXSCRIPTSIZE];
    //C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
    //ORIGINAL LINE: int *scriptptr;
    public struct DefInt
    {
        public int[] buffer;
        public int _bufferpos;

        public int bufferpos
        {
            get
            {
                return _bufferpos;
            }

            set
            {
                if (value < 0)
                    throw new System.Exception("BufferPos Invalid!");
                _bufferpos = value;
            }
        }

        public DefInt(int t)
        {
            buffer = new int[3000];
            _bufferpos = 0;
        }

        public static DefInt operator ++(DefInt w)
        {
            w.bufferpos++;
            return w;
        }

        public static DefInt operator --(DefInt w)
        {
            w.bufferpos--;
            return w;
        }

        public void Set(int i)
        {
            if (bufferpos >= buffer.Length)
                throw new System.Exception("Set on DefInit exceeds bounds");

            buffer[bufferpos] = i;
        }

        public int Get()
        {
            if (bufferpos >= buffer.Length)
                return 0;

            return buffer[bufferpos];
        }

        public int Get(int i)
        {
            if (bufferpos + i >= buffer.Length)
                return 0;

            return buffer[bufferpos + i];
        }


        public int GetPrev()
        {
            if (bufferpos - 1 >= buffer.Length)
                return 0;

            return buffer[bufferpos - 1];
        }
    }
    public static DefInt scriptptr = new DefInt(1);
//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
//ORIGINAL LINE: int *insptr;
	public static int insptr;
	public static int[] labelcode = new int[3000];
	public static int labelcnt;
    //C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
    //ORIGINAL LINE: int *actorscrptr[DefineConstants.MAXTILES],*parsing_actor;
    public static int[] actorscrptr;
//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
//ORIGINAL LINE: int *parsing_actor;
	public static int parsing_actor;
	public static string[] label = new string[5000];
	public static int error;
	public static int warning;
	public static char killit_flag;
	public static string music_pointer;
    public static int[] actortype; // = new int[DefineConstants.MAXTILES];


    public static bool[] KB_KeyDown = new bool[256];


    public static char display_mirror;
	public static char typebuflen;
	public static string typebuf = new string(new char[41]);

    public static string[,] music_fn = new string[4,64];
	public static char music_select;
    public static string[] env_music_fn = new string[164];
	public static char rtsplaying;


	public static short[] weaponsandammosprites = {DefineConstants.RPGSPRITE, DefineConstants.CHAINGUNSPRITE, DefineConstants.DEVISTATORAMMO, DefineConstants.RPGAMMO, DefineConstants.RPGAMMO, DefineConstants.JETPACK, DefineConstants.SHIELD, DefineConstants.FIRSTAID, DefineConstants.STEROIDS, DefineConstants.RPGAMMO, DefineConstants.RPGAMMO, DefineConstants.RPGSPRITE, DefineConstants.RPGAMMO, DefineConstants.FREEZESPRITE, DefineConstants.FREEZEAMMO};

	public static int impact_damage;

			//GLOBAL.C - replace the end "my's" with this
	public static int myx;
	public static int omyx;
	public static int myxvel;
	public static int myy;
	public static int omyy;
	public static int myyvel;
	public static int myz;
	public static int omyz;
	public static int myzvel;
	public static short myhoriz;
	public static short omyhoriz;
	public static short myhorizoff;
	public static short omyhorizoff;
	public static short myang;
	public static short omyang;
	public static short mycursectnum;
	public static short myjumpingcounter;
	public static short[,] frags = new short[DefineConstants.MAXPLAYERS, DefineConstants.MAXPLAYERS];

	public static char myjumpingtoggle;
	public static char myonground;
	public static char myhardlanding;
	public static char myreturntocenter;
	public static sbyte multiwho;
	public static sbyte multipos;
	public static sbyte multiwhat;
	public static sbyte multiflag;

	public static int fakemovefifoplc;
	public static int movefifoplc;
	public static int[] myxbak = new int[DefineConstants.MOVEFIFOSIZ];
	public static int[] myybak = new int[DefineConstants.MOVEFIFOSIZ];
	public static int[] myzbak = new int[DefineConstants.MOVEFIFOSIZ];
	public static int[] myhorizbak = new int[DefineConstants.MOVEFIFOSIZ];
	public static int dukefriction = 0xcc00;
	public static int show_shareware;

	public static short[] myangbak = new short[DefineConstants.MOVEFIFOSIZ];
	public static string myname = new string(new char[32]);
	public static char camerashitable;
	public static int freezerhurtowner = 0;
	public static char lasermode;
	// CTW - MODIFICATION
	// char networkmode = 255, movesperpacket = 1,gamequit = 0,playonten = 0,everyothertime;
	public static int networkmode = 255;
	public static int movesperpacket = 1;
	public static int gamequit = 0;
	public static char everyothertime;
	// CTW END - MODIFICATION
	public static int numfreezebounces = 3;
	public static int rpgblastradius;
	public static int pipebombblastradius;
	public static int tripbombblastradius;
	public static int shrinkerblastradius;
	public static int morterblastradius;
	public static int bouncemineblastradius;
	public static int seenineblastradius;
	public static STATUSBARTYPE sbar = new STATUSBARTYPE();

	public static int[] myminlag = new int[DefineConstants.MAXPLAYERS];
	public static int mymaxlag;
	public static int otherminlag;
	public static int bufferjitter = 1;
	public static short numclouds;
	public static short[] clouds = new short[128];
	public static short[] cloudx = new short[128];
	public static short[] cloudy = new short[128];
	public static int cloudtotalclock = 0;
	public static int totalmemory = 0;
	public static int numinterpolations = 0;
	public static int startofdynamicinterpolations = 0;
	public static int[] oldipos = new int[DefineConstants.MAXINTERPOLATIONS];
	public static int[] bakipos = new int[DefineConstants.MAXINTERPOLATIONS];
//C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
//ORIGINAL LINE: int *curipos[DefineConstants.MAXINTERPOLATIONS];
	public static int[] curipos = new int[DefineConstants.MAXINTERPOLATIONS];


}