using Build;
using UnityEngine;
using System;
using System.Text;
public partial class GlobalMembers
{
    internal static short g_i;
    internal static short g_p;
    internal static int g_x;
    internal static spritetype g_sp;

    internal static ConScript conScript;
    public static void loadefs(string filenam)
    {
        conScript = new ConScript();
    }

    public static void getglobalz(short i)
    {
        int hz = 0;
        int lz = 0;
        int zr = 0;

        spritetype s = Engine.board.sprite[i];

        if (s.statnum == 10 || s.statnum == 6 || s.statnum == 2 || s.statnum == 1 || s.statnum == 4)
        {
            if (s.statnum == 4)
            {
                zr = 4;
            }
            else
            {
                zr = 127;
            }

            Engine.board.getzrange(s.x, s.y, s.z - ((1 << 8)), s.sectnum, ref hittype[i].ceilingz, ref hz, ref hittype[i].floorz, ref lz, zr, (((1) << 16) + 1));

            if ((lz & 49152) == 49152 && (Engine.board.sprite[lz & (DefineConstants.MAXSPRITES - 1)].cstat & 48) == 0)
            {
                lz &= (DefineConstants.MAXSPRITES - 1);
                if (badguy(Engine.board.sprite[lz]) != 0 && Engine.board.sprite[lz].pal != 1)
                {
                    if (s.statnum != 4)
                    {
                        hittype[i].dispicnum = -4; // No shadows on actors
                        s.xvel = -256;
                        ssp(i, (uint)(((1) << 16) + 1));
                    }
                }
                else if (Engine.board.sprite[lz].picnum == DefineConstants.APLAYER && badguy(s) != 0)
                {
                    hittype[i].dispicnum = -4; // No shadows on actors
                    s.xvel = -256;
                    ssp(i, (uint)(((1) << 16) + 1));
                }
                else if (s.statnum == 4 && Engine.board.sprite[lz].picnum == DefineConstants.APLAYER)
                {
                    if (s.owner == lz)
                    {
                        hittype[i].ceilingz = Engine.board.sector[s.sectnum].ceilingz;
                        hittype[i].floorz = Engine.board.sector[s.sectnum].floorz;
                    }
                }
            }
        }
        else
        {
            hittype[i].ceilingz = Engine.board.sector[s.sectnum].ceilingz;
            hittype[i].floorz = Engine.board.sector[s.sectnum].floorz;
        }
    }

    public static void makeitfall(short i)
    {
        spritetype s = Engine.board.sprite[i];
        int hz = 0;
        int lz = 0;
        int c;

        if (floorspace(s.sectnum) != 0)
        {
            c = 0;
        }
        else
        {
            if (ceilingspace(s.sectnum) != 0 || Engine.board.sector[s.sectnum].lotag == 2)
            {
                c = gc / 6;
            }
            else
            {
                c = gc;
            }
        }

        if ((s.statnum == 1 || s.statnum == 10 || s.statnum == 2 || s.statnum == 6))
        {
            Engine.board.getzrange(s.x, s.y, s.z - ((1 << 8)), s.sectnum, ref hittype[i].ceilingz, ref hz, ref hittype[i].floorz, ref lz, 127, (((1) << 16) + 1));
        }
        else
        {
            hittype[i].ceilingz = Engine.board.sector[s.sectnum].ceilingz;
            hittype[i].floorz = Engine.board.sector[s.sectnum].floorz;
        }

        if (s.z < hittype[i].floorz - ((1 << 8)))
        {
            if (Engine.board.sector[s.sectnum].lotag == 2 && s.zvel > 3122)
            {
                s.zvel = 3144;
            }
            if (s.zvel < 6144)
            {
                s.zvel += (short)c;
            }
            else
            {
                s.zvel = 6144;
            }
            s.z += s.zvel;
        }
        if (s.z >= hittype[i].floorz - ((1 << 8)))
        {
            s.z = hittype[i].floorz - (1 << 8);
            s.zvel = 0;
        }
    }
    public static short getincangle(short a, short na)
    {
        a &= 2047;
        na &= 2047;

        if (pragmas.klabs(a - na) < 1024)
            return (short)(na - a);
        else
        {
            if (na > 1024) na -= 2048;
            if (a > 1024) a -= 2048;

            na -= 2048;
            a -= 2048;
            return (short)(na - a);
        }
    }

