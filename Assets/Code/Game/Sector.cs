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
    public static int haltsoundhack = 0;
    public static short callsound(short sn, short whatsprite)
    {
        int i;

        if (haltsoundhack != 0)
        {
            haltsoundhack = 0;
            return -1;
        }

        i = Engine.board.headspritesect[sn];
        while (i >= 0)
        {
            if (Engine.board.sprite[i].picnum == DefineConstants.MUSICANDSFX && Engine.board.sprite[i].lotag < 1000)
            {
                if (whatsprite == -1)
                {
                    whatsprite = (short)i;
                }

                if (hittype[i].count == 0)
                {
                    if ((soundm[Engine.board.sprite[i].lotag] & 16) == 0)
                    {
                        if (Engine.board.sprite[i].lotag != 0)
                        {
                            spritesound(Engine.board.sprite[i].lotag, whatsprite);
                            if (Engine.board.sprite[i].hitag != 0 && Engine.board.sprite[i].lotag != Engine.board.sprite[i].hitag && Engine.board.sprite[i].hitag < DefineConstants.NUM_SOUNDS)
                            {
                                stopsound(Engine.board.sprite[i].hitag);
                            }
                        }

                        if ((Engine.board.sector[Engine.board.sprite[i].sectnum].lotag & 0xff) != 22)
                        {
                            hittype[i].count = 1;
                        }
                    }
                }
                else if (Engine.board.sprite[i].hitag < DefineConstants.NUM_SOUNDS)
                {
                    if (Engine.board.sprite[i].hitag != 0)
                    {
                        spritesound(Engine.board.sprite[i].hitag, whatsprite);
                    }
                    if ((soundm[Engine.board.sprite[i].lotag] & 1) != 0 || (Engine.board.sprite[i].hitag != 0 && Engine.board.sprite[i].hitag != Engine.board.sprite[i].lotag))
                    {
                        stopsound(Engine.board.sprite[i].lotag);
                    }
                    hittype[i].count = 0;
                }
                return Engine.board.sprite[i].lotag;
            }
            i = Engine.board.nextspritesect[i];
        }
        return -1;
    }

    public static short check_activator_motion(short lotag)
    {
        int i;
        int j;
        spritetype s;

        i = Engine.board.headspritestat[8];
        while (i >= 0)
        {
            if (Engine.board.sprite[i].lotag == lotag)
            {
                s = Engine.board.sprite[i];

                for (j = animatecnt - 1; j >= 0; j--)
                {
                    if (s.sectnum == animatesect[j])
                    {
                        return (1);
                    }
                }

                j = Engine.board.headspritestat[3];
                while (j >= 0)
                {
                    if (s.sectnum == Engine.board.sprite[j].sectnum)
                    {
                        switch (Engine.board.sprite[j].lotag)
                        {
                            case 11:
                            case 30:
                                if (hittype[j].temp_data[4] != 0)
                                {
                                    return (1);
                                }
                                break;
                            case 20:
                            case 31:
                            case 32:
                            case 18:
                                if (hittype[j].count != 0)
                                {
                                    return (1);
                                }
                                break;
                        }
                    }

                    j = Engine.board.nextspritestat[j];
                }
            }
            i = Engine.board.nextspritestat[i];
        }
        return (0);
    }

    public static bool isadoorwall(short dapic)
    {
        switch (dapic)
        {
            case DefineConstants.DOORTILE1:
            case DefineConstants.DOORTILE2:
            case DefineConstants.DOORTILE3:
            case DefineConstants.DOORTILE4:
            case DefineConstants.DOORTILE5:
            case DefineConstants.DOORTILE6:
            case DefineConstants.DOORTILE7:
            case DefineConstants.DOORTILE8:
            case DefineConstants.DOORTILE9:
            case DefineConstants.DOORTILE10:
            case DefineConstants.DOORTILE11:
            case DefineConstants.DOORTILE12:
            case DefineConstants.DOORTILE14:
            case DefineConstants.DOORTILE15:
            case DefineConstants.DOORTILE16:
            case DefineConstants.DOORTILE17:
            case DefineConstants.DOORTILE18:
            case DefineConstants.DOORTILE19:
            case DefineConstants.DOORTILE20:
            case DefineConstants.DOORTILE21:
            case DefineConstants.DOORTILE22:
            case DefineConstants.DOORTILE23:
                return true;
        }
        return false;
    }

    public static bool isanunderoperator(short lotag)
    {
        switch (lotag & 0xff)
        {
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 22:
            case 26:
                return true;
        }
        return false;
    }

    public static bool isanearoperator(short lotag)
    {
        switch (lotag & 0xff)
        {
            case 9:
            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
            case 22:
            case 23:
            case 25:
            case 26:
            case 29: //Toothed door
                return true;
        }
        return false;
    }

    public static short checkcursectnums(short sect)
    {
        short i;
        for (i = connecthead; i >= 0; i = connectpoint2[i])
        {
            if (Engine.board.sprite[ps[i].i].sectnum == sect)
            {
                return i;
            }
        }
        return -1;
    }

    public static int ldist(spritetype s1, spritetype s2)
    {
        int vx;
        int vy;
        vx = s1.x - s2.x;
        vy = s1.y - s2.y;
        return (Engine.FindDistance2D(vx, vy) + 1);
    }

    public static int ldist(spritetype s1, spritetype2 s2)
    {
        int vx;
        int vy;
        vx = s1.x - s2.x;
        vy = s1.y - s2.y;
        return (Engine.FindDistance2D(vx, vy) + 1);
    }

    public static int dist(spritetype s1, spritetype s2)
    {
        int vx;
        int vy;
        int vz;
        vx = s1.x - s2.x;
        vy = s1.y - s2.y;
        vz = s1.z - s2.z;
        return (Engine.FindDistance3D(vx, vy, vz >> 4));
    }

    public static short findplayer(spritetype s, ref int d)
    {
        short j;
        short closest_player;
        int x;
        int closest;

        if (ud.multimode < 2)
        {
            d = pragmas.klabs(ps[myconnectindex].oposx - s.x) + pragmas.klabs(ps[myconnectindex].oposy - s.y) + ((pragmas.klabs(ps[myconnectindex].oposz - s.z + (28 << 8))) >> 4);
            return myconnectindex;
        }

        closest = 0x7fffffff;
        closest_player = 0;

        for (j = connecthead; j >= 0; j = connectpoint2[j])
        {
            x = pragmas.klabs(ps[j].oposx - s.x) + pragmas.klabs(ps[j].oposy - s.y) + ((pragmas.klabs(ps[j].oposz - s.z + (28 << 8))) >> 4);
            if (x < closest && Engine.board.sprite[ps[j].i].extra > 0)
            {
                closest_player = j;
                closest = x;
            }
        }

        d = closest;
        return closest_player;
    }

    public static short findotherplayer(short p, ref int d)
    {
        short j;
        short closest_player;
        int x;
        int closest;

        closest = 0x7fffffff;
        closest_player = p;

        for (j = connecthead; j >= 0; j = connectpoint2[j])
        {
            if (p != j && Engine.board.sprite[ps[j].i].extra > 0)
            {
                x = pragmas.klabs(ps[j].oposx - ps[p].posx) + pragmas.klabs(ps[j].oposy - ps[p].posy) + (pragmas.klabs(ps[j].oposz - ps[p].posz) >> 4);

                if (x < closest)
                {
                    closest_player = j;
                    closest = x;
                }
            }
        }

        d = closest;
        return closest_player;
    }

    public static void doanimations()
    {
        // jmarshall - sector animations
        /*
                int i;
                int j;
                int a;
                int p;
                int v;
                int dasect;

                for (i = animatecnt - 1; i >= 0; i--)
                {
                    a = *animateptr[i];
                    v = animatevel[i] * (DefineConstants.TICRATE / 26);
                    dasect = animatesect[i];

                    if (a == animategoal[i])
                    {
                        stopinterpolation(ref animateptr[i]);

                        animatecnt--;
                        animateptr[i] = animateptr[animatecnt];
                        animategoal[i] = animategoal[animatecnt];
                        animatevel[i] = animatevel[animatecnt];
                        animatesect[i] = animatesect[animatecnt];
                        if (sector[animatesect[i]].lotag == 18 || sector[animatesect[i]].lotag == 19)
                        {
                            if (animateptr[i] == &sector[animatesect[i]].ceilingz)
                            {
                                continue;
                            }
                        }

                        if ((sector[dasect].lotag & 0xff) != 22)
                        {
                            callsound((short)dasect, -1);
                        }

                        continue;
                    }

                    if (v > 0)
                    {
                        a = Math.Min(a + v, animategoal[i]);
                    }
                    else
                    {
                        a = Math.Max(a + v, animategoal[i]);
                    }

                    if (animateptr[i] == &sector[animatesect[i]].floorz)
                    {
                        for (p = connecthead; p >= 0; p = connectpoint2[p])
                        {
                            if (ps[p].cursectnum == dasect)
                            {
                                if ((sector[dasect].floorz - ps[p].posz) < (64 << 8))
                                {
                                    if (sprite[ps[p].i].owner >= 0)
                                    {
                                        ps[p].posz += v;
                                        ps[p].poszv = 0;
                                        if (p == myconnectindex)
                                        {
                                            myz += v;
                                            myzvel = 0;
                                            myzbak[((movefifoplc - 1) & (DefineConstants.MOVEFIFOSIZ - 1))] = ps[p].posz;
                                        }
                                    }
                                }
                            }
                        }

                        for (j = headspritesect[dasect]; j >= 0; j = nextspritesect[j])
                        {
                            if (sprite[j].statnum != 3)
                            {
                                hittype[j].bposz = sprite[j].z;
                                sprite[j].z += v;
                                hittype[j].floorz = sector[dasect].floorz + v;
                            }
                        }
                    }

                    *animateptr[i] = a;
                }
        */
        // jmarshall end
    }

    public static int getanimationgoal(ref int animptr)
    {
        // jmarshall - sector animations
        /*
                int i;
                int j;

                j = -1;
                for (i = animatecnt - 1; i >= 0; i--)
                {
                    if (animptr == (int)animateptr[i])
                    {
                        j = i;
                        break;
                    }
                }
                return (j);
        */
        return 0;
        // jamrshall end
    }

    public static int setanimation(short animsect, ref int animptr, int thegoal, int thevel)
    {
        // jmarshall - sector animations
        /*
                int i;
                int j;

                if (animatecnt >= DefineConstants.MAXANIMATES - 1)
                {
                    return (-1);
                }

                j = animatecnt;
                for (i = 0; i < animatecnt; i++)
                {
                    if (animptr == animateptr[i])
                    {
                        j = i;
                        break;
                    }
                }

                animatesect[j] = animsect;
                animateptr[j] = animptr;
                animategoal[j] = thegoal;
                if (thegoal >= animptr)
                {
                    animatevel[j] = thevel;
                }
                else
                {
                    animatevel[j] = -thevel;
                }

                if (j == animatecnt)
                {
                    animatecnt++;
                }

                setinterpolation(ref animptr);

                return (j);
        */
        return 0;
        // jmarshall end
    }

    public static void animatecamsprite()
    {
        short i;

        if (camsprite <= 0)
        {
            return;
        }

        i = camsprite;

        if (hittype[i].count >= 11)
        {
            hittype[i].count = 0;

            if (ps[screenpeek].newowner >= 0)
            {
                Engine.board.sprite[i].owner = ps[screenpeek].newowner;
            }

            else if (Engine.board.sprite[i].owner >= 0 && dist(Engine.board.sprite[ps[screenpeek].i], Engine.board.sprite[i]) < 2048)
            {
                xyzmirror(Engine.board.sprite[i].owner, Engine.board.sprite[i].picnum);
            }
        }
        else
        {
            hittype[i].count++;
        }
    }

    public static void animatewalls()
    {
        int i;
        int j;
        int p;
        int t;

        for (p = 0; p < numanimwalls; p++)
        {
            //    for(p=numanimwalls-1;p>=0;p--)
            i = animwall[p].wallnum;
            j = Engine.board.wall[i].picnum;

            switch (j)
            {
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

                    if ((Engine.krand() & 255) < 16)
                    {
                        animwall[p].tag = Engine.board.wall[i].picnum;
                        Engine.board.wall[i].picnum = DefineConstants.SCREENBREAK6;
                    }

                    continue;

                case DefineConstants.SCREENBREAK6:
                case DefineConstants.SCREENBREAK7:
                case DefineConstants.SCREENBREAK8:

                    if (animwall[p].tag >= 0 && Engine.board.wall[i].extra != DefineConstants.FEMPIC2 && Engine.board.wall[i].extra != DefineConstants.FEMPIC3)
                    {
                        Engine.board.wall[i].picnum = (short)animwall[p].tag;
                    }
                    else
                    {
                        Engine.board.wall[i].picnum++;
                        if (Engine.board.wall[i].picnum == (DefineConstants.SCREENBREAK6 + 3))
                        {
                            Engine.board.wall[i].picnum = DefineConstants.SCREENBREAK6;
                        }
                    }
                    continue;

            }

            if ((Engine.board.wall[i].cstat & 16) != 0)
            {
                switch (Engine.board.wall[i].overpicnum)
                {
                    case DefineConstants.W_FORCEFIELD:
                    case DefineConstants.W_FORCEFIELD + 1:
                    case DefineConstants.W_FORCEFIELD + 2:

                        t = animwall[p].tag;

                        if ((Engine.board.wall[i].cstat & 254) != 0)
                        {
                            Engine.board.wall[i].xpanning -= (byte)(t >> 10); // sintable[(t+512)&2047]>>12;
                            Engine.board.wall[i].ypanning -= (byte)(t >> 10); // sintable[t&2047]>>12;

                            if (Engine.board.wall[i].extra == 1)
                            {
                                Engine.board.wall[i].extra = 0;
                                animwall[p].tag = 0;
                            }
                            else
                            {
                                animwall[p].tag += 128;
                            }

                            if (animwall[p].tag < (128 << 4))
                            {
                                if ((animwall[p].tag & 128) != 0)
                                {
                                    Engine.board.wall[i].overpicnum = DefineConstants.W_FORCEFIELD;
                                }
                                else
                                {
                                    Engine.board.wall[i].overpicnum = DefineConstants.W_FORCEFIELD + 1;
                                }
                            }
                            else
                            {
                                if ((Engine.krand() & 255) < 32)
                                {
                                    animwall[p].tag = 128 << (int)(Engine.krand() & 3);
                                }
                                else
                                {
                                    Engine.board.wall[i].overpicnum = DefineConstants.W_FORCEFIELD + 1;
                                }
                            }
                        }

                        break;
                }
            }
        }
    }

    public static bool activatewarpelevators(int s, int d) //Parm = sectoreffectornum
    {
        int i;
        int sn;

        sn = Engine.board.sprite[s].sectnum;

        // See if the sector exists

        i = Engine.board.headspritestat[3];
        while (i >= 0)
        {
            if (Engine.board.sprite[i].lotag == 17)
            {
                if (Engine.board.sprite[i].hitag == Engine.board.sprite[s].hitag)
                {
                    if ((pragmas.klabs(Engine.board.sector[sn].floorz - hittype[s].actioncount) > Engine.board.sprite[i].yvel) || (Engine.board.sector[Engine.board.sprite[i].sectnum].hitag == (Engine.board.sector[sn].hitag - d)))
                    {
                        break;
                    }
                }
            }
            i = Engine.board.nextspritestat[i];
        }

        if (i == -1)
        {
            d = 0;
            return true; // No find
        }
        else
        {
            if (d == 0)
            {
                spritesound(DefineConstants.ELEVATOR_OFF, s);
            }
            else
            {
                spritesound(DefineConstants.ELEVATOR_ON, s);
            }
        }


        i = Engine.board.headspritestat[3];
        while (i >= 0)
        {
            if (Engine.board.sprite[i].lotag == 17)
            {
                if (Engine.board.sprite[i].hitag == Engine.board.sprite[s].hitag)
                {
                    hittype[i].count = d;
                    hittype[i].temp_data[1] = d; //Make all check warp
                }
            }
            i = Engine.board.nextspritestat[i];
        }
        return false;
    }

    public static void operatesectors(short sn, short ii)
    {
        int j;
        int l;
        int q;
        int startwall;
        int endwall;
        int i;
        int sect_error;
        sectortype sptr;

        sect_error = 0;
        sptr = Engine.board.sector[sn];

        switch (sptr.lotag & (0xffff - 49152))
        {

            case 30:
                j = Engine.board.sector[sn].hitag;
                if (hittype[j].tempang == 0 || hittype[j].tempang == 256)
                {
                    callsound(sn, ii);
                }
                if (Engine.board.sprite[j].extra == 1)
                {
                    Engine.board.sprite[j].extra = 3;
                }
                else
                {
                    Engine.board.sprite[j].extra = 1;
                }
                break;

            case 31:

                j = Engine.board.sector[sn].hitag;
                if (hittype[j].temp_data[4] == 0)
                {
                    hittype[j].temp_data[4] = 1;
                }

                callsound(sn, ii);
                break;

            case 26: //The split doors
                i = getanimationgoal(ref sptr.ceilingz);
                if (i == -1) //if the door has stopped
                {
                    haltsoundhack = 1;
                    sptr.lotag &= unchecked((short)0xff00); // jmarshall: setting these to unchecked, should match original behaivor.
                    sptr.lotag |= 22;
                    operatesectors(sn, ii);
                    sptr.lotag &= unchecked((short)0xff00); // jmarshall: setting these to unchecked, should match original behaivor.
                    sptr.lotag |= 9;
                    operatesectors(sn, ii);
                    sptr.lotag &= unchecked((short)0xff00); // jmarshall: setting these to unchecked, should match original behaivor.
                    sptr.lotag |= 26;
                }
                return;

            case 9:
                {
                    int dax;
                    int day;
                    int dax2;
                    int day2;
                    int sp;
                    int[] wallfind = new int[2];

                    startwall = sptr.wallptr;
                    endwall = startwall + sptr.wallnum - 1;

                    sp = sptr.extra >> 4;

                    //first find center point by averaging all points
                    dax = 0;
                    day = 0;
                    for (i = (short)startwall; i <= endwall; i++)
                    {
                        dax += Engine.board.wall[i].x;
                        day += Engine.board.wall[i].y;
                    }
                    dax /= (endwall - startwall + 1);
                    day /= (endwall - startwall + 1);

                    //find any points with either same x or same y coordinate
                    //  as center (dax, day) - should be 2 points found.
                    wallfind[0] = -1;
                    wallfind[1] = -1;
                    for (i = (short)startwall; i <= endwall; i++)
                    {
                        if ((Engine.board.wall[i].x == dax) || (Engine.board.wall[i].y == day))
                        {
                            if (wallfind[0] == -1)
                            {
                                wallfind[0] = i;
                            }
                            else
                            {
                                wallfind[1] = i;
                            }
                        }
                    }

                    for (j = 0; j < 2; j++)
                    {
                        if ((Engine.board.wall[wallfind[j]].x == dax) && (Engine.board.wall[wallfind[j]].y == day))
                        {
                            //find what direction door should open by averaging the
                            //  2 neighboring points of wallfind[0] & wallfind[1].
                            i = (short)(wallfind[j] - 1);
                            if (i < startwall)
                            {
                                i = (short)endwall;
                            }
                            dax2 = ((Engine.board.wall[i].x + Engine.board.wall[Engine.board.wall[wallfind[j]].point2].x) >> 1) - Engine.board.wall[wallfind[j]].x;
                            day2 = ((Engine.board.wall[i].y + Engine.board.wall[Engine.board.wall[wallfind[j]].point2].y) >> 1) - Engine.board.wall[wallfind[j]].y;
                            if (dax2 != 0)
                            {
                                dax2 = Engine.board.wall[Engine.board.wall[Engine.board.wall[wallfind[j]].point2].point2].x;
                                dax2 -= Engine.board.wall[Engine.board.wall[wallfind[j]].point2].x;
                                setanimation(sn, ref Engine.board.wall[wallfind[j]].x, Engine.board.wall[wallfind[j]].x + dax2, sp);
                                setanimation(sn, ref Engine.board.wall[i].x, Engine.board.wall[i].x + dax2, sp);
                                setanimation(sn, ref Engine.board.wall[Engine.board.wall[wallfind[j]].point2].x, Engine.board.wall[Engine.board.wall[wallfind[j]].point2].x + dax2, sp);
                                callsound(sn, ii);
                            }
                            else if (day2 != 0)
                            {
                                day2 = Engine.board.wall[Engine.board.wall[Engine.board.wall[wallfind[j]].point2].point2].y;
                                day2 -= Engine.board.wall[Engine.board.wall[wallfind[j]].point2].y;
                                setanimation(sn, ref Engine.board.wall[wallfind[j]].y, Engine.board.wall[wallfind[j]].y + day2, sp);
                                setanimation(sn, ref Engine.board.wall[i].y, Engine.board.wall[i].y + day2, sp);
                                setanimation(sn, ref Engine.board.wall[Engine.board.wall[wallfind[j]].point2].y, Engine.board.wall[Engine.board.wall[wallfind[j]].point2].y + day2, sp);
                                callsound(sn, ii);
                            }
                        }
                        else
                        {
                            i = (short)(wallfind[j] - 1);
                            if (i < startwall)
                            {
                                i = (short)endwall;
                            }
                            dax2 = ((Engine.board.wall[i].x + Engine.board.wall[Engine.board.wall[wallfind[j]].point2].x) >> 1) - Engine.board.wall[wallfind[j]].x;
                            day2 = ((Engine.board.wall[i].y + Engine.board.wall[Engine.board.wall[wallfind[j]].point2].y) >> 1) - Engine.board.wall[wallfind[j]].y;
                            if (dax2 != 0)
                            {
                                setanimation(sn, ref Engine.board.wall[wallfind[j]].x, dax, sp);
                                setanimation(sn, ref Engine.board.wall[i].x, dax + dax2, sp);
                                setanimation(sn, ref Engine.board.wall[Engine.board.wall[wallfind[j]].point2].x, dax + dax2, sp);
                                callsound(sn, ii);
                            }
                            else if (day2 != 0)
                            {
                                setanimation(sn, ref Engine.board.wall[wallfind[j]].y, day, sp);
                                setanimation(sn, ref Engine.board.wall[i].y, day + day2, sp);
                                setanimation(sn, ref Engine.board.wall[Engine.board.wall[wallfind[j]].point2].y, day + day2, sp);
                                callsound(sn, ii);
                            }
                        }
                    }

                }
                return;

            case 15: //Warping elevators

                if (Engine.board.sprite[ii].picnum != DefineConstants.APLAYER)
                {
                    return;
                }
                //            if(ps[sprite[ii].yvel].select_dir == 1) return;

                i = Engine.board.headspritesect[sn];
                while (i >= 0)
                {
                    if (Engine.board.sprite[i].picnum == DefineConstants.SECTOREFFECTOR && Engine.board.sprite[i].lotag == 17)
                    {
                        break;
                    }
                    i = Engine.board.nextspritesect[i];
                }

                if (Engine.board.sprite[ii].sectnum == sn)
                {
                    if (activatewarpelevators(i, -1))
                    {
                        activatewarpelevators(i, 1);
                    }
                    else if (activatewarpelevators(i, 1))
                    {
                        activatewarpelevators(i, -1);
                    }
                    return;
                }
                else
                {
                    if (sptr.floorz > Engine.board.sprite[i].z)
                    {
                        activatewarpelevators(i, -1);
                    }
                    else
                    {
                        activatewarpelevators(i, 1);
                    }
                }

                return;

            case 16:
            case 17:

                i = getanimationgoal(ref sptr.floorz);

                if (i == -1)
                {
                    i = Engine.board.nextsectorneighborz(sn, sptr.floorz, 1, 1);
                    if (i == -1)
                    {
                        i = Engine.board.nextsectorneighborz(sn, sptr.floorz, 1, -1);
                        if (i == -1)
                        {
                            return;
                        }
                        j = Engine.board.sector[i].floorz;
                        setanimation(sn, ref sptr.floorz, j, sptr.extra);
                    }
                    else
                    {
                        j = Engine.board.sector[i].floorz;
                        setanimation(sn, ref sptr.floorz, j, sptr.extra);
                    }
                    callsound(sn, ii);
                }

                return;

            case 18:
            case 19:

                i = getanimationgoal(ref sptr.floorz);

                if (i == -1)
                {
                    i = Engine.board.nextsectorneighborz(sn, sptr.floorz, 1, -1);
                    if (i == -1)
                    {
                        i = Engine.board.nextsectorneighborz(sn, sptr.floorz, 1, 1);
                    }
                    if (i == -1)
                    {
                        return;
                    }
                    j = Engine.board.sector[i].floorz;
                    q = sptr.extra;
                    l = sptr.ceilingz - sptr.floorz;
                    setanimation(sn, ref sptr.floorz, j, q);
                    setanimation(sn, ref sptr.ceilingz, j + l, q);
                    callsound(sn, ii);
                }
                return;

            case 29:

                if ((sptr.lotag & 0x8000) != 0)
                {
                    j = Engine.board.sector[Engine.board.nextsectorneighborz(sn, sptr.ceilingz, 1, 1)].floorz;
                }
                else
                {
                    j = Engine.board.sector[Engine.board.nextsectorneighborz(sn, sptr.ceilingz, -1, -1)].ceilingz;
                }

                i = Engine.board.headspritestat[3]; //Effectors
                while (i >= 0)
                {
                    if ((Engine.board.sprite[i].lotag == 22) && (Engine.board.sprite[i].hitag == sptr.hitag))
                    {
                        Engine.board.sector[Engine.board.sprite[i].sectnum].extra = (short)(-Engine.board.sector[Engine.board.sprite[i].sectnum].extra);

                        hittype[i].count = sn;
                        hittype[i].temp_data[1] = 1;
                    }
                    i = Engine.board.nextspritestat[i];
                }

                sptr.lotag ^= unchecked((short)0x8000); // jmarshall added unchecked here;

                setanimation(sn, ref sptr.ceilingz, j, sptr.extra);

                callsound(sn, ii);

                return;

            case 20:

                REDODOOR:
                j = 0; // unassigned local variable
                if ((sptr.lotag & 0x8000) != 0)
                {
                    i = Engine.board.headspritesect[sn];
                    while (i >= 0)
                    {
                        if (Engine.board.sprite[i].statnum == 3 && Engine.board.sprite[i].lotag == 9)
                        {
                            j = Engine.board.sprite[i].z;
                            break;
                        }
                        i = Engine.board.nextspritesect[i];
                    }
                    if (i == -1)
                    {
                        j = sptr.floorz;
                    }
                }
                else
                {
                    j = Engine.board.nextsectorneighborz(sn, sptr.ceilingz, -1, -1);

                    if (j >= 0)
                    {
                        j = Engine.board.sector[j].ceilingz;
                    }
                    else
                    {
                        sptr.lotag |= unchecked((short)32768);
                        goto REDODOOR;
                    }
                }

                sptr.lotag ^= unchecked((short)(0x8000));

                setanimation(sn, ref sptr.ceilingz, j, sptr.extra);
                callsound(sn, ii);

                return;

            case 21:
                i = getanimationgoal(ref sptr.floorz);
                if (i >= 0)
                {
                    if (animategoal[sn] == sptr.ceilingz)
                    {
                        animategoal[i] = Engine.board.sector[Engine.board.nextsectorneighborz(sn, sptr.ceilingz, 1, 1)].floorz;
                    }
                    else
                    {
                        animategoal[i] = sptr.ceilingz;
                    }
                    j = animategoal[i];
                }
                else
                {
                    if (sptr.ceilingz == sptr.floorz)
                    {
                        j = Engine.board.sector[Engine.board.nextsectorneighborz(sn, sptr.ceilingz, 1, 1)].floorz;
                    }
                    else
                    {
                        j = sptr.ceilingz;
                    }

                    sptr.lotag ^= unchecked((short)0x8000);

                    if (setanimation(sn, ref sptr.floorz, j, sptr.extra) >= 0)
                    {
                        callsound(sn, ii);
                    }
                }
                return;

            case 22:

                // REDODOOR22:

                if ((sptr.lotag & 0x8000) != 0)
                {
                    q = (sptr.ceilingz + sptr.floorz) >> 1;
                    j = setanimation(sn, ref sptr.floorz, q, sptr.extra);
                    j = setanimation(sn, ref sptr.ceilingz, q, sptr.extra);
                }
                else
                {
                    q = Engine.board.sector[Engine.board.nextsectorneighborz(sn, sptr.floorz, 1, 1)].floorz;
                    j = setanimation(sn, ref sptr.floorz, q, sptr.extra);
                    q = Engine.board.sector[Engine.board.nextsectorneighborz(sn, sptr.ceilingz, -1, -1)].ceilingz;
                    j = setanimation(sn, ref sptr.ceilingz, q, sptr.extra);
                }

                sptr.lotag ^= unchecked((short)0x8000);

                callsound(sn, ii);

                return;

            case 23: //Swingdoor

                j = -1;
                q = 0;

                i = Engine.board.headspritestat[3];
                while (i >= 0)
                {
                    if (Engine.board.sprite[i].lotag == 11 && Engine.board.sprite[i].sectnum == sn && hittype[i].temp_data[4] == 0)
                    {
                        j = i;
                        break;
                    }
                    i = Engine.board.nextspritestat[i];
                }

                l = Engine.board.sector[Engine.board.sprite[i].sectnum].lotag & 0x8000;

                if (j >= 0)
                {
                    i = Engine.board.headspritestat[3];
                    while (i >= 0)
                    {
                        if (l == (Engine.board.sector[Engine.board.sprite[i].sectnum].lotag & 0x8000) && Engine.board.sprite[i].lotag == 11 && Engine.board.sprite[j].hitag == Engine.board.sprite[i].hitag && hittype[i].temp_data[4] == 0)
                        {
                            if ((Engine.board.sector[Engine.board.sprite[i].sectnum].lotag & 0x8000) != 0)
                            {
                                Engine.board.sector[Engine.board.sprite[i].sectnum].lotag &= 0x7fff;
                            }
                            else
                            {
                                Engine.board.sector[Engine.board.sprite[i].sectnum].lotag |= unchecked((short)0x8000);
                            }
                            hittype[i].temp_data[4] = 1;
                            hittype[i].temp_data[3] = -hittype[i].temp_data[3];
                            if (q == 0)
                            {
                                callsound(sn, (short)i);
                                q = 1;
                            }
                        }
                        i = Engine.board.nextspritestat[i];
                    }
                }
                return;

            case 25: //Subway type sliding doors

                j = Engine.board.headspritestat[3];
                while (j >= 0) //Find the sprite
                {
                    if ((Engine.board.sprite[j].lotag) == 15 && Engine.board.sprite[j].sectnum == sn)
                    {
                        break; //Found the sectoreffector.
                    }
                    j = Engine.board.nextspritestat[j];
                }

                if (j < 0)
                {
                    return;
                }

                i = Engine.board.headspritestat[3];
                while (i >= 0)
                {
                    if (Engine.board.sprite[i].hitag == Engine.board.sprite[j].hitag)
                    {
                        if (Engine.board.sprite[i].lotag == 15)
                        {
                            Engine.board.sector[Engine.board.sprite[i].sectnum].lotag ^= unchecked((short)0x8000); // Toggle the open or close
                            Engine.board.sprite[i].ang += 1024;
                            if (hittype[i].temp_data[4] != 0)
                            {
                                callsound(Engine.board.sprite[i].sectnum, (short)i);
                            }
                            callsound(Engine.board.sprite[i].sectnum, (short)i);
                            if ((Engine.board.sector[Engine.board.sprite[i].sectnum].lotag & 0x8000) != 0)
                            {
                                hittype[i].temp_data[4] = 1;
                            }
                            else
                            {
                                hittype[i].temp_data[4] = 2;
                            }
                        }
                    }
                    i = Engine.board.nextspritestat[i];
                }
                return;

            case 27: //Extended bridge

                j = Engine.board.headspritestat[3];
                while (j >= 0)
                {
                    if ((Engine.board.sprite[j].lotag & 0xff) == 20 && Engine.board.sprite[j].sectnum == sn) //Bridge
                    {

                        Engine.board.sector[sn].lotag ^= unchecked((short)0x8000);
                        if ((Engine.board.sector[sn].lotag & 0x8000) != 0) //OPENING
                        {
                            hittype[j].count = 1;
                        }
                        else
                        {
                            hittype[j].count = 2;
                        }
                        callsound(sn, ii);
                        break;
                    }
                    j = Engine.board.nextspritestat[j];
                }
                return;


            case 28:
                //activate the rest of them

                j = Engine.board.headspritesect[sn];
                while (j >= 0)
                {
                    if (Engine.board.sprite[j].statnum == 3 && (Engine.board.sprite[j].lotag & 0xff) == 21)
                    {
                        break; //Found it
                    }
                    j = Engine.board.nextspritesect[j];
                }

                j = Engine.board.sprite[j].hitag;

                l = Engine.board.headspritestat[3];
                while (l >= 0)
                {
                    if ((Engine.board.sprite[l].lotag & 0xff) == 21 && hittype[l].count == 0 && (Engine.board.sprite[l].hitag) == j)
                    {
                        hittype[l].count = 1;
                    }
                    l = Engine.board.nextspritestat[l];
                }
                callsound(sn, ii);

                return;
        }
    }

    public static void operaterespawns(short low)
    {
        int i;
        int j;
        int nexti;

        i = Engine.board.headspritestat[11];
        while (i >= 0)
        {
            nexti = Engine.board.nextspritestat[i];
            if (Engine.board.sprite[i].lotag == low)
            {
                switch (Engine.board.sprite[i].picnum)
                {
                    case DefineConstants.RESPAWN:
                        if (badguypic(Engine.board.sprite[i].hitag) != 0 && ud.monsters_off > 0)
                        {
                            break;
                        }

                        j = spawn((short)i, DefineConstants.TRANSPORTERSTAR);
                        Engine.board.sprite[j].z -= (32 << 8);

                        Engine.board.sprite[i].extra = 66 - 12; // Just a way to killit
                        break;
                }
            }
            i = nexti;
        }
    }

    public static void operateactivators(short low, short snum)
    {
        int i;
        int k;
        int nexti;        
        walltype wal = null;
        short[] p = new short[6];

        for (i = numcyclers - 1; i >= 0; i--)
        {
            for (int d = 0; d < 6; d++)
            {
                p[d] = cyclers[i, d];
            }

            if (p[4] == low)
            {
                if (p[5] != 0)
                {
                    p[5] = 0;
                }
                else
                {
                    p[5] = 1;
                }

                Engine.board.sector[p[0]].floorshade = Engine.board.sector[p[0]].ceilingshade = (sbyte)p[3];
                for (int r = 0, j = Engine.board.sector[p[0]].wallnum; j > 0; j--, r++)
                {
                    wal = Engine.board.wall[Engine.board.sector[p[0]].wallptr + r];
                    wal.shade = (sbyte)p[3];
                }
            }
        }

        i = Engine.board.headspritestat[8];
        k = -1;
        while (i >= 0)
        {
            if (Engine.board.sprite[i].lotag == low)
            {
                if (Engine.board.sprite[i].picnum == DefineConstants.ACTIVATORLOCKED)
                {
                    if ((Engine.board.sector[Engine.board.sprite[i].sectnum].lotag & 16384) != 0)
                    {
                        Engine.board.sector[Engine.board.sprite[i].sectnum].lotag &= unchecked((short)(65535 - 16384));
                    }
                    else
                    {
                        Engine.board.sector[Engine.board.sprite[i].sectnum].lotag |= 16384;
                    }

                    if (snum >= 0)
                    {
                        if ((Engine.board.sector[Engine.board.sprite[i].sectnum].lotag & 16384) != 0)
                        {
                            FTA(4, ps[snum]);
                        }
                        else
                        {
                            FTA(8, ps[snum]);
                        }
                    }
                }
                else
                {
                    switch (Engine.board.sprite[i].hitag)
                    {
                        case 0:
                            break;
                        case 1:
                            if (Engine.board.sector[Engine.board.sprite[i].sectnum].floorz != Engine.board.sector[Engine.board.sprite[i].sectnum].ceilingz)
                            {
                                i = Engine.board.nextspritestat[i];
                                continue;
                            }
                            break;
                        case 2:
                            if (Engine.board.sector[Engine.board.sprite[i].sectnum].floorz == Engine.board.sector[Engine.board.sprite[i].sectnum].ceilingz)
                            {
                                i = Engine.board.nextspritestat[i];
                                continue;
                            }
                            break;
                    }

                    if (Engine.board.sector[Engine.board.sprite[i].sectnum].lotag < 3)
                    {
                        int j = Engine.board.headspritesect[Engine.board.sprite[i].sectnum];
                        while (j >= 0)
                        {
                            if (Engine.board.sprite[j].statnum == 3)
                            {
                                switch (Engine.board.sprite[j].lotag)
                                {
                                    case 36:
                                    case 31:
                                    case 32:
                                    case 18:
                                        hittype[j].count = 1 - hittype[j].count;
                                        callsound(Engine.board.sprite[i].sectnum, (short)j);
                                        break;
                                }
                            }
                            j = Engine.board.nextspritesect[j];
                        }
                    }

                    if (k == -1 && (Engine.board.sector[Engine.board.sprite[i].sectnum].lotag & 0xff) == 22)
                    {
                        k = callsound(Engine.board.sprite[i].sectnum, (short)i);
                    }

                    operatesectors(Engine.board.sprite[i].sectnum, (short)i);
                }
            }
            i = Engine.board.nextspritestat[i];
        }

        operaterespawns(low);
    }

    public static void operatemasterswitches(short low)
    {
        int i;

        i = Engine.board.headspritestat[6];
        while (i >= 0)
        {
            if (Engine.board.sprite[i].picnum == DefineConstants.MASTERSWITCH && Engine.board.sprite[i].lotag == low && Engine.board.sprite[i].yvel == 0)
            {
                Engine.board.sprite[i].yvel = 1;
            }
            i = Engine.board.nextspritestat[i];
        }
    }

    public static void operateforcefields(short s, short low)
    {
        int i;
        int p;

        for (p = numanimwalls; p >= 0; p--)
        {
            i = animwall[p].wallnum;

            if (low == Engine.board.wall[i].lotag || low == -1)
            {
                switch (Engine.board.wall[i].overpicnum)
                {
                    case DefineConstants.W_FORCEFIELD:
                    case DefineConstants.W_FORCEFIELD + 1:
                    case DefineConstants.W_FORCEFIELD + 2:
                    case DefineConstants.BIGFORCE:

                        animwall[p].tag = 0;

                        if (Engine.board.wall[i].cstat != 0)
                        {
                            Engine.board.wall[i].cstat = 0;

                            if (s >= 0 && Engine.board.sprite[s].picnum == DefineConstants.SECTOREFFECTOR && Engine.board.sprite[s].lotag == 30)
                            {
                                Engine.board.wall[i].lotag = 0;
                            }
                        }
                        else
                        {
                            Engine.board.wall[i].cstat = 85;
                        }
                        break;
                }
            }
        }
    }

    public static bool checkhitswitch(short snum, int w, char switchtype)
    {
        byte switchpal;
        int i;
        int x;
        short lotag;
        short hitag;
        short picnum;
        short correctdips;
        short numdips;
        int sx;
        int sy;

        if (w < 0)
        {
            return false;
        }
        correctdips = 1;
        numdips = 0;

        if (switchtype == 1) // A wall sprite
        {
            lotag = Engine.board.sprite[w].lotag;
            if (lotag == 0)
            {
                return false;
            }
            hitag = Engine.board.sprite[w].hitag;
            sx = Engine.board.sprite[w].x;
            sy = Engine.board.sprite[w].y;
            picnum = Engine.board.sprite[w].picnum;
            switchpal = Engine.board.sprite[w].pal;
        }
        else
        {
            lotag = Engine.board.wall[w].lotag;
            if (lotag == 0)
            {
                return false;
            }
            hitag = Engine.board.wall[w].hitag;
            sx = Engine.board.wall[w].x;
            sy = Engine.board.wall[w].y;
            picnum = Engine.board.wall[w].picnum;
            switchpal = Engine.board.wall[w].pal;
        }

        switch (picnum)
        {
            case DefineConstants.DIPSWITCH:
            case DefineConstants.DIPSWITCH + 1:
            case DefineConstants.TECHSWITCH:
            case DefineConstants.TECHSWITCH + 1:
            case DefineConstants.ALIENSWITCH:
            case DefineConstants.ALIENSWITCH + 1:
                break;
            case DefineConstants.ACCESSSWITCH:
                goto case DefineConstants.ACCESSSWITCH2;
            case DefineConstants.ACCESSSWITCH2:
                if (ps[snum].access_incs == 0)
                {
                    if (switchpal == 0)
                    {
                        if ((ps[snum].got_access & 1) != 0)
                        {
                            ps[snum].access_incs = 1;
                        }
                        else
                        {
                            FTA(70, ps[snum]);
                        }
                    }

                    else if (switchpal == 21)
                    {
                        if ((ps[snum].got_access & 2) != 0)
                        {
                            ps[snum].access_incs = 1;
                        }
                        else
                        {
                            FTA(71, ps[snum]);
                        }
                    }

                    else if (switchpal == 23)
                    {
                        if ((ps[snum].got_access & 4) != 0)
                        {
                            ps[snum].access_incs = 1;
                        }
                        else
                        {
                            FTA(72, ps[snum]);
                        }
                    }

                    if (ps[snum].access_incs == 1)
                    {
                        if (switchtype == 0)
                        {
                            ps[snum].access_wallnum = (short)w;
                        }
                        else
                        {
                            ps[snum].access_spritenum = (short)w;
                        }
                    }

                    return false;
                }
                goto case DefineConstants.POWERSWITCH2 + 1;
            case DefineConstants.DIPSWITCH2:
            case DefineConstants.DIPSWITCH2 + 1:
            case DefineConstants.DIPSWITCH3:
            case DefineConstants.DIPSWITCH3 + 1:
            case DefineConstants.MULTISWITCH:
            case DefineConstants.MULTISWITCH + 1:
            case DefineConstants.MULTISWITCH + 2:
            case DefineConstants.MULTISWITCH + 3:
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
                if (check_activator_motion(lotag) != 0)
                {
                    return false;
                }
                break;
            default:
                if (isadoorwall(picnum) == false)
                {
                    return false;
                }
                break;
        }

        i = Engine.board.headspritestat[0];
        while (i >= 0)
        {
            if (lotag == Engine.board.sprite[i].lotag)
            {
                switch (Engine.board.sprite[i].picnum)
                {
                    case DefineConstants.DIPSWITCH:
                    case DefineConstants.TECHSWITCH:
                    case DefineConstants.ALIENSWITCH:
                        if (switchtype == 1 && w == i)
                        {
                            Engine.board.sprite[i].picnum++;
                        }
                        else if (Engine.board.sprite[i].hitag == 0)
                        {
                            correctdips++;
                        }
                        numdips++;
                        break;
                    case DefineConstants.TECHSWITCH + 1:
                    case DefineConstants.DIPSWITCH + 1:
                    case DefineConstants.ALIENSWITCH + 1:
                        if (switchtype == 1 && w == i)
                        {
                            Engine.board.sprite[i].picnum--;
                        }
                        else if (Engine.board.sprite[i].hitag == 1)
                        {
                            correctdips++;
                        }
                        numdips++;
                        break;
                    case DefineConstants.MULTISWITCH:
                    case DefineConstants.MULTISWITCH + 1:
                    case DefineConstants.MULTISWITCH + 2:
                    case DefineConstants.MULTISWITCH + 3:
                        Engine.board.sprite[i].picnum++;
                        if (Engine.board.sprite[i].picnum > (DefineConstants.MULTISWITCH + 3))
                        {
                            Engine.board.sprite[i].picnum = DefineConstants.MULTISWITCH;
                        }
                        break;
                    case DefineConstants.ACCESSSWITCH:
                    case DefineConstants.ACCESSSWITCH2:
                    case DefineConstants.SLOTDOOR:
                    case DefineConstants.LIGHTSWITCH:
                    case DefineConstants.SPACELIGHTSWITCH:
                    case DefineConstants.SPACEDOORSWITCH:
                    case DefineConstants.FRANKENSTINESWITCH:
                    case DefineConstants.LIGHTSWITCH2:
                    case DefineConstants.POWERSWITCH1:
                    case DefineConstants.LOCKSWITCH1:
                    case DefineConstants.POWERSWITCH2:
                    case DefineConstants.HANDSWITCH:
                    case DefineConstants.PULLSWITCH:
                    case DefineConstants.DIPSWITCH2:
                    case DefineConstants.DIPSWITCH3:
                        Engine.board.sprite[i].picnum++;
                        break;
                    case DefineConstants.PULLSWITCH + 1:
                    case DefineConstants.HANDSWITCH + 1:
                    case DefineConstants.LIGHTSWITCH2 + 1:
                    case DefineConstants.POWERSWITCH1 + 1:
                    case DefineConstants.LOCKSWITCH1 + 1:
                    case DefineConstants.POWERSWITCH2 + 1:
                    case DefineConstants.SLOTDOOR + 1:
                    case DefineConstants.LIGHTSWITCH + 1:
                    case DefineConstants.SPACELIGHTSWITCH + 1:
                    case DefineConstants.SPACEDOORSWITCH + 1:
                    case DefineConstants.FRANKENSTINESWITCH + 1:
                    case DefineConstants.DIPSWITCH2 + 1:
                    case DefineConstants.DIPSWITCH3 + 1:
                        Engine.board.sprite[i].picnum--;
                        break;
                }
            }
            i = Engine.board.nextspritestat[i];
        }

        for (i = 0; i < Engine.board.numwalls; i++)
        {
            x = i;
            if (lotag == Engine.board.wall[x].lotag)
            {
                switch (Engine.board.wall[x].picnum)
                {
                    case DefineConstants.DIPSWITCH:
                    case DefineConstants.TECHSWITCH:
                    case DefineConstants.ALIENSWITCH:
                        if (switchtype == 0 && i == w)
                        {
                            Engine.board.wall[x].picnum++;
                        }
                        else if (Engine.board.wall[x].hitag == 0)
                        {
                            correctdips++;
                        }
                        numdips++;
                        break;
                    case DefineConstants.DIPSWITCH + 1:
                    case DefineConstants.TECHSWITCH + 1:
                    case DefineConstants.ALIENSWITCH + 1:
                        if (switchtype == 0 && i == w)
                        {
                            Engine.board.wall[x].picnum--;
                        }
                        else if (Engine.board.wall[x].hitag == 1)
                        {
                            correctdips++;
                        }
                        numdips++;
                        break;
                    case DefineConstants.MULTISWITCH:
                    case DefineConstants.MULTISWITCH + 1:
                    case DefineConstants.MULTISWITCH + 2:
                    case DefineConstants.MULTISWITCH + 3:
                        Engine.board.wall[x].picnum++;
                        if (Engine.board.wall[x].picnum > (DefineConstants.MULTISWITCH + 3))
                        {
                            Engine.board.wall[x].picnum = DefineConstants.MULTISWITCH;
                        }
                        break;
                    case DefineConstants.ACCESSSWITCH:
                    case DefineConstants.ACCESSSWITCH2:
                    case DefineConstants.SLOTDOOR:
                    case DefineConstants.LIGHTSWITCH:
                    case DefineConstants.SPACELIGHTSWITCH:
                    case DefineConstants.SPACEDOORSWITCH:
                    case DefineConstants.LIGHTSWITCH2:
                    case DefineConstants.POWERSWITCH1:
                    case DefineConstants.LOCKSWITCH1:
                    case DefineConstants.POWERSWITCH2:
                    case DefineConstants.PULLSWITCH:
                    case DefineConstants.HANDSWITCH:
                    case DefineConstants.DIPSWITCH2:
                    case DefineConstants.DIPSWITCH3:
                        Engine.board.wall[x].picnum++;
                        break;
                    case DefineConstants.HANDSWITCH + 1:
                    case DefineConstants.PULLSWITCH + 1:
                    case DefineConstants.LIGHTSWITCH2 + 1:
                    case DefineConstants.POWERSWITCH1 + 1:
                    case DefineConstants.LOCKSWITCH1 + 1:
                    case DefineConstants.POWERSWITCH2 + 1:
                    case DefineConstants.SLOTDOOR + 1:
                    case DefineConstants.LIGHTSWITCH + 1:
                    case DefineConstants.SPACELIGHTSWITCH + 1:
                    case DefineConstants.SPACEDOORSWITCH + 1:
                    case DefineConstants.DIPSWITCH2 + 1:
                    case DefineConstants.DIPSWITCH3 + 1:
                        Engine.board.wall[x].picnum--;
                        break;
                }
            }
        }

        if (lotag == (ushort)65535)
        {
            ps[myconnectindex].gm = (char)DefineConstants.MODE_EOL;
            if (ud.from_bonus != 0)
            {
                ud.level_number = ud.from_bonus;
                ud.m_level_number = ud.level_number;
                ud.from_bonus = 0;
            }
            else
            {
                ud.level_number++;
                if ((ud.volume_number != 0 && ud.level_number > 10) || (ud.volume_number == 0 && ud.level_number > 5))
                {
                    ud.level_number = 0;
                }
                ud.m_level_number = ud.level_number;
            }
            return true;
        }

        switch (picnum)
        {
            default:
                if (isadoorwall(picnum) == false)
                {
                    break;
                }
                goto case DefineConstants.ALIENSWITCH + 1;
            case DefineConstants.DIPSWITCH:
            case DefineConstants.DIPSWITCH + 1:
            case DefineConstants.TECHSWITCH:
            case DefineConstants.TECHSWITCH + 1:
            case DefineConstants.ALIENSWITCH:
            case DefineConstants.ALIENSWITCH + 1:
                if (picnum == DefineConstants.DIPSWITCH || picnum == DefineConstants.DIPSWITCH + 1 || picnum == DefineConstants.ALIENSWITCH || picnum == DefineConstants.ALIENSWITCH + 1 || picnum == DefineConstants.TECHSWITCH || picnum == DefineConstants.TECHSWITCH + 1)
                {
                    if (picnum == DefineConstants.ALIENSWITCH || picnum == DefineConstants.ALIENSWITCH + 1)
                    {
                        if (switchtype == 1)
                        {
                            xyzsound(DefineConstants.ALIEN_SWITCH1, (short)w, sx, sy, ps[snum].posz);
                        }
                        else
                        {
                            xyzsound(DefineConstants.ALIEN_SWITCH1, ps[snum].i, sx, sy, ps[snum].posz);
                        }
                    }
                    else
                    {
                        if (switchtype == 1)
                        {
                            xyzsound(DefineConstants.SWITCH_ON, (short)w, sx, sy, ps[snum].posz);
                        }
                        else
                        {
                            xyzsound(DefineConstants.SWITCH_ON, ps[snum].i, sx, sy, ps[snum].posz);
                        }
                    }
                    if (numdips != correctdips)
                    {
                        break;
                    }
                    xyzsound(DefineConstants.END_OF_LEVEL_WARN, ps[snum].i, sx, sy, ps[snum].posz);
                }
                goto case DefineConstants.DIPSWITCH2;
            //C++ TO C# CONVERTER TODO TASK: C# does not allow fall-through from a non-empty 'case':
            case DefineConstants.DIPSWITCH2:
            case DefineConstants.DIPSWITCH2 + 1:
            case DefineConstants.DIPSWITCH3:
            case DefineConstants.DIPSWITCH3 + 1:
            case DefineConstants.MULTISWITCH:
            case DefineConstants.MULTISWITCH + 1:
            case DefineConstants.MULTISWITCH + 2:
            case DefineConstants.MULTISWITCH + 3:
            case DefineConstants.ACCESSSWITCH:
            case DefineConstants.ACCESSSWITCH2:
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
            case DefineConstants.HANDSWITCH:
            case DefineConstants.HANDSWITCH + 1:
            case DefineConstants.PULLSWITCH:
            case DefineConstants.PULLSWITCH + 1:

                if (picnum == DefineConstants.MULTISWITCH || picnum == (DefineConstants.MULTISWITCH + 1) || picnum == (DefineConstants.MULTISWITCH + 2) || picnum == (DefineConstants.MULTISWITCH + 3))
                {
                    lotag += (short)(picnum - DefineConstants.MULTISWITCH);
                }

                x = Engine.board.headspritestat[3];
                while (x >= 0)
                {
                    if (((Engine.board.sprite[x].hitag) == lotag))
                    {
                        switch (Engine.board.sprite[x].lotag)
                        {
                            case 12:
                                Engine.board.sector[Engine.board.sprite[x].sectnum].floorpal = 0;
                                hittype[x].count++;
                                if (hittype[x].count == 2)
                                {
                                    hittype[x].count++;
                                }

                                break;
                            case 24:
                            case 34:
                            case 25:
                                if (hittype[x].temp_data[4] == 0)
                                {
                                    hittype[x].temp_data[4] = 1;
                                }
                                else
                                {
                                    hittype[x].temp_data[4] = 0;
                                }
                                if (hittype[x].temp_data[4] != 0)
                                {
                                    FTA(15, ps[snum]);
                                }
                                else
                                {
                                    FTA(2, ps[snum]);
                                }
                                break;
                            case 21:
                                FTA(2, ps[screenpeek]);
                                break;
                        }
                    }
                    x = Engine.board.nextspritestat[x];
                }

                operateactivators(lotag, snum);
                operateforcefields(ps[snum].i, lotag);
                operatemasterswitches(lotag);

                if (picnum == DefineConstants.DIPSWITCH || picnum == DefineConstants.DIPSWITCH + 1 || picnum == DefineConstants.ALIENSWITCH || picnum == DefineConstants.ALIENSWITCH + 1 || picnum == DefineConstants.TECHSWITCH || picnum == DefineConstants.TECHSWITCH + 1)
                {
                    return true;
                }

                if (hitag == 0 && isadoorwall(picnum) == false)
                {
                    if (switchtype == 1)
                    {
                        xyzsound(DefineConstants.SWITCH_ON, (short)w, sx, sy, ps[snum].posz);
                    }
                    else
                    {
                        xyzsound(DefineConstants.SWITCH_ON, ps[snum].i, sx, sy, ps[snum].posz);
                    }
                }
                else if (hitag != 0)
                {
                    if (switchtype == 1 && (soundm[hitag] & 4) == 0)
                    {
                        xyzsound(hitag, (short)w, sx, sy, ps[snum].posz);
                    }
                    else
                    {
                        spritesound((ushort)hitag, ps[snum].i);
                    }
                }

                return true;
        }
        return false;
    }

    public static void activatebysector(short sect, short j)
    {
        int i;
        int didit;

        didit = 0;

        i = Engine.board.headspritesect[sect];
        while (i >= 0)
        {
            if (Engine.board.sprite[i].picnum == DefineConstants.ACTIVATOR)
            {
                operateactivators(Engine.board.sprite[i].lotag, -1);
                didit = 1;
                //            return;
            }
            i = Engine.board.nextspritesect[i];
        }

        if (didit == 0)
        {
            operatesectors(sect, j);
        }
    }

    public static void breakwall(short newpn, short spr, short dawallnum)
    {
        Engine.board.wall[dawallnum].picnum = newpn;
        spritesound(DefineConstants.VENT_BUST, spr);
        spritesound(DefineConstants.GLASS_HEAVYBREAK, spr);
        lotsofglass(spr, dawallnum, 10);
    }

    public static void checkhitwall(short spr, short dawallnum, int x, int y, int z, short atwith)
    {
        short j;
        short i;
        short sn = -1;
        short darkestwall;
        sbyte nfloors;
        sbyte nceilings;
        short nextj;
        walltype wal;
        spritetype s;

        wal = Engine.board.wall[dawallnum];

        if (wal.overpicnum == DefineConstants.MIRROR)
        {
            switch (atwith)
            {
                case DefineConstants.HEAVYHBOMB:
                case DefineConstants.RADIUSEXPLOSION:
                case DefineConstants.RPG:
                case DefineConstants.HYDRENT:
                case DefineConstants.SEENINE:
                case DefineConstants.OOZFILTER:
                case DefineConstants.EXPLODINGBARREL:
                    lotsofglass(spr, dawallnum, 70);
                    wal.cstat &= ~16;
                    wal.overpicnum = DefineConstants.MIRRORBROKE;
                    spritesound(DefineConstants.GLASS_HEAVYBREAK, spr);
                    return;
            }
        }

        if (((wal.cstat & 16) != 0 || wal.overpicnum == DefineConstants.BIGFORCE) && wal.nextsector >= 0)
        {
            if (Engine.board.sector[wal.nextsector].floorz > z)
            {
                if ((Engine.board.sector[wal.nextsector].floorz - Engine.board.sector[wal.nextsector].ceilingz) != 0)
                {
                    switch (wal.overpicnum)
                    {
                        case DefineConstants.W_FORCEFIELD:
                        case DefineConstants.W_FORCEFIELD + 1:
                        case DefineConstants.W_FORCEFIELD + 2:
                            wal.extra = 1; // tell the forces to animate
                            goto case DefineConstants.BIGFORCE;
                        case DefineConstants.BIGFORCE:
                            Engine.board.updatesector(x, y, ref sn);
                            if (sn < 0)
                            {
                                return;
                            }

                            if (atwith == -1)
                            {
                                i = EGS(sn, x, y, z, DefineConstants.FORCERIPPLE, -127, 8, 8, 0, 0, 0, spr, 5);
                            }
                            else
                            {
                                if (atwith == DefineConstants.CHAINGUN)
                                {
                                    i = EGS(sn, x, y, z, DefineConstants.FORCERIPPLE, -127, (sbyte)(16 + Engine.board.sprite[spr].xrepeat), (sbyte)(16 + Engine.board.sprite[spr].yrepeat), 0, 0, 0, spr, 5);
                                }
                                else
                                {
                                    i = EGS(sn, x, y, z, DefineConstants.FORCERIPPLE, -127, 32, 32, 0, 0, 0, spr, 5);
                                }
                            }

                            Engine.board.sprite[i].cstat |= 18 + 128;
                            Engine.board.sprite[i].ang = (short)(Engine.getangle(wal.x - Engine.board.wall[wal.point2].x, wal.y - Engine.board.wall[wal.point2].y) - 512);

                            spritesound(DefineConstants.SOMETHINGHITFORCE, i);

                            return;

                        case DefineConstants.FANSPRITE:
                            wal.overpicnum = DefineConstants.FANSPRITEBROKE;
                            wal.cstat &= unchecked((short)(65535 - 65));
                            if (wal.nextwall >= 0)
                            {
                                Engine.board.wall[wal.nextwall].overpicnum = DefineConstants.FANSPRITEBROKE;
                                Engine.board.wall[wal.nextwall].cstat &= unchecked((short)(65535 - 65));
                            }
                            spritesound(DefineConstants.VENT_BUST, spr);
                            spritesound(DefineConstants.GLASS_BREAKING, spr);
                            return;

                        case DefineConstants.GLASS:
                            Engine.board.updatesector(x, y, ref sn);
                            if (sn < 0)
                            {
                                return;
                            }
                            wal.overpicnum = DefineConstants.GLASS2;
                            lotsofglass(spr, dawallnum, 10);
                            wal.cstat = 0;

                            if (wal.nextwall >= 0)
                            {
                                Engine.board.wall[wal.nextwall].cstat = 0;
                            }

                            i = EGS(sn, x, y, z, DefineConstants.SECTOREFFECTOR, 0, 0, 0, ps[0].ang, 0, 0, spr, 3);
                            Engine.board.sprite[i].lotag = 128;
                            hittype[i].temp_data[1] = 5;
                            hittype[i].actioncount = dawallnum;
                            spritesound(DefineConstants.GLASS_BREAKING, i);
                            return;
                        case DefineConstants.STAINGLASS1:
                            Engine.board.updatesector(x, y, ref sn);
                            if (sn < 0)
                            {
                                return;
                            }
                            lotsofcolourglass(spr, dawallnum, 80);
                            wal.cstat = 0;
                            if (wal.nextwall >= 0)
                            {
                                Engine.board.wall[wal.nextwall].cstat = 0;
                            }
                            spritesound(DefineConstants.VENT_BUST, spr);
                            spritesound(DefineConstants.GLASS_BREAKING, spr);
                            return;
                    }
                }
            }
        }

        switch (wal.picnum)
        {
            case DefineConstants.COLAMACHINE:
            case DefineConstants.VENDMACHINE:
                breakwall((short)(wal.picnum + 2), spr, dawallnum);
                spritesound(DefineConstants.VENT_BUST, spr);
                return;

            case DefineConstants.OJ:
            case DefineConstants.FEMPIC2:
            case DefineConstants.FEMPIC3:

            case DefineConstants.SCREENBREAK6:
            case DefineConstants.SCREENBREAK7:
            case DefineConstants.SCREENBREAK8:

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
            case DefineConstants.BORNTOBEWILDSCREEN:

                lotsofglass(spr, dawallnum, 30);
                wal.picnum = (short)(DefineConstants.W_SCREENBREAK + (Engine.krand() % 3));
                spritesound(DefineConstants.GLASS_HEAVYBREAK, spr);
                return;

            case DefineConstants.W_TECHWALL5:
            case DefineConstants.W_TECHWALL6:
            case DefineConstants.W_TECHWALL7:
            case DefineConstants.W_TECHWALL8:
            case DefineConstants.W_TECHWALL9:
                breakwall((short)(wal.picnum + 1), spr, dawallnum);
                return;
            case DefineConstants.W_MILKSHELF:
                breakwall(DefineConstants.W_MILKSHELFBROKE, spr, dawallnum);
                return;

            case DefineConstants.W_TECHWALL10:
                breakwall(DefineConstants.W_HITTECHWALL10, spr, dawallnum);
                return;

            case DefineConstants.W_TECHWALL1:
            case DefineConstants.W_TECHWALL11:
            case DefineConstants.W_TECHWALL12:
            case DefineConstants.W_TECHWALL13:
            case DefineConstants.W_TECHWALL14:
                breakwall(DefineConstants.W_HITTECHWALL1, spr, dawallnum);
                return;

            case DefineConstants.W_TECHWALL15:
                breakwall(DefineConstants.W_HITTECHWALL15, spr, dawallnum);
                return;

            case DefineConstants.W_TECHWALL16:
                breakwall(DefineConstants.W_HITTECHWALL16, spr, dawallnum);
                return;

            case DefineConstants.W_TECHWALL2:
                breakwall(DefineConstants.W_HITTECHWALL2, spr, dawallnum);
                return;

            case DefineConstants.W_TECHWALL3:
                breakwall(DefineConstants.W_HITTECHWALL3, spr, dawallnum);
                return;

            case DefineConstants.W_TECHWALL4:
                breakwall(DefineConstants.W_HITTECHWALL4, spr, dawallnum);
                return;

            case DefineConstants.ATM:
                wal.picnum = DefineConstants.ATMBROKE;
                lotsofmoney(Engine.board.sprite[spr], (short)(1 + (Engine.krand() & 7)));
                spritesound(DefineConstants.GLASS_HEAVYBREAK, spr);
                break;

            case DefineConstants.WALLLIGHT1:
            case DefineConstants.WALLLIGHT2:
            case DefineConstants.WALLLIGHT3:
            case DefineConstants.WALLLIGHT4:
            case DefineConstants.TECHLIGHT2:
            case DefineConstants.TECHLIGHT4:

                if (((Engine.krand() >> 8) >= (255 - (128))))
                {
                    spritesound(DefineConstants.GLASS_HEAVYBREAK, spr);
                }
                else
                {
                    spritesound(DefineConstants.GLASS_BREAKING, spr);
                }
                lotsofglass(spr, dawallnum, 30);

                if (wal.picnum == DefineConstants.WALLLIGHT1)
                {
                    wal.picnum = DefineConstants.WALLLIGHTBUST1;
                }

                if (wal.picnum == DefineConstants.WALLLIGHT2)
                {
                    wal.picnum = DefineConstants.WALLLIGHTBUST2;
                }

                if (wal.picnum == DefineConstants.WALLLIGHT3)
                {
                    wal.picnum = DefineConstants.WALLLIGHTBUST3;
                }

                if (wal.picnum == DefineConstants.WALLLIGHT4)
                {
                    wal.picnum = DefineConstants.WALLLIGHTBUST4;
                }

                if (wal.picnum == DefineConstants.TECHLIGHT2)
                {
                    wal.picnum = DefineConstants.TECHLIGHTBUST2;
                }

                if (wal.picnum == DefineConstants.TECHLIGHT4)
                {
                    wal.picnum = DefineConstants.TECHLIGHTBUST4;
                }

                if (wal.lotag == 0)
                {
                    return;
                }

                sn = wal.nextsector;
                if (sn < 0)
                {
                    return;
                }
                darkestwall = 0;

                int f = 0;
                for (i = Engine.board.sector[sn].wallnum; i > 0; i--, f++)
                {
                    wal = Engine.board.wall[Engine.board.sector[sn].wallptr + f];
                    if (wal.shade > darkestwall)
                    {
                        darkestwall = wal.shade;
                    }
                }

                j = (short)(Engine.krand() & 1);
                i = (short)Engine.board.headspritestat[3];
                while (i >= 0)
                {
                    if (Engine.board.sprite[i].hitag == Engine.board.wall[dawallnum].lotag && Engine.board.sprite[i].lotag == 3)
                    {
                        hittype[i].actioncount = j;
                        hittype[i].temp_data[3] = darkestwall;
                        hittype[i].temp_data[4] = 1;
                    }
                    i = (short)Engine.board.nextspritestat[i];
                }
                break;
        }
    }

    public static void checkplayerhurt(player_struct p, short j)
    {
        if ((j & 49152) == 49152)
        {
            j &= (DefineConstants.MAXSPRITES - 1);

            switch (Engine.board.sprite[j].picnum)
            {
                case DefineConstants.CACTUS:
                    if (p.hurt_delay < 8)
                    {
                        Engine.board.sprite[p.i].extra -= 5;

                        p.hurt_delay = 16;
                        p.pals_time = 32;
                        // jmarshall - hurt palette
                        //p.pals = StringFunctions.ChangeCharacter(p.pals, 0, 32);
                        //p.pals = p.pals.Substring(0, 1);
                        //p.pals = p.pals.Substring(0, 2);
                        // jmarshall end
                        spritesound(DefineConstants.DUKE_LONGTERM_PAIN, p.i);
                    }
                    break;
            }
            return;
        }

        if ((j & 49152) != 32768)
        {
            return;
        }
        j &= (DefineConstants.MAXWALLS - 1);

        if (p.hurt_delay > 0)
        {
            p.hurt_delay--;
        }
        else if ((Engine.board.wall[j].cstat & 85) != 0)
        {
            switch (Engine.board.wall[j].overpicnum)
            {
                case DefineConstants.W_FORCEFIELD:
                case DefineConstants.W_FORCEFIELD + 1:
                case DefineConstants.W_FORCEFIELD + 2:
                    Engine.board.sprite[p.i].extra -= 5;

                    p.hurt_delay = 16;
                    p.pals_time = 32;
                    // jmarshall - hurt palette
                    //p.pals = StringFunctions.ChangeCharacter(p.pals, 0, 32);
                    //p.pals = p.pals.Substring(0, 1);
                    //p.pals = p.pals.Substring(0, 2);
                    // jmarshall end

                    p.posxv = -(Engine.table.sintable[(p.ang + 512) & 2047] << 8);
                    p.posyv = -(Engine.table.sintable[(p.ang) & 2047] << 8);
                    spritesound(DefineConstants.DUKE_LONGTERM_PAIN, p.i);

                    checkhitwall(p.i, j, p.posx + (Engine.table.sintable[(p.ang + 512) & 2047] >> 9), p.posy + (Engine.table.sintable[p.ang & 2047] >> 9), p.posz, -1);

                    break;

                case DefineConstants.BIGFORCE:
                    p.hurt_delay = 26;
                    checkhitwall(p.i, j, p.posx + (Engine.table.sintable[(p.ang + 512) & 2047] >> 9), p.posy + (Engine.table.sintable[p.ang & 2047] >> 9), p.posz, -1);
                    break;

            }
        }
    }

    public static bool checkhitceiling(short sn)
    {
        int i;
        int j;
        int q;
        int darkestwall;
        int darkestceiling;
        int nfloors;
        int nceilings;
        walltype wal;

        switch (Engine.board.sector[sn].ceilingpicnum)
        {
            case DefineConstants.WALLLIGHT1:
            case DefineConstants.WALLLIGHT2:
            case DefineConstants.WALLLIGHT3:
            case DefineConstants.WALLLIGHT4:
            case DefineConstants.TECHLIGHT2:
            case DefineConstants.TECHLIGHT4:

                ceilingglass(ps[myconnectindex].i, sn, 10);
                spritesound(DefineConstants.GLASS_BREAKING, ps[screenpeek].i);

                if (Engine.board.sector[sn].ceilingpicnum == DefineConstants.WALLLIGHT1)
                {
                    Engine.board.sector[sn].ceilingpicnum = DefineConstants.WALLLIGHTBUST1;
                }

                if (Engine.board.sector[sn].ceilingpicnum == DefineConstants.WALLLIGHT2)
                {
                    Engine.board.sector[sn].ceilingpicnum = DefineConstants.WALLLIGHTBUST2;
                }

                if (Engine.board.sector[sn].ceilingpicnum == DefineConstants.WALLLIGHT3)
                {
                    Engine.board.sector[sn].ceilingpicnum = DefineConstants.WALLLIGHTBUST3;
                }

                if (Engine.board.sector[sn].ceilingpicnum == DefineConstants.WALLLIGHT4)
                {
                    Engine.board.sector[sn].ceilingpicnum = DefineConstants.WALLLIGHTBUST4;
                }

                if (Engine.board.sector[sn].ceilingpicnum == DefineConstants.TECHLIGHT2)
                {
                    Engine.board.sector[sn].ceilingpicnum = DefineConstants.TECHLIGHTBUST2;
                }

                if (Engine.board.sector[sn].ceilingpicnum == DefineConstants.TECHLIGHT4)
                {
                    Engine.board.sector[sn].ceilingpicnum = DefineConstants.TECHLIGHTBUST4;
                }


                if (Engine.board.sector[sn].hitag == 0)
                {
                    i = Engine.board.headspritesect[sn];
                    while (i >= 0)
                    {
                        if (Engine.board.sprite[i].picnum == DefineConstants.SECTOREFFECTOR && Engine.board.sprite[i].lotag == 12)
                        {
                            j = Engine.board.headspritestat[3];
                            while (j >= 0)
                            {
                                if (Engine.board.sprite[j].hitag == Engine.board.sprite[i].hitag)
                                {
                                    hittype[j].temp_data[3] = 1;
                                }
                                j = Engine.board.nextspritestat[j];
                            }
                            break;
                        }
                        i = Engine.board.nextspritesect[i];
                    }
                }

                i = Engine.board.headspritestat[3];
                j = (short)(Engine.krand() & 1);
                while (i >= 0)
                {
                    if (Engine.board.sprite[i].hitag == (Engine.board.sector[sn].hitag) && Engine.board.sprite[i].lotag == 3)
                    {
                        hittype[i].actioncount = j;
                        hittype[i].temp_data[4] = 1;
                    }
                    i = Engine.board.nextspritestat[i];
                }

                return true;
        }

        return false;
    }

    public static void checkhitsprite(short i, short sn)
    {
        short j;
        short k;
        short l;
        short nextj;
        short p;
        spritetype s;

        i &= (DefineConstants.MAXSPRITES - 1);

        switch (Engine.board.sprite[i].picnum)
        {
            case DefineConstants.OCEANSPRITE1:
            case DefineConstants.OCEANSPRITE2:
            case DefineConstants.OCEANSPRITE3:
            case DefineConstants.OCEANSPRITE4:
            case DefineConstants.OCEANSPRITE5:
                spawn(i, DefineConstants.SMALLSMOKE);
                Engine.board.deletesprite(i);
                break;
            case DefineConstants.QUEBALL:
            case DefineConstants.STRIPEBALL:
                if (Engine.board.sprite[sn].picnum == DefineConstants.QUEBALL || Engine.board.sprite[sn].picnum == DefineConstants.STRIPEBALL)
                {
                    Engine.board.sprite[sn].xvel = (short)((Engine.board.sprite[i].xvel >> 1) + (Engine.board.sprite[i].xvel >> 2));
                    Engine.board.sprite[sn].ang -= (short)((Engine.board.sprite[i].ang << 1) + 1024);
                    Engine.board.sprite[i].ang = (short)(Engine.getangle(Engine.board.sprite[i].x - Engine.board.sprite[sn].x, Engine.board.sprite[i].y - Engine.board.sprite[sn].y) - 512);
                    if (Sound[DefineConstants.POOLBALLHIT].num < 2)
                    {
                        spritesound(DefineConstants.POOLBALLHIT, i);
                    }
                }
                else
                {
                    if ((Engine.krand() & 3) != 0)
                    {
                        Engine.board.sprite[i].xvel = 164;
                        Engine.board.sprite[i].ang = Engine.board.sprite[sn].ang;
                    }
                    else
                    {
                        lotsofglass(i, -1, 3);
                        Engine.board.deletesprite(i);
                    }
                }
                break;
            case DefineConstants.TREE1:
            case DefineConstants.TREE2:
            case DefineConstants.TIRE:
            case DefineConstants.CONE:
            case DefineConstants.BOX:
                switch (Engine.board.sprite[sn].picnum)
                {
                    case DefineConstants.RADIUSEXPLOSION:
                    case DefineConstants.RPG:
                    case DefineConstants.FIRELASER:
                    case DefineConstants.HYDRENT:
                    case DefineConstants.HEAVYHBOMB:
                        if (hittype[i].count == 0)
                        {
                            Engine.board.sprite[i].cstat &= ~257;
                            hittype[i].count = 1;
                            spawn(i, DefineConstants.BURNING);
                        }
                        break;
                }
                break;
            case DefineConstants.CACTUS:
                //        case CACTUSBROKE:
                switch (Engine.board.sprite[sn].picnum)
                {
                    case DefineConstants.RADIUSEXPLOSION:
                    case DefineConstants.RPG:
                    case DefineConstants.FIRELASER:
                    case DefineConstants.HYDRENT:
                    case DefineConstants.HEAVYHBOMB:
                        for (k = 0; k < 64; k++)
                        {
                            j = EGS(Engine.board.sprite[i].sectnum, Engine.board.sprite[i].x, Engine.board.sprite[i].y, (short)(Engine.board.sprite[i].z - (Engine.krand() % (48 << 8))), (short)(DefineConstants.SCRAP3 + (Engine.krand() & 3)), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), (int)(-(Engine.krand() & 4095) - (Engine.board.sprite[i].zvel >> 2)), i, 5);
                            Engine.board.sprite[j].pal = 8;
                        }

                        if (Engine.board.sprite[i].picnum == DefineConstants.CACTUS)
                        {
                            Engine.board.sprite[i].picnum = DefineConstants.CACTUSBROKE;
                        }
                        Engine.board.sprite[i].cstat &= ~257;
                        //       else deletesprite(i);
                        break;
                }
                break;

            case DefineConstants.HANGLIGHT:
            case DefineConstants.GENERICPOLE2:
                for (k = 0; k < 6; k++)
                {
                    EGS(Engine.board.sprite[i].sectnum, Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].z - (8 << 8), (short)(DefineConstants.SCRAP1 + (Engine.krand() & 15)), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), (int)(-(Engine.krand() & 4095) - (Engine.board.sprite[i].zvel >> 2)), i, 5);
                }
                spritesound(DefineConstants.GLASS_HEAVYBREAK, i);
                Engine.board.deletesprite(i);
                break;


            case DefineConstants.FANSPRITE:
                Engine.board.sprite[i].picnum = DefineConstants.FANSPRITEBROKE;
                Engine.board.sprite[i].cstat &= unchecked((short)(65535 - 257));
                if (Engine.board.sector[Engine.board.sprite[i].sectnum].floorpicnum == DefineConstants.FANSHADOW)
                {
                    Engine.board.sector[Engine.board.sprite[i].sectnum].floorpicnum = DefineConstants.FANSHADOWBROKE;
                }

                spritesound(DefineConstants.GLASS_HEAVYBREAK, i);
                s = Engine.board.sprite[i];
                for (j = 0; j < 16; j++)
                {
                    EGS(s.sectnum, (short)(s.x + (Engine.krand() & 255) - 128), (short)(s.y + (Engine.krand() & 255) - 128), (int)(s.z - (8 << 8) - (Engine.krand() & 8191)), (short)(DefineConstants.SCRAP6 + (Engine.krand() & 15)), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), -512 - (short)(Engine.krand() & 2047), i, 5);
                }

                break;
            case DefineConstants.WATERFOUNTAIN:
            case DefineConstants.WATERFOUNTAIN + 1:
            case DefineConstants.WATERFOUNTAIN + 2:
            case DefineConstants.WATERFOUNTAIN + 3:
                Engine.board.sprite[i].picnum = DefineConstants.WATERFOUNTAINBROKE;
                spawn(i, DefineConstants.TOILETWATER);
                break;
            case DefineConstants.SATELITE:
            case DefineConstants.FUELPOD:
            case DefineConstants.SOLARPANNEL:
            case DefineConstants.ANTENNA:
                // jmarshall - attenna
                /*
                if (sprite[sn].extra != *actorscrptr[DefineConstants.SHOTSPARK1])
                {
                    for (j = 0; j < 15; j++)
                    {
                        EGS(sprite[i].sectnum, sprite[i].x, sprite[i].y, sector[sprite[i].sectnum].floorz - (12 << 8) - (j << 9), DefineConstants.SCRAP1 + (krand() & 15), -8, 64, 64, (short)(krand() & 2047), (short)((krand() & 127) + 64), -(krand() & 511) - 256, i, 5);
                    }
                    spawn(i, DefineConstants.EXPLOSION2);
                    deletesprite(i);
                }
                */
                // jmarshall end
                break;
            case DefineConstants.BOTTLE1:
            case DefineConstants.BOTTLE2:
            case DefineConstants.BOTTLE3:
            case DefineConstants.BOTTLE4:
            case DefineConstants.BOTTLE5:
            case DefineConstants.BOTTLE6:
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
            case DefineConstants.WATERFOUNTAINBROKE:
            case DefineConstants.DOMELITE:
            case DefineConstants.SUSHIPLATE1:
            case DefineConstants.SUSHIPLATE2:
            case DefineConstants.SUSHIPLATE3:
            case DefineConstants.SUSHIPLATE4:
            case DefineConstants.SUSHIPLATE5:
            case DefineConstants.WAITTOBESEATED:
            case DefineConstants.VASE:
            case DefineConstants.STATUEFLASH:
            case DefineConstants.STATUE:
                if (Engine.board.sprite[i].picnum == DefineConstants.BOTTLE10)
                {
                    lotsofmoney(Engine.board.sprite[i], (short)(4 + (Engine.krand() & 3)));
                }
                else if (Engine.board.sprite[i].picnum == DefineConstants.STATUE || Engine.board.sprite[i].picnum == DefineConstants.STATUEFLASH)
                {
                    lotsofcolourglass(i, -1, 40);
                    spritesound(DefineConstants.GLASS_HEAVYBREAK, i);
                }
                else if (Engine.board.sprite[i].picnum == DefineConstants.VASE)
                {
                    lotsofglass(i, -1, 40);
                }

                spritesound(DefineConstants.GLASS_BREAKING, i);
                Engine.board.sprite[i].ang = (short)(Engine.krand() & 2047);
                lotsofglass(i, -1, 8);
                Engine.board.deletesprite(i);
                break;
            case DefineConstants.FETUS:
                Engine.board.sprite[i].picnum = DefineConstants.FETUSBROKE;
                spritesound(DefineConstants.GLASS_BREAKING, i);
                lotsofglass(i, -1, 10);
                break;
            case DefineConstants.FETUSBROKE:
                for (j = 0; j < 48; j++)
                {
                    shoot(i, DefineConstants.BLOODSPLAT1);
                    Engine.board.sprite[i].ang += 333;
                }
                spritesound(DefineConstants.GLASS_HEAVYBREAK, i);
                spritesound(DefineConstants.SQUISHED, i);
                goto case DefineConstants.BOTTLE7;
            case DefineConstants.BOTTLE7:
                spritesound(DefineConstants.GLASS_BREAKING, i);
                lotsofglass(i, -1, 10);
                Engine.board.deletesprite(i);
                break;
            case DefineConstants.HYDROPLANT:
                Engine.board.sprite[i].picnum = DefineConstants.BROKEHYDROPLANT;
                spritesound(DefineConstants.GLASS_BREAKING, i);
                lotsofglass(i, -1, 10);
                break;

            case DefineConstants.FORCESPHERE:
                Engine.board.sprite[i].xrepeat = 0;
                hittype[Engine.board.sprite[i].owner].count = 32;
                if (hittype[Engine.board.sprite[i].owner].temp_data[1] == 0)
                {
                    hittype[Engine.board.sprite[i].owner].temp_data[1] = 1;
                }
                else
                {
                    hittype[Engine.board.sprite[i].owner].temp_data[1] = 0;
                }
                hittype[Engine.board.sprite[i].owner].actioncount++;
                spawn(i, DefineConstants.EXPLOSION2);
                break;

            case DefineConstants.BROKEHYDROPLANT:
                if ((Engine.board.sprite[i].cstat & 1) != 0)
                {
                    spritesound(DefineConstants.GLASS_BREAKING, i);
                    Engine.board.sprite[i].z += 16 << 8;
                    Engine.board.sprite[i].cstat = 0;
                    lotsofglass(i, -1, 5);
                }
                break;

            case DefineConstants.TOILET:
                Engine.board.sprite[i].picnum = DefineConstants.TOILETBROKE;
                Engine.board.sprite[i].cstat |= (short)((Engine.krand() & 1) << 2);
                Engine.board.sprite[i].cstat &= ~257;
                spawn(i, DefineConstants.TOILETWATER);
                spritesound(DefineConstants.GLASS_BREAKING, i);
                break;

            case DefineConstants.STALL:
                Engine.board.sprite[i].picnum = DefineConstants.STALLBROKE;
                Engine.board.sprite[i].cstat |= (short)((Engine.krand() & 1) << 2);
                Engine.board.sprite[i].cstat &= ~257;
                spawn(i, DefineConstants.TOILETWATER);
                spritesound(DefineConstants.GLASS_HEAVYBREAK, i);
                break;

            case DefineConstants.HYDRENT:
                Engine.board.sprite[i].picnum = DefineConstants.BROKEFIREHYDRENT;
                spawn(i, DefineConstants.TOILETWATER);

                //            for(k=0;k<5;k++)
                //          {
                //            j = EGS(SECT,SX,SY,SZ-(TRAND%(48<<8)),SCRAP3+(TRAND&3),-8,48,48,TRAND&2047,(TRAND&63)+64,-(TRAND&4095)-(sprite[i].zvel>>2),i,5);
                //          sprite[j].pal = 2;
                //    }
                spritesound(DefineConstants.GLASS_HEAVYBREAK, i);
                break;

            case DefineConstants.GRATE1:
                Engine.board.sprite[i].picnum = DefineConstants.BGRATE1;
                Engine.board.sprite[i].cstat &= unchecked((short)(65535 - 256 - 1));
                spritesound(DefineConstants.VENT_BUST, i);
                break;

            case DefineConstants.CIRCLEPANNEL:
                Engine.board.sprite[i].picnum = DefineConstants.CIRCLEPANNELBROKE;
                Engine.board.sprite[i].cstat &= unchecked((short)(65535 - 256 - 1));
                spritesound(DefineConstants.VENT_BUST, i);
                break;
            case DefineConstants.PANNEL1:
            case DefineConstants.PANNEL2:
                Engine.board.sprite[i].picnum = DefineConstants.BPANNEL1;
                Engine.board.sprite[i].cstat &= unchecked((short)(65535 - 256 - 1));
                spritesound(DefineConstants.VENT_BUST, i);
                break;
            case DefineConstants.PANNEL3:
                Engine.board.sprite[i].picnum = DefineConstants.BPANNEL3;
                Engine.board.sprite[i].cstat &= unchecked((short)(65535 - 256 - 1));
                spritesound(DefineConstants.VENT_BUST, i);
                break;
            case DefineConstants.PIPE1:
            case DefineConstants.PIPE2:
            case DefineConstants.PIPE3:
            case DefineConstants.PIPE4:
            case DefineConstants.PIPE5:
            case DefineConstants.PIPE6:
                switch (Engine.board.sprite[i].picnum)
                {
                    case DefineConstants.PIPE1:
                        Engine.board.sprite[i].picnum = DefineConstants.PIPE1B;
                        break;
                    case DefineConstants.PIPE2:
                        Engine.board.sprite[i].picnum = DefineConstants.PIPE2B;
                        break;
                    case DefineConstants.PIPE3:
                        Engine.board.sprite[i].picnum = DefineConstants.PIPE3B;
                        break;
                    case DefineConstants.PIPE4:
                        Engine.board.sprite[i].picnum = DefineConstants.PIPE4B;
                        break;
                    case DefineConstants.PIPE5:
                        Engine.board.sprite[i].picnum = DefineConstants.PIPE5B;
                        break;
                    case DefineConstants.PIPE6:
                        Engine.board.sprite[i].picnum = DefineConstants.PIPE6B;
                        break;
                }

                j = spawn(i, DefineConstants.STEAM);
                Engine.board.sprite[j].z = Engine.board.sector[Engine.board.sprite[i].sectnum].floorz - (32 << 8);
                break;

            case DefineConstants.MONK:
            case DefineConstants.LUKE:
            case DefineConstants.INDY:
            case DefineConstants.JURYGUY:
                spritesound(Engine.board.sprite[i].lotag, i);
                spawn(i, Engine.board.sprite[i].hitag);
                goto case DefineConstants.SPACEMARINE;
            case DefineConstants.SPACEMARINE:
                Engine.board.sprite[i].extra -= Engine.board.sprite[sn].extra;
                if (Engine.board.sprite[i].extra > 0)
                {
                    break;
                }
                Engine.board.sprite[i].ang = (short)(Engine.krand() & 2047);
                shoot(i, DefineConstants.BLOODSPLAT1);
                Engine.board.sprite[i].ang = (short)(Engine.krand() & 2047);
                shoot(i, DefineConstants.BLOODSPLAT2);
                Engine.board.sprite[i].ang = (short)(Engine.krand() & 2047);
                shoot(i, DefineConstants.BLOODSPLAT3);
                Engine.board.sprite[i].ang = (short)(Engine.krand() & 2047);
                shoot(i, DefineConstants.BLOODSPLAT4);
                Engine.board.sprite[i].ang = (short)(Engine.krand() & 2047);
                shoot(i, DefineConstants.BLOODSPLAT1);
                Engine.board.sprite[i].ang = (short)(Engine.krand() & 2047);
                shoot(i, DefineConstants.BLOODSPLAT2);
                Engine.board.sprite[i].ang = (short)(Engine.krand() & 2047);
                shoot(i, DefineConstants.BLOODSPLAT3);
                Engine.board.sprite[i].ang = (short)(Engine.krand() & 2047);
                shoot(i, DefineConstants.BLOODSPLAT4);
                guts(Engine.board.sprite[i], DefineConstants.JIBS1, 1, myconnectindex);
                guts(Engine.board.sprite[i], DefineConstants.JIBS2, 2, myconnectindex);
                guts(Engine.board.sprite[i], DefineConstants.JIBS3, 3, myconnectindex);
                guts(Engine.board.sprite[i], DefineConstants.JIBS4, 4, myconnectindex);
                guts(Engine.board.sprite[i], DefineConstants.JIBS5, 1, myconnectindex);
                guts(Engine.board.sprite[i], DefineConstants.JIBS3, 6, myconnectindex);
                sound(DefineConstants.SQUISHED);
                Engine.board.deletesprite(i);
                break;
            case DefineConstants.CHAIR1:
            case DefineConstants.CHAIR2:
                Engine.board.sprite[i].picnum = DefineConstants.BROKENCHAIR;
                Engine.board.sprite[i].cstat = 0;
                break;
            case DefineConstants.CHAIR3:
            case DefineConstants.MOVIECAMERA:
            case DefineConstants.SCALE:
            case DefineConstants.VACUUM:
            case DefineConstants.CAMERALIGHT:
            case DefineConstants.IVUNIT:
            case DefineConstants.POT1:
            case DefineConstants.POT2:
            case DefineConstants.POT3:
            case DefineConstants.TRIPODCAMERA:
                spritesound(DefineConstants.GLASS_HEAVYBREAK, i);
                s = Engine.board.sprite[i];
                for (j = 0; j < 16; j++)
                {
                    EGS(s.sectnum, (int)(s.x + (Engine.krand() & 255) - 128), (int)(s.y + (Engine.krand() & 255) - 128), (int)(s.z - (8 << 8) - (Engine.krand() & 8191)), (short)(DefineConstants.SCRAP6 + (Engine.krand() & 15)), -8, 48, 48, (short)(Engine.krand() & 2047), (short)((Engine.krand() & 63) + 64), (int)(-512 - (Engine.krand() & 2047)), i, 5);
                }
                Engine.board.deletesprite(i);
                break;
            case DefineConstants.PLAYERONWATER:
            default:
                // jmarshall - modified for switch passthrough.
                if (Engine.board.sprite[i].picnum == DefineConstants.PLAYERONWATER)
                    i = Engine.board.sprite[i].owner;

                if ((Engine.board.sprite[i].cstat & 16) != 0 && Engine.board.sprite[i].hitag == 0 && Engine.board.sprite[i].lotag == 0 && Engine.board.sprite[i].statnum == 0)
                {
                    break;
                }

                if ((Engine.board.sprite[sn].picnum == DefineConstants.FREEZEBLAST || Engine.board.sprite[sn].owner != i) && Engine.board.sprite[i].statnum != 4)
                {
                    if (badguy(Engine.board.sprite[i]) == 1)
                    {
                        if (Engine.board.sprite[sn].picnum == DefineConstants.RPG)
                        {
                            Engine.board.sprite[sn].extra <<= 1;
                        }

                        if ((Engine.board.sprite[i].picnum != DefineConstants.DRONE) && (Engine.board.sprite[i].picnum != DefineConstants.ROTATEGUN) && (Engine.board.sprite[i].picnum != DefineConstants.COMMANDER) && (Engine.board.sprite[i].picnum < DefineConstants.GREENSLIME || Engine.board.sprite[i].picnum > DefineConstants.GREENSLIME + 7))
                        {
                            if (Engine.board.sprite[sn].picnum != DefineConstants.FREEZEBLAST)
                            {
                                if (actortype[Engine.board.sprite[i].picnum] == 0) 
                                {
                                    j = spawn(sn, DefineConstants.JIBS6);
                                    if (Engine.board.sprite[sn].pal == 6)
                                    {
                                        Engine.board.sprite[j].pal = 6;
                                    }
                                    Engine.board.sprite[j].z += (4 << 8);
                                    Engine.board.sprite[j].xvel = 16;
                                    Engine.board.sprite[j].xrepeat = Engine.board.sprite[j].yrepeat = 24;
                                    Engine.board.sprite[j].ang += (short)(32 - (Engine.krand() & 63));
                                }
                            }
                        }

                        j = Engine.board.sprite[sn].owner;

                        if (j >= 0 && Engine.board.sprite[j].picnum == DefineConstants.APLAYER && Engine.board.sprite[i].picnum != DefineConstants.ROTATEGUN && Engine.board.sprite[i].picnum != DefineConstants.DRONE)
                        {
                            if (ps[Engine.board.sprite[j].yvel].curr_weapon == DefineConstants.SHOTGUN_WEAPON)
                            {
                                shoot(i, DefineConstants.BLOODSPLAT3);
                                shoot(i, DefineConstants.BLOODSPLAT1);
                                shoot(i, DefineConstants.BLOODSPLAT2);
                                shoot(i, DefineConstants.BLOODSPLAT4);
                            }
                        }

                        if (Engine.board.sprite[i].picnum != DefineConstants.TANK && Engine.board.sprite[i].picnum != DefineConstants.BOSS1 && Engine.board.sprite[i].picnum != DefineConstants.BOSS4 && Engine.board.sprite[i].picnum != DefineConstants.BOSS2 && Engine.board.sprite[i].picnum != DefineConstants.BOSS3 && Engine.board.sprite[i].picnum != DefineConstants.RECON && Engine.board.sprite[i].picnum != DefineConstants.ROTATEGUN)
                        {
                            if ((Engine.board.sprite[i].cstat & 48) == 0)
                            {
                                Engine.board.sprite[i].ang = (short)((Engine.board.sprite[sn].ang + 1024) & 2047);
                            }
                            Engine.board.sprite[i].xvel = (short)(-(Engine.board.sprite[sn].extra << 2));
                            j = Engine.board.sprite[i].sectnum;
                            Engine.board.pushmove(ref Engine.board.sprite[i].x, ref Engine.board.sprite[i].y, ref Engine.board.sprite[i].z, ref j, 128, (4 << 8), (4 << 8), (((1) << 16) + 1));
                            if (j != Engine.board.sprite[i].sectnum && j >= 0 && j < DefineConstants.MAXSECTORS)
                            {
                                Engine.board.changespritesect(i, j);
                            }
                        }

                        if (Engine.board.sprite[i].statnum == 2)
                        {
                            Engine.board.changespritestat(i, 1);
                            hittype[i].timetosleep = DefineConstants.SLEEPTIME;
                        }
                        if ((Engine.board.sprite[i].xrepeat < 24 || Engine.board.sprite[i].picnum == DefineConstants.SHARK) && Engine.board.sprite[sn].picnum == DefineConstants.SHRINKSPARK)
                        {
                            return;
                        }
                    }

                    if (Engine.board.sprite[i].statnum != 2)
                    {
                        if (Engine.board.sprite[sn].picnum == DefineConstants.FREEZEBLAST && ((Engine.board.sprite[i].picnum == DefineConstants.APLAYER && Engine.board.sprite[i].pal == 1) || (freezerhurtowner == 0 && Engine.board.sprite[sn].owner == i)))
                        {
                            return;
                        }

                        hittype[i].picnum = Engine.board.sprite[sn].picnum;
                        hittype[i].extra += Engine.board.sprite[sn].extra;
                        hittype[i].ang = Engine.board.sprite[sn].ang;
                        hittype[i].owner = Engine.board.sprite[sn].owner;
                    }

                    if (Engine.board.sprite[i].statnum == 10)
                    {
                        p = Engine.board.sprite[i].yvel;
                        if (ps[p].newowner >= 0)
                        {
                            ps[p].newowner = -1;
                            ps[p].posx = ps[p].oposx;
                            ps[p].posy = ps[p].oposy;
                            ps[p].posz = ps[p].oposz;
                            ps[p].ang = ps[p].oang;

                            Engine.board.updatesector(ps[p].posx, ps[p].posy, ref ps[p].cursectnum);
                            // setpal(ps[p]); jmarshall broken palette.

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

                        if (Engine.board.sprite[i].xrepeat < 24 && Engine.board.sprite[sn].picnum == DefineConstants.SHRINKSPARK)
                        {
                            return;
                        }

                        if (Engine.board.sprite[hittype[i].owner].picnum != DefineConstants.APLAYER)
                        {
                            if (ud.player_skill >= 3)
                            {
                                Engine.board.sprite[sn].extra += (short)(Engine.board.sprite[sn].extra >> 1);
                            }
                        }
                    }

                }
                break;
        }
    }

    public static void allignwarpelevators()
    {
        int i;
        int j;

        i = Engine.board.headspritestat[3];
        while (i >= 0)
        {
            if (Engine.board.sprite[i].lotag == 17 && Engine.board.sprite[i].shade > 16)
            {
                j = Engine.board.headspritestat[3];
                while (j >= 0)
                {
                    if ((Engine.board.sprite[j].lotag) == 17 && i != j && (Engine.board.sprite[i].hitag) == (Engine.board.sprite[j].hitag))
                    {
                        Engine.board.sector[Engine.board.sprite[j].sectnum].floorz = Engine.board.sector[Engine.board.sprite[i].sectnum].floorz;
                        Engine.board.sector[Engine.board.sprite[j].sectnum].ceilingz = Engine.board.sector[Engine.board.sprite[i].sectnum].ceilingz;
                    }

                    j = Engine.board.nextspritestat[j];
                }
            }
            i = Engine.board.nextspritestat[i];
        }
    }

    public static void cheatkeys(short snum)
    {
        // jmarshall: do we need this?
    }

    public static void checksectors(short snum)
    {
        int i = -1;
        int oldz;
        player_struct p;
        short j = 0;
        short hitscanwall;

        p = ps[snum];

        switch (Engine.board.sector[p.cursectnum].lotag)
        {

            case 32767:
                Engine.board.sector[p.cursectnum].lotag = 0;
                FTA(9, p);
                p.secret_rooms++;
                return;
            case -1:
                for (i = connecthead; i >= 0; i = connectpoint2[i])
                {
                    ps[i].gm = DefineConstants.MODE_EOL;
                }
                Engine.board.sector[p.cursectnum].lotag = 0;
                if (ud.from_bonus != 0)
                {
                    ud.level_number = ud.from_bonus;
                    ud.m_level_number = ud.level_number;
                    ud.from_bonus = 0;
                }
                else
                {
                    ud.level_number++;
                    if ((ud.volume_number != 0 && ud.level_number > 10) || ud.level_number > 5)
                    {
                        ud.level_number = 0;
                    }
                    ud.m_level_number = ud.level_number;
                }
                return;
            case -2:
                Engine.board.sector[p.cursectnum].lotag = 0;
                p.timebeforeexit = (short)(26 * 8);
                p.customexitsound = Engine.board.sector[p.cursectnum].hitag;
                return;
            default:
                if (Engine.board.sector[p.cursectnum].lotag >= 10000 && Engine.board.sector[p.cursectnum].lotag < 16383)
                {
                    if (snum == screenpeek || ud.coop == 1)
                    {
                        spritesound(Engine.board.sector[p.cursectnum].lotag - 10000, p.i);
                    }
                    Engine.board.sector[p.cursectnum].lotag = 0;
                }
                break;

        }

        //After this point the the player effects the map with space

        if ((p.gm & DefineConstants.MODE_TYPE) != 0 || Engine.board.sprite[p.i].extra <= 0)
        {
            return;
        }

        if (ud.cashman != 0 && (sync[snum].bits & (1 << 29)) != 0)
        {
            lotsofmoney(Engine.board.sprite[p.i], 2);
        }

        if (p.newowner >= 0)
        {
            if (pragmas.klabs(sync[snum].svel) > 768 || pragmas.klabs(sync[snum].fvel) > 768)
            {
                i = -1;
                if (i < 0)
                {
                    p.posx = p.oposx;
                    p.posy = p.oposy;
                    p.posz = p.oposz;
                    p.ang = p.oang;
                    p.newowner = -1;

                    Engine.board.updatesector(p.posx, p.posy, ref p.cursectnum);
                    //setpal(p); // jmarshall : pallete


                    i = Engine.board.headspritestat[1];
                    while (i >= 0)
                    {
                        if (Engine.board.sprite[i].picnum == DefineConstants.CAMERA1)
                        {
                            Engine.board.sprite[i].yvel = 0;
                        }
                        i = Engine.board.nextspritestat[i];
                    }
                }
                else if (p.newowner >= 0)
                {
                    p.newowner = -1;
                }

                if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false))
                {
                    KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
                };

                return;
            }
        }

        if ((sync[snum].bits & (1 << 29)) == 0 && (sync[snum].bits & (1 << 31)) == 0)
        {
            p.toggle_key_flag = 0;
        }

        else if (p.toggle_key_flag == 0)
        {

            if ((sync[snum].bits & (1 << 31)) != 0)
            {
                if (p.newowner >= 0)
                {
                    i = -1;
                    if (i < 0)
                    {
                        p.posx = p.oposx;
                        p.posy = p.oposy;
                        p.posz = p.oposz;
                        p.ang = p.oang;
                        p.newowner = -1;

                        Engine.board.updatesector(p.posx, p.posy, ref p.cursectnum);
                        //setpal(p); // jmarshall : pallete


                        i = Engine.board.headspritestat[1];
                        while (i >= 0)
                        {
                            if (Engine.board.sprite[i].picnum == DefineConstants.CAMERA1)
                            {
                                Engine.board.sprite[i].yvel = 0;
                            }
                            i = Engine.board.nextspritestat[i];
                        }
                    }
                    else if (p.newowner >= 0)
                    {
                        p.newowner = -1;
                    }

                    if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false))
                    {
                        KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
                    };

                    return;
                }
                return;
            }

            neartagsprite = -1;
            p.toggle_key_flag = 1;
            hitscanwall = -1;

            i = hitawall(p, ref hitscanwall);

            if (i < 1280 && hitscanwall >= 0 && Engine.board.wall[hitscanwall].overpicnum == DefineConstants.MIRROR)
            {
                if (Engine.board.wall[hitscanwall].lotag > 0 && Sound[Engine.board.wall[hitscanwall].lotag].num == 0 && snum == screenpeek)
                {
                    spritesound(Engine.board.wall[hitscanwall].lotag, p.i);
                    return;
                }
            }

            if (hitscanwall >= 0 && (Engine.board.wall[hitscanwall].cstat & 16) != 0)
            {
// jmarshall - this is right, saving just in case.
                if (Engine.board.wall[hitscanwall].lotag != 0)
                {
                    return;
                }
                //switch (Engine.board.wall[hitscanwall].overpicnum)
                //{
                //    default:
                //        if (Engine.board.wall[hitscanwall].lotag)
                //        {
                //            return;
                //        }
                //}
// jmarshall end
            }

            if (p.newowner >= 0)
            {
                Engine.board.neartag(p.oposx, p.oposy, p.oposz, Engine.board.sprite[p.i].sectnum, p.oang, ref neartagsector, ref neartagwall, ref neartagsprite, ref neartaghitdist, 1280, 1);
            }
            else
            {
                Engine.board.neartag(p.posx, p.posy, p.posz, Engine.board.sprite[p.i].sectnum, p.oang, ref neartagsector, ref neartagwall, ref neartagsprite, ref neartaghitdist, 1280, 1);
                if (neartagsprite == -1 && neartagwall == -1 && neartagsector == -1)
                {
                    Engine.board.neartag(p.posx, p.posy, p.posz + (8 << 8), Engine.board.sprite[p.i].sectnum, p.oang, ref neartagsector,ref  neartagwall, ref neartagsprite, ref neartaghitdist, 1280, 1);
                }
                if (neartagsprite == -1 && neartagwall == -1 && neartagsector == -1)
                {
                    Engine.board.neartag(p.posx, p.posy, p.posz + (16 << 8), Engine.board.sprite[p.i].sectnum, p.oang, ref neartagsector, ref neartagwall, ref neartagsprite, ref neartaghitdist, 1280, 1);
                }
                if (neartagsprite == -1 && neartagwall == -1 && neartagsector == -1)
                {
                    Engine.board.neartag(p.posx, p.posy, p.posz + (16 << 8), Engine.board.sprite[p.i].sectnum, p.oang, ref neartagsector, ref neartagwall, ref neartagsprite, ref neartaghitdist, 1280, 3);
                    if (neartagsprite >= 0)
                    {
                        switch (Engine.board.sprite[neartagsprite].picnum)
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
                            case DefineConstants.TOUGHGAL:
                                return;
                        }
                    }

                    neartagsprite = -1;
                    neartagwall = -1;
                    neartagsector = -1;
                }
            }

            if (p.newowner == -1 && neartagsprite == -1 && neartagsector == -1 && neartagwall == -1)
            {
                if (isanunderoperator(Engine.board.sector[Engine.board.sprite[p.i].sectnum].lotag))
                {
                    neartagsector = Engine.board.sprite[p.i].sectnum;
                }
            }

            if (neartagsector >= 0 && (Engine.board.sector[neartagsector].lotag & 16384) != 0)
            {
                return;
            }

            if (neartagsprite == -1 && neartagwall == -1)
            {
                if (Engine.board.sector[p.cursectnum].lotag == 2)
                {
                    oldz = hitasprite(p.i, ref neartagsprite);
                    if (oldz > 1280)
                    {
                        neartagsprite = -1;
                    }
                }
            }

            if (neartagsprite >= 0)
            {
                if (checkhitswitch(snum, neartagsprite, (char)1))
                {
                    return;
                }

                switch (Engine.board.sprite[neartagsprite].picnum)
                {
                    case DefineConstants.TOILET:
                    case DefineConstants.STALL:
                        if (p.last_pissed_time == 0)
                        {
                            if (ud.lockout == 0)
                            {
                                spritesound(DefineConstants.DUKE_URINATE, p.i);
                            }

                            p.last_pissed_time = 26 * 220;
                            p.transporter_hold = (short)(29 * 2);
                            if (p.holster_weapon == 0)
                            {
                                p.holster_weapon = (char)1;
                                p.weapon_pos = -1;
                            }
                            if (Engine.board.sprite[p.i].extra <= (max_player_health - (max_player_health / 10)))
                            {
                                Engine.board.sprite[p.i].extra += (short)(max_player_health / 10);
                                p.last_extra = Engine.board.sprite[p.i].extra;
                            }
                            else if (Engine.board.sprite[p.i].extra < max_player_health)
                            {
                                Engine.board.sprite[p.i].extra = (short)max_player_health;
                            }
                        }
                        else if (Sound[DefineConstants.FLUSH_TOILET].num == 0)
                        {
                            spritesound(DefineConstants.FLUSH_TOILET, p.i);
                        }
                        return;

                    case DefineConstants.NUKEBUTTON:

                        hitawall(p, ref j);
                        if (j >= 0 && Engine.board.wall[j].overpicnum == 0)
                        {
                            if (hittype[neartagsprite].count == 0)
                            {
                                hittype[neartagsprite].count = 1;
                                Engine.board.sprite[neartagsprite].owner = p.i;
                                //p.buttonpalette = Engine.board.sprite[neartagsprite].pal; // jmarshall: palette
                                if (p.buttonpalette != 0)
                                {
                                    ud.secretlevel = Engine.board.sprite[neartagsprite].lotag;
                                }
                                else
                                {
                                    ud.secretlevel = 0;
                                }
                            }
                        }
                        return;
                    case DefineConstants.WATERFOUNTAIN:
                        if (hittype[neartagsprite].count != 1)
                        {
                            hittype[neartagsprite].count = 1;
                            Engine.board.sprite[neartagsprite].owner = p.i;

                            if (Engine.board.sprite[p.i].extra < max_player_health)
                            {
                                Engine.board.sprite[p.i].extra++;
                                spritesound(DefineConstants.DUKE_DRINKING, p.i);
                            }
                        }
                        return;
                    case DefineConstants.PLUG:
                        spritesound(DefineConstants.SHORT_CIRCUIT, p.i);
                        Engine.board.sprite[p.i].extra -= (short)(2 + (Engine.krand() & 3));
                        // jmarshall: pallete
                        //p.pals = StringFunctions.ChangeCharacter(p.pals, 0, 48);
                        //p.pals = StringFunctions.ChangeCharacter(p.pals, 1, 48);
                        //p.pals = StringFunctions.ChangeCharacter(p.pals, 2, 64);
                        p.pals_time = 32;
                        break;
                    case DefineConstants.VIEWSCREEN:
                    case DefineConstants.VIEWSCREEN2:
                        {
                            i = Engine.board.headspritestat[1];

                            while (i >= 0)
                            {
                                if (Engine.board.sprite[i].picnum == DefineConstants.CAMERA1 && Engine.board.sprite[i].yvel == 0 && Engine.board.sprite[neartagsprite].hitag == Engine.board.sprite[i].lotag)
                                {
                                    Engine.board.sprite[i].yvel = 1; //Using this camera
                                    spritesound(DefineConstants.MONITOR_ACTIVE, neartagsprite);

                                    Engine.board.sprite[neartagsprite].owner = (short)i;
                                    Engine.board.sprite[neartagsprite].yvel = 1;


                                    j = p.cursectnum;
                                    p.cursectnum = Engine.board.sprite[i].sectnum;
                                    //setpal(p); jmarshall: pallete
                                    p.cursectnum = j;

                                    // parallaxtype = 2;
                                    p.newowner = (short)i;
                                    return;
                                }
                                i = Engine.board.nextspritestat[i];
                            }
                        }

                        CLEARCAMERAS:

                        if (i < 0)
                        {
                            p.posx = p.oposx;
                            p.posy = p.oposy;
                            p.posz = p.oposz;
                            p.ang = p.oang;
                            p.newowner = -1;

                            Engine.board.updatesector(p.posx, p.posy, ref p.cursectnum);
                            //setpal(p); // jmarshall : pallete


                            i = Engine.board.headspritestat[1];
                            while (i >= 0)
                            {
                                if (Engine.board.sprite[i].picnum == DefineConstants.CAMERA1)
                                {
                                    Engine.board.sprite[i].yvel = 0;
                                }
                                i = Engine.board.nextspritestat[i];
                            }
                        }
                        else if (p.newowner >= 0)
                        {
                            p.newowner = -1;
                        }

                        if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false))
                        {
                            KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
                        };

                        return;
                }
            }

            if ((sync[snum].bits & (1 << 29)) == 0)
            {
                return;
            }
            else if (p.newowner >= 0)
            {
                i = -1;
                if (i < 0)
                {
                    p.posx = p.oposx;
                    p.posy = p.oposy;
                    p.posz = p.oposz;
                    p.ang = p.oang;
                    p.newowner = -1;

                    Engine.board.updatesector(p.posx, p.posy, ref p.cursectnum);
                    //setpal(p); // jmarshall : pallete


                    i = Engine.board.headspritestat[1];
                    while (i >= 0)
                    {
                        if (Engine.board.sprite[i].picnum == DefineConstants.CAMERA1)
                        {
                            Engine.board.sprite[i].yvel = 0;
                        }
                        i = Engine.board.nextspritestat[i];
                    }
                }
                else if (p.newowner >= 0)
                {
                    p.newowner = -1;
                }

                if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false))
                {
                    KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
                };

                return;
            }

            if (neartagwall == -1 && neartagsector == -1 && neartagsprite == -1)
            {
                if (pragmas.klabs(hits(p.i)) < 512)
                {
                    if ((Engine.krand() & 255) < 16)
                    {
                        spritesound(DefineConstants.DUKE_SEARCH2, p.i);
                    }
                    else
                    {
                        spritesound(DefineConstants.DUKE_SEARCH, p.i);
                    }
                    return;
                }
            }

            if (neartagwall >= 0)
            {
                if (Engine.board.wall[neartagwall].lotag > 0 && isadoorwall(Engine.board.wall[neartagwall].picnum))
                {
                    if (hitscanwall == neartagwall || hitscanwall == -1)
                    {
                        checkhitswitch(snum, neartagwall, (char)0);
                    }
                    return;
                }
                else if (p.newowner >= 0)
                {
                    i = -1;
                    if (i < 0)
                    {
                        p.posx = p.oposx;
                        p.posy = p.oposy;
                        p.posz = p.oposz;
                        p.ang = p.oang;
                        p.newowner = -1;

                        Engine.board.updatesector(p.posx, p.posy, ref p.cursectnum);
                        //setpal(p); // jmarshall : pallete


                        i = Engine.board.headspritestat[1];
                        while (i >= 0)
                        {
                            if (Engine.board.sprite[i].picnum == DefineConstants.CAMERA1)
                            {
                                Engine.board.sprite[i].yvel = 0;
                            }
                            i = Engine.board.nextspritestat[i];
                        }
                    }
                    else if (p.newowner >= 0)
                    {
                        p.newowner = -1;
                    }

                    if ((KB_KeyDown[(DefineConstants.sc_Escape)] != false))
                    {
                        KB_KeyDown[(DefineConstants.sc_Escape)] = (!(1 == 1));
                    };

                    return;
                }
            }

            if (neartagsector >= 0 && (Engine.board.sector[neartagsector].lotag & 16384) == 0 && isanearoperator(Engine.board.sector[neartagsector].lotag))
            {
                i = Engine.board.headspritesect[neartagsector];
                while (i >= 0)
                {
                    if (Engine.board.sprite[i].picnum == DefineConstants.ACTIVATOR || Engine.board.sprite[i].picnum == DefineConstants.MASTERSWITCH)
                    {
                        return;
                    }
                    i = Engine.board.nextspritesect[i];
                }
                operatesectors(neartagsector, p.i);
            }
            else if ((Engine.board.sector[Engine.board.sprite[p.i].sectnum].lotag & 16384) == 0)
            {
                if (isanunderoperator(Engine.board.sector[Engine.board.sprite[p.i].sectnum].lotag))
                {
                    i = Engine.board.headspritesect[Engine.board.sprite[p.i].sectnum];
                    while (i >= 0)
                    {
                        if (Engine.board.sprite[i].picnum == DefineConstants.ACTIVATOR || Engine.board.sprite[i].picnum == DefineConstants.MASTERSWITCH)
                        {
                            return;
                        }
                        i = Engine.board.nextspritesect[i];
                    }
                    operatesectors(Engine.board.sprite[p.i].sectnum, p.i);
                }
                else
                {
                    checkhitswitch(snum, neartagwall, (char)0);
                }
            }
        }
    }
}

