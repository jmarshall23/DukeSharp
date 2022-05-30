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
using UnityEngine;

#pragma warning disable 0168
#pragma warning disable 0129
public partial class GlobalMembers
{
	public static void updateinterpolations() //Stick at beginning of domovethings
	{
		int i;

		for (i = numinterpolations - 1; i >= 0; i--)
		{
			oldipos[i] = curipos[i].Value;
		}
	}


	public static void setinterpolation(SectorAnimation posptr)
	{
		int i;

		if (numinterpolations >= DefineConstants.MAXINTERPOLATIONS)
		{
			return;
		}
		for (i = numinterpolations - 1; i >= 0; i--)
		{
			if (curipos[i].Compare(posptr))
			{
				return;
			}
		}
		curipos[numinterpolations] = posptr;
		oldipos[numinterpolations] = posptr.Value;
		numinterpolations++;
	}

	public static void stopinterpolation(SectorAnimation posptr)
	{
		int i;

		for (i = numinterpolations - 1; i >= startofdynamicinterpolations; i--)
		{
			if (curipos[i].Compare(posptr))
			{
				numinterpolations--;
				oldipos[i] = oldipos[numinterpolations];
				bakipos[i] = bakipos[numinterpolations];
				curipos[i] = curipos[numinterpolations];
			}
		}
	}

	public static void dointerpolations(int smoothratio) //Stick at beginning of drawscreen
	{
		int i;
		int j;
		int odelta;
		int ndelta;

		ndelta = 0;
		j = 0;
		for (i = numinterpolations - 1; i >= 0; i--)
		{
			bakipos[i] = curipos[i].Value;
			odelta = ndelta;
			ndelta = (curipos[i].Value) - oldipos[i];
			if (odelta != ndelta)
			{
				j = pragmas.mulscale16(ndelta, smoothratio);
			}
			curipos[i].Value = oldipos[i] + j;
		}
	}

	public static void restoreinterpolations() //Stick at end of drawscreen
	{
		int i;

		for (i = numinterpolations - 1; i >= 0; i--)
		{
			curipos[i].Value = bakipos[i];
		}
	}

	public static int ceilingspace(short sectnum)
	{
		if ((Engine.board.sector[sectnum].ceilingstat & 1) != 0 && Engine.board.sector[sectnum].ceilingpal == 0)
		{
			switch (Engine.board.sector[sectnum].ceilingpicnum)
			{
				case DefineConstants.MOONSKY1:
				case DefineConstants.BIGORBIT1:
					return 1;
			}
		}
		return 0;
	}

	public static int floorspace(short sectnum)
	{
		if ((Engine.board.sector[sectnum].floorstat & 1) != 0 && Engine.board.sector[sectnum].ceilingpal == 0)
		{
			switch (Engine.board.sector[sectnum].floorpicnum)
			{
				case DefineConstants.MOONSKY1:
				case DefineConstants.BIGORBIT1:
					return 1;
			}
		}
		return 0;
	}

	public static void addammo(short weapon, player_struct p, short amount)
	{
		p.ammo_amount[weapon] += amount;

		if (p.ammo_amount[weapon] > max_ammo_amount[weapon])
		{
			p.ammo_amount[weapon] = (short)max_ammo_amount[weapon];
		}
	}

	public static void addweapon(player_struct p, short weapon)
	{
		if (p.gotweapon[weapon] == false)
		{
			p.gotweapon[weapon] = true;
			if (weapon == DefineConstants.SHRINKER_WEAPON)
			{
				p.gotweapon[DefineConstants.GROW_WEAPON] = true;
			}
		}

		p.random_club_frame = 0;

		if (p.holster_weapon == 0)
		{
			p.weapon_pos = -1;
			p.last_weapon = p.curr_weapon;
		}
		else
		{
			p.weapon_pos = 10;
			p.holster_weapon = (char)0;
			p.last_weapon = -1;
		}

		p.kickback_pic = 0;
		p.curr_weapon = weapon;

		switch (weapon)
		{
			case DefineConstants.KNEE_WEAPON:
			case DefineConstants.TRIPBOMB_WEAPON:
			case DefineConstants.HANDREMOTE_WEAPON:
			case DefineConstants.HANDBOMB_WEAPON:
				break;
			case DefineConstants.SHOTGUN_WEAPON:
				spritesound(DefineConstants.SHOTGUN_COCK, p.i);
				break;
			case DefineConstants.PISTOL_WEAPON:
				spritesound(DefineConstants.INSERT_CLIP, p.i);
				break;
			default:
				spritesound(DefineConstants.SELECT_WEAPON, p.i);
				break;
		}
	}

	public static void checkavailinven(player_struct p)
	{

		if (p.firstaid_amount > 0)
		{
			p.inven_icon = 1;
		}
		else if (p.steroids_amount > 0)
		{
			p.inven_icon = 2;
		}
		else if (p.holoduke_amount > 0)
		{
			p.inven_icon = 3;
		}
		else if (p.jetpack_amount > 0)
		{
			p.inven_icon = 4;
		}
		else if (p.heat_amount > 0)
		{
			p.inven_icon = 5;
		}
		else if (p.scuba_amount > 0)
		{
			p.inven_icon = 6;
		}
		else if (p.boot_amount > 0)
		{
			p.inven_icon = 7;
		}
		else
		{
			p.inven_icon = 0;
		}
	}

	public static void checkavailweapon(player_struct p)
	{
		short i;
		short snum;
		int weap;

		if (p.wantweaponfire >= 0)
		{
			weap = p.wantweaponfire;
			p.wantweaponfire = -1;

			if (weap == p.curr_weapon)
			{
				return;
			}
			else if (p.gotweapon[weap] && p.ammo_amount[weap] > 0)
			{				
				addweapon(p, (short)weap);
				return;
			}
		}

		weap = p.curr_weapon;
		if (p.gotweapon[weap] && p.ammo_amount[weap] > 0)
		{
			return;
		}

		snum = Engine.board.sprite[p.i].yvel;

		for (i = 0; i < 10; i++)
		{
			weap = ud.wchoice[snum,i];
#if VOLUMEONE
			if (weap > 6)
			{
				continue;
			}
#endif

			if (weap == 0)
			{
				weap = 9;
			}
			else
			{
				weap--;
			}

			if (weap == 0 || (p.gotweapon[weap] && p.ammo_amount[weap] > 0))
			{
				break;
			}
		}

		if (i == 10)
		{
			weap = 0;
		}

		// Found the weapon

		p.last_weapon = p.curr_weapon;
		p.random_club_frame = 0;
		p.curr_weapon = (short)weap;
		p.kickback_pic = 0;
		if (p.holster_weapon == 1)
		{
			p.holster_weapon = 0;
			p.weapon_pos = 10;
		}
		else
		{
			p.weapon_pos = -1;
		}
	}

	/*
   void checkavailweapon( struct player_struct *p )
   {
	   short i,okay,check_shoot,check_bombs;

	   if(p->ammo_amount[p->curr_weapon] > 0) return;
	   okay = check_shoot = check_bombs = 0;

	   switch(p->curr_weapon)
	   {
		   case PISTOL_WEAPON:
		   case CHAINGUN_WEAPON:
		   case SHOTGUN_WEAPON:
   #ifndef VOLUMEONE
		   case FREEZE_WEAPON:
		   case DEVISTATOR_WEAPON:
		   case SHRINKER_WEAPON:
		   case GROW_WEAPON:
   #endif
		   case RPG_WEAPON:
		   case KNEE_WEAPON:
			   check_shoot = 1;
			   break;
		   case HANDBOMB_WEAPON:
		   case HANDREMOTE_WEAPON:
   #ifndef VOLUMEONE
		   case TRIPBOMB_WEAPON:
   #endif
			   check_bombs = 1;
			   break;
	   }

	   CHECK_SHOOT:
	   if(check_shoot)
	   {
		   for(i = p->curr_weapon+1; i < MAX_WEAPONS;i++)
			   switch(i)
			   {
				   case PISTOL_WEAPON:
				   case CHAINGUN_WEAPON:
				   case SHOTGUN_WEAPON:
   #ifndef VOLUMEONE
				   case FREEZE_WEAPON:
				   case SHRINKER_WEAPON:
				   case GROW_WEAPON:
				   case DEVISTATOR_WEAPON:
   #endif
					   if ( p->gotweapon[i] && p->ammo_amount[i] > 0 )
					   {
						   okay = i;
						   goto OKAY_HERE;
					   }
					   break;
			   }

		   for(i = p->curr_weapon-1; i > 0;i--)
			   switch(i)
			   {
				   case PISTOL_WEAPON:
				   case CHAINGUN_WEAPON:
				   case SHOTGUN_WEAPON:
   #ifndef VOLUMEONE
				   case FREEZE_WEAPON:
				   case DEVISTATOR_WEAPON:
				   case SHRINKER_WEAPON:
				   case GROW_WEAPON:
   #endif
					   if ( p->gotweapon[i] && p->ammo_amount[i] > 0 )
					   {
						   okay = i;
						   goto OKAY_HERE;
					   }
					   break;
			   }

		   if( p->gotweapon[RPG_WEAPON] && p->ammo_amount[RPG_WEAPON] > 0 )
		   {
			   okay = RPG_WEAPON;
			   goto OKAY_HERE;
		   }

		   if(check_bombs == 0)
			   check_bombs = 1;
		   else
		   {
			   addweapon(p,KNEE_WEAPON);
			   return;
		   }
	   }

	   if(check_bombs)
	   {
		   for(i = p->curr_weapon-1; i > 0;i--)
			   switch(i)
			   {
				   case HANDBOMB_WEAPON:
   #ifndef VOLUMEONE
				   case TRIPBOMB_WEAPON:
   #endif
					   if ( p->gotweapon[i] && p->ammo_amount[i] > 0 )
					   {
						   okay = i;
						   goto OKAY_HERE;
					   }
					   break;
			   }

		   for(i = p->curr_weapon+1; i < MAX_WEAPONS;i++)
			   switch(i)
			   {
				   case HANDBOMB_WEAPON:
   #ifdef VOLUMEONE
				   case TRIPBOMB_WEAPON:
   #endif
					   if ( p->gotweapon[i] && p->ammo_amount[i] > 0 )
					   {
						   okay = i;
						   goto OKAY_HERE;
					   }
					   break;
			   }

		   if(check_shoot == 0)
		   {
			   check_shoot = 1;
			   goto CHECK_SHOOT;
		   }
		   else
		   {
			   addweapon(p,KNEE_WEAPON);
			   return;
		   }
	   }

	   OKAY_HERE:

	   if(okay)
	   {
		   p->last_weapon  = p->curr_weapon;
		   p->random_club_frame = 0;
		   p->curr_weapon  = okay;
		   p->kickback_pic = 0;
		   if(p->holster_weapon == 1)
		   {
			   p->holster_weapon = 0;
			   p->weapon_pos = 10;
		   }
		   else p->weapon_pos   = -1;
		   return;
	   }
   }
	  */

	public static int ifsquished(short i, short p)
	{
		sectortype sc;
		bool squishme;
		int floorceildist;

		if (Engine.board.sprite[i].picnum == DefineConstants.APLAYER && ud.clipping > 0)
		{
			return 0;
		}

		sc = Engine.board.sector[Engine.board.sprite[i].sectnum];
		floorceildist = sc.floorz - sc.ceilingz;

		if (sc.lotag != 23)
		{
			if (Engine.board.sprite[i].pal == 1)
			{
				squishme = floorceildist < (32 << 8) && (sc.lotag & 32768) == 0;
			}
			else
			{
				squishme = floorceildist < (12 << 8); // && (sc->lotag&32768) == 0;
			}
		}
		else
		{
			squishme = false;
		}

		if (squishme)
		{
			FTA(10, ps[p]);

			if (badguy(Engine.board.sprite[i]) != 0)
			{
				Engine.board.sprite[i].xvel = 0;
			}

			if (Engine.board.sprite[i].pal == 1)
			{
				hittype[i].picnum = DefineConstants.SHOTSPARK1;
				hittype[i].extra = 1;
				return 0;
			}

			return 1;
		}
		return 0;
	}

	public static void hitradius(short i, int r, int hp1, int hp2, int hp3, int hp4)
	{
		spritetype s;
		spritetype sj;
		int d;
		int q;
		int x1;
		int y1;
		int sectcnt;
		int sectend;
		int dasect;
		int startwall;
		int endwall;
		int nextsect;
		short j;
		short k;
		short p;
		short x;
		short nextj;
		short sect =0;
		int[] statlist = new int[] { 0, 1, 6, 10, 12, 2, 5 };
		short[] tempshort = new short[3000];

		s = Engine.board.sprite[i];

		if (s.picnum == DefineConstants.RPG && s.xrepeat < 11)
		{
			goto SKIPWALLCHECK;
		}

		if (s.picnum != DefineConstants.SHRINKSPARK)
		{
			tempshort[0] = s.sectnum;
			dasect = s.sectnum;
			sectcnt = 0;
			sectend = 1;

			do
			{
				dasect = tempshort[sectcnt++];
				if (((Engine.board.sector[dasect].ceilingz - s.z) >> 8) < r)
				{
					d = pragmas.klabs(Engine.board.wall[Engine.board.sector[dasect].wallptr].x - s.x) + pragmas.klabs(Engine.board.wall[Engine.board.sector[dasect].wallptr].y - s.y);
					if (d < r)
					{
						checkhitceiling((short)dasect);
					}
					else
					{
						d = pragmas.klabs(Engine.board.wall[Engine.board.wall[Engine.board.wall[Engine.board.sector[dasect].wallptr].point2].point2].x - s.x) + pragmas.klabs(Engine.board.wall[Engine.board.wall[Engine.board.wall[Engine.board.sector[dasect].wallptr].point2].point2].y - s.y);
						if (d < r)
						{
							checkhitceiling((short)dasect);
						}
					}
				}

				startwall = Engine.board.sector[dasect].wallptr;
				endwall = startwall + Engine.board.sector[dasect].wallnum;
				int q2 = 0;
				for (x = (short)startwall; x < endwall; x++, q2++)
				{
					walltype wal = Engine.board.wall[startwall + q2];

					if ((pragmas.klabs(wal.x - s.x) + pragmas.klabs(wal.y - s.y)) < r)
					{
						nextsect = wal.nextsector;
						if (nextsect >= 0)
						{
							for (dasect = sectend - 1; dasect >= 0; dasect--)
							{
								if (tempshort[dasect] == nextsect)
								{
									break;
								}
							}
							if (dasect < 0)
							{
								tempshort[sectend++] = (short)nextsect;
							}
						}
						x1 = (((wal.x + Engine.board.wall[wal.point2].x) >> 1) + s.x) >> 1;
						y1 = (((wal.y + Engine.board.wall[wal.point2].y) >> 1) + s.y) >> 1;
						Engine.board.updatesector(x1, y1, ref sect);
						if (sect >= 0 && Engine.board.cansee(x1, y1, s.z, sect, s.x, s.y, s.z, s.sectnum))
						{
							checkhitwall(i, x, wal.x, wal.y, s.z, s.picnum);
						}
					}
				}
			} while (sectcnt < sectend);
		}

		SKIPWALLCHECK:

		q = (int)(-(16 << 8) + (Engine.krand() & ((32 << 8) - 1)));

		for (x = 0; x < 7; x++)
		{
			j = (short)Engine.board.headspritestat[statlist[x]];
			while (j >= 0)
			{
				nextj = (short)Engine.board.nextspritestat[j];
				sj = Engine.board.sprite[j];

				if (x == 0 || x >= 5 || (sj.picnum == DefineConstants.BOX || sj.picnum == DefineConstants.TREE1 || sj.picnum == DefineConstants.TREE2 || sj.picnum == DefineConstants.TIRE || sj.picnum == DefineConstants.CONE))
				{
					if (s.picnum != DefineConstants.SHRINKSPARK || (sj.cstat & 257) != 0)
					{
						if (dist(s, sj) < r)
						{
							if (badguy(sj) != 0 && !Engine.board.cansee(sj.x, sj.y, sj.z + q, sj.sectnum, s.x, s.y, s.z + q, s.sectnum))
							{
								goto BOLT;
							}
							checkhitsprite(j, i);
						}
					}
				}
				else if (sj.extra >= 0 && sj != s && (sj.picnum == DefineConstants.TRIPBOMB || badguy(sj) != 0 || sj.picnum == DefineConstants.QUEBALL || sj.picnum == DefineConstants.STRIPEBALL || (sj.cstat & 257) != 0 || sj.picnum == DefineConstants.DUKELYINGDEAD))
				{
					if (s.picnum == DefineConstants.SHRINKSPARK && sj.picnum != DefineConstants.SHARK && (j == s.owner || sj.xrepeat < 24))
					{
						j = nextj;
						continue;
					}
					if (s.picnum == DefineConstants.MORTER && j == s.owner)
					{
						j = nextj;
						continue;
					}

					if (sj.picnum == DefineConstants.APLAYER)
					{
						sj.z -= (38 << 8);
					}
					d = dist(s, sj);
					if (sj.picnum == DefineConstants.APLAYER)
					{
						sj.z += (38 << 8);
					}

					if (d < r && Engine.board.cansee(sj.x, sj.y, sj.z - (8 << 8), sj.sectnum, s.x, s.y, s.z - (12 << 8), s.sectnum))
					{
						hittype[j].ang = (short)Engine.getangle(sj.x - s.x, sj.y - s.y);

						if (s.picnum == DefineConstants.RPG && sj.extra > 0)
						{
							hittype[j].picnum = DefineConstants.RPG;
						}
						else
						{
							if (s.picnum == DefineConstants.SHRINKSPARK)
							{
								hittype[j].picnum = DefineConstants.SHRINKSPARK;
							}
							else
							{
								hittype[j].picnum = DefineConstants.RADIUSEXPLOSION;
							}
						}

						if (s.picnum != DefineConstants.SHRINKSPARK)
						{
							if (d < r / 3)
							{
								if (hp4 == hp3)
								{
									hp4++;
								}
								hittype[j].extra = (short)(hp3 + (Engine.krand() % (hp4 - hp3)));
							}
							else if (d < 2 * r / 3)
							{
								if (hp3 == hp2)
								{
									hp3++;
								}
								hittype[j].extra = (short)(hp2 + (Engine.krand() % (hp3 - hp2)));
							}
							else if (d < r)
							{
								if (hp2 == hp1)
								{
									hp2++;
								}
								hittype[j].extra = (short)(hp1 + (Engine.krand() % (hp2 - hp1)));
							}

							if (Engine.board.sprite[j].picnum != DefineConstants.TANK && Engine.board.sprite[j].picnum != DefineConstants.ROTATEGUN && Engine.board.sprite[j].picnum != DefineConstants.RECON && Engine.board.sprite[j].picnum != DefineConstants.BOSS1 && Engine.board.sprite[j].picnum != DefineConstants.BOSS2 && Engine.board.sprite[j].picnum != DefineConstants.BOSS3 && Engine.board.sprite[j].picnum != DefineConstants.BOSS4)
							{
								if (sj.xvel < 0)
								{
									sj.xvel = 0;
								}
								sj.xvel += (short)(s.extra << 2);
							}

							if (sj.picnum == DefineConstants.PODFEM1 || sj.picnum == DefineConstants.FEM1 || sj.picnum == DefineConstants.FEM2 || sj.picnum == DefineConstants.FEM3 || sj.picnum == DefineConstants.FEM4 || sj.picnum == DefineConstants.FEM5 || sj.picnum == DefineConstants.FEM6 || sj.picnum == DefineConstants.FEM7 || sj.picnum == DefineConstants.FEM8 || sj.picnum == DefineConstants.FEM9 || sj.picnum == DefineConstants.FEM10 || sj.picnum == DefineConstants.STATUE || sj.picnum == DefineConstants.STATUEFLASH || sj.picnum == DefineConstants.SPACEMARINE || sj.picnum == DefineConstants.QUEBALL || sj.picnum == DefineConstants.STRIPEBALL)
							{
								checkhitsprite(j, i);
							}
						}
						else if (s.extra == 0)
						{
							hittype[j].extra = 0;
						}

						if (sj.picnum != DefineConstants.RADIUSEXPLOSION && s.owner >= 0 && Engine.board.sprite[s.owner].statnum < DefineConstants.MAXSTATUS)
						{
							if (sj.picnum == DefineConstants.APLAYER)
							{
								p = sj.yvel;
								if (ps[p].newowner >= 0)
								{
									ps[p].newowner = -1;
									ps[p].posx = ps[p].oposx;
									ps[p].posy = ps[p].oposy;
									ps[p].posz = ps[p].oposz;
									ps[p].ang = ps[p].oang;
									Engine.board.updatesector(ps[p].posx, ps[p].posy, ref ps[p].cursectnum);
									//setpal(ps[p]); // jmarshall: palette.

									k = (short)Engine.board.headspritestat[1];
									while (k >= 0)
									{
										if (Engine.board.sprite[k].picnum == DefineConstants.CAMERA1)
										{
											Engine.board.sprite[k].yvel = 0;
										}
										k = (short)Engine.board.nextspritestat[k];
									}
								}
							}
							hittype[j].owner = s.owner;
						}
					}
				}
				BOLT:
				j = nextj;
			}
		}
	}


	//C++ TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
	public static int movesprite(short spritenum, int xchange, int ychange, int zchange, uint cliptype)
	{
		int daz;
		int h;
		int oldx;
		int oldy;
		short retval;
		short dasectnum;
		short a;
		short cd;
		bool bg;

		bg = badguy(Engine.board.sprite[spritenum]) != 0;

		if (Engine.board.sprite[spritenum].statnum == 5 || (bg && Engine.board.sprite[spritenum].xrepeat < 4))
		{
			Engine.board.sprite[spritenum].x += (xchange * (DefineConstants.TICRATE / 26)) >> 2;
			Engine.board.sprite[spritenum].y += (ychange * (DefineConstants.TICRATE / 26)) >> 2;
			Engine.board.sprite[spritenum].z += (zchange * (DefineConstants.TICRATE / 26)) >> 2;
			if (bg)
			{
				Engine.board.setsprite(spritenum, Engine.board.sprite[spritenum].x, Engine.board.sprite[spritenum].y, Engine.board.sprite[spritenum].z);
			}
			return 0;
		}

		dasectnum = Engine.board.sprite[spritenum].sectnum;

		daz = Engine.board.sprite[spritenum].z;
		h = ((Engine.tilesizy[Engine.board.sprite[spritenum].picnum] * Engine.board.sprite[spritenum].yrepeat) << 1);
		daz -= h;

		if (bg)
		{
			oldx = Engine.board.sprite[spritenum].x;
			oldy = Engine.board.sprite[spritenum].y;

			if (Engine.board.sprite[spritenum].xrepeat > 60)
			{
				retval = (short)Engine.board.clipmove(ref Engine.board.sprite[spritenum].x, ref Engine.board.sprite[spritenum].y, ref daz, ref dasectnum, ((xchange * (DefineConstants.TICRATE / 26)) << 11), ((ychange * (DefineConstants.TICRATE / 26)) << 11), 1024, (4 << 8), (4 << 8), (int)cliptype);
			}
			else
			{
				if (Engine.board.sprite[spritenum].picnum == DefineConstants.LIZMAN)
				{
					cd = 292;
				}
				else if ((actortype[Engine.board.sprite[spritenum].picnum] & 3) != 0)
				{
					cd = (short)(Engine.board.sprite[spritenum].clipdist << 2);
				}
				else
				{
					cd = 192;
				}

				retval = (short)Engine.board.clipmove(ref Engine.board.sprite[spritenum].x, ref Engine.board.sprite[spritenum].y, ref daz, ref dasectnum, ((xchange * (DefineConstants.TICRATE / 26)) << 11), ((ychange * (DefineConstants.TICRATE / 26)) << 11), cd, (4 << 8), (4 << 8), (int)cliptype);
			}

			if (dasectnum < 0 || (dasectnum >= 0 && ((hittype[spritenum].actorstayput >= 0 && hittype[spritenum].actorstayput != dasectnum) || ((Engine.board.sprite[spritenum].picnum == DefineConstants.BOSS2) && Engine.board.sprite[spritenum].pal == 0 && Engine.board.sector[dasectnum].lotag != 3) || ((Engine.board.sprite[spritenum].picnum == DefineConstants.BOSS1 || Engine.board.sprite[spritenum].picnum == DefineConstants.BOSS2) && Engine.board.sector[dasectnum].lotag == 1) || (Engine.board.sector[dasectnum].lotag == 1 && (Engine.board.sprite[spritenum].picnum == DefineConstants.LIZMAN || (Engine.board.sprite[spritenum].picnum == DefineConstants.LIZTROOP && Engine.board.sprite[spritenum].zvel == 0))))))
			{
// jmarshall - crash fix
// NOW HERE:
                if (dasectnum < 0)
                {
                	dasectnum = 0;
                }
// jmarshall end
                Engine.board.sprite[spritenum].x = oldx;
				Engine.board.sprite[spritenum].y = oldy;
				if (Engine.board.sector[dasectnum].lotag == 1 && Engine.board.sprite[spritenum].picnum == DefineConstants.LIZMAN)
				{
					Engine.board.sprite[spritenum].ang = (short)(Engine.krand() & 2047);
				}
				else if ((hittype[spritenum].count & 3) == 1 && Engine.board.sprite[spritenum].picnum != DefineConstants.COMMANDER)
				{
					Engine.board.sprite[spritenum].ang = (short)(Engine.krand() & 2047);
				}
				Engine.board.setsprite(spritenum, oldx, oldy, Engine.board.sprite[spritenum].z);
// jmarshall - crash fix
// WAS HERE:
				//if (dasectnum < 0)
				//{
				//	dasectnum = 0;
				//}
// jmarshall end
				return (16384 + dasectnum);
			}
			if ((retval & 49152) >= 32768 && (hittype[spritenum].cgg == 0))
			{
				Engine.board.sprite[spritenum].ang += 768;
			}
		}
		else
		{
			if (Engine.board.sprite[spritenum].statnum == 4)
			{
				retval = (short)Engine.board.clipmove(ref Engine.board.sprite[spritenum].x, ref Engine.board.sprite[spritenum].y, ref daz, ref dasectnum, ((xchange * (DefineConstants.TICRATE / 26)) << 11), ((ychange * (DefineConstants.TICRATE / 26)) << 11), 8, (4 << 8), (4 << 8), (int)cliptype);
			}
			else
			{
				retval = (short)Engine.board.clipmove(ref Engine.board.sprite[spritenum].x, ref Engine.board.sprite[spritenum].y, ref daz, ref dasectnum, ((xchange * (DefineConstants.TICRATE / 26)) << 11), ((ychange * (DefineConstants.TICRATE / 26)) << 11), (int)(Engine.board.sprite[spritenum].clipdist << 2), (4 << 8), (4 << 8), (int)cliptype);
			}
		}

		if (dasectnum >= 0)
		{
			if ((dasectnum != Engine.board.sprite[spritenum].sectnum))
			{
				Engine.board.changespritesect(spritenum, dasectnum);
			}
		}
		daz = Engine.board.sprite[spritenum].z + ((zchange * (DefineConstants.TICRATE / 26)) >> 3);
		if ((daz > hittype[spritenum].ceilingz) && (daz <= hittype[spritenum].floorz))
		{
			Engine.board.sprite[spritenum].z = daz;
		}
		else
		{
			if (retval == 0)
			{
				return (16384 + dasectnum);
			}
		}

		return (retval);
	}


	public static short ssp(short i, uint cliptype) //The set sprite function
	{
		spritetype s;
		int movetype;

		s = Engine.board.sprite[i];

		movetype = movesprite(i, (s.xvel * (Engine.table.sintable[(s.ang + 512) & 2047])) >> 14, (s.xvel * (Engine.table.sintable[s.ang & 2047])) >> 14, s.zvel, cliptype);

		//return (movetype == 0);
		if (movetype == 0)
			return 0;

		return 1;
	}

	public static void insertspriteq(short i)
	{
		if (spriteqamount > 0)
		{
			if (spriteq[spriteqloc] >= 0)
			{
				Engine.board.sprite[spriteq[spriteqloc]].xrepeat = 0;
			}
			spriteq[spriteqloc] = i;
			spriteqloc = (short)((spriteqloc + 1) % spriteqamount);
		}
		else
		{
			Engine.board.sprite[i].xrepeat = Engine.board.sprite[i].yrepeat = 0;
		}
	}

	public static void lotsofmoney(spritetype s, int n)
	{
		int i;
		int j;
		for (i = n; i > 0; i--)
		{
			j = EGS(s.sectnum, s.x, s.y, (int)(s.z - (Engine.krand() % (47 << 8))), DefineConstants.MONEY, -32, 8, 8, (short)(Engine.krand() & 2047), 0, 0, 0, 5);
			Engine.board.sprite[j].cstat = (short)(Engine.krand() & 12);
		}
	}

	public static void lotsofmail(spritetype s, int n)
	{
		int i;
		int j;
		for (i = n; i > 0; i--)
		{
			j = EGS(s.sectnum, s.x, s.y, (int)(s.z - (Engine.krand() % (47 << 8))), DefineConstants.MAIL, -32, 8, 8, (short)(Engine.krand() & 2047), 0, 0, 0, 5);
			Engine.board.sprite[j].cstat = (short)(Engine.krand() & 12);
		}
	}

	public static void lotsofpaper(spritetype s, short n)
	{
		short i;
		short j;
		for (i = n; i > 0; i--)
		{
			j = EGS(s.sectnum, s.x, s.y, (int)(s.z - (Engine.krand() % (47 << 8))), DefineConstants.PAPER, -32, 8, 8, (short)(Engine.krand() & 2047), 0, 0, 0, 5);
			Engine.board.sprite[j].cstat = (short)(Engine.krand() & 12);
		}
	}



