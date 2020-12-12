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
using UnityEngine;
public partial class GlobalMembers
{


    public static int gametext(int x, int y, string t, int s, int dabits)
    {
        int ac;
        int newx;
        bool centre;
        string oldt;

        centre = (x == (320 >> 1));
        newx = 0;
        oldt = t;

        if (centre)
        {
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == 32)
                {
                    newx += 5;
                    continue;
                }
                else
                {
                    ac = t[i] - '!' + DefineConstants.STARTALPHANUM;
                }

                if (ac < DefineConstants.STARTALPHANUM || ac > DefineConstants.ENDALPHANUM)
                {
                    break;
                }

                if (t[i] >= '0' && t[i] <= '9')
                {
                    newx += 8;
                }
                else
                {
                    newx += Engine.tilesizx[ac];
                }
            }

            t = oldt;
            x = (320 >> 1) - (newx >> 1);
        }

        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == 32)
            {
                x += 5;
                continue;
            }
            else
            {
                ac = t[i] - '!' + DefineConstants.STARTALPHANUM;
            }

            if (ac < DefineConstants.STARTALPHANUM || ac > DefineConstants.ENDALPHANUM)
            {
                break;
            }

            Engine.rotatesprite(x << 16, y << 16, 65536, 0, ac, (sbyte)s, 0, (byte)dabits, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

            if (t[i] >= '0' && t[i] <= '9')
            {
                x += 8;
            }
            else
            {
                x += Engine.tilesizx[ac];
            }
        }

        return (x);
    }

    //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 't', so pointers on this parameter are left unchanged:
    public static int gametextpal(int x, int y, string t, int s, int p)
    {
        int ac;
        int newx;
        bool centre;
        string oldt;

		int dabits = 32; // jmarshall: this is wrong


		centre = (x == (320 >> 1));
        newx = 0;
        oldt = t;

        if (centre)
        {
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == 32)
                {
                    newx += 5;
                    continue;
                }
                else
                {
                    ac = t[i] - '!' + DefineConstants.STARTALPHANUM;
                }

                if (ac < DefineConstants.STARTALPHANUM || ac > DefineConstants.ENDALPHANUM)
                {
                    break;
                }

                if (t[i] >= '0' && t[i] <= '9')
                {
                    newx += 8;
                }
                else
                {
                    newx += Engine.tilesizx[ac];
                }
            }

            t = oldt;
            x = (320 >> 1) - (newx >> 1);
        }

        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == 32)
            {
                x += 5;
                continue;
            }
            else
            {
                ac = t[i] - '!' + DefineConstants.STARTALPHANUM;
            }

            if (ac < DefineConstants.STARTALPHANUM || ac > DefineConstants.ENDALPHANUM)
            {
                break;
            }

            Engine.rotatesprite(x << 16, y << 16, 65536, (short)p, ac, (sbyte)s, 0, (byte)dabits, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

            if (t[i] >= '0' && t[i] <= '9')
            {
                x += 8;
            }
            else
            {
                x += Engine.tilesizx[ac];
            }
        }

        return (x);
    }

    //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 't', so pointers on this parameter are left unchanged:
    public static int gametextpart(int x, int y, string t, char s, int p)
    {
        int ac;
        short newx;
        short cnt;
        bool centre;
        string oldt;

        centre = (x == (320 >> 1));
        newx = 0;
        oldt = t;
        cnt = 0;

        if (centre)
        {
            for(int i = 0; i < t.Length; i++)
            {
                if (cnt == p)
                {
                    break;
                }

                if (t[i] == 32)
                {
                    newx += 5;
                    continue;
                }
                else
                {
                    ac = t[i] - '!' + DefineConstants.STARTALPHANUM;
                }

                if (ac < DefineConstants.STARTALPHANUM || ac > DefineConstants.ENDALPHANUM)
                {
                    break;
                }

                newx += Engine.tilesizx[ac];
                cnt++;

            }

            t = oldt;
            x = (320 >> 1) - (newx >> 1);
        }

        cnt = 0;
		for (int i = 0; i < t.Length; i++)
		{
            if (t[i] == 32)
            {
                x += 5;
                continue;
            }
            else
            {
                ac = t[i] - '!' + DefineConstants.STARTALPHANUM;
            }

            if (ac < DefineConstants.STARTALPHANUM || ac > DefineConstants.ENDALPHANUM)
            {
                break;
            }

            if (cnt == p)
            {
                Engine.rotatesprite(x << 16, y << 16, 65536, 0, ac, (sbyte)s, 1, 2 + 8 + 16, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                break;
            }
            else
            {
                Engine.rotatesprite(x << 16, y << 16, 65536, 0, ac, (sbyte)s, 0, 2 + 8 + 16, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
            }

            x += Engine.tilesizx[ac];

            cnt++;
        }

        return 0;
    }

    //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 't', so pointers on this parameter are left unchanged:
    public static int minitext(int x, int y, string t, int p, int sb)
    {
        int ac;

		t = t.ToUpper();

        for(int i = 0; i < t.Length; i++)
        {
            if (t[i] == 32)
            {
                x += 5;
                continue;
            }
            else
            {
                ac = t[i] - '!' + DefineConstants.MINIFONT;
            }

            Engine.rotatesprite(x << 16, y << 16, 65536, 0, ac, 0, (byte)p,(byte) sb, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
            x += 4; // Engine.tilesizx[ac]+1;
		 }
        return (x);

     
    }

    //C++ TO C# CONVERTER TODO TASK: Pointer arithmetic is detected on the parameter 't', so pointers on this parameter are left unchanged:
    public static int minitextshade(int x, int y, string t, char s, char p, char sb)
    {
		 int ac;

        t = t.ToUpper();

        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == 32)
            {
                x += 5;
                continue;
            }
            else
            {
                ac = t[i] - '!' + DefineConstants.MINIFONT;
            }

            Engine.rotatesprite(x << 16, y << 16, 65536, 0, ac, 0, (byte)p, (byte)sb, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
            x += 4; // Engine.tilesizx[ac]+1;
        }
        return (x);
    }

	public static void invennum(int x, int y, int num1, int ha, int sbits)
	{
		//char[] dabuf = {0, '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0'};
		//sprintf(dabuf,"%ld",num1);
		string dabuf = "";
		dabuf += num1;

		if (num1 > 99)
		{
			Engine.rotatesprite((x - 4) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[0] - '0', (sbyte)ha, 0, (byte)sbits, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			Engine.rotatesprite((x) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[1] - '0', (sbyte)ha, 0, (byte)sbits, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			Engine.rotatesprite((x + 4) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[2] - '0', (sbyte)ha, 0, (byte)sbits, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
		else if (num1 > 9)
		{
			Engine.rotatesprite((x) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[0] - '0', (sbyte)ha, 0, (byte)sbits, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			Engine.rotatesprite((x + 4) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[1] - '0', (sbyte)ha, 0, (byte)sbits, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
		else
		{
			Engine.rotatesprite((x + 4) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[0] - '0', (sbyte)ha, 0, (byte)sbits, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
	}

#if VOLUMEONE
	public static void orderweaponnum(short ind,int x,int y,int num1, int num2,char ha)
	{
		Engine.rotatesprite((x - 7) << 16,y << 16,65536,0,DefineConstants.THREEBYFIVE + ind + 1,ha - 10,7,10 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);
		Engine.rotatesprite((x - 3) << 16,y << 16,65536,0,DefineConstants.THREEBYFIVE+10,ha,0,10 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);

		minitextshade(x + 1, y - 4, "ORDER", 26, 6, 2 + 8 + 16 + 128);
	}
#endif


	public static void weaponnum(short ind, int x, int y, int num1, int num2, int ha)
	{
		string dabuf = "";
		Engine.rotatesprite((x - 7) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + ind + 1, (sbyte)(ha - 10), 7, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		Engine.rotatesprite((x - 3) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + 10, (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		Engine.rotatesprite((x + 9) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + 11, (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

		if (num1 > 99)
		{
			num1 = 99;
		}
		if (num2 > 99)
		{
			num2 = 99;
		}
		
		dabuf = "";
        dabuf += num1;
        if (num1 > 9)
		{
			Engine.rotatesprite((x) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[0] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			Engine.rotatesprite((x + 4) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[1] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
		else
		{
			Engine.rotatesprite((x + 4) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[0] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}

        dabuf = "";
        dabuf += num2;
        if (num2 > 9)
		{
			Engine.rotatesprite((x + 13) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[0] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			Engine.rotatesprite((x + 17) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[1] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
		else
		{
			Engine.rotatesprite((x + 13) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[0] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}

	}

	public static void weaponnum999(int ind, int x, int y, int num1, int num2, int ha)
	{
		string dabuf = "";
		Engine.rotatesprite((x - 7) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + ind + 1, (sbyte)(ha - 10), 7, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		Engine.rotatesprite((x - 4) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + 10, (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		Engine.rotatesprite((x + 13) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + 11, (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

        dabuf = "";
        dabuf += num1;
        if (num1 > 99)
		{
			Engine.rotatesprite((x) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[0] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			Engine.rotatesprite((x + 4) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[1] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			Engine.rotatesprite((x + 8) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[2] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
		else if (num1 > 9)
		{
			Engine.rotatesprite((x + 4) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[0] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			Engine.rotatesprite((x + 8) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[1] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
		else
		{
			Engine.rotatesprite((x + 8) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[0] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}

        dabuf = "";
        dabuf += num2;
        if (num2 > 99)
		{
			Engine.rotatesprite((x + 17) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[0] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			Engine.rotatesprite((x + 21) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[1] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			Engine.rotatesprite((x + 25) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[2] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
		else if (num2 > 9)
		{
			Engine.rotatesprite((x + 17) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[0] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			Engine.rotatesprite((x + 21) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[1] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
		else
		{
			Engine.rotatesprite((x + 25) << 16, y << 16, 65536, 0, DefineConstants.THREEBYFIVE + dabuf[0] - '0', (sbyte)ha, 0, 10 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}

	}


	//REPLACE FULLY
	public static void weapon_amounts(player_struct p, int x, int y, int u)
	{
		int cw;
		int[] temp_got_weapons = new int[DefineConstants.MAX_WEAPONS];
		int[] temp_got_weapons2 = new int[DefineConstants.MAX_WEAPONS];
		for (int i = 0; i < temp_got_weapons.Length; i++)
        {
			if (p.gotweapon[i])
			{
				temp_got_weapons[i] = 1;
				temp_got_weapons2[i] = 0;
			}
			else
			{
				temp_got_weapons[i] = 0;
				temp_got_weapons2[i] = 1;
			}
		}

        cw = p.curr_weapon;

		Engine.rotatesprite(0, (200 - 34) << 16, 65536, 0, DefineConstants.BOTTOMSTATUSBAR, 4, 0, 10 + 16 + 64 + 128, pragmas.scale(96, Engine.xdim, 320), pragmas.scale(178, Engine.ydim, 200), pragmas.scale(96 + 12, Engine.xdim, 320) - 1, pragmas.scale(178 + 6, Engine.ydim, 200) - 1);
		if ((u & 4) != 0)
        {
            weaponnum999(DefineConstants.PISTOL_WEAPON, x, y, p.ammo_amount[DefineConstants.PISTOL_WEAPON], max_ammo_amount[DefineConstants.PISTOL_WEAPON], (char)(12 - 20 * ((cw == DefineConstants.PISTOL_WEAPON) ? 1 : 0)));
        }
        if ((u & 8) != 0)
        {
            weaponnum999(DefineConstants.SHOTGUN_WEAPON, x, y + 6, p.ammo_amount[DefineConstants.SHOTGUN_WEAPON], max_ammo_amount[DefineConstants.SHOTGUN_WEAPON], (char)((temp_got_weapons2[DefineConstants.SHOTGUN_WEAPON] * 9) + 12 - 18 * ((cw == DefineConstants.SHOTGUN_WEAPON) ? 1 : 0)));
        }
        if ((u & 16) != 0)
        {
            weaponnum999(DefineConstants.CHAINGUN_WEAPON, x, y + 12, p.ammo_amount[DefineConstants.CHAINGUN_WEAPON], max_ammo_amount[DefineConstants.CHAINGUN_WEAPON], (char)((temp_got_weapons2[DefineConstants.CHAINGUN_WEAPON] * 9) + 12 - 18 * ((cw == DefineConstants.CHAINGUN_WEAPON) ? 1 : 0)));
        }
        if ((u & 32) != 0)
        {
            weaponnum(DefineConstants.RPG_WEAPON, x + 39, y, p.ammo_amount[DefineConstants.RPG_WEAPON], max_ammo_amount[DefineConstants.RPG_WEAPON], (char)((temp_got_weapons2[DefineConstants.RPG_WEAPON] * 9) + 12 - 19 * ((cw == DefineConstants.RPG_WEAPON) ? 1 : 0)));
        }
        if ((u & 64) != 0)
        {

			int _ammo1 = p.ammo_amount[DefineConstants.HANDBOMB_WEAPON];
			if (_ammo1 == 0)
				_ammo1 = temp_got_weapons2[DefineConstants.HANDBOMB_WEAPON];


			weaponnum(DefineConstants.HANDBOMB_WEAPON, x + 39, y + 6, p.ammo_amount[DefineConstants.HANDBOMB_WEAPON], max_ammo_amount[DefineConstants.HANDBOMB_WEAPON], (_ammo1 * 9) + 12 - 19 * (((cw == DefineConstants.HANDBOMB_WEAPON) || (cw == DefineConstants.HANDREMOTE_WEAPON))  ? 1 : 0));
        }
        if ((u & 128) != 0)
        {


#if VOLUMEONE
			 orderweaponnum(DefineConstants.SHRINKER_WEAPON, x + 39, y + 12, p.ammo_amount[DefineConstants.SHRINKER_WEAPON], max_ammo_amount[DefineConstants.SHRINKER_WEAPON], (temp_got_weapons2[DefineConstants.SHRINKER_WEAPON] * 9) + 12 - 18 * (cw == DefineConstants.SHRINKER_WEAPON));
#else
            if ((p.subweapon & (1 << DefineConstants.GROW_WEAPON)) != 0)
            {
                weaponnum(DefineConstants.SHRINKER_WEAPON, x + 39, y + 12, p.ammo_amount[DefineConstants.GROW_WEAPON], max_ammo_amount[DefineConstants.GROW_WEAPON], (temp_got_weapons2[DefineConstants.GROW_WEAPON] * 9) + 12 - 18 * ((cw == DefineConstants.GROW_WEAPON) ? 1 : 0));
            }
            else
            {
                weaponnum(DefineConstants.SHRINKER_WEAPON, x + 39, y + 12, p.ammo_amount[DefineConstants.SHRINKER_WEAPON], max_ammo_amount[DefineConstants.SHRINKER_WEAPON], (temp_got_weapons2[DefineConstants.SHRINKER_WEAPON] * 9) + 12 - 18 * ((cw == DefineConstants.SHRINKER_WEAPON) ? 1 : 0));
            }
#endif
        }
        if ((u & 256) != 0)
        {


#if VOLUMEONE
			orderweaponnum(DefineConstants.DEVISTATOR_WEAPON, x + 70, y, p.ammo_amount[DefineConstants.DEVISTATOR_WEAPON], max_ammo_amount[DefineConstants.DEVISTATOR_WEAPON], (temp_got_weapons2[DefineConstants.DEVISTATOR_WEAPON] * 9) + 12 - 18 * (cw == DefineConstants.DEVISTATOR_WEAPON));
#else
            weaponnum(DefineConstants.DEVISTATOR_WEAPON, x + 70, y, p.ammo_amount[DefineConstants.DEVISTATOR_WEAPON], max_ammo_amount[DefineConstants.DEVISTATOR_WEAPON], (temp_got_weapons2[DefineConstants.DEVISTATOR_WEAPON] * 9) + 12 - 18 * ((cw == DefineConstants.DEVISTATOR_WEAPON) ? 1 : 0));
#endif
        }
        if ((u & 512) != 0)
        {

#if VOLUMEONE
			 orderweaponnum(DefineConstants.TRIPBOMB_WEAPON, x + 70, y + 6, p.ammo_amount[DefineConstants.TRIPBOMB_WEAPON], max_ammo_amount[DefineConstants.TRIPBOMB_WEAPON], (temp_got_weapons2[DefineConstants.TRIPBOMB_WEAPON] * 9) + 12 - 18 * (cw == DefineConstants.TRIPBOMB_WEAPON));
#else
            weaponnum(DefineConstants.TRIPBOMB_WEAPON, x + 70, y + 6, p.ammo_amount[DefineConstants.TRIPBOMB_WEAPON], max_ammo_amount[DefineConstants.TRIPBOMB_WEAPON], (temp_got_weapons2[DefineConstants.TRIPBOMB_WEAPON] * 9) + 12 - 18 * ((cw == DefineConstants.TRIPBOMB_WEAPON) ? 1 : 0));
#endif
        }

        if ((u & 65536) != 0)
        {

#if VOLUMEONE
			orderweaponnum(-1, x + 70, y + 12, p.ammo_amount[DefineConstants.FREEZE_WEAPON], max_ammo_amount[DefineConstants.FREEZE_WEAPON], (temp_got_weapons2[DefineConstants.FREEZE_WEAPON] * 9) + 12 - 18 * (cw == DefineConstants.FREEZE_WEAPON));
#else
            weaponnum(-1, x + 70, y + 12, p.ammo_amount[DefineConstants.FREEZE_WEAPON], max_ammo_amount[DefineConstants.FREEZE_WEAPON], (temp_got_weapons2[DefineConstants.FREEZE_WEAPON] * 9) + 12 - 18 * ((cw == DefineConstants.FREEZE_WEAPON) ? 1 : 0));
#endif
        }
    }

    public static void digitalnumber(int x, int y, int n, int s, int cs)
	{
		int i;
		int j;
		int k;
		int p;
		int c;
		string b = "";

		b += n;
		i = b.Length;
		j = 0;

		for (k = 0; k < i; k++)
		{
			p = DefineConstants.DIGITALNUM + b[k] - '0';
			j += Engine.tilesizx[p] + 1;
		}
		c = (short)(x - (j >> 1));

		j = 0;
		for (k = 0; k < i; k++)
		{
			p = DefineConstants.DIGITALNUM + b[k] - '0';
			Engine.rotatesprite((c + j) << 16, y << 16, 65536, 0, p, (sbyte)s, 0, (byte)cs, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			j += Engine.tilesizx[p] + 1;
		}
	}

	/*
	
	void scratchmarks(long x,long y,long n,char s,char p)
	{
	    long i, ni;
	
	    ni = n/5;
	    for(i=ni;i >= 0;i--)
	    {
	        overwritesprite(x-2,y,SCRATCH+4,s,0,0);
	        x += Engine.tilesizx[SCRATCH+4]-1;
	    }
	
	    ni = n%5;
	    if(ni) overwritesprite(x,y,SCRATCH+ni-1,s,p,0);
	}
	  */
	public static void displayinventory(player_struct p)
	{
		int n;
		short j;
		short xoff;
		short y;

		j = xoff = 0;

		n = (short)(((p.jetpack_amount > 0) ? 1 : 0) << 3);
		if ((n & 8) != 0)
		{
			j++;
		}
		n |= ((p.scuba_amount > 0) ? 1 : 0) << 5;
		if ((n & 32) != 0)
		{
			j++;
		}
		n |= ((p.steroids_amount > 0) ? 1 : 0) << 1;
		if ((n & 2) != 0)
		{
			j++;
		}
		n |= ((p.holoduke_amount > 0) ? 1 : 0) << 2;
		if ((n & 4) != 0)
		{
			j++;
		}
		n |= ((p.firstaid_amount > 0) ? 1 : 0);
		if ((n & 1) != 0)
		{
			j++;
		}
		n |= ((p.heat_amount > 0) ? 1 : 0) << 4;
		if ((n & 16) != 0)
		{
			j++;
		}
		n |= ((p.boot_amount > 0) ? 1 : 0) << 6;
		if ((n & 64) != 0)
		{
			j++;
		}

		xoff = (short)(160 - (j * 11));

		j = 0;

		if (ud.screen_size > 4)
		{
			y = 154;
		}
		else
		{
			y = 172;
		}

		if (ud.screen_size == 4)
		{
			if (ud.multimode > 1)
			{
				xoff += 56;
			}
			else
			{
				xoff += 65;
			}
		}

		while (j <= 9)
		{
			if ((n & (1 << j)) != 0)
			{
				switch (n & (1 << j))
				{
					case 1:
						Engine.rotatesprite(xoff << 16, y << 16, 65536, 0, DefineConstants.FIRSTAID_ICON, 0, 0, 2 + 16, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
						break;
					case 2:
						Engine.rotatesprite((xoff + 1) << 16, y << 16, 65536, 0, DefineConstants.STEROIDS_ICON, 0, 0, 2 + 16, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
						break;
					case 4:
						Engine.rotatesprite((xoff + 2) << 16, y << 16, 65536, 0, DefineConstants.HOLODUKE_ICON, 0, 0, 2 + 16, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
						break;
					case 8:
						Engine.rotatesprite(xoff << 16, y << 16, 65536, 0, DefineConstants.JETPACK_ICON, 0, 0, 2 + 16, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
						break;
					case 16:
						Engine.rotatesprite(xoff << 16, y << 16, 65536, 0, DefineConstants.HEAT_ICON, 0, 0, 2 + 16, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
						break;
					case 32:
						Engine.rotatesprite(xoff << 16, y << 16, 65536, 0, DefineConstants.AIRTANK_ICON, 0, 0, 2 + 16, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
						break;
					case 64:
						Engine.rotatesprite(xoff << 16, (y - 1) << 16, 65536, 0, DefineConstants.BOOT_ICON, 0, 0, 2 + 16, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
						break;
				}

				xoff += 22;

				if (p.inven_icon == j + 1)
				{
					Engine.rotatesprite((xoff - 2) << 16, (y + 19) << 16, 65536, 1024, DefineConstants.ARROW, -32, 0, 2 + 16, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
				}
			}

			j++;
		}
	}



	public static void displayfragbar()
	{
		short i;
		short j;

		j = 0;

		for (i = connecthead; i >= 0; i = connectpoint2[i])
		{
			if (i > j)
			{
				j = i;
			}
		}

		Engine.rotatesprite(0, 0, 65600, 0, DefineConstants.FRAGBAR, 0, 0, 2 + 8 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		if (j >= 4)
		{
			Engine.rotatesprite(319, (8) << 16, 65600, 0, DefineConstants.FRAGBAR, 0, 0, 10 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
		if (j >= 8)
		{
			Engine.rotatesprite(319, (16) << 16, 65600, 0, DefineConstants.FRAGBAR, 0, 0, 10 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}
		if (j >= 12)
		{
			Engine.rotatesprite(319, (24) << 16, 65600, 0, DefineConstants.FRAGBAR, 0, 0, 10 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
		}

		for (i = connecthead; i >= 0; i = connectpoint2[i])
		{
			minitext(21 + (73 * (i & 3)), 2 + ((i & 28) << 1), ud.user_name[i], Engine.board.sprite[ps[i].i].pal, 2 + 8 + 16 + 128);
			//sprintf(tempbuf, "%d", ps[i].frag - ps[i].fraggedself);
			string s = "";
			s += (int)ps[i].frag - ps[i].fraggedself;
			minitext(17 + 50 + (73 * (i & 3)), 2 + ((i & 28) << 1), s, Engine.board.sprite[ps[i].i].pal, 2 + 8 + 16 + 128);
		}
	}

	public static void coolgaugetext(short snum)
	{
		player_struct p;
		int i;
		int j;
		int o;
		int ss;
		uint u;
		char c;
		char permbit;

		p = ps[snum];

		Engine.board.globalpal = 0;

		if (p.invdisptime > 0)
		{
			displayinventory(p);
		}


		if ((ps[snum].gm & DefineConstants.MODE_MENU) != 0)
		{
			if ((current_menu >= 400 && current_menu <= 405))
			{
				return;
			}
		}

		ss = ud.screen_size;
		if (ss < 4)
		{
			return;
		}		

		if (ud.multimode > 1 && ud.coop != 1)
		{
			if (pus != 0)
			{
				displayfragbar();
			}
			else
			{
				for (i = connecthead; i >= 0; i = connectpoint2[i])
				{
					if (ps[i].frag != sbar.frag[i])
					{
						displayfragbar();
						break;
					}
				}
			}
			for (i = connecthead; i >= 0; i = connectpoint2[i])
			{
				if (i != myconnectindex)
				{
					sbar.frag[i] = ps[i].frag;
				}
			}
		}

		if (ss == 4) //DRAW MINI STATUS BAR:
		{
			Engine.rotatesprite(5 << 16, (200 - 28) << 16, 65536, 0, DefineConstants.HEALTHBOX, 0, 21, 10 + 16, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			if (p.inven_icon != 0)
			{
				Engine.rotatesprite(69 << 16, (200 - 30) << 16, 65536, 0, DefineConstants.INVENTORYBOX, 0, 21, 10 + 16, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			}

			if (Engine.board.sprite[p.i].pal == 1 && p.last_extra < 2)
			{
				digitalnumber(20, 200 - 17, 1, -16, 10 + 16);
			}
			else
			{
				digitalnumber(20, 200 - 17, p.last_extra, -16, 10 + 16);
			}

			Engine.rotatesprite(37 << 16, (200 - 28) << 16, 65536, 0, DefineConstants.AMMOBOX, 0, 21, 10 + 16, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

			if (p.curr_weapon == DefineConstants.HANDREMOTE_WEAPON)
			{
				i = DefineConstants.HANDBOMB_WEAPON;
			}
			else
			{
				i = p.curr_weapon;
			}
			digitalnumber(53, 200 - 17, p.ammo_amount[i], -16, 10 + 16);

			o = 158;
			permbit = (char)0;
			if (p.inven_icon != 0)
			{
				switch ((int)p.inven_icon)
				{
					case 1:
						i = DefineConstants.FIRSTAID_ICON;
						break;
					case 2:
						i = DefineConstants.STEROIDS_ICON;
						break;
					case 3:
						i = DefineConstants.HOLODUKE_ICON;
						break;
					case 4:
						i = DefineConstants.JETPACK_ICON;
						break;
					case 5:
						i = DefineConstants.HEAT_ICON;
						break;
					case 6:
						i = DefineConstants.AIRTANK_ICON;
						break;
					case 7:
						i = DefineConstants.BOOT_ICON;
						break;
					default:
						i = -1;
						break;
				}
				if (i >= 0)
				{
					Engine.rotatesprite((231 - o) << 16, (200 - 21) << 16, 65536, 0, i, 0, 0, (byte)(10 + 16 + permbit), 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				}

				minitext(292 - 30 - o, 190, "%", 6, 10 + 16 + permbit);

				j = unchecked((int)0x80000000);
				switch ((int)p.inven_icon)
				{
					case 1:
						i = p.firstaid_amount;
						break;
					case 2:
						i = ((p.steroids_amount + 3) >> 2);
						break;
					case 3:
						i = ((p.holoduke_amount + 15) / 24);
						j = p.holoduke_on;
						break;
					case 4:
						i = ((p.jetpack_amount + 15) >> 4);
						j = p.jetpack_on;
						break;
					case 5:
						i = p.heat_amount / 12;
						j = p.heat_on;
						break;
					case 6:
						i = ((p.scuba_amount + 63) >> 6);
						break;
					case 7:
						i = (p.boot_amount >> 1);
						break;
				}
				invennum(284 - 30 - o, 200 - 6, (char)i, 0, 10 + permbit);
				if (j > 0)
				{
					minitext(288 - 30 - o, 180, "ON", 0, 10 + 16 + permbit);
				}
				else if (j != 0x80000000)
				{
					minitext(284 - 30 - o, 180, "OFF", 2, 10 + 16 + permbit);
				}
				if (p.inven_icon >= 6)
				{
					minitext(284 - 35 - o, 180, "AUTO", 2, 10 + 16 + permbit);
				}
			}
			return;
		}

		//DRAW/UPDATE FULL STATUS BAR:

		if (pus != 0)
		{
			pus = (char)0;
			u = unchecked((uint)0xffffffff);
		}
		else
		{
			u = 0;
		}

		if (sbar.frag[myconnectindex] != p.frag)
		{
			sbar.frag[myconnectindex] = p.frag;
		//	u |= 32768;
		}
		if (sbar.got_access != p.got_access)
		{
			sbar.got_access = p.got_access;
			//u |= 16384;
		}
		if (sbar.last_extra != p.last_extra)
		{
			sbar.last_extra = p.last_extra;
		//	u |= 1;
		}
		if (sbar.shield_amount != p.shield_amount)
		{
			sbar.shield_amount = p.shield_amount;
		//	u |= 2;
		}
		if (sbar.curr_weapon != p.curr_weapon)
		{
			sbar.curr_weapon = p.curr_weapon;
			//u |= (4 + 8 + 16 + 32 + 64 + 128 + 256 + 512 + 1024 + 65536);
		}
		for (i = 1; i < 10; i++)
		{
			if (sbar.ammo_amount[i] != p.ammo_amount[i])
			{
				sbar.ammo_amount[i] = p.ammo_amount[i];
				if (i < 9)
				{
				//	u |= ((2 << i) + 1024);
				}
				else
				{
				//	u |= 65536 + 1024;
				}
			}
			if (sbar.gotweapon[i] != p.gotweapon[i])
			{
				sbar.gotweapon[i] = p.gotweapon[i];
				if (i < 9)
				{
				//	u |= ((2 << i) + 1024);
				}
				else
				{
				//	u |= 65536 + 1024;
				}
			}
		}
		if (sbar.inven_icon != p.inven_icon)
		{
			sbar.inven_icon = p.inven_icon;
		//	u |= (2048 + 4096 + 8192);
		}
		if (sbar.holoduke_on != p.holoduke_on)
		{
			sbar.holoduke_on = p.holoduke_on;
		//	u |= (4096 + 8192);
		}
		if (sbar.jetpack_on != p.jetpack_on)
		{
			sbar.jetpack_on = p.jetpack_on;
		//	u |= (4096 + 8192);
		}
		if (sbar.heat_on != p.heat_on)
		{
			sbar.heat_on = p.heat_on;
		//	u |= (4096 + 8192);
		}
		if (sbar.firstaid_amount != p.firstaid_amount)
		{
			sbar.firstaid_amount = p.firstaid_amount;
		//	u |= 8192;
		}
		if (sbar.steroids_amount != p.steroids_amount)
		{
			sbar.steroids_amount = p.steroids_amount;
		//	u |= 8192;
		}
		if (sbar.holoduke_amount != p.holoduke_amount)
		{
			sbar.holoduke_amount = p.holoduke_amount;
		//	u |= 8192;
		}
		if (sbar.jetpack_amount != p.jetpack_amount)
		{
			sbar.jetpack_amount = p.jetpack_amount;
		//	u |= 8192;
		}
		if (sbar.heat_amount != p.heat_amount)
		{
			sbar.heat_amount = p.heat_amount;
		//	u |= 8192;
		}
		if (sbar.scuba_amount != p.scuba_amount)
		{
			sbar.scuba_amount = p.scuba_amount;
		//	u |= 8192;
		}
		if (sbar.boot_amount != p.boot_amount)
		{
			sbar.boot_amount = p.boot_amount;
		//	u |= 8192;
		}
		//if (u == 0)
		//{
		//	return; 
		//}

		u = 0xffffffff;

		//0 - update health
		//1 - update armor
		//2 - update PISTOL_WEAPON ammo
		//3 - update SHOTGUN_WEAPON ammo
		//4 - update CHAINGUN_WEAPON ammo
		//5 - update RPG_WEAPON ammo
		//6 - update HANDBOMB_WEAPON ammo
		//7 - update SHRINKER_WEAPON ammo
		//8 - update DEVISTATOR_WEAPON ammo
		//9 - update TRIPBOMB_WEAPON ammo
		//10 - update ammo display
		//11 - update inventory icon
		//12 - update inventory on/off
		//13 - update inventory %
		//14 - update keys
		//15 - update kills
		//16 - update FREEZE_WEAPON ammo

		if (u == 0xffffffff)
		{
			{
				Engine.rotatesprite(0, (200 - 34) << 16, 65536, 0, DefineConstants.BOTTOMSTATUSBAR, 4, 0, 10 + 16 + 64 + 128, pragmas.scale(0, Engine.xdim, 320), pragmas.scale(0, Engine.ydim, 200), pragmas.scale(320, Engine.xdim, 320) - 1, pragmas.scale(200, Engine.ydim, 200) - 1);
			};
			if (ud.multimode > 1 && ud.coop != 1)
			{
				Engine.rotatesprite(277 << 16, (200 - 27) << 16, 65536, 0, DefineConstants.KILLSICON, 0, 0, 10 + 16 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
			}
		}
		if (ud.multimode > 1 && ud.coop != 1)
		{
			if ((u & 32768) != 0)
			{
				if (u != 0xffffffff)
				{
					Engine.rotatesprite(0, (200 - 34) << 16, 65536, 0, DefineConstants.BOTTOMSTATUSBAR, 4, 0, 10 + 16 + 64 + 128, pragmas.scale(276, Engine.xdim, 320), pragmas.scale(183, Engine.ydim, 200), pragmas.scale(299, Engine.xdim, 320) - 1, pragmas.scale(193, Engine.ydim, 200) - 1);
				};
				digitalnumber(287, 200 - 17, Mathf.Max(p.frag - p.fraggedself, 0), -16, 10 + 16 + 128);
			}
		}
		else
		{
			if ((u & 16384) != 0)
			{
				if (u != 0xffffffff)
				{
					Engine.rotatesprite(0, (200 - 34) << 16, 65536, 0, DefineConstants.BOTTOMSTATUSBAR, 4, 0, 10 + 16 + 64 + 128, pragmas.scale(275, Engine.xdim, 320), pragmas.scale(182, Engine.ydim, 200), pragmas.scale(299, Engine.xdim, 320) - 1, pragmas.scale(194, Engine.ydim, 200) - 1);
				};
				if ((p.got_access & 4) != 0)
				{
					Engine.rotatesprite(275 << 16, 182 << 16, 65536, 0, DefineConstants.ACCESS_ICON, 0, 23, 10 + 16 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				}
				if ((p.got_access & 2) != 0)
				{
					Engine.rotatesprite(288 << 16, 182 << 16, 65536, 0, DefineConstants.ACCESS_ICON, 0, 21, 10 + 16 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				}
				if ((p.got_access & 1) != 0)
				{
					Engine.rotatesprite(281 << 16, 189 << 16, 65536, 0, DefineConstants.ACCESS_ICON, 0, 0, 10 + 16 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
				}
			}
		}
		if ((u & (4 + 8 + 16 + 32 + 64 + 128 + 256 + 512 + 65536)) != 0)
		{
			weapon_amounts(p, 96, 182, (int)u);
		}

		if ((u & 1) != 0)
		{
			if (u != 0xffffffff)
			{
				Engine.rotatesprite(0, (200 - 34) << 16, 65536, 0, DefineConstants.BOTTOMSTATUSBAR, 4, 0, 10 + 16 + 64 + 128, pragmas.scale(20, Engine.xdim, 320), pragmas.scale(183, Engine.ydim, 200), pragmas.scale(43, Engine.xdim, 320) - 1, pragmas.scale(193, Engine.ydim, 200) - 1);
			};
			if (Engine.board.sprite[p.i].pal == 1 && p.last_extra < 2)
			{
				digitalnumber(32, 200 - 17, 1, -16, 10 + 16 + 128);
			}
			else
			{
				digitalnumber(32, 200 - 17, p.last_extra, -16, 10 + 16 + 128);
			}
		}
		if ((u & 2) != 0)
		{
			if (u != 0xffffffff)
			{
				Engine.rotatesprite(0, (200 - 34) << 16, 65536, 0, DefineConstants.BOTTOMSTATUSBAR, 4, 0, 10 + 16 + 64 + 128, pragmas.scale(52, Engine.xdim, 320), pragmas.scale(183, Engine.ydim, 200), pragmas.scale(75, Engine.xdim, 320) - 1, pragmas.scale(193, Engine.ydim, 200) - 1);
			};
			digitalnumber(64, 200 - 17, p.shield_amount, -16, 10 + 16 + 128);
		}

		if ((u & 1024) != 0)
		{
			if (u != 0xffffffff)
			{
				Engine.rotatesprite(0, (200 - 34) << 16, 65536, 0, DefineConstants.BOTTOMSTATUSBAR, 4, 0, 10 + 16 + 64 + 128, pragmas.scale(196, Engine.xdim, 320), pragmas.scale(183, Engine.ydim, 200), pragmas.scale(219, Engine.xdim, 320) - 1, pragmas.scale(193, Engine.ydim, 200) - 1);
			};
			if (p.curr_weapon != DefineConstants.KNEE_WEAPON)
			{
				if (p.curr_weapon == DefineConstants.HANDREMOTE_WEAPON)
				{
					i = DefineConstants.HANDBOMB_WEAPON;
				}
				else
				{
					i = p.curr_weapon;
				}
				digitalnumber(230 - 22, 200 - 17, p.ammo_amount[i], -16, 10 + 16 + 128);
			}
		}

		if ((u & (2048 + 4096 + 8192)) != 0)
		{
			if (u != 0xffffffff)
			{
				if ((u & (2048 + 4096)) != 0)
				{
					{
						Engine.rotatesprite(0, (200 - 34) << 16, 65536, 0, DefineConstants.BOTTOMSTATUSBAR, 4, 0, 10 + 16 + 64 + 128, pragmas.scale(231, Engine.xdim, 320), pragmas.scale(179, Engine.ydim, 200), pragmas.scale(265, Engine.xdim, 320) - 1, pragmas.scale(197, Engine.ydim, 200) - 1);
					};
				}
				else
				{
					{
						Engine.rotatesprite(0, (200 - 34) << 16, 65536, 0, DefineConstants.BOTTOMSTATUSBAR, 4, 0, 10 + 16 + 64 + 128, pragmas.scale(250, Engine.xdim, 320), pragmas.scale(190, Engine.ydim, 200), pragmas.scale(261, Engine.xdim, 320) - 1, pragmas.scale(195, Engine.ydim, 200) - 1);
					};
				}
			}
			if (p.inven_icon != 0)
			{
				o = 0;
				permbit = (char)128;

				if ((u & (2048 + 4096)) != 0)
				{
					switch ((int)p.inven_icon)
					{
						case 1:
							i = DefineConstants.FIRSTAID_ICON;
							break;
						case 2:
							i = DefineConstants.STEROIDS_ICON;
							break;
						case 3:
							i = DefineConstants.HOLODUKE_ICON;
							break;
						case 4:
							i = DefineConstants.JETPACK_ICON;
							break;
						case 5:
							i = DefineConstants.HEAT_ICON;
							break;
						case 6:
							i = DefineConstants.AIRTANK_ICON;
							break;
						case 7:
							i = DefineConstants.BOOT_ICON;
							break;
					}
					Engine.rotatesprite((231 - o) << 16, (200 - 21) << 16, 65536, 0, i, 0, 0, (byte)(10 + 16 + permbit), 0, 0, Engine.xdim - 1, Engine.ydim - 1);
					minitext(292 - 30 - o, 190, "%", 6, 10 + 16 + permbit);
					if (p.inven_icon >= 6)
					{
						minitext(284 - 35 - o, 180, "AUTO", 2, 10 + 16 + permbit);
					}
				}
				if ((u & (2048 + 4096)) != 0)
				{
					switch ((int)p.inven_icon)
					{
						case 3:
							j = p.holoduke_on;
							break;
						case 4:
							j = p.jetpack_on;
							break;
						case 5:
							j = p.heat_on;
							break;
						default:
							j = unchecked((int)0x80000000);
							break;
					}
					if (j > 0)
					{
						minitext(288 - 30 - o, 180, "ON", 0, 10 + 16 + permbit);
					}
					else if (j != 0x80000000)
					{
						minitext(284 - 30 - o, 180, "OFF", 2, 10 + 16 + permbit);
					}
				}
				if ((u & 8192) != 0)
				{
					switch ((int)p.inven_icon)
					{
						case 1:
							i = p.firstaid_amount;
							break;
						case 2:
							i = ((p.steroids_amount + 3) >> 2);
							break;
						case 3:
							i = ((p.holoduke_amount + 15) / 24);
							break;
						case 4:
							i = ((p.jetpack_amount + 15) >> 4);
							break;
						case 5:
							i = p.heat_amount / 12;
							break;
						case 6:
							i = ((p.scuba_amount + 63) >> 6);
							break;
						case 7:
							i = (p.boot_amount >> 1);
							break;
					}
					invennum(284 - 30 - o, 200 - 6, i, 0, 10 + permbit);
				}
			}
		}
	}
}