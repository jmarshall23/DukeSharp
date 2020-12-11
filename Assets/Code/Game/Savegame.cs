using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Build;
using UnityEngine;

public partial class GlobalMembers
{
    public static string SaveFileExists(int i)
    {
        string fn = Application.streamingAssetsPath + "/" + "game" + i + ".sav";
        if (!File.Exists(fn))
            return null;

        FileStream fs = File.OpenRead(fn);

        if (fn == null)
        {
            return null;
        }
        
        BinaryFormatter formatter = new BinaryFormatter();

        int bv = (int)formatter.Deserialize(fs);
        string _mapname = (string)formatter.Deserialize(fs);

        fs.Close();

        return _mapname;
    }
	public static bool loadpheader(int spot, ref int vn, ref int ln, ref int psk, ref int nump)
	{
        int i;
        int j;
        string fn = "game0.sav";
        int bv;

        if (spot < 0)
        {
            multiflag = 1;
            multiwhat = 1;
            multipos = (sbyte)(-spot - 1);
            return false;
        }

        waitforeverybody();

        fn = Application.streamingAssetsPath + "/" + fn.Replace('0', (char)('0' + spot));

        FileStream fs = File.OpenRead(fn);

        if (fn == null)
        {
            return false;
        }

        ready2send = (char)0;
        BinaryFormatter formatter = new BinaryFormatter();

		bv = (int)formatter.Deserialize(fs);
        string _mapname = (string)formatter.Deserialize(fs);

        nump = (int)formatter.Deserialize(fs);
		vn = (int)formatter.Deserialize(fs);
		ln = (int)formatter.Deserialize(fs);
		psk = (int)formatter.Deserialize(fs);
		
		fs.Close();

		return true;
	}

