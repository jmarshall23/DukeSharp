public partial class ConScript
{
    public void FireShrinkGrow(ref char pus, int screenpeek, int snum, int currentWeapon, ref int kickback_pic, int pi, short[] ammo_amount, ref int lastvisinc, ref int visibility)
    {
        if (currentWeapon == GROW_WEAPON)
        {
            if (kickback_pic > 3)
            {
                kickback_pic = 0;
                if (screenpeek == snum)
                {
                    pus = (char)1;
                }
                ammo_amount[GROW_WEAPON]--;
                traps.shoot(GROWSPARK);

                visibility = 0;
                lastvisinc = traps.totalclock() + 32;
                traps.checkavailweapon();
            }
            else
            {
                kickback_pic++;
            }
        }
        else
        {
            if (kickback_pic > 10)
            {
                kickback_pic = 0;

                ammo_amount[SHRINKER_WEAPON]--;
                traps.shoot(SHRINKER);

                visibility = 0;
                lastvisinc = traps.totalclock() + 32;
                traps.checkavailweapon();
            }
            else
            {
                kickback_pic++;
            }
        }
    }

    private void DisplayShrinkGrow(int cw, int random_club_frame, int p_i, int weapon_xoffset, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
    {
        weapon_xoffset += 28;
        looking_arc += 18;

        if (kickback_pic == null)
        {
            if (cw == GROW_WEAPON)
            {
                traps.myospal(weapon_xoffset + 184 - (look_ang >> 1), looking_arc + 240 - gun_pos, SHRINKER + 2, (sbyte)(16 - (traps.sintable(random_club_frame & 2047) >> 10)), o, 2);

                traps.myospal(weapon_xoffset + 188 - (look_ang >> 1), looking_arc + 240 - gun_pos, SHRINKER - 2, gs, o, pal);
            }
            else
            {
                traps.myospal(weapon_xoffset + 184 - (look_ang >> 1), looking_arc + 240 - gun_pos, SHRINKER + 2, (sbyte)(16 - (traps.sintable(random_club_frame & 2047) >> 10)), o, 0);

                traps.myospal(weapon_xoffset + 188 - (look_ang >> 1), looking_arc + 240 - gun_pos, SHRINKER, gs, o, pal);
            }
        }
        else
        {
            if (traps.getspritepal(p_i) != 1)
            {
                weapon_xoffset += (short)(traps.krand() & 3);
                gun_pos += (short)(traps.krand() & 3);
            }

            if (cw == GROW_WEAPON)
            {
                traps.myospal(weapon_xoffset + 184 - (look_ang >> 1), looking_arc + 240 - gun_pos, SHRINKER + 3 + (kickback_pic & 3), -32, o, 2);

                traps.myospal(weapon_xoffset + 188 - (look_ang >> 1), looking_arc + 240 - gun_pos, SHRINKER - 1, gs, o, pal);

            }
            else
            {
                traps.myospal(weapon_xoffset + 184 - (look_ang >> 1), looking_arc + 240 - gun_pos, SHRINKER + 3 + (kickback_pic & 3), -32, o, 0);

                traps.myospal(weapon_xoffset + 188 - (look_ang >> 1), looking_arc + 240 - gun_pos, SHRINKER + 1, gs, o, pal);
            }
        }
    }
}