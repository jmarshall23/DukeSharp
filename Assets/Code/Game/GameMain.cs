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

#pragma warning disable 0168
public partial class GlobalMembers
{
    static bool in_menu = false;
    static byte[] palette = null;


    public static void displayrest(int smoothratio)
    {
        int a;
        int i;
        int j;

        player_struct pp;
        walltype wal;
        int cposx;
        int cposy;
        int cang;

        pp = ps[screenpeek];

        if (pp.pals_time > 0 && pp.loogcnt == 0)
        {
            palto(pp.pals[0], pp.pals[1], pp.pals[2], pp.pals_time /* | 128 */);

            restorepalette = (char)1;
        }
        else if (restorepalette != 0)
        {
            Engine.setbrightness(ud.brightness >> 2, GlobalMembers.palette); // palette.
            restorepalette = (char)0;
        }
        else if (pp.loogcnt > 0)
        {
            palto(0, 64, 0, (pp.loogcnt >> 1) + 128);
        }

        if (ud.show_help != 0)
        {
            switch (ud.show_help)
            {
                case 1:
                    Engine.rotatesprite(0, 0, 65536, 0, DefineConstants.TEXTSTORY, 0, 0, 10 + 16 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                    break;
                case 2:
                    Engine.rotatesprite(0, 0, 65536, 0, DefineConstants.F1HELP, 0, 0, 10 + 16 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                    break;
            }

            if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false))
            {
                {
                    KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
                };
                ud.show_help = 0;
                if (ud.multimode < 2 && ud.recstat != 2)
                {
                    ready2send = (char)1;
                    totalclock = ototalclock;
                }
                vscrn();
            }
            return;
        }

        i = pp.cursectnum;

// jmarshall: automap
/*
        show2dEngine.board.sector[i >> 3] |= (1 << (i & 7)); 
        wal = Engine.board.wall[Engine.board.sector[i].wallptr];
        for (j = Engine.board.sector[i].wallnum; j > 0; j--, wal++)
        {
            i = wal.nextsector;
            if (i < 0)
            {
                continue;
            }
            if ((wal.cstat & 0x0071) != 0)
            {
                continue;
            }
            if ((Engine.board.wall[wal.nextwall].cstat & 0x0071) != 0)
            {
                continue;
            }
            if (Engine.board.sector[i].lotag == 32767)
            {
                continue;
            }
            if (Engine.board.sector[i].ceilingz >= Engine.board.sector[i].floorz)
            {
                continue;
            }
            show2dEngine.board.sector[i >> 3] |= (1 << (i & 7));
        }
*/
// jmarshall end
        if (ud.camerasprite == -1)
        {
            if (ud.overhead_on != 2)
            {
                if (pp.newowner >= 0)
                {
                    cameratext(pp.newowner);
                }
                else
                {
                    displayweapon(screenpeek);
                    if (pp.over_shoulder_on == 0)
                    {
                        displaymasks(screenpeek);
                    }
                }
                // moveclouds(); // jmarshall: clouds
            }

            if (ud.overhead_on > 0)
            {
                smoothratio = Mathf.Min(Mathf.Max(smoothratio, 0), 65536);
                dointerpolations(smoothratio);
                if (ud.scrollmode == 0)
                {
                    if (pp.newowner == -1)
                    {
                        if (screenpeek == myconnectindex && numplayers > 1)
                        {
                            cposx = omyx + pragmas.mulscale16((int)(myx - omyx), smoothratio);
                            cposy = omyy + pragmas.mulscale16((int)(myy - omyy), smoothratio);
                            cang = omyang + pragmas.mulscale16((int)(((myang + 1024 - omyang) & 2047) - 1024), smoothratio);
                        }
                        else
                        {
                            cposx = pp.oposx + pragmas.mulscale16((int)(pp.posx - pp.oposx), smoothratio);
                            cposy = pp.oposy + pragmas.mulscale16((int)(pp.posy - pp.oposy), smoothratio);
                            cang = pp.oang + pragmas.mulscale16((int)(((pp.ang + 1024 - pp.oang) & 2047) - 1024), smoothratio);
                        }
                    }
                    else
                    {
                        cposx = pp.oposx;
                        cposy = pp.oposy;
                        cang = pp.oang;
                    }
                }
                else
                {

                    ud.fola += ud.folavel >> 3;
                    ud.folx += (ud.folfvel * Engine.table.sintable[(512 + 2048 - ud.fola) & 2047]) >> 14;
                    ud.foly += (ud.folfvel * Engine.table.sintable[(512 + 1024 - 512 - ud.fola) & 2047]) >> 14;

                    cposx = ud.folx;
                    cposy = ud.foly;
                    cang = ud.fola;
                }

                if (ud.overhead_on == 2)
                {
                    Engine.clearview();
                    // drawmapview(cposx, cposy, pp.zoom, cang); // jmarshall: automap.
                }
                //drawoverheadmap(cposx, cposy, pp.zoom, (short)cang); // jmarshall: automap

                restoreinterpolations();

                if (ud.overhead_on == 2)
                {
                    if (ud.screen_size > 0)
                    {
                        a = 147;
                    }
                    else
                    {
                        a = 182;
                    }

                    minitext(1, a + 6, volume_names[ud.volume_number], 0, 2 + 8 + 16);
                    minitext(1, a + 12, level_names[ud.volume_number * 11 + ud.level_number], 0, 2 + 8 + 16);
                }
            }
        }

        coolgaugetext(screenpeek);
        operatefta();

        if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false) && ud.overhead_on == 0 && ud.show_help == 0 && ps[myconnectindex].newowner == -1)
        {
            if ((ps[myconnectindex].gm & DefineConstants.MODE_MENU) == DefineConstants.MODE_MENU && current_menu < 51)
            {
                {
                    KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
                };
                ps[myconnectindex].gm &= ~DefineConstants.MODE_MENU;
                if (ud.multimode < 2 && ud.recstat != 2)
                {
                    ready2send = (char)1;
                    totalclock = ototalclock;
                    cameraclock = totalclock;
                    cameradist = 65536;
                }
                //walock[DefineConstants.MAXTILES - 1] = 199;
                vscrn();
            }
            else if ((ps[myconnectindex].gm & DefineConstants.MODE_MENU) != DefineConstants.MODE_MENU && ps[myconnectindex].newowner == -1 && (ps[myconnectindex].gm & DefineConstants.MODE_TYPE) != DefineConstants.MODE_TYPE)
            {
                {
                    KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
                };
                FX_StopAllSounds();
                clearsoundlocks();

                intomenusounds();

                ps[myconnectindex].gm |= DefineConstants.MODE_MENU;

                if (ud.multimode < 2 && ud.recstat != 2)
                {
                    ready2send = (char)0;
                }

                if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
                {
                    cmenu(50);
                }
                else
                {
                    cmenu(0);
                }
                screenpeek = myconnectindex;
            }
        }

        if (ps[myconnectindex].newowner == -1 && ud.overhead_on == 0 && ud.crosshair != 0 && ud.camerasprite == -1)
        {
            Engine.rotatesprite((160 - (ps[myconnectindex].look_ang >> 1)) << 16, 100 << 16, 65536, 0, DefineConstants.CROSSHAIR, 0, 0, 2 + 1, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
        }

        if ((ps[myconnectindex].gm & DefineConstants.MODE_TYPE) != 0)
        {
            //typemode(); // jmarshall typemode
        }
        else
        {
            menus();
        }

        if (ud.pause_on == 1 && (ps[myconnectindex].gm & DefineConstants.MODE_MENU) == 0)
        {
            menutext(160, 100, 0, 0, "GAME PAUSED");
        }

        if (ud.coords != 0)
        {
            coords(screenpeek);
        }
        if (ud.tickrate != 0)
        {
            tics();
        }
    }


    public static void view(player_struct pp, ref int vx, ref int vy, ref int vz, ref short vsectnum, short ang, short horiz)
    {
        spritetype sp;
        int i = 0;
        int nx = 0;
        int ny = 0;
        int nz = 0;
        int hx = 0;
        int hy = 0;
        int hz = 0;
        int hitx = 0;
        int hity = 0;
        int hitz = 0;
        short bakcstat = 0;
        int hitsect = 0;
        short hitwall = 0;
        short hitsprite = 0;
        short daang = 0;

        nx = (Engine.table.sintable[(ang + 1536) & 2047] >> 4);
        ny = (Engine.table.sintable[(ang + 1024) & 2047] >> 4);
        nz = (horiz - 100) * 128;

        sp = Engine.board.sprite[pp.i];

        bakcstat = sp.cstat;
        sp.cstat &= (short)~0x101;

        Engine.board.updatesectorz(vx, vy, vz, ref vsectnum);
        Engine.board.hitscan(vx, vy, vz, vsectnum, nx, ny, nz, ref hitsect, ref hitwall, ref hitsprite, ref hitx, ref hity, ref hitz, (((256) << 16) + 64));

        if (vsectnum < null)
        {
            sp.cstat = bakcstat;
            return;
        }

        hx = hitx - vx;
        hy = hity - vy;
        if (pragmas.klabs(nx) + pragmas.klabs(ny) > pragmas.klabs(hx) + pragmas.klabs(hy))
        {
            vsectnum = (short)hitsect;
            if (hitwall >= 0)
            {
                daang = (short)(Engine.getangle(Engine.board.wall[Engine.board.wall[hitwall].point2].x - Engine.board.wall[hitwall].x, Engine.board.wall[Engine.board.wall[hitwall].point2].y - Engine.board.wall[hitwall].y));

                i = (short)(nx * Engine.table.sintable[daang] + ny * Engine.table.sintable[(daang + 1536) & 2047]);
                if (pragmas.klabs(nx) > pragmas.klabs(ny))
                {
                    hx -= pragmas.mulscale28(nx, i);
                }
                else
                {
                    hy -= pragmas.mulscale28(ny, i);
                }
            }
            else if (hitsprite < 0)
            {
                if (pragmas.klabs(nx) > pragmas.klabs(ny))
                {
                    hx -= (nx >> 5);
                }
                else
                {
                    hy -= (ny >> 5);
                }
            }
            if (pragmas.klabs(nx) > pragmas.klabs(ny))
            {
                i = pragmas.divscale16(hx, nx);
            }
            else
            {
                i = pragmas.divscale16(hy, ny);
            }
            if (i < cameradist)
            {
                cameradist = i;
            }
        }
        vx = vx + pragmas.mulscale16(nx, cameradist);
        vy = vy + pragmas.mulscale16(ny, cameradist);
        vz = vz + pragmas.mulscale16(nz, cameradist);

        cameradist = Mathf.Min(cameradist + ((totalclock - cameraclock) << 10), 65536);
        cameraclock = totalclock;

        Engine.board.updatesectorz(vx, vy, vz, ref vsectnum);

        sp.cstat = bakcstat;
    }
    public static void displayrooms(short snum, int smoothratio)
    {
        int cposx;
        int cposy;
        int cposz;
        int dst;
        int j;
        int fz = 0;
        int cz = 0;
        int hz = 0;
        int lz = 0;
        short sect;
        short cang;
        short k;
        short choriz;
        short tsect;
        player_struct p;
        int tposx = 0;
        int tposy = 0;
        int tposz = 0;
        int dx;
        int dy;
        int thoriz;
        int i;
        short tang = 0;

        p = ps[snum];

        //    if(screencapt == 0 && (p->gm&MODE_MENU) && ( (current_menu/100) == 3 ) || (current_menu >= 1000 && current_menu < 2999 ) )
        //      return;

        if (pub > 0)
        {
            if (ud.screen_size > 8)
            {
                drawbackground();
            }
            pub = (char)0;
        }

        if (ud.overhead_on == 2 || ud.show_help != 0 || p.cursectnum == -1)
        {
            return;
        }

        smoothratio = Mathf.Min(Mathf.Max(smoothratio, 0), 65536);

        Engine.board.visibility = p.visibility;

        if (ud.pause_on != 0 || ps[snum].on_crane > -1)
        {
            smoothratio = 65536;
        }

        sect = p.cursectnum;
        if (sect < 0 || sect >= DefineConstants.MAXSECTORS)
        {
            return;
        }

        dointerpolations(smoothratio);

        animatecamsprite();

        if (ud.camerasprite >= 0)
        {
            spritetype s;

            s = Engine.board.sprite[ud.camerasprite];

            if (s.yvel < 0)
            {
                s.yvel = -100;
            }
            else if (s.yvel > 199)
            {
                s.yvel = 300;
            }

            cang = (short)(hittype[ud.camerasprite].tempang + pragmas.mulscale16((int)(((s.ang + 1024 - hittype[ud.camerasprite].tempang) & 2047) - 1024), smoothratio));

            //se40code(s.x, s.y, s.z, cang, s.yvel, smoothratio); // jmarshall se40.

            Engine.board.drawrooms(s.x, s.y, s.z - (4 << 8), cang, s.yvel, s.sectnum);

            A.forceRenderBlack = true;
            animatesprites(s.x, s.y, cang, smoothratio);
            Engine.board.drawmasks();
            A.forceRenderBlack = false;
        }
        else
        {
            i = pragmas.divscale22(1, Engine.board.sprite[p.i].yrepeat + 28);
            if (i != oyrepeat)
            {
                oyrepeat = i;
                Engine._device.setaspect(oyrepeat, Engine._device.yxaspect);
            }
// jmarshall: screencapt
            //if (screencapt)
            //{
            //    walock[DefineConstants.MAXTILES - 1] = 254;
            //    if (waloff[DefineConstants.MAXTILES - 1] == 0)
            //    {
            //        allocache((int)waloff[DefineConstants.MAXTILES - 1], 100 * 160, walock[DefineConstants.MAXTILES - 1]);
            //    }
            //    setviewtotile(DefineConstants.MAXTILES - 1, 100, 160);
            //}
            //else if ((ud.screen_tilting && p.rotscrnang) || ud.detail == 0)
            //{
            //    if (ud.screen_tilting)
            //    {
            //        tang = p.rotscrnang;
            //    }
            //    else
            //    {
            //        tang = 0;
            //    }
            //
            //    walock[DefineConstants.MAXTILES - 2] = 255;
            //    if (waloff[DefineConstants.MAXTILES - 2] == 0)
            //    {
            //        allocache(waloff[DefineConstants.MAXTILES - 2], 320 * 320, walock[DefineConstants.MAXTILES - 2]);
            //    }
            //    if ((tang & 1023) == 0)
            //    {
            //        setviewtotile(DefineConstants.MAXTILES - 2, 200 >> (1 - ud.detail), 320 >> (1 - ud.detail));
            //    }
            //    else
            //    {
            //        setviewtotile(DefineConstants.MAXTILES - 2, 320 >> (1 - ud.detail), 320 >> (1 - ud.detail));
            //    }
            //    if ((tang & 1023) == 512)
            //    { //Block off unscreen section of 90� tilted screen
            //        j = ((320 - 60) >> (1 - ud.detail));
            //        for (i = (60 >> (1 - ud.detail)) - 1; i >= 0; i--)
            //        {
            //            startumost[i] = 1;
            //            startumost[i + j] = 1;
            //            startdmost[i] = 0;
            //            startdmost[i + j] = 0;
            //        }
            //    }
            //
            //    i = (tang & 511);
            //    if (i > 256)
            //    {
            //        i = 512 - i;
            //    }
            //    i = sintable[i + 512] * 8 + sintable[i] * 5;
            //    setaspect(i >> 1, yxaspect);
            //}
// jmarshall end

            if ((snum == myconnectindex) && (numplayers > 1))
            {
                cposx = omyx + pragmas.mulscale16((int)(myx - omyx), smoothratio);
                cposy = omyy + pragmas.mulscale16((int)(myy - omyy), smoothratio);
                cposz = omyz + pragmas.mulscale16((int)(myz - omyz), smoothratio);
                cang = (short)(omyang + pragmas.mulscale16((int)(((myang + 1024 - omyang) & 2047) - 1024), smoothratio));
                choriz = (short)(omyhoriz + omyhorizoff + pragmas.mulscale16((int)(myhoriz + myhorizoff - omyhoriz - omyhorizoff), smoothratio));
                sect = mycursectnum;
            }
            else
            {
                cposx = p.oposx + pragmas.mulscale16((int)(p.posx - p.oposx), smoothratio);
                cposy = p.oposy + pragmas.mulscale16((int)(p.posy - p.oposy), smoothratio);
                cposz = p.oposz + pragmas.mulscale16((int)(p.posz - p.oposz), smoothratio);
                cang = (short)(p.oang + pragmas.mulscale16((int)(((p.ang + 1024 - p.oang) & 2047) - 1024), smoothratio));
                choriz = (short)(p.ohoriz + p.ohorizoff + pragmas.mulscale16((int)(p.horiz + p.horizoff - p.ohoriz - p.ohorizoff), smoothratio));
            }
            cang += p.look_ang;

            if (p.newowner >= 0)
            {
                cang = (short)(p.ang + p.look_ang);
                choriz = (short)(p.horiz + p.horizoff);
                cposx = p.posx;
                cposy = p.posy;
                cposz = p.posz;
                sect = Engine.board.sprite[p.newowner].sectnum;
                smoothratio = 65536;
            }

            else if (p.over_shoulder_on == 0)
            {
                cposz += p.opyoff + pragmas.mulscale16((int)(p.pyoff - p.opyoff), smoothratio);
            }
            else
            {
                view(p, ref cposx, ref cposy, ref cposz, ref sect, cang, choriz);
            }

            cz = hittype[p.i].ceilingz;
            fz = hittype[p.i].floorz;

            if (earthquaketime > 0 && p.on_ground == 1)
            {
                cposz += 256 - (((earthquaketime) & 1) << 9);
                cang += (short)((2 - ((earthquaketime) & 2)) << 2);
            }

            if (Engine.board.sprite[p.i].pal == 1)
            {
                cposz -= (18 << 8);
            }

            if (p.newowner >= 0)
            {
                choriz = (short)(100 + Engine.board.sprite[p.newowner].shade);
            }
            else if (p.spritebridge == 0)
            {
                if (cposz < (p.truecz + (4 << 8)))
                {
                    cposz = cz + (4 << 8);
                }
                else if (cposz > (p.truefz - (4 << 8)))
                {
                    cposz = fz - (4 << 8);
                }
            }

            if (sect >= 0)
            {
                Engine.board.getzsofslope(sect, cposx, cposy, ref cz,ref fz);
                if (cposz < cz + (4 << 8))
                {
                    cposz = cz + (4 << 8);
                }
                if (cposz > fz - (4 << 8))
                {
                    cposz = fz - (4 << 8);
                }
            }

            if (choriz > 299)
            {
                choriz = 299;
            }
            else if (choriz < -99)
            {
                choriz = -99;
            }

            // se40code(cposx, cposy, cposz, cang, choriz, smoothratio); // jmarshall se40
   
            if ((Engine.board.gotpic[DefineConstants.MIRROR >> 3] & (1 << (DefineConstants.MIRROR & 7))) > 0)
            {
                dst = 0x7fffffff;
                i = 0;
                for (k = 0;k < mirrorcnt;k++)
                {
                    j = pragmas.klabs(Engine.board.wall[mirrorwall[k]].x - cposx);
                    j += pragmas.klabs(Engine.board.wall[mirrorwall[k]].y - cposy);
                    if (j < dst)
                    {
                        dst = j; i = k;
                    }
                }
            
                if (Engine.board.wall[mirrorwall[i]].overpicnum == DefineConstants.MIRROR)
                {
                    Engine.board.preparemirror(cposx, cposy, cposz, cang, choriz, mirrorwall[i], mirrorsector[i], ref tposx, ref tposy, ref tang);
            
                    j = Engine.board.visibility; 
                    Engine.board.visibility = (j >> 1) + (j >> 2);

                    Engine.board.drawrooms(tposx,tposy,cposz,tang,choriz, (short)(mirrorsector[i] + DefineConstants.MAXSECTORS));
            
                    display_mirror = (char)1;
                    animatesprites(tposx, tposy, tang, smoothratio);
                    display_mirror = (char)0;

                    Engine.board.drawmasks();
                    Engine.board.completemirror(); //Reverse screen x-wise in this function
                    Engine.board.visibility = j;
                }
                Engine.board.gotpic[DefineConstants.MIRROR >> 3] &= ~(1 << (DefineConstants.MIRROR & 7));
            }

            Engine.board.drawrooms(cposx, cposy, cposz, cang, choriz, sect);

            A.forceRenderBlack = true;
            animatesprites(cposx, cposy, cang, smoothratio);
            Engine.board.drawmasks();
            A.forceRenderBlack = false;

            // jmarshall - screen capt
            //if (screencapt == 1)
            //{
            //    setviewback();
            //    walock[DefineConstants.MAXTILES - 1] = 1;
            //    screencapt = 0;
            //}
            //else if ((ud.screen_tilting && p.rotscrnang) || ud.detail == 0)
            //{
            //    if (ud.screen_tilting)
            //    {
            //        tang = p.rotscrnang;
            //    }
            //    else
            //    {
            //        tang = 0;
            //    }
            //    setviewback();
            //    picanm[DefineConstants.MAXTILES - 2] &= 0xff0000ff;
            //    i = (tang & 511);
            //    if (i > 256)
            //    {
            //        i = 512 - i;
            //    }
            //    i = sintable[i + 512] * 8 + sintable[i] * 5;
            //    if ((1 - ud.detail) == 0)
            //    {
            //        i >>= 1;
            //    }
            //    Engine.rotatesprite(160 << 16, 100 << 16, i, tang + 512, DefineConstants.MAXTILES - 2, 0, 0, 4 + 2 + 64, Engine._device.windowx1, Engine._device.windowy1, Engine._device.windowx2, Engine._device.windowy2);
            //    walock[DefineConstants.MAXTILES - 2] = 199;
            //}
            // jmarshall end
        }

        restoreinterpolations();

        if (totalclock < lastvisinc)
        {
            if (pragmas.klabs(p.visibility - ud.const_visibility) > 8)
            {
                p.visibility += (ud.const_visibility - p.visibility) >> 2;
            }
        }
        else
        {
            p.visibility = ud.const_visibility;
        }
    }


    public static void drawbackground()
    {
        short dapicnum;
        int x;
        int y;
        int x1;
        int y1;
        int x2;
        int y2;
        int topy;

        flushperms();

        switch (ud.m_volume_number)
        {
            default:
                dapicnum = DefineConstants.BIGHOLE;
                break;
            case 1:
                dapicnum = DefineConstants.BIGHOLE;
                break;
            case 2:
                dapicnum = DefineConstants.BIGHOLE;
                break;
        }

        y1 = 0;
        y2 = Engine.ydim;
        if (ready2send != 0 || ud.recstat == 2)
        {
            if (ud.coop != 1)
            {
                if (ud.multimode > 1)
                {
                    y1 += pragmas.scale(Engine.ydim, 8, 200);
                }
                if (ud.multimode > 4)
                {
                    y1 += pragmas.scale(Engine.ydim, 8, 200);
                }
            }
            if (ud.screen_size >= 8)
            {
                y2 = pragmas.scale(Engine.ydim, 200 - 34, 200);
            }
        }

        for (y = y1; y < y2; y += 128)
        {
            for (x = 0; x < Engine.xdim; x += 128)
            {
                Engine.rotatesprite(x << 16, y << 16, 65536, 0, dapicnum, 8, 0, 8 + 16 + 64 + 128, 0, y1, Engine.xdim - 1, y2 - 1);
            }
        }

        if (ud.screen_size > 8)
        {
            y = 0;
            if (ud.coop != 1)
            {
                if (ud.multimode > 1)
                {
                    y += 8;
                }
                if (ud.multimode > 4)
                {
                    y += 8;
                }
            }

            x1 = Mathf.Max(Engine._device.windowx1 - 4, 0);
            y1 = Mathf.Max(Engine._device.windowy1 - 4, y);
            x2 = Mathf.Min(Engine._device.windowx2 + 4, Engine.xdim - 1);
            y2 = Mathf.Min(Engine._device.windowy2 + 4, pragmas.scale(Engine.ydim, 200 - 34, 200) - 1);

            for (y = y1 + 4; y < y2 - 4; y += 64)
            {
                Engine.rotatesprite(x1 << 16, y << 16, 65536, 0, DefineConstants.VIEWBORDER, 0, 0, 8 + 16 + 64 + 128, x1, y1, x2, y2);
                Engine.rotatesprite((x2 + 1) << 16, (y + 64) << 16, 65536, 1024, DefineConstants.VIEWBORDER, 0, 0, 8 + 16 + 64 + 128, x1, y1, x2, y2);
            }

            for (x = x1 + 4; x < x2 - 4; x += 64)
            {
                Engine.rotatesprite((x + 64) << 16, y1 << 16, 65536, 512, DefineConstants.VIEWBORDER, 0, 0, 8 + 16 + 64 + 128, x1, y1, x2, y2);
                Engine.rotatesprite(x << 16, (y2 + 1) << 16, 65536, 1536, DefineConstants.VIEWBORDER, 0, 0, 8 + 16 + 64 + 128, x1, y1, x2, y2);
            }

            Engine.rotatesprite(x1 << 16, y1 << 16, 65536, 0, DefineConstants.VIEWBORDER + 1, 0, 0, 8 + 16 + 64 + 128, x1, y1, x2, y2);
            Engine.rotatesprite((x2 + 1) << 16, y1 << 16, 65536, 512, DefineConstants.VIEWBORDER + 1, 0, 0, 8 + 16 + 64 + 128, x1, y1, x2, y2);
            Engine.rotatesprite((x2 + 1) << 16, (y2 + 1) << 16, 65536, 1024, DefineConstants.VIEWBORDER + 1, 0, 0, 8 + 16 + 64 + 128, x1, y1, x2, y2);
            Engine.rotatesprite(x1 << 16, (y2 + 1) << 16, 65536, 1536, DefineConstants.VIEWBORDER + 1, 0, 0, 8 + 16 + 64 + 128, x1, y1, x2, y2);
        }
    }
    public static char domovethings()
    {
        short i;
        short j;
        char ch;
// jmarshall - multiplayer
/*
        for (i = connecthead; i >= 0; i = connectpoint2[i])
        {
            if ((sync[i].bits & (1 << 17)) != 0)
            {
                multiflag = 2;
                multiwhat = (sync[i].bits >> 18) & 1;
                multipos = (uint)(sync[i].bits >> 19) & 15;
                multiwho = i;

                if (multiwhat)
                {
                    saveplayer(multipos);
                    multiflag = 0;

                    if (multiwho != myconnectindex)
                    {
                        strcpy(fta_quotes[122], ud.user_name[multiwho][0]);
                        strcat(fta_quotes[122], " SAVED A MULTIPLAYER GAME");
                        FTA(122, ps[myconnectindex]);
                    }
                    else
                    {
                        strcpy(fta_quotes[122], "MULTIPLAYER GAME SAVED");
                        FTA(122, ps[myconnectindex]);
                    }
                    break;
                }
                else
                {
                    //            waitforeverybody();

                    j = (short)loadplayer(multipos);

                    multiflag = 0;

                    if (j == 0)
                    {
                        if (multiwho != myconnectindex)
                        {
                            strcpy(fta_quotes[122], ud.user_name[multiwho][0]);
                            strcat(fta_quotes[122], " LOADED A MULTIPLAYER GAME");
                            FTA(122, ps[myconnectindex]);
                        }
                        else
                        {
                            strcpy(fta_quotes[122], "MULTIPLAYER GAME LOADED");
                            FTA(122, ps[myconnectindex]);
                        }
                        return 1;
                    }
                }
            }
        }
*/
        ud.camerasprite = -1;
        lockclock += (DefineConstants.TICRATE / 26);

        if (earthquaketime > 0)
        {
            earthquaketime--;
        }
        if (rtsplaying > 0)
        {
            rtsplaying--;
        }

        for (i = 0; i < DefineConstants.MAXUSERQUOTES; i++)
        {
            if (user_quote_time[i] != 0)
            {
                user_quote_time[i]--;
                if (user_quote_time[i] == 0)
                {
                    pub = (char)DefineConstants.NUMPAGES;
                }
            }
        }
        if ((pragmas.klabs(quotebotgoal - quotebot) <= 16) && (ud.screen_size <= 8))
        {
            quotebot += pragmas.ksgn(quotebotgoal - quotebot);
        }
        else
        {
            quotebot = quotebotgoal;
        }

        if (show_shareware > 0)
        {
            show_shareware--;
            if (show_shareware == 0)
            {
                pus = (char)DefineConstants.NUMPAGES;
                pub = (char)DefineConstants.NUMPAGES;
            }
        }

        everyothertime++;

        for (i = connecthead; i >= 0; i = connectpoint2[i])
        {
            sync[i] = inputfifo[movefifoplc & (DefineConstants.MOVEFIFOSIZ - 1), i];
        }
        movefifoplc++;

        updateinterpolations();

        j = -1;
// jmarshall - multiplayer
/*
        for (i = connecthead; i >= 0; i = connectpoint2[i])
        {
            if ((sync[i].bits & (1 << 26)) == 0)
            {
                j = i;
                continue;
            }

            //closedemowrite();

            if (i == myconnectindex)
            {
                gameexit(" ");
            }
            if (screenpeek == i)
            {
                screenpeek = connectpoint2[i];
                if (screenpeek < 0)
                {
                    screenpeek = connecthead;
                }
            }

            if (i == connecthead)
            {
                connecthead = connectpoint2[connecthead];
            }
            else
            {
                connectpoint2[j] = connectpoint2[i];
            }

            numplayers--;
            ud.multimode--;

            if (numplayers < 2)
            {
                sound(DefineConstants.GENERIC_AMBIENCE17);
            }

            pub = (char)DefineConstants.NUMPAGES;
            pus = (char)DefineConstants.NUMPAGES;
            vscrn();

            sprintf(buf, "%s is history!", ud.user_name[i]);

            quickkill(ps[i]);
            deletesprite(ps[i].i);

            adduserquote(ref buf);

            if (j < 0 && networkmode == 0)
            {
                gameexit(" \nThe 'MASTER/First player' just quit the game.  All\nplayers are returned from the game. This only happens in 5-8\nplayer mode as a different network scheme is used.");
            }
        }

        if ((numplayers >= 2) && ((movefifoplc & 7) == 7))
        {
            ch = (char)(randomseed & 255);
            for (i = connecthead; i >= 0; i = connectpoint2[i])
            {
                ch += ((ps[i].posx + ps[i].posy + ps[i].posz + ps[i].ang + ps[i].horiz) & 255);
            }
            syncval[myconnectindex][syncvalhead[myconnectindex] & (DefineConstants.MOVEFIFOSIZ - 1)] = ch;
            syncvalhead[myconnectindex]++;
        }

        if (ud.recstat == 1)
        {
            record();
        }
*/
        if (ud.pause_on == 0)
        {
            global_random = (short)Engine.krand();
            movedummyplayers(); //ST 13
        }

        for (i = connecthead; i >= 0; i = connectpoint2[i])
        {
            cheatkeys(i);

            if (ud.pause_on == 0)
            {
                processinput(i);
                checksectors(i);
            }
        }

        if (ud.pause_on == 0)
        {
            movefta(); //ST 2
            moveweapons(); //ST 5 (must be last)
            movetransports(); //ST 9

            moveplayers(); //ST 10
            movefallers(); //ST 12
            moveexplosions(); //ST 4

            moveactors(); //ST 1
            moveeffectors(); //ST 3

            movestandables(); //ST 6
            doanimations();
            movefx(); //ST 11
        }

        fakedomovethingscorrect();

        if ((everyothertime & 1) == 0)
        {
            animatewalls();
            movecyclers();
            pan3dsound();
        }


        return (char)0;
    }
    public static void fakedomovethingscorrect()
    {
        int i;
        player_struct p;

        if (numplayers < 2)
        {
            return;
        }

        i = ((movefifoplc - 1) & (DefineConstants.MOVEFIFOSIZ - 1));
        p = ps[myconnectindex];

        if (p.posx == myxbak[i] && p.posy == myybak[i] && p.posz == myzbak[i] && p.horiz == myhorizbak[i] && p.ang == myangbak[i])
        {
            return;
        }

        myx = p.posx;
        omyx = p.oposx;
        myxvel = p.posxv;
        myy = p.posy;
        omyy = p.oposy;
        myyvel = p.posyv;
        myz = p.posz;
        omyz = p.oposz;
        myzvel = p.poszv;
        myang = p.ang;
        omyang = p.oang;
        mycursectnum = p.cursectnum;
        myhoriz = (short)p.horiz;
        omyhoriz = (short)p.ohoriz;
        myhorizoff = p.horizoff;
        omyhorizoff = (short)p.ohorizoff;
        myjumpingcounter = p.jumping_counter;
        myjumpingtoggle = p.jumping_toggle;
        myonground = p.on_ground;
        myhardlanding = p.hard_landing;
        myreturntocenter = p.return_to_center;

        fakemovefifoplc = movefifoplc;
        while (fakemovefifoplc < movefifoend[myconnectindex])
        {
            fakedomovethings();
        }

    }

    public static void fakedomovethings()
    {
        input syn;
        player_struct p;
        int i = 0;
        int j = 0;
        int k = 0;
        int doubvel = 0;
        int fz = 0;
        int cz = 0;
        int hz = 0;
        int lz = 0;
        int x = 0;
        int y = 0;
        uint sb_snum = 0;
        short psect = 0;
        short psectlotag= 0;
        short tempsect = 0;
        short backcstat = 0;
        bool shrunk = false;
        int spritebridge = 0;

        syn = (input)inputfifo[fakemovefifoplc & (DefineConstants.MOVEFIFOSIZ - 1),myconnectindex];

        p = ps[myconnectindex];

        backcstat = Engine.board.sprite[p.i].cstat;
        Engine.board.sprite[p.i].cstat &= ~257;

        sb_snum = syn.bits;

        psect = mycursectnum;
        psectlotag = Engine.board.sector[psect].lotag;
        spritebridge = (char)0;

        shrunk = (Engine.board.sprite[p.i].yrepeat < 32);

        if (ud.clipping == 0 && (Engine.board.sector[psect].floorpicnum == DefineConstants.MIRROR || psect < 0 || psect >= DefineConstants.MAXSECTORS))
        {
            myx = omyx;
            myy = omyy;
        }
        else
        {
            omyx = myx;
            omyy = myy;
        }

        omyhoriz = myhoriz;
        omyhorizoff = myhorizoff;
        omyz = myz;
        omyang = myang;

        Engine.board.getzrange(myx, myy, myz, psect, ref cz, ref hz, ref fz, ref lz, 163, (((1) << 16) + 1));

        j = Engine.board.getflorzofslope(psect, myx, myy);

        if ((lz & 49152) == 16384 && psectlotag == 1 && pragmas.klabs(myz - j) > (38 << 8) + (16 << 8))
        {
            psectlotag = 0;
        }

        if (p.aim_mode == 0 && myonground != 0 && psectlotag != 2 && (Engine.board.sector[psect].floorstat & 2) != 0)
        {
            x = myx + (Engine.table.sintable[(myang + 512) & 2047] >> 5);
            y = myy + (Engine.table.sintable[myang & 2047] >> 5);
            tempsect = psect;
            Engine.board.updatesector(x, y, ref tempsect);
            if (tempsect >= 0)
            {
                k = Engine.board.getflorzofslope(psect, x, y);
                if (psect == tempsect)
                {
                    myhorizoff += (short)pragmas.mulscale16(j - k, 160);
                }
                else if (pragmas.klabs(Engine.board.getflorzofslope(tempsect, x, y) - k) <= (4 << 8))
                {
                    myhorizoff += (short)pragmas.mulscale16(j - k, 160);
                }
            }
        }
        if (myhorizoff > 0)
        {
            myhorizoff -= (short)((myhorizoff >> 3) + 1);
        }
        else if (myhorizoff < 0)
        {
            myhorizoff += (short)(((-myhorizoff) >> 3) + 1);
        }

        if (hz >= 0 && (hz & 49152) == 49152)
        {
            hz &= (DefineConstants.MAXSPRITES - 1);
            if (Engine.board.sprite[hz].statnum == 1 && Engine.board.sprite[hz].extra >= 0)
            {
                hz = 0;
                cz = Engine.board.getceilzofslope(psect, myx, myy);
            }
        }

        if (lz >= 0 && (lz & 49152) == 49152)
        {
            j = lz & (DefineConstants.MAXSPRITES - 1);
            if ((Engine.board.sprite[j].cstat & 33) == 33)
            {
                psectlotag = 0;
                spritebridge = 1;
            }
            if (badguy(Engine.board.sprite[j]) != 0 && Engine.board.sprite[j].xrepeat > 24 && pragmas.klabs(Engine.board.sprite[p.i].z - Engine.board.sprite[j].z) < (84 << 8))
            {
                j = Engine.getangle(Engine.board.sprite[j].x - myx, Engine.board.sprite[j].y - myy);
                myxvel -= Engine.table.sintable[(j + 512) & 2047] << 4;
                myyvel -= Engine.table.sintable[j & 2047] << 4;
            }
        }

        if (Engine.board.sprite[p.i].extra <= 0)
        {
            if (psectlotag == 2)
            {
                if (p.on_warping_sector == 0)
                {
                    if (pragmas.klabs(myz - fz) > ((38 << 8) >> 1))
                    {
                        myz += 348;
                    }
                }
                Engine.board.clipmove(ref myx, ref myy, ref myz, ref mycursectnum, 0, 0, 164, (4 << 8), (4 << 8), (((1) << 16) + 1));
            }

            Engine.board.updatesector(myx, myy, ref mycursectnum);
            Engine.board.pushmove(ref myx, ref myy, ref myz, ref mycursectnum, 128, (4 << 8), (20 << 8), (((1) << 16) + 1));

            myhoriz = 100;
            myhorizoff = 0;

            goto ENDFAKEPROCESSINPUT;
        }

        doubvel = (DefineConstants.TICRATE / 26);

        if (p.on_crane >= 0)
        {
            goto FAKEHORIZONLY;
        }

        if (p.one_eighty_count < 0)
        {
            myang += 128;
        }

        i = 40;

        if (psectlotag == 2)
        {
            myjumpingcounter = 0;

            if ((sb_snum & 1) != 0)
            {
                if (myzvel > 0)
                {
                    myzvel = 0;
                }
                myzvel -= 348;
                if (myzvel < -(256 * 6))
                {
                    myzvel = -(256 * 6);
                }
            }
            else if ((sb_snum & (1 << 1)) != 0)
            {
                if (myzvel < 0)
                {
                    myzvel = 0;
                }
                myzvel += 348;
                if (myzvel > (256 * 6))
                {
                    myzvel = (256 * 6);
                }
            }
            else
            {
                if (myzvel < 0)
                {
                    myzvel += 256;
                    if (myzvel > 0)
                    {
                        myzvel = 0;
                    }
                }
                if (myzvel > 0)
                {
                    myzvel -= 256;
                    if (myzvel < 0)
                    {
                        myzvel = 0;
                    }
                }
            }

            if (myzvel > 2048)
            {
                myzvel >>= 1;
            }

            myz += myzvel;

            if (myz > (fz - (15 << 8)))
            {
                myz += ((fz - (15 << 8)) - myz) >> 1;
            }

            if (myz < (cz + (4 << 8)))
            {
                myz = cz + (4 << 8);
                myzvel = 0;
            }
        }

        else if (p.jetpack_on != 0)
        {
            myonground = (char)0;
            myjumpingcounter = 0;
            myhardlanding = (char)0;

            if (p.jetpack_on < 11)
            {
                myz -= (p.jetpack_on << 7); //Goin up
            }

            if (shrunk)
            {
                j = 512;
            }
            else
            {
                j = 2048;
            }

            if ((sb_snum & 1) != 0) //A
            {
                myz -= j;
            }
            if ((sb_snum & (1 << 1)) != 0) //Z
            {
                myz += j;
            }

            if (shrunk == false && (psectlotag == 0 || psectlotag == 2))
            {
                k = 32;
            }
            else
            {
                k = 16;
            }

            if (myz > (fz - (k << 8)))
            {
                myz += ((fz - (k << 8)) - myz) >> 1;
            }
            if (myz < (cz + (18 << 8)))
            {
                myz = cz + (18 << 8);
            }
        }
        else if (psectlotag != 2)
        {
            if (psectlotag == 1 && p.spritebridge == 0)
            {
                if (shrunk == false)
                {
                    i = 34;
                }
                else
                {
                    i = 12;
                }
            }
            if (myz < (fz - (i << 8)) && (floorspace(psect) | ceilingspace(psect)) == 0) //falling
            {
                if ((sb_snum & 3) == 0 && myonground != 0 && (Engine.board.sector[psect].floorstat & 2) != 0 && myz >= (fz - (i << 8) - (16 << 8)))
                {
                    myz = fz - (i << 8);
                }
                else
                {
                    myonground = (char)0;

                    myzvel += (gc + 80);

                    if (myzvel >= (4096 + 2048))
                    {
                        myzvel = (4096 + 2048);
                    }
                }
            }

            else
            {
                if (psectlotag != 1 && psectlotag != 2 && myonground == 0 && myzvel > (6144 >> 1))
                {
                    myhardlanding = (char)(myzvel >> 10);
                }
                myonground = (char)1;

                if (i == 40)
                {
                    //Smooth on the ground

                    k = ((fz - (i << 8)) - myz) >> 1;
                    if (pragmas.klabs(k) < 256)
                    {
                        k = 0;
                    }
                    myz += k; // ((fz-(i<<8))-myz)>>1;
                    myzvel -= 768; // 412;
                    if (myzvel < 0)
                    {
                        myzvel = 0;
                    }
                }
                else if (myjumpingcounter == 0)
                {
                    myz += ((fz - (i << 7)) - myz) >> 1; //Smooth on the water
                    if (p.on_warping_sector == 0 && myz > fz - (16 << 8))
                    {
                        myz = fz - (16 << 8);
                        myzvel >>= 1;
                    }
                }

                if ((sb_snum & 2) != 0)
                {
                    myz += (2048 + 768);
                }

                if ((sb_snum & 1) == 0 && myjumpingtoggle == 1)
                {
                    myjumpingtoggle = (char)0;
                }

                else if ((sb_snum & 1) != 0 && myjumpingtoggle == 0)
                {
                    if (myjumpingcounter == 0)
                    {
                        if ((fz - cz) > (56 << 8))
                        {
                            myjumpingcounter = 1;
                            myjumpingtoggle = (char)1;
                        }
                    }
                }
                if (myjumpingcounter != 0 && (sb_snum & 1) == 0)
                {
                    myjumpingcounter = 0;
                }
            }

            if (myjumpingcounter != 0)
            {
                if ((sb_snum & 1) == 0 && myjumpingtoggle == 1)
                {
                    myjumpingtoggle = (char)0;
                }

                if (myjumpingcounter < (1024 + 256))
                {
                    if (psectlotag == 1 && myjumpingcounter > 768)
                    {
                        myjumpingcounter = 0;
                        myzvel = -512;
                    }
                    else
                    {
                        myzvel -= (Engine.table.sintable[(2048 - 128 + myjumpingcounter) & 2047]) / 12;
                        myjumpingcounter += 180;

                        myonground = (char)0;
                    }
                }
                else
                {
                    myjumpingcounter = 0;
                    myzvel = 0;
                }
            }

            myz += myzvel;

            if (myz < (cz + (4 << 8)))
            {
                myjumpingcounter = 0;
                if (myzvel < 0)
                {
                    myxvel = myyvel = 0;
                }
                myzvel = 128;
                myz = cz + (4 << 8);
            }

        }

        if (p.fist_incs != 0 || p.transporter_hold > 2 || myhardlanding != 0 || p.access_incs > 0 || p.knee_incs > 0 || (p.curr_weapon == DefineConstants.TRIPBOMB_WEAPON && p.kickback_pic > 1 && p.kickback_pic < 4))
        {
            doubvel = 0;
            myxvel = 0;
            myyvel = 0;
        }
        else if (syn.avel != 0) //p->ang += syncangvel * constant
        { //ENGINE calculates angvel for you
            int tempang;

            tempang = syn.avel << 1;

            if (psectlotag == 2)
            {
                myang += (short)((tempang - (tempang >> 3)) * pragmas.sgn(doubvel));
            }
            else
            {
                myang += (short)((tempang) * pragmas.sgn(doubvel));
            }
            myang &= 2047;
        }

        if (myxvel != 0 || myyvel != 0|| syn.fvel != 0 || syn.svel != 0)
        {
            if (p.steroids_amount > 0 && p.steroids_amount < 400)
            {
                doubvel <<= 1;
            }

            myxvel += ((syn.fvel * doubvel) << 6);
            myyvel += ((syn.svel * doubvel) << 6);

            if ((p.curr_weapon == DefineConstants.KNEE_WEAPON && p.kickback_pic > 10 && myonground != 0) || (myonground != 0 && (sb_snum & 2) != 0))
            {
                myxvel = pragmas.mulscale16(myxvel, dukefriction - 0x2000);
                myyvel = pragmas.mulscale16(myyvel, dukefriction - 0x2000);
            }
            else
            {
                if (psectlotag == 2)
                {
                    myxvel = pragmas.mulscale16(myxvel, dukefriction - 0x1400);
                    myyvel = pragmas.mulscale16(myyvel, dukefriction - 0x1400);
                }
                else
                {
                    myxvel = pragmas.mulscale16(myxvel, dukefriction);
                    myyvel = pragmas.mulscale16(myyvel, dukefriction);
                }
            }

            if (Mathf.Abs(myxvel) < 2048 && Mathf.Abs(myyvel) < 2048)
            {
                myxvel = myyvel = 0;
            }

            if (shrunk)
            {
                myxvel = pragmas.mulscale16(myxvel, (dukefriction) - (dukefriction >> 1) + (dukefriction >> 2));
                myyvel = pragmas.mulscale16(myyvel, (dukefriction) - (dukefriction >> 1) + (dukefriction >> 2));
            }
        }

        FAKEHORIZONLY:
        if (psectlotag == 1 || spritebridge == 1)
        {
            i = (4 << 8);
        }
        else
        {
            i = (20 << 8);
        }

        Engine.board.clipmove(ref myx, ref myy, ref myz, ref mycursectnum, myxvel, myyvel, 164, 4 << 8, i, (((1) << 16) + 1));
        Engine.board.pushmove(ref myx, ref myy, ref myz, ref mycursectnum, 164, 4 << 8, 4 << 8, (((1) << 16) + 1));

        if (p.jetpack_on == 0 && psectlotag != 1 && psectlotag != 2 && shrunk)
        {
            myz += 30 << 8;
        }

        if ((sb_snum & (1 << 18)) != 0 || myhardlanding != 0)
        {
            myreturntocenter = (char)9;
        }

        if ((sb_snum & (1 << 13)) != 0)
        {
            myreturntocenter = (char)9;
            if ((sb_snum & (1 << 5)) != 0)
            {
                myhoriz += 6;
            }
            myhoriz += 6;
        }
        else if ((sb_snum & (1 << 14)) != 0) 
        {
            myreturntocenter = (char)9;
            if ((sb_snum & (1 << 5)) != 0)
            {
                myhoriz -= 6;
            }
            myhoriz -= 6;
        }
        else if ((sb_snum & (1 << 3)) != 0)
        {
            if ((sb_snum & (1 << 5)) != 0)
            {
                myhoriz += 6;
            }
            myhoriz += 6;
        }
        else if ((sb_snum & (1 << 4)) != 0)
        {
            if ((sb_snum & (1 << 5)) != 0)
            {
                myhoriz -= 6;
            }
            myhoriz -= 6;
        }

        if (myreturntocenter > 0)
        {
            if ((sb_snum & (1 << 13)) == 0 && (sb_snum & (1 << 14)) == 0)
            {
                myreturntocenter--;
                myhoriz += (short)(33 - (myhoriz / 3));
            }
        }

        if (p.aim_mode != 0)
        {
            myhoriz += (short)(syn.horz >> 1);
        }
        else
        {
            if (myhoriz > 95 && myhoriz < 105)
            {
                myhoriz = 100;
            }
            if (myhorizoff > -5 && myhorizoff < 5)
            {
                myhorizoff = 0;
            }
        }

        if (myhardlanding > 0)
        {
            myhardlanding--;
            myhoriz -= (short)(myhardlanding << 4);
        }

        if (myhoriz > 299)
        {
            myhoriz = 299;
        }
        else if (myhoriz < -99)
        {
            myhoriz = -99;
        }

        if (p.knee_incs > 0)
        {
            myhoriz -= 48;
            myreturntocenter = (char)9;
        }


        ENDFAKEPROCESSINPUT:

        myxbak[fakemovefifoplc & (DefineConstants.MOVEFIFOSIZ - 1)] = myx;
        myybak[fakemovefifoplc & (DefineConstants.MOVEFIFOSIZ - 1)] = myy;
        myzbak[fakemovefifoplc & (DefineConstants.MOVEFIFOSIZ - 1)] = myz;
        myangbak[fakemovefifoplc & (DefineConstants.MOVEFIFOSIZ - 1)] = myang;
        myhorizbak[fakemovefifoplc & (DefineConstants.MOVEFIFOSIZ - 1)] = myhoriz;
        fakemovefifoplc++;

        Engine.board.sprite[p.i].cstat = backcstat;
    }

    public static char moveloop()
    {
        int i;

        if (numplayers > 1)
        {
            while (fakemovefifoplc < movefifoend[myconnectindex])
            {
                fakedomovethings();
            }
        }

        getpackets();

        if (numplayers < 2)
        {
            bufferjitter = 0;
        }
        while (movefifoend[myconnectindex] - movefifoplc > bufferjitter)
        {
            for (i = connecthead; i >= 0; i = connectpoint2[i])
            {
                if (movefifoplc == movefifoend[i])
                {
                    break;
                }
            }
            if (i >= 0)
            {
                break;
            }
            if (domovethings() != 0)
            {
                return (char)1;
            }
        }
        return (char)0;
    }

    private static void playback_setup()
    {
        int i;
        int j;
        int k;
        int l;
        int t;
        short p;
        char foundemo;

        foundemo = (char)0;

        RECHECK:

        in_menu = (ps[myconnectindex].gm & DefineConstants.MODE_MENU) != 0;

        pub = (char)DefineConstants.NUMPAGES;
        pus = (char)DefineConstants.NUMPAGES;

        flushperms();

        // jmarshall - demos
        /*
                if (numplayers < 2)
                {
                    foundemo = opendemoread(which_demo);
                }

                if (foundemo == 0)
                {
                    if (which_demo > 1)
                    {
                        which_demo = 1;
                        goto RECHECK;
                    }
                    for (t = 0; t < 63; t += 7)
                    {
                        palto(0, 0, 0, t);
                    }
                    drawbackground();
                    menus();
                    ps[myconnectindex].palette = palette;
                    nextpage();
                    for (t = 63; t > 0; t -= 7)
                    {
                        palto(0, 0, 0, t);
                    }
                    ud.reccnt = 0;
                }
                else
                {
                    ud.recstat = 2;
                    which_demo++;
                    if (which_demo == 10)
                    {
                        which_demo = 1;
                    }
                    enterlevel(DefineConstants.MODE_DEMO);
                }
        */
        for (t = 0; t < 63; t += 7)
        {
            palto(0, 0, 0, t);
        }
        drawbackground();
        menus();
        // ps[myconnectindex].palette = palette; // palette
       // Engine.NextPage();
        for (t = 63; t > 0; t -= 7)
        {
            palto(0, 0, 0, t);
        }
        ud.reccnt = 0;
        // jmarshall end
        if (foundemo == 0 || in_menu || KB_KeyWaiting() != null || numplayers > 1)
        {
            FX_StopAllSounds();
            clearsoundlocks();
            ps[myconnectindex].gm |= DefineConstants.MODE_MENU;
        }

        ready2send = (char)0;
        i = 0;

        KB_FlushKeyboardQueue();

    }

    private static bool playback_state()
    {
        {
            drawbackground();
        }
        
        if ((ps[myconnectindex].gm & DefineConstants.MODE_MENU) != 0 && (ps[myconnectindex].gm & DefineConstants.MODE_EOL) != 0)
        {
            currentStage = GameStateType.GAME_STATE_MENU_NOGAME_SETUP;
            return false;
        }

        if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false))
        {
            {
                KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
            };
            FX_StopAllSounds();
            clearsoundlocks();
            ps[myconnectindex].gm |= DefineConstants.MODE_MENU;
            cmenu(0);
            intomenusounds();
        }

        if ((ps[myconnectindex].gm & DefineConstants.MODE_TYPE) != 0)
        {
            //typemode();
            if ((ps[myconnectindex].gm & DefineConstants.MODE_TYPE) != DefineConstants.MODE_TYPE)
            {
                ps[myconnectindex].gm = DefineConstants.MODE_MENU;
            }
        }
        else
        {
            menus();
        }

        operatefta();

        if (ud.last_camsprite != ud.camerasprite)
        {
            ud.last_camsprite = ud.camerasprite;
            ud.camera_time = totalclock + (DefineConstants.TICRATE * 2);
        }

