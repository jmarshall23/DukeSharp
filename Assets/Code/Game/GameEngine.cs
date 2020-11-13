using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Build;

public class GameEngine : MonoBehaviour
{
    public Player player;
    public RawImage canvasImage;

    public const int TICSPERFRAME = 3;

    class WallAnimation
    {
        public walltype wall = null;

        public bool isX = false;

        public bool isY = false;

        public int goalValue = 0;

        public int thevel = 0;

        public int theacc = 0;
    }

    List<WallAnimation> wallAnimations = new List<WallAnimation>();

    private void AddWallAnimation(walltype walltype, bool isX, bool isY, int goalValue, int thevel, int theacc)
    {
        WallAnimation newAnimation = new WallAnimation();

        newAnimation.wall = walltype;
        newAnimation.isX = isX;
        newAnimation.isY = isY;
        newAnimation.goalValue = goalValue;
        newAnimation.thevel = thevel;
        newAnimation.theacc = theacc;

        // Check to see if this already has animation.
        for (int i = 0; i < wallAnimations.Count; i++)
        {
            if (wallAnimations[i] == newAnimation)
                return;
        }

        wallAnimations.Add(newAnimation);
    }

    // Start is called before the first frame update
    public void InitEngine()
    {
        // Init the build engine.
        Engine.Init();

        // Load in the game data.
        Engine.initgroupfile("data.grp");

        Engine.LoadTables();

        // Init the device
        Engine.setgamemode(0, 640, 480, 8);

        // Load in the tiles.
        Engine.loadpics("tiles000.art");

        canvasImage.texture = Engine._device._screenbuffer._texture;
    }

