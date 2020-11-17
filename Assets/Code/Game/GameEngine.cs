//-------------------------------------------------------------------------
/*
Copyright (c) 2020 - Blackenmace Studios LLC
Copyright (C) 1996, 2003 - 3D Realms Entertainment

This file is part of the Duke Nukem 3D C# Source Port
This file is part of Duke Nukem 3D version 1.5 - Atomic Edition

Duke Nukem 3D is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  

See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

C# Port Conversion: 2020 - Justin Marshall
Original Source: 1996 - Todd Replogle
Prepared for public release: 03/21/2003 - Charlie Wiederhold, 3D Realms
*/
//-------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Runtime.InteropServices;

using Build;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    //public Player player;
    public RawImage canvasImage;
    public Texture2D _texture;

    public static string AppPath;

    private static void DukeThread()
    {
        GlobalMembers.DukeMain("");
    }

    // Start is called before the first frame update
    public void Start()
    {
        AppPath = Application.dataPath;

      // GlobalMembers.ud.warp_on = 1;
      // GlobalMembers.boardfilename = "aitest.map";

        // Init the build engine.
        Engine.Init();

        // Load in the game data.
        //Engine.initgroupfile("data.grp");
        //

        // Init the device
        Engine.setgamemode(0, 640, 480, 8);
        _texture = new Texture2D(Engine._device._screenbuffer._width, Engine._device._screenbuffer._height, TextureFormat.BGRA32, false);

        canvasImage.texture = _texture;

        // Load in the tiles.
        //  Engine.loadpics("tiles000.art");

        Thread dukeThread = new Thread(new ThreadStart(DukeThread));
        dukeThread.Start();
    }

    static float dukeClock = 0.0f;

    // Update is called once per frame
    void Update()
    {        
        GlobalMembers.anyKeyDown = Input.anyKeyDown;

        if (Input.GetKeyDown(KeyCode.Escape))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_Escape)] = true;
        else if (Input.GetKeyUp(KeyCode.Escape))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_Escape)] = false;

        if (Input.GetKeyDown(KeyCode.Return))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_Return)] = true;
        else if (Input.GetKeyUp(KeyCode.Return))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_Return)] = false;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_UpArrow)] = true;
        else if (Input.GetKeyUp(KeyCode.UpArrow))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_UpArrow)] = false;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_DownArrow)] = true;
        else if (Input.GetKeyUp(KeyCode.DownArrow))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_DownArrow)] = false;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_LeftArrow)] = true;
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_LeftArrow)] = false;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_RightArrow)] = true;
        else if (Input.GetKeyUp(KeyCode.RightArrow))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_RightArrow)] = false;


        if (GlobalMembers.totalclock == 0)
        {
            dukeClock = 1.0f;
            GlobalMembers.totalclock = 1;
        }
        else
        {
            dukeClock += Time.deltaTime;
            GlobalMembers.totalclock = (int)(dukeClock * 120.0f);
        }

        GlobalMembers.faketimerhandler();

        Engine._device._screenbuffer.mut.WaitOne();

        GCHandle handle = GCHandle.Alloc(Engine._device._screenbuffer.PresentedPixels, GCHandleType.Pinned);
        try
        {
            IntPtr pointer = handle.AddrOfPinnedObject();
            _texture.LoadRawTextureData(pointer, Engine._device._screenbuffer._width * Engine._device._screenbuffer._height * 4);
            _texture.Apply();
        }
        finally
        {
            if (handle.IsAllocated)
            {
                handle.Free();
            }
        }

        Engine._device._screenbuffer.mut.ReleaseMutex();
    }
}
