public partial class ConScript
{
    private void A_STEROIDS()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifcount(6))
                if (traps.ifpdistl(RETRIEVEDISTANCE))
                    if (traps.ifpinventory(GET_STEROIDS, STEROID_AMOUNT))
                        if (traps.ifcanseetarget())
                        {
                            traps.addinventory(GET_STEROIDS, STEROID_AMOUNT);
                            traps.quote(37);
                            if (traps.ifspawnedby(STEROIDS))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_BOOTS()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifcount(6))
                if (traps.ifpdistl(RETRIEVEDISTANCE))
                    if (traps.ifpinventory(GET_BOOTS, BOOT_AMOUNT))
                        if (traps.ifcanseetarget())
                        {
                            traps.addinventory(GET_BOOTS, BOOT_AMOUNT);
                            traps.quote(6);
                            if (traps.ifspawnedby(BOOTS))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_HEATSENSOR()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifcount(6))
                if (traps.ifpdistl(RETRIEVEDISTANCE))
                    if (traps.ifpinventory(GET_HEATS, HEAT_AMOUNT))
                        if (traps.ifcanseetarget())
                        {
                            traps.addinventory(GET_HEATS, HEAT_AMOUNT);
                            traps.quote(101);
                            if (traps.ifspawnedby(HEATSENSOR))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_SHIELD()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifcount(6))
                if (traps.ifpdistl(RETRIEVEDISTANCE))
                    if (traps.ifpinventory(GET_SHIELD, SHIELD_AMOUNT))
                        if (traps.ifcanseetarget())
                        {
                            if (traps.ifspawnedby(PIGCOP))
                            {
                                if (traps.ifrnd(128))
                                    traps.addinventory(GET_SHIELD, PIG_SHIELD_AMOUNT1);
                                else
                                    traps.addinventory(GET_SHIELD, PIG_SHIELD_AMOUNT2);
                                traps.quote(104);
                                traps.sound(KICK_HIT);
                                traps.palfrom(24, 0, 32);
                                traps.killit();
                            }
                            else
                                traps.addinventory(GET_SHIELD, SHIELD_AMOUNT);
                            traps.quote(38);
                            if (traps.ifspawnedby(SHIELD))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_AIRTANK()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifcount(6))
                if (traps.ifpdistl(RETRIEVEDISTANCE))
                    if (traps.ifpinventory(GET_SCUBA, SCUBA_AMOUNT))
                        if (traps.ifcanseetarget())
                        {
                            traps.addinventory(GET_SCUBA, SCUBA_AMOUNT);
                            traps.quote(39);
                            if (traps.ifspawnedby(AIRTANK))
                                getcode();
                            else
                                quikget();
                        }
    }
    static ConAction HOLODUKE_FRAMES = new ConAction(0, 4, 1, 1, 8);
    private void A_HOLODUKE()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifcount(6))
                if (traps.ifpdistl(RETRIEVEDISTANCE))
                    if (traps.ifpinventory(GET_HOLODUKE, HOLODUKE_AMOUNT))
                        if (traps.ifcanseetarget())
                        {
                            traps.addinventory(GET_HOLODUKE, HOLODUKE_AMOUNT);
                            traps.quote(51);
                            if (traps.ifspawnedby(HOLODUKE))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_JETPACK()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifpinventory(GET_JETPACK, JETPACK_AMOUNT))
                        if (traps.ifcanseetarget())
                        {
                            traps.addinventory(GET_JETPACK, JETPACK_AMOUNT);
                            traps.quote(41);
                            if (traps.ifspawnedby(JETPACK))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_ACCESSCARD()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        if (traps.ifpinventory(GET_ACCESS, 0))
                            return;
                        traps.addinventory(GET_ACCESS, 1);
                        traps.quote(43);
                        getcode();
                    }
    }
    private void A_AMMO()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifcount(6))
                if (traps.ifpdistl(RETRIEVEDISTANCE))
                    if (traps.ifcanseetarget())
                    {
                        traps.addammo(PISTOL_WEAPON, PISTOLAMMOAMOUNT);
                        traps.quote(65);
                        if (traps.ifspawnedby(AMMO))
                            getcode();
                        else
                            quikget();
                    }
    }
    private void A_FREEZEAMMO()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifcount(6))
                if (traps.ifpdistl(RETRIEVEDISTANCE))
                    if (traps.ifcanseetarget())
                    {
                        traps.addammo(FREEZE_WEAPON, FREEZEAMMOAMOUNT);
                        traps.quote(66);
                        if (traps.ifspawnedby(FREEZEAMMO))
                            getcode();
                        else
                            quikget();
                    }
    }
    private void A_SHOTGUNAMMO()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifcount(6))
                if (traps.ifpdistl(RETRIEVEDISTANCE))
                    if (traps.ifcanseetarget())
                    {
                        traps.addammo(SHOTGUN_WEAPON, SHOTGUNAMMOAMOUNT);
                        traps.quote(69);
                        if (traps.ifspawnedby(SHOTGUNAMMO))
                            getcode();
                        else
                            quikget();
                    }
    }
    private void A_AMMOLOTS()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifcount(6))
                if (traps.ifpdistl(RETRIEVEDISTANCE))
                    if (traps.ifcanseetarget())
                    {
                        traps.addammo(PISTOL_WEAPON, 48);
                        traps.quote(65);
                        if (traps.ifspawnedby(AMMOLOTS))
                            getcode();
                        else
                            quikget();
                    }
    }
    private void A_CRYSTALAMMO()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        traps.addammo(SHRINKER_WEAPON, CRYSTALAMMOAMOUNT);
                        traps.quote(78);
                        if (traps.ifspawnedby(CRYSTALAMMO))
                            getcode();
                        else
                            quikget();
                    }
    }
    private void A_GROWAMMO()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        traps.addammo(GROW_WEAPON, GROWCRYSTALAMMOAMOUNT);
                        traps.quote(123);
                        if (traps.ifspawnedby(GROWAMMO))
                            getcode();
                        else
                            quikget();
                    }
    }
    private void A_BATTERYAMMO()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        traps.addammo(CHAINGUN_WEAPON, CHAINGUNAMMOAMOUNT);
                        traps.quote(63);
                        if (traps.ifspawnedby(BATTERYAMMO))
                            getcode();
                        else
                            quikget();
                    }
    }
    private void A_DEVISTATORAMMO()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        traps.addammo(DEVISTATOR_WEAPON, DEVISTATORAMMOAMOUNT);
                        traps.quote(14);
                        if (traps.ifspawnedby(DEVISTATORAMMO))
                            getcode();
                        else
                            quikget();
                    }
    }
    private void A_RPGAMMO()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        traps.addammo(RPG_WEAPON, RPGAMMOBOX);
                        traps.quote(64);
                        if (traps.ifspawnedby(RPGAMMO))
                            getcode();
                        else
                            quikget();
                    }
    }
    private void A_HBOMBAMMO()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        if (traps.ifgotweaponce(0))
                            return;
                        traps.addweapon(HANDBOMB_WEAPON, HANDBOMBBOX);
                        traps.quote(55);
                        if (traps.ifspawnedby(HBOMBAMMO))
                            getweaponcode();
                        else
                            quikweaponget();
                    }
    }
    private void A_RPGSPRITE()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        if (traps.ifgotweaponce(0))
                            return;
                        traps.addweapon(RPG_WEAPON, RPGAMMOBOX);
                        traps.quote(56);
                        if (traps.ifspawnedby(RPGSPRITE))
                            getweaponcode();
                        else
                            quikweaponget();
                    }
    }
    private void A_SHOTGUNSPRITE()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        if (traps.ifspawnedby(PIGCOP))
                        {
                            traps.addweapon(SHOTGUN_WEAPON, 0);
                            if (traps.ifrnd(64))
                                traps.addammo(SHOTGUN_WEAPON, 4);
                            else
                            if (traps.ifrnd(64))
                                traps.addammo(SHOTGUN_WEAPON, 3);
                            else
                            if (traps.ifrnd(64))
                                traps.addammo(SHOTGUN_WEAPON, 2);
                            else
                                traps.addammo(SHOTGUN_WEAPON, 1);
                        }
                        else
                        {
                            if (traps.ifgotweaponce(0))
                                return;
                            traps.addweapon(SHOTGUN_WEAPON, SHOTGUNAMMOAMOUNT);
                            traps.quote(57);
                        }
                        if (traps.ifspawnedby(SHOTGUNSPRITE))
                            getweaponcode();
                        else
                            quikweaponget();
                    }
    }
    private void A_SIXPAK()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifphealthl(MAXPLAYERHEALTH))
                        if (traps.ifcanseetarget())
                        {
                            traps.addphealth(30);
                            traps.quote(62);
                            if (traps.ifspawnedby(SIXPAK))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_COLA()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifphealthl(MAXPLAYERHEALTH))
                        if (traps.ifcanseetarget())
                        {
                            traps.addphealth(10);
                            traps.quote(61);
                            if (traps.ifspawnedby(COLA))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_ATOMICHEALTH()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifphealthl(MAXPLAYERATOMICHEALTH))
                        if (traps.ifcanseetarget())
                        {
                            traps.addphealth(50);
                            traps.quote(19);
                            if (traps.ifspawnedby(ATOMICHEALTH))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_FIRSTAID()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifpinventory(GET_FIRSTAID, FIRSTAID_AMOUNT))
                        if (traps.ifcanseetarget())
                        {
                            traps.addinventory(GET_FIRSTAID, FIRSTAID_AMOUNT);
                            traps.quote(3);
                            if (traps.ifspawnedby(FIRSTAID))
                                getcode();
                            else
                                quikget();
                        }
    }
    private void A_FIRSTGUNSPRITE()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        if (traps.ifgotweaponce(0))
                            return;
                        traps.addweapon(PISTOL_WEAPON, 48);
                        if (traps.ifspawnedby(FIRSTGUNSPRITE))
                            getweaponcode();
                        else
                            quikweaponget();
                    }
    }
    private void A_TRIPBOMBSPRITE()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        if (traps.ifgotweaponce(0))
                            return;
                        traps.addweapon(TRIPBOMB_WEAPON, 1);
                        traps.quote(58);
                        if (traps.ifspawnedby(TRIPBOMBSPRITE))
                            getweaponcode();
                        else
                            quikweaponget();
                    }
    }
    private void A_CHAINGUNSPRITE()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        if (traps.ifgotweaponce(0))
                            return;
                        traps.addweapon(CHAINGUN_WEAPON, 50);
                        traps.quote(54);
                        if (traps.ifspawnedby(CHAINGUNSPRITE))
                            getweaponcode();
                        else
                            quikweaponget();
                    }
    }
    private void A_SHRINKERSPRITE()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        if (traps.ifgotweaponce(0))
                            return;
                        traps.addweapon(SHRINKER_WEAPON, 10);
                        traps.quote(60);
                        if (traps.ifspawnedby(SHRINKERSPRITE))
                            getweaponcode();
                        else
                            quikweaponget();
                    }
    }
    private void A_FREEZESPRITE()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        if (traps.ifgotweaponce(0))
                            return;
                        traps.addweapon(FREEZE_WEAPON, FREEZEAMMOAMOUNT);
                        traps.quote(59);
                        if (traps.ifspawnedby(FREEZESPRITE))
                            getweaponcode();
                        else
                            quikweaponget();
                    }
    }
    private void A_DEVISTATORSPRITE()
    {
        traps.fall();
        if (traps.ifmove(RESPAWN_ACTOR_FLAG))
            respawnit();
        else
        if (traps.ifp(pshrunk))
        {
        }
        else
        if (traps.ifp(palive))
            if (traps.ifpdistl(RETRIEVEDISTANCE))
                if (traps.ifcount(6))
                    if (traps.ifcanseetarget())
                    {
                        if (traps.ifgotweaponce(0))
                            return;
                        traps.addweapon(DEVISTATOR_WEAPON, DEVISTATORAMMOAMOUNT);
                        traps.quote(87);
                        if (traps.ifspawnedby(DEVISTATORSPRITE))
                            getweaponcode();
                        else
                            quikweaponget();
                    }
    }
}