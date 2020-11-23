using Build;

public partial class GlobalMembers
{
    public static class ConActions
    {
        public static void gamestartup(params int[] parms)
        {
            for(int j = 0; j < parms.Length; j++)
            {
                switch (j)
                {
                    case 0:
                        ud.const_visibility = parms[j];
                        break;
                    case 1:
                        impact_damage = parms[j];
                        break;
                    case 2:
                        max_player_health = parms[j];
                        break;
                    case 3:
                        max_armour_amount = parms[j];
                        break;
                    case 4:
                        respawnactortime = parms[j]; break;
                    case 5:
                        respawnitemtime = parms[j]; break;
                    case 6:
                        dukefriction = parms[j]; break;
                    case 7:
                        gc = parms[j]; break;
                    case 8: rpgblastradius = parms[j]; break;
                    case 9: pipebombblastradius = parms[j]; break;
                    case 10: shrinkerblastradius = parms[j]; break;
                    case 11: tripbombblastradius = parms[j]; break;
                    case 12: morterblastradius = parms[j]; break;
                    case 13: bouncemineblastradius = parms[j]; break;
                    case 14: seenineblastradius = parms[j]; break;

                    case 15:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 21:
                    case 22:
                    case 23:
                    case 24:
                        if (j == 24)
                            max_ammo_amount[11] = parms[j];
                        else max_ammo_amount[j - 14] = parms[j];
                        break;
                    case 25:
                        camerashitable = (char)parms[j];
                        break;
                    case 26:
                        numfreezebounces = parms[j];
                        break;
                    case 27:
                        freezerhurtowner = parms[j];
                        break;
                    case 28:
                        spriteqamount = (short)parms[j];
                        if (spriteqamount > 1024) spriteqamount = 1024;
                        else if (spriteqamount < 0) spriteqamount = 0;
                        break;
                    case 29:
                        lasermode = (char)parms[j];
                        break;
                }                
            }
        }
        public static void definemusic(int episode, params string[] music)
        {
            int k = episode;
            for(int i = 0; i < music.Length; i++)
            {
                GlobalMembers.music_fn[k,i] = music[i];
            }
        }
        public static void definesound(int id, string filename, int var1, int var2, int var3, int var4, int var5)
        {
            sounds[id] = filename;
            soundps[id] = (short)var1;
            soundpr[id] = var2;
            soundm[id] = var3;
            soundvo[id] = (short)var4;
        }
        public static void definelevelname(int episode, int level, string mapfile, string time1, string time2, string name)
        {
            int index = episode * 11 + level;
            GlobalMembers.level_file_names[index] = mapfile;
            GlobalMembers.partime[index] = time1; // jmarshall: partime
            GlobalMembers.designertime[index] = time2; // jmarshall: designertime
            GlobalMembers.level_names[index] = name.ToUpper();
        }
        public static void defineskillname(int id, string name)
        {
            GlobalMembers.skill_names[id] = name;
        }
        public static void definevolumename(int id, string name)
        {
            GlobalMembers.volume_names[id] = name;
        }
        public static void definequote(int id, string str)
        {
            GlobalMembers.fta_quotes[id] = str;
        }
        public static void RegisterActor(GlobalMembers.ScriptActorRegistration.Function_t function, int picnum, int aiType, int aiType2 = 0, GlobalMembers.ConActions.ConAction action = null, GlobalMembers.ConActions.MoveAction unknown2 = null, int unknown3 = 0, int unknown4 = 0)
        {
            GlobalMembers.scriptActorRegPtr[picnum] = new GlobalMembers.ScriptActorRegistration();
            GlobalMembers.scriptActorRegPtr[picnum].func = function;
            GlobalMembers.scriptActorRegPtr[picnum].aiType = aiType;
            GlobalMembers.scriptActorRegPtr[picnum].aiType2 = aiType2;
            GlobalMembers.scriptActorRegPtr[picnum].action = action;

            actortype[picnum] = 1;
        }


        public class ConAction
        {
            public int startframe;
            public int frames;
            public int viewtype;
            public int invvalue;
            public int delay;

