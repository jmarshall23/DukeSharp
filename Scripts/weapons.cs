public partial class ConScript
{
    public void Event_DisplayWeapon(int currentWeapon, int random_club_frame, int hbomb_hold_delay, int p_i, int weapon_xoffset, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
    {
        switch(currentWeapon)
        {
            case TRIPBOMB_WEAPON:
                DisplayTriBomb(weapon_xoffset, look_ang, looking_arc, kickback_pic, gun_pos, gs, o, pal);
                break;

            case HANDREMOTE_WEAPON:
                DisplayHandRemote(weapon_xoffset, look_ang, looking_arc, kickback_pic, gun_pos, gs, o, pal);
                break;
            case SHRINKER_WEAPON:
            case GROW_WEAPON:
                DisplayShrinkGrow(currentWeapon, random_club_frame, p_i, weapon_xoffset, look_ang, looking_arc, kickback_pic, gun_pos, gs, o, pal);
                break;

            case FREEZE_WEAPON:
                DisplayFreeze(p_i, weapon_xoffset, look_ang, looking_arc, kickback_pic, gun_pos, gs, o, pal);
                break;
            case DEVISTATOR_WEAPON:
                DisplayDevistator(weapon_xoffset, hbomb_hold_delay, look_ang, looking_arc, kickback_pic, gun_pos, gs, o, pal);
                break;
            case PISTOL_WEAPON:
                DisplayPistol(weapon_xoffset, look_ang, looking_arc, kickback_pic, gun_pos, gs, o, pal);
                break;

            case SHOTGUN_WEAPON:
                DisplayShotgun(weapon_xoffset, look_ang, looking_arc, kickback_pic, gun_pos, gs, o, pal);
                break;

            case CHAINGUN_WEAPON:
                DisplayChaingun(p_i, weapon_xoffset, look_ang, looking_arc, kickback_pic, gun_pos, gs, o, pal);
                break;

            case RPG_WEAPON:
                DisplayRPG(weapon_xoffset, look_ang, looking_arc, kickback_pic, gun_pos, gs, o, pal);
                break;

            case HANDBOMB_WEAPON:
                DisplayHandBomb(weapon_xoffset, look_ang, looking_arc, kickback_pic, gun_pos, gs, o, pal);
                break;
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

    private void DisplayTriBomb(int weapon_xoffset, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
    {
        weapon_xoffset += 8;
        gun_pos -= 10;

        if (kickback_pic > 6)
        {
            looking_arc += (kickback_pic << 3);
        }
        else if (kickback_pic < 4)
        {
            traps.myospal(weapon_xoffset + 142 - (look_ang >> 1), looking_arc + 234 - gun_pos, HANDHOLDINGLASER + 3, gs, o, pal);
        }

        traps.myospal(weapon_xoffset + 130 - (look_ang >> 1), looking_arc + 249 - gun_pos, HANDHOLDINGLASER + (kickback_pic >> 2), gs, o, pal);
        traps.myospal(weapon_xoffset + 152 - (look_ang >> 1), looking_arc + 249 - gun_pos, HANDHOLDINGLASER + (kickback_pic >> 2), gs, o | 4, pal);

    }

    private void DisplayHandRemote(int weapon_xoffset, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
    {
        sbyte[] remote_frames = { 0, 1, 1, 2, 1, 1, 0, 0, 0, 0, 0 };
        weapon_xoffset = -48;

        if (kickback_pic != 0)
        {
            traps.myospal(weapon_xoffset + 150 - (look_ang >> 1), looking_arc + 258 - gun_pos, HANDREMOTE + remote_frames[kickback_pic], gs, o, pal);
        }
        else
        {
            traps.myospal(weapon_xoffset + 150 - (look_ang >> 1), looking_arc + 258 - gun_pos, HANDREMOTE, gs, o, pal);
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

    private void DisplayHandBomb(int weapon_xoffset, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
    {
        if (kickback_pic != 0)
        {
            int[] throw_frames = { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2 };

            if (kickback_pic < 7)
            {
                gun_pos -= 10 * kickback_pic; //D
            }
            else if (kickback_pic < 12)
            {
                gun_pos += 20 * (kickback_pic - 10); //U
            }
            else if (kickback_pic < 20)
            {
                gun_pos -= 9 * (kickback_pic - 14); //D
            }

            traps.myospal(weapon_xoffset + 190 - (look_ang >> 1), looking_arc + 250 - gun_pos, HANDTHROW + throw_frames[kickback_pic], gs, o, pal);
        }
        else
        {
            traps.myospal(weapon_xoffset + 190 - (look_ang >> 1), looking_arc + 260 - gun_pos, HANDTHROW, gs, o, pal);
        }
    }

    private void DisplayRPG(int weapon_xoffset, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
    {
        weapon_xoffset -= traps.sintable((768 + (kickback_pic << 7)) & 2047) >> 11;
        gun_pos += traps.sintable((768 + (kickback_pic << 7) & 2047)) >> 11;

        if (kickback_pic > 0)
        {
            if (kickback_pic < 8)
            {
                traps.myospal(weapon_xoffset + 164, (looking_arc << 1) + 176 - gun_pos, RPGGUN + (kickback_pic >> 1), gs, o, pal);
            }
        }

        traps.myospal(weapon_xoffset + 164, (looking_arc << 1) + 176 - gun_pos, RPGGUN, gs, o, pal);
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

    private void DisplayPistol(int weapon_xoffset, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
    {
        if (kickback_pic < 5)
        {
            short[] kb_frames = { 0, 1, 2, 0, 0 };
            short l;

            l = (short)(195 - 12 + weapon_xoffset);

            if (kickback_pic == 2)
            {
                l -= 3;
            }
            traps.myospal((l - (look_ang >> 1)), (looking_arc + 244 - gun_pos), FIRSTGUN + kb_frames[kickback_pic], gs, 2, pal);
        }
        else
        {
            if (kickback_pic < 10)
            {
                traps.myospal(194 - (look_ang >> 1), looking_arc + 230 - gun_pos, FIRSTGUN + 4, gs, o, pal);
            }
            else if (kickback_pic < 15)
            {
                traps.myospal(244 - (kickback_pic << 3) - (look_ang >> 1), looking_arc + 130 - gun_pos + (kickback_pic << 4), FIRSTGUN + 6, gs, o, pal);
                traps.myospal(224 - (look_ang >> 1), looking_arc + 220 - gun_pos, FIRSTGUN + 5, gs, o, pal);
            }
            else if (kickback_pic < 20)
            {
                traps.myospal(124 + (kickback_pic << 1) - (look_ang >> 1), looking_arc + 430 - gun_pos - (kickback_pic << 3), FIRSTGUN + 6, gs, o, pal);
                traps.myospal(224 - (look_ang >> 1), looking_arc + 220 - gun_pos, FIRSTGUN + 5, gs, o, pal);
            }
            else if (kickback_pic < 23)
            {
                traps.myospal(184 - (look_ang >> 1), looking_arc + 235 - gun_pos, FIRSTGUN + 8, gs, o, pal);
                traps.myospal(224 - (look_ang >> 1), looking_arc + 210 - gun_pos, FIRSTGUN + 5, gs, o, pal);
            }
            else if (kickback_pic < 25)
            {
                traps.myospal(164 - (look_ang >> 1), looking_arc + 245 - gun_pos, FIRSTGUN + 8, gs, o, pal);
                traps.myospal(224 - (look_ang >> 1), looking_arc + 220 - gun_pos, FIRSTGUN + 5, gs, o, pal);
            }
            else if (kickback_pic < 27)
            {
                traps.myospal(194 - (look_ang >> 1), looking_arc + 235 - gun_pos, FIRSTGUN + 5, gs, o, pal);
            }
        }
    }
}