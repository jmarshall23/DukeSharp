using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using Build;
public partial class GlobalMembers
{
   
	public static int cameradist = 0;
	public static int cameraclock = 0;
	public static char eightytwofifty = (char)0;
	public static char playerswhenstarted;
	public static char qe;
	public static char cp;

	public static int oyrepeat = -1;

	public static int CommandSoundToggleOff = 0;
	public static int CommandMusicToggleOff = 0;

	public const string confilename = "GAME.CON";
	public static string boardfilename = "";
	public static byte[] waterpal = new byte[768];
	public static byte[] slimepal = new byte[768];
	public static byte[] titlepal = new byte[768];
	public static byte[] drealms = new byte[768];
	public static byte[] endingpal = new byte[768];
	public const string firstdemofile = "";

	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define patchstatusbar(x1,y1,x2,y2) { Engine.rotatesprite(0,(200-34)<<16,65536L,0,BOTTOMSTATUSBAR,4,0,10+16+64+128, scale(x1,Engine.xdim,320),scale(y1,Engine.ydim,200), scale(x2,Engine.xdim,320)-1,scale(y2,Engine.ydim,200)-1); }

//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void __interrupt __far newint24(int errval, int ax, int bp, int si);

	public static int recfilep;
	public static int totalreccnt;
	public static char debug_on = (char)0;
	public static char actor_tog = (char)0;
	public static string rtsptr;
	public static char memorycheckoveride = (char)0;



//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern char syncstate;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern int numlumps;

	//public static FILE frecfilep = (FILE *)null;
//C++ TO C# CONVERTER TODO TASK: The implementation of the following method could not be found:
	//void pitch_test();

	public static char restorepalette;
	public static char screencapt;
	public static char nomorelogohack;
	public static int sendmessagecommand = -1;

    //public static task TimerPtr = null;

    //C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
    //extern int lastvisinc;

    public static void closedemowrite()
    {

    }
    public static void lotsofglass(short i, short wallnum, short n)
    {

    }

    public static void lotsofcolourglass(short i, short wallnum, short n)
    {

    }

    public static void ceilingglass(short i, short sectnum, short n)
    {

    }

    public static void spriteglass(short i, short n)
    {

    }

    public static void opendemowrite()
    {

    }

    public static void dobonus(int bonusonly)
    {

    }


    public static void gameexit(string msg)
    {
        throw new Exception(msg);
    }

    public static void timerhandler()
	{
		totalclock++;
	}

	public static void inittimer()
	{
		//TimerPtr = TS_ScheduleTask(timerhandler, DefineConstants.TICRATE, 1, null);
		//TS_Dispatch();
	}

	public static void uninittimer()
	{
	   //if (TimerPtr != null)
	   //{
		//  TS_Terminate(TimerPtr);
	   //}
	   //TimerPtr = null;
	   //TS_Shutdown();
	}