    public static int dodge(spritetype s)
    {
        int i;
        int bx;
        int by;
        int mx;
        int my;
        int bxvect;
        int byvect;
        int mxvect;
        int myvect;
        int d;

        mx = s.x;
        my = s.y;
        mxvect = Engine.table.sintable[(s.ang + 512) & 2047];
        myvect = Engine.table.sintable[s.ang & 2047];

        for (i = Engine.board.headspritestat[4]; i >= 0; i = Engine.board.nextspritestat[i]) //weapons list
        {
            if (Engine.board.sprite[i].owner == i || Engine.board.sprite[i].sectnum != s.sectnum)
            {
                continue;
            }

            bx = Engine.board.sprite[i].x - mx;
            by = Engine.board.sprite[i].y - my;
            bxvect = Engine.table.sintable[(Engine.board.sprite[i].ang + 512) & 2047];
            byvect = Engine.table.sintable[Engine.board.sprite[i].ang & 2047];

            if (mxvect * bx + myvect * by >= 0)
            {
                if (bxvect * bx + byvect * by < 0)
                {
                    d = bxvect * by - byvect * bx;
                    if (pragmas.klabs(d) < 65536 * 64)
                    {
                        s.ang -= (short)(512 + (Engine.krand() & 1024));
                        return 1;
                    }
                }
            }
        }
        return 0;
    }

    public static short furthestangle(short i, short angs)
    {
        short j = 0;
        int hitsect = 0;
        short hitwall = 0;
        short hitspr = 0;
        short furthest_angle = 0;
        short angincs = 0;
        int hx = 0;
        int hy = 0;
        int hz = 0;
        int d = 0;
        int greatestd = 0;
        spritetype s = Engine.board.sprite[i];

        greatestd = -(1 << 30);
        angincs = (short)(2048 / angs);

        if (s.picnum != DefineConstants.APLAYER)
        {
            if ((hittype[g_i].count & 63) > 2)
            {
                return (short)(s.ang + 1024);
            }
        }

        for (j = s.ang; j < (2048 + s.ang); j += angincs)
        {
            Engine.board.hitscan(s.x, s.y, s.z - (8 << 8), s.sectnum, Engine.table.sintable[(j + 512) & 2047], Engine.table.sintable[j & 2047], 0, ref hitsect, ref hitwall, ref hitspr, ref hx, ref hy, ref hz, (((256) << 16) + 64));

            d = pragmas.klabs(hx - s.x) + pragmas.klabs(hy - s.y);

            if (d > greatestd)
            {
                greatestd = d;
                furthest_angle = j;
            }
        }
        return (short)(furthest_angle & 2047);
    }

    public static short furthestcanseepoint(short i, spritetype ts, ref int dax, ref int day)
    {
        short j = 0;
        int hitsect = 0;
        short hitwall = 0;
        short hitspr = 0;
        short angincs = 0;
        short tempang = 0;
        int hx = 0; //, d, cd, ca,tempx,tempy,cx,cy;
        int hy = 0;
        int hz = 0;
        int d = 0;
        int da = 0;
        spritetype s = Engine.board.sprite[i];

        if ((hittype[g_i].count & 63) != 0)
        {
            return -1;
        }

        if (ud.multimode < 2 && ud.player_skill < 3)
        {
            angincs = (short)(2048 / 2);
        }
        else
        {
            angincs = (short)(2048 / (1 + (Engine.krand() & 1)));
        }

        for (j = ts.ang; j < (2048 + ts.ang); j += (short)(angincs - (Engine.krand() & 511)))
        {
            Engine.board.hitscan(ts.x, ts.y, ts.z - (16 << 8), ts.sectnum, Engine.table.sintable[(j + 512) & 2047], Engine.table.sintable[j & 2047], (int)(16384 - (Engine.krand() & 32767)), ref hitsect, ref hitwall, ref hitspr, ref hx, ref hy, ref hz, (((256) << 16) + 64));

            d = pragmas.klabs(hx - ts.x) + pragmas.klabs(hy - ts.y);
            da = pragmas.klabs(hx - s.x) + pragmas.klabs(hy - s.y);

            if (d < da)
            {
                if (Engine.board.cansee(hx, hy, hz, (short)hitsect, s.x, s.y, s.z - (16 << 8), s.sectnum))
                {
                    dax = hx;
                    day = hy;
                    return (short)hitsect;
                }
            }
        }
        return -1;
    }