	public static bool loadplayer(sbyte spot)
	{
        int i;
        int j;
        string fn = "game0.sav";
        int bv;

        if (spot < 0)
        {
            multiflag = 1;
            multiwhat = 1;
            multipos = (sbyte)(-spot - 1);
            return false;
        }

        waitforeverybody();

        fn = Application.streamingAssetsPath + "/" + fn.Replace('0', (char)('0' + spot));

        FileStream fs = File.OpenRead(fn);

        if (fn == null)
        {
            return false;
        }

        ready2send = (char)0;
        BinaryFormatter formatter = new BinaryFormatter();

        bv = (int)formatter.Deserialize(fs); // dfwrite(bv, 4, 1, fil);
        string _mapname = (string)formatter.Deserialize(fs);
        ud.multimode = (int)formatter.Deserialize(fs); // dfwrite(ud.multimode, sizeof(ud.multimode), 1, fil);		

        //dfwrite(ud.savegame[spot][0], 19, 1, fil);
        ud.savegame[spot] = _mapname;
        ud.volume_number = (int)formatter.Deserialize(fs); //dfwrite(ud.volume_number, sizeof(ud.volume_number), 1, fil);
        ud.level_number = (int)formatter.Deserialize(fs); //dfwrite(ud.level_number, sizeof(ud.level_number), 1, fil);
        ud.player_skill = (int)formatter.Deserialize(fs);//dfwrite(ud.player_skill, sizeof(ud.player_skill), 1, fil);
                                                         //dfwrite((string)waloff[DefineConstants.MAXTILES - 1], 160, 100, fil);
        Engine.newboard();
        Engine.board.numwalls = (int)formatter.Deserialize(fs);//dfwrite(numwalls, 2, 1, fil);
        Engine.board.wall = (Build.walltype[])formatter.Deserialize(fs); //dfwrite(Engine.board.wall[0], sizeof(walltype), DefineConstants.MAXWALLS, fil);
        Engine.board.numsectors = (int)formatter.Deserialize(fs); //dfwrite(numsectors, 2, 1, fil);
                                                                  //formatter.Serialize(fs, Engine.board.numsprites);
        Engine.board.sector = (Build.sectortype[])formatter.Deserialize(fs); // dfwrite(sector[0], sizeof(sectortype), DefineConstants.MAXSECTORS, fil);
        Engine.board.sprite = (Build.spritetype[])formatter.Deserialize(fs); // dfwrite(Engine.board.sprite[0], sizeof(spritetype), DefineConstants.MAXSPRITES, fil);

        for(int d = 0; d < Engine.board.numsectors; d++)
        {
            Engine.board.sector[d].changed = true;
        }


        Engine.board.headspritesect = (int[])formatter.Deserialize(fs); //dfwrite(headspritesect[0], 2, DefineConstants.MAXSECTORS + 1, fil);
        Engine.board.prevspritesect = (int[])formatter.Deserialize(fs); //dfwrite(prevspritesect[0], 2, DefineConstants.MAXSPRITES, fil);
        Engine.board.nextspritesect = (int[])formatter.Deserialize(fs); //dfwrite(nextspritesect[0], 2, DefineConstants.MAXSPRITES, fil);
        Engine.board.headspritestat = (int[])formatter.Deserialize(fs);  //dfwrite(headspritestat[0], 2, DefineConstants.MAXSTATUS + 1, fil);
        Engine.board.prevspritestat = (int[])formatter.Deserialize(fs); //dfwrite(prevspritestat[0], 2, DefineConstants.MAXSPRITES, fil);
        Engine.board.nextspritestat = (int[])formatter.Deserialize(fs); //dfwrite(nextspritestat[0], 2, DefineConstants.MAXSPRITES, fil);
        numcyclers = (short)formatter.Deserialize(fs); // dfwrite(numcyclers, sizeof(numcyclers), 1, fil);
        cyclers = (short[,])formatter.Deserialize(fs); //dfwrite(cyclers[0][0], 12, DefineConstants.MAXCYCLERS, fil);
        ps = (player_struct[])formatter.Deserialize(fs); //dfwrite(ps, sizeof(ps), 1, fil);
        po = (player_orig[])formatter.Deserialize(fs); //dfwrite(po, sizeof(po), 1, fil);
        numanimwalls = (short)formatter.Deserialize(fs); //dfwrite(numanimwalls, sizeof(numanimwalls), 1, fil);
        animwall = (animwalltype[])formatter.Deserialize(fs);//dfwrite(animwall, sizeof(animwall), 1, fil);
                                                             //C++ TO C# CONVERTER WARNING: This 'sizeof' ratio was replaced with a direct reference to the array length:
                                                             //ORIGINAL LINE: dfwrite(&msx[0],sizeof(int),sizeof(msx)/sizeof(int),fil);
        msx = (int[])formatter.Deserialize(fs);//dfwrite(msx[0], sizeof(int), msx.Length, fil);
                                               //C++ TO C# CONVERTER WARNING: This 'sizeof' ratio was replaced with a direct reference to the array length:
                                               //ORIGINAL LINE: dfwrite(&msy[0],sizeof(int),sizeof(msy)/sizeof(int),fil);
        msy = (int[])formatter.Deserialize(fs);//dfwrite(msy[0], sizeof(int), msy.Length, fil);
        spriteqloc = (short)formatter.Deserialize(fs);//dfwrite(spriteqloc, sizeof(short), 1, fil);
        spriteqamount = (short)formatter.Deserialize(fs);//dfwrite(spriteqamount, sizeof(short), 1, fil);
        spriteq = (short[])formatter.Deserialize(fs); //dfwrite(spriteq[0], sizeof(short), spriteqamount, fil);
        mirrorcnt = (short)formatter.Deserialize(fs); //dfwrite(mirrorcnt, sizeof(short), 1, fil);
                                                      //formatter.Serialize(fs, Engine.board.wall);
                                                      //dfwrite(mirrorEngine.board.wall[0], sizeof(short), 64, fil);
                                                      //dfwrite(mirrorsector[0], sizeof(short), 64, fil);
                                                      //dfwrite(show2dsector[0], sizeof(char), DefineConstants.MAXSECTORS >> 3, fil);

        actortype = (int[])formatter.Deserialize(fs); // dfwrite(actortype[0], sizeof(char), DefineConstants.MAXTILES, fil);
        boardfilename = (string)formatter.Deserialize(fs);// dfwrite(boardfilename[0], sizeof(boardfilename), 1, fil);


        numclouds = (short)formatter.Deserialize(fs); // dfwrite(numclouds, sizeof(numclouds), 1, fil);
        clouds = (short[])formatter.Deserialize(fs);
        cloudx = (short[])formatter.Deserialize(fs);
        cloudy = (short[])formatter.Deserialize(fs);
        //dfwrite(clouds[0], sizeof(short) << 7, 1, fil);
        //dfwrite(cloudx[0], sizeof(short) << 7, 1, fil);
        //dfwrite(cloudy[0], sizeof(short) << 7, 1, fil);

        hittype = (weaponhit[])formatter.Deserialize(fs);
        lockclock = (int)formatter.Deserialize(fs);
        Engine.board.pskybits = (int)formatter.Deserialize(fs);
        Engine.board.pskyoff = (short[])formatter.Deserialize(fs);
        animatecnt = (int)formatter.Deserialize(fs);
        animatesect = (short[])formatter.Deserialize(fs);
        animateptr = (SectorAnimation[])formatter.Deserialize(fs);
        animategoal = (int[])formatter.Deserialize(fs);
        animatevel = (int[])formatter.Deserialize(fs);



        earthquaketime = (char)formatter.Deserialize(fs);
        ud.from_bonus = (short)formatter.Deserialize(fs);
        ud.secretlevel = (short)formatter.Deserialize(fs);
        ud.respawn_monsters = (int)formatter.Deserialize(fs);
        ud.respawn_items = (int)formatter.Deserialize(fs);
        ud.respawn_inventory = (int)formatter.Deserialize(fs);
        ud.god = (int)formatter.Deserialize(fs);
        ud.auto_run = (int)formatter.Deserialize(fs);
        ud.crosshair = (int)formatter.Deserialize(fs);
        ud.monsters_off = (int)formatter.Deserialize(fs);
        ud.last_level = (short)formatter.Deserialize(fs);
        ud.eog = (int)formatter.Deserialize(fs);
        ud.coop = (int)formatter.Deserialize(fs);
        ud.marker = (int)formatter.Deserialize(fs);
        ud.ffire = (int)formatter.Deserialize(fs);
        camsprite = (short)formatter.Deserialize(fs);
        connecthead = (short)formatter.Deserialize(fs);
        connectpoint2 = (short[])formatter.Deserialize(fs);
        numplayersprites = (char)formatter.Deserialize(fs);
        frags = (short[,])formatter.Deserialize(fs);
        Engine.randomseed = (int)formatter.Deserialize(fs);
        global_random = (short)formatter.Deserialize(fs);
        Engine.board.parallaxyscale = (int)formatter.Deserialize(fs);

        Engine.board.Init3D(false);


        resetmys();
        // jmarshall - palette
        ps[myconnectindex].palette = palette;
        palto(0, 0, 0, 0);
        //
        //setpal(ps[myconnectindex]);
        // jmarshall end
        flushperms();

        everyothertime = (char)0;
        global_random = 0;

        ud.last_level = (short)(ud.level_number + 1);

        clearfifo();

        for (i = (short)(numinterpolations - 1); i >= 0; i--)
        {
            bakipos[i] = curipos[i].Value;
        }

        // jmarshall - palette and networking
        //restorepalette = 1;
        //
        //flushpackets();
        // jmarshall end
        waitforeverybody();


        palto(0, 0, 0, 0);
        vscrn();
        Engine.clearview();
        drawbackground();

        // jmarshall - clear?
        //clearbufbyte(playerquitflag, DefineConstants.MAXPLAYERS, 0x01010101);
        Array.Clear(playerquitflag, 0, playerquitflag.Length);
        // jmarshall end
        ps[myconnectindex].over_shoulder_on = 0;

        clearfrags();

        resettimevars(); // Here we go

        currentStage = GameStateType.GAME_STATE_INGAME;
        ps[myconnectindex].gm = DefineConstants.MODE_GAME;
        in_menu = false;
        KB_FlushKeyboardQueue();

       // conScript.Event_EnterLevel(_mapName, ps[0].i);

        return true;
	}