#if VOLUMEONE
			if (ud.show_help == 0 && (ps[myconnectindex].gm & DefineConstants.MODE_MENU) == 0)
			{
				Engine.rotatesprite((320 - 50) << 16,9 << 16,65536,0,DefineConstants.BETAVERSION,0,0,2 + 8 + 16 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);
			}
#endif
        getpackets();
        Engine.NextPage();

        if (ps[myconnectindex].gm == DefineConstants.MODE_END || ps[myconnectindex].gm == DefineConstants.MODE_GAME)
        {
            // jmarshall - demo
            //if (foundemo)
            //{
            //    kclose(recfilep);
            //}
            // jmarshall end
            return true;
        }

        if ((ps[myconnectindex].gm & DefineConstants.MODE_MENU) != 0)
        {
            currentStage = GameStateType.GAME_STATE_MENU_NOGAME_SETUP;
            return false;
        }

        return true;
    }

    private static int playback()
    {
        int i;
        int j;
        int k;
        int l;
        int t;
        short p;
        char foundemo;

        if (ready2send != 0)
        {
            return 0;
        }

        foundemo = (char)0;

        RECHECK:

        in_menu = (ps[myconnectindex].gm & DefineConstants.MODE_MENU) != 0;

        pub = (char)DefineConstants.NUMPAGES;
        pus = (char)DefineConstants.NUMPAGES;

        flushperms();

// jmarshall - demos
/*
        if (numplayers < 2)
        {
            foundemo = opendemoread(which_demo);
        }

        if (foundemo == 0)
        {
            if (which_demo > 1)
            {
                which_demo = 1;
                goto RECHECK;
            }
            for (t = 0; t < 63; t += 7)
            {
                palto(0, 0, 0, t);
            }
            drawbackground();
            menus();
            ps[myconnectindex].palette = palette;
            nextpage();
            for (t = 63; t > 0; t -= 7)
            {
                palto(0, 0, 0, t);
            }
            ud.reccnt = 0;
        }
        else
        {
            ud.recstat = 2;
            which_demo++;
            if (which_demo == 10)
            {
                which_demo = 1;
            }
            enterlevel(DefineConstants.MODE_DEMO);
        }
*/
        for (t = 0; t < 63; t += 7)
        {
            palto(0, 0, 0, t);
        }
        drawbackground();
        menus();
       // ps[myconnectindex].palette = palette; // palette
        Engine.NextPage();
        for (t = 63; t > 0; t -= 7)
        {
            palto(0, 0, 0, t);
        }
        ud.reccnt = 0;
// jmarshall end
        if (foundemo == 0 || in_menu || KB_KeyWaiting() != null || numplayers > 1)
        {
            FX_StopAllSounds();
            clearsoundlocks();
            ps[myconnectindex].gm |= DefineConstants.MODE_MENU;
        }

        ready2send = (char)0;
        i = 0;

        KB_FlushKeyboardQueue();

        k = 0;

        while (ud.reccnt > 0 || foundemo == 0)
        {
// jmarshall - demo
            //if (foundemo)
            //{
            //    while (totalclock >= (lockclock + (DefineConstants.TICRATE / 26)))
            //    {
            //        if ((i == 0) || (i >= DefineConstants.RECSYNCBUFSIZ))
            //        {
            //            i = 0;
            //            l = Math.Min(ud.reccnt, DefineConstants.RECSYNCBUFSIZ);
            //            kdfread(recsync, sizeof(input) * ud.multimode, l / ud.multimode, recfilep);
            //        }
            //
            //        for (j = connecthead; j >= 0; j = connectpoint2[j])
            //        {
            //            copybufbyte(recsync[i], inputfifo[movefifoend[j] & (DefineConstants.MOVEFIFOSIZ - 1)][j], sizeof(input));
            //            movefifoend[j]++;
            //            i++;
            //            ud.reccnt--;
            //        }
            //        domovethings();
            //    }
            //}
// jmarshall end
            //if (foundemo == 0)
            {
                drawbackground();
            }
            //else
            //{
            //    nonsharedkeys();
            //
            //    j = Math.Min(Math.Max((totalclock - lockclock) * (65536 / (DefineConstants.TICRATE / 26)), 0), 65536);
            //    displayrooms(screenpeek, j);
            //    displayrest(j);
            //
            //    if (ud.multimode > 1 && ps[myconnectindex].gm)
            //    {
            //        getpackets();
            //    }
            //}

            if ((ps[myconnectindex].gm & DefineConstants.MODE_MENU) != 0 && (ps[myconnectindex].gm & DefineConstants.MODE_EOL) != 0)
            {
                goto RECHECK;
            }

            if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false))
            {
                {
                    KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
                };
                FX_StopAllSounds();
                clearsoundlocks();
                ps[myconnectindex].gm |= DefineConstants.MODE_MENU;
                cmenu(0);
                intomenusounds();
            }

            if ((ps[myconnectindex].gm & DefineConstants.MODE_TYPE) != 0)
            {
                //typemode();
                if ((ps[myconnectindex].gm & DefineConstants.MODE_TYPE) != DefineConstants.MODE_TYPE)
                {
                    ps[myconnectindex].gm = DefineConstants.MODE_MENU;
                }
            }
            else
            {
                menus();
// jmarshall: multiplayer
                //if (ud.multimode > 1)
                //{
                //    ControlInfo noshareinfo = new ControlInfo();
                //    CONTROL_GetInput(noshareinfo);
                //    if ((((gamefunc_SendMessage) > 31) ? ((CONTROL_ButtonState2 >> ((gamefunc_SendMessage) - 32)) & 1) : ((CONTROL_ButtonState1 >> (gamefunc_SendMessage)) & 1)) != 0)
                //    {
                //        KB_FlushKeyboardQueue();
                //        CONTROL_ClearButton(gamefunc_SendMessage);
                //        ps[myconnectindex].gm = DefineConstants.MODE_TYPE;
                //        typebuf[0] = 0;
                //        inputloc = 0;
                //    }
                //}
// jmarshall end
            }

            operatefta();

            if (ud.last_camsprite != ud.camerasprite)
            {
                ud.last_camsprite = ud.camerasprite;
                ud.camera_time = totalclock + (DefineConstants.TICRATE * 2);
            }

