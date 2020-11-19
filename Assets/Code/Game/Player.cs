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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Build;

public partial class GlobalMembers
{
	public static int turnheldtime; //MED
	public static int lastcontroltime; //MED

	public static void setpal(player_struct p)
	{
		if (p.heat_on != 0)
		{
			p.palette = slimepal;
		}
		else
		{
			switch (Engine.board.sector[p.cursectnum].ceilingpicnum)
			{
				case DefineConstants.FLOORSLIME:
				case DefineConstants.FLOORSLIME + 1:
				case DefineConstants.FLOORSLIME + 2:
					p.palette = slimepal;
					break;
				default:
					if (Engine.board.sector[p.cursectnum].lotag == 2)
					{
						p.palette = waterpal;
					}
					else
					{
						p.palette = Engine.palette.palette;
					}
					break;
			}
		}
		//restorepalette = 1;
	}

	public static void incur_damage(player_struct p)
	{
		int damage = 0;
		int shield_damage = 0;
		short i;
		short damage_source;

		Engine.board.sprite[p.i].extra -= (short)(p.extra_extra8 >> 8);

		damage = Engine.board.sprite[p.i].extra - p.last_extra;

		if (damage < 0)
		{
			p.extra_extra8 = 0;

			if (p.shield_amount > 0)
			{
				shield_damage = (int)(damage * (20 + (Engine.krand() % 30)) / 100);
				damage -= shield_damage;

				p.shield_amount += (short)shield_damage;

				if (p.shield_amount < 0)
				{
					damage += p.shield_amount;
					p.shield_amount = 0;
				}
			}

			Engine.board.sprite[p.i].extra = (short)(p.last_extra + damage);
		}
	}

	public static void forceplayerangle(player_struct p)
	{
		short n;

		n = (short)(128 - (Engine.krand() & 255));

		p.horiz += 64;
		p.return_to_center = (char)9;
		p.look_ang = (short)(n >> 1);
		p.rotscrnang = (short)(n >> 1);
	}

	public static void tracers(int x1, int y1, int z1, int x2, int y2, int z2, int n)
	{
		int i;
		int xv;
		int yv;
		int zv;
		short sect = -1;

		i = n + 1;
		xv = (x2 - x1) / i;
		yv = (y2 - y1) / i;
		zv = (z2 - z1) / i;

		if ((pragmas.klabs(x1 - x2) + pragmas.klabs(y1 - y2)) < 3084)
		{
			return;
		}

		for (i = n; i > 0; i--)
		{
			x1 += xv;
			y1 += yv;
			z1 += zv;
			Engine.board.updatesector(x1, y1, ref sect);
			if (sect >= 0)
			{
				if (Engine.board.sector[sect].lotag == 2)
				{
					EGS(sect, x1, y1, z1, DefineConstants.WATERBUBBLE, -32, (sbyte)(4 + (Engine.krand() & 3)), (sbyte)(4 + (Engine.krand() & 3)), (short)(Engine.krand() & 2047), 0, 0, ps[0].i, 5);
				}
				else
				{
					EGS(sect, x1, y1, z1, DefineConstants.SMALLSMOKE, -32, 14, 14, 0, 0, 0, ps[0].i, 5);
				}
			}
		}
	}

    public static int hits(short i)
    {
        int sx = 0;
        int sy = 0;
        int sz = 0;
        int zoff = 0;
        int sect = 0;
        short hs = 0;
        short hw = 0;

        if (Engine.board.sprite[i].picnum == DefineConstants.APLAYER)
        {
            zoff = (40 << 8);
        }
        else
        {
            zoff = 0;
        }

        Engine.board.hitscan(Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].z - zoff, Engine.board.sprite[i].sectnum, Engine.table.sintable[(Engine.board.sprite[i].ang + 512) & 2047], Engine.table.sintable[Engine.board.sprite[i].ang & 2047], 0, ref sect, ref hw, ref hs, ref sx, ref sy, ref sz, (((256) << 16) + 64));

