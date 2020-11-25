public partial class ConScript
{
    private void FireKnee(int sb_snum, int wantweaponfire, ref int kickback_pic, int pi, short[] ammo_amount, ref int lastvisinc, ref int visibility)
    {
        kickback_pic++;

        if (kickback_pic == 7)
        {
            traps.shoot(KNEE);
        }
        else if (kickback_pic == 14)
        {
            if ((sb_snum & (1 << 2)) != 0)
            {
                kickback_pic = (short)(1 + (traps.krand() & 3));
            }
            else
            {
                kickback_pic = 0;
            }
        }

        if (wantweaponfire >= 0)
        {
            traps.checkavailweapon();
        }
    }


    private void DisplayKnee(int p_i, int weapon_xoffset, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
    {
        if (kickback_pic <= 0)
            return;

        if (kickback_pic < 5 || kickback_pic > 9)
        {
            traps.myospal(weapon_xoffset + 220 - (look_ang >> 1), looking_arc + 250 - gun_pos, KNEE, gs, o, pal);
        }
        else
        {
            traps.myospal(weapon_xoffset + 160 - (look_ang >> 1), looking_arc + 214 - gun_pos, KNEE + 1, gs, o, pal);
        }
    }

}