    public static void cameratext(short i)
    {
        char flipbits;
        int x;
        int y;

        if (hittype[i].temp_data[0] == 0)
        {
            Engine.rotatesprite(24 << 16, 33 << 16, 65536, 0, DefineConstants.CAMCORNER, 0, 0, 2, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
            Engine.rotatesprite((320 - 26) << 16, 34 << 16, 65536, 0, DefineConstants.CAMCORNER + 1, 0, 0, 2, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
            Engine.rotatesprite(22 << 16, 163 << 16, 65536, 512, DefineConstants.CAMCORNER + 1, 0, 0, 2 + 4, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
            Engine.rotatesprite((310 - 10) << 16, 163 << 16, 65536, 512, DefineConstants.CAMCORNER + 1, 0, 0, 2, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
            if ((totalclock & 16) != 0)
            {
                Engine.rotatesprite(46 << 16, 32 << 16, 65536, 0, DefineConstants.CAMLIGHT, 0, 0, 2, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
            }
        }
        else
        {
            flipbits = (char)((totalclock << 1) & 48);
            for (x = 0; x < 394; x += 64)
            {
                for (y = 0; y < 200; y += 64)
                {
                    Engine.rotatesprite(x << 16, y << 16, 65536, 0, DefineConstants.STATIC, 0, 0, (byte)(2 + flipbits), Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
                }
            }
        }
    }

    //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 't', so pointers on this parameter are left unchanged:
    private static string itoa(int n)
    {
		char[] result = new char[11]; // 11 = "-2147483648".Length
        int index = result.Length;
        bool sign = n < 0;

        do
        {
            int digit = n % 10;
            if (sign)
            {
                digit = -digit;
            }
            result[--index] = (char)('0' + digit);
            n /= 10;
        }
        while (n != 0);

        if (sign)
        {
            result[--index] = '-';
        }
		return new string(result, index, result.Length - index);
	}

    public static void gamenumber(int x,int y,int n,char s)
	{
		string b = "";
		b += n;
		gametext(x, y, b, s, (short)(2 + 8 + 16));
	}


	public static string recbuf = new string(new char[80]);
	public static void allowtimetocorrecterrorswhenquitting()
	{
		 int i;
		 int j;
		 int oldtotalclock;

		 ready2send = (char)0;

		 for (j = 0;j < 8;j++)
		 {
			  oldtotalclock = totalclock;

			  while (totalclock < oldtotalclock + (DefineConstants.TICRATE / 26))
			  {
				  getpackets();
			  }

			  if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false))
			  {
				  return;
			  }

			  packbuf[0] = 127;
			  for (i = connecthead;i >= 0;i = connectpoint2[i])
			  {
					if (i != myconnectindex)
					{
						 //sendpacket(i,packbuf,1);
					}
			  }
		 }
	}

	public static int quotebot;
	public static int quotebotgoal;
	public static short[] user_quote_time = new short[DefineConstants.MAXUSERQUOTES];
	public static string[] user_quote = new string[DefineConstants.MAXUSERQUOTES];
	// char typebuflen,typebuf[41];

//C++ TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
	public static void adduserquote(string daquote)
	{
		int i;

		for (i = DefineConstants.MAXUSERQUOTES - 1;i > 0;i--)
		{
			user_quote[i] = user_quote[i - 1];
			user_quote_time[i] = user_quote_time[i - 1];
		}
		user_quote[0] = daquote;
		user_quote_time[0] = 180;
		pub = (char)DefineConstants.NUMPAGES;
	}


	public static void getpackets()
	{
// jmarshall - multiplayuer
/*
		int i;
		int j;
		int k;
		int l;
		FILE fp;
		short other;
		short packbufleng;
		input osyn;
		input nsyn;

		if (qe == 0 && (KB_KeyDown[(DefineConstants.sc_LeftControl)] != 0) && (KB_KeyDown[(DefineConstants.sc_LeftAlt)] != 0) && (KB_KeyDown[(DefineConstants.sc_Delete)] != 0))
		{
			qe = 1;
			gameexit("Quick Exit.");
		}

		if (numplayers < 2)
		{
			return;
		}
		while ((packbufleng = getpacket(other, packbuf)) > 0)
		{
			switch (packbuf[0])
			{
				case 125:
					cp = 0;
					break;

				case 126:
					multiflag = 2;
					multiwhat = 0;
					multiwho = other;
					multipos = packbuf[1];
					loadplayer(multipos);
					multiflag = 0;
					break;
				case 0: //[0] (receive master sync buffer)
					j = 1;

					if ((movefifoend[other] & (DefineConstants.TIMERUPDATESIZ - 1)) == 0)
					{
						for (i = connectpoint2[connecthead];i >= 0;i = connectpoint2[i])
						{
							if (playerquitflag[i] == 0)
							{
								continue;
							}
							if (i == myconnectindex)
							{
								otherminlag = (int)((sbyte)packbuf[j]);
							}
							j++;
						}
					}

					osyn = (input)inputfifo[(movefifoend[connecthead] - 1) & (DefineConstants.MOVEFIFOSIZ - 1)][0];
					nsyn = (input)inputfifo[(movefifoend[connecthead]) & (DefineConstants.MOVEFIFOSIZ - 1)][0];

					k = j;
					for (i = connecthead;i >= 0;i = connectpoint2[i])
					{
						j += playerquitflag[i];
					}
					for (i = connecthead;i >= 0;i = connectpoint2[i])
					{
						if (playerquitflag[i] == 0)
						{
							continue;
						}

						l = packbuf[k++];
						if (i == myconnectindex)
						{
								j += ((l & 1) << 1) + (l & 2) + ((l & 4)>>2) + ((l & 8) >> 3) + ((l & 16) >> 4) + ((l & 32) >> 5) + ((l & 64) >> 6) + ((l & 128) >> 7);
								continue;
						}

						copybufbyte(osyn[i], nsyn[i], sizeof(input));
						if ((l & 1) != 0)
						{
							nsyn[i].fvel = packbuf[j] + ((short)packbuf[j + 1] << 8), j += 2;
						}
						if ((l & 2) != 0)
						{
							nsyn[i].svel = packbuf[j] + ((short)packbuf[j + 1] << 8), j += 2;
						}
						if ((l & 4) != 0)
						{
							nsyn[i].avel = (sbyte)packbuf[j++];
						}
						if ((l & 8) != 0)
						{
							nsyn[i].bits = ((nsyn[i].bits & 0xffffff00) | ((int)packbuf[j++]));
						}
						if ((l & 16) != 0)
						{
							nsyn[i].bits = ((nsyn[i].bits & 0xffff00ff) | ((int)packbuf[j++]) << 8);
						}
						if ((l & 32) != 0)
						{
							nsyn[i].bits = ((nsyn[i].bits & 0xff00ffff) | ((int)packbuf[j++]) << 16);
						}
						if ((l & 64) != 0)
						{
							nsyn[i].bits = ((nsyn[i].bits & 0x00ffffff) | ((int)packbuf[j++]) << 24);
						}
						if ((l & 128) != 0)
						{
							nsyn[i].horz = (sbyte)packbuf[j++];
						}

						if ((nsyn[i].bits & (1 << 26)) != 0)
						{
							playerquitflag[i] = 0;
						}
						movefifoend[i]++;
					}

					while (j != packbufleng)
					{
						for (i = connecthead;i >= 0;i = connectpoint2[i])
						{
							if (i != myconnectindex)
							{
							syncval[i][syncvalhead[i] & (DefineConstants.MOVEFIFOSIZ - 1)] = packbuf[j];
							syncvalhead[i]++;
							}
						}
						j++;
					}

					for (i = connecthead;i >= 0;i = connectpoint2[i])
					{
						if (i != myconnectindex)
						{
							for (j = 1;j < movesperpacket;j++)
							{
								copybufbyte(nsyn[i], inputfifo[movefifoend[i] & (DefineConstants.MOVEFIFOSIZ - 1)][i], sizeof(input));
								movefifoend[i]++;
							}
						}
					}

					 movefifosendplc += movesperpacket;

					break;
				case 1: //[1] (receive slave sync buffer)
					j = 2;
					k = packbuf[1];

					osyn = (input)inputfifo[(movefifoend[other] - 1) & (DefineConstants.MOVEFIFOSIZ - 1)][0];
					nsyn = (input)inputfifo[(movefifoend[other]) & (DefineConstants.MOVEFIFOSIZ - 1)][0];

					copybufbyte(osyn[other], nsyn[other], sizeof(input));
					if ((k & 1) != 0)
					{
						nsyn[other].fvel = packbuf[j] + ((short)packbuf[j + 1] << 8), j += 2;
					}
					if ((k & 2) != 0)
					{
						nsyn[other].svel = packbuf[j] + ((short)packbuf[j + 1] << 8), j += 2;
					}
					if ((k & 4) != 0)
					{
						nsyn[other].avel = (sbyte)packbuf[j++];
					}
					if ((k & 8) != 0)
					{
						nsyn[other].bits = ((nsyn[other].bits & 0xffffff00) | ((int)packbuf[j++]));
					}
					if ((k & 16) != 0)
					{
						nsyn[other].bits = ((nsyn[other].bits & 0xffff00ff) | ((int)packbuf[j++]) << 8);
					}
					if ((k & 32) != 0)
					{
						nsyn[other].bits = ((nsyn[other].bits & 0xff00ffff) | ((int)packbuf[j++]) << 16);
					}
					if ((k & 64) != 0)
					{
						nsyn[other].bits = ((nsyn[other].bits & 0x00ffffff) | ((int)packbuf[j++]) << 24);
					}
					if ((k & 128) != 0)
					{
						nsyn[other].horz = (sbyte)packbuf[j++];
					}
					movefifoend[other]++;

					while (j != packbufleng)
					{
						syncval[other][syncvalhead[other] & (DefineConstants.MOVEFIFOSIZ - 1)] = packbuf[j++];
						syncvalhead[other]++;
					}

					for (i = 1;i < movesperpacket;i++)
					{
						copybufbyte(nsyn[other], inputfifo[movefifoend[other] & (DefineConstants.MOVEFIFOSIZ - 1)][other], sizeof(input));
						movefifoend[other]++;
					}

					break;

				case 4:
					strcpy(recbuf,packbuf + 1);
					recbuf = recbuf.Substring(0, packbufleng - 1);

					adduserquote(ref recbuf);
					sound(DefineConstants.EXITMENUSOUND);

					pus = DefineConstants.NUMPAGES;
					pub = DefineConstants.NUMPAGES;

					break;

				case 5:
					ud.m_level_number = ud.level_number = packbuf[1];
					ud.m_volume_number = ud.volume_number = packbuf[2];
					ud.m_player_skill = ud.player_skill = packbuf[3];
					ud.m_monsters_off = ud.monsters_off = packbuf[4];
					ud.m_respawn_monsters = ud.respawn_monsters = packbuf[5];
					ud.m_respawn_items = ud.respawn_items = packbuf[6];
					ud.m_respawn_inventory = ud.respawn_inventory = packbuf[7];
					ud.m_coop = packbuf[8];
					ud.m_marker = ud.marker = packbuf[9];
					ud.m_ffire = ud.ffire = packbuf[10];

					for (i = connecthead;i >= 0;i = connectpoint2[i])
					{
						resetweapons((short)i);
						resetinventory((short)i);
					}

					newgame(ud.volume_number, ud.level_number, ud.player_skill);
					ud.coop = ud.m_coop;

					enterlevel(DefineConstants.MODE_GAME);

					break;
				case 6:
					if (packbuf[1] != DefineConstants.BYTEVERSION)
					{
						gameexit("\nYou cannot play Duke with different versions.");
					}
					for (i = 2;packbuf[i];i++)
					{
						ud.user_name[other][i - 2] = packbuf[i];
					}
					ud.user_name[other][i - 2] = 0;
					break;
				case 9:
					for (i = 1;i < packbufleng;i++)
					{
						ud.wchoice[other][i - 1] = packbuf[i];
					}
					break;
				case 7:

					if (numlumps == 0)
					{
						break;
					}

					if (SoundToggle == 0 || ud.lockout == 1 || FXDevice == soundcardnames.NumSoundCards)
					{
						break;
					}
					rtsptr = (string)RTS_GetSound(packbuf[1] - 1);
					if (rtsptr == 'C')
					{
						FX_PlayVOC3D(ref rtsptr, 0, 0, 0, 255, (uint)(-packbuf[1]));
					}
					else
					{
						FX_PlayWAV3D(ref rtsptr, 0, 0, 0, 255, (uint)(-packbuf[1]));
					}
					rtsplaying = 7;
					break;
				case 8:
					ud.m_level_number = ud.level_number = packbuf[1];
					ud.m_volume_number = ud.volume_number = packbuf[2];
					ud.m_player_skill = ud.player_skill = packbuf[3];
					ud.m_monsters_off = ud.monsters_off = packbuf[4];
					ud.m_respawn_monsters = ud.respawn_monsters = packbuf[5];
					ud.m_respawn_items = ud.respawn_items = packbuf[6];
					ud.m_respawn_inventory = ud.respawn_inventory = packbuf[7];
					ud.m_coop = ud.coop = packbuf[8];
					ud.m_marker = ud.marker = packbuf[9];
					ud.m_ffire = ud.ffire = packbuf[10];

					copybufbyte(packbuf + 10,boardfilename,packbufleng - 11);
					boardfilename[packbufleng - 11] = 0;

					for (i = connecthead;i >= 0;i = connectpoint2[i])
					{
						resetweapons((short)i);
						resetinventory((short)i);
					}

					newgame(ud.volume_number, ud.level_number, ud.player_skill);
					enterlevel(DefineConstants.MODE_GAME);
					break;

				case 16:
					movefifoend[other] = movefifoplc = movefifosendplc = fakemovefifoplc = 0;
					syncvalhead[other] = syncvaltottail = 0;
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
				case 17:
					j = 1;

					if ((movefifoend[other] & (DefineConstants.TIMERUPDATESIZ - 1)) == 0)
					{
						if (other == connecthead)
						{
							for (i = connectpoint2[connecthead];i >= 0;i = connectpoint2[i])
							{
								if (i == myconnectindex)
								{
									otherminlag = (int)((sbyte)packbuf[j]);
								}
								j++;
							}
						}
					}

					osyn = (input)inputfifo[(movefifoend[other] - 1) & (DefineConstants.MOVEFIFOSIZ - 1)][0];
					nsyn = (input)inputfifo[(movefifoend[other]) & (DefineConstants.MOVEFIFOSIZ - 1)][0];

					copybufbyte(osyn[other], nsyn[other], sizeof(input));
					k = packbuf[j++];
					if ((k & 1) != 0)
					{
						nsyn[other].fvel = packbuf[j] + ((short)packbuf[j + 1] << 8), j += 2;
					}
					if ((k & 2) != 0)
					{
						nsyn[other].svel = packbuf[j] + ((short)packbuf[j + 1] << 8), j += 2;
					}
					if ((k & 4) != 0)
					{
						nsyn[other].avel = (sbyte)packbuf[j++];
					}
					if ((k & 8) != 0)
					{
						nsyn[other].bits = ((nsyn[other].bits & 0xffffff00) | ((int)packbuf[j++]));
					}
					if ((k & 16) != 0)
					{
						nsyn[other].bits = ((nsyn[other].bits & 0xffff00ff) | ((int)packbuf[j++]) << 8);
					}
					if ((k & 32) != 0)
					{
						nsyn[other].bits = ((nsyn[other].bits & 0xff00ffff) | ((int)packbuf[j++]) << 16);
					}
					if ((k & 64) != 0)
					{
						nsyn[other].bits = ((nsyn[other].bits & 0x00ffffff) | ((int)packbuf[j++]) << 24);
					}
					if ((k & 128) != 0)
					{
						nsyn[other].horz = (sbyte)packbuf[j++];
					}
					movefifoend[other]++;

					for (i = 1;i < movesperpacket;i++)
					{
						copybufbyte(nsyn[other], inputfifo[movefifoend[other] & (DefineConstants.MOVEFIFOSIZ - 1)][other], sizeof(input));
						movefifoend[other]++;
					}

					if (j > packbufleng)
					{
						printf("INVALID GAME PACKET!!! (%ld too many bytes)\n",j - packbufleng);
					}

					while (j != packbufleng)
					{
						syncval[other][syncvalhead[other] & (DefineConstants.MOVEFIFOSIZ - 1)] = packbuf[j++];
						syncvalhead[other]++;
					}

					break;
				case 127:
					break;

				case 250:
					playerreadyflag[other]++;
					break;
				case 255:
					gameexit(" ");
					break;
			}
		}
*/
	}

	public static void faketimerhandler()
	{
		int i;
		int j;
		int k;
		int l;
	//    short who;
		input osyn;
		input nsyn;

		//if (qe == 0 && (KB_KeyDown[(DefineConstants.sc_LeftControl)] != 0) && (KB_KeyDown[(DefineConstants.sc_LeftAlt)] != 0) && (KB_KeyDown[(DefineConstants.sc_Delete)] != 0))
		//{
		//	qe = 1;
		//	gameexit("Quick Exit.");
		//}

		if ((totalclock < ototalclock + (DefineConstants.TICRATE / 26)) || (ready2send == 0))
		{
			return;
		}
		ototalclock += (DefineConstants.TICRATE / 26);

// jmarshall - multiplayer
		//getpackets();
		//if (getoutputcirclesize() >= 16)
		//{
		//	return;
		//}
// jmarshall end
		for (i = connecthead;i >= 0;i = connectpoint2[i])
		{
			if (i != myconnectindex)
			{
				if (movefifoend[i] < movefifoend[myconnectindex] - 200)
				{
					return;
				}
			}
		}

		 getinput(myconnectindex);

		 avgfvel += loc.fvel;
		 avgsvel += loc.svel;
		 avgavel += loc.avel;
		 avghorz += loc.horz;
		 avgbits |= (int)loc.bits;
		// jmarshall - fake timer handler.
		//if ((movefifoend[myconnectindex] & (movesperpacket - 1)) != 0)
		//{
		//	  copybufbyte(inputfifo[(movefifoend[myconnectindex] - 1) & (DefineConstants.MOVEFIFOSIZ - 1)][myconnectindex], inputfifo[movefifoend[myconnectindex] & (DefineConstants.MOVEFIFOSIZ - 1)][myconnectindex], sizeof(input));
		//	  movefifoend[myconnectindex]++;
		//	  return;
		//}
		// jmarshall end
		if (inputfifo[movefifoend[myconnectindex] & (DefineConstants.MOVEFIFOSIZ - 1), myconnectindex] == null)
			inputfifo[movefifoend[myconnectindex] & (DefineConstants.MOVEFIFOSIZ - 1), myconnectindex] = new input();

		 nsyn = inputfifo[movefifoend[myconnectindex] & (DefineConstants.MOVEFIFOSIZ - 1),myconnectindex];
		 nsyn.fvel = (short)(avgfvel / movesperpacket);
		 nsyn.svel = (short)(avgsvel / movesperpacket);
		 nsyn.avel = (sbyte)(avgavel / movesperpacket);
		 nsyn.horz = (sbyte)(avghorz / movesperpacket);
		 nsyn.bits = (uint)avgbits;
		 avgfvel = avgsvel = avgavel = avghorz = avgbits = 0;
		 movefifoend[myconnectindex]++;

		 if (numplayers < 2)
		 {
			// jmarshall - fake timer handler.
/*
			  if (ud.multimode > 1)
			  {
				  for (i = connecthead;i >= 0;i = connectpoint2[i])
				  {
				  if (i != myconnectindex)
				  {
					  //clearbufbyte(&inputfifo[movefifoend[i]&(MOVEFIFOSIZ-1)][i],sizeof(input),0L);
					  if (ud.playerai)
					  {
						  computergetinput(i, inputfifo[movefifoend[i] & (DefineConstants.MOVEFIFOSIZ - 1)][i]);
					  }
					  movefifoend[i]++;
				  }
				  }
			  }
*/
			  return;
		 }
// jmarshall - fake timer handler.
/*
		for (i = connecthead;i >= 0;i = connectpoint2[i])
		{
			if (i != myconnectindex)
			{
				k = (movefifoend[myconnectindex] - 1) - movefifoend[i];
				myminlag[i] = Math.Min(myminlag[i],k);
				mymaxlag = Math.Max(mymaxlag,k);
			}
		}

		if (((movefifoend[myconnectindex] - 1) & (DefineConstants.TIMERUPDATESIZ - 1)) == 0)
		{
			i = mymaxlag - bufferjitter;
			mymaxlag = 0;
			if (i > 0)
			{
				bufferjitter += ((3 + i) >> 2);
			}
			else if (i < 0)
			{
				bufferjitter -= ((1 - i) >> 2);
			}
		}

		if (networkmode == 1)
		{
			packbuf[0] = 17;
			if ((movefifoend[myconnectindex] - 1) == 0)
			{
				packbuf[0] = 16;
			}
			j = 1;

				//Fix timers and buffer/jitter value
			if (((movefifoend[myconnectindex] - 1) & (DefineConstants.TIMERUPDATESIZ - 1)) == 0)
			{
				if (myconnectindex != connecthead)
				{
					i = myminlag[connecthead] - otherminlag;
					if (pragmas.klabs(i) > 8)
					{
						i >>= 1;
					}
					else if (pragmas.klabs(i) > 2)
					{
						i = ksgn(i);
					}
					else
					{
						i = 0;
					}

					totalclock -= (DefineConstants.TICRATE / 26) * i;
					myminlag[connecthead] -= i;
					otherminlag += i;
				}

				if (myconnectindex == connecthead)
				{
					for (i = connectpoint2[connecthead];i >= 0;i = connectpoint2[i])
					{
						packbuf[j++] = Math.Min(Math.Max(myminlag[i],-128),127);
					}
				}

				for (i = connecthead;i >= 0;i = connectpoint2[i])
				{
					myminlag[i] = 0x7fffffff;
				}
			}

			osyn = (input)inputfifo[(movefifoend[myconnectindex] - 2) & (DefineConstants.MOVEFIFOSIZ - 1)][myconnectindex];
			nsyn = (input)inputfifo[(movefifoend[myconnectindex] - 1) & (DefineConstants.MOVEFIFOSIZ - 1)][myconnectindex];

			k = j;
			packbuf[j++] = 0;

			if (nsyn[0].fvel != osyn[0].fvel)
			{
				packbuf[j++] = (char)nsyn[0].fvel;
				packbuf[j++] = (char)(nsyn[0].fvel >> 8);
				packbuf[k] |= 1;
			}
			if (nsyn[0].svel != osyn[0].svel)
			{
				packbuf[j++] = (char)nsyn[0].svel;
				packbuf[j++] = (char)(nsyn[0].svel >> 8);
				packbuf[k] |= 2;
			}
			if (nsyn[0].avel != osyn[0].avel)
			{
				packbuf[j++] = (sbyte)nsyn[0].avel;
				packbuf[k] |= 4;
			}
			if (((nsyn[0].bits ^ osyn[0].bits) & 0x000000ff) != 0)
			{
				packbuf[j++] = (nsyn[0].bits & 255), packbuf[k] |= 8;
			}
			if (((nsyn[0].bits ^ osyn[0].bits) & 0x0000ff00) != 0)
			{
				packbuf[j++] = ((nsyn[0].bits >> 8) & 255), packbuf[k] |= 16;
			}
			if (((nsyn[0].bits ^ osyn[0].bits) & 0x00ff0000) != 0)
			{
				packbuf[j++] = ((nsyn[0].bits >> 16) & 255), packbuf[k] |= 32;
			}
			if (((nsyn[0].bits ^ osyn[0].bits) & 0xff000000) != 0)
			{
				packbuf[j++] = ((nsyn[0].bits >> 24) & 255), packbuf[k] |= 64;
			}
			if (nsyn[0].horz != osyn[0].horz)
			{
				packbuf[j++] = (char)nsyn[0].horz;
				packbuf[k] |= 128;
			}

			while (syncvalhead[myconnectindex] != syncvaltail)
			{
				packbuf[j++] = syncval[myconnectindex][syncvaltail & (DefineConstants.MOVEFIFOSIZ - 1)];
				syncvaltail++;
			}

			for (i = connecthead;i >= 0;i = connectpoint2[i])
			{
				if (i != myconnectindex)
				{
					sendpacket(i,packbuf,j);
				}
			}

			return;
		}
		if (myconnectindex != connecthead) //Slave
		{
				//Fix timers and buffer/jitter value
			if (((movefifoend[myconnectindex] - 1) & (DefineConstants.TIMERUPDATESIZ - 1)) == 0)
			{
				i = myminlag[connecthead] - otherminlag;
				if (pragmas.klabs(i) > 8)
				{
					i >>= 1;
				}
				else if (pragmas.klabs(i) > 2)
				{
					i = ksgn(i);
				}
				else
				{
					i = 0;
				}

				totalclock -= (DefineConstants.TICRATE / 26) * i;
				myminlag[connecthead] -= i;
				otherminlag += i;

				for (i = connecthead;i >= 0;i = connectpoint2[i])
				{
					myminlag[i] = 0x7fffffff;
				}
			}

			packbuf[0] = 1;
			packbuf[1] = 0;
			j = 2;

			osyn = (input)inputfifo[(movefifoend[myconnectindex] - 2) & (DefineConstants.MOVEFIFOSIZ - 1)][myconnectindex];
			nsyn = (input)inputfifo[(movefifoend[myconnectindex] - 1) & (DefineConstants.MOVEFIFOSIZ - 1)][myconnectindex];

			if (nsyn[0].fvel != osyn[0].fvel)
			{
				packbuf[j++] = (char)nsyn[0].fvel;
				packbuf[j++] = (char)(nsyn[0].fvel >> 8);
				packbuf[1] |= 1;
			}
			if (nsyn[0].svel != osyn[0].svel)
			{
				packbuf[j++] = (char)nsyn[0].svel;
				packbuf[j++] = (char)(nsyn[0].svel >> 8);
				packbuf[1] |= 2;
			}
			if (nsyn[0].avel != osyn[0].avel)
			{
				packbuf[j++] = (sbyte)nsyn[0].avel;
				packbuf[1] |= 4;
			}
			if (((nsyn[0].bits ^ osyn[0].bits) & 0x000000ff) != 0)
			{
				packbuf[j++] = (nsyn[0].bits & 255), packbuf[1] |= 8;
			}
			if (((nsyn[0].bits ^ osyn[0].bits) & 0x0000ff00) != 0)
			{
				packbuf[j++] = ((nsyn[0].bits >> 8) & 255), packbuf[1] |= 16;
			}
			if (((nsyn[0].bits ^ osyn[0].bits) & 0x00ff0000) != 0)
			{
				packbuf[j++] = ((nsyn[0].bits >> 16) & 255), packbuf[1] |= 32;
			}
			if (((nsyn[0].bits ^ osyn[0].bits) & 0xff000000) != 0)
			{
				packbuf[j++] = ((nsyn[0].bits >> 24) & 255), packbuf[1] |= 64;
			}
			if (nsyn[0].horz != osyn[0].horz)
			{
				packbuf[j++] = (char)nsyn[0].horz;
				packbuf[1] |= 128;
			}

			while (syncvalhead[myconnectindex] != syncvaltail)
			{
				packbuf[j++] = syncval[myconnectindex][syncvaltail & (DefineConstants.MOVEFIFOSIZ - 1)];
				syncvaltail++;
			}

			sendpacket(connecthead,packbuf,j);
			return;
		}

			//This allows allow packet-resends
		for (i = connecthead;i >= 0;i = connectpoint2[i])
		{
			if (movefifoend[i] <= movefifosendplc)
			{
				packbuf[0] = 127;
				for (i = connectpoint2[connecthead];i >= 0;i = connectpoint2[i])
				{
				   sendpacket(i,packbuf,1);
				}
				return;
			}
		}

		while (true) //Master
		{
			for (i = connecthead;i >= 0;i = connectpoint2[i])
			{
				if (playerquitflag[i] && (movefifoend[i] <= movefifosendplc))
				{
					return;
				}
			}

			osyn = (input)inputfifo[(movefifosendplc - 1) & (DefineConstants.MOVEFIFOSIZ - 1)][0];
			nsyn = (input)inputfifo[(movefifosendplc) & (DefineConstants.MOVEFIFOSIZ - 1)][0];

				//MASTER -> SLAVE packet
			packbuf[0] = 0;
			j = 1;

				//Fix timers and buffer/jitter value
			if ((movefifosendplc & (DefineConstants.TIMERUPDATESIZ - 1)) == 0)
			{
				for (i = connectpoint2[connecthead];i >= 0;i = connectpoint2[i])
				{
				   if (playerquitflag[i])
				   {
					packbuf[j++] = Math.Min(Math.Max(myminlag[i],-128),127);
				   }
				}

				for (i = connecthead;i >= 0;i = connectpoint2[i])
				{
					myminlag[i] = 0x7fffffff;
				}
			}

			k = j;
			for (i = connecthead;i >= 0;i = connectpoint2[i])
			{
			   j += playerquitflag[i];
			}
			for (i = connecthead;i >= 0;i = connectpoint2[i])
			{
				if (playerquitflag[i] == 0)
				{
					continue;
				}

				packbuf[k] = 0;
				if (nsyn[i].fvel != osyn[i].fvel)
				{
					packbuf[j++] = (char)nsyn[i].fvel;
					packbuf[j++] = (char)(nsyn[i].fvel >> 8);
					packbuf[k] |= 1;
				}
				if (nsyn[i].svel != osyn[i].svel)
				{
					packbuf[j++] = (char)nsyn[i].svel;
					packbuf[j++] = (char)(nsyn[i].svel >> 8);
					packbuf[k] |= 2;
				}
				if (nsyn[i].avel != osyn[i].avel)
				{
					packbuf[j++] = (sbyte)nsyn[i].avel;
					packbuf[k] |= 4;
				}
				if (((nsyn[i].bits ^ osyn[i].bits) & 0x000000ff) != 0)
				{
					packbuf[j++] = (nsyn[i].bits & 255), packbuf[k] |= 8;
				}
				if (((nsyn[i].bits ^ osyn[i].bits) & 0x0000ff00) != 0)
				{
					packbuf[j++] = ((nsyn[i].bits >> 8) & 255), packbuf[k] |= 16;
				}
				if (((nsyn[i].bits ^ osyn[i].bits) & 0x00ff0000) != 0)
				{
					packbuf[j++] = ((nsyn[i].bits >> 16) & 255), packbuf[k] |= 32;
				}
				if (((nsyn[i].bits ^ osyn[i].bits) & 0xff000000) != 0)
				{
					packbuf[j++] = ((nsyn[i].bits >> 24) & 255), packbuf[k] |= 64;
				}
				if (nsyn[i].horz != osyn[i].horz)
				{
					packbuf[j++] = (char)nsyn[i].horz;
					packbuf[k] |= 128;
				}
				k++;
			}

			while (syncvalhead[myconnectindex] != syncvaltail)
			{
				packbuf[j++] = syncval[myconnectindex][syncvaltail & (DefineConstants.MOVEFIFOSIZ - 1)];
				syncvaltail++;
			}

			for (i = connectpoint2[connecthead];i >= 0;i = connectpoint2[i])
			{
				if (playerquitflag[i])
				{
					 sendpacket(i,packbuf,j);
					 if ((nsyn[i].bits & (1 << 26)) != 0)
					 {
						playerquitflag[i] = 0;
					 }
				}
			}

			movefifosendplc += movesperpacket;
		}
*/
	}

//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern int cacnum;
//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern cactype cac[];

	public static void caches()
	{
/*
		 short i;
		 short k;

		 k = 0;
		 for (i = 0;i < cacnum;i++)
		 {
			  if ((*cac[i].@lock) >= 200)
			  {
					sprintf(tempbuf,"Locked- %ld: Leng:%ld, Lock:%ld",i,cac[i].leng,*cac[i].@lock);
					printext256(0,k,31,-1,tempbuf,1);
					k += 6;
			  }
		 }

		 k += 6;

		 for (i = 1;i < 11;i++)
		 {
			  if (lumplockbyte[i] >= 200)
			  {
					sprintf(tempbuf,"RTS Locked %ld:",i);
					printext256(0,k,31,-1,tempbuf,1);
					k += 6;
			  }
		 }
*/

	}



	public static void checksync()
	{
// jmarshall - multiplayer
/*
		  int i;
		  int k;

		  for (i = connecthead;i >= 0;i = connectpoint2[i])
		  {
				if (syncvalhead[i] == syncvaltottail)
				{
					break;
				}
		  }
		  if (i < 0)
		  {
				 syncstat = 0;
				 do
				 {
						 for (i = connectpoint2[connecthead];i >= 0;i = connectpoint2[i])
						 {
								if (syncval[i][syncvaltottail & (DefineConstants.MOVEFIFOSIZ - 1)] != syncval[connecthead][syncvaltottail & (DefineConstants.MOVEFIFOSIZ - 1)])
								{
									 syncstat = 1;
								}
						 }
						 syncvaltottail++;
						 for (i = connecthead;i >= 0;i = connectpoint2[i])
						 {
								if (syncvalhead[i] == syncvaltottail)
								{
									break;
								}
						 }
				 } while (i < 0);
		  }
		  if (connectpoint2[connecthead] < 0)
		  {
			  syncstat = 0;
		  }

		  if (syncstat)
		  {
			  printext256(4,130,31,0,"Out Of Sync - Please restart game",0);
			  printext256(4,138,31,0,"RUN DN3DHELP.EXE for information.",0);
		  }
		  if (syncstate)
		  {
			  printext256(4,160,31,0,"Missed Network packet!",0);
			  printext256(4,138,31,0,"RUN DN3DHELP.EXE for information.",0);
		  }
*/
	}

    public static int hitasprite(short i, ref short hitsp)
    {
        int sx = 0;
        int sy = 0;
        int sz = 0;
        int zoff = 0;
        int sect = 0;
        short hw = 0;

        if (badguy(Engine.board.sprite[i]) != 0)
        {
            zoff = (42 << 8);
        }
        else if (Engine.board.sprite[i].picnum == DefineConstants.APLAYER)
        {
            zoff = (39 << 8);
        }
        else
        {
            zoff = 0;
        }

        Engine.board.hitscan(Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].z - zoff, Engine.board.sprite[i].sectnum, Engine.table.sintable[(Engine.board.sprite[i].ang + 512) & 2047], Engine.table.sintable[Engine.board.sprite[i].ang & 2047], 0, ref sect, ref hw, ref hitsp, ref sx, ref sy, ref sz, (((256) << 16) + 64));

        if (hw >= 0 && (Engine.board.wall[hw].cstat & 16) != 0 && badguy(Engine.board.sprite[i]) != 0)
        {
            return ((1 << 30));
        }

        return (Engine.FindDistance2D(sx - Engine.board.sprite[i].x, sy - Engine.board.sprite[i].y));
    }

    public static void check_fta_sounds(int i)
	{
		if (Engine.board.sprite[i].extra > 0)
		{
			switch (Engine.board.sprite[i].picnum)
			{
			case DefineConstants.LIZTROOPONTOILET:
			case DefineConstants.LIZTROOPJUSTSIT:
			case DefineConstants.LIZTROOPSHOOT:
			case DefineConstants.LIZTROOPJETPACK:
			case DefineConstants.LIZTROOPDUCKING:
			case DefineConstants.LIZTROOPRUNNING:
			case DefineConstants.LIZTROOP:
				spritesound(DefineConstants.PRED_RECOG, i);
				break;
			case DefineConstants.LIZMAN:
			case DefineConstants.LIZMANSPITTING:
			case DefineConstants.LIZMANFEEDING:
			case DefineConstants.LIZMANJUMP:
				spritesound(DefineConstants.CAPT_RECOG, i);
				break;
			case DefineConstants.PIGCOP:
			case DefineConstants.PIGCOPDIVE:
				spritesound(DefineConstants.PIG_RECOG, i);
				break;
			case DefineConstants.RECON:
				spritesound(DefineConstants.RECO_RECOG, i);
				break;
			case DefineConstants.DRONE:
				spritesound(DefineConstants.DRON_RECOG, i);
				break;
			case DefineConstants.COMMANDER:
			case DefineConstants.COMMANDERSTAYPUT:
				spritesound(DefineConstants.COMM_RECOG, i);
				break;
			case DefineConstants.ORGANTIC:
				spritesound(DefineConstants.TURR_RECOG, i);
				break;
			case DefineConstants.OCTABRAIN:
			case DefineConstants.OCTABRAINSTAYPUT:
				spritesound(DefineConstants.OCTA_RECOG, i);
				break;
			case DefineConstants.BOSS1:
				sound(DefineConstants.BOS1_RECOG);
				break;
			case DefineConstants.BOSS2:
				if (Engine.board.sprite[i].pal == 1)
				{
					sound(DefineConstants.BOS2_RECOG);
				}
				else
				{
					sound(DefineConstants.WHIPYOURASS);
				}
				break;
			case DefineConstants.BOSS3:
				if (Engine.board.sprite[i].pal == 1)
				{
					sound(DefineConstants.BOS3_RECOG);
				}
				else
				{
					sound(DefineConstants.RIPHEADNECK);
				}
				break;
			case DefineConstants.BOSS4:
			case DefineConstants.BOSS4STAYPUT:
				if (Engine.board.sprite[i].pal == 1)
				{
					sound(DefineConstants.BOS4_RECOG);
				}
				sound(DefineConstants.BOSS4_FIRSTSEE);
				break;
			case DefineConstants.GREENSLIME:
				spritesound(DefineConstants.SLIM_RECOG, i);
				break;
			}
		}
	}

	public static short inventory(spritetype s)
	{
		switch (s.picnum)
		{
			case DefineConstants.FIRSTAID:
			case DefineConstants.STEROIDS:
			case DefineConstants.HEATSENSOR:
			case DefineConstants.BOOTS:
			case DefineConstants.JETPACK:
			case DefineConstants.HOLODUKE:
			case DefineConstants.AIRTANK:
				return 1;
		}
		return 0;
	}


	public static short badguy(spritetype s)
	{

		switch (s.picnum)
		{
				case DefineConstants.SHARK:
				case DefineConstants.RECON:
				case DefineConstants.DRONE:
				case DefineConstants.LIZTROOPONTOILET:
				case DefineConstants.LIZTROOPJUSTSIT:
				case DefineConstants.LIZTROOPSTAYPUT:
				case DefineConstants.LIZTROOPSHOOT:
				case DefineConstants.LIZTROOPJETPACK:
				case DefineConstants.LIZTROOPDUCKING:
				case DefineConstants.LIZTROOPRUNNING:
				case DefineConstants.LIZTROOP:
				case DefineConstants.OCTABRAIN:
				case DefineConstants.COMMANDER:
				case DefineConstants.COMMANDERSTAYPUT:
				case DefineConstants.PIGCOP:
				case DefineConstants.EGG:
				case DefineConstants.PIGCOPSTAYPUT:
				case DefineConstants.PIGCOPDIVE:
				case DefineConstants.LIZMAN:
				case DefineConstants.LIZMANSPITTING:
				case DefineConstants.LIZMANFEEDING:
				case DefineConstants.LIZMANJUMP:
				case DefineConstants.ORGANTIC:
				case DefineConstants.BOSS1:
				case DefineConstants.BOSS2:
				case DefineConstants.BOSS3:
				case DefineConstants.BOSS4:
				case DefineConstants.GREENSLIME:
				case DefineConstants.GREENSLIME+1:
				case DefineConstants.GREENSLIME+2:
				case DefineConstants.GREENSLIME+3:
				case DefineConstants.GREENSLIME+4:
				case DefineConstants.GREENSLIME+5:
				case DefineConstants.GREENSLIME+6:
				case DefineConstants.GREENSLIME+7:
				case DefineConstants.RAT:
				case DefineConstants.ROTATEGUN:
					return 1;
		}
		if (actortype[s.picnum] != 0)
		{
			return 1;
		}

		return 0;
	}


    public static short badguypic(short pn)
	{

		switch (pn)
		{
				case DefineConstants.SHARK:
				case DefineConstants.RECON:
				case DefineConstants.DRONE:
				case DefineConstants.LIZTROOPONTOILET:
				case DefineConstants.LIZTROOPJUSTSIT:
				case DefineConstants.LIZTROOPSTAYPUT:
				case DefineConstants.LIZTROOPSHOOT:
				case DefineConstants.LIZTROOPJETPACK:
				case DefineConstants.LIZTROOPDUCKING:
				case DefineConstants.LIZTROOPRUNNING:
				case DefineConstants.LIZTROOP:
				case DefineConstants.OCTABRAIN:
				case DefineConstants.COMMANDER:
				case DefineConstants.COMMANDERSTAYPUT:
				case DefineConstants.PIGCOP:
				case DefineConstants.EGG:
				case DefineConstants.PIGCOPSTAYPUT:
				case DefineConstants.PIGCOPDIVE:
				case DefineConstants.LIZMAN:
				case DefineConstants.LIZMANSPITTING:
				case DefineConstants.LIZMANFEEDING:
				case DefineConstants.LIZMANJUMP:
				case DefineConstants.ORGANTIC:
				case DefineConstants.BOSS1:
				case DefineConstants.BOSS2:
				case DefineConstants.BOSS3:
				case DefineConstants.BOSS4:
				case DefineConstants.GREENSLIME:
				case DefineConstants.GREENSLIME+1:
				case DefineConstants.GREENSLIME+2:
				case DefineConstants.GREENSLIME+3:
				case DefineConstants.GREENSLIME+4:
				case DefineConstants.GREENSLIME+5:
				case DefineConstants.GREENSLIME+6:
				case DefineConstants.GREENSLIME+7:
				case DefineConstants.RAT:
				case DefineConstants.ROTATEGUN:
					return 1;
		}

		if (actortype[pn] != 0)
		{
			return 1;
		}

		return 0;
	}



	public static void myos(int x, int y, short tilenum, sbyte shade, char orientation)
	{
		int p;
		short a;

		if ((orientation & 4) != 0)
		{
			a = 1024;
		}
		else
		{
			a = 0;
		}

		p = Engine.board.sector[ps[screenpeek].cursectnum].floorpal;
		Engine.rotatesprite(x << 16,y << 16,65536,a,tilenum,shade,(byte)p, (byte)(2 | orientation),Engine._device.windowx1,Engine._device.windowy1,Engine._device.windowx2,Engine._device.windowy2);
	}

	public static void flushperms()
    {

    }

	public static void myospal(int x, int y, int tilenum, int shade, int orientation, int p)
	{
		int fp;
		short a;

		if ((orientation & 4) != 0)
		{
			a = 1024;
		}
		else
		{
			a = 0;
		}

		fp = Engine.board.sector[ps[screenpeek].cursectnum].floorpal;

		Engine.rotatesprite(x << 16,y << 16,65536,a,tilenum,(sbyte)shade, (byte)p, (byte)(2 | orientation), Engine._device.windowx1,Engine._device.windowy1,Engine._device.windowx2,Engine._device.windowy2);

	}

	


	internal static int[] frameval = new int[DefineConstants.AVERAGEFRAMES];
	internal static int framecnt = 0;

	public static void tics()
	{
		int i;
		string b = new string(new char[10]);

		i = totalclock;
		if (i != frameval[framecnt])
		{
// jmarshall - debug
			//sprintf(b,"%ld",(DefineConstants.TICRATE * DefineConstants.AVERAGEFRAMES) / (i - frameval[framecnt]));
			//printext256(Engine._device.windowx1,Engine._device.windowy1,31,-21,b,1);
			frameval[framecnt] = i;
		}

		framecnt = ((framecnt + 1) & (DefineConstants.AVERAGEFRAMES - 1));
	}

	public static void coords(short snum)
	{
		short y = 0;
// jmarshall - debug
/*
		if (ud.coop != 1)
		{
			if (ud.multimode > 1 && ud.multimode < 5)
			{
				y = 8;
			}
			else if (ud.multimode > 4)
			{
				y = 16;
			}
		}

		sprintf(tempbuf,"X= %ld",ps[snum].posx);
		printext256(250,y,31,-1,tempbuf,1);
		sprintf(tempbuf,"Y= %ld",ps[snum].posy);
		printext256(250,y + 7,31,-1,tempbuf,1);
		sprintf(tempbuf,"Z= %ld",ps[snum].posz);
		printext256(250,y + 14,31,-1,tempbuf,1);
		sprintf(tempbuf,"A= %ld",ps[snum].ang);
		printext256(250,y + 21,31,-1,tempbuf,1);
		sprintf(tempbuf,"ZV= %ld",ps[snum].poszv);
		printext256(250,y + 28,31,-1,tempbuf,1);
		sprintf(tempbuf,"OG= %ld",ps[snum].on_ground);
		printext256(250,y + 35,31,-1,tempbuf,1);
		sprintf(tempbuf,"AM= %ld",ps[snum].ammo_amount[DefineConstants.GROW_WEAPON]);
		printext256(250,y + 43,31,-1,tempbuf,1);
		sprintf(tempbuf,"LFW= %ld",ps[snum].last_full_weapon);
		printext256(250,y + 50,31,-1,tempbuf,1);
		sprintf(tempbuf,"SECTL= %ld",Engine.board.sector[ps[snum].cursectnum].lotag);
		printext256(250,y + 57,31,-1,tempbuf,1);
		sprintf(tempbuf,"SEED= %ld",randomseed);
		printext256(250,y + 64,31,-1,tempbuf,1);
		sprintf(tempbuf,"THOLD= %ld",ps[snum].transporter_hold);
		printext256(250,y + 64 + 7,31,-1,tempbuf,1);
*/
	}

	public static void operatefta()
	{
		 int i;
		 int j;
		 int k;

		 if (ud.screen_size > 0)
		 {
			 j = 200 - 45;
		 }
		 else
		 {
			 j = 200 - 8;
		 }
		 quotebot = Math.Min(quotebot,j);
		 quotebotgoal = Math.Min(quotebotgoal,j);
		 if ((ps[myconnectindex].gm & DefineConstants.MODE_TYPE) != 0)
		 {
			 j -= 8;
		 }
		 quotebotgoal = j;
		 j = quotebot;
		 for (i = 0;i < DefineConstants.MAXUSERQUOTES;i++)
		 {
			 k = user_quote_time[i];
			 if (k <= 0)
			 {
				 break;
			 }

			 if (k > 4)
			 {
				  gametext(320 >> 1, j, user_quote[i], 0, (short)(2 + 8 + 16));
			 }
			 else if (k > 2)
			 {
				 gametext(320 >> 1, j, user_quote[i], 0, (short)(2 + 8 + 16 + 1));
			 }
				 else
				 {
					 gametext(320 >> 1, j, user_quote[i], 0, (short)(2 + 8 + 16 + 1 + 32));
				 }
			 j -= 8;
		 }

		 if (ps[screenpeek].fta <= 1)
		 {
			 return;
		 }

		 if (ud.coop != 1 && ud.screen_size > 0 && ud.multimode > 1)
		 {
			 j = 0;
			 k = 8;
			 for (i = connecthead;i >= 0;i = connectpoint2[i])
			 {
				 if (i > j)
				 {
					 j = i;
				 }
			 }

			 if (j >= 4 && j <= 8)
			 {
				 k += 8;
			 }
			 else if (j > 8 && j <= 12)
			 {
				 k += 16;
			 }
			 else if (j > 12)
			 {
				 k += 24;
			 }
		 }
		 else
		 {
			 k = 0;
		 }

		 if (ps[screenpeek].ftq == 115 || ps[screenpeek].ftq == 116)
		 {
			 k = quotebot;
			 for (i = 0;i < DefineConstants.MAXUSERQUOTES;i++)
			 {
				 if (user_quote_time[i] <= 0)
				 {
					 break;
				 }
				 k -= 8;
			 }
			 k -= 4;
		 }

		 j = ps[screenpeek].fta;
		 if (j > 4)
		 {
			  gametext(320 >> 1, k, fta_quotes[ps[screenpeek].ftq], 0, (short)(2 + 8 + 16));
		 }
		 else
		 {
			 if (j > 2)
			 {
				 gametext(320 >> 1, k, fta_quotes[ps[screenpeek].ftq], 0, (short)(2 + 8 + 16 + 1));
			 }
		 else
		 {
			 gametext(320 >> 1, k, fta_quotes[ps[screenpeek].ftq], 0, (short)(2 + 8 + 16 + 1 + 32));
		 }
		 }
	}

	public static void FTA(short q, player_struct p)
	{
		if (ud.fta_on == 1)
		{
			if (p.fta > 0 && q != 115 && q != 116)
			{
				if (p.ftq == 115 || p.ftq == 116)
				{
					return;
				}
			}

			p.fta = 100;

			if (p.ftq != q || q == 26)
			{
			// || q == 26 || q == 115 || q ==116 || q == 117 || q == 122 )
				p.ftq = q;
				pub = (char)DefineConstants.NUMPAGES;
				pus = (char)DefineConstants.NUMPAGES;
			}
		}
	}

	public static short LocateTheLocator(short n, short sn)
	{
		int i;

		i = Engine.board.headspritestat[7];
		while (i >= 0)
		{
			if ((sn == -1 || sn == Engine.board.sprite[i].sectnum) && n == Engine.board.sprite[i].lotag)
			{
				return (short)i;
			}
			i = Engine.board.nextspritestat[i];
		}
		return -1;
	}

	public static short EGS(int whatsect, long s_x, long s_y, long s_z, long s_pn, long s_s, long s_xr, long s_yr, long s_a, long s_ve, long s_zv, long s_ow, long s_ss)
	{
		int i;
		spritetype s;

		i = Engine.board.insertsprite((short)whatsect, (short)s_ss);

		if (i < 0)
		{
			throw new Exception(" Too many sprites spawned.");
		}

		hittype[i] = new weaponhit();

		hittype[i].bposx = (short)s_x;
		hittype[i].bposy = (short)s_y;
		hittype[i].bposz = (short)s_z;

		s = Engine.board.sprite[i];

		s.x = (int)s_x;
		s.y = (int)s_y;
		s.z = (int)s_z;
		s.cstat = 0;
		s.picnum = (short)s_pn;
		s.shade = (sbyte)s_s;
		s.xrepeat = (byte)s_xr;
		s.yrepeat = (byte)s_yr;
		s.pal = 0;

		s.ang = (short)s_a;
		s.xvel = (short)s_ve;
		s.zvel = (short)s_zv;
		s.owner = (short)s_ow;
		s.xoffset = 0;
		s.yoffset = 0;
		s.yvel = 0;
		s.clipdist = 0;
		s.pal = 0;
		s.lotag = 0;

		hittype[i].picnum = Engine.board.sprite[s_ow].picnum;

		hittype[i].lastvx = 0;
		hittype[i].lastvy = 0;

		hittype[i].timetosleep = 0;
		hittype[i].actorstayput = -1;
		hittype[i].extra = -1;
		hittype[i].owner = (short)s_ow;
		hittype[i].cgg = (char)0;
		hittype[i].movflag = 0;
		hittype[i].tempang = 0;
		hittype[i].dispicnum = 0;
		hittype[i].floorz = hittype[s_ow].floorz;
		hittype[i].ceilingz = hittype[s_ow].ceilingz;

		hittype[i].temp_data[0] = hittype[i].temp_data[2] = hittype[i].temp_data[3] = hittype[i].temp_data[5] = 0;
		if (actorscrptr[s_pn] != 0)
		{
			s.extra = (short)scriptptr.buffer[actorscrptr[s_pn]];
			hittype[i].temp_data[4] = scriptptr.buffer[actorscrptr[s_pn + 1]]; //*(actorscrptr[s_pn] + 1);
			hittype[i].temp_data[1] = scriptptr.buffer[actorscrptr[s_pn + 2]]; //* (actorscrptr[s_pn] + 2);
			s.hitag = (short)scriptptr.buffer[actorscrptr[s_pn + 3]]; //*(actorscrptr[s_pn] + 3);
		}
		else
		{
			hittype[i].temp_data[1] = hittype[i].temp_data[4] = 0;
			s.extra = 0;
			s.hitag = 0;
		}
// jmarshall - automap
		//if ((show2dEngine.board.sector[Engine.board.sprite[i].sectnum >> 3] & (1 << (Engine.board.sprite[i].sectnum & 7))) != 0)
		//{
		//	show2dsprite[i >> 3] |= (1 << (i & 7));
		//}
		//else
		//{
		//	show2dsprite[i >> 3] &= ~(1 << (i & 7));
		//}
// jmarshall end
		/*
			if(s->sectnum < 0)
			{
				s->xrepeat = s->yrepeat = 0;
				changespritestat(i,5);
			}
		*/
		return (short)(i);
	}

	public static char wallswitchcheck(short i)
	{
		switch (Engine.board.sprite[i].picnum)
		{
			case DefineConstants.HANDPRINTSWITCH:
			case DefineConstants.HANDPRINTSWITCH + 1:
			case DefineConstants.ALIENSWITCH:
			case DefineConstants.ALIENSWITCH + 1:
			case DefineConstants.MULTISWITCH:
			case DefineConstants.MULTISWITCH + 1:
			case DefineConstants.MULTISWITCH + 2:
			case DefineConstants.MULTISWITCH + 3:
			case DefineConstants.ACCESSSWITCH:
			case DefineConstants.ACCESSSWITCH2:
			case DefineConstants.PULLSWITCH:
			case DefineConstants.PULLSWITCH + 1:
			case DefineConstants.HANDSWITCH:
			case DefineConstants.HANDSWITCH + 1:
			case DefineConstants.SLOTDOOR:
			case DefineConstants.SLOTDOOR + 1:
			case DefineConstants.LIGHTSWITCH:
			case DefineConstants.LIGHTSWITCH + 1:
			case DefineConstants.SPACELIGHTSWITCH:
			case DefineConstants.SPACELIGHTSWITCH + 1:
			case DefineConstants.SPACEDOORSWITCH:
			case DefineConstants.SPACEDOORSWITCH + 1:
			case DefineConstants.FRANKENSTINESWITCH:
			case DefineConstants.FRANKENSTINESWITCH + 1:
			case DefineConstants.LIGHTSWITCH2:
			case DefineConstants.LIGHTSWITCH2 + 1:
			case DefineConstants.POWERSWITCH1:
			case DefineConstants.POWERSWITCH1 + 1:
			case DefineConstants.LOCKSWITCH1:
			case DefineConstants.LOCKSWITCH1 + 1:
			case DefineConstants.POWERSWITCH2:
			case DefineConstants.POWERSWITCH2 + 1:
			case DefineConstants.DIPSWITCH:
			case DefineConstants.DIPSWITCH + 1:
			case DefineConstants.DIPSWITCH2:
			case DefineConstants.DIPSWITCH2 + 1:
			case DefineConstants.TECHSWITCH:
			case DefineConstants.TECHSWITCH + 1:
			case DefineConstants.DIPSWITCH3:
			case DefineConstants.DIPSWITCH3 + 1:
				return (char)1;
		}
		return (char)0;
	}


	public static int tempwallptr;
	public static short spawn(short j, short pn)
	{
		short i;
		short s;
		short startwall;
		short endwall;
		short sect;
		short clostest = 0;
		int x;
		int y;
		int d;
		spritetype sp;

		if (j >= 0)
		{
			i = EGS(Engine.board.sprite[j].sectnum, Engine.board.sprite[j].x, Engine.board.sprite[j].y, Engine.board.sprite[j].z, pn, 0, 0, 0, 0, 0, 0, j, 0);
			hittype[i].picnum = Engine.board.sprite[j].picnum;
		}
		else
		{
			i = pn;

			hittype[i] = new weaponhit();

			hittype[i].picnum = Engine.board.sprite[i].picnum;
			hittype[i].timetosleep = 0;
			hittype[i].extra = -1;

			hittype[i].bposx = Engine.board.sprite[i].x;
			hittype[i].bposy = Engine.board.sprite[i].y;
			hittype[i].bposz = Engine.board.sprite[i].z;

			Engine.board.sprite[i].owner = hittype[i].owner = i;
			hittype[i].cgg = (char)0;
			hittype[i].movflag = 0;
			hittype[i].tempang = 0;
			hittype[i].dispicnum = 0;
			hittype[i].floorz = Engine.board.sector[Engine.board.sprite[i].sectnum].floorz;
			hittype[i].ceilingz = Engine.board.sector[Engine.board.sprite[i].sectnum].ceilingz;

			hittype[i].lastvx = 0;
			hittype[i].lastvy = 0;
			hittype[i].actorstayput = -1;

			hittype[i].temp_data[0] = hittype[i].temp_data[1] = hittype[i].temp_data[2] = hittype[i].temp_data[3] = hittype[i].temp_data[4] = hittype[i].temp_data[5] = 0;

			if (Engine.board.sprite[i].picnum != DefineConstants.SPEAKER && Engine.board.sprite[i].picnum != DefineConstants.LETTER && Engine.board.sprite[i].picnum != DefineConstants.DUCK && Engine.board.sprite[i].picnum != DefineConstants.TARGET && Engine.board.sprite[i].picnum != DefineConstants.TRIPBOMB && Engine.board.sprite[i].picnum != DefineConstants.VIEWSCREEN && Engine.board.sprite[i].picnum != DefineConstants.VIEWSCREEN2 && (Engine.board.sprite[i].cstat & 48) != 0)
			{
				if (!(Engine.board.sprite[i].picnum >= DefineConstants.CRACK1 && Engine.board.sprite[i].picnum <= DefineConstants.CRACK4))
				{
					if (Engine.board.sprite[i].shade == 127)
					{
						return i;
					}
					if (wallswitchcheck(i) == 1 && (Engine.board.sprite[i].cstat & 16) != 0)
					{
						if (Engine.board.sprite[i].picnum != DefineConstants.ACCESSSWITCH && Engine.board.sprite[i].picnum != DefineConstants.ACCESSSWITCH2 && Engine.board.sprite[i].pal != 0)
						{
							if ((ud.multimode < 2) || (ud.multimode > 1 && ud.coop == 1))
							{
								Engine.board.sprite[i].xrepeat = Engine.board.sprite[i].yrepeat = 0;
								Engine.board.sprite[i].cstat = Engine.board.sprite[i].lotag = Engine.board.sprite[i].hitag = 0;
								return i;
							}
						}
						Engine.board.sprite[i].cstat |= 257;
						if (Engine.board.sprite[i].pal != 0 && Engine.board.sprite[i].picnum != DefineConstants.ACCESSSWITCH && Engine.board.sprite[i].picnum != DefineConstants.ACCESSSWITCH2)
						{
							Engine.board.sprite[i].pal = 0;
						}
						return i;
					}

					if (Engine.board.sprite[i].hitag != 0)
					{
						Engine.board.changespritestat(i, 12);
						Engine.board.sprite[i].cstat |= 257;
						Engine.board.sprite[i].extra = (short)impact_damage;
						return i;
					}
				}
			}

			s = Engine.board.sprite[i].picnum;

			if ((Engine.board.sprite[i].cstat & 1) != 0)
			{
				Engine.board.sprite[i].cstat |= 256;
			}

			if (actorscrptr[s] != 0)
			{
				Engine.board.sprite[i].extra = (short)scriptptr.buffer[actorscrptr[s]];
				hittype[i].temp_data[4] = (short)scriptptr.buffer[actorscrptr[s + 1]];
				hittype[i].temp_data[1] = (short)scriptptr.buffer[actorscrptr[s + 2]];
				if (scriptptr.buffer[actorscrptr[s + 3]] != 0 && Engine.board.sprite[i].hitag == 0)
				{
					Engine.board.sprite[i].hitag = (short)scriptptr.buffer[actorscrptr[s + 3]];
				}
			}
			else
			{
				hittype[i].temp_data[1] = hittype[i].temp_data[4] = 0;
			}
		}

		sp = Engine.board.sprite[i];
		sect = sp.sectnum;

		switch (sp.picnum)
		{
			default:

				if (actorscrptr[sp.picnum] != 0)
				{
					if (j == -1 && sp.lotag > ud.player_skill)
					{
						sp.xrepeat = sp.yrepeat = 0;
						Engine.board.changespritestat(i, 5);
						break;
					}

					//  Init the size
					if (sp.xrepeat == 0 || sp.yrepeat == 0)
					{
						sp.xrepeat = sp.yrepeat = 1;
					}

					if ((actortype[sp.picnum] & 3) != 0)
					{
						if (ud.monsters_off == 1)
						{
							sp.xrepeat = sp.yrepeat = 0;
							Engine.board.changespritestat(i, 5);
							break;
						}

						makeitfall(i);

						if ((actortype[sp.picnum] & 2) != 0)
						{
							hittype[i].actorstayput = sp.sectnum;
						}

						ps[myconnectindex].max_actors_killed++;
						sp.clipdist = 80;
						if (j >= 0)
						{
							if (Engine.board.sprite[j].picnum == DefineConstants.RESPAWN)
							{
								hittype[i].tempang = Engine.board.sprite[i].pal = Engine.board.sprite[j].pal;
							}
							Engine.board.changespritestat(i, 1);
						}
						else
						{
							Engine.board.changespritestat(i, 2);
						}
					}
					else
					{
						sp.clipdist = 40;
						sp.owner = i;
						Engine.board.changespritestat(i, 1);
					}

					hittype[i].timetosleep = 0;

					if (j >= 0)
					{
						sp.ang = Engine.board.sprite[j].ang;
					}
				}
				break;
			case DefineConstants.FOF:
				sp.xrepeat = sp.yrepeat = 0;
				Engine.board.changespritestat(i, 5);
				break;
			case DefineConstants.WATERSPLASH2:
				if (j >= 0)
				{
					Engine.board.setsprite(i, Engine.board.sprite[j].x, Engine.board.sprite[j].y, Engine.board.sprite[j].z);
					sp.xrepeat = sp.yrepeat = (byte)(8 + (Engine.krand() & 7));
				}
				else
				{
					sp.xrepeat = sp.yrepeat = (byte)(16 + (Engine.krand() & 15));
				}

				sp.shade = -16;
				sp.cstat |= 128;
				if (j >= 0)
				{
					if (Engine.board.sector[Engine.board.sprite[j].sectnum].lotag == 2)
					{
						sp.z = Engine.board.getceilzofslope(Engine.board.sprite[i].sectnum, Engine.board.sprite[i].x, Engine.board.sprite[i].y) + (16 << 8);
						sp.cstat |= 8;
					}
					else if (Engine.board.sector[Engine.board.sprite[j].sectnum].lotag == 1)
					{
						sp.z = Engine.board.getflorzofslope(Engine.board.sprite[i].sectnum, Engine.board.sprite[i].x, Engine.board.sprite[i].y);
					}
				}

				if (Engine.board.sector[sect].floorpicnum == DefineConstants.FLOORSLIME || Engine.board.sector[sect].ceilingpicnum == DefineConstants.FLOORSLIME)
				{
					sp.pal = 7;
				}
				goto case DefineConstants.NEON1;
			case DefineConstants.NEON1:
			case DefineConstants.NEON2:
			case DefineConstants.NEON3:
			case DefineConstants.NEON4:
			case DefineConstants.NEON5:
			case DefineConstants.NEON6:
			case DefineConstants.DOMELITE:
				if (sp.picnum != DefineConstants.WATERSPLASH2)
				{
					sp.cstat |= 257;
				}
				goto case DefineConstants.NUKEBUTTON;
			case DefineConstants.NUKEBUTTON:
				if (sp.picnum == DefineConstants.DOMELITE)
				{
					sp.cstat |= 257;
				}
				goto case DefineConstants.JIBS1;
			case DefineConstants.JIBS1:
			case DefineConstants.JIBS2:
			case DefineConstants.JIBS3:
			case DefineConstants.JIBS4:
			case DefineConstants.JIBS5:
			case DefineConstants.JIBS6:
			case DefineConstants.HEADJIB1:
			case DefineConstants.ARMJIB1:
			case DefineConstants.LEGJIB1:
			case DefineConstants.LIZMANHEAD1:
			case DefineConstants.LIZMANARM1:
			case DefineConstants.LIZMANLEG1:
			case DefineConstants.DUKETORSO:
			case DefineConstants.DUKEGUN:
			case DefineConstants.DUKELEG:
				Engine.board.changespritestat(i, 5);
				break;
			case DefineConstants.TONGUE:
				if (j >= 0)
				{
					sp.ang = Engine.board.sprite[j].ang;
				}
				sp.z -= 38 << 8;
				sp.zvel = (short)(256 - (Engine.krand() & 511));
				sp.xvel = (short)(64 - (Engine.krand() & 127));
				Engine.board.changespritestat(i, 4);
				break;
			case DefineConstants.NATURALLIGHTNING:
				sp.cstat &= ~257;
				sp.cstat |= unchecked((short)32768);
				break;
			case DefineConstants.TRANSPORTERSTAR:
			case DefineConstants.TRANSPORTERBEAM:
				if (j == -1)
				{
					break;
				}
				if (sp.picnum == DefineConstants.TRANSPORTERBEAM)
				{
					sp.xrepeat = 31;
					sp.yrepeat = 1;
					sp.z = Engine.board.sector[Engine.board.sprite[j].sectnum].floorz - (40 << 8);
				}
				else
				{
					if (Engine.board.sprite[j].statnum == 4)
					{
						sp.xrepeat = 8;
						sp.yrepeat = 8;
					}
					else
					{
						sp.xrepeat = 48;
						sp.yrepeat = 64;
						if (Engine.board.sprite[j].statnum == 10 || badguy(Engine.board.sprite[j]) != 0)
						{
							sp.z -= (32 << 8);
						}
					}
				}

				sp.shade = -127;
				sp.cstat = (short)(128 | 2);
				sp.ang = Engine.board.sprite[j].ang;

				sp.xvel = 128;
				Engine.board.changespritestat(i, 5);
				ssp(i, (uint)(((1) << 16) + 1));
				Engine.board.setsprite(i, sp.x, sp.y, sp.z);
				break;

			case DefineConstants.FRAMEEFFECT1:
				if (j >= 0)
				{
					sp.xrepeat = Engine.board.sprite[j].xrepeat;
					sp.yrepeat = Engine.board.sprite[j].yrepeat;
					hittype[i].temp_data[1] = Engine.board.sprite[j].picnum;
				}
				else
				{
					sp.xrepeat = sp.yrepeat = 0;
				}

				Engine.board.changespritestat(i, 5);

				break;

			case DefineConstants.LASERLINE:
				sp.yrepeat = 6;
				sp.xrepeat = 32;

				if (lasermode == 1)
				{
					sp.cstat = (short)(16 + 2);
				}
				else if (lasermode == 0 || lasermode == 2)
				{
					sp.cstat = 16;
				}
				else
				{
					sp.xrepeat = 0;
					sp.yrepeat = 0;
				}

				if (j >= 0)
				{
					sp.ang = (short)(hittype[j].temp_data[5] + 512);
				}
				Engine.board.changespritestat(i, 5);
				break;

			case DefineConstants.FORCESPHERE:
				if (j == -1)
				{
					sp.cstat = unchecked((short)32768);
					Engine.board.changespritestat(i, 2);
				}
				else
				{
					sp.xrepeat = sp.yrepeat = 1;
					Engine.board.changespritestat(i, 5);
				}
				break;

			case DefineConstants.BLOOD:
				sp.xrepeat = sp.yrepeat = 16;
				sp.z -= (26 << 8);
				if (j >= 0 && Engine.board.sprite[j].pal == 6)
				{
					sp.pal = 6;
				}
				Engine.board.changespritestat(i, 5);
				break;
			case DefineConstants.BLOODPOOL:
			case DefineConstants.PUKE:
				{
					short s1;
					s1 = sp.sectnum;

					Engine.board.updatesector(sp.x + 108, sp.y + 108, ref s1);
					if (s1 >= 0 && Engine.board.sector[s1].floorz == Engine.board.sector[sp.sectnum].floorz)
					{
						Engine.board.updatesector(sp.x - 108, sp.y - 108, ref s1);
						if (s1 >= 0 && Engine.board.sector[s1].floorz == Engine.board.sector[sp.sectnum].floorz)
						{
							Engine.board.updatesector(sp.x + 108, sp.y - 108, ref s1);
							if (s1 >= 0 && Engine.board.sector[s1].floorz == Engine.board.sector[sp.sectnum].floorz)
							{
								Engine.board.updatesector(sp.x - 108, sp.y + 108, ref s1);
								if (s1 >= 0 && Engine.board.sector[s1].floorz != Engine.board.sector[sp.sectnum].floorz)
								{
									sp.xrepeat = sp.yrepeat = 0;
									Engine.board.changespritestat(i, 5);
									break;
								}
							}
							else
							{
								sp.xrepeat = sp.yrepeat = 0;
								Engine.board.changespritestat(i, 5);
								break;
							}
						}
						else
						{
							sp.xrepeat = sp.yrepeat = 0;
							Engine.board.changespritestat(i, 5);
							break;
						}
					}
					else
					{
						sp.xrepeat = sp.yrepeat = 0;
						Engine.board.changespritestat(i, 5);
						break;
					}
				}

				if (Engine.board.sector[Engine.board.sprite[i].sectnum].lotag == 1)
				{
					Engine.board.changespritestat(i, 5);
					break;
				}

				if (j >= 0 && sp.picnum != DefineConstants.PUKE)
				{
					if (Engine.board.sprite[j].pal == 1)
					{
						sp.pal = 1;
					}
					else if (Engine.board.sprite[j].pal != 6 && Engine.board.sprite[j].picnum != DefineConstants.NUKEBARREL && Engine.board.sprite[j].picnum != DefineConstants.TIRE)
					{
						if (Engine.board.sprite[j].picnum == DefineConstants.FECES)
						{
							sp.pal = 7; // Brown
						}
						else
						{
							sp.pal = 2; // Red
						}
					}
					else
					{
						sp.pal = 0; // green
					}

					if (Engine.board.sprite[j].picnum == DefineConstants.TIRE)
					{
						sp.shade = 127;
					}
				}
				sp.cstat |= 32;
				goto case DefineConstants.FECES;
			case DefineConstants.FECES:
				if (j >= 0)
				{
					sp.xrepeat = sp.yrepeat = 1;
				}
				Engine.board.changespritestat(i, 5);
				break;

			case DefineConstants.BLOODSPLAT1:
			case DefineConstants.BLOODSPLAT2:
			case DefineConstants.BLOODSPLAT3:
			case DefineConstants.BLOODSPLAT4:
				sp.cstat |= 16;
				sp.xrepeat = (byte)(7 + (Engine.krand() & 7));
				sp.yrepeat = (byte)(7 + (Engine.krand() & 7));
				sp.z -= (16 << 8);
				if (j >= 0 && Engine.board.sprite[j].pal == 6)
				{
					sp.pal = 6;
				}
				insertspriteq(i);
				Engine.board.changespritestat(i, 5);
				break;

			case DefineConstants.TRIPBOMB:
				if (sp.lotag > ud.player_skill)
				{
					sp.xrepeat = sp.yrepeat = 0;
					Engine.board.changespritestat(i, 5);
					break;
				}

				sp.xrepeat = 4;
				sp.yrepeat = 5;

				sp.owner = i;
				sp.hitag = i;

				sp.xvel = 16;
				ssp(i, (uint)(((1) << 16) + 1));
				hittype[i].temp_data[0] = 17;
				hittype[i].temp_data[2] = 0;
				hittype[i].temp_data[5] = sp.ang;

				goto case DefineConstants.SPACEMARINE;
			case DefineConstants.SPACEMARINE:
				if (sp.picnum == DefineConstants.SPACEMARINE)
				{
					sp.extra = 20;
					sp.cstat |= 257;
				}
				Engine.board.changespritestat(i, 2);
				break;

			case DefineConstants.HYDRENT:
			case DefineConstants.PANNEL1:
			case DefineConstants.PANNEL2:
			case DefineConstants.SATELITE:
			case DefineConstants.FUELPOD:
			case DefineConstants.SOLARPANNEL:
			case DefineConstants.ANTENNA:
			case DefineConstants.GRATE1:
			case DefineConstants.CHAIR1:
			case DefineConstants.CHAIR2:
			case DefineConstants.CHAIR3:
			case DefineConstants.BOTTLE1:
			case DefineConstants.BOTTLE2:
			case DefineConstants.BOTTLE3:
			case DefineConstants.BOTTLE4:
			case DefineConstants.BOTTLE5:
			case DefineConstants.BOTTLE6:
			case DefineConstants.BOTTLE7:
			case DefineConstants.BOTTLE8:
			case DefineConstants.BOTTLE10:
			case DefineConstants.BOTTLE11:
			case DefineConstants.BOTTLE12:
			case DefineConstants.BOTTLE13:
			case DefineConstants.BOTTLE14:
			case DefineConstants.BOTTLE15:
			case DefineConstants.BOTTLE16:
			case DefineConstants.BOTTLE17:
			case DefineConstants.BOTTLE18:
			case DefineConstants.BOTTLE19:
			case DefineConstants.OCEANSPRITE1:
			case DefineConstants.OCEANSPRITE2:
			case DefineConstants.OCEANSPRITE3:
			case DefineConstants.OCEANSPRITE5:
			case DefineConstants.MONK:
			case DefineConstants.INDY:
			case DefineConstants.LUKE:
			case DefineConstants.JURYGUY:
			case DefineConstants.SCALE:
			case DefineConstants.VACUUM:
			case DefineConstants.FANSPRITE:
			case DefineConstants.CACTUS:
			case DefineConstants.CACTUSBROKE:
			case DefineConstants.HANGLIGHT:
			case DefineConstants.FETUS:
			case DefineConstants.FETUSBROKE:
			case DefineConstants.CAMERALIGHT:
			case DefineConstants.MOVIECAMERA:
			case DefineConstants.IVUNIT:
			case DefineConstants.POT1:
			case DefineConstants.POT2:
			case DefineConstants.POT3:
			case DefineConstants.TRIPODCAMERA:
			case DefineConstants.SUSHIPLATE1:
			case DefineConstants.SUSHIPLATE2:
			case DefineConstants.SUSHIPLATE3:
			case DefineConstants.SUSHIPLATE4:
			case DefineConstants.SUSHIPLATE5:
			case DefineConstants.WAITTOBESEATED:
			case DefineConstants.VASE:
			case DefineConstants.PIPE1:
			case DefineConstants.PIPE2:
			case DefineConstants.PIPE3:
			case DefineConstants.PIPE4:
			case DefineConstants.PIPE5:
			case DefineConstants.PIPE6:
				sp.clipdist = 32;
				sp.cstat |= 257;
				goto case DefineConstants.OCEANSPRITE4;
			case DefineConstants.OCEANSPRITE4:
				Engine.board.changespritestat(i, 0);
				break;
			case DefineConstants.FEMMAG1:
			case DefineConstants.FEMMAG2:
				sp.cstat &= ~257;
				Engine.board.changespritestat(i, 0);
				break;
			case DefineConstants.DUKETAG:
			case DefineConstants.SIGN1:
			case DefineConstants.SIGN2:
				if (ud.multimode < 2 && sp.pal != 0)
				{
					sp.xrepeat = sp.yrepeat = 0;
					Engine.board.changespritestat(i, 5);
				}
				else
				{
					sp.pal = 0;
				}
				break;
			case DefineConstants.MASKWALL1:
			case DefineConstants.MASKWALL2:
			case DefineConstants.MASKWALL3:
			case DefineConstants.MASKWALL4:
			case DefineConstants.MASKWALL5:
			case DefineConstants.MASKWALL6:
			case DefineConstants.MASKWALL7:
			case DefineConstants.MASKWALL8:
			case DefineConstants.MASKWALL9:
			case DefineConstants.MASKWALL10:
			case DefineConstants.MASKWALL11:
			case DefineConstants.MASKWALL12:
			case DefineConstants.MASKWALL13:
			case DefineConstants.MASKWALL14:
			case DefineConstants.MASKWALL15:
				j = (short)(sp.cstat & 60);
				sp.cstat = (short)(j | 1);
				Engine.board.changespritestat(i, 0);
				break;
			case DefineConstants.FOOTPRINTS:
			case DefineConstants.FOOTPRINTS2:
			case DefineConstants.FOOTPRINTS3:
			case DefineConstants.FOOTPRINTS4:
				if (j >= 0)
				{
					short s1;
					s1 = sp.sectnum;

					Engine.board.updatesector(sp.x + 84, sp.y + 84, ref s1);
					if (s1 >= 0 && Engine.board.sector[s1].floorz == Engine.board.sector[sp.sectnum].floorz)
					{
						Engine.board.updatesector(sp.x - 84, sp.y - 84, ref s1);
						if (s1 >= 0 && Engine.board.sector[s1].floorz == Engine.board.sector[sp.sectnum].floorz)
						{
							Engine.board.updatesector(sp.x + 84, sp.y - 84, ref s1);
							if (s1 >= 0 && Engine.board.sector[s1].floorz == Engine.board.sector[sp.sectnum].floorz)
							{
								Engine.board.updatesector(sp.x - 84, sp.y + 84, ref s1);
								if (s1 >= 0 && Engine.board.sector[s1].floorz != Engine.board.sector[sp.sectnum].floorz)
								{
									sp.xrepeat = sp.yrepeat = 0;
									Engine.board.changespritestat(i, 5);
									break;
								}
							}
							else
							{
								sp.xrepeat = sp.yrepeat = 0;
								break;
							}
						}
						else
						{
							sp.xrepeat = sp.yrepeat = 0;
							break;
						}
					}
					else
					{
						sp.xrepeat = sp.yrepeat = 0;
						break;
					}

					sp.cstat = (short)(32 + ((ps[Engine.board.sprite[j].yvel].footprintcount & 1) << 2));
					sp.ang = Engine.board.sprite[j].ang;
				}

				sp.z = Engine.board.sector[sect].floorz;
				if (Engine.board.sector[sect].lotag != 1 && Engine.board.sector[sect].lotag != 2)
				{
					sp.xrepeat = sp.yrepeat = 32;
				}

				insertspriteq(i);
				Engine.board.changespritestat(i, 5);
				break;

			case DefineConstants.FEM1:
			case DefineConstants.FEM2:
			case DefineConstants.FEM3:
			case DefineConstants.FEM4:
			case DefineConstants.FEM5:
			case DefineConstants.FEM6:
			case DefineConstants.FEM7:
			case DefineConstants.FEM8:
			case DefineConstants.FEM9:
			case DefineConstants.FEM10:
			case DefineConstants.PODFEM1:
			case DefineConstants.NAKED1:
			case DefineConstants.STATUE:
			case DefineConstants.TOUGHGAL:
				sp.yvel = sp.hitag;
				sp.hitag = -1;
				if (sp.picnum == DefineConstants.PODFEM1)
				{
					sp.extra <<= 1;
				}
				goto case DefineConstants.BLOODYPOLE;
			case DefineConstants.BLOODYPOLE:
			case DefineConstants.QUEBALL:
			case DefineConstants.STRIPEBALL:

				if (sp.picnum == DefineConstants.QUEBALL || sp.picnum == DefineConstants.STRIPEBALL)
				{
					sp.cstat = 256;
					sp.clipdist = 8;
				}
				else
				{
					sp.cstat |= 257;
					sp.clipdist = 32;
				}

				Engine.board.changespritestat(i, 2);
				break;

			case DefineConstants.DUKELYINGDEAD:
				if (j >= 0 && Engine.board.sprite[j].picnum == DefineConstants.APLAYER)
				{
					sp.xrepeat = Engine.board.sprite[j].xrepeat;
					sp.yrepeat = Engine.board.sprite[j].yrepeat;
					sp.shade = Engine.board.sprite[j].shade;
					sp.pal = (byte)ps[Engine.board.sprite[j].yvel].palookup;
				}
				goto case DefineConstants.DUKECAR;
			case DefineConstants.DUKECAR:
			case DefineConstants.HELECOPT:
				//                if(sp->picnum == HELECOPT || sp->picnum == DUKECAR) sp->xvel = 1024;
				sp.cstat = 0;
				sp.extra = 1;
				sp.xvel = 292;
				sp.zvel = 360;
				goto case DefineConstants.RESPAWNMARKERRED;
			case DefineConstants.RESPAWNMARKERRED:
			case DefineConstants.BLIMP:

				if (sp.picnum == DefineConstants.RESPAWNMARKERRED)
				{
					sp.xrepeat = sp.yrepeat = 24;
					if (j >= 0)
					{
						sp.z = hittype[j].floorz; // -(1<<4);
					}
				}
				else
				{
					sp.cstat |= 257;
					sp.clipdist = 128;
				}
				goto case DefineConstants.MIKE;
			case DefineConstants.MIKE:
				if (sp.picnum == DefineConstants.MIKE)
				{
					sp.yvel = sp.hitag;
				}
				goto case DefineConstants.WEATHERWARN;
			case DefineConstants.WEATHERWARN:
				Engine.board.changespritestat(i, 1);
				break;

			case DefineConstants.SPOTLITE:
				hittype[i].temp_data[0] = sp.x;
				hittype[i].temp_data[1] = sp.y;
				break;
			case DefineConstants.BULLETHOLE:
				sp.xrepeat = sp.yrepeat = 3;
				sp.cstat = (short)(16 + (Engine.krand() & 12));
				insertspriteq(i);
				goto case DefineConstants.MONEY;
			case DefineConstants.MONEY:
			case DefineConstants.MAIL:
			case DefineConstants.PAPER:
				if (sp.picnum == DefineConstants.MONEY || sp.picnum == DefineConstants.MAIL || sp.picnum == DefineConstants.PAPER)
				{
					hittype[i].temp_data[0] = (short)(Engine.krand() & 2047);
					sp.cstat = (short)(Engine.krand() & 12);
					sp.xrepeat = sp.yrepeat = 8;
					sp.ang = (short)(Engine.krand() & 2047);
				}
				Engine.board.changespritestat(i, 5);
				break;

			case DefineConstants.VIEWSCREEN:
			case DefineConstants.VIEWSCREEN2:
				sp.owner = i;
				sp.lotag = 1;
				sp.extra = 1;
				Engine.board.changespritestat(i, 6);
				break;

			case DefineConstants.SHELL: //From the player
			case DefineConstants.SHOTGUNSHELL:
				if (j >= 0)
				{
					short snum;
					short a;

					if (Engine.board.sprite[j].picnum == DefineConstants.APLAYER)
					{
						snum = Engine.board.sprite[j].yvel;
						a = (short)(ps[snum].ang - (Engine.krand() & 63) + 8); //Fine tune

						hittype[i].temp_data[0] = (short)(Engine.krand() & 1);
						if (sp.picnum == DefineConstants.SHOTGUNSHELL)
						{
							sp.z = (6 << 8) + ps[snum].pyoff + ps[snum].posz - ((ps[snum].horizoff + ps[snum].horiz - 100) << 4);
						}
						else
						{
							sp.z = (3 << 8) + ps[snum].pyoff + ps[snum].posz - ((ps[snum].horizoff + ps[snum].horiz - 100) << 4);
						}
						sp.zvel = (short)(-(Engine.krand() & 255));
					}
					else
					{
						a = sp.ang;
						sp.z = Engine.board.sprite[j].z - (38 << 8) + (3 << 8);
					}

					sp.x = Engine.board.sprite[j].x + (Engine.table.sintable[(a + 512) & 2047] >> 7);
					sp.y = Engine.board.sprite[j].y + (Engine.table.sintable[a & 2047] >> 7);

					sp.shade = -8;

					sp.ang = (short)(a - 512);
					sp.xvel = 20;

					sp.xrepeat = sp.yrepeat = 4;

					Engine.board.changespritestat(i, 5);
				}
				break;

			case DefineConstants.RESPAWN:
				sp.extra = (short)(66 - 13);
				goto case DefineConstants.MUSICANDSFX;
			case DefineConstants.MUSICANDSFX:
				if (ud.multimode < 2 && sp.pal == 1)
				{
					sp.xrepeat = sp.yrepeat = 0;
					Engine.board.changespritestat(i, 5);
					break;
				}
				sp.cstat = unchecked((short)32768);
				Engine.board.changespritestat(i, 11);
				break;

			case DefineConstants.EXPLOSION2:
			case DefineConstants.EXPLOSION2BOT:
			case DefineConstants.BURNING:
			case DefineConstants.BURNING2:
			case DefineConstants.SMALLSMOKE:
			case DefineConstants.SHRINKEREXPLOSION:
			case DefineConstants.COOLEXPLOSION1:

				if (j >= 0)
				{
					sp.ang = Engine.board.sprite[j].ang;
					sp.shade = -64;
					sp.cstat = (short)(128 | (Engine.krand() & 4));
				}

				if (sp.picnum == DefineConstants.EXPLOSION2 || sp.picnum == DefineConstants.EXPLOSION2BOT)
				{
					sp.xrepeat = 48;
					sp.yrepeat = 48;
					sp.shade = -127;
					sp.cstat |= 128;
				}
				else if (sp.picnum == DefineConstants.SHRINKEREXPLOSION)
				{
					sp.xrepeat = 32;
					sp.yrepeat = 32;
				}
				else if (sp.picnum == DefineConstants.SMALLSMOKE)
				{
					// 64 "money"
					sp.xrepeat = 24;
					sp.yrepeat = 24;
				}
				else if (sp.picnum == DefineConstants.BURNING || sp.picnum == DefineConstants.BURNING2)
				{
					sp.xrepeat = 4;
					sp.yrepeat = 4;
				}

				if (j >= 0)
				{
					x = Engine.board.getflorzofslope(sp.sectnum, sp.x, sp.y);
					if (sp.z > x - (12 << 8))
					{
						sp.z = x - (12 << 8);
					}
				}

				Engine.board.changespritestat(i, 5);

				break;

			case DefineConstants.PLAYERONWATER:
				if (j >= 0)
				{
					sp.xrepeat = Engine.board.sprite[j].xrepeat;
					sp.yrepeat = Engine.board.sprite[j].yrepeat;
					sp.zvel = 128;
					if (Engine.board.sector[sp.sectnum].lotag != 2)
					{
						sp.cstat |= unchecked((short)32768);
					}
				}
				Engine.board.changespritestat(i, 13);
				break;

			case DefineConstants.APLAYER:
				sp.xrepeat = sp.yrepeat = 0;
				j = (byte)ud.coop;
				if (j == 2)
				{
					j = 0;
				}

				if (ud.multimode < 2 || (ud.multimode > 1 && j != sp.lotag))
				{
					Engine.board.changespritestat(i, 5);
				}
				else
				{
					Engine.board.changespritestat(i, 10);
				}
				break;
			case DefineConstants.WATERBUBBLE:
				if (j >= 0 && Engine.board.sprite[j].picnum == DefineConstants.APLAYER)
				{
					sp.z -= (16 << 8);
				}
				if (sp.picnum == DefineConstants.WATERBUBBLE)
				{
					if (j >= 0)
					{
						sp.ang = Engine.board.sprite[j].ang;
					}
					sp.xrepeat = sp.yrepeat = 4;
				}
				else
				{
					sp.xrepeat = sp.yrepeat = 32;
				}

				Engine.board.changespritestat(i, 5);
				break;

			case DefineConstants.CRANE:

				sp.cstat |= 64 | 257;

				sp.picnum += 2;
				sp.z = Engine.board.sector[sect].ceilingz + (48 << 8);
				hittype[i].temp_data[4] = tempwallptr;

				msx[tempwallptr] = sp.x;
				msy[tempwallptr] = sp.y;
				msx[tempwallptr + 2] = sp.z;

				s = (short)Engine.board.headspritestat[0];
				while (s >= 0)
				{
					if (Engine.board.sprite[s].picnum == DefineConstants.CRANEPOLE && Engine.board.sprite[i].hitag == (Engine.board.sprite[s].hitag))
					{
						msy[tempwallptr + 2] = s;

						hittype[i].temp_data[1] = Engine.board.sprite[s].sectnum;

						Engine.board.sprite[s].xrepeat = 48;
						Engine.board.sprite[s].yrepeat = 128;

						msx[tempwallptr + 1] = Engine.board.sprite[s].x;
						msy[tempwallptr + 1] = Engine.board.sprite[s].y;

						Engine.board.sprite[s].x = sp.x;
						Engine.board.sprite[s].y = sp.y;
						Engine.board.sprite[s].z = sp.z;
						Engine.board.sprite[s].shade = sp.shade;

						Engine.board.setsprite(s, Engine.board.sprite[s].x, Engine.board.sprite[s].y, Engine.board.sprite[s].z);
						break;
					}
					s = (short)Engine.board.nextspritestat[s];
				}

				tempwallptr += 3;
				sp.owner = -1;
				sp.extra = 8;
				Engine.board.changespritestat(i, 6);
				break;

			case DefineConstants.WATERDRIP:
				if (j >= 0 && (Engine.board.sprite[j].statnum == 10 || Engine.board.sprite[j].statnum == 1)) // jmarshall: crash fix j == -1
				{
					sp.shade = 32;
					if (Engine.board.sprite[j].pal != 1)
					{
						sp.pal = 2;
						sp.z -= (18 << 8);
					}
					else
					{
						sp.z -= (13 << 8);
					}
					sp.ang = (short)Engine.getangle(ps[connecthead].posx - sp.x, ps[connecthead].posy - sp.y);
					sp.xvel = (short)(48 - (Engine.krand() & 31));
					ssp(i, (uint)(((1) << 16) + 1));
				}
				else if (j == -1)
				{
					sp.z += (4 << 8);
					hittype[i].temp_data[0] = sp.z;
					hittype[i].temp_data[1] = (short)(Engine.krand() & 127);
				}
				goto case DefineConstants.TRASH;
			case DefineConstants.TRASH:

				if (sp.picnum != DefineConstants.WATERDRIP)
				{
					sp.ang = (short)(Engine.krand() & 2047);
				}

				goto case DefineConstants.WATERDRIPSPLASH;
			case DefineConstants.WATERDRIPSPLASH:

				sp.xrepeat = 24;
				sp.yrepeat = 24;


				Engine.board.changespritestat(i, 6);
				break;

			case DefineConstants.PLUG:
				sp.lotag = 9999;
				Engine.board.changespritestat(i, 6);
				break;
			case DefineConstants.TOUCHPLATE:
				hittype[i].temp_data[2] = Engine.board.sector[sect].floorz;
				if (Engine.board.sector[sect].lotag != 1 && Engine.board.sector[sect].lotag != 2)
				{
					Engine.board.sector[sect].floorz = sp.z;
				}
				if (sp.pal != 0 && ud.multimode > 1)
				{
					sp.xrepeat = sp.yrepeat = 0;
					Engine.board.changespritestat(i, 5);
					break;
				}
				goto case DefineConstants.WATERBUBBLEMAKER;
			case DefineConstants.WATERBUBBLEMAKER:
				sp.cstat |= unchecked((short)32768);
				Engine.board.changespritestat(i, 6);
				break;
			case DefineConstants.BOLT1:
			case DefineConstants.BOLT1 + 1:
			case DefineConstants.BOLT1 + 2:
			case DefineConstants.BOLT1 + 3:
			case DefineConstants.SIDEBOLT1:
			case DefineConstants.SIDEBOLT1 + 1:
			case DefineConstants.SIDEBOLT1 + 2:
			case DefineConstants.SIDEBOLT1 + 3:
				hittype[i].temp_data[0] = sp.xrepeat;
				hittype[i].temp_data[1] = sp.yrepeat;
				goto case DefineConstants.MASTERSWITCH;
			case DefineConstants.MASTERSWITCH:
				if (sp.picnum == DefineConstants.MASTERSWITCH)
				{
					sp.cstat |= unchecked((short)32768);
				}
				sp.yvel = 0;
				Engine.board.changespritestat(i, 6);
				break;
			case DefineConstants.TARGET:
			case DefineConstants.DUCK:
			case DefineConstants.LETTER:
				sp.extra = 1;
				sp.cstat |= 257;
				Engine.board.changespritestat(i, 1);
				break;
			case DefineConstants.OCTABRAINSTAYPUT:
			case DefineConstants.LIZTROOPSTAYPUT:
			case DefineConstants.PIGCOPSTAYPUT:
			case DefineConstants.LIZMANSTAYPUT:
			case DefineConstants.BOSS1STAYPUT:
			case DefineConstants.PIGCOPDIVE:
			case DefineConstants.COMMANDERSTAYPUT:
			case DefineConstants.BOSS4STAYPUT:
				hittype[i].actorstayput = sp.sectnum;
				goto case DefineConstants.BOSS1;
			case DefineConstants.BOSS1:
			case DefineConstants.BOSS2:
			case DefineConstants.BOSS3:
			case DefineConstants.BOSS4:
			case DefineConstants.ROTATEGUN:
			case DefineConstants.GREENSLIME:
				if (sp.picnum == DefineConstants.GREENSLIME)
				{
					sp.extra = 1;
				}
				goto case DefineConstants.DRONE;
			case DefineConstants.DRONE:
			case DefineConstants.LIZTROOPONTOILET:
			case DefineConstants.LIZTROOPJUSTSIT:
			case DefineConstants.LIZTROOPSHOOT:
			case DefineConstants.LIZTROOPJETPACK:
			case DefineConstants.LIZTROOPDUCKING:
			case DefineConstants.LIZTROOPRUNNING:
			case DefineConstants.LIZTROOP:
			case DefineConstants.OCTABRAIN:
			case DefineConstants.COMMANDER:
			case DefineConstants.PIGCOP:
			case DefineConstants.LIZMAN:
			case DefineConstants.LIZMANSPITTING:
			case DefineConstants.LIZMANFEEDING:
			case DefineConstants.LIZMANJUMP:
			case DefineConstants.ORGANTIC:
			case DefineConstants.RAT:
			case DefineConstants.SHARK:

				if (sp.pal == 0)
				{
					switch (sp.picnum)
					{
						case DefineConstants.LIZTROOPONTOILET:
						case DefineConstants.LIZTROOPSHOOT:
						case DefineConstants.LIZTROOPJETPACK:
						case DefineConstants.LIZTROOPDUCKING:
						case DefineConstants.LIZTROOPRUNNING:
						case DefineConstants.LIZTROOPSTAYPUT:
						case DefineConstants.LIZTROOPJUSTSIT:
						case DefineConstants.LIZTROOP:
							sp.pal = 22;
							break;
					}
				}

				if (sp.picnum == DefineConstants.BOSS4STAYPUT || sp.picnum == DefineConstants.BOSS1 || sp.picnum == DefineConstants.BOSS2 || sp.picnum == DefineConstants.BOSS1STAYPUT || sp.picnum == DefineConstants.BOSS3 || sp.picnum == DefineConstants.BOSS4)
				{
					if (j >= 0 && Engine.board.sprite[j].picnum == DefineConstants.RESPAWN)
					{
						sp.pal = Engine.board.sprite[j].pal;
					}
					if (sp.pal != 0)
					{
						sp.clipdist = 80;
						sp.xrepeat = 40;
						sp.yrepeat = 40;
					}
					else
					{
						sp.xrepeat = 80;
						sp.yrepeat = 80;
						sp.clipdist = 164;
					}
				}
				else
				{
					if (sp.picnum != DefineConstants.SHARK)
					{
						sp.xrepeat = 40;
						sp.yrepeat = 40;
						sp.clipdist = 80;
					}
					else
					{
						sp.xrepeat = 60;
						sp.yrepeat = 60;
						sp.clipdist = 40;
					}
				}

				if (j >= 0)
				{
					sp.lotag = 0;
				}

				if ((sp.lotag > ud.player_skill) || ud.monsters_off == 1)
				{
					sp.xrepeat = sp.yrepeat = 0;
					Engine.board.changespritestat(i, 5);
					break;
				}
				else
				{
					makeitfall(i);

					if (sp.picnum == DefineConstants.RAT)
					{
						sp.ang = (short)(Engine.krand() & 2047);
						sp.xrepeat = sp.yrepeat = 48;
						sp.cstat = 0;
					}
					else
					{
						sp.cstat |= 257;

						if (sp.picnum != DefineConstants.SHARK)
						{
							ps[myconnectindex].max_actors_killed++;
						}
					}

					if (sp.picnum == DefineConstants.ORGANTIC)
					{
						sp.cstat |= 128;
					}

					if (j >= 0)
					{
						hittype[i].timetosleep = 0;
						check_fta_sounds(i);
						Engine.board.changespritestat(i, 1);
					}
					else
					{
						Engine.board.changespritestat(i, 2);
					}
				}

				if (sp.picnum == DefineConstants.ROTATEGUN)
				{
					sp.zvel = 0;
				}

				break;

			case DefineConstants.LOCATORS:
				sp.cstat |= unchecked((short)32768);
				Engine.board.changespritestat(i, 7);
				break;

			case DefineConstants.ACTIVATORLOCKED:
			case DefineConstants.ACTIVATOR:
				sp.cstat = unchecked((short)32768);
				if (sp.picnum == DefineConstants.ACTIVATORLOCKED)
				{
					Engine.board.sector[sp.sectnum].lotag |= 16384;
				}
				Engine.board.changespritestat(i, 8);
				break;

			case DefineConstants.DOORSHOCK:
				sp.cstat |= 1 + 256;
				sp.shade = -12;
				Engine.board.changespritestat(i, 6);
				break;

			case DefineConstants.OOZ:
			case DefineConstants.OOZ2:
				sp.shade = -12;

				if (j >= 0)
				{
					if (Engine.board.sprite[j].picnum == DefineConstants.NUKEBARREL)
					{
						sp.pal = 8;
					}
					insertspriteq(i);
				}

				Engine.board.changespritestat(i, 1);

				getglobalz(i);

				j = (short)((hittype[i].floorz - hittype[i].ceilingz) >> 9);

				sp.yrepeat = (byte)j;
				sp.xrepeat = (byte)(25 - (j >> 1));
				sp.cstat |= unchecked((short)(Engine.krand() & 4));

				break;

			case DefineConstants.HEAVYHBOMB:
				if (j >= 0)
				{
					sp.owner = j;
				}
				else
				{
					sp.owner = i;
				}
				sp.xrepeat = sp.yrepeat = 9;
				sp.yvel = 4;
				goto case DefineConstants.REACTOR2;
			case DefineConstants.REACTOR2:
			case DefineConstants.REACTOR:
			case DefineConstants.RECON:

				if (sp.picnum == DefineConstants.RECON)
				{
					if (sp.lotag > ud.player_skill)
					{
						sp.xrepeat = sp.yrepeat = 0;
						Engine.board.changespritestat(i, 5);
						return i;
					}
					ps[myconnectindex].max_actors_killed++;
					hittype[i].temp_data[5] = 0;
					if (ud.monsters_off == 1)
					{
						sp.xrepeat = sp.yrepeat = 0;
						Engine.board.changespritestat(i, 5);
						break;
					}
					sp.extra = 130;
				}

				if (sp.picnum == DefineConstants.REACTOR || sp.picnum == DefineConstants.REACTOR2)
				{
					sp.extra = (short)impact_damage;
				}

				Engine.board.sprite[i].cstat |= 257; // Make it hitable

				if (ud.multimode < 2 && sp.pal != 0)
				{
					sp.xrepeat = sp.yrepeat = 0;
					Engine.board.changespritestat(i, 5);
					break;
				}
				sp.pal = 0;
				Engine.board.sprite[i].shade = -17;

				Engine.board.changespritestat(i, 2);
				break;

			case DefineConstants.ATOMICHEALTH:
			case DefineConstants.STEROIDS:
			case DefineConstants.HEATSENSOR:
			case DefineConstants.SHIELD:
			case DefineConstants.AIRTANK:
			case DefineConstants.TRIPBOMBSPRITE:
			case DefineConstants.JETPACK:
			case DefineConstants.HOLODUKE:

			case DefineConstants.FIRSTGUNSPRITE:
			case DefineConstants.CHAINGUNSPRITE:
			case DefineConstants.SHOTGUNSPRITE:
			case DefineConstants.RPGSPRITE:
			case DefineConstants.SHRINKERSPRITE:
			case DefineConstants.FREEZESPRITE:
			case DefineConstants.DEVISTATORSPRITE:

			case DefineConstants.SHOTGUNAMMO:
			case DefineConstants.FREEZEAMMO:
			case DefineConstants.HBOMBAMMO:
			case DefineConstants.CRYSTALAMMO:
			case DefineConstants.GROWAMMO:
			case DefineConstants.BATTERYAMMO:
			case DefineConstants.DEVISTATORAMMO:
			case DefineConstants.RPGAMMO:
			case DefineConstants.BOOTS:
			case DefineConstants.AMMO:
			case DefineConstants.AMMOLOTS:
			case DefineConstants.COLA:
			case DefineConstants.FIRSTAID:
			case DefineConstants.SIXPAK:
				if (j >= 0)
				{
					sp.lotag = 0;
					sp.z -= (32 << 8);
					sp.zvel = -1024;
					ssp(i, (uint)(((1) << 16) + 1));
					sp.cstat = (short)(Engine.krand() & 4);
				}
				else
				{
					sp.owner = i;
					sp.cstat = 0;
				}

				if ((ud.multimode < 2 && sp.pal != 0) || (sp.lotag > ud.player_skill))
				{
					sp.xrepeat = sp.yrepeat = 0;
					Engine.board.changespritestat(i, 5);
					break;
				}

				sp.pal = 0;

				goto case DefineConstants.ACCESSCARD;
			case DefineConstants.ACCESSCARD:

				if (sp.picnum == DefineConstants.ATOMICHEALTH)
				{
					sp.cstat |= 128;
				}

				if (ud.multimode > 1 && ud.coop != 1 && sp.picnum == DefineConstants.ACCESSCARD)
				{
					sp.xrepeat = sp.yrepeat = 0;
					Engine.board.changespritestat(i, 5);
					break;
				}
				else
				{
					if (sp.picnum == DefineConstants.AMMO)
					{
						sp.xrepeat = sp.yrepeat = 16;
					}
					else
					{
						sp.xrepeat = sp.yrepeat = 32;
					}
				}

				sp.shade = -17;

				if (j >= 0)
				{
					Engine.board.changespritestat(i, 1);
				}
				else
				{
					Engine.board.changespritestat(i, 2);
					makeitfall(i);
				}
				break;

			case DefineConstants.WATERFOUNTAIN:
				Engine.board.sprite[i].lotag = 1;

				goto case DefineConstants.TREE1;
			case DefineConstants.TREE1:
			case DefineConstants.TREE2:
			case DefineConstants.TIRE:
			case DefineConstants.CONE:
			case DefineConstants.BOX:
				Engine.board.sprite[i].cstat = 257; // Make it hitable
				Engine.board.sprite[i].extra = 1;
				Engine.board.changespritestat(i, 6);
				break;

			case DefineConstants.FLOORFLAME:
				sp.shade = -127;
				Engine.board.changespritestat(i, 6);
				break;

			case DefineConstants.BOUNCEMINE:
				sp.owner = i;
				sp.cstat |= 1 + 256; //Make it hitable
				sp.xrepeat = sp.yrepeat = 24;
				sp.shade = -127;
				sp.extra = (short)(impact_damage << 2);
				Engine.board.changespritestat(i, 2);
				break;

			case DefineConstants.CAMERA1:
			case DefineConstants.CAMERA1 + 1:
			case DefineConstants.CAMERA1 + 2:
			case DefineConstants.CAMERA1 + 3:
			case DefineConstants.CAMERA1 + 4:
			case DefineConstants.CAMERAPOLE:
				sp.extra = 1;

				if (camerashitable != 0)
				{
					sp.cstat = 257;
				}
				else
				{
					sp.cstat = 0;
				}

				goto case DefineConstants.GENERICPOLE;
			case DefineConstants.GENERICPOLE:

				if (ud.multimode < 2 && sp.pal != 0)
				{
					sp.xrepeat = sp.yrepeat = 0;
					Engine.board.changespritestat(i, 5);
					break;
				}
				else
				{
					sp.pal = 0;
				}
				if (sp.picnum == DefineConstants.CAMERAPOLE || sp.picnum == DefineConstants.GENERICPOLE)
				{
					break;
				}
				sp.picnum = DefineConstants.CAMERA1;
				Engine.board.changespritestat(i, 1);
				break;
			case DefineConstants.STEAM:
				if (j >= 0)
				{
					sp.ang = Engine.board.sprite[j].ang;
					sp.cstat = (short)(16 + 128 + 2);
					sp.xrepeat = sp.yrepeat = 1;
					sp.xvel = -8;
					ssp(i, (uint)(((1) << 16) + 1));
				}
				goto case DefineConstants.CEILINGSTEAM;
			case DefineConstants.CEILINGSTEAM:
				Engine.board.changespritestat(i, 6);
				break;

			case DefineConstants.SECTOREFFECTOR:
				sp.yvel = Engine.board.sector[sect].extra;
				sp.cstat |= unchecked((short)32768);
				sp.xrepeat = sp.yrepeat = 0;

				switch (sp.lotag)
				{
					case 28:
						hittype[i].temp_data[5] = 65; // Delay for lightning
						break;
					case 7: // Transporters!!!!
					case 23: // XPTR END
						if (sp.lotag != 23)
						{
							for (j = 0; j < DefineConstants.MAXSPRITES; j++)
							{
								if (Engine.board.sprite[j].statnum < DefineConstants.MAXSTATUS && Engine.board.sprite[j].picnum == DefineConstants.SECTOREFFECTOR && (Engine.board.sprite[j].lotag == 7 || Engine.board.sprite[j].lotag == 23) && i != j && Engine.board.sprite[j].hitag == Engine.board.sprite[i].hitag)
								{
									Engine.board.sprite[i].owner = j;
									break;
								}
							}
						}
						else
						{
							Engine.board.sprite[i].owner = i;
						}

						if (Engine.board.sector[sect].floorz == Engine.board.sprite[i].z)
							hittype[i].temp_data[4] = 1;
						else
							hittype[i].temp_data[4] = 0;

						sp.cstat = 0;
						Engine.board.changespritestat(i, 9);
						return i;
					case 1:
						sp.owner = -1;
						hittype[i].temp_data[0] = 1;
						break;
					case 18:

						if (sp.ang == 512)
						{
							hittype[i].temp_data[1] = Engine.board.sector[sect].ceilingz;
							if (sp.pal != 0)
							{
								Engine.board.sector[sect].ceilingz = sp.z;
							}
						}
						else
						{
							hittype[i].temp_data[1] = Engine.board.sector[sect].floorz;
							if (sp.pal != 0)
							{
								Engine.board.sector[sect].floorz = sp.z;
							}
						}

						sp.hitag <<= 2;
						break;

					case 19:
						sp.owner = -1;
						break;
					case 25: // Pistons
						hittype[i].temp_data[3] = Engine.board.sector[sect].ceilingz;
						hittype[i].temp_data[4] = 1;
						Engine.board.sector[sect].ceilingz = sp.z;
						setinterpolation(ref Engine.board.sector[sect].ceilingz);
						break;
					case 35:
						Engine.board.sector[sect].ceilingz = sp.z;
						break;
					case 27:
						if (ud.recstat == 1)
						{
							sp.xrepeat = sp.yrepeat = 64;
							sp.cstat &= 32767;
						}
						break;
					case 12:

						hittype[i].temp_data[1] = Engine.board.sector[sect].floorshade;
						hittype[i].temp_data[2] = Engine.board.sector[sect].ceilingshade;
						break;

					case 13:

						hittype[i].temp_data[0] = Engine.board.sector[sect].ceilingz;
						hittype[i].temp_data[1] = Engine.board.sector[sect].floorz;

						if (pragmas.klabs(hittype[i].temp_data[0] - sp.z) < pragmas.klabs(hittype[i].temp_data[1] - sp.z))
						{
							sp.owner = 1;
						}
						else
						{
							sp.owner = 0;
						}

						if (sp.ang == 512)
						{
							if (sp.owner != 0)
							{
								Engine.board.sector[sect].ceilingz = sp.z;
							}
							else
							{
								Engine.board.sector[sect].floorz = sp.z;
							}
						}
						else
						{
							Engine.board.sector[sect].ceilingz = Engine.board.sector[sect].floorz = sp.z;
						}

						if ((Engine.board.sector[sect].ceilingstat & 1) != 0)
						{
							Engine.board.sector[sect].ceilingstat ^= 1;
							hittype[i].temp_data[3] = 1;

							if (sp.owner == 0 && sp.ang == 512)
							{
								Engine.board.sector[sect].ceilingstat ^= 1;
								hittype[i].temp_data[3] = 0;
							}

							Engine.board.sector[sect].ceilingshade = Engine.board.sector[sect].floorshade;

							if (sp.ang == 512)
							{
								startwall = Engine.board.sector[sect].wallptr;
								endwall = (short)(startwall + Engine.board.sector[sect].wallnum);
								for (j = startwall; j < endwall; j++)
								{
									x = Engine.board.wall[j].nextsector;
									if (x >= 0)
									{
										if ((Engine.board.sector[x].ceilingstat & 1) == 0)
										{
											Engine.board.sector[sect].ceilingpicnum = Engine.board.sector[x].ceilingpicnum;
											Engine.board.sector[sect].ceilingshade = Engine.board.sector[x].ceilingshade;
											break; //Leave earily
										}
									}
								}
							}
						}

						break;

					case 17:

						hittype[i].temp_data[2] = Engine.board.sector[sect].floorz; //Stopping loc

						j = Engine.board.nextsectorneighborz(sect, Engine.board.sector[sect].floorz, -1, -1);
						if(j >= 0)
							hittype[i].temp_data[3] = Engine.board.sector[j].ceilingz;

						j = Engine.board.nextsectorneighborz(sect, Engine.board.sector[sect].ceilingz, 1, 1);

						if (j >= 0)
							hittype[i].temp_data[4] = Engine.board.sector[j].floorz;

						if (numplayers < 2)
						{
							setinterpolation(ref Engine.board.sector[sect].floorz);
							setinterpolation(ref Engine.board.sector[sect].ceilingz);
						}

						break;

					case 24:
						sp.yvel <<= 1;
						goto case 36;
					case 36:
						break;

					case 20:
						{
							int q;

							startwall = Engine.board.sector[sect].wallptr;
							endwall = (short)(startwall + Engine.board.sector[sect].wallnum);

							//find the two most clostest wall x's and y's
							q = 0x7fffffff;

							for (s = startwall; s < endwall; s++)
							{
								x = Engine.board.wall[s].x;
								y = Engine.board.wall[s].y;

								d = Engine.FindDistance2D(sp.x - x, sp.y - y);
								if (d < q)
								{
									q = d;
									clostest = s;
								}
							}

							hittype[i].temp_data[1] = (short)clostest;

							q = 0x7fffffff;

							for (s = startwall; s < endwall; s++)
							{
								x = Engine.board.wall[s].x;
								y = Engine.board.wall[s].y;

								d = Engine.FindDistance2D(sp.x - x, sp.y - y);
								if (d < q && s != hittype[i].temp_data[1])
								{
									q = d;
									clostest = s;
								}
							}

							hittype[i].temp_data[2] = clostest;
						}

						break;

					case 3:

						hittype[i].temp_data[3] = Engine.board.sector[sect].floorshade;

						Engine.board.sector[sect].floorshade = sp.shade;
						Engine.board.sector[sect].ceilingshade = sp.shade;

						sp.owner = (short)(Engine.board.sector[sect].ceilingpal << 8);
						sp.owner |= Engine.board.sector[sect].floorpal;

						//fix all the walls;

						startwall = Engine.board.sector[sect].wallptr;
						endwall = (short)(startwall + Engine.board.sector[sect].wallnum);

						for (s = startwall; s < endwall; s++)
						{
							if ((Engine.board.wall[s].hitag & 1) == 0)
							{
								Engine.board.wall[s].shade = sp.shade;
							}
							if ((Engine.board.wall[s].cstat & 2) != 0 && Engine.board.wall[s].nextwall >= 0)
							{
								Engine.board.wall[Engine.board.wall[s].nextwall].shade = sp.shade;
							}
						}
						break;

					case 31:
						hittype[i].temp_data[1] = Engine.board.sector[sect].floorz;
						//    T3 = sp->hitag;
						if (sp.ang != 1536)
						{
							Engine.board.sector[sect].floorz = sp.z;
						}

						startwall = Engine.board.sector[sect].wallptr;
						endwall = (short)(startwall + Engine.board.sector[sect].wallnum);

						for (s = startwall; s < endwall; s++)
						{
							if (Engine.board.wall[s].hitag == 0)
							{
								Engine.board.wall[s].hitag = 9999;
							}
						}

						setinterpolation(ref Engine.board.sector[sect].floorz);

						break;
					case 32:
						hittype[i].temp_data[1] = Engine.board.sector[sect].ceilingz;
						hittype[i].temp_data[2] = sp.hitag;
						if (sp.ang != 1536)
						{
							Engine.board.sector[sect].ceilingz = sp.z;
						}

						startwall = Engine.board.sector[sect].wallptr;
						endwall = (short)(startwall + Engine.board.sector[sect].wallnum);

						for (s = startwall; s < endwall; s++)
						{
							if (Engine.board.wall[s].hitag == 0)
							{
								Engine.board.wall[s].hitag = 9999;
							}
						}

						setinterpolation(ref Engine.board.sector[sect].ceilingz);

						break;

					case 4: //Flashing lights

						hittype[i].temp_data[2] = Engine.board.sector[sect].floorshade;

						startwall = Engine.board.sector[sect].wallptr;
						endwall = (short)(startwall + Engine.board.sector[sect].wallnum);

						sp.owner = (short)(Engine.board.sector[sect].ceilingpal << 8);
						sp.owner |= Engine.board.sector[sect].floorpal;

						for (s = startwall; s < endwall; s++)
						{
							if (Engine.board.wall[s].shade > hittype[i].temp_data[3])
							{
								hittype[i].temp_data[3] = Engine.board.wall[s].shade;
							}
						}

						break;

					case 9:
						if (Engine.board.sector[sect].lotag != 0 && Math.Abs(Engine.board.sector[sect].ceilingz - sp.z) > 1024)
						{
							Engine.board.sector[sect].lotag |= unchecked((short)32768); //If its open
						}
						goto case 8;
					case 8:
						//First, get the ceiling-floor shade

						hittype[i].temp_data[0] = Engine.board.sector[sect].floorshade;
						hittype[i].temp_data[1] = Engine.board.sector[sect].ceilingshade;

						startwall = Engine.board.sector[sect].wallptr;
						endwall = (short)(startwall + Engine.board.sector[sect].wallnum);

						for (s = startwall; s < endwall; s++)
						{
							if (Engine.board.wall[s].shade > hittype[i].temp_data[2])
							{
								hittype[i].temp_data[2] = Engine.board.wall[s].shade;
							}
						}

						hittype[i].temp_data[3] = 1; //Take Out;

						break;

					case 11: //Pivitor rotater
						if (sp.ang > 1024)
						{
							hittype[i].temp_data[3] = 2;
						}
						else
						{
							hittype[i].temp_data[3] = -2;
						}
						goto case 0;
					case 0:
					case 2: //Earthquakemakers
					case 5: //Boss Creature
					case 6: //Subway
					case 14: //Caboos
					case 15: //Subwaytype sliding door
					case 16: //That rotating blocker reactor thing
					case 26: //ESCELATOR
					case 30: //No rotational subways

						if (sp.lotag == 0)
						{
							if (Engine.board.sector[sect].lotag == 30)
							{
								if (sp.pal != 0)
								{
									Engine.board.sprite[i].clipdist = 1;
								}
								else
								{
									Engine.board.sprite[i].clipdist = 0;
								}
								hittype[i].temp_data[3] = Engine.board.sector[sect].floorz;
								Engine.board.sector[sect].hitag = i;
							}

							for (j = 0; j < DefineConstants.MAXSPRITES; j++)
							{
								if (Engine.board.sprite[j].statnum < DefineConstants.MAXSTATUS)
								{
									if (Engine.board.sprite[j].picnum == DefineConstants.SECTOREFFECTOR && Engine.board.sprite[j].lotag == 1 && Engine.board.sprite[j].hitag == sp.hitag)
									{
										if (sp.ang == 512)
										{
											sp.x = Engine.board.sprite[j].x;
											sp.y = Engine.board.sprite[j].y;
										}
										break;
									}
								}
							}
							if (j == DefineConstants.MAXSPRITES)
							{
								gameexit("Found lonely Sector Effector(lotag 0) at " + sp.x + " " + sp.y);
							}
							sp.owner = j;
						}

						startwall = Engine.board.sector[sect].wallptr;
						endwall = (short)(startwall + Engine.board.sector[sect].wallnum);

						hittype[i].temp_data[1] = tempwallptr;
						for (s = startwall; s < endwall; s++)
						{
							msx[tempwallptr] = Engine.board.wall[s].x - sp.x;
							msy[tempwallptr] = Engine.board.wall[s].y - sp.y;
							tempwallptr++;
							if (tempwallptr > 2047)
							{
								gameexit("Too many moving sectors at " + Engine.board.wall[s].x + " " +  Engine.board.wall[s].y);
							}
						}
						if (sp.lotag == 30 || sp.lotag == 6 || sp.lotag == 14 || sp.lotag == 5)
						{

							startwall = Engine.board.sector[sect].wallptr;
							endwall = (short)(startwall + Engine.board.sector[sect].wallnum);

							if (Engine.board.sector[sect].hitag == -1)
							{
								sp.extra = 0;
							}
							else
							{
								sp.extra = 1;
							}

							Engine.board.sector[sect].hitag = i;

							j = 0;

							for (s = startwall; s < endwall; s++)
							{
								if (Engine.board.wall[s].nextsector >= 0 && Engine.board.sector[Engine.board.wall[s].nextsector].hitag == 0 && Engine.board.sector[Engine.board.wall[s].nextsector].lotag < 3)
								{
									s = Engine.board.wall[s].nextsector;
									j = 1;
									break;
								}
							}

							if (j == 0)
							{
								gameexit("Subway found no zero'd sectors with locators " + sp.x + " " + sp.y);
							}

							sp.owner = -1;
							hittype[i].temp_data[0] = s;

							if (sp.lotag != 30)
							{
								hittype[i].temp_data[3] = sp.hitag;
							}
						}

						else if (sp.lotag == 16)
						{
							hittype[i].temp_data[3] = Engine.board.sector[sect].ceilingz;
						}

						else if (sp.lotag == 26)
						{
							hittype[i].temp_data[3] = sp.x;
							hittype[i].temp_data[4] = sp.y;
							if (sp.shade == Engine.board.sector[sect].floorshade) //UP
							{
								sp.zvel = -256;
							}
							else
							{
								sp.zvel = 256;
							}

							sp.shade = 0;
						}
						else if (sp.lotag == 2)
						{
							hittype[i].temp_data[5] = Engine.board.sector[sp.sectnum].floorheinum;
							Engine.board.sector[sp.sectnum].floorheinum = 0;
						}
						break;
				}

				switch (sp.lotag)
				{
					case 6:
					case 14:
						j = callsound(sect, i);
						if (j == -1)
						{
							j = DefineConstants.SUBWAY;
						}
						hittype[i].lastvx = j;
						goto case 30;
					case 30:
						if (numplayers > 1)
						{
							break;
						}
						goto case 0;
					case 0:
					case 1:
					case 5:
					case 11:
					case 15:
					case 16:
					case 26:
						setsectinterpolate(i);
						break;
				}

				switch (Engine.board.sprite[i].lotag)
				{
					case 40:
					case 41:
					case 43:
					case 44:
					case 45:
						Engine.board.changespritestat(i, 15);
						break;
					default:
						Engine.board.changespritestat(i, 3);
						break;
				}

				break;


			case DefineConstants.SEENINE:
			case DefineConstants.OOZFILTER:

				sp.shade = -16;
				if (sp.xrepeat <= 8)
				{
					sp.cstat = unchecked((short)32768);
					sp.xrepeat = sp.yrepeat = 0;
				}
				else
				{
					sp.cstat = (short)(1 + 256);
				}
				sp.extra = (short)(impact_damage << 2);
				sp.owner = i;

				Engine.board.changespritestat(i, 6);
				break;

			case DefineConstants.CRACK1:
			case DefineConstants.CRACK2:
			case DefineConstants.CRACK3:
			case DefineConstants.CRACK4:
			case DefineConstants.FIREEXT:
				if (sp.picnum == DefineConstants.FIREEXT)
				{
					sp.cstat = 257;
					sp.extra = (short)(impact_damage << 2);
				}
				else
				{
					sp.cstat |= 17;
					sp.extra = 1;
				}

				if (ud.multimode < 2 && sp.pal != 0)
				{
					sp.xrepeat = sp.yrepeat = 0;
					Engine.board.changespritestat(i, 5);
					break;
				}

				sp.pal = 0;
				sp.owner = i;
				Engine.board.changespritestat(i, 6);
				sp.xvel = 8;
				ssp(i, (uint)(((1) << 16) + 1));
				break;

			case DefineConstants.TOILET:
			case DefineConstants.STALL:
				sp.lotag = 1;
				sp.cstat |= 257;
				sp.clipdist = 8;
				sp.owner = i;
				break;
			case DefineConstants.CANWITHSOMETHING:
			case DefineConstants.CANWITHSOMETHING2:
			case DefineConstants.CANWITHSOMETHING3:
			case DefineConstants.CANWITHSOMETHING4:
			case DefineConstants.RUBBERCAN:
				sp.extra = 0;
				goto case DefineConstants.EXPLODINGBARREL;
			case DefineConstants.EXPLODINGBARREL:
			case DefineConstants.HORSEONSIDE:
			case DefineConstants.FIREBARREL:
			case DefineConstants.NUKEBARREL:
			case DefineConstants.FIREVASE:
			case DefineConstants.NUKEBARRELDENTED:
			case DefineConstants.NUKEBARRELLEAKED:
			case DefineConstants.WOODENHORSE:

				if (j >= 0)
				{
					sp.xrepeat = sp.yrepeat = 32;
				}
				sp.clipdist = 72;
				makeitfall(i);
				if (j >= 0)
				{
					sp.owner = j;
				}
				else
				{
					sp.owner = i;
				}
				goto case DefineConstants.EGG;
			case DefineConstants.EGG:
				if (ud.monsters_off == 1 && sp.picnum == DefineConstants.EGG)
				{
					sp.xrepeat = sp.yrepeat = 0;
					Engine.board.changespritestat(i, 5);
				}
				else
				{
					if (sp.picnum == DefineConstants.EGG)
					{
						sp.clipdist = 24;
					}
					sp.cstat = (short)(257 | (Engine.krand() & 4));
					Engine.board.changespritestat(i, 2);
				}
				break;
			case DefineConstants.TOILETWATER:
				sp.shade = -16;
				Engine.board.changespritestat(i, 6);
				break;
		}
		return i;
	}


	public static void animatesprites(int x, int y, short a, int smoothratio)
	{
		short i;
		short j;
		short k;
		short p;
		short sect;
		int l;
		int t1;
		int t3;
		int t4;
		spritetype s;
		spritetype t;

		for (j = 0; j < Engine.board.spritesortcnt; j++)
		{
			t = Engine.board.tsprite[j];
			i = t.owner;
			s = Engine.board.sprite[t.owner];

			switch (t.picnum)
			{
                default:
                    if (((t.cstat & 16)) != 0 || (badguy(t) != 0 && t.extra > 0) || t.statnum == 10)
                    {
                        continue;
                    }
					break;
                case DefineConstants.BLOODPOOL:
				case DefineConstants.PUKE:
				case DefineConstants.FOOTPRINTS:
				case DefineConstants.FOOTPRINTS2:
				case DefineConstants.FOOTPRINTS3:
				case DefineConstants.FOOTPRINTS4:
					if (t.shade == 127)
					{
						continue;
					}
					break;
				case DefineConstants.RESPAWNMARKERRED:
				case DefineConstants.RESPAWNMARKERYELLOW:
				case DefineConstants.RESPAWNMARKERGREEN:
					if (ud.marker == 0)
					{
						t.xrepeat = t.yrepeat = 0;
					}
					continue;
				case DefineConstants.CHAIR3:

					k = (short)((((t.ang + 3072 + 128 - a) & 2047) >> 8) & 7);
					if (k > 4)
					{
						k = (short)(8 - k);
						t.cstat |= 4;
					}
					else
					{
						t.cstat &= ~4;
					}
					t.picnum = (short)(s.picnum + k);
					break;
				case DefineConstants.BLOODSPLAT1:
				case DefineConstants.BLOODSPLAT2:
				case DefineConstants.BLOODSPLAT3:
				case DefineConstants.BLOODSPLAT4:
					if (ud.lockout != 0)
					{
						t.xrepeat = t.yrepeat = 0;
					}
					else if (t.pal == 6)
					{
						t.shade = -127;
						continue;
					}
					goto case DefineConstants.BULLETHOLE;
				case DefineConstants.BULLETHOLE:
				case DefineConstants.CRACK1:
				case DefineConstants.CRACK2:
				case DefineConstants.CRACK3:
				case DefineConstants.CRACK4:
					t.shade = 16;
					continue;
				case DefineConstants.NEON1:
				case DefineConstants.NEON2:
				case DefineConstants.NEON3:
				case DefineConstants.NEON4:
				case DefineConstants.NEON5:
				case DefineConstants.NEON6:
					continue;
				case DefineConstants.GREENSLIME:
				case DefineConstants.GREENSLIME + 1:
				case DefineConstants.GREENSLIME + 2:
				case DefineConstants.GREENSLIME + 3:
				case DefineConstants.GREENSLIME + 4:
				case DefineConstants.GREENSLIME + 5:
				case DefineConstants.GREENSLIME + 6:
				case DefineConstants.GREENSLIME + 7:
					break;
				
			}

			if ((Engine.board.sector[t.sectnum].ceilingstat & 1) != 0)
			{
				l = Engine.board.sector[t.sectnum].ceilingshade;
			}
			else
			{
				l = Engine.board.sector[t.sectnum].floorshade;
			}

			if (l < -127)
			{
				l = -127;
			}
			if (l > 128)
			{
				l = 127;
			}
			t.shade = (sbyte)l;
		}


		for (j = 0; j <  Engine.board.spritesortcnt; j++) //Between drawrooms() and drawmasks()
		{ //is the perfect time to animate sprites
			t = Engine.board.tsprite[j];
			i = t.owner;
			s = Engine.board.sprite[i];

			switch (s.picnum)
			{
				case DefineConstants.SECTOREFFECTOR:
					if (t.lotag == 27 && ud.recstat == 1)
					{
						t.picnum = (short)(11 + ((totalclock >> 3) & 1));
						t.cstat |= 128;
					}
					else
					{
						t.xrepeat = t.yrepeat = 0;
					}
					break;
				case DefineConstants.NATURALLIGHTNING:
					t.shade = -127;
					break;
				case DefineConstants.FEM1:
				case DefineConstants.FEM2:
				case DefineConstants.FEM3:
				case DefineConstants.FEM4:
				case DefineConstants.FEM5:
				case DefineConstants.FEM6:
				case DefineConstants.FEM7:
				case DefineConstants.FEM8:
				case DefineConstants.FEM9:
				case DefineConstants.FEM10:
				case DefineConstants.MAN:
				case DefineConstants.MAN2:
				case DefineConstants.WOMAN:
				case DefineConstants.NAKED1:
				case DefineConstants.PODFEM1:
				case DefineConstants.FEMMAG1:
				case DefineConstants.FEMMAG2:
				case DefineConstants.FEMPIC1:
				case DefineConstants.FEMPIC2:
				case DefineConstants.FEMPIC3:
				case DefineConstants.FEMPIC4:
				case DefineConstants.FEMPIC5:
				case DefineConstants.FEMPIC6:
				case DefineConstants.FEMPIC7:
				case DefineConstants.BLOODYPOLE:
				case DefineConstants.FEM6PAD:
				case DefineConstants.STATUE:
				case DefineConstants.STATUEFLASH:
				case DefineConstants.OOZ:
				case DefineConstants.OOZ2:
				case DefineConstants.WALLBLOOD1:
				case DefineConstants.WALLBLOOD2:
				case DefineConstants.WALLBLOOD3:
				case DefineConstants.WALLBLOOD4:
				case DefineConstants.WALLBLOOD5:
				case DefineConstants.WALLBLOOD7:
				case DefineConstants.WALLBLOOD8:
				case DefineConstants.SUSHIPLATE1:
				case DefineConstants.SUSHIPLATE2:
				case DefineConstants.SUSHIPLATE3:
				case DefineConstants.SUSHIPLATE4:
				case DefineConstants.FETUS:
				case DefineConstants.FETUSJIB:
				case DefineConstants.FETUSBROKE:
				case DefineConstants.HOTMEAT:
				case DefineConstants.FOODOBJECT16:
				case DefineConstants.DOLPHIN1:
				case DefineConstants.DOLPHIN2:
				case DefineConstants.TOUGHGAL:
				case DefineConstants.TAMPON:
				case DefineConstants.XXXSTACY:
				case 4946:
				case 4947:
				case 693:
				case 2254:
				case 4560:
				case 4561:
				case 4562:
				case 4498:
				case 4957:
					if (ud.lockout != 0)
					{
						t.xrepeat = t.yrepeat = 0;
						continue;
					}
					break;
			}

			if (t.statnum == 99)
			{
				continue;
			}
			if (s.statnum != 1 && s.picnum == DefineConstants.APLAYER && ps[s.yvel].newowner == -1 && s.owner >= 0)
			{
				t.x -= pragmas.mulscale16(65536 - smoothratio, ps[s.yvel].posx - ps[s.yvel].oposx);
				t.y -= pragmas.mulscale16(65536 - smoothratio, ps[s.yvel].posy - ps[s.yvel].oposy);
				t.z = ps[s.yvel].oposz + pragmas.mulscale16(smoothratio, ps[s.yvel].posz - ps[s.yvel].oposz);
				t.z += (40 << 8);
			}
			else if ((s.statnum == 0 && s.picnum != DefineConstants.CRANEPOLE) || s.statnum == 10 || s.statnum == 6 || s.statnum == 4 || s.statnum == 5 || s.statnum == 1)
			{
				t.x -= pragmas.mulscale16(65536 - smoothratio, s.x - hittype[i].bposx);
				t.y -= pragmas.mulscale16(65536 - smoothratio, s.y - hittype[i].bposy);
				t.z -= pragmas.mulscale16(65536 - smoothratio, s.z - hittype[i].bposz);
			}

			sect = s.sectnum;
			t1 = hittype[i].temp_data[1];
			t3 = hittype[i].temp_data[3];
			t4 = hittype[i].temp_data[4];

			switch (s.picnum)
			{
				case DefineConstants.DUKELYINGDEAD:
					t.z += (24 << 8);
					break;
				case DefineConstants.BLOODPOOL:
				case DefineConstants.FOOTPRINTS:
				case DefineConstants.FOOTPRINTS2:
				case DefineConstants.FOOTPRINTS3:
				case DefineConstants.FOOTPRINTS4:
					if (t.pal == 6)
					{
						t.shade = -127;
					}
					goto case DefineConstants.PUKE;
				case DefineConstants.PUKE:
				case DefineConstants.MONEY:
				case DefineConstants.MONEY + 1:
				case DefineConstants.MAIL:
				case DefineConstants.MAIL + 1:
				case DefineConstants.PAPER:
				case DefineConstants.PAPER + 1:
					if (ud.lockout != 0 && s.pal == 2)
					{
						t.xrepeat = t.yrepeat = 0;
						continue;
					}
					break;
				case DefineConstants.TRIPBOMB:
					continue;
				case DefineConstants.FORCESPHERE:
					if (t.statnum == 5)
					{
						short sqa;
						short sqb;

						sqa = (short)Engine.getangle(Engine.board.sprite[s.owner].x - ps[screenpeek].posx, Engine.board.sprite[s.owner].y - ps[screenpeek].posy);
						sqb = (short)Engine.getangle(Engine.board.sprite[s.owner].x - t.x, Engine.board.sprite[s.owner].y - t.y);

						if (pragmas.klabs(getincangle(sqa, sqb)) > 512)
						{
							if (ldist(Engine.board.sprite[s.owner], t) < ldist(Engine.board.sprite[ps[screenpeek].i], Engine.board.sprite[s.owner]))
							{
								t.xrepeat = t.yrepeat = 0;
							}
						}
					}
					continue;
				case DefineConstants.BURNING:
				case DefineConstants.BURNING2:
					if (Engine.board.sprite[s.owner].statnum == 10)
					{
						if (display_mirror == 0 && Engine.board.sprite[s.owner].yvel == screenpeek && ps[Engine.board.sprite[s.owner].yvel].over_shoulder_on == 0)
						{
							t.xrepeat = 0;
						}
						else
						{
							t.ang = (short)Engine.getangle(x - t.x, y - t.y);
							t.x = Engine.board.sprite[s.owner].x;
							t.y = Engine.board.sprite[s.owner].y;
							t.x += Engine.table.sintable[(t.ang + 512) & 2047] >> 10;
							t.y += Engine.table.sintable[t.ang & 2047] >> 10;
						}
					}
					break;

				case DefineConstants.ATOMICHEALTH:
					t.z -= (4 << 8);
					break;
				case DefineConstants.CRYSTALAMMO:
					t.shade = (sbyte)(Engine.table.sintable[(totalclock << 4) & 2047] >> 10);
					continue;
				case DefineConstants.VIEWSCREEN:
				case DefineConstants.VIEWSCREEN2:
					if (camsprite >= 0 && hittype[Engine.board.sprite[i].owner].temp_data[0] == 1)
					{
						t.picnum = DefineConstants.STATIC;
						t.cstat |= (short)(Engine.krand() & 12);
						t.xrepeat += 8;
						t.yrepeat += 8;
					}
					break;

				case DefineConstants.SHRINKSPARK:
					t.picnum = (short)(DefineConstants.SHRINKSPARK + ((totalclock >> 4) & 3));
					break;
				case DefineConstants.GROWSPARK:
					t.picnum = (short)(DefineConstants.GROWSPARK + ((totalclock >> 4) & 3));
					break;
				case DefineConstants.RPG:
					k = (short)Engine.getangle(s.x - x, s.y - y);
					k = (short)(((s.ang + 3072 + 128 - k) & 2047) / 170);
					if (k > 6)
					{
						k = (short)(12 - k);
						t.cstat |= 4;
					}
					else
					{
						t.cstat &= ~4;
					}
					t.picnum = (short)(DefineConstants.RPG + k);
					break;

				case DefineConstants.RECON:

					k = (short)Engine.getangle(s.x - x, s.y - y);
					if (hittype[i].temp_data[0] < 4)
					{
						k = (short)(((s.ang + 3072 + 128 - k) & 2047) / 170);
					}
					else
					{
						k = (short)(((s.ang + 3072 + 128 - k) & 2047) / 170);
					}

					if (k > 6)
					{
						k = (short)(12 - k);
						t.cstat |= 4;
					}
					else
					{
						t.cstat &= ~4;
					}

					if (pragmas.klabs(t3) > 64)
					{
						k += 7;
					}
					t.picnum = (short)(DefineConstants.RECON + k);

					break;

				case DefineConstants.APLAYER:

					p = s.yvel;

					if (t.pal == 1)
					{
						t.z -= (18 << 8);
					}

					if (ps[p].over_shoulder_on > 0 && ps[p].newowner < 0)
					{
						t.cstat |= 2;
						if (screenpeek == myconnectindex && numplayers >= 2)
						{
							t.x = omyx + pragmas.mulscale16((int)(myx - omyx), smoothratio);
							t.y = omyy + pragmas.mulscale16((int)(myy - omyy), smoothratio);
							t.z = omyz + pragmas.mulscale16((int)(myz - omyz), smoothratio) + (40 << 8);
							t.ang = (short)(omyang + pragmas.mulscale16((int)(((myang + 1024 - omyang) & 2047) - 1024), smoothratio));
							t.sectnum = mycursectnum;
						}
					}

					if ((display_mirror == 1 || screenpeek != p || s.owner == -1) && ud.multimode > 1 && ud.showweapons != 0 && Engine.board.sprite[ps[p].i].extra > 0 && ps[p].curr_weapon > 0)
					{
						Engine.board.tsprite[Engine.board.spritesortcnt].Copy(t);

						Engine.board.tsprite[Engine.board.spritesortcnt].statnum = 99;

						Engine.board.tsprite[Engine.board.spritesortcnt].yrepeat = (byte)(t.yrepeat >> 3);
						if (t.yrepeat < 4)
						{
							t.yrepeat = 4;
						}

						Engine.board.tsprite[Engine.board.spritesortcnt].shade = t.shade;
						Engine.board.tsprite[Engine.board.spritesortcnt].cstat = 0;

						switch (ps[p].curr_weapon)
						{
							case DefineConstants.PISTOL_WEAPON:
								Engine.board.tsprite[Engine.board.spritesortcnt].picnum = DefineConstants.FIRSTGUNSPRITE;
								break;
							case DefineConstants.SHOTGUN_WEAPON:
								Engine.board.tsprite[Engine.board.spritesortcnt].picnum = DefineConstants.SHOTGUNSPRITE;
								break;
							case DefineConstants.CHAINGUN_WEAPON:
								Engine.board.tsprite[Engine.board.spritesortcnt].picnum = DefineConstants.CHAINGUNSPRITE;
								break;
							case DefineConstants.RPG_WEAPON:
								Engine.board.tsprite[Engine.board.spritesortcnt].picnum = DefineConstants.RPGSPRITE;
								break;
							case DefineConstants.HANDREMOTE_WEAPON:
							case DefineConstants.HANDBOMB_WEAPON:
								Engine.board.tsprite[Engine.board.spritesortcnt].picnum = DefineConstants.HEAVYHBOMB;
								break;
							case DefineConstants.TRIPBOMB_WEAPON:
								Engine.board.tsprite[Engine.board.spritesortcnt].picnum = DefineConstants.TRIPBOMBSPRITE;
								break;
							case DefineConstants.GROW_WEAPON:
								Engine.board.tsprite[Engine.board.spritesortcnt].picnum = DefineConstants.GROWSPRITEICON;
								break;
							case DefineConstants.SHRINKER_WEAPON:
								Engine.board.tsprite[Engine.board.spritesortcnt].picnum = DefineConstants.SHRINKERSPRITE;
								break;
							case DefineConstants.FREEZE_WEAPON:
								Engine.board.tsprite[Engine.board.spritesortcnt].picnum = DefineConstants.FREEZESPRITE;
								break;
							case DefineConstants.DEVISTATOR_WEAPON:
								Engine.board.tsprite[Engine.board.spritesortcnt].picnum = DefineConstants.DEVISTATORSPRITE;
								break;
						}

						if (s.owner >= 0)
						{
							Engine.board.tsprite[Engine.board.spritesortcnt].z = ps[p].posz - (12 << 8);
						}
						else
						{
							Engine.board.tsprite[Engine.board.spritesortcnt].z = s.z - (51 << 8);
						}
						if (ps[p].curr_weapon == DefineConstants.HANDBOMB_WEAPON)
						{
							Engine.board.tsprite[Engine.board.spritesortcnt].xrepeat = 10;
							Engine.board.tsprite[Engine.board.spritesortcnt].yrepeat = 10;
						}
						else
						{
							Engine.board.tsprite[Engine.board.spritesortcnt].xrepeat = 16;
							Engine.board.tsprite[Engine.board.spritesortcnt].yrepeat = 16;
						}
						Engine.board.tsprite[Engine.board.spritesortcnt].pal = 0;
						Engine.board.spritesortcnt++;
					}

					if (s.owner == -1)
					{
						k = (short)((((s.ang + 3072 + 128 - a) & 2047) >> 8) & 7);
						if (k > 4)
						{
							k = (short)(8 - k);
							t.cstat |= 4;
						}
						else
						{
							t.cstat &= ~4;
						}

						if (Engine.board.sector[t.sectnum].lotag == 2)
						{
							k += 1795 - 1405;
						}
						else if ((hittype[i].floorz - s.z) > (64 << 8))
						{
							k += (byte)60;
						}

						t.picnum += k;
						t.pal = (byte)ps[p].palookup;

						goto PALONLY;
					}

					if (ps[p].on_crane == -1 && (Engine.board.sector[s.sectnum].lotag & 0x7ff) != 1)
					{
						l = s.z - hittype[ps[p].i].floorz + (3 << 8);
						if (l > 1024 && s.yrepeat > 32 && s.extra > 0)
						{
							s.yoffset = (sbyte)(l / (s.yrepeat << 2));
						}
						else
						{
							s.yoffset = 0;
						}
					}

					if (ps[p].newowner > -1)
					{
						t4 = (short)scriptptr.buffer[actorscrptr[DefineConstants.APLAYER] + 1];
						t3 = 0;
						t1 = (short)scriptptr.buffer[actorscrptr[DefineConstants.APLAYER] + 2];
					}

					if (ud.camerasprite == -1 && ps[p].newowner == -1)
					{
						if (s.owner >= 0 && display_mirror == 0 && ps[p].over_shoulder_on == 0)
						{
							if (ud.multimode < 2 || (ud.multimode > 1 && p == screenpeek))
							{
								t.owner = -1;
								t.xrepeat = t.yrepeat = 0;
								continue;
							}
						}
					}

					PALONLY:

					if (Engine.board.sector[sect].floorpal != 0)
					{
						t.pal = Engine.board.sector[sect].floorpal;
					}

					if (s.owner == -1)
					{
						continue;
					}

					if (t.z > hittype[i].floorz && t.xrepeat < 32)
					{
						t.z = hittype[i].floorz;
					}

					break;

				case DefineConstants.JIBS1:
				case DefineConstants.JIBS2:
				case DefineConstants.JIBS3:
				case DefineConstants.JIBS4:
				case DefineConstants.JIBS5:
				case DefineConstants.JIBS6:
				case DefineConstants.HEADJIB1:
				case DefineConstants.LEGJIB1:
				case DefineConstants.ARMJIB1:
				case DefineConstants.LIZMANHEAD1:
				case DefineConstants.LIZMANARM1:
				case DefineConstants.LIZMANLEG1:
				case DefineConstants.DUKELEG:
				case DefineConstants.DUKEGUN:
				case DefineConstants.DUKETORSO:
					if (ud.lockout != 0)
					{
						t.xrepeat = t.yrepeat = 0;
						continue;
					}
					if (t.pal == 6)
					{
						t.shade = -120;
					}

					goto case DefineConstants.SCRAP1;
				case DefineConstants.SCRAP1:
				case DefineConstants.SCRAP2:
				case DefineConstants.SCRAP3:
				case DefineConstants.SCRAP4:
				case DefineConstants.SCRAP5:
				case DefineConstants.SCRAP6:
				case DefineConstants.SCRAP6 + 1:
				case DefineConstants.SCRAP6 + 2:
				case DefineConstants.SCRAP6 + 3:
				case DefineConstants.SCRAP6 + 4:
				case DefineConstants.SCRAP6 + 5:
				case DefineConstants.SCRAP6 + 6:
				case DefineConstants.SCRAP6 + 7:

					if (hittype[i].picnum == DefineConstants.BLIMP && t.picnum == DefineConstants.SCRAP1 && s.yvel >= 0)
					{
						t.picnum = s.yvel;
					}
					else
					{
						t.picnum += (short)hittype[i].temp_data[0];
					}
					t.shade -= 6;

					if (Engine.board.sector[sect].floorpal != 0)
					{
						t.pal = Engine.board.sector[sect].floorpal;
					}
					break;

				case DefineConstants.WATERBUBBLE:
					if (Engine.board.sector[t.sectnum].floorpicnum == DefineConstants.FLOORSLIME)
					{
						t.pal = 7;
						break;
					}
                    if (Engine.board.sector[sect].floorpal != 0)
                    {
                        t.pal = Engine.board.sector[sect].floorpal;
                    }
                    break;
                default:

					if (Engine.board.sector[sect].floorpal != 0)
					{
						t.pal = Engine.board.sector[sect].floorpal;
					}
					break;
			}

			if (actorscrptr[s.picnum] != 0)
			{
				if (t4 != 0)
				{
					l = (int)(t4 + 8);

					switch (l)
					{
						case 2:
							k = (short)((((s.ang + 3072 + 128 - a) & 2047) >> 8) & 1);
							break;

						case 3:
						case 4:
							k = (short)((((s.ang + 3072 + 128 - a) & 2047) >> 7) & 7);
							if (k > 3)
							{
								t.cstat |= 4;
								k = (short)(7 - k);
							}
							else
							{
								t.cstat &= ~4;
							}
							break;

						case 5:
							k = (short)Engine.getangle(s.x - x, s.y - y);
							k = (short)((((s.ang + 3072 + 128 - k) & 2047) >> 8) & 7);
							if (k > 4)
							{
								k = (short)(8 - k);
								t.cstat |= 4;
							}
							else
							{
								t.cstat &= ~4;
							}
							break;
						case 7:
							k = (short)Engine.getangle(s.x - x, s.y - y);
							k = (short)(((s.ang + 3072 + 128 - k) & 2047) / 170);
							if (k > 6)
							{
								k = (short)(12 - k);
								t.cstat |= 4;
							}
							else
							{
								t.cstat &= ~4;
							}
							break;
						case 8:
							k = (short)((((s.ang + 3072 + 128 - a) & 2047) >> 8) & 7);
							t.cstat &= ~4;
							break;
						default:
							k = 0;
							break;
					}

					t.picnum += (short)(k + ((int)t4) + l * t3);

					if (l > 0)
					{
						while (Engine.tilesizx[t.picnum] == 0 && t.picnum > 0)
						{
							t.picnum -= (short)l; //Hack, for actors
						}
					}

					if (hittype[i].dispicnum >= 0)
					{
						hittype[i].dispicnum = t.picnum;
					}
				}
				else if (display_mirror == 1)
				{
					t.cstat |= 4;
				}
			}

			if (s.statnum == 13 || badguy(s) != 0 || (s.picnum == DefineConstants.APLAYER && s.owner >= 0))
			{
				if (t.statnum != 99 && s.picnum != DefineConstants.EXPLOSION2 && s.picnum != DefineConstants.HANGLIGHT && s.picnum != DefineConstants.DOMELITE)
				{
					if (s.picnum != DefineConstants.HOTMEAT)
					{
						if (hittype[i].dispicnum < 0)
						{
							hittype[i].dispicnum++;
							continue;
						}
						else if (ud.shadows != 0 && Engine.board.spritesortcnt < (DefineConstants.MAXSPRITESONSCREEN - 2))
						{
							int daz;
							int xrep;
							int yrep;

							if ((Engine.board.sector[sect].lotag & 0xff) > 2 || s.statnum == 4 || s.statnum == 5 || s.picnum == DefineConstants.DRONE || s.picnum == DefineConstants.COMMANDER)
							{
								daz = Engine.board.sector[sect].floorz;
							}
							else
							{
								daz = hittype[i].floorz;
							}

							if ((s.z - daz) < (8 << 8))
							{
								if (ps[screenpeek].posz < daz)
								{
									//C++ TO C# CONVERTER TODO TASK: The memory management function 'memcpy' has no equivalent in C#:
									//memcpy((spritetype) & tsprite[spritesortcnt], (spritetype)t, sizeof(spritetype));
									Engine.board.tsprite[Engine.board.spritesortcnt].Copy(t);

									Engine.board.tsprite[Engine.board.spritesortcnt].statnum = 99;

									Engine.board.tsprite[Engine.board.spritesortcnt].yrepeat = (byte)(t.yrepeat >> 3);
									if (t.yrepeat < 4)
									{
										t.yrepeat = 4;
									}

									Engine.board.tsprite[Engine.board.spritesortcnt].shade = 127;
									Engine.board.tsprite[Engine.board.spritesortcnt].cstat |= 2;

									Engine.board.tsprite[Engine.board.spritesortcnt].z = daz;
									xrep = Engine.board.tsprite[Engine.board.spritesortcnt].xrepeat; // - (pragmas.klabs(daz-t->z)>>11);
									Engine.board.tsprite[Engine.board.spritesortcnt].xrepeat = (byte)xrep;
									Engine.board.tsprite[Engine.board.spritesortcnt].pal = 4;

									yrep = Engine.board.tsprite[Engine.board.spritesortcnt].yrepeat; // - (pragmas.klabs(daz-t->z)>>11);
									Engine.board.tsprite[Engine.board.spritesortcnt].yrepeat = (byte)yrep;
									Engine.board.spritesortcnt++;
								}
							}
						}

						if (ps[screenpeek].heat_amount > 0 && ps[screenpeek].heat_on != 0)
						{
							t.pal = 6;
							t.shade = 0;
						}
					}
				}
			}


			switch (s.picnum)
			{
				case DefineConstants.LASERLINE:
					if (Engine.board.sector[t.sectnum].lotag == 2)
					{
						t.pal = 8;
					}
					t.z = Engine.board.sprite[s.owner].z - (3 << 8);
					if (lasermode == 2 && ps[screenpeek].heat_on == 0)
					{
						t.yrepeat = 0;
					}
					goto case DefineConstants.EXPLOSION2;
				case DefineConstants.EXPLOSION2:
				case DefineConstants.EXPLOSION2BOT:
				case DefineConstants.FREEZEBLAST:
				case DefineConstants.ATOMICHEALTH:
				case DefineConstants.FIRELASER:
				case DefineConstants.SHRINKSPARK:
				case DefineConstants.GROWSPARK:
				case DefineConstants.CHAINGUN:
				case DefineConstants.SHRINKEREXPLOSION:
				case DefineConstants.RPG:
				case DefineConstants.FLOORFLAME:
					if (t.picnum == DefineConstants.EXPLOSION2)
					{
						ps[screenpeek].visibility = -127;
						lastvisinc = totalclock + 32;
						restorepalette = (char)1;
					}
					t.shade = -127;
					break;
				case DefineConstants.FIRE:
				case DefineConstants.FIRE2:
				case DefineConstants.BURNING:
				case DefineConstants.BURNING2:
					if (Engine.board.sprite[s.owner].picnum != DefineConstants.TREE1 && Engine.board.sprite[s.owner].picnum != DefineConstants.TREE2)
					{
						t.z = Engine.board.sector[t.sectnum].floorz;
					}
					t.shade = -127;
					break;
				case DefineConstants.COOLEXPLOSION1:
					t.shade = -127;
					t.picnum += (short)(s.shade >> 1);
					break;
				case DefineConstants.PLAYERONWATER:

					k = (short)((((t.ang + 3072 + 128 - a) & 2047) >> 8) & 7);
					if (k > 4)
					{
						k = (short)(8 - k);
						t.cstat |= 4;
					}
					else
					{
						t.cstat &= ~4;
					}

					int __tt = 0;
					if (hittype[i].temp_data[0] < 4)
						__tt = 1;

					t.picnum = (short)(s.picnum + k + ((__tt) * 5));
					t.shade = Engine.board.sprite[s.owner].shade;

					break;

				case DefineConstants.WATERSPLASH2:
					t.picnum = (short)(DefineConstants.WATERSPLASH2 + t1);
					break;
				case DefineConstants.REACTOR2:
					t.picnum = (short)(s.picnum + hittype[i].temp_data[2]);
					break;
				case DefineConstants.SHELL:
					t.picnum = (short)(s.picnum + (hittype[i].temp_data[0] & 1));
					goto case DefineConstants.SHOTGUNSHELL;
				case DefineConstants.SHOTGUNSHELL:
					t.cstat |= 12;
					if (hittype[i].temp_data[0] > 1)
					{
						t.cstat &= ~4;
					}
					if (hittype[i].temp_data[0] > 2)
					{
						t.cstat &= ~12;
					}
					break;
				case DefineConstants.FRAMEEFFECT1:
					if (s.owner >= 0 && Engine.board.sprite[s.owner].statnum < DefineConstants.MAXSTATUS)
					{
						if (Engine.board.sprite[s.owner].picnum == DefineConstants.APLAYER)
						{
							if (ud.camerasprite == -1)
							{
								if (screenpeek == Engine.board.sprite[s.owner].yvel && display_mirror == 0)
								{
									t.owner = -1;
									break;
								}
							}
						}
						if ((Engine.board.sprite[s.owner].cstat & 32768) == 0)
						{
							t.picnum = hittype[s.owner].dispicnum;
							t.pal = Engine.board.sprite[s.owner].pal;
							t.shade = Engine.board.sprite[s.owner].shade;
							t.ang = Engine.board.sprite[s.owner].ang;
							t.cstat = (short)(2 | Engine.board.sprite[s.owner].cstat);
						}
					}
					break;

				case DefineConstants.CAMERA1:
				case DefineConstants.RAT:
					k = (short)((((t.ang + 3072 + 128 - a) & 2047) >> 8) & 7);
					if (k > 4)
					{
						k = (short)(8 - k);
						t.cstat |= 4;
					}
					else
					{
						t.cstat &= ~4;
					}
					t.picnum = (short)(s.picnum + k);
					break;
			}

			hittype[i].dispicnum = t.picnum;
			if (Engine.board.sector[t.sectnum].floorpicnum == DefineConstants.MIRROR)
			{
				t.xrepeat = t.yrepeat = 0;
			}
		}
	}


#if GAME_IMPLE
	public static void showtwoscreens()
	{
		short i;

#if DEMO
		setview(0,0,Engine.xdim - 1,Engine.ydim - 1);
		flushperms();
		ps[myconnectindex].palette = palette;
		for (i = 0;i < 64;i += 7)
		{
			palto(0, 0, 0, i);
		}
		KB_FlushKeyboardQueue();
		Engine.rotatesprite(0,0,65536,0,3291,0,0,2 + 8 + 16 + 64, 0,0,Engine.xdim - 1,Engine.ydim - 1);
		nextpage();
		for (i = 63;i > 0;i -= 7)
		{
			palto(0, 0, 0, i);
		}
		while (KB_KeyWaiting() == null)
		{
			getpackets();
		}

		for (i = 0;i < 64;i += 7)
		{
			palto(0, 0, 0, i);
		}
		KB_FlushKeyboardQueue();
		Engine.rotatesprite(0,0,65536,0,3290,0,0,2 + 8 + 16 + 64, 0,0,Engine.xdim - 1,Engine.ydim - 1);
		nextpage();
		for (i = 63;i > 0;i -= 7)
		{
			palto(0, 0, 0, i);
		}
		while (KB_KeyWaiting() == null)
		{
			getpackets();
		}
#else
	// CTW - REMOVED
	/*  setview(0,0,Engine.xdim-1,Engine.ydim-1);
	    flushperms();
	    ps[myconnectindex].palette = palette;
	    for(i=0;i<64;i+=7) palto(0,0,0,i);
	    KB_FlushKeyboardQueue();
	    clearview(0L);
	    Engine.rotatesprite(0,0,65536L,0,TENSCREEN,0,0,2+8+16+64, 0,0,Engine.xdim-1,Engine.ydim-1);
	    nextpage(); for(i=63;i>0;i-=7) palto(0,0,0,i);
	    totalclock = 0;
	    while( !KB_KeyWaiting() && totalclock < 2400) getpackets();*/
	// CTW END - REMOVED
#endif
	}

	public static void binscreen()
	{
		int fil;
#if VOLUMEONE
		fil = kopen4load("dukesw.bin",1);
#else
		fil = kopen4load("duke3d.bin",1);
#endif
		if (fil == -1)
		{
			return;
		}
		kread(fil,(string)0xb8000,4000);
		kclose(fil);
	}


	public static void gameexit(string t)
	{
		short i;

		if (t != null)
		{
			ps[myconnectindex].palette = (string) & palette[0];
		}

		if (numplayers > 1)
		{
			allowtimetocorrecterrorswhenquitting();
			uninitmultiplayers();
		}

		if (ud.recstat == 1)
		{
			closedemowrite();
		}
		else if (ud.recstat == 2)
		{
			fclose(frecfilep);
		}

		if (qe || cp)
		{
			goto GOTOHERE;
		}

		if (playerswhenstarted > 1 && ud.coop != 1 && t == ' ')
		{
			dobonus(1);
	// CTW - MODIFICATION
	//      setgamemode();
			setgamemode(ScreenMode,ScreenWidth,ScreenHeight);
	// CTW END - MODIFICATION
		}
#if ONELEVELDEMO
		doorders();
		t = "You have been playing a ONE LEVEL demo of Duke Nukem 3D.";
#endif

	// CTW - MODIFICATION
	/*  if( *t != 0 && *(t+1) != 'V' && *(t+1) != 'Y' && playonten == 0 )
	        showtwoscreens();*/
		if (t != null && *(t.Substring(1)) != 'V' && *(t.Substring(1)) != 'Y' && (1 == 1))
		{
			showtwoscreens();
		}
	// CTW END - MODIFICATION

		GOTOHERE:

		Shutdown();

		if (t != null)
		{
			setvmode(0x3);
			binscreen();
	// CTW - MODIFICATION
	/*      if(playonten == 0)
	        {
	            if(*t == ' ' && *(t+1) == 0) *t = 0;
	            printf("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
	            printf("%s%s","\n",t);
	        }*/
			if ((1 == 1))
			{
				if (t == ' ' && *(t.Substring(1)) == 0)
				{
					t = null;
				}
				printf("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
				printf("%s%s","\n",t);
			}
	// CTW END - MODIFICATION        
		}

		uninitgroupfile();

		unlink("duke3d.tmp");

		exit(0);
	}




	public static short inputloc = 0;
	public static short strget(short x, short y, ref string t, short dalen, short c)
	{
		short ch;
		short sc;

		while (KB_KeyWaiting() != null)
		{
			sc = 0;
			ch = KB_Getch();

			if (ch == 0)
			{

				sc = KB_Getch();
				if (sc == 104)
				{
					return (1);
				}

				continue;
			}
			else
			{
				if (ch == 8)
				{
					if (inputloc > 0)
					{
						inputloc--;
						*(t.Substring(inputloc)) = 0;
					}
				}
				else
				{
					if (ch == DefineConstants.asc_Enter || sc == 104)
					{
						{
							KB_KeyDown[(DefineConstants.sc_Return)] = (!(1 == 1));
					};
					{
							KB_KeyDown[(DefineConstants.sc_kpad_Enter)] = (!(1 == 1));
					};
						return (1);
					}
					else if (ch == DefineConstants.asc_Escape)
					{
						{
							KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
					};
						return (short)(-1);
					}
					else if (ch >= 32 && inputloc < dalen && ch < 127)
					{
						ch = toupper(ch);
						*(t.Substring(inputloc)) = ch;
						*(t.Substring(inputloc) + 1) = 0;
						inputloc++;
					}
				}
			}
		}

		if (c == 999)
		{
			return (0);
		}
		if (c == 998)
		{
			string b = new string(new char[41]);
			char ii;
			for (ii = 0;ii < inputloc;ii++)
			{
				b = StringFunctions.ChangeCharacter(b, ii, '*');
			}
			b = b.Substring(0, ii);
			x = (short)gametext(x, y, b, c, (short)(2 + 8 + 16));
		}
		else
		{
			x = (short)gametext(x, y, t, c, (short)(2 + 8 + 16));
		}
		c = (short)(4 - (sintable[(totalclock << 4) & 2047]>>11));
		Engine.rotatesprite((x + 8) << 16,(y + 4) << 16,32768,0,DefineConstants.SPINNINGNUKEICON + ((totalclock>>3) % 7),c,0,2 + 8,0,0,Engine.xdim - 1,Engine.ydim - 1);

		return (0);
	}

	public static void typemode()
	{
		 short ch;
		 short hitstate;
		 short i;
		 short j;

		 if ((ps[myconnectindex].gm & DefineConstants.MODE_SENDTOWHOM) != 0)
		 {
			  if (sendmessagecommand != -1 || ud.multimode < 3 || movesperpacket == 4)
			  {
					tempbuf[0] = 4;
					tempbuf[1] = 0;
					recbuf = null;

					if (ud.multimode < 3)
					{
						 sendmessagecommand = 2;
					}

					strcat(recbuf,ud.user_name[myconnectindex]);
					strcat(recbuf,": ");
					strcat(recbuf,typebuf);
					j = strlen(recbuf);
					recbuf = recbuf.Substring(0, j);
					strcat(tempbuf + 1,recbuf);

					if (sendmessagecommand >= ud.multimode || movesperpacket == 4)
					{
						 for (ch = connecthead;ch >= 0;ch = connectpoint2[ch])
						 {
							  if (ch != myconnectindex)
							  {
									sendpacket(ch,tempbuf,j + 1);
							  }
						 }

						 adduserquote(ref recbuf);
						 quotebot += 8;
						 quotebotgoal = quotebot;
					}
					else if (sendmessagecommand >= 0)
					{
						 sendpacket(sendmessagecommand,tempbuf,j + 1);
					}

					sendmessagecommand = -1;
					ps[myconnectindex].gm &= ~(DefineConstants.MODE_TYPE | DefineConstants.MODE_SENDTOWHOM);
			  }
			  else if (sendmessagecommand == -1)
			  {
					j = 50;
					gametext(320 >> 1, j, "SEND MESSAGE TO...", 0, (short)(2 + 8 + 16));
					j += 8;
					for (i = connecthead;i >= 0;i = connectpoint2[i])
					{
	//                for(i=0;i<ud.multimode;i++)
						 if (i == myconnectindex)
						 {
							 minitextshade((320 >> 1) - 40 + 1, j + 1, "A/ENTER - ALL", 26, 0, 2 + 8 + 16);
							 minitext((320 >> 1) - 40, j, "A/ENTER - ALL", 0, 2 + 8 + 16);
							 j += 7;
						 }
						 else
						 {
							 sprintf(buf,"      %ld - %s",i + 1,ud.user_name[i]);
							 minitextshade((320 >> 1) - 40 - 6 + 1, j + 1, buf, 26, 0, 2 + 8 + 16);
							 minitext((320 >> 1) - 40 - 6, j, buf, 0, 2 + 8 + 16);
							 j += 7;
						 }
					}
					minitextshade((320 >> 1) - 40 - 4 + 1, j + 1, "    ESC - Abort", 26, 0, 2 + 8 + 16);
					minitext((320 >> 1) - 40 - 4, j, "    ESC - Abort", 0, 2 + 8 + 16);
					j += 7;

					//sprintf(buf,"PRESS 1-%ld FOR INDIVIDUAL PLAYER.",ud.multimode);
					//gametext(320>>1,j,buf,0,2+8+16); j += 8;
					//gametext(320>>1,j,"'A' OR 'ENTER' FOR ALL PLAYERS",0,2+8+16); j += 8;
					//gametext(320>>1,j,"ESC ABORTS",0,2+8+16); j += 8;

					if (ud.screen_size > 0)
					{
						j = (short)(200 - 45);
					}
					else
					{
						j = (short)(200 - 8);
					}
					gametext(320 >> 1, j, typebuf, 0, (short)(2 + 8 + 16));

					if (KB_KeyWaiting() != null)
					{
						 i = KB_GetCh();

						 if (i == 'A' || i == 'a' || i == 13)
						 {
							  sendmessagecommand = ud.multimode;
						 }
						 else if (i >= '1' || i <= (ud.multimode + '1'))
						 {
							  sendmessagecommand = i - '1';
						 }
						 else
						 {
							sendmessagecommand = ud.multimode;
							  if (i == 27)
							  {
								  ps[myconnectindex].gm &= ~(DefineConstants.MODE_TYPE | DefineConstants.MODE_SENDTOWHOM);
								  sendmessagecommand = -1;
							  }
							  else
							  {
							  typebuf[0] = 0;
							  }
						 }

						 {
							 KB_KeyDown[(DefineConstants.sc_1)] = (!(1 == 1));
					 };
					 {
							 KB_KeyDown[(DefineConstants.sc_2)] = (!(1 == 1));
					 };
					 {
							 KB_KeyDown[(DefineConstants.sc_3)] = (!(1 == 1));
					 };
					 {
							 KB_KeyDown[(DefineConstants.sc_4)] = (!(1 == 1));
					 };
					 {
							 KB_KeyDown[(DefineConstants.sc_5)] = (!(1 == 1));
					 };
					 {
							 KB_KeyDown[(DefineConstants.sc_6)] = (!(1 == 1));
					 };
					 {
							 KB_KeyDown[(DefineConstants.sc_7)] = (!(1 == 1));
					 };
					 {
							 KB_KeyDown[(DefineConstants.sc_8)] = (!(1 == 1));
					 };
					 {
							 KB_KeyDown[(DefineConstants.sc_A)] = (!(1 == 1));
					 };
					 {
							 KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
					 };
					 {
							 KB_KeyDown[(DefineConstants.sc_Return)] = (!(1 == 1));
					 };
					}
			  }
		 }
		 else
		 {
			  if (ud.screen_size > 0)
			  {
				  j = (short)(200 - 45);
			  }
			  else
			  {
				  j = (short)(200 - 8);
			  }
			  hitstate = strget((short)(320 >> 1), j, ref typebuf, 30, 1);

			  if (hitstate == 1)
			  {
					{
						KB_KeyDown[(DefineConstants.sc_Return)] = (!(1 == 1));
				};
					ps[myconnectindex].gm |= DefineConstants.MODE_SENDTOWHOM;
			  }
			  else if (hitstate == -1)
			  {
					ps[myconnectindex].gm &= ~(DefineConstants.MODE_TYPE | DefineConstants.MODE_SENDTOWHOM);
			  }
			  else
			  {
				  pub = DefineConstants.NUMPAGES;
			  }
		 }
	}

	public static void moveclouds()
	{
		if (totalclock > cloudtotalclock || totalclock < (cloudtotalclock - 7))
		{
			short i;

			cloudtotalclock = totalclock + 6;

			for (i = 0;i < numclouds;i++)
			{
				cloudx[i] += (sintable[(ps[screenpeek].ang + 512) & 2047] >> 9);
				cloudy[i] += (sintable[ps[screenpeek].ang & 2047] >> 9);

				Engine.board.sector[clouds[i]].ceilingxpanning = cloudx[i] >> 6;
				Engine.board.sector[clouds[i]].ceilingypanning = cloudy[i] >> 6;
			}
		}
	}


	public static void updatesectorz(int x, int y, int z, ref short sectnum)
	{
//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
		walltype * wal = new walltype();
		int i;
		int j;
		int cz;
		int fz;

		getzsofslope(sectnum, x, y, cz, fz);
		if ((z >= cz) && (z <= fz))
		{
			if (inside(x,y, sectnum) != 0)
			{
				return;
			}
		}

		if ((sectnum >= null) && (sectnum < numsectors))
		{
			wal = &Engine.board.wall[Engine.board.sector[sectnum].wallptr];
			j = Engine.board.sector[sectnum].wallnum;
			do
			{
				i = wal.nextsector;
				if (i >= 0)
				{
					getzsofslope(i, x, y, cz, fz);
					if ((z >= cz) && (z <= fz))
					{
						if (inside(x,y,(short)i) == 1)
						{
								sectnum = (short)i;
								return;
						}
					}
				}
				wal++;
				j--;
			} while (j != 0);
		}

		for (i = numsectors - 1;i >= 0;i--)
		{
			getzsofslope(i, x, y, cz, fz);
			if ((z >= cz) && (z <= fz))
			{
				if (inside(x,y,(short)i) == 1)
				{
						sectnum = (short)i;
						return;
				}
			}
		}

		sectnum = -1;
	}


		//REPLACE FULLY
	


	// Floor Over Floor

	// If standing in sector with SE42
	// then draw viewing to SE41 and raise all =hi SE43 cielings.

	// If standing in sector with SE43
	// then draw viewing to SE40 and lower all =hi SE42 floors.

	// If standing in sector with SE44
	// then draw viewing to SE40.

	// If standing in sector with SE45
	// then draw viewing to SE41.

	public static int[] tempsectorz = new int[DefineConstants.MAXSECTORS];
	public static int[] tempsectorpicnum = new int[DefineConstants.MAXSECTORS];
	//short tempcursectnum;

//C++ TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
	public static SE40_Draw(int spnum,int x,int y,int z,short a,short h,int smoothratio)
	{
	 int i = 0;
	 int j = 0;
	 int k = 0;
	 int floor1 = 0;
	 int floor2 = 0;
	 int ok = 0;
	 int fofmode = 0;
	 int offx;
	 int offy;

	 if (Engine.board.sprite[spnum].ang != 512)
	 {
		 return;
	 }

	 i = DefineConstants.FOFTILE; //Effect TILE
	 if ((gotpic[i >> 3] & (1 << (i & 7))) == 0)
	 {
		 return;
	 }
	 gotpic[i >> 3] &= ~(1 << (i & 7));

	 floor1 = spnum;

	 if (Engine.board.sprite[spnum].lotag == 42)
	 {
		 fofmode = 40;
	 }
	 if (Engine.board.sprite[spnum].lotag == 43)
	 {
		 fofmode = 41;
	 }
	 if (Engine.board.sprite[spnum].lotag == 44)
	 {
		 fofmode = 40;
	 }
	 if (Engine.board.sprite[spnum].lotag == 45)
	 {
		 fofmode = 41;
	 }

	// fofmode=Engine.board.sprite[spnum].lotag-2;

	// sectnum=Engine.board.sprite[j].sectnum;
	// sectnum=cursectnum;
	 ok++;

	/*  recursive?
	 for(j=0;j<MAXSPRITES;j++)
	 {
	  if(
	     Engine.board.sprite[j].sectnum==sectnum &&
	     Engine.board.sprite[j].picnum==1 &&
	     Engine.board.sprite[j].lotag==110
	    ) { DrawFloorOverFloor(j); break;}
	 }
	*/

	// if(ok==0) { Message("no fof",RED); return; }

	 for (j = 0;j < DefineConstants.MAXSPRITES;j++)
	 {
	  if (Engine.board.sprite[j].picnum == 1 && Engine.board.sprite[j].lotag == fofmode && Engine.board.sprite[j].hitag == Engine.board.sprite[floor1].hitag)
	  {
		  floor1 = j;
		  fofmode = Engine.board.sprite[j].lotag;
		  ok++;
		  break;
	  }
	 }
	// if(ok==1) { Message("no floor1",RED); return; }

	 if (fofmode == 40)
	 {
		 k = 41;
	 }
	 else
	 {
		 k = 40;
	 }

	 for (j = 0;j < DefineConstants.MAXSPRITES;j++)
	 {
	  if (Engine.board.sprite[j].picnum == 1 && Engine.board.sprite[j].lotag == k && Engine.board.sprite[j].hitag == Engine.board.sprite[floor1].hitag)
	  {
		  floor2 = j;
		  ok++;
		  break;
	  }
	 }

	// if(ok==2) { Message("no floor2",RED); return; }

	 for (j = 0;j < DefineConstants.MAXSPRITES;j++) // raise ceiling or floor
	 {
	  if (Engine.board.sprite[j].picnum == 1 && Engine.board.sprite[j].lotag == k + 2 && Engine.board.sprite[j].hitag == Engine.board.sprite[floor1].hitag)
	  {
		 if (k == 40)
		 {
			 tempsectorz[Engine.board.sprite[j].sectnum] = Engine.board.sector[Engine.board.sprite[j].sectnum].floorz;
		  Engine.board.sector[Engine.board.sprite[j].sectnum].floorz += (((z - Engine.board.sector[Engine.board.sprite[j].sectnum].floorz) / 32768) + 1) * 32768;
		  tempsectorpicnum[Engine.board.sprite[j].sectnum] = Engine.board.sector[Engine.board.sprite[j].sectnum].floorpicnum;
		  Engine.board.sector[Engine.board.sprite[j].sectnum].floorpicnum = 13;
		 }
		 if (k == 41)
		 {
			 tempsectorz[Engine.board.sprite[j].sectnum] = Engine.board.sector[Engine.board.sprite[j].sectnum].ceilingz;
		  Engine.board.sector[Engine.board.sprite[j].sectnum].ceilingz += (((z - Engine.board.sector[Engine.board.sprite[j].sectnum].ceilingz) / 32768) - 1) * 32768;
		  tempsectorpicnum[Engine.board.sprite[j].sectnum] = Engine.board.sector[Engine.board.sprite[j].sectnum].ceilingpicnum;
		  Engine.board.sector[Engine.board.sprite[j].sectnum].ceilingpicnum = 13;
		 }
	  }
	 }

	 i = floor1;
	 offx = x - Engine.board.sprite[i].x;
	 offy = y - Engine.board.sprite[i].y;
	 i = floor2;
	 drawrooms(offx + Engine.board.sprite[i].x,offy + Engine.board.sprite[i].y,z,a,h,Engine.board.sprite[i].sectnum);
	 animatesprites(x, y, a, smoothratio);
	 drawmasks();

	 for (j = 0;j < DefineConstants.MAXSPRITES;j++) // restore ceiling or floor
	 {
	  if (Engine.board.sprite[j].picnum == 1 && Engine.board.sprite[j].lotag == k + 2 && Engine.board.sprite[j].hitag == Engine.board.sprite[floor1].hitag)
	  {
		 if (k == 40)
		 {
			 Engine.board.sector[Engine.board.sprite[j].sectnum].floorz = tempsectorz[Engine.board.sprite[j].sectnum];
		  Engine.board.sector[Engine.board.sprite[j].sectnum].floorpicnum = tempsectorpicnum[Engine.board.sprite[j].sectnum];
		 }
		 if (k == 41)
		 {
			 Engine.board.sector[Engine.board.sprite[j].sectnum].ceilingz = tempsectorz[Engine.board.sprite[j].sectnum];
		  Engine.board.sector[Engine.board.sprite[j].sectnum].ceilingpicnum = tempsectorpicnum[Engine.board.sprite[j].sectnum];
		 }
	  } // end if
	 } // end for

	} // end SE40




	public static void se40code(int x,int y,int z,int a,int h, int smoothratio)
	{
		int i;

		i = Engine.board.headspritestat[15];
		while (i >= 0)
		{
			switch (Engine.board.sprite[i].lotag)
			{
	//            case 40:
	//            case 41:
	//                SE40_Draw(i,x,y,a,smoothratio);
	//                break;
				case 42:
				case 43:
				case 44:
				case 45:
					if (ps[screenpeek].cursectnum == Engine.board.sprite[i].sectnum)
					{
						SE40_Draw(i, x, y, z, (short)a, (short)h, smoothratio);
					}
					break;
			}
			i = Engine.board.nextspritestat[i];
		}
	}

	

	




	


	public static string[] cheatquotes = {"cornholio", "stuff", "scotty###", "coords", "view", "time", "unlock", "cashman", "items", "rate", "skill#", "beta", "hyper", "monsters", "<RESERVED>", "<RESERVED>", "todd", "showmap", "kroz", "allen", "clip", "weapons", "inventory", "keys", "debug"};


	public static string cheatbuf = new string(new char[10]);
	public static char cheatbuflen;
	public static void cheats()
	{
	// jmarshall - cheats

		short ch;
		short i;
		short j;
		short k;
		short keystate;
		short weapon;

		if ((ps[myconnectindex].gm & DefineConstants.MODE_TYPE) != 0 || (ps[myconnectindex].gm & DefineConstants.MODE_MENU) != 0)
		{
			return;
		}

#if BETA
		return;
#endif

		if (ps[myconnectindex].cheat_phase == 1)
		{
		   while (KB_KeyWaiting() != null)
		   {
			  ch = KB_Getch();
			  ch = tolower(ch);

			  if (!((ch >= 'a' && ch <= 'z') || (ch >= '0' && ch <= '9')))
			  {
				 ps[myconnectindex].cheat_phase = 0;
	//             FTA(46,&ps[myconnectindex]);
				 return;
			  }

			  cheatbuf = StringFunctions.ChangeCharacter(cheatbuf, cheatbuflen++, ch);
			  cheatbuf = cheatbuf.Substring(0, cheatbuflen);

			  if (cheatbuflen > 11)
			  {
				  ps[myconnectindex].cheat_phase = 0;
				  return;
			  }

			  for (k = 0;k < NUMCHEATCODES;k++)
			  {
				  for (j = 0;j < cheatbuflen;j++)
				  {
					  if (cheatbuf[j] == cheatquotes[k][j] || (cheatquotes[k][j] == '#' && ch >= '0' && ch <= '9'))
					  {
						  if (cheatquotes[k][j + 1] == 0)
						  {
							  goto FOUNDCHEAT;
						  }
						  if (j == cheatbuflen - 1)
						  {
							  return;
						  }
					  }
					  else
					  {
						  break;
					  }
				  }
			  }

			  ps[myconnectindex].cheat_phase = 0;
			  return;

			  FOUNDCHEAT:
			  {
					switch (k)
					{
						case 21:
#if VOLUMEONE
							j = 6;
#else
							j = 0;
#endif

							for (weapon = DefineConstants.PISTOL_WEAPON;weapon < DefineConstants.MAX_WEAPONS - j;weapon++)
							{
								addammo(weapon, ps[myconnectindex], max_ammo_amount[weapon]);
								ps[myconnectindex].gotweapon[weapon] = 1;
							}

							KB_FlushKeyBoardQueue();
							ps[myconnectindex].cheat_phase = 0;
							FTA(119, ps[myconnectindex]);
							return;
						case 22:
							KB_FlushKeyBoardQueue();
							ps[myconnectindex].cheat_phase = 0;
							ps[myconnectindex].steroids_amount = 400;
							ps[myconnectindex].heat_amount = 1200;
							ps[myconnectindex].boot_amount = 200;
							ps[myconnectindex].shield_amount = 100;
							ps[myconnectindex].scuba_amount = 6400;
							ps[myconnectindex].holoduke_amount = 2400;
							ps[myconnectindex].jetpack_amount = 1600;
							ps[myconnectindex].firstaid_amount = max_player_health;
							FTA(120, ps[myconnectindex]);
							ps[myconnectindex].cheat_phase = 0;
							return;
						case 23:
							ps[myconnectindex].got_access = 7;
							KB_FlushKeyBoardQueue();
							ps[myconnectindex].cheat_phase = 0;
							FTA(121, ps[myconnectindex]);
							return;
						case 24:
							debug_on = 1 - debug_on;
							KB_FlushKeyBoardQueue();
							ps[myconnectindex].cheat_phase = 0;
							break;
						case 20:
							ud.clipping = 1 - ud.clipping;
							KB_FlushKeyBoardQueue();
							ps[myconnectindex].cheat_phase = 0;
							FTA(112 + ud.clipping, ps[myconnectindex]);
							return;

						case 15:
							ps[myconnectindex].gm = DefineConstants.MODE_EOL;
							ps[myconnectindex].cheat_phase = 0;
							KB_FlushKeyBoardQueue();
							return;

						case 19:
							FTA(79, ps[myconnectindex]);
							ps[myconnectindex].cheat_phase = 0;
							{
								KB_KeyDown[(DefineConstants.sc_N)] = (!(1 == 1));
							};
							return;
						case 0:
						case 18:

							ud.god = 1 - ud.god;

							if (ud.god)
							{
								pus = 1;
								pub = 1;
								Engine.board.sprite[ps[myconnectindex].i].cstat = 257;

								hittype[ps[myconnectindex].i].temp_data[0] = 0;
								hittype[ps[myconnectindex].i].temp_data[1] = 0;
								hittype[ps[myconnectindex].i].temp_data[2] = 0;
								hittype[ps[myconnectindex].i].temp_data[3] = 0;
								hittype[ps[myconnectindex].i].temp_data[4] = 0;
								hittype[ps[myconnectindex].i].temp_data[5] = 0;

								Engine.board.sprite[ps[myconnectindex].i].hitag = 0;
								Engine.board.sprite[ps[myconnectindex].i].lotag = 0;
								Engine.board.sprite[ps[myconnectindex].i].pal = ps[myconnectindex].palookup;

								FTA(17, ps[myconnectindex]);
							}
							else
							{
								ud.god = 0;
								Engine.board.sprite[ps[myconnectindex].i].extra = max_player_health;
								hittype[ps[myconnectindex].i].extra = -1;
								ps[myconnectindex].last_extra = max_player_health;
								FTA(18, ps[myconnectindex]);
							}

							Engine.board.sprite[ps[myconnectindex].i].extra = max_player_health;
							hittype[ps[myconnectindex].i].extra = 0;
							ps[myconnectindex].cheat_phase = 0;
							KB_FlushKeyBoardQueue();

							return;

						case 1:

#if VOLUMEONE
							j = 6;
#else
							j = 0;
#endif
							for (weapon = DefineConstants.PISTOL_WEAPON;weapon < DefineConstants.MAX_WEAPONS - j;weapon++)
							{
							   ps[myconnectindex].gotweapon[weapon] = 1;
							}

							for (weapon = DefineConstants.PISTOL_WEAPON; weapon < (DefineConstants.MAX_WEAPONS - j); weapon++)
							{
								addammo(weapon, ps[myconnectindex], max_ammo_amount[weapon]);
							}

							ps[myconnectindex].ammo_amount[DefineConstants.GROW_WEAPON] = 50;

							ps[myconnectindex].steroids_amount = 400;
							ps[myconnectindex].heat_amount = 1200;
							ps[myconnectindex].boot_amount = 200;
							ps[myconnectindex].shield_amount = 100;
							ps[myconnectindex].scuba_amount = 6400;
							ps[myconnectindex].holoduke_amount = 2400;
							ps[myconnectindex].jetpack_amount = 1600;
							ps[myconnectindex].firstaid_amount = max_player_health;

							ps[myconnectindex].got_access = 7;
							FTA(5, ps[myconnectindex]);
							ps[myconnectindex].cheat_phase = 0;


	//                        FTA(21,&ps[myconnectindex]);
							ps[myconnectindex].cheat_phase = 0;
							KB_FlushKeyBoardQueue();
							ps[myconnectindex].inven_icon = 1;
							return;

						case 2:
						case 10:
#if ONELEVELDEMO
		ps[myconnectindex].cheat_phase = 0;
		break;
#endif

							if (k == 2)
							{
								short volnume;
								short levnume;
#if !DEMO
								volnume = cheatbuf[6] - '0';
								levnume = (cheatbuf[7] - '0') * 10 + (cheatbuf[8] - '0');
#else
								volnume = cheatbuf[6] - '0';
								levnume = cheatbuf[7] - '0';
#endif

								volnume--;
								levnume--;
#if VOLUMEONE
								if (volnume > 0)
								{
									ps[myconnectindex].cheat_phase = 0;
									KB_FlushKeyBoardQueue();
									return;
								}
#endif
#if !DEMO
								if (volnume > 4)
								{
									ps[myconnectindex].cheat_phase = 0;
									KB_FlushKeyBoardQueue();
									return;
								}
								else
								{
#else
								if (volnume > 3)
								{
									ps[myconnectindex].cheat_phase = 0;
									KB_FlushKeyBoardQueue();
									return;
								}
								else
								{
#endif

								if (volnume == 0)
								{
									if (levnume > 5)
									{
										ps[myconnectindex].cheat_phase = 0;
										KB_FlushKeyBoardQueue();
										return;
									}
								}
								else
								{
									if (levnume >= 11)
									{
										ps[myconnectindex].cheat_phase = 0;
										KB_FlushKeyBoardQueue();
										return;
									}
								}
								}
							}

								ud.m_volume_number = ud.volume_number = volnume;
								ud.m_level_number = ud.level_number = levnume;

							break;
					}
							else
							{
								ud.m_player_skill = ud.player_skill = cheatbuf[5] - '1';
							}

							if (numplayers > 1 && myconnectindex == connecthead)
							{
								tempbuf[0] = 5;
								tempbuf[1] = ud.m_level_number;
								tempbuf[2] = ud.m_volume_number;
								tempbuf[3] = ud.m_player_skill;
								tempbuf[4] = ud.m_monsters_off;
								tempbuf[5] = ud.m_respawn_monsters;
								tempbuf[6] = ud.m_respawn_items;
								tempbuf[7] = ud.m_respawn_inventory;
								tempbuf[8] = ud.m_coop;
								tempbuf[9] = ud.m_marker;
								tempbuf[10] = ud.m_ffire;

								for (i = connecthead;i >= 0;i = connectpoint2[i])
								{
									sendpacket(i,tempbuf,11);
								}
							}
							else
							{
								ps[myconnectindex].gm |= DefineConstants.MODE_RESTART;
							}

							ps[myconnectindex].cheat_phase = 0;
							KB_FlushKeyBoardQueue();
							return;

						case 3:
							ps[myconnectindex].cheat_phase = 0;
							ud.coords = 1 - ud.coords;
							KB_FlushKeyBoardQueue();
							return;

						case 4:
							if (ps[myconnectindex].over_shoulder_on)
							{
								ps[myconnectindex].over_shoulder_on = 0;
							}
							else
							{
								ps[myconnectindex].over_shoulder_on = 1;
								cameradist = 0;
								cameraclock = totalclock;
							}
							FTA(22, ps[myconnectindex]);
							ps[myconnectindex].cheat_phase = 0;
							KB_FlushKeyBoardQueue();
							return;
						case 5:

							FTA(21, ps[myconnectindex]);
							ps[myconnectindex].cheat_phase = 0;
							KB_FlushKeyBoardQueue();
							return;
#if !VOLUMEONE
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 6:
							for (i = numsectors - 1;i >= 0;i--) //Unlock
							{
								j = Engine.board.sector[i].lotag;
								if (j == -1 || j == 32767)
								{
									continue;
								}
								if ((j & 0x7fff) > 2)
								{
									if ((j & (0xffff - 16384)) != 0)
									{
										Engine.board.sector[i].lotag &= (0xffff - 16384);
									}
									operatesectors(i, ps[myconnectindex].i);
								}
							}
							operateforcefields(ps[myconnectindex].i, -1);

							FTA(100, ps[myconnectindex]);
							ps[myconnectindex].cheat_phase = 0;
							KB_FlushKeyBoardQueue();
							return;
#endif

//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 7:
							ud.cashman = 1 - ud.cashman;
							{
								KB_KeyDown[(DefineConstants.sc_N)] = (!(1 == 1));
							};
							ps[myconnectindex].cheat_phase = 0;
							return;
						case 8:

							ps[myconnectindex].steroids_amount = 400;
							ps[myconnectindex].heat_amount = 1200;
							ps[myconnectindex].boot_amount = 200;
							ps[myconnectindex].shield_amount = 100;
							ps[myconnectindex].scuba_amount = 6400;
							ps[myconnectindex].holoduke_amount = 2400;
							ps[myconnectindex].jetpack_amount = 1600;

							ps[myconnectindex].firstaid_amount = max_player_health;
							ps[myconnectindex].got_access = 7;
							FTA(5, ps[myconnectindex]);
							ps[myconnectindex].cheat_phase = 0;
							KB_FlushKeyBoardQueue();
							return;
						case 17: // SHOW ALL OF THE MAP TOGGLE;
							ud.showallmap = 1 - ud.showallmap;
							if (ud.showallmap)
							{
								for (i = 0;i < (DefineConstants.MAXSECTORS>>3);i++)
								{
									show2dEngine.board.sector[i] = 255;
								}
								for (i = 0;i < (DefineConstants.MAXWALLS>>3);i++)
								{
									show2dwall[i] = 255;
								}
								FTA(111, ps[myconnectindex]);
							}
							else
							{
								for (i = 0;i < (DefineConstants.MAXSECTORS>>3);i++)
								{
									show2dEngine.board.sector[i] = 0;
								}
								for (i = 0;i < (DefineConstants.MAXWALLS>>3);i++)
								{
									show2dwall[i] = 0;
								}
								FTA(1, ps[myconnectindex]);
							}
							ps[myconnectindex].cheat_phase = 0;
							KB_FlushKeyBoardQueue();
							return;

						case 16:
							FTA(99, ps[myconnectindex]);
							ps[myconnectindex].cheat_phase = 0;
							KB_FlushKeyBoardQueue();
							return;
						case 9:
							ud.tickrate = !ud.tickrate;
							ps[myconnectindex].cheat_phase = 0;
							KB_FlushKeyBoardQueue();
							return;
						case 11:
							FTA(105, ps[myconnectindex]);
							{
								KB_KeyDown[(DefineConstants.sc_H)] = (!(1 == 1));
							};
							ps[myconnectindex].cheat_phase = 0;
							KB_FlushKeyBoardQueue();
							return;
						case 12:
							ps[myconnectindex].steroids_amount = 399;
							ps[myconnectindex].heat_amount = 1200;
							ps[myconnectindex].cheat_phase = 0;
							FTA(37, ps[myconnectindex]);
							KB_FlushKeyBoardQueue();
							return;
						case 13:
							if (actor_tog == 3)
							{
								actor_tog = 0;
							}
							actor_tog++;
							ps[screenpeek].cheat_phase = 0;
							KB_FlushKeyBoardQueue();
							return;
						case 14:
						case 25:
							ud.eog = 1;
							ps[myconnectindex].gm |= DefineConstants.MODE_EOL;
							KB_FlushKeyBoardQueue();
							return;
			  }
		   }
		}
	}

		else
		{
			if ((KB_KeyDown[(DefineConstants.sc_D)] != 0))
			{
				if (ps[myconnectindex].cheat_phase >= 0 && numplayers < 2 && ud.recstat == 0)
				{
					ps[myconnectindex].cheat_phase = -1;
				}
			}

			if ((KB_KeyDown[(DefineConstants.sc_N)] != 0))
			{
				if (ps[myconnectindex].cheat_phase == -1)
				{
					if (ud.player_skill == 4)
					{
						FTA(22, ps[myconnectindex]);
						ps[myconnectindex].cheat_phase = 0;
					}
					else
					{
						ps[myconnectindex].cheat_phase = 1;
	//                    FTA(25,&ps[myconnectindex]);
						cheatbuflen = 0;
					}
					KB_FlushKeyboardQueue();
				}
				else if (ps[myconnectindex].cheat_phase != 0)
				{
					ps[myconnectindex].cheat_phase = 0;
					{
						KB_KeyDown[(DefineConstants.sc_D)] = (!(1 == 1));
					};
					{
						KB_KeyDown[(DefineConstants.sc_N)] = (!(1 == 1));
				};
				}
			}
		}
}


	int nonsharedtimer;
	void nonsharedkeys()
	{
		short i;
		short ch;
		short weapon;
		int j;

		if (ud.recstat == 2)
		{
			ControlInfo noshareinfo = new ControlInfo();
			CONTROL_GetInput(noshareinfo);
		}

		if ((KB_KeyDown[(DefineConstants.sc_F12)] != 0))
		{
			{
				KB_KeyDown[(DefineConstants.sc_F12)] = (!(1 == 1));
		};
			screencapture("duke0000.pcx",0);
			FTA(103, ps[myconnectindex]);
		}

		if (!((KB_KeyDown[(DefineConstants.sc_RightAlt)] != 0) || (KB_KeyDown[(DefineConstants.sc_LeftAlt)] != 0)) && ud.overhead_on == 0)
		{
				if ((((gamefunc_Enlarge_Screen) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Enlarge_Screen) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Enlarge_Screen)) & 1)) != 0)
				{
					CONTROL_ClearButton(gamefunc_Enlarge_Screen);
					if (ud.screen_size > 0)
					{
						sound(DefineConstants.THUD);
					}
					ud.screen_size -= 4;
					vscrn();
				}
				if ((((gamefunc_Shrink_Screen) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Shrink_Screen) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Shrink_Screen)) & 1)) != 0)
				{
					CONTROL_ClearButton(gamefunc_Shrink_Screen);
					if (ud.screen_size < 64)
					{
						sound(DefineConstants.THUD);
					}
					ud.screen_size += 4;
					vscrn();
				}
		}

		if (ps[myconnectindex].cheat_phase == 1 || (ps[myconnectindex].gm & (DefineConstants.MODE_MENU | DefineConstants.MODE_TYPE)) != 0)
		{
			return;
		}

		if ((((gamefunc_See_Coop_View) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_See_Coop_View) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_See_Coop_View)) & 1)) != 0 && (ud.coop == 1 || ud.recstat == 2))
		{
			CONTROL_ClearButton(gamefunc_See_Coop_View);
			screenpeek = connectpoint2[screenpeek];
			if (screenpeek == -1)
			{
				screenpeek = connecthead;
			}
			restorepalette = 1;
		}

		if (ud.multimode > 1 && (((gamefunc_Show_Opponents_Weapon) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Show_Opponents_Weapon) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Show_Opponents_Weapon)) & 1)) != 0)
		{
			CONTROL_ClearButton(gamefunc_Show_Opponents_Weapon);
			ud.showweapons = 1 - ud.showweapons;
			FTA(82 - ud.showweapons, ps[screenpeek]);
		}

		if ((((gamefunc_Toggle_Crosshair) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Toggle_Crosshair) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Toggle_Crosshair)) & 1)) != 0)
		{
			CONTROL_ClearButton(gamefunc_Toggle_Crosshair);
			ud.crosshair = 1 - ud.crosshair;
			FTA(21 - ud.crosshair, ps[screenpeek]);
		}

		if (ud.overhead_on && (((gamefunc_Map_Follow_Mode) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Map_Follow_Mode) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Map_Follow_Mode)) & 1)) != 0)
		{
			CONTROL_ClearButton(gamefunc_Map_Follow_Mode);
			ud.scrollmode = 1 - ud.scrollmode;
			if (ud.scrollmode)
			{
				ud.folx = ps[screenpeek].oposx;
				ud.foly = ps[screenpeek].oposy;
				ud.fola = ps[screenpeek].oang;
			}
			FTA(83 + ud.scrollmode, ps[myconnectindex]);
		}

		if (((KB_KeyDown[(DefineConstants.sc_RightShift)] != 0) || (KB_KeyDown[(DefineConstants.sc_LeftShift)] != 0)) || ((KB_KeyDown[(DefineConstants.sc_RightAlt)] != 0) || (KB_KeyDown[(DefineConstants.sc_LeftAlt)] != 0)))
		{
			i = 0;
			if ((KB_KeyDown[(DefineConstants.sc_F1)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F1)] = (!(1 == 1));
			};
				i = 1;
			}
			if ((KB_KeyDown[(DefineConstants.sc_F2)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F2)] = (!(1 == 1));
			};
				i = 2;
			}
			if ((KB_KeyDown[(DefineConstants.sc_F3)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F3)] = (!(1 == 1));
			};
				i = 3;
			}
			if ((KB_KeyDown[(DefineConstants.sc_F4)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F4)] = (!(1 == 1));
			};
				i = 4;
			}
			if ((KB_KeyDown[(DefineConstants.sc_F5)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F5)] = (!(1 == 1));
			};
				i = 5;
			}
			if ((KB_KeyDown[(DefineConstants.sc_F6)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F6)] = (!(1 == 1));
			};
				i = 6;
			}
			if ((KB_KeyDown[(DefineConstants.sc_F7)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F7)] = (!(1 == 1));
			};
				i = 7;
			}
			if ((KB_KeyDown[(DefineConstants.sc_F8)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F8)] = (!(1 == 1));
			};
				i = 8;
			}
			if ((KB_KeyDown[(DefineConstants.sc_F9)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F9)] = (!(1 == 1));
			};
				i = 9;
			}
			if ((KB_KeyDown[(DefineConstants.sc_F10)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F10)] = (!(1 == 1));
			};
				i = 10;
			}

			if (i != 0)
			{
				if (((KB_KeyDown[(DefineConstants.sc_RightShift)] != 0) || (KB_KeyDown[(DefineConstants.sc_LeftShift)] != 0)))
				{
					if (i == 5 && ps[myconnectindex].fta > 0 && ps[myconnectindex].ftq == 26)
					{
						music_select++;
#if !DEMO
						if (music_select == 44)
						{
							music_select = 0;
						}
#else
						if (music_select == 6)
						{
							music_select = 0;
						}
#endif
						strcpy(tempbuf[0], "PLAYING ");
						strcat(tempbuf[0], music_fn[0][music_select][0]);
						playmusic(ref music_fn[0][music_select][0]);
						strcpy(fta_quotes[26][0], tempbuf[0]);
						FTA(26, ps[myconnectindex]);
						return;
					}

					adduserquote(ref ud.ridecule[i - 1]);

					ch = 0;

					tempbuf[ch] = 4;
					tempbuf[ch + 1] = 0;
					strcat(tempbuf + 1,ud.ridecule[i - 1]);

					i = 1 + strlen(ud.ridecule[i - 1]);

					if (ud.multimode > 1)
					{
						for (ch = connecthead;ch >= 0;ch = connectpoint2[ch])
						{
							if (ch != myconnectindex)
							{
								sendpacket(ch,tempbuf,i);
							}
						}
					}

					pus = DefineConstants.NUMPAGES;
					pub = DefineConstants.NUMPAGES;

					return;

				}

				if (ud.lockout == 0)
				{
					if (SoundToggle && ((KB_KeyDown[(DefineConstants.sc_RightAlt)] != 0) || (KB_KeyDown[(DefineConstants.sc_LeftAlt)] != 0)) && (RTS_NumSounds() > 0) && rtsplaying == 0 && VoiceToggle)
					{
					rtsptr = (string)RTS_GetSound(i - 1);
					if (rtsptr == 'C')
					{
						FX_PlayVOC3D(ref rtsptr, 0, 0, 0, 255, (uint)(-i));
					}
					else
					{
						FX_PlayWAV3D(ref rtsptr, 0, 0, 0, 255, (uint)(-i));
					}

					rtsplaying = 7;

					if (ud.multimode > 1)
					{
						tempbuf[0] = 7;
						tempbuf[1] = i;

						for (ch = connecthead;ch >= 0;ch = connectpoint2[ch])
						{
							if (ch != myconnectindex)
							{
								sendpacket(ch,tempbuf,2);
							}
						}
					}

					pus = DefineConstants.NUMPAGES;
					pub = DefineConstants.NUMPAGES;

					return;
					}
				}
			}
		}

		if (!((KB_KeyDown[(DefineConstants.sc_RightAlt)] != 0) || (KB_KeyDown[(DefineConstants.sc_LeftAlt)] != 0)) && !((KB_KeyDown[(DefineConstants.sc_RightShift)] != 0) || (KB_KeyDown[(DefineConstants.sc_LeftShift)] != 0)))
		{

			if (ud.multimode > 1 && (((gamefunc_SendMessage) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_SendMessage) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_SendMessage)) & 1)) != 0)
			{
				KB_FlushKeyboardQueue();
				CONTROL_ClearButton(gamefunc_SendMessage);
				ps[myconnectindex].gm |= DefineConstants.MODE_TYPE;
				typebuf[0] = 0;
				inputloc = 0;
			}

			if ((KB_KeyDown[(DefineConstants.sc_F1)] != 0) || (ud.show_help && ((KB_KeyDown[(DefineConstants.sc_Space)] != 0) || (KB_KeyDown[(DefineConstants.sc_Return)] != 0) || (KB_KeyDown[(DefineConstants.sc_kpad_Enter)] != 0))))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F1)] = (!(1 == 1));
			};
			{
					KB_KeyDown[(DefineConstants.sc_Space)] = (!(1 == 1));
			};
			{
					KB_KeyDown[(DefineConstants.sc_kpad_Enter)] = (!(1 == 1));
			};
			{
					KB_KeyDown[(DefineConstants.sc_Return)] = (!(1 == 1));
			};
				ud.show_help++;

				if (ud.show_help > 2)
				{
					ud.show_help = 0;
					if (ud.multimode < 2 && ud.recstat != 2)
					{
						ready2send = 1;
					}
					vscrn();
				}
				else
				{
					setview(0,0,Engine.xdim - 1,Engine.ydim - 1);
					if (ud.multimode < 2 && ud.recstat != 2)
					{
						ready2send = 0;
						totalclock = ototalclock;
					}
				}
			}

			{
	//        if(ud.multimode < 2)
				if (ud.recstat != 2 && (KB_KeyDown[(DefineConstants.sc_F2)] != 0))
				{
					{
						KB_KeyDown[(DefineConstants.sc_F2)] = (!(1 == 1));
				};

					if (movesperpacket == 4 && connecthead != myconnectindex)
					{
						return;
					}

					FAKE_F2:
					if (Engine.board.sprite[ps[myconnectindex].i].extra <= 0)
					{
						FTA(118, ps[myconnectindex]);
						return;
					}
					cmenu(350);
					screencapt = 1;
					displayrooms(myconnectindex, 65536);
					savetemp("duke3d.tmp", waloff[DefineConstants.MAXTILES - 1], 160 * 100);
					screencapt = 0;
					FX_StopAllSounds();
					clearsoundlocks();

	//                setview(0,0,Engine.xdim-1,Engine.ydim-1);
					ps[myconnectindex].gm |= DefineConstants.MODE_MENU;

					if (ud.multimode < 2)
					{
						ready2send = 0;
						totalclock = ototalclock;
						screenpeek = myconnectindex;
					}
				}

				if ((KB_KeyDown[(DefineConstants.sc_F3)] != 0))
				{
					{
						KB_KeyDown[(DefineConstants.sc_F3)] = (!(1 == 1));
				};

					if (movesperpacket == 4 && connecthead != myconnectindex)
					{
						return;
					}

					cmenu(300);
					FX_StopAllSounds();
					clearsoundlocks();

	//                setview(0,0,Engine.xdim-1,Engine.ydim-1);
					ps[myconnectindex].gm |= DefineConstants.MODE_MENU;
					if (ud.multimode < 2 && ud.recstat != 2)
					{
						ready2send = 0;
						totalclock = ototalclock;
					}
					screenpeek = myconnectindex;
				}
		}

			if ((KB_KeyDown[(DefineConstants.sc_F4)] != 0) && FXDevice != soundcardnames.NumSoundCards)
			{
				{
					KB_KeyDown[(DefineConstants.sc_F4)] = (!(1 == 1));
			};
				FX_StopAllSounds();
				clearsoundlocks();

				ps[myconnectindex].gm |= DefineConstants.MODE_MENU;
				if (ud.multimode < 2 && ud.recstat != 2)
				{
					ready2send = 0;
					totalclock = ototalclock;
				}
				cmenu(700);

			}

			if ((KB_KeyDown[(DefineConstants.sc_F6)] != 0) && (ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
			{
				{
					KB_KeyDown[(DefineConstants.sc_F6)] = (!(1 == 1));
			};

				if (movesperpacket == 4 && connecthead != myconnectindex)
				{
					return;
				}

				if (lastsavedpos == -1)
				{
					goto FAKE_F2;
				}

				KB_FlushKeyboardQueue();

				if (Engine.board.sprite[ps[myconnectindex].i].extra <= 0)
				{
					FTA(118, ps[myconnectindex]);
					return;
				}
				screencapt = 1;
				displayrooms(myconnectindex, 65536);
				savetemp("duke3d.tmp", waloff[DefineConstants.MAXTILES - 1], 160 * 100);
				screencapt = 0;
				if (lastsavedpos >= 0)
				{
					inputloc = strlen(ud.savegame[lastsavedpos][0]);
					current_menu = 360 + lastsavedpos;
					probey = lastsavedpos;
				}
				FX_StopAllSounds();
				clearsoundlocks();

				setview(0,0,Engine.xdim - 1,Engine.ydim - 1);
				ps[myconnectindex].gm |= DefineConstants.MODE_MENU;
				if (ud.multimode < 2 && ud.recstat != 2)
				{
					ready2send = 0;
					totalclock = ototalclock;
				}
			}

			if ((KB_KeyDown[(DefineConstants.sc_F7)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F7)] = (!(1 == 1));
			};
				if (ps[myconnectindex].over_shoulder_on)
				{
					ps[myconnectindex].over_shoulder_on = 0;
				}
				else
				{
					ps[myconnectindex].over_shoulder_on = 1;
					cameradist = 0;
					cameraclock = totalclock;
				}
				FTA(109 + ps[myconnectindex].over_shoulder_on, ps[myconnectindex]);
			}

			if ((KB_KeyDown[(DefineConstants.sc_F5)] != 0) && MusicDevice != soundcardnames.NumSoundCards)
			{
				{
					KB_KeyDown[(DefineConstants.sc_F5)] = (!(1 == 1));
			};
				strcpy(tempbuf[0], music_fn[0][music_select][0]);
				strcat(tempbuf[0], ".  USE SHIFT-F5 TO CHANGE.");
				strcpy(fta_quotes[26][0], tempbuf[0]);
				FTA(26, ps[myconnectindex]);

			}

			if ((KB_KeyDown[(DefineConstants.sc_F8)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F8)] = (!(1 == 1));
			};
				ud.fta_on = !ud.fta_on;
				if (ud.fta_on)
				{
					FTA(23, ps[myconnectindex]);
				}
				else
				{
					ud.fta_on = 1;
					FTA(24, ps[myconnectindex]);
					ud.fta_on = 0;
				}
			}

			if ((KB_KeyDown[(DefineConstants.sc_F9)] != 0) && (ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
			{
				{
					KB_KeyDown[(DefineConstants.sc_F9)] = (!(1 == 1));
			};

				if (movesperpacket == 4 && myconnectindex != connecthead)
				{
					return;
				}

				if (lastsavedpos >= 0)
				{
					cmenu(15001);
				}
				else
				{
					cmenu(25000);
				}
				FX_StopAllSounds();
				clearsoundlocks();
				ps[myconnectindex].gm |= DefineConstants.MODE_MENU;
				if (ud.multimode < 2 && ud.recstat != 2)
				{
					ready2send = 0;
					totalclock = ototalclock;
				}
			}

			if ((KB_KeyDown[(DefineConstants.sc_F10)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F10)] = (!(1 == 1));
			};
				cmenu(500);
				FX_StopAllSounds();
				clearsoundlocks();
				ps[myconnectindex].gm |= DefineConstants.MODE_MENU;
				if (ud.multimode < 2 && ud.recstat != 2)
				{
					ready2send = 0;
					totalclock = ototalclock;
				}
			}


			if (ud.overhead_on != 0)
			{

				j = totalclock - nonsharedtimer;
				nonsharedtimer += j;
				if ((((gamefunc_Enlarge_Screen) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Enlarge_Screen) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Enlarge_Screen)) & 1)) != 0)
				{
					ps[myconnectindex].zoom += mulscale6(j,Math.Max(ps[myconnectindex].zoom,256));
				}
				if ((((gamefunc_Shrink_Screen) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Shrink_Screen) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Shrink_Screen)) & 1)) != 0)
				{
					ps[myconnectindex].zoom -= mulscale6(j,Math.Max(ps[myconnectindex].zoom,256));
				}

				if ((ps[myconnectindex].zoom > 2048))
				{
					ps[myconnectindex].zoom = 2048;
				}
				if ((ps[myconnectindex].zoom < 48))
				{
					ps[myconnectindex].zoom = 48;
				}

			}
		}

		if ((KB_KeyDown[(DefineConstants.sc_Escape)] != 0) && ud.overhead_on && ps[myconnectindex].newowner == -1)
		{
			{
				KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
		};
			ud.last_overhead = ud.overhead_on;
			ud.overhead_on = 0;
			ud.scrollmode = 0;
			vscrn();
		}

		if ((((gamefunc_AutoRun) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_AutoRun) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_AutoRun)) & 1)) != 0)
		{
			CONTROL_ClearButton(gamefunc_AutoRun);
			ud.auto_run = 1 - ud.auto_run;
			FTA(85 + ud.auto_run, ps[myconnectindex]);
		}

		if ((((gamefunc_Map) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Map) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Map)) & 1)) != 0)
		{
			CONTROL_ClearButton(gamefunc_Map);
			if (ud.last_overhead != ud.overhead_on && ud.last_overhead)
			{
				ud.overhead_on = ud.last_overhead;
				ud.last_overhead = 0;
			}
			else
			{
				ud.overhead_on++;
				if (ud.overhead_on == 3)
				{
					ud.overhead_on = 0;
				}
				ud.last_overhead = ud.overhead_on;
			}
			restorepalette = 1;
			vscrn();
		}

		if ((KB_KeyDown[(DefineConstants.sc_F11)] != 0))
		{
			{
				KB_KeyDown[(DefineConstants.sc_F11)] = (!(1 == 1));
		};
			if (((KB_KeyDown[(DefineConstants.sc_RightShift)] != 0) || (KB_KeyDown[(DefineConstants.sc_LeftShift)] != 0)))
			{
				ud.brightness -= 4;
			}
			else
			{
				ud.brightness += 4;
			}

			if (ud.brightness > (7 << 2))
			{
				ud.brightness = 0;
			}
			else if (ud.brightness < 0)
			{
				ud.brightness = (7 << 2);
			}

			setbrightness(ud.brightness >> 2, ps[myconnectindex].palette[0]);
			if (ud.brightness < 20)
			{
				FTA((short)(29 + (ud.brightness >> 2)), ps[myconnectindex]);
			}
			else if (ud.brightness < 40)
			{
				FTA((short)(96 + (ud.brightness >> 2) - 5), ps[myconnectindex]);
			}
		}
	}



	void comlinehelp(char * *argv)
	{
		printf("Command line help.  %s [/flags...]\n",argv[0]);
		puts(" ?, /?         This help message");
		puts(" /l##          Level (1-11)");
		puts(" /v#           Volume (1-4)");
		puts(" /s#           Skill (1-4)");
		puts(" /r            Record demo");
		puts(" /dFILE        Start to play demo FILE");
		puts(" /m            No monsters");
		puts(" /ns           No sound");
		puts(" /nm           No music");
		puts(" /t#           Respawn, 1 = Monsters, 2 = Items, 3 = Inventory, x = All");
		puts(" /c#           MP mode, 1 = DukeMatch(spawn), 2 = Coop, 3 = Dukematch(no spawn)");
		puts(" /q#           Fake multiplayer (2-8 players)");
		puts(" /a            Use player AI (fake multiplayer only)");
		puts(" /i#           Network mode (1/0) (multiplayer only) (default == 1)");
		puts(" /f#           Send fewer packets (1, 2, 4) (multiplayer only)");
		puts(" /gFILE, /g... Use multiple group files (must be last on command line)");
		puts(" /xFILE        Compile FILE (default GAME.CON)");
		puts(" /u#########   User's favorite weapon order (default: 3425689071)");
		puts(" /#            Load and run a game (slot 0-9)");
		puts(" /z            Skip memory check");
		puts(" -map FILE     Use a map FILE");
		puts(" -name NAME    Foward NAME");
	  printf(" -net          Net mode game");
	}

	void checkcommandline(int argc,char * *argv)
	{
		short i;
		short j;
//C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
		char * c;

		i = 1;

		ud.fta_on = 1;
		ud.god = 0;
		ud.m_respawn_items = 0;
		ud.m_respawn_monsters = 0;
		ud.m_respawn_inventory = 0;
		ud.warp_on = 0;
		ud.cashman = 0;
		ud.m_player_skill = ud.player_skill = 2;

#if BETA
		return;
#endif

		if (argc > 1)
		{
			while (i < argc)
			{
				c = argv[i];
				if (*c == '-')
				{
					if (*(c + 1) == '8')
					{
						eightytwofifty = 1;
					}
					i++;
					continue;
				}

				if (*c == '?')
				{
					comlinehelp(argv);
					exit(-1);
				}

				if (*c == '/')
				{
					c++;
					switch (*c)
					{
						default:
	  //                      printf("Unknown command line parameter '%s'\n",argv[i]);
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case '?':
							comlinehelp(argv);
							exit(0);
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 'x':
						case 'X':
							c++;
							if (*c)
							{
								strcpy(confilename,c);
								if (SafeFileExists(c) == 0)
								{
									printf("Could not find con file '%s'.\n",confilename);
									exit(-1);
								}
								else
								{
									printf("Using con file: '%s'\n",confilename);
								}
							}
							break;
						case 'g':
						case 'G':
							c++;
							if (*c)
							{
								if (strchr(c,'.') == 0)
								{
								   strcat(c,".grp");
								}

								j = initgroupfile(c);
								if (j == -1)
								{
									printf("Could not find group file %s.\n",c);
								}
								else
								{
									groupfile = j;
									printf("Using group file %s.\n",c);
								}
							}

							break;
						case 'a':
						case 'A':
							ud.playerai = 1;
							puts("Other player AI.");
							break;
						case 'n':
						case 'N':
							c++;
							if (*c == 's' || *c == 'S')
							{
								CommandSoundToggleOff = 2;
								puts("Sound off.");
							}
							else if (*c == 'm' || *c == 'M')
							{
								CommandMusicToggleOff = 1;
								puts("Music off.");
							}
							else
							{
								comlinehelp(argv);
								exit(-1);
							}
							break;
						case 'i':
						case 'I':
							c++;
							if (*c == '0')
							{
								networkmode = 0;
							}
							if (*c == '1')
							{
								networkmode = 1;
							}
							printf("Network Mode %d\n",networkmode);
							break;
						case 'c':
						case 'C':
							c++;
							if (*c == '1' || *c == '2' || *c == '3')
							{
								ud.m_coop = *c - '0' - 1;
							}
							else
							{
								ud.m_coop = 0;
							}

							switch (ud.m_coop)
							{
								case 0:
									puts("Dukematch (spawn).");
									break;
								case 1:
									puts("Cooperative play.");
									break;
								case 2:
									puts("Dukematch (no spawn).");
									break;
							}

							break;
						case 'z':
						case 'Z':
							memorycheckoveride = 1;
							break;
						case 'f':
						case 'F':
							c++;
							if (*c == '1')
							{
								movesperpacket = 1;
							}
							if (*c == '2')
							{
								movesperpacket = 2;
							}
							if (*c == '4')
							{
								movesperpacket = 4;
								setpackettimeout(0x3fffffff,0x3fffffff);
							}
							break;
						case 't':
						case 'T':
							c++;
							if (*c == '1')
							{
								ud.m_respawn_monsters = 1;
							}
							else if (*c == '2')
							{
								ud.m_respawn_items = 1;
							}
							else if (*c == '3')
							{
								ud.m_respawn_inventory = 1;
							}
							else
							{
								ud.m_respawn_monsters = 1;
								ud.m_respawn_items = 1;
								ud.m_respawn_inventory = 1;
							}
							puts("Respawn on.");
							break;
						case 'm':
						case 'M':
							if (*(c + 1) != 'a' && *(c + 1) != 'A')
							{
								ud.m_monsters_off = 1;
								ud.m_player_skill = ud.player_skill = 0;
								puts("Monsters off.");
							}
							break;
						case 'w':
						case 'W':
							ud.coords = 1;
							break;
						case 'q':
						case 'Q':
							puts("Fake multiplayer mode.");
							if (*(++c) == 0)
							{
								ud.multimode = 1;
							}
							else
							{
								ud.multimode = atol(c) % 17;
							}
							ud.m_coop = ud.coop = 0;
							ud.m_marker = ud.marker = 1;
							ud.m_respawn_monsters = ud.respawn_monsters = 1;
							ud.m_respawn_items = ud.respawn_items = 1;
							ud.m_respawn_inventory = ud.respawn_inventory = 1;

							break;
						case 'r':
						case 'R':
							ud.m_recstat = 1;
							puts("Demo record mode on.");
							break;
						case 'd':
						case 'D':
							c++;
							if (strchr(c,'.') == 0)
							{
								strcat(c,".dmo");
							}
							printf("Play demo %s.\n",c);
							strcpy(firstdemofile,c);
							break;
						case 'l':
						case 'L':
							ud.warp_on = 1;
							c++;
							ud.m_level_number = ud.level_number = (atol(c) - 1) % 11;
							break;
						case 'j':
						case 'J':
#if !DEMO
#if AUSTRALIA
			printf("Duke Nukem 3D (AUSSIE FULL VERSION) v%s\n",DefineConstants.VERSION);
#else
			printf("Duke Nukem 3D (FULL VERSION) v%s\n",DefineConstants.VERSION);
#endif
#else
#if AUSTRALIA
			printf("Duke Nukem 3D (AUSSIE SHAREWARE) v%s\n",DefineConstants.VERSION);
#else
			printf("Duke Nukem 3D (SHAREWARE) v%s\n",DefineConstants.VERSION);
#endif
#endif

							exit(0);

//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 'v':
						case 'V':
							c++;
							ud.warp_on = 1;
							ud.m_volume_number = ud.volume_number = atol(c) - 1;
							break;
						case 's':
						case 'S':
							c++;
							ud.m_player_skill = ud.player_skill = (atol(c) % 5);
							if (ud.m_player_skill == 4)
							{
								ud.m_respawn_monsters = ud.respawn_monsters = 1;
							}
							break;
						case '0':
						case '1':
						case '2':
						case '3':
						case '4':
						case '5':
						case '6':
						case '7':
						case '8':
						case '9':
							ud.warp_on = 2 + (*c) - '0';
							break;
						case 'u':
						case 'U':
							c++;
							j = 0;
							if (*c)
							{
								puts("Using favorite weapon order(s).");
								while (*c)
								{
									ud.wchoice[0][j] = *c - '0';
									c++;
									j++;
								}
								while (j < 10)
								{
									if (j == 9)
									{
										ud.wchoice[0][9] = 1;
									}
									else
									{
										ud.wchoice[0][j] = 2;
									}

									j++;
								}
							}
							else
							{
								puts("Using default weapon orders.");
								ud.wchoice[0][0] = 3;
								ud.wchoice[0][1] = 4;
								ud.wchoice[0][2] = 5;
								ud.wchoice[0][3] = 7;
								ud.wchoice[0][4] = 8;
								ud.wchoice[0][5] = 6;
								ud.wchoice[0][6] = 0;
								ud.wchoice[0][7] = 2;
								ud.wchoice[0][8] = 9;
								ud.wchoice[0][9] = 1;
							}

							break;
					}
				}
				i++;
			}
		}
	}



	void printstr(short x, short y, char string[81], char attribute)
	{
			char character;
			short i;
			short pos;

			pos = (short)((y * 80 + x) << 1);
			i = 0;
			while (string[i] != 0)
			{
					character = string[i];
					printchrasm(0xb8000 + (int)pos,1,((int)attribute << 8) + (int)character);
					i++;
					pos += 2;
			}
	}

	/*
	void cacheicon(void)
	{
	    if(cachecount > 0)
	    {
	        if( (ps[myconnectindex].gm&MODE_MENU) == 0 )
	            Engine.rotatesprite((320-7)<<16,(200-23)<<16,32768L,0,SPINNINGNUKEICON,0,0,2,Engine._device.windowx1,Engine._device.windowy1,Engine._device.windowx2,Engine._device.windowy2);
	        cachecount = 0;
	    }
	}
	       */


	void loadtmb()
	{
		string tmb = new string(new char[8000]);
		int fil;
		int l;

		fil = kopen4load("d3dtimbr.tmb",0);
		if (fil == -1)
		{
			return;
		}
		l = kfilelength(fil);
		kread(fil,(string)tmb,l);
		MUSIC_RegisterTimbreBank(ref tmb);
		kclose(fil);
	}

	/*
	===================
	=
	= ShutDown
	=
	===================
	*/

	void ShutDown()
	{
		SoundShutdown();
		MusicShutdown();
		uninittimer();
		uninitengine();
		CONTROL_Shutdown();
		CONFIG_WriteSetup();
		KB_Shutdown();
	}

	static string todd = "Duke Nukem 3D(tm) Copyright 1989, 1996 Todd Replogle and 3D Realms Entertainment";
	static string trees = "I want to make a game with trees";
	static string sixteen = "16 Possible Dukes";


	void sendscore(char * s)
	{
		if (numplayers > 1)
		{
		  genericmultifunction(-1,s,strlen(s) + 1,5);
		}
	}


	void getnames()
	{
		short i;
		short l;

		for (l = 0;myname[l];l++)
		{
			ud.user_name[myconnectindex][l] = toupper(myname[l]);
			buf[l + 2] = toupper(myname[l]);
		}

		if (numplayers > 1)
		{
			buf[0] = 6;
			buf[1] = DefineConstants.BYTEVERSION;

			buf[l + 2] = 0;
			l += 3;

			for (i = connecthead;i >= 0;i = connectpoint2[i])
			{
				if (i != myconnectindex)
				{
					sendpacket(i, buf[0], l);
				}
			}

	  //      getpackets();

			l = 1;
			buf[0] = 9;

			for (i = 0;i < 10;i++)
			{
				ud.wchoice[myconnectindex][i] = ud.wchoice[0][i];
				buf[l] = (char) ud.wchoice[0][i];
				l++;
			}

			for (i = connecthead;i >= 0;i = connectpoint2[i])
			{
				if (i != myconnectindex)
				{
					sendpacket(i, buf[0], 11);
				}
			}

	//        getpackets();

			buf[0] = 10;
			buf[1] = ps[0].aim_mode;
			ps[myconnectindex].aim_mode = ps[0].aim_mode;

			for (i = connecthead;i >= 0;i = connectpoint2[i])
			{
				if (i != myconnectindex)
				{
					sendpacket(i,buf,2);
				}
			}

	//        getpackets();

			if (cp == 0)
			{
				buf[0] = 125;

				for (i = connecthead;i >= 0;i = connectpoint2[i])
				{
					if (i != myconnectindex)
					{
						sendpacket(i,buf,1);
					}
				}
			}

			getpackets();

			waitforeverybody();
		}

		if (cp == 1)
		{
			gameexit("Please put Duke Nukem 3D Atomic Edition CD in drive.");
		}
	}

	void writestring(int a1,int a2,int a3,short a4,int vx,int vy,int vz)
	{

		FILE fp;

		fp = (FILE)fopen("debug.txt","rt+");

		fprintf(fp,"%ld %ld %ld %ld %ld %ld %ld\n",a1,a2,a3,a4,vx,vy,vz);

		fclose(fp);

	}


	char testcd(ref char * fn)
	{

	 short drive_count;
	 short drive;
	 int dalen = 0;
	 find_t dafilet = new find_t();
	 int fil;

	 _REGS ir = new _REGS();
	 _REGS or = new _REGS();
	 _SREGS sr = new _SREGS();

	 if (DefineConstants.IDFSIZE != 9961476)
	 {
		 drive = toupper(*fn) - 'A';

		 ir.w.ax = 0x1500;
		 ir.w.bx = 0; // check that MSCDEX is installed
		 int386(0x2f, ir, or);
		 drive_count = or.w.bx;

		 if (drive_count == 0)
		 {
			 return 1;
		 }

		 ir.w.ax = 0x150b;
		 ir.w.bx = 0;
		 ir.w.cx = drive;
		 int386(0x2f, ir, or);

		 if (or.w.ax == 0 || or.w.bx != 0xadad)
		 {
			 return 1;
		 }

		 ir.w.ax = 0x1502;
		 ir.w.bx = FP_OFF(buf);
		 sr.es = FP_SEG(buf);
		 ir.w.cx = drive;
		 int386x(0x2f, ir, or, sr);

		 if (or.h.al == 0 || or.h.al == 30)
		 {
			 return 1;
		 }

	 }

	  fil = open(fn,O_RDONLY,S_IREAD);

	  if (fil < 0)
	  {
		  return 1;
	  }

	  // ( DO A SEE/Byte check here.) (Not coded in this version)


	  dalen = filelength(fil);

	  close(fil);

	  return (dalen != DefineConstants.IDFSIZE);

	}


	void copyprotect()
	{
		FILE fp;
		string idfile = new string(new char[256]);

		return;

		cp = 0;

		fp = (FILE)fopen("cdrom.ini","rt");
		if (fp == (FILE) null)
		{
			cp = 1;
			return;
		}

		fscanf(fp,"%s",idfile);
		fclose(fp);

		strcat(idfile,DefineConstants.IDFILENAME);

		if (testcd(ref idfile))
		{
			cp = 1;
			return;
		}
	}


	char opendemoread(char which_demo) // 0 = mine
	{
		const string d = "demo_.dmo";
		char ver;
		short i;

		if (which_demo == 10)
		{
			d = StringFunctions.ChangeCharacter(d, 4, 'x');
		}
		else
		{
			d = StringFunctions.ChangeCharacter(d, 4, '0' + which_demo);
		}

		ud.reccnt = 0;

		 if (which_demo == 1 && firstdemofile[0] != 0)
		 {
		   if ((recfilep = kopen4load(firstdemofile,loadfromgrouponly)) == -1)
		   {
			   return (0);
		   }
		 }
		 else
		 {
		   if ((recfilep = kopen4load(d,loadfromgrouponly)) == -1)
		   {
			   return (0);
		   }
		 }

		 kread(recfilep, ud.reccnt, sizeof(int));
		 kread(recfilep, ver, sizeof(char));
		 if ((ver != DefineConstants.BYTEVERSION)) // || (ud.reccnt < 512) )
		 {
			kclose(recfilep);
			return 0;
		 }
			 kread(recfilep, (string) & ud.volume_number, sizeof(char));
			 kread(recfilep, (string) & ud.level_number, sizeof(char));
			 kread(recfilep, (string) & ud.player_skill, sizeof(char));
		 kread(recfilep, (string) & ud.m_coop, sizeof(char));
		 kread(recfilep, (string) & ud.m_ffire, sizeof(char));
		 kread(recfilep, (short) & ud.multimode, sizeof(short));
		 kread(recfilep, (short) & ud.m_monsters_off, sizeof(short));
		 kread(recfilep, (int) & ud.m_respawn_monsters, sizeof(int));
		 kread(recfilep, (int) & ud.m_respawn_items, sizeof(int));
		 kread(recfilep, (int) & ud.m_respawn_inventory, sizeof(int));
		 kread(recfilep, (int) & ud.playerai, sizeof(int));
		 kread(recfilep, (string) & ud.user_name[0][0], sizeof(ud.user_name), 1);
		 kread(recfilep, (int) & ud.auto_run, sizeof(int));
		 kread(recfilep,(string)boardfilename,sizeof(char));
		 if (boardfilename[0] != 0)
		 {
			ud.m_level_number = 7;
			ud.m_volume_number = 0;
		 }

		 for (i = 0;i < ud.multimode;i++)
		 {
			kread(recfilep, (int) & ps[i].aim_mode, sizeof(char), 1);
		 }
		 ud.god = ud.cashman = ud.eog = ud.showallmap = 0;
		 ud.clipping = ud.scrollmode = ud.overhead_on = 0;
		 ud.showweapons = ud.pause_on = ud.auto_run = 0;

			 newgame(ud.volume_number, ud.level_number, ud.player_skill);
			 return (1);
	}


	void opendemowrite()
	{
		string d = "demo1.dmo";
		int dummylong = 0;
		char ver;
		short i;

		if (ud.recstat == 2)
		{
			kclose(recfilep);
		}

		ver = DefineConstants.BYTEVERSION;

	// CTW - MODIFICATION
	//  if ((frecfilep = fopen(d,"wb")) == -1) return;
		if ((frecfilep = fopen(d,"wb")) == null)
		{
			return;
		}
	// CTW END - MODIFICATION
		fwrite(dummylong, 4, 1, frecfilep);
		fwrite(ver, sizeof(char), 1, frecfilep);
		fwrite((string) & ud.volume_number, sizeof(char), 1, frecfilep);
		fwrite((string) & ud.level_number, sizeof(char), 1, frecfilep);
		fwrite((string) & ud.player_skill, sizeof(char), 1, frecfilep);
		fwrite((string) & ud.m_coop, sizeof(char), 1, frecfilep);
		fwrite((string) & ud.m_ffire, sizeof(char), 1, frecfilep);
		fwrite((short) & ud.multimode, sizeof(short), 1, frecfilep);
		fwrite((short) & ud.m_monsters_off, sizeof(short), 1, frecfilep);
		fwrite((int) & ud.m_respawn_monsters, sizeof(int), 1, frecfilep);
		fwrite((int) & ud.m_respawn_items, sizeof(int), 1, frecfilep);
		fwrite((int) & ud.m_respawn_inventory, sizeof(int), 1, frecfilep);
		fwrite((int) & ud.playerai, sizeof(int), 1, frecfilep);
		fwrite((string) & ud.user_name[0][0], sizeof(ud.user_name), 1, frecfilep);
		fwrite((int) & ud.auto_run, sizeof(int), 1, frecfilep);
		fwrite((string)boardfilename,sizeof(char),1,frecfilep);

		for (i = 0;i < ud.multimode;i++)
		{
			fwrite((int) & ps[i].aim_mode, sizeof(char), 1, frecfilep);
		}

		totalreccnt = 0;
		ud.reccnt = 0;
	}

	void record()
	{
		short i;

		for (i = connecthead;i >= 0;i = connectpoint2[i])
		{
			 copybufbyte(sync[i], recsync[ud.reccnt], sizeof(input));
					 ud.reccnt++;
					 totalreccnt++;
					 if (ud.reccnt >= DefineConstants.RECSYNCBUFSIZ)
					 {
				  dfwrite(recsync,sizeof(input) * ud.multimode,ud.reccnt / ud.multimode,frecfilep);
							  ud.reccnt = 0;
					 }
		}
	}

