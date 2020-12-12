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

    public void Event_FTA_Sounds(int spriteId, int picnum)
    {
        int pal = traps.getspritepal(spriteId);

        switch (picnum)
        {
            case LIZTROOPONTOILET:
            case LIZTROOPJUSTSIT:
            case LIZTROOPSHOOT:
            case LIZTROOPJETPACK:
            case LIZTROOPDUCKING:
            case LIZTROOPRUNNING:
            case LIZTROOP:
                traps.sound(PRED_RECOG);
                break;
            case LIZMAN:
            case LIZMANSPITTING:
            case LIZMANFEEDING:
            case LIZMANJUMP:
                traps.sound(CAPT_RECOG);
                break;
            case PIGCOP:
            case PIGCOPDIVE:
                traps.sound(PIG_RECOG);
                break;
            case RECON:
                traps.sound(RECO_RECOG);
                break;
            case DRONE:
                traps.sound(DRON_RECOG);
                break;
            case COMMANDER:
            case COMMANDERSTAYPUT:
                traps.sound(COMM_RECOG);
                break;
            case ORGANTIC:
                traps.sound(TURR_RECOG);
                break;
            case OCTABRAIN:
            case OCTABRAINSTAYPUT:
                traps.sound(OCTA_RECOG);
                break;
            case BOSS1:
                traps.sound(BOS1_RECOG);
                break;
            case BOSS2:
                if (pal == 1)
                {
                    traps.localsound(BOS2_RECOG);
                }
                else
                {
                    traps.localsound(WHIPYOURASS);
                }
                break;
            case BOSS3:
                if (pal == 1)
                {
                    traps.localsound(BOS3_RECOG);
                }
                else
                {
                    traps.localsound(RIPHEADNECK);
                }
                break;
            case BOSS4:
            case BOSS4STAYPUT:
                if (pal == 1)
                {
                    traps.localsound(BOS4_RECOG);
                }
                traps.sound(BOSS4_FIRSTSEE);
                break;
            case GREENSLIME:
                traps.sound(SLIM_RECOG);
                break;
        }
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

    public bool Event_OperateSprite(int neartagsprite)
    {
        return false;
    }
}