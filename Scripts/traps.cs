public class ScriptActorRegistration
{
    public delegate void Function_t();
    public Function_t func;
    public int aiType;
    public int aiType2;
    public ConAction action;
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
        switch (i)
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
    public ConAction action;
    public MoveAction moveAction;
    public int val;
    public AIAction(ConAction action, MoveAction moveAction, int val = 0, int unknown = 0)
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
public abstract class ConTraps
{
    // Sector Accessor Functions
    public abstract void SetSectorWallPtr(int sectNum, int value);
    public abstract void SetSectorWallNum(int sectNum, int value);
    public abstract void SetSectorCeilingZ(int sectNum, int value);
    public abstract void SetSectorFloorZ(int sectNum, int value);
    public abstract void SetSectorCeilingStat(int sectNum, int value);
    public abstract void SetSectorFloorStat(int sectNum, int value);
    public abstract void SetSectorCeilingPicNum(int sectNum, int value);
    public abstract void SetSectorCeilingHeinum(int sectNum, int value);
    public abstract void SetSectorCeilingShade(int sectNum, int value);
    public abstract void SetSectorCeilingPal(int sectNum, int value);
    public abstract void SetSectorCeilingxpanning(int sectNum, int value);
    public abstract void SetSectorCeilingypanning(int sectNum, int value);
    public abstract void SetSectorFloorPicnum(int sectNum, int value);
    public abstract void SetSectorFloorheinum(int sectNum, int value);
    public abstract void SetSectorFloorShade(int sectNum, int value);
    public abstract void SetSectorFloorpal(int sectNum, int value);
    public abstract void SetSectorFloorxpanning(int sectNum, int value);
    public abstract void SetSectorFloorypanning(int sectNum, int value);
    public abstract void SetSectorVisbility(int sectNum, int value);
    public abstract void SetSectorFiller(int sectNum, int value);
    public abstract void SetSectorLotag(int sectNum, int value);
    public abstract void SetSectorHitag(int sectNum, int value);
    public abstract void SetSectorExtra(int sectNum, int value);


    public abstract int GetSectorWallPtr(int sectNum);
    public abstract int GetSectorWallNum(int sectNum);
    public abstract int GetSectorCeilingZ(int sectNum);
    public abstract int GetSectorFloorZ(int sectNum);
    public abstract int GetSectorCeilingStat(int sectNum);
    public abstract int GetSectorFloorStat(int sectNum);
    public abstract int GetSectorCeilingPicNum(int sectNum);
    public abstract int GetSectorCeilingHeinum(int sectNum);
    public abstract int GetSectorCeilingShade(int sectNum);
    public abstract int GetSectorCeilingPal(int sectNum);
    public abstract int GetSectorCeilingxpanning(int sectNum);
    public abstract int GetSectorCeilingypanning(int sectNum);
    public abstract int GetSectorFloorPicnum(int sectNum);
    public abstract int GetSectorFloorheinum(int sectNum);
    public abstract int GetSectorFloorShade(int sectNum);
    public abstract int GetSectorFloorpal(int sectNum);
    public abstract int GetSectorFloorxpanning(int sectNum);
    public abstract int GetSectorFloorypanning(int sectNum);
    public abstract int GetSectorVisbility(int sectNum);
    public abstract int GetSectorFiller(int sectNum);
    public abstract int GetSectorLotag(int sectNum);
    public abstract int GetSectorHitag(int sectNum);
    public abstract int GetSectorExtra(int sectNum);
// Sector Accessor Functions end

    public abstract double DeltaTime();
    public abstract int GetGlobalSpriteID();
// Sprite Accessor Functions
    public abstract int GetSpriteX(int spriteId);
    public abstract int GetSpriteY(int spriteID);
    public abstract int GetSpriteZ(int spriteID);
    public abstract int GetCStat(int spriteID);
    public abstract int GetPicNum(int spriteID);
    public abstract int GetShade(int spriteID);
    public abstract int GetPal(int spriteID);
    public abstract int GetClipDist(int spriteID);
    public abstract int GetFiller(int spriteID);
    public abstract int GetXRepeat(int spriteID);
    public abstract int GetYRepeat(int spriteID);
    public abstract int GetXOffset(int spriteID);
    public abstract int GetYOffset(int spriteID);
    public abstract int GetSectNum(int spriteID);
    public abstract int GetStatNum(int spriteID);
    public abstract int GetAng(int spriteID);
    public abstract int GetOwner(int spriteID);
    public abstract int GetXVel(int spriteID);
    public abstract int GetYVel(int spriteID);
    public abstract int GetZVel(int spriteID);
    public abstract int GetLotag(int spriteID);
    public abstract int GetHitag(int spriteID);
    public abstract int GetExtra(int spriteID);
    public abstract void SetSpriteX(int spriteId, int value);
    public abstract void SetSpriteY(int spriteID, int value);
    public abstract void SetSpriteZ(int spriteID, int value);
    public abstract void SetCStat(int spriteID, int value);
    public abstract void SetPicNum(int spriteID, int value);
    public abstract void SetShade(int spriteID, int value);
    public abstract void SetPal(int spriteID, int value);
    public abstract void SetClipDist(int spriteID, int value);
    public abstract void SetFiller(int spriteID, int value);
    public abstract void SetXRepeat(int spriteID, int value);
    public abstract void SetYRepeat(int spriteID, int value);
    public abstract void SetXOffset(int spriteID, int value);
    public abstract void SetYOffset(int spriteID, int value);
    public abstract void SetSectNum(int spriteID, int value);
    public abstract void SetStatNum(int spriteID, int value);
    public abstract void SetAng(int spriteID, int value);
    public abstract void SetOwner(int spriteID, int value);
    public abstract void SetXVel(int spriteID, int value);
    public abstract void SetYVel(int spriteID, int value);
    public abstract void SetZVel(int spriteID, int value);
    public abstract void SetLotag(int spriteID, int value);
    public abstract void SetHitag(int spriteID, int value);
    public abstract void SetExtra(int spriteID, int value);
 // Sprite Accessor Functions End


    public abstract void RegisterVoxel(string voxel);
    public abstract void tripbombresetposz();
    public abstract void chaingunprojectileshift(int sprite);
    public abstract void adjustspriteang(int sprite, int ang);
    public abstract short ssp(short i, uint cliptype);
    public abstract void checkavailweapon();
    public abstract int totalclock();
    public abstract int sgn(int i1);
    public abstract int sintable(int index);
    public abstract int getspritepal(int index);
    public abstract uint krand();
    public abstract void myospal(int x, int y, int tilenum, int shade, int orientation, int p);

    public abstract void gamestartup(params int[] parms);

    public abstract void definemusic(int episode, params string[] music);
    public abstract void definesound(int id, string filename, int var1, int var2, int var3, int var4, int var5);
    public abstract void definelevelname(int episode, int level, string mapfile, string time1, string time2, string name);
    public abstract void defineskillname(int id, string name);
    public abstract void definevolumename(int id, string name);
    public abstract void definequote(int id, string str);
    public abstract void RegisterActor(ScriptActorRegistration.Function_t function, int picnum, int aiType, int aiType2 = 0, ConAction action = null, MoveAction unknown2 = null, int unknown3 = 0, int unknown4 = 0);


    public abstract bool ifnosounds();
    public abstract bool ifangdiffl(int value);
    public abstract bool ifspritepal(int value);

    public abstract void respawnhitag();
    public abstract bool ifnotmoving();
    public abstract bool ifinouterspace();
    public abstract void quote(int value);
    public abstract bool ifawayfromwall();
    public abstract void pstomp();

    public abstract bool ifpinventory(int val1, int val2);

    public abstract bool ifphealthl(int value);
    public abstract void palfrom(int v1 = 0, int v2 = 0, int v3 = 0, int v4 = 0);
    public abstract bool ifceilingdistl(int val);
    public abstract bool iffloordistl(int val);
    public abstract bool ifrespawn();
    public abstract bool ifbulletnear();
    public abstract void cactor(int value);
    public abstract void spritepal(int value);
    public abstract bool ifinspace();
    public abstract void operate();
    public abstract bool ifmultiplayer();
    public abstract bool ifoutside();
    public abstract bool ifhitspace();
    public abstract bool ifgapzl(int val);
    public abstract void wackplayer();

    public abstract bool ifspawnedby(int value);

    public abstract void guts(int value1, int value2);

    public abstract bool ifstrength(int value);

    public abstract bool ifp(int value, object notused = null, object notused2 = null, object notused3 = null, object notused4 = null);

    public abstract void hitradius(int val1 = 0, int val2 = 0, int val3 = 0, int val4 = 0, int val5 = 0);

    public abstract void addinventory(int val1, int val2);
    public abstract void resetcount();
    public abstract bool ifactor(int val1);
    public abstract bool ifcount(int val);
    public abstract bool ifinwater();
    public abstract bool ifonwater();
    public abstract void resetplayer();
    public abstract bool ifmove(MoveAction val1);

    public abstract void cstat(int value);
    public abstract void clipdist(int value);
    public abstract void cstator(int value);
    public abstract void count(int value);
    public abstract void debris(int val1, int val2);
    public abstract bool ifrnd(int val1);
    public abstract void resetactioncount();
    public abstract bool ifactioncount(int val1);

    public abstract void SetAction(ConAction action);

    public abstract bool ifaction(ConAction action);

    public abstract void Ai(AIAction ai);
    public abstract bool ifai(AIAction ai);

    public abstract bool ifwasweapon(int val);
    public abstract int spawn(int val);

    public abstract void Move(MoveAction val, int val2 = 0, int val3 = 0, int unknown1 = 0);

    public abstract void Move(int val, int val2 = 0);


    public abstract void addphealth(int val);

    public abstract void endofgame(int timebeforeexit);

    public abstract void debug();

    public abstract void addweapon(int val);

    public abstract void addweapon(int val, int val2);
    public abstract void killit();
    public abstract void lotsofglass(int val);
    public abstract void addkills(int val);

    public abstract void paper(int val);
    public abstract void sleeptime(int val);
    public abstract void mail(int val);

    public abstract void money(int val);
    public abstract void addammo(int val, int val2);
    public abstract void fall();

    public abstract void tip();
    public abstract void sound(int val);
    public abstract void globalsound(int val);
    public abstract void stopsound(int val);
    public abstract void soundonce(int val);

    public abstract void shoot(int val);
    public abstract void sizeat(int val, int val2);
    public abstract void sizeto(int val, int val2);
    public abstract void pkick();
    public abstract void mikesnd();
    public abstract void nullop();
    public abstract void tossweapon();

    public abstract void getlastpal();
    public abstract bool ifgotweaponce(int val);
    public abstract void strength(int val);

    public abstract void addstrength(int val);


    public abstract bool ifpdistg(int val);

    public abstract bool ifpdistl(int val);

    // jmarshall
    //public abstract void ai()
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
    public abstract bool ifdead();
    public abstract bool ifsquished();

    public abstract bool ifhitweapon();

    public abstract bool ifcansee();

    public abstract bool ifactornotstayput();

    public abstract bool ifcanseetarget();
    public abstract bool ifcanshoottarget();
}