    public static void alterang(short a)
    {
        short aang;
        short angdif;
        short goalang;
        short j;
        int ticselapsed;

        ticselapsed = (hittype[g_i].count) & 31;

        aang = g_sp.ang;

        g_sp.xvel += (short)((hittype[g_i].count - g_sp.xvel) / 5);
        if (g_sp.zvel < 648)
        {
            g_sp.zvel += (short)(((hittype[g_i].moveAction.GetIndex(0) << 4) - g_sp.zvel) / 5);
        }

        if ((a & DefineConstants.seekplayer) != 0)
        {
            j = ps[g_p].holoduke_on;

            if (j >= 0 && Engine.board.cansee(Engine.board.sprite[j].x, Engine.board.sprite[j].y, Engine.board.sprite[j].z, Engine.board.sprite[j].sectnum, g_sp.x, g_sp.y, g_sp.z, g_sp.sectnum))
            {
                g_sp.owner = j;
            }
            else
            {
                g_sp.owner = ps[g_p].i;
            }

            if (Engine.board.sprite[g_sp.owner].picnum == DefineConstants.APLAYER)
            {
                goalang = (short)Engine.getangle(hittype[g_i].lastvx - g_sp.x, hittype[g_i].lastvy - g_sp.y);
            }
            else
            {
                goalang = (short)Engine.getangle(Engine.board.sprite[g_sp.owner].x - g_sp.x, Engine.board.sprite[g_sp.owner].y - g_sp.y);
            }

            if (g_sp.xvel != 0 && g_sp.picnum != DefineConstants.DRONE)
            {
                angdif = getincangle(aang, goalang);

                if (ticselapsed < 2)
                {
                    if (pragmas.klabs(angdif) < 256)
                    {
                        j = (short)(128 - (Engine.krand() & 256));
                        g_sp.ang += j;
                        if (hits(g_i) < 844)
                        {
                            g_sp.ang -= j;
                        }
                    }
                }
                else if (ticselapsed > 18 && ticselapsed < 26) // choose
                {
                    if (pragmas.klabs(angdif >> 2) < 128)
                    {
                        g_sp.ang = goalang;
                    }
                    else
                    {
                        g_sp.ang += (short)(angdif >> 2);
                    }
                }
            }
            else
            {
                g_sp.ang = goalang;
            }
        }

        if (ticselapsed < 1)
        {
            j = 2;
            if ((a & DefineConstants.furthestdir) != 0)
            {
                goalang = furthestangle(g_i, j);
                g_sp.ang = goalang;
                g_sp.owner = ps[g_p].i;
            }

            if ((a & DefineConstants.fleeenemy) != 0)
            {
                goalang = furthestangle(g_i, j);
                g_sp.ang = goalang; // += angdif; //  = getincangle(aang,goalang)>>1;
            }
        }
    }

