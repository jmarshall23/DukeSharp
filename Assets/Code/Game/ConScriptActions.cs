using Build;
public class TrapEngine : ConTraps
{
    public override void SetSectorWallPtr(int sectNum, int value)
    {
        Engine.board.sector[sectNum].wallptr = (short)value;
    }
    public override void SetSectorWallNum(int sectNum, int value)
    {
        Engine.board.sector[sectNum].wallnum = (short)value;
    }
    public override void SetSectorCeilingZ(int sectNum, int value)
    {
        Engine.board.sector[sectNum].ceilingz = (short)value;
    }
    public override void SetSectorFloorZ(int sectNum, int value)
    {
        Engine.board.sector[sectNum].floorz = value;
    }
    public override void SetSectorCeilingStat(int sectNum, int value)
    {
        Engine.board.sector[sectNum].ceilingstat = (short)value;
    }
    public override void SetSectorFloorStat(int sectNum, int value)
    {
        Engine.board.sector[sectNum].floorstat = (short)value;
    }
    public override void SetSectorCeilingPicNum(int sectNum, int value)
    {
        Engine.board.sector[sectNum].ceilingpicnum = (short)value;
    }
    public override void SetSectorCeilingHeinum(int sectNum, int value)
    {
        Engine.board.sector[sectNum].ceilingheinum = (short)value;
    }
    public override void SetSectorCeilingShade(int sectNum, int value)
    {
        Engine.board.sector[sectNum].ceilingshade = (sbyte)value;
    }
    public override void SetSectorCeilingPal(int sectNum, int value)
    {
        Engine.board.sector[sectNum].ceilingpal = (byte)value;
    }
    public override void SetSectorCeilingxpanning(int sectNum, int value)
    {
        Engine.board.sector[sectNum].ceilingxpanning = (byte)value;
    }
    public override void SetSectorCeilingypanning(int sectNum, int value)
    {
        Engine.board.sector[sectNum].ceilingypanning = (byte)value;
    }
    public override void SetSectorFloorPicnum(int sectNum, int value)
    {
        Engine.board.sector[sectNum].floorpicnum = (short)value;
    }
    public override void SetSectorFloorheinum(int sectNum, int value)
    {
        Engine.board.sector[sectNum].floorheinum = (short)value;
    }
    public override void SetSectorFloorShade(int sectNum, int value)
    {
        Engine.board.sector[sectNum].floorshade = (sbyte)value;
    }
    public override void SetSectorFloorpal(int sectNum, int value)
    {
        Engine.board.sector[sectNum].floorpal = (byte)value;
    }
    public override void SetSectorFloorxpanning(int sectNum, int value)
    {
        Engine.board.sector[sectNum].floorxpanning = (byte)value;
    }
    public override void SetSectorFloorypanning(int sectNum, int value)
    {
        Engine.board.sector[sectNum].floorypanning = (byte)value;
    }
    public override void SetSectorVisbility(int sectNum, int value)
    {
        Engine.board.sector[sectNum].visibility = (byte)value;
    }
    public override void SetSectorFiller(int sectNum, int value)
    {
        Engine.board.sector[sectNum].filler = (byte)value;
    }
    public override void SetSectorLotag(int sectNum, int value)
    {
        Engine.board.sector[sectNum].lotag = (short)value;
    }
    public override void SetSectorHitag(int sectNum, int value)
    {
        Engine.board.sector[sectNum].hitag = (short)value;
    }
    public override void SetSectorExtra(int sectNum, int value)
    {
        Engine.board.sector[sectNum].extra = (short)value;
    }

    public override int GetSectorWallPtr(int sectNum)
    {
        return Engine.board.sector[sectNum].wallptr;
    }
    public override int GetSectorWallNum(int sectNum)
    {
        return Engine.board.sector[sectNum].wallnum;
    }
    public override int GetSectorCeilingZ(int sectNum)
    {
        return Engine.board.sector[sectNum].ceilingz;
    }
    public override int GetSectorFloorZ(int sectNum)
    {
        return Engine.board.sector[sectNum].floorz;
    }
    public override int GetSectorCeilingStat(int sectNum)
    {
        return Engine.board.sector[sectNum].ceilingstat;
    }
    public override int GetSectorFloorStat(int sectNum)
    {
        return Engine.board.sector[sectNum].floorstat;
    }
    public override int GetSectorCeilingPicNum(int sectNum)
    {
        return Engine.board.sector[sectNum].ceilingpicnum;
    }
    public override int GetSectorCeilingHeinum(int sectNum)
    {
        return Engine.board.sector[sectNum].ceilingheinum;
    }
    public override int GetSectorCeilingShade(int sectNum)
    {
        return Engine.board.sector[sectNum].ceilingshade;
    }
    public override int GetSectorCeilingPal(int sectNum)
    {
        return Engine.board.sector[sectNum].ceilingpal;
    }
    public override int GetSectorCeilingxpanning(int sectNum)
    {
        return Engine.board.sector[sectNum].ceilingxpanning;
    }
    public override int GetSectorCeilingypanning(int sectNum)
    {
        return Engine.board.sector[sectNum].ceilingypanning;
    }
    public override int GetSectorFloorPicnum(int sectNum)
    {
        return Engine.board.sector[sectNum].floorpicnum;
    }
    public override int GetSectorFloorheinum(int sectNum)
    {
        return Engine.board.sector[sectNum].floorheinum;
    }
    public override int GetSectorFloorShade(int sectNum)
    {
        return Engine.board.sector[sectNum].floorshade;
    }
    public override int GetSectorFloorpal(int sectNum)
    {
        return Engine.board.sector[sectNum].floorpal;
    }
    public override int GetSectorFloorxpanning(int sectNum)
    {
        return Engine.board.sector[sectNum].floorxpanning;
    }
    public override int GetSectorFloorypanning(int sectNum)
    {
        return Engine.board.sector[sectNum].floorypanning;
    }
    public override int GetSectorVisbility(int sectNum)
    {
        return Engine.board.sector[sectNum].visibility;
    }
    public override int GetSectorFiller(int sectNum)
    {
        return Engine.board.sector[sectNum].filler;
    }
    public override int GetSectorLotag(int sectNum)
    {
        return Engine.board.sector[sectNum].lotag;
    }
    public override int GetSectorHitag(int sectNum)
    {
        return Engine.board.sector[sectNum].hitag;
    }
    public override int GetSectorExtra(int sectNum)
    {
        return Engine.board.sector[sectNum].extra;
    }
    public override double DeltaTime()
    {
        return UnityEngine.Time.deltaTime;
    }

    public override int GetGlobalSpriteID()
    {
        return GlobalMembers.g_i;
    }

    public override int GetSpriteX(int spriteId)
    {
        return Engine.board.sprite[spriteId].x;
    }
    public override int GetSpriteY(int spriteId)
    {
        return Engine.board.sprite[spriteId].y;
    }
    public override int GetSpriteZ(int spriteId)
    {
        return Engine.board.sprite[spriteId].z;
    }
    public override int GetCStat(int spriteId)
    {
        return Engine.board.sprite[spriteId].cstat;
    }
    public override int GetPicNum(int spriteId)
    {
        return Engine.board.sprite[spriteId].picnum;
    }
    public override int GetShade(int spriteId)
    {
        return Engine.board.sprite[spriteId].shade;
    }
    public override int GetPal(int spriteId)
    {
        return Engine.board.sprite[spriteId].pal;
    }
    public override int GetClipDist(int spriteId)
    {
        return Engine.board.sprite[spriteId].clipdist;
    }
    public override int GetFiller(int spriteId)
    {
        return Engine.board.sprite[spriteId].filler;
    }
    public override int GetXRepeat(int spriteId)
    {
        return Engine.board.sprite[spriteId].xrepeat;
    }
    public override int GetYRepeat(int spriteId)
    {
        return Engine.board.sprite[spriteId].yrepeat;
    }
    public override int GetXOffset(int spriteId)
    {
        return Engine.board.sprite[spriteId].xoffset;
    }
    public override int GetYOffset(int spriteId)
    {
        return Engine.board.sprite[spriteId].yoffset;
    }
    public override int GetSectNum(int spriteId)
    {
        return Engine.board.sprite[spriteId].sectnum;
    }
    public override int GetStatNum(int spriteId)
    {
        return Engine.board.sprite[spriteId].statnum;
    }
    public override int GetAng(int spriteId)
    {
        return Engine.board.sprite[spriteId].ang;
    }
    public override int GetOwner(int spriteId)
    {
        return Engine.board.sprite[spriteId].owner;
    }
    public override int GetXVel(int spriteId)
    {
        return Engine.board.sprite[spriteId].xvel;
    }
    public override int GetYVel(int spriteId)
    {
        return Engine.board.sprite[spriteId].yvel;
    }
    public override int GetZVel(int spriteId)
    {
        return Engine.board.sprite[spriteId].zvel;
    }
    public override int GetLotag(int spriteId)
    {
        return Engine.board.sprite[spriteId].lotag;
    }
    public override int GetHitag(int spriteId)
    {
        return Engine.board.sprite[spriteId].hitag;
    }
    public override int GetExtra(int spriteId)
    {
        return Engine.board.sprite[spriteId].extra;
    }

