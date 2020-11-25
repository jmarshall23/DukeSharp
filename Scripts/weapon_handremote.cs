public partial class ConScript
{
    private void FireHandRemote(ref char hbomb_on, ref int kickback_pic, int pi, short[] ammo_amount, ref int lastvisinc, ref int visibility)
    {
        kickback_pic++;

        if (kickback_pic == 2)
        {
            hbomb_on = (char)0;
        }

        if (kickback_pic == 10)
        {
            kickback_pic = 0;
            if (ammo_amount[HANDBOMB_WEAPON] > 0)
            {
                traps.addweapon(HANDBOMB_WEAPON);
            }
            else
            {
                traps.checkavailweapon();
            }
        }
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

}