    public void OperateSector(int dasector)
    {
        //Door code
        int i, j, k, s, nexti, good, cnt, datag;
        int dax, day, daz, dax2, day2, daz2, centx, centy;
        int startwall, endwall;
        int[] wallfind = new int[2];

        datag = Engine.board.sector[dasector].lotag;

        startwall = Engine.board.sector[dasector].wallptr;
        endwall = startwall + Engine.board.sector[dasector].wallnum;
        centx = 0; centy = 0;
        for (i = startwall; i < endwall; i++)
        {
            centx += Engine.board.wall[i].x;
            centy += Engine.board.wall[i].y;
        }
        centx /= (endwall - startwall);
        centy /= (endwall - startwall);

        if (datag == 9)   //Smooshy-wall sideways double-door
        {
            //find any points with either same x or same y coordinate
            //  as center (centx, centy) - should be 2 points found.
            wallfind[0] = -1;
            wallfind[1] = -1;
            for (i = startwall; i < endwall; i++)
                if ((Engine.board.wall[i].x == centx) || (Engine.board.wall[i].y == centy))
                {
                    if (wallfind[0] == -1)
                        wallfind[0] = i;
                    else
                        wallfind[1] = i;
                }

            for (j = 0; j < 2; j++)
            {
                if ((Engine.board.wall[wallfind[j]].x == centx) && (Engine.board.wall[wallfind[j]].y == centy))
                {
                    //find what direction door should open by averaging the
                    //  2 neighboring points of wallfind[0] & wallfind[1].
                    i = wallfind[j] - 1; if (i < startwall) i = endwall - 1;
                    dax2 = ((Engine.board.wall[i].x + Engine.board.wall[Engine.board.wall[wallfind[j]].point2].x) >> 1) - Engine.board.wall[wallfind[j]].x;
                    day2 = ((Engine.board.wall[i].y + Engine.board.wall[Engine.board.wall[wallfind[j]].point2].y) >> 1) - Engine.board.wall[wallfind[j]].y;
                    if (dax2 != 0)
                    {
                        dax2 = Engine.board.wall[Engine.board.wall[Engine.board.wall[wallfind[j]].point2].point2].x;
                        dax2 -= Engine.board.wall[Engine.board.wall[wallfind[j]].point2].x;
                        //setanimation(&Engine.board.wall[wallfind[j]].x, Engine.board.wall[wallfind[j]].x + dax2, 4, 0);
                        AddWallAnimation(Engine.board.wall[wallfind[j]], true, false, Engine.board.wall[wallfind[j]].x + dax2, 4, 0);

                        //setanimation(&Engine.board.wall[i].x, Engine.board.wall[i].x + dax2, 4, 0);
                        AddWallAnimation(Engine.board.wall[i], true, false, Engine.board.wall[i].x + dax2, 4, 0);

                        //setanimation(&Engine.board.wall[Engine.board.wall[wallfind[j]].point2].x, Engine.board.wall[Engine.board.wall[wallfind[j]].point2].x + dax2, 4, 0);
                        AddWallAnimation(Engine.board.wall[Engine.board.wall[wallfind[j]].point2], true, false, Engine.board.wall[Engine.board.wall[wallfind[j]].point2].x + dax2, 4, 0);
                    }
                    else if (day2 != 0)
                    {
                        day2 = Engine.board.wall[Engine.board.wall[Engine.board.wall[wallfind[j]].point2].point2].y;
                        day2 -= Engine.board.wall[Engine.board.wall[wallfind[j]].point2].y;
                        //setanimation(&Engine.board.wall[wallfind[j]].y, Engine.board.wall[wallfind[j]].y + day2, 4, 0);
                        AddWallAnimation(Engine.board.wall[wallfind[j]], false, true, Engine.board.wall[wallfind[j]].y + day2, 4, 0);

                        //setanimation(&Engine.board.wall[i].y, Engine.board.wall[i].y + day2, 4, 0);
                        AddWallAnimation(Engine.board.wall[i], false, true, Engine.board.wall[i].y + day2, 4, 0);

                        //setanimation(&Engine.board.wall[Engine.board.wall[wallfind[j]].point2].y, Engine.board.wall[Engine.board.wall[wallfind[j]].point2].y + day2, 4, 0);
                        AddWallAnimation(Engine.board.wall[Engine.board.wall[wallfind[j]].point2], false, true, Engine.board.wall[Engine.board.wall[wallfind[j]].point2].y + day2, 4, 0);
                    }
                }
                else
                {
                    i = wallfind[j] - 1; if (i < startwall) i = endwall - 1;
                    dax2 = ((Engine.board.wall[i].x + Engine.board.wall[Engine.board.wall[wallfind[j]].point2].x) >> 1) - Engine.board.wall[wallfind[j]].x;
                    day2 = ((Engine.board.wall[i].y + Engine.board.wall[Engine.board.wall[wallfind[j]].point2].y) >> 1) - Engine.board.wall[wallfind[j]].y;
                    if (dax2 != 0)
                    {
                        //setanimation(&Engine.board.wall[wallfind[j]].x, centx, 4, 0);
                        AddWallAnimation(Engine.board.wall[wallfind[j]], true, false, centx, 4, 0);

                        //setanimation(&Engine.board.wall[i].x, centx + dax2, 4, 0);
                        AddWallAnimation(Engine.board.wall[i], true, false, centx + dax2, 4, 0);

                        //setanimation(&Engine.board.wall[Engine.board.wall[wallfind[j]].point2].x, centx + dax2, 4, 0);
                        AddWallAnimation(Engine.board.wall[Engine.board.wall[wallfind[j]].point2], true, false, centx + dax2, 4, 0);
                    }
                    else if (day2 != 0)
                    {
                        //setanimation(&Engine.board.wall[wallfind[j]].y, centy, 4, 0);
                        AddWallAnimation(Engine.board.wall[wallfind[j]], false, true, centy, 4, 0);

                        //setanimation(&Engine.board.wall[i].y, centy + day2, 4, 0);
                        AddWallAnimation(Engine.board.wall[i], false, true, centy + day2, 4, 0);

                        //setanimation(&Engine.board.wall[Engine.board.wall[wallfind[j]].point2].y, centy + day2, 4, 0);
                        AddWallAnimation(Engine.board.wall[Engine.board.wall[wallfind[j]].point2], false, true, centy + day2, 4, 0);
                    }
                }
            }
            //   wsayfollow("updowndr.wav", 4096L - 256L, 256L, &centx, &centy, 0);
            //   wsayfollow("updowndr.wav", 4096L + 256L, 256L, &centx, &centy, 0);
        }

    }

    void RunWallAnimations()
    {
        for (int i = 0; i < wallAnimations.Count; i++)
        {
            WallAnimation wallAnimation = wallAnimations[i];

            int value = -1;

            if(wallAnimation.isX)
                value = wallAnimation.wall.x;
            if(wallAnimation.isY)
                value = wallAnimation.wall.y;

            if (value < wallAnimation.goalValue)
                value = Mathf.Min(value + wallAnimation.thevel * TICSPERFRAME, wallAnimation.goalValue);
            else
                value = Mathf.Max(value - wallAnimation.thevel * TICSPERFRAME, wallAnimation.goalValue);

            wallAnimation.thevel += wallAnimation.theacc;

            if(wallAnimation.isX)
                wallAnimation.wall.x = value;
            if(wallAnimation.isY)
                wallAnimation.wall.y = value;

            if (value == wallAnimation.goalValue)
            {
                wallAnimations.Remove(wallAnimation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        RunWallAnimations();

        Engine.board.drawrooms(player.posx, player.posy, player.posz, player.ang, 100, player.sectornum);
        Engine.board.drawmasks();
        Engine.NextPage();
    }
}
