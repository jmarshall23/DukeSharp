
using Build;
using UnityEngine;
public partial class GlobalMembers
{

    public static void dobonus(char bonusonly)
    {
        short t;
        short r;
        short tinc;
        short gfx_offset;
        int i;
        int y;
        int xfragtotal;
        int yfragtotal;
        short bonuscnt;

        string temptxt = "";

        int[] breathe = { 0, 30, DefineConstants.VICTORY1 + 1, 176, 59, 30, 60, DefineConstants.VICTORY1 + 2, 176, 59, 60, 90, DefineConstants.VICTORY1 + 1, 176, 59, 90, 120, 0, 176, 59 };

        int[] bossmove = { 0, 120, DefineConstants.VICTORY1 + 3, 86, 59, 220, 260, DefineConstants.VICTORY1 + 4, 86, 59, 260, 290, DefineConstants.VICTORY1 + 5, 86, 59, 290, 320, DefineConstants.VICTORY1 + 6, 86, 59, 320, 350, DefineConstants.VICTORY1 + 7, 86, 59, 350, 380, DefineConstants.VICTORY1 + 8, 86, 59 };

        bonuscnt = 0;

        for (t = 0; t < 64; t += 7)
        {
            palto(0, 0, 0, t);
        }
        Engine._device.setview(0, 0, Engine.xdim - 1, Engine.ydim - 1);
        Engine.clearview();
        Engine.NextPage();
        flushperms();

        FX_StopAllSounds();
        clearsoundlocks();
        FX_SetReverb(0);

        if (bonusonly != 0)
        {
            goto FRAGBONUS;
        }

        if (numplayers < 2 && ud.eog != 0 && ud.from_bonus == 0)
        {
            switch (ud.volume_number)
            {
                case 0:
                    if (ud.lockout == 0)
                    {
                        Engine.clearview();
                        Engine.rotatesprite(0, 50 << 16, 65536, 0, DefineConstants.VICTORY1, 0, 0, 2 + 8 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                        Engine.NextPage();
                        ps[myconnectindex].palette = endingpal;
                        for (t = 63; t >= 0; t--)
                        {
                            palto(0, 0, 0, t);
                        }

                        KB_FlushKeyboardQueue();
                        totalclock = 0;
                        tinc = 0;
                        while (true)
                        {
                            Engine.clearview();
                            Engine.rotatesprite(0, 50 << 16, 65536, 0, DefineConstants.VICTORY1, 0, 0, 2 + 8 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

                            // boss
                            if (totalclock > 390 && totalclock < 780)
                            {
                                for (t = 0; t < 35; t += 5)
                                {
                                    if (bossmove[t + 2] != 0 && (totalclock % 390) > bossmove[t] && (totalclock % 390) <= bossmove[t + 1])
                                    {
                                        if (t == 10 && bonuscnt == 1)
                                        {
                                            sound(DefineConstants.SHOTGUN_FIRE);
                                            sound(DefineConstants.SQUISHED);
                                            bonuscnt++;
                                        }
                                        Engine.rotatesprite(bossmove[t + 3] << 16, bossmove[t + 4] << 16, 65536, 0, bossmove[t + 2], 0, 0, 2 + 8 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                                    }
                                }
                            }

                            // Breathe
                            if (totalclock < 450 || totalclock >= 750)
                            {
                                if (totalclock >= 750)
                                {
                                    Engine.rotatesprite(86 << 16, 59 << 16, 65536, 0, DefineConstants.VICTORY1 + 8, 0, 0, 2 + 8 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                                    if (totalclock >= 750 && bonuscnt == 2)
                                    {
                                        sound(DefineConstants.DUKETALKTOBOSS);
                                        bonuscnt++;
                                    }
                                }
                                for (t = 0; t < 20; t += 5)
                                {
                                    if (breathe[t + 2] != 0 && (totalclock % 120) > breathe[t] && (totalclock % 120) <= breathe[t + 1])
                                    {
                                        if (t == 5 && bonuscnt == 0)
                                        {
                                            sound(DefineConstants.BOSSTALKTODUKE);
                                            bonuscnt++;
                                        }
                                        Engine.rotatesprite(breathe[t + 3] << 16, breathe[t + 4] << 16, 65536, 0, breathe[t + 2], 0, 0, 2 + 8 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                                    }
                                }
                            }

                            getpackets();
                            Engine.NextPage();
                            if (KB_KeyWaiting() != null)
                            {
                                break;
                            }
                        }
                    }

                    for (t = 0; t < 64; t++)
                    {
                        palto(0, 0, 0, t);
                    }

                    KB_FlushKeyboardQueue();
                    ps[myconnectindex].palette = palette;

                    Engine.rotatesprite(0, 0, 65536, 0, 3292, 0, 0, 2 + 8 + 16 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                    Engine.NextPage();
                    for (t = 63; t > 0; t--)
                    {
                        palto(0, 0, 0, t);
                    }
                    while (KB_KeyWaiting() == null)
                    {
                        getpackets();
                    }
                    for (t = 0; t < 64; t++)
                    {
                        palto(0, 0, 0, t);
                    }
                    MUSIC_StopSong();
                    FX_StopAllSounds();
                    clearsoundlocks();
                    break;
                case 1:
                    MUSIC_StopSong();
                    Engine.clearview();
                    Engine.NextPage();

                    if (ud.lockout == 0)
                    {
                        playanm("cineov2.anm", 1);
                        KB_FlushKeyboardQueue();
                        Engine.clearview();
                        Engine.NextPage();
                    }

                    sound(DefineConstants.PIPEBOMB_EXPLODE);

                    for (t = 0; t < 64; t++)
                    {
                        palto(0, 0, 0, t);
                    }
                    Engine._device.setview(0, 0, Engine.xdim - 1, Engine.ydim - 1);
                    KB_FlushKeyboardQueue();
                    ps[myconnectindex].palette = palette;
                    Engine.rotatesprite(0, 0, 65536, 0, 3293, 0, 0, 2 + 8 + 16 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                    Engine.NextPage();
                    for (t = 63; t > 0; t--)
                    {
                        palto(0, 0, 0, t);
                    }
                    while (KB_KeyWaiting() == null)
                    {
                        getpackets();
                    }
                    for (t = 0; t < 64; t++)
                    {
                        palto(0, 0, 0, t);
                    }

                    break;

                case 3:

                    Engine._device.setview(0, 0, Engine.xdim - 1, Engine.ydim - 1);

                    MUSIC_StopSong();
                    Engine.clearview();
                    Engine.NextPage();

                    if (ud.lockout == 0)
                    {
                        KB_FlushKeyboardQueue();
                        playanm("vol4e1.anm", 8);
                        Engine.clearview();
                        Engine.NextPage();
                        playanm("vol4e2.anm", 10);
                        Engine.clearview();
                        Engine.NextPage();
                        playanm("vol4e3.anm", 11);
                        Engine.clearview();
                        Engine.NextPage();
                    }

                    FX_StopAllSounds();
                    clearsoundlocks();
                    sound(DefineConstants.ENDSEQVOL3SND4);
                    KB_FlushKeyboardQueue();

                    ps[myconnectindex].palette = palette;
                    palto(0, 0, 0, 63);
                    Engine.clearview();
                    menutext(160, 60, 0, 0, "THANKS TO ALL OUR");
                    menutext(160, 60 + 16, 0, 0, "FANS FOR GIVING");
                    menutext(160, 60 + 16 + 16, 0, 0, "US BIG HEADS.");
                    menutext(160, 70 + 16 + 16 + 16, 0, 0, "LOOK FOR A DUKE NUKEM 3D");
                    menutext(160, 70 + 16 + 16 + 16 + 16, 0, 0, "SEQUEL SOON.");
                    Engine.NextPage();

                    for (t = 63; t > 0; t -= 3)
                    {
                        palto(0, 0, 0, t);
                    }
                    KB_FlushKeyboardQueue();
                    while (KB_KeyWaiting() == null)
                    {
                        getpackets();
                    }
                    for (t = 0; t < 64; t += 3)
                    {
                        palto(0, 0, 0, t);
                    }

                    Engine.clearview();
                    Engine.NextPage();

                    playanm("DUKETEAM.ANM", 4);

                    KB_FlushKeyboardQueue();
                    while (KB_KeyWaiting() == null)
                    {
                        getpackets();
                    }

                    Engine.clearview();
                    Engine.NextPage();
                    palto(0, 0, 0, 63);

                    FX_StopAllSounds();
                    clearsoundlocks();
                    KB_FlushKeyboardQueue();

                    break;

                case 2:

                    MUSIC_StopSong();
                    Engine.clearview();
                    Engine.NextPage();
                    if (ud.lockout == 0)
                    {
                        for (t = 63; t >= 0; t--)
                        {
                            palto(0, 0, 0, t);
                        }
                        playanm("cineov3.anm", 2);
                        KB_FlushKeyboardQueue();
                        ototalclock = totalclock + 200;
                        while (totalclock < ototalclock)
                        {
                            getpackets();
                        }
                        Engine.clearview();
                        Engine.NextPage();

                        FX_StopAllSounds();
                        clearsoundlocks();
                    }

                    playanm("RADLOGO.ANM", 3);

                    if (ud.lockout == 0 && KB_KeyWaiting() == null)
                    {
                        sound(DefineConstants.ENDSEQVOL3SND5);
                        while (Sound[DefineConstants.ENDSEQVOL3SND5].@lock >= 200)
                        {
                            getpackets();
                        }
                        if (KB_KeyWaiting() != null)
                        {
                            goto ENDANM;
                        }
                        sound(DefineConstants.ENDSEQVOL3SND6);
                        while (Sound[DefineConstants.ENDSEQVOL3SND6].@lock >= 200)
                        {
                            getpackets();
                        }
                        if (KB_KeyWaiting() != null)
                        {
                            goto ENDANM;
                        }
                        sound(DefineConstants.ENDSEQVOL3SND7);
                        while (Sound[DefineConstants.ENDSEQVOL3SND7].@lock >= 200)
                        {
                            getpackets();
                        }
                        if (KB_KeyWaiting() != null)
                        {
                            goto ENDANM;
                        }
                        sound(DefineConstants.ENDSEQVOL3SND8);
                        while (Sound[DefineConstants.ENDSEQVOL3SND8].@lock >= 200)
                        {
                            getpackets();
                        }
                        if (KB_KeyWaiting() != null)
                        {
                            goto ENDANM;
                        }
                        sound(DefineConstants.ENDSEQVOL3SND9);
                        while (Sound[DefineConstants.ENDSEQVOL3SND9].@lock >= 200)
                        {
                            getpackets();
                        }
                    }

                    KB_FlushKeyboardQueue();
                    totalclock = 0;
                    while (KB_KeyWaiting() == null && totalclock < 120)
                    {
                        getpackets();
                    }

                    ENDANM:

                    FX_StopAllSounds();
                    clearsoundlocks();

                    KB_FlushKeyboardQueue();

                    Engine.clearview();

                    break;
            }
        }

        FRAGBONUS:

        ps[myconnectindex].palette = palette;
        KB_FlushKeyboardQueue();
        totalclock = 0;
        tinc = 0;
        bonuscnt = 0;

        MUSIC_StopSong();
        FX_StopAllSounds();
        clearsoundlocks();

        if (playerswhenstarted > 1 && ud.coop != 1)
        {
            //if (!(MusicToggle == 0 || MusicDevice == soundcardnames.NumSoundCards))
            {
                sound(DefineConstants.BONUSMUSIC);
            }

            Engine.rotatesprite(0, 0, 65536, 0, DefineConstants.MENUSCREEN, 16, 0, 2 + 8 + 16 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
            Engine.rotatesprite(160 << 16, 34 << 16, 65536, 0, DefineConstants.INGAMEDUKETHREEDEE, 0, 0, 10, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
            Engine.rotatesprite((260) << 16, 36 << 16, 65536, 0, DefineConstants.PLUTOPAKSPRITE + 2, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
            gametext(160, 58 + 2, "MULTIPLAYER TOTALS", 0, (short)(2 + 8 + 16));
            gametext(160, 58 + 10, level_names[(ud.volume_number * 11) + ud.last_level - 1], 0, (short)(2 + 8 + 16));

            gametext(160, 165, "PRESS ANY KEY TO CONTINUE", 0, (short)(2 + 8 + 16));


            t = 0;
            minitext(23, 80, "   NAME                                           KILLS", 8, 2 + 8 + 16 + 128);
            for (i = 0; i < playerswhenstarted; i++)
            {
                temptxt = string.Format("{0}", i + 1);
                minitext(92 + (i * 23), 80, temptxt, 3, 2 + 8 + 16 + 128);
            }

            for (i = 0; i < playerswhenstarted; i++)
            {
                xfragtotal = 0;
                temptxt = string.Format( "{0}", i + 1);

                minitext(30, 90 + t, temptxt, 0, 2 + 8 + 16 + 128);
                minitext(38, 90 + t, ud.user_name[i], ps[i].palookup, 2 + 8 + 16 + 128);

                for (y = 0; y < playerswhenstarted; y++)
                {
                    if (i == y)
                    {
                        temptxt = string.Format("{0}", ps[y].fraggedself);
                        minitext(92 + (y * 23), 90 + t, temptxt, 2, 2 + 8 + 16 + 128);
                        xfragtotal -= ps[y].fraggedself;
                    }
                    else
                    {
                        temptxt = string.Format("{0}", frags[i,y]);
                        minitext(92 + (y * 23), 90 + t, temptxt, 0, 2 + 8 + 16 + 128);
                        xfragtotal += frags[i,y];
                    }

                    if (myconnectindex == connecthead)
                    {
                        temptxt = string.Format("stats {0} killed {1} {2}\n", i + 1, y + 1, frags[i,y]);
                       // sendscore(ref temptxt); // jmarshall: networking score?
                    }
                }

                temptxt = string.Format("{0}", xfragtotal);
                minitext(101 + (8 * 23), 90 + t, temptxt, 2, 2 + 8 + 16 + 128);

                t += 7;
            }

            for (y = 0; y < playerswhenstarted; y++)
            {
                yfragtotal = 0;
                for (i = 0; i < playerswhenstarted; i++)
                {
                    if (i == y)
                    {
                        yfragtotal += ps[i].fraggedself;
                    }
                    yfragtotal += frags[i,y];
                }
                temptxt = string.Format("{0}", yfragtotal);
                minitext(92 + (y * 23), 96 + (8 * 7), temptxt, 2, 2 + 8 + 16 + 128);
            }

            minitext(45, 96 + (8 * 7), "DEATHS", 8, 2 + 8 + 16 + 128);
            Engine.NextPage();

            for (t = 0; t < 64; t += 7)
            {
                palto(0, 0, 0, 63 - t);
            }

            KB_FlushKeyboardQueue();
            while (KB_KeyWaiting() == 0)
            {
                getpackets();
            }

           // if ((KB_KeyDown[(DefineConstants.sc_F12)] != 0))
           // {
           //     {
           //         KB_KeyDown[(DefineConstants.sc_F12)] = (!(1 == 1));
           //     };
           //     screencapture("duke0000.pcx", 0);
           // }

            if (bonusonly != 0 || ud.multimode > 1)
            {
                return;
            }

            for (t = 0; t < 64; t += 7)
            {
                palto(0, 0, 0, t);
            }
        }

        if (bonusonly != 0 || ud.multimode > 1)
        {
            return;
        }

        switch (ud.volume_number)
        {
            case 1:
                gfx_offset = 5;
                break;
            default:
                gfx_offset = 0;
                break;
        }

        Engine.rotatesprite(0, 0, 65536, 0, DefineConstants.BONUSSCREEN + gfx_offset, 0, 0, 2 + 8 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

        menutext(160, 20 - 6, 0, 0, level_names[(ud.volume_number * 11) + ud.last_level - 1]);
        menutext(160, 36 - 6, 0, 0, "COMPLETED");

        gametext(160, 192, "PRESS ANY KEY TO CONTINUE", 16, (short)(2 + 8 + 16));

       // if (!(MusicToggle == 0 || MusicDevice == soundcardnames.NumSoundCards))
        {
            sound(DefineConstants.BONUSMUSIC);
        }

        Engine.NextPage();
        KB_FlushKeyboardQueue();
        for (t = 0; t < 64; t++)
        {
            palto(0, 0, 0, 63 - t);
        }
        bonuscnt = 0;
        totalclock = 0;
        tinc = 0;

        while (true)
        {
            if ((ps[myconnectindex].gm & DefineConstants.MODE_EOL) != 0)
            {
                Engine.rotatesprite(0, 0, 65536, 0, DefineConstants.BONUSSCREEN + gfx_offset, 0, 0, 2 + 8 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

                if (totalclock > (1000000000) && totalclock < (1000000320))
                {
                    switch ((totalclock >> 4) % 15)
                    {
                        case 0:
                            if (bonuscnt == 6)
                            {
                                bonuscnt++;
                                sound(DefineConstants.SHOTGUN_COCK);
                                switch (Engine.krand() & 3)
                                {
                                    case 0:
                                        sound(DefineConstants.BONUS_SPEECH1);
                                        break;
                                    case 1:
                                        sound(DefineConstants.BONUS_SPEECH2);
                                        break;
                                    case 2:
                                        sound(DefineConstants.BONUS_SPEECH3);
                                        break;
                                    case 3:
                                        sound(DefineConstants.BONUS_SPEECH4);
                                        break;
                                }
                            }
                            goto case 1;
                        case 1:
                        case 4:
                        case 5:
                            Engine.rotatesprite(199 << 16, 31 << 16, 65536, 0, DefineConstants.BONUSSCREEN + 3 + gfx_offset, 0, 0, 2 + 8 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                            break;
                        case 2:
                        case 3:
                            Engine.rotatesprite(199 << 16, 31 << 16, 65536, 0, DefineConstants.BONUSSCREEN + 4 + gfx_offset, 0, 0, 2 + 8 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                            break;
                    }
                }
                else if (totalclock > (10240 + 120))
                {
                    break;
                }
                else
                {
                    switch ((totalclock >> 5) & 3)
                    {
                        case 1:
                        case 3:
                            Engine.rotatesprite(199 << 16, 31 << 16, 65536, 0, DefineConstants.BONUSSCREEN + 1 + gfx_offset, 0, 0, 2 + 8 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                            break;
                        case 2:
                            Engine.rotatesprite(199 << 16, 31 << 16, 65536, 0, DefineConstants.BONUSSCREEN + 2 + gfx_offset, 0, 0, 2 + 8 + 16 + 64 + 128, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                            break;
                    }
                }

                menutext(160, 20 - 6, 0, 0, level_names[(ud.volume_number * 11) + ud.last_level - 1]);
                menutext(160, 36 - 6, 0, 0, "COMPLETED");

                gametext(160, 192, "PRESS ANY KEY TO CONTINUE", 16, (short)(2 + 8 + 16));

                if (totalclock > (60 * 3))
                {
                    gametext(10, 59 + 9, "Your Time:", 0, (short)(2 + 8 + 16));
                    gametext(10, 69 + 9, "Par time:", 0, (short)(2 + 8 + 16));
                    gametext(10, 78 + 9, "3D Realms' Time:", 0, (short)(2 + 8 + 16));
                    if (bonuscnt == 0)
                    {
                        bonuscnt++;
                    }

                    if (totalclock > (60 * 4))
                    {
                        if (bonuscnt == 1)
                        {
                            bonuscnt++;
                            sound(DefineConstants.PIPEBOMB_EXPLODE);
                        }
                        temptxt = string.Format("{0}:{1}", (ps[myconnectindex].player_par / (26 * 60)) % 60, (ps[myconnectindex].player_par / 26) % 60);
                        gametext((320 >> 2) + 71, 60 + 9, temptxt, 0, (short)(2 + 8 + 16));

                        temptxt = string.Format("{0}", partime[ud.volume_number * 11 + ud.last_level - 1]);
                        gametext((320 >> 2) + 71, 69 + 9, temptxt, 0, (short)(2 + 8 + 16));

                        temptxt = string.Format("{0}", designertime[ud.volume_number * 11 + ud.last_level - 1]);
                        gametext((320 >> 2) + 71, 78 + 9, temptxt, 0, (short)(2 + 8 + 16));

                    }
                }
                if (totalclock > (60 * 6))
                {
                    gametext(10, 94 + 9, "Enemies Killed:", 0, (short)(2 + 8 + 16));
                    gametext(10, 99 + 4 + 9, "Enemies Left:", 0, (short)(2 + 8 + 16));

                    if (bonuscnt == 2)
                    {
                        bonuscnt++;
                        sound(DefineConstants.FLY_BY);
                    }

                    if (totalclock > (60 * 7))
                    {
                        if (bonuscnt == 3)
                        {
                            bonuscnt++;
                            sound(DefineConstants.PIPEBOMB_EXPLODE);
                        }
                        temptxt = string.Format("{0}", ps[myconnectindex].actors_killed);
                        gametext((320 >> 2) + 70, 93 + 9, temptxt, 0, (short)(2 + 8 + 16));
                        if (ud.player_skill > 3)
                        {
                            temptxt = string.Format( "N/A");
                            gametext((320 >> 2) + 70, 99 + 4 + 9, temptxt, 0, (short)(2 + 8 + 16));
                        }
                        else
                        {
                            if ((ps[myconnectindex].max_actors_killed - ps[myconnectindex].actors_killed) < 0)
                            {
                                temptxt = string.Format("{0}", 0);
                            }
                            else
                            {
                                temptxt = string.Format("{0}", ps[myconnectindex].max_actors_killed - ps[myconnectindex].actors_killed);
                            }
                            gametext((320 >> 2) + 70, 99 + 4 + 9, temptxt, 0, (short)(2 + 8 + 16));
                        }
                    }
                }
                if (totalclock > (60 * 9))
                {
                    gametext(10, 120 + 9, "Secrets Found:", 0, (short)(2 + 8 + 16));
                    gametext(10, 130 + 9, "Secrets Missed:", 0, (short)(2 + 8 + 16));
                    if (bonuscnt == 4)
                    {
                        bonuscnt++;
                    }

                    if (totalclock > (60 * 10))
                    {
                        if (bonuscnt == 5)
                        {
                            bonuscnt++;
                            sound(DefineConstants.PIPEBOMB_EXPLODE);
                        }
                        temptxt = string.Format("{0}", ps[myconnectindex].secret_rooms);
                        gametext((320 >> 2) + 70, 120 + 9, temptxt, 0, (short)(2 + 8 + 16));
                        if (ps[myconnectindex].secret_rooms > 0)
                        {
                            temptxt = string.Format("{0}", (100 * ps[myconnectindex].secret_rooms / ps[myconnectindex].max_secret_rooms));
                        }
                        temptxt = string.Format("{0}", ps[myconnectindex].max_secret_rooms - ps[myconnectindex].secret_rooms);
                        gametext((320 >> 2) + 70, 130 + 9, temptxt, 0, (short)(2 + 8 + 16));
                    }
                }

                if (totalclock > 10240 && totalclock < 10240 + 10240)
                {
                    totalclock = 1024;
                }

                if (KB_KeyWaiting() != null && totalclock > (60 * 2))
                {
                    //if ((KB_KeyDown[(DefineConstants.sc_F12)] != false))
                    //{
                    //    {
                    //        KB_KeyDown[(DefineConstants.sc_F12)] = (!(1 == 1));
                    //    };
                    //    screencapture("duke0000.pcx", 0);
                    //}

                    if (totalclock < (60 * 13))
                    {
                        KB_FlushKeyboardQueue();
                        totalclock = (60 * 13);
                    }
                    else if (totalclock < (1000000000))
                    {
                        totalclock = (1000000000);
                    }
                }
            }
            else
            {
                break;
            }
            Engine.NextPage();
        }
    }
}