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

using Build;

public partial class GlobalMembers
{

	//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern char inputloc;
	//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern int recfilep;
	//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern char vgacompatible;
	public static short probey = 0;
	public static short lastprobey = 0;
	public static short last_menu;
	public static short globalskillsound = -1;
	public static short sh;
	public static short onbar;
	public static short buttonstat;
	public static short deletespot;
	public static short last_zero;
	public static short last_fifty;
	public static short last_threehundred = 0;
	internal static char fileselect = (char)1;
	internal static char menunamecnt;
	internal static string[] menuname = new string[256];
	internal static string curpath = "";
	internal static string menupath = "";


	// CTW - REMOVED
	/* Error codes */
	/*
	#define eTenBnNotInWindows 3801
	#define eTenBnBadGameIni 3802
	#define eTenBnBadTenIni 3803
	#define eTenBnBrowseCancel 3804
	#define eTenBnBadTenInst 3805
	
	int  tenBnStart(void);
	void tenBnSetBrowseRtn(char *(*rtn)(char *str, int len));
	void tenBnSetExitRtn(void (*rtn)(void));
	void tenBnSetEndRtn(void (*rtn)(void));*/
	// CTW END - REMOVED

	public static void dummyfunc()
	{
	}

	public static void dummymess(int i, ref string c)
	{
	}

	// CTW - REMOVED
	/*
	void TENtext(void)
	{
	    long dacount,dalastcount;
	
	    puts("\nDuke Nukem 3D has been licensed exclusively to TEN (Total");
	    puts("Entertainment Network) for wide-area networked (WAN) multiplayer");
	    puts("games.\n");
	
	    puts("The multiplayer code within Duke Nukem 3D has been highly");
	    puts("customized to run best on TEN, where you'll experience fast and");
	    puts("stable performance, plus other special benefits.\n");
	
	    puts("We do not authorize or recommend the use of Duke Nukem 3D with");
	    puts("gaming services other than TEN.\n");
	
	    puts("Duke Nukem 3D is protected by United States copyright law and");
	    puts("international treaty.\n");
	
	    puts("For the best online multiplayer gaming experience, please call TEN");
	    puts("at 800-8040-TEN, or visit TEN's Web Site at www.ten.net.\n");
	
	    puts("Press any key to continue.\n");
	
	    _bios_timeofday(0,&dacount);
	
	    while( _bios_keybrd(1) == 0 )
	    {
	        _bios_timeofday(0,&dalastcount);
	        if( (dacount+240) < dalastcount ) break;
	    }
	}
	*/
	// CTW END - REMOVED

	public static void cmenu(short cm)
	{
		current_menu = cm;

		if ((cm >= 1000 && cm <= 1009))
		{
			return;
		}

		if (cm == 0)
		{
			probey = last_zero;
		}
		else if (cm == 50)
		{
			probey = last_fifty;
		}
		else if (cm >= 300 && cm < 400)
		{
			probey = last_threehundred;
		}
		else if (cm == 110)
		{
			probey = 1;
		}
		else
		{
			probey = 0;
		}
		lastprobey = -1;
	}


	public static void savetemp(ref string fn, int daptr, int dasiz)
	{

	}

	public static void getangplayers(short snum)
	{
		int i;
		int a;

		for (i = connecthead; i >= 0; i = connectpoint2[i])
		{
			if (i != snum)
			{
				a = ps[snum].ang + Engine.getangle(ps[i].posx - ps[snum].posx, ps[i].posy - ps[snum].posy);
				a = (short)(a - 1024);
				Engine.rotatesprite((320 << 15) + (((Engine.table.sintable[(a + 512) & 2047]) >> 7) << 15), (320 << 15) - (((Engine.table.sintable[a & 2047]) >> 8) << 15), pragmas.klabs(Engine.table.sintable[((a >> 1) + 768) & 2047] << 2), 0, DefineConstants.APLAYER, 0, (byte)ps[i].palookup, 0, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			}
		}
	}

	public static int mi;

	public static int probe(int x, int y, int i, int n)
	{
		short centre;
		short s;

		s = (short)(1 + (CONTROL_GetMouseSensitivity() >> 4));

		// jmarshall - mouse present
		//if (ControllerType == 1 && CONTROL_MousePresent)
		//{
		//	//C++ TO C# CONVERTER TODO TASK: The following line was determined to contain a copy constructor call - this should be verified and a copy constructor should be created:
		//	//ORIGINAL LINE: CONTROL_GetInput(&minfo);
		//	CONTROL_GetInput(new ControlInfo(minfo));
		//	mi += minfo.dz;
		//}
		//else
		// jmarshall end
		{
			minfo.dz = minfo.dyaw = 0;
		}

		if (x == (320 >> 1))
		{
			centre = (short)(320 >> 2);
		}
		else
		{
			centre = 0;
		}

		if (buttonstat == 0)
		{
			if ((KB_KeyDown[(DefineConstants.sc_UpArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_PgUp)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_8)] != false) || mi < -8192)
			{
				mi = 0;
				{
					KB_KeyDown[(DefineConstants.sc_UpArrow)] = (!(1 == 1));
				};
				{
					KB_KeyDown[(DefineConstants.sc_kpad_8)] = (!(1 == 1));
				};
				{
					KB_KeyDown[(DefineConstants.sc_PgUp)] = (!(1 == 1));
				};
				sound(DefineConstants.KICK_HIT);

				probey--;
				if (probey < 0)
				{
					probey = (short)(n - 1);
				}
				minfo.dz = 0;
			}
			if ((KB_KeyDown[(DefineConstants.sc_DownArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_PgDn)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_2)] != false) || mi > 8192)
			{
				mi = 0;
				{
					KB_KeyDown[(DefineConstants.sc_DownArrow)] = (!(1 == 1));
				};
				{
					KB_KeyDown[(DefineConstants.sc_kpad_2)] = (!(1 == 1));
				};
				{
					KB_KeyDown[(DefineConstants.sc_PgDn)] = (!(1 == 1));
				};
				sound(DefineConstants.KICK_HIT);
				probey++;
				minfo.dz = 0;
			}
		}

		if (probey >= n)
		{
			probey = 0;
		}

		if (centre != 0)
		{
			//        Engine.rotatesprite(((320>>1)+(centre)+54)<<16,(y+(probey*i)-4)<<16,65536L,0,SPINNINGNUKEICON+6-((6+(totalclock>>3))%7),sh,0,10,0,0,Engine.xdim-1,Engine.ydim-1);
			//        Engine.rotatesprite(((320>>1)-(centre)-54)<<16,(y+(probey*i)-4)<<16,65536L,0,SPINNINGNUKEICON+((totalclock>>3)%7),sh,0,10,0,0,Engine.xdim-1,Engine.ydim-1);

			Engine.rotatesprite(((320 >> 1) + (centre >> 1) + 70) << 16, (y + (probey * i) - 4) << 16, 65536, 0, DefineConstants.SPINNINGNUKEICON + 6 - ((6 + (totalclock >> 3)) % 7), (sbyte)sh, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			Engine.rotatesprite(((320 >> 1) - (centre >> 1) - 70) << 16, (y + (probey * i) - 4) << 16, 65536, 0, DefineConstants.SPINNINGNUKEICON + ((totalclock >> 3) % 7), (sbyte)sh, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
		else
		{
			Engine.rotatesprite((x - Engine.tilesizx[DefineConstants.BIGFNTCURSOR] - 4) << 16, (y + (probey * i) - 4) << 16, 65536, 0, DefineConstants.SPINNINGNUKEICON + (((totalclock >> 3)) % 7), (sbyte)sh, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}

		if ((KB_KeyDown[(DefineConstants.sc_Space)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_Enter)] != false) || (KB_KeyDown[(DefineConstants.sc_Return)] != false) || ((buttonstat & 1) != 0 && onbar == 0))
		{
			if (current_menu != 110)
			{
				sound(DefineConstants.PISTOL_BODYHIT);
			}
			{
				KB_KeyDown[(DefineConstants.sc_Return)] = (!(1 == 1));
			};
			{
				KB_KeyDown[(DefineConstants.sc_Space)] = (!(1 == 1));
			};
			{
				KB_KeyDown[(DefineConstants.sc_kpad_Enter)] = (!(1 == 1));
			};
			return (probey);
		}
		else if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false) || ((buttonstat & 2) != 0))
		{
			onbar = 0;
			{
				KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
			};
			sound(DefineConstants.EXITMENUSOUND);
			return (-1);
		}
		else
		{
			if (onbar == 0)
			{
				return (-probey - 2);
			}
			if ((KB_KeyDown[(DefineConstants.sc_LeftArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_4)] != false) || ((buttonstat & 1) != 0 && minfo.dyaw < -128))
			{
				return (probey);
			}
			else if ((KB_KeyDown[(DefineConstants.sc_RightArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_6)] != false) || ((buttonstat & 1) != 0 && minfo.dyaw > 128))
			{
				return (probey);
			}
			else
			{
				return (-probey - 2);
			}
		}

		return 0;
	}

