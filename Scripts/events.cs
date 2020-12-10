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
}