    public static void move()
    {
        int l;
        short j;
        short a;
        short goalang;
        short angdif;
        int daxvel;

        a = g_sp.hitag;

        if (a == -1)
        {
            a = 0;
        }

        hittype[g_i].count++;

        if ((a & DefineConstants.face_player) != 0)
        {
            if (ps[g_p].newowner >= 0)
            {
                goalang = (short)Engine.getangle(ps[g_p].oposx - g_sp.x, ps[g_p].oposy - g_sp.y);
            }
            else
            {
                goalang = (short)Engine.getangle(ps[g_p].posx - g_sp.x, ps[g_p].posy - g_sp.y);
            }
            angdif = (short)(getincangle(g_sp.ang, goalang) >> 2);
            if (angdif > -8 && angdif < 0)
            {
                angdif = 0;
            }
            g_sp.ang += angdif;
        }

        if ((a & DefineConstants.spin) != 0)
        {
            g_sp.ang += (short)(Engine.table.sintable[((hittype[g_i].count << 3) & 2047)] >> 6);
        }

        if ((a & DefineConstants.face_player_slow) != 0)
        {
            if (ps[g_p].newowner >= 0)
            {
                goalang = (short)Engine.getangle(ps[g_p].oposx - g_sp.x, ps[g_p].oposy - g_sp.y);
            }
            else
            {
                goalang = (short)Engine.getangle(ps[g_p].posx - g_sp.x, ps[g_p].posy - g_sp.y);
            }
            angdif = (short)(pragmas.ksgn(getincangle(g_sp.ang, goalang)) << 5);
            if (angdif > -32 && angdif < 0)
            {
                angdif = 0;
                g_sp.ang = goalang;
            }
            g_sp.ang += angdif;
        }


        if ((a & DefineConstants.jumptoplayer) == DefineConstants.jumptoplayer)
        {
            if (hittype[g_i].count < 16)
            {
                g_sp.zvel -= (short)((Engine.table.sintable[(512 + (hittype[g_i].count << 4)) & 2047] >> 5));
            }
        }

        if ((a & DefineConstants.face_player_smart) != 0)
        {
            int newx;
            int newy;

            newx = ps[g_p].posx + (ps[g_p].posxv / 768);
            newy = ps[g_p].posy + (ps[g_p].posyv / 768);
            goalang = (short)Engine.getangle(newx - g_sp.x, newy - g_sp.y);
            angdif = (short)(getincangle(g_sp.ang, goalang) >> 2);
            if (angdif > -8 && angdif < 0)
            {
                angdif = 0;
            }
            g_sp.ang += angdif;
        }

        if (hittype[g_i].moveAction == null || hittype[g_i].moveAction.GetIndex(0) == 0 || a == 0)
        {
            if ((badguy(g_sp) != 0 && g_sp.extra <= 0) || (hittype[g_i].bposx != g_sp.x) || (hittype[g_i].bposy != g_sp.y))
            {
                hittype[g_i].bposx = g_sp.x;
                hittype[g_i].bposy = g_sp.y;
                Engine.board.setsprite(g_i, g_sp.x, g_sp.y, g_sp.z);
            }
            return;
        }

        ConActions.MoveAction moveptr = (ConActions.MoveAction)hittype[g_i].moveAction;

        if ((a & DefineConstants.geth) != 0)
        {
            g_sp.xvel += (short)((moveptr.horizontal - g_sp.xvel) >> 1);
        }
        if ((a & DefineConstants.getv) != 0)
        {
            g_sp.zvel += (short)(((moveptr.vertical << 4) - g_sp.zvel) >> 1);
        }

        if ((a & DefineConstants.dodgebullet) != 0)
        {
            dodge(g_sp);
        }

        if (g_sp.picnum != DefineConstants.APLAYER)
        {
            alterang(a);
        }

        if (g_sp.xvel > -6 && g_sp.xvel < 6)
        {
            g_sp.xvel = 0;
        }

        a = badguy(g_sp);

        if (g_sp.xvel != 0 || g_sp.zvel != 0)
        {
            if (a != 0 && g_sp.picnum != DefineConstants.ROTATEGUN)
            {
                if ((g_sp.picnum == DefineConstants.DRONE || g_sp.picnum == DefineConstants.COMMANDER) && g_sp.extra > 0)
                {
                    if (g_sp.picnum == DefineConstants.COMMANDER)
                    {
                        hittype[g_i].floorz = l = Engine.board.getflorzofslope(g_sp.sectnum, g_sp.x, g_sp.y);
                        if (g_sp.z > (l - (8 << 8)))
                        {
                            if (g_sp.z > (l - (8 << 8)))
                            {
                                g_sp.z = l - (8 << 8);
                            }
                            g_sp.zvel = 0;
                        }

                        hittype[g_i].ceilingz = l = Engine.board.getceilzofslope(g_sp.sectnum, g_sp.x, g_sp.y);
                        if ((g_sp.z - l) < (80 << 8))
                        {
                            g_sp.z = l + (80 << 8);
                            g_sp.zvel = 0;
                        }
                    }
                    else
                    {
                        if (g_sp.zvel > 0)
                        {
                            hittype[g_i].floorz = l = Engine.board.getflorzofslope(g_sp.sectnum, g_sp.x, g_sp.y);
                            if (g_sp.z > (l - (30 << 8)))
                            {
                                g_sp.z = l - (30 << 8);
                            }
                        }
                        else
                        {
                            hittype[g_i].ceilingz = l = Engine.board.getceilzofslope(g_sp.sectnum, g_sp.x, g_sp.y);
                            if ((g_sp.z - l) < (50 << 8))
                            {
                                g_sp.z = l + (50 << 8);
                                g_sp.zvel = 0;
                            }
                        }
                    }
                }
                else if (g_sp.picnum != DefineConstants.ORGANTIC)
                {
                    if (g_sp.zvel > 0 && hittype[g_i].floorz < g_sp.z)
                    {
                        g_sp.z = hittype[g_i].floorz;
                    }
                    if (g_sp.zvel < 0)
                    {
                        l = Engine.board.getceilzofslope(g_sp.sectnum, g_sp.x, g_sp.y);
                        if ((g_sp.z - l) < (66 << 8))
                        {
                            g_sp.z = l + (66 << 8);
                            g_sp.zvel >>= 1;
                        }
                    }
                }
            }
            else if (g_sp.picnum == DefineConstants.APLAYER)
            {
                if ((g_sp.z - hittype[g_i].ceilingz) < (32 << 8))
                {
                    g_sp.z = hittype[g_i].ceilingz + (32 << 8);
                }
            }

            daxvel = g_sp.xvel;
            angdif = g_sp.ang;

            if (a != 0 && g_sp.picnum != DefineConstants.ROTATEGUN)
            {
                if (g_x < 960 && g_sp.xrepeat > 16)
                {

                    daxvel = -(1024 - g_x);
                    angdif = (short)Engine.getangle(ps[g_p].posx - g_sp.x, ps[g_p].posy - g_sp.y);

                    if (g_x < 512)
                    {
                        ps[g_p].posxv = 0;
                        ps[g_p].posyv = 0;
                    }
                    else
                    {
                        ps[g_p].posxv = pragmas.mulscale(ps[g_p].posxv, dukefriction - 0x2000, 16);
                        ps[g_p].posyv = pragmas.mulscale(ps[g_p].posyv, dukefriction - 0x2000, 16);
                    }
                }
                else if (g_sp.picnum != DefineConstants.DRONE && g_sp.picnum != DefineConstants.SHARK && g_sp.picnum != DefineConstants.COMMANDER)
                {
                    if (hittype[g_i].bposz != g_sp.z || (ud.multimode < 2 && ud.player_skill < 2))
                    {
                        if ((hittype[g_i].count & 1) != 0 || ps[g_p].actorsqu == g_i)
                        {
                            return;
                        }
                        else
                        {
                            daxvel <<= 1;
                        }
                    }
                    else
                    {
                        if ((hittype[g_i].count & 3) != 0 || ps[g_p].actorsqu == g_i)
                        {
                            return;
                        }
                        else
                        {
                            daxvel <<= 2;
                        }
                    }
                }
            }

            hittype[g_i].movflag = (short)movesprite(g_i, (daxvel * (Engine.table.sintable[(angdif + 512) & 2047])) >> 14, (daxvel * (Engine.table.sintable[angdif & 2047])) >> 14, g_sp.zvel, (uint)(((1) << 16) + 1));
        }

        if (a != 0)
        {
            if ((Engine.board.sector[g_sp.sectnum].ceilingstat & 1) != 0)
            {
                g_sp.shade += (sbyte)((Engine.board.sector[g_sp.sectnum].ceilingshade - g_sp.shade) >> 1);
            }
            else
            {
                g_sp.shade += (sbyte)((Engine.board.sector[g_sp.sectnum].floorshade - g_sp.shade) >> 1);
            }

            if (Engine.board.sector[g_sp.sectnum].floorpicnum == DefineConstants.MIRROR)
            {
                Engine.board.deletesprite(g_i);
            }
        }
    }