	public static bool saveplayer(sbyte spot)
	{
		int i;
		int j;
		string fn = "game0.sav";
		int bv = DefineConstants.BYTEVERSION;

		if (spot < 0)
		{
			multiflag = 1;
			multiwhat = 1;
			multipos = (sbyte)(-spot - 1);
			return false;
		}

		waitforeverybody();

        fn = Application.streamingAssetsPath + "/" + fn.Replace('0', (char)('0' + spot));

		FileStream fs = File.OpenWrite(fn);

		if (fn == null)
        {
            return false;
        }

        ready2send = (char)0;
		BinaryFormatter formatter = new BinaryFormatter();

        string _mapName = boardfilename;
        if (boardfilename.Length == 0)
        {
            _mapName = level_names[(ud.volume_number * 11) + ud.level_number];
        }

        ud.savegame[spot] = _mapName;

        formatter.Serialize(fs, bv); // dfwrite(bv, 4, 1, fil);
        formatter.Serialize(fs, _mapName);
        formatter.Serialize(fs, ud.multimode); // dfwrite(ud.multimode, sizeof(ud.multimode), 1, fil);		        

        //dfwrite(ud.savegame[spot][0], 19, 1, fil);

        formatter.Serialize(fs, ud.volume_number); //dfwrite(ud.volume_number, sizeof(ud.volume_number), 1, fil);
		formatter.Serialize(fs, ud.level_number); //dfwrite(ud.level_number, sizeof(ud.level_number), 1, fil);
		formatter.Serialize(fs, ud.player_skill);//dfwrite(ud.player_skill, sizeof(ud.player_skill), 1, fil);
												 //dfwrite((string)waloff[DefineConstants.MAXTILES - 1], 160, 100, fil);

		formatter.Serialize(fs, Engine.board.numwalls);//dfwrite(numwalls, 2, 1, fil);
		formatter.Serialize(fs, Engine.board.wall); //dfwrite(Engine.board.wall[0], sizeof(walltype), DefineConstants.MAXWALLS, fil);
		formatter.Serialize(fs, Engine.board.numsectors); //dfwrite(numsectors, 2, 1, fil);
		//formatter.Serialize(fs, Engine.board.numsprites);
		formatter.Serialize(fs, Engine.board.sector); // dfwrite(sector[0], sizeof(sectortype), DefineConstants.MAXSECTORS, fil);
		formatter.Serialize(fs, Engine.board.sprite); // dfwrite(Engine.board.sprite[0], sizeof(spritetype), DefineConstants.MAXSPRITES, fil);


		formatter.Serialize(fs, Engine.board.headspritesect); //dfwrite(headspritesect[0], 2, DefineConstants.MAXSECTORS + 1, fil);
		formatter.Serialize(fs, Engine.board.prevspritesect); //dfwrite(prevspritesect[0], 2, DefineConstants.MAXSPRITES, fil);
		formatter.Serialize(fs, Engine.board.nextspritesect); //dfwrite(nextspritesect[0], 2, DefineConstants.MAXSPRITES, fil);
		formatter.Serialize(fs, Engine.board.headspritestat);  //dfwrite(headspritestat[0], 2, DefineConstants.MAXSTATUS + 1, fil);
		formatter.Serialize(fs, Engine.board.prevspritestat); //dfwrite(prevspritestat[0], 2, DefineConstants.MAXSPRITES, fil);
		formatter.Serialize(fs, Engine.board.nextspritestat); //dfwrite(nextspritestat[0], 2, DefineConstants.MAXSPRITES, fil);
		formatter.Serialize(fs, numcyclers); // dfwrite(numcyclers, sizeof(numcyclers), 1, fil);
		formatter.Serialize(fs, cyclers); //dfwrite(cyclers[0][0], 12, DefineConstants.MAXCYCLERS, fil);
		formatter.Serialize(fs, ps); //dfwrite(ps, sizeof(ps), 1, fil);
		formatter.Serialize(fs, po); //dfwrite(po, sizeof(po), 1, fil);
		formatter.Serialize(fs, numanimwalls); //dfwrite(numanimwalls, sizeof(numanimwalls), 1, fil);
		formatter.Serialize(fs, animwall);//dfwrite(animwall, sizeof(animwall), 1, fil);
		//C++ TO C# CONVERTER WARNING: This 'sizeof' ratio was replaced with a direct reference to the array length:
		//ORIGINAL LINE: dfwrite(&msx[0],sizeof(int),sizeof(msx)/sizeof(int),fil);
		formatter.Serialize(fs, msx);//dfwrite(msx[0], sizeof(int), msx.Length, fil);
		//C++ TO C# CONVERTER WARNING: This 'sizeof' ratio was replaced with a direct reference to the array length:
		//ORIGINAL LINE: dfwrite(&msy[0],sizeof(int),sizeof(msy)/sizeof(int),fil);
		formatter.Serialize(fs, msy);//dfwrite(msy[0], sizeof(int), msy.Length, fil);
		formatter.Serialize(fs, spriteqloc);//dfwrite(spriteqloc, sizeof(short), 1, fil);
		formatter.Serialize(fs, spriteqamount);//dfwrite(spriteqamount, sizeof(short), 1, fil);
		formatter.Serialize(fs, spriteq); //dfwrite(spriteq[0], sizeof(short), spriteqamount, fil);
		formatter.Serialize(fs, mirrorcnt); //dfwrite(mirrorcnt, sizeof(short), 1, fil);
		//formatter.Serialize(fs, Engine.board.wall);
		//dfwrite(mirrorEngine.board.wall[0], sizeof(short), 64, fil);
		//dfwrite(mirrorsector[0], sizeof(short), 64, fil);
		//dfwrite(show2dsector[0], sizeof(char), DefineConstants.MAXSECTORS >> 3, fil);

		formatter.Serialize(fs, actortype); // dfwrite(actortype[0], sizeof(char), DefineConstants.MAXTILES, fil);
		formatter.Serialize(fs, boardfilename);// dfwrite(boardfilename[0], sizeof(boardfilename), 1, fil);


		formatter.Serialize(fs, numclouds); // dfwrite(numclouds, sizeof(numclouds), 1, fil);
		formatter.Serialize(fs, clouds);
		formatter.Serialize(fs, cloudx);
		formatter.Serialize(fs, cloudy);
		//dfwrite(clouds[0], sizeof(short) << 7, 1, fil);
		//dfwrite(cloudx[0], sizeof(short) << 7, 1, fil);
		//dfwrite(cloudy[0], sizeof(short) << 7, 1, fil);

		formatter.Serialize(fs, hittype);
		formatter.Serialize(fs, lockclock);
		formatter.Serialize(fs, Engine.board.pskybits);
		formatter.Serialize(fs, Engine.board.pskyoff);
		formatter.Serialize(fs, animatecnt);
		formatter.Serialize(fs, animatesect);
		formatter.Serialize(fs, animateptr);
		formatter.Serialize(fs, animategoal);
		formatter.Serialize(fs, animatevel);



		formatter.Serialize(fs, earthquaketime);
		formatter.Serialize(fs, ud.from_bonus);
		formatter.Serialize(fs, ud.secretlevel);
		formatter.Serialize(fs, ud.respawn_monsters);
		formatter.Serialize(fs, ud.respawn_items);
		formatter.Serialize(fs, ud.respawn_inventory);
		formatter.Serialize(fs, ud.god);
		formatter.Serialize(fs, ud.auto_run);
		formatter.Serialize(fs, ud.crosshair);
		formatter.Serialize(fs, ud.monsters_off);
		formatter.Serialize(fs, ud.last_level);
		formatter.Serialize(fs, ud.eog);
		formatter.Serialize(fs, ud.coop);
		formatter.Serialize(fs, ud.marker);
		formatter.Serialize(fs, ud.ffire);
		formatter.Serialize(fs, camsprite);
		formatter.Serialize(fs, connecthead);
		formatter.Serialize(fs, connectpoint2);
		formatter.Serialize(fs, numplayersprites);
		formatter.Serialize(fs, frags);

		formatter.Serialize(fs, Engine.randomseed);
		formatter.Serialize(fs, global_random);
		formatter.Serialize(fs, Engine.board.parallaxyscale);
		
		fs.Close();

		if (ud.multimode < 2)
		{
			fta_quotes[122] = "GAME SAVED";
			FTA(122, ps[myconnectindex]);
		}

		ready2send = (char)1;

		waitforeverybody();

		ototalclock = totalclock;

       // conScript.Event_EnterLevel("", ps[0].i);

        return true;
	}
}