#if VOLUMEONE
			if (ud.show_help == 0 && (ps[myconnectindex].gm & DefineConstants.MODE_MENU) == 0)
			{
				Engine.rotatesprite((320 - 50) << 16,9 << 16,65536,0,DefineConstants.BETAVERSION,0,0,2 + 8 + 16 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);
			}
#endif
            getpackets();
            Engine.NextPage();

            if (ps[myconnectindex].gm == DefineConstants.MODE_END || ps[myconnectindex].gm == DefineConstants.MODE_GAME)
            {
// jmarshall - demo
                //if (foundemo)
                //{
                //    kclose(recfilep);
                //}
// jmarshall end
                return 0;
            }
        }
        //kclose(recfilep);
        if ((ps[myconnectindex].gm & DefineConstants.MODE_MENU) != 0)
        {
            goto RECHECK;
        }
        return 1;
    }

/*
    private static void Logo()
    {
        short i;
        short j;
        short soundanm;

        soundanm = 0;

        ready2send = (char)0;

        ps[myconnectindex].palette = drealms;

        KB_FlushKeyboardQueue();

        Engine._device.setview(0, 0, Engine.xdim - 1, Engine.ydim - 1);
		Engine.clearview();
        palto(0, 0, 0, 63);

        flushperms();
		Engine.NextPage();

        MUSIC_StopSong();

#if !DEMO

		if (KB_KeyWaiting() == null && nomorelogohack == 0)
		{
			getpackets();
			playanm("logo.anm", 5);
			palto(0, 0, 0, 63);
			KB_FlushKeyboardQueue();
		}

		Engine.clearview();
        Engine.NextPage();
#endif

        playmusic(0, 0);
        for (i = 0; i < 64; i += 7)
        {
            palto(0, 0, 0, i);
        }
        ps[myconnectindex].palette = drealms;
        palto(0, 0, 0, 63);
        int width = Engine.xdim - 1;
        int height = Engine.ydim - 1;
        Engine.rotatesprite(0, 0, 65536, 0, DefineConstants.DREALMS, 0, 0, 2 + 8 + 16 + 64, 0, 0, width, height);
        Engine.NextPage();
        for (i = 63; i > 0; i -= 7)
        {
            palto(0, 0, 0, i);
        }
        totalclock = 0;
        while (totalclock < (120 * 7) && KB_KeyWaiting() == 0)
        {
            getpackets();
        }

        for (i = 0; i < 64; i += 7)
        {
            palto(0, 0, 0, i);
        }
        Engine.clearview();
		Engine.NextPage();

        ps[myconnectindex].palette = titlepal;
        flushperms();
        Engine.rotatesprite(0, 0, 65536, 0, DefineConstants.BETASCREEN, 0, 0, 2 + 8 + 16 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
        KB_FlushKeyboardQueue();
		Engine.NextPage();
		for (i = 63; i > 0; i -= 7)
        {
            palto(0, 0, 0, i);
        }
        totalclock = 0;

        while (totalclock < (860 + 120) && KB_KeyWaiting() == 0)
        {
            Engine.rotatesprite(0, 0, 65536, 0, DefineConstants.BETASCREEN, 0, 0, 2 + 8 + 16 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

            if (totalclock > 120 && totalclock < (120 + 60))
            {
                if (soundanm == 0)
                {
                    soundanm = 1;
                    sound(DefineConstants.PIPEBOMB_EXPLODE);
                }
                Engine.rotatesprite(160 << 16, 104 << 16, (totalclock - 120) << 10, 0, DefineConstants.DUKENUKEM, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
            }
            else if (totalclock >= (120 + 60))
            {
                Engine.rotatesprite(160 << 16, (104) << 16, 60 << 10, 0, DefineConstants.DUKENUKEM, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
            }

            if (totalclock > 220 && totalclock < (220 + 30))
            {
                if (soundanm == 1)
                {
                    soundanm = 2;
                    sound(DefineConstants.PIPEBOMB_EXPLODE);
                }

                Engine.rotatesprite(160 << 16, (104) << 16, 60 << 10, 0, DefineConstants.DUKENUKEM, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                Engine.rotatesprite(160 << 16, (129) << 16, (totalclock - 220) << 11, 0, DefineConstants.THREEDEE, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
            }
            else if (totalclock >= (220 + 30))
            {
                Engine.rotatesprite(160 << 16, (129) << 16, 30 << 11, 0, DefineConstants.THREEDEE, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
            }

            if (totalclock >= 280 && totalclock < 395)
            {
                Engine.rotatesprite(160 << 16, (151) << 16, (410 - totalclock) << 12, 0, DefineConstants.PLUTOPAKSPRITE + 1, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                if (soundanm == 2)
                {
                    soundanm = 3;
                    sound(DefineConstants.FLY_BY);
                }
            }
            else if (totalclock >= 395)
            {
                if (soundanm == 3)
                {
                    soundanm = 4;
                    sound(DefineConstants.PIPEBOMB_EXPLODE);
                }
                Engine.rotatesprite(160 << 16, (151) << 16, 30 << 11, 0, DefineConstants.PLUTOPAKSPRITE + 1, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
            }

            getpackets();
			Engine.NextPage();
		}

        if (ud.multimode > 1)
        {
            Engine.rotatesprite(0, 0, 65536, 0, DefineConstants.BETASCREEN, 0, 0, 2 + 8 + 16 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

            Engine.rotatesprite(160 << 16, (104) << 16, 60 << 10, 0, DefineConstants.DUKENUKEM, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
            Engine.rotatesprite(160 << 16, (129) << 16, 30 << 11, 0, DefineConstants.THREEDEE, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
            Engine.rotatesprite(160 << 16, (151) << 16, 30 << 11, 0, DefineConstants.PLUTOPAKSPRITE + 1, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

            gametext(160, 190, "WAITING FOR PLAYERS", 14, 2);
			Engine.NextPage();
		}

        waitforeverybody();

        flushperms();
        Engine.clearview();
		Engine.NextPage();

        ps[myconnectindex].palette = palette; 
        sound(DefineConstants.NITEVISION_ONOFF);

        palto(0, 0, 0, 0);
		Engine.clearview();
    }
*/
    /*
	===================
	=
	= Startup
	=
	===================
	*/

    private static void Startup()
	{
		int i;

		//KB_Startup();

		loadefs(DefineConstants.confilename);

        Engine.loadpics("tiles000.art");


        Engine.tilesizx[DefineConstants.MIRROR] = 0;
        Engine.tilesizy[DefineConstants.MIRROR] = 0;

//		CONFIG_GetSetupFilename();
//		CONFIG_ReadSetup();
//
//#if AUSTRALIA
//	  ud.lockout = 1;
//#endif
//
//		if (CommandSoundToggleOff != 0)
//		{
//			SoundToggle = 0;
//		}
//		if (CommandMusicToggleOff != 0)
//		{
//			MusicToggle = 0;
//		}
//
//#if VOLUMEONE
//
//	   printf("\n*** You have run Duke Nukem 3D %ld times. ***\n\n",ud.executions);
//	   if (ud.executions >= 50)
//	   {
//		   puts("IT IS NOW TIME TO UPGRADE TO THE COMPLETE VERSION!!!\n");
//	   }
//
//#endif
//
//		CONTROL_Startup(ControllerType, GetTime, DefineConstants.TICRATE);
//
//		// CTW - MODIFICATION
//		// initengine(ScreenMode,ScreenWidth,ScreenHeight);
//		initengine();
//		// CTW END - MODIFICATION
//		inittimer();
//
//		puts("* Hold Esc to Abort. *");
//		puts("Loading art header.");
//		loadpics("tiles000.art");
//
//		readsavenames();
//
//		Engine.tilesizx[DefineConstants.MIRROR] = tilesizy[DefineConstants.MIRROR] = 0;
//
//		for (i = 0; i < DefineConstants.MAXPLAYERS; i++)
//		{
//			playerreadyflag[i] = 0;
//		}
//		initmultiplayers(0, 0, 0);
//
//		if (numplayers > 1)
//		{
//			puts("Multiplayer initialized.");
//		}
//
//		ps[myconnectindex].palette = (string)&palette[0];
//		SetupGameButtons();
//
//		if (networkmode == 255)
//		{
//			networkmode = 1;
//		}

		//puts("Checking music inits.");
		//MusicStartup();
		//puts("Checking sound inits.");
		//SoundStartup();
		//loadtmb();
	}

	public static void DukeMain(string commandLine)
	{
		int i;
		int j;
		int k;
		int l;
		int tempautorun;

 
		Debug.Log("Duke Nukem 3D 1.4 - Atomic Edition");
        Debug.Log("Copyright (c) 1996 3D Realms Entertainment");

        ud.multimode = 1;

		Engine.initgroupfile("duke3d.grp");

		//checkcommandline(argc, argv);
		//
		//totalmemory = Z_AvailHeap();
		//
		//if (memorycheckoveride == 0)
		//{
		//	if (totalmemory < (3162000 - 350000))
		//	{
		//		puts("You don't have enough free memory to run Duke Nukem 3D.");
		//		puts("The DOS \"mem\" command should report 6,800K (or 6.8 megs)");
		//		puts("of \"total memory free\".\n");
		//		printf("Duke Nukem 3D requires %ld more bytes to run.\n", 3162000 - 350000 - totalmemory);
		//		exit(0);
		//	}
		//}
		//else
		//{
		//	printf("Using %ld bytes for heap.\n", totalmemory);
		//}

		Startup();

        for (int d = 0; d < 10; d++)
        {
            string savname = SaveFileExists(d);
            if (savname != null)
            {
                ud.savegame[d] = savname;
            }
            else
            {
                ud.savegame[d] = "";
            }
        }

        if (numplayers > 1)
		{
			ud.multimode = numplayers;
		//	sendlogon();
		}
		else if (boardfilename.Length != 0)
		{
			ud.m_level_number = 7;
			ud.m_volume_number = 0;
			ud.warp_on = 1;
		}

		//getnames();

		if (ud.multimode > 1)
		{
			playerswhenstarted = (char)ud.multimode;

			if (ud.warp_on == 0)
			{
				ud.m_monsters_off = 1;
				ud.m_player_skill = 0;
			}
		}

		ud.last_level = -1;

		//RTS_Init(ref ud.rtsname);
		//if (numlumps)
		//{
		//	printf("Using .RTS file:%s\n", ud.rtsname);
		//}

		//if (CONTROL_JoystickEnabled)
		//{
		//	CONTROL_CenterJoystick(CenterCenter, UpperLeft, LowerRight, CenterThrottle, CenterRudder);
		//}

		//puts("Loading palette/lookups.");

		// CTW - MODIFICATION
		/*  if( setgamemode(ScreenMode,ScreenWidth,ScreenHeight) < 0 )
			{
				printf("\nVESA driver for ( %i * %i ) not found/supported!\n",Engine.xdim,Engine.ydim);
				vidoption = 2;
				setgamemode(vidoption,320,200);
			}*/

		//Engine.setgamemode(ScreenMode, ScreenWidth, ScreenHeight);
		
		genspriteremaps();

        ps[myconnectindex] = new player_struct();
        sync[myconnectindex] = new input();
#if VOLUMEONE
			if (numplayers > 4 || ud.multimode > 4)
			{
				gameexit(" The full version of Duke Nukem 3D supports 5 or more players.");
			}
#endif
        // jmarshall - palette
        //Engine.setbrightness(ud.brightness >> 2, ps[myconnectindex].palette[0]);
        // jmarshall end
        //if ((KB_KeyDown[(DefineConstants.sc_Escape)] != 0))
        //{
        //	gameexit(" ");
        //}

        FX_StopAllSounds();
		clearsoundlocks();

        palette = Engine.palette.palette;

        //if (ud.warp_on > 1 && ud.multimode < 2)
        //{
        //	clearview(0);
        //	ps[myconnectindex].palette = palette;
        //	palto(0, 0, 0, 0);
        //	Engine.rotatesprite(320 << 15, 200 << 15, 65536, 0, DefineConstants.LOADSCREEN, 0, 0, 2 + 8 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
        //	menutext(160, 105, 0, 0, "LOADING SAVED GAME...");
        //	nextpage();
        //
        //	j = loadplayer(ud.warp_on - 2);
        //	if (j != 0)
        //	{
        //		ud.warp_on = 0;
        //	}
        //}

        //    getpackets();
#if false
        MAIN_LOOP_RESTART:

		if (ud.warp_on == 0)
		{
			Logo();
		}
		else if (ud.warp_on == 1)
		{
			newgame((char)ud.m_volume_number, (char)ud.m_level_number, (char)ud.m_player_skill);
			enterlevel((char)DefineConstants.MODE_GAME);
		}
		else
		{
			vscrn();
		}

		tempautorun = ud.auto_run;

		if (ud.warp_on == 0 && playback() != 0)
		{
			FX_StopAllSounds();
			clearsoundlocks();
			nomorelogohack = (char)1;
			goto MAIN_LOOP_RESTART;
		}

		ud.auto_run = tempautorun;

		ud.warp_on = 0;

		while ((ps[myconnectindex].gm & DefineConstants.MODE_END) == 0) //The whole loop!!!!!!!!!!!!!!!!!!
		{
			if (ud.recstat == 2 || ud.multimode > 1 || (ud.show_help == 0 && (ps[myconnectindex].gm & DefineConstants.MODE_MENU) != DefineConstants.MODE_MENU))
			{
				if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
				{
					if (moveloop() != 0)
					{
						continue;
					}
				}
			}

			if ((ps[myconnectindex].gm & DefineConstants.MODE_EOL) != 0 || (ps[myconnectindex].gm & DefineConstants.MODE_RESTART) != 0)
			{
				if ((ps[myconnectindex].gm & DefineConstants.MODE_EOL) != 0)
				{
#if ONELEVELDEMO
					gameexit(" ");
#endif
					//closedemowrite(); // jmarshall : demo

					ready2send = (char)0;

					i = ud.screen_size;
					ud.screen_size = 0;
					vscrn();
					ud.screen_size = i;
					dobonus((char)0); // jmarshall: end screens

					if (ud.eog != 0)
					{
						ud.eog = 0;
						if (ud.multimode < 2)
						{
//#if DEMO
//							doorders();
//#endif
							ps[myconnectindex].gm = DefineConstants.MODE_MENU;
							cmenu(0);
							probey = 0;
							goto MAIN_LOOP_RESTART;
						}
						else
						{
							ud.m_level_number = 0;
							ud.level_number = 0;
						}
					}
				}

				ready2send = (char)0;
				if (numplayers > 1)
				{
					ps[myconnectindex].gm = DefineConstants.MODE_GAME;
				}
				enterlevel((char)ps[myconnectindex].gm);
				continue;
			}

			//cheats();
			//nonsharedkeys(); // jmarshall: hot keys

			if ((ud.show_help == 0 && ud.multimode < 2 && 0 == (ps[myconnectindex].gm & DefineConstants.MODE_MENU)) || ud.multimode > 1 || ud.recstat == 2)
			{
				i = Mathf.Min(Mathf.Max((totalclock - ototalclock) * (65536 / (DefineConstants.TICRATE / 26)), 0), 65536);
			}
			else
			{
				i = 65536;
			}

			displayrooms(screenpeek, i);
			displayrest(i);

			//        if( KB_KeyPressed(sc_F) )
			//        {
			//            KB_ClearKeyDown(sc_F);
			//            addplayer();
			//        }

			if ((ps[myconnectindex].gm & DefineConstants.MODE_DEMO) != 0)
			{
				goto MAIN_LOOP_RESTART;
			}

			//if (debug_on)
			//{
			//	caches();
			//}

			checksync();

#if VOLUMEONE
			if (ud.show_help == 0 && show_shareware > 0 && (ps[myconnectindex].gm & DefineConstants.MODE_MENU) == 0)
			{
				Engine.rotatesprite((320 - 50) << 16,9 << 16,65536,0,DefineConstants.BETAVERSION,0,0,2 + 8 + 16 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);
			}
#endif
			Engine.NextPage();
		}

		gameexit(" ");
#endif
	}

    private static void DukeCoreLoop()
    {
        int i;
        if (ud.recstat == 2 || ud.multimode > 1 || (ud.show_help == 0 && (ps[myconnectindex].gm & DefineConstants.MODE_MENU) != DefineConstants.MODE_MENU))
        {
            if ((ps[myconnectindex].gm & DefineConstants.MODE_GAME) != 0)
            {
                if (moveloop() != 0)
                {
                    return;
                }
            }
        }

        if ((ps[myconnectindex].gm & DefineConstants.MODE_EOL) != 0 || (ps[myconnectindex].gm & DefineConstants.MODE_RESTART) != 0)
        {
            if ((ps[myconnectindex].gm & DefineConstants.MODE_EOL) != 0)
            {
#if ONELEVELDEMO
					gameexit(" ");
#endif
                //closedemowrite(); // jmarshall : demo

                ready2send = (char)0;

                i = ud.screen_size;
                ud.screen_size = 0;
                vscrn();
                ud.screen_size = i;
             //   dobonus((char)0); // jmarshall: end screens

                if (ud.eog != 0)
                {
                    ud.eog = 0;
                    if (ud.multimode < 2)
                    {
                        //#if DEMO
                        //							doorders();
                        //#endif
                        ps[myconnectindex].gm = DefineConstants.MODE_MENU;
                        cmenu(0);
                        probey = 0;
                        currentStage = GameStateType.GAME_STATE_LOGO_LOGOANIM;
                    }
                    else
                    {
                        ud.m_level_number = 0;
                        ud.level_number = 0;
                    }
                }
            }

            ready2send = (char)0;
            if (numplayers > 1)
            {
                ps[myconnectindex].gm = DefineConstants.MODE_GAME;
            }
            enterlevel((char)ps[myconnectindex].gm);
            return;
        }

        //cheats();
        //nonsharedkeys(); // jmarshall: hot keys

        if ((ud.show_help == 0 && ud.multimode < 2 && 0 == (ps[myconnectindex].gm & DefineConstants.MODE_MENU)) || ud.multimode > 1 || ud.recstat == 2)
        {
            i = Mathf.Min(Mathf.Max((totalclock - ototalclock) * (65536 / (DefineConstants.TICRATE / 26)), 0), 65536);
        }
        else
        {
            i = 65536;
        }

        displayrooms(screenpeek, i);
        displayrest(i);

        //        if( KB_KeyPressed(sc_F) )
        //        {
        //            KB_ClearKeyDown(sc_F);
        //            addplayer();
        //        }

        if ((ps[myconnectindex].gm & DefineConstants.MODE_DEMO) != 0)
        {
            currentStage = GameStateType.GAME_STATE_LOGO_MOVIE;
            return;
        }

        //if (debug_on)
        //{
        //	caches();
        //}

        checksync();

#if VOLUMEONE
			if (ud.show_help == 0 && show_shareware > 0 && (ps[myconnectindex].gm & DefineConstants.MODE_MENU) == 0)
			{
				Engine.rotatesprite((320 - 50) << 16,9 << 16,65536,0,DefineConstants.BETAVERSION,0,0,2 + 8 + 16 + 128,0,0,Engine.xdim - 1,Engine.ydim - 1);
			}
#endif
        Engine.NextPage();
    }
}
