public partial class ConScript
{

    private void FireFreeze(int xrepeat, int sb_snum, ref int kickback_pic, int pi, short[] ammo_amount, ref int lastvisinc, ref int visibility)
    {
        if (kickback_pic < 4)
        {
            kickback_pic++;
            if (kickback_pic == 3)
            {
                ammo_amount[FREEZE_WEAPON]--;
                visibility = 0;
                lastvisinc = traps.totalclock() + 32;
                traps.shoot(FREEZEBLAST);
                traps.checkavailweapon();
            }
            if (xrepeat < 32)
            {
                kickback_pic = 0;
                return;
            }
        }
        else
        {
            if ((sb_snum & (1 << 2)) != 0)
            {
                kickback_pic = 1;
                traps.sound(CAT_FIRE);
            }
            else
            {
                kickback_pic = 0;
            }
        }
    }

    private void DisplayFreeze(int p_i, int weapon_xoffset, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
    {
        if (kickback_pic != 0)
        {
            int[] cat_frames = { 0, 0, 1, 1, 2, 2 };

            if (traps.getspritepal(p_i) != 1)
            {
                weapon_xoffset += (short)(traps.krand() & 3);
                looking_arc += (short)(traps.krand() & 3);
            }
            gun_pos -= 16;
            traps.myospal(weapon_xoffset + 210 - (look_ang >> 1), looking_arc + 261 - gun_pos, FREEZE + 2, -32, o, pal);
            traps.myospal(weapon_xoffset + 210 - (look_ang >> 1), looking_arc + 235 - gun_pos, FREEZE + 3 + cat_frames[kickback_pic % 6], -32, o, pal);
        }
        else
        {
            traps.myospal(weapon_xoffset + 210 - (look_ang >> 1), looking_arc + 261 - gun_pos, FREEZE, gs, o, pal);
        }
    }
}