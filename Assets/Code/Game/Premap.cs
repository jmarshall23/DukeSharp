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

using System;
using Build;

#pragma warning disable 0168

public partial class GlobalMembers
{

	//C++ TO C# CONVERTER NOTE: 'extern' variable declarations are not required in C#:
	//extern char everyothertime;
	public static short which_palookup = 9;


	//C++ TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
	public static void tloadtile(short tilenume)
	{
		Engine.board.gotpic[tilenume >> 3] |= (1 << (tilenume & 7));
	}

	public static void cachespritenum(short i)
	{
		int maxc;
		short j;

		if (ud.monsters_off != 0 && badguy(Engine.board.sprite[i]) != 0)
		{
			return;
		}

		maxc = 1;

		switch (Engine.board.sprite[i].picnum)
		{
			case DefineConstants.HYDRENT:
				tloadtile(DefineConstants.BROKEFIREHYDRENT);
				for (j = DefineConstants.TOILETWATER; j < (DefineConstants.TOILETWATER + 4); j++)
				{
					if (Engine.waloff[j].memory == null)
					{
						tloadtile(j);
					}
				}
				break;
			case DefineConstants.TOILET:
				tloadtile(DefineConstants.TOILETBROKE);
				for (j = DefineConstants.TOILETWATER; j < (DefineConstants.TOILETWATER + 4); j++)
				{
					if (Engine.waloff[j].memory == null)
					{
						tloadtile(j);
					}
				}
				break;
			case DefineConstants.STALL:
				tloadtile(DefineConstants.STALLBROKE);
				for (j = DefineConstants.TOILETWATER; j < (DefineConstants.TOILETWATER + 4); j++)
				{
					if (Engine.waloff[j].memory == null)
					{
						tloadtile(j);
					}
				}
				break;
			case DefineConstants.RUBBERCAN:
				maxc = 2;
				break;
			case DefineConstants.TOILETWATER:
				maxc = 4;
				break;
			case DefineConstants.FEMPIC1:
				maxc = 44;
				break;
			case DefineConstants.LIZTROOP:
			case DefineConstants.LIZTROOPRUNNING:
			case DefineConstants.LIZTROOPSHOOT:
			case DefineConstants.LIZTROOPJETPACK:
			case DefineConstants.LIZTROOPONTOILET:
			case DefineConstants.LIZTROOPDUCKING:
				for (j = DefineConstants.LIZTROOP; j < (DefineConstants.LIZTROOP + 72); j++)
				{
					if (Engine.waloff[j].memory == null)
					{
						tloadtile(j);
					}
				}
				for (j = DefineConstants.HEADJIB1; j < DefineConstants.LEGJIB1 + 3; j++)
				{
					if (Engine.waloff[j].memory == null)
					{
						tloadtile(j);
					}
				}
				maxc = 0;
				break;
			case DefineConstants.WOODENHORSE:
				maxc = 5;
				for (j = DefineConstants.HORSEONSIDE; j < (DefineConstants.HORSEONSIDE + 4); j++)
				{
					if (Engine.waloff[j].memory == null)
					{
						tloadtile(j);
					}
				}
				break;
			case DefineConstants.NEWBEAST:
			case DefineConstants.NEWBEASTSTAYPUT:
				maxc = 90;
				break;
			case DefineConstants.BOSS1:
			case DefineConstants.BOSS2:
			case DefineConstants.BOSS3:
				maxc = 30;
				break;
			case DefineConstants.OCTABRAIN:
			case DefineConstants.OCTABRAINSTAYPUT:
			case DefineConstants.COMMANDER:
			case DefineConstants.COMMANDERSTAYPUT:
				maxc = 38;
				break;
			case DefineConstants.RECON:
				maxc = 13;
				break;
			case DefineConstants.PIGCOP:
			case DefineConstants.PIGCOPDIVE:
				maxc = 61;
				break;
			case DefineConstants.SHARK:
				maxc = 30;
				break;
			case DefineConstants.LIZMAN:
			case DefineConstants.LIZMANSPITTING:
			case DefineConstants.LIZMANFEEDING:
			case DefineConstants.LIZMANJUMP:
				for (j = DefineConstants.LIZMANHEAD1; j < DefineConstants.LIZMANLEG1 + 3; j++)
				{
					if (Engine.waloff[j].memory == null)
					{
						tloadtile(j);
					}
				}
				maxc = 80;
				break;
			case DefineConstants.APLAYER:
				maxc = 0;
				if (ud.multimode > 1)
				{
					maxc = 5;
					for (j = 1420; j < 1420 + 106; j++)
					{
						if (Engine.waloff[j].memory == null)
						{
							tloadtile(j);
						}
					}
				}
				break;
			case DefineConstants.ATOMICHEALTH:
				maxc = 14;
				break;
			case DefineConstants.DRONE:
				maxc = 10;
				break;
			case DefineConstants.EXPLODINGBARREL:
			case DefineConstants.SEENINE:
			case DefineConstants.OOZFILTER:
				maxc = 3;
				break;
			case DefineConstants.NUKEBARREL:
			case DefineConstants.CAMERA1:
				maxc = 5;
				break;
		}

		for (j = Engine.board.sprite[i].picnum; j < (Engine.board.sprite[i].picnum + maxc); j++)
		{
			if (Engine.waloff[j].memory == null)
			{
				tloadtile(j);
			}
		}
	}

	public static void cachegoodsprites()
	{
		short i;

// jmarshall caching?
		//if (ud.screen_size >= 8)
		//{
		//	if (Engine.waloff[DefineConstants.BOTTOMSTATUSBAR].memory == null)
		//	{
		//		tloadtile(DefineConstants.BOTTOMSTATUSBAR);
		//	}
		//	if (ud.multimode > 1)
		//	{
		//		if (Engine.waloff[DefineConstants.FRAGBAR].memory == null)
		//		{
		//			tloadtile(DefineConstants.FRAGBAR);
		//		}
		//		for (i = DefineConstants.MINIFONT; i < DefineConstants.MINIFONT + 63; i++)
		//		{
		//			if (Engine.waloff[i].memory == null)
		//			{
		//				tloadtile(i);
		//			}
		//		}
		//	}
		//}
// jmarshall end

		tloadtile(DefineConstants.VIEWSCREEN);
// jmarshall caching?
		//for (i = DefineConstants.STARTALPHANUM; i < DefineConstants.ENDALPHANUM + 1; i++)
		//{
		//	if (Engine.waloff[i].memory == null)
		//	{
		//		tloadtile(i);
		//	}
		//}
		//
		//for (i = DefineConstants.FOOTPRINTS; i < DefineConstants.FOOTPRINTS + 3; i++)
		//{
		//	if (Engine.waloff[i].memory == null)
		//	{
		//		tloadtile(i);
		//	}
		//}
		//
		//for (i = DefineConstants.BIGALPHANUM; i < DefineConstants.BIGALPHANUM + 82; i++)
		//{
		//	if (Engine.waloff[i].memory == null)
		//	{
		//		tloadtile(i);
		//	}
		//}
		//
		//for (i = DefineConstants.BURNING; i < DefineConstants.BURNING + 14; i++)
		//{
		//	if (Engine.waloff[i].memory == null)
		//	{
		//		tloadtile(i);
		//	}
		//}
		//
		//for (i = DefineConstants.BURNING2; i < DefineConstants.BURNING2 + 14; i++)
		//{
		//	if (Engine.waloff[i].memory == null)
		//	{
		//		tloadtile(i);
		//	}
		//}
		//
		//for (i = DefineConstants.CRACKKNUCKLES; i < DefineConstants.CRACKKNUCKLES + 4; i++)
		//{
		//	if (Engine.waloff[i].memory == null)
		//	{
		//		tloadtile(i);
		//	}
		//}
		//
		//for (i = DefineConstants.FIRSTGUN; i < DefineConstants.FIRSTGUN + 3; i++)
		//{
		//	if (Engine.waloff[i].memory == null)
		//	{
		//		tloadtile(i);
		//	}
		//}
		//
		//for (i = DefineConstants.EXPLOSION2; i < DefineConstants.EXPLOSION2 + 21; i++)
		//{
		//	if (Engine.waloff[i].memory == null)
		//	{
		//		tloadtile(i);
		//	}
		//}
		//
		//tloadtile(DefineConstants.BULLETHOLE);
		//
		//for (i = DefineConstants.FIRSTGUNRELOAD; i < DefineConstants.FIRSTGUNRELOAD + 8; i++)
		//{
		//	if (Engine.waloff[i].memory == null)
		//	{
		//		tloadtile(i);
		//	}
		//}
		//
		//tloadtile(DefineConstants.FOOTPRINTS);
		//
		//for (i = DefineConstants.JIBS1; i < (DefineConstants.JIBS5 + 5); i++)
		//{
		//	if (Engine.waloff[i].memory == null)
		//	{
		//		tloadtile(i);
		//	}
		//}
		//
		//for (i = DefineConstants.SCRAP1; i < (DefineConstants.SCRAP1 + 19); i++)
		//{
		//	if (Engine.waloff[i].memory == null)
		//	{
		//		tloadtile(i);
		//	}
		//}
		//
		//for (i = DefineConstants.SMALLSMOKE; i < (DefineConstants.SMALLSMOKE + 4); i++)
		//{
		//	if (Engine.waloff[i].memory == null)
		//	{
		//		tloadtile(i);
		//	}
		//}
	}

