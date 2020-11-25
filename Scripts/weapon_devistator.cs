public partial class ConScript
{
    public void FireDevistator(ref int kickback_pic, int pi, short[] ammo_amount, ref int lastvisinc, ref int visibility)
    {
        if (kickback_pic != 0)
        {
            kickback_pic++;

            if ((kickback_pic & 1) != 0)
            {
                visibility = 0;
                lastvisinc = traps.totalclock() + 32;
                traps.shoot(RPG);
                ammo_amount[DEVISTATOR_WEAPON]--;
                traps.checkavailweapon();
            }
            if (kickback_pic > 5)
            {
                kickback_pic = 0;
            }
        }
    }

    private void DisplayDevistator(int weapon_xoffset, int hbomb_hold_delay, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
    {
        if (kickback_pic != 0)
        {
            int[] cycloidy = { 0, 4, 12, 24, 12, 4, 0 };

            int i = traps.sgn(kickback_pic >> 2);

            if (hbomb_hold_delay != 0)
            {
                traps.myospal((cycloidy[kickback_pic] >> 1) + weapon_xoffset + 268 - (look_ang >> 1), cycloidy[kickback_pic] + looking_arc + 238 - gun_pos, DEVISTATOR + i, -32, o, pal);
                traps.myospal(weapon_xoffset + 30 - (look_ang >> 1), looking_arc + 240 - gun_pos, DEVISTATOR, gs, o | 4, pal);
            }
            else
            {
                traps.myospal(-(cycloidy[kickback_pic] >> 1) + weapon_xoffset + 30 - (look_ang >> 1), cycloidy[kickback_pic] + looking_arc + 240 - gun_pos, DEVISTATOR + i, -32, o | 4, pal);
                traps.myospal(weapon_xoffset + 268 - (look_ang >> 1), looking_arc + 238 - gun_pos, DEVISTATOR, gs, o, pal);
            }
        }
        else
        {
            traps.myospal(weapon_xoffset + 268 - (look_ang >> 1), looking_arc + 238 - gun_pos, DEVISTATOR, gs, o, pal);
            traps.myospal(weapon_xoffset + 30 - (look_ang >> 1), looking_arc + 240 - gun_pos, DEVISTATOR, gs, o | 4, pal);
        }
    }

}