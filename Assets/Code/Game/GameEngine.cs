using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Build;

public class GameEngine : MonoBehaviour
{
    //public Player player;
    public RawImage canvasImage;

    // Start is called before the first frame update
    public void Start()
    {
        // Init the build engine.
        Engine.Init();

        // Load in the game data.
        //Engine.initgroupfile("data.grp");
        //
        //Engine.LoadTables();

        // Init the device
        Engine.setgamemode(0, 640, 480, 8);

        // Load in the tiles.
      //  Engine.loadpics("tiles000.art");

        canvasImage.texture = Engine._device._screenbuffer._texture;

        GlobalMembers.DukeMain("");
    }

    // Update is called once per frame
    void Update()
    {
        //RunWallAnimations();
        //
        //Engine.board.drawrooms(player.posx, player.posy, player.posz, player.ang, 100, player.sectornum);
        //Engine.board.drawmasks();
        //Engine.NextPage();
    }
}