	public static char getsound(ushort num)
	{
		kFile fp;
		int l;

// jmarshall - sound
		return (char)0;
/*
		if (num >= DefineConstants.NUM_SOUNDS || SoundToggle == 0)
		{
			return (char)0;
		}
		if (FXDevice == soundcardnames.NumSoundCards)
		{
			return (char)0;
		}

		fp = kopen4load(sounds[num], loadfromgrouponly);
		if (fp == -1)
		{
			return (char)0;
		}

		l = fp.Length;
		soundsiz[num] = l;

		if ((ud.level_number == 0 && ud.volume_number == 0 && (num == 189 || num == 232 || num == 99 || num == 233 || num == 17)) || (l < 12288))
		{
			Sound[num].@lock = 2;
			//allocache((int)&Sound[num].ptr, l, Sound[num].@lock); 
			//if (Sound[num].ptr != null)
			//{
			//	kread(fp, Sound[num].ptr, l);
			//}
		}
		return 1;
*/
// jmarshall		
	}

	public static void precachenecessarysounds()
	{
		short i;
		short j;
// jmarshall - sounds
/*
		if (FXDevice == soundcardnames.NumSoundCards)
		{
			return;
		}
		j = 0;

		for (i = 0; i < DefineConstants.NUM_SOUNDS; i++)
		{
			if (Sound[i].ptr == 0)
			{
				j++;
				if ((j & 7) == 0)
				{
					getpackets();
				}
				getsound((ushort)i);
			}
		}
*/
// jmarshall end
	}


	public static void cacheit()
	{
		short i;
		short j;

		precachenecessarysounds();

		cachegoodsprites();
// jmarshall - caching?
		//for (i = 0; i < numwalls; i++)
		//{
		//	if (Engine.waloff[Engine.board.wall[i].picnum] == 0)
		//	{
		//		if (Engine.waloff[Engine.board.wall[i].picnum] == 0)
		//		{
		//			tloadtile(Engine.board.wall[i].picnum);
		//		}
		//		if (Engine.board.wall[i].overpicnum >= 0 && Engine.waloff[Engine.board.wall[i].overpicnum] == 0)
		//		{
		//			tloadtile(Engine.board.wall[i].overpicnum);
		//		}
		//	}
		//}
		//
		//for (i = 0; i < numsectors; i++)
		//{
		//	if (Engine.waloff[Engine.board.sector[i].floorpicnum] == 0)
		//	{
		//		tloadtile(Engine.board.sector[i].floorpicnum);
		//	}
		//	if (Engine.waloff[Engine.board.sector[i].ceilingpicnum] == 0)
		//	{
		//		tloadtile(Engine.board.sector[i].ceilingpicnum);
		//		if (Engine.waloff[Engine.board.sector[i].ceilingpicnum] == DefineConstants.LA)
		//		{
		//			tloadtile(DefineConstants.LA + 1);
		//			tloadtile(DefineConstants.LA + 2);
		//		}
		//	}
		//
		//	j = headspritesect[i];
		//	while (j >= 0)
		//	{
		//		if (Engine.board.sprite[j].xrepeat != 0 && Engine.board.sprite[j].yrepeat != 0 && (Engine.board.sprite[j].cstat & 32768) == 0)
		//		{
		//			if (Engine.waloff[Engine.board.sprite[j].picnum] == 0)
		//			{
		//				cachespritenum(j);
		//			}
		//		}
		//		j = nextspritesect[j];
		//	}
		//}
// jmarshall end
	}

	public static void docacheit()
	{
// jmarshall - caching?
/*
		int i;
		int j;

		j = 0;

		for (i = 0; i < DefineConstants.MAXTILES; i++)
		{
			if ((gotpic[i >> 3] & (1 << (i & 7))) != 0 && Engine.waloff[i] == 0)
			{
				loadtile((short)i);
				j++;
				if ((j & 7) == 0)
				{
					getpackets();
				}
			}
		}

		clearbufbyte(gotpic, sizeof(gotpic), 0);
*/
// jmarshall end
	}



	public static void xyzmirror(short i, short wn)
	{
// jmarshall - mirrors
		//if (Engine.waloff[wn] == 0)
		//{
		//	loadtile(wn);
		//}

		//Engine.setviewtotile(wn, tilesizy[wn], tilesizx[wn]);
		//
		//drawrooms(Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].z, Engine.board.sprite[i].ang, 100 + Engine.board.sprite[i].shade, Engine.board.sprite[i].sectnum);
		//display_mirror = 1;
		//animatesprites(Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].ang, 65536);
		//display_mirror = 0;
		//drawmasks();
		//
		//setviewback();
		//squarerotatetile(wn);
// jmarshall end
	}

	public static void vscrn()
	{
		int i;
		int j;
		int ss;
		int x1;
		int x2;
		int y1;
		int y2;

		if (ud.screen_size < 0)
		{
			ud.screen_size = 0;
		}
		else if (ud.screen_size > 63)
		{
			ud.screen_size = 64;
		}

		if (ud.screen_size == 0)
		{
			flushperms();
		}

		ss = Math.Max(ud.screen_size - 8, 0);

		x1 = pragmas.scale(ss, Engine.xdim, 160);
		x2 = Engine.xdim - x1;

		y1 = ss;
		y2 = 200;
		if (ud.screen_size > 0 && ud.coop != 1 && ud.multimode > 1)
		{
			j = 0;
			for (i = connecthead; i >= 0; i = connectpoint2[i])
			{
				if (i > j)
				{
					j = i;
				}
			}

			if (j >= 1)
			{
				y1 += 8;
			}
			if (j >= 4)
			{
				y1 += 8;
			}
			if (j >= 8)
			{
				y1 += 8;
			}
			if (j >= 12)
			{
				y1 += 8;
			}
		}

		if (ud.screen_size >= 8)
		{
			y2 -= (ss + 34);
		}

		y1 = pragmas.scale(y1, Engine.ydim, 200);
		y2 = pragmas.scale(y2, Engine.ydim, 200);

		Engine._device.setview(x1, y1, x2 - 1, y2 - 1);

		pub = (char)DefineConstants.NUMPAGES;
		pus = (char)DefineConstants.NUMPAGES;
	}