    public override void SetSpriteX(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].x = value;
    }
    public override void SetSpriteY(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].y = value;
    }
    public override void SetSpriteZ(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].z = value;
    }

    public override void SetCStat(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].cstat = (short)value;
    }
    public override void SetPicNum(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].picnum = (short)value;
    }
    public override void SetShade(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].shade = (sbyte)value;
    }
    public override void SetPal(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].pal = (byte)value;
    }
    public override void SetClipDist(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].clipdist = (byte)value;
    }
    public override void SetFiller(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].filler = (byte)value;
    }
    public override void SetXRepeat(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].xrepeat = (byte)value;
    }
    public override void SetYRepeat(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].yrepeat = (byte)value;
    }
    public override void SetXOffset(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].xoffset = (sbyte)value;
    }
    public override void SetYOffset(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].yoffset = (sbyte)value;
    }
    public override void SetSectNum(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].sectnum = (short)value;
    }
    public override void SetStatNum(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].statnum = (short)value;
    }
    public override void SetAng(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].ang = (short)value;
    }
    public override void SetOwner(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].owner = (short)value;
    }
    public override void SetXVel(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].xvel = (short)value;
    }
    public override void SetYVel(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].yvel = (short)value;
    }
    public override void SetZVel(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].zvel = (short)value;
    }
    public override void SetLotag(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].lotag = (short)value;
    }
    public override void SetHitag(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].hitag = (short)value;
    }
    public override void SetExtra(int spriteId, int value)
    {
        Engine.board.sprite[spriteId].extra = (short)value;
    }

    public override void RegisterVoxel(string voxel)
    {
        string temp = "";
        bool nukeStart = true;
        int tileid = 0;

        for(int i = 0; i < voxel.Length; i++)
        {
            if(nukeStart)
            {
                if(voxel[i] == '0')
                {
                    continue;
                }
                nukeStart = false;                
            }

            if (voxel[i] == '_')
                break;

            temp += voxel[i];
        }

        tileid = int.Parse(temp);

        Engine.qloadkvx(GlobalMembers.nextvoxid, "voxels/" + voxel);
        Engine.tiletovox[tileid] = GlobalMembers.nextvoxid++;
    }

// jmarshall - these functions are hacks because stuff isn't exposed enough to DukeScript but allowed me to move over fire* functions.
    public override void chaingunprojectileshift(int sprite)
    {
        Engine.board.sprite[sprite].ang += 1024;
        Engine.board.sprite[sprite].ang &= 2047;
        Engine.board.sprite[sprite].xvel += 32;
        Engine.board.sprite[sprite].z += (3 << 8);
    }

    public override void tripbombresetposz()
    {
        player_struct p;        
        p = GlobalMembers.ps[GlobalMembers.g_p];
        p.posz = p.oposz;
        p.poszv = 0;
    }
