public partial class ConScript
{
    private void FireTripbomb(int weapon_pos, ref int kickback_pic, int pi, short[] ammo_amount, ref int lastvisinc, ref int visibility)
    {
        if (kickback_pic < 4)
        {
            //p.posz = p.oposz;
            //p.poszv = 0;
            traps.tripbombresetposz();
            if (kickback_pic == 3)
            {
                traps.shoot(HANDHOLDINGLASER);
            }
        }
        if (kickback_pic == 16)
        {
            kickback_pic = 0;
            traps.checkavailweapon();
            weapon_pos = -9;
        }
        else
        {
            kickback_pic++;
        }
    }
    private void DisplayTripBomb(int weapon_xoffset, int look_ang, int looking_arc, int kickback_pic, int gun_pos, sbyte gs, char o, int pal)
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

}