public static void closedemowrite()
	{
			 if (ud.recstat == 1)
			 {
			if (ud.reccnt > 0)
			{
				dfwrite(recsync,sizeof(input) * ud.multimode,ud.reccnt / ud.multimode,frecfilep);

				fseek(frecfilep,SEEK_SET,0);
				fwrite(totalreccnt,sizeof(int),1,frecfilep);
				ud.recstat = ud.m_recstat = 0;
			}
			fclose(frecfilep);
			 }
	}

	// CTW - MODIFICATION
	// On my XP machine, demo playback causes the game to crash shortly in.
	// Only bug found so far, not sure if it's OS dependent or compiler or what.
	// Seems to happen when player input starts being simulated, but just guessing.
	// This change effectively disables it. The related code is still enabled.
	// char which_demo = 1;
	char which_demo = 0;
	// CTW END - MODIFICATION



	// extern long syncs[];
	



	void doorders()
	{
		short i;

		setview(0,0,Engine.xdim - 1,Engine.ydim - 1);

		for (i = 0;i < 63;i += 7)
		{
			palto(0, 0, 0, i);
		}
		ps[myconnectindex].palette = palette;
		totalclock = 0;
		KB_FlushKeyboardQueue();
		Engine.rotatesprite(0,0,65536,0,DefineConstants.ORDERING,0,0,2 + 8 + 16 + 64, 0,0,Engine.xdim - 1,Engine.ydim - 1);
		nextpage();
		for (i = 63;i > 0;i -= 7)
		{
			palto(0, 0, 0, i);
		}
		totalclock = 0;
		while (KB_KeyWaiting() == null)
		{
			getpackets();
		}

		for (i = 0;i < 63;i += 7)
		{
			palto(0, 0, 0, i);
		}
		totalclock = 0;
		KB_FlushKeyboardQueue();
		Engine.rotatesprite(0,0,65536,0,DefineConstants.ORDERING + 1,0,0,2 + 8 + 16 + 64, 0,0,Engine.xdim - 1,Engine.ydim - 1);
		nextpage();
		for (i = 63;i > 0;i -= 7)
		{
			palto(0, 0, 0, i);
		}
		totalclock = 0;
		while (KB_KeyWaiting() == null)
		{
			getpackets();
		}

		for (i = 0;i < 63;i += 7)
		{
			palto(0, 0, 0, i);
		}
		totalclock = 0;
		KB_FlushKeyboardQueue();
		Engine.rotatesprite(0,0,65536,0,DefineConstants.ORDERING + 2,0,0,2 + 8 + 16 + 64, 0,0,Engine.xdim - 1,Engine.ydim - 1);
		nextpage();
		for (i = 63;i > 0;i -= 7)
		{
			palto(0, 0, 0, i);
		}
		totalclock = 0;
		while (KB_KeyWaiting() == null)
		{
			getpackets();
		}

		for (i = 0;i < 63;i += 7)
		{
			palto(0, 0, 0, i);
		}
		totalclock = 0;
		KB_FlushKeyboardQueue();
		Engine.rotatesprite(0,0,65536,0,DefineConstants.ORDERING + 3,0,0,2 + 8 + 16 + 64, 0,0,Engine.xdim - 1,Engine.ydim - 1);
		nextpage();
		for (i = 63;i > 0;i -= 7)
		{
			palto(0, 0, 0, i);
		}
		totalclock = 0;
		while (KB_KeyWaiting() == null)
		{
			getpackets();
		}
	}

