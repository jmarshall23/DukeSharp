public partial class ConScript
{
    public void Event_FireWeapon(ref char hbomb_on, ref char pus, int screenpeek, int snum, int weapon_pos, int xrepeat, int sb_snum, int currentWeapon, int wantweaponfire, ref int kickback_pic, int pi, short[] ammo_amount, ref int lastvisinc, ref int visibility)
    {
        switch (currentWeapon)
        {
            case KNEE_WEAPON:
                FireKnee(sb_snum, wantweaponfire, ref kickback_pic, pi, ammo_amount, ref lastvisinc, ref visibility);
                break;
            case PISTOL_WEAPON:
                FirePistol(ref kickback_pic, pi, ammo_amount, ref lastvisinc, ref visibility);
                break;

            case SHOTGUN_WEAPON:
                FireShotgun(ref kickback_pic, pi, ammo_amount, ref lastvisinc, ref visibility);
                break;

            case CHAINGUN_WEAPON:
                FireChaingun(sb_snum, ref kickback_pic, pi, ammo_amount, ref lastvisinc, ref visibility);
                break;

            case RPG_WEAPON:
                FireRPG(ref kickback_pic, pi, ammo_amount, ref lastvisinc, ref visibility);
                break;

            case TRIPBOMB_WEAPON:
                FireTripbomb(weapon_pos, ref kickback_pic, pi, ammo_amount, ref lastvisinc, ref visibility);
                break;

            case DEVISTATOR_WEAPON:
                FireDevistator(ref kickback_pic, pi, ammo_amount, ref lastvisinc, ref visibility);
                break;

            case FREEZE_WEAPON:
                FireFreeze(xrepeat, sb_snum, ref kickback_pic, pi, ammo_amount, ref lastvisinc, ref visibility);
                break;
            case SHRINKER_WEAPON:
            case GROW_WEAPON:
                FireShrinkGrow(ref pus, screenpeek, snum, currentWeapon, ref kickback_pic, pi, ammo_amount, ref lastvisinc, ref visibility);
                break;

            case HANDREMOTE_WEAPON:
                FireHandRemote(ref hbomb_on, ref kickback_pic, pi, ammo_amount, ref lastvisinc, ref visibility);
                break;
        }
    }

    public void Event_DisplayWeapon(int currentWeapon, int random_club_frame, int hbomb_hold_delay, int p_i, int weapon_xoffset, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
    {
        switch (currentWeapon)
        {
            case TRIPBOMB_WEAPON:
                DisplayTripBomb(weapon_xoffset, look_ang, looking_arc, kickback_pic, gun_pos, gs, o, pal);
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



}