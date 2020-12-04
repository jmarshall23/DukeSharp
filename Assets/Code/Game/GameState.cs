using Build;
using UnityEngine;

public partial class GlobalMembers
{
    public enum GameStateType
    {
        GAME_STATE_LOGO_MOVIE = 0,
        GAME_STATE_LOGO_3DREALMS,
        GAME_STATE_LOGO_BETASCREEN,
        GAME_STATE_LOGO_LOGOANIM,
        GAME_STATE_MENU_NOGAME_SETUP,
        GAME_STATE_MENU_NOGAME,
        GAME_STATE_INGAME,
        GAME_STATE_BONUS
    }

    public static GameStateType currentStage = GameStateType.GAME_STATE_LOGO_MOVIE;

    internal static int soundanm = 0;

    public static void RunState()
    {
        if(currentStage == GameStateType.GAME_STATE_LOGO_MOVIE)
        {
            if(ud.warp_on == 1)
            {
                newgame((char)ud.m_volume_number, (char)ud.m_level_number, (char)ud.m_player_skill);
                enterlevel((char)DefineConstants.MODE_GAME);
                ud.warp_on = 0;
                return;
            }
        }

        switch(currentStage)
        {
            case GameStateType.GAME_STATE_LOGO_MOVIE:
                ps[myconnectindex].palette = drealms;
                Engine.skyMaterial.SetTexture("_FrontTex", Texture2D.blackTexture);
                Engine.skyMaterial.SetTexture("_BackTex", Texture2D.blackTexture);
                Engine.skyMaterial.SetTexture("_LeftTex", Texture2D.blackTexture);
                Engine.skyMaterial.SetTexture("_RightTex", Texture2D.blackTexture);
                Engine.skyMaterial.SetTexture("_UpTex", Texture2D.blackTexture);
                Engine.skyMaterial.SetTexture("_DownTex", Texture2D.blackTexture);
// jmarshall - todo implemente movie bits
                //playanm("logo.anm", 5);
                //if (KB_KeyWaiting() != 0)
// jmarshall end
                {
                    currentStage = GameStateType.GAME_STATE_LOGO_3DREALMS;
                    palto(0, 0, 0, 63);
                    KB_FlushKeyboardQueue();
                    Engine.clearview();

                    playmusic(0, 0);
                    palto(0, 0, 0, 63);
                    totalclock = 0;

                    flushperms();

                    ps[myconnectindex].palette = drealms;
                }
                break;
            case GameStateType.GAME_STATE_LOGO_3DREALMS:
                {
                    int width = Engine.xdim - 1;
                    int height = Engine.ydim - 1;
                    Engine.rotatesprite(0, 0, 65536, 0, DefineConstants.DREALMS, 0, 0, 2 + 8 + 16 + 64, 0, 0, width, height);

                    if(KB_KeyWaiting() != 0 || totalclock >= (120 * 7))
                    {
                        currentStage = GameStateType.GAME_STATE_LOGO_BETASCREEN;
                        ps[myconnectindex].palette = titlepal;
                        palto(0, 0, 0, 63);
                        flushperms();
                        totalclock = 0;
                    }
                }
                break;
            case GameStateType.GAME_STATE_LOGO_BETASCREEN:
                {
                    int width = Engine.xdim - 1;
                    int height = Engine.ydim - 1;
                    Engine.rotatesprite(0, 0, 65536, 0, DefineConstants.BETASCREEN, 0, 0, 2 + 8 + 16 + 64, 0, 0, width, height);

                    if (KB_KeyWaiting() != 0 || totalclock >= (120 * 7))
                    {
                        currentStage = GameStateType.GAME_STATE_LOGO_LOGOANIM;
                        totalclock = 0;
                        soundanm = 0;
                    }
                }
                break;

            case GameStateType.GAME_STATE_LOGO_LOGOANIM:
                {
                    Engine.rotatesprite(0, 0, 65536, 0, DefineConstants.BETASCREEN, 0, 0, 2 + 8 + 16 + 64, 0, 0, Engine.xdim - 1, Engine.ydim - 1);

                    if (totalclock > 120 && totalclock < (120 + 60))
                    {
                        if (soundanm == 0)
                        {
                            soundanm = 1;
                            sound(DefineConstants.PIPEBOMB_EXPLODE);
                        }
                        Engine.rotatesprite(160 << 16, 104 << 16, (totalclock - 120) << 10, 0, DefineConstants.DUKENUKEM, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                    }
                    else if (totalclock >= (120 + 60))
                    {
                        Engine.rotatesprite(160 << 16, (104) << 16, 60 << 10, 0, DefineConstants.DUKENUKEM, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                    }

                    if (totalclock > 220 && totalclock < (220 + 30))
                    {
                        if (soundanm == 1)
                        {
                            soundanm = 2;
                            sound(DefineConstants.PIPEBOMB_EXPLODE);
                        }

                        Engine.rotatesprite(160 << 16, (104) << 16, 60 << 10, 0, DefineConstants.DUKENUKEM, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                        Engine.rotatesprite(160 << 16, (129) << 16, (totalclock - 220) << 11, 0, DefineConstants.THREEDEE, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                    }
                    else if (totalclock >= (220 + 30))
                    {
                        Engine.rotatesprite(160 << 16, (129) << 16, 30 << 11, 0, DefineConstants.THREEDEE, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                    }

                    if (totalclock >= 280 && totalclock < 395)
                    {
                        Engine.rotatesprite(160 << 16, (151) << 16, (410 - totalclock) << 12, 0, DefineConstants.PLUTOPAKSPRITE + 1, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                        if (soundanm == 2)
                        {
                            soundanm = 3;
                            sound(DefineConstants.FLY_BY);
                        }
                    }
                    else if (totalclock >= 395)
                    {
                        if (soundanm == 3)
                        {
                            soundanm = 4;
                            sound(DefineConstants.PIPEBOMB_EXPLODE);
                        }
                        Engine.rotatesprite(160 << 16, (151) << 16, 30 << 11, 0, DefineConstants.PLUTOPAKSPRITE + 1, 0, 0, 2 + 8, 0, 0, Engine.xdim - 1, Engine.ydim - 1);
                    }

                    getpackets();
                    if (totalclock >= (860 + 120) || KB_KeyWaiting() != 0)
                    {
                        currentStage = GameStateType.GAME_STATE_MENU_NOGAME_SETUP;
                        flushperms();
                        Engine.clearview();
                        Engine.NextPage();

                        ps[myconnectindex].palette = palette;
                        sound(DefineConstants.NITEVISION_ONOFF);
                    }
                }
                break;

            case GameStateType.GAME_STATE_MENU_NOGAME_SETUP:
                //tempautorun = ud.auto_run;
                palto(0, 0, 0, 63);
                ud.warp_on = 0;
                playback_setup();

                if (currentStage != GameStateType.GAME_STATE_INGAME)
                {
                    currentStage = GameStateType.GAME_STATE_MENU_NOGAME;
                }
                break;

            case GameStateType.GAME_STATE_MENU_NOGAME:
                playback_state();
                break;

            case GameStateType.GAME_STATE_INGAME:
                //ud.auto_run = tempautorun;
                ud.warp_on = 0;
                DukeCoreLoop();
                break;
        }
    }
}