public static void dobonus(char bonusonly)
	{
		short t;
		short r;
		short tinc;
		short gfx_offset;
		int i;
		int y;
		int xfragtotal;
		int yfragtotal;
		short bonuscnt;

		int[] breathe = {0, 30, DefineConstants.VICTORY1 + 1, 176, 59, 30, 60, DefineConstants.VICTORY1 + 2, 176, 59, 60, 90, DefineConstants.VICTORY1 + 1, 176, 59, 90, 120, 0, 176, 59};

		int[] bossmove = {0, 120, DefineConstants.VICTORY1 + 3, 86, 59, 220, 260, DefineConstants.VICTORY1 + 4, 86, 59, 260, 290, DefineConstants.VICTORY1 + 5, 86, 59, 290, 320, DefineConstants.VICTORY1 + 6, 86, 59, 320, 350, DefineConstants.VICTORY1 + 7, 86, 59, 350, 380, DefineConstants.VICTORY1 + 8, 86, 59};

		bonuscnt = 0;

		for (t = 0;t < 64;t += 7)
		{
			palto(0, 0, 0, t);
		}
		setview(0,0,Engine.xdim - 1,Engine.ydim - 1);
		clearview(0);
		nextpage();
		flushperms();

		FX_StopAllSounds();
		clearsoundlocks();
		FX_SetReverb(0);

		if (bonusonly)
		{
			goto FRAGBONUS;
		}

		if (numplayers < 2 && ud.eog && ud.from_bonus == 0)
		{
			switch (ud.volume_number)
			{
			case 0:
				if (ud.lockout == 0)
				{
					clearview(0);
					Engine.rotatesprite(0,50 << 16,65536,0,DefineConstants.VICTORY1,0,0,2 + 8 + 16 + 64 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);
					nextpage();
					ps[myconnectindex].palette = endingpal;
					for (t = 63;t >= 0;t--)
					{
						palto(0, 0, 0, t);
					}

					KB_FlushKeyboardQueue();
					totalclock = 0;
					tinc = 0;
					while (true)
					{
						clearview(0);
						Engine.rotatesprite(0,50 << 16,65536,0,DefineConstants.VICTORY1,0,0,2 + 8 + 16 + 64 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);

						// boss
						if (totalclock > 390 && totalclock < 780)
						{
							for (t = 0;t < 35;t += 5)
							{
								if (bossmove[t + 2] != 0 && (totalclock % 390) > bossmove[t] && (totalclock % 390) <= bossmove[t + 1])
								{
							if (t == 10 && bonuscnt == 1)
							{
								sound(DefineConstants.SHOTGUN_FIRE);
								sound(DefineConstants.SQUISHED);
								bonuscnt++;
							}
							Engine.rotatesprite(bossmove[t + 3] << 16,bossmove[t + 4] << 16,65536,0,bossmove[t + 2],0,0,2 + 8 + 16 + 64 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);
								}
							}
						}

						// Breathe
						if (totalclock < 450 || totalclock >= 750)
						{
							if (totalclock >= 750)
							{
								Engine.rotatesprite(86 << 16,59 << 16,65536,0,DefineConstants.VICTORY1 + 8,0,0,2 + 8 + 16 + 64 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);
								if (totalclock >= 750 && bonuscnt == 2)
								{
									sound(DefineConstants.DUKETALKTOBOSS);
									bonuscnt++;
								}
							}
							for (t = 0;t < 20;t += 5)
							{
								if (breathe[t + 2] != 0 && (totalclock % 120) > breathe[t] && (totalclock % 120) <= breathe[t + 1])
								{
									if (t == 5 && bonuscnt == 0)
									{
										sound(DefineConstants.BOSSTALKTODUKE);
										bonuscnt++;
									}
									Engine.rotatesprite(breathe[t + 3] << 16,breathe[t + 4] << 16,65536,0,breathe[t + 2],0,0,2 + 8 + 16 + 64 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);
								}
							}
						}

						getpackets();
						nextpage();
						if (KB_KeyWaiting() != null)
						{
							break;
						}
					}
				}

				for (t = 0;t < 64;t++)
				{
					palto(0, 0, 0, t);
				}

				KB_FlushKeyboardQueue();
				ps[myconnectindex].palette = palette;

				Engine.rotatesprite(0,0,65536,0,3292,0,0,2 + 8 + 16 + 64, 0,0,Engine.xdim - 1,Engine.ydim - 1);
				nextpage();
				for (t = 63;t > 0;t--)
				{
					palto(0, 0, 0, t);
				}
				while (KB_KeyWaiting() == null)
				{
					getpackets();
				}
				for (t = 0;t < 64;t++)
				{
					palto(0, 0, 0, t);
				}
				MUSIC_StopSong();
				FX_StopAllSounds();
				clearsoundlocks();
				break;
			case 1:
				MUSIC_StopSong();
				clearview(0);
				nextpage();

				if (ud.lockout == 0)
				{
					playanm("cineov2.anm", 1);
					KB_FlushKeyBoardQueue();
					clearview(0);
					nextpage();
				}

				sound(DefineConstants.PIPEBOMB_EXPLODE);

				for (t = 0;t < 64;t++)
				{
					palto(0, 0, 0, t);
				}
				setview(0,0,Engine.xdim - 1,Engine.ydim - 1);
				KB_FlushKeyboardQueue();
				ps[myconnectindex].palette = palette;
				Engine.rotatesprite(0,0,65536,0,3293,0,0,2 + 8 + 16 + 64, 0,0,Engine.xdim - 1,Engine.ydim - 1);
				nextpage();
				for (t = 63;t > 0;t--)
				{
					palto(0, 0, 0, t);
				}
				while (KB_KeyWaiting() == null)
				{
					getpackets();
				}
				for (t = 0;t < 64;t++)
				{
					palto(0, 0, 0, t);
				}

				break;

			case 3:

				setview(0,0,Engine.xdim - 1,Engine.ydim - 1);

				MUSIC_StopSong();
				clearview(0);
				nextpage();

				if (ud.lockout == 0)
				{
					KB_FlushKeyboardQueue();
					playanm("vol4e1.anm", 8);
					clearview(0);
					nextpage();
					playanm("vol4e2.anm", 10);
					clearview(0);
					nextpage();
					playanm("vol4e3.anm", 11);
					clearview(0);
					nextpage();
				}

				FX_StopAllSounds();
				clearsoundlocks();
				sound(DefineConstants.ENDSEQVOL3SND4);
				KB_FlushKeyBoardQueue();

				ps[myconnectindex].palette = palette;
				palto(0, 0, 0, 63);
				clearview(0);
				menutext(160, 60, 0, 0, "THANKS TO ALL OUR");
				menutext(160, 60 + 16, 0, 0, "FANS FOR GIVING");
				menutext(160, 60 + 16 + 16, 0, 0, "US BIG HEADS.");
				menutext(160, 70 + 16 + 16 + 16, 0, 0, "LOOK FOR A DUKE NUKEM 3D");
				menutext(160, 70 + 16 + 16 + 16 + 16, 0, 0, "SEQUEL SOON.");
				nextpage();

				for (t = 63;t > 0;t -= 3)
				{
					palto(0, 0, 0, t);
				}
				KB_FlushKeyboardQueue();
				while (KB_KeyWaiting() == null)
				{
					getpackets();
				}
				for (t = 0;t < 64;t += 3)
				{
					palto(0, 0, 0, t);
				}

				clearview(0);
				nextpage();

				playanm("DUKETEAM.ANM", 4);

				KB_FlushKeyBoardQueue();
				while (KB_KeyWaiting() == null)
				{
					getpackets();
				}

				clearview(0);
				nextpage();
				palto(0, 0, 0, 63);

				FX_StopAllSounds();
				clearsoundlocks();
				KB_FlushKeyBoardQueue();

				break;

			case 2:

				MUSIC_StopSong();
				clearview(0);
				nextpage();
				if (ud.lockout == 0)
				{
					for (t = 63;t >= 0;t--)
					{
						palto(0, 0, 0, t);
					}
					playanm("cineov3.anm", 2);
					KB_FlushKeyBoardQueue();
					ototalclock = totalclock + 200;
					while (totalclock < ototalclock)
					{
						getpackets();
					}
					clearview(0);
					nextpage();

					FX_StopAllSounds();
					clearsoundlocks();
				}

				playanm("RADLOGO.ANM", 3);

				if (ud.lockout == 0 && KB_KeyWaiting() == null)
				{
					sound(DefineConstants.ENDSEQVOL3SND5);
					while (Sound[DefineConstants.ENDSEQVOL3SND5].@lock >= 200)
					{
						getpackets();
					}
					if (KB_KeyWaiting() != null)
					{
						goto ENDANM;
					}
					sound(DefineConstants.ENDSEQVOL3SND6);
					while (Sound[DefineConstants.ENDSEQVOL3SND6].@lock >= 200)
					{
						getpackets();
					}
					if (KB_KeyWaiting() != null)
					{
						goto ENDANM;
					}
					sound(DefineConstants.ENDSEQVOL3SND7);
					while (Sound[DefineConstants.ENDSEQVOL3SND7].@lock >= 200)
					{
						getpackets();
					}
					if (KB_KeyWaiting() != null)
					{
						goto ENDANM;
					}
					sound(DefineConstants.ENDSEQVOL3SND8);
					while (Sound[DefineConstants.ENDSEQVOL3SND8].@lock >= 200)
					{
						getpackets();
					}
					if (KB_KeyWaiting() != null)
					{
						goto ENDANM;
					}
					sound(DefineConstants.ENDSEQVOL3SND9);
					while (Sound[DefineConstants.ENDSEQVOL3SND9].@lock >= 200)
					{
						getpackets();
					}
				}

				KB_FlushKeyBoardQueue();
				totalclock = 0;
				while (KB_KeyWaiting() == null && totalclock < 120)
				{
					getpackets();
				}

				ENDANM:

				FX_StopAllSounds();
				clearsoundlocks();

				KB_FlushKeyBoardQueue();

				clearview(0);

				break;
			}
		}

		FRAGBONUS:

		ps[myconnectindex].palette = palette;
		KB_FlushKeyboardQueue();
		totalclock = 0;
		tinc = 0;
		bonuscnt = 0;

		MUSIC_StopSong();
		FX_StopAllSounds();
		clearsoundlocks();

		if (playerswhenstarted > 1 && ud.coop != 1)
		{
			if (!(MusicToggle == 0 || MusicDevice == soundcardnames.NumSoundCards))
			{
				sound(DefineConstants.BONUSMUSIC);
			}

			Engine.rotatesprite(0,0,65536,0,DefineConstants.MENUSCREEN,16,0,2 + 8 + 16 + 64,0,0,Engine.xdim - 1,Engine.ydim - 1);
			Engine.rotatesprite(160 << 16,34 << 16,65536,0,DefineConstants.INGAMEDUKETHREEDEE,0,0,10,0,0,Engine.xdim - 1,Engine.ydim - 1);
			Engine.rotatesprite((260) << 16,36 << 16,65536,0,DefineConstants.PLUTOPAKSPRITE+2,0,0,2 + 8,0,0,Engine.xdim - 1,Engine.ydim - 1);
			gametext(160, 58 + 2, "MULTIPLAYER TOTALS", 0, (short)(2 + 8 + 16));
			gametext(160, 58 + 10, level_names[(ud.volume_number * 11) + ud.last_level - 1], 0, (short)(2 + 8 + 16));

			gametext(160, 165, "PRESS ANY KEY TO CONTINUE", 0, (short)(2 + 8 + 16));


			t = 0;
			minitext(23, 80, "   NAME                                           KILLS", 8, 2 + 8 + 16 + 128);
			for (i = 0;i < playerswhenstarted;i++)
			{
				sprintf(tempbuf,"%-4ld",i + 1);
				minitext(92 + (i * 23), 80, tempbuf, 3, 2 + 8 + 16 + 128);
			}

			for (i = 0;i < playerswhenstarted;i++)
			{
				xfragtotal = 0;
				sprintf(tempbuf,"%ld",i + 1);

				minitext(30, 90 + t, tempbuf, 0, 2 + 8 + 16 + 128);
				minitext(38, 90 + t, ud.user_name[i], ps[i].palookup, 2 + 8 + 16 + 128);

				for (y = 0;y < playerswhenstarted;y++)
				{
					if (i == y)
					{
						sprintf(tempbuf,"%-4ld",ps[y].fraggedself);
						minitext(92 + (y * 23), 90 + t, tempbuf, 2, 2 + 8 + 16 + 128);
						xfragtotal -= ps[y].fraggedself;
					}
					else
					{
						sprintf(tempbuf,"%-4ld",frags[i][y]);
						minitext(92 + (y * 23), 90 + t, tempbuf, 0, 2 + 8 + 16 + 128);
						xfragtotal += frags[i][y];
					}

					if (myconnectindex == connecthead)
					{
						sprintf(tempbuf,"stats %ld killed %ld %ld\n",i + 1,y + 1,frags[i][y]);
						sendscore(ref tempbuf);
					}
				}

				sprintf(tempbuf,"%-4ld",xfragtotal);
				minitext(101 + (8 * 23), 90 + t, tempbuf, 2, 2 + 8 + 16 + 128);

				t += 7;
			}

			for (y = 0;y < playerswhenstarted;y++)
			{
				yfragtotal = 0;
				for (i = 0;i < playerswhenstarted;i++)
				{
					if (i == y)
					{
						yfragtotal += ps[i].fraggedself;
					}
					yfragtotal += frags[i][y];
				}
				sprintf(tempbuf,"%-4ld",yfragtotal);
				minitext(92 + (y * 23), 96 + (8 * 7), tempbuf, 2, 2 + 8 + 16 + 128);
			}

			minitext(45, 96 + (8 * 7), "DEATHS", 8, 2 + 8 + 16 + 128);
			nextpage();

			for (t = 0;t < 64;t += 7)
			{
				palto(0, 0, 0, 63 - t);
			}

			KB_FlushKeyboardQueue();
			while (KB_KeyWaiting() == 0)
			{
				getpackets();
			}

			if ((KB_KeyDown[(DefineConstants.sc_F12)] != 0))
			{
				{
					KB_KeyDown[(DefineConstants.sc_F12)] = (!(1 == 1));
			};
				screencapture("duke0000.pcx",0);
			}

			if (bonusonly || ud.multimode > 1)
			{
				return;
			}

			for (t = 0;t < 64;t += 7)
			{
				palto(0, 0, 0, t);
			}
		}

		if (bonusonly || ud.multimode > 1)
		{
			return;
		}

		switch (ud.volume_number)
		{
			case 1:
				gfx_offset = 5;
				break;
			default:
				gfx_offset = 0;
				break;
		}

		Engine.rotatesprite(0,0,65536,0,DefineConstants.BONUSSCREEN + gfx_offset,0,0,2 + 8 + 16 + 64 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);

		menutext(160, 20 - 6, 0, 0, ref level_names[(ud.volume_number * 11) + ud.last_level - 1][0]);
		menutext(160, 36 - 6, 0, 0, "COMPLETED");

		gametext(160, 192, "PRESS ANY KEY TO CONTINUE", 16, (short)(2 + 8 + 16));

		if (!(MusicToggle == 0 || MusicDevice == soundcardnames.NumSoundCards))
		{
			sound(DefineConstants.BONUSMUSIC);
		}

		nextpage();
		KB_FlushKeyboardQueue();
		for (t = 0;t < 64;t++)
		{
			palto(0, 0, 0, 63 - t);
		}
		bonuscnt = 0;
		totalclock = 0;
		tinc = 0;

		while (true)
		{
			if ((ps[myconnectindex].gm & DefineConstants.MODE_EOL) != 0)
			{
				Engine.rotatesprite(0,0,65536,0,DefineConstants.BONUSSCREEN + gfx_offset,0,0,2 + 8 + 16 + 64 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);

				if (totalclock > (1000000000) && totalclock < (1000000320))
				{
					switch ((totalclock >> 4) % 15)
					{
						case 0:
							if (bonuscnt == 6)
							{
								bonuscnt++;
								sound(DefineConstants.SHOTGUN_COCK);
								switch (rand() & 3)
								{
									case 0:
										sound(DefineConstants.BONUS_SPEECH1);
										break;
									case 1:
										sound(DefineConstants.BONUS_SPEECH2);
										break;
									case 2:
										sound(DefineConstants.BONUS_SPEECH3);
										break;
									case 3:
										sound(DefineConstants.BONUS_SPEECH4);
										break;
								}
							}
//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
						case 1:
						case 4:
						case 5:
							Engine.rotatesprite(199 << 16,31 << 16,65536,0,DefineConstants.BONUSSCREEN + 3 + gfx_offset,0,0,2 + 8 + 16 + 64 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);
							break;
						case 2:
						case 3:
						   Engine.rotatesprite(199 << 16,31 << 16,65536,0,DefineConstants.BONUSSCREEN + 4 + gfx_offset,0,0,2 + 8 + 16 + 64 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);
						   break;
					}
				}
				else if (totalclock > (10240 + 120))
				{
					break;
				}
				else
				{
					switch ((totalclock >> 5) & 3)
					{
						case 1:
						case 3:
							Engine.rotatesprite(199 << 16,31 << 16,65536,0,DefineConstants.BONUSSCREEN + 1 + gfx_offset,0,0,2 + 8 + 16 + 64 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);
							break;
						case 2:
							Engine.rotatesprite(199 << 16,31 << 16,65536,0,DefineConstants.BONUSSCREEN + 2 + gfx_offset,0,0,2 + 8 + 16 + 64 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);
							break;
					}
				}

				menutext(160, 20 - 6, 0, 0, ref level_names[(ud.volume_number * 11) + ud.last_level - 1][0]);
				menutext(160, 36 - 6, 0, 0, "COMPLETED");

				gametext(160, 192, "PRESS ANY KEY TO CONTINUE", 16, (short)(2 + 8 + 16));

				if (totalclock > (60 * 3))
				{
					gametext(10, 59 + 9, "Your Time:", 0, (short)(2 + 8 + 16));
					gametext(10, 69 + 9, "Par time:", 0, (short)(2 + 8 + 16));
					gametext(10, 78 + 9, "3D Realms' Time:", 0, (short)(2 + 8 + 16));
					if (bonuscnt == 0)
					{
						bonuscnt++;
					}

					if (totalclock > (60 * 4))
					{
						if (bonuscnt == 1)
						{
							bonuscnt++;
							sound(DefineConstants.PIPEBOMB_EXPLODE);
						}
						sprintf(tempbuf,"%02ld:%02ld", (ps[myconnectindex].player_par / (26 * 60)) % 60, (ps[myconnectindex].player_par / 26) % 60);
						gametext((320 >> 2) + 71, 60 + 9, tempbuf, 0, (short)(2 + 8 + 16));

						sprintf(tempbuf,"%02ld:%02ld", (partime[ud.volume_number * 11 + ud.last_level - 1] / (26 * 60)) % 60, (partime[ud.volume_number * 11 + ud.last_level - 1] / 26) % 60);
						gametext((320 >> 2) + 71, 69 + 9, tempbuf, 0, (short)(2 + 8 + 16));

						sprintf(tempbuf,"%02ld:%02ld", (designertime[ud.volume_number * 11 + ud.last_level - 1] / (26 * 60)) % 60, (designertime[ud.volume_number * 11 + ud.last_level - 1] / 26) % 60);
						gametext((320 >> 2) + 71, 78 + 9, tempbuf, 0, (short)(2 + 8 + 16));

					}
				}
				if (totalclock > (60 * 6))
				{
					gametext(10, 94 + 9, "Enemies Killed:", 0, (short)(2 + 8 + 16));
					gametext(10, 99 + 4 + 9, "Enemies Left:", 0, (short)(2 + 8 + 16));

					if (bonuscnt == 2)
					{
						bonuscnt++;
						sound(DefineConstants.FLY_BY);
					}

					if (totalclock > (60 * 7))
					{
						if (bonuscnt == 3)
						{
							bonuscnt++;
							sound(DefineConstants.PIPEBOMB_EXPLODE);
						}
						sprintf(tempbuf,"%-3ld",ps[myconnectindex].actors_killed);
						gametext((320 >> 2) + 70, 93 + 9, tempbuf, 0, (short)(2 + 8 + 16));
						if (ud.player_skill > 3)
						{
							sprintf(tempbuf,"N/A");
							gametext((320 >> 2) + 70, 99 + 4 + 9, tempbuf, 0, (short)(2 + 8 + 16));
						}
						else
						{
							if ((ps[myconnectindex].max_actors_killed - ps[myconnectindex].actors_killed) < 0)
							{
								sprintf(tempbuf,"%-3ld",0);
							}
							else
							{
								sprintf(tempbuf,"%-3ld",ps[myconnectindex].max_actors_killed - ps[myconnectindex].actors_killed);
							}
							gametext((320 >> 2) + 70, 99 + 4 + 9, tempbuf, 0, (short)(2 + 8 + 16));
						}
					}
				}
				if (totalclock > (60 * 9))
				{
					gametext(10, 120 + 9, "Secrets Found:", 0, (short)(2 + 8 + 16));
					gametext(10, 130 + 9, "Secrets Missed:", 0, (short)(2 + 8 + 16));
					if (bonuscnt == 4)
					{
						bonuscnt++;
					}

					if (totalclock > (60 * 10))
					{
						if (bonuscnt == 5)
						{
							bonuscnt++;
							sound(DefineConstants.PIPEBOMB_EXPLODE);
						}
						sprintf(tempbuf,"%-3ld",ps[myconnectindex].secret_rooms);
						gametext((320 >> 2) + 70, 120 + 9, tempbuf, 0, (short)(2 + 8 + 16));
						if (ps[myconnectindex].secret_rooms > 0)
						{
							sprintf(tempbuf,"%-3ld%",(100 * ps[myconnectindex].secret_rooms / ps[myconnectindex].max_secret_rooms));
						}
						sprintf(tempbuf,"%-3ld",ps[myconnectindex].max_secret_rooms - ps[myconnectindex].secret_rooms);
						gametext((320 >> 2) + 70, 130 + 9, tempbuf, 0, (short)(2 + 8 + 16));
					}
				}

				if (totalclock > 10240 && totalclock < 10240 + 10240)
				{
					totalclock = 1024;
				}

				if (KB_KeyWaiting() != null && totalclock > (60 * 2))
				{
					if ((KB_KeyDown[(DefineConstants.sc_F12)] != 0))
					{
						{
							KB_KeyDown[(DefineConstants.sc_F12)] = (!(1 == 1));
					};
						screencapture("duke0000.pcx",0);
					}

					if (totalclock < (60 * 13))
					{
						KB_FlushKeyboardQueue();
						totalclock = (60 * 13);
					}
					else if (totalclock < (1000000000))
					{
					   totalclock = (1000000000);
					}
				}
			}
			else
			{
				break;
			}
			nextpage();
		}
	}




