public partial class ConScript
{
    public bool Event_HitSprite(int hitSpriteId, int instigatorId)
    {
        switch(traps.GetPicNum(hitSpriteId))
        {
            case HYDRENT:
                traps.SetPicNum(hitSpriteId, BROKEFIREHYDRENT);
                traps.spawn(TOILETWATER);
                traps.sound(GLASS_HEAVYBREAK);
                return true;

            case CHAIR1:
            case CHAIR2:
                traps.SetPicNum(hitSpriteId, BROKENCHAIR);
                traps.SetCStat(hitSpriteId, 0);
                return true;
        }

        return false;
    }

    public void Event_EnterLevel(string mapname, int playerSpriteID)
    {

    }

    public bool Event_CheckSectors(int spriteNum, int cursectnum)
    {
        int sectorLotag = traps.GetSectorLotag(cursectnum);
        if(sectorLotag >= 10000 && sectorLotag < 16383)
        {
            traps.sound(sectorLotag - 10000);
            traps.SetSectorLotag(cursectnum, 0);
        }

        return false;
    }
}