	public static void pickrandomspot(short snum)
	{
		player_struct p;
		uint i;

		p = ps[snum];

		if (ud.multimode > 1 && ud.coop != 1)
		{
			i = Engine.krand() % numplayersprites;
		}
		else
		{
			i = (uint)snum;
		}

		p.bobposx = p.oposx = p.posx = po[i].ox;
		p.bobposy = p.oposy = p.posy = po[i].oy;
		p.oposz = p.posz = po[i].oz;
		p.ang = po[i].oa;
		p.cursectnum = po[i].os;
	}

	public static void resetplayerstats(short snum)
	{
		player_struct p;
		short i;

		p = ps[snum];

		ud.show_help = 0;
		ud.showallmap = 0;
		p.dead_flag = 0;
		p.wackedbyactor = -1;
		p.falling_counter = (char)0;
		p.quick_kick = 0;
		p.subweapon = 0;
		p.last_full_weapon = 0;
		p.ftq = 0;
		p.fta = 0;
		p.tipincs = 0;
		p.buttonpalette = (char)0;
		p.actorsqu = -1;
		p.invdisptime = 0;
		p.refresh_inventory = (char)0;
		p.last_pissed_time = 0;
		p.holster_weapon = 0;
		p.pycount = 0;
		p.pyoff = 0;
		p.opyoff = 0;
		p.loogcnt = 0;
		p.angvel = 0;
		p.weapon_sway = 0;
		//    p->select_dir       = 0;
		p.extra_extra8 = 0;
		p.show_empty_weapon = 0;
		p.dummyplayersprite = -1;
		p.crack_time = 0;
		p.hbomb_hold_delay = 0;
		p.transporter_hold = 0;
		p.wantweaponfire = -1;
		p.hurt_delay = 0;
		p.footprintcount = (char)0;
		p.footprintpal = (char)0;
		p.footprintshade = (short)0;
		p.jumping_toggle = (char)0;
		p.ohoriz = p.horiz = 140;
		p.horizoff = 0;
		p.bobcounter = 0;
		p.on_ground = (char)0;
		p.player_par = 0;
		p.return_to_center = (char)9;
		p.airleft = (short)(15 * 26);
		p.rapid_fire_hold = (char)0;
		p.toggle_key_flag = 0;
		p.access_spritenum = -1;
		if (ud.multimode > 1 && ud.coop != 1)
		{
			p.got_access = 7;
		}
		else
		{
			p.got_access = 0;
		}
		p.random_club_frame = 0;
		pus = (char)1;
		p.on_warping_sector = (char)0;
		p.spritebridge = (char)0;
// jmarshall - palette
		//p.palette = (string)&palette[0];
// jmarshall end

		if (p.steroids_amount < 400)
		{
			p.steroids_amount = 0;
			p.inven_icon = 0;
		}
		p.heat_on = (char)0;
		p.jetpack_on = (char)0;
		p.holoduke_on = -1;

		p.look_ang = (short)(512 - ((ud.level_number & 1) << 10));

		p.rotscrnang = 0;
		p.newowner = -1;
		p.jumping_counter = 0;
		p.hard_landing = (char)0;
		p.posxv = 0;
		p.posyv = 0;
		p.poszv = 0;
		fricxv = 0;
		fricyv = 0;
		p.somethingonplayer = -1;
		p.one_eighty_count = 0;
		p.cheat_phase = 0;

		p.on_crane = -1;

		if (p.curr_weapon == DefineConstants.PISTOL_WEAPON)
		{
			p.kickback_pic = 5;
		}
		else
		{
			p.kickback_pic = 0;
		}

		p.weapon_pos = 6;
		p.walking_snd_toggle = (char)0;
		p.weapon_ang = 0;

		p.knuckle_incs = (char)1;
		p.fist_incs = 0;
		p.knee_incs = 0;
		p.jetpack_on = (char)0;
// jmarshall
		//setpal(p);
// jmarshall end
	}



	public static void resetweapons(short snum)
	{
		short weapon;
		player_struct p;

		p = ps[snum];

		for (weapon = DefineConstants.PISTOL_WEAPON; weapon < DefineConstants.MAX_WEAPONS; weapon++)
		{
			p.gotweapon[weapon] = false;
		}
		for (weapon = DefineConstants.PISTOL_WEAPON; weapon < DefineConstants.MAX_WEAPONS; weapon++)
		{
			p.ammo_amount[weapon] = 0;
		}

		p.weapon_pos = 6;
		p.kickback_pic = 5;
		p.curr_weapon = DefineConstants.PISTOL_WEAPON;
		p.gotweapon[DefineConstants.PISTOL_WEAPON] = true;
		p.gotweapon[DefineConstants.KNEE_WEAPON] = true;
		p.ammo_amount[DefineConstants.PISTOL_WEAPON] = 48;
		p.gotweapon[DefineConstants.HANDREMOTE_WEAPON] = true;
		p.last_weapon = -1;

		p.show_empty_weapon = 0;
		p.last_pissed_time = 0;
		p.holster_weapon = 0;
	}

	public static void resetinventory(short snum)
	{
		player_struct p;
		short i;

		p = ps[snum];

		p.inven_icon = 0;
		p.boot_amount = 0;
		p.scuba_on = (char)0;
		p.scuba_amount = 0;
		p.heat_amount = 0;
		p.heat_on = (char)0;
		p.jetpack_on = (char)0;
		p.jetpack_amount = 0;
		p.shield_amount = (short)max_armour_amount;
		p.holoduke_on = -1;
		p.holoduke_amount = 0;
		p.firstaid_amount = 0;
		p.steroids_amount = 0;
		p.inven_icon = 0;
	}


	public static void resetprestat(short snum, char g)
	{
		player_struct p;
		short i;

		p = ps[snum];

		spriteqloc = 0;
		for (i = 0; i < spriteqamount; i++)
		{
			spriteq[i] = -1;
		}

		p.hbomb_on = (char)0;
		p.cheat_phase = 0;
		p.pals_time = 0;
		p.toggle_key_flag = 0;
		p.secret_rooms = (char)0;
		p.max_secret_rooms = (char)0;
		p.actors_killed = (char)0;
		p.max_actors_killed = (char)0;
		p.lastrandomspot = (char)0;
		p.weapon_pos = 6;
		p.kickback_pic = 5;
		p.last_weapon = -1;
		p.weapreccnt = 0;
		p.show_empty_weapon = 0;
		p.holster_weapon = 0;
		p.last_pissed_time = 0;

		p.one_parallax_sectnum = -1;
		p.visibility = ud.const_visibility;

		screenpeek = myconnectindex;
		numanimwalls = 0;
		numcyclers = 0;
		animatecnt = 0;
		Engine.board.parallaxtype = 0;
		Engine.randomseed = 17;
		ud.pause_on = 0;
		ud.camerasprite = -1;
		ud.eog = 0;
		//tempwallptr = 0;
		camsprite = -1;
		earthquaketime = (char)0;

		numinterpolations = 0;
		startofdynamicinterpolations = 0;

		if (((g & DefineConstants.MODE_EOL) != DefineConstants.MODE_EOL && numplayers < 2) || (ud.coop != 1 && numplayers > 1))
		{
			resetweapons(snum);
			resetinventory(snum);
		}
		else if (p.curr_weapon == DefineConstants.HANDREMOTE_WEAPON)
		{
			p.ammo_amount[DefineConstants.HANDBOMB_WEAPON]++;
			p.curr_weapon = DefineConstants.HANDBOMB_WEAPON;
		}

		p.timebeforeexit = 0;
		p.customexitsound = 0;

	}