public static void vglass(int x,int y,short a,short wn,short n)
	{
		int z;
		int zincs;
		short sect;

		sect = Engine.board.wall[wn].nextsector;
		if (sect == -1)
		{
			return;
		}
		zincs = (Engine.board.sector[sect].floorz - Engine.board.sector[sect].ceilingz) / n;

		for (z = Engine.board.sector[sect].ceilingz;z < Engine.board.sector[sect].floorz; z += zincs)
		{
			EGS(sect, x, y, z - (Engine.krand() & 8191), DefineConstants.GLASSPIECES + (z & (Engine.krand() % 3)), -32, 36, 36, a + 128 - (Engine.krand() & 255), (short)(16 + (Engine.krand() & 31)), 0, -1, 5);
		}
	}

	public static void lotsofglass(int i,int wallnum,int n)
	{
		 int j;
		 int xv;
		 int yv;
		 int z;
		 int x1;
		 int y1;
		 short sect;
		 short a;

		 sect = -1;

		 if (wallnum < 0)
		 {
			for (j = n - 1; j >= 0 ;j--)
			{
				a = Engine.board.sprite[i].ang - 256 + (Engine.krand() & 511) + 1024;
				EGS(Engine.board.sprite[i].sectnum, Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].z, DefineConstants.GLASSPIECES + (j % 3), -32, 36, 36, a, (short)(32 + (Engine.krand() & 63)), 1024 - (Engine.krand() & 1023), i, 5);
			}
			return;
		 }

		 j = n + 1;

		 x1 = Engine.board.wall[wallnum].x;
		 y1 = Engine.board.wall[wallnum].y;

		 xv = Engine.board.wall[Engine.board.wall[wallnum].point2].x - x1;
		 yv = Engine.board.wall[Engine.board.wall[wallnum].point2].y - y1;

		 x1 -= ksgn(yv);
		 y1 += ksgn(xv);

		 xv /= j;
		 yv /= j;

		 for (j = n;j > 0;j--)
		 {
					  x1 += xv;
					  y1 += yv;

			  Engine.board.updatesector(x1, y1, sect);
			  if (sect >= 0)
			  {
				  z = Engine.board.sector[sect].floorz - (Engine.krand() & (pragmas.klabs(Engine.board.sector[sect].ceilingz - Engine.board.sector[sect].floorz)));
				  if (z < -(32 << 8) || z > (32 << 8))
				  {
					  z = Engine.board.sprite[i].z - (32 << 8) + (Engine.krand() & ((64 << 8) - 1));
				  }
				  a = Engine.board.sprite[i].ang - 1024;
				  EGS(Engine.board.sprite[i].sectnum, x1, y1, z, DefineConstants.GLASSPIECES + (j % 3), -32, 36, 36, a, (short)(32 + (Engine.krand() & 63)), -(Engine.krand() & 1023), i, 5);
			  }
		 }
	}

	public static void spriteglass(short i,short n)
	{
		int j;
		int k;
		int a;
		int z;

		for (j = n;j > 0;j--)
		{
			a = Engine.krand() & 2047;
			z = Engine.board.sprite[i].z - ((Engine.krand() & 16) << 8);
			k = EGS(Engine.board.sprite[i].sectnum, Engine.board.sprite[i].x, Engine.board.sprite[i].y, z, DefineConstants.GLASSPIECES + (j % 3), (sbyte)(Engine.krand() & 15), 36, 36, (short)a, (short)(32 + (Engine.krand() & 63)), -512 - (Engine.krand() & 2047), i, 5);
			Engine.board.sprite[k].pal = Engine.board.sprite[i].pal;
		}
	}

	public static void opendemowrite()
	{
	
	}

	public static void closedemowrite()
	{
	
	}

	public static void ceilingglass(int i,int sectnum,int n)
	{
		 int j;
		 int xv;
		 int yv;
		 int z;
		 int x1;
		 int y1;
		 short a;
		 short s;
		 short startwall;
		 short endwall;

		 startwall = Engine.board.sector[sectnum].wallptr;
		 endwall = startwall + Engine.board.sector[sectnum].wallnum;

		 for (s = startwall;s < (endwall - 1);s++)
		 {
			 x1 = Engine.board.wall[s].x;
			 y1 = Engine.board.wall[s].y;

			 xv = (Engine.board.wall[s + 1].x - x1) / (n + 1);
			 yv = (Engine.board.wall[s + 1].y - y1) / (n + 1);

			 for (j = n;j > 0;j--)
			 {
				  x1 += xv;
				  y1 += yv;
				  a = (short)(Engine.krand() & 2047);
				  z = Engine.board.sector[sectnum].ceilingz + ((Engine.krand() & 15) << 8);
				  EGS(sectnum, x1, y1, z, DefineConstants.GLASSPIECES + (j % 3), -32, 36, 36, a, (short)(Engine.krand() & 31), 0, i, 5);
			 }
		 }
	}



	void lotsofcolourglass(int i,int wallnum,int n)
	{
		 int j;
		 int xv;
		 int yv;
		 int z;
		 int x1;
		 int y1;
		 short sect = -1;
		 short a;
		 short k;

		 if (wallnum < 0)
		 {
			for (j = n - 1; j >= 0 ;j--)
			{
				a = (short)(Engine.krand() & 2047);
				k = EGS(Engine.board.sprite[i].sectnum, Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].z - (Engine.krand() & (63 << 8)), DefineConstants.GLASSPIECES + (j % 3), -32, 36, 36, a, (short)(32 + (Engine.krand() & 63)), 1024 - (Engine.krand() & 2047), i, 5);
				Engine.board.sprite[k].pal = Engine.krand() & 15;
			}
			return;
		 }

		 j = n + 1;
		 x1 = Engine.board.wall[wallnum].x;
		 y1 = Engine.board.wall[wallnum].y;

		 xv = (Engine.board.wall[Engine.board.wall[wallnum].point2].x - Engine.board.wall[wallnum].x) / j;
		 yv = (Engine.board.wall[Engine.board.wall[wallnum].point2].y - Engine.board.wall[wallnum].y) / j;

		 for (j = n;j > 0;j--)
		 {
					  x1 += xv;
					  y1 += yv;

			  Engine.board.updatesector(x1, y1, ref sect);
			  z = Engine.board.sector[sect].floorz - (Engine.krand() & (pragmas.klabs(Engine.board.sector[sect].ceilingz - Engine.board.sector[sect].floorz)));
			  if (z < -(32 << 8) || z > (32 << 8))
			  {
				  z = Engine.board.sprite[i].z - (32 << 8) + (Engine.krand() & ((64 << 8) - 1));
			  }
			  a = Engine.board.sprite[i].ang - 1024;
			  k = EGS(Engine.board.sprite[i].sectnum, x1, y1, z, DefineConstants.GLASSPIECES + (j % 3), -32, 36, 36, a, (short)(32 + (Engine.krand() & 63)), -(Engine.krand() & 2047), i, 5);
			  Engine.board.sprite[k].pal = Engine.krand() & 7;
		 }
	}

	void SetupGameButtons()
	{
// jmarshall - control.
	/*
	   CONTROL_DefineFlag(gamefunc_Move_Forward, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Move_Backward, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Turn_Left, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Turn_Right, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Strafe, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Fire, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Open, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Run, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_AutoRun, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Jump, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Crouch, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Look_Up, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Look_Down, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Look_Left, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Look_Right, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Strafe_Left, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Strafe_Right, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Aim_Up, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Aim_Down, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Weapon_1, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Weapon_2, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Weapon_3, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Weapon_4, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Weapon_5, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Weapon_6, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Weapon_7, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Weapon_8, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Weapon_9, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Weapon_10, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Inventory, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Inventory_Left, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Inventory_Right, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Holo_Duke, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Jetpack, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_NightVision, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_MedKit, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_TurnAround, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_SendMessage, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Map, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Shrink_Screen, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Enlarge_Screen, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Center_View, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Holster_Weapon, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Show_Opponents_Weapon, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Map_Follow_Mode, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_See_Coop_View, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Mouse_Aiming, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Toggle_Crosshair, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Steroids, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Quick_Kick, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Next_Weapon, (!(1 == 1)));
	   CONTROL_DefineFlag(gamefunc_Previous_Weapon, (!(1 == 1)));
	*/
	}

	/*
	===================
	=
	= GetTime
	=
	===================
	*/

	int GetTime()
	{
	   return totalclock;
	}


	/*
	===================
	=
	= CenterCenter
	=
	===================
	*/

	void CenterCenter()
	{
	   printf("Center the joystick and press a button\n");
	}

	/*
	===================
	=
	= UpperLeft
	=
	===================
	*/

	void UpperLeft()
	{
	   printf("Move joystick to upper-left corner and press a button\n");
	}

	/*
	===================
	=
	= LowerRight
	=
	===================
	*/

	void LowerRight()
	{
	   printf("Move joystick to lower-right corner and press a button\n");
	}

	/*
	===================
	=
	= CenterThrottle
	=
	===================
	*/

	void CenterThrottle()
	{
	   printf("Center the throttle control and press a button\n");
	}

	/*
	===================
	=
	= CenterRudder
	=
	===================
	*/

	void CenterRudder()
	{
	   printf("Center the rudder control and press a button\n");
	}
