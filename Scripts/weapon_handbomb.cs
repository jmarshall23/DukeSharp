public partial class ConScript
{

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


}