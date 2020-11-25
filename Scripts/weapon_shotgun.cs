public partial class ConScript
{
    private void FireShotgun(ref int kickback_pic, int pi, short[] ammo_amount, ref int lastvisinc, ref int visibility)
    {
        int j;

        kickback_pic++;

        if (kickback_pic == 4)
        {
            traps.shoot(SHOTGUN);
            traps.shoot(SHOTGUN);
            traps.shoot(SHOTGUN);
            traps.shoot(SHOTGUN);
            traps.shoot(SHOTGUN);
            traps.shoot(SHOTGUN);
            traps.shoot(SHOTGUN);

            ammo_amount[SHOTGUN_WEAPON]--;

            traps.sound(SHOTGUN_FIRE);

            lastvisinc = traps.totalclock() + 32;
            visibility = 0;
        }

        switch (kickback_pic)
        {
            case 13:
                traps.checkavailweapon();
                break;
            case 15:
                traps.sound(SHOTGUN_COCK);
                break;
            case 17:
            case 20:
                kickback_pic++;
                break;
            case 24:
                j = traps.spawn(SHOTGUNSHELL);
                traps.adjustspriteang(j, 1024);//Engine.board.sprite[j].ang += 1024;
                traps.ssp((short)j, (uint)(((1) << 16) + 1));
                traps.adjustspriteang(j, 1024); //Engine.board.sprite[j].ang += 1024;
                kickback_pic++;
                break;
            case 31:
                kickback_pic = 0;
                return;
        }
    }
    private void DisplayShotgun(int weapon_xoffset, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
    {
        weapon_xoffset -= 8;

        switch (kickback_pic)
        {
            case 1:
            case 2:
                traps.myospal(weapon_xoffset + 168 - (look_ang >> 1), looking_arc + 201 - gun_pos, SHOTGUN + 2, -128, o, pal);
                goto case 0;
            case 0:
            case 6:
            case 7:
            case 8:
                traps.myospal(weapon_xoffset + 146 - (look_ang >> 1), looking_arc + 202 - gun_pos, SHOTGUN, gs, o, pal);
                break;
            case 3:
            case 4:
            case 5:
            case 9:
            case 10:
            case 11:
            case 12:
                if (kickback_pic > 1 && kickback_pic < 5)
                {
                    gun_pos -= 40;
                    weapon_xoffset += 20;

                    traps.myospal(weapon_xoffset + 178 - (look_ang >> 1), looking_arc + 194 - gun_pos, SHOTGUN + 1 + (((kickback_pic) - 1) >> 1), -128, o, pal);
                }

                traps.myospal(weapon_xoffset + 158 - (look_ang >> 1), looking_arc + 220 - gun_pos, SHOTGUN + 3, gs, o, pal);

                break;
            case 13:
            case 14:
            case 15:
                traps.myospal(32 + weapon_xoffset + 166 - (look_ang >> 1), looking_arc + 210 - gun_pos, SHOTGUN + 4, gs, o, pal);
                break;
            case 16:
            case 17:
            case 18:
            case 19:
                traps.myospal(64 + weapon_xoffset + 170 - (look_ang >> 1), looking_arc + 196 - gun_pos, SHOTGUN + 5, gs, o, pal);
                break;
            case 20:
            case 21:
            case 22:
            case 23:
                traps.myospal(64 + weapon_xoffset + 176 - (look_ang >> 1), looking_arc + 196 - gun_pos, SHOTGUN + 6, gs, o, pal);
                break;
            case 24:
            case 25:
            case 26:
            case 27:
                traps.myospal(64 + weapon_xoffset + 170 - (look_ang >> 1), looking_arc + 196 - gun_pos, SHOTGUN + 5, gs, o, pal);
                break;
            case 28:
            case 29:
            case 30:
                traps.myospal(32 + weapon_xoffset + 156 - (look_ang >> 1), looking_arc + 206 - gun_pos, SHOTGUN + 4, gs, o, pal);
                break;
        }
    }
}