	public static void setupbackdrop(short sky)
	{
		short i;

		for (i = 0; i < DefineConstants.MAXPSKYTILES; i++)
		{
			Engine.board.pskyoff[i] = 0;
		}

		if (Engine.board.parallaxyscale != 65536)
		{
			Engine.board.parallaxyscale = 32768;
		}

		switch (sky)
		{
			case DefineConstants.CLOUDYOCEAN:
				Engine.board.parallaxyscale = 65536;
				break;
			case DefineConstants.MOONSKY1:
				Engine.board.pskyoff[6] = 1;
				Engine.board.pskyoff[1] = 2;
				Engine.board.pskyoff[4] = 2;
				Engine.board.pskyoff[2] = 3;
				break;
			case DefineConstants.BIGORBIT1: // orbit
				Engine.board.pskyoff[5] = 1;
				Engine.board.pskyoff[6] = 2;
				Engine.board.pskyoff[7] = 3;
				Engine.board.pskyoff[2] = 4;
				break;
			case DefineConstants.LA:
				Engine.board.parallaxyscale = 16384 + 1024;
				Engine.board.pskyoff[0] = 1;
				Engine.board.pskyoff[1] = 2;
				Engine.board.pskyoff[2] = 1;
				Engine.board.pskyoff[3] = 3;
				Engine.board.pskyoff[4] = 4;
				Engine.board.pskyoff[5] = 0;
				Engine.board.pskyoff[6] = 2;
				Engine.board.pskyoff[7] = 3;
				break;
		}

		Engine.board.pskybits = 3;
	}

