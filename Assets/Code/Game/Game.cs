using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using Build;
public partial class GlobalMembers
{
    public static int actor_tog = 0;
    public static int cameradist = 0;
    public static int cameraclock = 0;

    public static string boardfilename = "";

    public static byte[] waterpal = new byte[768];
    public static byte[] slimepal = new byte[768];
    public static byte[] titlepal = new byte[768];
    public static byte[] drealms = new byte[768];
    public static byte[] endingpal = new byte[768];

    public static void gametextpal(int x, int y, string t, char s, char p)
    {

    }

    public static void menutext(int x, int y, short s, short p, string t)
    {

    }

    public static void drawbackground()
    {

    }

    public static void opendemowrite()
    {

    }

    public static void dobonus(int bonusonly)
    {

    }

    public static void flushperms()
    {

    }
    public static void check_fta_sounds(int i)
    {

    }


    public static void gameexit(string msg)
    {
        throw new Exception(msg);
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

    public static short inventory(spritetype s)
    {
        return 0;
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

    public static short EGS(short whatsect, int s_x, int s_y, int s_z, short s_pn, int s_s, int s_xr, int s_yr, int s_a, int s_ve, int s_zv, int s_ow, int s_ss)
    {
        return 0;
    }

    public static short EGS(int whatsect, int s_x, int s_y, int s_z, short s_pn, int s_s, int s_xr, int s_yr, int s_a, int s_ve, int s_zv, int s_ow, int s_ss)
    {
        return 0;
    }


    public static void myospal(int x, int y, int tilenum, int shade, int orientation, int p)
    {
        
    }

    public static short EGS(short whatsect, long s_x, long s_y, long s_z, long s_pn, long s_s, long s_xr, long s_yr, long s_a, long s_ve, long s_zv, long s_ow, long s_ss)
    {
        return 0;
    }

    public static void myos(int x, int y, short tilenum, sbyte shade, char orientation)
    {

    }

    public static void ceilingglass(short i, short sectnum, short n)
    {

    }

    public static void spriteglass(short i, short n)
    {

    }

    public static void closedemowrite()
    {

    }

    public static int wallswitchcheck(short i)
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

        if (actortype[pn] != 0)
        {
            return 1;
        }

        return 0;
    }

    public static void Startup()
    {
        loadefs(DefineConstants.confilename);
    }

    public static void DukeMain(string commandLine)
    {
        Debug.Log("Duke Nukem 3D 1.4 - Atomic Edition");
        Debug.Log("Copyright (c) 1996 3D Realms Entertainment");

        // Load in the game data.
        Engine.initgroupfile("duke3d.grp");

        ud.multimode = 1;
        ud.last_level = -1;

        Startup();
    }
}
