using Build;

public partial class GlobalMembers
{
    public static class ConActions
    {
        internal static int j;
        internal static bool jj = false;
        internal static int l;
        internal static int s;
        internal static short temphit = 0;

        public static void ifnosounds()
        {
            for (j = 1; j < DefineConstants.NUM_SOUNDS; j++)
            {
                if (SoundOwner[j, 0].i == g_i)
                {
                    break;
                }
            }

            parseifelse(j == DefineConstants.NUM_SOUNDS);
        }
        public static void ifangdiffl()
        {
            insptr++;
            j = pragmas.klabs(getincangle(ps[g_p].ang, g_sp.ang));
            parseifelse(j <= (short)scriptptr.buffer[insptr]);
        }
        public static void ifspritepal()
        {
            insptr++;
            parseifelse(g_sp.pal == (short)scriptptr.buffer[insptr]);
        }

        public static void respawnhitag()
        {
            insptr++;
            switch (g_sp.picnum)
            {
                case DefineConstants.FEM1:
                case DefineConstants.FEM2:
                case DefineConstants.FEM3:
                case DefineConstants.FEM4:
                case DefineConstants.FEM5:
                case DefineConstants.FEM6:
                case DefineConstants.FEM7:
                case DefineConstants.FEM8:
                case DefineConstants.FEM9:
                case DefineConstants.FEM10:
                case DefineConstants.PODFEM1:
                case DefineConstants.NAKED1:
                case DefineConstants.STATUE:
                    if (g_sp.yvel != 0)
                    {
                        operaterespawns(g_sp.yvel);
                    }
                    break;
                default:
                    if (g_sp.hitag >= 0)
                    {
                        operaterespawns(g_sp.hitag);
                    }
                    break;
            }
        }
        public static void ifnotmoving()
        {
            parseifelse((hittype[g_i].movflag & 49152) > 16384);
        }
        public static void ifinouterspace()
        {
            parseifelse(floorspace(g_sp.sectnum) != 0);
        }
        public static void quote()
        {
            insptr++;
            FTA((short)scriptptr.buffer[insptr], ps[g_p]);
            insptr++;
        }
        public static void ifawayfromwall()
        {
            short s1;

            s1 = g_sp.sectnum;

            j = 0;

            Engine.board.updatesector(g_sp.x + 108, g_sp.y + 108, ref s1);
            if (s1 == g_sp.sectnum)
            {
                Engine.board.updatesector(g_sp.x - 108, g_sp.y - 108, ref s1);
                if (s1 == g_sp.sectnum)
                {
                    Engine.board.updatesector(g_sp.x + 108, g_sp.y - 108, ref s1);
                    if (s1 == g_sp.sectnum)
                    {
                        Engine.board.updatesector(g_sp.x - 108, g_sp.y + 108, ref s1);
                        if (s1 == g_sp.sectnum)
                        {
                            j = 1;
                        }
                    }
                }
            }
            parseifelse(j != 0);
        }
        public static void pstomp()
        {
            insptr++;
            if (ps[g_p].knee_incs == 0 && Engine.board.sprite[ps[g_p].i].xrepeat >= 40)
            {
                if (Engine.board.cansee(g_sp.x, g_sp.y, g_sp.z - (4 << 8), g_sp.sectnum, ps[g_p].posx, ps[g_p].posy, ps[g_p].posz + (16 << 8), Engine.board.sprite[ps[g_p].i].sectnum))
                {
                    ps[g_p].knee_incs = 1;
                    if (ps[g_p].weapon_pos == 0)
                    {
                        ps[g_p].weapon_pos = -1;
                    }
                    ps[g_p].actorsqu = g_i;
                }
            }
        }
        public static void ifpinventory()
        {
            insptr++;
            j = 0;
            switch (scriptptr.buffer[insptr++])
            {
                case 0:
                    if (ps[g_p].steroids_amount != (short)scriptptr.buffer[insptr])
                    {
                        j = 1;
                    }
                    break;
                case 1:
                    if (ps[g_p].shield_amount != max_player_health)
                    {
                        j = 1;
                    }
                    break;
                case 2:
                    if (ps[g_p].scuba_amount != (short)scriptptr.buffer[insptr])
                    {
                        j = 1;
                    }
                    break;
                case 3:
                    if (ps[g_p].holoduke_amount != (short)scriptptr.buffer[insptr])
                    {
                        j = 1;
                    }
                    break;
                case 4:
                    if (ps[g_p].jetpack_amount != (short)scriptptr.buffer[insptr])
                    {
                        j = 1;
                    }
                    break;
                case 6:
                    switch (g_sp.pal)
                    {
                        case 0:
                            if ((ps[g_p].got_access & 1) != 0)
                            {
                                j = 1;
                            }
                            break;
                        case 21:
                            if ((ps[g_p].got_access & 2) != 0)
                            {
                                j = 1;
                            }
                            break;
                        case 23:
                            if ((ps[g_p].got_access & 4) != 0)
                            {
                                j = 1;
                            }
                            break;
                    }
                    break;
                case 7:
                    if (ps[g_p].heat_amount != (short)scriptptr.buffer[insptr])
                    {
                        j = 1;
                    }
                    break;
                case 9:
                    if (ps[g_p].firstaid_amount != (short)scriptptr.buffer[insptr])
                    {
                        j = 1;
                    }
                    break;
                case 10:
                    if (ps[g_p].boot_amount != (short)scriptptr.buffer[insptr])
                    {
                        j = 1;
                    }
                    break;
            }

            parseifelse(j != 0);
        }
        public static void ifphealthl()
        {
            insptr++;
            parseifelse(Engine.board.sprite[ps[g_p].i].extra < (short)scriptptr.buffer[insptr]);
        }
        public static void palfrom()
        {

            insptr++;
            ps[g_p].pals_time = (short)scriptptr.buffer[insptr];
            insptr++;
            for (j = 0; j < 3; j++)
            {
                ps[g_p].pals[j] = (byte)scriptptr.buffer[insptr];
                insptr++;
            }
        }
        public static void ifceilingdistl()
        {
            insptr++;
            //            getglobalz(g_i);
            parseifelse((g_sp.z - hittype[g_i].ceilingz) <= (((short)scriptptr.buffer[insptr]) << 8));
        }
        public static void iffloordistl()
        {
            insptr++;
            //            getglobalz(g_i);
            parseifelse((hittype[g_i].floorz - g_sp.z) <= (((short)scriptptr.buffer[insptr]) << 8));
        }
        public static void ifrespawn()
        {
            if (badguy(g_sp) != 0)
            {
                parseifelse(ud.respawn_monsters != 0);
            }
            else if (inventory(g_sp) != 0)
            {
                parseifelse(ud.respawn_inventory != 0);
            }
            else
            {
                parseifelse(ud.respawn_items != 0);
            }
        }
        public static void ifbulletnear()
        {
            parseifelse(dodge(g_sp) == 1);
        }
        public static void cactor()
        {
            insptr++;
            g_sp.picnum = (short)scriptptr.buffer[insptr];
            insptr++;
        }
        public static void spritepal()
        {
            insptr++;
            if (g_sp.picnum != DefineConstants.APLAYER)
            {
                hittype[g_i].tempang = g_sp.pal;
            }
            g_sp.pal = (byte)scriptptr.buffer[insptr];
            insptr++;
        }
        public static void ifinspace()
        {
            parseifelse(ceilingspace(g_sp.sectnum) != 0);
        }
        public static void operate()
        {
            insptr++;
            if (Engine.board.sector[g_sp.sectnum].lotag == 0)
            {
                Engine.board.neartag(g_sp.x, g_sp.y, g_sp.z - (32 << 8), g_sp.sectnum, g_sp.ang, ref neartagsector, ref neartagwall, ref neartagsprite, ref neartaghitdist, 768, 1);
                if (neartagsector >= 0 && isanearoperator(Engine.board.sector[neartagsector].lotag))
                {
                    if ((Engine.board.sector[neartagsector].lotag & 0xff) == 23 || Engine.board.sector[neartagsector].floorz == Engine.board.sector[neartagsector].ceilingz)
                    {
                        if ((Engine.board.sector[neartagsector].lotag & 16384) == 0)
                        {
                            if ((Engine.board.sector[neartagsector].lotag & 32768) == 0)
                            {
                                j = Engine.board.headspritesect[neartagsector];
                                while (j >= 0)
                                {
                                    if (Engine.board.sprite[j].picnum == DefineConstants.ACTIVATOR)
                                    {
                                        break;
                                    }
                                    j = Engine.board.nextspritesect[j];
                                }
                                if (j == -1)
                                {
                                    operatesectors(neartagsector, g_i);
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void ifmultiplayer()
        {
            parseifelse(ud.multimode > 1);
        }
        public static void ifoutside()
        {
            parseifelse((Engine.board.sector[g_sp.sectnum].ceilingstat & 1) != 0);
        }
        public static void ifhitspace()
        {
            parseifelse((sync[g_p].bits & (1 << 29)) != 0);
        }
        public static void ifgapzl()
        {
            insptr++;
            parseifelse(((hittype[g_i].floorz - hittype[g_i].ceilingz) >> 8) < (short)scriptptr.buffer[insptr]);
        }
        public static void wackplayer()
        {
            insptr++;
            forceplayerangle(ps[g_p]);
        }

        public static void ifspawnedby()
        {
            insptr++;
            //            if(g_sp->owner >= 0 && Engine.board.sprite[g_sp->owner].picnum == (short)scriptptr.buffer[insptr])
            //              parseifelse(1);
            //            else
            parseifelse(hittype[g_i].picnum == (short)scriptptr.buffer[insptr]);
        }

        public static void guts()
        {
            insptr += 2;
            GlobalMembers.guts(g_sp, (short)scriptptr.buffer[insptr - 1], (short)scriptptr.buffer[insptr], g_p);
            insptr++;
        }

        public static void ifstrength()
        {
            insptr++;
            parseifelse(g_sp.extra <= (short)scriptptr.buffer[insptr]);
        }

        public static void ifp()
        {

            insptr++;

            l = (short)scriptptr.buffer[insptr];
            j = 0;

            s = g_sp.xvel;

            if ((l & 8) != 0 && ps[g_p].on_ground != 0 && (sync[g_p].bits & 2) != 0)
            {
                j = 1;
            }
            else if ((l & 16) != 0 && ps[g_p].jumping_counter == 0 && ps[g_p].on_ground == 0 && ps[g_p].poszv > 2048)
            {
                j = 1;
            }
            else if ((l & 32) != 0 && ps[g_p].jumping_counter > 348)
            {
                j = 1;
            }
            else if ((l & 1) != 0 && s >= 0 && s < 8)
            {
                j = 1;
            }
            else if ((l & 2) != 0 && s >= 8 && 0 == (sync[g_p].bits & (1 << 5)))
            {
                j = 1;
            }
            else if ((l & 4) != 0 && s >= 8 && 1 == (sync[g_p].bits & (1 << 5)))
            {
                j = 1;
            }
            else if ((l & 64) != 0 && ps[g_p].posz < (g_sp.z - (48 << 8)))
            {
                j = 1;
            }
            else if ((l & 128) != 0 && s <= -8 && 0 == (sync[g_p].bits & (1 << 5)))
            {
                j = 1;
            }
            else if ((l & 256) != 0 && s <= -8 && 1 == (sync[g_p].bits & (1 << 5)))
            {
                j = 1;
            }
            else if ((l & 512) != 0 && (ps[g_p].quick_kick > 0 || (ps[g_p].curr_weapon == DefineConstants.KNEE_WEAPON && ps[g_p].kickback_pic > 0)))
            {
                j = 1;
            }
            else if ((l & 1024) != 0 && Engine.board.sprite[ps[g_p].i].xrepeat < 32)
            {
                j = 1;
            }
            else if ((l & 2048) != 0 && ps[g_p].jetpack_on != 0)
            {
                j = 1;
            }
            else if ((l & 4096) != 0 && ps[g_p].steroids_amount > 0 && ps[g_p].steroids_amount < 400)
            {
                j = 1;
            }
            else if ((l & 8192) != 0 && ps[g_p].on_ground != 0)
            {
                j = 1;
            }
            else if ((l & 16384) != 0 && Engine.board.sprite[ps[g_p].i].xrepeat > 32 && Engine.board.sprite[ps[g_p].i].extra > 0 && ps[g_p].timebeforeexit == 0)
            {
                j = 1;
            }
            else if ((l & 32768) != 0 && Engine.board.sprite[ps[g_p].i].extra <= 0)
            {
                j = 1;
            }
            else if ((l & 65536) != 0)
            {
                if (g_sp.picnum == DefineConstants.APLAYER && ud.multimode > 1)
                {
                    j = getincangle(ps[otherp].ang, (short)Engine.getangle(ps[g_p].posx - ps[otherp].posx, ps[g_p].posy - ps[otherp].posy));
                }
                else
                {
                    j = getincangle(ps[g_p].ang, (short)Engine.getangle(g_sp.x - ps[g_p].posx, g_sp.y - ps[g_p].posy));
                }

                if (j > -128 && j < 128)
                {
                    j = 1;
                }
                else
                {
                    j = 0;
                }
            }

            parseifelse(j == 1);
        }

        public static void hitradius()
        {
            GlobalMembers.hitradius(g_i, ((short)scriptptr.buffer[insptr + 1]), (insptr + 2), (insptr + 3), (insptr + 4), (insptr + 5));
            insptr += 6;
        }

        public static void addinventory()
        {
            insptr += 2;
            switch ((short)scriptptr.buffer[insptr - 1])
            {
                case 0:
                    ps[g_p].steroids_amount = (short)scriptptr.buffer[insptr];
                    ps[g_p].inven_icon = (char)2;
                    break;
                case 1:
                    ps[g_p].shield_amount += (short)scriptptr.buffer[insptr]; // 100;
                    if (ps[g_p].shield_amount > max_player_health)
                    {
                        ps[g_p].shield_amount = (short)max_player_health;
                    }
                    break;
                case 2:
                    ps[g_p].scuba_amount = (short)scriptptr.buffer[insptr]; // 1600;
                    ps[g_p].inven_icon = (char)6;
                    break;
                case 3:
                    ps[g_p].holoduke_amount = (short)scriptptr.buffer[insptr]; // 1600;
                    ps[g_p].inven_icon = (char)3;
                    break;
                case 4:
                    ps[g_p].jetpack_amount = (short)scriptptr.buffer[insptr]; // 1600;
                    ps[g_p].inven_icon = (char)4;
                    break;
                case 6:
                    switch (g_sp.pal)
                    {
                        case 0:
                            ps[g_p].got_access |= 1;
                            break;
                        case 21:
                            ps[g_p].got_access |= 2;
                            break;
                        case 23:
                            ps[g_p].got_access |= 4;
                            break;
                    }
                    break;
                case 7:
                    ps[g_p].heat_amount = (short)scriptptr.buffer[insptr];
                    ps[g_p].inven_icon = (char)5;
                    break;
                case 9:
                    ps[g_p].inven_icon = (char)1;
                    ps[g_p].firstaid_amount = (short)scriptptr.buffer[insptr];
                    break;
                case 10:
                    ps[g_p].inven_icon = (char)7;
                    ps[g_p].boot_amount = (short)scriptptr.buffer[insptr];
                    break;
            }
            insptr++;
        }
        public static void resetcount()
        {
            insptr++;
            g_t[0] = 0;
        }
        public static void ifactor()
        {
            insptr++;
            parseifelse(g_sp.picnum == (short)scriptptr.buffer[insptr]);
        }
        public static void ifcount()
        {
            insptr++;
            parseifelse(g_t[0] >= (short)scriptptr.buffer[insptr]);
        }
        public static void ifinwater()
        {
            parseifelse(Engine.board.sector[g_sp.sectnum].lotag == 2);
        }
        public static void ifonwater()
        {
            parseifelse(pragmas.klabs(g_sp.z - Engine.board.sector[g_sp.sectnum].floorz) < (32 << 8) && Engine.board.sector[g_sp.sectnum].lotag == 1);
        }
        public static void resetplayer()
        {
            insptr++;

            if (ud.multimode < 2)
            {
                if (lastsavedpos >= 0 && ud.recstat != 2)
                {
                    ps[g_p].gm = DefineConstants.MODE_MENU;
                    {
                        KB_KeyDown[(DefineConstants.sc_Space)] = (!(1 == 1));
                    };
                    cmenu(15000);
                }
                else
                {
                    ps[g_p].gm = DefineConstants.MODE_RESTART;
                }
                killit_flag = (char)2;
            }
            else
            {
                pickrandomspot(g_p);
                g_sp.x = hittype[g_i].bposx = ps[g_p].bobposx = ps[g_p].oposx = ps[g_p].posx;
                g_sp.y = hittype[g_i].bposy = ps[g_p].bobposy = ps[g_p].oposy = ps[g_p].posy;
                g_sp.z = hittype[g_i].bposy = ps[g_p].oposz = ps[g_p].posz;
                Engine.board.updatesector(ps[g_p].posx, ps[g_p].posy, ref ps[g_p].cursectnum);
                Engine.board.setsprite(ps[g_p].i, ps[g_p].posx, ps[g_p].posy, ps[g_p].posz + (38 << 8));
                g_sp.cstat = 257;

                g_sp.shade = -12;
                g_sp.clipdist = 64;
                g_sp.xrepeat = 42;
                g_sp.yrepeat = 36;
                g_sp.owner = g_i;
                g_sp.xoffset = 0;
                //g_sp.pal = ps[g_p].palookup; // jmarshall palette

                ps[g_p].last_extra = g_sp.extra = (short)max_player_health;
                ps[g_p].wantweaponfire = -1;
                ps[g_p].horiz = 100;
                ps[g_p].on_crane = -1;
                ps[g_p].frag_ps = g_p;
                ps[g_p].horizoff = 0;
                ps[g_p].opyoff = 0;
                ps[g_p].wackedbyactor = -1;
                ps[g_p].shield_amount = (short)max_armour_amount;
                ps[g_p].dead_flag = 0;
                ps[g_p].pals_time = 0;
                ps[g_p].footprintcount = (char)0;
                ps[g_p].weapreccnt = 0;
                ps[g_p].fta = 0;
                ps[g_p].ftq = 0;
                ps[g_p].posxv = ps[g_p].posyv = 0;
                ps[g_p].rotscrnang = 0;

                ps[g_p].falling_counter = (char)0;

                hittype[g_i].extra = -1;
                hittype[g_i].owner = g_i;

                hittype[g_i].cgg = (char)0;
                hittype[g_i].movflag = 0;
                hittype[g_i].tempang = 0;
                hittype[g_i].actorstayput = -1;
                hittype[g_i].dispicnum = 0;
                hittype[g_i].owner = ps[g_p].i;

                resetinventory(g_p);
                resetweapons(g_p);

                cameradist = 0;
                cameraclock = totalclock;
            }
            // setpal(ps[g_p]);// jmarshall palette
        }
        public static void ifmove()
        {
            insptr++;
            parseifelse(scriptptr.buffer[g_t[1]] == (short)scriptptr.buffer[insptr]);
        }
        public static void cstat()
        {
            insptr++;
            g_sp.cstat = (short)(short)scriptptr.buffer[insptr];
            insptr++;
        }
        public static void clipdist()
        {
            insptr++;
            g_sp.clipdist = (byte)scriptptr.buffer[insptr];
            insptr++;
        }
        public static void cstator()
        {
            insptr++;
            g_sp.cstat |= (short)(short)scriptptr.buffer[insptr];
            insptr++;
        }
        public static void count()
        {
            insptr++;
            g_t[0] = (short)(short)scriptptr.buffer[insptr];
            insptr++;
        }
        public static void debris()
        {
            short dnum;

            insptr++;
            dnum = (short)scriptptr.buffer[insptr];
            insptr++;

            if (g_sp.sectnum >= 0 && g_sp.sectnum < DefineConstants.MAXSECTORS)
            {
                for (j = ((short)scriptptr.buffer[insptr]) - 1; j >= 0; j--)
                {
                    if (g_sp.picnum == DefineConstants.BLIMP && dnum == DefineConstants.SCRAP1)
                    {
                        s = 0;
                    }
                    else
                    {
                        s = (short)(Engine.krand() % 3);
                    }

                    l = EGS(g_sp.sectnum, g_sp.x + (Engine.krand() & 255) - 128, g_sp.y + (Engine.krand() & 255) - 128, g_sp.z - (8 << 8) - (Engine.krand() & 8191), dnum + s, g_sp.shade, (sbyte)(32 + (Engine.krand() & 15)), (sbyte)(32 + (Engine.krand() & 15)), (short)(Engine.krand() & 2047), (short)((Engine.krand() & 127) + 32), -(Engine.krand() & 2047), g_i, 5);
                    if (g_sp.picnum == DefineConstants.BLIMP && dnum == DefineConstants.SCRAP1)
                    {
                        Engine.board.sprite[l].yvel = weaponsandammosprites[j % 14];
                    }
                    else
                    {
                        Engine.board.sprite[l].yvel = -1;
                    }
                    Engine.board.sprite[l].pal = g_sp.pal;
                }
            }
            insptr++;
        }
        public static void ifrnd()
        {
            insptr++;
            parseifelse(((Engine.krand() >> 8) >= (255 - (scriptptr.buffer[insptr]))));
        }
        public static void resetactioncount()
        {
            insptr++;
            g_t[2] = 0;
        }
        public static void ifactioncount()
        {
            insptr++;
            parseifelse(g_t[2] >= (short)scriptptr.buffer[insptr]);
        }
        public static void ifaction()
        {
            insptr++;
            parseifelse(g_t[4] == (short)scriptptr.buffer[insptr]);
        }
        public static void ifai()
        {
            insptr++;
            parseifelse(g_t[5] == (short)scriptptr.buffer[insptr]);
        }
        public static void ifwasweapon()
        {
            insptr++;
            parseifelse(hittype[g_i].picnum == (short)scriptptr.buffer[insptr]);
        }

        public static void spawn()
        {
            insptr++;
            if (g_sp.sectnum >= 0 && g_sp.sectnum < DefineConstants.MAXSECTORS)
            {
                GlobalMembers.spawn(g_i, (short)scriptptr.buffer[insptr]);
            }
            insptr++;
        }

        public static void move()
        {
            g_t[0] = 0;
            insptr++;
            g_t[1] = scriptptr.buffer[insptr];
            insptr++;
            g_sp.hitag = (short)scriptptr.buffer[insptr];
            insptr++;
            if ((g_sp.hitag & DefineConstants.random_angle) != 0)
            {
                g_sp.ang = (short)(Engine.krand() & 2047);
            }
        }

        public static void openbracket()
        {
            insptr++;
            while (true)
            {
                if (parse() != 0)
                {
                    break;
                }
            }
        }

        public static void state()
        {
            //C++ TO C# CONVERTER TODO TASK: C# does not have an equivalent to pointers to value types:
            //ORIGINAL LINE: int *tempscrptr;

            int tempscrptr;

            tempscrptr = insptr + 2;

            insptr = (scriptptr.buffer[insptr + 1]); // jmarshall 
            while (true)
            {
                if (parse() != 0)
                {
                    break;
                }
            }
            insptr = tempscrptr;
        }

        public static void addphealth()
        {
            insptr++;

            if (ps[g_p].newowner >= 0)
            {
                ps[g_p].newowner = -1;
                ps[g_p].posx = ps[g_p].oposx;
                ps[g_p].posy = ps[g_p].oposy;
                ps[g_p].posz = ps[g_p].oposz;
                ps[g_p].ang = ps[g_p].oang;
                Engine.board.updatesector(ps[g_p].posx, ps[g_p].posy, ref ps[g_p].cursectnum);
                //setpal(ps[g_p]); // jmarshall palette.

                j = Engine.board.headspritestat[1];
                while (j >= 0)
                {
                    if (Engine.board.sprite[j].picnum == DefineConstants.CAMERA1)
                    {
                        Engine.board.sprite[j].yvel = 0;
                    }
                    j = Engine.board.nextspritestat[j];
                }
            }

            j = Engine.board.sprite[ps[g_p].i].extra;

            if (g_sp.picnum != DefineConstants.ATOMICHEALTH)
            {
                if (j > max_player_health && (short)scriptptr.buffer[insptr] > 0)
                {
                    insptr++;
                    return;
                }
                else
                {
                    if (j > 0)
                    {
                        j += (short)scriptptr.buffer[insptr];
                    }
                    if (j > max_player_health && (short)scriptptr.buffer[insptr] > 0)
                    {
                        j = max_player_health;
                    }
                }
            }
            else
            {
                if (j > 0)
                {
                    j += (short)scriptptr.buffer[insptr];
                }
                if (j > (max_player_health << 1))
                {
                    j = (max_player_health << 1);
                }
            }

            if (j < 0)
            {
                j = 0;
            }

            if (ud.god == 0)
            {
                if ((short)scriptptr.buffer[insptr] > 0)
                {
                    if ((j - (short)scriptptr.buffer[insptr]) < (max_player_health >> 2) && j >= (max_player_health >> 2))
                    {
                        spritesound(DefineConstants.DUKE_GOTHEALTHATLOW, ps[g_p].i);
                    }

                    ps[g_p].last_extra = (short)j;
                }

                Engine.board.sprite[ps[g_p].i].extra = (short)j;
            }

            insptr++;
        }

        public static void endofgame()
        {
            insptr++;
            ps[g_p].timebeforeexit = (short)scriptptr.buffer[insptr];
            ps[g_p].customexitsound = -1;
            ud.eog = 1;
            insptr++;
        }

        public static void debug()
        {
            insptr++;
            //Engine.Printf("" + scriptptr.buffer[insptr]);
            insptr++;
        }

        public static void addweapon()
        {
            insptr++;
            if (ps[g_p].gotweapon[(short)scriptptr.buffer[insptr]] == false)
            {
                GlobalMembers.addweapon(ps[g_p], (short)scriptptr.buffer[insptr]);
            }
            else if (ps[g_p].ammo_amount[(short)scriptptr.buffer[insptr]] >= max_ammo_amount[(short)scriptptr.buffer[insptr]])
            {
                killit_flag = (char)2;
                return;
            }
            GlobalMembers.addammo((short)scriptptr.buffer[insptr], ps[g_p], ((short)scriptptr.buffer[insptr + 1]));
            if (ps[g_p].curr_weapon == DefineConstants.KNEE_WEAPON)
            {
                if (ps[g_p].gotweapon[(short)scriptptr.buffer[insptr]])
                {
                    GlobalMembers.addweapon(ps[g_p], (short)scriptptr.buffer[insptr]);
                }
            }
            insptr += 2;
        }
        public static void killit()
        {
            insptr++;
            killit_flag = (char)1;
        }
        public static void lotsofglass()
        {
            insptr++;
            spriteglass(g_i, (short)scriptptr.buffer[insptr]);
            insptr++;
        }
        public static void addkills()
        {
            insptr++;
            ps[g_p].actors_killed += (char)scriptptr.buffer[insptr];
            hittype[g_i].actorstayput = -1;
            insptr++;
        }

        public static void paper()
        {
            insptr++;
            lotsofpaper(g_sp, (short)scriptptr.buffer[insptr]);
            insptr++;
        }

        public static void sleeptime()
        {
            insptr++;
            hittype[g_i].timetosleep = (short)scriptptr.buffer[insptr];
            insptr++;
        }
        public static void mail()
        {
            insptr++;
            lotsofmail(g_sp, (short)scriptptr.buffer[insptr]);
            insptr++;
        }

        public static void money()
        {
            insptr++;
            lotsofmoney(g_sp, scriptptr.buffer[insptr]);
            insptr++;
        }
        public static void addammo()
        {
            insptr++;
            if (ps[g_p].ammo_amount[scriptptr.buffer[insptr]] >= max_ammo_amount[scriptptr.buffer[insptr]])
            {
                killit_flag = (char)2;
                return;
            }
            GlobalMembers.addammo((short)scriptptr.buffer[insptr], ps[g_p], (short)scriptptr.buffer[insptr + 1]);
            if (ps[g_p].curr_weapon == DefineConstants.KNEE_WEAPON)
            {
                if (ps[g_p].gotweapon[scriptptr.buffer[insptr]])
                {
                    GlobalMembers.addweapon(ps[g_p], (short)scriptptr.buffer[insptr]);
                }
            }
            insptr += 2;
        }
        public static void fall()
        {
            insptr++;
            g_sp.xoffset = 0;
            g_sp.yoffset = 0;
            //            if(!gotz)
            {
                int c;

                if (floorspace(g_sp.sectnum) != 0)
                {
                    c = 0;
                }
                else
                {
                    if (ceilingspace(g_sp.sectnum) != 0 || Engine.board.sector[g_sp.sectnum].lotag == 2)
                    {
                        c = gc / 6;
                    }
                    else
                    {
                        c = gc;
                    }
                }

                if (hittype[g_i].cgg <= 0 || (Engine.board.sector[g_sp.sectnum].floorstat & 2) != 0)
                {
                    getglobalz(g_i);
                    hittype[g_i].cgg = (char)6;
                }
                else
                {
                    hittype[g_i].cgg--;
                }

                if (g_sp.z < (hittype[g_i].floorz - (1 << 8)))
                {
                    g_sp.zvel += (short)c;
                    g_sp.z += g_sp.zvel;

                    if (g_sp.zvel > 6144)
                    {
                        g_sp.zvel = 6144;
                    }
                }
                else
                {
                    g_sp.z = hittype[g_i].floorz - (1 << 8);

                    if (badguy(g_sp) != 0 || (g_sp.picnum == DefineConstants.APLAYER && g_sp.owner >= 0))
                    {

                        if (g_sp.zvel > 3084 && g_sp.extra <= 1)
                        {
                            if (g_sp.pal != 1 && g_sp.picnum != DefineConstants.DRONE)
                            {
                                if (g_sp.picnum == DefineConstants.APLAYER && g_sp.extra > 0)
                                {
                                    goto SKIPJIBS;
                                }
                                GlobalMembers.guts(g_sp, DefineConstants.JIBS6, 15, g_p);
                                spritesound(DefineConstants.SQUISHED, g_i);
                                GlobalMembers.spawn(g_i, DefineConstants.BLOODPOOL);
                            }

                            SKIPJIBS:

                            hittype[g_i].picnum = DefineConstants.SHOTSPARK1;
                            hittype[g_i].extra = 1;
                            g_sp.zvel = 0;
                        }
                        else if (g_sp.zvel > 2048 && Engine.board.sector[g_sp.sectnum].lotag != 1)
                        {

                            j = g_sp.sectnum;
                            short _jj = (short)j;
                            Engine.board.pushmove(ref g_sp.x, ref g_sp.y, ref g_sp.z, ref _jj, 128, (4 << 8), (4 << 8), (((1) << 16) + 1));
                            j = _jj;
                            if (j != g_sp.sectnum && j >= 0 && j < DefineConstants.MAXSECTORS)
                            {
                                Engine.board.changespritesect(g_i, (short)j);
                            }

                            spritesound(DefineConstants.THUD, g_i);
                        }
                    }
                    if (Engine.board.sector[g_sp.sectnum].lotag == 1)
                    {
                        switch (g_sp.picnum)
                        {
                            case DefineConstants.OCTABRAIN:
                            case DefineConstants.COMMANDER:
                            case DefineConstants.DRONE:
                                break;
                            default:
                                g_sp.z += (24 << 8);
                                break;
                        }
                    }
                    else
                    {
                        g_sp.zvel = 0;
                    }
                }
            }
        }

        public static void tip()
        {
            insptr++;
            ps[g_p].tipincs = 26;
        }
        public static void sound()
        {
            insptr++;
            spritesound(scriptptr.buffer[insptr], g_i);
            insptr++;
        }
        public static void globalsound()
        {
            insptr++;
            if (g_p == screenpeek || ud.coop == 1)
            {
                spritesound(scriptptr.buffer[insptr], ps[screenpeek].i);
            }
            insptr++;
        }
        public static void stopsound()
        {
            insptr++;
            if (Sound[scriptptr.buffer[insptr]].num > 0)
            {
                GlobalMembers.stopsound(scriptptr.buffer[insptr]);
            }
            insptr++;
        }
        public static void soundonce()
        {
            insptr++;
            if (Sound[scriptptr.buffer[insptr]].num == 0)
            {
                spritesound((short)scriptptr.buffer[insptr], g_i);
            }
            insptr++;
        }
        public static void shoot()
        {
            insptr++;
            GlobalMembers.shoot(g_i, (short)scriptptr.buffer[insptr]);
            insptr++;
        }
        public static void sizeat()
        {
            insptr++;
            g_sp.xrepeat = (byte)scriptptr.buffer[insptr];
            insptr++;
            g_sp.yrepeat = (byte)scriptptr.buffer[insptr];
            insptr++;
        }
        public static void sizeto()
        {
            insptr++;

            j = ((scriptptr.buffer[insptr]) - g_sp.xrepeat) << 1;
            g_sp.xrepeat += (byte)pragmas.ksgn(j);

            insptr++;

            if ((g_sp.picnum == DefineConstants.APLAYER && g_sp.yrepeat < 36) || insptr < g_sp.yrepeat || ((g_sp.yrepeat * (Engine.tilesizy[g_sp.picnum] + 8)) << 2) < (hittype[g_i].floorz - hittype[g_i].ceilingz))
            {
                j = ((scriptptr.buffer[insptr]) - g_sp.yrepeat) << 1;
                if (pragmas.klabs(j) != 0)
                {
                    g_sp.yrepeat += (byte)pragmas.ksgn(j);
                }
            }

            insptr++;
        }
        public static void pkick()
        {
            insptr++;

            if (ud.multimode > 1 && g_sp.picnum == DefineConstants.APLAYER)
            {
                if (ps[otherp].quick_kick == 0)
                {
                    ps[otherp].quick_kick = 14;
                }
            }
            else if (g_sp.picnum != DefineConstants.APLAYER && ps[g_p].quick_kick == 0)
            {
                ps[g_p].quick_kick = 14;
            }
        }
        public static void mikesnd()
        {
            insptr++;
            if (Sound[g_sp.yvel].num == 0)
            {
                spritesound((ushort)g_sp.yvel, g_i);
            }
        }
        public static void nullop()
        {
            insptr++;
        }

        public static void tossweapon()
        {
            insptr++;
            checkweapons(ps[g_sp.yvel]);
        }

        public static void getlastpal()
        {
            insptr++;
            if (g_sp.picnum == DefineConstants.APLAYER)
            {
                g_sp.pal = (byte)ps[g_sp.yvel].palookup;
            }
            else
            {
                g_sp.pal = (byte)hittype[g_i].tempang;
            }
            hittype[g_i].tempang = 0;
        }

        public static void ifgotweaponce()
        {
            insptr++;

            if (ud.coop >= 1 && ud.multimode > 1)
            {
                if (scriptptr.buffer[insptr] == 0)
                {
                    for (j = 0; j < ps[g_p].weapreccnt; j++)
                    {
                        if (ps[g_p].weaprecs[j] == g_sp.picnum)
                        {
                            break;
                        }
                    }

                    parseifelse(j < ps[g_p].weapreccnt && g_sp.owner == g_i);
                }
                else if (ps[g_p].weapreccnt < 16)
                {
                    ps[g_p].weaprecs[ps[g_p].weapreccnt++] = g_sp.picnum;
                    parseifelse(g_sp.owner == g_i);
                }
            }
            else
            {
                parseifelse(false);
            }
        }
        public static void strength()
        {
            insptr++;
            g_sp.extra = (short)scriptptr.buffer[insptr];
            insptr++;
        }

        public static void addstrength()
        {
            insptr++;
            g_sp.extra += (short)scriptptr.buffer[insptr];
            insptr++;
        }

        public static void _else()
        {
            insptr = scriptptr.buffer[insptr + 1];
        }

        public static void ifpdistg()
        {
            insptr++;
            parseifelse(g_x > scriptptr.buffer[insptr]);
            if (g_x > DefineConstants.MAXSLEEPDIST && hittype[g_i].timetosleep == 0)
            {
                hittype[g_i].timetosleep = DefineConstants.SLEEPTIME;
            }
        }

        public static void ifpdistl()
        {
            insptr++;
            parseifelse(g_x < scriptptr.buffer[insptr]);
            if (g_x > DefineConstants.MAXSLEEPDIST && hittype[g_i].timetosleep == 0)
            {
                hittype[g_i].timetosleep = DefineConstants.SLEEPTIME;
            }
        }

        public static void action()
        {
            insptr++;
            g_t[2] = 0;
            g_t[3] = 0;
            g_t[4] = insptr;
            insptr++;
        }

        public static void ai()
        {
            insptr++;
            g_t[5] = insptr;
            g_t[4] = g_t[5]; // Action
            g_t[1] = g_t[5] + 4; // move
            g_sp.hitag = (short)scriptptr.buffer[g_t[5] + 8]; // Ai
            g_t[0] = g_t[2] = g_t[3] = 0;
            if ((g_sp.hitag & DefineConstants.random_angle) != 0)
            {
                g_sp.ang = (short)(Engine.krand() & 2047);
            }
            insptr++;
        }

        public static void ifdead()
        {
            j = g_sp.extra;
            if (g_sp.picnum == DefineConstants.APLAYER)
            {
                j--;
            }
            parseifelse(j < 0);
        }
        public static void ifsquished()
        {
            parseifelse(GlobalMembers.ifsquished(g_i, g_p) == 1);
        }

        public static void ifhitweapon()
        {
            parseifelse(ifhitbyweapon(g_i) >= 0);
        }

        public static void ifcansee()
        {
            spritetype ss;
            short sect;

            if (ps[g_p].holoduke_on >= 0)
            {
                ss = Engine.board.sprite[ps[g_p].holoduke_on];
                jj = Engine.board.cansee(g_sp.x, g_sp.y, (int)(g_sp.z - (Engine.krand() & ((32 << 8) - 1))), g_sp.sectnum, ss.x, ss.y, ss.z, ss.sectnum);
                if (jj == false)
                {
                    ss = Engine.board.sprite[ps[g_p].i];
                }
            }
            else
            {
                ss = Engine.board.sprite[ps[g_p].i];
            }

            jj = Engine.board.cansee(g_sp.x, g_sp.y, (int)(g_sp.z - (Engine.krand() & ((47 << 8)))), g_sp.sectnum, ss.x, ss.y, ss.z - (24 << 8), ss.sectnum);

            if (jj == false)
            {
                if ((pragmas.klabs(hittype[g_i].lastvx - g_sp.x) + pragmas.klabs(hittype[g_i].lastvy - g_sp.y)) < (pragmas.klabs(hittype[g_i].lastvx - ss.x) + pragmas.klabs(hittype[g_i].lastvy - ss.y)))
                {
                    jj = false;
                }

                if (jj == false)
                {
                    j = furthestcanseepoint(g_i, ss, ref hittype[g_i].lastvx, ref hittype[g_i].lastvy);

                    if (j == -1)
                    {
                        jj = false;
                    }
                    else
                    {
                        jj = true;
                    }
                }
            }
            else
            {
                hittype[g_i].lastvx = ss.x;
                hittype[g_i].lastvy = ss.y;
            }

            if (jj && (g_sp.statnum == 1 || g_sp.statnum == 6))
            {
                hittype[g_i].timetosleep = DefineConstants.SLEEPTIME;
            }

            parseifelse(jj);
        }

        public static void ifactornotstayput()
        {
            parseifelse(hittype[g_i].actorstayput == -1);
        }

        public static void ifcanseetarget()
        {
            jj = Engine.board.cansee(g_sp.x, g_sp.y, (short)(g_sp.z - ((Engine.krand() & 41) << 8)), g_sp.sectnum, ps[g_p].posx, ps[g_p].posy, ps[g_p].posz, Engine.board.sprite[ps[g_p].i].sectnum);
            parseifelse(jj);
            if (jj)
            {
                hittype[g_i].timetosleep = DefineConstants.SLEEPTIME;
            }
        }
        public static void ifcanshoottarget()
        {
            if (g_x > 1024)
            {
                // short temphit;
                short sclip;
                short angdif;

                if (badguy(g_sp) != 0 && g_sp.xrepeat > 56)
                {
                    sclip = 3084;
                    angdif = 48;
                }
                else
                {
                    sclip = 768;
                    angdif = 16;
                }

                j = hitasprite(g_i, ref temphit);
                if (j == (1 << 30))
                {
                    parseifelse(true);
                    return;
                }
                if (j > sclip)
                {
                    if (temphit >= 0 && Engine.board.sprite[temphit].picnum == g_sp.picnum)
                    {
                        j = 0;
                    }
                    else
                    {
                        g_sp.ang += angdif;
                        j = hitasprite(g_i, ref temphit);
                        g_sp.ang -= angdif;
                        if (j > sclip)
                        {
                            if (temphit >= 0 && Engine.board.sprite[temphit].picnum == g_sp.picnum)
                            {
                                j = 0;
                            }
                            else
                            {
                                g_sp.ang -= angdif;
                                j = hitasprite(g_i, ref temphit);
                                g_sp.ang += angdif;
                                if (j > 768)
                                {
                                    if (temphit >= 0 && Engine.board.sprite[temphit].picnum == g_sp.picnum)
                                    {
                                        j = 0;
                                    }
                                    else
                                    {
                                        j = 1;
                                    }
                                }
                                else
                                {
                                    j = 0;
                                }
                            }
                        }
                        else
                        {
                            j = 0;
                        }
                    }
                }
                else
                {
                    j = 0;
                }
            }
            else
            {
                j = 1;
            }

            parseifelse(j != 0);
        }
    }
}