	public static void prelevel(char g)
	{
		int i;
		short nexti;
		short j;
		short startwall;
		short endwall;
		short lotaglist;
		short[] lotags = new short[65];

// jmarshall - clear sector 2d
		//clearbufbyte(show2dsector, sizeof(show2dsector), 0);
		//clearbufbyte(show2dwall, sizeof(show2dwall), 0);
		//clearbufbyte(show2dsprite, sizeof(show2dsprite), 0);
// jmarshall end

		resetprestat(0, g);
		numclouds = 0;

		for (i = 0; i < Engine.board.numsectors; i++)
		{
			Engine.board.sector[i].extra = 256;

			switch (Engine.board.sector[i].lotag)
			{
				case 20:
				case 22:
					if (Engine.board.sector[i].floorz > Engine.board.sector[i].ceilingz)
					{
						Engine.board.sector[i].lotag |= unchecked((short)32768);
					}
					continue;
			}

			if ((Engine.board.sector[i].ceilingstat & 1) != 0)
			{
// jmarshall - precache?
				//if (Engine.waloff[Engine.board.sector[i].ceilingpicnum] == 0)
				//{
				//	if (Engine.board.sector[i].ceilingpicnum == DefineConstants.LA)
				//	{
				//		for (j = 0; j < 5; j++)
				//		{
				//			if (Engine.waloff[Engine.board.sector[i].ceilingpicnum + j] == 0)
				//			{
				//				tloadtile(Engine.board.sector[i].ceilingpicnum + j);
				//			}
				//		}
				//	}
				//}
// jmarshall end
				setupbackdrop(Engine.board.sector[i].ceilingpicnum);

				if (Engine.board.sector[i].ceilingpicnum == DefineConstants.CLOUDYSKIES && numclouds < 127)
				{
					clouds[numclouds++] = (short)i;
				}

				if (ps[0].one_parallax_sectnum == -1)
				{
					ps[0].one_parallax_sectnum = (short)i;
				}
			}

			if (Engine.board.sector[i].lotag == 32767) //Found a secret room
			{
				ps[0].max_secret_rooms++;
				continue;
			}

			if (Engine.board.sector[i].lotag == -1)
			{
				ps[0].exitx = Engine.board.wall[Engine.board.sector[i].wallptr].x;
				ps[0].exity = Engine.board.wall[Engine.board.sector[i].wallptr].y;
				continue;
			}
		}

		i = Engine.board.headspritestat[0];
		while (i >= 0)
		{
			nexti = (short)Engine.board.nextspritestat[i];

			if (Engine.board.sprite[i].lotag == -1 && (Engine.board.sprite[i].cstat & 16) != 0)
			{
				ps[0].exitx = Engine.board.sprite[i].x;
				ps[0].exity = Engine.board.sprite[i].y;
			}
			else
			{
				switch (Engine.board.sprite[i].picnum)
				{
					case DefineConstants.GPSPEED:
						Engine.board.sector[Engine.board.sprite[i].sectnum].extra = Engine.board.sprite[i].lotag;
						Engine.board.deletesprite(i);
						break;

					case DefineConstants.CYCLER:
						if (numcyclers >= DefineConstants.MAXCYCLERS)
						{
							gameexit("\nToo many cycling sectors.");
						}
						cyclers[numcyclers,0] = Engine.board.sprite[i].sectnum;
						cyclers[numcyclers,1] = Engine.board.sprite[i].lotag;
						cyclers[numcyclers,2] = Engine.board.sprite[i].shade;
						cyclers[numcyclers,3] = Engine.board.sector[Engine.board.sprite[i].sectnum].floorshade;
						cyclers[numcyclers,4] = Engine.board.sprite[i].hitag;
						if (Engine.board.sprite[i].ang == 1536)
							cyclers[numcyclers, 5] = 1;
						else
							cyclers[numcyclers, 5] = 0;

						numcyclers++;
						Engine.board.deletesprite(i);
						break;
				}
			}
			i = nexti;
		}

		for (i = 0; i < DefineConstants.MAXSPRITES; i++)
		{
			if (Engine.board.sprite[i] == null)
				continue;
			if (Engine.board.sprite[i].statnum < DefineConstants.MAXSTATUS)
			{
				if (Engine.board.sprite[i].picnum == DefineConstants.SECTOREFFECTOR && Engine.board.sprite[i].lotag == 14)
				{
					continue;
				}
				spawn(-1, (short)i);
			}
		}

		for (i = 0; i < DefineConstants.MAXSPRITES; i++)
		{
            if (Engine.board.sprite[i] == null)
                continue;

            if (Engine.board.sprite[i].statnum < DefineConstants.MAXSTATUS)
			{
				if (Engine.board.sprite[i].picnum == DefineConstants.SECTOREFFECTOR && Engine.board.sprite[i].lotag == 14)
				{
					spawn(-1, (short)i);
				}
			}
		}

		lotaglist = 0;

		i = Engine.board.headspritestat[0];
		while (i >= 0)
		{
			switch (Engine.board.sprite[i].picnum)
			{
				case DefineConstants.DIPSWITCH:
				case DefineConstants.DIPSWITCH2:
				case DefineConstants.ACCESSSWITCH:
				case DefineConstants.PULLSWITCH:
				case DefineConstants.HANDSWITCH:
				case DefineConstants.SLOTDOOR:
				case DefineConstants.LIGHTSWITCH:
				case DefineConstants.SPACELIGHTSWITCH:
				case DefineConstants.SPACEDOORSWITCH:
				case DefineConstants.FRANKENSTINESWITCH:
				case DefineConstants.LIGHTSWITCH2:
				case DefineConstants.POWERSWITCH1:
				case DefineConstants.LOCKSWITCH1:
				case DefineConstants.POWERSWITCH2:
					break;
				case DefineConstants.DIPSWITCH + 1:
				case DefineConstants.DIPSWITCH2 + 1:
				case DefineConstants.PULLSWITCH + 1:
				case DefineConstants.HANDSWITCH + 1:
				case DefineConstants.SLOTDOOR + 1:
				case DefineConstants.LIGHTSWITCH + 1:
				case DefineConstants.SPACELIGHTSWITCH + 1:
				case DefineConstants.SPACEDOORSWITCH + 1:
				case DefineConstants.FRANKENSTINESWITCH + 1:
				case DefineConstants.LIGHTSWITCH2 + 1:
				case DefineConstants.POWERSWITCH1 + 1:
				case DefineConstants.LOCKSWITCH1 + 1:
				case DefineConstants.POWERSWITCH2 + 1:
					for (j = 0; j < lotaglist; j++)
					{
						if (Engine.board.sprite[i].lotag == lotags[j])
						{
							break;
						}
					}

					if (j == lotaglist)
					{
						lotags[lotaglist] = Engine.board.sprite[i].lotag;
						lotaglist++;
						if (lotaglist > 64)
						{
							gameexit("\nToo many switches (64 max).");
						}

						j = (short)Engine.board.headspritestat[3];
						while (j >= 0)
						{
							if (Engine.board.sprite[j].lotag == 12 && Engine.board.sprite[j].hitag == Engine.board.sprite[i].lotag)
							{
								hittype[j].count = 1;
							}
							j = (short)Engine.board.nextspritestat[j];
						}
					}
					break;
			}
			i = Engine.board.nextspritestat[i];
		}

		mirrorcnt = 0;

		for (i = 0; i < Engine.board.numwalls; i++)
		{
			walltype wal;
			wal = Engine.board.wall[i];

			if (wal.overpicnum == DefineConstants.MIRROR && (wal.cstat & 32) != 0)
			{
				j = wal.nextsector;

				if (mirrorcnt > 63)
				{
					gameexit("\nToo many mirrors (64 max.)");
				}
				if ((j >= 0) && Engine.board.sector[j].ceilingpicnum != DefineConstants.MIRROR)
				{
                    Engine.board.sector[j].ceilingpicnum = DefineConstants.MIRROR;
                    Engine.board.sector[j].floorpicnum = DefineConstants.MIRROR;
                    mirrorwall[mirrorcnt] = (short)i;
                    mirrorsector[mirrorcnt] = j;
                    mirrorcnt++;
                    continue;
				}
			}

			if (numanimwalls >= DefineConstants.MAXANIMWALLS)
			{
				gameexit("\nToo many 'anim' walls (max 512.)");
			}

			animwall[numanimwalls] = new animwalltype();

			animwall[numanimwalls].tag = 0;
            animwall[numanimwalls].wallnum = 0;

			switch (wal.overpicnum)
            {
                case DefineConstants.FANSHADOW:
                case DefineConstants.FANSPRITE:
					wal.cstat |= 65;
                    animwall[numanimwalls].wallnum = (short)i;
                    numanimwalls++;
                    break;

                case DefineConstants.W_FORCEFIELD:
// jmarshall - cache?
                    //if (waloff[DefineConstants.W_FORCEFIELD] == 0)
                    //{
                    //    for (j = 0; j < 3; j++)
                    //    {
                    //        tloadtile((short)(DefineConstants.W_FORCEFIELD + j));
                    //    }
                    //}
// jmarshall end
					goto case DefineConstants.W_FORCEFIELD + 1;

				case DefineConstants.W_FORCEFIELD + 1:
                case DefineConstants.W_FORCEFIELD + 2:
                    if (wal.shade > 31)
                    {
                        wal.cstat = 0;
                    }
                    else
                    {
                        wal.cstat |= 85 + 256;
                    }


                    if (wal.lotag != 0 && wal.nextwall >= 0)
                    {
                        Engine.board.wall[wal.nextwall].lotag = wal.lotag;
                    }

					goto case DefineConstants.BIGFORCE;

				case DefineConstants.BIGFORCE:

                    animwall[numanimwalls].wallnum = (short)i;
                    numanimwalls++;

                    continue;
            }

            wal.extra = -1;

			switch (wal.picnum)
			{
				case DefineConstants.WATERTILE2:
					for (j = 0; j < 3; j++)
					{
// jmarshall - cache
						//if (Engine.waloff[wal.picnum + j] == 0)
						//{
						//	tloadtile((short)(wal.picnum + j));
						//}
// jmarshall end
					}
					break;

				case DefineConstants.TECHLIGHT2:
				case DefineConstants.TECHLIGHT4:
// jmarshall - cache
					//if (Engine.waloff[wal.picnum] == 0)
					//{
					//	tloadtile(wal.picnum);
					//}
// jmarshall end
					break;
				case DefineConstants.W_TECHWALL1:
				case DefineConstants.W_TECHWALL2:
				case DefineConstants.W_TECHWALL3:
				case DefineConstants.W_TECHWALL4:
					animwall[numanimwalls].wallnum = (short)i;
					//                animwall[numanimwalls].tag = -1;
					numanimwalls++;
					break;
				case DefineConstants.SCREENBREAK6:
				case DefineConstants.SCREENBREAK7:
				case DefineConstants.SCREENBREAK8:
// jmarshall - cache
					//if (Engine.waloff[DefineConstants.SCREENBREAK6] == 0)
					//{
					//	for (j = DefineConstants.SCREENBREAK6; j < DefineConstants.SCREENBREAK9; j++)
					//	{
					//		tloadtile(j);
					//	}
					//}
// jmarshall end
					animwall[numanimwalls].wallnum = (short)i;
					animwall[numanimwalls].tag = -1;
					numanimwalls++;
					break;

				case DefineConstants.FEMPIC1:
				case DefineConstants.FEMPIC2:
				case DefineConstants.FEMPIC3:

					wal.extra = wal.picnum;
					animwall[numanimwalls].tag = -1;
					if (ud.lockout != 0)
					{
						if (wal.picnum == DefineConstants.FEMPIC1)
						{
							wal.picnum = DefineConstants.BLANKSCREEN;
						}
						else
						{
							wal.picnum = DefineConstants.SCREENBREAK6;
						}
					}

					animwall[numanimwalls].wallnum = (short)i;
					animwall[numanimwalls].tag = wal.picnum;
					numanimwalls++;
					break;

				case DefineConstants.SCREENBREAK1:
				case DefineConstants.SCREENBREAK2:
				case DefineConstants.SCREENBREAK3:
				case DefineConstants.SCREENBREAK4:
				case DefineConstants.SCREENBREAK5:

				case DefineConstants.SCREENBREAK9:
				case DefineConstants.SCREENBREAK10:
				case DefineConstants.SCREENBREAK11:
				case DefineConstants.SCREENBREAK12:
				case DefineConstants.SCREENBREAK13:
				case DefineConstants.SCREENBREAK14:
				case DefineConstants.SCREENBREAK15:
				case DefineConstants.SCREENBREAK16:
				case DefineConstants.SCREENBREAK17:
				case DefineConstants.SCREENBREAK18:
				case DefineConstants.SCREENBREAK19:

					animwall[numanimwalls].wallnum = (short)i;
					animwall[numanimwalls].tag = wal.picnum;
					numanimwalls++;
					break;
			}
		}

		//Invalidate textures in sector behind mirror
		for (i = 0; i < mirrorcnt; i++)
		{
			startwall = Engine.board.sector[mirrorsector[i]].wallptr;
			endwall = (short)(startwall + Engine.board.sector[mirrorsector[i]].wallnum);
			for (j = startwall; j < endwall; j++)
			{
				Engine.board.wall[j].picnum = DefineConstants.MIRROR;
				Engine.board.wall[j].overpicnum = DefineConstants.MIRROR;
			}
		}
	}


