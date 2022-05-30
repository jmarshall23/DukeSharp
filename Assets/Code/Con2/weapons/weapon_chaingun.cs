public partial class ConScript
{
    private void FireChaingun(int sb_snum, ref int kickback_pic, int pi, short[] ammo_amount, ref int lastvisinc, ref int visibility)
    {
        kickback_pic++;

        if ((kickback_pic) <= 12)
        {
            if (((kickback_pic) % 3) == 0)
            {
                ammo_amount[CHAINGUN_WEAPON]--;

                if (((kickback_pic) % 3) == 0)
                {
                    int j = traps.spawn(SHELL);

                    //Engine.board.sprite[j].ang += 1024;
                    //Engine.board.sprite[j].ang &= 2047;
                    //Engine.board.sprite[j].xvel += 32;
                    //Engine.board.sprite[j].z += (3 << 8);
                    traps.chaingunprojectileshift(j);
                    traps.ssp((short)j, (uint)(((1) << 16) + 1));
                }

                traps.sound(CHAINGUN_FIRE);
                traps.shoot(CHAINGUN);
                lastvisinc = traps.totalclock() + 32;
                visibility = 0;
                traps.checkavailweapon();

                if ((sb_snum & (1 << 2)) == 0)
                {
                    kickback_pic = 0;
                    return;
                }
            }
        }
        else if (kickback_pic > 10)
        {
            if ((sb_snum & (1 << 2)) != 0)
            {
                kickback_pic = 1;
            }
            else
            {
                kickback_pic = 0;
            }
        }
    }

    private void DisplayChaingun(int p_i, int weapon_xoffset, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
    {
        int f = 0;
        if (kickback_pic > 0)
        {
            gun_pos -= traps.sintable(kickback_pic << 7) >> 12;
        }

        if (kickback_pic > 0 && traps.getspritepal(p_i) != 1)
        {
            weapon_xoffset += (short)(1 - (traps.krand() & 3));
        }

        traps.myospal(weapon_xoffset + 168 - (look_ang >> 1), looking_arc + 260 - gun_pos, CHAINGUN, gs, o, pal);
        switch (kickback_pic)
        {
            case 0:
                traps.myospal(weapon_xoffset + 178 - (look_ang >> 1), looking_arc + 233 - gun_pos, CHAINGUN + 1, gs, o, pal);
                break;
            default:
                if (kickback_pic > 4 && kickback_pic < 12)
                {
                    f = 0;
                    if (traps.getspritepal(p_i) != 1)
                    {
                        f = (short)(traps.krand() & 7);
                    }
                    traps.myospal(f + weapon_xoffset - 4 + 140 - (look_ang >> 1), f + looking_arc - (kickback_pic >> 1) + 208 - gun_pos, CHAINGUN + 5 + ((kickback_pic - 4) / 5), gs, o, pal);
                    if (traps.getspritepal(p_i) != 1)
                    {
                        f = (short)(traps.krand() & 7);
                    }
                    traps.myospal(f + weapon_xoffset - 4 + 184 - (look_ang >> 1), f + looking_arc - (kickback_pic >> 1) + 208 - gun_pos, CHAINGUN + 5 + ((kickback_pic - 4) / 5), gs, o, pal);
                }
                if (kickback_pic < 8)
                {
                    f = (short)(traps.krand() & 7);
                    traps.myospal(f + weapon_xoffset - 4 + 162 - (look_ang >> 1), f + looking_arc - (kickback_pic >> 1) + 208 - gun_pos, CHAINGUN + 5 + ((kickback_pic - 2) / 5), gs, o, pal);
                    traps.myospal(weapon_xoffset + 178 - (look_ang >> 1), looking_arc + 233 - gun_pos, CHAINGUN + 1 + (kickback_pic >> 1), gs, o, pal);
                }
                else
                {
                    traps.myospal(weapon_xoffset + 178 - (look_ang >> 1), looking_arc + 233 - gun_pos, CHAINGUN + 1, gs, o, pal);
                }
                break;
        }
    }

}