    public static void execute(int i, short p, int x)
    {
        char done;

        g_i = (short)i;
        g_p = p;
        g_x = x;
        g_sp = Engine.board.sprite[g_i];

        if (GlobalMembers.scriptActorRegPtr[g_sp.picnum] == null)
        {
            return;
        }

        actorscrptr[g_sp.picnum] = hittype[g_i];

        //insptr = 4 + ();

        killit_flag = (char)0;

        if (g_sp.sectnum < 0 || g_sp.sectnum >= DefineConstants.MAXSECTORS)
        {
            if (badguy(g_sp) != 0)
            {
                ps[g_p].actors_killed++;
            }
            Engine.board.deletesprite(g_i);
            return;
        }
        // jmarshall: eval
        /*
        if (g_t[4] != 0)
        {
            g_sp.lotag += (DefineConstants.TICRATE / 26);
            if (g_sp.lotag > scriptptr.buffer[g_t[4] + 16])
            {
                hittype[g_i].actioncount++;
                g_sp.lotag = 0;
                hittype[g_i].animcounter += scriptptr.buffer[(g_t[4] + 12)];
            }
            if (pragmas.klabs(hittype[g_i].animcounter) >= pragmas.klabs(scriptptr.buffer[(g_t[4] + 4)] * scriptptr.buffer[(g_t[4] + 12)]))
            {
                hittype[g_i].animcounter = 0;
            }
        }
        */

        if (hittype[g_i].action != null)
        {
            GlobalMembers.ConActions.ConAction action = hittype[g_i].action;
            g_sp.lotag += (DefineConstants.TICRATE / 26);
            if(g_sp.lotag > action.delay)
            {
                g_sp.lotag = 0;
                hittype[g_i].actioncount++;
                hittype[g_i].animcounter += action.invvalue;
                if (pragmas.klabs(hittype[g_i].animcounter) >= pragmas.klabs(action.frames * action.invvalue))
                {
                    hittype[g_i].animcounter = 0;
                }
            }

            
        }
 // jmarshall end
        GlobalMembers.scriptActorRegPtr[g_sp.picnum].func();

        if (killit_flag == 1)
        {
            if (ps[g_p].actorsqu == g_i)
            {
                ps[g_p].actorsqu = -1;
            }
            Engine.board.deletesprite(g_i);
        }
        else
        {
            move();

            if (g_sp.statnum == 1)
            {
                if (badguy(g_sp) != 0)
                {
                    if (g_sp.xrepeat > 60)
                    {
                        return;
                    }
                    if (ud.respawn_monsters == 1 && g_sp.extra <= 0)
                    {
                        return;
                    }
                }
                else if (ud.respawn_items == 1 && (g_sp.cstat & 32768) != 0)
                {
                    return;
                }

                if (hittype[g_i].timetosleep > 1)
                {
                    hittype[g_i].timetosleep--;
                }
                else if (hittype[g_i].timetosleep == 1)
                {
                    Engine.board.changespritestat(g_i, 2);
                }
            }

            else if (g_sp.statnum == 6)
            {
                switch (g_sp.picnum)
                {
                    case DefineConstants.RUBBERCAN:
                    case DefineConstants.EXPLODINGBARREL:
                    case DefineConstants.WOODENHORSE:
                    case DefineConstants.HORSEONSIDE:
                    case DefineConstants.CANWITHSOMETHING:
                    case DefineConstants.FIREBARREL:
                    case DefineConstants.NUKEBARREL:
                    case DefineConstants.NUKEBARRELDENTED:
                    case DefineConstants.NUKEBARRELLEAKED:
                    case DefineConstants.TRIPBOMB:
                    case DefineConstants.EGG:
                        if (hittype[g_i].timetosleep > 1)
                        {
                            hittype[g_i].timetosleep--;
                        }
                        else if (hittype[g_i].timetosleep == 1)
                        {
                            Engine.board.changespritestat(g_i, 2);
                        }
                        break;
                }
            }
        }
    }
}