            public int GetIndex(int i)
            {
                switch(i)
                {
                    case 0:
                        return startframe;
                    case 1:
                        return frames;
                    case 2:
                        return viewtype;
                    case 3:
                        return invvalue;
                    case 4:
                        return delay;
                }
                return -1;
            }

            public ConAction(int startframe = 0, int frames = 0, int viewtype = 0, int invvalue = 0, int delay = 0)
            {
                this.startframe = startframe;
                this.frames = frames;
                this.viewtype = viewtype;
                this.invvalue = invvalue;
                this.delay = delay;
            }
        }

        public class AIAction
        {
            public GlobalMembers.ConActions.ConAction action;
            public GlobalMembers.ConActions.MoveAction moveAction;
            public int val;
            public AIAction(GlobalMembers.ConActions.ConAction action, GlobalMembers.ConActions.MoveAction moveAction, int val = 0, int unknown = 0)
            {
                this.action = action;
                this.moveAction = moveAction;
                this.val = val;
            }
        }

        public class MoveAction
        {
            public int horizontal;
            public int vertical;

            public int GetIndex(int i)
            {
                switch (i)
                {
                    case 0:
                        return horizontal;
                    case 1:
                        return vertical;             
                }
                return -1;
            }

            public MoveAction(int horizontal = 0, int vertical = 0)
            {
                this.horizontal = horizontal;
                this.vertical = vertical;
            }
        }

        internal static int j;
        internal static bool jj = false;
        internal static int l;
        internal static int s;
        internal static short temphit = 0;

        public static bool ifnosounds()
        {
            for (j = 1; j < DefineConstants.NUM_SOUNDS; j++)
            {
                if (SoundOwner[j, 0].i == g_i)
                {
                    break;
                }
            }

            return (j == DefineConstants.NUM_SOUNDS);
        }
        public static bool ifangdiffl(int value)
        {
            j = pragmas.klabs(getincangle(ps[g_p].ang, g_sp.ang));
            return (j <= value);
        }
        public static bool ifspritepal(int value)
        {
            return (g_sp.pal == value);
        }

