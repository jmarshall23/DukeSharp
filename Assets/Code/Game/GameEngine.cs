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

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GameEngine : MonoBehaviour
{
    //public Player player;
    public RawImage canvasImage;
    public Texture2D _texture;
    public TextAsset _defaultGrpFile; // Only used on non PC platforms
    public Canvas mobileCanvas;
    public UIButton mobileUpButton;
    public UIButton mobileDownButton;
    public UIButton mobileLeftButton;
    public UIButton mobileRightButton;
    public UIButton mobileFireButton;
    public UIButton mobileJumpButton;
    public UIButton mobileOpenButton;
    public UIButton mobilePrevButton;
    public UIButton mobileNextButton;

    public static string AppPath;

    private bool delayedStart = true;
    private GCHandle handle;

    // Start is called before the first frame update
    public void Start()
    {
        bGrpArchive._defaultGrpFile = _defaultGrpFile;

#if (UNITY_STANDALONE || UNITY_EDITOR)
        mobileCanvas.enabled = false;
#endif
    }

    private void DelayedStart()
    {
        AppPath = Application.dataPath;

       // GlobalMembers.ud.warp_on = 1;
       // GlobalMembers.boardfilename = "e1l1.map";

        // Init the build engine.
        Engine.Init();

        // This needs to be done in the main thread so we can do sound loading immediatly afterwords.
        GlobalMembers.conScript = new ConScript(new TrapEngine());
        SoundEngine.globalSoundEngine.LoadAllSounds();

        // Load in the game data.
        //Engine.initgroupfile("data.grp");
        //

        // Init the device
        Engine.setgamemode(0, 640, 480, 8);
        _texture = new Texture2D(Engine._device._screenbuffer._width, Engine._device._screenbuffer._height, TextureFormat.BGRA32, false);

        canvasImage.texture = _texture;

        GlobalMembers.DukeMain(""); // Get everything setup.

        Engine.palette.UpdatePaletteMainThread();

        handle = GCHandle.Alloc(Engine._device._screenbuffer.PresentedPixels, GCHandleType.Pinned);
    }

    static float dukeClock = 0.0f;

    // Update is called once per frame
    void Update()
    {      
        if(delayedStart)
        {
            DelayedStart();
            delayedStart = false;
        }

        GlobalMembers.anyKeyDown = Input.anyKeyDown;

#if !(UNITY_STANDALONE || UNITY_EDITOR)
        GlobalMembers.KB_KeyDown[(DefineConstants.sc_UpArrow)] = mobileUpButton.buttonPressed;
        GlobalMembers.KB_KeyDown[(DefineConstants.sc_DownArrow)] = mobileDownButton.buttonPressed;
        GlobalMembers.KB_KeyDown[(DefineConstants.sc_LeftArrow)] = mobileLeftButton.buttonPressed;
        GlobalMembers.KB_KeyDown[(DefineConstants.sc_RightArrow)] = mobileRightButton.buttonPressed;
        GlobalMembers.KB_KeyDown[(DefineConstants.sc_LeftControl)] = mobileFireButton.buttonPressed;
        GlobalMembers.KB_KeyDown[(DefineConstants.sc_Space)] = mobileJumpButton.buttonPressed;
        GlobalMembers.KB_KeyDown[(DefineConstants.sc_E)] = mobileOpenButton.buttonPressed;
        GlobalMembers.KB_KeyDown[(DefineConstants.sc_R)] = mobilePrevButton.buttonPressed;
        GlobalMembers.KB_KeyDown[(DefineConstants.sc_T)] = mobileNextButton.buttonPressed;
#else
        if (Input.GetKey(KeyCode.LeftShift))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_LeftShift)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_LeftShift)] = false;


        if (Input.GetKeyDown(KeyCode.Escape))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_Escape)] = true;
        else if (Input.GetKeyUp(KeyCode.Escape))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_Escape)] = false;

        if (Input.GetKey(KeyCode.Return))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_Return)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_Return)] = false;

        if (Input.GetKey(KeyCode.LeftBracket))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_OpenBracket)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_OpenBracket)] = false;

        if (Input.GetKey(KeyCode.RightBracket))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_CloseBracket)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_CloseBracket)] = false;

        if (Input.GetKey(KeyCode.UpArrow))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_UpArrow)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_UpArrow)] = false;

        if (Input.GetKey(KeyCode.DownArrow))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_DownArrow)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_DownArrow)] = false;

        if (Input.GetKey(KeyCode.LeftArrow))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_LeftArrow)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_LeftArrow)] = false;

        if (Input.GetKey(KeyCode.RightArrow))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_RightArrow)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_RightArrow)] = false;

        if (Input.GetKey(KeyCode.Space))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_Space)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_Space)] = false;


        if (Input.GetKey(KeyCode.C))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_C)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_C)] = false;

        if (Input.GetKey(KeyCode.LeftControl))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_LeftControl)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_LeftControl)] = false;

        if (Input.GetKey(KeyCode.E))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_E)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_E)] = false;

        if (Input.GetKey(KeyCode.R))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_R)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_R)] = false;

        if (Input.GetKey(KeyCode.T))
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_T)] = true;
        else
            GlobalMembers.KB_KeyDown[(DefineConstants.sc_T)] = false;
#endif
        for (int i = 0; i <= 9; i++)
        {
            if (Input.GetKey(KeyCode.Alpha0 + i))
                GlobalMembers.KB_KeyDown[(DefineConstants.sc_0 + i)] = true;
            else
                GlobalMembers.KB_KeyDown[(DefineConstants.sc_0 + i)] = false;
        }


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

        GlobalMembers.RunState();

        GlobalMembers.faketimerhandler();        

        if (Engine.board != null && Engine.board.render3D != null)
        {
            Engine.board.render3D.DisplayRoom(Engine.board.globalcursectnum);
        }


        IntPtr pointer = handle.AddrOfPinnedObject();
        _texture.LoadRawTextureData(pointer, Engine._device._screenbuffer._width * Engine._device._screenbuffer._height * 4);
        _texture.Apply();
    }
}