	public static void newgame(int vn, int ln, int sk)
	{
		player_struct p = ps[0];
		short i;
// jmarshall - global kill sound
		//if (globalskillsound >= 0)
		//{
		//	while (Sound[globalskillsound].@lock >= 200)
		//	{
		//		;
		//	}
		//}
// jmarshall end
		globalskillsound = -1;

		waitforeverybody();
		ready2send = (char)0;

		if (ud.m_recstat != 2 && ud.last_level >= 0 && ud.multimode > 1 && ud.coop != 1)
		{
			dobonus((char)1);
		}

		if (ln == 0 && vn == 3 && ud.multimode < 2 && ud.lockout == 0)
		{
			//playmusic(env_music_fn[1]); // jmarshall: eval vol4 animations

			flushperms();
			Engine._device.setview(0, 0, Engine.xdim - 1, Engine.ydim - 1);
			Engine.clearview();
			Engine.NextPage();

			playanm("vol41a.anm", 6);
			Engine.clearview();
			Engine.NextPage();
			playanm("vol42a.anm", 7);
			//        clearview(0L);
			//      nextpage();
			playanm("vol43a.anm", 9);
			Engine.clearview();
			Engine.NextPage();

			FX_StopAllSounds();
		}

		show_shareware = 26 * 34;

		ud.level_number = ln;
		ud.volume_number = vn;
		ud.player_skill = sk;
		ud.secretlevel = 0;
		ud.from_bonus = 0;
// jmarshall - isntance checking
		//Engine.board.parallaxyscale = 0;
// jmarshall end
		ud.last_level = -1;
		lastsavedpos = -1;
		p.zoom = 768;
		p.gm = 0;

		if (ud.m_coop != 1)
		{
			p.curr_weapon = DefineConstants.PISTOL_WEAPON;
			p.gotweapon[DefineConstants.PISTOL_WEAPON] = true;
			p.gotweapon[DefineConstants.KNEE_WEAPON] = true;
			p.ammo_amount[DefineConstants.PISTOL_WEAPON] = 48;
			p.gotweapon[DefineConstants.HANDREMOTE_WEAPON] = true;
			p.last_weapon = -1;
		}

		display_mirror = (char)0;

		if (ud.multimode > 1)
		{
			if (numplayers < 2)
			{
				connecthead = 0;
				for (i = 0; i < DefineConstants.MAXPLAYERS; i++)
				{
					connectpoint2[i] = (short)(i + 1);
				}
				connectpoint2[ud.multimode - 1] = -1;
			}
		}
		else
		{
			connecthead = 0;
			connectpoint2[0] = -1;
		}
	}


	public static void resetpspritevars(char g)
	{
		short i;
		short j;
		short nexti;
		short circ;
		int firstx;
		int firsty;
		spritetype s;
		int[] aimmode = new int[DefineConstants.MAXPLAYERS];
		STATUSBARTYPE[] tsbar = new STATUSBARTYPE[DefineConstants.MAXPLAYERS];

		EGS(ps[0].cursectnum, ps[0].posx, ps[0].posy, ps[0].posz, DefineConstants.APLAYER, 0, 0, 0, ps[0].ang, 0, 0, 0, 10);

		if (ud.recstat != 2)
		{
			for (i = 0; i < DefineConstants.MAXPLAYERS; i++)
			{
				if (ps[i] == null)
					continue;

				aimmode[i] = ps[i].aim_mode;// = StringFunctions.ChangeCharacter(aimmode, i, ps[i].aim_mode);
				if (ud.multimode > 1 && ud.coop == 1 && ud.last_level >= 0)
				{
					for (j = 0; j < DefineConstants.MAX_WEAPONS; j++)
					{
						tsbar[i].ammo_amount[j] = ps[i].ammo_amount[j];
						tsbar[i].gotweapon[j] = ps[i].gotweapon[j]; // = StringFunctions.ChangeCharacter(tsbar[i].gotweapon, j, ps[i].gotweapon[j]);
					}

					tsbar[i].shield_amount = ps[i].shield_amount;
					tsbar[i].curr_weapon = ps[i].curr_weapon;
					tsbar[i].inven_icon = ps[i].inven_icon;

					tsbar[i].firstaid_amount = ps[i].firstaid_amount;
					tsbar[i].steroids_amount = ps[i].steroids_amount;
					tsbar[i].holoduke_amount = ps[i].holoduke_amount;
					tsbar[i].jetpack_amount = ps[i].jetpack_amount;
					tsbar[i].heat_amount = ps[i].heat_amount;
					tsbar[i].scuba_amount = ps[i].scuba_amount;
					tsbar[i].boot_amount = ps[i].boot_amount;
				}
			}
		}

		resetplayerstats(0);

		for (i = 1; i < DefineConstants.MAXPLAYERS; i++)
		{			
			ps[i] = ps[0];
		}

		if (ud.recstat != 2)
		{
			for (i = 0; i < DefineConstants.MAXPLAYERS; i++)
			{
				ps[i].aim_mode = aimmode[i];
				if (ud.multimode > 1 && ud.coop == 1 && ud.last_level >= 0)
				{
					for (j = 0; j < DefineConstants.MAX_WEAPONS; j++)
					{
						ps[i].ammo_amount[j] = tsbar[i].ammo_amount[j];
						ps[i].gotweapon[j] = tsbar[i].gotweapon[j];
					}
					ps[i].shield_amount = tsbar[i].shield_amount;
					ps[i].curr_weapon = tsbar[i].curr_weapon;
					ps[i].inven_icon = tsbar[i].inven_icon;

					ps[i].firstaid_amount = tsbar[i].firstaid_amount;
					ps[i].steroids_amount = tsbar[i].steroids_amount;
					ps[i].holoduke_amount = tsbar[i].holoduke_amount;
					ps[i].jetpack_amount = tsbar[i].jetpack_amount;
					ps[i].heat_amount = tsbar[i].heat_amount;
					ps[i].scuba_amount = tsbar[i].scuba_amount;
					ps[i].boot_amount = tsbar[i].boot_amount;
				}
			}
		}

		numplayersprites = (char)0;
		circ = (short)(2048 / ud.multimode);

		which_palookup = 9;
		j = connecthead;
		i = (short)Engine.board.headspritestat[10];
		while (i >= 0)
		{
			nexti = (short)Engine.board.nextspritestat[i];
			s = Engine.board.sprite[i];

			if (numplayersprites == DefineConstants.MAXPLAYERS)
			{
				gameexit("\nToo many player sprites (max 16.)");
			}

			if (numplayersprites == 0)
			{
				firstx = ps[0].posx;
				firsty = ps[0].posy;
			}

			po[numplayersprites] = new player_orig();

			po[numplayersprites].ox = s.x;
			po[numplayersprites].oy = s.y;
			po[numplayersprites].oz = s.z;
			po[numplayersprites].oa = s.ang;
			po[numplayersprites].os = s.sectnum;

			numplayersprites++;
			if (j >= 0)
			{
				s.owner = i;
				s.shade = 0;
				s.xrepeat = 42;
				s.yrepeat = 36;
				s.cstat = (short)(1 + 256);
				s.xoffset = 0;
				s.clipdist = 64;

				if ((g & DefineConstants.MODE_EOL) != DefineConstants.MODE_EOL || ps[j].last_extra == 0)
				{
					ps[j].last_extra = (short)max_player_health;
					s.extra = (short)max_player_health;
				}
				else
				{
					s.extra = ps[j].last_extra;
				}

				s.yvel = j;

				if (s.pal == 0)
				{
// jmarshall - palette
					//s.pal = (short)ps[j].palookup = (short)which_palookup;
// jmarshall end
					which_palookup++;
					if (which_palookup >= 17)
					{
						which_palookup = 9;
					}
				}
				else
				{
					ps[j].palookup = (char)s.pal;
				}

				ps[j].i = i;
				ps[j].frag_ps = j;
				hittype[i].owner = i;

				hittype[i].bposx = ps[j].bobposx = ps[j].oposx = ps[j].posx = s.x;
				hittype[i].bposy = ps[j].bobposy = ps[j].oposy = ps[j].posy = s.y;
				hittype[i].bposz = ps[j].oposz = ps[j].posz = s.z;
				ps[j].oang = ps[j].ang = s.ang;

				Engine.board.updatesector(s.x, s.y, ref ps[j].cursectnum);

				j = connectpoint2[j];

			}
			else
			{
				Engine.board.deletesprite(i);
			}
			i = nexti;
		}
	}