	public static int menutext(int x, int y, short s, short p, string t)
	{
		int i;
		int ac;
		int centre;

		y -= 12;

		i = centre = 0;

		if (x == (320 >> 1))
		{
			for (int c = 0; c < t.Length; c++)
			{
				if (t[c] == ' ')
				{
					centre += 5;
					i++;
					continue;
				}
				ac = 0;
				if (t[c] >= '0' && t[c] <= '9')
				{
					ac = t[c] - '0' + DefineConstants.BIGALPHANUM - 10;
				}
				else if (t[c] >= 'a' && t[c] <= 'z')
				{
					ac = char.ToUpper(t[c]) - 'A' + DefineConstants.BIGALPHANUM;
				}
				else if (t[c] >= 'A' && t[c] <= 'Z')
				{
					ac = t[c] - 'A' + DefineConstants.BIGALPHANUM;
				}
				else
				{
					switch (t[c])
					{
						case '-':
							ac = DefineConstants.BIGALPHANUM - 11;
							break;
						case '.':
							ac = DefineConstants.BIGPERIOD;
							break;
						case '\'':
							ac = DefineConstants.BIGAPPOS;
							break;
						case ',':
							ac = DefineConstants.BIGCOMMA;
							break;
						case '!':
							ac = DefineConstants.BIGX;
							break;
						case '?':
							ac = DefineConstants.BIGQ;
							break;
						case ';':
							ac = DefineConstants.BIGSEMI;
							break;
						case ':':
							ac = DefineConstants.BIGSEMI;
							break;
						default:
							centre += 5;
							i++;
							continue;
					}
				}

				centre += Engine.tilesizx[ac] - 1;
				i++;
			}
		}

		if (centre != 0)
		{
			x = (320 - centre - 10) >> 1;
		}

		for (int c = 0; c < t.Length; c++)
		{
			if (t[c] == ' ')
			{
				x += 5;
				continue;
			}
			ac = 0;
			if (t[c] >= '0' && t[c] <= '9')
			{
				ac = t[c] - '0' + DefineConstants.BIGALPHANUM - 10;
			}
			else if (t[c] >= 'a' && t[c] <= 'z')
			{
				ac = char.ToUpper(t[c]) - 'A' + DefineConstants.BIGALPHANUM;
			}
			else if (t[c] >= 'A' && t[c] <= 'Z')
			{
				ac = t[c] - 'A' + DefineConstants.BIGALPHANUM;
			}
			else
			{
				switch (t[c])
				{
					case '-':
						ac = DefineConstants.BIGALPHANUM - 11;
						break;
					case '.':
						ac = DefineConstants.BIGPERIOD;
						break;
					case ',':
						ac = DefineConstants.BIGCOMMA;
						break;
					case '!':
						ac = DefineConstants.BIGX;
						break;
					case '\'':
						ac = DefineConstants.BIGAPPOS;
						break;
					case '?':
						ac = DefineConstants.BIGQ;
						break;
					case ';':
						ac = DefineConstants.BIGSEMI;
						break;
					case ':':
						ac = DefineConstants.BIGCOLIN;
						break;
					default:
						x += 5;
						continue;
				}
			}

			Engine.rotatesprite(x << 16, y << 16, 65536, 0, ac, (sbyte)s, (byte)p, 10 + 16, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

			x += Engine.tilesizx[ac];
		}
		return (x);
	}

	//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 't', so pointers on this parameter are left unchanged:
	public static int menutextc(int x, int y, short s, short p, string t)
	{
		// jmarshall - evaluate
		int i;
		int ac;
		int centre;

		y -= 12;

		i = centre = 0;

		if (x == (320 >> 1))
		{
			for (int c = 0; c < t.Length; c++)
			{
				if (t[c] == ' ')
				{
					centre += 5;
					i++;
					continue;
				}
				ac = 0;
				if (t[c] >= '0' && t[c] <= '9')
				{
					ac = t[c] - '0' + DefineConstants.BIGALPHANUM - 10;
				}
				else if (t[c] >= 'a' && t[c] <= 'z')
				{
					ac = char.ToUpper(t[c]) - 'A' + DefineConstants.BIGALPHANUM;
				}
				else if (t[c] >= 'A' && t[c] <= 'Z')
				{
					ac = t[c] - 'A' + DefineConstants.BIGALPHANUM;
				}
				else
				{
					switch (t[c])
					{
						case '-':
							ac = DefineConstants.BIGALPHANUM - 11;
							break;
						case '.':
							ac = DefineConstants.BIGPERIOD;
							break;
						case '\'':
							ac = DefineConstants.BIGAPPOS;
							break;
						case ',':
							ac = DefineConstants.BIGCOMMA;
							break;
						case '!':
							ac = DefineConstants.BIGX;
							break;
						case '?':
							ac = DefineConstants.BIGQ;
							break;
						case ';':
							ac = DefineConstants.BIGSEMI;
							break;
						case ':':
							ac = DefineConstants.BIGSEMI;
							break;
						default:
							centre += 5;
							i++;
							continue;
					}
				}

				centre += Engine.tilesizx[ac] - 1;
				i++;
			}
		}

		if (centre != 0)
		{
			x = (320 - centre - 10) >> 1;
		}

		for (int c = 0; c < t.Length; c++)
		{
			if (t[c] == ' ')
			{
				x += 5;
				continue;
			}
			ac = 0;
			if (t[c] >= '0' && t[c] <= '9')
			{
				ac = t[c] - '0' + DefineConstants.BIGALPHANUM - 10;
			}
			else if (t[c] >= 'a' && t[c] <= 'z')
			{
				ac = char.ToUpper(t[c]) - 'A' + DefineConstants.BIGALPHANUM;
			}
			else if (t[c] >= 'A' && t[c] <= 'Z')
			{
				ac = t[c] - 'A' + DefineConstants.BIGALPHANUM;
			}
			else
			{
				switch (t[c])
				{
					case '-':
						ac = DefineConstants.BIGALPHANUM - 11;
						break;
					case '.':
						ac = DefineConstants.BIGPERIOD;
						break;
					case ',':
						ac = DefineConstants.BIGCOMMA;
						break;
					case '!':
						ac = DefineConstants.BIGX;
						break;
					case '\'':
						ac = DefineConstants.BIGAPPOS;
						break;
					case '?':
						ac = DefineConstants.BIGQ;
						break;
					case ';':
						ac = DefineConstants.BIGSEMI;
						break;
					case ':':
						ac = DefineConstants.BIGCOLIN;
						break;
					default:
						x += 5;
						continue;
				}
			}

			Engine.rotatesprite(x << 16, y << 16, 65536, 0, ac, (sbyte)s, (byte)p, 10 + 16, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

			x += Engine.tilesizx[ac];
		}
		return (x);
	}

	public static void bar(int x, int y, ref int p, short dainc, char damodify, short s, short pa)
	{
		int xloc;
		int rev;

		if (dainc < 0)
		{
			dainc = (short)(-dainc);
			rev = 1;
		}
		else
		{
			rev = 0;
		}
		y -= 2;

		if (damodify != 0)
		{
			if (rev == 0)
			{
				if ((KB_KeyDown[(DefineConstants.sc_LeftArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_4)] != false) || ((buttonstat & 1) != 0 && minfo.dyaw < -256)) // && onbar) )
				{
					{
						KB_KeyDown[(DefineConstants.sc_LeftArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_4)] = (!(1 == 1));
					};

					p -= dainc;
					if (p < 0)
					{
						p = 0;
					}
					sound(DefineConstants.KICK_HIT);
				}
				if ((KB_KeyDown[(DefineConstants.sc_RightArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_6)] != false) || ((buttonstat & 1) != 0 && minfo.dyaw > 256)) //&& onbar) )
				{
					{
						KB_KeyDown[(DefineConstants.sc_RightArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_6)] = (!(1 == 1));
					};

					p += dainc;
					if (p > 63)
					{
						p = 63;
					}
					sound(DefineConstants.KICK_HIT);
				}
			}
			else
			{
				if ((KB_KeyDown[(DefineConstants.sc_RightArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_6)] != false) || ((buttonstat & 1) != 0 && minfo.dyaw > 256)) //&& onbar ))
				{
					{
						KB_KeyDown[(DefineConstants.sc_RightArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_6)] = (!(1 == 1));
					};

					p -= dainc;
					if (p < 0)
					{
						p = 0;
					}
					sound(DefineConstants.KICK_HIT);
				}
				if ((KB_KeyDown[(DefineConstants.sc_LeftArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_4)] != false) || ((buttonstat & 1) != 0 && minfo.dyaw < -256)) // && onbar) )
				{
					{
						KB_KeyDown[(DefineConstants.sc_LeftArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_4)] = (!(1 == 1));
					};

					p += dainc;
					if (p > 64)
					{
						p = 64;
					}
					sound(DefineConstants.KICK_HIT);
				}
			}
		}

		xloc = p;

		Engine.rotatesprite((x + 22) << 16, (y - 3) << 16, 65536, 0, DefineConstants.SLIDEBAR, (sbyte)s, (byte)pa, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		if (rev == 0)
		{
			Engine.rotatesprite((x + xloc + 1) << 16, (y + 1) << 16, 65536, 0, DefineConstants.SLIDEBAR + 1, (sbyte)s, (byte)pa, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
		else
		{
			Engine.rotatesprite((x + (65 - xloc)) << 16, (y + 1) << 16, 65536, 0, DefineConstants.SLIDEBAR + 1, (sbyte)s, (byte)pa, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
    }

    //C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
    //ORIGINAL LINE: #define SHX
    // ((x==X)*(-sh))
    //C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
    //ORIGINAL LINE: #define PHX
    // ((x==X)?1:2)
    //C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
    //ORIGINAL LINE: #define MWIN(X) Engine.rotatesprite( 320<<15,200<<15,X,0,MENUSCREEN,-16,0,10+64,0,0,Engine.xdim-1,Engine.ydim-1)
    //C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
    //ORIGINAL LINE: #define MWINXY(X,OX,OY) Engine.rotatesprite( ( 320+(OX) )<<15, ( 200+(OY) )<<15,X,0,MENUSCREEN,-16,0,10+64,0,0,Engine.xdim-1,Engine.ydim-1)


    public static int volnum;
	public static int levnum;
	public static int plrskl;
	public static int numplr;
	public static short lastsavedpos = -1;

	public static void dispnames()
	{
		short x;
		short c = 160;

		c += 64;
		for (x = 0; x <= 108; x += 12)
		{
			Engine.rotatesprite((c + 91 - 64) << 16, (x + 56) << 16, 65536, 0, DefineConstants.TEXTBOX, 24, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}

		Engine.rotatesprite(22 << 16, 97 << 16, 65536, 0, DefineConstants.WINDOWBORDER2, 24, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		Engine.rotatesprite(180 << 16, 97 << 16, 65536, 1024, DefineConstants.WINDOWBORDER2, 24, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		Engine.rotatesprite(99 << 16, 50 << 16, 65536, 512, DefineConstants.WINDOWBORDER1, 24, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		Engine.rotatesprite(103 << 16, 144 << 16, 65536, 1024 + 512, DefineConstants.WINDOWBORDER1, 24, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

		minitext(c, 48, ud.savegame[0], 2, 10 + 16);
		minitext(c, 48 + 12, ud.savegame[1], 2, 10 + 16);
		minitext(c, 48 + 12 + 12, ud.savegame[2], 2, 10 + 16);
		minitext(c, 48 + 12 + 12 + 12, ud.savegame[3], 2, 10 + 16);
		minitext(c, 48 + 12 + 12 + 12 + 12, ud.savegame[4], 2, 10 + 16);
		minitext(c, 48 + 12 + 12 + 12 + 12 + 12, ud.savegame[5], 2, 10 + 16);
		minitext(c, 48 + 12 + 12 + 12 + 12 + 12 + 12, ud.savegame[6], 2, 10 + 16);
		minitext(c, 48 + 12 + 12 + 12 + 12 + 12 + 12 + 12, ud.savegame[7], 2, 10 + 16);
		minitext(c, 48 + 12 + 12 + 12 + 12 + 12 + 12 + 12 + 12, ud.savegame[8], 2, 10 + 16);
		minitext(c, 48 + 12 + 12 + 12 + 12 + 12 + 12 + 12 + 12 + 12, ud.savegame[9], 2, 10 + 16);

	}

	//C++ TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
	public static int getfilenames(string kind)
	{
		// jmarshall -getfilenames
		/*
				short type;
				find_t fileinfo = new find_t();

				if (strcmp(kind, "SUBD") == 0)
				{
					strcpy(kind, "*.*");
					if (_dos_findfirst(kind, _A_SUBDIR, fileinfo) != 0)
					{
						return (-1);
					}
					type = 1;
				}
				else
				{
					if (_dos_findfirst(kind, _A_NORMAL, fileinfo) != 0)
					{
						return (-1);
					}
					type = 0;
				}
				do
				{
					if ((type == 0) || ((fileinfo.attrib & 16) > 0))
					{
						if ((fileinfo.name[0] != '.') || (fileinfo.name[1] != 0))
						{
							strcpy(menuname[menunamecnt], fileinfo.name);
							menuname[menunamecnt][16] = type;
							menunamecnt++;
						}
					}
				} while (_dos_findnext(fileinfo) == 0);
		*/
		return (0);
	}

	public static void sortfilenames()
	{
		// jmarshall -getfilenames
		/*
				string sortbuffer = new string(new char[17]);
				int i;
				int j;
				int k;

				for (i = 1; i < menunamecnt; i++)
				{
					for (j = 0; j < i; j++)
					{
						k = 0;
						while ((menuname[i][k] == menuname[j][k]) && (menuname[i][k] != 0) && (menuname[j][k] != 0))
						{
							k++;
						}
						if (menuname[i][k] < menuname[j][k])
						{
							//C++ TO C# CONVERTER TODO TASK: The memory management function 'memcpy' has no equivalent in C#:
							memcpy(sortbuffer[0], menuname[i][0], sizeof(char));
							//C++ TO C# CONVERTER TODO TASK: The memory management function 'memcpy' has no equivalent in C#:
							memcpy(menuname[i][0], menuname[j][0], sizeof(char));
							//C++ TO C# CONVERTER TODO TASK: The memory management function 'memcpy' has no equivalent in C#:
							memcpy(menuname[j][0], sortbuffer[0], sizeof(char));
						}
					}
				}
		*/
	}

	public static int quittimer = 0;

	public static void menus()
	{
		short c;
		short x;
		//C++ TO C# CONVERTER TODO TASK: 'volatile' has a different meaning in C#:
		//ORIGINAL LINE: volatile int l;
		int l;
		// CTW - REMOVED
		//  int tenerr;
		// CTW END - REMOVED
		// jmarshall - mouse present.
		/*
				getpackets();

				if (ControllerType == 1 && CONTROL_MousePresent)
				{
					if (buttonstat != 0 && onbar == 0)
					{
						x = (short)(MOUSE_GetButtons() << 3);
						if (x != 0)
						{
							buttonstat = (short)(x << 3);
						}
						else
						{
							buttonstat = 0;
						}
					}
					else
					{
						buttonstat = (short)MOUSE_GetButtons();
					}
				}
				else
		*/
		{
			buttonstat = 0;
		}


		if ((ps[myconnectindex].gm & DefineConstants.MODE_MENU) == 0)
		{
			//walock[DefineConstants.MAXTILES - 3] = 1;
			return;
		}

		ps[myconnectindex].gm &= (0xff - DefineConstants.MODE_TYPE);
		ps[myconnectindex].fta = 0;

		x = 0;

		sh = (short)(4 - (Engine.table.sintable[(totalclock << 4) & 2047] >> 11));

		if (!(current_menu >= 1000 && current_menu <= 2999 && current_menu >= 300 && current_menu <= 369))
		{
			vscrn();
		}

		switch (current_menu)
		{
			case 25000:
				gametext(160, 90, "SELECT A SAVE SPOT BEFORE", 0, (short)(2 + 8 + 16));
				gametext(160, 90 + 9, "YOU QUICK RESTORE.", 0, (short)(2 + 8 + 16));

				x = (short)probe(186, 124, 0, 0);
				if (x >= -1)
				{
					if (ud.multimode < 2 && ud.recstat != 2)
					{
						ready2send = (char)1;
						totalclock = ototalclock;
					}
					ps[myconnectindex].gm &= ~DefineConstants.MODE_MENU;
				}
				break;

			case 20000:
				x = (short)probe(326, 190, 0, 0);
				gametext(160, 50 - 8, "YOU ARE PLAYING THE SHAREWARE", 0, (short)(2 + 8 + 16));
				gametext(160, 59 - 8, "VERSION OF DUKE NUKEM 3D.  WHILE", 0, (short)(2 + 8 + 16));
				gametext(160, 68 - 8, "THIS VERSION IS REALLY COOL, YOU", 0, (short)(2 + 8 + 16));
				gametext(160, 77 - 8, "ARE MISSING OVER 75% OF THE TOTAL", 0, (short)(2 + 8 + 16));
				gametext(160, 86 - 8, "GAME, ALONG WITH OTHER GREAT EXTRAS", 0, (short)(2 + 8 + 16));
				gametext(160, 95 - 8, "AND GAMES, WHICH YOU'LL GET WHEN", 0, (short)(2 + 8 + 16));
				gametext(160, 104 - 8, "YOU ORDER THE COMPLETE VERSION AND", 0, (short)(2 + 8 + 16));
				gametext(160, 113 - 8, "GET THE FINAL TWO EPISODES.", 0, (short)(2 + 8 + 16));

				gametext(160, 113 + 8, "PLEASE READ THE 'HOW TO ORDER' ITEM", 0, (short)(2 + 8 + 16));
				gametext(160, 122 + 8, "ON THE MAIN MENU IF YOU WISH TO", 0, (short)(2 + 8 + 16));
				gametext(160, 131 + 8, "UPGRADE TO THE FULL REGISTERED", 0, (short)(2 + 8 + 16));
				gametext(160, 140 + 8, "VERSION OF DUKE NUKEM 3D.", 0, (short)(2 + 8 + 16));
				gametext(160, 149 + 16, "PRESS ANY KEY...", 0, (short)(2 + 8 + 16));

				if (x >= -1)
				{
					cmenu(100);
				}
				break;
			// CTW - REMOVED
			/*      case 20001:
						x = probe(188,80+32+32,0,0);
						gametext(160,86-8,"You must be in Windows 95 to",0,2+8+16);
						gametext(160,86,"play on TEN",0,2+8+16);
						gametext(160,86+32,"PRESS ANY KEY...",0,2+8+16);
						if(x >= -1) cmenu(0);
						break;

					case 20002:
						x = probe(188,80+32+32+32,0,0);
						gametext(160,86-8,"MISSING FILE: TENGAME.INI.  PLEASE",0,2+8+16);
						gametext(160,86,"CONNECT TO TEN BY LAUNCHING THE",0,2+8+16);
						gametext(160,86+8,"CONNECT TO TEN SHORTCUT OR CONTACT",0,2+8+16);
						gametext(160,86+8+8,"CUSTOMER SUPPORT AT 1-800-8040-TEN.",0,2+8+16);
						gametext(160,86+8+8+32,"PRESS ANY KEY...",0,2+8+16);
						if(x >= -1) cmenu(0);
						break;
					case 20003:
						x = probe(188,80+32+32,0,0);
						gametext(160,86-8,"BAD TEN INSTALL:  PLEASE RE-INSTALL",0,2+8+16);
						gametext(160,86,"BAD TEN INSTALL:  PLEASE RE-INSTALL TEN",0,2+8+16);
						gametext(160,86+32,"PRESS ANY KEY...",0,2+8+16);
						if(x >= -1) cmenu(0);
						break;
					case 20005:
						x = probe(188,80+32+32,0,0);
						gametext(160,86-8,"GET THE LATEST TEN SOFTWARE AT",0,2+8+16);
						gametext(160,86,"HTTP://WWW.TEN.NET",0,2+8+16);
						gametext(160,86+32,"PRESS ANY KEY...",0,2+8+16);
						if(x >= -1) cmenu(0);
						break;*/
			// CTW END - REMOVED

			case 15001:
			case 15000:

				gametext(160, 90, "LOAD last game:", 0, (short)(2 + 8 + 16));

				gametext(160, 99, ud.savegame[lastsavedpos], 0, (short)(2 + 8 + 16));

				gametext(160, 99 + 9, "(Y/N)", 0, (short)(2 + 8 + 16));

				if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false) || (KB_KeyDown[(DefineConstants.sc_N)] != false) || (buttonstat & 2) != 0)
				{
					if (Engine.board.sprite[ps[myconnectindex].i].extra <= 0)
					{
						enterlevel((char)DefineConstants.MODE_GAME);
						return;
					}

					{
						KB_KeyDown[(DefineConstants.sc_N)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
					};

					ps[myconnectindex].gm &= ~DefineConstants.MODE_MENU;
					if (ud.multimode < 2 && ud.recstat != 2)
					{
						ready2send = (char)1;
						totalclock = ototalclock;
					}
				}

				if ((KB_KeyDown[(DefineConstants.sc_Space)] != false) || (KB_KeyDown[(DefineConstants.sc_Return)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_Enter)] != false) || (KB_KeyDown[(DefineConstants.sc_Y)] != false) || (buttonstat & 1) != 0)
				{
					KB_FlushKeyboardQueue();
					FX_StopAllSounds();

					if (ud.multimode > 1)
					{
						loadplayer((sbyte)(-1 - lastsavedpos));
						ps[myconnectindex].gm = DefineConstants.MODE_GAME;
					}
					else
					{
						c = (short)(loadplayer((sbyte)lastsavedpos) ? 1 : 0);
						if (c == 0)
						{
							ps[myconnectindex].gm = DefineConstants.MODE_GAME;
						}
					}
				}

				probe(186, 124 + 9, 0, 0);

				break;

			case 10000:
			case 10001:

				c = 60;
				Engine.rotatesprite(160 << 16, 19 << 16, 65536, 0, DefineConstants.MENUBAR, 16, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				menutext(160, 24, 0, 0, "ADULT MODE");

				x = (short)probe(60, 50 + 16, 16, 2);
				if (x == -1)
				{
					cmenu(200);
					break;
				}

				menutext(c, 50 + 16, (-2), (-2), "ADULT MODE");
				menutext(c, 50 + 16 + 16, (-3), (-3), "ENTER PASSWORD");

				if (ud.lockout != 0)
				{
					menutext(c + 160 + 40, 50 + 16, 0, 0, "OFF");
				}
				else
				{
					menutext(c + 160 + 40, 50 + 16, 0, 0, "ON");
				}
				// jmarshall - adult mode password
				/*
								if (current_menu == 10001)
								{
									gametext(160, 50 + 16 + 16 + 16 + 16 - 12, "ENTER PASSWORD", 0, (short)(2 + 8 + 16));
									x = strget((short)(320 >> 1), (short)(50 + 16 + 16 + 16 + 16), ref buf, 19, 998);

									if (x != 0)
									{
										if (ud.pwlockout[0] == 0 || ud.lockout == 0)
										{
											strcpy(ud.pwlockout[0], buf);
										}
										else if (strcmp(buf, ud.pwlockout[0]) == 0)
										{
											ud.lockout = 0;
											buf[0] = 0;

											for (x = 0; x < numanimwalls; x++)
											{
												if (Engine.board.wall[animwall[x].wallnum].picnum != DefineConstants.W_SCREENBREAK && Engine.board.wall[animwall[x].wallnum].picnum != DefineConstants.W_SCREENBREAK + 1 && Engine.board.wall[animwall[x].wallnum].picnum != DefineConstants.W_SCREENBREAK + 2)
												{
													if (Engine.board.wall[animwall[x].wallnum].extra >= 0)
													{
														Engine.board.wall[animwall[x].wallnum].picnum = Engine.board.wall[animwall[x].wallnum].extra;
													}
												}
											}

										}
										current_menu = 10000;
										{
											KB_KeyDown[(DefineConstants.sc_Return)] = (!(1 == 1));
										};
										{
											KB_KeyDown[(DefineConstants.sc_kpad_Enter)] = (!(1 == 1));
										};
										KB_FlushKeyboardQueue();
									}
								}
								else
								{
									if (x == 0)
									{
										if (ud.lockout == 1)
										{
											if (ud.pwlockout[0] == 0)
											{
												ud.lockout = 0;
												for (x = 0; x < numanimwalls; x++)
												{
													if (Engine.board.wall[animwall[x].wallnum].picnum != DefineConstants.W_SCREENBREAK && Engine.board.wall[animwall[x].wallnum].picnum != DefineConstants.W_SCREENBREAK + 1 && Engine.board.wall[animwall[x].wallnum].picnum != DefineConstants.W_SCREENBREAK + 2)
													{
														if (Engine.board.wall[animwall[x].wallnum].extra >= 0)
														{
															Engine.board.wall[animwall[x].wallnum].picnum = Engine.board.wall[animwall[x].wallnum].extra;
														}
													}
												}
											}
											else
											{
												buf[0] = 0;
												current_menu = 10001;
												inputloc = 0;
												KB_FlushKeyboardQueue();
											}
										}
										else
										{
											ud.lockout = 1;

											for (x = 0; x < numanimwalls; x++)
											{
												switch (Engine.board.wall[animwall[x].wallnum].picnum)
												{
													case DefineConstants.FEMPIC1:
														Engine.board.wall[animwall[x].wallnum].picnum = DefineConstants.BLANKSCREEN;
														break;
													case DefineConstants.FEMPIC2:
													case DefineConstants.FEMPIC3:
														Engine.board.wall[animwall[x].wallnum].picnum = DefineConstants.SCREENBREAK6;
														break;
												}
											}
										}
									}

									else if (x == 1)
									{
										current_menu = 10001;
										inputloc = 0;
										KB_FlushKeyboardQueue();
									}

								}
				*/
				// jmarshall end
				break;

			case 1000:
			case 1001:
			case 1002:
			case 1003:
			case 1004:
			case 1005:
			case 1006:
			case 1007:
			case 1008:
			case 1009:
				string _loadgamestr = "";
				Engine.rotatesprite(160 << 16, 200 << 15, 65536, 0, DefineConstants.MENUSCREEN, 16, 0, 10 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				Engine.rotatesprite(160 << 16, 19 << 16, 65536, 0, DefineConstants.MENUBAR, 16, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				menutext(160, 24, 0, 0, "LOAD GAME");
				Engine.rotatesprite(101 << 16, 97 << 16, 65536, 512, DefineConstants.MAXTILES - 3, -32, 0, 4 + 10 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

				dispnames();

				//sprintf(tempbuf, "PLAYERS: %-2d                      ", numplr);
				_loadgamestr = "PLAYERS: " + numplr;
				gametext(160, 158, _loadgamestr, 0, (short)(2 + 8 + 16));

				//sprintf(tempbuf, "EPISODE: %-2d / LEVEL: %-2d / SKILL: %-2d", 1 + volnum, 1 + levnum, plrskl);
				_loadgamestr = string.Format("EPISODE: {0} / LEVEL: {1} / SKILL: {2}", 1 + volnum, 1 + levnum, plrskl);
				gametext(160, 170, _loadgamestr, 0, (short)(2 + 8 + 16));

				gametext(160, 90, "LOAD game:", 0, (short)(2 + 8 + 16));
				//sprintf(tempbuf, "\"%s\"", ud.savegame[current_menu - 1000]);
				_loadgamestr = string.Format("\"{0}\"", ud.savegame[current_menu - 1000]);
				gametext(160, 99, _loadgamestr, 0, (short)(2 + 8 + 16));
				gametext(160, 99 + 9, "(Y/N)", 0, (short)(2 + 8 + 16));

				if ((KB_KeyDown[(DefineConstants.sc_Space)] != false) || (KB_KeyDown[(DefineConstants.sc_Return)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_Enter)] != false) || (KB_KeyDown[(DefineConstants.sc_Y)] != false) || (buttonstat & 1) != 0)
				{
					lastsavedpos = (short)(current_menu - 1000);

					KB_FlushKeyboardQueue();
					if (ud.multimode < 2 && ud.recstat != 2)
					{
						ready2send = (char)1;
						totalclock = ototalclock;
					}

					if (ud.multimode > 1)
					{
						if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
						{
							loadplayer((sbyte)(-1 - lastsavedpos));
							ps[myconnectindex].gm = DefineConstants.MODE_GAME;
						}
						else
						{
							tempbuf[0] = 126;
							tempbuf[1] = (byte)lastsavedpos;
							for (x = connecthead; x >= 0; x = connectpoint2[x])
							{
								if (x != myconnectindex)
								{
								//	sendpacket(x, tempbuf, 2);
								}
							}

							getpackets();

							loadplayer((sbyte)lastsavedpos);

							multiflag = 0;
						}
					}
					else
					{
						c = (short)(loadplayer((sbyte)lastsavedpos) ? 1 : 0);
						if (c == 0)
						{
							ps[myconnectindex].gm = DefineConstants.MODE_GAME;
						}
					}

					break;
				}
				if ((KB_KeyDown[(DefineConstants.sc_N)] != false) || (KB_KeyDown[(DefineConstants.sc_Escape)] != false) || (buttonstat & 2) != 0)
				{
					{
						KB_KeyDown[(DefineConstants.sc_N)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
					};
					sound(DefineConstants.EXITMENUSOUND);
					if ((ps[myconnectindex].gm & DefineConstants.MODE_DEMO) != 0)
					{
						cmenu(300);
					}
					else
					{
						ps[myconnectindex].gm &= ~DefineConstants.MODE_MENU;
						if (ud.multimode < 2 && ud.recstat != 2)
						{
							ready2send = (char)1;
							totalclock = ototalclock;
						}
					}
				}

				probe(186, 124 + 9, 0, 0);

				break;

			case 1500:

				if ((KB_KeyDown[(DefineConstants.sc_Space)] != false) || (KB_KeyDown[(DefineConstants.sc_Return)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_Enter)] != false) || (KB_KeyDown[(DefineConstants.sc_Y)] != false) || (buttonstat & 1) != 0)
				{
					KB_FlushKeyboardQueue();
					cmenu(100);
				}
				if ((KB_KeyDown[(DefineConstants.sc_N)] != false) || (KB_KeyDown[(DefineConstants.sc_Escape)] != false) || (buttonstat & 2) != 0)
				{
					{
						KB_KeyDown[(DefineConstants.sc_N)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
					};
					if (ud.multimode < 2 && ud.recstat != 2)
					{
						ready2send = (char)1;
						totalclock = ototalclock;
					}
					ps[myconnectindex].gm &= ~DefineConstants.MODE_MENU;
					sound(DefineConstants.EXITMENUSOUND);
					break;
				}
				probe(186, 124, 0, 0);
				gametext(160, 90, "ABORT this game?", 0, (short)(2 + 8 + 16));
				gametext(160, 90 + 9, "(Y/N)", 0, (short)(2 + 8 + 16));

				break;

			case 2000:
			case 2001:
			case 2002:
			case 2003:
			case 2004:
			case 2005:
			case 2006:
			case 2007:
			case 2008:
			case 2009:
				string _savegame2 = "";
				Engine.rotatesprite(160 << 16, 200 << 15, 65536, 0, DefineConstants.MENUSCREEN, 16, 0, 10 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				Engine.rotatesprite(160 << 16, 19 << 16, 65536, 0, DefineConstants.MENUBAR, 16, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				menutext(160, 24, 0, 0, "SAVE GAME");

				Engine.rotatesprite(101 << 16, 97 << 16, 65536, 512, DefineConstants.MAXTILES - 3, -32, 0, 4 + 10 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				_savegame2 = string.Format("PLAYERS: {0}", ud.multimode);
				//sprintf(tempbuf, "PLAYERS: %-2d                      ", ud.multimode);
				gametext(160, 158, _savegame2, 0, (short)(2 + 8 + 16));

				_savegame2 = string.Format("EPISODE: {0} / LEVEL: {1} / SKILL: {2}", 1 + ud.volume_number, 1 + ud.level_number, ud.player_skill);
				gametext(160, 170, _savegame2, 0, (short)(2 + 8 + 16));

				dispnames();

				gametext(160, 90, "OVERWRITE previous SAVED game?", 0, (short)(2 + 8 + 16));
				gametext(160, 90 + 9, "(Y/N)", 0, (short)(2 + 8 + 16));

				if ((KB_KeyDown[(DefineConstants.sc_Space)] != false) || (KB_KeyDown[(DefineConstants.sc_Return)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_Enter)] != false) || (KB_KeyDown[(DefineConstants.sc_Y)] != false) || (buttonstat & 1) != 0)
				{
					KB_FlushKeyboardQueue();
					//inputloc = ud.savegame[current_menu - 2000].Length;

					cmenu((short)(current_menu - 2000 + 360));

					KB_FlushKeyboardQueue();
					break;
				}
				if ((KB_KeyDown[(DefineConstants.sc_N)] != false) || (KB_KeyDown[(DefineConstants.sc_Escape)] != false) || (buttonstat & 2) != 0)
				{
					{
						KB_KeyDown[(DefineConstants.sc_N)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
					};
					cmenu(351);
					sound(DefineConstants.EXITMENUSOUND);
				}
				probe(186, 124, 0, 0);

				break;

			case 990:
			case 991:
			case 992:
			case 993:
			case 994:
			case 995:
			case 996:
			case 997:

				//            Engine.rotatesprite(c<<16,200<<15,65536L,0,MENUSCREEN,16,0,10+64,0,0,Engine.xdim-1,Engine.ydim-1);
				//            Engine.rotatesprite(c<<16,19<<16,65536L,0,MENUBAR,16,0,10,0,0,Engine.xdim-1,Engine.ydim-1);
				//            menutext(c,24,0,0,"CREDITS");

				if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false))
				{
					cmenu(0);
					break;
				}

				if ((KB_KeyDown[(DefineConstants.sc_LeftArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_4)] != false) || (KB_KeyDown[(DefineConstants.sc_UpArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_PgUp)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_8)] != false))
				{
					{
						KB_KeyDown[(DefineConstants.sc_LeftArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_4)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_UpArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_PgUp)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_8)] = (!(1 == 1));
					};

					sound(DefineConstants.KICK_HIT);
					current_menu--;
					if (current_menu < 990)
					{
						current_menu = 992;
					}
				}
				else if ((KB_KeyDown[(DefineConstants.sc_PgDn)] != false) || (KB_KeyDown[(DefineConstants.sc_Return)] != false) || (KB_KeyDown[(DefineConstants.sc_Space)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_Enter)] != false) || (KB_KeyDown[(DefineConstants.sc_RightArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_DownArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_2)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_9)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_6)] != false))
				{
					{
						KB_KeyDown[(DefineConstants.sc_PgDn)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_Return)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_RightArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_Enter)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_6)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_9)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_2)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_DownArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_Space)] = (!(1 == 1));
					};
					sound(DefineConstants.KICK_HIT);
					current_menu++;
					if (current_menu > 992)
					{
						current_menu = 990;
					}
				}

				switch (current_menu)
				{
					case 990:
					case 991:
					case 992:
						Engine.rotatesprite(160 << 16, 200 << 15, 65536, 0, 2504 + current_menu - 990, 0, 0, 10 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

						break;

				}
				break;

			case 0:
				c = (short)(320 >> 1);
				Engine.rotatesprite(c << 16, 28 << 16, 65536, 0, DefineConstants.INGAMEDUKETHREEDEE, 0, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				Engine.rotatesprite((c + 100) << 16, 36 << 16, 65536, 0, DefineConstants.PLUTOPAKSPRITE + 2, (sbyte)(Engine.table.sintable[(totalclock << 4) & 2047] >> 11), 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				// CTW - MODIFICATION
				//          x = probe(c,67,16,7);
				x = (short)probe(c, 67, 16, 6);
				// CTW END - MODIFICATION
				if (x >= 0)
				{
					if (ud.multimode > 1 && x == 0 && ud.recstat != 2)
					{
						if (movesperpacket == 4 && myconnectindex != connecthead)
						{
							break;
						}

						last_zero = 0;
						cmenu(600);
					}
					else
					{
						last_zero = x;
						switch (x)
						{
							case 0:
								cmenu(100);
								break;
							// CTW - MODIFICATION
							// Shifted the entire menu input results up one.
							/*                      case 1:
														if(movesperpacket == 4 || numplayers > 1)
															break;

														tenBnSetExitRtn(dummyfunc);
														setDebugMsgRoutine(dummymess);
														tenerr = tenBnStart();

														switch(tenerr)
														{
															case eTenBnNotInWindows:
																cmenu(20001);
																break;
															case eTenBnBadGameIni:
																cmenu(20002);
																break;
															case eTenBnBadTenIni:
																cmenu(20003);
																break;
															case eTenBnBrowseCancel:
																cmenu(20004);
																break;
															case eTenBnBadTenInst:
																cmenu(20005);
																break;
															default:
																playonten = 1;
																gameexit(" ");
																break;
														}
														break;*/
							case 1:
								cmenu(200);
								break;
							case 2:
								if (movesperpacket == 4 && connecthead != myconnectindex)
								{
									break;
								}
								cmenu(300);
								break;
							case 3:
								KB_FlushKeyboardQueue();
								cmenu(400);
								break;
							case 4:
								cmenu(990);
								break;
							case 5:
								cmenu(500);
								break;
								// CTW END - MODIFICATION
						}
					}
				}

				if ((KB_KeyDown[(DefineConstants.sc_Q)] != false))
				{
					cmenu(500);
				}

				if (x == -1)
				{
					ps[myconnectindex].gm &= ~DefineConstants.MODE_MENU;
					if (ud.multimode < 2 && ud.recstat != 2)
					{
						ready2send = (char)1;
						totalclock = ototalclock;
					}
				}

				if (movesperpacket == 4)
				{
					if (myconnectindex == connecthead)
					{
						menutext(c, 67, (-2), (-2), "NEW GAME");
					}
					else
					{
						menutext(c, 67, (-2), 1, "NEW GAME");
					}
				}
				else
				{
					menutext(c, 67, (-2), (-2), "NEW GAME");
				}

				// CTW - REMOVED
				/*          if(movesperpacket != 4 && numplayers < 2)
								menutext(c,67+16,SHX(-3),PHX(-3),"PLAY ON TEN");
							else
								menutext(c,67+16,SHX(-3),1,"PLAY ON TEN");*/
				// CTW END - REMOVED

				// CTW - MODIFICATION - Not going to comment out the exact old code here.
				// I shifted up every menu option by 16.
				// I shifted up every menu result by 1.
				menutext(c, 67 + 16, (-3), (-3), "OPTIONS");

				if (movesperpacket == 4 && connecthead != myconnectindex)
				{
					menutext(c, 67 + 16 + 16, (-4), 1, "LOAD GAME");
				}
				else
				{
					menutext(c, 67 + 16 + 16, (-4), (-4), "LOAD GAME");
				}

#if DEMO
				menutext(c, 67 + 16 + 16 + 16, (-5), (-5), "HOW TO ORDER");
#else
				menutext(c, 67 + 16 + 16 + 16, (-5), (-5), "HELP");
#endif
				menutext(c, 67 + 16 + 16 + 16 + 16, (-6), (-6), "CREDITS");

				menutext(c, 67 + 16 + 16 + 16 + 16 + 16, (-7), (-7), "QUIT");

				break;
			// CTW END - MODIFICATION

			case 50:
				c = (short)(320 >> 1);
				Engine.rotatesprite(c << 16, 32 << 16, 65536, 0, DefineConstants.INGAMEDUKETHREEDEE, 0, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				Engine.rotatesprite((c + 100) << 16, 36 << 16, 65536, 0, DefineConstants.PLUTOPAKSPRITE + 2, (sbyte)(Engine.table.sintable[(totalclock << 4) & 2047] >> 11), 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				x = (short)probe(c, 67, 16, 7);
				switch (x)
				{
					case 0:
						if (movesperpacket == 4 && myconnectindex != connecthead)
						{
							break;
						}
						if (ud.multimode < 2 || ud.recstat == 2)
						{
							cmenu(1500);
						}
						else
						{
							cmenu(600);
							last_fifty = 0;
						}
						break;
					case 1:
						if (movesperpacket == 4 && connecthead != myconnectindex)
						{
							break;
						}
						if (ud.recstat != 2)
						{
							last_fifty = 1;
							cmenu(350);
							Engine._device.setview(0, 0, Engine.xdim - 1, Engine.ydim - 1);
						}
						break;
					case 2:
						if (movesperpacket == 4 && connecthead != myconnectindex)
						{
							break;
						}
						last_fifty = 2;
						cmenu(300);
						break;
					case 3:
						last_fifty = 3;
						cmenu(200);
						break;
					case 4:
						last_fifty = 4;
						KB_FlushKeyboardQueue();
						cmenu(400);
						break;
					case 5:
						if (numplayers < 2)
						{
							last_fifty = 5;
							cmenu(501);
						}
						break;
					case 6:
						last_fifty = 6;
						cmenu(500);
						break;
					case -1:
						ps[myconnectindex].gm &= ~DefineConstants.MODE_MENU;
						if (ud.multimode < 2 && ud.recstat != 2)
						{
							ready2send = (char)1;
							totalclock = ototalclock;
						}
						break;
				}

				if ((KB_KeyDown[(DefineConstants.sc_Q)] != false))
				{
					cmenu(500);
				}

				if (movesperpacket == 4 && connecthead != myconnectindex)
				{
					menutext(c, 67, (-2), 1, "NEW GAME");
					menutext(c, 67 + 16, (-3), 1, "SAVE GAME");
					menutext(c, 67 + 16 + 16, (-4), 1, "LOAD GAME");
				}
				else
				{
					menutext(c, 67, (-2), (-2), "NEW GAME");
					menutext(c, 67 + 16, (-3), (-3), "SAVE GAME");
					menutext(c, 67 + 16 + 16, (-4), (-4), "LOAD GAME");
				}

				menutext(c, 67 + 16 + 16 + 16, (-5), (-5), "OPTIONS");
#if DEMO
				menutext(c, 67 + 16 + 16 + 16 + 16, (-6), (-6), "HOW TO ORDER");
#else
				menutext(c, 67 + 16 + 16 + 16 + 16, (-6), (-6), " HELP");
#endif
				if (numplayers > 1)
				{
					menutext(c, 67 + 16 + 16 + 16 + 16 + 16, (-7), 1, "QUIT TO TITLE");
				}
				else
				{
					menutext(c, 67 + 16 + 16 + 16 + 16 + 16, (-7), (-7), "QUIT TO TITLE");
				}
				menutext(c, 67 + 16 + 16 + 16 + 16 + 16 + 16, (-8), (-8), "QUIT GAME");
				break;

			case 100:
				Engine.rotatesprite(160 << 16, 19 << 16, 65536, 0, DefineConstants.MENUBAR, 16, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				menutext(160, 24, 0, 0, "SELECT AN EPISODE");
#if !DEMO
				if (boardfilename.Length > 0)
				{
					x = (short)probe(160, 60, 20, 5);
				}
				else
				{
					x = (short)probe(160, 60, 20, 4);
				}
#else
				if (boardfilename.Length > 0)
				{
					x = (short)probe(160, 60, 20, 4);
				}
				else
				{
					x = (short)probe(160, 60, 20, 3);
				}
#endif
				if (x >= 0)
				{
#if VOLUMEONE
					if (x > 0)
					{
						cmenu(20000);
					}
					else
					{
						ud.m_volume_number = x;
						ud.m_level_number = 0;
						cmenu(110);
					}
#endif

#if !VOLUMEONE
#if !PLUTOPAK

					if (x == 3 && boardfilename.Length > 0)
					{
						ud.m_volume_number = 0;
						ud.m_level_number = 7;
					}
#else
					if (x == 4 && boardfilename[0])
					{
						ud.m_volume_number = 0;
						ud.m_level_number = 7;
					}
#endif

					else
					{
						ud.m_volume_number = x;
						ud.m_level_number = 0;
					}
					cmenu(110);
#endif
				}
				else if (x == -1)
				{
					if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
					{
						cmenu(50);
					}
					else
					{
						cmenu(0);
					}
				}

				menutext(160, 60, (-2), (-2), volume_names[0]);

				c = 80;
#if VOLUMEONE
				menutext(160, 60 + 20, (-3), 1, volume_names[1]);
				menutext(160, 60 + 20 + 20, (-4), 1, volume_names[2]);
#if !DEMO
				menutext(160, 60 + 20 + 20, (-5), 1, volume_names[3]);
#endif
#else
				menutext(160, 60 + 20, (-3), (-3), volume_names[1]);
				menutext(160, 60 + 20 + 20, (-4), (-4), volume_names[2]);
#if !DEMO
				menutext(160, 60 + 20 + 20 + 20, (-5), (-5), volume_names[3]);
				if (boardfilename.Length > 0)
				{

					menutext(160, 60 + 20 + 20 + 20 + 20, (-6), (-6), "USER MAP");
					gametextpal(160, 60 + 20 + 20 + 20 + 20 + 3, boardfilename, 16 + (Engine.table.sintable[(totalclock << 4) & 2047]>>11), 2);
				}
#else
				if (boardfilename.Length > 0)
				{
					menutext(160, 60 + 20 + 20 + 20, (-6), (-6), "USER MAP");
					gametext(160, 60 + 20 + 20 + 20 + 6, boardfilename, 2, (short)(2 + 8 + 16));
				}
#endif

#endif
				break;

			case 110:
				c = (short)(320 >> 1);
				Engine.rotatesprite(c << 16, 19 << 16, 65536, 0, DefineConstants.MENUBAR, 16, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				menutext(c, 24, 0, 0, "SELECT SKILL");
				x = (short)probe(c, 70, 19, 4);
				if (x >= 0)
				{
					switch (x)
					{
						case 0:
							globalskillsound = DefineConstants.JIBBED_ACTOR6;
							break;
						case 1:
							globalskillsound = DefineConstants.BONUS_SPEECH1;
							break;
						case 2:
							globalskillsound = DefineConstants.DUKE_GETWEAPON2;
							break;
						case 3:
							globalskillsound = DefineConstants.JIBBED_ACTOR5;
							break;
					}

					sound(globalskillsound);

					ud.m_player_skill = x + 1;
					if (x == 3)
					{
						ud.m_respawn_monsters = 1;
					}
					else
					{
						ud.m_respawn_monsters = 0;
					}

					ud.m_monsters_off = ud.monsters_off = 0;

					ud.m_respawn_items = 0;
					ud.m_respawn_inventory = 0;

					ud.multimode = 1;

					if (ud.m_volume_number == 3)
					{
						flushperms();
						Engine._device.setview(0, 0, Engine.xdim - 1, Engine.ydim - 1);
						Engine.clearview();
						Engine.NextPage();
					}

					newgame((char)ud.m_volume_number, (char)ud.m_level_number, (char)ud.m_player_skill);
					enterlevel((char)DefineConstants.MODE_GAME);
				}
				else if (x == -1)
				{
					cmenu(100);
					KB_FlushKeyboardQueue();
				}

				menutext(c, 70, (-2), (-2), skill_names[0]);
				menutext(c, 70 + 19, (-3), (-3), skill_names[1]);
				menutext(c, 70 + 19 + 19, (-4), (-4), skill_names[2]);
				menutext(c, 70 + 19 + 19 + 19, (-5), (-5), skill_names[3]);
				break;

			case 200:

				Engine.rotatesprite(320 << 15, 10 << 16, 65536, 0, DefineConstants.MENUBAR, 16, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				menutext(320 >> 1, 15, 0, 0, "OPTIONS");

				c = (short)((320 >> 1) - 120);

				if (probey == 3 || probey == 4 || probey == 5)
					onbar = 1;
				else
					onbar = 0;

				x = (short)probe(c + 6, 31, 15, 10);

				if (x == -1)
				{
					if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
					{
						cmenu(50);
					}
					else
					{
						cmenu(0);
					}
				}

				if (onbar == 0)
				{
					switch (x)
					{
						case 0:
							ud.detail = 1 - ud.detail;
							break;
						case 1:
							ud.shadows = 1 - ud.shadows;
							break;
						case 2:
							ud.screen_tilting = 1 - ud.screen_tilting;
							break;
						case 6:
							// jmarshall - keyboard and house
							//if (ControllerType == controltype.controltype_keyboardandmouse)
							//{
							//	ud.mouseflip = 1 - ud.mouseflip;
							//}
							// jmarshall end
							break;
						case 7:
							cmenu(700);
							break;
						case 8:
#if !AUSTRALIA
							cmenu(10000);
#endif
							break;
						case 9:
							if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
							{
								closedemowrite();
								break;
							}
							if (ud.m_recstat == 0)
								ud.m_recstat = 1;
							else
								ud.m_recstat = 0;
							break;
					}
				}

				if (ud.detail != 0)
				{
					menutext(c + 160 + 40, 31, 0, 0, "HIGH");
				}
				else
				{
					menutext(c + 160 + 40, 31, 0, 0, "LOW");
				}

				if (ud.shadows != 0)
				{
					menutext(c + 160 + 40, 31 + 15, 0, 0, "ON");
				}
				else
				{
					menutext(c + 160 + 40, 31 + 15, 0, 0, "OFF");
				}

				switch (ud.screen_tilting)
				{
					case 0:
						menutext(c + 160 + 40, 31 + 15 + 15, 0, 0, "OFF");
						break;
					case 1:
						menutext(c + 160 + 40, 31 + 15 + 15, 0, 0, "ON");
						break;
					case 2:
						menutext(c + 160 + 40, 31 + 15 + 15, 0, 0, "FULL");
						break;
				}

				menutext(c, 31, (-2), (-2), "DETAIL");
				menutext(c, 31 + 15, (-3), (-3), "SHADOWS");
				menutext(c, 31 + 15 + 15, (-4), (-4), "SCREEN TILTING");
				menutext(c, 31 + 15 + 15 + 15, (-5), (-5), "SCREEN SIZE");

								bar(c + 167 + 40, 31 + 15 + 15 + 15, ref ud.screen_size, -4, (char)((x == 3) ? 1 : 0), (-5), (-5));

								menutext(c, 31 + 15 + 15 + 15 + 15, (-6), (-6), "BRIGHTNESS");
								bar(c + 167 + 40, 31 + 15 + 15 + 15 + 15, ref ud.brightness, 8, (char)((x == 4) ? 1 : 0), (-6), (-6));
								if (x == 4)
								{
									Engine.setbrightness(ud.brightness >> 2, ps[myconnectindex].palette);
								}
				// jmarshall - options mouse
				/*
								if (ControllerType == controltype.controltype_keyboardandmouse)
								{
									short sense;
									sense = (short)(CONTROL_GetMouseSensitivity() >> 10);

									menutext(c, 31 + 15 + 15 + 15 + 15 + 15, (-7), (-7), "MOUSE SENSITIVITY");
									bar(c + 167 + 40, 31 + 15 + 15 + 15 + 15 + 15, sense, 4, x == 5, (-7), (-7));
									CONTROL_SetMouseSensitivity(sense << 10);
									menutext(c, 31 + 15 + 15 + 15 + 15 + 15 + 15, (-7), (-7), "MOUSE AIMING FLIP");

									if (ud.mouseflip)
									{
										menutext(c + 160 + 40, 31 + 15 + 15 + 15 + 15 + 15 + 15, (-7), (-7), "ON");
									}
									else
									{
										menutext(c + 160 + 40, 31 + 15 + 15 + 15 + 15 + 15 + 15, (-7), (-7), "OFF");
									}

								}
								else
								{
									short sense;
									sense = (short)(CONTROL_GetMouseSensitivity() >> 10);

									menutext(c, 31 + 15 + 15 + 15 + 15 + 15, (-7), 1, "MOUSE SENSITIVITY");
									bar(c + 167 + 40, 31 + 15 + 15 + 15 + 15 + 15, sense, 4, x == 99, (-7), 1);
									menutext(c, 31 + 15 + 15 + 15 + 15 + 15 + 15, (-7), 1, "MOUSE AIMING FLIP");

									if (ud.mouseflip)
									{
										menutext(c + 160 + 40, 31 + 15 + 15 + 15 + 15 + 15 + 15, (-7), 1, "ON");
									}
									else
									{
										menutext(c + 160 + 40, 31 + 15 + 15 + 15 + 15 + 15 + 15, (-7), 1, "OFF");
									}
								}
				*/
				// jmarshall end
				menutext(c, 31 + 15 + 15 + 15 + 15 + 15 + 15 + 15, (-8), (-8), "SOUNDS");
#if !AUSTRALIA
				menutext(c, 31 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 15, (-9), (-9), "PARENTAL LOCK");
#else
				menutext(c, 31 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 15, (-9), 1, "PARENTAL LOCK");
#endif
				if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0 && ud.m_recstat != 1)
				{
					menutext(c, 31 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 15, (-10), 1, "RECORD");
					menutext(c + 160 + 40, 31 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 15, (-10), 1, "OFF");
				}
				else
				{
					menutext(c, 31 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 15, (-10), (-10), "RECORD");

					if (ud.m_recstat == 1)
					{
						menutext(c + 160 + 40, 31 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 15, (-10), (-10), "ON");
					}
					else
					{
						menutext(c + 160 + 40, 31 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 15 + 15, (-10), (-10), "OFF");
					}
				}

				break;

			case 700:
				c = (short)((320 >> 1) - 120);
				Engine.rotatesprite(320 << 15, 19 << 16, 65536, 0, DefineConstants.MENUBAR, 16, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				menutext(320 >> 1, 24, 0, 0, "SOUNDS");
				if (probey == 2 || probey == 3)
					onbar = 1;
				else
					onbar = 0;

				x = (short)probe(c, 50, 16, 7);
				switch (x)
				{
					case -1:
						if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
						{
							ps[myconnectindex].gm &= ~DefineConstants.MODE_MENU;
							if (ud.multimode < 2 && ud.recstat != 2)
							{
								ready2send = (char)1;
								totalclock = ototalclock;
							}
						}

						else
						{
							cmenu(200);
						}
						break;
					case 0:
						//if (FXDevice != soundcardnames.NumSoundCards)
						{
							SoundToggle = 1 - SoundToggle;
							if (SoundToggle == 0)
							{
								FX_StopAllSounds();
								clearsoundlocks();
							}
							onbar = 0;
						}
						break;
					case 1:
						// jmarshall - sound
						/*
												if (eightytwofifty == 0 || numplayers < 2)
												{
													if (MusicDevice != soundcardnames.NumSoundCards)
													{
														MusicToggle = 1 - MusicToggle;
														if (MusicToggle == 0)
														{
															MUSIC_Pause();
														}
														else
														{
															if (ud.recstat != 2 && (ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
															{
																playmusic(ref music_fn[0][music_select][0]);
															}
															else
															{
																playmusic(ref env_music_fn[0][0]);
															}

															MUSIC_Continue();
														}
													}
												}
						*/
						onbar = 0;

						break;
					// jmarshall - sound
					/*

										case 4:
											if (SoundToggle && (FXDevice != soundcardnames.NumSoundCards))
											{
												VoiceToggle = 1 - VoiceToggle;
											}
											onbar = 0;
											break;
										case 5:
											if (SoundToggle && (FXDevice != soundcardnames.NumSoundCards))
											{
												AmbienceToggle = 1 - AmbienceToggle;
											}
											onbar = 0;
											break;
										case 6:
											if (SoundToggle && (FXDevice != soundcardnames.NumSoundCards))
											{
												ReverseStereo = 1 - ReverseStereo;
												FX_SetReverseStereo(ReverseStereo);
											}
											onbar = 0;
											break;
					*/
					default:
						onbar = 1;
						break;
				}
				// jmarshall - sound
				/*

								if (SoundToggle && FXDevice != soundcardnames.NumSoundCards)
								{
									menutext(c + 160 + 40, 50, 0, (FXDevice == soundcardnames.NumSoundCards), "ON");
								}
								else
								{
									menutext(c + 160 + 40, 50, 0, (FXDevice == soundcardnames.NumSoundCards), "OFF");
								}

								if (MusicToggle && (MusicDevice != soundcardnames.NumSoundCards) && (!eightytwofifty || numplayers < 2))
								{
									menutext(c + 160 + 40, 50 + 16, 0, (MusicDevice == soundcardnames.NumSoundCards), "ON");
								}
								else
								{
									menutext(c + 160 + 40, 50 + 16, 0, (MusicDevice == soundcardnames.NumSoundCards), "OFF");
								}

								menutext(c, 50, (-2), (FXDevice == soundcardnames.NumSoundCards), "SOUND");
								menutext(c, 50 + 16 + 16, (-4), 0, "SOUND VOLUME");
								{
									l = FXVolume;
									FXVolume >>= 2;
									bar(c + 167 + 40, 50 + 16 + 16, (short)&FXVolume, 4, (FXDevice != soundcardnames.NumSoundCards) && x == 2, (-4), SoundToggle == 0 || (FXDevice == soundcardnames.NumSoundCards));
									if (l != FXVolume)
									{
										FXVolume <<= 2;
									}
									if (l != FXVolume)
									{
										FX_SetVolume((short)FXVolume);
									}
								}
								menutext(c, 50 + 16, (-3), (MusicDevice == soundcardnames.NumSoundCards), "MUSIC");
								menutext(c, 50 + 16 + 16 + 16, (-5), (MusicDevice == soundcardnames.NumSoundCards) || (numplayers > 1 && eightytwofifty) || MusicToggle == 0, "MUSIC VOLUME");
								{
									l = MusicVolume;
									MusicVolume >>= 2;
									bar(c + 167 + 40, 50 + 16 + 16 + 16, (short)&MusicVolume, 4, (eightytwofifty == 0 || numplayers < 2) && (MusicDevice != soundcardnames.NumSoundCards) && x == 3, (-5), (numplayers > 1 && eightytwofifty) || MusicToggle == 0 || (MusicDevice == soundcardnames.NumSoundCards));
									MusicVolume <<= 2;
									if (l != MusicVolume)
									{
										Music_SetVolume((short)MusicVolume);
									}

								}
								menutext(c, 50 + 16 + 16 + 16 + 16, (-6), 0, "DUKE TALK");
								menutext(c, 50 + 16 + 16 + 16 + 16 + 16, (-7), 0, "AMBIENCE");

								menutext(c, 50 + 16 + 16 + 16 + 16 + 16 + 16, (-8), 0, "FLIP STEREO");

								if (VoiceToggle != 0)
								{
									menutext(c + 160 + 40, 50 + 16 + 16 + 16 + 16, 0, 0, "ON");
								}
								else
								{
									menutext(c + 160 + 40, 50 + 16 + 16 + 16 + 16, 0, 0, "OFF");
								}

								if (AmbienceToggle != 0)
								{
									menutext(c + 160 + 40, 50 + 16 + 16 + 16 + 16 + 16, 0, 0, "ON");
								}
								else
								{
									menutext(c + 160 + 40, 50 + 16 + 16 + 16 + 16 + 16, 0, 0, "OFF");
								}

								if (ReverseStereo != 0)
								{
									menutext(c + 160 + 40, 50 + 16 + 16 + 16 + 16 + 16 + 16, 0, 0, "ON");
								}
								else
								{
									menutext(c + 160 + 40, 50 + 16 + 16 + 16 + 16 + 16 + 16, 0, 0, "OFF");
								}
				*/

				break;

			case 350:
				cmenu(351);
				break;

			case 360:
			case 361:
			case 362:
			case 363:
			case 364:
			case 365:
			case 366:
			case 367:
			case 368:
			case 369:
			case 351:
			case 300:
				string _loadstr2 = "";
				c = (short)(320 >> 1);
				Engine.rotatesprite(c << 16, 200 << 15, 65536, 0, DefineConstants.MENUSCREEN, 16, 0, 10 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				Engine.rotatesprite(c << 16, 19 << 16, 65536, 0, DefineConstants.MENUBAR, 16, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

				if (current_menu == 300)
				{
					menutext(c, 24, 0, 0, "LOAD GAME");
				}
				else
				{
					menutext(c, 24, 0, 0, "SAVE GAME");
				}

				if (current_menu >= 360 && current_menu <= 369)
				{
					_loadstr2 = string.Format("PLAYERS: {0}", ud.multimode);
					gametext(160, 158, _loadstr2, 0, (short)(2 + 8 + 16));
					_loadstr2 = string.Format("EPISODE: {0} / LEVEL: {1} / SKILL: {2}", 1 + ud.volume_number, 1 + ud.level_number, ud.player_skill);
					gametext(160, 170, _loadstr2, 0, (short)(2 + 8 + 16));

					x = (short)(ud.savegame[current_menu - 360].Length > 0 ? 1 : 0);

					if (x == -1)
					{
						//        readsavenames();
						ps[myconnectindex].gm = DefineConstants.MODE_GAME;
						if (ud.multimode < 2 && ud.recstat != 2)
						{
							ready2send = (char)1;
							totalclock = ototalclock;
						}
						goto DISPLAYNAMES;
					}

					if (x == 1)
					{
						if (ud.savegame[current_menu - 360][0] == 0)
						{
							KB_FlushKeyboardQueue();
							cmenu(351);
						}
						else
						{
							if (ud.multimode > 1)
							{
								saveplayer((sbyte)(-1 - (current_menu - 360)));
							}
							else
							{
								saveplayer((sbyte)(current_menu - 360));
							}
							lastsavedpos = (sbyte)(current_menu - 360);
							ps[myconnectindex].gm = DefineConstants.MODE_GAME;

							if (ud.multimode < 2 && ud.recstat != 2)
							{
								ready2send = (char)1;
								totalclock = ototalclock;
							}
							{
								KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
							};
							sound(DefineConstants.EXITMENUSOUND);
						}
					}

					Engine.rotatesprite(101 << 16, 97 << 16, 65536, 512, DefineConstants.MAXTILES - 1, -32, 0, 2 + 4 + 8 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
					{
						string _mapName = boardfilename;
						if (boardfilename.Length == 0)
						{
							_mapName = level_names[(ud.volume_number * 11) + ud.level_number];
						}
						ud.savegame[current_menu - 360] = _mapName;
					}
					dispnames();
					Engine.rotatesprite(c + 67 + ud.savegame[current_menu - 360].Length * 4 << 16, (50 + 12 * probey) << 16, 32768 - 10240, 0, DefineConstants.SPINNINGNUKEICON + (((totalclock) >> 3) % 7), 0, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
					break;
				}

				last_threehundred = probey;

				x = (short)probe(c + 68, 54, 12, 10);

				if (current_menu == 300)
				{
					if (ud.savegame[probey].Length > 0)
					{
						if (lastprobey != probey)
						{
							loadpheader(probey, ref volnum, ref levnum, ref plrskl, ref numplr);
							lastprobey = probey;
						}

						Engine.rotatesprite(101 << 16, 97 << 16, 65536, 512, DefineConstants.MAXTILES - 3, -32, 0, 4 + 10 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
						_loadstr2 = string.Format("PLAYERS: {0}", numplr);
						gametext(160, 158, _loadstr2, 0, (short)(2 + 8 + 16));
						_loadstr2 = string.Format("EPISODE: {0} / LEVEL: {1} / SKILL: {2}", 1 + volnum, 1 + levnum, plrskl);
						gametext(160, 170, _loadstr2, 0, (short)(2 + 8 + 16));
					}
					else
					{
						menutext(69, 70, 0, 0, "EMPTY");
					}
				}
				else
				{
					if (ud.savegame[probey].Length > 0)
					{
						if (lastprobey != probey)
						{
							loadpheader(probey, ref volnum, ref levnum, ref plrskl, ref numplr);
						}
						lastprobey = probey;
						Engine.rotatesprite(101 << 16, 97 << 16, 65536, 512, DefineConstants.MAXTILES - 3, -32, 0, 4 + 10 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
					}
					else
					{
						menutext(69, 70, 0, 0, "EMPTY");
					}
					_loadstr2 = string.Format("PLAYERS: {0}", ud.multimode);
					gametext(160, 158, _loadstr2, 0, (short)(2 + 8 + 16));
					_loadstr2 = string.Format("EPISODE: {0} / LEVEL: {1} / SKILL: {2}", 1 + ud.volume_number, 1 + ud.level_number, ud.player_skill);
					gametext(160, 170, _loadstr2, 0, (short)(2 + 8 + 16));
				}

				switch (x)
				{
					case -1:
						if (current_menu == 300)
						{
							if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != DefineConstants.MODE_GAME)
							{
								cmenu(0);
								break;
							}
							else
							{
								ps[myconnectindex].gm &= ~DefineConstants.MODE_MENU;
							}
						}
						else
						{
							ps[myconnectindex].gm = DefineConstants.MODE_GAME;
						}

						if (ud.multimode < 2 && ud.recstat != 2)
						{
							ready2send = (char)1;
							totalclock = ototalclock;
						}

						break;
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
						if (current_menu == 300)
						{
							if (ud.savegame[x].Length > 0)
							{
								current_menu = (1000 + x);
							}
						}
						else
						{
							if (ud.savegame[x].Length > 0)
							{
								current_menu = 2000 + x;
							}
							else
							{
								KB_FlushKeyboardQueue();
								current_menu = (360 + x);
								ud.savegame[x] = "";
								//inputloc = 0;
							}
						}
						break;
				}

				DISPLAYNAMES:
				dispnames();

				break;

#if DEMO
			//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
			case 400:
			case 401:
			case 402:
			case 403:

				c = (short)(320 >> 1);

				if ((KB_KeyDown[(DefineConstants.sc_LeftArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_4)] != false) || (KB_KeyDown[(DefineConstants.sc_UpArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_PgUp)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_8)] != false))
				{
					{
						KB_KeyDown[(DefineConstants.sc_LeftArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_4)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_UpArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_PgUp)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_8)] = (!(1 == 1));
					};

					sound(DefineConstants.KICK_HIT);
					current_menu--;
					if (current_menu < 400)
					{
						current_menu = 403;
					}
				}
				else if ((KB_KeyDown[(DefineConstants.sc_PgDn)] != false) || (KB_KeyDown[(DefineConstants.sc_Return)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_Enter)] != false) || (KB_KeyDown[(DefineConstants.sc_RightArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_DownArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_2)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_9)] != false) || (KB_KeyDown[(DefineConstants.sc_Space)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_6)] != false))
				{
					{
						KB_KeyDown[(DefineConstants.sc_PgDn)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_Return)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_RightArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_Enter)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_6)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_9)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_2)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_DownArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_Space)] = (!(1 == 1));
					};
					sound(DefineConstants.KICK_HIT);
					current_menu++;
					if (current_menu > 403)
					{
						current_menu = 400;
					}
				}

				if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false))
				{
					if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
					{
						cmenu(50);
					}
					else
					{
						cmenu(0);
					}
					return;
				}

				flushperms();
				Engine.rotatesprite(0, 0, 65536, 0, DefineConstants.ORDERING + current_menu - 400, 0, 0, 10 + 16 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

#else
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
			case 400:
			case 401:

				c = (short)(320 >> 1);

				if ((KB_KeyDown[(DefineConstants.sc_LeftArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_4)] != false) || (KB_KeyDown[(DefineConstants.sc_UpArrow)] != false || (KB_KeyDown[(DefineConstants.sc_PgUp)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_8)] != false)))
				{
					{
						KB_KeyDown[(DefineConstants.sc_LeftArrow)] = (!(1 == 1));
				};
				{
						KB_KeyDown[(DefineConstants.sc_kpad_4)] = (!(1 == 1));
				};
				{
						KB_KeyDown[(DefineConstants.sc_UpArrow)] = (!(1 == 1));
				};
				{
						KB_KeyDown[(DefineConstants.sc_PgUp)] = (!(1 == 1));
				};
				{
						KB_KeyDown[(DefineConstants.sc_kpad_8)] = (!(1 == 1));
				};

					sound(DefineConstants.KICK_HIT);
					current_menu--;
					if (current_menu < 400)
					{
						current_menu = 401;
					}
				}
				else if ((KB_KeyDown[(DefineConstants.sc_PgDn)] != false) || (KB_KeyDown[(DefineConstants.sc_Return)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_Enter)] != false) || (KB_KeyDown[(DefineConstants.sc_RightArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_DownArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_2)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_9)] != false) || (KB_KeyDown[(DefineConstants.sc_Space)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_6)] != false))
				{
					{
						KB_KeyDown[(DefineConstants.sc_PgDn)] = (!(1 == 1));
				};
				{
						KB_KeyDown[(DefineConstants.sc_Return)] = (!(1 == 1));
				};
				{
						KB_KeyDown[(DefineConstants.sc_RightArrow)] = (!(1 == 1));
				};
				{
						KB_KeyDown[(DefineConstants.sc_kpad_Enter)] = (!(1 == 1));
				};
				{
						KB_KeyDown[(DefineConstants.sc_kpad_6)] = (!(1 == 1));
				};
				{
						KB_KeyDown[(DefineConstants.sc_kpad_9)] = (!(1 == 1));
				};
				{
						KB_KeyDown[(DefineConstants.sc_kpad_2)] = (!(1 == 1));
				};
				{
						KB_KeyDown[(DefineConstants.sc_DownArrow)] = (!(1 == 1));
				};
				{
						KB_KeyDown[(DefineConstants.sc_Space)] = (!(1 == 1));
				};
					sound(DefineConstants.KICK_HIT);
					current_menu++;
					if (current_menu > 401)
					{
						current_menu = 400;
					}
				}

				if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false))
				{
					if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
					{
						cmenu(50);
					}
					else
					{
						cmenu(0);
					}
					return;
				}

				flushperms();
				switch (current_menu)
				{
					case 400:
						Engine.rotatesprite(0,0,65536,0,DefineConstants.TEXTSTORY,0,0,10 + 16 + 64, 0,0,Engine.xdim - 1,Engine.ydim - 1);
						break;
					case 401:
						Engine.rotatesprite(0,0,65536,0,DefineConstants.F1HELP,0,0,10 + 16 + 64, 0,0,Engine.xdim - 1,Engine.ydim - 1);
						break;
				}

