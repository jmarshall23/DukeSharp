using Build;
public partial class GlobalMembers
{
    public static void check_fta_sounds(int i)
    {

    }

    public static void execute(int i, short p, int x)
    {

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


    public static void getglobalz(int i)
    {
       
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

}