#endif
	// Rare Multiplayer, when dead, total screen screwup back again!
	// E3l1 (Coop /w monsters) sprite list corrupt 50%
	// Univbe exit, instead, default to screen buffer.
	// Check all caches bounds and memory usages
	// Fix enlarger weapon selections to perfection
	// Need sounds.c
	// Spawning a couple of sounds at the same time
	// Check Weapon Switching
	// FIRE and FIRE2
	// Where should I flash the screen white???
	// Jittery on subs in mp?
	// Check accurate memory amounts!
	// Why squish sound at hit space when dead?
	// Falling Counter Not reset in mp
	// Wierd small freezer
	// Double freeze on player?, still firing
	// Do Mouse Flip option
	// Save mouse aiming
	// Laser bounce off mirrors
	// GEORGE:   Ten in text screen.
	// Alien:
	// Freeze: change
	// Press space holding player
	// Press space
	// tank broke
	// 2d mode fucked in fake mp mode
	// 207
	// Mail not rolling up on conveyers
	// Fix all alien animations
	// Do episode names in .CONS
	// do syntak check for "{?????"
	// Make commline parms set approiate multiplayer flags

	// Check all breakables to see if they are exploding properly
	// Fix freezing palette on Alien

	// Do a demo make run overnite
	// Fix Super Duck
	// Slime Guies, use quickkick.

	// Make Lasers from trip bombs reflect off mirrors
	// Remember for lockout of sound swears
	// Pass sender in packed, NOT
	// Fatal sync give no message for TEN
	// Hitting TEN BUTTON(OPTION) no TEN SCreen
	// Check multioperateswitches for se 31,32
	// Fix pal for ceilings (SE#18)
	// case 31: sprites up one high
	// E1l1 No Kill All troops in room, sleep time

	// Fifo for message list

	// Bloodsplat on conveyers

	// Meclanical
	// Increase sound
	// Mouse Delay at death
	// Wierd slowdown

	// Footprints on stuff floating

	// Ken, The inside function is called a lot in -1 sectors
	// No loading Univbe message rewrite
	// Expander must cycle with rest of weapons
	// Duck SHOOT PIPEBOMB, red wall

	// Get commit source from mark

	/*
	1. fix pipebomb bug
	2. check george maps
	4. Save/Restore check (MP and SP)
	5. Check TEN
	6. Get Commit fixed
	8. Is mail slow?
	9. Cacheing
	10. Blue out "PLAY ON TEN" in MULTIPLAYER
	11. Eight Player test
	12. Postal.voc not found.
	13. All Monsters explode in arcade,
	    check SEENINE STRENGTH,
	    Change 28<<8 back to 16<<8 in hitradius
	    Compare 1.3d to 1.4
	14. Check sounds/gfx for for parr lock
	15. Player # Loaded a game
	16. Replace Crane code 1.3d to 1.4
	17. Fix Greenslime
	18. Small Freeze sprite,below floor
	19. Vesa message auto abort in mp?
	20. Fucked Palette in my skip ahead in MP
	21. Load in main menu
	22. Rotated frag screen no game screen
	23. Jibs sounds when killed other dukes
	24. Ten code and /f4 mode
	25. Fix All MP Glitches!!
	26. Unrem Menues anim tenbn
	27. buy groc,clothes,scanner
	28. Why Double Defs in global and game, is so at work
	29. Check that all .objs are erased
	30. Check why 1.3ds gotweapon gamedef coop code no workie
	31. Heavy mods to net code
	32. Make sure all commline stuff works,
	33. killed all waitfor???
	34. 90k stack
	35. double door probs
	36: copy protection
	* when you start a game the duke saying that is played when you choose a skill the sound is cut off.
	* NEWBEASTJUMPING is not deleted at premap in multi-play
	if(*c == '4') no work need objs ask ken, commit
	{
	movesperpacket = 4;
	setpackettimeout(0x3fffffff,0x3fffffff);
	}
	remember, netcode load
	*/
	//  Ai Problem in god mode.
	// Checkplayerhurtwall for forcefields bigforce
	// Nuddie, posters. IMF
	// Release commit.c to public?
	// Document Save bug with mp
	// Check moves per packet /f4 waitforeverybody over net?
	// Kill IDF OBJ
	// No shotguns under water @ tanker
	// Unrem copyprotect
	// Look for printf and puts
	// Check con rewrites
	// erase mmulti.c, or get newest objs
	// Why nomonsters screwy in load menu in mp
	// load last > 'y' == NOT
	// Check xptr oos when dead rising to surface.
	//    diaginal warping with shotguns
	// Test white room.  Lasertripbomb arming crash
	// The Bog
	// Run Duke Out of windows
	// Put Version number in con files
	// Test diff. version playing together
	// Reorganize dukecd
	// Put out patch w/ two weeks testing
	// Print draw3d
	// Double Klick

	/*
	Duke Nukem V
	
	Layout:
	
	      Settings:
	        Suburbs
	          Duke inflitrating neighborhoods inf. by aliens
	        Death Valley:
	          Sorta like a western.  Bull-skulls half buried in the sand
	          Military compound:  Aliens take over nuke-missle silo, duke
	            must destroy.
	          Abondend Aircraft field
	        Vegas:
	          Blast anything bright!  Alien lights camoflauged.
	          Alien Drug factory. The Blue Liquid
	        Mountainal Cave:
	          Interior cave battles.
	        Jungle:
	          Trees, canopee, animals, a mysterious hole in the earth with
	          gas seaping thru.
	        Penetencury:
	          Good use of spotlights:
	        Mental ward:
	          People whom have claimed to be slowly changing into an
	          alien species
	
	      Inventory:
	        Wood,
	        Metal,
	        Torch,
	        Rope,
	        Plastique,
	        Cloth,
	        Wiring,
	        Glue,
	        Cigars,
	        Food,
	        Duck Tape,
	        Nails,
	        Piping,
	        Petrol,
	        Uranium,
	        Gold,
	        Prism,
	        Power Cell,
	
	        Hand spikes (Limited usage, they become dull)
	        Oxygent     (Oxygen mixed with stimulant)
	
	
	      Player Skills:
	        R-Left,R-Right,Foward,Back
	        Strafe, Jump, Double Flip Jump for distance
	        Help, Escape
	        Fire/Use
	        Use Menu
	
	    After a brief resbit, Duke decides to get back to work.
	
	Cmdr:   "Duke, we've got a lot of scared people down there.
	         Some reports even claim that people are already
	         slowly changing into aliens."
	Duke:   "No problem, my speciality is in croud control."
	Cmdr:   "Croud control, my ass!  Remember that incident
	         during the war?  You created nuthin' but death and
	         destruction."
	Duke:   "Not destruction, justice."
	Cmdr:   "I'll take no responsibility for your actions.  Your on
	         your own!  Behave your self, damnit!  You got that,
	         soldger?"
	Duke:   "I've always been on my own...   Face it, it's ass kickin' time,
	         SIR!"
	Cmdr:   "Get outta here...!"
	        (Duke gives the Cmdr a hard stair, then cocks his weapon and
	         walks out of the room)
	Cmdr:   In a wisper: "Good luck, my friend."
	
	        (Cut to a scene where aliens are injecting genetic material
	         into an unconcious subject)
	
	Programming:   ( the functions I need )
	     Images: Polys
	     Actors:
	       Multi-Object sections for change (head,arms,legs,torsoe,all change)
	       Facial expressions.  Pal lookup per poly?
	
	     struct imagetype
	        {
	            int *itable; // AngX,AngY,AngZ,Xoff,Yoff,Zoff;
	            int *idata;
	            struct imagetype *prev, *next;
	        }
	
	*/


	// Test frag screen name fuckup
	// Test all xptrs
	// Make Jibs stick to ceiling
	// Save Game menu crash
	// Cache len sum err
	// Loading in main (MP), reset totalclock?
	// White Room
	// Sound hitch with repeat bits
	// Rewrite saved menues so no crash
	// Put a getpackets after loadplayer in menus
	// Put "loading..." before waitfor in loadpla
	// No ready2send = 0 for loading
	// Test Joystick
	// Ten
	// Bog
	// Test Blimp respawn
	// move 1 in player???

}