	public static void clearfrags()
	{
		short i;

		for (i = 0; i < DefineConstants.MAXPLAYERS; i++)
		{
			ps[i].frag = ps[i].fraggedself = 0;
		}
		//clearbufbyte(frags[0][0], (DefineConstants.MAXPLAYERS * DefineConstants.MAXPLAYERS) << 1, 0);
		Array.Clear(frags, 0, DefineConstants.MAXPLAYERS);
	}

	public static void resettimevars()
	{
		vel = svel = angvel = horiz = 0;

		totalclock = 0;
		cloudtotalclock = 0;
		ototalclock = 0;
		lockclock = 0;
		ready2send = (char)1;
	}


	public static void genspriteremaps()
	{
		int j;
		kFile fp;
		int look_pos;
		string lookfn = "lookup.dat";
		int numl = 0;

		Engine.LoadTables();

		fp = Engine.filesystem.kopen4load(lookfn);
		if (fp != null)
		{
			//kread(fp, (string)&numl, 1);
			numl = (char)fp.kreadbyte();
		}
		else
		{
			gameexit("\nERROR: File 'LOOKUP.DAT' not found.");
		}

		for (j = 0; j < numl; j++)
		{
			look_pos = fp.kreadbyte();
			fp.kread<byte>(ref tempbuf, 0, 256);
			Engine.palette.makepalookup((int)look_pos, tempbuf, 0, 0, 0, true);
		}

		fp.kread<byte>(ref waterpal, 0, 768);
		fp.kread<byte>(ref slimepal, 0, 768);
		fp.kread<byte>(ref titlepal, 0, 768);
		fp.kread<byte>(ref drealms, 0, 768);
		fp.kread<byte>(ref endingpal, 0, 768);

// jmarshall - palette
		//palette[765] = palette[766] = palette[767] = 0;
		//slimepal[765] = slimepal[766] = slimepal[767] = 0;
		//waterpal[765] = waterpal[766] = waterpal[767] = 0;
// jmarshall end
		//kclose(fp);
	}

	public static void waitforeverybody()
	{
		int i;
// jmarshall - multiplayer
/*
		if (numplayers < 2)
		{
			return;
		}
		packbuf[0] = 250;
		for (i = connecthead; i >= 0; i = connectpoint2[i])
		{
			if (i != myconnectindex)
			{
				sendpacket(i, packbuf, 1);
			}
		}

		playerreadyflag[myconnectindex]++;
		do
		{
			getpackets();
			for (i = connecthead; i >= 0; i = connectpoint2[i])
			{
				if (playerreadyflag[i] < playerreadyflag[myconnectindex])
				{
					break;
				}
			}
		} while (i >= 0);
*/
// jmarshall end
	}