// jmarshall end
    public override int sgn(int i1)
    {
        return pragmas.sgn(i1);
    }

    public override int sintable(int index)
    {
        return Engine.table.sintable[index];
    }

    public override int getspritepal(int index)
    {
        return Engine.board.sprite[index].pal;
    }

    public override uint krand()
    {
        return Engine.krand();
    }
    public override void gamestartup(params int[] parms)
    {
        for (int j = 0; j < parms.Length; j++)
        {
            switch (j)
            {
                case 0:
                    GlobalMembers.ud.const_visibility = parms[j];
                    break;
                case 1:
                    GlobalMembers.impact_damage = parms[j];
                    break;
                case 2:
                    GlobalMembers.max_player_health = parms[j];
                    break;
                case 3:
                    GlobalMembers.max_armour_amount = parms[j];
                    break;
                case 4:
                    GlobalMembers.respawnactortime = parms[j]; break;
                case 5:
                    GlobalMembers.respawnitemtime = parms[j]; break;
                case 6:
                    GlobalMembers.dukefriction = parms[j]; break;
                case 7:
                    GlobalMembers.gc = parms[j]; break;
                case 8: GlobalMembers.rpgblastradius = parms[j]; break;
                case 9: GlobalMembers.pipebombblastradius = parms[j]; break;
                case 10: GlobalMembers.shrinkerblastradius = parms[j]; break;
                case 11: GlobalMembers.tripbombblastradius = parms[j]; break;
                case 12: GlobalMembers.morterblastradius = parms[j]; break;
                case 13: GlobalMembers.bouncemineblastradius = parms[j]; break;
                case 14: GlobalMembers.seenineblastradius = parms[j]; break;

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
                        GlobalMembers.max_ammo_amount[11] = parms[j];
                    else GlobalMembers.max_ammo_amount[j - 14] = parms[j];
                    break;
                case 25:
                    GlobalMembers.camerashitable = (char)parms[j];
                    break;
                case 26:
                    GlobalMembers.numfreezebounces = parms[j];
                    break;
                case 27:
                    GlobalMembers.freezerhurtowner = parms[j];
                    break;
                case 28:
                    GlobalMembers.spriteqamount = (short)parms[j];
                    if (GlobalMembers.spriteqamount > 1024) GlobalMembers.spriteqamount = 1024;
                    else if (GlobalMembers.spriteqamount < 0) GlobalMembers.spriteqamount = 0;
                    break;
                case 29:
                    GlobalMembers.lasermode = (char)parms[j];
                    break;
            }
        }
    }
    public override void definemusic(int episode, params string[] music)
    {
        int k = episode;
        for (int i = 0; i < music.Length; i++)
        {
            GlobalMembers.music_fn[k, i] = music[i];
        }
    }
    public override void definesound(int id, string filename, int var1, int var2, int var3, int var4, int var5)
    {
        GlobalMembers.sounds[id] = filename;
        GlobalMembers.soundps[id] = (short)var1;
        GlobalMembers.soundpr[id] = var2;
        GlobalMembers.soundm[id] = var3;
        GlobalMembers.soundvo[id] = (short)var4;
    }
    public override void definelevelname(int episode, int level, string mapfile, string time1, string time2, string name)
    {
        int index = episode * 11 + level;
        GlobalMembers.level_file_names[index] = mapfile;
        GlobalMembers.partime[index] = time1; // jmarshall: partime
        GlobalMembers.designertime[index] = time2; // jmarshall: designertime
        GlobalMembers.level_names[index] = name.ToUpper();
    }
    public override void defineskillname(int id, string name)
    {
        GlobalMembers.skill_names[id] = name;
    }
    public override void definevolumename(int id, string name)
    {
        GlobalMembers.volume_names[id] = name;
    }
    public override void definequote(int id, string str)
    {
        GlobalMembers.fta_quotes[id] = str;
    }
    public override void RegisterActor(ScriptActorRegistration.Function_t function, int picnum, int aiType, int aiType2 = 0, ConAction action = null, MoveAction unknown2 = null, int unknown3 = 0, int unknown4 = 0)
    {
        GlobalMembers.scriptActorRegPtr[picnum] = new ScriptActorRegistration();
        GlobalMembers.scriptActorRegPtr[picnum].func = function;
        GlobalMembers.scriptActorRegPtr[picnum].aiType = aiType;
        GlobalMembers.scriptActorRegPtr[picnum].aiType2 = aiType2;
        GlobalMembers.scriptActorRegPtr[picnum].action = action;

        GlobalMembers.actortype[picnum] = 1;
    }

    public override void myospal(int x, int y, int tilenum, int shade, int orientation, int p)
    {
        GlobalMembers.myospal(x, y, tilenum, shade, orientation, p);
    }

    public override int totalclock()
    {
        return Engine.totalclocklock;
    }

    internal static int j;
    internal static bool jj = false;
    internal static int l;
    internal static int s;
    internal static short temphit = 0;

    public override bool ifnosounds()
    {
        for (j = 1; j < DefineConstants.NUM_SOUNDS; j++)
        {
            if (GlobalMembers.SoundOwner[j, 0].i == GlobalMembers.g_i)
            {
                break;
            }
        }

        return (j == DefineConstants.NUM_SOUNDS);
    }
    public override bool ifangdiffl(int value)
    {
        j = pragmas.klabs(GlobalMembers.getincangle(GlobalMembers.ps[GlobalMembers.g_p].ang, GlobalMembers.g_sp.ang));
        return (j <= value);
    }
    public override bool ifspritepal(int value)
    {
        return (GlobalMembers.g_sp.pal == value);
    }

    public override void respawnhitag()
    {
        switch (GlobalMembers.g_sp.picnum)
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
                if (GlobalMembers.g_sp.yvel != 0)
                {
                    GlobalMembers.operaterespawns(GlobalMembers.g_sp.yvel);
                }
                break;
            default:
                if (GlobalMembers.g_sp.hitag >= 0)
                {
                    GlobalMembers.operaterespawns(GlobalMembers.g_sp.hitag);
                }
                break;
        }
    }
    public override bool ifnotmoving()
    {
        return (GlobalMembers.hittype[GlobalMembers.g_i].movflag & 49152) > 16384;
    }
    public override bool ifinouterspace()
    {
        return (GlobalMembers.floorspace(GlobalMembers.g_sp.sectnum) != 0);
    }
    public override void quote(int value)
    {
        GlobalMembers.FTA((short)value, GlobalMembers.ps[GlobalMembers.g_p]);
    }
    public override bool ifawayfromwall()
    {
        short s1;

        s1 = GlobalMembers.g_sp.sectnum;

        j = 0;

        Engine.board.updatesector(GlobalMembers.g_sp.x + 108, GlobalMembers.g_sp.y + 108, ref s1);
        if (s1 == GlobalMembers.g_sp.sectnum)
        {
            Engine.board.updatesector(GlobalMembers.g_sp.x - 108, GlobalMembers.g_sp.y - 108, ref s1);
            if (s1 == GlobalMembers.g_sp.sectnum)
            {
                Engine.board.updatesector(GlobalMembers.g_sp.x + 108, GlobalMembers.g_sp.y - 108, ref s1);
                if (s1 == GlobalMembers.g_sp.sectnum)
                {
                    Engine.board.updatesector(GlobalMembers.g_sp.x - 108, GlobalMembers.g_sp.y + 108, ref s1);
                    if (s1 == GlobalMembers.g_sp.sectnum)
                    {
                        j = 1;
                    }
                }
            }
        }
        return (j != 0);
    }
    public override void pstomp()
    {
        if (GlobalMembers.ps[GlobalMembers.g_p].knee_incs == 0 && Engine.board.sprite[GlobalMembers.ps[GlobalMembers.g_p].i].xrepeat >= 40)
        {
            if (Engine.board.cansee(GlobalMembers.g_sp.x, GlobalMembers.g_sp.y, GlobalMembers.g_sp.z - (4 << 8), GlobalMembers.g_sp.sectnum, GlobalMembers.ps[GlobalMembers.g_p].posx, GlobalMembers.ps[GlobalMembers.g_p].posy, GlobalMembers.ps[GlobalMembers.g_p].posz + (16 << 8), Engine.board.sprite[GlobalMembers.ps[GlobalMembers.g_p].i].sectnum))
            {
                GlobalMembers.ps[GlobalMembers.g_p].knee_incs = 1;
                if (GlobalMembers.ps[GlobalMembers.g_p].weapon_pos == 0)
                {
                    GlobalMembers.ps[GlobalMembers.g_p].weapon_pos = -1;
                }
                GlobalMembers.ps[GlobalMembers.g_p].actorsqu = GlobalMembers.g_i;
            }
        }
    }

    public override bool ifpinventory(int val1, int val2)
    {
        j = 0;
        switch (val1)
        {
            case 0:
                if (GlobalMembers.ps[GlobalMembers.g_p].steroids_amount != (short)val2)
                {
                    j = 1;
                }
                break;
            case 1:
                if (GlobalMembers.ps[GlobalMembers.g_p].shield_amount != GlobalMembers.max_player_health)
                {
                    j = 1;
                }
                break;
            case 2:
                if (GlobalMembers.ps[GlobalMembers.g_p].scuba_amount != (short)val2)
                {
                    j = 1;
                }
                break;
            case 3:
                if (GlobalMembers.ps[GlobalMembers.g_p].holoduke_amount != (short)val2)
                {
                    j = 1;
                }
                break;
            case 4:
                if (GlobalMembers.ps[GlobalMembers.g_p].jetpack_amount != (short)val2)
                {
                    j = 1;
                }
                break;
            case 6:
                switch (GlobalMembers.g_sp.pal)
                {
                    case 0:
                        if ((GlobalMembers.ps[GlobalMembers.g_p].got_access & 1) != 0)
                        {
                            j = 1;
                        }
                        break;
                    case 21:
                        if ((GlobalMembers.ps[GlobalMembers.g_p].got_access & 2) != 0)
                        {
                            j = 1;
                        }
                        break;
                    case 23:
                        if ((GlobalMembers.ps[GlobalMembers.g_p].got_access & 4) != 0)
                        {
                            j = 1;
                        }
                        break;
                }
                break;
            case 7:
                if (GlobalMembers.ps[GlobalMembers.g_p].heat_amount != (short)val2)
                {
                    j = 1;
                }
                break;
            case 9:
                if (GlobalMembers.ps[GlobalMembers.g_p].firstaid_amount != (short)val2)
                {
                    j = 1;
                }
                break;
            case 10:
                if (GlobalMembers.ps[GlobalMembers.g_p].boot_amount != (short)val2)
                {
                    j = 1;
                }
                break;
        }

        return (j != 0);
    }

    public override bool ifphealthl(int value)
    {
        return (Engine.board.sprite[GlobalMembers.ps[GlobalMembers.g_p].i].extra < value);
    }
    public override void palfrom(int v1 = 0, int v2 = 0, int v3 = 0, int v4 = 0)
    {
        GlobalMembers.ps[GlobalMembers.g_p].pals_time = v1;
        GlobalMembers.ps[GlobalMembers.g_p].pals[0] = (byte)v2;
        GlobalMembers.ps[GlobalMembers.g_p].pals[1] = (byte)v3;
        GlobalMembers.ps[GlobalMembers.g_p].pals[2] = (byte)v4;
    }
    public override bool ifceilingdistl(int val)
    {
        return ((GlobalMembers.g_sp.z - GlobalMembers.hittype[GlobalMembers.g_i].ceilingz) <= (((short)val) << 8));
    }
    public override bool iffloordistl(int val)
    {
        return ((GlobalMembers.hittype[GlobalMembers.g_i].floorz - GlobalMembers.g_sp.z) <= (((short)val) << 8));
    }
    public override bool ifrespawn()
    {
        if (GlobalMembers.badguy(GlobalMembers.g_sp) != 0)
        {
            return (GlobalMembers.ud.respawn_monsters != 0);
        }
        else if (GlobalMembers.inventory(GlobalMembers.g_sp) != 0)
        {
            return (GlobalMembers.ud.respawn_inventory != 0);
        }
        else
        {
            return (GlobalMembers.ud.respawn_items != 0);
        }
    }
    public override bool ifbulletnear()
    {
        return (GlobalMembers.dodge(GlobalMembers.g_sp) == 1);
    }
    public override void cactor(int value)
    {
        GlobalMembers.g_sp.picnum = (short)value;
    }
    public override void spritepal(int value)
    {
        if (GlobalMembers.g_sp.picnum != DefineConstants.APLAYER)
        {
            GlobalMembers.hittype[GlobalMembers.g_i].tempang = GlobalMembers.g_sp.pal;
        }
        GlobalMembers.g_sp.pal = (byte)value;
    }
    public override bool ifinspace()
    {
        return (GlobalMembers.ceilingspace(GlobalMembers.g_sp.sectnum) != 0);
    }
    public override void operate()
    {
        if (Engine.board.sector[GlobalMembers.g_sp.sectnum].lotag == 0)
        {
            Engine.board.neartag(GlobalMembers.g_sp.x, GlobalMembers.g_sp.y, GlobalMembers.g_sp.z - (32 << 8), GlobalMembers.g_sp.sectnum, GlobalMembers.g_sp.ang, ref GlobalMembers.neartagsector, ref GlobalMembers.neartagwall, ref GlobalMembers.neartagsprite, ref GlobalMembers.neartaghitdist, 768, 1);
            if (GlobalMembers.neartagsector >= 0 && GlobalMembers.isanearoperator(Engine.board.sector[GlobalMembers.neartagsector].lotag))
            {
                if ((Engine.board.sector[GlobalMembers.neartagsector].lotag & 0xff) == 23 || Engine.board.sector[GlobalMembers.neartagsector].floorz == Engine.board.sector[GlobalMembers.neartagsector].ceilingz)
                {
                    if ((Engine.board.sector[GlobalMembers.neartagsector].lotag & 16384) == 0)
                    {
                        if ((Engine.board.sector[GlobalMembers.neartagsector].lotag & 32768) == 0)
                        {
                            j = Engine.board.headspritesect[GlobalMembers.neartagsector];
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
                                GlobalMembers.operatesectors(GlobalMembers.neartagsector, GlobalMembers.g_i);
                            }
                        }
                    }
                }
            }
        }
    }
    public override bool ifmultiplayer()
    {
        return (GlobalMembers.ud.multimode > 1);
    }
    public override bool ifoutside()
    {
        return ((Engine.board.sector[GlobalMembers.g_sp.sectnum].ceilingstat & 1) != 0);
    }
    public override bool ifhitspace()
    {
        return ((GlobalMembers.sync[GlobalMembers.g_p].bits & (1 << 29)) != 0);
    }
    public override bool ifgapzl(int val)
    {
        return (((GlobalMembers.hittype[GlobalMembers.g_i].floorz - GlobalMembers.hittype[GlobalMembers.g_i].ceilingz) >> 8) < (short)val);
    }
    public override void wackplayer()
    {
        GlobalMembers.forceplayerangle(GlobalMembers.ps[GlobalMembers.g_p]);
    }

    public override bool ifspawnedby(int value)
    {
        return (GlobalMembers.hittype[GlobalMembers.g_i].picnum == (short)value);
    }

    public override void guts(int value1, int value2)
    {
        GlobalMembers.guts(GlobalMembers.g_sp, (short)value1, (short)value2, GlobalMembers.g_p);
    }

    public override bool ifstrength(int value)
    {
        return (GlobalMembers.g_sp.extra <= (short)value);
    }

    public override bool ifp(int value, object notused = null, object notused2 = null, object notused3 = null, object notused4 = null)
    {
        l = (short)value;
        j = 0;

        s = GlobalMembers.g_sp.xvel;

        if ((l & 8) != 0 && GlobalMembers.ps[GlobalMembers.g_p].on_ground != 0 && (GlobalMembers.sync[GlobalMembers.g_p].bits & 2) != 0)
        {
            j = 1;
        }
        else if ((l & 16) != 0 && GlobalMembers.ps[GlobalMembers.g_p].jumping_counter == 0 && GlobalMembers.ps[GlobalMembers.g_p].on_ground == 0 && GlobalMembers.ps[GlobalMembers.g_p].poszv > 2048)
        {
            j = 1;
        }
        else if ((l & 32) != 0 && GlobalMembers.ps[GlobalMembers.g_p].jumping_counter > 348)
        {
            j = 1;
        }
        else if ((l & 1) != 0 && s >= 0 && s < 8)
        {
            j = 1;
        }
        else if ((l & 2) != 0 && s >= 8 && 0 == (GlobalMembers.sync[GlobalMembers.g_p].bits & (1 << 5)))
        {
            j = 1;
        }
        else if ((l & 4) != 0 && s >= 8 && 1 == (GlobalMembers.sync[GlobalMembers.g_p].bits & (1 << 5)))
        {
            j = 1;
        }
        else if ((l & 64) != 0 && GlobalMembers.ps[GlobalMembers.g_p].posz < (GlobalMembers.g_sp.z - (48 << 8)))
        {
            j = 1;
        }
        else if ((l & 128) != 0 && s <= -8 && 0 == (GlobalMembers.sync[GlobalMembers.g_p].bits & (1 << 5)))
        {
            j = 1;
        }
        else if ((l & 256) != 0 && s <= -8 && 1 == (GlobalMembers.sync[GlobalMembers.g_p].bits & (1 << 5)))
        {
            j = 1;
        }
        else if ((l & 512) != 0 && (GlobalMembers.ps[GlobalMembers.g_p].quick_kick > 0 || (GlobalMembers.ps[GlobalMembers.g_p].curr_weapon == DefineConstants.KNEE_WEAPON && GlobalMembers.ps[GlobalMembers.g_p].kickback_pic > 0)))
        {
            j = 1;
        }
        else if ((l & 1024) != 0 && Engine.board.sprite[GlobalMembers.ps[GlobalMembers.g_p].i].xrepeat < 32)
        {
            j = 1;
        }
        else if ((l & 2048) != 0 && GlobalMembers.ps[GlobalMembers.g_p].jetpack_on != 0)
        {
            j = 1;
        }
        else if ((l & 4096) != 0 && GlobalMembers.ps[GlobalMembers.g_p].steroids_amount > 0 && GlobalMembers.ps[GlobalMembers.g_p].steroids_amount < 400)
        {
            j = 1;
        }
        else if ((l & 8192) != 0 && GlobalMembers.ps[GlobalMembers.g_p].on_ground != 0)
        {
            j = 1;
        }
        else if ((l & 16384) != 0 && Engine.board.sprite[GlobalMembers.ps[GlobalMembers.g_p].i].xrepeat > 32 && Engine.board.sprite[GlobalMembers.ps[GlobalMembers.g_p].i].extra > 0 && GlobalMembers.ps[GlobalMembers.g_p].timebeforeexit == 0)
        {
            j = 1;
        }
        else if ((l & 32768) != 0 && Engine.board.sprite[GlobalMembers.ps[GlobalMembers.g_p].i].extra <= 0)
        {
            j = 1;
        }
        else if ((l & 65536) != 0)
        {
            if (GlobalMembers.g_sp.picnum == DefineConstants.APLAYER && GlobalMembers.ud.multimode > 1)
            {
                j = GlobalMembers.getincangle(GlobalMembers.ps[GlobalMembers.otherp].ang, (short)Engine.getangle(GlobalMembers.ps[GlobalMembers.g_p].posx - GlobalMembers.ps[GlobalMembers.otherp].posx, GlobalMembers.ps[GlobalMembers.g_p].posy - GlobalMembers.ps[GlobalMembers.otherp].posy));
            }
            else
            {
                j = GlobalMembers.getincangle(GlobalMembers.ps[GlobalMembers.g_p].ang, (short)Engine.getangle(GlobalMembers.g_sp.x - GlobalMembers.ps[GlobalMembers.g_p].posx, GlobalMembers.g_sp.y - GlobalMembers.ps[GlobalMembers.g_p].posy));
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

    public override void hitradius(int val1 = 0, int val2 = 0, int val3 = 0, int val4 = 0, int val5 = 0)
    {
        GlobalMembers.hitradius(GlobalMembers.g_i, ((short)val1), val2, val3, val4, val5);
    }

    public override void addinventory(int val1, int val2)
    {
        switch ((short)val1)
        {
            case 0:
                GlobalMembers.ps[GlobalMembers.g_p].steroids_amount = (short)val2;
                GlobalMembers.ps[GlobalMembers.g_p].inven_icon = 2;
                break;
            case 1:
                GlobalMembers.ps[GlobalMembers.g_p].shield_amount += (short)val2; // 100;
                if (GlobalMembers.ps[GlobalMembers.g_p].shield_amount > GlobalMembers.max_player_health)
                {
                    GlobalMembers.ps[GlobalMembers.g_p].shield_amount = (short)GlobalMembers.max_player_health;
                }
                break;
            case 2:
                GlobalMembers.ps[GlobalMembers.g_p].scuba_amount = (short)val2; // 1600;
                GlobalMembers.ps[GlobalMembers.g_p].inven_icon = 6;
                break;
            case 3:
                GlobalMembers.ps[GlobalMembers.g_p].holoduke_amount = (short)val2; // 1600;
                GlobalMembers.ps[GlobalMembers.g_p].inven_icon = 3;
                break;
            case 4:
                GlobalMembers.ps[GlobalMembers.g_p].jetpack_amount = (short)val2; // 1600;
                GlobalMembers.ps[GlobalMembers.g_p].inven_icon = 4;
                break;
            case 6:
                switch (GlobalMembers.g_sp.pal)
                {
                    case 0:
                        GlobalMembers.ps[GlobalMembers.g_p].got_access |= 1;
                        break;
                    case 21:
                        GlobalMembers.ps[GlobalMembers.g_p].got_access |= 2;
                        break;
                    case 23:
                        GlobalMembers.ps[GlobalMembers.g_p].got_access |= 4;
                        break;
                }
                break;
            case 7:
                GlobalMembers.ps[GlobalMembers.g_p].heat_amount = (short)val2;
                GlobalMembers.ps[GlobalMembers.g_p].inven_icon = 5;
                break;
            case 9:
                GlobalMembers.ps[GlobalMembers.g_p].inven_icon = 1;
                GlobalMembers.ps[GlobalMembers.g_p].firstaid_amount = (short)val2;
                break;
            case 10:
                GlobalMembers.ps[GlobalMembers.g_p].inven_icon = 7;
                GlobalMembers.ps[GlobalMembers.g_p].boot_amount = (short)val2;
                break;
        }
    }
    public override void resetcount()
    {
        GlobalMembers.hittype[GlobalMembers.g_i].count = 0;
    }
    public override bool ifactor(int val1)
    {
        return (GlobalMembers.g_sp.picnum == (short)val1);
    }
    public override bool ifcount(int val)
    {
        int v = GlobalMembers.hittype[GlobalMembers.g_i].count;
        return (v >= (short)val);
    }
    public override bool ifinwater()
    {
        return (Engine.board.sector[GlobalMembers.g_sp.sectnum].lotag == 2);
    }
    public override bool ifonwater()
    {
        return (pragmas.klabs(GlobalMembers.g_sp.z - Engine.board.sector[GlobalMembers.g_sp.sectnum].floorz) < (32 << 8) && Engine.board.sector[GlobalMembers.g_sp.sectnum].lotag == 1);
    }
    public override void resetplayer()
    {
        if (GlobalMembers.ud.multimode < 2)
        {
            if (GlobalMembers.lastsavedpos >= 0 && GlobalMembers.ud.recstat != 2)
            {
                GlobalMembers.ps[GlobalMembers.g_p].gm = DefineConstants.MODE_MENU;
                {
                    GlobalMembers.KB_KeyDown[(DefineConstants.sc_Space)] = (!(1 == 1));
                };
                GlobalMembers.cmenu(15000);
            }
            else
            {
                GlobalMembers.ps[GlobalMembers.g_p].gm = DefineConstants.MODE_RESTART;
            }
            GlobalMembers.killit_flag = (char)2;
        }
        else
        {
            GlobalMembers.pickrandomspot(GlobalMembers.g_p);
            GlobalMembers.g_sp.x = GlobalMembers.hittype[GlobalMembers.g_i].bposx = GlobalMembers.ps[GlobalMembers.g_p].bobposx = GlobalMembers.ps[GlobalMembers.g_p].oposx = GlobalMembers.ps[GlobalMembers.g_p].posx;
            GlobalMembers.g_sp.y = GlobalMembers.hittype[GlobalMembers.g_i].bposy = GlobalMembers.ps[GlobalMembers.g_p].bobposy = GlobalMembers.ps[GlobalMembers.g_p].oposy = GlobalMembers.ps[GlobalMembers.g_p].posy;
            GlobalMembers.g_sp.z = GlobalMembers.hittype[GlobalMembers.g_i].bposy = GlobalMembers.ps[GlobalMembers.g_p].oposz = GlobalMembers.ps[GlobalMembers.g_p].posz;
            Engine.board.updatesector(GlobalMembers.ps[GlobalMembers.g_p].posx, GlobalMembers.ps[GlobalMembers.g_p].posy, ref GlobalMembers.ps[GlobalMembers.g_p].cursectnum);
            Engine.board.setsprite(GlobalMembers.ps[GlobalMembers.g_p].i, GlobalMembers.ps[GlobalMembers.g_p].posx, GlobalMembers.ps[GlobalMembers.g_p].posy, GlobalMembers.ps[GlobalMembers.g_p].posz + (38 << 8));
            GlobalMembers.g_sp.cstat = 257;

            GlobalMembers.g_sp.shade = -12;
            GlobalMembers.g_sp.clipdist = 64;
            GlobalMembers.g_sp.xrepeat = 42;
            GlobalMembers.g_sp.yrepeat = 36;
            GlobalMembers.g_sp.owner = GlobalMembers.g_i;
            GlobalMembers.g_sp.xoffset = 0;
            //g_sp.pal = ps[g_p].palookup; // jmarshall palette

            GlobalMembers.ps[GlobalMembers.g_p].last_extra = GlobalMembers.g_sp.extra = (short)GlobalMembers.max_player_health;
            GlobalMembers.ps[GlobalMembers.g_p].wantweaponfire = -1;
            GlobalMembers.ps[GlobalMembers.g_p].horiz = 100;
            GlobalMembers.ps[GlobalMembers.g_p].on_crane = -1;
            GlobalMembers.ps[GlobalMembers.g_p].frag_ps = GlobalMembers.g_p;
            GlobalMembers.ps[GlobalMembers.g_p].horizoff = 0;
            GlobalMembers.ps[GlobalMembers.g_p].opyoff = 0;
            GlobalMembers.ps[GlobalMembers.g_p].wackedbyactor = -1;
            GlobalMembers.ps[GlobalMembers.g_p].shield_amount = (short)GlobalMembers.max_armour_amount;
            GlobalMembers.ps[GlobalMembers.g_p].dead_flag = 0;
            GlobalMembers.ps[GlobalMembers.g_p].pals_time = 0;
            GlobalMembers.ps[GlobalMembers.g_p].footprintcount = (char)0;
            GlobalMembers.ps[GlobalMembers.g_p].weapreccnt = 0;
            GlobalMembers.ps[GlobalMembers.g_p].fta = 0;
            GlobalMembers.ps[GlobalMembers.g_p].ftq = 0;
            GlobalMembers.ps[GlobalMembers.g_p].posxv = GlobalMembers.ps[GlobalMembers.g_p].posyv = 0;
            GlobalMembers.ps[GlobalMembers.g_p].rotscrnang = 0;

            GlobalMembers.ps[GlobalMembers.g_p].falling_counter = (char)0;

            GlobalMembers.hittype[GlobalMembers.g_i].extra = -1;
            GlobalMembers.hittype[GlobalMembers.g_i].owner = GlobalMembers.g_i;

            GlobalMembers.hittype[GlobalMembers.g_i].cgg = (char)0;
            GlobalMembers.hittype[GlobalMembers.g_i].movflag = 0;
            GlobalMembers.hittype[GlobalMembers.g_i].tempang = 0;
            GlobalMembers.hittype[GlobalMembers.g_i].actorstayput = -1;
            GlobalMembers.hittype[GlobalMembers.g_i].dispicnum = 0;
            GlobalMembers.hittype[GlobalMembers.g_i].owner = GlobalMembers.ps[GlobalMembers.g_p].i;

            GlobalMembers.resetinventory(GlobalMembers.g_p);
            GlobalMembers.resetweapons(GlobalMembers.g_p);

            GlobalMembers.cameradist = 0;
            GlobalMembers.cameraclock = GlobalMembers.totalclock;
        }
        // setpal(ps[g_p]);// jmarshall palette
    }
    public override bool ifmove(MoveAction val1)
    {
        return GlobalMembers.hittype[GlobalMembers.g_i].moveAction == val1;
    }

    public override void cstat(int value)
    {
        GlobalMembers.g_sp.cstat = (short)value;
    }
    public override void clipdist(int value)
    {
        GlobalMembers.g_sp.clipdist = (byte)value;
    }
    public override void cstator(int value)
    {
        GlobalMembers.g_sp.cstat |= (short)value;
    }
    public override void count(int value)
    {
        GlobalMembers.hittype[GlobalMembers.g_i].count = value;
    }
    public override void debris(int val1, int val2)
    {
        short dnum;

        dnum = (short)val1;

        if (GlobalMembers.g_sp.sectnum >= 0 && GlobalMembers.g_sp.sectnum < DefineConstants.MAXSECTORS)
        {
            for (j = ((short)val2) - 1; j >= 0; j--)
            {
                if (GlobalMembers.g_sp.picnum == DefineConstants.BLIMP && dnum == DefineConstants.SCRAP1)
                {
                    s = 0;
                }
                else
                {
                    s = (short)(Engine.krand() % 3);
                }

                l = GlobalMembers.EGS(GlobalMembers.g_sp.sectnum, GlobalMembers.g_sp.x + (Engine.krand() & 255) - 128, GlobalMembers.g_sp.y + (Engine.krand() & 255) - 128, GlobalMembers.g_sp.z - (8 << 8) - (Engine.krand() & 8191), dnum + s, GlobalMembers.g_sp.shade, (sbyte)(32 + (Engine.krand() & 15)), (sbyte)(32 + (Engine.krand() & 15)), (short)(Engine.krand() & 2047), (short)((Engine.krand() & 127) + 32), -(Engine.krand() & 2047), GlobalMembers.g_i, 5);
                if (GlobalMembers.g_sp.picnum == DefineConstants.BLIMP && dnum == DefineConstants.SCRAP1)
                {
                    Engine.board.sprite[l].yvel = GlobalMembers.weaponsandammosprites[j % 14];
                }
                else
                {
                    Engine.board.sprite[l].yvel = -1;
                }
                Engine.board.sprite[l].pal = GlobalMembers.g_sp.pal;
            }
        }
    }
    public override bool ifrnd(int val1)
    {
        return (((Engine.krand() >> 8) >= (255 - (val1))));
    }
    public override void resetactioncount()
    {
        GlobalMembers.hittype[GlobalMembers.g_i].actioncount = 0;
    }
    public override bool ifactioncount(int val1)
    {
        return (GlobalMembers.hittype[GlobalMembers.g_i].actioncount >= (short)val1);
    }

    public override void SetAction(ConAction action)
    {
        GlobalMembers.hittype[GlobalMembers.g_i].actioncount = 0;
        GlobalMembers.hittype[GlobalMembers.g_i].animcounter = 0;
        GlobalMembers.hittype[GlobalMembers.g_i].action = action;
    }

    public override bool ifaction(ConAction action)
    {
        return (GlobalMembers.hittype[GlobalMembers.g_i].action == action);
    }

    public override void Ai(AIAction ai)
    {
        GlobalMembers.hittype[GlobalMembers.g_i].aiaction = ai;
        GlobalMembers.hittype[GlobalMembers.g_i].action = ai.action; // Action
        GlobalMembers.hittype[GlobalMembers.g_i].moveAction = ai.moveAction; // move
        GlobalMembers.g_sp.hitag = (short)ai.val; // Ai
        GlobalMembers.hittype[GlobalMembers.g_i].count = GlobalMembers.hittype[GlobalMembers.g_i].actioncount = GlobalMembers.hittype[GlobalMembers.g_i].animcounter = 0;
        if ((GlobalMembers.g_sp.hitag & DefineConstants.random_angle) != 0)
        {
            GlobalMembers.g_sp.ang = (short)(Engine.krand() & 2047);
        }
    }
    public override bool ifai(AIAction ai)
    {
        return (GlobalMembers.hittype[GlobalMembers.g_i].aiaction == ai);
    }

    public override bool ifwasweapon(int val)
    {
        return (GlobalMembers.hittype[GlobalMembers.g_i].picnum == (short)val);
    }

    public override void adjustspriteang(int sprite, int ang)
    {
        Engine.board.sprite[sprite].ang += (short)ang;
    }

    public override short ssp(short i, uint cliptype)
    {
        return GlobalMembers.ssp(i, cliptype);
    }

    public override int spawn(int val)
    {
        int j = -1;
        if (GlobalMembers.g_sp.sectnum >= 0 && GlobalMembers.g_sp.sectnum < DefineConstants.MAXSECTORS)
        {
            j = GlobalMembers.spawn(GlobalMembers.g_i, (short)val);
        }
        return j;
    }

    public override void Move(MoveAction val, int val2 = 0, int val3 = 0, int unknown1 = 0)
    {
        GlobalMembers.hittype[GlobalMembers.g_i].count = 0;
        GlobalMembers.hittype[GlobalMembers.g_i].moveAction = val;
        GlobalMembers.g_sp.hitag = (short)val2;
        if ((GlobalMembers.g_sp.hitag & DefineConstants.random_angle) != 0)
        {
            GlobalMembers.g_sp.ang = (short)(Engine.krand() & 2047);
        }
    }

    public override void Move(int val, int val2 = 0)
    {
        if (val != 0)
            throw new System.Exception("Move val not null");

        GlobalMembers.hittype[GlobalMembers.g_i].count = 0;
        GlobalMembers.hittype[GlobalMembers.g_i].moveAction = null;
        GlobalMembers.g_sp.hitag = (short)val2;
        if ((GlobalMembers.g_sp.hitag & DefineConstants.random_angle) != 0)
        {
            GlobalMembers.g_sp.ang = (short)(Engine.krand() & 2047);
        }
    }


    public override void addphealth(int val)
    {
        if (GlobalMembers.ps[GlobalMembers.g_p].newowner >= 0)
        {
            GlobalMembers.ps[GlobalMembers.g_p].newowner = -1;
            GlobalMembers.ps[GlobalMembers.g_p].posx = GlobalMembers.ps[GlobalMembers.g_p].oposx;
            GlobalMembers.ps[GlobalMembers.g_p].posy = GlobalMembers.ps[GlobalMembers.g_p].oposy;
            GlobalMembers.ps[GlobalMembers.g_p].posz = GlobalMembers.ps[GlobalMembers.g_p].oposz;
            GlobalMembers.ps[GlobalMembers.g_p].ang = GlobalMembers.ps[GlobalMembers.g_p].oang;
            Engine.board.updatesector(GlobalMembers.ps[GlobalMembers.g_p].posx, GlobalMembers.ps[GlobalMembers.g_p].posy, ref GlobalMembers.ps[GlobalMembers.g_p].cursectnum);
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

        j = Engine.board.sprite[GlobalMembers.ps[GlobalMembers.g_p].i].extra;

        if (GlobalMembers.g_sp.picnum != DefineConstants.ATOMICHEALTH)
        {
            if (j > GlobalMembers.max_player_health && (short)val > 0)
            {
                return;
            }
            else
            {
                if (j > 0)
                {
                    j += (short)val;
                }
                if (j > GlobalMembers.max_player_health && (short)val > 0)
                {
                    j = GlobalMembers.max_player_health;
                }
            }
        }
        else
        {
            if (j > 0)
            {
                j += (short)val;
            }
            if (j > (GlobalMembers.max_player_health << 1))
            {
                j = (GlobalMembers.max_player_health << 1);
            }
        }

        if (j < 0)
        {
            j = 0;
        }

        if (GlobalMembers.ud.god == 0)
        {
            if ((short)val > 0)
            {
                if ((j - (short)val) < (GlobalMembers.max_player_health >> 2) && j >= (GlobalMembers.max_player_health >> 2))
                {
                    GlobalMembers.spritesound(DefineConstants.DUKE_GOTHEALTHATLOW, GlobalMembers.ps[GlobalMembers.g_p].i);
                }

                GlobalMembers.ps[GlobalMembers.g_p].last_extra = (short)j;
            }

            Engine.board.sprite[GlobalMembers.ps[GlobalMembers.g_p].i].extra = (short)j;
        }
    }

    public override void endofgame(int timebeforeexit)
    {
        GlobalMembers.ps[GlobalMembers.g_p].timebeforeexit = (short)timebeforeexit;
        GlobalMembers.ps[GlobalMembers.g_p].customexitsound = -1;
        GlobalMembers.ud.eog = 1;
    }

    public override void debug()
    {
        //insptr++;
        //Engine.Printf("" + scriptptr.buffer[insptr]);
       // insptr++;
    }

    public override void addweapon(int val)
    {
        GlobalMembers.addweapon(GlobalMembers.ps[GlobalMembers.g_p], (short)val);
    }

    public override void addweapon(int val, int val2)
    {
        if (GlobalMembers.ps[GlobalMembers.g_p].gotweapon[(short)val] == false)
        {
            GlobalMembers.addweapon(GlobalMembers.ps[GlobalMembers.g_p], (short)val);
        }
        else if (GlobalMembers.ps[GlobalMembers.g_p].ammo_amount[(short)val] >= GlobalMembers.max_ammo_amount[(short)val])
        {
            GlobalMembers.killit_flag = (char)2;
            return;
        }
        GlobalMembers.addammo((short)val, GlobalMembers.ps[GlobalMembers.g_p], ((short)val2));
        if (GlobalMembers.ps[GlobalMembers.g_p].curr_weapon == DefineConstants.KNEE_WEAPON)
        {
            if (GlobalMembers.ps[GlobalMembers.g_p].gotweapon[(short)val])
            {
                GlobalMembers.addweapon(GlobalMembers.ps[GlobalMembers.g_p], (short)val);
            }
        }
    }
    public override void killit()
    {
        GlobalMembers.killit_flag = (char)1;
    }
    public override void lotsofglass(int val)
    {
        GlobalMembers.spriteglass(GlobalMembers.g_i, (short)val);
    }
    public override void addkills(int val)
    {
        GlobalMembers.ps[GlobalMembers.g_p].actors_killed += (char)val;
        GlobalMembers.hittype[GlobalMembers.g_i].actorstayput = -1;
    }

    public override void paper(int val)
    {
        GlobalMembers.lotsofpaper(GlobalMembers.g_sp, (short)val);
    }

    public override void sleeptime(int val)
    {
        GlobalMembers.hittype[GlobalMembers.g_i].timetosleep = (short)val;
    }
    public override void mail(int val)
    {
        GlobalMembers.lotsofmail(GlobalMembers.g_sp, (short)val);
    }

    public override void money(int val)
    {
        GlobalMembers.lotsofmoney(GlobalMembers.g_sp, val);
    }
    public override void addammo(int val, int val2)
    {
        if (GlobalMembers.ps[GlobalMembers.g_p].ammo_amount[val] >= GlobalMembers.max_ammo_amount[val])
        {
            GlobalMembers.killit_flag = (char)2;
            return;
        }
        GlobalMembers.addammo((short)val, GlobalMembers.ps[GlobalMembers.g_p], (short)val2);
        if (GlobalMembers.ps[GlobalMembers.g_p].curr_weapon == DefineConstants.KNEE_WEAPON)
        {
            if (GlobalMembers.ps[GlobalMembers.g_p].gotweapon[val])
            {
                GlobalMembers.addweapon(GlobalMembers.ps[GlobalMembers.g_p], (short)val);
            }
        }
    }
    public override void fall()
    {
        GlobalMembers.g_sp.xoffset = 0;
        GlobalMembers.g_sp.yoffset = 0;
        //            if(!gotz)
        {
            int c;

            if (GlobalMembers.floorspace(GlobalMembers.g_sp.sectnum) != 0)
            {
                c = 0;
            }
            else
            {
                if (GlobalMembers.ceilingspace(GlobalMembers.g_sp.sectnum) != 0 || Engine.board.sector[GlobalMembers.g_sp.sectnum].lotag == 2)
                {
                    c = GlobalMembers.gc / 6;
                }
                else
                {
                    c = GlobalMembers.gc;
                }
            }

            if (GlobalMembers.hittype[GlobalMembers.g_i].cgg <= 0 || (Engine.board.sector[GlobalMembers.g_sp.sectnum].floorstat & 2) != 0)
            {
                GlobalMembers.getglobalz(GlobalMembers.g_i);
                GlobalMembers.hittype[GlobalMembers.g_i].cgg = (char)6;
            }
            else
            {
                GlobalMembers.hittype[GlobalMembers.g_i].cgg--;
            }

            if (GlobalMembers.g_sp.z < (GlobalMembers.hittype[GlobalMembers.g_i].floorz - (1 << 8)))
            {
                GlobalMembers.g_sp.zvel += (short)c;
                GlobalMembers.g_sp.z += GlobalMembers.g_sp.zvel;

                if (GlobalMembers.g_sp.zvel > 6144)
                {
                    GlobalMembers.g_sp.zvel = 6144;
                }
            }
            else
            {
                GlobalMembers.g_sp.z = GlobalMembers.hittype[GlobalMembers.g_i].floorz - (1 << 8);

                if (GlobalMembers.badguy(GlobalMembers.g_sp) != 0 || (GlobalMembers.g_sp.picnum == DefineConstants.APLAYER && GlobalMembers.g_sp.owner >= 0))
                {

                    if (GlobalMembers.g_sp.zvel > 3084 && GlobalMembers.g_sp.extra <= 1)
                    {
                        if (GlobalMembers.g_sp.pal != 1 && GlobalMembers.g_sp.picnum != DefineConstants.DRONE)
                        {
                            if (GlobalMembers.g_sp.picnum == DefineConstants.APLAYER && GlobalMembers.g_sp.extra > 0)
                            {
                                goto SKIPJIBS;
                            }
                            GlobalMembers.guts(GlobalMembers.g_sp, DefineConstants.JIBS6, 15, GlobalMembers.g_p);
                            GlobalMembers.spritesound(DefineConstants.SQUISHED, GlobalMembers.g_i);
                            GlobalMembers.spawn(GlobalMembers.g_i, DefineConstants.BLOODPOOL);
                        }

                        SKIPJIBS:

                        GlobalMembers.hittype[GlobalMembers.g_i].picnum = DefineConstants.SHOTSPARK1;
                        GlobalMembers.hittype[GlobalMembers.g_i].extra = 1;
                        GlobalMembers.g_sp.zvel = 0;
                    }
                    else if (GlobalMembers.g_sp.zvel > 2048 && Engine.board.sector[GlobalMembers.g_sp.sectnum].lotag != 1)
                    {

                        j = GlobalMembers.g_sp.sectnum;
                        short _jj = (short)j;
                        Engine.board.pushmove(ref GlobalMembers.g_sp.x, ref GlobalMembers.g_sp.y, ref GlobalMembers.g_sp.z, ref _jj, 128, (4 << 8), (4 << 8), (((1) << 16) + 1));
                        j = _jj;
                        if (j != GlobalMembers.g_sp.sectnum && j >= 0 && j < DefineConstants.MAXSECTORS)
                        {
                            Engine.board.changespritesect(GlobalMembers.g_i, (short)j);
                        }

                        GlobalMembers.spritesound(DefineConstants.THUD, GlobalMembers.g_i);
                    }
                }
                if (Engine.board.sector[GlobalMembers.g_sp.sectnum].lotag == 1)
                {
                    switch (GlobalMembers.g_sp.picnum)
                    {
                        case DefineConstants.OCTABRAIN:
                        case DefineConstants.COMMANDER:
                        case DefineConstants.DRONE:
                            break;
                        default:
                            GlobalMembers.g_sp.z += (24 << 8);
                            break;
                    }
                }
                else
                {
                    GlobalMembers.g_sp.zvel = 0;
                }
            }
        }
    }

    public override void checkavailweapon()
    {
        GlobalMembers.checkavailweapon(GlobalMembers.ps[GlobalMembers.g_p]);
    }

    public override void tip()
    {
        GlobalMembers.ps[GlobalMembers.g_p].tipincs = 26;
    }
    public override void sound(int val)
    {
        GlobalMembers.spritesound(val, GlobalMembers.g_i);
    }
    public override void globalsound(int val)
    {
        if (GlobalMembers.g_p == GlobalMembers.screenpeek || GlobalMembers.ud.coop == 1)
        {
            GlobalMembers.spritesound(val, GlobalMembers.ps[GlobalMembers.screenpeek].i);
        }
    }
    public override void stopsound(int val)
    {
        if (GlobalMembers.Sound[val].num > 0)
        {
            GlobalMembers.stopsound(val);
        }
    }
    public override void soundonce(int val)
    {
        if (GlobalMembers.Sound[val].num == 0)
        {
            GlobalMembers.spritesound((short)val, GlobalMembers.g_i);
        }
    }
    public override void shoot(int val)
    {
        GlobalMembers.shoot(GlobalMembers.g_i, (short)val);
    }
    public override void sizeat(int val, int val2)
    {
        GlobalMembers.g_sp.xrepeat = (byte)val;
        GlobalMembers.g_sp.yrepeat = (byte)val2;
    }
    public override void sizeto(int val, int val2)
    {
        j = ((val) - GlobalMembers.g_sp.xrepeat) << 1;
        GlobalMembers.g_sp.xrepeat += (byte)pragmas.ksgn(j);

        if ((GlobalMembers.g_sp.picnum == DefineConstants.APLAYER && GlobalMembers.g_sp.yrepeat < 36) || val2 < GlobalMembers.g_sp.yrepeat || ((GlobalMembers.g_sp.yrepeat * (Engine.tilesizy[GlobalMembers.g_sp.picnum] + 8)) << 2) < (GlobalMembers.hittype[GlobalMembers.g_i].floorz - GlobalMembers.hittype[GlobalMembers.g_i].ceilingz))
        {
            j = ((val2) - GlobalMembers.g_sp.yrepeat) << 1;
            if (pragmas.klabs(j) != 0)
            {
                GlobalMembers.g_sp.yrepeat += (byte)pragmas.ksgn(j);
            }
        }
    }
    public override void pkick()
    {
        if (GlobalMembers.ud.multimode > 1 && GlobalMembers.g_sp.picnum == DefineConstants.APLAYER)
        {
            if (GlobalMembers.ps[GlobalMembers.otherp].quick_kick == 0)
            {
                GlobalMembers.ps[GlobalMembers.otherp].quick_kick = 14;
            }
        }
        else if (GlobalMembers.g_sp.picnum != DefineConstants.APLAYER && GlobalMembers.ps[GlobalMembers.g_p].quick_kick == 0)
        {
            GlobalMembers.ps[GlobalMembers.g_p].quick_kick = 14;
        }
    }
    public override void mikesnd()
    {
        if (GlobalMembers.Sound[GlobalMembers.g_sp.yvel].num == 0)
        {
            GlobalMembers.spritesound((ushort)GlobalMembers.g_sp.yvel, GlobalMembers.g_i);
        }
    }
    public override void nullop()
    {

    }

    public override void tossweapon()
    {
        GlobalMembers.checkweapons(GlobalMembers.ps[GlobalMembers.g_sp.yvel]);
    }

    public override void getlastpal()
    {
        if (GlobalMembers.g_sp.picnum == DefineConstants.APLAYER)
        {
            GlobalMembers.g_sp.pal = (byte)GlobalMembers.ps[GlobalMembers.g_sp.yvel].palookup;
        }
        else
        {
            GlobalMembers.g_sp.pal = (byte)GlobalMembers.hittype[GlobalMembers.g_i].tempang;
        }
        GlobalMembers.hittype[GlobalMembers.g_i].tempang = 0;
    }

    public override bool ifgotweaponce(int val)
    {
        if (GlobalMembers.ud.coop >= 1 && GlobalMembers.ud.multimode > 1)
        {
            if (val == 0)
            {
                for (j = 0; j < GlobalMembers.ps[GlobalMembers.g_p].weapreccnt; j++)
                {
                    if (GlobalMembers.ps[GlobalMembers.g_p].weaprecs[j] == GlobalMembers.g_sp.picnum)
                    {
                        break;
                    }
                }

                return (j < GlobalMembers.ps[GlobalMembers.g_p].weapreccnt && GlobalMembers.g_sp.owner == GlobalMembers.g_i);
            }
            else if (GlobalMembers.ps[GlobalMembers.g_p].weapreccnt < 16)
            {
                GlobalMembers.ps[GlobalMembers.g_p].weaprecs[GlobalMembers.ps[GlobalMembers.g_p].weapreccnt++] = GlobalMembers.g_sp.picnum;
                return (GlobalMembers.g_sp.owner == GlobalMembers.g_i);
            }
        }
        return (false);
    }
    public override void strength(int val)
    {
        GlobalMembers.g_sp.extra = (short)val;
    }

    public override void addstrength(int val)
    {
        GlobalMembers.g_sp.extra += (short)val;
    }


    public override bool ifpdistg(int val)
    {
        bool r = (GlobalMembers.g_x > val);
        if (GlobalMembers.g_x > DefineConstants.MAXSLEEPDIST && GlobalMembers.hittype[GlobalMembers.g_i].timetosleep == 0)
        {
            GlobalMembers.hittype[GlobalMembers.g_i].timetosleep = DefineConstants.SLEEPTIME;
        }
        return r; // jmarshall: the flow of this might be wrong.
    }

    public override bool ifpdistl(int val)
    {
        bool r = (GlobalMembers.g_x < val);
        if (GlobalMembers.g_x > DefineConstants.MAXSLEEPDIST && GlobalMembers.hittype[GlobalMembers.g_i].timetosleep == 0)
        {
            GlobalMembers.hittype[GlobalMembers.g_i].timetosleep = DefineConstants.SLEEPTIME;
        }
        return r; // jmarshall: the flow of this might be wrong.
    }

    // jmarshall
    //public override void ai()
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
    public override bool ifdead()
    {
        j = GlobalMembers.g_sp.extra;
        if (GlobalMembers.g_sp.picnum == DefineConstants.APLAYER)
        {
            j--;
        }
        return (j < 0);
    }
    public override bool ifsquished()
    {
        return (GlobalMembers.ifsquished(GlobalMembers.g_i, GlobalMembers.g_p) == 1);
    }

    public override bool ifhitweapon()
    {
        return (GlobalMembers.ifhitbyweapon(GlobalMembers.g_i) >= 0);
    }

    public override bool ifcansee()
    {
        spritetype ss;
        short sect;

        if (GlobalMembers.ps[GlobalMembers.g_p].holoduke_on >= 0)
        {
            ss = Engine.board.sprite[GlobalMembers.ps[GlobalMembers.g_p].holoduke_on];
            jj = Engine.board.cansee(GlobalMembers.g_sp.x, GlobalMembers.g_sp.y, (int)(GlobalMembers.g_sp.z - (Engine.krand() & ((32 << 8) - 1))), GlobalMembers.g_sp.sectnum, ss.x, ss.y, ss.z, ss.sectnum);
            if (jj == false)
            {
                ss = Engine.board.sprite[GlobalMembers.ps[GlobalMembers.g_p].i];
            }
        }
        else
        {
            ss = Engine.board.sprite[GlobalMembers.ps[GlobalMembers.g_p].i];
        }

        jj = Engine.board.cansee(GlobalMembers.g_sp.x, GlobalMembers.g_sp.y, (int)(GlobalMembers.g_sp.z - (Engine.krand() & ((47 << 8)))), GlobalMembers.g_sp.sectnum, ss.x, ss.y, ss.z - (24 << 8), ss.sectnum);

        if (jj == false)
        {
            if ((pragmas.klabs(GlobalMembers.hittype[GlobalMembers.g_i].lastvx - GlobalMembers.g_sp.x) + pragmas.klabs(GlobalMembers.hittype[GlobalMembers.g_i].lastvy - GlobalMembers.g_sp.y)) < (pragmas.klabs(GlobalMembers.hittype[GlobalMembers.g_i].lastvx - ss.x) + pragmas.klabs(GlobalMembers.hittype[GlobalMembers.g_i].lastvy - ss.y)))
            {
                jj = false;
            }

            if (jj == false)
            {
                j = GlobalMembers.furthestcanseepoint(GlobalMembers.g_i, ss, ref GlobalMembers.hittype[GlobalMembers.g_i].lastvx, ref GlobalMembers.hittype[GlobalMembers.g_i].lastvy);

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
            GlobalMembers.hittype[GlobalMembers.g_i].lastvx = ss.x;
            GlobalMembers.hittype[GlobalMembers.g_i].lastvy = ss.y;
        }

        if (jj && (GlobalMembers.g_sp.statnum == 1 || GlobalMembers.g_sp.statnum == 6))
        {
            GlobalMembers.hittype[GlobalMembers.g_i].timetosleep = DefineConstants.SLEEPTIME;
        }

        return (jj);
    }

    public override bool ifactornotstayput()
    {
        return (GlobalMembers.hittype[GlobalMembers.g_i].actorstayput == -1);
    }

    public override bool ifcanseetarget() 
    {
        bool jj = Engine.board.cansee(GlobalMembers.g_sp.x, GlobalMembers.g_sp.y, (int)(GlobalMembers.g_sp.z - ((Engine.krand() & 41) << 8)), GlobalMembers.g_sp.sectnum, GlobalMembers.ps[GlobalMembers.g_p].posx, GlobalMembers.ps[GlobalMembers.g_p].posy, GlobalMembers.ps[GlobalMembers.g_p].posz, Engine.board.sprite[GlobalMembers.ps[GlobalMembers.g_p].i].sectnum);
        if (jj)
        {
            GlobalMembers.hittype[GlobalMembers.g_i].timetosleep = DefineConstants.SLEEPTIME;
        }
        return jj;
    }
    public override bool ifcanshoottarget()
    {
        if (GlobalMembers.g_x > 1024)
        {
            // short temphit;
            short sclip;
            short angdif;

            if (GlobalMembers.badguy(GlobalMembers.g_sp) != 0 && GlobalMembers.g_sp.xrepeat > 56)
            {
                sclip = 3084;
                angdif = 48;
            }
            else
            {
                sclip = 768;
                angdif = 16;
            }

            j = GlobalMembers.hitasprite(GlobalMembers.g_i, ref temphit);
            if (j == (1 << 30))
            {
                return true;
            }
            if (j > sclip)
            {
                if (temphit >= 0 && Engine.board.sprite[temphit].picnum == GlobalMembers.g_sp.picnum)
                {
                    j = 0;
                }
                else
                {
                    GlobalMembers.g_sp.ang += angdif;
                    j = GlobalMembers.hitasprite(GlobalMembers.g_i, ref temphit);
                    GlobalMembers.g_sp.ang -= angdif;
                    if (j > sclip)
                    {
                        if (temphit >= 0 && Engine.board.sprite[temphit].picnum == GlobalMembers.g_sp.picnum)
                        {
                            j = 0;
                        }
                        else
                        {
                            GlobalMembers.g_sp.ang -= angdif;
                            j = GlobalMembers.hitasprite(GlobalMembers.g_i, ref temphit);
                            GlobalMembers.g_sp.ang += angdif;
                            if (j > 768)
                            {
                                if (temphit >= 0 && Engine.board.sprite[temphit].picnum == GlobalMembers.g_sp.picnum)
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

        return (j != 0);
    }
}