#endif

				break;

			case 500:
				c = (short)(320 >> 1);

				gametext(c, 90, "Are you sure you want to quit?", 0, (short)(2 + 8 + 16));
				gametext(c, 99, "(Y/N)", 0, (short)(2 + 8 + 16));

				if ((KB_KeyDown[(DefineConstants.sc_Space)] != false) || (KB_KeyDown[(DefineConstants.sc_Return)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_Enter)] != false) || (KB_KeyDown[(DefineConstants.sc_Y)] != false) || (buttonstat & 1) != 0)
				{
					KB_FlushKeyboardQueue();

					if (gamequit == 0 && (numplayers > 1))
					{
						if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
						{
							gamequit = 1;
							quittimer = totalclock + 120;
						}
						else
						{
							//sendlogoff();
							gameexit(" ");
						}
					}
					else if (numplayers < 2)
					{
						gameexit(" ");
					}

					if ((totalclock > quittimer) && (gamequit == 1))
					{
						gameexit("Timed out.");
					}
				}

				x = (short)probe(186, 124, 0, 0);
				if (x == -1 || (KB_KeyDown[(DefineConstants.sc_N)] != false) || (buttonstat & 2) != 0)
				{
					{
						KB_KeyDown[(DefineConstants.sc_N)] = (!(1 == 1));
					};
					quittimer = 0;
					if ((ps[myconnectindex].gm & DefineConstants.MODE_DEMO) != 0)
					{
						ps[myconnectindex].gm = DefineConstants.MODE_DEMO;
					}
					else
					{
						ps[myconnectindex].gm &= ~DefineConstants.MODE_MENU;
						if (ud.multimode < 2 && ud.recstat != 2)
						{
							ready2send = (char)1;
							totalclock = ototalclock;
						}
					}
				}

				break;
			case 501:
				c = (short)(320 >> 1);
				gametext(c, 90, "Quit to Title?", 0, (short)(2 + 8 + 16));
				gametext(c, 99, "(Y/N)", 0, (short)(2 + 8 + 16));

				if ((KB_KeyDown[(DefineConstants.sc_Space)] != false) || (KB_KeyDown[(DefineConstants.sc_Return)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_Enter)] != false) || (KB_KeyDown[(DefineConstants.sc_Y)] != false) || (buttonstat & 1) != 0)
				{
					KB_FlushKeyboardQueue();
					ps[myconnectindex].gm = DefineConstants.MODE_DEMO;
					if (ud.recstat == 1)
					{
						closedemowrite();
					}
					cmenu(0);
				}

				x = (short)probe(186, 124, 0, 0);

				if (x == -1 || (KB_KeyDown[(DefineConstants.sc_N)] != false) || (buttonstat & 2) != 0)
				{
					ps[myconnectindex].gm &= ~DefineConstants.MODE_MENU;
					if (ud.multimode < 2 && ud.recstat != 2)
					{
						ready2send = (char)1;
						totalclock = ototalclock;
					}
				}

				break;

			case 601:
				// jmarshall multiplayer
				/* 
								displayfragbar();
								Engine.rotatesprite(160 << 16, 29 << 16, 65536, 0, DefineConstants.MENUBAR, 16, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
								menutext(320 >> 1, 34, 0, 0, ud.user_name[myconnectindex][0]);

								sprintf(tempbuf, "Waiting for master");
								gametext(160, 50, ref tempbuf, 0, (short)(2 + 8 + 16));
								gametext(160, 59, "to select level", 0, (short)(2 + 8 + 16));

								if ((KB_KeyDown[(DefineConstants.sc_Escape)] != 0))
								{
									{
										KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
									};
									sound(DefineConstants.EXITMENUSOUND);
									cmenu(0);
								}
				*/
				break;

			case 602:
				if (menunamecnt == 0)
				{
					//        getfilenames("SUBD");
					getfilenames("*.MAP");
					sortfilenames();
					if (menunamecnt == 0)
					{
						cmenu(600);
					}
				}
				goto case 603;
			case 603:
				c = (short)((320 >> 1) - 120);
				//displayfragbar();
				Engine.rotatesprite(320 >> 1 << 16, 19 << 16, 65536, 0, DefineConstants.MENUBAR, 16, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				menutext(320 >> 1, 24, 0, 0, "USER MAPS");
				for (x = 0; x < menunamecnt; x++)
				{
					if (x == fileselect)
					{
						minitext(15 + (x / 15) * 54, 32 + (x % 15) * 8, menuname[x], 0, 26);
					}
					else
					{
						minitext(15 + (x / 15) * 54, 32 + (x % 15) * 8, menuname[x], 16, 26);
					}
				}

				fileselect = (char)probey;
				if ((KB_KeyDown[(DefineConstants.sc_LeftArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_4)] != false) || ((buttonstat & 1) != 0 && minfo.dyaw < -256))
				{
					{
						KB_KeyDown[(DefineConstants.sc_LeftArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_4)] = (!(1 == 1));
					};
					probey -= 15;
					if (probey < 0)
					{
						probey += 15;
					}
					else
					{
						sound(DefineConstants.KICK_HIT);
					}
				}
				if ((KB_KeyDown[(DefineConstants.sc_RightArrow)] != false) || (KB_KeyDown[(DefineConstants.sc_kpad_6)] != false) || ((buttonstat & 1) != 0 && minfo.dyaw > 256))
				{
					{
						KB_KeyDown[(DefineConstants.sc_RightArrow)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_kpad_6)] = (!(1 == 1));
					};
					probey += 15;
					if (probey >= menunamecnt)
					{
						probey -= 15;
					}
					else
					{
						sound(DefineConstants.KICK_HIT);
					}
				}

				onbar = 0;
				x = (short)probe(0, 0, 0, menunamecnt);

				if (x == -1)
				{
					cmenu(600);
				}
				else if (x >= 0)
				{
					tempbuf[0] = 8;
					tempbuf[1] = (byte)(ud.m_level_number = 6);
					tempbuf[2] = (byte)(ud.m_volume_number = 0);
					tempbuf[3] = (byte)(ud.m_player_skill + 1);

					if (ud.player_skill == 3)
					{
						ud.m_respawn_monsters = 1;
					}
					else
					{
						ud.m_respawn_monsters = 0;
					}

					if (ud.m_coop == 0)
					{
						ud.m_respawn_items = 1;
					}
					else
					{
						ud.m_respawn_items = 0;
					}

					ud.m_respawn_inventory = 1;

					tempbuf[4] = (byte)ud.m_monsters_off;
					tempbuf[5] = (byte)ud.m_respawn_monsters;
					tempbuf[6] = (byte)ud.m_respawn_items;
					tempbuf[7] = (byte)ud.m_respawn_inventory;
					tempbuf[8] = (byte)ud.m_coop;
					tempbuf[9] = (byte)ud.m_marker;
					// jmarshall - user maps
					/*
										x = strlen(menuname[probey]);

										copybufbyte(menuname[probey], tempbuf + 10, x);
										copybufbyte(menuname[probey], boardfilename, x + 1);

										for (c = connecthead; c >= 0; c = connectpoint2[c])
										{
											if (c != myconnectindex)
											{
												sendpacket(c, tempbuf, x + 10);
											}
										}

										newgame(ud.m_volume_number, ud.m_level_number, ud.m_player_skill + 1);
										enterlevel(DefineConstants.MODE_GAME);
					*/
					// jmarshall end
				}
				break;

			case 600:
				c = (short)((320 >> 1) - 120);
				if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != DefineConstants.MODE_GAME)
				{
					// displayfragbar(); // jmarshall fragbar.
				}
				Engine.rotatesprite(160 << 16, 26 << 16, 65536, 0, DefineConstants.MENUBAR, 16, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				menutext(160, 31, 0, 0, ud.user_name[myconnectindex]);

				x = (short)probe(c, 57 - 8, 16, 8);

				switch (x)
				{
					case -1:
						ud.m_recstat = 0;
						if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
						{
							cmenu(50);
						}
						else
						{
							cmenu(0);
						}
						break;
					case 0:
						ud.m_coop++;
						if (ud.m_coop == 3)
						{
							ud.m_coop = 0;
						}
						break;
					case 1:
#if !VOLUMEONE
						ud.m_volume_number++;
#if !DEMO
						if (ud.m_volume_number > 3)
						{
							ud.m_volume_number = 0;
						}
#else
						if (ud.m_volume_number > 2)
						{
							ud.m_volume_number = 0;
						}
#endif
						if (ud.m_volume_number == 0 && ud.m_level_number > 6)
						{
							ud.m_level_number = 0;
						}
						if (ud.m_level_number > 10)
						{
							ud.m_level_number = 0;
						}
#endif
						break;
					case 2:
#if !ONELEVELDEMO
						ud.m_level_number++;
#if !VOLUMEONE
						if (ud.m_volume_number == 0 && ud.m_level_number > 6)
						{
							ud.m_level_number = 0;
						}
#else
						if (ud.m_volume_number == 0 && ud.m_level_number > 5)
						{
							ud.m_level_number = 0;
						}
#endif
						if (ud.m_level_number > 10)
						{
							ud.m_level_number = 0;
						}
#endif
						break;
					case 3:
						if (ud.m_monsters_off == 1 && ud.m_player_skill > 0)
						{
							ud.m_monsters_off = 0;
						}

						if (ud.m_monsters_off == 0)
						{
							ud.m_player_skill++;
							if (ud.m_player_skill > 3)
							{
								ud.m_player_skill = 0;
								ud.m_monsters_off = 1;
							}
						}
						else
						{
							ud.m_monsters_off = 0;
						}

						break;

					case 4:
						if (ud.m_coop == 0)
						{
							if (ud.m_marker != 0)
								ud.m_marker = 0;
							else
								ud.m_marker = 1;
						}
						break;

					case 5:
						if (ud.m_coop == 1)
						{
							if (ud.m_ffire != 0)
								ud.m_ffire = 0;
							else
								ud.m_ffire = 1;
						}
						break;

					case 6:
#if !DEMO
						if (boardfilename[0] == 0)
						{
							break;
						}

						tempbuf[0] = 5;
						tempbuf[1] = 7;
						ud.m_level_number = 7;
						tempbuf[2] = 0;
						ud.m_volume_number = 0;
						tempbuf[3] = (byte)(ud.m_player_skill + 1);

						ud.level_number = ud.m_level_number;
						ud.volume_number = ud.m_volume_number;

						if (ud.m_player_skill == 3)
						{
							ud.m_respawn_monsters = 1;
						}
						else
						{
							ud.m_respawn_monsters = 0;
						}

						if (ud.m_coop == 0)
						{
							ud.m_respawn_items = 1;
						}
						else
						{
							ud.m_respawn_items = 0;
						}

						ud.m_respawn_inventory = 1;

						tempbuf[4] = (byte)ud.m_monsters_off;
						tempbuf[5] = (byte)ud.m_respawn_monsters;
						tempbuf[6] = (byte)ud.m_respawn_items;
						tempbuf[7] = (byte)ud.m_respawn_inventory;
						tempbuf[8] = (byte)ud.m_coop;
						tempbuf[9] = (byte)ud.m_marker;
						tempbuf[10] = (byte)ud.m_ffire;

						for (c = connecthead;c >= 0;c = connectpoint2[c])
						{
							resetweapons(c);
							resetinventory(c);

							if (c != myconnectindex)
							{
								//sendpacket(c,tempbuf,11);
							}
						}

						newgame((char)ud.m_volume_number, (char)ud.m_level_number, (char)(ud.m_player_skill + 1));
						enterlevel((char)DefineConstants.MODE_GAME);

						return;
#endif
					//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
					case 7:

						tempbuf[0] = 5;
						tempbuf[1] = (byte)ud.m_level_number;
						tempbuf[2] = (byte)ud.m_volume_number;
						tempbuf[3] = (byte)(ud.m_player_skill + 1);

						if (ud.m_player_skill == 3)
						{
							ud.m_respawn_monsters = 1;
						}
						else
						{
							ud.m_respawn_monsters = 0;
						}

						if (ud.m_coop == 0)
						{
							ud.m_respawn_items = 1;
						}
						else
						{
							ud.m_respawn_items = 0;
						}

						ud.m_respawn_inventory = 1;

						tempbuf[4] = (byte)ud.m_monsters_off;
						tempbuf[5] = (byte)ud.m_respawn_monsters;
						tempbuf[6] = (byte)ud.m_respawn_items;
						tempbuf[7] = (byte)ud.m_respawn_inventory;
						tempbuf[8] = (byte)ud.m_coop;
						tempbuf[9] = (byte)ud.m_marker;
						tempbuf[10] = (byte)ud.m_ffire;

						for (c = connecthead; c >= 0; c = connectpoint2[c])
						{
							resetweapons(c);
							resetinventory(c);

							if (c != myconnectindex)
							{
								//sendpacket(c, tempbuf, 11);
							}
						}

						newgame((char)ud.m_volume_number, (char)ud.m_level_number, (char)(ud.m_player_skill + 1));
						enterlevel((char)DefineConstants.MODE_GAME);

						return;

				}

				c += 40;

				if (ud.m_coop == 1)
				{
					gametext(c + 70, 57 - 7 - 9, "COOPERATIVE PLAY", 0, (short)(2 + 8 + 16));
				}
				else if (ud.m_coop == 2)
				{
					gametext(c + 70, 57 - 7 - 9, "DUKEMATCH (NO SPAWN)", 0, (short)(2 + 8 + 16));
				}
				else
				{
					gametext(c + 70, 57 - 7 - 9, "DUKEMATCH (SPAWN)", 0, (short)(2 + 8 + 16));
				}

#if VOLUMEONE
				gametext(c + 70, 57 + 16 - 7 - 9, ref volume_names[ud.m_volume_number], 0, (short)(2 + 8 + 16));
#else
				gametext(c + 70, 57 + 16 - 7 - 9, volume_names[ud.m_volume_number], 0, (short)(2 + 8 + 16));
#endif

				gametext(c + 70, 57 + 16 + 16 - 7 - 9, level_names[11 * ud.m_volume_number + ud.m_level_number], 0, (short)(2 + 8 + 16));

				if (ud.m_monsters_off == 0 || ud.m_player_skill > 0)
				{
					gametext(c + 70, 57 + 16 + 16 + 16 - 7 - 9, skill_names[ud.m_player_skill], 0, (short)(2 + 8 + 16));
				}
				else
				{
					gametext(c + 70, 57 + 16 + 16 + 16 - 7 - 9, "NONE", 0, (short)(2 + 8 + 16));
				}

				if (ud.m_coop == 0)
				{
					if (ud.m_marker != 0)
					{
						gametext(c + 70, 57 + 16 + 16 + 16 + 16 - 7 - 9, "ON", 0, (short)(2 + 8 + 16));
					}
					else
					{
						gametext(c + 70, 57 + 16 + 16 + 16 + 16 - 7 - 9, "OFF", 0, (short)(2 + 8 + 16));
					}
				}

				if (ud.m_coop == 1)
				{
					if (ud.m_ffire != 0)
					{
						gametext(c + 70, 57 + 16 + 16 + 16 + 16 + 16 - 7 - 9, "ON", 0, (short)(2 + 8 + 16));
					}
					else
					{
						gametext(c + 70, 57 + 16 + 16 + 16 + 16 + 16 - 7 - 9, "OFF", 0, (short)(2 + 8 + 16));
					}
				}

				c -= 44;

				menutext(c, 57 - 9, (-2), (-2), "GAME TYPE");

				string s = "EPISODE " + ud.m_volume_number + 1;
#if VOLUMEONE
				sprintf(tempbuf,"EPISODE %ld",ud.m_volume_number + 1);
				menutext(c, 57 + 16 - 9, (-3), 1, tempbuf);
#else
				
				menutext(c, 57 + 16 - 9, (-3), (-3), s);
#endif

#if !ONELEVELDEMO
				s = "LEVEL " + ud.m_level_number + 1;
				//sprintf(tempbuf, "LEVEL %ld", ud.m_level_number + 1);
				menutext(c, 57 + 16 + 16 - 9, (-4), (-4), s);
#else
				sprintf(tempbuf,"LEVEL %ld",ud.m_level_number + 1);
				menutext(c, 57 + 16 + 16 - 9, (-4), 1, tempbuf);
#endif
				menutext(c, 57 + 16 + 16 + 16 - 9, (-5), (-5), "MONSTERS");

				if (ud.m_coop == 0)
				{
					menutext(c, 57 + 16 + 16 + 16 + 16 - 9, (-6), (-6), "MARKERS");
				}
				else
				{
					menutext(c, 57 + 16 + 16 + 16 + 16 - 9, (-6), 1, "MARKERS");
				}

				if (ud.m_coop == 1)
				{
					menutext(c, 57 + 16 + 16 + 16 + 16 + 16 - 9, (-6), (-6), "FR. FIRE");
				}
				else
				{
					menutext(c, 57 + 16 + 16 + 16 + 16 + 16 - 9, (-6), 1, "FR. FIRE");
				}

#if !DEMO
				short __rr = 0;
				if (boardfilename.Length > 0)
					__rr = 1;
				menutext(c, 57 + 16 + 16 + 16 + 16 + 16 + 16 - 9, (-7), __rr, "USER MAP");
				if (boardfilename[0] != 0)
				{
					gametext(c + 70 + 44, 57 + 16 + 16 + 16 + 16 + 16, boardfilename, 0, (short)(2 + 8 + 16));
				}
#else
				menutext(c, 57 + 16 + 16 + 16 + 16 + 16 + 16 - 9, (-7), 1, "USER MAP");
#endif

				menutext(c, 57 + 16 + 16 + 16 + 16 + 16 + 16 + 16 - 9, (-8), (-8), "START GAME");

				break;
		}

		if ((ps[myconnectindex].gm & DefineConstants.MODE_MENU) != DefineConstants.MODE_MENU)
		{
			vscrn();
			cameraclock = totalclock;
			cameradist = 65536;
		}

		KB_FlushKeyboardQueue();
	}

	public static void palto(int r, int g, int b, int e)
	{
		// jmarshall - palette
		int i;
		byte[] temparray = new byte[768];

        for (i = 0; i < 768; i += 3)
        {
			int rshift = ((r - ps[myconnectindex].palette[i + 0]) * e) >> 8;
			int gshift = ((g - ps[myconnectindex].palette[i + 1]) * e) >> 8;
			int bshift = ((b - ps[myconnectindex].palette[i + 2]) * e) >> 8;

			int _r = (((int)ps[myconnectindex].palette[i + 0]) + rshift);
            int _g = (((int)ps[myconnectindex].palette[i + 1]) + gshift);
            int _b = (((int)ps[myconnectindex].palette[i + 2]) + bshift);

			temparray[i + 0] = (byte)_r;
			temparray[i + 1] = (byte)_g;
			temparray[i + 2] = (byte)_b;
		}

		Engine.setbrightness(ud.brightness >> 2, temparray);		
	}


	public static void drawoverheadmap(int cposx, int cposy, int czoom, short cang)
	{
		// jmarshall - auto map
		/*
				int i;
				int j;
				int k;
				int l;
				int x1;
				int y1;
				int x2;
				int y2;
				int x3;
				int y3;
				int x4;
				int y4;
				int ox;
				int oy;
				int xoff;
				int yoff;
				int dax;
				int day;
				int cosang;
				int sinang;
				int xspan;
				int yspan;
				int sprx;
				int spry;
				int xrepeat;
				int yrepeat;
				int z1;
				int z2;
				int startwall;
				int endwall;
				int tilenum;
				int daang;
				int xvect;
				int yvect;
				int xvect2;
				int yvect2;
				short p;
				char col;
				//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
				walltype* wal = new walltype();
				walltype wal2;
				spritetype spr;

				xvect = Engine.table.sintable[(-cang) & 2047] * czoom;
				yvect = Engine.table.sintable[(1536 - cang) & 2047] * czoom;
				xvect2 = mulscale16(xvect, yxaspect);
				yvect2 = mulscale16(yvect, yxaspect);

				//Draw red lines
				for (i = 0; i < numsectors; i++)
				{
					if ((show2dsector[i >> 3] & (1 << (i & 7))) == 0)
					{
						continue;
					}

					startwall = sector[i].wallptr;
					endwall = sector[i].wallptr + sector[i].wallnum;

					z1 = sector[i].ceilingz;
					z2 = sector[i].floorz;

					for (j = startwall, wal = &Engine.board.wall[startwall]; j < endwall; j++, wal++)
					{
						k = wal.nextwall;
						if (k < 0)
						{
							continue;
						}

						//if ((show2dEngine.board.wall[j>>3]&(1<<(j&7))) == 0) continue;
						//if ((k > j) && ((show2dEngine.board.wall[k>>3]&(1<<(k&7))) > 0)) continue;

						if (sector[wal.nextsector].ceilingz == z1)
						{
							if (sector[wal.nextsector].floorz == z2)
							{
								if (((wal.cstat | Engine.board.wall[wal.nextwall].cstat) & (16 + 32)) == 0)
								{
									continue;
								}
							}
						}

						col = 139; //red
						if (((wal.cstat | Engine.board.wall[wal.nextwall].cstat) & 1) != 0)
						{
							col = 234; //magenta
						}

						if ((show2dsector[wal.nextsector >> 3] & (1 << (wal.nextsector & 7))) == 0)
						{
							col = 24;
						}
						else
						{
							continue;
						}

						ox = wal.x - cposx;
						oy = wal.y - cposy;
						x1 = dmulscale16(ox, xvect, -oy, yvect) + (Engine.xdim << 11);
						y1 = dmulscale16(oy, xvect2, ox, yvect2) + (Engine.ydim << 11);

						wal2 = Engine.board.wall[wal.point2];
						ox = wal2.x - cposx;
						oy = wal2.y - cposy;
						x2 = dmulscale16(ox, xvect, -oy, yvect) + (Engine.xdim << 11);
						y2 = dmulscale16(oy, xvect2, ox, yvect2) + (Engine.ydim << 11);

						drawline256(x1, y1, x2, y2, col);
					}
				}

				//Draw sprites
				k = ps[screenpeek].i;
				for (i = 0; i < numsectors; i++)
				{
					if ((show2dsector[i >> 3] & (1 << (i & 7))) == 0)
					{
						continue;
					}
					for (j = headspritesect[i]; j >= 0; j = nextspritesect[j])
					{
						//if ((show2dEngine.board.sprite[j>>3]&(1<<(j&7))) > 0)
						spr = Engine.board.sprite[j];

						if (j == k || (spr.cstat & 0x8000) != 0 || spr.cstat == 257 || spr.xrepeat == 0)
						{
							continue;
						}

						col = 71; //cyan
						if ((spr.cstat & 1) != 0)
						{
							col = 234; //magenta
						}

						sprx = spr.x;
						spry = spr.y;

						if ((spr.cstat & 257) != 0)
						{
							switch (spr.cstat & 48)
							{
								case 0:
									break;

									ox = sprx - cposx;
									oy = spry - cposy;
									x1 = dmulscale16(ox, xvect, -oy, yvect);
									y1 = dmulscale16(oy, xvect2, ox, yvect2);

									ox = (Engine.table.sintable[(spr.ang + 512) & 2047] >> 7);
									oy = (Engine.table.sintable[(spr.ang) & 2047] >> 7);
									x2 = dmulscale16(ox, xvect, -oy, yvect);
									y2 = dmulscale16(oy, xvect, ox, yvect);

									x3 = mulscale16(x2, yxaspect);
									y3 = mulscale16(y2, yxaspect);

									drawline256(x1 - x2 + (Engine.xdim << 11), y1 - y3 + (Engine.ydim << 11), x1 + x2 + (Engine.xdim << 11), y1 + y3 + (Engine.ydim << 11), col);
									drawline256(x1 - y2 + (Engine.xdim << 11), y1 + x3 + (Engine.ydim << 11), x1 + x2 + (Engine.xdim << 11), y1 + y3 + (Engine.ydim << 11), col);
									drawline256(x1 + y2 + (Engine.xdim << 11), y1 - x3 + (Engine.ydim << 11), x1 + x2 + (Engine.xdim << 11), y1 + y3 + (Engine.ydim << 11), col);
									break;

								case 16:
									if (spr.picnum == DefineConstants.LASERLINE)
									{
										x1 = sprx;
										y1 = spry;
										tilenum = spr.picnum;
										xoff = (int)((sbyte)((picanm[tilenum] >> 8) & 255)) + ((int)spr.xoffset);
										if ((spr.cstat & 4) > 0)
										{
											xoff = -xoff;
										}
										k = spr.ang;
										l = spr.xrepeat;
										dax = Engine.table.sintable[k & 2047] * l;
										day = Engine.table.sintable[(k + 1536) & 2047] * l;
										l = Engine.tilesizx[tilenum];
										k = (l >> 1) + xoff;
										x1 -= mulscale16(dax, k);
										x2 = x1 + mulscale16(dax, l);
										y1 -= mulscale16(day, k);
										y2 = y1 + mulscale16(day, l);

										ox = x1 - cposx;
										oy = y1 - cposy;
										x1 = dmulscale16(ox, xvect, -oy, yvect);
										y1 = dmulscale16(oy, xvect2, ox, yvect2);

										ox = x2 - cposx;
										oy = y2 - cposy;
										x2 = dmulscale16(ox, xvect, -oy, yvect);
										y2 = dmulscale16(oy, xvect2, ox, yvect2);

										drawline256(x1 + (Engine.xdim << 11), y1 + (Engine.ydim << 11), x2 + (Engine.xdim << 11), y2 + (Engine.ydim << 11), col);
									}

									break;

								case 32:

									tilenum = spr.picnum;
									xoff = (int)((sbyte)((picanm[tilenum] >> 8) & 255)) + ((int)spr.xoffset);
									yoff = (int)((sbyte)((picanm[tilenum] >> 16) & 255)) + ((int)spr.yoffset);
									if ((spr.cstat & 4) > 0)
									{
										xoff = -xoff;
									}
									if ((spr.cstat & 8) > 0)
									{
										yoff = -yoff;
									}

									k = spr.ang;
									cosang = Engine.table.sintable[(k + 512) & 2047];
									sinang = Engine.table.sintable[k];
									xspan = Engine.tilesizx[tilenum];
									xrepeat = spr.xrepeat;
									yspan = Engine.tilesizy[tilenum];
									yrepeat = spr.yrepeat;

									dax = ((xspan >> 1) + xoff) * xrepeat;
									day = ((yspan >> 1) + yoff) * yrepeat;
									x1 = sprx + dmulscale16(sinang, dax, cosang, day);
									y1 = spry + dmulscale16(sinang, day, -cosang, dax);
									l = xspan * xrepeat;
									x2 = x1 - mulscale16(sinang, l);
									y2 = y1 + mulscale16(cosang, l);
									l = yspan * yrepeat;
									k = -mulscale16(cosang, l);
									x3 = x2 + k;
									x4 = x1 + k;
									k = -mulscale16(sinang, l);
									y3 = y2 + k;
									y4 = y1 + k;

									ox = x1 - cposx;
									oy = y1 - cposy;
									x1 = dmulscale16(ox, xvect, -oy, yvect);
									y1 = dmulscale16(oy, xvect2, ox, yvect2);

									ox = x2 - cposx;
									oy = y2 - cposy;
									x2 = dmulscale16(ox, xvect, -oy, yvect);
									y2 = dmulscale16(oy, xvect2, ox, yvect2);

									ox = x3 - cposx;
									oy = y3 - cposy;
									x3 = dmulscale16(ox, xvect, -oy, yvect);
									y3 = dmulscale16(oy, xvect2, ox, yvect2);

									ox = x4 - cposx;
									oy = y4 - cposy;
									x4 = dmulscale16(ox, xvect, -oy, yvect);
									y4 = dmulscale16(oy, xvect2, ox, yvect2);

									drawline256(x1 + (Engine.xdim << 11), y1 + (Engine.ydim << 11), x2 + (Engine.xdim << 11), y2 + (Engine.ydim << 11), col);

									drawline256(x2 + (Engine.xdim << 11), y2 + (Engine.ydim << 11), x3 + (Engine.xdim << 11), y3 + (Engine.ydim << 11), col);

									drawline256(x3 + (Engine.xdim << 11), y3 + (Engine.ydim << 11), x4 + (Engine.xdim << 11), y4 + (Engine.ydim << 11), col);

									drawline256(x4 + (Engine.xdim << 11), y4 + (Engine.ydim << 11), x1 + (Engine.xdim << 11), y1 + (Engine.ydim << 11), col);

									break;
							}
						}
					}
				}

				//Draw white lines
				for (i = 0; i < numsectors; i++)
				{
					if ((show2dsector[i >> 3] & (1 << (i & 7))) == 0)
					{
						continue;
					}

					startwall = sector[i].wallptr;
					endwall = sector[i].wallptr + sector[i].wallnum;

					k = -1;
					for (j = startwall, wal = &Engine.board.wall[startwall]; j < endwall; j++, wal++)
					{
						if (wal.nextwall >= 0)
						{
							continue;
						}

						//if ((show2dEngine.board.wall[j>>3]&(1<<(j&7))) == 0) continue;

						if (Engine.tilesizx[wal.picnum] == 0)
						{
							continue;
						}
						if (Engine.tilesizy[wal.picnum] == 0)
						{
							continue;
						}

						if (j == k)
						{
							x1 = x2;
							y1 = y2;
						}
						else
						{
							ox = wal.x - cposx;
							oy = wal.y - cposy;
							x1 = dmulscale16(ox, xvect, -oy, yvect) + (Engine.xdim << 11);
							y1 = dmulscale16(oy, xvect2, ox, yvect2) + (Engine.ydim << 11);
						}

						k = wal.point2;
						wal2 = Engine.board.wall[k];
						ox = wal2.x - cposx;
						oy = wal2.y - cposy;
						x2 = dmulscale16(ox, xvect, -oy, yvect) + (Engine.xdim << 11);
						y2 = dmulscale16(oy, xvect2, ox, yvect2) + (Engine.ydim << 11);

						drawline256(x1, y1, x2, y2, 24);
					}
				}

				for (p = connecthead; p >= 0; p = connectpoint2[p])
				{
					if (ud.scrollmode && p == screenpeek)
					{
						continue;
					}

					ox = Engine.board.sprite[ps[p].i].x - cposx;
					oy = Engine.board.sprite[ps[p].i].y - cposy;
					daang = (Engine.board.sprite[ps[p].i].ang - cang) & 2047;
					if (p == screenpeek)
					{
						ox = 0;
						oy = 0;
						daang = 0;
					}
					x1 = mulscale(ox, xvect, 16) - mulscale(oy, yvect, 16);
					y1 = mulscale(oy, xvect2, 16) + mulscale(ox, yvect2, 16);

					if (p == screenpeek || ud.coop == 1)
					{
						if (Engine.board.sprite[ps[p].i].xvel > 16 && ps[p].on_ground)
						{
							i = DefineConstants.APLAYERTOP + ((totalclock >> 4) & 3);
						}
						else
						{
							i = DefineConstants.APLAYERTOP;
						}

						j = pragmas.klabs(ps[p].truefz - ps[p].posz) >> 8;
						j = mulscale(czoom * (Engine.board.sprite[ps[p].i].yrepeat + j), yxaspect, 16);

						if (j < 22000)
						{
							j = 22000;
						}
						else if (j > (65536 << 1))
						{
							j = (65536 << 1);
						}

						Engine.rotatesprite((x1 << 4) + (Engine.xdim << 15), (y1 << 4) + (Engine.ydim << 15), j, daang, i, Engine.board.sprite[ps[p].i].shade, Engine.board.sprite[ps[p].i].pal, (Engine.board.sprite[ps[p].i].cstat & 2) >> 1, windowx1, windowy1, windowx2, windowy2);
					}
				}
		*/
	}



	public static void endanimsounds(int fr)
	{
		switch (ud.volume_number)
		{
			case 0:
				break;
			case 1:
				switch (fr)
				{
					case 1:
						sound(DefineConstants.WIND_AMBIENCE);
						break;
					case 26:
						sound(DefineConstants.ENDSEQVOL2SND1);
						break;
					case 36:
						sound(DefineConstants.ENDSEQVOL2SND2);
						break;
					case 54:
						sound(DefineConstants.THUD);
						break;
					case 62:
						sound(DefineConstants.ENDSEQVOL2SND3);
						break;
					case 75:
						sound(DefineConstants.ENDSEQVOL2SND4);
						break;
					case 81:
						sound(DefineConstants.ENDSEQVOL2SND5);
						break;
					case 115:
						sound(DefineConstants.ENDSEQVOL2SND6);
						break;
					case 124:
						sound(DefineConstants.ENDSEQVOL2SND7);
						break;
				}
				break;
			case 2:
				switch (fr)
				{
					case 1:
						sound(DefineConstants.WIND_REPEAT);
						break;
					case 98:
						sound(DefineConstants.DUKE_GRUNT);
						break;
					case 82 + 20:
						sound(DefineConstants.THUD);
						sound(DefineConstants.SQUISHED);
						break;
					case 104 + 20:
						sound(DefineConstants.ENDSEQVOL3SND3);
						break;
					case 114 + 20:
						sound(DefineConstants.ENDSEQVOL3SND2);
						break;
					case 158:
						sound(DefineConstants.PIPEBOMB_EXPLODE);
						break;
				}
				break;
		}
	}

	public static void logoanimsounds(int fr)
	{
		switch (fr)
		{
			case 1:
				sound(DefineConstants.FLY_BY);
				break;
			case 19:
				sound(DefineConstants.PIPEBOMB_EXPLODE);
				break;
		}
	}

	public static void intro4animsounds(int fr)
	{
		switch (fr)
		{
			case 1:
				sound(DefineConstants.INTRO4_B);
				break;
			case 12:
			case 34:
				sound(DefineConstants.SHORT_CIRCUIT);
				break;
			case 18:
				sound(DefineConstants.INTRO4_5);
				break;
		}
	}

	public static void first4animsounds(int fr)
	{
		switch (fr)
		{
			case 1:
				sound(DefineConstants.INTRO4_1);
				break;
			case 12:
				sound(DefineConstants.INTRO4_2);
				break;
			case 7:
				sound(DefineConstants.INTRO4_3);
				break;
			case 26:
				sound(DefineConstants.INTRO4_4);
				break;
		}
	}

	public static void intro42animsounds(int fr)
	{
		switch (fr)
		{
			case 10:
				sound(DefineConstants.INTRO4_6);
				break;
		}
	}




	public static void endanimvol41(int fr)
	{
		switch (fr)
		{
			case 3:
				sound(DefineConstants.DUKE_UNDERWATER);
				break;
			case 35:
				sound(DefineConstants.VOL4ENDSND1);
				break;
		}
	}

	public static void endanimvol42(int fr)
	{
		switch (fr)
		{
			case 11:
				sound(DefineConstants.DUKE_UNDERWATER);
				break;
			case 20:
				sound(DefineConstants.VOL4ENDSND1);
				break;
			case 39:
				sound(DefineConstants.VOL4ENDSND2);
				break;
			case 50:
				FX_StopAllSounds();
				break;
		}
	}

	public static void endanimvol43(int fr)
	{
		switch (fr)
		{
			case 1:
				sound(DefineConstants.BOSS4_DEADSPEECH);
				break;
			case 40:
				sound(DefineConstants.VOL4ENDSND1);
				sound(DefineConstants.DUKE_UNDERWATER);
				break;
			case 50:
				sound(DefineConstants.BIGBANG);
				break;
		}
	}


	public static int lastanimhack = 0;
	public static void playanm(ref string fn, char t)
	{
		// jmarshall - animation
		/*
				string animbuf;
				string palptr;
				int i;
				int j;
				int k;
				int length = 0;
				int numframes = 0;
				int handle = -1;

				//    return;

				if (t != 7 && t != 9 && t != 10 && t != 11)
				{
					KB_FlushKeyboardQueue();
				}

				if (KB_KeyWaiting() != null)
				{
					FX_StopAllSounds();
					goto ENDOFANIMLOOP;
				}

				handle = kopen4load(fn, 0);
				if (handle == -1)
				{
					return;
				}
				length = kfilelength(handle);

				walock[DefineConstants.MAXTILES - 3 - t] = 219 + t;

				if (anim == 0 || lastanimhack != (DefineConstants.MAXTILES - 3 - t))
				{
					allocache((int)&anim, length + sizeof(anim_t), walock[DefineConstants.MAXTILES - 3 - t]);
				}

				animbuf = (string)(FP_OFF(anim) + sizeof(anim_t));

				lastanimhack = (DefineConstants.MAXTILES - 3 - t);

				Engine.tilesizx[DefineConstants.MAXTILES - 3 - t] = 200;
				Engine.tilesizy[DefineConstants.MAXTILES - 3 - t] = 320;

				kread(handle, animbuf, length);
				kclose(handle);

				ANIM_LoadAnim(ref animbuf);
				numframes = ANIM_NumFrames();

				palptr = ANIM_GetPalette();
				for (i = 0; i < 256; i++)
				{
					j = (i << 2);
					k = j - i;
					tempbuf[j + 0] = (palptr[k + 2] >> 2);
					tempbuf[j + 1] = (palptr[k + 1] >> 2);
					tempbuf[j + 2] = (palptr[k + 0] >> 2);
					tempbuf[j + 3] = 0;
				}

				VBE_setPalette(0, 256, tempbuf);

				ototalclock = totalclock + 10;

				for (i = 1; i < numframes; i++)
				{
					while (totalclock < ototalclock)
					{
						if (KB_KeyWaiting() != null)
						{
							goto ENDOFANIMLOOP;
						}
						getpackets();
					}

					if (t == 10)
					{
						ototalclock += 14;
					}
					else if (t == 9)
					{
						ototalclock += 10;
					}
					else if (t == 7)
					{
						ototalclock += 18;
					}
					else if (t == 6)
					{
						ototalclock += 14;
					}
					else if (t == 5)
					{
						ototalclock += 9;
					}
					else if (ud.volume_number == 3)
					{
						ototalclock += 10;
					}
					else if (ud.volume_number == 2)
					{
						ototalclock += 10;
					}
					else if (ud.volume_number == 1)
					{
						ototalclock += 18;
					}
					else
					{
						ototalclock += 10;
					}

					waloff[DefineConstants.MAXTILES - 3 - t] = FP_OFF(ANIM_DrawFrame(i));
					Engine.rotatesprite(0 << 16, 0 << 16, 65536, 512, DefineConstants.MAXTILES - 3 - t, 0, 0, 2 + 4 + 8 + 16 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
					nextpage();

					if (t == 8)
					{
						endanimvol41(i);
					}
					else if (t == 10)
					{
						endanimvol42(i);
					}
					else if (t == 11)
					{
						endanimvol43(i);
					}
					else if (t == 9)
					{
						intro42animsounds(i);
					}
					else if (t == 7)
					{
						intro4animsounds(i);
					}
					else if (t == 6)
					{
						first4animsounds(i);
					}
					else if (t == 5)
					{
						logoanimsounds(i);
					}
					else if (t < 4)
					{
						endanimsounds(i);
					}
				}

				ENDOFANIMLOOP:

				ANIM_FreeAnim();
				walock[DefineConstants.MAXTILES - 3 - t] = 1;
		*/
	}
}