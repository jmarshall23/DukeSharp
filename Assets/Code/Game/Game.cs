using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Build;
public partial class GlobalMembers
{
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

        Engine.board.hitscan(Engine.board.sprite[i].x, Engine.board.sprite[i].y, Engine.board.sprite[i].z - zoff, Engine.board.sprite[i].sectnum, Engine.table.sintable[(Engine.board.sprite[i].ang + 512) & 2047], Engine.table.sintable[Engine.board.sprite[i].ang & 2047], 0, ref sect,ref  hw,ref hs, ref sx, ref sy, ref sz, (((256) << 16) + 64));

        return (Engine.FindDistance2D(sx - Engine.board.sprite[i].x, sy - Engine.board.sprite[i].y));
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


    public static short spawn(short j, short pn)
    {
        return 0;
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

    public static void lotsofglass(short i, short wallnum, short n)
    {
     
    }

    public static void lotsofcolourglass(short i, short wallnum, short n)
    {

    }

    public static void lotsofmoney(spritetype x, int y)
    {

    }

    public static void shoot(int x, int y)
    {

    }

    public static short EGS(short whatsect, int s_x, int s_y, int s_z, short s_pn, int s_s, int s_xr, int s_yr, int s_a, int s_ve, int s_zv, int s_ow, int s_ss)
    {
        return 0;
    }

    public static void ceilingglass(short i, short sectnum, short n)
    {

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
            case DefineConstants.GREENSLIME + 1:
            case DefineConstants.GREENSLIME + 2:
            case DefineConstants.GREENSLIME + 3:
            case DefineConstants.GREENSLIME + 4:
            case DefineConstants.GREENSLIME + 5:
            case DefineConstants.GREENSLIME + 6:
            case DefineConstants.GREENSLIME + 7:
            case DefineConstants.RAT:
            case DefineConstants.ROTATEGUN:
                return 1;
        }
        if (actortype[s.picnum].Length != 0)
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
            case DefineConstants.GREENSLIME + 1:
            case DefineConstants.GREENSLIME + 2:
            case DefineConstants.GREENSLIME + 3:
            case DefineConstants.GREENSLIME + 4:
            case DefineConstants.GREENSLIME + 5:
            case DefineConstants.GREENSLIME + 6:
            case DefineConstants.GREENSLIME + 7:
            case DefineConstants.RAT:
            case DefineConstants.ROTATEGUN:
                return 1;
        }

        if (actortype[pn].Length != 0)
        {
            return 1;
        }

        return 0;
    }
}