        return (Engine.FindDistance2D(sx - Engine.board.sprite[i].x, sy - Engine.board.sprite[i].y));
    }


    /*
	long hitaspriteandwall(short i,short *hitsp,short *hitw,short *x, short *y)
	{
	    long sz;
	    short sect;
	
	    Engine.board.hitscan(SX,SY,SZ,SECT,
	        Engine.table.sintable[(SA+512)&2047],
	        Engine.table.sintable[SA&2047],
	        0,&sect,hitw,hitsp,x,y,&sz,CLIPMASK1);
	
	    return ( Engine.FindDistance2D(*x-SX,*y-SY) );
	}
	*/


    public static int hitawall(player_struct p, ref short hitw)
	{
		int sx = 0;
		int sy = 0;
		int sz = 0;
		int sect = 0;
		short hs = 0;

		Engine.board.hitscan(p.posx, p.posy, p.posz, p.cursectnum, Engine.table.sintable[(p.ang + 512) & 2047], Engine.table.sintable[p.ang & 2047], 0, ref sect, ref hitw, ref hs, ref sx, ref sy, ref sz, (((1) << 16) + 1));

		return (Engine.FindDistance2D(sx - p.posx, sy - p.posy));
	}

	public static short aim(spritetype s, short aang)
	{
		bool gotshrinker;
		bool gotfreezer;
		short i;
		short j;
		short a;
		short k;
		bool cans;
		short[] aimstats = { 10, 13, 1, 2 };
		int dx1;
		int dy1;
		int dx2;
		int dy2;
		int dx3;
		int dy3;
		int smax;
		int sdist;
		int xv;
		int yv;

		a = s.ang;

		j = -1;
		//    if(s->picnum == APLAYER && ps[s->yvel].aim_mode) return -1;

		gotshrinker = s.picnum == DefineConstants.APLAYER && ps[s.yvel].curr_weapon == DefineConstants.SHRINKER_WEAPON;
		gotfreezer = s.picnum == DefineConstants.APLAYER && ps[s.yvel].curr_weapon == DefineConstants.FREEZE_WEAPON;

		smax = 0x7fffffff;

		dx1 = Engine.table.sintable[(a + 512 - aang) & 2047];
		dy1 = Engine.table.sintable[(a - aang) & 2047];
		dx2 = Engine.table.sintable[(a + 512 + aang) & 2047];
		dy2 = Engine.table.sintable[(a + aang) & 2047];

		dx3 = Engine.table.sintable[(a + 512) & 2047];
		dy3 = Engine.table.sintable[a & 2047];

		for (k = 0; k < 4; k++)
		{
			if (j >= 0)
			{
				break;
			}
			for (i = (short)Engine.board.headspritestat[aimstats[k]]; i >= 0; i = (short)Engine.board.nextspritestat[i])
			{
				if (Engine.board.sprite[i].xrepeat > 0 && Engine.board.sprite[i].extra >= 0 && (Engine.board.sprite[i].cstat & (257 + 32768)) == 257)
				{
					if (badguy(Engine.board.sprite[i]) != 0 || k < 2)
					{
						if (badguy(Engine.board.sprite[i]) != 0 || Engine.board.sprite[i].picnum == DefineConstants.APLAYER || Engine.board.sprite[i].picnum == DefineConstants.SHARK)
						{
							if (Engine.board.sprite[i].picnum == DefineConstants.APLAYER && ud.coop == 1 && s.picnum == DefineConstants.APLAYER && s != Engine.board.sprite[i])
							{
								continue;
							}

							if (gotshrinker && Engine.board.sprite[i].xrepeat < 30)
							{
								switch (Engine.board.sprite[i].picnum)
								{
									case DefineConstants.SHARK:
										if (Engine.board.sprite[i].xrepeat < 20)
										{
											continue;
										}
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
									default:
										continue;
								}
							}
							if (gotfreezer && Engine.board.sprite[i].pal == 1)
							{
								continue;
							}
						}

						xv = (Engine.board.sprite[i].x - s.x);
						yv = (Engine.board.sprite[i].y - s.y);

						if ((dy1 * xv) <= (dx1 * yv))
						{
							if ((dy2 * xv) >= (dx2 * yv))
							{
								sdist = pragmas.mulscale(dx3, xv, 14) + pragmas.mulscale(dy3, yv, 14);
								if (sdist > 512 && sdist < smax)
								{
									if (s.picnum == DefineConstants.APLAYER)
									{
										if (pragmas.klabs(pragmas.scale(Engine.board.sprite[i].z - s.z, 10, sdist) - (ps[s.yvel].horiz + ps[s.yvel].horizoff - 100)) < 100)
											a = 1;
										else
											a = 0;
									}
									else
									{
										a = 1;
									}

									if (Engine.board.sprite[i].picnum == DefineConstants.ORGANTIC || Engine.board.sprite[i].picnum == DefineConstants.ROTATEGUN)
									{
										cans = Engine.board.cansee(Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].z, Engine.board.sprite[i].sectnum, s.x, s.y, s.z - (32 << 8), s.sectnum);
									}
									else
									{
										cans = Engine.board.cansee(Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].z - (32 << 8), Engine.board.sprite[i].sectnum, s.x, s.y, s.z - (32 << 8), s.sectnum);
									}

									if (a != 0 && cans)
									{
										smax = sdist;
										j = i;
									}
								}
							}
						}
					}
				}
			}
		}

		return j;
	}




	public static void shoot(short i, short atwith)
	{
		short sect = 0;
		int hitsect = 0;
		short hitspr = 0;
		short hitwall = 0;
		short l = 0;
		short sa = 0;
		short p = 0;
		short j = 0;
		short k = 0;
		short scount = 0;
		int sx = 0;
		int sy = 0;
		int sz = 0;
		int vel = 0;
		int zvel = 0;
		int hitx = 0;
		int hity = 0;
		int hitz = 0;
		int x = 0;
		int oldzvel = 0;
		int dal = 0;
		byte sizx = 0;
		byte sizy = 0;
		spritetype s;

		s = Engine.board.sprite[i];
		sect = s.sectnum;
		zvel = 0;

		if (s.picnum == DefineConstants.APLAYER)
		{
			p = s.yvel;

			sx = ps[p].posx;
			sy = ps[p].posy;
			sz = ps[p].posz + ps[p].pyoff + (4 << 8);
			sa = ps[p].ang;

			ps[p].crack_time = 777;

		}
		else
		{
			p = -1;
			sa = s.ang;
			sx = s.x;
			sy = s.y;
			sz = s.z - ((s.yrepeat * Engine.tilesizy[s.picnum]) << 1) + (4 << 8);
			if (s.picnum != DefineConstants.ROTATEGUN)
			{
				sz -= (7 << 8);
				if (badguy(s) != 0 && Engine.board.sprite[i].picnum != DefineConstants.COMMANDER)
				{
					sx += (Engine.table.sintable[(sa + 1024 + 96) & 2047] >> 7);
					sy += (Engine.table.sintable[(sa + 512 + 96) & 2047] >> 7);
				}
			}
		}

		switch (atwith)
		{
			case DefineConstants.BLOODSPLAT1:
			case DefineConstants.BLOODSPLAT2:
			case DefineConstants.BLOODSPLAT3:
			case DefineConstants.BLOODSPLAT4:

				if (p >= 0)
				{
					sa += (short)(64 - (Engine.krand() & 127));
				}
				else
				{
					sa += (short)(1024 + 64 - (Engine.krand() & 127));
				}
				zvel = (short)(1024 - (Engine.krand() & 2047));
				goto case DefineConstants.KNEE;
			case DefineConstants.KNEE:
				if (atwith == DefineConstants.KNEE)
				{
					if (p >= 0)
					{
						zvel = (100 - ps[p].horiz - ps[p].horizoff) << 5;
						sz += (6 << 8);
						sa += 15;
					}
					else
					{
						j = ps[findplayer(s, ref x)].i;
						zvel = ((Engine.board.sprite[j].z - sz) << 8) / (x + 1);
						sa = (short)Engine.getangle(Engine.board.sprite[j].x - sx, Engine.board.sprite[j].y - sy);
					}
				}

				//            writestring(sx,sy,sz,sect,Engine.table.sintable[(sa+512)&2047],Engine.table.sintable[sa&2047],zvel<<6);

				Engine.board.hitscan(sx, sy, sz, sect, Engine.table.sintable[(sa + 512) & 2047], Engine.table.sintable[sa & 2047], zvel << 6, ref hitsect, ref hitwall, ref hitspr, ref hitx, ref hity, ref hitz, (((256) << 16) + 64));

				if (atwith == DefineConstants.BLOODSPLAT1 || atwith == DefineConstants.BLOODSPLAT2 || atwith == DefineConstants.BLOODSPLAT3 || atwith == DefineConstants.BLOODSPLAT4)
				{
					if (Engine.FindDistance2D(sx - hitx, sy - hity) < 1024)
					{
						if (hitwall >= 0 && Engine.board.wall[hitwall].overpicnum != DefineConstants.BIGFORCE)
						{
							if ((Engine.board.wall[hitwall].nextsector >= 0 && hitsect >= 0 && Engine.board.sector[Engine.board.wall[hitwall].nextsector].lotag == 0 && Engine.board.sector[hitsect].lotag == 0 && Engine.board.sector[Engine.board.wall[hitwall].nextsector].lotag == 0 && (Engine.board.sector[hitsect].floorz - Engine.board.sector[Engine.board.wall[hitwall].nextsector].floorz) > (16 << 8)) || (Engine.board.wall[hitwall].nextsector == -1 && Engine.board.sector[hitsect].lotag == 0))
							{
								if ((Engine.board.wall[hitwall].cstat & 16) == 0)
								{
									if (Engine.board.wall[hitwall].nextsector >= 0)
									{
										k = (short)Engine.board.headspritesect[Engine.board.wall[hitwall].nextsector];
										while (k >= 0)
										{
											if (Engine.board.sprite[k].statnum == 3 && Engine.board.sprite[k].lotag == 13)
											{
												return;
											}
											k = (short)Engine.board.nextspritesect[k];
										}
									}

									if (Engine.board.wall[hitwall].nextwall >= 0 && Engine.board.wall[Engine.board.wall[hitwall].nextwall].hitag != 0)
									{
										return;
									}

									if (Engine.board.wall[hitwall].hitag == 0)
									{
										k = spawn(i, atwith);
										Engine.board.sprite[k].xvel = -12;
										Engine.board.sprite[k].ang = (short)(Engine.getangle(Engine.board.wall[hitwall].x - Engine.board.wall[Engine.board.wall[hitwall].point2].x, Engine.board.wall[hitwall].y - Engine.board.wall[Engine.board.wall[hitwall].point2].y) + 512);
										Engine.board.sprite[k].x = hitx;
										Engine.board.sprite[k].y = hity;
										Engine.board.sprite[k].z = hitz;
										Engine.board.sprite[k].cstat |= (short)(Engine.krand() & 4);
										ssp(k, (uint)(((1) << 16) + 1));
										Engine.board.setsprite(k, Engine.board.sprite[k].x, Engine.board.sprite[k].y, Engine.board.sprite[k].z);
										if (Engine.board.sprite[i].picnum == DefineConstants.OOZFILTER || Engine.board.sprite[i].picnum == DefineConstants.NEWBEAST)
										{
											Engine.board.sprite[k].pal = 6;
										}
									}
								}
							}
						}
					}
					return;
				}

				if (hitsect < 0)
				{
					break;
				}

				if ((pragmas.klabs(sx - hitx) + pragmas.klabs(sy - hity)) < 1024)
				{
					if (hitwall >= 0 || hitspr >= 0)
					{
						j = EGS(hitsect, hitx, hity, hitz, DefineConstants.KNEE, -15, 0, 0, sa, 32, 0, i, 4);
						Engine.board.sprite[j].extra += (short)(Engine.krand() & 7);
						if (p >= 0)
						{
							k = spawn(j, DefineConstants.SMALLSMOKE);
							Engine.board.sprite[k].z -= (8 << 8);
							spritesound(DefineConstants.KICK_HIT, j);
						}

						if (p >= 0 && ps[p].steroids_amount > 0 && ps[p].steroids_amount < 400)
						{
							Engine.board.sprite[j].extra += (short)(max_player_health >> 2);
						}

						if (hitspr >= 0 && Engine.board.sprite[hitspr].picnum != DefineConstants.ACCESSSWITCH && Engine.board.sprite[hitspr].picnum != DefineConstants.ACCESSSWITCH2)
						{
							checkhitsprite(hitspr, j);
							if (p >= 0)
							{
								checkhitswitch(p, hitspr, (char)1);
							}
						}

						else if (hitwall >= 0)
						{
							if ((Engine.board.wall[hitwall].cstat & 2) != 0)
							{
								if (Engine.board.wall[hitwall].nextsector >= 0)
								{
									if (hitz >= (Engine.board.sector[Engine.board.wall[hitwall].nextsector].floorz))
									{
										hitwall = Engine.board.wall[hitwall].nextwall;
									}
								}
							}

							if (hitwall >= 0 && Engine.board.wall[hitwall].picnum != DefineConstants.ACCESSSWITCH && Engine.board.wall[hitwall].picnum != DefineConstants.ACCESSSWITCH2)
							{
								checkhitwall(j, hitwall, hitx, hity, hitz, atwith);
								if (p >= 0)
								{
									checkhitswitch(p, hitwall, (char)0);
								}
							}
						}
					}
					else if (p >= 0 && zvel > 0 && Engine.board.sector[hitsect].lotag == 1)
					{
						j = spawn(ps[p].i, DefineConstants.WATERSPLASH2);
						Engine.board.sprite[j].x = hitx;
						Engine.board.sprite[j].y = hity;
						Engine.board.sprite[j].ang = ps[p].ang; // Total tweek
						Engine.board.sprite[j].xvel = 32;
						ssp(i, (uint)(((1) << 16) + 1));
						Engine.board.sprite[j].xvel = 0;

					}
				}

				break;

			case DefineConstants.SHOTSPARK1:
			case DefineConstants.SHOTGUN:
			case DefineConstants.CHAINGUN:

				if (s.extra >= 0)
				{
					s.shade = -96;
				}

				if (p >= 0)
				{
					j = aim(s, DefineConstants.AUTO_AIM_ANGLE);
					if (j >= 0)
					{
						dal = ((Engine.board.sprite[j].xrepeat * Engine.tilesizy[Engine.board.sprite[j].picnum]) << 1) + (5 << 8);
						switch (Engine.board.sprite[j].picnum)
						{
							case DefineConstants.GREENSLIME:
							case DefineConstants.GREENSLIME + 1:
							case DefineConstants.GREENSLIME + 2:
							case DefineConstants.GREENSLIME + 3:
							case DefineConstants.GREENSLIME + 4:
							case DefineConstants.GREENSLIME + 5:
							case DefineConstants.GREENSLIME + 6:
							case DefineConstants.GREENSLIME + 7:
							case DefineConstants.ROTATEGUN:
								dal -= (8 << 8);
								break;
						}
						zvel = ((Engine.board.sprite[j].z - sz - dal) << 8) / ldist(Engine.board.sprite[ps[p].i], Engine.board.sprite[j]);
						sa = (short)Engine.getangle(Engine.board.sprite[j].x - sx, Engine.board.sprite[j].y - sy);
					}

					if (atwith == DefineConstants.SHOTSPARK1)
					{
						if (j == -1)
						{
							sa += (short)(16 - (Engine.krand() & 31));
							zvel = (100 - ps[p].horiz - ps[p].horizoff) << 5;
							zvel += (short)(128 - (Engine.krand() & 255));
						}
					}
					else
					{
						sa += (short)(16 - (Engine.krand() & 31));
						if (j == -1)
						{
							zvel = (100 - ps[p].horiz - ps[p].horizoff) << 5;
						}
						zvel += (short)(128 - (Engine.krand() & 255));
					}
					sz -= (2 << 8);
				}
				else
				{
					j = findplayer(s, ref x);
					sz -= (4 << 8);
					zvel = ((ps[j].posz - sz) << 8) / (ldist(Engine.board.sprite[ps[j].i], s));
					if (s.picnum != DefineConstants.BOSS1)
					{
						zvel += (short)(128 - (Engine.krand() & 255));
						sa += (short)(32 - (Engine.krand() & 63));
					}
					else
					{
						zvel += (short)(128 - (Engine.krand() & 255));
						sa = (short)(Engine.getangle(ps[j].posx - sx, ps[j].posy - sy) + 64 - (Engine.krand() & 127));
					}
				}

				s.cstat &= ~257;
				Engine.board.hitscan(sx, sy, sz, sect, Engine.table.sintable[(sa + 512) & 2047], Engine.table.sintable[sa & 2047], zvel << 6, ref hitsect, ref hitwall, ref hitspr, ref hitx, ref hity, ref hitz, (((256) << 16) + 64));
				s.cstat |= 257;

				if (hitsect < 0)
				{
					return;
				}

				if ((Engine.krand() & 15) == 0 && Engine.board.sector[hitsect].lotag == 2)
				{
					tracers(hitx, hity, hitz, sx, sy, sz, 8 - (ud.multimode >> 1));
				}

				if (p >= 0)
				{
					k = EGS(hitsect, hitx, hity, hitz, DefineConstants.SHOTSPARK1, -15, 10, 10, sa, 0, 0, i, 4);
					//Engine.board.sprite[k].extra = (short)scriptptr.buffer[actorscrptr[atwith]]; // jmarshall - con_integrate
					Engine.board.sprite[k].extra += (short)((Engine.krand() % 6));

					if (hitwall == -1 && hitspr == -1)
					{
						if (zvel < 0)
						{
							if ((Engine.board.sector[hitsect].ceilingstat & 1) != 0)
							{
								Engine.board.sprite[k].xrepeat = 0;
								Engine.board.sprite[k].yrepeat = 0;
								return;
							}
							else
							{
								checkhitceiling((short)hitsect);
							}
						}
						spawn(k, DefineConstants.SMALLSMOKE);
					}

					if (hitspr >= 0)
					{
						checkhitsprite(hitspr, k);
						if (Engine.board.sprite[hitspr].picnum == DefineConstants.APLAYER && (ud.coop != 1 || ud.ffire == 1))
						{
							l = spawn(k, DefineConstants.JIBS6);
							Engine.board.sprite[k].xrepeat = Engine.board.sprite[k].yrepeat = 0;
							Engine.board.sprite[l].z += (4 << 8);
							Engine.board.sprite[l].xvel = 16;
							Engine.board.sprite[l].xrepeat = Engine.board.sprite[l].yrepeat = 24;
							Engine.board.sprite[l].ang += (short)(64 - (Engine.krand() & 127));
						}
						else
						{
							spawn(k, DefineConstants.SMALLSMOKE);
						}

						if (p >= 0 && (Engine.board.sprite[hitspr].picnum == DefineConstants.DIPSWITCH || Engine.board.sprite[hitspr].picnum == DefineConstants.DIPSWITCH + 1 || Engine.board.sprite[hitspr].picnum == DefineConstants.DIPSWITCH2 || Engine.board.sprite[hitspr].picnum == DefineConstants.DIPSWITCH2 + 1 || Engine.board.sprite[hitspr].picnum == DefineConstants.DIPSWITCH3 || Engine.board.sprite[hitspr].picnum == DefineConstants.DIPSWITCH3 + 1 || Engine.board.sprite[hitspr].picnum == DefineConstants.HANDSWITCH || Engine.board.sprite[hitspr].picnum == DefineConstants.HANDSWITCH + 1))
						{
							checkhitswitch(p, hitspr, (char)1);
							return;
						}
					}
					else if (hitwall >= 0)
					{
						spawn(k, DefineConstants.SMALLSMOKE);

						if (isadoorwall(Engine.board.wall[hitwall].picnum))
						{
							goto SKIPBULLETHOLE;
						}
						if (p >= 0 && (Engine.board.wall[hitwall].picnum == DefineConstants.DIPSWITCH || Engine.board.wall[hitwall].picnum == DefineConstants.DIPSWITCH + 1 || Engine.board.wall[hitwall].picnum == DefineConstants.DIPSWITCH2 || Engine.board.wall[hitwall].picnum == DefineConstants.DIPSWITCH2 + 1 || Engine.board.wall[hitwall].picnum == DefineConstants.DIPSWITCH3 || Engine.board.wall[hitwall].picnum == DefineConstants.DIPSWITCH3 + 1 || Engine.board.wall[hitwall].picnum == DefineConstants.HANDSWITCH || Engine.board.wall[hitwall].picnum == DefineConstants.HANDSWITCH + 1))
						{
							checkhitswitch(p, hitwall, (char)0);
							return;
						}

						if (Engine.board.wall[hitwall].hitag != 0 || (Engine.board.wall[hitwall].nextwall >= 0 && Engine.board.wall[Engine.board.wall[hitwall].nextwall].hitag != 0))
						{
							goto SKIPBULLETHOLE;
						}

						if (hitsect >= 0 && Engine.board.sector[hitsect].lotag == 0)
						{
							if (Engine.board.wall[hitwall].overpicnum != DefineConstants.BIGFORCE)
							{
								if ((Engine.board.wall[hitwall].nextsector >= 0 && Engine.board.sector[Engine.board.wall[hitwall].nextsector].lotag == 0) || (Engine.board.wall[hitwall].nextsector == -1 && Engine.board.sector[hitsect].lotag == 0))
								{
									if ((Engine.board.wall[hitwall].cstat & 16) == 0)
									{
										if (Engine.board.wall[hitwall].nextsector >= 0)
										{
											l = (short)Engine.board.headspritesect[Engine.board.wall[hitwall].nextsector];
											while (l >= 0)
											{
												if (Engine.board.sprite[l].statnum == 3 && Engine.board.sprite[l].lotag == 13)
												{
													goto SKIPBULLETHOLE;
												}
												l = (short)Engine.board.nextspritesect[l];
											}
										}

										l = (short)Engine.board.headspritestat[5];
										while (l >= 0)
										{
											if (Engine.board.sprite[l].picnum == DefineConstants.BULLETHOLE)
											{
												if (dist(Engine.board.sprite[l], Engine.board.sprite[k]) < (12 + (Engine.krand() & 7)))
												{
													goto SKIPBULLETHOLE;
												}
											}
											l = (short)Engine.board.nextspritestat[l];
										}
										l = spawn(k, DefineConstants.BULLETHOLE);
										Engine.board.sprite[l].xvel = -1;
										Engine.board.sprite[l].ang = (short)(Engine.getangle(Engine.board.wall[hitwall].x - Engine.board.wall[Engine.board.wall[hitwall].point2].x, Engine.board.wall[hitwall].y - Engine.board.wall[Engine.board.wall[hitwall].point2].y) + 512);
										ssp(l, (uint)(((1) << 16) + 1));
									}
								}
							}
						}

						SKIPBULLETHOLE:

						if ((Engine.board.wall[hitwall].cstat & 2) != 0)
						{
							if (Engine.board.wall[hitwall].nextsector >= 0)
							{
								if (hitz >= (Engine.board.sector[Engine.board.wall[hitwall].nextsector].floorz))
								{
									hitwall = Engine.board.wall[hitwall].nextwall;
								}
							}
						}

						checkhitwall(k, hitwall, hitx, hity, hitz, DefineConstants.SHOTSPARK1);
					}
				}
				else
				{
					k = EGS(hitsect, hitx, hity, hitz, DefineConstants.SHOTSPARK1, -15, 24, 24, sa, 0, 0, i, 4);
					//Engine.board.sprite[k].extra = (short)scriptptr.buffer[actorscrptr[atwith]]; // jmarshall - con_integrate

					if (hitspr >= 0)
					{
						checkhitsprite(hitspr, k);
						if (Engine.board.sprite[hitspr].picnum != DefineConstants.APLAYER)
						{
							spawn(k, DefineConstants.SMALLSMOKE);
						}
						else
						{
							Engine.board.sprite[k].xrepeat = Engine.board.sprite[k].yrepeat = 0;
						}
					}
					else if (hitwall >= 0)
					{
						checkhitwall(k, hitwall, hitx, hity, hitz, DefineConstants.SHOTSPARK1);
					}
				}

				if ((Engine.krand() & 255) < 4)
				{
					xyzsound(DefineConstants.PISTOL_RICOCHET, k, hitx, hity, hitz);
				}

				return;

			case DefineConstants.FIRELASER:
			case DefineConstants.SPIT:
			case DefineConstants.COOLEXPLOSION1:

				if (s.extra >= 0)
				{
					s.shade = -96;
				}

				scount = 1;
				if (atwith == DefineConstants.SPIT)
				{
					vel = 292;
				}
				else
				{
					if (atwith == DefineConstants.COOLEXPLOSION1)
					{
						if (s.picnum == DefineConstants.BOSS2)
						{
							vel = 644;
						}
						else
						{
							vel = 348;
						}
						sz -= (4 << 7);
					}
					else
					{
						vel = 840;
						sz -= (4 << 7);
					}
				}

				if (p >= 0)
				{
					j = aim(s, DefineConstants.AUTO_AIM_ANGLE);

					if (j >= 0)
					{
						dal = ((Engine.board.sprite[j].xrepeat * Engine.tilesizy[Engine.board.sprite[j].picnum]) << 1) - (12 << 8);
						zvel = ((Engine.board.sprite[j].z - sz - dal) * vel) / ldist(Engine.board.sprite[ps[p].i], Engine.board.sprite[j]);
						sa = (short)(Engine.getangle(Engine.board.sprite[j].x - sx, Engine.board.sprite[j].y - sy));
					}
					else
					{
						zvel = (100 - ps[p].horiz - ps[p].horizoff) * 98;
					}
				}
				else
				{
					j = findplayer(s, ref x);
					//                sa = Engine.getangle(ps[j].oposx-sx,ps[j].oposy-sy);
					sa += (short)(16 - (Engine.krand() & 31));
					zvel = (((ps[j].oposz - sz + (3 << 8))) * vel) / ldist(Engine.board.sprite[ps[j].i], s);
				}

				oldzvel = zvel;

				if (atwith == DefineConstants.SPIT)
				{
					sizx = 18;
					sizy = 18;
					sz -= (10 << 8);
				}
				else
				{
					if (atwith == DefineConstants.FIRELASER)
					{
						if (p >= 0)
						{

							sizx = 34;
							sizy = 34;
						}
						else
						{
							sizx = 18;
							sizy = 18;
						}
					}
					else
					{
						sizx = 18;
						sizy = 18;
					}
				}

				if (p >= 0)
				{
					sizx = 7;
					sizy = 7;
				}

				while (scount > 0)
				{
					j = EGS(sect, sx, sy, sz, atwith, -127, (sbyte)sizx, (sbyte)sizy, sa, (short)vel, zvel, i, 4);
					Engine.board.sprite[j].extra += (short)((Engine.krand() & 7));

					if (atwith == DefineConstants.COOLEXPLOSION1)
					{
						Engine.board.sprite[j].shade = 0;
						if (Engine.board.sprite[i].picnum == DefineConstants.BOSS2)
						{
							l = Engine.board.sprite[j].xvel;
							Engine.board.sprite[j].xvel = 1024;
							ssp(j, (uint)(((1) << 16) + 1));
							Engine.board.sprite[j].xvel = l;
							Engine.board.sprite[j].ang += (short)(128 - (Engine.krand() & 255));
						}
					}

					Engine.board.sprite[j].cstat = 128;
					Engine.board.sprite[j].clipdist = 4;

					sa = (short)(s.ang + 32 - (Engine.krand() & 63));
					zvel = (short)(oldzvel + 512 - (Engine.krand() & 1023));

					scount--;
				}

				return;

			case DefineConstants.FREEZEBLAST:
				sz += (3 << 8);
				goto case DefineConstants.RPG;
			case DefineConstants.RPG:

				if (s.extra >= 0)
				{
					s.shade = -96;
				}

				scount = 1;
				vel = 644;

				j = -1;

				if (p >= 0)
				{
					j = aim(s, 48);
					if (j >= 0)
					{
						dal = ((Engine.board.sprite[j].xrepeat * Engine.tilesizy[Engine.board.sprite[j].picnum]) << 1) + (8 << 8);
						zvel = ((Engine.board.sprite[j].z - sz - dal) * vel) / ldist(Engine.board.sprite[ps[p].i], Engine.board.sprite[j]);
						if (Engine.board.sprite[j].picnum != DefineConstants.RECON)
						{
							sa = (short)(Engine.getangle(Engine.board.sprite[j].x - sx, Engine.board.sprite[j].y - sy));
						}
					}
					else
					{
						zvel = (100 - ps[p].horiz - ps[p].horizoff) * 81;
					}
					if (atwith == DefineConstants.RPG)
					{
						spritesound(DefineConstants.RPG_SHOOT, i);
					}

				}
				else
				{
					j = findplayer(s, ref x);
					sa = (short)(Engine.getangle(ps[j].oposx - sx, ps[j].oposy - sy));
					if (Engine.board.sprite[i].picnum == DefineConstants.BOSS3)
					{
						sz -= (32 << 8);
					}
					else if (Engine.board.sprite[i].picnum == DefineConstants.BOSS2)
					{
						vel += 128;
						sz += 24 << 8;
					}

					l = (short)ldist(Engine.board.sprite[ps[j].i], s);
					zvel = ((ps[j].oposz - sz) * vel) / l;

					if (badguy(s) != 0 && (s.hitag & DefineConstants.face_player_smart) != 0)
					{
						sa = (short)(s.ang + (Engine.krand() & 31) - 16);
					}
				}

				if (p >= 0 && j >= 0)
				{
					l = j;
				}
				else
				{
					l = -1;
				}

				j = EGS(sect, sx + (Engine.table.sintable[(348 + sa + 512) & 2047] / 448), sy + (Engine.table.sintable[(sa + 348) & 2047] / 448), sz - (1 << 8), atwith, 0, 14, 14, sa, (short)vel, zvel, i, 4);

				Engine.board.sprite[j].extra += (short)((Engine.krand() & 7));
				if (atwith != DefineConstants.FREEZEBLAST)
				{
					Engine.board.sprite[j].yvel = l;
				}
				else
				{
					Engine.board.sprite[j].yvel = (short)(numfreezebounces);
					Engine.board.sprite[j].xrepeat >>= 1;
					Engine.board.sprite[j].yrepeat >>= 1;
					Engine.board.sprite[j].zvel -= (2 << 4);
				}

				if (p == -1)
				{
					if (Engine.board.sprite[i].picnum == DefineConstants.BOSS3)
					{
						if ((Engine.krand() & 1) != 0)
						{
							Engine.board.sprite[j].x -= Engine.table.sintable[sa & 2047] >> 6;
							Engine.board.sprite[j].y -= Engine.table.sintable[(sa + 1024 + 512) & 2047] >> 6;
							Engine.board.sprite[j].ang -= 8;
						}
						else
						{
							Engine.board.sprite[j].x += Engine.table.sintable[sa & 2047] >> 6;
							Engine.board.sprite[j].y += Engine.table.sintable[(sa + 1024 + 512) & 2047] >> 6;
							Engine.board.sprite[j].ang += 4;
						}
						Engine.board.sprite[j].xrepeat = 42;
						Engine.board.sprite[j].yrepeat = 42;
					}
					else if (Engine.board.sprite[i].picnum == DefineConstants.BOSS2)
					{
						Engine.board.sprite[j].x -= Engine.table.sintable[sa & 2047] / 56;
						Engine.board.sprite[j].y -= Engine.table.sintable[(sa + 1024 + 512) & 2047] / 56;
						Engine.board.sprite[j].ang -= (short)(8 + (Engine.krand() & 255) - 128);
						Engine.board.sprite[j].xrepeat = 24;
						Engine.board.sprite[j].yrepeat = 24;
					}
					else if (atwith != DefineConstants.FREEZEBLAST)
					{
						Engine.board.sprite[j].xrepeat = 30;
						Engine.board.sprite[j].yrepeat = 30;
						Engine.board.sprite[j].extra >>= 2;
					}
				}
				else if (ps[p].curr_weapon == DefineConstants.DEVISTATOR_WEAPON)
				{
					Engine.board.sprite[j].extra >>= 2;
					Engine.board.sprite[j].ang += (short)(16 - (Engine.krand() & 31));
					Engine.board.sprite[j].zvel += (short)(256 - (Engine.krand() & 511));

					if (ps[p].hbomb_hold_delay != 0)
					{
						Engine.board.sprite[j].x -= Engine.table.sintable[sa & 2047] / 644;
						Engine.board.sprite[j].y -= Engine.table.sintable[(sa + 1024 + 512) & 2047] / 644;
					}
					else
					{
						Engine.board.sprite[j].x += Engine.table.sintable[sa & 2047] >> 8;
						Engine.board.sprite[j].y += Engine.table.sintable[(sa + 1024 + 512) & 2047] >> 8;
					}
					Engine.board.sprite[j].xrepeat >>= 1;
					Engine.board.sprite[j].yrepeat >>= 1;
				}

				Engine.board.sprite[j].cstat = 128;
				if (atwith == DefineConstants.RPG)
				{
					Engine.board.sprite[j].clipdist = 4;
				}
				else
				{
					Engine.board.sprite[j].clipdist = 40;
				}

				break;

			case DefineConstants.HANDHOLDINGLASER:

				if (p >= 0)
				{
					zvel = (100 - ps[p].horiz - ps[p].horizoff) * 32;
				}
				else
				{
					zvel = 0;
				}

				Engine.board.hitscan(sx, sy, sz - ps[p].pyoff, sect, Engine.table.sintable[(sa + 512) & 2047], Engine.table.sintable[sa & 2047], zvel << 6, ref hitsect, ref hitwall, ref hitspr, ref hitx, ref hity, ref hitz, (((256) << 16) + 64));

				j = 0;
				if (hitspr >= 0)
				{
					break;
				}

				if (hitwall >= 0 && hitsect >= 0)
				{
					if (((hitx - sx) * (hitx - sx) + (hity - sy) * (hity - sy)) < (290 * 290))
					{
						if (Engine.board.wall[hitwall].nextsector >= 0)
						{
							if (Engine.board.sector[Engine.board.wall[hitwall].nextsector].lotag <= 2 && Engine.board.sector[hitsect].lotag <= 2)
							{
								j = 1;
							}
						}
						else if (Engine.board.sector[hitsect].lotag <= 2)
						{
							j = 1;
						}
					}
				}

				if (j == 1)
				{
					k = EGS(hitsect, hitx, hity, hitz, DefineConstants.TRIPBOMB, -16, 4, 5, sa, 0, 0, i, 6);

					Engine.board.sprite[k].hitag = k;
					spritesound(DefineConstants.LASERTRIP_ONWALL, k);
					Engine.board.sprite[k].xvel = -20;
					ssp(k, (uint)(((1) << 16) + 1));
					Engine.board.sprite[k].cstat = 16;
					hittype[k].temp_data[5] = Engine.board.sprite[k].ang = (short)(Engine.getangle(Engine.board.wall[hitwall].x - Engine.board.wall[Engine.board.wall[hitwall].point2].x, Engine.board.wall[hitwall].y - Engine.board.wall[Engine.board.wall[hitwall].point2].y) - 512);

					if (p >= 0)
					{
						ps[p].ammo_amount[DefineConstants.TRIPBOMB_WEAPON]--;
					}

				}
				return;

			case DefineConstants.BOUNCEMINE:
			case DefineConstants.MORTER:

				if (s.extra >= 0)
				{
					s.shade = -96;
				}

				j = ps[findplayer(s, ref x)].i;
				x = ldist(Engine.board.sprite[j], s);

				zvel = -x >> 1;

				if (zvel < -4096)
				{
					zvel = -2048;
				}
				vel = x >> 4;

				EGS(sect, sx + (Engine.table.sintable[(512 + sa + 512) & 2047] >> 8), sy + (Engine.table.sintable[(sa + 512) & 2047] >> 8), sz + (6 << 8), atwith, -64, 32, 32, sa, (short)vel, zvel, i, 1);
				break;

			case DefineConstants.GROWSPARK:

				if (p >= 0)
				{
					j = aim(s, DefineConstants.AUTO_AIM_ANGLE);
					if (j >= 0)
					{
						dal = ((Engine.board.sprite[j].xrepeat * Engine.tilesizy[Engine.board.sprite[j].picnum]) << 1) + (5 << 8);
						switch (Engine.board.sprite[j].picnum)
						{
							case DefineConstants.GREENSLIME:
							case DefineConstants.GREENSLIME + 1:
							case DefineConstants.GREENSLIME + 2:
							case DefineConstants.GREENSLIME + 3:
							case DefineConstants.GREENSLIME + 4:
							case DefineConstants.GREENSLIME + 5:
							case DefineConstants.GREENSLIME + 6:
							case DefineConstants.GREENSLIME + 7:
							case DefineConstants.ROTATEGUN:
								dal -= (8 << 8);
								break;
						}
						zvel = ((Engine.board.sprite[j].z - sz - dal) << 8) / (ldist(Engine.board.sprite[ps[p].i], Engine.board.sprite[j]));
						sa = (short)(Engine.getangle(Engine.board.sprite[j].x - sx, Engine.board.sprite[j].y - sy));
					}
					else
					{
						sa += (short)(16 - (Engine.krand() & 31));
						zvel = (100 - ps[p].horiz - ps[p].horizoff) << 5;
						zvel += (short)(128 - (Engine.krand() & 255));
					}

					sz -= (2 << 8);
				}
				else
				{
					j = findplayer(s, ref x);
					sz -= (4 << 8);
					zvel = ((ps[j].posz - sz) << 8) / (ldist(Engine.board.sprite[ps[j].i], s));
					zvel += (short)(128 - (Engine.krand() & 255));
					sa += (short)(32 - (Engine.krand() & 63));
				}

				k = 0;

				//            RESHOOTGROW:

				s.cstat &= ~257;
				Engine.board.hitscan(sx, sy, sz, sect, Engine.table.sintable[(sa + 512) & 2047], Engine.table.sintable[sa & 2047], zvel << 6, ref hitsect, ref hitwall, ref hitspr, ref hitx, ref hity, ref hitz, (((256) << 16) + 64));

				s.cstat |= 257;

				j = EGS(sect, hitx, hity, hitz, DefineConstants.GROWSPARK, -16, 28, 28, sa, 0, 0, i, 1);

				Engine.board.sprite[j].pal = 2;
				Engine.board.sprite[j].cstat |= 130;
				Engine.board.sprite[j].xrepeat = Engine.board.sprite[j].yrepeat = 1;

				if (hitwall == -1 && hitspr == -1 && hitsect >= 0)
				{
					if (zvel < 0 && (Engine.board.sector[hitsect].ceilingstat & 1) == 0)
					{
						checkhitceiling((short)hitsect);
					}
				}
				else if (hitspr >= 0)
				{
					checkhitsprite(hitspr, j);
				}
				else if (hitwall >= 0 && Engine.board.wall[hitwall].picnum != DefineConstants.ACCESSSWITCH && Engine.board.wall[hitwall].picnum != DefineConstants.ACCESSSWITCH2)
				{
					/*    if(Engine.board.wall[hitwall].overpicnum == MIRROR && k == 0)
						{
							l = Engine.getangle(
								Engine.board.wall[Engine.board.wall[hitwall].point2].x-Engine.board.wall[hitwall].x,
								Engine.board.wall[Engine.board.wall[hitwall].point2].y-Engine.board.wall[hitwall].y);

							sx = hitx;
							sy = hity;
							sz = hitz;
							sect = hitsect;
							sa = ((l<<1) - sa)&2047;
							sx += Engine.table.sintable[(sa+512)&2047]>>12;
							sy += Engine.table.sintable[sa&2047]>>12;

							k++;
							goto RESHOOTGROW;
						}
						else */
					checkhitwall(j, hitwall, hitx, hity, hitz, atwith);
				}

				break;
			case DefineConstants.SHRINKER:
				if (s.extra >= 0)
				{
					s.shade = -96;
				}
				if (p >= 0)
				{
					j = aim(s, DefineConstants.AUTO_AIM_ANGLE);
					if (j >= 0)
					{
						dal = ((Engine.board.sprite[j].xrepeat * Engine.tilesizy[Engine.board.sprite[j].picnum]) << 1);
						zvel = ((Engine.board.sprite[j].z - sz - dal - (4 << 8)) * 768) / (ldist(Engine.board.sprite[ps[p].i], Engine.board.sprite[j]));
						sa = (short)(Engine.getangle(Engine.board.sprite[j].x - sx, Engine.board.sprite[j].y - sy));
					}
					else
					{
						zvel = (100 - ps[p].horiz - ps[p].horizoff) * 98;
					}
				}
				else if (s.statnum != 3)
				{
					j = findplayer(s, ref x);
					l = (short)ldist(Engine.board.sprite[ps[j].i], s);
					zvel = ((ps[j].oposz - sz) * 512) / l;
				}
				else
				{
					zvel = 0;
				}

				j = EGS(sect, sx + (Engine.table.sintable[(512 + sa + 512) & 2047] >> 12), sy + (Engine.table.sintable[(sa + 512) & 2047] >> 12), sz + (2 << 8), DefineConstants.SHRINKSPARK, -16, 28, 28, sa, 768, zvel, i, 4);

				Engine.board.sprite[j].cstat = 128;
				Engine.board.sprite[j].clipdist = 32;


				return;
		}
		return;
	}



	public static void displayloogie(short snum)
	{
		int i;
		int a;
		int x;
		int y;
		int z;

		if (ps[snum].loogcnt == 0)
		{
			return;
		}

		y = (ps[snum].loogcnt << 2);
		for (i = 0; i < ps[snum].numloogs; i++)
		{
			a = pragmas.klabs(Engine.table.sintable[((ps[snum].loogcnt + i) << 5) & 2047]) >> 5;
			z = 4096 + ((ps[snum].loogcnt + i) << 9);
			x = (-sync[snum].avel) + (Engine.table.sintable[((ps[snum].loogcnt + i) << 6) & 2047] >> 10);

			Engine.rotatesprite((ps[snum].loogiex[i] + x) << 16, (200 + ps[snum].loogiey[i] - y) << 16, z - (i << 8), (short)(256 - a), DefineConstants.LOOGIE, 0, 0, 2, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
	}

	public static char animatefist(short gs, short snum)
	{
		short looking_arc;
		short fisti;
		short fistpal;
		int fistzoom;
		int fistz;

		fisti = ps[snum].fist_incs;
		if (fisti > 32)
		{
			fisti = 32;
		}
		if (fisti <= 0)
		{
			return (char)0;
		}

		looking_arc = (short)(pragmas.klabs(ps[snum].look_ang) / 9);

		fistzoom = 65536 - (Engine.table.sintable[(512 + (fisti << 6)) & 2047] << 2);
		if (fistzoom > 90612)
		{
			fistzoom = 90612;
		}
		if (fistzoom < 40920)
		{
			fistzoom = 40290;
		}
		fistz = 194 + (Engine.table.sintable[((6 + fisti) << 7) & 2047] >> 9);

		if (Engine.board.sprite[ps[snum].i].pal == 1)
		{
			fistpal = 1;
		}
		else
		{
			fistpal = Engine.board.sector[ps[snum].cursectnum].floorpal;
		}

		Engine.rotatesprite((-fisti + 222 + (sync[snum].avel >> 4)) << 16, (looking_arc + fistz) << 16, fistzoom, 0, DefineConstants.FIST, (sbyte)gs, (byte)fistpal, 2, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

		return (char)1;
	}

	public static char animateknee(short gs, short snum)
	{
		short[] knee_y = { 0, -8, -16, -32, -64, -84, -108, -108, -108, -72, -32, -8 };
		short looking_arc;
		short pal;

		if (ps[snum].knee_incs > 11 || ps[snum].knee_incs == 0 || Engine.board.sprite[ps[snum].i].extra <= 0)
		{
			return (char)0;
		}

		looking_arc = (short)(knee_y[ps[snum].knee_incs] + pragmas.klabs(ps[snum].look_ang) / 9);

		looking_arc -= (short)((ps[snum].hard_landing << 3));

		if (Engine.board.sprite[ps[snum].i].pal == 1)
		{
			pal = 1;
		}
		else
		{
			pal = Engine.board.sector[ps[snum].cursectnum].floorpal;
			if (pal == 0)
			{
				pal = (short)(ps[snum].palookup);
			}
		}

		myospal(105 + (sync[snum].avel >> 4) - (ps[snum].look_ang >> 1) + (knee_y[ps[snum].knee_incs] >> 2), looking_arc + 280 - ((ps[snum].horiz - ps[snum].horizoff) >> 4), DefineConstants.KNEE, (sbyte)gs, 4, pal);

		return (char)1;
	}

	public static int animateknuckles(short gs, short snum)
	{
		short[] knuckle_frames = { 0, 1, 2, 2, 3, 3, 3, 2, 2, 1, 0 };
		short looking_arc;
		short pal;

		if (ps[snum].knuckle_incs == 0 || Engine.board.sprite[ps[snum].i].extra <= 0)
		{
			return 0;
		}

// jmarshall - knuckles
/*
		looking_arc = (short)(pragmas.klabs(ps[snum].look_ang) / 9);

		looking_arc -= (short)((ps[snum].hard_landing << 3));

		if (Engine.board.sprite[ps[snum].i].pal == 1)
		{
			pal = 1;
		}
		else
		{
			pal = Engine.board.sector[ps[snum].cursectnum].floorpal;
		}

		myospal(160 + (sync[snum].avel >> 4) - (ps[snum].look_ang >> 1), looking_arc + 180 - ((ps[snum].horiz - ps[snum].horizoff) >> 4), DefineConstants.CRACKKNUCKLES + knuckle_frames[ps[snum].knuckle_incs >> 1], (sbyte)gs, 4, pal);
*/
		return 0;
	}



	public static int lastvisinc;

	public static void displaymasks(short snum)
	{
		short i;
		short p;

		if (Engine.board.sprite[ps[snum].i].pal == 1)
		{
			p = 1;
		}
		else
		{
			p = Engine.board.sector[ps[snum].cursectnum].floorpal;
		}

		if (ps[snum].scuba_on != 0)
		{
			if (ud.screen_size > 4)
			{
				Engine.rotatesprite(43 << 16, (200 - 8 - (Engine.tilesizy[DefineConstants.SCUBAMASK]) << 16), 65536, 0, DefineConstants.SCUBAMASK, 0, (byte)p, 2 + 16, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
				Engine.rotatesprite((320 - 43) << 16, (200 - 8 - (Engine.tilesizy[DefineConstants.SCUBAMASK]) << 16), 65536, 1024, DefineConstants.SCUBAMASK, 0, (byte)p, 2 + 4 + 16, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
			}
			else
			{
				Engine.rotatesprite(43 << 16, (200 - (Engine.tilesizy[DefineConstants.SCUBAMASK]) << 16), 65536, 0, DefineConstants.SCUBAMASK, 0, (byte)p, 2 + 16, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
				Engine.rotatesprite((320 - 43) << 16, (200 - (Engine.tilesizy[DefineConstants.SCUBAMASK]) << 16), 65536, 1024, DefineConstants.SCUBAMASK, 0, (byte)p, 2 + 4 + 16, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
			}
		}
	}

	public static int animatetip(short gs, short snum)
	{
		short p;
		short looking_arc;
		short[] tip_y = { 0, -8, -16, -32, -64, -84, -108, -108, -108, -108, -108, -108, -108, -108, -108, -108, -96, -72, -64, -32, -16 };

		if (ps[snum].tipincs == 0)
		{
			return 0;
		}

		looking_arc = (short)(pragmas.klabs(ps[snum].look_ang) / 9);
		looking_arc -= (short)((ps[snum].hard_landing << 3));

		if (Engine.board.sprite[ps[snum].i].pal == 1)
		{
			p = 1;
		}
		else
		{
			p = Engine.board.sector[ps[snum].cursectnum].floorpal;
		}

		/*    if(ps[snum].access_spritenum >= 0)
				p = Engine.board.sprite[ps[snum].access_spritenum].pal;
			else
				p = Engine.board.wall[ps[snum].access_wallnum].pal;
		  */
		myospal(170 + (sync[snum].avel >> 4) - (ps[snum].look_ang >> 1), (tip_y[ps[snum].tipincs] >> 1) + looking_arc + 240 - ((ps[snum].horiz - ps[snum].horizoff) >> 4), DefineConstants.TIP + ((26 - ps[snum].tipincs) >> 4), (sbyte)gs, 0, p);

		return 1;
	}

	public static int animateaccess(short gs, short snum)
	{
		short[] access_y = { 0, -8, -16, -32, -64, -84, -108, -108, -108, -108, -108, -108, -108, -108, -108, -108, -96, -72, -64, -32, -16 };
		short looking_arc;
		int p;

		if (ps[snum].access_incs == 0 || Engine.board.sprite[ps[snum].i].extra <= 0)
		{
			return 0;
		}

		looking_arc = (short)(access_y[ps[snum].access_incs] + pragmas.klabs(ps[snum].look_ang) / 9);
		looking_arc -= (short)((ps[snum].hard_landing << 3));

		if (ps[snum].access_spritenum >= 0)
		{
			p = (Engine.board.sprite[ps[snum].access_spritenum].pal);
		}
		else
		{
			p = 0;
		}
		//    else
		//        p = Engine.board.wall[ps[snum].access_wallnum].pal;

		if ((ps[snum].access_incs - 3) > 0 && ((ps[snum].access_incs - 3) >> 3) != 0)
		{
			myospal(170 + (sync[snum].avel >> 4) - (ps[snum].look_ang >> 1) + (access_y[ps[snum].access_incs] >> 2), looking_arc + 266 - ((ps[snum].horiz - ps[snum].horizoff) >> 4), DefineConstants.HANDHOLDINGLASER + (ps[snum].access_incs >> 3), (sbyte)gs, 0, p);
		}
		else
		{
			myospal(170 + (sync[snum].avel >> 4) - (ps[snum].look_ang >> 1) + (access_y[ps[snum].access_incs] >> 2), looking_arc + 266 - ((ps[snum].horiz - ps[snum].horizoff) >> 4), DefineConstants.HANDHOLDINGACCESS, (sbyte)gs, 4, p);
		}

		return 1;
	}

	public static short fistsign;

	public static void displayweapon(short snum)
	{
		int gun_pos;
		int looking_arc;
		int cw;
		int weapon_xoffset;
		int i;
		int j;
		int x1;
		int y1;
		int x2;
		char o;
		int pal;
		sbyte gs;
		player_struct p;

		p = ps[snum];

		o = (char)0;

		looking_arc = pragmas.klabs(p.look_ang) / 9;

		gs = Engine.board.sprite[p.i].shade;
		if (gs > 24)
		{
			gs = 24;
		}

		if (p.newowner >= 0 || ud.camerasprite >= 0 || p.over_shoulder_on > 0 || (Engine.board.sprite[p.i].pal != 1 && Engine.board.sprite[p.i].extra <= 0) || animatefist(gs, snum) != 0 || animateknuckles(gs, snum) != 0 || animatetip(gs, snum) != 0 || animateaccess(gs, snum) != 0)
		{
			return;
		}

		animateknee(gs, snum);

		gun_pos = 80 - (p.weapon_pos * p.weapon_pos);

		weapon_xoffset = (160) - 90;
		weapon_xoffset -= (Engine.table.sintable[((p.weapon_sway >> 1) + 512) & 2047] / (1024 + 512));
		weapon_xoffset -= 58 + p.weapon_ang;
		if (Engine.board.sprite[p.i].xrepeat < 32)
		{
			gun_pos -= pragmas.klabs(Engine.table.sintable[(p.weapon_sway << 2) & 2047] >> 9);
		}
		else
		{
			gun_pos -= pragmas.klabs(Engine.table.sintable[(p.weapon_sway >> 1) & 2047] >> 10);
		}

		gun_pos -= (p.hard_landing << 3);

		if (p.last_weapon >= 0)
		{
			cw = p.last_weapon;
		}
		else
		{
			cw = p.curr_weapon;
		}

		j = 14 - p.quick_kick;
		if (j != 14)
		{
			if (Engine.board.sprite[p.i].pal == 1)
			{
				pal = 1;
			}
			else
			{
				pal = Engine.board.sector[p.cursectnum].floorpal;
				if (pal == 0)
				{
					pal = p.palookup;
				}
			}


			if (j < 5 || j > 9)
			{
				myospal(weapon_xoffset + 80 - (p.look_ang >> 1), looking_arc + 250 - gun_pos, DefineConstants.KNEE, gs, o | 4, pal);
			}
			else
			{
				myospal(weapon_xoffset + 160 - 16 - (p.look_ang >> 1), looking_arc + 214 - gun_pos, DefineConstants.KNEE + 1, gs, o | 4, pal);
			}
		}

		if (Engine.board.sprite[p.i].xrepeat < 40)
		{
			if (p.jetpack_on == 0)
			{
				i = Engine.board.sprite[p.i].xvel;
				looking_arc += 32 - (i >> 1);
				fistsign += (short)(i >> 1);
			}
			cw = weapon_xoffset;
			weapon_xoffset += Engine.table.sintable[(fistsign) & 2047] >> 10;
			myos(weapon_xoffset + 250 - (p.look_ang >> 1), looking_arc + 258 - (pragmas.klabs(Engine.table.sintable[(fistsign) & 2047] >> 8)), DefineConstants.FIST, gs, o);
			weapon_xoffset = cw;
			weapon_xoffset -= Engine.table.sintable[(fistsign) & 2047] >> 10;
			myos(weapon_xoffset + 40 - (p.look_ang >> 1), looking_arc + 200 + (pragmas.klabs(Engine.table.sintable[(fistsign) & 2047] >> 8)), DefineConstants.FIST, gs, (char)(o | 4));
		}
		else
		{
			switch (cw)
			{
				case DefineConstants.KNEE_WEAPON:
					if (p.kickback_pic > null)
					{
						if (Engine.board.sprite[p.i].pal == 1)
						{
							pal = 1;
						}
						else
						{
							pal = Engine.board.sector[p.cursectnum].floorpal;
							if (pal == 0)
							{
								pal = p.palookup;
							}
						}

						if (p.kickback_pic < 5 || p.kickback_pic > 9)
						{
							myospal(weapon_xoffset + 220 - (p.look_ang >> 1), looking_arc + 250 - gun_pos, DefineConstants.KNEE, gs, o, pal);
						}
						else
						{
							myospal(weapon_xoffset + 160 - (p.look_ang >> 1), looking_arc + 214 - gun_pos, DefineConstants.KNEE + 1, gs, o, pal);
						}
					}
					break;

				case DefineConstants.TRIPBOMB_WEAPON:
					if (Engine.board.sprite[p.i].pal == 1)
					{
						pal = 1;
					}
					else
					{
						pal = Engine.board.sector[p.cursectnum].floorpal;
					}

					weapon_xoffset += 8;
					gun_pos -= 10;

					if (p.kickback_pic > 6)
					{
						looking_arc += (p.kickback_pic << 3);
					}
					else if (p.kickback_pic < 4)
					{
						myospal(weapon_xoffset + 142 - (p.look_ang >> 1), looking_arc + 234 - gun_pos, DefineConstants.HANDHOLDINGLASER + 3, gs, o, pal);
					}

					myospal(weapon_xoffset + 130 - (p.look_ang >> 1), looking_arc + 249 - gun_pos, DefineConstants.HANDHOLDINGLASER + (p.kickback_pic >> 2), gs, o, pal);
					myospal(weapon_xoffset + 152 - (p.look_ang >> 1), looking_arc + 249 - gun_pos, DefineConstants.HANDHOLDINGLASER + (p.kickback_pic >> 2), gs, o | 4, pal);

					break;

				case DefineConstants.RPG_WEAPON:
					if (Engine.board.sprite[p.i].pal == 1)
					{
						pal = 1;
					}
					else
					{
						pal = Engine.board.sector[p.cursectnum].floorpal;
					}

					weapon_xoffset -= Engine.table.sintable[(768 + (p.kickback_pic << 7)) & 2047] >> 11;
					gun_pos += Engine.table.sintable[(768 + (p.kickback_pic << 7) & 2047)] >> 11;

					if (p.kickback_pic > 0)
					{
						if (p.kickback_pic < 8)
						{
							myospal(weapon_xoffset + 164, (looking_arc << 1) + 176 - gun_pos, DefineConstants.RPGGUN + (p.kickback_pic >> 1), gs, o, pal);
						}
					}

					myospal(weapon_xoffset + 164, (looking_arc << 1) + 176 - gun_pos, DefineConstants.RPGGUN, gs, o, pal);

					break;

				case DefineConstants.SHOTGUN_WEAPON:
					if (Engine.board.sprite[p.i].pal == 1)
					{
						pal = 1;
					}
					else
					{
						pal = Engine.board.sector[p.cursectnum].floorpal;
					}

					weapon_xoffset -= 8;

					switch (p.kickback_pic)
					{
						case 1:
						case 2:
							myospal(weapon_xoffset + 168 - (p.look_ang >> 1), looking_arc + 201 - gun_pos, DefineConstants.SHOTGUN + 2, -128, o, pal);
							goto case 0;
						case 0:
						case 6:
						case 7:
						case 8:
							myospal(weapon_xoffset + 146 - (p.look_ang >> 1), looking_arc + 202 - gun_pos, DefineConstants.SHOTGUN, gs, o, pal);
							break;
						case 3:
						case 4:
						case 5:
						case 9:
						case 10:
						case 11:
						case 12:
							if (p.kickback_pic > 1 && p.kickback_pic < 5)
							{
								gun_pos -= 40;
								weapon_xoffset += 20;

								myospal(weapon_xoffset + 178 - (p.look_ang >> 1), looking_arc + 194 - gun_pos, DefineConstants.SHOTGUN + 1 + (((p.kickback_pic) - 1) >> 1), -128, o, pal);
							}

							myospal(weapon_xoffset + 158 - (p.look_ang >> 1), looking_arc + 220 - gun_pos, DefineConstants.SHOTGUN + 3, gs, o, pal);

							break;
						case 13:
						case 14:
						case 15:
							myospal(32 + weapon_xoffset + 166 - (p.look_ang >> 1), looking_arc + 210 - gun_pos, DefineConstants.SHOTGUN + 4, gs, o, pal);
							break;
						case 16:
						case 17:
						case 18:
						case 19:
							myospal(64 + weapon_xoffset + 170 - (p.look_ang >> 1), looking_arc + 196 - gun_pos, DefineConstants.SHOTGUN + 5, gs, o, pal);
							break;
						case 20:
						case 21:
						case 22:
						case 23:
							myospal(64 + weapon_xoffset + 176 - (p.look_ang >> 1), looking_arc + 196 - gun_pos, DefineConstants.SHOTGUN + 6, gs, o, pal);
							break;
						case 24:
						case 25:
						case 26:
						case 27:
							myospal(64 + weapon_xoffset + 170 - (p.look_ang >> 1), looking_arc + 196 - gun_pos, DefineConstants.SHOTGUN + 5, gs, o, pal);
							break;
						case 28:
						case 29:
						case 30:
							myospal(32 + weapon_xoffset + 156 - (p.look_ang >> 1), looking_arc + 206 - gun_pos, DefineConstants.SHOTGUN + 4, gs, o, pal);
							break;
					}
					break;



				case DefineConstants.CHAINGUN_WEAPON:
					if (Engine.board.sprite[p.i].pal == 1)
					{
						pal = 1;
					}
					else
					{
						pal = Engine.board.sector[p.cursectnum].floorpal;
					}

					if (p.kickback_pic > 0)
					{
						gun_pos -= Engine.table.sintable[p.kickback_pic << 7] >> 12;
					}

					if (p.kickback_pic > 0 && Engine.board.sprite[p.i].pal != 1)
					{
						weapon_xoffset += (short)(1 - (Engine.krand() & 3));
					}

					myospal(weapon_xoffset + 168 - (p.look_ang >> 1), looking_arc + 260 - gun_pos, DefineConstants.CHAINGUN, gs, o, pal);
					switch (p.kickback_pic)
					{
						case 0:
							myospal(weapon_xoffset + 178 - (p.look_ang >> 1), looking_arc + 233 - gun_pos, DefineConstants.CHAINGUN + 1, gs, o, pal);
							break;
						default:
							if (p.kickback_pic > 4 && p.kickback_pic < 12)
							{
								i = 0;
								if (Engine.board.sprite[p.i].pal != 1)
								{
									i = (short)(Engine.krand() & 7);
								}
								myospal(i + weapon_xoffset - 4 + 140 - (p.look_ang >> 1), i + looking_arc - (p.kickback_pic >> 1) + 208 - gun_pos, DefineConstants.CHAINGUN + 5 + ((p.kickback_pic - 4) / 5), gs, o, pal);
								if (Engine.board.sprite[p.i].pal != 1)
								{
									i = (short)(Engine.krand() & 7);
								}
								myospal(i + weapon_xoffset - 4 + 184 - (p.look_ang >> 1), i + looking_arc - (p.kickback_pic >> 1) + 208 - gun_pos, DefineConstants.CHAINGUN + 5 + ((p.kickback_pic - 4) / 5), gs, o, pal);
							}
							if (p.kickback_pic < 8)
							{
								i = (short)(Engine.krand() & 7);
								myospal(i + weapon_xoffset - 4 + 162 - (p.look_ang >> 1), i + looking_arc - (p.kickback_pic >> 1) + 208 - gun_pos, DefineConstants.CHAINGUN + 5 + ((p.kickback_pic - 2) / 5), gs, o, pal);
								myospal(weapon_xoffset + 178 - (p.look_ang >> 1), looking_arc + 233 - gun_pos, DefineConstants.CHAINGUN + 1 + (p.kickback_pic >> 1), gs, o, pal);
							}
							else
							{
								myospal(weapon_xoffset + 178 - (p.look_ang >> 1), looking_arc + 233 - gun_pos, DefineConstants.CHAINGUN + 1, gs, o, pal);
							}
							break;
					}
					break;
				case DefineConstants.PISTOL_WEAPON:
					if (Engine.board.sprite[p.i].pal == 1)
					{
						pal = 1;
					}
					else
					{
						pal = Engine.board.sector[p.cursectnum].floorpal;
					}

					if (p.kickback_pic < 5)
					{
						short[] kb_frames = { 0, 1, 2, 0, 0 };
						short l;

						l = (short)(195 - 12 + weapon_xoffset);

						if (p.kickback_pic == 2)
						{
							l -= 3;
						}
						myospal((l - (p.look_ang >> 1)), (looking_arc + 244 - gun_pos), DefineConstants.FIRSTGUN + kb_frames[p.kickback_pic], gs, 2, pal);
					}
					else
					{
						if (p.kickback_pic < 10)
						{
							myospal(194 - (p.look_ang >> 1), looking_arc + 230 - gun_pos, DefineConstants.FIRSTGUN + 4, gs, o, pal);
						}
						else if (p.kickback_pic < 15)
						{
							myospal(244 - (p.kickback_pic << 3) - (p.look_ang >> 1), looking_arc + 130 - gun_pos + (p.kickback_pic << 4), DefineConstants.FIRSTGUN + 6, gs, o, pal);
							myospal(224 - (p.look_ang >> 1), looking_arc + 220 - gun_pos, DefineConstants.FIRSTGUN + 5, gs, o, pal);
						}
						else if (p.kickback_pic < 20)
						{
							myospal(124 + (p.kickback_pic << 1) - (p.look_ang >> 1), looking_arc + 430 - gun_pos - (p.kickback_pic << 3), DefineConstants.FIRSTGUN + 6, gs, o, pal);
							myospal(224 - (p.look_ang >> 1), looking_arc + 220 - gun_pos, DefineConstants.FIRSTGUN + 5, gs, o, pal);
						}
						else if (p.kickback_pic < 23)
						{
							myospal(184 - (p.look_ang >> 1), looking_arc + 235 - gun_pos, DefineConstants.FIRSTGUN + 8, gs, o, pal);
							myospal(224 - (p.look_ang >> 1), looking_arc + 210 - gun_pos, DefineConstants.FIRSTGUN + 5, gs, o, pal);
						}
						else if (p.kickback_pic < 25)
						{
							myospal(164 - (p.look_ang >> 1), looking_arc + 245 - gun_pos, DefineConstants.FIRSTGUN + 8, gs, o, pal);
							myospal(224 - (p.look_ang >> 1), looking_arc + 220 - gun_pos, DefineConstants.FIRSTGUN + 5, gs, o, pal);
						}
						else if (p.kickback_pic < 27)
						{
							myospal(194 - (p.look_ang >> 1), looking_arc + 235 - gun_pos, DefineConstants.FIRSTGUN + 5, gs, o, pal);
						}
					}

					break;
				case DefineConstants.HANDBOMB_WEAPON:
					{
						if (Engine.board.sprite[p.i].pal == 1)
						{
							pal = 1;
						}
						else
						{
							pal = Engine.board.sector[p.cursectnum].floorpal;
						}

						if (p.kickback_pic != 0)
						{
							int[] throw_frames = { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2 };

							if (p.kickback_pic < 7)
							{
								gun_pos -= 10 * p.kickback_pic; //D
							}
							else if (p.kickback_pic < 12)
							{
								gun_pos += 20 * (p.kickback_pic - 10); //U
							}
							else if (p.kickback_pic < 20)
							{
								gun_pos -= 9 * (p.kickback_pic - 14); //D
							}

							myospal(weapon_xoffset + 190 - (p.look_ang >> 1), looking_arc + 250 - gun_pos, DefineConstants.HANDTHROW + throw_frames[p.kickback_pic], gs, o, pal);
						}
						else
						{
							myospal(weapon_xoffset + 190 - (p.look_ang >> 1), looking_arc + 260 - gun_pos, DefineConstants.HANDTHROW, gs, o, pal);
						}
					}
					break;

				case DefineConstants.HANDREMOTE_WEAPON:
					{
						sbyte[] remote_frames = { 0, 1, 1, 2, 1, 1, 0, 0, 0, 0, 0 };
						if (Engine.board.sprite[p.i].pal == 1)
						{
							pal = 1;
						}
						else
						{
							pal = Engine.board.sector[p.cursectnum].floorpal;
						}

						weapon_xoffset = -48;

						if (p.kickback_pic != 0)
						{
							myospal(weapon_xoffset + 150 - (p.look_ang >> 1), looking_arc + 258 - gun_pos, DefineConstants.HANDREMOTE + remote_frames[p.kickback_pic], gs, o, pal);
						}
						else
						{
							myospal(weapon_xoffset + 150 - (p.look_ang >> 1), looking_arc + 258 - gun_pos, DefineConstants.HANDREMOTE, gs, o, pal);
						}
					}
					break;
				case DefineConstants.DEVISTATOR_WEAPON:
					if (Engine.board.sprite[p.i].pal == 1)
					{
						pal = 1;
					}
					else
					{
						pal = Engine.board.sector[p.cursectnum].floorpal;
					}

					if (p.kickback_pic != 0)
					{
						int[] cycloidy = { 0, 4, 12, 24, 12, 4, 0 };

						i = pragmas.sgn(p.kickback_pic >> 2);

						if (p.hbomb_hold_delay != 0)
						{
							myospal((cycloidy[p.kickback_pic] >> 1) + weapon_xoffset + 268 - (p.look_ang >> 1), cycloidy[p.kickback_pic] + looking_arc + 238 - gun_pos, DefineConstants.DEVISTATOR + i, -32, o, pal);
							myospal(weapon_xoffset + 30 - (p.look_ang >> 1), looking_arc + 240 - gun_pos, DefineConstants.DEVISTATOR, gs, o | 4, pal);
						}
						else
						{
							myospal(-(cycloidy[p.kickback_pic] >> 1) + weapon_xoffset + 30 - (p.look_ang >> 1), cycloidy[p.kickback_pic] + looking_arc + 240 - gun_pos, DefineConstants.DEVISTATOR + i, -32, o | 4, pal);
							myospal(weapon_xoffset + 268 - (p.look_ang >> 1), looking_arc + 238 - gun_pos, DefineConstants.DEVISTATOR, gs, o, pal);
						}
					}
					else
					{
						myospal(weapon_xoffset + 268 - (p.look_ang >> 1), looking_arc + 238 - gun_pos, DefineConstants.DEVISTATOR, gs, o, pal);
						myospal(weapon_xoffset + 30 - (p.look_ang >> 1), looking_arc + 240 - gun_pos, DefineConstants.DEVISTATOR, gs, o | 4, pal);
					}
					break;

				case DefineConstants.FREEZE_WEAPON:
					if (Engine.board.sprite[p.i].pal == 1)
					{
						pal = 1;
					}
					else
					{
						pal = Engine.board.sector[p.cursectnum].floorpal;
					}

					if (p.kickback_pic != 0)
					{
						int[] cat_frames = { 0, 0, 1, 1, 2, 2 };

						if (Engine.board.sprite[p.i].pal != 1)
						{
							weapon_xoffset += (short)(Engine.krand() & 3);
							looking_arc += (short)(Engine.krand() & 3);
						}
						gun_pos -= 16;
						myospal(weapon_xoffset + 210 - (p.look_ang >> 1), looking_arc + 261 - gun_pos, DefineConstants.FREEZE + 2, -32, o, pal);
						myospal(weapon_xoffset + 210 - (p.look_ang >> 1), looking_arc + 235 - gun_pos, DefineConstants.FREEZE + 3 + cat_frames[p.kickback_pic % 6], -32, o, pal);
					}
					else
					{
						myospal(weapon_xoffset + 210 - (p.look_ang >> 1), looking_arc + 261 - gun_pos, DefineConstants.FREEZE, gs, o, pal);
					}

					break;

				case DefineConstants.SHRINKER_WEAPON:
				case DefineConstants.GROW_WEAPON:
					weapon_xoffset += 28;
					looking_arc += 18;
					if (Engine.board.sprite[p.i].pal == 1)
					{
						pal = 1;
					}
					else
					{
						pal = Engine.board.sector[p.cursectnum].floorpal;
					}
					if (p.kickback_pic == null)
					{
						if (cw == DefineConstants.GROW_WEAPON)
						{
							myospal(weapon_xoffset + 184 - (p.look_ang >> 1), looking_arc + 240 - gun_pos, DefineConstants.SHRINKER + 2, (sbyte)(16 - (Engine.table.sintable[p.random_club_frame & 2047] >> 10)), o, 2);

							myospal(weapon_xoffset + 188 - (p.look_ang >> 1), looking_arc + 240 - gun_pos, DefineConstants.SHRINKER - 2, gs, o, pal);
						}
						else
						{
							myospal(weapon_xoffset + 184 - (p.look_ang >> 1), looking_arc + 240 - gun_pos, DefineConstants.SHRINKER + 2, (sbyte)(16 - (Engine.table.sintable[p.random_club_frame & 2047] >> 10)), o, 0);

							myospal(weapon_xoffset + 188 - (p.look_ang >> 1), looking_arc + 240 - gun_pos, DefineConstants.SHRINKER, gs, o, pal);
						}
					}
					else
					{
						if (Engine.board.sprite[p.i].pal != 1)
						{
							weapon_xoffset += (short)(Engine.krand() & 3);
							gun_pos += (short)(Engine.krand() & 3);
						}

						if (cw == DefineConstants.GROW_WEAPON)
						{
							myospal(weapon_xoffset + 184 - (p.look_ang >> 1), looking_arc + 240 - gun_pos, DefineConstants.SHRINKER + 3 + (p.kickback_pic & 3), -32, o, 2);

							myospal(weapon_xoffset + 188 - (p.look_ang >> 1), looking_arc + 240 - gun_pos, DefineConstants.SHRINKER - 1, gs, o, pal);

						}
						else
						{
							myospal(weapon_xoffset + 184 - (p.look_ang >> 1), looking_arc + 240 - gun_pos, DefineConstants.SHRINKER + 3 + (p.kickback_pic & 3), -32, o, 0);

							myospal(weapon_xoffset + 188 - (p.look_ang >> 1), looking_arc + 240 - gun_pos, DefineConstants.SHRINKER + 1, gs, o, pal);
						}
					}
					break;
			}
		}

		displayloogie(snum);

	}

	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define TURBOTURNTIME (TICRATE/8)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define MAXVEL ((NORMALKEYMOVE*2)+10)
	//C++ TO C# CONVERTER NOTE: The following #define macro was replaced in-line:
	//ORIGINAL LINE: #define MAXSVEL ((NORMALKEYMOVE*2)+10)

	public static int myaimmode = 0;
	public static int myaimstat = 0;
	public static int omyaimstat = 0;

	public static void getinput(short snum)
	{
		short j;
		short daang;
		// MED
		//ControlInfo info = new ControlInfo();
		int tics;
		bool running = false;
		int turnamount;
		int keymove = 10;
		int momx;
		int momy;
		player_struct p;

		momx = momy = 0;
		p = ps[snum];

		//CONTROL_GetInput(info);

		if ((p.gm & DefineConstants.MODE_MENU) != 0 || (p.gm & DefineConstants.MODE_TYPE) != 0 || (ud.pause_on != 0 && !(KB_KeyDown[(DefineConstants.sc_Pause)] != false)))
		{
			vel = 0;
			svel = 0;
			angvel = 0;
			horiz = 0;

			loc.fvel = 0;
			loc.svel = 0;
			loc.avel = 0;
			loc.horz = 0;
			loc.bits = (uint)(((int)gamequit) << 26);			
			return;
		}

		tics = totalclock - lastcontroltime;
		lastcontroltime = totalclock;

// jmarshall - mouse aiming.
		//if (MouseAiming)
		//{
		//	myaimmode = (((gamefunc_Mouse_Aiming) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Mouse_Aiming) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Mouse_Aiming)) & 1));
		//}
		//else
		//{
		//	omyaimstat = myaimstat;
		//	myaimstat = (((gamefunc_Mouse_Aiming) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Mouse_Aiming) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Mouse_Aiming)) & 1));
		//	if (myaimstat > omyaimstat)
		//	{
		//		myaimmode ^= 1;
		//		FTA((short)(44 + myaimmode), p);
		//	}
		//}
// jmarshall end

		if (multiflag == 1)
		{
			loc.bits = 1 << 17;
			loc.bits |= (uint)(multiwhat << 18);
			loc.bits |= (uint)(multipos << 19);
			multiflag = 0;
			return;
		}

// jmarshall - keys and weapon switch.
/*
		loc.bits = (((gamefunc_Jump) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Jump) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Jump)) & 1));
		loc.bits |= (((gamefunc_Crouch) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Crouch) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Crouch)) & 1)) << 1;
		loc.bits |= (((gamefunc_Fire) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Fire) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Fire)) & 1)) << 2;
		loc.bits |= (((gamefunc_Aim_Up) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Aim_Up) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Aim_Up)) & 1)) << 3;
		loc.bits |= (((gamefunc_Aim_Down) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Aim_Down) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Aim_Down)) & 1)) << 4;
		loc.bits |= (((gamefunc_Run) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Run) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Run)) & 1)) << 5;
		loc.bits |= (((gamefunc_Look_Left) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Look_Left) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Look_Left)) & 1)) << 6;
		loc.bits |= (((gamefunc_Look_Right) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Look_Right) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Look_Right)) & 1)) << 7;

		j = 0;
		if ((((gamefunc_Weapon_1) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Weapon_1) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Weapon_1)) & 1)) != 0)
		{
			j = 1;
		}
		if ((((gamefunc_Weapon_2) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Weapon_2) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Weapon_2)) & 1)) != 0)
		{
			j = 2;
		}
		if ((((gamefunc_Weapon_3) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Weapon_3) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Weapon_3)) & 1)) != 0)
		{
			j = 3;
		}
		if ((((gamefunc_Weapon_4) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Weapon_4) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Weapon_4)) & 1)) != 0)
		{
			j = 4;
		}
		if ((((gamefunc_Weapon_5) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Weapon_5) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Weapon_5)) & 1)) != 0)
		{
			j = 5;
		}
		if ((((gamefunc_Weapon_6) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Weapon_6) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Weapon_6)) & 1)) != 0)
		{
			j = 6;
		}

		if ((((gamefunc_Previous_Weapon) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Previous_Weapon) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Previous_Weapon)) & 1)) != 0)
		{
			j = 11;
		}
		if ((((gamefunc_Next_Weapon) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Next_Weapon) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Next_Weapon)) & 1)) != 0)
		{
			j = 12;
		}

#if !VOLUMEONE
		if ((((gamefunc_Weapon_7) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Weapon_7) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Weapon_7)) & 1)) != 0)
		{
			j = 7;
		}
		if ((((gamefunc_Weapon_8) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Weapon_8) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Weapon_8)) & 1)) != 0)
		{
			j = 8;
		}
		if ((((gamefunc_Weapon_9) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Weapon_9) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Weapon_9)) & 1)) != 0)
		{
			j = 9;
		}
		if ((((gamefunc_Weapon_10) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Weapon_10) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Weapon_10)) & 1)) != 0)
		{
			j = 10;
		}
#endif

		loc.bits |= j << 8;
		loc.bits |= (((gamefunc_Steroids) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Steroids) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Steroids)) & 1)) << 12;
		loc.bits |= (((gamefunc_Look_Up) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Look_Up) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Look_Up)) & 1)) << 13;
		loc.bits |= (((gamefunc_Look_Down) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Look_Down) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Look_Down)) & 1)) << 14;
		loc.bits |= (((gamefunc_NightVision) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_NightVision) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_NightVision)) & 1)) << 15;
		loc.bits |= (((gamefunc_MedKit) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_MedKit) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_MedKit)) & 1)) << 16;
		loc.bits |= (((gamefunc_Center_View) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Center_View) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Center_View)) & 1)) << 18;
		loc.bits |= (((gamefunc_Holster_Weapon) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Holster_Weapon) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Holster_Weapon)) & 1)) << 19;
		loc.bits |= (((gamefunc_Inventory_Left) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Inventory_Left) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Inventory_Left)) & 1)) << 20;
		loc.bits |= (KB_KeyDown[(DefineConstants.sc_Pause)] != 0) << 21;
		loc.bits |= (((gamefunc_Quick_Kick) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Quick_Kick) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Quick_Kick)) & 1)) << 22;
		loc.bits |= myaimmode << 23;
		loc.bits |= (((gamefunc_Holo_Duke) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Holo_Duke) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Holo_Duke)) & 1)) << 24;
		loc.bits |= (((gamefunc_Jetpack) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Jetpack) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Jetpack)) & 1)) << 25;
		loc.bits |= (((int)gamequit) << 26);
		loc.bits |= (((gamefunc_Inventory_Right) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Inventory_Right) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Inventory_Right)) & 1)) << 27;
		loc.bits |= (((gamefunc_TurnAround) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_TurnAround) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_TurnAround)) & 1)) << 28;
		loc.bits |= (((gamefunc_Open) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Open) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Open)) & 1)) << 29;
		loc.bits |= (((gamefunc_Inventory) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Inventory) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Inventory)) & 1)) << 30;
		loc.bits |= (KB_KeyDown[(DefineConstants.sc_Escape)] != 0) << 31;
		running = (((gamefunc_Run) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Run) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Run)) & 1)) | ud.auto_run;
*/
		svel = vel = angvel = horiz = 0;

		//if (CONTROL_JoystickEnabled)
		//{
		//	if (running != null)
		//	{
		//		info.dz *= 2;
		//	}
		//}
// jmarshall - look and shift
/*
		if (KB_KeyDown[DefineConstants.sc_LeftShift])
		{
			svel = -info.dyaw / 8;
		}
		else
		{
			angvel = info.dyaw / 64;
		}

		if (myaimmode != 0)
		{
			if (ud.mouseflip)
			{
				horiz -= info.dz / (314 - 128);
			}
			else
			{
				horiz += info.dz / (314 - 128);
			}

			info.dz = 0;
		}

		svel -= info.dx;
		vel = -info.dz >> 6;



		if ((((gamefunc_Strafe) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Strafe) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Strafe)) & 1)) != 0)
		{
			if ((((gamefunc_Turn_Left) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Turn_Left) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Turn_Left)) & 1)) != 0)
			{
				svel -= -keymove;
			}
			if ((((gamefunc_Turn_Right) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Turn_Right) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Turn_Right)) & 1)) != 0)
			{
				svel -= keymove;
			}
		}
		else
		{
			if ((((gamefunc_Turn_Left) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Turn_Left) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Turn_Left)) & 1)) != 0)
			{
				turnheldtime += tics;
				if (turnheldtime >= (DefineConstants.TICRATE / 8))
				{
					angvel -= turnamount;
				}
				else
				{
					angvel -= DefineConstants.PREAMBLETURN;
				}
			}
			else if ((((gamefunc_Turn_Right) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_Turn_Right) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_Turn_Right)) & 1)))
			{
				turnheldtime += tics;
				if (turnheldtime >= (DefineConstants.TICRATE / 8))
				{
					angvel += turnamount;
				}
				else
				{
					angvel += DefineConstants.PREAMBLETURN;
				}
			}
			else
			{
				turnheldtime = 0;
			}
		}
*/
		if (running != null)
		{
			turnamount = DefineConstants.NORMALTURN << 1;
			keymove = DefineConstants.NORMALKEYMOVE << 1;
		}
		else
		{
			turnamount = DefineConstants.NORMALTURN;
			keymove = DefineConstants.NORMALKEYMOVE;
		}
		if (KB_KeyDown[DefineConstants.sc_LeftArrow])
		{
			angvel -= turnamount;
		}

		if (KB_KeyDown[DefineConstants.sc_RightArrow])
		{
			angvel += turnamount;
		}

		if (KB_KeyDown[DefineConstants.sc_UpArrow])
		{
			vel += keymove;
		}

		if (KB_KeyDown[DefineConstants.sc_DownArrow])
		{
			vel += -keymove;
		}

		if (vel < -((DefineConstants.NORMALKEYMOVE * 2) + 10))
		{
			vel = -((DefineConstants.NORMALKEYMOVE * 2) + 10);
		}
		if (vel > ((DefineConstants.NORMALKEYMOVE * 2) + 10))
		{
			vel = ((DefineConstants.NORMALKEYMOVE * 2) + 10);
		}
		if (svel < -((DefineConstants.NORMALKEYMOVE * 2) + 10))
		{
			svel = -((DefineConstants.NORMALKEYMOVE * 2) + 10);
		}
		if (svel > ((DefineConstants.NORMALKEYMOVE * 2) + 10))
		{
			svel = ((DefineConstants.NORMALKEYMOVE * 2) + 10);
		}
		if (angvel < -DefineConstants.MAXANGVEL)
		{
			angvel = -DefineConstants.MAXANGVEL;
		}
		if (angvel > DefineConstants.MAXANGVEL)
		{
			angvel = DefineConstants.MAXANGVEL;
		}
		if (horiz < -DefineConstants.MAXHORIZ)
		{
			horiz = -DefineConstants.MAXHORIZ;
		}
		if (horiz > DefineConstants.MAXHORIZ)
		{
			horiz = DefineConstants.MAXHORIZ;
		}

// jmarshall: automap
		//if (ud.scrollmode && ud.overhead_on)
		//{
		//	ud.folfvel = vel;
		//	ud.folavel = angvel;
		//	loc.fvel = 0;
		//	loc.svel = 0;
		//	loc.avel = 0;
		//	loc.horz = 0;
		//	return;
		//}
// jmarshall end

		if (numplayers > 1)
		{
			daang = myang;
		}
		else
		{
			daang = p.ang;
		}

		momx = pragmas.mulscale9(vel, Engine.table.sintable[(daang + 2560) & 2047]);
		momy = pragmas.mulscale9(vel, Engine.table.sintable[(daang + 2048) & 2047]);

		momx += pragmas.mulscale9(svel, Engine.table.sintable[(daang + 2048) & 2047]);
		momy += pragmas.mulscale9(svel, Engine.table.sintable[(daang + 1536) & 2047]);

		momx += fricxv;
		momy += fricyv;

		loc.fvel = (short)momx;
		loc.svel = (short)momy;
		loc.avel = (sbyte)angvel;
		loc.horz = (sbyte)horiz;
	}


	public static char doincrements(player_struct p)
	{
		int i;
		int snum;

		snum = Engine.board.sprite[p.i].yvel;
		//    j = sync[snum].avel;
		//    p->weapon_ang = -(j/5);

		p.player_par++;

		if (p.invdisptime > 0)
		{
			p.invdisptime--;
		}

		if (p.tipincs > 0)
		{
			p.tipincs--;
		}

		if (p.last_pissed_time > 0)
		{
			p.last_pissed_time--;

			if (p.last_pissed_time == (26 * 219))
			{
				spritesound(DefineConstants.FLUSH_TOILET, p.i);
				if (snum == screenpeek || ud.coop == 1)
				{
					spritesound(DefineConstants.DUKE_PISSRELIEF, p.i);
				}
			}

			if (p.last_pissed_time == (26 * 218))
			{
				p.holster_weapon = 0;
				p.weapon_pos = 10;
			}
		}

		if (p.crack_time > 0)
		{
			p.crack_time--;
			if (p.crack_time == 0)
			{
				p.knuckle_incs = (char)1;
				p.crack_time = 777;
			}
		}

		if (p.steroids_amount > 0 && p.steroids_amount < 400)
		{
			p.steroids_amount--;
			if (p.steroids_amount == 0)
			{
				checkavailinven(p);
			}
			if ((p.steroids_amount & 7) == 0)
			{
				if (snum == screenpeek || ud.coop == 1)
				{
					spritesound(DefineConstants.DUKE_HARTBEAT, p.i);
				}
			}
		}

		if (p.heat_on != 0 && p.heat_amount > 0)
		{
			p.heat_amount--;
			if (p.heat_amount == 0)
			{
				p.heat_on = (char)0;
				checkavailinven(p);
				spritesound(DefineConstants.NITEVISION_ONOFF, p.i);
				setpal(p);
			}
		}

		if (p.holoduke_on >= 0)
		{
			p.holoduke_amount--;
			if (p.holoduke_amount <= 0)
			{
				spritesound(DefineConstants.TELEPORTER, p.i);
				p.holoduke_on = -1;
				checkavailinven(p);
			}
		}

		if (p.jetpack_on != 0 && p.jetpack_amount > 0)
		{
			p.jetpack_amount--;
			if (p.jetpack_amount <= 0)
			{
				p.jetpack_on = (char)0;
				checkavailinven(p);
				spritesound(DefineConstants.DUKE_JETPACK_OFF, p.i);
				stopsound(DefineConstants.DUKE_JETPACK_IDLE);
				stopsound(DefineConstants.DUKE_JETPACK_ON);
			}
		}

		if (p.quick_kick > 0 && Engine.board.sprite[p.i].pal != 1)
		{
			p.quick_kick--;
			if (p.quick_kick == 8)
			{
				shoot(p.i, DefineConstants.KNEE);
			}
		}

		if (p.access_incs != 0 && Engine.board.sprite[p.i].pal != 1)
		{
			p.access_incs++;
			if (Engine.board.sprite[p.i].extra <= 0)
			{
				p.access_incs = 12;
			}
			if (p.access_incs == 12)
			{
				if (p.access_spritenum >= 0)
				{
					checkhitswitch((short)snum, p.access_spritenum, (char)1);
					switch (Engine.board.sprite[p.access_spritenum].pal)
					{
						case 0:
							p.got_access &= unchecked((short)((0xffff - 0x1)));
							break;
						case 21:
							p.got_access &= unchecked((short)((0xffff - 0x2)));
							break;
						case 23:
							p.got_access &= unchecked((short)((0xffff - 0x4)));//(0xffff - 0x4);
							break;
					}
					p.access_spritenum = -1;
				}
				else
				{
					checkhitswitch((short)snum, p.access_wallnum, (char)0);
					switch (Engine.board.wall[p.access_wallnum].pal)
					{
                        case 0:
                            p.got_access &= unchecked((short)((0xffff - 0x1)));
                            break;
                        case 21:
                            p.got_access &= unchecked((short)((0xffff - 0x2)));
                            break;
                        case 23:
                            p.got_access &= unchecked((short)((0xffff - 0x4)));//(0xffff - 0x4);
                            break;
                    }
				}
			}

			if (p.access_incs > 20)
			{
				p.access_incs = 0;
				p.weapon_pos = 10;
				p.kickback_pic = 0;
			}
		}

		if (p.scuba_on == 0 && Engine.board.sector[p.cursectnum].lotag == 2)
		{
			if (p.scuba_amount > 0)
			{
				p.scuba_on = (char)1;
				p.inven_icon = (char)6;
				FTA(76, p);
			}
			else
			{
				if (p.airleft > 0)
				{
					p.airleft--;
				}
				else
				{
					p.extra_extra8 += 32;
					if (p.last_extra < (max_player_health >> 1) && (p.last_extra & 3) == 0)
					{
						spritesound(DefineConstants.DUKE_LONGTERM_PAIN, p.i);
					}
				}
			}
		}
		else if (p.scuba_amount > 0 && p.scuba_on != 0)
		{
			p.scuba_amount--;
			if (p.scuba_amount == 0)
			{
				p.scuba_on = (char)0;
				checkavailinven(p);
			}
		}

		if (p.knuckle_incs != 0)
		{
			p.knuckle_incs++;
			if (p.knuckle_incs == 10)
			{
				if (totalclock > 1024)
				{
					if (snum == screenpeek || ud.coop == 1)
					{
						if ((Engine.krand() & 1) != 0)
						{
							spritesound(DefineConstants.DUKE_CRACK, p.i);
						}
						else
						{
							spritesound(DefineConstants.DUKE_CRACK2, p.i);
						}
					}
				}
				spritesound(DefineConstants.DUKE_CRACK_FIRST, p.i);
			}
			else if (p.knuckle_incs == 22 || (sync[snum].bits & (1 << 2)) != 0)
			{
				p.knuckle_incs = (char)0;
			}

			return (char)1;
		}
		return (char)0;
	}

	public static short[] weapon_sprites = { DefineConstants.KNEE, DefineConstants.FIRSTGUNSPRITE, DefineConstants.SHOTGUNSPRITE, DefineConstants.CHAINGUNSPRITE, DefineConstants.RPGSPRITE, DefineConstants.HEAVYHBOMB, DefineConstants.SHRINKERSPRITE, DefineConstants.DEVISTATORSPRITE, DefineConstants.TRIPBOMBSPRITE, DefineConstants.FREEZESPRITE, DefineConstants.HEAVYHBOMB, DefineConstants.SHRINKERSPRITE };

	public static void checkweapons(player_struct p)
	{
		short j;
		short cw;

		cw = p.curr_weapon;

		if (cw < 1 || cw >= DefineConstants.MAX_WEAPONS)
		{
			return;
		}

		if (cw != 0)
		{
			if ((Engine.krand() & 1) != 0)
			{
				spawn(p.i, weapon_sprites[cw]);
			}
			else
			{
				switch (cw)
				{
					case DefineConstants.RPG_WEAPON:
					case DefineConstants.HANDBOMB_WEAPON:
						spawn(p.i, DefineConstants.EXPLOSION2);
						break;
				}
			}
		}
	}

	public static void processinput(short snum)
	{
		int j;
		int i;
		int k;
		int doubvel;
		int fz = 0;
		int cz = 0;
		int hz = 0;
		int lz = 0;
		int truefdist;
		int x;
		int y;
		bool shrunk;
		int sb_snum;
		short psect;
		short psectlotag;
		short tempsect;
		short pi;
		player_struct p;
		spritetype s;

		p = ps[snum];
		pi = p.i;
		s = Engine.board.sprite[pi];

		if (p.cheat_phase <= 0)
		{
// jmarshall: sb_snum
			//sb_snum = (int)sync[snum].bits;
			sb_snum = 0;
// jmarshall end
		}
		else
		{
			sb_snum = 0;
		}

		psect = p.cursectnum;
		if (psect == -1)
		{
			if (s.extra > 0 && ud.clipping == 0)
			{
				quickkill(p);
				spritesound(DefineConstants.SQUISHED, pi);
			}
			psect = 0;
		}

		psectlotag = Engine.board.sector[psect].lotag;
		p.spritebridge = (char)0;

		shrunk = (s.yrepeat < 32);
		Engine.board.getzrange(p.posx, p.posy, p.posz, psect, ref cz, ref hz, ref fz,ref  lz, 163, (((1) << 16) + 1));

		j = Engine.board.getflorzofslope(psect, p.posx, p.posy);

		p.truefz = j;
		p.truecz = Engine.board.getceilzofslope(psect, p.posx, p.posy);

		truefdist = pragmas.klabs(p.posz - j);
		if ((lz & 49152) == 16384 && psectlotag == 1 && truefdist > (38 << 8) + (16 << 8))
		{
			psectlotag = 0;
		}

		hittype[pi].floorz = fz;
		hittype[pi].ceilingz = cz;

		p.ohoriz = p.horiz;
		p.ohorizoff = p.horizoff;

		if (p.aim_mode == 0 && p.on_ground != 0 && psectlotag != 2 && (Engine.board.sector[psect].floorstat & 2) != 0)
		{
			x = p.posx + (Engine.table.sintable[(p.ang + 512) & 2047] >> 5);
			y = p.posy + (Engine.table.sintable[p.ang & 2047] >> 5);
			tempsect = psect;
			Engine.board.updatesector(x, y, ref tempsect);
			if (tempsect >= 0)
			{
				k = Engine.board.getflorzofslope(psect, x, y);
				if (psect == tempsect)
				{
					p.horizoff += (short)pragmas.mulscale16(j - k, 160);
				}
				else if (pragmas.klabs(Engine.board.getflorzofslope(tempsect, x, y) - k) <= (4 << 8))
				{
					p.horizoff += (short)pragmas.mulscale16(j - k, 160);
				}
			}
		}
		if (p.horizoff > 0)
		{
			p.horizoff -= (short)((p.horizoff >> 3) + 1);
		}
		else if (p.horizoff < 0)
		{
			p.horizoff += (short)(((-p.horizoff) >> 3) + 1);
		}

		if (hz >= 0 && (hz & 49152) == 49152)
		{
			hz &= (DefineConstants.MAXSPRITES - 1);

			if (Engine.board.sprite[hz].statnum == 1 && Engine.board.sprite[hz].extra >= 0)
			{
				hz = 0;
				cz = p.truecz;
			}
		}

		if (lz >= 0 && (lz & 49152) == 49152)
		{
			j = lz & (DefineConstants.MAXSPRITES - 1);

			if ((Engine.board.sprite[j].cstat & 33) == 33)
			{
				psectlotag = 0;
				p.footprintcount = (char)0;
				p.spritebridge = (char)1;
			}
			else if (badguy(Engine.board.sprite[j]) != 0 && Engine.board.sprite[j].xrepeat > 24 && pragmas.klabs(s.z - Engine.board.sprite[j].z) < (84 << 8))
			{
				j = Engine.getangle(Engine.board.sprite[j].x - p.posx, Engine.board.sprite[j].y - p.posy);
				p.posxv -= Engine.table.sintable[(j + 512) & 2047] << 4;
				p.posyv -= Engine.table.sintable[j & 2047] << 4;
			}
		}


		if (s.extra > 0)
		{
			incur_damage(p);
		}
		else
		{
			s.extra = 0;
			p.shield_amount = 0;
		}

		p.last_extra = s.extra;

		if (p.loogcnt > 0)
		{
			p.loogcnt--;
		}
		else
		{
			p.loogcnt = 0;
		}

		if (p.fist_incs != 0)
		{
			p.fist_incs++;
			if (p.fist_incs == 28)
			{
				if (ud.recstat == 1)
				{
					closedemowrite();
				}
				sound(DefineConstants.PIPEBOMB_EXPLODE);
				p.pals[0] = 64;
				p.pals[1] = 64;
				p.pals[2] = 64;
				p.pals_time = 48;
			}
			if (p.fist_incs > 42)
			{
				if (p.buttonpalette != 0 && ud.from_bonus == 0)
				{
					ud.from_bonus = (short)(ud.level_number + 1);
					if (ud.secretlevel > 0 && ud.secretlevel < 12)
					{
						ud.level_number = ud.secretlevel - 1;
					}
					ud.m_level_number = ud.level_number;
				}
				else
				{
					if (ud.from_bonus != 0)
					{
						ud.level_number = ud.from_bonus;
						ud.m_level_number = ud.level_number;
						ud.from_bonus = 0;
					}
					else
					{
						if (ud.level_number == ud.secretlevel && ud.from_bonus > 0)
						{
							ud.level_number = ud.from_bonus;
						}
						else
						{
							ud.level_number++;
						}

						if (ud.level_number > 10)
						{
							ud.level_number = 0;
						}
						ud.m_level_number = ud.level_number;

					}
				}
				for (i = connecthead; i >= 0; i = connectpoint2[i])
				{
					ps[i].gm = DefineConstants.MODE_EOL;
				}
				p.fist_incs = 0;

				return;
			}
		}

		if (p.timebeforeexit > 1 && p.last_extra > 0)
		{
			p.timebeforeexit--;
			if (p.timebeforeexit == 26 * 5)
			{
				FX_StopAllSounds();
				clearsoundlocks();
				if (p.customexitsound >= 0)
				{
					sound(p.customexitsound);
					FTA(102, p);
				}
			}
			else if (p.timebeforeexit == 1)
			{
				for (i = connecthead; i >= 0; i = connectpoint2[i])
				{
					ps[i].gm = DefineConstants.MODE_EOL;
				}
				if (ud.from_bonus != 0)
				{
					ud.level_number = ud.from_bonus;
					ud.m_level_number = ud.level_number;
					ud.from_bonus = 0;
				}
				else
				{
					ud.level_number++;
					ud.m_level_number = ud.level_number;
				}
				return;
			}
		}
		/*
			if(p->select_dir)
			{
				if(psectlotag != 15 || (sb_snum&(1<<31)) )
					p->select_dir = 0;
				else
				{
					if(sync[snum].fvel > 127)
					{
						p->select_dir = 0;
						activatewarpelevators(pi,-1);
					}
					else if(sync[snum].fvel <= -127)
					{
						p->select_dir = 0;
						activatewarpelevators(pi,1);
					}
					return;
				}
			}
		  */
		if (p.pals_time > 0)
		{
			p.pals_time--;
		}

		if (p.fta > 0)
		{
			p.fta--;
			if (p.fta == 0)
			{
				pub = (char)DefineConstants.NUMPAGES;
				pus = (char)DefineConstants.NUMPAGES;
				p.ftq = 0;
			}
		}

		if (s.extra <= 0)
		{
			if (p.dead_flag == 0)
			{
				if (s.pal != 1)
				{
// jmarshall - palette
					//p.pals = StringFunctions.ChangeCharacter(p.pals, 0, 63);
					//p.pals = p.pals.Substring(0, 1);
					//p.pals = p.pals.Substring(0, 2);
// jmarshall end
					p.pals_time = 63;
					p.posz -= (16 << 8);
					s.z -= (16 << 8);
				}

				if (ud.recstat == 1 && ud.multimode < 2)
				{
					closedemowrite();
				}

				if (s.pal != 1)
				{
					p.dead_flag = (short)((512 - ((Engine.krand() & 1) << 10) + (Engine.krand() & 255) - 512) & 2047);
				}

				p.jetpack_on = (char)0;
				p.holoduke_on = -1;

				stopsound(DefineConstants.DUKE_JETPACK_IDLE);
				if (p.scream_voice > (int)FX_ERRORS.FX_Ok)
				{
					FX_StopSound(p.scream_voice);
					testcallback(DefineConstants.DUKE_SCREAM);
					p.scream_voice = (int)FX_ERRORS.FX_Ok;
				}

				if (s.pal != 1 && (s.cstat & 32768) == 0)
				{
					s.cstat = 0;
				}

				if (ud.multimode > 1 && (s.pal != 1 || (s.cstat & 32768) != 0))
				{
					if (p.frag_ps != snum)
					{
						ps[p.frag_ps].frag++;
						frags[p.frag_ps,snum]++;

						if (ud.user_name[p.frag_ps][0] != 0)
						{
							if (snum == screenpeek)
							{
								fta_quotes[115] = "KILLED BY " + ud.user_name[p.frag_ps];
								FTA(115, p);
							}
							else
							{
								fta_quotes[116] = "KILLED " + ud.user_name[snum];
								FTA(116, ps[p.frag_ps]);
							}
						}
						else
						{
							if (snum == screenpeek)
							{
								fta_quotes[115] = "KILLED BY PLAYER %ld" + (1 + p.frag_ps);
								FTA(115, p);
							}
							else
							{
								fta_quotes[116] = "KILLED PLAYER " + (1 + snum);
								FTA(116, ps[p.frag_ps]);
							}
						}
					}
					else
					{
						p.fraggedself++;
					}

					if (myconnectindex == connecthead)
					{
// jmarshall - send score
						//sprintf(tempbuf, "frag %d killed %d\n", p.frag_ps + 1, snum + 1);
						//sendscore(ref tempbuf);
// jmarshall end
						//                    printf(tempbuf);
					}

					p.frag_ps = snum;
					pus = (char)DefineConstants.NUMPAGES;
				}
			}

			if (psectlotag == 2)
			{
				if (p.on_warping_sector == 0)
				{
					if (pragmas.klabs(p.posz - fz) > ((38 << 8) >> 1))
					{
						p.posz += 348;
					}
				}
				else
				{
					s.z -= 512;
					s.zvel = -348;
				}

				Engine.board.clipmove(ref p.posx, ref p.posy, ref p.posz, ref p.cursectnum, 0, 0, 164, (4 << 8), (4 << 8), (((1) << 16) + 1));
				//            p->bobcounter += 32;
			}

			p.oposx = p.posx;
			p.oposy = p.posy;
			p.oposz = p.posz;
			p.oang = p.ang;
			p.opyoff = p.pyoff;

			p.horiz = 100;
			p.horizoff = 0;

			Engine.board.updatesector(p.posx, p.posy, ref p.cursectnum);

			Engine.board.pushmove(ref p.posx, ref p.posy, ref p.posz, ref p.cursectnum, 128, (4 << 8), (20 << 8), (((1) << 16) + 1));

			if (fz > cz + (16 << 8) && s.pal != 1)
			{
				p.rotscrnang = (short)((p.dead_flag + ((fz + p.posz) >> 7)) & 2047);
			}

			p.on_warping_sector = (char)0;

			return;
		}

		if (p.transporter_hold > 0)
		{
			p.transporter_hold--;
			if (p.transporter_hold == 0 && p.on_warping_sector != 0)
			{
				p.transporter_hold = 2;
			}
		}
		if (p.transporter_hold < 0)
		{
			p.transporter_hold++;
		}

		if (p.newowner >= 0)
		{
			i = p.newowner;
			p.posx = Engine.board.sprite[i].x;
			p.posy = Engine.board.sprite[i].y;
			p.posz = Engine.board.sprite[i].z;
			p.ang = Engine.board.sprite[i].ang;
			p.posxv = p.posyv = s.xvel = 0;
			p.look_ang = 0;
			p.rotscrnang = 0;

			doincrements(p);

			if (p.curr_weapon == DefineConstants.HANDREMOTE_WEAPON)
			{
				goto SHOOTINCODE;
			}

			return;
		}

		doubvel = (DefineConstants.TICRATE / 26);

		if (p.rotscrnang > 0)
		{
			p.rotscrnang -= (short)(((p.rotscrnang >> 1) + 1));
		}
		else if (p.rotscrnang < 0)
		{
			p.rotscrnang += (short)((((-p.rotscrnang) >> 1) + 1));
		}

		p.look_ang -= (short)((p.look_ang >> 2));

		if ((sb_snum & (1 << 6)) != 0)
		{
			p.look_ang -= 152;
			p.rotscrnang += 24;
		}

		if ((sb_snum & (1 << 7)) != 0)
		{
			p.look_ang += 152;
			p.rotscrnang -= 24;
		}

		if (p.on_crane >= 0)
		{
			goto HORIZONLY;
		}

		if (sync[snum] == null)
			sync[snum] = new input();

		j = pragmas.ksgn(sync[snum].avel);
		/*
		if( j && ud.screen_tilting == 2)
		{
		    k = 4;
		    if(sb_snum&(1<<5)) k <<= 2;
		    p->rotscrnang -= k*j;
		    p->look_ang += k*j;
		}
		*/

		if (s.xvel < 32 || p.on_ground == 0 || p.bobcounter == 1024)
		{
			if ((p.weapon_sway & 2047) > (1024 + 96))
			{
				p.weapon_sway -= 96;
			}
			else if ((p.weapon_sway & 2047) < (1024 - 96))
			{
				p.weapon_sway += 96;
			}
			else
			{
				p.weapon_sway = 1024;
			}
		}
		else
		{
			p.weapon_sway = p.bobcounter;
		}

		s.xvel = (short)pragmas.ksqrt((p.posx - p.bobposx) * (p.posx - p.bobposx) + (p.posy - p.bobposy) * (p.posy - p.bobposy));
		if (p.on_ground != 0)
		{
			p.bobcounter += Engine.board.sprite[p.i].xvel >> 1;
		}

		if (ud.clipping == 0 && (Engine.board.sector[p.cursectnum].floorpicnum == DefineConstants.MIRROR || p.cursectnum < 0 || p.cursectnum >= DefineConstants.MAXSECTORS))
		{
			p.posx = p.oposx;
			p.posy = p.oposy;
		}
		else
		{
			p.oposx = p.posx;
			p.oposy = p.posy;
		}

		p.bobposx = p.posx;
		p.bobposy = p.posy;

		p.oposz = p.posz;
		p.opyoff = p.pyoff;
		p.oang = p.ang;

		if (p.one_eighty_count < 0)
		{
			p.one_eighty_count += 128;
			p.ang += 128;
		}

		// Shrinking code

		i = 40;

		if (psectlotag == 2)
		{
			p.jumping_counter = 0;

			p.pycount += 32;
			p.pycount &= 2047;
			p.pyoff = Engine.table.sintable[p.pycount] >> 7;

			if (Sound[DefineConstants.DUKE_UNDERWATER].num == 0)
			{
				spritesound(DefineConstants.DUKE_UNDERWATER, pi);
			}

			if ((sb_snum & 1) != 0)
			{
				if (p.poszv > 0)
				{
					p.poszv = 0;
				}
				p.poszv -= 348;
				if (p.poszv < -(256 * 6))
				{
					p.poszv = -(256 * 6);
				}
			}
			else if ((sb_snum & (1 << 1)) != 0)
			{
				if (p.poszv < 0)
				{
					p.poszv = 0;
				}
				p.poszv += 348;
				if (p.poszv > (256 * 6))
				{
					p.poszv = (256 * 6);
				}
			}
			else
			{
				if (p.poszv < 0)
				{
					p.poszv += 256;
					if (p.poszv > 0)
					{
						p.poszv = 0;
					}
				}
				if (p.poszv > 0)
				{
					p.poszv -= 256;
					if (p.poszv < 0)
					{
						p.poszv = 0;
					}
				}
			}

			if (p.poszv > 2048)
			{
				p.poszv >>= 1;
			}

			p.posz += p.poszv;

			if (p.posz > (fz - (15 << 8)))
			{
				p.posz += ((fz - (15 << 8)) - p.posz) >> 1;
			}

			if (p.posz < (cz + (4 << 8)))
			{
				p.posz = cz + (4 << 8);
				p.poszv = 0;
			}

			if (p.scuba_on != 0 && (Engine.krand() & 255) < 8)
			{
				j = spawn(pi, DefineConstants.WATERBUBBLE);
				Engine.board.sprite[j].x += Engine.table.sintable[(p.ang + 512 + 64 - (global_random & 128)) & 2047] >> 6;
				Engine.board.sprite[j].y += Engine.table.sintable[(p.ang + 64 - (global_random & 128)) & 2047] >> 6;
				Engine.board.sprite[j].xrepeat = 3;
				Engine.board.sprite[j].yrepeat = 2;
				Engine.board.sprite[j].z = p.posz + (8 << 8);
			}
		}

		else if (p.jetpack_on != 0)
		{
			p.on_ground = (char)0;
			p.jumping_counter = 0;
			p.hard_landing = (char)0;
			p.falling_counter = (char)0;

			p.pycount += 32;
			p.pycount &= 2047;
			p.pyoff = Engine.table.sintable[p.pycount] >> 7;

			if (p.jetpack_on < 11)
			{
				p.jetpack_on++;
				p.posz -= (p.jetpack_on << 7); //Goin up
			}
			else if (p.jetpack_on == 11 && Sound[DefineConstants.DUKE_JETPACK_IDLE].num < 1)
			{
				spritesound(DefineConstants.DUKE_JETPACK_IDLE, pi);
			}

			if (shrunk)
			{
				j = 512;
			}
			else
			{
				j = 2048;
			}

			if ((sb_snum & 1) != 0) //A (soar high)
			{
				p.posz -= j;
				p.crack_time = 777;
			}

			if ((sb_snum & (1 << 1)) != 0) //Z (soar low)
			{
				p.posz += j;
				p.crack_time = 777;
			}

			if (shrunk == false && (psectlotag == 0 || psectlotag == 2))
			{
				k = 32;
			}
			else
			{
				k = 16;
			}

			if (psectlotag != 2 && p.scuba_on == 1)
			{
				p.scuba_on = (char)0;
			}

			if (p.posz > (fz - (k << 8)))
			{
				p.posz += ((fz - (k << 8)) - p.posz) >> 1;
			}
			if (p.posz < (hittype[pi].ceilingz + (18 << 8)))
			{
				p.posz = hittype[pi].ceilingz + (18 << 8);
			}

		}
		else if (psectlotag != 2)
		{
			if (p.airleft != 15 * 26)
			{
				p.airleft = (short)(15 * 26); //Aprox twenty seconds.
			}

			if (p.scuba_on == 1)
			{
				p.scuba_on = (char)0;
			}

			if (psectlotag == 1 && p.spritebridge == 0)
			{
				if (shrunk == false)
				{
					i = 34;
					p.pycount += 32;
					p.pycount &= 2047;
					p.pyoff = Engine.table.sintable[p.pycount] >> 6;
				}
				else
				{
					i = 12;
				}

				if (shrunk == false && truefdist <= (38 << 8))
				{
					if (p.on_ground == 1)
					{
						if (p.dummyplayersprite == -1)
						{
							p.dummyplayersprite = spawn(pi, DefineConstants.PLAYERONWATER);
						}

						p.footprintcount = (char)6;
						if (Engine.board.sector[p.cursectnum].floorpicnum == DefineConstants.FLOORSLIME)
						{
							p.footprintpal = (char)8;
						}
						else
						{
							p.footprintpal = (char)0;
						}
						p.footprintshade = 0;
					}
				}
			}
			else
			{
				if (p.footprintcount > 0 && p.on_ground != 0)
				{
					if ((Engine.board.sector[p.cursectnum].floorstat & 2) != 2)
					{
						for (j = (short)Engine.board.headspritesect[psect]; j >= 0; j = (short)Engine.board.nextspritesect[j])
						{
							if (Engine.board.sprite[j].picnum == DefineConstants.FOOTPRINTS || Engine.board.sprite[j].picnum == DefineConstants.FOOTPRINTS2 || Engine.board.sprite[j].picnum == DefineConstants.FOOTPRINTS3 || Engine.board.sprite[j].picnum == DefineConstants.FOOTPRINTS4)
							{
								if (pragmas.klabs(Engine.board.sprite[j].x - p.posx) < 384)
								{
									if (pragmas.klabs(Engine.board.sprite[j].y - p.posy) < 384)
									{
										break;
									}
								}
							}
						}
						if (j < 0)
						{
							p.footprintcount--;
							if (Engine.board.sector[p.cursectnum].lotag == 0 && Engine.board.sector[p.cursectnum].hitag == 0)
							{
								switch (Engine.krand() & 3)
								{
									case 0:
										j = spawn(pi, DefineConstants.FOOTPRINTS);
										break;
									case 1:
										j = spawn(pi, DefineConstants.FOOTPRINTS2);
										break;
									case 2:
										j = spawn(pi, DefineConstants.FOOTPRINTS3);
										break;
									default:
										j = spawn(pi, DefineConstants.FOOTPRINTS4);
										break;
								}
								Engine.board.sprite[j].pal = (byte)p.footprintpal;
								Engine.board.sprite[j].shade = (sbyte)p.footprintshade;
							}
						}
					}
				}
			}

			if (p.posz < (fz - (i << 8))) //falling
			{
				if ((sb_snum & 3) == 0 && p.on_ground != 0 && (Engine.board.sector[psect].floorstat & 2) != 0 && p.posz >= (fz - (i << 8) - (16 << 8)))
				{
					p.posz = fz - (i << 8);
				}
				else
				{
					p.on_ground = (char)0;
					p.poszv += (gc + 80); // (TICSPERFRAME<<6);
					if (p.poszv >= (4096 + 2048))
					{
						p.poszv = (4096 + 2048);
					}
					if (p.poszv > 2400 && p.falling_counter < 255)
					{
						p.falling_counter++;
						if (p.falling_counter == 38)
						{
							p.scream_voice = spritesound(DefineConstants.DUKE_SCREAM, pi);
						}
					}

					if ((p.posz + p.poszv) >= (fz - (i << 8))) // hit the ground
					{
						if (Engine.board.sector[p.cursectnum].lotag != 1)
						{
							if (p.falling_counter > 62)
							{
								quickkill(p);
							}

							else if (p.falling_counter > 9)
							{
								j = p.falling_counter;
								s.extra -= (short)(j - (Engine.krand() & 3));
								if (s.extra <= 0)
								{
									spritesound(DefineConstants.SQUISHED, pi);
// jmarshall - palette
									//p.pals = StringFunctions.ChangeCharacter(p.pals, 0, 63);
									//p.pals = p.pals.Substring(0, 1);
									//p.pals = p.pals.Substring(0, 2);
// jmarshall end
									p.pals_time = 63;
								}
								else
								{
									spritesound(DefineConstants.DUKE_LAND, pi);
									spritesound(DefineConstants.DUKE_LAND_HURT, pi);
								}

// jmarshall - palette
								//p.pals = StringFunctions.ChangeCharacter(p.pals, 0, 16);
								//p.pals = p.pals.Substring(0, 1);
								//p.pals = p.pals.Substring(0, 2);
// jmarshall end
								p.pals_time = 32;
							}
							else if (p.poszv > 2048)
							{
								spritesound(DefineConstants.DUKE_LAND, pi);
							}
						}
					}
				}
			}

			else
			{
				p.falling_counter = (char)0;
				if (p.scream_voice > (int)FX_ERRORS.FX_Ok)
				{
					FX_StopSound(p.scream_voice);
					p.scream_voice = (int)FX_ERRORS.FX_Ok;
				}

				if (psectlotag != 1 && psectlotag != 2 && p.on_ground == 0 && p.poszv > (6144 >> 1))
				{
					p.hard_landing = (char)(p.poszv >> 10);
				}

				p.on_ground = (char)1;

				if (i == 40)
				{
					//Smooth on the ground

					k = ((fz - (i << 8)) - p.posz) >> 1;
					if (pragmas.klabs(k) < 256)
					{
						k = 0;
					}
					p.posz += k;
					p.poszv -= 768;
					if (p.poszv < 0)
					{
						p.poszv = 0;
					}
				}
				else if (p.jumping_counter == 0)
				{
					p.posz += ((fz - (i << 7)) - p.posz) >> 1; //Smooth on the water
					if (p.on_warping_sector == 0 && p.posz > fz - (16 << 8))
					{
						p.posz = fz - (16 << 8);
						p.poszv >>= 1;
					}
				}

				p.on_warping_sector = (char)0;

				if ((sb_snum & 2) != 0)
				{
					p.posz += (2048 + 768);
					p.crack_time = 777;
				}

				if ((sb_snum & 1) == 0 && p.jumping_toggle == 1)
				{
					p.jumping_toggle = (char)0;
				}

				else if ((sb_snum & 1) != 0&& p.jumping_toggle == 0)
				{
					if (p.jumping_counter == 0)
					{
						if ((fz - cz) > (56 << 8))
						{
							p.jumping_counter = 1;
							p.jumping_toggle = (char)1;
						}
					}
				}

				if (p.jumping_counter != 0 && (sb_snum & 1) == 0)
				{
					p.jumping_toggle = (char)0;
				}
			}

			if (p.jumping_counter != 0)
			{
				if ((sb_snum & 1) == 0 && p.jumping_toggle == 1)
				{
					p.jumping_toggle = (char)0;
				}

				if (p.jumping_counter < (1024 + 256))
				{
					if (psectlotag == 1 && p.jumping_counter > 768)
					{
						p.jumping_counter = 0;
						p.poszv = -512;
					}
					else
					{
						p.poszv -= (Engine.table.sintable[(2048 - 128 + p.jumping_counter) & 2047]) / 12;
						p.jumping_counter += 180;
						p.on_ground = (char)0;
					}
				}
				else
				{
					p.jumping_counter = 0;
					p.poszv = 0;
				}
			}

			p.posz += p.poszv;

			if (p.posz < (cz + (4 << 8)))
			{
				p.jumping_counter = 0;
				if (p.poszv < 0)
				{
					p.posxv = p.posyv = 0;
				}
				p.poszv = 128;
				p.posz = cz + (4 << 8);
			}
		}

		//Do the quick lefts and rights

		if (p.fist_incs != 0 || p.transporter_hold > 2 || p.hard_landing != 0 || p.access_incs > 0 || p.knee_incs > 0 || (p.curr_weapon == DefineConstants.TRIPBOMB_WEAPON && p.kickback_pic > 1 && p.kickback_pic < 4))
		{
			doubvel = 0;
			p.posxv = 0;
			p.posyv = 0;
		}
		else if (sync[snum].avel != 0) //p->ang += syncangvel * constant
		{ //ENGINE calculates angvel for you
			int tempang;

			tempang = sync[snum].avel << 1;

			if (psectlotag == 2)
			{
				p.angvel = (short)((tempang - (tempang >> 3)) * pragmas.sgn(doubvel));
			}
			else
			{
				p.angvel = (short)(tempang * pragmas.sgn(doubvel));
			}

			p.ang += p.angvel;
			p.ang &= 2047;
			p.crack_time = 777;
		}

		if (p.spritebridge == 0)
		{
			j = Engine.board.sector[s.sectnum].floorpicnum;

			if (j == DefineConstants.PURPLELAVA || Engine.board.sector[s.sectnum].ceilingpicnum == DefineConstants.PURPLELAVA)
			{
				if (p.boot_amount > 0)
				{
					p.boot_amount--;
					p.inven_icon = (char)7;
					if (p.boot_amount <= 0)
					{
						checkavailinven(p);
					}
				}
				else
				{
					if (Sound[DefineConstants.DUKE_LONGTERM_PAIN].num < 1)
					{
						spritesound(DefineConstants.DUKE_LONGTERM_PAIN, pi);
					}
// jmarshall - palette
					//p.pals = null;
					//p.pals = StringFunctions.ChangeCharacter(p.pals, 1, 8);
					//p.pals = p.pals.Substring(0, 2);
// jmarshall end
					p.pals_time = 32;
					s.extra--;
				}
			}

			k = 0;

			if (p.on_ground != 0 && truefdist <= (38 << 8) + (16 << 8))
			{
				switch (j)
				{
					case DefineConstants.HURTRAIL:
						if (((Engine.krand() >> 8) >= (255 - (32))))
						{
							if (p.boot_amount > 0)
							{
								k = 1;
							}
							else
							{
								if (Sound[DefineConstants.DUKE_LONGTERM_PAIN].num < 1)
								{
									spritesound(DefineConstants.DUKE_LONGTERM_PAIN, pi);
								}
// jmarshall - palette
								//p.pals = StringFunctions.ChangeCharacter(p.pals, 0, 64);
								//p.pals = StringFunctions.ChangeCharacter(p.pals, 1, 64);
								//p.pals = StringFunctions.ChangeCharacter(p.pals, 2, 64);
// jmarsshall end
								p.pals_time = 32;
								s.extra -= (short)(1 + (Engine.krand() & 3));
								if (Sound[DefineConstants.SHORT_CIRCUIT].num < 1)
								{
									spritesound(DefineConstants.SHORT_CIRCUIT, pi);
								}
							}
						}
						break;
					case DefineConstants.FLOORSLIME:
						if (((Engine.krand() >> 8) >= (255 - (16))))
						{
							if (p.boot_amount > 0)
							{
								k = 1;
							}
							else
							{
								if (Sound[DefineConstants.DUKE_LONGTERM_PAIN].num < 1)
								{
									spritesound(DefineConstants.DUKE_LONGTERM_PAIN, pi);
								}
// jmarshall -palette
								//p.pals = null;
								//p.pals = StringFunctions.ChangeCharacter(p.pals, 1, 8);
								//p.pals = p.pals.Substring(0, 2);
// jmarshall end
								p.pals_time = 32;
								s.extra -= (short)(1 + (Engine.krand() & 3));
							}
						}
						break;
					case DefineConstants.FLOORPLASMA:
						if (((Engine.krand() >> 8) >= (255 - (32))))
						{
							if (p.boot_amount > 0)
							{
								k = 1;
							}
							else
							{
								if (Sound[DefineConstants.DUKE_LONGTERM_PAIN].num < 1)
								{
									spritesound(DefineConstants.DUKE_LONGTERM_PAIN, pi);
								}
// jmarshall - palette
								//p.pals = StringFunctions.ChangeCharacter(p.pals, 0, 8);
								//p.pals = p.pals.Substring(0, 1);
								//p.pals = p.pals.Substring(0, 2);
// jmarshall end
								p.pals_time = 32;
								s.extra -= (short)(1 + (Engine.krand() & 3));
							}
						}
						break;
				}
			}

			if (k != 0)
			{
				FTA(75, p);
				p.boot_amount -= 2;
				if (p.boot_amount <= 0)
				{
					checkavailinven(p);
				}
			}
		}

		if (p.posxv != 0 || p.posyv != 0 || sync[snum].fvel != 0|| sync[snum].svel != 0)
		{
			p.crack_time = 777;

			k = Engine.table.sintable[p.bobcounter & 2047] >> 12;

			if (truefdist < (38 << 8) + (8 << 8))
			{
				if (k == 1 || k == 3)
				{
					if (p.spritebridge == 0 && p.walking_snd_toggle == 0 && p.on_ground != 0)
					{
						switch (psectlotag)
						{
							case 0:

								if (lz >= 0 && (lz & (DefineConstants.MAXSPRITES - 1)) == 49152)
								{
									j = Engine.board.sprite[lz & (DefineConstants.MAXSPRITES - 1)].picnum;
								}
								else
								{
									j = Engine.board.sector[psect].floorpicnum;
								}

								switch (j)
								{
									case DefineConstants.PANNEL1:
									case DefineConstants.PANNEL2:
										spritesound(DefineConstants.DUKE_WALKINDUCTS, pi);
										p.walking_snd_toggle = (char)1;
										break;
								}
								break;
							case 1:
								if ((Engine.krand() & 1) == 0)
								{
									spritesound(DefineConstants.DUKE_ONWATER, pi);
								}
								p.walking_snd_toggle = (char)1;
								break;
						}
					}
				}
				else if (p.walking_snd_toggle > 0)
				{
					p.walking_snd_toggle--;
				}
			}

			if (p.jetpack_on == 0 && p.steroids_amount > 0 && p.steroids_amount < 400)
			{
				doubvel <<= 1;
			}

			p.posxv += ((sync[snum].fvel * doubvel) << 6);
			p.posyv += ((sync[snum].svel * doubvel) << 6);

			if ((p.curr_weapon == DefineConstants.KNEE_WEAPON && p.kickback_pic > 10 && p.on_ground != 0) || (p.on_ground != 0 && (sb_snum & 2) != 0))
			{
				p.posxv = pragmas.mulscale(p.posxv, dukefriction - 0x2000, 16);
				p.posyv = pragmas.mulscale(p.posyv, dukefriction - 0x2000, 16);
			}
			else
			{
				if (psectlotag == 2)
				{
					p.posxv = pragmas.mulscale(p.posxv, dukefriction - 0x1400, 16);
					p.posyv = pragmas.mulscale(p.posyv, dukefriction - 0x1400, 16);
				}
				else
				{
					p.posxv = pragmas.mulscale(p.posxv, dukefriction, 16);
					p.posyv = pragmas.mulscale(p.posyv, dukefriction, 16);
				}
			}

			if (Mathf.Abs(p.posxv) < 2048 && Mathf.Abs(p.posyv) < 2048)
			{
				p.posxv = p.posyv = 0;
			}

			if (shrunk)
			{
				p.posxv = pragmas.mulscale16(p.posxv, dukefriction - (dukefriction >> 1) + (dukefriction >> 2));
				p.posyv = pragmas.mulscale16(p.posyv, dukefriction - (dukefriction >> 1) + (dukefriction >> 2));
			}
		}

		HORIZONLY:

		if (psectlotag == 1 || p.spritebridge == 1)
		{
			i = (4 << 8);
		}
		else
		{
			i = (20 << 8);
		}

		if (Engine.board.sector[p.cursectnum].lotag == 2)
		{
			k = 0;
		}
		else
		{
			k = 1;
		}

		if (ud.clipping != 0)
		{
			j = 0;
			p.posx += p.posxv >> 14;
			p.posy += p.posyv >> 14;
			Engine.board.updatesector(p.posx, p.posy, ref p.cursectnum);
			Engine.board.changespritesect(pi, p.cursectnum);
		}
		else
		{
			j = Engine.board.clipmove(ref p.posx, ref p.posy, ref p.posz, ref p.cursectnum, p.posxv, p.posyv, 164, (4 << 8), i, (((1) << 16) + 1));
		}

		if (p.jetpack_on == 0 && psectlotag != 2 && psectlotag != 1 && shrunk)
		{
			p.posz += 32 << 8;
		}

		if (j != 0)
		{
			checkplayerhurt(p, (short)j);
		}

		if (p.jetpack_on == 0)
		{
			if (s.xvel > 16)
			{
				if (psectlotag != 1 && psectlotag != 2 && p.on_ground != 0)
				{
					p.pycount += 52;
					p.pycount &= 2047;
					p.pyoff = pragmas.klabs(s.xvel * Engine.table.sintable[p.pycount]) / 1596;
				}
			}
			else if (psectlotag != 2 && psectlotag != 1)
			{
				p.pyoff = 0;
			}
		}

		// RBG***
		Engine.board.setsprite(pi, p.posx, p.posy, p.posz + (38 << 8));

		if (psectlotag < 3)
		{
			psect = s.sectnum;
			if (ud.clipping == 0 && Engine.board.sector[psect].lotag == 31)
			{
				if (Engine.board.sprite[Engine.board.sector[psect].hitag].xvel != 0 && hittype[Engine.board.sector[psect].hitag].count == 0)
				{
					quickkill(p);
					return;
				}
			}
		}

		if ((truefdist < (38 << 8)) && p.on_ground != 0 && psectlotag != 1 && shrunk == false && Engine.board.sector[p.cursectnum].lotag == 1)
		{
			if (Sound[DefineConstants.DUKE_ONWATER].num == 0)
			{
				spritesound(DefineConstants.DUKE_ONWATER, pi);
			}
		}

		if (p.cursectnum != s.sectnum)
		{
			Engine.board.changespritesect(pi, p.cursectnum);
		}

		if (ud.clipping == 0)
		{
			if ((Engine.board.pushmove(ref p.posx, ref p.posy, ref p.posz, ref p.cursectnum, 164, (4 << 8), (4 << 8), (((1) << 16) + 1)) < 0 && furthestangle(pi, 8) < 512))
				j = 1;
			else
				j = 0;
		}
		else
		{
			j = 0;
		}

		if (ud.clipping == 0)
		{
			if (pragmas.klabs(hittype[pi].floorz - hittype[pi].ceilingz) < (48 << 8) || j != 0)
			{
				if ((Engine.board.sector[s.sectnum].lotag & 0x8000) == 0 && (isanunderoperator(Engine.board.sector[s.sectnum].lotag) || isanearoperator(Engine.board.sector[s.sectnum].lotag)))
				{
					activatebysector(s.sectnum, pi);
				}
				if (j != 0)
				{
					quickkill(p);
					return;
				}
			}
			else if (pragmas.klabs(fz - cz) < (32 << 8) && isanunderoperator(Engine.board.sector[psect].lotag))
			{
				activatebysector(psect, pi);
			}
		}

		if ((sb_snum & (1 << 18)) != 0 || p.hard_landing != 0)
		{
			p.return_to_center = (char)9;
		}

		if ((sb_snum & (1 << 13)) != 0)
		{
			p.return_to_center = (char)9;
			if ((sb_snum & (1 << 5)) != 0)
			{
				p.horiz += 12;
			}
			p.horiz += 12;
		}

		else if ((sb_snum & (1 << 14)) != 0)
		{
			p.return_to_center = (char)9;
			if ((sb_snum & (1 << 5)) != 0)
			{
				p.horiz -= 12;
			}
			p.horiz -= 12;
		}

		else if ((sb_snum & (1 << 3)) != 0)
		{
			if ((sb_snum & (1 << 5)) != 0)
			{
				p.horiz += 6;
			}
			p.horiz += 6;
		}

		else if ((sb_snum & (1 << 4)) != 0)
		{
			if ((sb_snum & (1 << 5)) != 0)
			{
				p.horiz -= 6;
			}
			p.horiz -= 6;
		}
		if (p.return_to_center > 0)
		{
			if ((sb_snum & (1 << 13)) == 0 && (sb_snum & (1 << 14)) == 0)
			{
				p.return_to_center--;
				p.horiz += 33 - (p.horiz / 3);
			}
		}

		if (p.hard_landing > 0)
		{
			p.hard_landing--;
			p.horiz -= (p.hard_landing << 4);
		}

		if (p.aim_mode != 0)
		{
			p.horiz += sync[snum].horz >> 1;
		}
		else
		{
			if (p.horiz > 95 && p.horiz < 105)
			{
				p.horiz = 100;
			}
			if (p.horizoff > -5 && p.horizoff < 5)
			{
				p.horizoff = 0;
			}
		}

		if (p.horiz > 299)
		{
			p.horiz = 299;
		}
		else if (p.horiz < -99)
		{
			p.horiz = -99;
		}

		//Shooting code/changes

		if (p.show_empty_weapon > 0)
		{
			p.show_empty_weapon--;
			if (p.show_empty_weapon == 0)
			{
				if (p.last_full_weapon == DefineConstants.GROW_WEAPON)
				{
					p.subweapon |= (1 << DefineConstants.GROW_WEAPON);
				}
				else if (p.last_full_weapon == DefineConstants.SHRINKER_WEAPON)
				{
					p.subweapon &= ~(1 << DefineConstants.GROW_WEAPON);
				}
				addweapon(p, p.last_full_weapon);
				return;
			}
		}

		if (p.knee_incs > 0)
		{
			p.knee_incs++;
			p.horiz -= 48;
			p.return_to_center = (char)9;
			if (p.knee_incs > 15)
			{
				p.knee_incs = 0;
				p.holster_weapon = 0;
				if (p.weapon_pos < 0)
				{
					p.weapon_pos = (short)(-p.weapon_pos);
				}
				if (p.actorsqu >= 0 && dist(Engine.board.sprite[pi], Engine.board.sprite[p.actorsqu]) < 1400)
				{
					guts(Engine.board.sprite[p.actorsqu], DefineConstants.JIBS6, 7, myconnectindex);
					spawn(p.actorsqu, DefineConstants.BLOODPOOL);
					spritesound(DefineConstants.SQUISHED, p.actorsqu);
					switch (Engine.board.sprite[p.actorsqu].picnum)
					{
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
							if (Engine.board.sprite[p.actorsqu].yvel != 0)
							{
								operaterespawns(Engine.board.sprite[p.actorsqu].yvel);
							}
							break;
					}

					if (Engine.board.sprite[p.actorsqu].picnum == DefineConstants.APLAYER)
					{
						quickkill(ps[Engine.board.sprite[p.actorsqu].yvel]);
						ps[Engine.board.sprite[p.actorsqu].yvel].frag_ps = snum;
					}
					else if (badguy(Engine.board.sprite[p.actorsqu]) != 0)
					{
						Engine.board.deletesprite(p.actorsqu);
						p.actors_killed++;
					}
					else
					{
						Engine.board.deletesprite(p.actorsqu);
					}
				}
				p.actorsqu = -1;
			}
			else if (p.actorsqu >= 0)
			{
				p.ang += (short)(getincangle(p.ang, (short)(Engine.getangle(Engine.board.sprite[p.actorsqu].x - p.posx, (short)(Engine.board.sprite[p.actorsqu].y - p.posy)))) >> 2);
			}
		}

		if (doincrements(p) != 0)
		{
			return;
		}

		if (p.weapon_pos != 0)
		{
			if (p.weapon_pos == -9)
			{
				if (p.last_weapon >= 0)
				{
					p.weapon_pos = 10;
					//                if(p->curr_weapon == KNEE_WEAPON) *p.kickback_pic = 1;
					p.last_weapon = -1;
				}
				else if (p.holster_weapon == 0)
				{
					p.weapon_pos = 10;
				}
			}
			else
			{
				p.weapon_pos--;
			}
		}

		// HACKS

		SHOOTINCODE:

		if (p.curr_weapon == DefineConstants.SHRINKER_WEAPON || p.curr_weapon == DefineConstants.GROW_WEAPON)
		{
			p.random_club_frame += 64; // Glowing
		}

		if (p.rapid_fire_hold == 1)
		{
			if ((sb_snum & (1 << 2)) != 0)
			{
				return;
			}
			p.rapid_fire_hold = (char)0;
		}

		if (shrunk || p.tipincs != 0 || p.access_incs != 0)
		{
			sb_snum &= ((~(1 << 2)));
		}
		else if (shrunk == false && (sb_snum & (1 << 2)) != 0 && p.kickback_pic == null && p.fist_incs == 0 && p.last_weapon == -1 && (p.weapon_pos == 0 || p.holster_weapon == 1))
		{

			p.crack_time = 777;

			if (p.holster_weapon == 1)
			{
				if (p.last_pissed_time <= (26 * 218) && p.weapon_pos == -9)
				{
					p.holster_weapon = 0;
					p.weapon_pos = 10;
					FTA(74, p);
				}
			}
			else
			{
				switch (p.curr_weapon)
				{
					case DefineConstants.HANDBOMB_WEAPON:
						p.hbomb_hold_delay = 0;
						if (p.ammo_amount[DefineConstants.HANDBOMB_WEAPON] > 0)
						{
							p.kickback_pic = 1;
						}
						break;
					case DefineConstants.HANDREMOTE_WEAPON:
						p.hbomb_hold_delay = 0;
						p.kickback_pic = 1;
						break;

					case DefineConstants.PISTOL_WEAPON:
						if (p.ammo_amount[DefineConstants.PISTOL_WEAPON] > 0)
						{
							p.ammo_amount[DefineConstants.PISTOL_WEAPON]--;
							p.kickback_pic = 1;
						}
						break;


					case DefineConstants.CHAINGUN_WEAPON:
						if (p.ammo_amount[DefineConstants.CHAINGUN_WEAPON] > 0) // && p->random_club_frame == 0)
						{
							p.kickback_pic = 1;
						}
						break;

					case DefineConstants.SHOTGUN_WEAPON:
						if (p.ammo_amount[DefineConstants.SHOTGUN_WEAPON] > 0 && p.random_club_frame == 0)
						{
							p.kickback_pic = 1;
						}
						break;
#if !VOLUMEONE
					//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
					case DefineConstants.TRIPBOMB_WEAPON:
						if (p.ammo_amount[DefineConstants.TRIPBOMB_WEAPON] > 0)
						{
							int sx = 0;
							int sy = 0;
							int sz = 0;
							int sect = 0;
							short hw = 0;
							short hitsp = 0;

							Engine.board.hitscan(p.posx, p.posy, p.posz, p.cursectnum, Engine.table.sintable[(p.ang + 512) & 2047], Engine.table.sintable[p.ang & 2047], (100 - p.horiz - p.horizoff) * 32, ref sect, ref hw,ref  hitsp, ref sx, ref sy, ref sz, (((256) << 16) + 64));

							if (sect < 0 || hitsp >= 0)
							{
								break;
							}

							if (hw >= 0 && Engine.board.sector[sect].lotag > 2)
							{
								break;
							}

							if (hw >= 0 && Engine.board.wall[hw].overpicnum >= 0)
							{
								if (Engine.board.wall[hw].overpicnum == DefineConstants.BIGFORCE)
								{
									break;
								}
							}

							j = (short)Engine.board.headspritesect[sect];
							while (j >= 0)
							{
								if (Engine.board.sprite[j].picnum == DefineConstants.TRIPBOMB && pragmas.klabs(Engine.board.sprite[j].z - sz) < (12 << 8) && ((Engine.board.sprite[j].x - sx) * (Engine.board.sprite[j].x - sx) + (Engine.board.sprite[j].y - sy) * (Engine.board.sprite[j].y - sy)) < (290 * 290))
								{
									break;
								}
								j = (short)Engine.board.nextspritesect[j];
							}

							if (j == -1 && hw >= 0 && (Engine.board.wall[hw].cstat & 16) == 0)
							{
								if ((Engine.board.wall[hw].nextsector >= 0 && Engine.board.sector[Engine.board.wall[hw].nextsector].lotag <= 2) || (Engine.board.wall[hw].nextsector == -1 && Engine.board.sector[sect].lotag <= 2))
								{
									if (((sx - p.posx) * (sx - p.posx) + (sy - p.posy) * (sy - p.posy)) < (290 * 290))
									{
										p.posz = p.oposz;
										p.poszv = 0;
										p.kickback_pic = 1;
									}
								}
							}
						}
						break;

					case DefineConstants.SHRINKER_WEAPON:
					case DefineConstants.GROW_WEAPON:
						if (p.curr_weapon == DefineConstants.GROW_WEAPON)
						{
							if (p.ammo_amount[DefineConstants.GROW_WEAPON] > 0)
							{
								p.kickback_pic = 1;
								spritesound(DefineConstants.EXPANDERSHOOT, pi);
							}
						}
						else if (p.ammo_amount[DefineConstants.SHRINKER_WEAPON] > 0)
						{
							p.kickback_pic = 1;
							spritesound(DefineConstants.SHRINKER_FIRE, pi);
						}
						break;

					case DefineConstants.FREEZE_WEAPON:
						if (p.ammo_amount[DefineConstants.FREEZE_WEAPON] > 0)
						{
							p.kickback_pic = 1;
							spritesound(DefineConstants.CAT_FIRE, pi);
						}
						break;
					case DefineConstants.DEVISTATOR_WEAPON:
						if (p.ammo_amount[DefineConstants.DEVISTATOR_WEAPON] > 0)
						{
							p.kickback_pic = 1;
							if (p.hbomb_hold_delay == 0)
								p.hbomb_hold_delay = 1;
							else
								p.hbomb_hold_delay = 0;

							spritesound(DefineConstants.CAT_FIRE, pi);
						}
						break;

#endif
					//C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
					case DefineConstants.RPG_WEAPON:
						if (p.ammo_amount[DefineConstants.RPG_WEAPON] > 0)
						{
							p.kickback_pic = 1;
						}
						break;

					case DefineConstants.KNEE_WEAPON:
						if (p.quick_kick == 0)
						{
							p.kickback_pic = 1;
						}
						break;
				}
			}
		}
		else if (p.kickback_pic != 0)
		{
			switch (p.curr_weapon)
			{
				case DefineConstants.HANDBOMB_WEAPON:

					if (p.kickback_pic == 6 && (sb_snum & (1 << 2)) != 0)
					{
						p.rapid_fire_hold = (char)1;
						break;
					}
					p.kickback_pic++;
					if (p.kickback_pic == 12)
					{
						p.ammo_amount[DefineConstants.HANDBOMB_WEAPON]--;

						if (p.on_ground != 0 && (sb_snum & 2) != 0)
						{
							k = 15;
							i = ((p.horiz + p.horizoff - 100) * 20);
						}
						else
						{
							k = 140;
							i = -512 - ((p.horiz + p.horizoff - 100) * 20);
						}

						j = EGS(p.cursectnum, p.posx + (Engine.table.sintable[(p.ang + 512) & 2047] >> 6), p.posy + (Engine.table.sintable[p.ang & 2047] >> 6), p.posz, DefineConstants.HEAVYHBOMB, -16, 9, 9, p.ang, (short)(k + (p.hbomb_hold_delay << 5)), i, pi, 1);

						if (k == 15)
						{
							Engine.board.sprite[j].yvel = 3;
							Engine.board.sprite[j].z += (8 << 8);
						}

						k = hits(pi);
						if (k < 512)
						{
							Engine.board.sprite[j].ang += 1024;
							Engine.board.sprite[j].zvel /= 3;
							Engine.board.sprite[j].xvel /= 3;
						}

						p.hbomb_on = (char)1;

					}
					else if (p.kickback_pic < 12 && (sb_snum & (1 << 2)) != 0)
					{
						p.hbomb_hold_delay++;
					}
					else if (p.kickback_pic > 19)
					{
						p.kickback_pic = 0;
						p.curr_weapon = DefineConstants.HANDREMOTE_WEAPON;
						p.last_weapon = -1;
						p.weapon_pos = 10;
					}

					break;


				case DefineConstants.HANDREMOTE_WEAPON:

					p.kickback_pic++;

					if (p.kickback_pic == 2)
					{
						p.hbomb_on = (char)0;
					}

					if (p.kickback_pic == 10)
					{
						p.kickback_pic = 0;
						if (p.ammo_amount[DefineConstants.HANDBOMB_WEAPON] > 0)
						{
							addweapon(p, DefineConstants.HANDBOMB_WEAPON);
						}
						else
						{
							checkavailweapon(p);
						}
					}
					break;

				case DefineConstants.PISTOL_WEAPON:
					if (p.kickback_pic == 1)
					{
						shoot(pi, DefineConstants.SHOTSPARK1);
						spritesound(DefineConstants.PISTOL_FIRE, pi);

						lastvisinc = totalclock + 32;
						p.visibility = 0;
					}
					else if (p.kickback_pic == 2)
					{
						spawn(pi, DefineConstants.SHELL);
					}

					p.kickback_pic++;

					if (p.kickback_pic >= 5)
					{
						if (p.ammo_amount[DefineConstants.PISTOL_WEAPON] <= 0 || (p.ammo_amount[DefineConstants.PISTOL_WEAPON] % 12) != 0)
						{
							p.kickback_pic = 0;
							checkavailweapon(p);
						}
						else
						{
							switch (p.kickback_pic)
							{
								case 5:
									spritesound(DefineConstants.EJECT_CLIP, pi);
									break;
								case 8:
									spritesound(DefineConstants.INSERT_CLIP, pi);
									break;
							}
						}
					}

					if (p.kickback_pic == 27)
					{
						p.kickback_pic = 0;
						checkavailweapon(p);
					}

					break;

				case DefineConstants.SHOTGUN_WEAPON:

					p.kickback_pic++;

					if (p.kickback_pic == 4)
					{
						shoot(pi, DefineConstants.SHOTGUN);
						shoot(pi, DefineConstants.SHOTGUN);
						shoot(pi, DefineConstants.SHOTGUN);
						shoot(pi, DefineConstants.SHOTGUN);
						shoot(pi, DefineConstants.SHOTGUN);
						shoot(pi, DefineConstants.SHOTGUN);
						shoot(pi, DefineConstants.SHOTGUN);

						p.ammo_amount[DefineConstants.SHOTGUN_WEAPON]--;

						spritesound(DefineConstants.SHOTGUN_FIRE, pi);

						lastvisinc = totalclock + 32;
						p.visibility = 0;
					}

					switch (p.kickback_pic)
					{
						case 13:
							checkavailweapon(p);
							break;
						case 15:
							spritesound(DefineConstants.SHOTGUN_COCK, pi);
							break;
						case 17:
						case 20:
							p.kickback_pic++;
							break;
						case 24:
							j = spawn(pi, DefineConstants.SHOTGUNSHELL);
							Engine.board.sprite[j].ang += 1024;
							ssp((short)j, (uint)(((1) << 16) + 1));
							Engine.board.sprite[j].ang += 1024;
							p.kickback_pic++;
							break;
						case 31:
							p.kickback_pic = 0;
							return;
					}
					break;

				case DefineConstants.CHAINGUN_WEAPON:

					p.kickback_pic++;

					if ((p.kickback_pic) <= 12)
					{
						if (((p.kickback_pic) % 3) == 0)
						{
							p.ammo_amount[DefineConstants.CHAINGUN_WEAPON]--;

							if (((p.kickback_pic) % 3) == 0)
							{
								j = spawn(pi, DefineConstants.SHELL);

								Engine.board.sprite[j].ang += 1024;
								Engine.board.sprite[j].ang &= 2047;
								Engine.board.sprite[j].xvel += 32;
								Engine.board.sprite[j].z += (3 << 8);
								ssp((short)j, (uint)(((1) << 16) + 1));
							}

							spritesound(DefineConstants.CHAINGUN_FIRE, pi);
							shoot(pi, DefineConstants.CHAINGUN);
							lastvisinc = totalclock + 32;
							p.visibility = 0;
							checkavailweapon(p);

							if ((sb_snum & (1 << 2)) == 0)
							{
								p.kickback_pic = 0;
								break;
							}
						}
					}
					else if (p.kickback_pic > 10)
					{
						if ((sb_snum & (1 << 2)) != 0)
						{
							p.kickback_pic = 1;
						}
						else
						{
							p.kickback_pic = 0;
						}
					}

					break;

				case DefineConstants.SHRINKER_WEAPON:
				case DefineConstants.GROW_WEAPON:

					if (p.curr_weapon == DefineConstants.GROW_WEAPON)
					{
						if (p.kickback_pic > 3)
						{
							p.kickback_pic = 0;
							if (screenpeek == snum)
							{
								pus = (char)1;
							}
							p.ammo_amount[DefineConstants.GROW_WEAPON]--;
							shoot(pi, DefineConstants.GROWSPARK);

							p.visibility = 0;
							lastvisinc = totalclock + 32;
							checkavailweapon(p);
						}
						else
						{
							p.kickback_pic++;
						}
					}
					else
					{
						if (p.kickback_pic > 10)
						{
							p.kickback_pic = 0;

							p.ammo_amount[DefineConstants.SHRINKER_WEAPON]--;
							shoot(pi, DefineConstants.SHRINKER);

							p.visibility = 0;
							lastvisinc = totalclock + 32;
							checkavailweapon(p);
						}
						else
						{
							p.kickback_pic++;
						}
					}
					break;

				case DefineConstants.DEVISTATOR_WEAPON:
					if (p.kickback_pic != 0)
					{
						p.kickback_pic++;

						if ((p.kickback_pic & 1) != 0)
						{
							p.visibility = 0;
							lastvisinc = totalclock + 32;
							shoot(pi, DefineConstants.RPG);
							p.ammo_amount[DefineConstants.DEVISTATOR_WEAPON]--;
							checkavailweapon(p);
						}
						if (p.kickback_pic > 5)
						{
							p.kickback_pic = 0;
						}
					}
					break;
				case DefineConstants.FREEZE_WEAPON:

					if (p.kickback_pic < 4)
					{
						p.kickback_pic++;
						if (p.kickback_pic == 3)
						{
							p.ammo_amount[DefineConstants.FREEZE_WEAPON]--;
							p.visibility = 0;
							lastvisinc = totalclock + 32;
							shoot(pi, DefineConstants.FREEZEBLAST);
							checkavailweapon(p);
						}
						if (s.xrepeat < 32)
						{
							p.kickback_pic = 0;
							break;
						}
					}
					else
					{
						if ((sb_snum & (1 << 2)) != 0)
						{
							p.kickback_pic = 1;
							spritesound(DefineConstants.CAT_FIRE, pi);
						}
						else
						{
							p.kickback_pic = 0;
						}
					}
					break;

				case DefineConstants.TRIPBOMB_WEAPON:
					if (p.kickback_pic < 4)
					{
						p.posz = p.oposz;
						p.poszv = 0;
						if (p.kickback_pic == 3)
						{
							shoot(pi, DefineConstants.HANDHOLDINGLASER);
						}
					}
					if (p.kickback_pic == 16)
					{
						p.kickback_pic = 0;
						checkavailweapon(p);
						p.weapon_pos = -9;
					}
					else
					{
						p.kickback_pic++;
					}
					break;
				case DefineConstants.KNEE_WEAPON:
					p.kickback_pic++;

					if (p.kickback_pic == 7)
					{
						shoot(pi, DefineConstants.KNEE);
					}
					else if (p.kickback_pic == 14)
					{
						if ((sb_snum & (1 << 2)) != 0)
						{
							p.kickback_pic = (short)(1 + (Engine.krand() & 3));
						}
						else
						{
							p.kickback_pic = 0;
						}
					}

					if (p.wantweaponfire >= 0)
					{
						checkavailweapon(p);
					}
					break;

				case DefineConstants.RPG_WEAPON:
					p.kickback_pic++;
					if (p.kickback_pic == 4)
					{
						p.ammo_amount[DefineConstants.RPG_WEAPON]--;
						lastvisinc = totalclock + 32;
						p.visibility = 0;
						shoot(pi, DefineConstants.RPG);
						checkavailweapon(p);
					}
					else if (p.kickback_pic == 20)
					{
						p.kickback_pic = 0;
					}
					break;
			}
		}
	}



	//UPDATE THIS FILE OVER THE OLD GETSPRITESCORE/COMPUTERGETINPUT FUNCTIONS
	//C++ TO C# CONVERTER WARNING: The following constructor is declared outside of its associated class:
	public static int getspritescore(int snum, int dapicnum)
	{
		switch (dapicnum)
		{
			case DefineConstants.FIRSTGUNSPRITE:
				return (5);
			case DefineConstants.CHAINGUNSPRITE:
				return (50);
			case DefineConstants.RPGSPRITE:
				return (200);
			case DefineConstants.FREEZESPRITE:
				return (25);
			case DefineConstants.SHRINKERSPRITE:
				return (80);
			case DefineConstants.HEAVYHBOMB:
				return (60);
			case DefineConstants.TRIPBOMBSPRITE:
				return (50);
			case DefineConstants.SHOTGUNSPRITE:
				return (120);
			case DefineConstants.DEVISTATORSPRITE:
				return (120);

			case DefineConstants.FREEZEAMMO:
				if (ps[snum].ammo_amount[DefineConstants.FREEZE_WEAPON] < max_ammo_amount[DefineConstants.FREEZE_WEAPON])
				{
					return (10);
				}
				else
				{
					return (0);
				}
			case DefineConstants.AMMO:
				if (ps[snum].ammo_amount[DefineConstants.SHOTGUN_WEAPON] < max_ammo_amount[DefineConstants.SHOTGUN_WEAPON])
				{
					return (10);
				}
				else
				{
					return (0);
				}
			case DefineConstants.BATTERYAMMO:
				if (ps[snum].ammo_amount[DefineConstants.CHAINGUN_WEAPON] < max_ammo_amount[DefineConstants.CHAINGUN_WEAPON])
				{
					return (20);
				}
				else
				{
					return (0);
				}
			case DefineConstants.DEVISTATORAMMO:
				if (ps[snum].ammo_amount[DefineConstants.DEVISTATOR_WEAPON] < max_ammo_amount[DefineConstants.DEVISTATOR_WEAPON])
				{
					return (25);
				}
				else
				{
					return (0);
				}
			case DefineConstants.RPGAMMO:
				if (ps[snum].ammo_amount[DefineConstants.RPG_WEAPON] < max_ammo_amount[DefineConstants.RPG_WEAPON])
				{
					return (50);
				}
				else
				{
					return (0);
				}
			case DefineConstants.CRYSTALAMMO:
				if (ps[snum].ammo_amount[DefineConstants.SHRINKER_WEAPON] < max_ammo_amount[DefineConstants.SHRINKER_WEAPON])
				{
					return (10);
				}
				else
				{
					return (0);
				}
			case DefineConstants.HBOMBAMMO:
				if (ps[snum].ammo_amount[DefineConstants.HANDBOMB_WEAPON] < max_ammo_amount[DefineConstants.HANDBOMB_WEAPON])
				{
					return (30);
				}
				else
				{
					return (0);
				}
			case DefineConstants.SHOTGUNAMMO:
				if (ps[snum].ammo_amount[DefineConstants.SHOTGUN_WEAPON] < max_ammo_amount[DefineConstants.SHOTGUN_WEAPON])
				{
					return (25);
				}
				else
				{
					return (0);
				}

			case DefineConstants.COLA:
				if (Engine.board.sprite[ps[snum].i].extra < 100)
				{
					return (10);
				}
				else
				{
					return (0);
				}
			case DefineConstants.SIXPAK:
				if (Engine.board.sprite[ps[snum].i].extra < 100)
				{
					return (30);
				}
				else
				{
					return (0);
				}
			case DefineConstants.FIRSTAID:
				if (ps[snum].firstaid_amount < 100)
				{
					return (100);
				}
				else
				{
					return (0);
				}
			case DefineConstants.SHIELD:
				if (ps[snum].shield_amount < 100)
				{
					return (50);
				}
				else
				{
					return (0);
				}
			case DefineConstants.STEROIDS:
				if (ps[snum].steroids_amount < 400)
				{
					return (30);
				}
				else
				{
					return (0);
				}
			case DefineConstants.AIRTANK:
				if (ps[snum].scuba_amount < 6400)
				{
					return (30);
				}
				else
				{
					return (0);
				}
			case DefineConstants.JETPACK:
				if (ps[snum].jetpack_amount < 1600)
				{
					return (100);
				}
				else
				{
					return (0);
				}
			case DefineConstants.HEATSENSOR:
				if (ps[snum].heat_amount < 1200)
				{
					return (10);
				}
				else
				{
					return (0);
				}
			case DefineConstants.ACCESSCARD:
				return (1);
			case DefineConstants.BOOTS:
				if (ps[snum].boot_amount < 200)
				{
					return (50);
				}
				else
				{
					return (0);
				}
			case DefineConstants.ATOMICHEALTH:
				if (Engine.board.sprite[ps[snum].i].extra < max_player_health)
				{
					return (50);
				}
				else
				{
					return (0);
				}
			case DefineConstants.HOLODUKE:
				if (ps[snum].holoduke_amount < 2400)
				{
					return (30);
				}
				else
				{
					return (0);
				}
		}
		return (0);
	}

	internal static int[][] fdmatrix =
	{
		new int[] {128, -1, -1, -1, 128, -1, -1, -1, 128, -1, 128, -1},
		new int[] {1024, 1024, 1024, 1024, 2560, 128, 2560, 2560, 1024, 2560, 2560, 2560},
		new int[] {512, 512, 512, 512, 2560, 128, 2560, 2560, 1024, 2560, 2560, 2560},
		new int[] {512, 512, 512, 512, 2560, 128, 2560, 2560, 1024, 2560, 2560, 2560},
		new int[] {2560, 2560, 2560, 2560, 2560, 2560, 2560, 2560, 2560, 2560, 2560, 2560},
		new int[] {512, 512, 512, 512, 2048, 512, 2560, 2560, 512, 2560, 2560, 2560},
		new int[] {128, 128, 128, 128, 2560, 128, 2560, 2560, 128, 128, 128, 128},
		new int[] {1536, 1536, 1536, 1536, 2560, 1536, 1536, 1536, 1536, 1536, 1536, 1536},
		new int[] {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1},
		new int[] {128, 128, 128, 128, 2560, 128, 2560, 2560, 128, 128, 128, 128},
		new int[] {2560, 2560, 2560, 2560, 2560, 2560, 2560, 2560, 2560, 2560, 2560, 2560},
		new int[] {128, 128, 128, 128, 2560, 128, 2560, 2560, 128, 128, 128, 128}
	};

	internal static int[] goalx = new int[DefineConstants.MAXPLAYERS];
	internal static int[] goaly = new int[DefineConstants.MAXPLAYERS];
	internal static int[] goalz = new int[DefineConstants.MAXPLAYERS];
	internal static int[] goalsect = new int[DefineConstants.MAXPLAYERS];
	internal static int[] goalwall = new int[DefineConstants.MAXPLAYERS];
	internal static int[] goalsprite = new int[DefineConstants.MAXPLAYERS];
	internal static int[] goalplayer = new int[DefineConstants.MAXPLAYERS];
	internal static int[] clipmovecount = new int[DefineConstants.MAXPLAYERS];
	public static short[] searchsect = new short[DefineConstants.MAXSECTORS];
	public static short[] searchparent = new short[DefineConstants.MAXSECTORS];
	//C++ TO C# CONVERTER TODO TASK: The following statement was not recognized, possibly due to an unrecognized macro:
	public static char[] dashow2dsector = new char[(DefineConstants.MAXSECTORS + 7) >> 3];
	public static void computergetinput(int snum, input syn)
	{
// jmarshall - legacy bot code?
/*
		int i;
		int j;
		int k;
		int l;
		int x1;
		int y1;
		int z1;
		int x2;
		int y2;
		int z2;
		int x3;
		int y3;
		int z3;
		int dx;
		int dy;
		int dist;
		int daang;
		int zang;
		int fightdist;
		int damyang;
		int damysect;
		int startsect;
		int endsect;
		int splc;
		int send;
		int startwall;
		int endwall;
		short dasect;
		short dawall;
		short daspr;
		player_struct p;
		walltype wal;

		p = ps[snum];
		syn.fvel = 0;
		syn.svel = 0;
		syn.avel = 0;
		syn.horz = 0;
		syn.bits = 0;

		x1 = Engine.board.sprite[p.i].x;
		y1 = Engine.board.sprite[p.i].y;
		z1 = Engine.board.sprite[p.i].z;
		damyang = Engine.board.sprite[p.i].ang;
		damysect = Engine.board.sprite[p.i].sectnum;
		if ((numplayers >= 2) && (snum == myconnectindex))
		{
			x1 = myx;
			y1 = myy;
			z1 = myz + (38 << 8);
			damyang = myang;
			damysect = mycursectnum;
		}

		if ((numframes & 7) == 0)
		{
			if (!Engine.board.cansee(x1, y1, z1 - (48 << 8), damysect, x2, y2, z2 - (48 << 8), Engine.board.sprite[ps[goalplayer[snum]].i].sectnum))
			{
				goalplayer[snum] = snum;
			}
		}

		if ((goalplayer[snum] == snum) || (ps[goalplayer[snum]].dead_flag != 0))
		{
			j = 0x7fffffff;
			for (i = connecthead; i >= 0; i = connectpoint2[i])
			{
				if (i != snum)
				{
					dist = ksqrt((Engine.board.sprite[ps[i].i].x - x1) * (Engine.board.sprite[ps[i].i].x - x1) + (Engine.board.sprite[ps[i].i].y - y1) * (Engine.board.sprite[ps[i].i].y - y1));

					x2 = Engine.board.sprite[ps[i].i].x;
					y2 = Engine.board.sprite[ps[i].i].y;
					z2 = Engine.board.sprite[ps[i].i].z;
					if (!Engine.board.cansee(x1, y1, z1 - (48 << 8), damysect, x2, y2, z2 - (48 << 8), Engine.board.sprite[ps[i].i].sectnum))
					{
						dist <<= 1;
					}

					if (dist < j)
					{
						j = dist;
						goalplayer[snum] = i;
					}
				}
			}
		}

		x2 = Engine.board.sprite[ps[goalplayer[snum]].i].x;
		y2 = Engine.board.sprite[ps[goalplayer[snum]].i].y;
		z2 = Engine.board.sprite[ps[goalplayer[snum]].i].z;

		if (p.dead_flag != 0)
		{
			syn.bits |= (1 << 29);
		}
		if ((p.firstaid_amount > 0) && (p.last_extra < 100))
		{
			syn.bits |= (1 << 16);
		}

		for (j = (short)Engine.board.headspritestat[4]; j >= 0; j = (short)Engine.board.nextspritestat[j])
		{
			switch (Engine.board.sprite[j].picnum)
			{
				case DefineConstants.TONGUE:
					k = 4;
					break;
				case DefineConstants.FREEZEBLAST:
					k = 4;
					break;
				case DefineConstants.SHRINKSPARK:
					k = 16;
					break;
				case DefineConstants.RPG:
					k = 16;
					break;
				default:
					k = 0;
					break;
			}
			if (k != 0)
			{
				x3 = Engine.board.sprite[j].x;
				y3 = Engine.board.sprite[j].y;
				z3 = Engine.board.sprite[j].z;
				for (l = 0; l <= 8; l++)
				{
					if (pragmas.tmulscale11(x3 - x1, x3 - x1, y3 - y1, y3 - y1, (z3 - z1) >> 4, (z3 - z1) >> 4) < 3072)
					{
						dx = Engine.table.sintable[(Engine.board.sprite[j].ang + 512) & 2047];
						dy = Engine.table.sintable[Engine.board.sprite[j].ang & 2047];
						if ((x1 - x3) * dy > (y1 - y3) * dx)
						{
							i = -k * 512;
						}
						else
						{
							i = k * 512;
						}
						syn.fvel -= mulscale17(dy, i);
						syn.svel += mulscale17(dx, i);
					}
					if (l < 7)
					{
						x3 += (mulscale14(Engine.board.sprite[j].xvel, Engine.table.sintable[(Engine.board.sprite[j].ang + 512) & 2047]) << 2);
						y3 += (mulscale14(Engine.board.sprite[j].xvel, Engine.table.sintable[Engine.board.sprite[j].ang & 2047]) << 2);
						z3 += (Engine.board.sprite[j].zvel << 2);
					}
					else
					{
						Engine.board.hitscan(Engine.board.sprite[j].x, Engine.board.sprite[j].y, Engine.board.sprite[j].z, Engine.board.sprite[j].sectnum, mulscale14(Engine.board.sprite[j].xvel, Engine.table.sintable[(Engine.board.sprite[j].ang + 512) & 2047]), mulscale14(Engine.board.sprite[j].xvel, Engine.table.sintable[Engine.board.sprite[j].ang & 2047]), (int)Engine.board.sprite[j].zvel, dasect, dawall, daspr, x3, y3, z3, (((256) << 16) + 64));
					}
				}
			}
		}

		if ((ps[goalplayer[snum]].dead_flag == 0) && ((Engine.board.cansee(x1, y1, z1, damysect, x2, y2, z2, Engine.board.sprite[ps[goalplayer[snum]].i].sectnum)) || (Engine.board.cansee(x1, y1, z1 - (24 << 8), damysect, x2, y2, z2 - (24 << 8), Engine.board.sprite[ps[goalplayer[snum]].i].sectnum)) || (Engine.board.cansee(x1, y1, z1 - (48 << 8), damysect, x2, y2, z2 - (48 << 8), Engine.board.sprite[ps[goalplayer[snum]].i].sectnum))))
		{
			syn.bits |= (1 << 2);

			if ((p.curr_weapon == DefineConstants.HANDBOMB_WEAPON) && ((rand() & 7) == 0))
			{
				syn.bits &= ~(1 << 2);
			}

			if (p.curr_weapon == DefineConstants.TRIPBOMB_WEAPON)
			{
				syn.bits |= ((rand() % DefineConstants.MAX_WEAPONS) << 8);
			}

			if (p.curr_weapon == DefineConstants.RPG_WEAPON)
			{
				Engine.board.hitscan(x1, y1, z1 - (38 << 8), damysect, Engine.table.sintable[(damyang + 512) & 2047], Engine.table.sintable[damyang & 2047], (100 - p.horiz - p.horizoff) * 32, dasect, dawall, daspr, x3, y3, z3, (((256) << 16) + 64));
				if ((x3 - x1) * (x3 - x1) + (y3 - y1) * (y3 - y1) < 2560 * 2560)
				{
					syn.bits &= ~(1 << 2);
				}
			}


			fightdist = fdmatrix[p.curr_weapon][ps[goalplayer[snum]].curr_weapon];
			if (fightdist < 128)
			{
				fightdist = 128;
			}
			dist = ksqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
			if (dist == 0)
			{
				dist = 1;
			}
			daang = Engine.getangle(x2 + (ps[goalplayer[snum]].posxv >> 14) - x1, y2 + (ps[goalplayer[snum]].posyv >> 14) - y1);
			zang = 100 - ((z2 - z1) * 8) / dist;
			fightdist = Math.Max(fightdist, (pragmas.klabs(z2 - z1) >> 4));

			if (Engine.board.sprite[ps[goalplayer[snum]].i].yrepeat < 32)
			{
				fightdist = 0;
				syn.bits &= ~(1 << 2);
			}
			if (Engine.board.sprite[ps[goalplayer[snum]].i].pal == 1)
			{
				fightdist = 0;
				syn.bits &= ~(1 << 2);
			}

			if (dist < 256)
			{
				syn.bits |= (1 << 22);
			}

			x3 = x2 + ((x1 - x2) * fightdist / dist);
			y3 = y2 + ((y1 - y2) * fightdist / dist);
			syn.fvel += (x3 - x1) * 2047 / dist;
			syn.svel += (y3 - y1) * 2047 / dist;

			//Strafe attack
			if (fightdist != 0)
			{
				j = totalclock + snum * 13468;
				i = Engine.table.sintable[(j << 6) & 2047];
				i += Engine.table.sintable[((j + 4245) << 5) & 2047];
				i += Engine.table.sintable[((j + 6745) << 4) & 2047];
				i += Engine.table.sintable[((j + 15685) << 3) & 2047];
				dx = Engine.table.sintable[(Engine.board.sprite[ps[goalplayer[snum]].i].ang + 512) & 2047];
				dy = Engine.table.sintable[Engine.board.sprite[ps[goalplayer[snum]].i].ang & 2047];
				if ((x1 - x2) * dy > (y1 - y2) * dx)
				{
					i += 8192;
				}
				else
				{
					i -= 8192;
				}
				syn.fvel += ((Engine.table.sintable[(daang + 1024) & 2047] * i) >> 17);
				syn.svel += ((Engine.table.sintable[(daang + 512) & 2047] * i) >> 17);
			}

			syn.avel = (sbyte)Math.Min(Math.Max((((daang + 1024 - damyang) & 2047) - 1024) >> 1, -127), 127);
			syn.horz = (sbyte)Math.Min(Math.Max((zang - p.horiz) >> 1, -DefineConstants.MAXHORIZ), DefineConstants.MAXHORIZ);
			syn.bits |= (1 << 23);
			return;
		}

		goalsect[snum] = -1;
		if (goalsect[snum] < 0)
		{
			goalwall[snum] = -1;
			startsect = Engine.board.sprite[p.i].sectnum;
			endsect = Engine.board.sprite[ps[goalplayer[snum]].i].sectnum;

			clearbufbyte(dashow2dsector, (DefineConstants.MAXSECTORS + 7) >> 3, 0);
			searchsect[0] = (short)startsect;
			searchparent[0] = -1;
			dashow2dEngine.board.sector[startsect >> 3] |= (1 << (startsect & 7));
			for (splc = 0, send = 1; splc < send; splc++)
			{
				startwall = Engine.board.sector[searchsect[splc]].wallptr;
				endwall = startwall + Engine.board.sector[searchsect[splc]].wallnum;
				for (i = startwall, wal = Engine.board.wall[startwall]; i < endwall; i++, wal++)
				{
					j = wal.nextsector;
					if (j < 0)
					{
						continue;
					}

					dx = ((Engine.board.wall[wal.point2].x + wal.x) >> 1);
					dy = ((Engine.board.wall[wal.point2].y + wal.y) >> 1);
					if ((getceilzofslope(j, dx, dy) > getflorzofslope(j, dx, dy) - (28 << 8)) && ((Engine.board.sector[j].lotag < 15) || (Engine.board.sector[j].lotag > 22)))
					{
						continue;
					}
					if (getflorzofslope(j, dx, dy) < getflorzofslope(searchsect[splc], dx, dy) - (72 << 8))
					{
						continue;
					}
					if ((dashow2dEngine.board.sector[j >> 3] & (1 << (j & 7))) == 0)
					{
						dashow2dEngine.board.sector[j >> 3] |= (1 << (j & 7));
						searchsect[send] = (short)j;
						searchparent[send] = (short)splc;
						send++;
						if (j == endsect)
						{
							clearbufbyte(dashow2dsector, (DefineConstants.MAXSECTORS + 7) >> 3, 0);
							for (k = send - 1; k >= 0; k = searchparent[k])
							{
								dashow2dEngine.board.sector[searchsect[k] >> 3] |= (1 << (searchsect[k] & 7));
							}

							for (k = send - 1; k >= 0; k = searchparent[k])
							{
								if (searchparent[k] == 0)
								{
									break;
								}
							}

							goalsect[snum] = searchsect[k];
							startwall = Engine.board.sector[goalsect[snum]].wallptr;
							endwall = startwall + Engine.board.sector[goalsect[snum]].wallnum;
							x3 = y3 = 0;
							for (i = startwall; i < endwall; i++)
							{
								x3 += Engine.board.wall[i].x;
								y3 += Engine.board.wall[i].y;
							}
							x3 /= (endwall - startwall);
							y3 /= (endwall - startwall);

							startwall = Engine.board.sector[startsect].wallptr;
							endwall = startwall + Engine.board.sector[startsect].wallnum;
							l = 0;
							k = startwall;
							for (i = startwall; i < endwall; i++)
							{
								if (Engine.board.wall[i].nextsector != goalsect[snum])
								{
									continue;
								}
								dx = Engine.board.wall[Engine.board.wall[i].point2].x - Engine.board.wall[i].x;
								dy = Engine.board.wall[Engine.board.wall[i].point2].y - Engine.board.wall[i].y;

								//if (dx*(y1-Engine.board.wall[i].y) <= dy*(x1-Engine.board.wall[i].x))
								//   if (dx*(y2-Engine.board.wall[i].y) >= dy*(x2-Engine.board.wall[i].x))
								if ((x3 - x1) * (Engine.board.wall[i].y - y1) <= (y3 - y1) * (Engine.board.wall[i].x - x1))
								{
									if ((x3 - x1) * (Engine.board.wall[Engine.board.wall[i].point2].y - y1) >= (y3 - y1) * (Engine.board.wall[Engine.board.wall[i].point2].x - x1))
									{
										k = i;
										break;
									}
								}

								dist = ksqrt(dx * dx + dy * dy);
								if (dist > l)
								{
									l = dist;
									k = i;
								}
							}
							goalwall[snum] = k;
							daang = ((Engine.getangle(Engine.board.wall[Engine.board.wall[k].point2].x - Engine.board.wall[k].x, Engine.board.wall[Engine.board.wall[k].point2].y - Engine.board.wall[k].y) + 1536) & 2047);
							goalx[snum] = ((Engine.board.wall[k].x + Engine.board.wall[Engine.board.wall[k].point2].x) >> 1) + (Engine.table.sintable[(daang + 512) & 2047] >> 8);
							goaly[snum] = ((Engine.board.wall[k].y + Engine.board.wall[Engine.board.wall[k].point2].y) >> 1) + (Engine.table.sintable[daang & 2047] >> 8);
							goalz[snum] = Engine.board.sector[goalsect[snum]].floorz - (32 << 8);
							break;
						}
					}
				}

				for (i = (short)Engine.board.headspritesect[searchsect[splc]]; i >= 0; i = (short)Engine.board.nextspritesect[i])
				{
					if (Engine.board.sprite[i].lotag == 7)
					{
						j = Engine.board.sprite[Engine.board.sprite[i].owner].sectnum;
						if ((dashow2dEngine.board.sector[j >> 3] & (1 << (j & 7))) == 0)
						{
							dashow2dEngine.board.sector[j >> 3] |= (1 << (j & 7));
							searchsect[send] = (short)j;
							searchparent[send] = (short)splc;
							send++;
							if (j == endsect)
							{
								clearbufbyte(dashow2dsector, (DefineConstants.MAXSECTORS + 7) >> 3, 0);
								for (k = send - 1; k >= 0; k = searchparent[k])
								{
									dashow2dEngine.board.sector[searchsect[k] >> 3] |= (1 << (searchsect[k] & 7));
								}

								for (k = send - 1; k >= 0; k = searchparent[k])
								{
									if (searchparent[k] == 0)
									{
										break;
									}
								}

								goalsect[snum] = searchsect[k];
								startwall = Engine.board.sector[startsect].wallptr;
								endwall = startwall + Engine.board.sector[startsect].wallnum;
								l = 0;
								k = startwall;
								for (i = startwall; i < endwall; i++)
								{
									dx = Engine.board.wall[Engine.board.wall[i].point2].x - Engine.board.wall[i].x;
									dy = Engine.board.wall[Engine.board.wall[i].point2].y - Engine.board.wall[i].y;
									dist = ksqrt(dx * dx + dy * dy);
									if ((Engine.board.wall[i].nextsector == goalsect[snum]) && (dist > l))
									{
										l = dist;
										k = i;
									}
								}
								goalwall[snum] = k;
								daang = ((Engine.getangle(Engine.board.wall[Engine.board.wall[k].point2].x - Engine.board.wall[k].x, Engine.board.wall[Engine.board.wall[k].point2].y - Engine.board.wall[k].y) + 1536) & 2047);
								goalx[snum] = ((Engine.board.wall[k].x + Engine.board.wall[Engine.board.wall[k].point2].x) >> 1) + (Engine.table.sintable[(daang + 512) & 2047] >> 8);
								goaly[snum] = ((Engine.board.wall[k].y + Engine.board.wall[Engine.board.wall[k].point2].y) >> 1) + (Engine.table.sintable[daang & 2047] >> 8);
								goalz[snum] = Engine.board.sector[goalsect[snum]].floorz - (32 << 8);
								break;
							}
						}
					}
				}
				if (goalwall[snum] >= 0)
				{
					break;
				}
			}
		}

		if ((goalsect[snum] < 0) || (goalwall[snum] < 0))
		{
			if (goalEngine.board.sprite[snum] < 0)
			{
				for (k = 0; k < 4; k++)
				{
					i = (rand() % numsectors);
					for (j = (short)Engine.board.headspritesect[i]; j >= 0; j = (short)Engine.board.nextspritesect[j])
					{
						if ((Engine.board.sprite[j].xrepeat <= 0) || (Engine.board.sprite[j].yrepeat <= 0))
						{
							continue;
						}
						if (getspritescore(snum, Engine.board.sprite[j].picnum) <= 0)
						{
							continue;
						}
						if (Engine.board.cansee(x1, y1, z1 - (32 << 8), damysect, Engine.board.sprite[j].x, Engine.board.sprite[j].y, Engine.board.sprite[j].z - (4 << 8), i))
						{
							goalx[snum] = Engine.board.sprite[j].x;
							goaly[snum] = Engine.board.sprite[j].y;
							goalz[snum] = Engine.board.sprite[j].z;
							goalEngine.board.sprite[snum] = j;
							break;
						}
					}
				}
			}
			x2 = goalx[snum];
			y2 = goaly[snum];
			dist = ksqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
			if (dist == 0)
			{
				return;
			}
			daang = Engine.getangle(x2 - x1, y2 - y1);
			syn.fvel += (x2 - x1) * 2047 / dist;
			syn.svel += (y2 - y1) * 2047 / dist;
			syn.avel = (sbyte)Math.Min(Math.Max((((daang + 1024 - damyang) & 2047) - 1024) >> 3, -127), 127);
		}
		else
		{
			goalEngine.board.sprite[snum] = -1;
		}

		x3 = p.posx;
		y3 = p.posy;
		z3 = p.posz;
		dasect = p.cursectnum;
		i = clipmove(x3, y3, z3, dasect, p.posxv, p.posyv, 164, 4 << 8, 4 << 8, (((1) << 16) + 1));
		if (i == 0)
		{
			x3 = p.posx;
			y3 = p.posy;
			z3 = p.posz + (24 << 8);
			dasect = p.cursectnum;
			i = clipmove(x3, y3, z3, dasect, p.posxv, p.posyv, 164, 4 << 8, 4 << 8, (((1) << 16) + 1));
		}
		if (i != 0)
		{
			clipmovecount[snum]++;

			j = 0;
			if ((i & 0xc000) == 32768) //Hit a wall (49152 for sprite)
			{
				if (Engine.board.wall[i & (DefineConstants.MAXWALLS - 1)].nextsector >= 0)
				{
					if (getflorzofslope(Engine.board.wall[i & (DefineConstants.MAXWALLS - 1)].nextsector, p.posx, p.posy) <= p.posz + (24 << 8))
					{
						j |= 1;
					}
					if (getceilzofslope(Engine.board.wall[i & (DefineConstants.MAXWALLS - 1)].nextsector, p.posx, p.posy) >= p.posz - (24 << 8))
					{
						j |= 2;
					}
				}
			}
			if ((i & 0xc000) == 49152)
			{
				j = 1;
			}
			if ((j & 1) != 0)
			{
				if (clipmovecount[snum] == 4)
				{
					syn.bits |= (1 << 0);
				}
			}
			if ((j & 2) != 0)
			{
				syn.bits |= (1 << 1);
			}

			//Strafe attack
			daang = Engine.getangle(x2 - x1, y2 - y1);
			if ((i & 0xc000) == 32768)
			{
				daang = Engine.getangle(Engine.board.wall[Engine.board.wall[i & (DefineConstants.MAXWALLS - 1)].point2].x - Engine.board.wall[i & (DefineConstants.MAXWALLS - 1)].x, Engine.board.wall[Engine.board.wall[i & (DefineConstants.MAXWALLS - 1)].point2].y - Engine.board.wall[i & (DefineConstants.MAXWALLS - 1)].y);
			}
			j = totalclock + snum * 13468;
			i = Engine.table.sintable[(j << 6) & 2047];
			i += Engine.table.sintable[((j + 4245) << 5) & 2047];
			i += Engine.table.sintable[((j + 6745) << 4) & 2047];
			i += Engine.table.sintable[((j + 15685) << 3) & 2047];
			syn.fvel += ((Engine.table.sintable[(daang + 1024) & 2047] * i) >> 17);
			syn.svel += ((Engine.table.sintable[(daang + 512) & 2047] * i) >> 17);

			if ((clipmovecount[snum] & 31) == 2)
			{
				syn.bits |= (1 << 29);
			}
			if ((clipmovecount[snum] & 31) == 17)
			{
				syn.bits |= (1 << 22);
			}
			if (clipmovecount[snum] > 32)
			{
				goalsect[snum] = -1;
				goalwall[snum] = -1;
				clipmovecount[snum] = 0;
			}

			goalEngine.board.sprite[snum] = -1;
		}
		else
		{
			clipmovecount[snum] = 0;
		}

		if ((goalsect[snum] >= 0) && (goalwall[snum] >= 0))
		{
			x2 = goalx[snum];
			y2 = goaly[snum];
			dist = ksqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
			if (dist == 0)
			{
				return;
			}
			daang = Engine.getangle(x2 - x1, y2 - y1);
			if ((goalwall[snum] >= 0) && (dist < 4096))
			{
				daang = ((Engine.getangle(Engine.board.wall[Engine.board.wall[goalwall[snum]].point2].x - Engine.board.wall[goalwall[snum]].x, Engine.board.wall[Engine.board.wall[goalwall[snum]].point2].y - Engine.board.wall[goalwall[snum]].y) + 1536) & 2047);
			}
			syn.fvel += (x2 - x1) * 2047 / dist;
			syn.svel += (y2 - y1) * 2047 / dist;
			syn.avel = (sbyte)Math.Min(Math.Max((((daang + 1024 - damyang) & 2047) - 1024) >> 3, -127), 127);
		}
*/
// jmarshall end
	}

}
