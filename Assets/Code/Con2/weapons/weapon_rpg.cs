public partial class ConScript
{
    private void FireRPG(ref int kickback_pic, int pi, short[] ammo_amount, ref int lastvisinc, ref int visibility)
    {
        kickback_pic++;
        if (kickback_pic == 4)
        {
            ammo_amount[RPG_WEAPON]--;
            lastvisinc = traps.totalclock() + 32;
            visibility = 0;
            traps.shoot(RPG);
            traps.checkavailweapon();
        }
        else if (kickback_pic == 20)
        {
            kickback_pic = 0;
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

}