	public static void guts(spritetype s, short gtype, short n, short p)
	{
		int gutz;
		int floorz;
		short i;
		short a;
		short j;
		int sx;
		int sy;
		sbyte pal;

		if (badguy(s) != 0 && s.xrepeat < 16)
		{
			sx = sy = 8;
		}
		else
		{
			sx = sy = 32;
		}

		gutz = s.z - (8 << 8);
		floorz = Engine.board.getflorzofslope(s.sectnum, s.x, s.y);

		if (gutz > (floorz - (8 << 8)))
		{
			gutz = floorz - (8 << 8);
		}

		if (s.picnum == DefineConstants.COMMANDER)
		{
			gutz -= (24 << 8);
		}

		if (badguy(s) != 0 && s.pal == 6)
		{
			pal = 6;
		}
		else
		{
			pal = 0;
		}

		for (j = 0; j < n; j++)
		{
			a = (short)(Engine.krand() & 2047);
			i = EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, gutz - (Engine.krand() & 8191), gtype, -32, sx, sy, a, (short)(48 + (Engine.krand() & 31)), -512 - (Engine.krand() & 2047), ps[p].i, 5);
			if (Engine.board.sprite[i].picnum == DefineConstants.JIBS2)
			{
				Engine.board.sprite[i].xrepeat >>= 2;
				Engine.board.sprite[i].yrepeat >>= 2;
			}
			if (pal == 6)
			{
				Engine.board.sprite[i].pal = 6;
			}
		}
	}

	public static void gutsdir(spritetype s, short gtype, short n, short p)
	{
		int gutz;
		int floorz;
		short i;
		short a;
		short j;
		int sx;
		int sy;

		if (badguy(s) != 0 && s.xrepeat < 16)
		{
			sx = sy = 8;
		}
		else
		{
			sx = sy = 32;
		}

		gutz = s.z - (8 << 8);
		floorz = Engine.board.getflorzofslope(s.sectnum, s.x, s.y);

		if (gutz > (floorz - (8 << 8)))
		{
			gutz = floorz - (8 << 8);
		}

		if (s.picnum == DefineConstants.COMMANDER)
		{
			gutz -= (24 << 8);
		}

		for (j = 0; j < n; j++)
		{
			a = (short)(Engine.krand() & 2047);
			i = EGS(s.sectnum, s.x, s.y, gutz, gtype, -32, sx, sy, a, (short)(256 + (Engine.krand() & 127)), -512 - (Engine.krand() & 2047), ps[p].i, 5);
		}
	}

	public static void setsectinterpolate(short i)
	{
		int j;
		int k;
		int startwall;
		int endwall;

		startwall = Engine.board.sector[Engine.board.sprite[i].sectnum].wallptr;
		endwall = startwall + Engine.board.sector[Engine.board.sprite[i].sectnum].wallnum;

		for (j = startwall; j < endwall; j++)
		{
			setinterpolation(new SectorAnimation(Engine.board.wall[j], SectorAnimation.WallAnimType.WALL_ANIM_X));
			setinterpolation(new SectorAnimation(Engine.board.wall[j], SectorAnimation.WallAnimType.WALL_ANIM_Y));
			k = Engine.board.wall[j].nextwall;
			if (k >= 0)
			{
				setinterpolation(new SectorAnimation(Engine.board.wall[k], SectorAnimation.WallAnimType.WALL_ANIM_X));
				setinterpolation(new SectorAnimation(Engine.board.wall[k], SectorAnimation.WallAnimType.WALL_ANIM_Y));
				k = Engine.board.wall[k].point2;
				setinterpolation(new SectorAnimation(Engine.board.wall[k], SectorAnimation.WallAnimType.WALL_ANIM_X));
				setinterpolation(new SectorAnimation(Engine.board.wall[k], SectorAnimation.WallAnimType.WALL_ANIM_Y));
			}
		}
	}

	public static void clearsectinterpolate(short i)
	{
		int j;
		int startwall;
		int endwall;

		startwall = Engine.board.sector[Engine.board.sprite[i].sectnum].wallptr;
		endwall = startwall + Engine.board.sector[Engine.board.sprite[i].sectnum].wallnum;
		for (j = startwall; j < endwall; j++)
		{
			stopinterpolation(new SectorAnimation(Engine.board.wall[j], SectorAnimation.WallAnimType.WALL_ANIM_X));
			stopinterpolation(new SectorAnimation(Engine.board.wall[j], SectorAnimation.WallAnimType.WALL_ANIM_Y));
			if (Engine.board.wall[j].nextwall >= 0)
			{
				stopinterpolation(new SectorAnimation(Engine.board.wall[Engine.board.wall[j].nextwall], SectorAnimation.WallAnimType.WALL_ANIM_X));
				stopinterpolation(new SectorAnimation(Engine.board.wall[Engine.board.wall[j].nextwall], SectorAnimation.WallAnimType.WALL_ANIM_Y));
			}
		}
	}

	public static void ms(short i)
	{
		//T1,T2 and T3 are used for all the sector moving stuff!!!

		int startwall;
		int endwall;
		int x = 0;
		int tx = 0;
		int ty = 0;
		int j;
		int k;
		spritetype s;

		s = Engine.board.sprite[i];

		s.x += (s.xvel * (Engine.table.sintable[(s.ang + 512) & 2047])) >> 14;
		s.y += (s.xvel * (Engine.table.sintable[s.ang & 2047])) >> 14;

		j = hittype[i].temp_data[1];
		k = hittype[i].temp_data[2];

		startwall = Engine.board.sector[s.sectnum].wallptr;
		endwall = startwall + Engine.board.sector[s.sectnum].wallnum;
		for (x = startwall; x < endwall; x++)
		{
			Engine.rotatepoint(0, 0, msx[j], msy[j], (short)(k & 2047), ref tx, ref ty);

			Engine.board.dragpoint((short)x, s.x + tx, s.y + ty);

			j++;
		}
	}

	public static void movefta()
	{
		int x = 0;
		int px = 0;
		int py = 0;
		int sx = 0;
		int sy = 0;
		int i = 0;
		bool j = false;
		int p = 0;
		short psect = 0;
		short ssect = 0;
		short nexti = 0;
		spritetype s;

		i = Engine.board.headspritestat[2];
		while (i >= 0)
		{
			nexti = (short)Engine.board.nextspritestat[i];

			s = Engine.board.sprite[i];
			p = findplayer(s, ref x);

			ssect = psect = s.sectnum;

			if (Engine.board.sprite[ps[p].i].extra > 0)
			{
				if (x < 30000)
				{
					hittype[i].timetosleep++;
					if (hittype[i].timetosleep >= (x >> 8))
					{
						if (badguy(s) != 0)
						{
							px = (int)(ps[p].oposx + 64 - (Engine.krand() & 127));
							py = (int)(ps[p].oposy + 64 - (Engine.krand() & 127));
							Engine.board.updatesector(px, py, ref psect);
							if (psect == -1)
							{
								i = nexti;
								continue;
							}
							sx = (int)(s.x + 64 - (Engine.krand() & 127));
							sy = (int)(s.y + 64 - (Engine.krand() & 127));
							Engine.board.updatesector(px, py, ref ssect);
							if (ssect == -1)
							{
								i = nexti;
								continue;
							}
							j = Engine.board.cansee(sx, sy, (int)(s.z - (Engine.krand() % (52 << 8))), s.sectnum, px, py, (int)(ps[p].oposz - (Engine.krand() % (32 << 8))), ps[p].cursectnum);
						}
						else
						{
							j = Engine.board.cansee(s.x, s.y, (int)(s.z - ((Engine.krand() & 31) << 8)), s.sectnum, ps[p].oposx, ps[p].oposy, (int)(ps[p].oposz - ((Engine.krand() & 31) << 8)), ps[p].cursectnum);
						}

						//             j = 1;

						if (j)
						{
							switch (s.picnum)
							{
								case DefineConstants.RUBBERCAN:
								case DefineConstants.EXPLODINGBARREL:
								case DefineConstants.WOODENHORSE:
								case DefineConstants.HORSEONSIDE:
								case DefineConstants.CANWITHSOMETHING:
								case DefineConstants.CANWITHSOMETHING2:
								case DefineConstants.CANWITHSOMETHING3:
								case DefineConstants.CANWITHSOMETHING4:
								case DefineConstants.FIREBARREL:
								case DefineConstants.FIREVASE:
								case DefineConstants.NUKEBARREL:
								case DefineConstants.NUKEBARRELDENTED:
								case DefineConstants.NUKEBARRELLEAKED:
								case DefineConstants.TRIPBOMB:
									if ((Engine.board.sector[s.sectnum].ceilingstat & 1) != 0)
									{
										s.shade = Engine.board.sector[s.sectnum].ceilingshade;
									}
									else
									{
										s.shade = Engine.board.sector[s.sectnum].floorshade;
									}

									hittype[i].timetosleep = 0;
									Engine.board.changespritestat((short)i, 6);
									break;
								default:
									hittype[i].timetosleep = 0;
									check_fta_sounds(i);
									Engine.board.changespritestat((short)i, 1);
									break;
							}
						}
						else
						{
							hittype[i].timetosleep = 0;
						}
					}
				}
				if (badguy(s) != 0)
				{
					if ((Engine.board.sector[s.sectnum].ceilingstat & 1) != 0)
					{
						s.shade = Engine.board.sector[s.sectnum].ceilingshade;
					}
					else
					{
						s.shade = Engine.board.sector[s.sectnum].floorshade;
					}
				}
			}
			i = nexti;
		}
	}

	public static short ifhitsectors(short sectnum)
	{
		int i;

		i = Engine.board.headspritestat[5];
		while (i >= 0)
		{
			if (Engine.board.sprite[i].picnum == DefineConstants.EXPLOSION2 && sectnum == Engine.board.sprite[i].sectnum)
			{
				return (short)i;
			}
			i = Engine.board.nextspritestat[i];
		}
		return -1;
	}

	public static short ifhitbyweapon(short sn)
	{
		short j;
		short k;
		short p;
		spritetype npc;

		if (hittype[sn].extra >= 0)
		{
			if (Engine.board.sprite[sn].extra >= 0)
			{
				npc = Engine.board.sprite[sn];

				if (npc.picnum == DefineConstants.APLAYER)
				{
					if (ud.god != 0 && hittype[sn].picnum != DefineConstants.SHRINKSPARK)
					{
						return -1;
					}

					p = npc.yvel;
					j = hittype[sn].owner;

					if (j >= 0 && Engine.board.sprite[j].picnum == DefineConstants.APLAYER && ud.coop == 1 && ud.ffire == 0)
					{
						return -1;
					}

					npc.extra -= hittype[sn].extra;

					if (j >= 0)
					{
						if (npc.extra <= 0 && hittype[sn].picnum != DefineConstants.FREEZEBLAST)
						{
							npc.extra = 0;

							ps[p].wackedbyactor = j;

							if (Engine.board.sprite[hittype[sn].owner].picnum == DefineConstants.APLAYER && p != Engine.board.sprite[hittype[sn].owner].yvel)
							{
								ps[p].frag_ps = Engine.board.sprite[j].yvel;
							}

							hittype[sn].owner = ps[p].i;
						}
					}

					switch (hittype[sn].picnum)
					{
						case DefineConstants.RADIUSEXPLOSION:
						case DefineConstants.RPG:
						case DefineConstants.HYDRENT:
						case DefineConstants.HEAVYHBOMB:
						case DefineConstants.SEENINE:
						case DefineConstants.OOZFILTER:
						case DefineConstants.EXPLODINGBARREL:
							ps[p].posxv += hittype[sn].extra * (Engine.table.sintable[(hittype[sn].ang + 512) & 2047]) << 2;
							ps[p].posyv += hittype[sn].extra * (Engine.table.sintable[hittype[sn].ang & 2047]) << 2;
							break;
						default:
							ps[p].posxv += hittype[sn].extra * (Engine.table.sintable[(hittype[sn].ang + 512) & 2047]) << 1;
                            ps[p].posyv += hittype[sn].extra * (Engine.table.sintable[hittype[sn].ang & 2047]) << 1;
							break;
					}
				}
				else
				{
					if (hittype[sn].extra == 0)
					{
						if (hittype[sn].picnum == DefineConstants.SHRINKSPARK && npc.xrepeat < 24)
						{
							return -1;
						}
					}

					npc.extra -= hittype[sn].extra;
					if (npc.picnum != DefineConstants.RECON && npc.owner >= 0 && Engine.board.sprite[npc.owner].statnum < DefineConstants.MAXSTATUS)
					{
						npc.owner = hittype[sn].owner;
					}
				}

				hittype[sn].extra = -1;
				return hittype[sn].picnum;
			}
		}

		hittype[sn].extra = -1;
		return -1;
	}

	public static void movecyclers()
	{
		int q;
		short j;
		short x;
		short t;
		short s;
		short[] c = new short[6]; ;		
		short cshade;

		for (q = numcyclers - 1; q >= 0; q--)
		{
            for (int d = 0; d < 6; d++)
            {
                c[d] = cyclers[q, d];
            }
			s = c[0];

			t = c[3];
			j = (short)(t + (Engine.table.sintable[c[1] & 2047] >> 10));
			cshade = c[2];

			if (j < cshade)
			{
				j = cshade;
			}
			else if (j > t)
			{
				j = t;
			}

			c[1] += Engine.board.sector[s].extra;
			if (c[5] != 0)
			{
				int yy = 0;
				for (x = Engine.board.sector[s].wallnum; x > 0; x--, yy++)
				{
					walltype wal = Engine.board.wall[Engine.board.sector[s].wallptr + yy];
					if (wal.hitag != 1)
					{
						wal.shade = (sbyte)j;

						if ((wal.cstat & 2) != 0 && wal.nextwall >= 0)
						{
							Engine.board.wall[wal.nextwall].shade = (sbyte)j;
						}

					}
				}
				Engine.board.sector[s].floorshade = Engine.board.sector[s].ceilingshade = (sbyte)j;
			}
		}
	}

	public static void movedummyplayers()
	{
		int i;
		int p;
		int nexti;

		i = Engine.board.headspritestat[13];
		while (i >= 0)
		{
			nexti = Engine.board.nextspritestat[i];

			p = Engine.board.sprite[Engine.board.sprite[i].owner].yvel;

			if (ps[p].on_crane >= 0 || Engine.board.sector[ps[p].cursectnum].lotag != 1 || Engine.board.sprite[ps[p].i].extra <= 0)
			{
				ps[p].dummyplayersprite = -1;
				{
					Engine.board.deletesprite(i);
					goto BOLT;
				};
			}
			else
			{
				if (ps[p].on_ground > 0 && ps[p].on_warping_sector == 1 && Engine.board.sector[ps[p].cursectnum].lotag == 1)
				{
					Engine.board.sprite[i].cstat = 257;
					Engine.board.sprite[i].z = Engine.board.sector[Engine.board.sprite[i].sectnum].ceilingz + (27 << 8);
					Engine.board.sprite[i].ang = ps[p].ang;
					if (hittype[i].count == 8)
					{
						hittype[i].count = 0;
					}
					else
					{
						hittype[i].count++;
					}
				}
				else
				{
					if (Engine.board.sector[Engine.board.sprite[i].sectnum].lotag != 2)
					{
						Engine.board.sprite[i].z = Engine.board.sector[Engine.board.sprite[i].sectnum].floorz;
					}
					Engine.board.sprite[i].cstat = unchecked((short)32768);
				}
			}

			Engine.board.sprite[i].x += (ps[p].posx - ps[p].oposx);
			Engine.board.sprite[i].y += (ps[p].posy - ps[p].oposy);
			Engine.board.setsprite((short)i, Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].z);

			BOLT:

			i = (short)nexti;
		}
	}

	public static void quickkill(player_struct p)
	{
	    p.pals[0] = 48;
	    p.pals[1] = 48;
	    p.pals[2] = 48;
	    p.pals_time = 48;
	
	    Engine.board.sprite[p.i].extra = 0;
	    Engine.board.sprite[p.i].cstat |= unchecked((short)32768);
	    if(ud.god == 0) guts(Engine.board.sprite[p.i],DefineConstants.JIBS6,8,myconnectindex);
	    return;
	}

	public static short otherp;
	public static void moveplayers() //Players
	{
		int i;
		int nexti;
		int otherx = 0;
		spritetype s;
		player_struct p;

		i = Engine.board.headspritestat[10];
		while (i >= 0)
		{
			nexti = Engine.board.nextspritestat[i];

			s = Engine.board.sprite[i];
			p = ps[s.yvel];
			if (s.owner >= 0)
			{
				if (p.newowner >= 0) //Looking thru the camera
				{
					s.x = p.oposx;
					s.y = p.oposy;
					hittype[i].bposz = s.z = p.oposz + (38 << 8);
					s.ang = p.oang;
					Engine.board.setsprite((short)i, s.x, s.y, s.z);
				}
				else
				{
					if (ud.multimode > 1)
					{
						otherp = findotherplayer(s.yvel, ref otherx);
					}
					else
					{
						otherp = s.yvel;
						otherx = 0;
					}

					execute(i, s.yvel, otherx);

					if (ud.multimode > 1)
					{
						if (Engine.board.sprite[ps[otherp].i].extra > 0)
						{
							if (s.yrepeat > 32 && Engine.board.sprite[ps[otherp].i].yrepeat < 32)
							{
								if (otherx < 1400 && p.knee_incs == 0)
								{
									p.knee_incs = 1;
									p.weapon_pos = -1;
									p.actorsqu = ps[otherp].i;
								}
							}
						}
					}
					if (ud.god != 0)
					{
						s.extra = (short)max_player_health;
						s.cstat = 257;
						p.jetpack_amount = 1599;
					}


					if (s.extra > 0)
					{
						hittype[i].owner = (short)i;

						if (ud.god == 0)
						{
							if (ceilingspace(s.sectnum) != 0 || floorspace(s.sectnum) != 0)
							{
								quickkill(p);
							}
						}
					}
					else
					{

						p.posx = s.x;
						p.posy = s.y;
						p.posz = s.z - (20 << 8);

						p.newowner = -1;

						if (p.wackedbyactor >= 0 && Engine.board.sprite[p.wackedbyactor].statnum < DefineConstants.MAXSTATUS)
						{
							p.ang += (short)(getincangle(p.ang, (short)Engine.getangle(Engine.board.sprite[p.wackedbyactor].x - p.posx, Engine.board.sprite[p.wackedbyactor].y - p.posy)) >> 1);
							p.ang &= 2047;
						}

					}
					s.ang = p.ang;
				}
			}
			else
			{
				if (p.holoduke_on == -1)
				{
					Engine.board.deletesprite((short)i);
					goto BOLT;
				};

				hittype[i].bposx = s.x;
				hittype[i].bposy = s.y;
				hittype[i].bposz = s.z;

				s.cstat = 0;

				if (s.xrepeat < 42)
				{
					s.xrepeat += 4;
					s.cstat |= 2;
				}
				else
				{
					s.xrepeat = 42;
				}
				if (s.yrepeat < 36)
				{
					s.yrepeat += 4;
				}
				else
				{
					s.yrepeat = 36;
					if (Engine.board.sector[s.sectnum].lotag != 2)
					{
						makeitfall((short)i);
					}
					if (s.zvel == 0 && Engine.board.sector[s.sectnum].lotag == 1)
					{
						s.z += (32 << 8);
					}
				}

				if (s.extra < 8)
				{
					s.xvel = 128;
					s.ang = p.ang;
					s.extra++;
					if (ssp((short)i, (uint)(((1) << 16) + 1)) != 0)
					{
						;
					}
				}
				else
				{
					s.ang = (short)(2047 - p.ang);
					Engine.board.setsprite((short)i, s.x, s.y, s.z);
				}
			}

			if ((Engine.board.sector[s.sectnum].ceilingstat & 1) != 0)
			{
				s.shade += (sbyte)((Engine.board.sector[s.sectnum].ceilingshade - s.shade) >> 1);
			}
			else
			{
				s.shade += (sbyte)((Engine.board.sector[s.sectnum].floorshade - s.shade) >> 1);
			}

			BOLT:
			i = nexti;
		}
	}


	public static void movefx()
	{
		int i;
		int j;
		int nexti;
		int p;
		int x;
		int ht;
		spritetype s;

		i = Engine.board.headspritestat[11];
		while (i >= 0)
		{
			s = Engine.board.sprite[i];

			nexti = Engine.board.nextspritestat[i];

			switch (s.picnum)
			{
				case DefineConstants.RESPAWN:
					if (Engine.board.sprite[i].extra == 66)
					{
						j = spawn((short)i, Engine.board.sprite[i].hitag);
						//                    Engine.board.sprite[j].pal = Engine.board.sprite[i].pal;
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
					else if (Engine.board.sprite[i].extra > (66 - 13))
					{
						Engine.board.sprite[i].extra++;
					}
					break;

				case DefineConstants.MUSICANDSFX:

					ht = s.hitag;

					if (hittype[i].temp_data[1] != SoundToggle)
					{
						hittype[i].temp_data[1] = SoundToggle;
						hittype[i].count = 0;
					}

					if (s.lotag >= 1000 && s.lotag < 2000)
					{
						x = ldist(Engine.board.sprite[ps[screenpeek].i], s);
						if (x < ht && hittype[i].count == 0)
						{
							FX_SetReverb(s.lotag - 1000);
							hittype[i].count = 1;
						}
						if (x >= ht && hittype[i].count == 1)
						{
							FX_SetReverb(0);
							FX_SetReverbDelay(0);
							hittype[i].count = 0;
						}
					}
					else if (s.lotag < 999 && (uint)Engine.board.sector[s.sectnum].lotag < 9 && AmbienceToggle != 0 && Engine.board.sector[Engine.board.sprite[i].sectnum].floorz != Engine.board.sector[Engine.board.sprite[i].sectnum].ceilingz)
					{
						if ((soundm[s.lotag] & 2) != 0)
						{
							x = dist(Engine.board.sprite[ps[screenpeek].i], s);
							if (x < ht && hittype[i].count == 0 && FX_VoiceAvailable(soundpr[s.lotag] - 1) != 0)
							{
								if (numenvsnds == NumVoices)
								{
									j = Engine.board.headspritestat[11];
									while (j >= 0)
									{
										if (Engine.board.sprite[i].picnum == DefineConstants.MUSICANDSFX && j != i && Engine.board.sprite[j].lotag < 999 && hittype[j].count == 1 && dist(Engine.board.sprite[j], Engine.board.sprite[ps[screenpeek].i]) > x)
										{
											stopenvsound(Engine.board.sprite[j].lotag, j);
											break;
										}
										j = Engine.board.nextspritestat[j];
									}
									if (j == -1)
									{
										goto BOLT;
									}
								}
								spritesound((ushort)s.lotag, i);
								hittype[i].count = 1;
							}
							if (x >= ht && hittype[i].count == 1)
							{
								hittype[i].count = 0;
								stopenvsound(s.lotag, i);
							}
						}
						if ((soundm[s.lotag] & 16) != 0)
						{
							if (hittype[i].temp_data[4] > 0)
							{
								hittype[i].temp_data[4]--;
							}
							else
							{
								for (p = connecthead; p >= 0; p = connectpoint2[p])
								{
									if (p == myconnectindex && ps[p].cursectnum == s.sectnum)
									{
										j = (short)(s.lotag + ((uint)global_random % (s.hitag + 1)));
										sound(j);
										hittype[i].temp_data[4] = 26 * 40 + (global_random % (26 * 40));
									}
								}
							}
						}
					}
					break;
			}
			BOLT:
			i = nexti;
		}
	}



	public static void movefallers()
	{
		int i;
		int nexti;
		int sect;
		int j;
		spritetype s;
		int x;

		i = Engine.board.headspritestat[12];
		while (i >= 0)
		{
			nexti = Engine.board.nextspritestat[i];
			s = Engine.board.sprite[i];

			sect = s.sectnum;

			if (hittype[i].count == 0)
			{
				s.z -= (16 << 8);
				hittype[i].temp_data[1] = s.ang;
				x = s.extra;
				j = ifhitbyweapon((short)i);
				if (j >= 0)
				{
					if (j == DefineConstants.FIREEXT || j == DefineConstants.RPG || j == DefineConstants.RADIUSEXPLOSION || j == DefineConstants.SEENINE || j == DefineConstants.OOZFILTER)
					{
						if (s.extra <= 0)
						{
							hittype[i].count = 1;
							j = Engine.board.headspritestat[12];
							while (j >= 0)
							{
								if (Engine.board.sprite[j].hitag == Engine.board.sprite[i].hitag)
								{
									hittype[j].count = 1;
									Engine.board.sprite[j].cstat &= unchecked((short)(65535 - 64));
									if (Engine.board.sprite[j].picnum == DefineConstants.CEILINGSTEAM || Engine.board.sprite[j].picnum == DefineConstants.STEAM)
									{
										Engine.board.sprite[j].cstat |= unchecked((short)32768);
									}
								}
								j = Engine.board.nextspritestat[j];
							}
						}
					}
					else
					{
						hittype[i].extra = 0;
						s.extra = (short)x;
					}
				}
				s.ang = (short)hittype[i].temp_data[1];
				s.z += (16 << 8);
			}
			else if (hittype[i].count == 1)
			{
				if (s.lotag > 0)
				{
					s.lotag -= 3;
					if (s.lotag <= 0)
					{
						s.xvel = (short)(32 + Engine.krand() & 63);
						s.zvel = (short)(-(1024 + (Engine.krand() & 1023)));
					}
				}
				else
				{
					if (s.xvel > 0)
					{
						s.xvel -= 8;
						ssp((short)i, (uint)(((1) << 16) + 1));
					}

					if (floorspace(s.sectnum) != 0)
					{
						x = 0;
					}
					else
					{
						if (ceilingspace(s.sectnum) != 0)
						{
							x = gc / 6;
						}
						else
						{
							x = gc;
						}
					}

					if (s.z < (Engine.board.sector[sect].floorz - (1 << 8)))
					{
						s.zvel += (short)x;
						if (s.zvel > 6144)
						{
							s.zvel = 6144;
						}
						s.z += s.zvel;
					}
					if ((Engine.board.sector[sect].floorz - s.z) < (16 << 8))
					{
						j = (short)(1 + (Engine.krand() & 7));
						for (x = 0; x < j; x++)
						{
							EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
						}
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
				}
			}

			BOLT:
			i = nexti;
		}
	}

	public static void movestandables()
	{
		int i = 0;
		int j = 0;
		int k = 0;
		int m = 0;
		int nexti = 0;
		int nextj = 0;
		int nextk = 0;
		int p = 0;
		int q = 0;
		int sect= 0;
		int l = 0;
		int x = 0;
		int x1 = 0;
		int y1 = 0;
		spritetype s;

		i = Engine.board.headspritestat[6];
		while (i >= 0)
		{
			nexti = Engine.board.nextspritestat[i];

			s = Engine.board.sprite[i];
			sect = s.sectnum;

			if (sect < 0)
			{
				Engine.board.deletesprite(i);
				goto BOLT;
			};

			hittype[i].bposx = s.x;
			hittype[i].bposy = s.y;
			hittype[i].bposz = s.z;

			// 
			if ((Engine.board.sprite[i].picnum) >= (DefineConstants.CRANE) && (Engine.board.sprite[i].picnum) <= (DefineConstants.CRANE + 3))
			{
				//t[0] = state
				//t[1] = checking sector number

				if (s.xvel != 0)
				{
					getglobalz((short)i);
				}

				if (hittype[i].count == 0) //Waiting to check the sector
				{
					j = Engine.board.headspritesect[hittype[i].temp_data[1]];
					while (j >= 0)
					{
						nextj = Engine.board.nextspritesect[j];
						switch (Engine.board.sprite[j].statnum)
						{
							case 1:
							case 2:
							case 6:
							case 10:
								s.ang = (short)Engine.getangle(msx[hittype[i].temp_data[4] + 1] - s.x, msy[hittype[i].temp_data[4] + 1] - s.y);
								Engine.board.setsprite((short)j, msx[hittype[i].temp_data[4] + 1], msy[hittype[i].temp_data[4] + 1], Engine.board.sprite[j].z);
								hittype[i].count++;
								goto BOLT;
						}
						j = nextj;
					}
				}

				else if (hittype[i].count == 1)
				{
					if (s.xvel < 184)
					{
						s.picnum = DefineConstants.CRANE + 1;
						s.xvel += 8;
					}
					if (ssp((short)i, (uint)(((1) << 16) + 1)) != 0)
					{
						;
					}
					if (sect == hittype[i].temp_data[1])
					{
						hittype[i].count++;
					}
				}
				else if (hittype[i].count == 2 || hittype[i].count == 7)
				{
					s.z += (1024 + 512);

					if (hittype[i].count == 2)
					{
						if ((Engine.board.sector[sect].floorz - s.z) < (64 << 8))
						{
							if (s.picnum > DefineConstants.CRANE)
							{
								s.picnum--;
							}
						}

						if ((Engine.board.sector[sect].floorz - s.z) < (4096 + 1024))
						{
							hittype[i].count++;
						}
					}
					if (hittype[i].count == 7)
					{
						if ((Engine.board.sector[sect].floorz - s.z) < (64 << 8))
						{
							if (s.picnum > DefineConstants.CRANE)
							{
								s.picnum--;
							}
							else
							{
								if (s.owner == -2)
								{
									spritesound(DefineConstants.DUKE_GRUNT, ps[p].i);
									p = findplayer(s, ref x);
									if (ps[p].on_crane == i)
									{
										ps[p].on_crane = -1;
									}
								}
								hittype[i].count++;
								s.owner = -1;
							}
						}
					}
				}
				else if (hittype[i].count == 3)
				{
					s.picnum++;
					if (s.picnum == (DefineConstants.CRANE + 2))
					{
						p = checkcursectnums((short)hittype[i].temp_data[1]);
						if (p >= 0 && ps[p].on_ground != 0)
						{
							s.owner = -2;
							ps[p].on_crane = (short)i;
							spritesound(DefineConstants.DUKE_GRUNT, ps[p].i);
							ps[p].ang = (short)( s.ang + 1024);
						}
						else
						{
							j = Engine.board.headspritesect[hittype[i].temp_data[1]];
							while (j >= 0)
							{
								switch (Engine.board.sprite[j].statnum)
								{
									case 1:
									case 6:
										s.owner = (short)j;
										break;
								}
								j = Engine.board.nextspritesect[j];
							}
						}

						hittype[i].count++; //Grabbed the sprite
						hittype[i].actioncount = 0;
						goto BOLT;
					}
				}
				else if (hittype[i].count == 4) //Delay before going up
				{
					hittype[i].actioncount++;
					if (hittype[i].actioncount > 10)
					{
						hittype[i].count++;
					}
				}
				else if (hittype[i].count == 5 || hittype[i].count == 8)
				{
					if (hittype[i].count == 8 && s.picnum < (DefineConstants.CRANE + 2))
					{
						if ((Engine.board.sector[sect].floorz - s.z) > 8192)
						{
							s.picnum++;
						}
					}

					if (s.z < msx[hittype[i].temp_data[4] + 2])
					{
						hittype[i].count++;
						s.xvel = 0;
					}
					else
					{
						s.z -= (1024 + 512);
					}
				}
				else if (hittype[i].count == 6)
				{
					if (s.xvel < 192)
					{
						s.xvel += 8;
					}
					s.ang = (short)Engine.getangle(msx[hittype[i].temp_data[4]] - s.x, msy[hittype[i].temp_data[4]] - s.y);
					if (ssp((short)i, (uint)(((1) << 16) + 1)) != 0)
					{
						;
					}
					if (((s.x - msx[hittype[i].temp_data[4]]) * (s.x - msx[hittype[i].temp_data[4]]) + (s.y - msy[hittype[i].temp_data[4]]) * (s.y - msy[hittype[i].temp_data[4]])) < (128 * 128))
					{
						hittype[i].count++;
					}
				}

				else if (hittype[i].count == 9)
				{
					hittype[i].count = 0;
				}

				Engine.board.setsprite((short)msy[hittype[i].temp_data[4] + 2], s.x, s.y, s.z - (34 << 8));

				if (s.owner != -1)
				{
					p = findplayer(s, ref x);

					j = ifhitbyweapon((short)i);
					if (j >= 0)
					{
						if (s.owner == -2)
						{
							if (ps[p].on_crane == i)
							{
								ps[p].on_crane = -1;
							}
						}
						s.owner = -1;
						s.picnum = DefineConstants.CRANE;
						goto BOLT;
					}

					if (s.owner >= 0)
					{
						Engine.board.setsprite(s.owner, s.x, s.y, s.z);

						hittype[s.owner].bposx = s.x;
						hittype[s.owner].bposy = s.y;
						hittype[s.owner].bposz = s.z;

						s.zvel = 0;
					}
					else if (s.owner == -2)
					{
						ps[p].oposx = ps[p].posx = s.x - (Engine.table.sintable[(ps[p].ang + 512) & 2047] >> 6);
						ps[p].oposy = ps[p].posy = s.y - (Engine.table.sintable[ps[p].ang & 2047] >> 6);
						ps[p].oposz = ps[p].posz = s.z + (2 << 8);
						Engine.board.setsprite(ps[p].i, ps[p].posx, ps[p].posy, ps[p].posz);
						ps[p].cursectnum = Engine.board.sprite[ps[p].i].sectnum;
					}
				}

				goto BOLT;
			}

			if ((Engine.board.sprite[i].picnum) >= (DefineConstants.WATERFOUNTAIN) && (Engine.board.sprite[i].picnum) <= (DefineConstants.WATERFOUNTAIN + 3))
			{
				if (hittype[i].count > 0)
				{
					if (hittype[i].count < 20)
					{
						hittype[i].count++;

						s.picnum++;

						if (s.picnum == (DefineConstants.WATERFOUNTAIN + 3))
						{
							s.picnum = DefineConstants.WATERFOUNTAIN + 1;
						}
					}
					else
					{
						p = findplayer(s, ref x);

						if (x > 512)
						{
							hittype[i].count = 0;
							s.picnum = DefineConstants.WATERFOUNTAIN;
						}
						else
						{
							hittype[i].count = 1;
						}
					}
				}
				goto BOLT;
			}

			if ((s.picnum == DefineConstants.BOX || s.picnum == DefineConstants.TREE1 || s.picnum == DefineConstants.TREE2 || s.picnum == DefineConstants.TIRE || s.picnum == DefineConstants.CONE))
			{
				if (hittype[i].count == 1)
				{
					hittype[i].temp_data[1]++;
					if ((hittype[i].temp_data[1] & 3) > 0)
					{
						goto BOLT;
					}

					if (s.picnum == DefineConstants.TIRE && hittype[i].temp_data[1] == 32)
					{
						s.cstat = 0;
						j = spawn((short)i, DefineConstants.BLOODPOOL);
						Engine.board.sprite[j].shade = 127;
					}
					else
					{
						if (s.shade < 64)
						{
							s.shade++;
						}
						else
						{
							Engine.board.deletesprite((short)i);
							goto BOLT;
						};
					}

					j = (short)(s.xrepeat - (Engine.krand() & 7));
					if (j < 10)
					{
						{
							Engine.board.deletesprite((short)i);
							goto BOLT;
						};
					}

					s.xrepeat = (byte)j;

					j = (short)(s.yrepeat - (Engine.krand() & 7));
					if (j < 4)
					{
						{
							Engine.board.deletesprite((short)i);
							goto BOLT;
						};
					}
					s.yrepeat = (byte)j;
				}
				if (s.picnum == DefineConstants.BOX)
				{
					makeitfall((short)i);
					hittype[i].ceilingz = Engine.board.sector[s.sectnum].ceilingz;
				}
				goto BOLT;
			}

			if (s.picnum == DefineConstants.TRIPBOMB)
			{
				if (hittype[i].actioncount > 0)
				{
					hittype[i].actioncount--;
					if (hittype[i].actioncount == 8)
					{
						spritesound(DefineConstants.LASERTRIP_EXPLODE, i);
						for (j = 0; j < 5; j++)
						{
							EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
						}
						x = s.extra;
						hitradius((short)i, tripbombblastradius, x >> 2, x >> 1, x - (x >> 2), x);

						j = spawn((short)i, DefineConstants.EXPLOSION2);
						Engine.board.sprite[j].ang = s.ang;
						Engine.board.sprite[j].xvel = 348;
						ssp((short)j, (uint)(((1) << 16) + 1));

						j = Engine.board.headspritestat[5];
						while (j >= 0)
						{
							if (Engine.board.sprite[j].picnum == DefineConstants.LASERLINE && s.hitag == Engine.board.sprite[j].hitag)
							{
								Engine.board.sprite[j].xrepeat = Engine.board.sprite[j].yrepeat = 0;
							}
							j = Engine.board.nextspritestat[j];
						}
						{
							Engine.board.deletesprite((short)i);
							goto BOLT;
						};
					}
					goto BOLT;
				}
				else
				{
					x = s.extra;
					s.extra = 1;
					l = s.ang;
					j = ifhitbyweapon((short)i);
					if (j >= 0)
					{
						hittype[i].actioncount = 16;
					}
					s.extra = (short)x;
					s.ang = (short)l;
				}

				if (hittype[i].count < 32)
				{
					p = findplayer(s, ref x);
					if (x > 768)
					{
						hittype[i].count++;
					}
					else if (hittype[i].count > 16)
					{
						hittype[i].count++;
					}
				}
				if (hittype[i].count == 32)
				{
					l = s.ang;
					s.ang = (short)hittype[i].temp_data[5];

					hittype[i].temp_data[3] = s.x;
					hittype[i].temp_data[4] = s.y;
					s.x += Engine.table.sintable[(hittype[i].temp_data[5] + 512) & 2047] >> 9;
					s.y += Engine.table.sintable[(hittype[i].temp_data[5]) & 2047] >> 9;
					s.z -= (3 << 8);
					Engine.board.setsprite((short)i, s.x, s.y, s.z);

					short _m = (short)m;
					x = hitasprite((short)i, ref _m);
					m = _m;

					hittype[i].lastvx = x;

					s.ang = (short)l;

					k = 0;

					while (x > 0)
					{
						j = spawn((short)i, DefineConstants.LASERLINE);
						Engine.board.setsprite((short)j, Engine.board.sprite[j].x, Engine.board.sprite[j].y, Engine.board.sprite[j].z);
						Engine.board.sprite[j].hitag = s.hitag;
						hittype[j].temp_data[1] = Engine.board.sprite[j].z;

						s.x += Engine.table.sintable[(hittype[i].temp_data[5] + 512) & 2047] >> 4;
						s.y += Engine.table.sintable[(hittype[i].temp_data[5]) & 2047] >> 4;

						if (x < 1024)
						{
							Engine.board.sprite[j].xrepeat = (byte)(x >> 5);
							break;
						}
						x -= 1024;
					}

					hittype[i].count++;
					s.x = hittype[i].temp_data[3];
					s.y = hittype[i].temp_data[4];
					s.z += (3 << 8);
					Engine.board.setsprite((short)i, s.x, s.y, s.z);
					hittype[i].temp_data[3] = 0;
					if (m >= 0)
					{
						hittype[i].actioncount = 13;
						spritesound(DefineConstants.LASERTRIP_ARMING, i);
					}
					else
					{
						hittype[i].actioncount = 0;
					}
				}
				if (hittype[i].count == 33)
				{
					hittype[i].temp_data[1]++;


					hittype[i].temp_data[3] = s.x;
					hittype[i].temp_data[4] = s.y;
					s.x += Engine.table.sintable[(hittype[i].temp_data[5] + 512) & 2047] >> 9;
					s.y += Engine.table.sintable[(hittype[i].temp_data[5]) & 2047] >> 9;
					s.z -= (3 << 8);
					Engine.board.setsprite((short)i, s.x, s.y, s.z);

					short _m = (short)m;
					x = hitasprite((short)i, ref _m);
					m = _m;

					s.x = hittype[i].temp_data[3];
					s.y = hittype[i].temp_data[4];
					s.z += (3 << 8);
					Engine.board.setsprite((short)i, s.x, s.y, s.z);

					if (hittype[i].lastvx != x)
					{
						hittype[i].actioncount = 13;
						spritesound(DefineConstants.LASERTRIP_ARMING, i);
					}
				}
				goto BOLT;
			}


			if (s.picnum >= DefineConstants.CRACK1 && s.picnum <= DefineConstants.CRACK4)
			{
				if (s.hitag > 0)
				{
					hittype[i].count = s.cstat;
					hittype[i].temp_data[1] = s.ang;
					j = ifhitbyweapon((short)i);
					if (j == DefineConstants.FIREEXT || j == DefineConstants.RPG || j == DefineConstants.RADIUSEXPLOSION || j == DefineConstants.SEENINE || j == DefineConstants.OOZFILTER)
					{
						j = Engine.board.headspritestat[6];
						while (j >= 0)
						{
							if (s.hitag == Engine.board.sprite[j].hitag && (Engine.board.sprite[j].picnum == DefineConstants.OOZFILTER || Engine.board.sprite[j].picnum == DefineConstants.SEENINE))
							{
								if (Engine.board.sprite[j].shade != -32)
								{
									Engine.board.sprite[j].shade = -32;
								}
							}
							j = Engine.board.nextspritestat[j];
						}

                        earthquaketime = (char)16;

                        j = Engine.board.headspritestat[3];
                        while (j >= 0)
                        {
                            if (s.hitag == Engine.board.sprite[j].hitag)
                            {
                                if (Engine.board.sprite[j].lotag == 13)
                                {
                                    if (hittype[j].actioncount == 0)
                                    {
                                        hittype[j].actioncount = 1;
                                    }
                                }
                                else if (Engine.board.sprite[j].lotag == 8)
                                {
                                    hittype[j].temp_data[4] = 1;
                                }
                                else if (Engine.board.sprite[j].lotag == 18)
                                {
                                    if (hittype[j].count == 0)
                                    {
                                        hittype[j].count = 1;
                                    }
                                }
                                else if (Engine.board.sprite[j].lotag == 21)
                                {
                                    hittype[j].count = 1;
                                }
                            }
                            j = Engine.board.nextspritestat[j];
                        }

                        s.z -= (32 << 8);

                        if ((hittype[i].temp_data[3] == 1 && s.xrepeat != 0) || s.lotag == -99)
                        {
                            x = s.extra;
                            spawn((short)i, DefineConstants.EXPLOSION2);
                            hitradius((short)i, seenineblastradius, x >> 2, x - (x >> 1), x - (x >> 2), x);
                            spritesound(DefineConstants.PIPEBOMB_EXPLODE, i);
                        }

                        if (s.xrepeat != 0)
                        {
                            for (x = 0; x < 8; x++)
                            {
                                EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
                            }
                        }

                        {
                            Engine.board.deletesprite((short)i);
                            goto BOLT;
                        };
                    }
					else
					{
						s.cstat = (short)hittype[i].count;
						s.ang = (short)hittype[i].temp_data[1];
						s.extra = 0;
					}
				}
				goto BOLT;
			}

			if (s.picnum == DefineConstants.FIREEXT)
			{
				j = ifhitbyweapon((short)i);
				if (j == -1)
				{
					goto BOLT;
				}

				for (k = 0; k < 16; k++)
				{
					j = EGS(Engine.board.sprite[i].sectnum, Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].z - (Engine.krand() % (48 << 8)), DefineConstants.SCRAP3 + (Engine.krand() & 3), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -(Engine.krand() & 4095) - (Engine.board.sprite[i].zvel >> 2), i, 5);
					Engine.board.sprite[j].pal = 2;
				}

				spawn((short)i, DefineConstants.EXPLOSION2);
				spritesound(DefineConstants.PIPEBOMB_EXPLODE, i);
				spritesound(DefineConstants.GLASS_HEAVYBREAK, i);

				if (s.hitag > 0)
				{
					j = Engine.board.headspritestat[6];
					while (j >= 0)
					{
						if (s.hitag == Engine.board.sprite[j].hitag && (Engine.board.sprite[j].picnum == DefineConstants.OOZFILTER || Engine.board.sprite[j].picnum == DefineConstants.SEENINE))
						{
							if (Engine.board.sprite[j].shade != -32)
							{
								Engine.board.sprite[j].shade = -32;
							}
						}
						j = Engine.board.nextspritestat[j];
					}

					x = s.extra;
					spawn((short)i, DefineConstants.EXPLOSION2);
					hitradius((short)i, pipebombblastradius, x >> 2, x - (x >> 1), x - (x >> 2), x);
					spritesound(DefineConstants.PIPEBOMB_EXPLODE, i);

                    earthquaketime = (char)16;

                    j = Engine.board.headspritestat[3];
                    while (j >= 0)
                    {
                        if (s.hitag == Engine.board.sprite[j].hitag)
                        {
                            if (Engine.board.sprite[j].lotag == 13)
                            {
                                if (hittype[j].actioncount == 0)
                                {
                                    hittype[j].actioncount = 1;
                                }
                            }
                            else if (Engine.board.sprite[j].lotag == 8)
                            {
                                hittype[j].temp_data[4] = 1;
                            }
                            else if (Engine.board.sprite[j].lotag == 18)
                            {
                                if (hittype[j].count == 0)
                                {
                                    hittype[j].count = 1;
                                }
                            }
                            else if (Engine.board.sprite[j].lotag == 21)
                            {
                                hittype[j].count = 1;
                            }
                        }
                        j = Engine.board.nextspritestat[j];
                    }

                    s.z -= (32 << 8);

                    if ((hittype[i].temp_data[3] == 1 && s.xrepeat != 0) || s.lotag == -99)
                    {
                        x = s.extra;
                        spawn((short)i, DefineConstants.EXPLOSION2);
                        hitradius((short)i, seenineblastradius, x >> 2, x - (x >> 1), x - (x >> 2), x);
                        spritesound(DefineConstants.PIPEBOMB_EXPLODE, i);
                    }

                    if (s.xrepeat != 0)
                    {
                        for (x = 0; x < 8; x++)
                        {
                            EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
                        }
                    }

                    {
                        Engine.board.deletesprite((short)i);
                        goto BOLT;
                    };
                }
				else
				{
					hitradius((short)i, seenineblastradius, 10, 15, 20, 25);
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};
				}
				goto BOLT;
			}

			if (s.picnum == DefineConstants.OOZFILTER || s.picnum == DefineConstants.SEENINE || s.picnum == DefineConstants.SEENINEDEAD || s.picnum == (DefineConstants.SEENINEDEAD + 1))
			{
				if (s.shade != -32 && s.shade != -33)
				{
					if (s.xrepeat != 0)
					{
						if ((ifhitbyweapon((short)i) >= 0))
							j = 1;
						else
							j = 0;
					}
					else
					{
						j = 0;
					}

					if (j != 0 || s.shade == -31)
					{
						if (j != 0)
						{
							s.lotag = 0;
						}

						hittype[i].temp_data[3] = 1;

						j = Engine.board.headspritestat[6];
						while (j >= 0)
						{
							if (s.hitag == Engine.board.sprite[j].hitag && (Engine.board.sprite[j].picnum == DefineConstants.SEENINE || Engine.board.sprite[j].picnum == DefineConstants.OOZFILTER))
							{
								Engine.board.sprite[j].shade = -32;
							}
							j = Engine.board.nextspritestat[j];
						}
					}
				}
				else
				{
					if (s.shade == -32)
					{
						if (s.lotag > 0)
						{
							s.lotag -= 3;
							if (s.lotag <= 0)
							{
								s.lotag = -99;
							}
						}
						else
						{
							s.shade = -33;
						}
					}
					else
					{
						if (s.xrepeat > 0)
						{
							hittype[i].actioncount++;
							if (hittype[i].actioncount == 3)
							{
								if (s.picnum == DefineConstants.OOZFILTER)
								{
									hittype[i].actioncount = 0;
									goto DETONATE;
								}
								if (s.picnum != (DefineConstants.SEENINEDEAD + 1))
								{
									hittype[i].actioncount = 0;

									if (s.picnum == DefineConstants.SEENINEDEAD)
									{
										s.picnum++;
									}
									else if (s.picnum == DefineConstants.SEENINE)
									{
										s.picnum = DefineConstants.SEENINEDEAD;
									}
								}
								else
								{
									goto DETONATE;
								}
							}
							goto BOLT;
						}

						DETONATE:

						earthquaketime = (char)16;

						j = Engine.board.headspritestat[3];
						while (j >= 0)
						{
							if (s.hitag == Engine.board.sprite[j].hitag)
							{
								if (Engine.board.sprite[j].lotag == 13)
								{
									if (hittype[j].actioncount == 0)
									{
										hittype[j].actioncount = 1;
									}
								}
								else if (Engine.board.sprite[j].lotag == 8)
								{
									hittype[j].temp_data[4] = 1;
								}
								else if (Engine.board.sprite[j].lotag == 18)
								{
									if (hittype[j].count == 0)
									{
										hittype[j].count = 1;
									}
								}
								else if (Engine.board.sprite[j].lotag == 21)
								{
									hittype[j].count = 1;
								}
							}
							j = Engine.board.nextspritestat[j];
						}

						s.z -= (32 << 8);

						if ((hittype[i].temp_data[3] == 1 && s.xrepeat != 0) || s.lotag == -99)
						{
							x = s.extra;
							spawn((short)i, DefineConstants.EXPLOSION2);
							hitradius((short)i, seenineblastradius, x >> 2, x - (x >> 1), x - (x >> 2), x);
							spritesound(DefineConstants.PIPEBOMB_EXPLODE, i);
						}

						if (s.xrepeat != 0)
						{
							for (x = 0; x < 8; x++)
							{
								EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
							}
						}

						{
							Engine.board.deletesprite((short)i);
							goto BOLT;
						};
					}
				}
				goto BOLT;
			}

			if (s.picnum == DefineConstants.MASTERSWITCH)
			{
				if (s.yvel == 1)
				{
					s.hitag--;
					if (s.hitag <= 0)
					{
						operatesectors((short)sect, (short)i);

						j = Engine.board.headspritesect[sect];
						while (j >= 0)
						{
							if (Engine.board.sprite[j].statnum == 3)
							{
								switch (Engine.board.sprite[j].lotag)
								{
									case 2:
									case 21:
									case 31:
									case 32:
									case 36:
										hittype[j].count = 1;
										break;
									case 3:
										hittype[j].temp_data[4] = 1;
										break;
								}
							}
							else if (Engine.board.sprite[j].statnum == 6)
							{
								switch (Engine.board.sprite[j].picnum)
								{
									case DefineConstants.SEENINE:
									case DefineConstants.OOZFILTER:
										Engine.board.sprite[j].shade = -31;
										break;
								}
							}
							j = Engine.board.nextspritesect[j];
						}
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
				}
				goto BOLT;
			}

			switch (s.picnum)
			{
				case DefineConstants.VIEWSCREEN:
				case DefineConstants.VIEWSCREEN2:

					if (s.xrepeat == 0)
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};

					p = findplayer(s, ref x);

					if (x < 2048)
					{
						if (Engine.board.sprite[i].yvel == 1)
						{
							camsprite = (short)i;
						}
					}
					else if (camsprite != -1 && hittype[i].count == 1)
					{
						camsprite = -1;
						hittype[i].count = 0;
						Engine.loadtile(s.picnum);
					}

					goto BOLT;

				case DefineConstants.TRASH:

					if (s.xvel == 0)
					{
						s.xvel = 1;
					}
					if (ssp((short)i, (uint)(((1) << 16) + 1)) != 0)
					{
						makeitfall((short)i);
						if ((Engine.krand() & 1) != 0)
						{
							s.zvel -= 256;
						}
						if (pragmas.klabs(s.xvel) < 48)
						{
							s.xvel += (short)(Engine.krand() & 3);
						}
					}
					else
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};
					break;

				case DefineConstants.SIDEBOLT1:
				case DefineConstants.SIDEBOLT1 + 1:
				case DefineConstants.SIDEBOLT1 + 2:
				case DefineConstants.SIDEBOLT1 + 3:
					p = findplayer(s, ref x);
					if (x > 20480)
					{
						goto BOLT;
					}

					CLEAR_THE_BOLT2:
					if (hittype[i].actioncount != 0)
					{
						hittype[i].actioncount--;
						goto BOLT;
					}
					if ((s.xrepeat | s.yrepeat) == 0)
					{
						s.xrepeat = (byte)hittype[i].count;
						s.yrepeat = (byte)hittype[i].temp_data[1];
					}
					if ((Engine.krand() & 8) == 0)
					{
						hittype[i].count = s.xrepeat;
						hittype[i].temp_data[1] = s.yrepeat;
						hittype[i].actioncount = global_random & 4;
						s.xrepeat = s.yrepeat = 0;
						goto CLEAR_THE_BOLT2;
					}
					s.picnum++;

					if ((l & 1) != 0)
					{
						s.cstat ^= 2;
					}

					if ((Engine.krand() & 1) != 0 && Engine.board.sector[sect].floorpicnum == DefineConstants.HURTRAIL)
					{
						spritesound(DefineConstants.SHORT_CIRCUIT, i);
					}

					if (s.picnum == DefineConstants.SIDEBOLT1 + 4)
					{
						s.picnum = DefineConstants.SIDEBOLT1;
					}

					goto BOLT;

				case DefineConstants.BOLT1:
				case DefineConstants.BOLT1 + 1:
				case DefineConstants.BOLT1 + 2:
				case DefineConstants.BOLT1 + 3:
					p = findplayer(s, ref x);
					if (x > 20480)
					{
						goto BOLT;
					}

					if (hittype[i].temp_data[3] == 0)
					{
						hittype[i].temp_data[3] = Engine.board.sector[sect].floorshade;
					}

					CLEAR_THE_BOLT:
					if (hittype[i].actioncount != 0)
					{
						hittype[i].actioncount--;
						Engine.board.sector[sect].floorshade = 20;
						Engine.board.sector[sect].ceilingshade = 20;
						goto BOLT;
					}
					if ((s.xrepeat | s.yrepeat) == 0)
					{
						s.xrepeat = (byte)hittype[i].count;
						s.yrepeat = (byte)hittype[i].temp_data[1];
					}
					else if ((Engine.krand() & 8) == 0)
					{
						hittype[i].count = s.xrepeat;
						hittype[i].temp_data[1] = s.yrepeat;
						hittype[i].actioncount = global_random & 4;
						s.xrepeat = s.yrepeat = 0;
						goto CLEAR_THE_BOLT;
					}
					s.picnum++;

					l = global_random & 7;
					s.xrepeat = (byte)(l + 8);

					if ((l & 1) != 0)
					{
						s.cstat ^= 2;
					}

					if (s.picnum == (DefineConstants.BOLT1 + 1) && (Engine.krand() & 7) == 0 && Engine.board.sector[sect].floorpicnum == DefineConstants.HURTRAIL)
					{
						spritesound(DefineConstants.SHORT_CIRCUIT, i);
					}

					if (s.picnum == DefineConstants.BOLT1 + 4)
					{
						s.picnum = DefineConstants.BOLT1;
					}

					if ((s.picnum & 1) != 0)
					{
						Engine.board.sector[sect].floorshade = 0;
						Engine.board.sector[sect].ceilingshade = 0;
					}
					else
					{
						Engine.board.sector[sect].floorshade = 20;
						Engine.board.sector[sect].ceilingshade = 20;
					}
					goto BOLT;

				case DefineConstants.WATERDRIP:

					if (hittype[i].temp_data[1] != 0)
					{
						hittype[i].temp_data[1]--;
						if (hittype[i].temp_data[1] == 0)
						{
							s.cstat &= 32767;
						}
					}
					else
					{
						makeitfall((short)i);
						ssp((short)i, (uint)(((1) << 16) + 1));
						if (s.xvel > 0)
						{
							s.xvel -= 2;
						}

						if (s.zvel == 0)
						{
							s.cstat |= unchecked((short)32768);

							if (s.pal != 2 && s.hitag == 0)
							{
// jmarshall - disable water drip because its fucking annoying
//								spritesound(DefineConstants.SOMETHING_DRIPPING, i);
// jmarshall end
							}

							if (Engine.board.sprite[s.owner].picnum != DefineConstants.WATERDRIP)
							{
								{
									Engine.board.deletesprite((short)i);
									goto BOLT;
								};
							}
							else
							{
								hittype[i].bposz = s.z = hittype[i].count;
								hittype[i].temp_data[1] = (int)(48 + (Engine.krand() & 31));
							}
						}
					}


					goto BOLT;

				case DefineConstants.DOORSHOCK:
					j = (short)(pragmas.klabs(Engine.board.sector[sect].ceilingz - Engine.board.sector[sect].floorz) >> 9);
					s.yrepeat = (byte)(j + 4);
					s.xrepeat = 16;
					s.z = Engine.board.sector[sect].floorz;
					goto BOLT;

				case DefineConstants.TOUCHPLATE:
					if (hittype[i].temp_data[1] == 1 && s.hitag >= 0) //Move the sector floor
					{
						x = Engine.board.sector[sect].floorz;

						if (hittype[i].temp_data[3] == 1)
						{
							if (x >= hittype[i].actioncount)
							{
								Engine.board.sector[sect].floorz = x;
								hittype[i].temp_data[1] = 0;
							}
							else
							{
								Engine.board.sector[sect].floorz += Engine.board.sector[sect].extra;
								p = checkcursectnums((short)sect);
								if (p >= 0)
								{
									ps[p].posz += Engine.board.sector[sect].extra;
								}
							}
						}
						else
						{
							if (x <= s.z)
							{
								Engine.board.sector[sect].floorz = s.z;
								hittype[i].temp_data[1] = 0;
							}
							else
							{
								Engine.board.sector[sect].floorz -= Engine.board.sector[sect].extra;
								p = checkcursectnums((short)sect);
								if (p >= 0)
								{
									ps[p].posz -= Engine.board.sector[sect].extra;
								}
							}
						}
						goto BOLT;
					}

					if (hittype[i].temp_data[5] == 1)
					{
						goto BOLT;
					}

					p = checkcursectnums((short)sect);
					if (p >= 0 && (ps[p].on_ground != 0 || s.ang == 512))
					{
						if (hittype[i].count == 0 && check_activator_motion(s.lotag) == 0)
						{
							hittype[i].count = 1;
							hittype[i].temp_data[1] = 1;
							if (hittype[i].temp_data[3] == 1)
								hittype[i].temp_data[3] = 0;
							else
								hittype[i].temp_data[3] = 1;
							operatemasterswitches(s.lotag);
							operateactivators(s.lotag, (short)p);
							if (s.hitag > 0)
							{
								s.hitag--;
								if (s.hitag == 0)
								{
									hittype[i].temp_data[5] = 1;
								}
							}
						}
					}
					else
					{
						hittype[i].count = 0;
					}

					if (hittype[i].temp_data[1] == 1)
					{
						j = Engine.board.headspritestat[6];
						while (j >= 0)
						{
							if (j != i && Engine.board.sprite[j].picnum == DefineConstants.TOUCHPLATE && Engine.board.sprite[j].lotag == s.lotag)
							{
								hittype[j].temp_data[1] = 1;
                                if (hittype[i].temp_data[3] == 1)
                                    hittype[i].temp_data[3] = 0;
                                else
                                    hittype[i].temp_data[3] = 1;
                            }
							j = Engine.board.nextspritestat[j];
						}
					}
					goto BOLT;

				case DefineConstants.CANWITHSOMETHING:
				case DefineConstants.CANWITHSOMETHING2:
				case DefineConstants.CANWITHSOMETHING3:
				case DefineConstants.CANWITHSOMETHING4:
					makeitfall((short)i);
					j = ifhitbyweapon((short)i);
					if (j >= 0)
					{
						spritesound(DefineConstants.VENT_BUST, i);
						for (j = 0; j < 10; j++)
						{
							EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
						}

						if (s.lotag != 0)
						{
							spawn((short)i, s.lotag);
						}

						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
					goto BOLT;

				case DefineConstants.EXPLODINGBARREL:
				case DefineConstants.WOODENHORSE:
				case DefineConstants.HORSEONSIDE:
				case DefineConstants.FLOORFLAME:
				case DefineConstants.FIREBARREL:
				case DefineConstants.FIREVASE:
				case DefineConstants.NUKEBARREL:
				case DefineConstants.NUKEBARRELDENTED:
				case DefineConstants.NUKEBARRELLEAKED:
				case DefineConstants.TOILETWATER:
				case DefineConstants.RUBBERCAN:
				case DefineConstants.STEAM:
				case DefineConstants.CEILINGSTEAM:
					p = findplayer(s, ref x);
					execute(i, (short)p, x);
					goto BOLT;
				case DefineConstants.WATERBUBBLEMAKER:
					p = findplayer(s, ref x);
					execute(i, (short)p, x);
					goto BOLT;
			}

			BOLT:
			i = nexti;
		}
	}

	public static void bounce(short i)
	{
		int k;
		int l;
		int daang;
		int dax;
		int day;
		int daz;
		int xvect;
		int yvect;
		int zvect;
		short hitsect;
		spritetype s = Engine.board.sprite[i];

		xvect = pragmas.mulscale10(s.xvel, Engine.table.sintable[(s.ang + 512) & 2047]);
		yvect = pragmas.mulscale10(s.xvel, Engine.table.sintable[s.ang & 2047]);
		zvect = s.zvel;

		hitsect = s.sectnum;

		k = Engine.board.sector[hitsect].wallptr;
		l = Engine.board.wall[k].point2;
		daang = Engine.getangle(Engine.board.wall[l].x - Engine.board.wall[k].x, Engine.board.wall[l].y - Engine.board.wall[k].y);

		if (s.z < (hittype[i].floorz + hittype[i].ceilingz) >> 1)
		{
			k = Engine.board.sector[hitsect].ceilingheinum;
		}
		else
		{
			k = Engine.board.sector[hitsect].floorheinum;
		}

		dax = pragmas.mulscale14(k, Engine.table.sintable[(daang) & 2047]);
		day = pragmas.mulscale14(k, Engine.table.sintable[(daang + 1536) & 2047]);
		daz = 4096;

		k = xvect * dax + yvect * day + zvect * daz;
		l = dax * dax + day * day + daz * daz;
		if ((pragmas.klabs(k) >> 14) < l)
		{
			k = pragmas.divscale17(k, l);
			xvect -= pragmas.mulscale16(dax, k);
			yvect -= pragmas.mulscale16(day, k);
			zvect -= pragmas.mulscale16(daz, k);
		}

		s.zvel = (short)zvect;
		s.xvel = (short)pragmas.ksqrt(pragmas.dmulscale8(xvect, xvect, yvect, yvect));
		s.ang = (short)Engine.getangle(xvect, yvect);
	}

	public static void moveweapons()
	{
		int i;
		int j;
		int k;
		int nexti;
		int p;
		int q;
		int tempsect;
		int dax;
		int day;
		int daz;
		int x = 0;
		int l;
		int ll;
		int x1;
		int y1;
		uint qq;
		spritetype s;

		i = Engine.board.headspritestat[4];
		while (i >= 0)
		{
			nexti = Engine.board.nextspritestat[i];
			s = Engine.board.sprite[i];

			if (s.sectnum < 0)
			{
				Engine.board.deletesprite(i);
				goto BOLT;
			};

			hittype[i].bposx = s.x;
			hittype[i].bposy = s.y;
			hittype[i].bposz = s.z;

			switch (s.picnum)
			{
				case DefineConstants.RADIUSEXPLOSION:
				case DefineConstants.KNEE:
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};
				case DefineConstants.TONGUE:
					hittype[i].count = Engine.table.sintable[(hittype[i].temp_data[1]) & 2047] >> 9;
					hittype[i].temp_data[1] += 32;
					if (hittype[i].temp_data[1] > 2047)
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};

					if (Engine.board.sprite[s.owner].statnum == DefineConstants.MAXSTATUS)
					{
						if (badguy(Engine.board.sprite[s.owner]) == 0)
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}

					s.ang = Engine.board.sprite[s.owner].ang;
					s.x = Engine.board.sprite[s.owner].x;
					s.y = Engine.board.sprite[s.owner].y;
					if (Engine.board.sprite[s.owner].picnum == DefineConstants.APLAYER)
					{
						s.z = Engine.board.sprite[s.owner].z - (34 << 8);
					}
					for (k = 0; k < hittype[i].count; k++)
					{
						q = EGS(s.sectnum, s.x + ((k * Engine.table.sintable[(s.ang + 512) & 2047]) >> 9), s.y + ((k * Engine.table.sintable[s.ang & 2047]) >> 9), s.z + ((k * pragmas.ksgn(s.zvel)) * pragmas.klabs(s.zvel / 12)), DefineConstants.TONGUE, (sbyte)(-40 + (k << 1)), 8, 8, 0, 0, 0, i, 5);
						Engine.board.sprite[q].cstat = 128;
						Engine.board.sprite[q].pal = 8;
					}
					q = EGS(s.sectnum, s.x + ((k * Engine.table.sintable[(s.ang + 512) & 2047]) >> 9), s.y + ((k * Engine.table.sintable[s.ang & 2047]) >> 9), s.z + ((k * pragmas.ksgn(s.zvel)) * pragmas.klabs(s.zvel / 12)), DefineConstants.INNERJAW, -40, 32, 32, 0, 0, 0, i, 5);
					Engine.board.sprite[q].cstat = 128;
					if (hittype[i].temp_data[1] > 512 && hittype[i].temp_data[1] < (1024))
					{
						Engine.board.sprite[q].picnum = DefineConstants.INNERJAW + 1;
					}

					goto BOLT;

				case DefineConstants.FREEZEBLAST:
					if (s.yvel < 1 || s.extra < 2 || (s.xvel | s.zvel) == 0)
					{
						j = spawn((short)i, DefineConstants.TRANSPORTERSTAR);
						Engine.board.sprite[j].pal = 1;
						Engine.board.sprite[j].xrepeat = 32;
						Engine.board.sprite[j].yrepeat = 32;
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
					goto case DefineConstants.SHRINKSPARK;
				//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
				case DefineConstants.SHRINKSPARK:
				case DefineConstants.RPG:
				case DefineConstants.FIRELASER:
				case DefineConstants.SPIT:
				case DefineConstants.COOLEXPLOSION1:

					if (s.picnum == DefineConstants.COOLEXPLOSION1)
					{
						if (Sound[DefineConstants.WIERDSHOT_FLY].num == 0)
						{
							spritesound(DefineConstants.WIERDSHOT_FLY, i);
						}
					}

					p = -1;

					if (s.picnum == DefineConstants.RPG && Engine.board.sector[s.sectnum].lotag == 2)
					{
						k = (short)(s.xvel >> 1);
						ll = s.zvel >> 1;
					}
					else
					{
						k = s.xvel;
						ll = s.zvel;
					}

					dax = s.x;
					day = s.y;
					daz = s.z;

					getglobalz((short)i);
					qq = (uint)(((256) << 16) + 64);

					switch (s.picnum)
					{
						case DefineConstants.RPG:
							if (hittype[i].picnum != DefineConstants.BOSS2 && s.xrepeat >= 10 && Engine.board.sector[s.sectnum].lotag != 2)
							{
								j = spawn((short)i, DefineConstants.SMALLSMOKE);
								Engine.board.sprite[j].z += (1 << 8);
							}
							break;
					}

					j = movesprite((short)i, (k * (Engine.table.sintable[(s.ang + 512) & 2047])) >> 14, (k * (Engine.table.sintable[s.ang & 2047])) >> 14, ll, qq);

					if (s.picnum == DefineConstants.RPG && s.yvel >= 0)
					{
						if (Engine.FindDistance2D(s.x - Engine.board.sprite[s.yvel].x, s.y - Engine.board.sprite[s.yvel].y) < 256)
						{
							j = (short)(49152 | s.yvel);
						}
					}

					if (s.sectnum < 0)
					{
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}

					if ((j & 49152) != 49152)
					{
						if (s.picnum != DefineConstants.FREEZEBLAST)
						{
							if (s.z < hittype[i].ceilingz)
							{
								j = (short)(16384 | (s.sectnum));
								s.zvel = -1;
							}
							else
							{
								if ((s.z > hittype[i].floorz && Engine.board.sector[s.sectnum].lotag != 1) || (s.z > hittype[i].floorz + (16 << 8) && Engine.board.sector[s.sectnum].lotag == 1))
								{
									j = (short)(16384 | (s.sectnum));
									if (Engine.board.sector[s.sectnum].lotag != 1)
									{
										s.zvel = 1;
									}
								}
							}
						}
					}

					if (s.picnum == DefineConstants.FIRELASER)
					{
						for (k = -3; k < 2; k++)
						{
							x = EGS(s.sectnum, s.x + ((k * Engine.table.sintable[(s.ang + 512) & 2047]) >> 9), s.y + ((k * Engine.table.sintable[s.ang & 2047]) >> 9), s.z + ((k * pragmas.ksgn(s.zvel)) * pragmas.klabs(s.zvel / 24)), DefineConstants.FIRELASER, (sbyte)(-40 + (k << 2)), (sbyte)s.xrepeat, (sbyte)s.yrepeat, 0, 0, 0, s.owner, 5);

							Engine.board.sprite[x].cstat = 128;
							Engine.board.sprite[x].pal = s.pal;
						}
					}
					else if (s.picnum == DefineConstants.SPIT)
					{
						if (s.zvel < 6144)
						{
							s.zvel += (short)(gc - 112);
						}
					}

					if (j != 0)
					{
						if (s.picnum == DefineConstants.COOLEXPLOSION1)
						{
							if ((j & 49152) == 49152 && Engine.board.sprite[j & (DefineConstants.MAXSPRITES - 1)].picnum != DefineConstants.APLAYER)
							{
								goto BOLT;
							}
							s.xvel = 0;
							s.zvel = 0;
						}

						if ((j & 49152) == 49152)
						{
							j &= (DefineConstants.MAXSPRITES - 1);

							if (s.picnum == DefineConstants.FREEZEBLAST && Engine.board.sprite[j].pal == 1)
							{
								if (badguy(Engine.board.sprite[j]) != 0 || Engine.board.sprite[j].picnum == DefineConstants.APLAYER)
								{
									j = spawn((short)i, DefineConstants.TRANSPORTERSTAR);
									Engine.board.sprite[j].pal = 1;
									Engine.board.sprite[j].xrepeat = 32;
									Engine.board.sprite[j].yrepeat = 32;

									{
										Engine.board.deletesprite(i);
										goto BOLT;
									};
								}
							}

							checkhitsprite((short)j, (short)i);

							if (Engine.board.sprite[j].picnum == DefineConstants.APLAYER)
							{
								p = Engine.board.sprite[j].yvel;
								spritesound(DefineConstants.PISTOL_BODYHIT, j);

								if (s.picnum == DefineConstants.SPIT)
								{
									ps[p].horiz += 32;
									ps[p].return_to_center = (char)8;

									if (ps[p].loogcnt == 0)
									{
										if (Sound[DefineConstants.DUKE_LONGTERM_PAIN].num < 1)
										{
											spritesound(DefineConstants.DUKE_LONGTERM_PAIN, ps[p].i);
										}

										j = (short)(3 + (Engine.krand() & 3));
										ps[p].numloogs = j;
										ps[p].loogcnt = 24 * 4;
										for (x = 0; x < j; x++)
										{
											ps[p].loogiex[x] = (int)(Engine.krand() % Engine.xdim);
											ps[p].loogiey[x] = (int)(Engine.krand() % Engine.ydim);
										}
									}
								}
							}
						}
						else if ((j & 49152) == 32768)
						{
							j &= (DefineConstants.MAXWALLS - 1);

							if (s.picnum != DefineConstants.RPG && s.picnum != DefineConstants.FREEZEBLAST && s.picnum != DefineConstants.SPIT && (Engine.board.wall[j].overpicnum == DefineConstants.MIRROR || Engine.board.wall[j].picnum == DefineConstants.MIRROR))
							{
								k = Engine.getangle(Engine.board.wall[Engine.board.wall[j].point2].x - Engine.board.wall[j].x, Engine.board.wall[Engine.board.wall[j].point2].y - Engine.board.wall[j].y);
								s.ang = (short)(((k << 1) - s.ang) & 2047);
								s.owner = (short)i;
								spawn((short)i, DefineConstants.TRANSPORTERSTAR);
								goto BOLT;
							}
							else
							{
								Engine.board.setsprite((short)i, dax, day, daz);
								checkhitwall((short)i, (short)j, s.x, s.y, s.z, s.picnum);

								if (s.picnum == DefineConstants.FREEZEBLAST)
								{
									if (Engine.board.wall[j].overpicnum != DefineConstants.MIRROR && Engine.board.wall[j].picnum != DefineConstants.MIRROR)
									{
										s.extra >>= 1;
										s.yvel--;
									}

									k = Engine.getangle(Engine.board.wall[Engine.board.wall[j].point2].x - Engine.board.wall[j].x, Engine.board.wall[Engine.board.wall[j].point2].y - Engine.board.wall[j].y);
									s.ang = (short)(((k << 1) - s.ang) & 2047);
									goto BOLT;
								}
							}
						}
						else if ((j & 49152) == 16384)
						{
							Engine.board.setsprite((short)i, dax, day, daz);

							if (s.zvel < 0)
							{
								if ((Engine.board.sector[s.sectnum].ceilingstat & 1) != 0)
								{
									if (Engine.board.sector[s.sectnum].ceilingpal == 0)
									{
										Engine.board.deletesprite(i);
										goto BOLT;
									};
								}

								checkhitceiling(s.sectnum);
							}

							if (s.picnum == DefineConstants.FREEZEBLAST)
							{
								bounce((short)i);
								ssp((short)i, qq);
								s.extra >>= 1;
								if (s.xrepeat > 8)
								{
									s.xrepeat -= 2;
								}
								if (s.yrepeat > 8)
								{
									s.yrepeat -= 2;
								}
								s.yvel--;
								goto BOLT;
							}
						}

						if (s.picnum != DefineConstants.SPIT)
						{
							if (s.picnum == DefineConstants.RPG)
							{
								k = spawn((short)i, DefineConstants.EXPLOSION2);
								Engine.board.sprite[k].x = dax;
								Engine.board.sprite[k].y = day;
								Engine.board.sprite[k].z = daz;

								if (s.xrepeat < 10)
								{
									Engine.board.sprite[k].xrepeat = 6;
									Engine.board.sprite[k].yrepeat = 6;
								}
								else if ((j & 49152) == 16384)
								{
									if (s.zvel > 0)
									{
										spawn((short)i, DefineConstants.EXPLOSION2BOT);
									}
									else
									{
										Engine.board.sprite[k].cstat |= 8;
										Engine.board.sprite[k].z += (48 << 8);
									}
								}
							}
							else if (s.picnum == DefineConstants.SHRINKSPARK)
							{
								spawn((short)i, DefineConstants.SHRINKEREXPLOSION);
								spritesound(DefineConstants.SHRINKER_HIT, i);
								hitradius((short)i, shrinkerblastradius, 0, 0, 0, 0);
							}
							else if (s.picnum != DefineConstants.COOLEXPLOSION1 && s.picnum != DefineConstants.FREEZEBLAST && s.picnum != DefineConstants.FIRELASER)
							{
								k = spawn((short)i, DefineConstants.EXPLOSION2);
								Engine.board.sprite[k].xrepeat = Engine.board.sprite[k].yrepeat = (byte)(s.xrepeat >> 1);
								if ((j & 49152) == 16384)
								{
									if (s.zvel < 0)
									{
										Engine.board.sprite[k].cstat |= 8;
										Engine.board.sprite[k].z += (72 << 8);
									}
								}
							}
							if (s.picnum == DefineConstants.RPG)
							{
								spritesound(DefineConstants.RPG_EXPLODE, i);

								if (s.xrepeat >= 10)
								{
									x = s.extra;
									hitradius((short)i, rpgblastradius, x >> 2, x >> 1, x - (x >> 2), x);
								}
								else
								{
									x = s.extra + (global_random & 3);
									hitradius((short)i, (rpgblastradius >> 1), x >> 2, x >> 1, x - (x >> 2), x);
								}
							}
						}
						if (s.picnum != DefineConstants.COOLEXPLOSION1)
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
					if (s.picnum == DefineConstants.COOLEXPLOSION1)
					{
						s.shade++;
						if (s.shade >= 40)
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
					else if (s.picnum == DefineConstants.RPG && Engine.board.sector[s.sectnum].lotag == 2 && s.xrepeat >= 10 && ((Engine.krand() >> 8) >= (255 - (140))))
					{
						spawn((short)i, DefineConstants.WATERBUBBLE);
					}

					goto BOLT;


				case DefineConstants.SHOTSPARK1:
					p = findplayer(s, ref x);
					execute(i, (short)p, x);
					goto BOLT;
			}
			BOLT:
			i = nexti;
		}
	}


	public static void movetransports()
	{
		char warpspriteto;
		short i;
		short j;
		short k;
		short l;
		short p;
		short sect;
		short sectlotag;
		short nexti;
		short nextj;
		short nextk;
		int ll;
		int onfloorz;
		int q;

		i = (short)Engine.board.headspritestat[9]; //Transporters

		while (i >= 0)
		{
			sect = Engine.board.sprite[i].sectnum;
			sectlotag = Engine.board.sector[sect].lotag;

			nexti = (short)Engine.board.nextspritestat[i];

			if (Engine.board.sprite[i].owner == i)
			{
				i = nexti;
				continue;
			}

			onfloorz = hittype[i].temp_data[4];

			if (hittype[i].count > 0)
			{
				hittype[i].count--;
			}

			j = (short)Engine.board.headspritesect[sect];
			while (j >= 0)
			{
				nextj = (short)Engine.board.nextspritesect[j];

				switch (Engine.board.sprite[j].statnum)
				{
					case 10: // Player

						if (Engine.board.sprite[j].owner != -1)
						{
							p = Engine.board.sprite[j].yvel;

							ps[p].on_warping_sector = (char)1;

							if (ps[p].transporter_hold == 0 && ps[p].jumping_counter == 0)
							{
								if (ps[p].on_ground != 0 && sectlotag == 0 && onfloorz != 0 && ps[p].jetpack_on == 0)
								{
									if (Engine.board.sprite[i].pal == 0)
									{
										spawn(i, DefineConstants.TRANSPORTERBEAM);
										spritesound(DefineConstants.TELEPORTER, i);
									}

									for (k = connecthead; k >= 0; k = connectpoint2[k])
									{
										if (ps[k].cursectnum == Engine.board.sprite[Engine.board.sprite[i].owner].sectnum)
										{
											ps[k].frag_ps = p;
											Engine.board.sprite[ps[k].i].extra = 0;
										}
									}

									ps[p].ang = Engine.board.sprite[Engine.board.sprite[i].owner].ang;

									if (Engine.board.sprite[Engine.board.sprite[i].owner].owner != Engine.board.sprite[i].owner)
									{
										hittype[i].count = 13;
										hittype[Engine.board.sprite[i].owner].count = 13;
										ps[p].transporter_hold = 13;
									}

									ps[p].bobposx = ps[p].oposx = ps[p].posx = Engine.board.sprite[Engine.board.sprite[i].owner].x;
									ps[p].bobposy = ps[p].oposy = ps[p].posy = Engine.board.sprite[Engine.board.sprite[i].owner].y;
									ps[p].oposz = ps[p].posz = Engine.board.sprite[Engine.board.sprite[i].owner].z - (38 << 8);

									Engine.board.changespritesect(j, Engine.board.sprite[Engine.board.sprite[i].owner].sectnum);
									ps[p].cursectnum = Engine.board.sprite[j].sectnum;

									if (Engine.board.sprite[i].pal == 0)
									{
										k = spawn(Engine.board.sprite[i].owner, DefineConstants.TRANSPORTERBEAM);
										spritesound(DefineConstants.TELEPORTER, k);
									}

									break;
								}
							}
							else if (!(sectlotag == 1 && ps[p].on_ground == 1))
							{
								break;
							}

							if (onfloorz == 0 && pragmas.klabs(Engine.board.sprite[i].z - ps[p].posz) < 6144)
							{
								if ((ps[p].jetpack_on == 0) || (ps[p].jetpack_on != 0 && (sync[p].bits & 1) != 0) || (ps[p].jetpack_on != 0 && (sync[p].bits & 2) != 0))
								{
									ps[p].oposx = ps[p].posx += Engine.board.sprite[Engine.board.sprite[i].owner].x - Engine.board.sprite[i].x;
									ps[p].oposy = ps[p].posy += Engine.board.sprite[Engine.board.sprite[i].owner].y - Engine.board.sprite[i].y;

									if (ps[p].jetpack_on != 0 && ((sync[p].bits & 1) != 0 || ps[p].jetpack_on < 11))
									{
										ps[p].posz = Engine.board.sprite[Engine.board.sprite[i].owner].z - 6144;
									}
									else
									{
										ps[p].posz = Engine.board.sprite[Engine.board.sprite[i].owner].z + 6144;
									}
									ps[p].oposz = ps[p].posz;

									hittype[ps[p].i].bposx = ps[p].posx;
									hittype[ps[p].i].bposy = ps[p].posy;
									hittype[ps[p].i].bposz = ps[p].posz;

									Engine.board.changespritesect(j, Engine.board.sprite[Engine.board.sprite[i].owner].sectnum);
									ps[p].cursectnum = Engine.board.sprite[Engine.board.sprite[i].owner].sectnum;

									break;
								}
							}

							k = 0;

							if (onfloorz != 0 && sectlotag == 1 && ps[p].on_ground != 0 && ps[p].posz > (Engine.board.sector[sect].floorz - (16 << 8)) && ((sync[p].bits & 2) != 0 || ps[p].poszv > 2048))
							{
								//                        if( onfloorz && sectlotag == 1 && ps[p].posz > (Engine.board.sector[sect].floorz-(6<<8)) )
								k = 1;
								if (screenpeek == p)
								{
									FX_StopAllSounds();
									clearsoundlocks();
								}
								if (Engine.board.sprite[ps[p].i].extra > 0)
								{
									spritesound(DefineConstants.DUKE_UNDERWATER, j);
								}
								ps[p].oposz = ps[p].posz = Engine.board.sector[Engine.board.sprite[Engine.board.sprite[i].owner].sectnum].ceilingz + (7 << 8);

								ps[p].posxv = (int)(4096 - (Engine.krand() & 8192));
								ps[p].posyv = (int)(4096 - (Engine.krand() & 8192));

							}

							if (onfloorz != 0 && sectlotag == 2 && ps[p].posz < (Engine.board.sector[sect].ceilingz + (6 << 8)))
							{
								k = 1;
								//                            if( Engine.board.sprite[j].extra <= 0) break;
								if (screenpeek == p)
								{
									FX_StopAllSounds();
									clearsoundlocks();
								}
								spritesound(DefineConstants.DUKE_GASP, j);

								ps[p].oposz = ps[p].posz = Engine.board.sector[Engine.board.sprite[Engine.board.sprite[i].owner].sectnum].floorz - (7 << 8);

								ps[p].jumping_toggle = (char)1;
								ps[p].jumping_counter = 0;
							}

							if (k == 1)
							{
								ps[p].oposx = ps[p].posx += Engine.board.sprite[Engine.board.sprite[i].owner].x - Engine.board.sprite[i].x;
								ps[p].oposy = ps[p].posy += Engine.board.sprite[Engine.board.sprite[i].owner].y - Engine.board.sprite[i].y;

								if (Engine.board.sprite[Engine.board.sprite[i].owner].owner != Engine.board.sprite[i].owner)
								{
									ps[p].transporter_hold = -2;
								}
								ps[p].cursectnum = Engine.board.sprite[Engine.board.sprite[i].owner].sectnum;

								Engine.board.changespritesect(j, Engine.board.sprite[Engine.board.sprite[i].owner].sectnum);
								Engine.board.setsprite(ps[p].i, ps[p].posx, ps[p].posy, ps[p].posz + (38 << 8));

								//setpal(ps[p]); // jmarshall: palette

								if ((Engine.krand() & 255) < 32)
								{
									spawn(j, DefineConstants.WATERSPLASH2);
								}

								if (sectlotag == 1)
								{
									for (l = 0; l < 9; l++)
									{
										q = spawn(ps[p].i, DefineConstants.WATERBUBBLE);
										Engine.board.sprite[q].z += (int)(Engine.krand() & 16383);
									}
								}
							}
						}
						break;

					case 1:
						switch (Engine.board.sprite[j].picnum)
						{
							case DefineConstants.SHARK:
							case DefineConstants.COMMANDER:
							case DefineConstants.OCTABRAIN:
							case DefineConstants.GREENSLIME:
							case DefineConstants.GREENSLIME + 1:
							case DefineConstants.GREENSLIME + 2:
							case DefineConstants.GREENSLIME + 3:
							case DefineConstants.GREENSLIME + 4:
							case DefineConstants.GREENSLIME + 5:
							case DefineConstants.GREENSLIME + 6:
							case DefineConstants.GREENSLIME + 7:
								if (Engine.board.sprite[j].extra > 0)
								{
									goto JBOLT;
								}
								break;
						}
						goto case 4;
					case 4:
					case 5:
					case 12:
					case 13:

						ll = pragmas.klabs(Engine.board.sprite[j].zvel);

						{
							warpspriteto = (char)0;
							if (ll != 0 && sectlotag == 2 && Engine.board.sprite[j].z < (Engine.board.sector[sect].ceilingz + ll))
							{
								warpspriteto = (char)1;
							}

							if (ll != 0 && sectlotag == 1 && Engine.board.sprite[j].z > (Engine.board.sector[sect].floorz - ll))
							{
								warpspriteto = (char)1;
							}

							if (sectlotag == 0 && (onfloorz != 0 || pragmas.klabs(Engine.board.sprite[j].z - Engine.board.sprite[i].z) < 4096))
							{
								if (Engine.board.sprite[Engine.board.sprite[i].owner].owner != Engine.board.sprite[i].owner && onfloorz != 0 && hittype[i].count > 0 && Engine.board.sprite[j].statnum != 5)
								{
									hittype[i].count++;
									goto BOLT;
								}
								warpspriteto = (char)1;
							}

							if (warpspriteto != 0)
							{
								switch (Engine.board.sprite[j].picnum)
								{
									case DefineConstants.TRANSPORTERSTAR:
									case DefineConstants.TRANSPORTERBEAM:
									case DefineConstants.TRIPBOMB:
									case DefineConstants.BULLETHOLE:
									case DefineConstants.WATERSPLASH2:
									case DefineConstants.BURNING:
									case DefineConstants.BURNING2:
									case DefineConstants.FIRE:
									case DefineConstants.FIRE2:
									case DefineConstants.TOILETWATER:
									case DefineConstants.LASERLINE:
										goto JBOLT;
									case DefineConstants.PLAYERONWATER:
										if (sectlotag == 2)
										{
											Engine.board.sprite[j].cstat &= 32767;
											break;
										}
                                        if (Engine.board.sprite[j].statnum == 5 && !(sectlotag == 1 || sectlotag == 2))
                                        {
                                            break;
                                        }
										goto case DefineConstants.WATERBUBBLE;
									default:
										if (Engine.board.sprite[j].statnum == 5 && !(sectlotag == 1 || sectlotag == 2))
										{
											break;
										}
										goto case DefineConstants.WATERBUBBLE;

									case DefineConstants.WATERBUBBLE:
										//                                if( rnd(192) && Engine.board.sprite[j].picnum == WATERBUBBLE)
										//                                 break;

										if (sectlotag > 0)
										{
											k = spawn(j, DefineConstants.WATERSPLASH2);
											if (sectlotag == 1 && Engine.board.sprite[j].statnum == 4)
											{
												Engine.board.sprite[k].xvel = (short)(Engine.board.sprite[j].xvel >> 1);
												Engine.board.sprite[k].ang = Engine.board.sprite[j].ang;
												ssp(k, (uint)(((1) << 16) + 1));
											}
										}

										switch (sectlotag)
										{
											case 0:
												if (onfloorz != 0)
												{
													if (Engine.board.sprite[j].statnum == 4 || (checkcursectnums(sect) == -1 && checkcursectnums(Engine.board.sprite[Engine.board.sprite[i].owner].sectnum) == -1))
													{
														Engine.board.sprite[j].x += (Engine.board.sprite[Engine.board.sprite[i].owner].x - Engine.board.sprite[i].x);
														Engine.board.sprite[j].y += (Engine.board.sprite[Engine.board.sprite[i].owner].y - Engine.board.sprite[i].y);
														Engine.board.sprite[j].z -= Engine.board.sprite[i].z - Engine.board.sector[Engine.board.sprite[Engine.board.sprite[i].owner].sectnum].floorz;
														Engine.board.sprite[j].ang = Engine.board.sprite[Engine.board.sprite[i].owner].ang;

														hittype[j].bposx = Engine.board.sprite[j].x;
														hittype[j].bposy = Engine.board.sprite[j].y;
														hittype[j].bposz = Engine.board.sprite[j].z;

														if (Engine.board.sprite[i].pal == 0)
														{
															k = spawn(i, DefineConstants.TRANSPORTERBEAM);
															spritesound(DefineConstants.TELEPORTER, k);

															k = spawn(Engine.board.sprite[i].owner, DefineConstants.TRANSPORTERBEAM);
															spritesound(DefineConstants.TELEPORTER, k);
														}

														if (Engine.board.sprite[Engine.board.sprite[i].owner].owner != Engine.board.sprite[i].owner)
														{
															hittype[i].count = 13;
															hittype[Engine.board.sprite[i].owner].count = 13;
														}

														Engine.board.changespritesect(j, Engine.board.sprite[Engine.board.sprite[i].owner].sectnum);
													}
												}
												else
												{
													Engine.board.sprite[j].x += (Engine.board.sprite[Engine.board.sprite[i].owner].x - Engine.board.sprite[i].x);
													Engine.board.sprite[j].y += (Engine.board.sprite[Engine.board.sprite[i].owner].y - Engine.board.sprite[i].y);
													Engine.board.sprite[j].z = Engine.board.sprite[Engine.board.sprite[i].owner].z + 4096;

													hittype[j].bposx = Engine.board.sprite[j].x;
													hittype[j].bposy = Engine.board.sprite[j].y;
													hittype[j].bposz = Engine.board.sprite[j].z;

													Engine.board.changespritesect(j, Engine.board.sprite[Engine.board.sprite[i].owner].sectnum);
												}
												break;
											case 1:
												Engine.board.sprite[j].x += (Engine.board.sprite[Engine.board.sprite[i].owner].x - Engine.board.sprite[i].x);
												Engine.board.sprite[j].y += (Engine.board.sprite[Engine.board.sprite[i].owner].y - Engine.board.sprite[i].y);
												Engine.board.sprite[j].z = Engine.board.sector[Engine.board.sprite[Engine.board.sprite[i].owner].sectnum].ceilingz + ll;

												hittype[j].bposx = Engine.board.sprite[j].x;
												hittype[j].bposy = Engine.board.sprite[j].y;
												hittype[j].bposz = Engine.board.sprite[j].z;

												Engine.board.changespritesect(j, Engine.board.sprite[Engine.board.sprite[i].owner].sectnum);

												break;
											case 2:
												Engine.board.sprite[j].x += (Engine.board.sprite[Engine.board.sprite[i].owner].x - Engine.board.sprite[i].x);
												Engine.board.sprite[j].y += (Engine.board.sprite[Engine.board.sprite[i].owner].y - Engine.board.sprite[i].y);
												Engine.board.sprite[j].z = Engine.board.sector[Engine.board.sprite[Engine.board.sprite[i].owner].sectnum].floorz - ll;

												hittype[j].bposx = Engine.board.sprite[j].x;
												hittype[j].bposy = Engine.board.sprite[j].y;
												hittype[j].bposz = Engine.board.sprite[j].z;

												Engine.board.changespritesect(j, Engine.board.sprite[Engine.board.sprite[i].owner].sectnum);

												break;
										}

										break;
								}
							}
						}
						break;

				}
				JBOLT:
				j = nextj;
			}
			BOLT:
			i = nexti;
		}
	}




	public static void moveactors()
	{
		int x = 09;
		int m = 09;
		int l = 09;
		weaponhit t;
		short a = 0;
		short i = 0;
		short j = 0;
		short nexti = 0;
		short nextj = 0;
		short sect = 0;
		short p = 0;
		spritetype s = null;
		ushort k = 0;

		i = (short)Engine.board.headspritestat[1];
		while (i >= 0)
		{
			nexti = (short)Engine.board.nextspritestat[i];

			s = Engine.board.sprite[i];

			sect = s.sectnum;

			if (s.xrepeat == 0 || sect < 0 || sect >= DefineConstants.MAXSECTORS)
			{
				Engine.board.deletesprite(i);
				goto BOLT;
			};

			t = hittype[i];

			hittype[i].bposx = s.x;
			hittype[i].bposy = s.y;
			hittype[i].bposz = s.z;


			switch (s.picnum)
			{
				case DefineConstants.DUCK:
				case DefineConstants.TARGET:
					if ((s.cstat & 32) != 0)
					{
						t[0]++;
						if (t[0] > 60)
						{
							t[0] = 0;
							s.cstat = (short)(128 + 257 + 16);
							s.extra = 1;
						}
					}
					else
					{
						j = ifhitbyweapon(i);
						if (j >= 0)
						{
							s.cstat = (short)(32 + 128);
							k = 1;

							j = (short)Engine.board.headspritestat[1];
							while (j >= 0)
							{
								if (Engine.board.sprite[j].lotag == s.lotag && Engine.board.sprite[j].picnum == s.picnum)
								{
									if ((Engine.board.sprite[j].hitag == 0 && (Engine.board.sprite[j].cstat & 32) == 0) || (Engine.board.sprite[j].hitag == 0 && (Engine.board.sprite[j].cstat & 32) == 0))
									{
										k = 0;
										break;
									}
								}

								j = (short)Engine.board.nextspritestat[j];
							}

							if (k == 1)
							{
								operateactivators(s.lotag, -1);
								operateforcefields(i, s.lotag);
								operatemasterswitches(s.lotag);
							}
						}
					}
					goto BOLT;

				case DefineConstants.RESPAWNMARKERRED:
				case DefineConstants.RESPAWNMARKERYELLOW:
				case DefineConstants.RESPAWNMARKERGREEN:
					hittype[i].count++;
					if (hittype[i].count > respawnitemtime)
					{
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
					if (hittype[i].count >= (respawnitemtime >> 1) && hittype[i].count < ((respawnitemtime >> 1) + (respawnitemtime >> 2)))
					{
						Engine.board.sprite[i].picnum = DefineConstants.RESPAWNMARKERYELLOW;
					}
					else if (hittype[i].count > ((respawnitemtime >> 1) + (respawnitemtime >> 2)))
					{
						Engine.board.sprite[i].picnum = DefineConstants.RESPAWNMARKERGREEN;
					}
					makeitfall(i);
					break;

				case DefineConstants.HELECOPT:
				case DefineConstants.DUKECAR:

					s.z += s.zvel;
					t[0]++;

					if (t[0] == 4)
					{
						spritesound(DefineConstants.WAR_AMBIENCE2, i);
					}

					if (t[0] > (26 * 8))
					{
						sound(DefineConstants.RPG_EXPLODE);
						for (j = 0; j < 32; j++)
						{
							EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
						}
						earthquaketime = (char)16;
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
					else if ((t[0] & 3) == 0)
					{
						spawn(i, DefineConstants.EXPLOSION2);
					}
					ssp(i, (uint)(((1) << 16) + 1));
					break;
				case DefineConstants.RAT:
					makeitfall(i);
					if (ssp(i, (uint)(((1) << 16) + 1)) != 0)
					{
						if ((Engine.krand() & 255) < 3)
						{
							spritesound(DefineConstants.RATTY, i);
						}
						s.ang += (short)((Engine.krand() & 31) - 15 + (Engine.table.sintable[(t[0] << 8) & 2047] >> 11));
					}
					else
					{
						hittype[i].count++;
						if (hittype[i].count > 1)
						{
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							};
						}
						else
						{
							s.ang = (short)(Engine.krand() & 2047);
						}
					}
					if (s.xvel < 128)
					{
						s.xvel += 2;
					}
					s.ang += (short)((Engine.krand() & 3) - 6);
					break;
				case DefineConstants.QUEBALL:
				case DefineConstants.STRIPEBALL:
					if (s.xvel != 0)
					{
						j = (short)Engine.board.headspritestat[0];
						while (j >= 0)
						{
							nextj = (short)Engine.board.nextspritestat[j];
							if (Engine.board.sprite[j].picnum == DefineConstants.POCKET && ldist(Engine.board.sprite[j], s) < 52)
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							};
							j = nextj;
						}

						j = (short)Engine.board.clipmove(ref s.x, ref s.y, ref s.z, ref s.sectnum, (((s.xvel * (Engine.table.sintable[(s.ang + 512) & 2047])) >> 14) * (DefineConstants.TICRATE / 26)) << 11, (((s.xvel * (Engine.table.sintable[s.ang & 2047])) >> 14) * (DefineConstants.TICRATE / 26)) << 11, 24, (4 << 8), (4 << 8), (((256) << 16) + 64));

						if ((j & 49152) != 0)
						{
							if ((j & 49152) == 32768)
							{
								j &= (DefineConstants.MAXWALLS - 1);
								k = (ushort)Engine.getangle(Engine.board.wall[Engine.board.wall[j].point2].x - Engine.board.wall[j].x, Engine.board.wall[Engine.board.wall[j].point2].y - Engine.board.wall[j].y);
								s.ang = (short)(((k << 1) - s.ang) & 2047);
							}
							else if ((j & 49152) == 49152)
							{
								j &= (DefineConstants.MAXSPRITES - 1);
								checkhitsprite(i, j);
							}
						}
						s.xvel--;
						if (s.xvel < 0)
						{
							s.xvel = 0;
						}
						if (s.picnum == DefineConstants.STRIPEBALL)
						{
							s.cstat = 257;
							s.cstat |= (short)(4 & s.xvel);
							s.cstat |= (short)(8 & s.xvel);
						}
					}
					else
					{
						p = findplayer(s, ref x);

						if (x < 1596)
						{

							{
								//                        if(s->pal == 12)
								j = getincangle(ps[p].ang, (short)Engine.getangle(s.x - ps[p].posx, s.y - ps[p].posy));
								if (j > -64 && j < 64 && (sync[p].bits & (1 << 29)) != 0)
								{
									if (ps[p].toggle_key_flag == 1)
									{
										a = (short)Engine.board.headspritestat[1];
										while (a >= 0)
										{
											if (Engine.board.sprite[a].picnum == DefineConstants.QUEBALL || Engine.board.sprite[a].picnum == DefineConstants.STRIPEBALL)
											{
												j = getincangle(ps[p].ang, (short)Engine.getangle(Engine.board.sprite[a].x - ps[p].posx, Engine.board.sprite[a].y - ps[p].posy));
												if (j > -64 && j < 64)
												{
													findplayer(Engine.board.sprite[a], ref l);
													if (x > l)
													{
														break;
													}
												}
											}
											a = (short)Engine.board.nextspritestat[a];
										}
										if (a == -1)
										{
											if (s.pal == 12)
											{
												s.xvel = 164;
											}
											else
											{
												s.xvel = 140;
											}
											s.ang = ps[p].ang;
											ps[p].toggle_key_flag = 2;
										}
									}
								}
							}
						}
						if (x < 512 && s.sectnum == ps[p].cursectnum)
						{
							s.ang = (short)Engine.getangle(s.x - ps[p].posx, s.y - ps[p].posy);
							s.xvel = 48;
						}
					}

					break;
				case DefineConstants.FORCESPHERE:

					if (s.yvel == 0)
					{
						s.yvel = 1;

						for (l = 512; l < (2048 - 512); l += 128)
						{
							for (j = 0; j < 2048; j += 128)
							{
								k = (ushort)spawn(i, DefineConstants.FORCESPHERE);
								Engine.board.sprite[k].cstat = 257 + 128;
								Engine.board.sprite[k].clipdist = 64;
								Engine.board.sprite[k].ang = j;
								Engine.board.sprite[k].zvel = (short)(Engine.table.sintable[l & 2047] >> 5);
								Engine.board.sprite[k].xvel = (short)(Engine.table.sintable[(l + 512) & 2047] >> 9);
								Engine.board.sprite[k].owner = i;
							}
						}
					}

					if (t[3] > 0)
					{
						if (s.zvel < 6144)
						{
							s.zvel += 192;
						}
						s.z += s.zvel;
						if (s.z > Engine.board.sector[sect].floorz)
						{
							s.z = Engine.board.sector[sect].floorz;
						}
						t[3]--;
						if (t[3] == 0)
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
					else if (t[2] > 10)
					{
						j = (short)Engine.board.headspritestat[5];
						while (j >= 0)
						{
							if (Engine.board.sprite[j].owner == i && Engine.board.sprite[j].picnum == DefineConstants.FORCESPHERE)
							{
								hittype[j].temp_data[1] = (int)(1 + (Engine.krand() & 63));
							}
							j = (short)Engine.board.nextspritestat[j];
						}
						t[3] = 64;
					}

					goto BOLT;

				case DefineConstants.RECON:

					getglobalz(i);

					if ((Engine.board.sector[s.sectnum].ceilingstat & 1) != 0)
					{
						s.shade += (sbyte)((Engine.board.sector[s.sectnum].ceilingshade - s.shade) >> 1);
					}
					else
					{
						s.shade += (sbyte)((Engine.board.sector[s.sectnum].floorshade - s.shade) >> 1);
					}

					if (s.z < Engine.board.sector[sect].ceilingz + (32 << 8))
					{
						s.z = Engine.board.sector[sect].ceilingz + (32 << 8);
					}

					if (ud.multimode < 2)
					{
						if (actor_tog == 1)
						{
							s.cstat = unchecked((short)32768);
							goto BOLT;
						}
						else if (actor_tog == 2)
						{
							s.cstat = 257;
						}
					}
					j = ifhitbyweapon(i);
					if (j >= 0)
					{
						if (s.extra < 0 && t[0] != -1)
						{
							t[0] = -1;
							s.extra = 0;
						}
						spritesound(DefineConstants.RECO_PAIN, i);
						EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
					}

					if (t[0] == -1)
					{
						s.z += 1024;
						t[2]++;
						if ((t[2] & 3) == 0)
						{
							spawn(i, DefineConstants.EXPLOSION2);
						}
						getglobalz(i);
						s.ang += 96;
						s.xvel = 128;
						j = ssp(i, (uint)(((1) << 16) + 1));
						if (j != 1 || s.z > hittype[i].floorz)
						{
							for (l = 0; l < 16; l++)
							{
								EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
							}
							spritesound(DefineConstants.LASERTRIP_EXPLODE, i);
							spawn(i, DefineConstants.PIGCOP);
							ps[myconnectindex].actors_killed++;
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							};
						}
						goto BOLT;
					}
					else
					{
						if (s.z > hittype[i].floorz - (48 << 8))
						{
							s.z = hittype[i].floorz - (48 << 8);
						}
					}

					p = findplayer(s, ref x);
					j = s.owner;

					// 3 = findplayerz, 4 = shoot

					if (t[0] >= 4)
					{
						t[2]++;
						if ((t[2] & 15) == 0)
						{
							a = s.ang;
							s.ang = hittype[i].tempang;
							spritesound(DefineConstants.RECO_ATTACK, i);
							shoot(i, DefineConstants.FIRELASER);
							s.ang = a;
						}
						if (t[2] > (26 * 3) || !Engine.board.cansee(s.x, s.y, s.z - (16 << 8), s.sectnum, ps[p].posx, ps[p].posy, ps[p].posz, ps[p].cursectnum))
						{
							t[0] = 0;
							t[2] = 0;
						}
						else
						{
							hittype[i].tempang += (short)(getincangle(hittype[i].tempang, (short)Engine.getangle(ps[p].posx - s.x, ps[p].posy - s.y)) / 3);
						}
					}
					else if (t[0] == 2 || t[0] == 3)
					{
						t[3] = 0;
						if (s.xvel > 0)
						{
							s.xvel -= 16;
						}
						else
						{
							s.xvel = 0;
						}

						if (t[0] == 2)
						{
							l = ps[p].posz - s.z;
							if (pragmas.klabs(l) < (48 << 8))
							{
								t[0] = 3;
							}
							else
							{
								s.z += pragmas.sgn(ps[p].posz - s.z) << 10;
							}
						}
						else
						{
							t[2]++;
							if (t[2] > (26 * 3) || !Engine.board.cansee(s.x, s.y, s.z - (16 << 8), s.sectnum, ps[p].posx, ps[p].posy, ps[p].posz, ps[p].cursectnum))
							{
								t[0] = 1;
								t[2] = 0;
							}
							else if ((t[2] & 15) == 0)
							{
								spritesound(DefineConstants.RECO_ATTACK, i);
								shoot(i, DefineConstants.FIRELASER);
							}
						}
						s.ang += (short)(getincangle(s.ang, (short)Engine.getangle(ps[p].posx - s.x, ps[p].posy - s.y)) >> 2);
					}

					if (t[0] != 2 && t[0] != 3)
					{
						l = ldist(Engine.board.sprite[j], s);
						if (l <= 1524)
						{
							a = s.ang;
							s.xvel >>= 1;
						}
						else
						{
							a = (short)Engine.getangle(Engine.board.sprite[j].x - s.x, Engine.board.sprite[j].y - s.y);
						}

						if (t[0] == 1 || t[0] == 4) // Found a locator and going with it
						{
							l = dist(Engine.board.sprite[j], s);

							if (l <= 1524)
							{
								if (t[0] == 1)
								{
									t[0] = 0;
								}
								else
								{
									t[0] = 5;
								}
							}
							else
							{
								// Control speed here
								if (l > 1524)
								{
									if (s.xvel < 256)
									{
										s.xvel += 32;
									}
								}
								else
								{
									if (s.xvel > 0)
									{
										s.xvel -= 16;
									}
									else
									{
										s.xvel = 0;
									}
								}
							}

							if (t[0] < 2)
							{
								t[2]++;
							}

							if (x < 6144 && t[0] < 2 && t[2] > (26 * 4))
							{
								t[0] = (int)(2 + (Engine.krand() & 2));
								t[2] = 0;
								hittype[i].tempang = s.ang;
							}
						}

						if (t[0] == 0 || t[0] == 5)
						{
							if (t[0] == 0)
							{
								t[0] = 1;
							}
							else
							{
								t[0] = 4;
							}
							j = s.owner = LocateTheLocator(s.hitag, -1);
							if (j == -1)
							{
								s.hitag = j = (short)hittype[i].temp_data[5];
								s.owner = LocateTheLocator(j, -1);
								j = s.owner;
								if (j == -1)
								{
									Engine.board.deletesprite(i);
									goto BOLT;
								};
							}
							else
							{
								s.hitag++;
							}
						}

						t[3] = getincangle(s.ang, a);
						s.ang += (short)(t[3] >> 3);

						if (s.z < Engine.board.sprite[j].z)
						{
							s.z += 1024;
						}
						else
						{
							s.z -= 1024;
						}
					}

					if (Sound[DefineConstants.RECO_ROAM].num == 0)
					{
						spritesound(DefineConstants.RECO_ROAM, i);
					}

					ssp(i, (uint)(((1) << 16) + 1));

					goto BOLT;

				case DefineConstants.OOZ:
				case DefineConstants.OOZ2:

					getglobalz(i);

					j = (short)((hittype[i].floorz - hittype[i].ceilingz) >> 9);
					if (j > 255)
					{
						j = 255;
					}

					x = 25 - (j >> 1);
					if (x < 8)
					{
						x = 8;
					}
					else if (x > 48)
					{
						x = 48;
					}

					s.yrepeat = (byte)j;
					s.xrepeat = (byte)x;
					s.z = hittype[i].floorz;

					goto BOLT;

				case DefineConstants.GREENSLIME:
				case DefineConstants.GREENSLIME + 1:
				case DefineConstants.GREENSLIME + 2:
				case DefineConstants.GREENSLIME + 3:
				case DefineConstants.GREENSLIME + 4:
				case DefineConstants.GREENSLIME + 5:
				case DefineConstants.GREENSLIME + 6:
				case DefineConstants.GREENSLIME + 7:

					// #ifndef VOLUMEONE
					if (ud.multimode < 2)
					{
						if (actor_tog == 1)
						{
							s.cstat = unchecked((short)32768);
							goto BOLT;
						}
						else if (actor_tog == 2)
						{
							s.cstat = 257;
						}
					}
					// #endif

					t[1] += 128;

					if ((Engine.board.sector[sect].floorstat & 1) != 0)
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};

					p = findplayer(s, ref x);

					if (x > 20480)
					{
						hittype[i].timetosleep++;
						if (hittype[i].timetosleep > DefineConstants.SLEEPTIME)
						{
							hittype[i].timetosleep = 0;
							Engine.board.changespritestat(i, 2);
							goto BOLT;
						}
					}

					if (t[0] == -5) // FROZEN
					{
						t[3]++;
						if (t[3] > 280)
						{
							s.pal = 0;
							t[0] = 0;
							goto BOLT;
						}
						makeitfall(i);
						s.cstat = 257;
						s.picnum = DefineConstants.GREENSLIME + 2;
						s.extra = 1;
						s.pal = 1;
						j = ifhitbyweapon(i);
						if (j >= 0)
						{
							if (j == DefineConstants.FREEZEBLAST)
							{
								goto BOLT;
							}
							for (j = 16; j >= 0; j--)
							{
								k = (ushort)EGS(Engine.board.sprite[i].sectnum, Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].z, DefineConstants.GLASSPIECES + (j % 3), -32, 36, 36, (short)(Engine.krand() & 2047), (short)(32 + (Engine.krand() & 63)), 1024 - (Engine.krand() & 1023), i, 5);
								Engine.board.sprite[k].pal = 1;
							}
							spritesound(DefineConstants.GLASS_BREAKING, i);
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							};
						}
						else if (x < 1024 && ps[p].quick_kick == 0)
						{
							j = getincangle(ps[p].ang, (short)Engine.getangle(Engine.board.sprite[i].x - ps[p].posx, Engine.board.sprite[i].y - ps[p].posy));
							if (j > -128 && j < 128)
							{
								ps[p].quick_kick = 14;
							}
						}

						goto BOLT;
					}

					if (x < 1596)
					{
						s.cstat = 0;
					}
					else
					{
						s.cstat = 257;
					}

					if (t[0] == -4) //On the player
					{
						if (Engine.board.sprite[ps[p].i].extra < 1)
						{
							t[0] = 0;
							goto BOLT;
						}

						Engine.board.setsprite(i, s.x, s.y, s.z);

						s.ang = ps[p].ang;

						if (((sync[p].bits & 4) != 0 || (ps[p].quick_kick > 0)) && Engine.board.sprite[ps[p].i].extra > 0)
						{
							if (ps[p].quick_kick > 0 || (ps[p].curr_weapon != DefineConstants.HANDREMOTE_WEAPON && ps[p].curr_weapon != DefineConstants.HANDBOMB_WEAPON && ps[p].curr_weapon != DefineConstants.TRIPBOMB_WEAPON && ps[p].ammo_amount[ps[p].curr_weapon] >= 0))
							{
								for (x = 0; x < 8; x++)
								{
									j = EGS(sect, s.x, s.y, s.z - (8 << 8), DefineConstants.SCRAP3 + (Engine.krand() & 3), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -(Engine.krand() & 4095) - (s.zvel >> 2), i, 5);
									Engine.board.sprite[j].pal = 6;
								}

								spritesound(DefineConstants.SLIM_DYING, i);
								spritesound(DefineConstants.SQUISHED, i);
								if ((Engine.krand() & 255) < 32)
								{
									j = spawn(i, DefineConstants.BLOODPOOL);
									Engine.board.sprite[j].pal = 0;
								}
								ps[p].actors_killed++;
								t[0] = -3;
								if (ps[p].somethingonplayer == i)
								{
									ps[p].somethingonplayer = -1;
								}
								{
									Engine.board.deletesprite(i);
									goto BOLT;
								};
							}
						}

						s.z = ps[p].posz + ps[p].pyoff - t[2] + (8 << 8);

						s.z += (100 - ps[p].horiz) << 4;

						if (t[2] > 512)
						{
							t[2] -= 128;
						}

						if (t[2] < 348)
						{
							t[2] += 128;
						}

						if (ps[p].newowner >= 0)
						{
							ps[p].newowner = -1;
							ps[p].posx = ps[p].oposx;
							ps[p].posy = ps[p].oposy;
							ps[p].posz = ps[p].oposz;
							ps[p].ang = ps[p].oang;

							Engine.board.updatesector(ps[p].posx, ps[p].posy, ref ps[p].cursectnum);
							//setpal(ps[p]); // jmarshall paletee

							j = (short)Engine.board.headspritestat[1];
							while (j >= 0)
							{
								if (Engine.board.sprite[j].picnum == DefineConstants.CAMERA1)
								{
									Engine.board.sprite[j].yvel = 0;
								}
								j = (short)Engine.board.nextspritestat[j];
							}
						}

						if (t[3] > 0)
						{
							short[] frames = { 5, 5, 6, 6, 7, 7, 6, 5 };

							s.picnum = (short)(DefineConstants.GREENSLIME + frames[t[3]]);

							if (t[3] == 5)
							{
								Engine.board.sprite[ps[p].i].extra += (short)(-(5 + (Engine.krand() & 3)));
								spritesound(DefineConstants.SLIM_ATTACK, i);
							}

							if (t[3] < 7)
							{
								t[3]++;
							}
							else
							{
								t[3] = 0;
							}

						}
						else
						{
							s.picnum = DefineConstants.GREENSLIME + 5;
							if (((Engine.krand() >> 8) >= (255 - (32))))
							{
								t[3] = 1;
							}
						}

						s.xrepeat = (byte)(20 + (Engine.table.sintable[t[1] & 2047] >> 13));
						s.yrepeat = (byte)(15 + (Engine.table.sintable[t[1] & 2047] >> 13));

						s.x = ps[p].posx + (Engine.table.sintable[(ps[p].ang + 512) & 2047] >> 7);
						s.y = ps[p].posy + (Engine.table.sintable[ps[p].ang & 2047] >> 7);

						goto BOLT;
					}

					else if (s.xvel < 64 && x < 768)
					{
						if (ps[p].somethingonplayer == -1)
						{
							ps[p].somethingonplayer = i;
							if (t[0] == 3 || t[0] == 2) //Falling downward
							{
								t[2] = (12 << 8);
							}
							else
							{
								t[2] = -(13 << 8); //Climbing up duke
							}
							t[0] = -4;
						}
					}

					j = ifhitbyweapon(i);
					if (j >= 0)
					{
						spritesound(DefineConstants.SLIM_DYING, i);

						ps[p].actors_killed++;
						if (ps[p].somethingonplayer == i)
						{
							ps[p].somethingonplayer = -1;
						}

						if (j == DefineConstants.FREEZEBLAST)
						{
							spritesound(DefineConstants.SOMETHINGFROZE, i);
							t[0] = -5;
							t[3] = 0;
							goto BOLT;
						}

						if ((Engine.krand() & 255) < 32)
						{
							j = spawn(i, DefineConstants.BLOODPOOL);
							Engine.board.sprite[j].pal = 0;
						}

						for (x = 0; x < 8; x++)
						{
							j = EGS(sect, s.x, s.y, s.z - (8 << 8), DefineConstants.SCRAP3 + (Engine.krand() & 3), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -(Engine.krand() & 4095) - (s.zvel >> 2), i, 5);
							Engine.board.sprite[j].pal = 6;
						}
						t[0] = -3;
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
					// All weap
					if (t[0] == -1) //Shrinking down
					{
						makeitfall(i);

						s.cstat &= unchecked((short)65535 - 8);
						s.picnum = DefineConstants.GREENSLIME + 4;

						//                    if(s->yrepeat > 62)
						//                      guts(s,JIBS6,5,myconnectindex);

						if (s.xrepeat > 32)
						{
							s.xrepeat -= (byte)(Engine.krand() & 7);
						}
						if (s.yrepeat > 16)
						{
							s.yrepeat -= (byte)(Engine.krand() & 7);
						}
						else
						{
							s.xrepeat = 40;
							s.yrepeat = 16;
							t[5] = -1;
							t[0] = 0;
						}

						goto BOLT;
					}
					else if (t[0] != -2)
					{
						getglobalz(i);
					}

					if (t[0] == -2) //On top of somebody
					{
						makeitfall(i);
						Engine.board.sprite[t[5]].xvel = 0;

						l = Engine.board.sprite[t[5]].ang;

						s.z = Engine.board.sprite[t[5]].z;
						s.x = Engine.board.sprite[t[5]].x + (Engine.table.sintable[(l + 512) & 2047] >> 11);
						s.y = Engine.board.sprite[t[5]].y + (Engine.table.sintable[l & 2047] >> 11);

						s.picnum = (short)(DefineConstants.GREENSLIME + 2 + (global_random & 1));

						if (s.yrepeat < 64)
						{
							s.yrepeat += 2;
						}
						else
						{
							if (s.xrepeat < 32)
							{
								s.xrepeat += 4;
							}
							else
							{
								t[0] = -1;
								x = ldist(s, Engine.board.sprite[t[5]]);
								if (x < 768)
								{
									Engine.board.sprite[t[5]].xrepeat = 0;
								}
							}
						}

						goto BOLT;
					}

					//Check randomly to see of there is an actor near
					if (((Engine.krand() >> 8) >= (255 - (32))))
					{
						j = (short)Engine.board.headspritesect[sect];
						while (j >= 0)
						{
							switch (Engine.board.sprite[j].picnum)
							{
								case DefineConstants.LIZTROOP:
								case DefineConstants.LIZMAN:
								case DefineConstants.PIGCOP:
								case DefineConstants.NEWBEAST:
									if (ldist(s, Engine.board.sprite[j]) < 768 && (pragmas.klabs(s.z - Engine.board.sprite[j].z) < 8192)) //Gulp them
									{
										t[5] = j;
										t[0] = -2;
										t[1] = 0;
										goto BOLT;
									}
									break;
							}

							j = (short)Engine.board.nextspritesect[j];
						}
					}

					//Moving on the ground or ceiling

					if (t[0] == 0 || t[0] == 2)
					{
						s.picnum = DefineConstants.GREENSLIME;

						if ((Engine.krand() & 511) == 0)
						{
							spritesound(DefineConstants.SLIM_ROAM, i);
						}

						if (t[0] == 2)
						{
							s.zvel = 0;
							s.cstat &= unchecked((short)(65535 - 8));

							if ((Engine.board.sector[sect].ceilingstat & 1) != 0 || (hittype[i].ceilingz + 6144) < s.z)
							{
								s.z += 2048;
								t[0] = 3;
								goto BOLT;
							}
						}
						else
						{
							s.cstat |= 8;
							makeitfall(i);
						}

						if ((everyothertime & 1) != 0)
						{
							ssp(i, (uint)(((1) << 16) + 1));
						}

						if (s.xvel > 96)
						{
							s.xvel -= 2;
							goto BOLT;
						}
						else
						{
							if (s.xvel < 32)
							{
								s.xvel += 4;
							}
							s.xvel = (short)(64 - (Engine.table.sintable[(t[1] + 512) & 2047] >> 9));

							s.ang += (short)(getincangle(s.ang, (short)Engine.getangle(ps[p].posx - s.x, ps[p].posy - s.y)) >> 3);
							// TJR
						}

						s.xrepeat = (byte)(36 + (Engine.table.sintable[(t[1] + 512) & 2047] >> 11));
						s.yrepeat = (byte)(16 + (Engine.table.sintable[t[1] & 2047] >> 13));

						if (((Engine.krand() >> 8) >= (255 - (4))) && (Engine.board.sector[sect].ceilingstat & 1) == 0 && pragmas.klabs(hittype[i].floorz - hittype[i].ceilingz) < (192 << 8))
						{
							s.zvel = 0;
							t[0]++;
						}

					}

					if (t[0] == 1)
					{
						s.picnum = DefineConstants.GREENSLIME;
						if (s.yrepeat < 40)
						{
							s.yrepeat += 8;
						}
						if (s.xrepeat > 8)
						{
							s.xrepeat -= 4;
						}
						if (s.zvel > -(2048 + 1024))
						{
							s.zvel -= 348;
						}
						s.z += s.zvel;
						if (s.z < hittype[i].ceilingz + 4096)
						{
							s.z = hittype[i].ceilingz + 4096;
							s.xvel = 0;
							t[0] = 2;
						}
					}

					if (t[0] == 3)
					{
						s.picnum = DefineConstants.GREENSLIME + 1;

						makeitfall(i);

						if (s.z > hittype[i].floorz - (8 << 8))
						{
							s.yrepeat -= 4;
							s.xrepeat += 2;
						}
						else
						{
							if (s.yrepeat < (40 - 4))
							{
								s.yrepeat += 8;
							}
							if (s.xrepeat > 8)
							{
								s.xrepeat -= 4;
							}
						}

						if (s.z > hittype[i].floorz - 2048)
						{
							s.z = hittype[i].floorz - 2048;
							t[0] = 0;
							s.xvel = 0;
						}
					}
					goto BOLT;

				case DefineConstants.BOUNCEMINE:
				case DefineConstants.MORTER:
					j = spawn(i, DefineConstants.FRAMEEFFECT1);
					hittype[j].count = 3;

					goto case DefineConstants.HEAVYHBOMB;
				case DefineConstants.HEAVYHBOMB:

					if ((s.cstat & 32768) != 0)
					{
						t[2]--;
						if (t[2] <= 0)
						{
							spritesound(DefineConstants.TELEPORTER, i);
							spawn(i, DefineConstants.TRANSPORTERSTAR);
							s.cstat = 257;
						}
						goto BOLT;
					}

					p = findplayer(s, ref x);

					if (x < 1220)
					{
						s.cstat &= ~257;
					}
					else
					{
						s.cstat |= 257;
					}

					if (t[3] == 0)
					{
						j = ifhitbyweapon(i);
						if (j >= 0)
						{
							t[3] = 1;
							t[4] = 0;
							l = 0;
							s.xvel = 0;
							goto DETONATEB;
						}
					}

					if (s.picnum != DefineConstants.BOUNCEMINE)
					{
						makeitfall(i);

						if (Engine.board.sector[sect].lotag != 1 && s.z >= hittype[i].floorz - ((1 << 8)) && s.yvel < 3)
						{
							if (s.yvel > 0 || (s.yvel == 0 && hittype[i].floorz == Engine.board.sector[sect].floorz))
							{
								spritesound(DefineConstants.PIPEBOMB_BOUNCE, i);
							}
							s.zvel = (short)(-((4 - s.yvel) << 8));
							if (Engine.board.sector[s.sectnum].lotag == 2)
							{
								s.zvel >>= 2;
							}
							s.yvel++;
						}
						if (s.z < hittype[i].ceilingz) // && Engine.board.sector[sect].lotag != 2 )
						{
							s.z = hittype[i].ceilingz + (3 << 8);
							s.zvel = 0;
						}
					}

					j = (short)movesprite(i, (s.xvel * (Engine.table.sintable[(s.ang + 512) & 2047])) >> 14, (s.xvel * (Engine.table.sintable[s.ang & 2047])) >> 14, s.zvel, (((1) << 16) + 1));

					if (Engine.board.sector[Engine.board.sprite[i].sectnum].lotag == 1 && s.zvel == 0)
					{
						s.z += (32 << 8);
						if (t[5] == 0)
						{
							t[5] = 1;
							spawn(i, DefineConstants.WATERSPLASH2);
						}
					}
					else
					{
						t[5] = 0;
					}

					if (t[3] == 0 && (s.picnum == DefineConstants.BOUNCEMINE || s.picnum == DefineConstants.MORTER) && (j != 0 || x < 844))
					{
						t[3] = 1;
						t[4] = 0;
						l = 0;
						s.xvel = 0;
						goto DETONATEB;
					}

					if (Engine.board.sprite[s.owner].picnum == DefineConstants.APLAYER)
					{
						l = Engine.board.sprite[s.owner].yvel;
					}
					else
					{
						l = -1;
					}

					if (s.xvel > 0)
					{
						s.xvel -= 5;
						if (Engine.board.sector[sect].lotag == 2)
						{
							s.xvel -= 10;
						}

						if (s.xvel < 0)
						{
							s.xvel = 0;
						}
						if ((s.xvel & 8) != 0)
						{
							s.cstat ^= 4;
						}
					}

					if ((j & 49152) == 32768)
					{
						j &= (DefineConstants.MAXWALLS - 1);

						checkhitwall(i, j, s.x, s.y, s.z, s.picnum);

						k = (ushort)Engine.getangle(Engine.board.wall[Engine.board.wall[j].point2].x - Engine.board.wall[j].x, Engine.board.wall[Engine.board.wall[j].point2].y - Engine.board.wall[j].y);

						s.ang = (short)(((k << 1) - s.ang) & 2047);
						s.xvel >>= 1;
					}

					DETONATEB:

					if ((l >= 0 && ps[l].hbomb_on == 0) || t[3] == 1)
					{
						t[4]++;

						if (t[4] == 2)
						{
							x = s.extra;
							m = 0;
							switch (s.picnum)
							{
								case DefineConstants.HEAVYHBOMB:
									m = pipebombblastradius;
									break;
								case DefineConstants.MORTER:
									m = morterblastradius;
									break;
								case DefineConstants.BOUNCEMINE:
									m = bouncemineblastradius;
									break;
							}

							hitradius(i, m, x >> 2, x >> 1, x - (x >> 2), x);
							spawn(i, DefineConstants.EXPLOSION2);
							if (s.zvel == 0)
							{
								spawn(i, DefineConstants.EXPLOSION2BOT);
							}
							spritesound(DefineConstants.PIPEBOMB_EXPLODE, i);
							for (x = 0; x < 8; x++)
							{
								EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
							}
						}

						if (s.yrepeat != 0)
						{
							s.yrepeat = 0;
							goto BOLT;
						}

						if (t[4] > 20)
						{
							if (s.owner != i || ud.respawn_items == 0)
							{
								{
									Engine.board.deletesprite(i);
									goto BOLT;
								};
							}
							else
							{
								t[2] = respawnitemtime;
								spawn(i, DefineConstants.RESPAWNMARKERRED);
								s.cstat = unchecked((short)32768);
								s.yrepeat = 9;
								goto BOLT;
							}
						}
					}
					else if (s.picnum == DefineConstants.HEAVYHBOMB && x < 788 && t[0] > 7 && s.xvel == 0)
					{
						if (Engine.board.cansee(s.x, s.y, s.z - (8 << 8), s.sectnum, ps[p].posx, ps[p].posy, ps[p].posz, ps[p].cursectnum))
						{
							if (ps[p].ammo_amount[DefineConstants.HANDBOMB_WEAPON] < max_ammo_amount[DefineConstants.HANDBOMB_WEAPON])
							{
								if (ud.coop >= 1 && s.owner == i)
								{
									for (j = 0; j < ps[p].weapreccnt; j++)
									{
										if (ps[p].weaprecs[j] == s.picnum)
										{
											goto BOLT;
										}
									}

									if (ps[p].weapreccnt < 255)
									{
										ps[p].weaprecs[ps[p].weapreccnt++] = s.picnum;
									}
								}

								addammo(DefineConstants.HANDBOMB_WEAPON, ps[p], 1);
								spritesound(DefineConstants.DUKE_GET, ps[p].i);

								if (ps[p].gotweapon[DefineConstants.HANDBOMB_WEAPON] == false || s.owner == ps[p].i)
								{
									addweapon(ps[p], DefineConstants.HANDBOMB_WEAPON);
								}

								if (Engine.board.sprite[s.owner].picnum != DefineConstants.APLAYER)
								{
									ps[p].pals[0] = 0;
									ps[p].pals[1] = 32;
									ps[p].pals[2] = 0;
									ps[p].pals_time = 32;
								}

								if (s.owner != i || ud.respawn_items == 0)
								{
									if (s.owner == i && ud.coop >= 1)
									{
										goto BOLT;
									}
									{
										Engine.board.deletesprite(i);
										goto BOLT;
									};
								}
								else
								{
									t[2] = respawnitemtime;
									spawn(i, DefineConstants.RESPAWNMARKERRED);
									s.cstat = unchecked((short)32768);
								}
							}
						}
					}

					if (t[0] < 8)
					{
						t[0]++;
					}
					goto BOLT;

				case DefineConstants.REACTORBURNT:
				case DefineConstants.REACTOR2BURNT:
					goto BOLT;

				case DefineConstants.REACTOR:
				case DefineConstants.REACTOR2:

					if (t[4] == 1)
					{
						j = (short)Engine.board.headspritesect[sect];
						while (j >= 0)
						{
							switch (Engine.board.sprite[j].picnum)
							{
								case DefineConstants.SECTOREFFECTOR:
									if (Engine.board.sprite[j].lotag == 1)
									{
										Engine.board.sprite[j].lotag = unchecked((short)65535);
										Engine.board.sprite[j].hitag = unchecked((short)65535);
									}
									break;
								case DefineConstants.REACTOR:
									Engine.board.sprite[j].picnum = DefineConstants.REACTORBURNT;
									break;
								case DefineConstants.REACTOR2:
									Engine.board.sprite[j].picnum = DefineConstants.REACTOR2BURNT;
									break;
								case DefineConstants.REACTORSPARK:
								case DefineConstants.REACTOR2SPARK:
									Engine.board.sprite[j].cstat = unchecked((short)32768);
									break;
							}
							j = (short)Engine.board.nextspritesect[j];
						}
						goto BOLT;
					}

					if (t[1] >= 20)
					{
						t[4] = 1;
						goto BOLT;
					}

					p = findplayer(s, ref x);

					t[2]++;
					if (t[2] == 4)
					{
						t[2] = 0;
					}

					if (x < 4096)
					{
						if ((Engine.krand() & 255) < 16)
						{
							if (Sound[DefineConstants.DUKE_LONGTERM_PAIN].num < 1)
							{
								spritesound(DefineConstants.DUKE_LONGTERM_PAIN, ps[p].i);
							}

							spritesound(DefineConstants.SHORT_CIRCUIT, i);

							Engine.board.sprite[ps[p].i].extra--;
							ps[p].pals_time = 32;
							ps[p].pals[0] = 32;
							ps[p].pals[1] = 0;
							ps[p].pals[2] = 0;
						}
						t[0] += 128;
						if (t[3] == 0)
						{
							t[3] = 1;
						}
					}
					else
					{
						t[3] = 0;
					}

					if (t[1] != 0)
					{
						t[1]++;

						t[4] = s.z;
						s.z = (short)(Engine.board.sector[sect].floorz - (Engine.krand() % (Engine.board.sector[sect].floorz - Engine.board.sector[sect].ceilingz)));

						switch (t[1])
						{
							case 3:
								//Turn on all of those flashing sectoreffector.
								hitradius(i, 4096, impact_damage << 2, impact_damage << 2, impact_damage << 2, impact_damage << 2);
								/*
															j = (short)Engine.board.headspritestat[3];
															while(j>=0)
															{
																if( Engine.board.sprite[j].lotag  == 3 )
																	hittype[j].temp_data[4]=1;
																else if(Engine.board.sprite[j].lotag == 12)
																{
																	hittype[j].temp_data[4] = 1;
																	Engine.board.sprite[j].lotag = 3;
																	Engine.board.sprite[j].owner = 0;
																	hittype[j].count = s->shade;
																}
																j = (short)Engine.board.nextspritestat[j];
															}
								*/
								j = (short)Engine.board.headspritestat[6];
								while (j >= 0)
								{
									if (Engine.board.sprite[j].picnum == DefineConstants.MASTERSWITCH)
									{
										if (Engine.board.sprite[j].hitag == s.hitag)
										{
											if (Engine.board.sprite[j].yvel == 0)
											{
												Engine.board.sprite[j].yvel = 1;
											}
										}
									}
									j = (short)Engine.board.nextspritestat[j];
								}
								break;

							case 4:
							case 7:
							case 10:
							case 15:
								j = (short)Engine.board.headspritesect[sect];
								while (j >= 0)
								{
									l = (short)Engine.board.nextspritesect[j];

									if (j != i)
									{
										Engine.board.deletesprite(j);
										break;
									}
									j = (short)l;
								}
								break;
						}
						for (x = 0; x < 16; x++)
						{
							EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
						}

						s.z = t[4];
						t[4] = 0;

					}
					else
					{
						j = ifhitbyweapon(i);
						if (j >= 0)
						{
							for (x = 0; x < 32; x++)
							{
								EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
							}
							if (s.extra < 0)
							{
								t[1] = 1;
							}
						}
					}
					goto BOLT;

				case DefineConstants.CAMERA1:

					if (t[0] == 0)
					{
						t[1] += 8;
						if (camerashitable != 0)
						{
							j = ifhitbyweapon(i);
							if (j >= 0)
							{
								t[0] = 1; // static
								s.cstat = unchecked((short)32768);
								for (x = 0; x < 5; x++)
								{
									EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
								}
								goto BOLT;
							}
						}

						if (s.hitag > 0)
						{
							if (t[1] < s.hitag)
							{
								s.ang += 8;
							}
							else if (t[1] < (s.hitag * 3))
							{
								s.ang -= 8;
							}
							else if (t[1] < (s.hitag << 2))
							{
								s.ang += 8;
							}
							else
							{
								t[1] = 8;
								s.ang += 16;
							}
						}
					}
					goto BOLT;
			}


			// #ifndef VOLOMEONE
			if (ud.multimode < 2 && badguy(s) != 0)
			{
				if (actor_tog == 1)
				{
					s.cstat = unchecked((short)32768);
					goto BOLT;
				}
				else if (actor_tog == 2)
				{
					s.cstat = 257;
				}
			}
			// #endif

			p = findplayer(s, ref x);

			execute(i, p, x);

			BOLT:

			i = nexti;
		}

	}


	public static void moveexplosions() // STATNUM 5
	{
		short i = 0;
		short j = 0;
		short k = 0;
		short nexti = 0;
		short sect = 0;
		short p = 0;
		int l = 0;
		int x = 0;
		weaponhit t;
		spritetype s;

		i = (short)Engine.board.headspritestat[5];
		while (i >= 0)
		{
			nexti = (short)Engine.board.nextspritestat[i];

			t = hittype[i];
			s = Engine.board.sprite[i];
			sect = s.sectnum;

			if (sect < 0 || s.xrepeat == 0)
			{
				Engine.board.deletesprite(i);
				goto BOLT;
			};

			hittype[i].bposx = s.x;
			hittype[i].bposy = s.y;
			hittype[i].bposz = s.z;

			switch (s.picnum)
			{
				case DefineConstants.NEON1:
				case DefineConstants.NEON2:
				case DefineConstants.NEON3:
				case DefineConstants.NEON4:
				case DefineConstants.NEON5:
				case DefineConstants.NEON6:

					if ((global_random / (s.lotag + 1) & 31) > 4)
					{
						s.shade = -127;
					}
					else
					{
						s.shade = 127;
					}
					goto BOLT;

				case DefineConstants.BLOODSPLAT1:
				case DefineConstants.BLOODSPLAT2:
				case DefineConstants.BLOODSPLAT3:
				case DefineConstants.BLOODSPLAT4:

					if (t[0] == 7 * 26)
					{
						goto BOLT;
					}
					s.z += (int)(16 + (Engine.krand() & 15));
					t[0]++;
					if ((t[0] % 9) == 0)
					{
						s.yrepeat++;
					}
					goto BOLT;

				case DefineConstants.NUKEBUTTON:
				case DefineConstants.NUKEBUTTON + 1:
				case DefineConstants.NUKEBUTTON + 2:
				case DefineConstants.NUKEBUTTON + 3:

					if (t[0] != 0)
					{
						t[0]++;
						if (t[0] == 8)
						{
							s.picnum = DefineConstants.NUKEBUTTON + 1;
						}
						else if (t[0] == 16)
						{
							s.picnum = DefineConstants.NUKEBUTTON + 2;
							ps[Engine.board.sprite[s.owner].yvel].fist_incs = 1;
						}
						if (ps[Engine.board.sprite[s.owner].yvel].fist_incs == 26)
						{
							s.picnum = DefineConstants.NUKEBUTTON + 3;
						}
					}
					goto BOLT;

				case DefineConstants.FORCESPHERE:

					l = s.xrepeat;
					if (t[1] > 0)
					{
						t[1]--;
						if (t[1] == 0)
						{
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							};
						}
					}
					if (hittype[s.owner].temp_data[1] == 0)
					{
						if (t[0] < 64)
						{
							t[0]++;
							l += 3;
						}
					}
					else
					{
						if (t[0] > 64)
						{
							t[0]--;
							l -= 3;
						}
					}

					s.x = Engine.board.sprite[s.owner].x;
					s.y = Engine.board.sprite[s.owner].y;
					s.z = Engine.board.sprite[s.owner].z;
					s.ang += (short)hittype[s.owner].count;

					if (l > 64)
					{
						l = 64;
					}
					else if (l < 1)
					{
						l = 1;
					}

					s.xrepeat = (byte)l;
					s.yrepeat = (byte)l;
					s.shade = (sbyte)((l >> 1) - 48);

					for (j = (short)t[0]; j > 0; j--)
					{
						ssp(i, (uint)(((1) << 16) + 1));
					}
					goto BOLT;
				case DefineConstants.WATERSPLASH2:

					t[0]++;
					if (t[0] == 1)
					{
						if (Engine.board.sector[sect].lotag != 1 && Engine.board.sector[sect].lotag != 2)
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
						/*                    else
											{
												l = getflorzofslope(sect,s->x,s->y)-s->z;
												if( l > (16<<8) ) KILLIT(i);
											}
											else */
						if (Sound[DefineConstants.ITEM_SPLASH].num == 0)
						{
							spritesound(DefineConstants.ITEM_SPLASH, i);
						}
					}
					if (t[0] == 3)
					{
						t[0] = 0;
						t[1]++;
					}
					if (t[1] == 5)
					{
						Engine.board.deletesprite(i);
					}
					goto BOLT;

				case DefineConstants.FRAMEEFFECT1:

					if (s.owner >= 0)
					{
						t[0]++;

						if (t[0] > 7)
						{
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							};
						}
						else if (t[0] > 4)
						{
							s.cstat |= 512 + 2;
						}
						else if (t[0] > 2)
						{
							s.cstat |= 2;
						}
						s.xoffset = Engine.board.sprite[s.owner].xoffset;
						s.yoffset = Engine.board.sprite[s.owner].yoffset;
					}
					goto BOLT;
				case DefineConstants.INNERJAW:
				case DefineConstants.INNERJAW + 1:
					x = 0;
					p = findplayer(s, ref x);
					if (x < 512)
					{
						ps[p].pals_time = 32;
						ps[p].pals[0] = 32;
						ps[p].pals[1] = 0;
						ps[p].pals[2] = 0;
						Engine.board.sprite[ps[p].i].extra -= 4;
					}

					goto case DefineConstants.FIRELASER;
				case DefineConstants.FIRELASER:
					if (s.extra != 999)
					{
						s.extra = 999;
					}
					else
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};
					break;
				case DefineConstants.TONGUE:
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};
				case DefineConstants.MONEY + 1:
				case DefineConstants.MAIL + 1:
				case DefineConstants.PAPER + 1:
					hittype[i].floorz = s.z = Engine.board.getflorzofslope(s.sectnum, s.x, s.y);
					break;
				case DefineConstants.MONEY:
				case DefineConstants.MAIL:
				case DefineConstants.PAPER:

					s.xvel = (short)((Engine.krand() & 7) + (Engine.table.sintable[hittype[i].count & 2047] >> 9));
					hittype[i].count += (short)(Engine.krand() & 63);
					if ((hittype[i].count & 2047) > 512 && (hittype[i].count & 2047) < 1596)
					{
						if (Engine.board.sector[sect].lotag == 2)
						{
							if (s.zvel < 64)
							{
								s.zvel += (short)((gc >> 5) + (Engine.krand() & 7));
							}
						}
						else
						{
							if (s.zvel < 144)
							{
								s.zvel += (short)((gc >> 5) + (Engine.krand() & 7));
							}
						}
					}

					ssp(i, (uint)(((1) << 16) + 1));

					if ((Engine.krand() & 3) == 0)
					{
						Engine.board.setsprite(i, s.x, s.y, s.z);
					}

					if (s.sectnum == -1)
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};
					l = Engine.board.getflorzofslope(s.sectnum, s.x, s.y);

					if (s.z > l)
					{
						s.z = l;

						insertspriteq(i);
						Engine.board.sprite[i].picnum++;

						j = (short)Engine.board.headspritestat[5];
						while (j >= 0)
						{
							if (Engine.board.sprite[j].picnum == DefineConstants.BLOODPOOL)
							{
								if (ldist(s, Engine.board.sprite[j]) < 348)
								{
									s.pal = 2;
									break;
								}
							}
							j = (short)Engine.board.nextspritestat[j];
						}
					}

					break;

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

					if (s.xvel > 0)
					{
						s.xvel--;
					}
					else
					{
						s.xvel = 0;
					}

					if (t[5] < 30 * 10)
					{
						t[5]++;
					}
					else
					{
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}


					if (s.zvel > 1024 && s.zvel < 1280)
					{
						Engine.board.setsprite(i, s.x, s.y, s.z);
						sect = s.sectnum;
					}

					l = Engine.board.getflorzofslope(sect, s.x, s.y);
					x = Engine.board.getceilzofslope(sect, s.x, s.y);
					if (x == l || sect < 0 || sect >= DefineConstants.MAXSECTORS)
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};

					if (s.z < l - (2 << 8))
					{
						if (t[1] < 2)
						{
							t[1]++;
						}
						else if (Engine.board.sector[sect].lotag != 2)
						{
							t[1] = 0;
							if (s.picnum == DefineConstants.DUKELEG || s.picnum == DefineConstants.DUKETORSO || s.picnum == DefineConstants.DUKEGUN)
							{
								if (t[0] > 6)
								{
									t[0] = 0;
								}
								else
								{
									t[0]++;
								}
							}
							else
							{
								if (t[0] > 2)
								{
									t[0] = 0;
								}
								else
								{
									t[0]++;
								}
							}
						}

						if (s.zvel < 6144)
						{
							if (Engine.board.sector[sect].lotag == 2)
							{
								if (s.zvel < 1024)
								{
									s.zvel += 48;
								}
								else
								{
									s.zvel = 1024;
								}
							}
							else
							{
								s.zvel += (short)(gc - 50);
							}
						}

						s.x += (s.xvel * Engine.table.sintable[(s.ang + 512) & 2047]) >> 14;
						s.y += (s.xvel * Engine.table.sintable[s.ang & 2047]) >> 14;
						s.z += s.zvel;

					}
					else
					{
						if (t[2] == 0)
						{
							if (s.sectnum == -1)
							{
								{
									Engine.board.deletesprite(i);
									goto BOLT;
								};
							}
							if ((Engine.board.sector[s.sectnum].floorstat & 2) != 0)
							{
								{
									Engine.board.deletesprite(i);
									goto BOLT;
								};
							}
							t[2]++;
						}
						l = Engine.board.getflorzofslope(s.sectnum, s.x, s.y);

						s.z = l - (2 << 8);
						s.xvel = 0;

						if (s.picnum == DefineConstants.JIBS6)
						{
							t[1]++;
							if ((t[1] & 3) == 0 && t[0] < 7)
							{
								t[0]++;
							}
							if (t[1] > 20)
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							};
						}
						else
						{
							s.picnum = DefineConstants.JIBS6;
							t[0] = 0;
							t[1] = 0;
						}
					}
					goto BOLT;

				case DefineConstants.BLOODPOOL:
				case DefineConstants.PUKE:

					if (t[0] == 0)
					{
						t[0] = 1;
						if ((Engine.board.sector[sect].floorstat & 2) != 0)
						{
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							};
						}
						else
						{
							insertspriteq(i);
						}
					}

					makeitfall(i);

					p = findplayer(s, ref x);

					s.z = hittype[i].floorz - ((1 << 8));

					if (t[2] < 32)
					{
						t[2]++;
						if (hittype[i].picnum == DefineConstants.TIRE)
						{
							if (s.xrepeat < 64 && s.yrepeat < 64)
							{
								s.xrepeat += (byte)(Engine.krand() & 3);
								s.yrepeat += (byte)(Engine.krand() & 3);
							}
						}
						else
						{
							if (s.xrepeat < 32 && s.yrepeat < 32)
							{
								s.xrepeat += (byte)(Engine.krand() & 3);
								s.yrepeat += (byte)(Engine.krand() & 3);
							}
						}
					}

					if (x < 844 && s.xrepeat > 6 && s.yrepeat > 6)
					{
						if (s.pal == 0 && (Engine.krand() & 255) < 16 && s.picnum != DefineConstants.PUKE)
						{
							if (ps[p].boot_amount > 0)
							{
								ps[p].boot_amount--;
							}
							else
							{
								if (Sound[DefineConstants.DUKE_LONGTERM_PAIN].num < 1)
								{
									spritesound(DefineConstants.DUKE_LONGTERM_PAIN, ps[p].i);
								}
								Engine.board.sprite[ps[p].i].extra--;
								ps[p].pals_time = 32;
								ps[p].pals[0] = 16;
								ps[p].pals[1] = 0;
								ps[p].pals[2] = 0;
							}
						}

						if (t[1] == 1)
						{
							goto BOLT;
						}
						t[1] = 1;

						if (hittype[i].picnum == DefineConstants.TIRE)
						{
							ps[p].footprintcount = (char)10;
						}
						else
						{
							ps[p].footprintcount = (char)3;
						}

						//ps[p].footprintpal = s.pal; // jmarshall palette
						ps[p].footprintshade = s.shade;

						if (t[2] == 32)
						{
							s.xrepeat -= 6;
							s.yrepeat -= 6;
						}
					}
					else
					{
						t[1] = 0;
					}
					goto BOLT;

				case DefineConstants.BURNING:
				case DefineConstants.BURNING2:
				case DefineConstants.FECES:
				case DefineConstants.WATERBUBBLE:
				case DefineConstants.SMALLSMOKE:
				case DefineConstants.EXPLOSION2:
				case DefineConstants.SHRINKEREXPLOSION:
				case DefineConstants.EXPLOSION2BOT:
				case DefineConstants.BLOOD:
				case DefineConstants.LASERSITE:
				case DefineConstants.FORCERIPPLE:
				case DefineConstants.TRANSPORTERSTAR:
				case DefineConstants.TRANSPORTERBEAM:
					p = findplayer(s, ref x);
					execute(i, p, x);
					goto BOLT;

				case DefineConstants.SHELL:
				case DefineConstants.SHOTGUNSHELL:

					ssp(i, (uint)(((1) << 16) + 1));

					if (sect < 0 || (Engine.board.sector[sect].floorz + (24 << 8)) < s.z)
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};

					if (Engine.board.sector[sect].lotag == 2)
					{
						t[1]++;
						if (t[1] > 8)
						{
							t[1] = 0;
							t[0]++;
							t[0] &= 3;
						}
						if (s.zvel < 128)
						{
							s.zvel += (short)(gc / 13); // 8
						}
						else
						{
							s.zvel -= 64;
						}
						if (s.xvel > 0)
						{
							s.xvel -= 4;
						}
						else
						{
							s.xvel = 0;
						}
					}
					else
					{
						t[1]++;
						if (t[1] > 3)
						{
							t[1] = 0;
							t[0]++;
							t[0] &= 3;
						}
						if (s.zvel < 512)
						{
							s.zvel += (short)(gc / 3); // 52;
						}
						if (s.xvel > 0)
						{
							s.xvel--;
						}
						else
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}

					goto BOLT;

				case DefineConstants.GLASSPIECES:
				case DefineConstants.GLASSPIECES + 1:
				case DefineConstants.GLASSPIECES + 2:

					makeitfall(i);

					if (s.zvel > 4096)
					{
						s.zvel = 4096;
					}
					if (sect < 0)
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};

					if (s.z == hittype[i].floorz - ((1 << 8)) && t[0] < 3)
					{
						s.zvel = (short)(-((3 - t[0]) << 8) - (Engine.krand() & 511));
						if (Engine.board.sector[sect].lotag == 2)
						{
							s.zvel >>= 1;
						}
						s.xrepeat >>= 1;
						s.yrepeat >>= 1;
						if (((Engine.krand() >> 8) >= (255 - (96))))
						{
							Engine.board.setsprite(i, s.x, s.y, s.z);
						}
						t[0]++; //Number of bounces
					}
					else if (t[0] == 3)
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};

					if (s.xvel > 0)
					{
						s.xvel -= 2;
						s.cstat = (short)((s.xvel & 3) << 2);
					}
					else
					{
						s.xvel = 0;
					}

					ssp(i, (uint)(((1) << 16) + 1));

					goto BOLT;
			}

			if ((Engine.board.sprite[i].picnum) >= (DefineConstants.SCRAP6) && (Engine.board.sprite[i].picnum) <= (DefineConstants.SCRAP5 + 3))
			{
				if (s.xvel > 0)
				{
					s.xvel--;
				}
				else
				{
					s.xvel = 0;
				}

				if (s.zvel > 1024 && s.zvel < 1280)
				{
					Engine.board.setsprite(i, s.x, s.y, s.z);
					sect = s.sectnum;
				}

				if (s.z < Engine.board.sector[sect].floorz - (2 << 8))
				{
					if (t[1] < 1)
					{
						t[1]++;
					}
					else
					{
						t[1] = 0;

						if (s.picnum < DefineConstants.SCRAP6 + 8)
						{
							if (t[0] > 6)
							{
								t[0] = 0;
							}
							else
							{
								t[0]++;
							}
						}
						else
						{
							if (t[0] > 2)
							{
								t[0] = 0;
							}
							else
							{
								t[0]++;
							}
						}
					}
					if (s.zvel < 4096)
					{
						s.zvel += (short)(gc - 50);
					}
					s.x += (s.xvel * Engine.table.sintable[(s.ang + 512) & 2047]) >> 14;
					s.y += (s.xvel * Engine.table.sintable[s.ang & 2047]) >> 14;
					s.z += s.zvel;
				}
				else
				{
					if (s.picnum == DefineConstants.SCRAP1 && s.yvel > 0)
					{
						j = spawn(i, s.yvel);
						Engine.board.setsprite(j, s.x, s.y, s.z);
						getglobalz(j);
						Engine.board.sprite[j].hitag = Engine.board.sprite[j].lotag = 0;
					}
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};
				}
				goto BOLT;
			}

			BOLT:
			i = nexti;
		}
	}

	public static void moveeffectors() //STATNUM 3
	{
		int q = 0;
		int l = 0;
		int m = 0;
		int x = 0;
		int st = 0;
		int j = 0;
		weaponhit t;
		short i = 0;
		short k = 0;
		short nexti = 0;
		short nextk = 0;
		short p = 0;
		short sh = 0;
		short nextj = 0;
		spritetype s;
		sectortype sc;
		////C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on this variable, so pointers on this variable are left unchanged:
		//walltype* wal = new walltype();

		fricxv = fricyv = 0;

		i = (short)Engine.board.headspritestat[3];
		while (i >= 0)
		{
			nexti = (short)Engine.board.nextspritestat[i];
			s = Engine.board.sprite[i];

			sc = Engine.board.sector[s.sectnum];
			st = s.lotag;
			sh = s.hitag;

			t = hittype[i];

			switch (st)
			{
				case 0:
					{
						int zchange = 0;

						zchange = 0;

						j = s.owner;

						if (Engine.board.sprite[j].lotag == unchecked((short)65535))
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};

						q = sc.extra >> 3;
						l = 0;

						if (sc.lotag == 30)
						{
							q >>= 2;

							if (Engine.board.sprite[i].extra == 1)
							{
								if (hittype[i].tempang < 256)
								{
									hittype[i].tempang += 4;
									if (hittype[i].tempang >= 256)
									{
										callsound(s.sectnum, i);
									}
									if (s.clipdist != 0)
									{
										l = 1;
									}
									else
									{
										l = -1;
									}
								}
								else
								{
									hittype[i].tempang = 256;
								}

								if (sc.floorz > s.z) //z's are touching
								{
									sc.floorz -= 512;
									zchange = -512;
									if (sc.floorz < s.z)
									{
										sc.floorz = s.z;
									}
								}

								else if (sc.floorz < s.z) //z's are touching
								{
									sc.floorz += 512;
									zchange = 512;
									if (sc.floorz > s.z)
									{
										sc.floorz = s.z;
									}
								}
							}
							else if (Engine.board.sprite[i].extra == 3)
							{
								if (hittype[i].tempang > 0)
								{
									hittype[i].tempang -= 4;
									if (hittype[i].tempang <= 0)
									{
										callsound(s.sectnum, i);
									}
									if (s.clipdist != 0)
									{
										l = -1;
									}
									else
									{
										l = 1;
									}
								}
								else
								{
									hittype[i].tempang = 0;
								}

								if (sc.floorz > hittype[i].temp_data[3]) //z's are touching
								{
									sc.floorz -= 512;
									zchange = -512;
									if (sc.floorz < hittype[i].temp_data[3])
									{
										sc.floorz = hittype[i].temp_data[3];
									}
								}

								else if (sc.floorz < hittype[i].temp_data[3]) //z's are touching
								{
									sc.floorz += 512;
									zchange = 512;
									if (sc.floorz > hittype[i].temp_data[3])
									{
										sc.floorz = hittype[i].temp_data[3];
									}
								}
							}

							s.ang += (short)(l * q);
							t.temp_data[2] += (l * q);
						}
						else
						{
							if (hittype[j].count == 0)
							{
								break;
							}
							if (hittype[j].count == 2)
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							};

							if (Engine.board.sprite[j].ang > 1024)
							{
								l = -1;
							}
							else
							{
								l = 1;
							}
							if (t.temp_data[3] == 0)
							{
								t.temp_data[3] = ldist(s, Engine.board.sprite[j]);
							}
							s.xvel = (short)t.temp_data[3];
							s.x = Engine.board.sprite[j].x;
							s.y = Engine.board.sprite[j].y;
							s.ang += (short)(l * q);
							t.temp_data[2] += (l * q);
						}

						if (l != 0 && (sc.floorstat & 64) != 0)
						{
							for (p = connecthead; p >= 0; p = connectpoint2[p])
							{
								if (ps[p].cursectnum == s.sectnum && ps[p].on_ground == 1)
								{

									ps[p].ang += (short)(l * q);
									ps[p].ang &= 2047;

									ps[p].posz += zchange;

									Engine.rotatepoint(Engine.board.sprite[j].x, Engine.board.sprite[j].y, ps[p].posx, ps[p].posy, (short)(q * l), ref m, ref x);

									ps[p].bobposx += m - ps[p].posx;
									ps[p].bobposy += x - ps[p].posy;

									ps[p].posx = m;
									ps[p].posy = x;

									if (Engine.board.sprite[ps[p].i].extra <= 0)
									{
										Engine.board.sprite[ps[p].i].x = m;
										Engine.board.sprite[ps[p].i].y = x;
									}
								}
							}

							p = (short)Engine.board.headspritesect[s.sectnum];
							while (p >= 0)
							{
								if (Engine.board.sprite[p].statnum != 3 && Engine.board.sprite[p].statnum != 4)
								{
									if (Engine.board.sprite[p].picnum != DefineConstants.LASERLINE)
									{
										if (Engine.board.sprite[p].picnum == DefineConstants.APLAYER && Engine.board.sprite[p].owner >= 0)
										{
											p = (short)Engine.board.nextspritesect[p];
											continue;
										}

										Engine.board.sprite[p].ang += (short)(l * q);
										Engine.board.sprite[p].ang &= 2047;

										Engine.board.sprite[p].z += zchange;

										Engine.rotatepoint(Engine.board.sprite[j].x, Engine.board.sprite[j].y, Engine.board.sprite[p].x, Engine.board.sprite[p].y, (short)(q * l), ref Engine.board.sprite[p].x, ref Engine.board.sprite[p].y);

									}
								}
								p = (short)Engine.board.nextspritesect[p];
							}

						}

						ms(i);
					}

					break;
				case 1: //Nothing for now used as the pivot
					if (s.owner == -1) //Init
					{
						s.owner = i;

						j = (short)Engine.board.headspritestat[3];
						while (j >= 0)
						{
							if (Engine.board.sprite[j].lotag == 19 && Engine.board.sprite[j].hitag == sh)
							{
								t[0] = 0;
								break;
							}
							j = (short)Engine.board.nextspritestat[j];
						}
					}

					break;
				case 6:
					k = sc.extra;

					if (t[4] > 0)
					{
						t[4]--;
						if (t[4] >= (k - (k >> 3)))
						{
							s.xvel -= (short)(k >> 5);
						}
						if (t[4] > ((k >> 1) - 1) && t[4] < (k - (k >> 3)))
						{
							s.xvel = 0;
						}
						if (t[4] < (k >> 1))
						{
							s.xvel += (short)(k >> 5);
						}
						if (t[4] < ((k >> 1) - (k >> 3)))
						{
							t[4] = 0;
							s.xvel = k;
						}
					}
					else
					{
						s.xvel = k;
					}

					j = (short)Engine.board.headspritestat[3];
					while (j >= 0)
					{
						if ((Engine.board.sprite[j].lotag == 14) && (sh == Engine.board.sprite[j].hitag) && (hittype[j].count == t[0]))
						{
							Engine.board.sprite[j].xvel = s.xvel;
							//                        if( t[4] == 1 )
							{
								if (hittype[j].temp_data[5] == 0)
								{
									hittype[j].temp_data[5] = dist(Engine.board.sprite[j], s);
								}
								x = pragmas.sgn(dist(Engine.board.sprite[j], s) - hittype[j].temp_data[5]);
								if (Engine.board.sprite[j].extra != 0)
								{
									x = -x;
								}
								s.xvel += (short)x;
							}
							hittype[j].temp_data[4] = t[4];
						}
						j = (short)Engine.board.nextspritestat[j];
					}
					x = 0;

					goto case 14;
				case 14:
					if (s.owner == -1)
					{
						s.owner = LocateTheLocator((short)t[3], (short)t[0]);
					}

					if (s.owner == -1)
					{
						throw new Exception("Could not find any locators for SE# 6 and 14 with a hitag of " + t[3]);
					}

					j = ldist(Engine.board.sprite[s.owner], s);

					if (j < 1024)
					{
						if (st == 6)
						{
							if ((Engine.board.sprite[s.owner].hitag & 1) != 0)
							{
								t[4] = sc.extra; //Slow it down
							}
						}
						t[3]++;
						s.owner = LocateTheLocator((short)t[3], (short)t[0]);
						if (s.owner == -1)
						{
							t[3] = 0;
							s.owner = LocateTheLocator(0, (short)t[0]);
						}
					}

					if (s.xvel != 0)
					{
						x = Engine.getangle(Engine.board.sprite[s.owner].x - s.x, Engine.board.sprite[s.owner].y - s.y);
						q = getincangle(s.ang, (short)x) >> 3;

						t[2] += q;
						s.ang += (short)q;

						if (s.xvel == sc.extra)
						{
							if ((sc.floorstat & 1) == 0 && (sc.ceilingstat & 1) == 0)
							{
								if (Sound[hittype[i].lastvx].num == 0)
								{
									spritesound(hittype[i].lastvx, i);
								}
							}
							else if (ud.monsters_off == 0 && sc.floorpal == 0 && (sc.floorstat & 1) != 0 && ((Engine.krand() >> 8) >= (255 - (8))))
							{
								p = findplayer(s, ref x);
								if (x < 20480)
								{
									j = s.ang;
									s.ang = (short)Engine.getangle(s.x - ps[p].posx, s.y - ps[p].posy);
									shoot(i, DefineConstants.RPG);
									s.ang = (short)j;
								}
							}
						}

						if (s.xvel <= 64 && (sc.floorstat & 1) == 0 && (sc.ceilingstat & 1) == 0)
						{
							stopsound(hittype[i].lastvx);
						}

						if ((sc.floorz - sc.ceilingz) < (108 << 8))
						{
							if (ud.clipping == 0 && s.xvel >= 192)
							{
								for (p = connecthead; p >= 0; p = connectpoint2[p])
								{
									if (Engine.board.sprite[ps[p].i].extra > 0)
									{
										k = ps[p].cursectnum;
										Engine.board.updatesector(ps[p].posx, ps[p].posy, ref k);
										if ((k == -1 && ud.clipping == 0) || (k == s.sectnum && ps[p].cursectnum != s.sectnum))
										{
											ps[p].posx = s.x;
											ps[p].posy = s.y;
											ps[p].cursectnum = s.sectnum;

											Engine.board.setsprite(ps[p].i, s.x, s.y, s.z);
											quickkill(ps[p]);
										}
									}
								}
							}
						}

						m = (s.xvel * Engine.table.sintable[(s.ang + 512) & 2047]) >> 14;
						x = (s.xvel * Engine.table.sintable[s.ang & 2047]) >> 14;

						for (p = connecthead; p >= 0; p = connectpoint2[p])
						{
							if (Engine.board.sector[ps[p].cursectnum].lotag != 2)
							{
								if (po[p].os == s.sectnum)
								{
									po[p].ox += m;
									po[p].oy += x;
								}

								if (s.sectnum == Engine.board.sprite[ps[p].i].sectnum)
								{
									Engine.rotatepoint(s.x, s.y, ps[p].posx, ps[p].posy, (short)q, ref ps[p].posx, ref ps[p].posy);

									ps[p].posx += m;
									ps[p].posy += x;

									ps[p].bobposx += m;
									ps[p].bobposy += x;

									ps[p].ang += (short)q;

									if (numplayers > 1)
									{
										ps[p].oposx = ps[p].posx;
										ps[p].oposy = ps[p].posy;
									}
									if (Engine.board.sprite[ps[p].i].extra <= 0)
									{
										Engine.board.sprite[ps[p].i].x = ps[p].posx;
										Engine.board.sprite[ps[p].i].y = ps[p].posy;
									}
								}
							}
						}
						j = (short)Engine.board.headspritesect[s.sectnum];
						while (j >= 0)
						{
							if (Engine.board.sprite[j].statnum != 10 && Engine.board.sector[Engine.board.sprite[j].sectnum].lotag != 2 && Engine.board.sprite[j].picnum != DefineConstants.SECTOREFFECTOR && Engine.board.sprite[j].picnum != DefineConstants.LOCATORS)
							{
								Engine.rotatepoint(s.x, s.y, Engine.board.sprite[j].x, Engine.board.sprite[j].y, (short)q, ref Engine.board.sprite[j].x, ref Engine.board.sprite[j].y);

								Engine.board.sprite[j].x += m;
								Engine.board.sprite[j].y += x;

								Engine.board.sprite[j].ang += (short)q;

								if (numplayers > 1)
								{
									hittype[j].bposx = Engine.board.sprite[j].x;
									hittype[j].bposy = Engine.board.sprite[j].y;
								}
							}
							j = (short)Engine.board.nextspritesect[j];
						}

						ms(i);
						Engine.board.setsprite(i, s.x, s.y, s.z);

						if ((sc.floorz - sc.ceilingz) < (108 << 8))
						{
							if (ud.clipping == 0 && s.xvel >= 192)
							{
								for (p = connecthead; p >= 0; p = connectpoint2[p])
								{
									if (Engine.board.sprite[ps[p].i].extra > 0)
									{
										k = ps[p].cursectnum;
										Engine.board.updatesector(ps[p].posx, ps[p].posy, ref k);
										if ((k == -1 && ud.clipping == 0) || (k == s.sectnum && ps[p].cursectnum != s.sectnum))
										{
											ps[p].oposx = ps[p].posx = s.x;
											ps[p].oposy = ps[p].posy = s.y;
											ps[p].cursectnum = s.sectnum;

											Engine.board.setsprite(ps[p].i, s.x, s.y, s.z);
											quickkill(ps[p]);
										}
									}
								}
							}

							j = (short)Engine.board.headspritesect[Engine.board.sprite[Engine.board.sprite[i].owner].sectnum];
							while (j >= 0)
							{
								l = (short)Engine.board.nextspritesect[j];
								if (Engine.board.sprite[j].statnum == 1 && badguy(Engine.board.sprite[j]) != 0 && Engine.board.sprite[j].picnum != DefineConstants.SECTOREFFECTOR && Engine.board.sprite[j].picnum != DefineConstants.LOCATORS)
								{
									k = Engine.board.sprite[j].sectnum;
									Engine.board.updatesector(Engine.board.sprite[j].x, Engine.board.sprite[j].y, ref k);
									if (Engine.board.sprite[j].extra >= 0 && k == s.sectnum)
									{
										gutsdir(Engine.board.sprite[j], DefineConstants.JIBS6, 72, myconnectindex);
										spritesound(DefineConstants.SQUISHED, i);
										Engine.board.deletesprite(j);
									}
								}
								j = l;
							}
						}
					}

					break;

				case 30:
					if (s.owner == -1)
					{
						if (t[3] == 1)
							t[3] = 0;
						else
							t[3] = 1;
						s.owner = LocateTheLocator((short)t[3], (short)t[0]);
					}
					else
					{

						if (t[4] == 1) // Starting to go
						{
							if (ldist(Engine.board.sprite[s.owner], s) < (2048 - 128))
							{
								t[4] = 2;
							}
							else
							{
								if (s.xvel == 0)
								{
									int v = 0;
									// jmarshall
									if (t[3] == 0)
										v = 1;
									operateactivators((short)(s.hitag + (v)), -1);
								}
								if (s.xvel < 256)
								{
									s.xvel += 16;
								}
							}
						}
						if (t[4] == 2)
						{
							l = Engine.FindDistance2D(Engine.board.sprite[s.owner].x - s.x, Engine.board.sprite[s.owner].y - s.y);

							if (l <= 128)
							{
								s.xvel = 0;
							}

							if (s.xvel > 0)
							{
								s.xvel -= 16;
							}
							else
							{
								s.xvel = 0;
								operateactivators((short)(s.hitag + (short)t[3]), -1);
								s.owner = -1;
								s.ang += 1024;
								t[4] = 0;
								operateforcefields(i, s.hitag);

								j = (short)Engine.board.headspritesect[s.sectnum];
								while (j >= 0)
								{
									if (Engine.board.sprite[j].picnum != DefineConstants.SECTOREFFECTOR && Engine.board.sprite[j].picnum != DefineConstants.LOCATORS)
									{
										hittype[j].bposx = Engine.board.sprite[j].x;
										hittype[j].bposy = Engine.board.sprite[j].y;
									}
									j = (short)Engine.board.nextspritesect[j];
								}

							}
						}
					}

					if (s.xvel != 0)
					{
						l = (s.xvel * Engine.table.sintable[(s.ang + 512) & 2047]) >> 14;
						x = (s.xvel * Engine.table.sintable[s.ang & 2047]) >> 14;

						if ((sc.floorz - sc.ceilingz) < (108 << 8))
						{
							if (ud.clipping == 0)
							{
								for (p = connecthead; p >= 0; p = connectpoint2[p])
								{
									if (Engine.board.sprite[ps[p].i].extra > 0)
									{
										k = ps[p].cursectnum;
										Engine.board.updatesector(ps[p].posx, ps[p].posy, ref k);
										if ((k == -1 && ud.clipping == 0) || (k == s.sectnum && ps[p].cursectnum != s.sectnum))
										{
											ps[p].posx = s.x;
											ps[p].posy = s.y;
											ps[p].cursectnum = s.sectnum;

											Engine.board.setsprite(ps[p].i, s.x, s.y, s.z);
											quickkill(ps[p]);
										}
									}
								}
							}
						}

						for (p = connecthead; p >= 0; p = connectpoint2[p])
						{
							if (Engine.board.sprite[ps[p].i].sectnum == s.sectnum)
							{
								ps[p].posx += l;
								ps[p].posy += x;

								if (numplayers > 1)
								{
									ps[p].oposx = ps[p].posx;
									ps[p].oposy = ps[p].posy;
								}

								ps[p].bobposx += l;
								ps[p].bobposy += x;
							}

							if (po[p].os == s.sectnum)
							{
								po[p].ox += l;
								po[p].oy += x;
							}
						}

						j = (short)Engine.board.headspritesect[s.sectnum];
						while (j >= 0)
						{
							if (Engine.board.sprite[j].picnum != DefineConstants.SECTOREFFECTOR && Engine.board.sprite[j].picnum != DefineConstants.LOCATORS)
							{
								if (numplayers < 2)
								{
									hittype[j].bposx = Engine.board.sprite[j].x;
									hittype[j].bposy = Engine.board.sprite[j].y;
								}

								Engine.board.sprite[j].x += l;
								Engine.board.sprite[j].y += x;

								if (numplayers > 1)
								{
									hittype[j].bposx = Engine.board.sprite[j].x;
									hittype[j].bposy = Engine.board.sprite[j].y;
								}
							}
							j = (short)Engine.board.nextspritesect[j];
						}

						ms(i);
						Engine.board.setsprite(i, s.x, s.y, s.z);

						if ((sc.floorz - sc.ceilingz) < (108 << 8))
						{
							if (ud.clipping == 0)
							{
								for (p = connecthead; p >= 0; p = connectpoint2[p])
								{
									if (Engine.board.sprite[ps[p].i].extra > 0)
									{
										k = ps[p].cursectnum;
										Engine.board.updatesector(ps[p].posx, ps[p].posy, ref k);
										if ((k == -1 && ud.clipping == 0) || (k == s.sectnum && ps[p].cursectnum != s.sectnum))
										{
											ps[p].posx = s.x;
											ps[p].posy = s.y;

											ps[p].oposx = ps[p].posx;
											ps[p].oposy = ps[p].posy;

											ps[p].cursectnum = s.sectnum;

											Engine.board.setsprite(ps[p].i, s.x, s.y, s.z);
											quickkill(ps[p]);
										}
									}
								}
							}

							j = (short)Engine.board.headspritesect[Engine.board.sprite[Engine.board.sprite[i].owner].sectnum];
							while (j >= 0)
							{
								l = (short)Engine.board.nextspritesect[j];
								if (Engine.board.sprite[j].statnum == 1 && badguy(Engine.board.sprite[j]) != 0 && Engine.board.sprite[j].picnum != DefineConstants.SECTOREFFECTOR && Engine.board.sprite[j].picnum != DefineConstants.LOCATORS)
								{
									{
										//                    if(Engine.board.sprite[j].sectnum != s->sectnum)
										k = Engine.board.sprite[j].sectnum;
										Engine.board.updatesector(Engine.board.sprite[j].x, Engine.board.sprite[j].y, ref k);
										if (Engine.board.sprite[j].extra >= 0 && k == s.sectnum)
										{
											gutsdir(Engine.board.sprite[j], DefineConstants.JIBS6, 24, myconnectindex);
											spritesound(DefineConstants.SQUISHED, (short)j);
											Engine.board.deletesprite(j);
										}
									}

								}
								j = l;
							}
						}
					}

					break;


				case 2: //Quakes
					if (t[4] > 0 && t[0] == 0)
					{
						if (t[4] < sh)
						{
							t[4]++;
						}
						else
						{
							t[0] = 1;
						}
					}

					if (t[0] > 0)
					{
						t[0]++;

						s.xvel = 3;

						if (t[0] > 96)
						{
							t[0] = -1; //Stop the quake
							t[4] = -1;
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							};
						}
						else
						{
							if ((t[0] & 31) == 8)
							{
								earthquaketime = (char)48;
								spritesound(DefineConstants.EARTHQUAKE, ps[screenpeek].i);
							}

							if (pragmas.klabs(sc.floorheinum - t[5]) < 8)
							{
								sc.floorheinum = (short)t[5];
							}
							else
							{
								sc.floorheinum += (short)(pragmas.sgn(t[5] - sc.floorheinum) << 4);
							}
						}

						m = (s.xvel * Engine.table.sintable[(s.ang + 512) & 2047]) >> 14;
						x = (s.xvel * Engine.table.sintable[s.ang & 2047]) >> 14;


						for (p = connecthead; p >= 0; p = connectpoint2[p])
						{
							if (ps[p].cursectnum == s.sectnum && ps[p].on_ground != 0)
							{
								ps[p].posx += m;
								ps[p].posy += x;

								ps[p].bobposx += m;
								ps[p].bobposy += x;
							}
						}

						j = (short)Engine.board.headspritesect[s.sectnum];
						while (j >= 0)
						{
							nextj = (short)Engine.board.nextspritesect[j];

							if (Engine.board.sprite[j].picnum != DefineConstants.SECTOREFFECTOR)
							{
								Engine.board.sprite[j].x += m;
								Engine.board.sprite[j].y += x;
								Engine.board.setsprite((short)j, Engine.board.sprite[j].x, Engine.board.sprite[j].y, Engine.board.sprite[j].z);
							}
							j = nextj;
						}
						ms(i);
						Engine.board.setsprite(i, s.x, s.y, s.z);
					}
					break;

				//Flashing sector lights after reactor EXPLOSION2

				case 3:

					if (t[4] == 0)
					{
						break;
					}
					p = findplayer(s, ref x);

					//    if(t[5] > 0) { t[5]--; break; }

					if ((global_random / (sh + 1) & 31) < 4 && t[2] == 0)
					{
						//       t[5] = 4+(global_random&7);
						sc.ceilingpal = (byte)(s.owner >> 8);
						sc.floorpal = (byte)(s.owner & 0xff);
						t[0] = s.shade + (global_random & 15);
					}
					else
					{
						//       t[5] = 4+(global_random&3);
						sc.ceilingpal = s.pal;
						sc.floorpal = s.pal;
						t[0] = t[3];
					}

					sc.ceilingshade = (sbyte)t[0];
					sc.floorshade = (sbyte)t[0];

					{
						int cc = 0;
						for (x = sc.wallnum; x > 0; x--, cc++)
						{
							walltype wal = Engine.board.wall[sc.wallptr + cc]; // jmarshall
							if (wal.hitag != 1)
							{
								wal.shade = (sbyte)t[0];
								if ((wal.cstat & 2) != 0 && wal.nextwall >= 0)
								{
									Engine.board.wall[wal.nextwall].shade = wal.shade;
								}
							}
						}
					}

					break;

				case 4:

					if ((global_random / (sh + 1) & 31) < 4)
					{
						t[1] = s.shade + (global_random & 15); //Got really bright
						t[0] = s.shade + (global_random & 15);
						sc.ceilingpal = (byte)(s.owner >> 8);
						sc.floorpal = (byte)(s.owner & 0xff);
						j = 1;
					}
					else
					{
						t[1] = t[2];
						t[0] = t[3];

						sc.ceilingpal = s.pal;
						sc.floorpal = s.pal;

						j = 0;
					}

					sc.floorshade = (sbyte)t[1];
					sc.ceilingshade = (sbyte)t[1];

					{
						int cc = 0;
						for (x = sc.wallnum; x > 0; x--, cc++)
						{
							walltype wal = Engine.board.wall[sc.wallptr + cc];
							if (j != 0)
							{
								wal.pal = (byte)(s.owner & 0xff);
							}
							else
							{
								wal.pal = s.pal;
							}

							if (wal.hitag != 1)
							{
								wal.shade = (sbyte)t[0];
								if ((wal.cstat & 2) != 0 && wal.nextwall >= 0)
								{
									Engine.board.wall[wal.nextwall].shade = wal.shade;
								}
							}
						}
					}

					j = (short)Engine.board.headspritesect[Engine.board.sprite[i].sectnum];
					while (j >= 0)
					{
						if ((Engine.board.sprite[j].cstat & 16) != 0)
						{
							if ((sc.ceilingstat & 1) != 0)
							{
								Engine.board.sprite[j].shade = sc.ceilingshade;
							}
							else
							{
								Engine.board.sprite[j].shade = sc.floorshade;
							}
						}

						j = (short)Engine.board.nextspritesect[j];
					}

					if (t[4] != 0)
					{
						Engine.board.deletesprite(i);
						goto BOLT;
					};

					break;

				//BOSS
				case 5:
					p = findplayer(s, ref x);
					if (x < 8192)
					{
						j = s.ang;
						s.ang = (short)Engine.getangle(s.x - ps[p].posx, s.y - ps[p].posy);
						shoot(i, DefineConstants.FIRELASER);
						s.ang = (short)j;
					}

					if (s.owner == -1) //Start search
					{
						t[4] = 0;
						l = 0x7fffffff;
						while (true) //Find the shortest dist
						{
							s.owner = LocateTheLocator((short)t[4], -1); //t[0] hold sectnum

							if (s.owner == -1)
							{
								break;
							}

							m = ldist(Engine.board.sprite[ps[p].i], Engine.board.sprite[s.owner]);

							if (l > m)
							{
								q = s.owner;
								l = m;
							}

							t[4]++;
						}

						s.owner = (short)q;
						s.zvel = (short)(pragmas.ksgn(Engine.board.sprite[q].z - s.z) << 4);
					}

					if (ldist(Engine.board.sprite[s.owner], s) < 1024)
					{
						short ta;
						ta = s.ang;
						s.ang = (short)Engine.getangle(ps[p].posx - s.x, ps[p].posy - s.y);
						s.ang = ta;
						s.owner = -1;
						goto BOLT;

					}
					else
					{
						s.xvel = 256;
					}

					x = Engine.getangle(Engine.board.sprite[s.owner].x - s.x, Engine.board.sprite[s.owner].y - s.y);
					q = getincangle(s.ang, (short)x) >> 3;
					s.ang += (short)q;

					if (((Engine.krand() >> 8) >= (255 - (32))))
					{
						t[2] += q;
						sc.ceilingshade = 127;
					}
					else
					{
						t[2] += getincangle((short)(t[2] + 512), (short)Engine.getangle(ps[p].posx - s.x, ps[p].posy - s.y)) >> 2;
						sc.ceilingshade = 0;
					}
					j = ifhitbyweapon(i);
					if (j >= 0)
					{
						t[3]++;
						if (t[3] == 5)
						{
							s.zvel += 1024;
							FTA(7, ps[myconnectindex]);
						}
					}

					s.z += s.zvel;
					sc.ceilingz += s.zvel;
					Engine.board.sector[t[0]].ceilingz += s.zvel;
					ms(i);
					Engine.board.setsprite(i, s.x, s.y, s.z);
					break;


				case 8:
				case 9:

					// work only if its moving

					j = -1;

					if (hittype[i].temp_data[4] != 0)
					{
						hittype[i].temp_data[4]++;
						if (hittype[i].temp_data[4] > 8)
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
						j = 1;
					}
					else
					{
						j = getanimationgoal(new SectorAnimation(sc, SectorAnimation.SectorAnimType.SECTOR_CEILING_Z));
					}

					if (j >= 0)
					{
						short sn;

						if ((sc.lotag & 0x8000) != 0 || hittype[i].temp_data[4] != 0)
						{
							x = -t[3];
						}
						else
						{
							x = t[3];
						}

						if (st == 9)
						{
							x = -x;
						}

						j = (short)Engine.board.headspritestat[3];
						while (j >= 0)
						{
							if (((Engine.board.sprite[j].lotag) == st) && (Engine.board.sprite[j].hitag) == sh)
							{
								sn = Engine.board.sprite[j].sectnum;
								m = Engine.board.sprite[j].shade;


								int jj = 0;
								for (l = Engine.board.sector[sn].wallnum; l > 0; l--, jj++)
								{
									walltype wal = Engine.board.wall[Engine.board.sector[sn].wallptr + jj];
									if (wal.hitag != 1)
									{
										wal.shade += (sbyte)x;

										if (wal.shade < m)
										{
											wal.shade = (sbyte)m;
										}
										else if (wal.shade > hittype[j].actioncount)
										{
											wal.shade = (sbyte)hittype[j].actioncount;
										}

										if (wal.nextwall >= 0)
										{
											if (Engine.board.wall[wal.nextwall].hitag != 1)
											{
												Engine.board.wall[wal.nextwall].shade = wal.shade;
											}
										}
									}
								}

								Engine.board.sector[sn].floorshade += (sbyte)x;
								Engine.board.sector[sn].ceilingshade += (sbyte)x;

								if (Engine.board.sector[sn].floorshade < m)
								{
									Engine.board.sector[sn].floorshade = (sbyte)m;
								}
								else if (Engine.board.sector[sn].floorshade > hittype[j].count)
								{
									Engine.board.sector[sn].floorshade = (sbyte)hittype[j].count;
								}

								if (Engine.board.sector[sn].ceilingshade < m)
								{
									Engine.board.sector[sn].ceilingshade = (sbyte)m;
								}
								else if (Engine.board.sector[sn].ceilingshade > hittype[j].temp_data[1])
								{
									Engine.board.sector[sn].ceilingshade = (sbyte)hittype[j].temp_data[1];
								}

							}
							j = (short)Engine.board.nextspritestat[j];
						}
					}
					break;
				case 10:

					if ((sc.lotag & 0xff) == 27 || (sc.floorz > sc.ceilingz && (sc.lotag & 0xff) != 23) || sc.lotag == unchecked((short)32791))
					{
						j = 1;

						if ((sc.lotag & 0xff) != 27)
						{
							for (p = connecthead; p >= 0; p = connectpoint2[p])
							{
								if (sc.lotag != 30 && sc.lotag != 31 && sc.lotag != 0)
								{
									if (s.sectnum == Engine.board.sprite[ps[p].i].sectnum)
									{
										j = 0;
									}
								}
							}
						}

						if (j == 1)
						{
							if (t[0] > sh)
							{
								switch (Engine.board.sector[s.sectnum].lotag)
								{
									case 20:
									case 21:
									case 22:
									case 26:
										if (getanimationgoal(new SectorAnimation(Engine.board.sector[s.sectnum], SectorAnimation.SectorAnimType.SECTOR_CEILING_Z)) >= 0)
										{
											break;
										}
                                        activatebysector(s.sectnum, i);
                                        t[0] = 0;
                                        break;
									default:
										activatebysector(s.sectnum, i);
										t[0] = 0;
										break;
								}
							}
							else
							{
								t[0]++;
							}
						}
					}
					else
					{
						t[0] = 0;
					}
					break;
				case 11: //Swingdoor

					if (hittype[i].temp_data[5] > 0)
					{
						hittype[i].temp_data[5]--;
						break;
					}

					if (hittype[i].temp_data[4] != 0)
					{
						short startwall;
						short endwall;

						startwall = sc.wallptr;
						endwall = (short)(startwall + sc.wallnum);

						for (j = startwall; j < endwall; j++)
						{
							k = (short)Engine.board.headspritestat[1];
							while (k >= 0)
							{
								if (Engine.board.sprite[k].extra > 0 && badguy(Engine.board.sprite[k]) != 0 && Engine.board.clipinsidebox(Engine.board.sprite[k].x, Engine.board.sprite[k].y, (short)j, 256) == 1)
								{
									goto BOLT;
								}
								k = (short)Engine.board.nextspritestat[k];
							}

							k = (short)Engine.board.headspritestat[10];
							while (k >= 0)
							{
								if (Engine.board.sprite[k].owner >= 0 && Engine.board.clipinsidebox(Engine.board.sprite[k].x, Engine.board.sprite[k].y, (short)j, 144) == 1)
								{
									hittype[i].temp_data[5] = 8; // Delay
									k = (short)((Engine.board.sprite[i].yvel >> 3) * hittype[i].temp_data[3]);
									hittype[i].temp_data[2] -= k;
									hittype[i].temp_data[4] -= k;
									ms(i);
									Engine.board.setsprite(i, s.x, s.y, s.z);
									goto BOLT;
								}
								k = (short)Engine.board.nextspritestat[k];
							}
						}

						k = (short)((Engine.board.sprite[i].yvel >> 3) * hittype[i].temp_data[3]);
						hittype[i].temp_data[2] += k;
						hittype[i].temp_data[4] += k;
						ms(i);
						Engine.board.setsprite(i, s.x, s.y, s.z);

						if (hittype[i].temp_data[4] <= -511 || hittype[i].temp_data[4] >= 512)
						{
							hittype[i].temp_data[4] = 0;
							hittype[i].temp_data[2] &= unchecked((int)0xffffff00);
							ms(i);
							Engine.board.setsprite(i, s.x, s.y, s.z);
							break;
						}
					}
					break;
				case 12:
					if (t[0] == 3 || t[3] == 1) //Lights going off
					{
						sc.floorpal = 0;
						sc.ceilingpal = 0;

						{
							int cc = 0;
							for (j = sc.wallnum; j > 0; j--, cc++)
							{
								walltype wal = Engine.board.wall[sc.wallptr + cc];
								if (wal.hitag != 1)
								{
									wal.shade = (sbyte)t[1];
									wal.pal = 0;
								}
							}
						}

						sc.floorshade = (sbyte)t[1];
						sc.ceilingshade = (sbyte)t[2];
						t[0] = 0;

						j = (short)Engine.board.headspritesect[Engine.board.sprite[i].sectnum];
						while (j >= 0)
						{
							if ((Engine.board.sprite[j].cstat & 16) != 0)
							{
								if ((sc.ceilingstat & 1) != 0)
								{
									Engine.board.sprite[j].shade = sc.ceilingshade;
								}
								else
								{
									Engine.board.sprite[j].shade = sc.floorshade;
								}
							}
							j = (short)Engine.board.nextspritesect[j];

						}

						if (t[3] == 1)
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
					if (t[0] == 1) //Lights flickering on
					{
						if (sc.floorshade > s.shade)
						{
							sc.floorpal = s.pal;
							sc.ceilingpal = s.pal;

							sc.floorshade -= 2;
							sc.ceilingshade -= 2;


							{
								int cc = 0;
								for (j = sc.wallnum; j > 0; j--, cc++)
								{
									walltype wal = Engine.board.wall[sc.wallptr + cc];
									if (wal.hitag != 1)
									{
										wal.pal = s.pal;
										wal.shade -= 2;
									}
								}
							}
						}
						else
						{
							t[0] = 2;
						}

						j = (short)Engine.board.headspritesect[Engine.board.sprite[i].sectnum];
						while (j >= 0)
						{
							if ((Engine.board.sprite[j].cstat & 16) != 0)
							{
								if ((sc.ceilingstat & 1) != 0)
								{
									Engine.board.sprite[j].shade = sc.ceilingshade;
								}
								else
								{
									Engine.board.sprite[j].shade = sc.floorshade;
								}
							}
							j = (short)Engine.board.nextspritesect[j];
						}
					}
					break;


				case 13:
					if (t[2] != 0)
					{
						j = (Engine.board.sprite[i].yvel << 5) | 1;

						if (s.ang == 512)
						{
							if (s.owner != 0)
							{
								if (pragmas.klabs(t[0] - sc.ceilingz) >= j)
								{
									sc.ceilingz += pragmas.sgn(t[0] - sc.ceilingz) * j;
								}
								else
								{
									sc.ceilingz = t[0];
								}
							}
							else
							{
								if (pragmas.klabs(t[1] - sc.floorz) >= j)
								{
									sc.floorz += pragmas.sgn(t[1] - sc.floorz) * j;
								}
								else
								{
									sc.floorz = t[1];
								}
							}
						}
						else
						{
							if (pragmas.klabs(t[1] - sc.floorz) >= j)
							{
								sc.floorz += pragmas.sgn(t[1] - sc.floorz) * j;
							}
							else
							{
								sc.floorz = t[1];
							}
							if (pragmas.klabs(t[0] - sc.ceilingz) >= j)
							{
								sc.ceilingz += pragmas.sgn(t[0] - sc.ceilingz) * j;
							}
							sc.ceilingz = t[0];
						}

						if (t[3] == 1)
						{
							//Change the shades

							t[3]++;
							sc.ceilingstat ^= 1;

							if (s.ang == 512)
							{
								{
									int cc = 0;									
									for (j = sc.wallnum; j > 0; j--, cc++)
									{
										walltype wal = Engine.board.wall[sc.wallptr + cc];
										wal.shade = s.shade;
									}
								}

								sc.floorshade = s.shade;

								if (ps[0].one_parallax_sectnum >= 0)
								{
									sc.ceilingpicnum = Engine.board.sector[ps[0].one_parallax_sectnum].ceilingpicnum;
									sc.ceilingshade = Engine.board.sector[ps[0].one_parallax_sectnum].ceilingshade;
								}
							}
						}
						t[2]++;
						if (t[2] > 256)
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}


					if (t[2] == 4 && s.ang != 512)
					{
						for (x = 0; x < 7; x++)
						{
							EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
						}
					}
					break;


				case 15:

					if (t[4] != 0)
					{
						s.xvel = 16;

						if (t[4] == 1) //Opening
						{
							if (t[3] >= (Engine.board.sprite[i].yvel >> 3))
							{
								t[4] = 0; //Turn off the sliders
								callsound(s.sectnum, i);
								break;
							}
							t[3]++;
						}
						else if (t[4] == 2)
						{
							if (t[3] < 1)
							{
								t[4] = 0;
								callsound(s.sectnum, i);
								break;
							}
							t[3]--;
						}

						ms(i);
						Engine.board.setsprite(i, s.x, s.y, s.z);
					}
					break;

				case 16: //Reactor

					t[2] += 32;
					if (sc.floorz < sc.ceilingz)
					{
						s.shade = 0;
					}

					else if (sc.ceilingz < t[3])
					{

						//The following code check to see if
						//there is any other sprites in the sector.
						//If there isn't, then kill this sectoreffector
						//itself.....

						j = (short)Engine.board.headspritesect[s.sectnum];
						while (j >= 0)
						{
							if (Engine.board.sprite[j].picnum == DefineConstants.REACTOR || Engine.board.sprite[j].picnum == DefineConstants.REACTOR2)
							{
								break;
							}
							j = (short)Engine.board.nextspritesect[j];
						}
						if (j == -1)
						{
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							};
						}
						else
						{
							s.shade = 1;
						}
					}

					if (s.shade != 0)
					{
						sc.ceilingz += 1024;
					}
					else
					{
						sc.ceilingz -= 512;
					}

					ms(i);
					Engine.board.setsprite(i, s.x, s.y, s.z);

					break;

				case 17:

					q = t[0] * (Engine.board.sprite[i].yvel << 2);

					sc.ceilingz += q;
					sc.floorz += q;

					j = (short)Engine.board.headspritesect[s.sectnum];
					while (j >= 0)
					{
						if (Engine.board.sprite[j].statnum == 10 && Engine.board.sprite[j].owner >= 0)
						{
							p = Engine.board.sprite[j].yvel;
							if (numplayers < 2)
							{
								ps[p].oposz = ps[p].posz;
							}
							ps[p].posz += q;
							ps[p].truefz += q;
							ps[p].truecz += q;
							if (numplayers > 1)
							{
								ps[p].oposz = ps[p].posz;
							}
						}
						if (Engine.board.sprite[j].statnum != 3)
						{
							hittype[j].bposz = Engine.board.sprite[j].z;
							Engine.board.sprite[j].z += q;
						}

						hittype[j].floorz = sc.floorz;
						hittype[j].ceilingz = sc.ceilingz;

						j = (short)Engine.board.nextspritesect[j];
					}

					if (t[0] != 0)
					{
						if (t[0] != 0) //If in motion
						{
							if (pragmas.klabs(sc.floorz - t[2]) <= Engine.board.sprite[i].yvel)
							{
								activatewarpelevators(i, 0);
								break;
							}

							if (t[0] == -1)
							{
								if (sc.floorz > t[3])
								{
									break;
								}
							}
							else if (sc.ceilingz < t[4])
							{
								break;
							}

							if (t[1] == 0)
							{
								break;
							}
							t[1] = 0;

							j = (short)Engine.board.headspritestat[3];
							while (j >= 0)
							{
								if (i != j && (Engine.board.sprite[j].lotag) == 17)
								{
									if ((sc.hitag - t[0]) == (Engine.board.sector[Engine.board.sprite[j].sectnum].hitag) && sh == (Engine.board.sprite[j].hitag))
									{
										break;
									}
								}
								j = (short)Engine.board.nextspritestat[j];
							}

							if (j == -1)
							{
								break;
							}

							k = (short)Engine.board.headspritesect[s.sectnum];
							while (k >= 0)
							{
								nextk = (short)Engine.board.nextspritesect[k];

								if (Engine.board.sprite[k].statnum == 10 && Engine.board.sprite[k].owner >= 0)
								{
									p = Engine.board.sprite[k].yvel;

									ps[p].posx += Engine.board.sprite[j].x - s.x;
									ps[p].posy += Engine.board.sprite[j].y - s.y;
									ps[p].posz = Engine.board.sector[Engine.board.sprite[j].sectnum].floorz - (sc.floorz - ps[p].posz);

									hittype[k].floorz = Engine.board.sector[Engine.board.sprite[j].sectnum].floorz;
									hittype[k].ceilingz = Engine.board.sector[Engine.board.sprite[j].sectnum].ceilingz;

									ps[p].bobposx = ps[p].oposx = ps[p].posx;
									ps[p].bobposy = ps[p].oposy = ps[p].posy;
									ps[p].oposz = ps[p].posz;

									ps[p].truefz = hittype[k].floorz;
									ps[p].truecz = hittype[k].ceilingz;
									ps[p].bobcounter = 0;

									Engine.board.changespritesect(k, Engine.board.sprite[j].sectnum);
									ps[p].cursectnum = Engine.board.sprite[j].sectnum;
								}
								else if (Engine.board.sprite[k].statnum != 3)
								{
									Engine.board.sprite[k].x += Engine.board.sprite[j].x - s.x;
									Engine.board.sprite[k].y += Engine.board.sprite[j].y - s.y;
									Engine.board.sprite[k].z = Engine.board.sector[Engine.board.sprite[j].sectnum].floorz - (sc.floorz - Engine.board.sprite[k].z);

									hittype[k].bposx = Engine.board.sprite[k].x;
									hittype[k].bposy = Engine.board.sprite[k].y;
									hittype[k].bposz = Engine.board.sprite[k].z;

									Engine.board.changespritesect(k, Engine.board.sprite[j].sectnum);
									Engine.board.setsprite(k, Engine.board.sprite[k].x, Engine.board.sprite[k].y, Engine.board.sprite[k].z);

									hittype[k].floorz = Engine.board.sector[Engine.board.sprite[j].sectnum].floorz;
									hittype[k].ceilingz = Engine.board.sector[Engine.board.sprite[j].sectnum].ceilingz;

								}
								k = nextk;
							}
						}
					}
					break;

				case 18:
					if (t[0] != 0)
					{
						if (s.pal != 0)
						{
							if (s.ang == 512)
							{
								sc.ceilingz -= sc.extra;
								if (sc.ceilingz <= t[1])
								{
									sc.ceilingz = t[1];
									{
										Engine.board.deletesprite(i);
										goto BOLT;
									};
								}
							}
							else
							{
								sc.floorz += sc.extra;
								j = (short)Engine.board.headspritesect[s.sectnum];
								while (j >= 0)
								{
									if (Engine.board.sprite[j].picnum == DefineConstants.APLAYER && Engine.board.sprite[j].owner >= 0)
									{
										if (ps[Engine.board.sprite[j].yvel].on_ground == 1)
										{
											ps[Engine.board.sprite[j].yvel].posz += sc.extra;
										}
									}
									if (Engine.board.sprite[j].zvel == 0 && Engine.board.sprite[j].statnum != 3 && Engine.board.sprite[j].statnum != 4)
									{
										hittype[j].bposz = Engine.board.sprite[j].z += sc.extra;
										hittype[j].floorz = sc.floorz;
									}
									j = (short)Engine.board.nextspritesect[j];
								}
								if (sc.floorz >= t[1])
								{
									sc.floorz = t[1];
									{
										Engine.board.deletesprite(i);
										goto BOLT;
									};
								}
							}
						}
						else
						{
							if (s.ang == 512)
							{
								sc.ceilingz += sc.extra;
								if (sc.ceilingz >= s.z)
								{
									sc.ceilingz = s.z;
									{
										Engine.board.deletesprite(i);
										goto BOLT;
									};
								}
							}
							else
							{
								sc.floorz -= sc.extra;
								j = (short)Engine.board.headspritesect[s.sectnum];
								while (j >= 0)
								{
									if (Engine.board.sprite[j].picnum == DefineConstants.APLAYER && Engine.board.sprite[j].owner >= 0)
									{
										if (ps[Engine.board.sprite[j].yvel].on_ground == 1)
										{
											ps[Engine.board.sprite[j].yvel].posz -= sc.extra;
										}
									}
									if (Engine.board.sprite[j].zvel == 0 && Engine.board.sprite[j].statnum != 3 && Engine.board.sprite[j].statnum != 4)
									{
										hittype[j].bposz = Engine.board.sprite[j].z -= sc.extra;
										hittype[j].floorz = sc.floorz;
									}
									j = (short)Engine.board.nextspritesect[j];
								}
								if (sc.floorz <= s.z)
								{
									sc.floorz = s.z;
									{
										Engine.board.deletesprite(i);
										goto BOLT;
									};
								}
							}
						}

						t[2]++;
						if (t[2] >= s.hitag)
						{
							t[2] = 0;
							t[0] = 0;
						}
					}
					break;

				case 19: //Battlestar galactia shields

					if (t[0] != 0)
					{
						if (t[0] == 1)
						{
							t[0]++;
							x = sc.wallptr;
							q = x + sc.wallnum;
							for (j = x; j < q; j++)
							{
								if (Engine.board.wall[j].overpicnum == DefineConstants.BIGFORCE)
								{
									Engine.board.wall[j].cstat &= (128 + 32 + 8 + 4 + 2);
									Engine.board.wall[j].overpicnum = 0;
									if (Engine.board.wall[j].nextwall >= 0)
									{
										Engine.board.wall[Engine.board.wall[j].nextwall].overpicnum = 0;
										Engine.board.wall[Engine.board.wall[j].nextwall].cstat &= (128 + 32 + 8 + 4 + 2);
									}
								}
							}
						}

						if (sc.ceilingz < sc.floorz)
						{
							sc.ceilingz += Engine.board.sprite[i].yvel;
						}
						else
						{
							sc.ceilingz = sc.floorz;

							j = (short)Engine.board.headspritestat[3];
							while (j >= 0)
							{
								if (Engine.board.sprite[j].lotag == 0 && Engine.board.sprite[j].hitag == sh)
								{
									q = Engine.board.sprite[Engine.board.sprite[j].owner].sectnum;
									Engine.board.sector[Engine.board.sprite[j].sectnum].floorpal = Engine.board.sector[Engine.board.sprite[j].sectnum].ceilingpal = Engine.board.sector[q].floorpal;
									Engine.board.sector[Engine.board.sprite[j].sectnum].floorshade = Engine.board.sector[Engine.board.sprite[j].sectnum].ceilingshade = Engine.board.sector[q].floorshade;

									hittype[Engine.board.sprite[j].owner].count = 2;
								}
								j = (short)Engine.board.nextspritestat[j];
							}
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							};
						}
					}
					else //Not hit yet
					{
						j = ifhitsectors(s.sectnum);
						if (j >= 0)
						{
							FTA(8, ps[myconnectindex]);

							l = (short)Engine.board.headspritestat[3];
							while (l >= 0)
							{
								x = Engine.board.sprite[l].lotag & 0x7fff;
								switch (x)
								{
									case 0:
										if (Engine.board.sprite[l].hitag == sh)
										{
											q = Engine.board.sprite[l].sectnum;
											Engine.board.sector[q].floorshade = Engine.board.sector[q].ceilingshade = Engine.board.sprite[Engine.board.sprite[l].owner].shade;
											Engine.board.sector[q].floorpal = Engine.board.sector[q].ceilingpal = Engine.board.sprite[Engine.board.sprite[l].owner].pal;
										}
										break;

									case 1:
									case 12:
									//                                case 18:
									case 19:

										if (sh == Engine.board.sprite[l].hitag)
										{
											if (hittype[l].count == 0)
											{
												hittype[l].count = 1; //Shut them all on
												Engine.board.sprite[l].owner = i;
											}
										}

										break;
								}
								l = (short)Engine.board.nextspritestat[l];
							}
						}
					}

					break;

				case 20: //Extend-o-bridge

					if (t[0] == 0)
					{
						break;
					}
					if (t[0] == 1)
					{
						s.xvel = 8;
					}
					else
					{
						s.xvel = -8;
					}

					if (s.xvel != 0) //Moving
					{
						x = (s.xvel * Engine.table.sintable[(s.ang + 512) & 2047]) >> 14;
						l = (s.xvel * Engine.table.sintable[s.ang & 2047]) >> 14;

						t[3] += s.xvel;

						s.x += x;
						s.y += l;

						if (t[3] <= 0 || (t[3] >> 6) >= (Engine.board.sprite[i].yvel >> 6))
						{
							s.x -= x;
							s.y -= l;
							t[0] = 0;
							callsound(s.sectnum, i);
							break;
						}

						j = (short)Engine.board.headspritesect[s.sectnum];
						while (j >= 0)
						{
							nextj = (short)Engine.board.nextspritesect[j];

							if (Engine.board.sprite[j].statnum != 3 && Engine.board.sprite[j].zvel == 0)
							{
								Engine.board.sprite[j].x += x;
								Engine.board.sprite[j].y += l;
								Engine.board.setsprite((short)j, Engine.board.sprite[j].x, Engine.board.sprite[j].y, Engine.board.sprite[j].z);
								if ((Engine.board.sector[Engine.board.sprite[j].sectnum].floorstat & 2) != 0)
								{
									if (Engine.board.sprite[j].statnum == 2)
									{
										makeitfall((short)j);
									}
								}
							}
							j = nextj;
						}

						Engine.board.dragpoint((short)t[1], Engine.board.wall[t[1]].x + x, Engine.board.wall[t[1]].y + l);
						Engine.board.dragpoint((short)t[2], Engine.board.wall[t[2]].x + x, Engine.board.wall[t[2]].y + l);

						for (p = connecthead; p >= 0; p = connectpoint2[p])
						{
							if (ps[p].cursectnum == s.sectnum && ps[p].on_ground != 0)
							{
								ps[p].posx += x;
								ps[p].posy += l;

								ps[p].oposx = ps[p].posx;
								ps[p].oposy = ps[p].posy;

								Engine.board.setsprite(ps[p].i, ps[p].posx, ps[p].posy, ps[p].posz + (38 << 8));
							}
						}

						sc.floorxpanning -= (byte)(x >> 3);
						sc.floorypanning -= (byte)(l >> 3);

						sc.ceilingxpanning -= (byte)(x >> 3);
						sc.ceilingypanning -= (byte)(l >> 3);
					}

					break;

				case 21: // Cascading effect

					if (t[0] == 0)
					{
						break;
					}

					if (s.ang == 1536)
					{
						l = (int)sc.ceilingz;
					}
					else
					{
						l = (int)sc.floorz;
					}

					if (t[0] == 1) //Decide if the s->sectnum should go up or down
					{
						s.zvel = (short)(pragmas.ksgn(s.z - (int)l) * (Engine.board.sprite[i].yvel << 4));
						t[0]++;
					}

					if (sc.extra == 0)
					{
						l += s.zvel;

						if (pragmas.klabs((int)l - s.z) < 1024)
						{
							l = s.z;
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							}; //All done
						}
					}
					else
					{
						sc.extra--;
					}
					break;

				case 22:

					if (t[1] != 0)
					{
						if (getanimationgoal(new SectorAnimation(Engine.board.sector[t[0]], SectorAnimation.SectorAnimType.SECTOR_CEILING_Z)) >= 0)
						{
							sc.ceilingz += sc.extra * 9;
						}
						else
						{
							t[1] = 0;
						}
					}
					break;

				case 24:
				case 34:

					if (t[4] != 0)
					{
						break;
					}

					x = (Engine.board.sprite[i].yvel * Engine.table.sintable[(s.ang + 512) & 2047]) >> 18;
					l = (Engine.board.sprite[i].yvel * Engine.table.sintable[s.ang & 2047]) >> 18;

					k = 0;

					j = (short)Engine.board.headspritesect[s.sectnum];
					while (j >= 0)
					{
						nextj = (short)Engine.board.nextspritesect[j];
						if (Engine.board.sprite[j].zvel >= 0)
						{
							switch (Engine.board.sprite[j].statnum)
							{
								case 5:
									switch (Engine.board.sprite[j].picnum)
									{
										case DefineConstants.BLOODPOOL:
										case DefineConstants.PUKE:
										case DefineConstants.FOOTPRINTS:
										case DefineConstants.FOOTPRINTS2:
										case DefineConstants.FOOTPRINTS3:
										case DefineConstants.FOOTPRINTS4:
										case DefineConstants.BULLETHOLE:
										case DefineConstants.BLOODSPLAT1:
										case DefineConstants.BLOODSPLAT2:
										case DefineConstants.BLOODSPLAT3:
										case DefineConstants.BLOODSPLAT4:
											Engine.board.sprite[j].xrepeat = Engine.board.sprite[j].yrepeat = 0;
											j = nextj;
											continue;
										case DefineConstants.LASERLINE:
											j = nextj;
											continue;
									}
									goto case 6;
								case 6:
									if (Engine.board.sprite[j].picnum == DefineConstants.TRIPBOMB)
									{
										break;
									}
									goto case 1;
								case 1:
								case 0:
									if (Engine.board.sprite[j].picnum == DefineConstants.BOLT1 || Engine.board.sprite[j].picnum == DefineConstants.BOLT1 + 1 || Engine.board.sprite[j].picnum == DefineConstants.BOLT1 + 2 || Engine.board.sprite[j].picnum == DefineConstants.BOLT1 + 3 || Engine.board.sprite[j].picnum == DefineConstants.SIDEBOLT1 || Engine.board.sprite[j].picnum == DefineConstants.SIDEBOLT1 + 1 || Engine.board.sprite[j].picnum == DefineConstants.SIDEBOLT1 + 2 || Engine.board.sprite[j].picnum == DefineConstants.SIDEBOLT1 + 3 || wallswitchcheck((short)j) != 0)
									{
										break;
									}

									if (!(Engine.board.sprite[j].picnum >= DefineConstants.CRANE && Engine.board.sprite[j].picnum <= (DefineConstants.CRANE + 3)))
									{
										if (Engine.board.sprite[j].z > (hittype[j].floorz - (16 << 8)))
										{
											hittype[j].bposx = Engine.board.sprite[j].x;
											hittype[j].bposy = Engine.board.sprite[j].y;

											Engine.board.sprite[j].x += x >> 2;
											Engine.board.sprite[j].y += l >> 2;

											Engine.board.setsprite((short)j, Engine.board.sprite[j].x, Engine.board.sprite[j].y, Engine.board.sprite[j].z);

											if ((Engine.board.sector[Engine.board.sprite[j].sectnum].floorstat & 2) != 0)
											{
												if (Engine.board.sprite[j].statnum == 2)
												{
													makeitfall((short)j);
												}
											}
										}
									}
									break;
							}
						}
						j = nextj;
					}

					p = myconnectindex;
					if (ps[p].cursectnum == s.sectnum && ps[p].on_ground != 0)
					{
						if (pragmas.klabs(ps[p].posz - ps[p].truefz) < (38 << 8) + (9 << 8))
						{
							fricxv += x << 3;
							fricyv += l << 3;
						}
					}

					sc.floorxpanning += (byte)(Engine.board.sprite[i].yvel >> 7);

					break;

				case 35:
					if (sc.ceilingz > s.z)
					{
						for (j = 0; j < 8; j++)
						{
							s.ang += (short)(Engine.krand() & 511);
							k = spawn(i, DefineConstants.SMALLSMOKE);
							Engine.board.sprite[k].xvel = (short)(96 + (Engine.krand() & 127));
							ssp(k, (uint)(((1) << 16) + 1));
							Engine.board.setsprite(k, Engine.board.sprite[k].x, Engine.board.sprite[k].y, Engine.board.sprite[k].z);
							if (((Engine.krand() >> 8) >= (255 - (16))))
							{
								spawn(i, DefineConstants.EXPLOSION2);
							}
						}
					}

					switch (t[0])
					{
						case 0:
							sc.ceilingz += s.yvel;
							if (sc.ceilingz > sc.floorz)
							{
								sc.floorz = sc.ceilingz;
							}
							if (sc.ceilingz > s.z + (32 << 8))
							{
								t[0]++;
							}
							break;
						case 1:
							sc.ceilingz -= (s.yvel << 2);
							if (sc.ceilingz < t[4])
							{
								sc.ceilingz = t[4];
								t[0] = 0;
							}
							break;
					}
					break;

				case 25: //PISTONS

					if (t[4] == 0)
					{
						break;
					}

					if (sc.floorz <= sc.ceilingz)
					{
						s.shade = 0;
					}
					else if (sc.ceilingz <= t[3])
					{
						s.shade = 1;
					}

					if (s.shade != 0)
					{
						sc.ceilingz += Engine.board.sprite[i].yvel << 4;
						if (sc.ceilingz > sc.floorz)
						{
							sc.ceilingz = sc.floorz;
						}
					}
					else
					{
						sc.ceilingz -= Engine.board.sprite[i].yvel << 4;
						if (sc.ceilingz < t[3])
						{
							sc.ceilingz = t[3];
						}
					}

					break;

				case 26:

					s.xvel = 32;
					l = (s.xvel * Engine.table.sintable[(s.ang + 512) & 2047]) >> 14;
					x = (s.xvel * Engine.table.sintable[s.ang & 2047]) >> 14;

					s.shade++;
					if (s.shade > 7)
					{
						s.x = t[3];
						s.y = t[4];
						sc.floorz -= ((s.zvel * s.shade) - s.zvel);
						s.shade = 0;
					}
					else
					{
						sc.floorz += s.zvel;
					}

					j = (short)Engine.board.headspritesect[s.sectnum];
					while (j >= 0)
					{
						nextj = (short)Engine.board.nextspritesect[j];
						if (Engine.board.sprite[j].statnum != 3 && Engine.board.sprite[j].statnum != 10)
						{
							hittype[j].bposx = Engine.board.sprite[j].x;
							hittype[j].bposy = Engine.board.sprite[j].y;

							Engine.board.sprite[j].x += l;
							Engine.board.sprite[j].y += x;

							Engine.board.sprite[j].z += s.zvel;
							Engine.board.setsprite((short)j, Engine.board.sprite[j].x, Engine.board.sprite[j].y, Engine.board.sprite[j].z);
						}
						j = nextj;
					}

					p = myconnectindex;
					if (Engine.board.sprite[ps[p].i].sectnum == s.sectnum && ps[p].on_ground != 0)
					{
						fricxv += l << 5;
						fricyv += x << 5;
					}

					for (p = connecthead; p >= 0; p = connectpoint2[p])
					{
						if (Engine.board.sprite[ps[p].i].sectnum == s.sectnum && ps[p].on_ground != 0)
						{
							ps[p].posz += s.zvel;
						}
					}

					ms(i);
					Engine.board.setsprite(i, s.x, s.y, s.z);

					break;


				case 27:

					if (ud.recstat == 0)
					{
						break;
					}

					hittype[i].tempang = s.ang;

					p = findplayer(s, ref x);
					if (Engine.board.sprite[ps[p].i].extra > 0 && myconnectindex == screenpeek)
					{
						if (t[0] < 0)
						{
							ud.camerasprite = i;
							t[0]++;
						}
						else if (ud.recstat == 2 && ps[p].newowner == -1)
						{
							if (Engine.board.cansee(s.x, s.y, s.z, Engine.board.sprite[i].sectnum, ps[p].posx, ps[p].posy, ps[p].posz, ps[p].cursectnum))
							{
								if (x < (uint)sh)
								{
									ud.camerasprite = i;
									t[0] = 999;
									s.ang += getincangle(s.ang, (short)((Engine.getangle(ps[p].posx - s.x, ps[p].posy - s.y)) >> 3));
									Engine.board.sprite[i].yvel = (short)(100 + ((s.z - ps[p].posz) / 257));

								}
								else if (t[0] == 999)
								{
									if (ud.camerasprite == i)
									{
										t[0] = 0;
									}
									else
									{
										t[0] = -10;
									}
									ud.camerasprite = i;

								}
							}
							else
							{
								s.ang = (short)Engine.getangle(ps[p].posx - s.x, ps[p].posy - s.y);

								if (t[0] == 999)
								{
									if (ud.camerasprite == i)
									{
										t[0] = 0;
									}
									else
									{
										t[0] = -20;
									}
									ud.camerasprite = i;
								}
							}
						}
					}
					break;
				case 28:
					if (t[5] > 0)
					{
						t[5]--;
						break;
					}

					if (hittype[i].count == 0)
					{
						p = findplayer(s, ref x);
						if (x > 15500)
						{
							break;
						}
						hittype[i].count = 1;
						hittype[i].temp_data[1] = (int)(64 + (Engine.krand() & 511));
						hittype[i].actioncount = 0;
					}
					else
					{
						hittype[i].actioncount++;
						if (hittype[i].actioncount > hittype[i].temp_data[1])
						{
							hittype[i].count = 0;
							ps[screenpeek].visibility = ud.const_visibility;
							break;
						}
						else if (hittype[i].actioncount == (hittype[i].temp_data[1] >> 1))
						{
							spritesound(DefineConstants.THUNDER, i);
						}
						else if (hittype[i].actioncount == (hittype[i].temp_data[1] >> 3))
						{
							spritesound(DefineConstants.LIGHTNING_SLAP, i);
						}
						else if (hittype[i].actioncount == (hittype[i].temp_data[1] >> 2))
						{
							j = (short)Engine.board.headspritestat[0];
							while (j >= 0)
							{
								if (Engine.board.sprite[j].picnum == DefineConstants.NATURALLIGHTNING && Engine.board.sprite[j].hitag == s.hitag)
								{
									Engine.board.sprite[j].cstat |= unchecked((short)32768);
								}
								j = (short)Engine.board.nextspritestat[j];
							}
						}
						else if (hittype[i].actioncount > (hittype[i].temp_data[1] >> 3) && hittype[i].actioncount < (hittype[i].temp_data[1] >> 2))
						{
							if (Engine.board.cansee(s.x, s.y, s.z, s.sectnum, ps[screenpeek].posx, ps[screenpeek].posy, ps[screenpeek].posz, ps[screenpeek].cursectnum))
							{
								j = 1;
							}
							else
							{
								j = 0;
							}

							if (((Engine.krand() >> 8) >= (255 - (192))) && (hittype[i].actioncount & 1) != 0)
							{
								if (j != 0)
								{
									ps[screenpeek].visibility = 0;
								}
							}
							else if (j != 0)
							{
								ps[screenpeek].visibility = ud.const_visibility;
							}

							j = (short)Engine.board.headspritestat[0];
							while (j >= 0)
							{
								if (Engine.board.sprite[j].picnum == DefineConstants.NATURALLIGHTNING && Engine.board.sprite[j].hitag == s.hitag)
								{
									if (((Engine.krand() >> 8) >= (255 - (32))) && (hittype[i].actioncount & 1) != 0)
									{
										Engine.board.sprite[j].cstat &= 32767;
										spawn((short)j, DefineConstants.SMALLSMOKE);

										p = findplayer(s, ref x);
										x = ldist(Engine.board.sprite[ps[p].i], Engine.board.sprite[j]);
										if (x < 768)
										{
											if (Sound[DefineConstants.DUKE_LONGTERM_PAIN].num < 1)
											{
												spritesound(DefineConstants.DUKE_LONGTERM_PAIN, ps[p].i);
											}
											spritesound(DefineConstants.SHORT_CIRCUIT, ps[p].i);
											Engine.board.sprite[ps[p].i].extra -= (short)(8 + (Engine.krand() & 7));
											ps[p].pals_time = 32;
											ps[p].pals[0] = 16;
											ps[p].pals[1] = 0;
											ps[p].pals[2] = 0;
										}
										break;
									}
									else
									{
										Engine.board.sprite[j].cstat |= unchecked((short)32768);
									}
								}

								j = (short)Engine.board.nextspritestat[j];
							}
						}
					}
					break;
				case 29:
					s.hitag += 64;
					l = pragmas.mulscale12((int)s.yvel, Engine.table.sintable[s.hitag & 2047]);
					sc.floorz = s.z + l;
					break;
				case 31: // True Drop Floor
					if (t[0] == 1)
					{
						// Choose dir

						if (t[3] > 0)
						{
							t[3]--;
							break;
						}

						if (t[2] == 1) // Retract
						{
							if (Engine.board.sprite[i].ang != 1536)
							{
								if (pragmas.klabs(sc.floorz - s.z) < Engine.board.sprite[i].yvel)
								{
									sc.floorz = s.z;
									t[2] = 0;
									t[0] = 0;
									t[3] = s.hitag;
									callsound(s.sectnum, i);
								}
								else
								{
									l = pragmas.sgn(s.z - sc.floorz) * Engine.board.sprite[i].yvel;
									sc.floorz += l;

									j = (short)Engine.board.headspritesect[s.sectnum];
									while (j >= 0)
									{
										if (Engine.board.sprite[j].picnum == DefineConstants.APLAYER && Engine.board.sprite[j].owner >= 0)
										{
											if (ps[Engine.board.sprite[j].yvel].on_ground == 1)
											{
												ps[Engine.board.sprite[j].yvel].posz += l;
											}
										}
										if (Engine.board.sprite[j].zvel == 0 && Engine.board.sprite[j].statnum != 3 && Engine.board.sprite[j].statnum != 4)
										{
											hittype[j].bposz = Engine.board.sprite[j].z += l;
											hittype[j].floorz = sc.floorz;
										}
										j = (short)Engine.board.nextspritesect[j];
									}
								}
							}
							else
							{
								if (pragmas.klabs(sc.floorz - t[1]) < Engine.board.sprite[i].yvel)
								{
									sc.floorz = t[1];
									callsound(s.sectnum, i);
									t[2] = 0;
									t[0] = 0;
									t[3] = s.hitag;
								}
								else
								{
									l = pragmas.sgn(t[1] - sc.floorz) * Engine.board.sprite[i].yvel;
									sc.floorz += l;

									j = (short)Engine.board.headspritesect[s.sectnum];
									while (j >= 0)
									{
										if (Engine.board.sprite[j].picnum == DefineConstants.APLAYER && Engine.board.sprite[j].owner >= 0)
										{
											if (ps[Engine.board.sprite[j].yvel].on_ground == 1)
											{
												ps[Engine.board.sprite[j].yvel].posz += l;
											}
										}
										if (Engine.board.sprite[j].zvel == 0 && Engine.board.sprite[j].statnum != 3 && Engine.board.sprite[j].statnum != 4)
										{
											hittype[j].bposz = Engine.board.sprite[j].z += l;
											hittype[j].floorz = sc.floorz;
										}
										j = (short)Engine.board.nextspritesect[j];
									}
								}
							}
							break;
						}

						if ((s.ang & 2047) == 1536)
						{
							if (pragmas.klabs(s.z - sc.floorz) < Engine.board.sprite[i].yvel)
							{
								callsound(s.sectnum, i);
								t[0] = 0;
								t[2] = 1;
								t[3] = s.hitag;
							}
							else
							{
								l = pragmas.sgn(s.z - sc.floorz) * Engine.board.sprite[i].yvel;
								sc.floorz += l;

								j = (short)Engine.board.headspritesect[s.sectnum];
								while (j >= 0)
								{
									if (Engine.board.sprite[j].picnum == DefineConstants.APLAYER && Engine.board.sprite[j].owner >= 0)
									{
										if (ps[Engine.board.sprite[j].yvel].on_ground == 1)
										{
											ps[Engine.board.sprite[j].yvel].posz += l;
										}
									}
									if (Engine.board.sprite[j].zvel == 0 && Engine.board.sprite[j].statnum != 3 && Engine.board.sprite[j].statnum != 4)
									{
										hittype[j].bposz = Engine.board.sprite[j].z += l;
										hittype[j].floorz = sc.floorz;
									}
									j = (short)Engine.board.nextspritesect[j];
								}
							}
						}
						else
						{
							if (pragmas.klabs(sc.floorz - t[1]) < Engine.board.sprite[i].yvel)
							{
								t[0] = 0;
								callsound(s.sectnum, i);
								t[2] = 1;
								t[3] = s.hitag;
							}
							else
							{
								l = pragmas.sgn(s.z - t[1]) * Engine.board.sprite[i].yvel;
								sc.floorz -= l;

								j = (short)Engine.board.headspritesect[s.sectnum];
								while (j >= 0)
								{
									if (Engine.board.sprite[j].picnum == DefineConstants.APLAYER && Engine.board.sprite[j].owner >= 0)
									{
										if (ps[Engine.board.sprite[j].yvel].on_ground == 1)
										{
											ps[Engine.board.sprite[j].yvel].posz -= l;
										}
									}
									if (Engine.board.sprite[j].zvel == 0 && Engine.board.sprite[j].statnum != 3 && Engine.board.sprite[j].statnum != 4)
									{
										hittype[j].bposz = Engine.board.sprite[j].z -= l;
										hittype[j].floorz = sc.floorz;
									}
									j = (short)Engine.board.nextspritesect[j];
								}
							}
						}
					}
					break;

				case 32: // True Drop Ceiling
					if (t[0] == 1)
					{
						// Choose dir

						if (t[2] == 1) // Retract
						{
							if (Engine.board.sprite[i].ang != 1536)
							{
								if (pragmas.klabs(sc.ceilingz - s.z) < (Engine.board.sprite[i].yvel << 1))
								{
									sc.ceilingz = s.z;
									callsound(s.sectnum, i);
									t[2] = 0;
									t[0] = 0;
								}
								else
								{
									sc.ceilingz += pragmas.sgn(s.z - sc.ceilingz) * Engine.board.sprite[i].yvel;
								}
							}
							else
							{
								if (pragmas.klabs(sc.ceilingz - t[1]) < (Engine.board.sprite[i].yvel << 1))
								{
									sc.ceilingz = t[1];
									callsound(s.sectnum, i);
									t[2] = 0;
									t[0] = 0;
								}
								else
								{
									sc.ceilingz += pragmas.sgn(t[1] - sc.ceilingz) * Engine.board.sprite[i].yvel;
								}
							}
							break;
						}

						if ((s.ang & 2047) == 1536)
						{
							if (pragmas.klabs(sc.ceilingz - s.z) < (Engine.board.sprite[i].yvel << 1))
							{
								t[0] = 0;
								if (t[2] == 0)
									t[2] = 1;
								else
									t[2] = 0;
								//t[2] = !t[2];
								callsound(s.sectnum, i);
								sc.ceilingz = s.z;
							}
							else
							{
								sc.ceilingz += pragmas.sgn(s.z - sc.ceilingz) * Engine.board.sprite[i].yvel;
							}
						}
						else
						{
							if (pragmas.klabs(sc.ceilingz - t[1]) < (Engine.board.sprite[i].yvel << 1))
							{
								t[0] = 0;
                                if (t[2] == 0)
                                    t[2] = 1;
                                else
                                    t[2] = 0;
                                callsound(s.sectnum, i);
							}
							else
							{
								sc.ceilingz -= pragmas.sgn(s.z - t[1]) * Engine.board.sprite[i].yvel;
							}
						}
					}
					break;

				case 33:
					if (earthquaketime > 0 && (Engine.krand() & 7) == 0)
					{
						EGS(s.sectnum, s.x + (Engine.krand() & 255) - 128, s.y + (Engine.krand() & 255) - 128, s.z - (8 << 8) - (Engine.krand() & 8191), DefineConstants.SCRAP6 + (Engine.krand() & 15), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (Engine.krand() & 2047), i, 5);
					}
					break;
				case 36:

					if (t[0] != 0)
					{
						if (t[0] == 1)
						{
							shoot(i, sc.extra);
						}
						else if (t[0] == 26 * 5)
						{
							t[0] = 0;
						}
						t[0]++;
					}
					break;

				case 128: //SE to control glass breakage
					{
						walltype wal = Engine.board.wall[t[2]];

						if ((wal.cstat | 32) != 0)
						{
							wal.cstat &= (255 - 32);
							wal.cstat |= 16;
							if (wal.nextwall >= 0)
							{
								Engine.board.wall[wal.nextwall].cstat &= (255 - 32);
								Engine.board.wall[wal.nextwall].cstat |= 16;
							}
						}
						else
						{
							break;
						}

						wal.overpicnum++;
						if (wal.nextwall >= 0)
						{
							Engine.board.wall[wal.nextwall].overpicnum++;
						}

						if (t[0] < t[1])
						{
							t[0]++;
						}
						else
						{
							wal.cstat &= (128 + 32 + 8 + 4 + 2);
							if (wal.nextwall >= 0)
							{
								Engine.board.wall[wal.nextwall].cstat &= (128 + 32 + 8 + 4 + 2);
							}
							{
								Engine.board.deletesprite(i);
								goto BOLT;
							};
						}
					}
                    break;

				case 130:
					if (t[0] > 80)
					{
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
					else
					{
						t[0]++;
					}

					x = sc.floorz - sc.ceilingz;

					if (((Engine.krand() >> 8) >= (255 - (64))))
					{
						k = spawn(i, DefineConstants.EXPLOSION2);
						Engine.board.sprite[k].xrepeat = Engine.board.sprite[k].yrepeat = (byte)(2 + (Engine.krand() & 7));
						Engine.board.sprite[k].z = (int)(sc.floorz - (Engine.krand() % x));
						Engine.board.sprite[k].ang += (short)(256 - (Engine.krand() % 511));
						Engine.board.sprite[k].xvel = (short)(Engine.krand() & 127);
						ssp(k, (uint)(((1) << 16) + 1));
					}
					break;
				case 131:
					if (t[0] > 40)
					{
						{
							Engine.board.deletesprite(i);
							goto BOLT;
						};
					}
					else
					{
						t[0]++;
					}

					x = sc.floorz - sc.ceilingz;

					if (((Engine.krand() >> 8) >= (255 - (32))))
					{
						k = spawn(i, DefineConstants.EXPLOSION2);
						Engine.board.sprite[k].xrepeat = Engine.board.sprite[k].yrepeat = (byte)(2 + (Engine.krand() & 3));
						Engine.board.sprite[k].z = (int)(sc.floorz - (Engine.krand() % x));
						Engine.board.sprite[k].ang += (short)(256 - (Engine.krand() % 511));
						Engine.board.sprite[k].xvel = (short)(Engine.krand() & 127);
						ssp(k, (uint)(((1) << 16) + 1));
					}
					break;
			}
			BOLT:
			i = nexti;
		}

		//Sloped sin-wave floors!
		for (i = (short)Engine.board.headspritestat[3]; i >= 0; i = (short)Engine.board.nextspritestat[i])
		{
			s = Engine.board.sprite[i];
			if (s.lotag != 29)
			{
				continue;
			}
			sc = Engine.board.sector[s.sectnum];
			if (sc.wallnum != 4)
			{
				continue;
			}
			walltype wal = Engine.board.wall[sc.wallptr + 2];
			Engine.board.alignflorslope(s.sectnum, wal.x, wal.y, Engine.board.sector[wal.nextsector].floorz);
		}
	}
}