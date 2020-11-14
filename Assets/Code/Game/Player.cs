using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Build;

public partial class GlobalMembers
{
    public static void checkweapons(player_struct p)
    {

    }

    public static void forceplayerangle(player_struct p)
    {

    }

    public static short inventory(spritetype s)
    {
        return 0;
    }
}

public class Player : MonoBehaviour
{
    public int posx;
    public int posy;
    public int posz;
    public short ang;
    public short sectornum;

    private int fvel = 0;
    private int svel = 0;

    private int angvel = 0;

    private int poszv = 0;

    private int jumping_counter = 0;

    public GameEngine gameEngine;


    void Start()
    {
        gameEngine.InitEngine();
        Engine.loadboard("NUKELAND.MAP", ref posx, ref posy, ref posz, ref ang, ref sectornum);
    }

    //
    // ProcessInput
    //
    public void ProcessInput(int fvel, int svel, int angvel)
    {
        this.fvel += fvel;
        this.svel += svel;
        this.angvel += angvel;
    }

    //
    // Jump
    //
    public void Jump()
    {
        if (jumping_counter > 0)
            return;

        jumping_counter = 1;
    }

    //
    // ProcessMovement
    //
    private void ProcessMovement(int xvect, int yvect)
    {
        int i = 40;
        int fz = 0, cz = 0, hz = 0, lz = 0;
        int k;

        Engine.board.getzrange(posx, posy, posz, sectornum, ref cz, ref hz, ref fz, ref lz, 163, Engine.CLIPMASK0);

        if (jumping_counter > 0)
        {
            if (jumping_counter < (1024 + 512))
            {
                if (jumping_counter > 768)
                {
                    jumping_counter = 0;
                    poszv = -2048;
                }
                else
                {
                    poszv -= (Engine.table.sintable[(2048 - 128 + jumping_counter) & 2047]) / 12;
                    jumping_counter += 180;
                    // onground = false;
                }
            }
            else
            {
                jumping_counter = 0;
                poszv = 0;
            }
        }
        else if (posz < (fz - (i << 8)))
        {
            poszv += (176 + 80);

            if ((posz + poszv) >= (fz - (i << 8))) // hit the ground
            {
                poszv = 0;
            }
        }
        else
        {
            //Smooth on the ground

            k = ((fz - (i << 8)) - posz) >> 1;
            if (pragmas.klabs(k) < 256) k = 0;
            posz += k;
            poszv -= 768;
            if (poszv < 0) poszv = 0;
        }

        posz += poszv;

        Engine.board.clipmove(ref posx, ref posy, ref posz, ref sectornum, xvect, yvect, 164, (4 << 8), (4 << 8), Engine.CLIPMASK0);
    }

    private void MovePlayer()
    {
        int xvect = 0, yvect = 0;

        ang += (short)angvel;

        int doubvel = 3;

        xvect = 0; yvect = 0;
        if (fvel != 0)
        {
            xvect += ((((int)fvel) * doubvel * (int)Engine.table.sintable[(ang + 512) & 2047]) >> 3);
            yvect += ((((int)fvel) * doubvel * (int)Engine.table.sintable[ang & 2047]) >> 3);
        }
        if (svel != 0)
        {
            xvect += ((((int)svel) * doubvel * (int)Engine.table.sintable[ang & 2047]) >> 3);
            yvect += ((((int)svel) * doubvel * (int)Engine.table.sintable[(ang + 1536) & 2047]) >> 3);
        }

        ProcessMovement(xvect, yvect);

        svel = 0;
        fvel = 0;
        angvel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int xvel = 0;
        int yvel = 0;

        if(Input.GetKey(KeyCode.UpArrow))
            xvel = 20;

        if(Input.GetKey(KeyCode.DownArrow))
            xvel = -20;

        if(Input.GetKey(KeyCode.LeftArrow))
            yvel = -4;

        if(Input.GetKey(KeyCode.RightArrow))
            yvel = 4;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            short neartagsector = -1;
            short neartagwall = -1;
            short neartagsprite = -1;
            int neartaghitdist = -1;

            Engine.board.neartag(posx,posy,posz,sectornum,ang,ref neartagsector,ref neartagwall,ref neartagsprite, ref neartaghitdist,1024,3);

            if (neartagsector >= 0)
				if (Engine.board.sector[neartagsector].hitag == 0)
					gameEngine.OperateSector(neartagsector);
        }

        ProcessInput(xvel, 0, yvel);
        
        ProcessMovement(fvel, svel);
        MovePlayer();
    }
}