        public static void respawnhitag()
        {
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
        public static bool ifnotmoving()
        {
            return (hittype[g_i].movflag & 49152) > 16384;
        }
        public static bool ifinouterspace()
        {
            return (floorspace(g_sp.sectnum) != 0);
        }
        public static void quote(int value)
        {
            FTA((short)value, ps[g_p]);
        }
        public static bool ifawayfromwall()
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
            return (j != 0);
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

        public static bool ifpinventory(int val1, int val2)
        {
            j = 0;
            switch (val1)
            {
                case 0:
                    if (ps[g_p].steroids_amount != (short)val2)
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
                    if (ps[g_p].scuba_amount != (short)val2)
                    {
                        j = 1;
                    }
                    break;
                case 3:
                    if (ps[g_p].holoduke_amount != (short)val2)
                    {
                        j = 1;
                    }
                    break;
                case 4:
                    if (ps[g_p].jetpack_amount != (short)val2)
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
                    if (ps[g_p].heat_amount != (short)val2)
                    {
                        j = 1;
                    }
                    break;
                case 9:
                    if (ps[g_p].firstaid_amount != (short)val2)
                    {
                        j = 1;
                    }
                    break;
                case 10:
                    if (ps[g_p].boot_amount != (short)val2)
                    {
                        j = 1;
                    }
                    break;
            }

            return (j != 0);
        }

        public static bool ifphealthl(int value)
        {
            return (Engine.board.sprite[ps[g_p].i].extra < value);
        }
        public static void palfrom(int v1 = 0, int v2 = 0, int v3 = 0, int v4 = 0)
        {
            ps[g_p].pals_time = v1;
            ps[g_p].pals[0] = (byte)v2;
            ps[g_p].pals[1] = (byte)v3;
            ps[g_p].pals[2] = (byte)v4;            
        }
        public static bool ifceilingdistl(int val)
        {            
            return ((g_sp.z - hittype[g_i].ceilingz) <= (((short)val) << 8));
        }
        public static bool iffloordistl(int val)
        {
            return ((hittype[g_i].floorz - g_sp.z) <= (((short)val) << 8));
        }
        public static bool ifrespawn()
        {
            if (badguy(g_sp) != 0)
            {
                return (ud.respawn_monsters != 0);
            }
            else if (inventory(g_sp) != 0)
            {
                return  (ud.respawn_inventory != 0);
            }
            else
            {
                return (ud.respawn_items != 0);
            }
        }
        public static bool ifbulletnear()
        {
            return (dodge(g_sp) == 1);
        }
        public static void cactor(int value)
        {
            g_sp.picnum = (short)value;
        }
        public static void spritepal(int value)
        {
            if (g_sp.picnum != DefineConstants.APLAYER)
            {
                hittype[g_i].tempang = g_sp.pal;
            }
            g_sp.pal = (byte)value;
        }
        public static bool ifinspace()
        {
            return (ceilingspace(g_sp.sectnum) != 0);
        }
        public static void operate()
        {
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
        public static bool ifmultiplayer()
        {
            return (ud.multimode > 1);
        }
        public static bool ifoutside()
        {
            return ((Engine.board.sector[g_sp.sectnum].ceilingstat & 1) != 0);
        }
        public static bool ifhitspace()
        {
            return ((sync[g_p].bits & (1 << 29)) != 0);
        }
        public static bool ifgapzl(int val)
        {
            return (((hittype[g_i].floorz - hittype[g_i].ceilingz) >> 8) < (short)val);
        }
        public static void wackplayer()
        {
            forceplayerangle(ps[g_p]);
        }

        public static bool ifspawnedby(int value)
        {
            return (hittype[g_i].picnum == (short)value);
        }

        public static void guts(int value1, int value2)
        {
            GlobalMembers.guts(g_sp, (short)value1, (short)value2, g_p);
        }

        public static bool ifstrength(int value)
        {
            return (g_sp.extra <= (short)value);
        }

        public static bool ifp(int value, object notused = null, object notused2 = null, object notused3 = null, object notused4 = null)
        {
            l = (short)value;
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

            return (j == 1);
        }

        public static void hitradius(int val1 = 0, int val2 = 0, int val3 = 0, int val4 = 0, int val5 = 0)
        {
            GlobalMembers.hitradius(g_i, ((short)val1), val2, val3, val4, val5);
        }

        public static void addinventory(int val1, int val2)
        {
            switch ((short)val1)
            {
                case 0:
                    ps[g_p].steroids_amount = (short)val2;
                    ps[g_p].inven_icon = 2;
                    break;
                case 1:
                    ps[g_p].shield_amount += (short)val2; // 100;
                    if (ps[g_p].shield_amount > max_player_health)
                    {
                        ps[g_p].shield_amount = (short)max_player_health;
                    }
                    break;
                case 2:
                    ps[g_p].scuba_amount = (short)val2; // 1600;
                    ps[g_p].inven_icon = 6;
                    break;
                case 3:
                    ps[g_p].holoduke_amount = (short)val2; // 1600;
                    ps[g_p].inven_icon = 3;
                    break;
                case 4:
                    ps[g_p].jetpack_amount = (short)val2; // 1600;
                    ps[g_p].inven_icon = 4;
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
                    ps[g_p].heat_amount = (short)val2;
                    ps[g_p].inven_icon = 5;
                    break;
                case 9:
                    ps[g_p].inven_icon = 1;
                    ps[g_p].firstaid_amount = (short)val2;
                    break;
                case 10:
                    ps[g_p].inven_icon = 7;
                    ps[g_p].boot_amount = (short)val2;
                    break;
            }
            insptr++;
        }
        public static void resetcount()
        {
            hittype[g_i].count = 0;
        }
        public static bool ifactor(int val1)
        {
            return (g_sp.picnum == (short)val1);
        }
        public static bool ifcount(int val)
        {
            int v = hittype[g_i].count;
            return (v >= (short)val);
        }
        public static bool ifinwater()
        {
            return (Engine.board.sector[g_sp.sectnum].lotag == 2);
        }
        public static bool ifonwater()
        {
            return (pragmas.klabs(g_sp.z - Engine.board.sector[g_sp.sectnum].floorz) < (32 << 8) && Engine.board.sector[g_sp.sectnum].lotag == 1);
        }
        public static void resetplayer()
        {
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
        public static bool ifmove(MoveAction val1)
        {
            return hittype[g_i].moveAction == val1; 
        }

        public static void cstat(int value)
        {
            g_sp.cstat = (short)value;
        }
        public static void clipdist(int value)
        {
            g_sp.clipdist = (byte)value;
        }
        public static void cstator(int value)
        {
            g_sp.cstat |= (short)value;
        }
        public static void count(int value)
        {
            hittype[g_i].count = value;
        }
        public static void debris(int val1, int val2)
        {
            short dnum;

            dnum = (short)val1;

            if (g_sp.sectnum >= 0 && g_sp.sectnum < DefineConstants.MAXSECTORS)
            {
                for (j = ((short)val2) - 1; j >= 0; j--)
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
        public static bool ifrnd(int val1)
        {
            return (((Engine.krand() >> 8) >= (255 - (val1))));
        }
        public static void resetactioncount()
        {
            hittype[g_i].actioncount = 0;
        }
        public static bool ifactioncount(int val1)
        {
            return (hittype[g_i].actioncount >= (short)val1);
        }

        public static void SetAction(ConAction action)
        {
            hittype[g_i].actioncount = 0;
            hittype[g_i].animcounter = 0;
            hittype[g_i].action = action;
        }

        public static bool ifaction(ConAction action)
        {
            return (hittype[g_i].action == action);
        }

        public static void Ai(AIAction ai)
        {
            hittype[g_i].aiaction = ai;
            hittype[g_i].action = ai.action; // Action
            hittype[g_i].moveAction = ai.moveAction; // move
            g_sp.hitag = (short)ai.val; // Ai
            hittype[g_i].count = hittype[g_i].actioncount = hittype[g_i].animcounter = 0;
            if ((g_sp.hitag & DefineConstants.random_angle) != 0)
            {
                g_sp.ang = (short)(Engine.krand() & 2047);
            }
        }
        public static bool ifai(AIAction ai)
        {
            return (hittype[g_i].aiaction == ai);
        }
 
        public static bool ifwasweapon(int val)
        {
            return (hittype[g_i].picnum == (short)val);
        }

        public static void spawn(int val)
        {
            if (g_sp.sectnum >= 0 && g_sp.sectnum < DefineConstants.MAXSECTORS)
            {
                GlobalMembers.spawn(g_i, (short)val);
            }
        }

        public static void Move(MoveAction val, int val2 = 0, int val3 = 0, int unknown1 = 0)
        {
            hittype[g_i].count = 0;
            hittype[g_i].moveAction = val;
            g_sp.hitag = (short)val2;
            if ((g_sp.hitag & DefineConstants.random_angle) != 0)
            {
                g_sp.ang = (short)(Engine.krand() & 2047);
            }
        }

        public static void Move(int val, int val2 = 0)
        {
            if (val != 0)
                throw new System.Exception("Move val not null");

            hittype[g_i].count = 0;
            hittype[g_i].moveAction = null;
            g_sp.hitag = (short)val2;
            if ((g_sp.hitag & DefineConstants.random_angle) != 0)
            {
                g_sp.ang = (short)(Engine.krand() & 2047);
            }
        }


        public static void addphealth(int val)
        {
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
                if (j > max_player_health && (short)val > 0)
                {
                    insptr++;
                    return;
                }
                else
                {
                    if (j > 0)
                    {
                        j += (short)val;
                    }
                    if (j > max_player_health && (short)val > 0)
                    {
                        j = max_player_health;
                    }
                }
            }
            else
            {
                if (j > 0)
                {
                    j += (short)val;
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
                if ((short)val > 0)
                {
                    if ((j - (short)val) < (max_player_health >> 2) && j >= (max_player_health >> 2))
                    {
                        spritesound(DefineConstants.DUKE_GOTHEALTHATLOW, ps[g_p].i);
                    }

                    ps[g_p].last_extra = (short)j;
                }

                Engine.board.sprite[ps[g_p].i].extra = (short)j;
            }

            insptr++;
        }

        public static void endofgame(int timebeforeexit)
        {
            ps[g_p].timebeforeexit = (short)timebeforeexit;
            ps[g_p].customexitsound = -1;
            ud.eog = 1;
        }

        public static void debug()
        {
            insptr++;
            //Engine.Printf("" + scriptptr.buffer[insptr]);
            insptr++;
        }

        public static void addweapon(int val, int val2)
        {
            if (ps[g_p].gotweapon[(short)val] == false)
            {
                GlobalMembers.addweapon(ps[g_p], (short)val);
            }
            else if (ps[g_p].ammo_amount[(short)val] >= max_ammo_amount[(short)val])
            {
                killit_flag = (char)2;
                return;
            }
            GlobalMembers.addammo((short)val, ps[g_p], ((short)val2));
            if (ps[g_p].curr_weapon == DefineConstants.KNEE_WEAPON)
            {
                if (ps[g_p].gotweapon[(short)val])
                {
                    GlobalMembers.addweapon(ps[g_p], (short)val);
                }
            }
        }
        public static void killit()
        {
            killit_flag = (char)1;
        }
        public static void lotsofglass(int val)
        {
            spriteglass(g_i, (short)val);
        }
        public static void addkills(int val)
        {
            ps[g_p].actors_killed += (char)val;
            hittype[g_i].actorstayput = -1;
        }

        public static void paper(int val)
        {
            lotsofpaper(g_sp, (short)val);
        }

        public static void sleeptime(int val)
        {
            hittype[g_i].timetosleep = (short)val;
        }
        public static void mail(int val)
        {
            lotsofmail(g_sp, (short)val);
        }

        public static void money(int val)
        {
            lotsofmoney(g_sp, val);
        }
        public static void addammo(int val, int val2)
        {
            if (ps[g_p].ammo_amount[val] >= max_ammo_amount[val])
            {
                killit_flag = (char)2;
                return;
            }
            GlobalMembers.addammo((short)val, ps[g_p], (short)val2);
            if (ps[g_p].curr_weapon == DefineConstants.KNEE_WEAPON)
            {
                if (ps[g_p].gotweapon[val])
                {
                    GlobalMembers.addweapon(ps[g_p], (short)val);
                }
            }
        }
        public static void fall()
        {
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
            ps[g_p].tipincs = 26;
        }
        public static void sound(int val)
        {
            spritesound(val, g_i);
        }
        public static void globalsound(int val)
        {
            if (g_p == screenpeek || ud.coop == 1)
            {
                spritesound(val, ps[screenpeek].i);
            }
        }
        public static void stopsound(int val)
        {            
            if (Sound[val].num > 0)
            {
                GlobalMembers.stopsound(val);
            }
        }
        public static void soundonce(int val)
        {
            if (Sound[val].num == 0)
            {
                spritesound((short)val, g_i);
            }
        }
        public static void shoot(int val)
        {
            GlobalMembers.shoot(g_i, (short)val);
        }
        public static void sizeat(int val, int val2)
        {
            g_sp.xrepeat = (byte)val;
            g_sp.yrepeat = (byte)val2;
        }
        public static void sizeto(int val, int val2)
        {
            j = ((val) - g_sp.xrepeat) << 1;
            g_sp.xrepeat += (byte)pragmas.ksgn(j);

            if ((g_sp.picnum == DefineConstants.APLAYER && g_sp.yrepeat < 36) || val2 < g_sp.yrepeat || ((g_sp.yrepeat * (Engine.tilesizy[g_sp.picnum] + 8)) << 2) < (hittype[g_i].floorz - hittype[g_i].ceilingz))
            {
                j = ((val2) - g_sp.yrepeat) << 1;
                if (pragmas.klabs(j) != 0)
                {
                    g_sp.yrepeat += (byte)pragmas.ksgn(j);
                }
            }            
        }
        public static void pkick()
        {
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
            if (Sound[g_sp.yvel].num == 0)
            {
                spritesound((ushort)g_sp.yvel, g_i);
            }
        }
        public static void nullop()
        {

        }

        public static void tossweapon()
        {
            checkweapons(ps[g_sp.yvel]);
        }

        public static void getlastpal()
        {
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

        public static bool ifgotweaponce(int val)
        {
            if (ud.coop >= 1 && ud.multimode > 1)
            {
                if (val == 0)
                {
                    for (j = 0; j < ps[g_p].weapreccnt; j++)
                    {
                        if (ps[g_p].weaprecs[j] == g_sp.picnum)
                        {
                            break;
                        }
                    }

                    return (j < ps[g_p].weapreccnt && g_sp.owner == g_i);
                }
                else if (ps[g_p].weapreccnt < 16)
                {
                    ps[g_p].weaprecs[ps[g_p].weapreccnt++] = g_sp.picnum;
                    return (g_sp.owner == g_i);
                }
            }
            return (false);
        }
        public static void strength(int val)
        {
            g_sp.extra = (short)val;
        }

        public static void addstrength(int val)
        {
            g_sp.extra += (short)val;
        }


        public static bool ifpdistg(int val)
        {
            insptr++;
            bool r = (g_x > val);
            if (g_x > DefineConstants.MAXSLEEPDIST && hittype[g_i].timetosleep == 0)
            {
                hittype[g_i].timetosleep = DefineConstants.SLEEPTIME;
            }
            return r; // jmarshall: the flow of this might be wrong.
        }

        public static bool ifpdistl(int val)
        {
            bool r = (g_x < val);
            if (g_x > DefineConstants.MAXSLEEPDIST && hittype[g_i].timetosleep == 0)
            {
                hittype[g_i].timetosleep = DefineConstants.SLEEPTIME;
            }
            return r; // jmarshall: the flow of this might be wrong.
        }

// jmarshall
        //public static void ai()
        //{
        //    insptr++;
        //    g_t[5] = insptr;
        //    g_t[4] = g_t[5]; // Action
        //    g_t[1] = g_t[5] + 4; // move
        //    g_sp.hitag = (short)scriptptr.buffer[g_t[5] + 8]; // Ai
        //    hittype[g_i].count = hittype[g_i].actioncount = hittype[g_i].animcounter = 0;
        //    if ((g_sp.hitag & DefineConstants.random_angle) != 0)
        //    {
        //        g_sp.ang = (short)(Engine.krand() & 2047);
        //    }
        //    insptr++;
        //}
// jmarshall end
        public static bool ifdead()
        {
            j = g_sp.extra;
            if (g_sp.picnum == DefineConstants.APLAYER)
            {
                j--;
            }
            return (j < 0);
        }
        public static bool ifsquished()
        {
            return (GlobalMembers.ifsquished(g_i, g_p) == 1);
        }

        public static bool ifhitweapon()
        {
            return (ifhitbyweapon(g_i) >= 0);
        }

        public static bool ifcansee()
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

            return (jj);
        }

        public static bool ifactornotstayput()
        {
            return (hittype[g_i].actorstayput == -1);
        }

        public static bool ifcanseetarget()
        {
            bool jj = Engine.board.cansee(g_sp.x, g_sp.y, (short)(g_sp.z - ((Engine.krand() & 41) << 8)), g_sp.sectnum, ps[g_p].posx, ps[g_p].posy, ps[g_p].posz, Engine.board.sprite[ps[g_p].i].sectnum);
            if (jj)
            {
                hittype[g_i].timetosleep = DefineConstants.SLEEPTIME;
            }
            return jj;
        }
        public static bool ifcanshoottarget()
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
                    return true;
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

            return(j != 0);
        }
    }
}