	public static void dofrontscreens()
	{
		int tincs;
		int i;
		int j;

		if (ud.recstat != 2)
		{
// jmarshall - palette
			//ps[myconnectindex].palette = palette;
			//for (j = 0; j < 63; j += 7)
			//{
			//	palto(0, 0, 0, j);
			//}
// jmarshall end
			i = ud.screen_size;
			ud.screen_size = 0;
			vscrn();
			Engine.clearview();

			Engine.rotatesprite(320 << 15, 200 << 15, 65536, 0, DefineConstants.LOADSCREEN, 0, 0, 2 + 8 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

			if (boardfilename.Length != 0 && ud.level_number == 7 && ud.volume_number == 0)
			{
				menutext(160, 90, 0, 0, "ENTERING USER MAP");
				gametextpal(160, 90 + 10, boardfilename, (char)14, (char)2);
			}
			else
			{
				menutext(160, 90, 0, 0, "ENTERING");
				menutext(160, 90 + 16 + 8, 0, 0, level_names[(ud.volume_number * 11) + ud.level_number]);
			}

			Engine.NextPage();
// jmarshall
			//for (j = 63; j > 0; j -= 7)
			//{
			//	palto(0, 0, 0, j);
			//}
			//
			//KB_FlushKeyboardQueue();
// jmarshall end
			ud.screen_size = i;
		}
		else
		{
			Engine.clearview();
// jmarshall - palette
			//ps[myconnectindex].palette = palette;
			//palto(0, 0, 0, 0);
// jmarshall end
			Engine.rotatesprite(320 << 15, 200 << 15, 65536, 0, DefineConstants.LOADSCREEN, 0, 0, 2 + 8 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			menutext(160, 105, 0, 0, "LOADING...");
			Engine.NextPage();
		}
	}

	public static void clearfifo()
	{
		syncvaltail = 0;
		syncvaltottail = 0;
		syncstat = (char)0;
		bufferjitter = 1;
		mymaxlag = otherminlag = 0;

		movefifoplc = movefifosendplc = fakemovefifoplc = 0;
		avgfvel = avgsvel = avgavel = avghorz = avgbits = 0;
		otherminlag = mymaxlag = 0;

		Array.Clear(myminlag, 0, myminlag.Length); //clearbufbyte(myminlag, DefineConstants.MAXPLAYERS << 2, 0);
		loc = new input(); // clearbufbyte(loc, sizeof(input), 0);
		Array.Clear(sync, 0, sync.Length);// = new input[DefineConstants.MAXPLAYERS]; //clearbufbyte(sync[0], sizeof(sync), 0);
		inputfifo = new input[DefineConstants.MOVEFIFOSIZ, DefineConstants.MAXPLAYERS]; //clearbufbyte(inputfifo, sizeof(input) * DefineConstants.MOVEFIFOSIZ * DefineConstants.MAXPLAYERS, 0);

		Array.Clear(movefifoend, 0, movefifoend.Length); // = new int[DefineConstants.MAXPLAYERS]; //clearbuf(movefifoend, DefineConstants.MAXPLAYERS, 0);
		Array.Clear(syncvalhead, 0, syncvalhead.Length); // = new int[DefineConstants.MAXPLAYERS];//clearbuf(syncvalhead, DefineConstants.MAXPLAYERS, 0);
		Array.Clear(myminlag, 0, myminlag.Length); // = new int[DefineConstants.MAXPLAYERS]; //clearbuf(myminlag, DefineConstants.MAXPLAYERS, 0);

		//    clearbufbyte(playerquitflag,MAXPLAYERS,0x01);
	}

	public static void resetmys()
	{
		myx = omyx = ps[myconnectindex].posx;
		myy = omyy = ps[myconnectindex].posy;
		myz = omyz = ps[myconnectindex].posz;
		myxvel = myyvel = myzvel = 0;
		myang = omyang = ps[myconnectindex].ang;
		myhoriz = omyhoriz = (short)ps[myconnectindex].horiz;
		myhorizoff = omyhorizoff = ps[myconnectindex].horizoff;
		mycursectnum = ps[myconnectindex].cursectnum;
		myjumpingcounter = ps[myconnectindex].jumping_counter;
		myjumpingtoggle = ps[myconnectindex].jumping_toggle;
		myonground = ps[myconnectindex].on_ground;
		myhardlanding = ps[myconnectindex].hard_landing;
		myreturntocenter = ps[myconnectindex].return_to_center;
	}

	public static void enterlevel(char g)
	{
		short i;
		short j;
		int l;
		string levname = new string(new char[256]);

		if ((g & DefineConstants.MODE_DEMO) != DefineConstants.MODE_DEMO)
		{
			ud.recstat = ud.m_recstat;
		}
		ud.respawn_monsters = ud.m_respawn_monsters;
		ud.respawn_items = ud.m_respawn_items;
		ud.respawn_inventory = ud.m_respawn_inventory;
		ud.monsters_off = ud.m_monsters_off;
		ud.coop = ud.m_coop;
		ud.marker = ud.m_marker;
		ud.ffire = ud.m_ffire;

		if ((g & DefineConstants.MODE_DEMO) == 0 && ud.recstat == 2)
		{
			ud.recstat = 0;
		}

		FX_StopAllSounds();
		clearsoundlocks();
		FX_SetReverb(0);

		i = (short)ud.screen_size;
		ud.screen_size = 0;
		dofrontscreens();
		vscrn();
		ud.screen_size = i;

#if !VOLUMEONE
		string _mapName = boardfilename;
		if(boardfilename.Length == 0)
        {
			_mapName = level_file_names[(ud.volume_number * 11) + ud.level_number];
		}

		if (boardfilename.Length != 0 && ud.m_level_number == 7 && ud.m_volume_number == 0)
		{
			if (Engine.loadboard(boardfilename, ref ps[0].posx, ref ps[0].posy, ref ps[0].posz, ref ps[0].ang, ref ps[0].cursectnum) == -1)
			{
				gameexit("Map not found! " + boardfilename);
			}
		}
		else if (Engine.loadboard(level_file_names[(ud.volume_number * 11) + ud.level_number], ref ps[0].posx, ref ps[0].posy, ref ps[0].posz, ref ps[0].ang, ref ps[0].cursectnum) == -1)
		{
			gameexit("Map not found! " + level_file_names[(ud.volume_number * 11) + ud.level_number]);
		}

#else

		l = strlen(level_file_names[(ud.volume_number * 11) + ud.level_number]);
		copybufbyte(level_file_names[(ud.volume_number * 11) + ud.level_number], levname[0], l);
		levname = StringFunctions.ChangeCharacter(levname, l, 255);
		levname = levname.Substring(0, l + 1);

		if (loadboard(levname, ps[0].posx, ps[0].posy, ps[0].posz, ps[0].ang, ps[0].cursectnum) == -1)
		{
			sprintf(tempbuf,"Map %s not found!",level_file_names[(ud.volume_number * 11) + ud.level_number]);
			gameexit(ref tempbuf);
		}
#endif		
		Array.Clear(Engine.board.gotpic, 0, Engine.board.gotpic.Length);

		prelevel(g);

		allignwarpelevators();
		resetpspritevars(g);

		cachedebug = 0;
		automapping = 0;

		if (ud.recstat != 2)
		{
			MUSIC_StopSong();
		}

		cacheit();
		docacheit();

		if (ud.recstat != 2)
		{
			music_select = (char)((ud.volume_number * 11) + ud.level_number);
// jmarshall - changed to just pass in the indexes
			playmusic(ud.volume_number + 1, ud.level_number);
// jmarshall end
		}

		if ((g & DefineConstants.MODE_GAME) != 0 || (g & DefineConstants.MODE_EOL) != 0)
		{
			ps[myconnectindex].gm = DefineConstants.MODE_GAME;
		}
		else if ((g & DefineConstants.MODE_RESTART) != 0)
		{
			if (ud.recstat == 2)
			{
				ps[myconnectindex].gm = DefineConstants.MODE_DEMO;
			}
			else
			{
				ps[myconnectindex].gm = DefineConstants.MODE_GAME;
			}
		}

		if ((ud.recstat == 1) && (g & DefineConstants.MODE_RESTART) != DefineConstants.MODE_RESTART)
		{
			opendemowrite();
		}

#if VOLUMEONE
		if (ud.level_number == 0 && ud.recstat != 2)
		{
			FTA(40, ps[myconnectindex]);
		}
#endif

		for (i = connecthead; i >= 0; i = connectpoint2[i])
		{
			switch (Engine.board.sector[Engine.board.sprite[ps[i].i].sectnum].floorpicnum)
			{
				case DefineConstants.HURTRAIL:
				case DefineConstants.FLOORSLIME:
				case DefineConstants.FLOORPLASMA:
					resetweapons(i);
					resetinventory(i);
					ps[i].gotweapon[DefineConstants.PISTOL_WEAPON] = false;
					ps[i].ammo_amount[DefineConstants.PISTOL_WEAPON] = 0;
					ps[i].curr_weapon = DefineConstants.KNEE_WEAPON;
					ps[i].kickback_pic = 0;
					break;
			}
		}

		//PREMAP.C - replace near the my's at the end of the file

		resetmys();
// jmarshall - palette
		ps[myconnectindex].palette = palette;
		palto(0, 0, 0, 0);
		//
		//setpal(ps[myconnectindex]);
// jmarshall end
		flushperms();

		everyothertime = (char)0;
		global_random = 0;

		ud.last_level = (short)(ud.level_number + 1);

		clearfifo();

		for (i = (short)(numinterpolations - 1); i >= 0; i--)
		{
			bakipos[i] = curipos[i].Value;
		}

// jmarshall - palette and networking
		//restorepalette = 1;
		//
		//flushpackets();
// jmarshall end
		waitforeverybody();


		palto(0, 0, 0, 0);
		vscrn();
		Engine.clearview();
		drawbackground();

// jmarshall - clear?
		//clearbufbyte(playerquitflag, DefineConstants.MAXPLAYERS, 0x01010101);
		Array.Clear(playerquitflag, 0, playerquitflag.Length);
// jmarshall end
		ps[myconnectindex].over_shoulder_on = 0;

		clearfrags();

		resettimevars(); // Here we go

		currentStage = GameStateType.GAME_STATE_INGAME;
		ps[myconnectindex].gm = DefineConstants.MODE_GAME;
		in_menu = false;
		KB_FlushKeyboardQueue();

		conScript.Event_EnterLevel(_mapName, ps[0].i);
	}

    /*
	Duke Nukem V
	
	Layout:
	
	      Settings:
	        Suburbs
	          Duke inflitrating neighborhoods inf. by aliens
	        Death Valley:
	          Sorta like a western.  Bull-skulls halb buried in the sand
	          Military compound:  Aliens take over nuke-missle silo, duke
	            must destroy.
	          Abondend Aircraft field
	        Vegas:
	          Blast anything bright!  Alien lights camoflauged.
	          Alien Drug factory. The Blue Liquid
	        Mountainal Cave:
	          Interior cave battles.
	        Jungle:
	          Trees, canopee, animals, a mysterious hole in the earth
	        Penetencury:
	          Good use of spotlights:
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
	
	Programming:
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
}
