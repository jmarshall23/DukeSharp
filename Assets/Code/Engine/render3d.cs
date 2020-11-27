using System;
using UnityEngine;
using LibTessDotNet;

namespace Build
{
    class Render3D
    {

        private class Plane3D
        {
            public Vector3[] xyz;
            public Vector2[] st;
            public int[] indexes;

            public void Init(int vertexcount)
            {
                xyz = new Vector3[vertexcount];
                st = new Vector2[vertexcount];
            }
        }
        private class Sector3D
        {
            public float floorz;
            public float ceilingz;
            public float floorheinum;
            public float ceilingheinum;
            public float floorstat;
            public float ceilingstat;
            public float floorxpanning;
            public float ceilingxpanning;
            public float floorypanning;
            public float ceilingypanning;
            public float floorshade;
            public float floorpal;
            public float floorpicnum;
            public float ceilingpicnum;

            public float[] verts;

            public int indicescount;

            public Plane3D floor = new Plane3D();
            public Plane3D ceil = new Plane3D();
        }

        private class Wall3D
        {
            public int picnum_anim;
            public int overpicnum_anim;
            public int nwallpicnum;
            public int nwallxpanning;
            public int nwallypanning;
            public int nwallcstat;
            public int nwallshade;
            public int underover;


            public Plane3D wall = new Plane3D();
            public Plane3D over = new Plane3D();
            public Plane3D mask = new Plane3D();
        }

        private bMap board;
        private Sector3D[] sector3D;
        private Wall3D[] wall3D;

        public void LoadBoard(bMap board)
        {
            this.board = board;

            sector3D = new Sector3D[board.numsectors];

            for(int i = 0; i < board.numsectors; i++)
            {
                InitSector(i);
                UpdateSector((short)i);
            }

            wall3D = new Wall3D[board.numwalls];
            for (int i = 0; i < board.numwalls; i++)
            {
                wall3D[i].wall.Init(4);
                UpdateWall((short)i);
            }
        }

        private void DO_TILE_ANIM(ref short Picnum, int fakevar)
        {
            //if (Engine.picanm[Picnum] & PICANM_ANIMTYPE_MASK) Picnum += animateoffs(Picnum, Fakevar);
        }

        private void UpdateWall(short wallnum)
        {
			short nwallnum;
            short nnwallnum;
            short curpicnum;
            short wallpicnum;
            short walloverpicnum;
            short nwallpicnum;
            char curxpanning;
            char curypanning;
            char underwall;
            char overwall;
            char curpal;
            sbyte curshade;
            walltype wal;
            sectortype sec;
            sectortype nsec;
            Wall3D w;
            Sector3D s;
            Sector3D ns;
            int xref;
            int yref;
            float ypancoef;
            float dist;
            int i;
          //  uint invalid;
            int sectofwall = board.sectorofwall(wallnum);

            // yes, this function is messy and unefficient
            // it also works, bitches
            sec = board.sector[sectofwall];

            if (sectofwall < 0 || sectofwall >= board.numsectors || wallnum < 0 || wallnum > board.numwalls || sec.wallptr > wallnum || wallnum >= (sec.wallptr + sec.wallnum))
            {
                return; // yay, corrupt map
            }

            wal = board.wall[wallnum];
            nwallnum = wal.nextwall;

            w = wall3D[wallnum];
            s = sector3D[sectofwall];
           // invalid = s.invalidid;
            if (nwallnum >= 0 && nwallnum < board.numwalls && wal.nextsector >= 0 && wal.nextsector < board.numsectors)
            {
                ns = sector3D[wal.nextsector];
             //   invalid += ns.invalidid;
                nsec = board.sector[wal.nextsector];
            }
            else
            {
                ns = null;
                nsec = null;
            }

            if (w.wall.xyz == null)
            {
                w.wall.xyz = new Vector3[4];
                w.wall.st = new Vector2[4];
            }

            wallpicnum = wal.picnum;
            DO_TILE_ANIM(ref wallpicnum, wallnum + 16384);

            walloverpicnum = wal.overpicnum;
            if (walloverpicnum >= 0)
            {
                DO_TILE_ANIM(ref walloverpicnum, wallnum + 16384);
            }

            if (nwallnum >= 0 && nwallnum < board.numwalls)
            {
                nwallpicnum = board.wall[nwallnum].picnum;
                DO_TILE_ANIM(ref nwallpicnum, wallnum + 16384);
            }
            else
            {
                nwallpicnum = 0;
            }

            if ((wallpicnum == w.picnum_anim) && (walloverpicnum == w.overpicnum_anim) && ((nwallnum < 0 || nwallnum > board.numwalls) || ((nwallpicnum == w.nwallpicnum) && (board.wall[nwallnum].xpanning == w.nwallxpanning) && (board.wall[nwallnum].ypanning == w.nwallypanning) && (board.wall[nwallnum].cstat == w.nwallcstat) && (board.wall[nwallnum].shade == w.nwallshade))))
            {
                //w.flags.uptodate = 1;
                return; // screw you guys I'm going home
            }
            else
            { 
                w.picnum_anim = wallpicnum;
                w.overpicnum_anim = walloverpicnum;

                if (nwallnum >= 0 && nwallnum < board.numwalls)
                {
                    w.nwallpicnum = nwallpicnum;
                    w.nwallxpanning = board.wall[nwallnum].xpanning;
                    w.nwallypanning = board.wall[nwallnum].ypanning;
                    w.nwallcstat = board.wall[nwallnum].cstat;
                    w.nwallshade = board.wall[nwallnum].shade;
                }
            }

            w.underover = underwall = overwall = (char)0;

            if ((wal.cstat & 8) != 0)
            {
                xref = 1;
            }
            else
            {
                xref = 0;
            }

            if ((uint)wal.nextsector >= (uint)board.numsectors || ns == null)
            {
                w.wall.xyz[0] = s.floor.xyz[wallnum - sec.wallptr];
                w.wall.xyz[1] = s.floor.xyz[wal.point2 - sec.wallptr];
                w.wall.xyz[2] = s.ceil.xyz[wal.point2 - sec.wallptr];
                w.wall.xyz[3] = s.ceil.xyz[wallnum - sec.wallptr];

                if (wal.nextsector < 0)
                {
                    curpicnum = wallpicnum;
                }
                else
                {
                    curpicnum = walloverpicnum;
                }

               // w.wall.bucket = polymer_getbuildmaterial(w.wall.material, curpicnum, wal.pal, wal.shade, sec.visibility, DAMETH_WALL);

                if ((wal.cstat & 4) != 0)
                {
                    yref = sec.floorz;
                }
                else
                {
                    yref = sec.ceilingz;
                }

                if ((wal.cstat & 32) != 0 && (wal.nextsector >= 0))
                {
                    if ((0 == (wal.cstat & 2) && (wal.cstat & 4) != 0) || ((wal.cstat & 2) != 0 && 0 != (board.wall[nwallnum].cstat & 4)))
                    {
                        yref = sec.ceilingz;
                    }
                    else
                    {
                        yref = nsec.floorz;
                    }
                }

                //if (wal.ypanning)
                //{
                //    // white (but not 1-way)
                //    ypancoef = calc_ypancoef(wal.ypanning, curpicnum, !(wal.cstat & 4));
                //}
                //else
                {
                    ypancoef = 0F;
                }

                i = 0;
                while (i < 4)
                {
                    if ((i == 0) || (i == 3))
                    {
                        dist = (float)xref;
                    }
                    else
                    {
                        dist = (float)((xref == 0) ? 1 : 0);
                    }

                    w.wall.st[i].x = ((dist * 8.0f * wal.xrepeat) + wal.xpanning) / (float)(Engine.tilesizx[curpicnum]);
                    w.wall.st[i].y = (-(float)(yref + (w.wall.xyz[i].y * 16)) / ((Engine.tilesizy[curpicnum] * 2048.0f) / (float)(wal.yrepeat))) + ypancoef;

                    if ((wal.cstat & 256) != 0)
                    {
                        w.wall.st[i].y = -w.wall.st[i].y;
                    }

                    i++;
                }

                w.underover |= 1;
            }
            else
            {
                nnwallnum = board.wall[nwallnum].point2;

                if ((s.floor.xyz[wallnum - sec.wallptr].y < ns.floor.xyz[nnwallnum - nsec.wallptr].y) || (s.floor.xyz[wal.point2 - sec.wallptr].y < ns.floor.xyz[nwallnum - nsec.wallptr].y))
                {
                    underwall = (char)1;
                }

                if ((underwall) != 0 || (wal.cstat & 16) != 0 || (wal.cstat & 32) != 0)
                {
                    int refwall;

                    if (s.floor.xyz[wallnum - sec.wallptr].y < ns.floor.xyz[nnwallnum - nsec.wallptr].y)
                    {
                        w.wall.xyz[0] = s.floor.xyz[wallnum - sec.wallptr];
                    }
                    else
                    {
                        w.wall.xyz[0] = ns.floor.xyz[nnwallnum - nsec.wallptr];
                    }
                    w.wall.xyz[1] = s.floor.xyz[wal.point2 - sec.wallptr];
                    w.wall.xyz[2] = ns.floor.xyz[nwallnum - nsec.wallptr];
                    w.wall.xyz[3] = ns.floor.xyz[nnwallnum - nsec.wallptr];

                    if ((wal.cstat & 2) != 0)
                    {
                        refwall = nwallnum;
                    }
                    else
                    {
                        refwall = wallnum;
                    }

                    curpicnum = (wal.cstat & 2) != 0 ? nwallpicnum : wallpicnum;
                    curpal = (char)board.wall[refwall].pal;
                    curshade = board.wall[refwall].shade;
                    curxpanning = (char)board.wall[refwall].xpanning;
                    curypanning = (char)board.wall[refwall].ypanning;

                   // w.wall.bucket = polymer_getbuildmaterial(w.wall.material, curpicnum, curpal, curshade, sec.visibility, DAMETH_WALL);

                    if ((board.wall[refwall].cstat & 4) == 0)
                    {
                        yref = nsec.floorz;
                    }
                    else
                    {
                        yref = sec.ceilingz;
                    }

                    //if (curypanning)
                    //{
                    //    // under
                    //    ypancoef = calc_ypancoef(curypanning, curpicnum, !(wall[refwall].cstat & 4));
                    //}
                    //else
                    {
                        ypancoef = 0F;
                    }

                    i = 0;
                    while (i < 4)
                    {
                        if ((i == 0) || (i == 3))
                        {
                            dist = (float)xref;
                        }
                        else
                        {
                            dist = (float)((xref == 0) ? 1 : 0);
                        }

                        w.wall.st[i].x = ((dist * 8.0f * wal.xrepeat) + curxpanning) / (float)(Engine.tilesizx[curpicnum]);
                        w.wall.st[i].y = (-(float)(yref + (w.wall.xyz[i].y * 16)) / ((Engine.tilesizy[curpicnum] * 2048.0f) / (float)(wal.yrepeat))) + ypancoef;

                        if ((0 == (wal.cstat & 2) && (wal.cstat & 256) != 0) || ((wal.cstat & 2) != 0 && 0 != (board.wall[nwallnum].cstat & 256)))
                        {
                            w.wall.st[i].y = -w.wall.st[i].y;
                        }

                        i++;
                    }

                    if (underwall != 0)
                    {
                        w.underover |= 1;
                    }

                    w.mask.xyz[0] = w.wall.xyz[3];
                    w.mask.st[0] = w.wall.st[3];

                    w.mask.xyz[1] = w.wall.xyz[2];
                    w.mask.st[1] = w.wall.st[2];
                }
                else
                {
                    w.mask.xyz[0] = s.floor.xyz[wallnum - sec.wallptr];
                    w.mask.st[0] = s.floor.st[wallnum - sec.wallptr];

                    w.mask.xyz[1] = s.floor.xyz[wal.point2 - sec.wallptr];
                    w.mask.st[1] = s.floor.st[wal.point2 - sec.wallptr];


                    //Bmemcpy(w.mask.buffer, s.floor.buffer[wallnum - sec.wallptr], sizeof(GLfloat) * 5);
                    //Bmemcpy(w.mask.buffer[1], s.floor.buffer[wal.point2 - sec.wallptr], sizeof(GLfloat) * 5);
                }

                if ((s.ceil.xyz[wallnum - sec.wallptr].y > ns.ceil.xyz[nnwallnum - nsec.wallptr].y) || (s.ceil.xyz[wal.point2 - sec.wallptr].y > ns.ceil.xyz[nwallnum - nsec.wallptr].y))
                {
                    overwall = (char)1;
                }

                if ((overwall != 0) || (wal.cstat & 48) != 0)
                {
                    if (w.over.xyz == null)
                    {
                        w.over.Init(4);
                    }

                    w.over.xyz[0] = ns.ceil.xyz[nnwallnum - nsec.wallptr]; // Bmemcpy(w.over.buffer, ns.ceil.buffer[nnwallnum - nsec.wallptr], sizeof(GLfloat) * 3);
                    w.over.xyz[1] = ns.ceil.xyz[nwallnum - nsec.wallptr]; // Bmemcpy(w.over.buffer[1], ns.ceil.buffer[nwallnum - nsec.wallptr], sizeof(GLfloat) * 3);


                    if (s.ceil.xyz[wal.point2 - sec.wallptr].y > ns.ceil.xyz[nwallnum - nsec.wallptr].y)
                    {
                        w.over.xyz[2] = s.ceil.xyz[wal.point2 - sec.wallptr];
                    }
                    else
                    {
                        w.over.xyz[2] = ns.ceil.xyz[nwallnum - nsec.wallptr];
                    }
                    w.over.xyz[3] = s.ceil.xyz[wallnum - sec.wallptr]; //                     Bmemcpy(w.over.buffer[3], s.ceil.buffer[wallnum - sec.wallptr], sizeof(GLfloat) * 3);

                    if ((wal.cstat & 16) != 0 || (wal.overpicnum == 0))
                    {
                        curpicnum = wallpicnum;
                    }
                    else
                    {
                        curpicnum = wallpicnum;
                    }

                    //w.over.bucket = polymer_getbuildmaterial(w.over.material, curpicnum, wal.pal, wal.shade, sec.visibility, DAMETH_WALL);
                    //
                    //if ((wal.cstat & 48) != 0)
                    //{
                    //    // mask
                    //    w.mask.bucket = polymer_getbuildmaterial(w.mask.material, walloverpicnum, wal.pal, wal.shade, sec.visibility, DAMETH_WALL | ((wal.cstat & 48) == 48 ? DAMETH_NOMASK : DAMETH_MASK));
                    //
                    //    if ((wal.cstat & 128) != 0)
                    //    {
                    //        if ((wal.cstat & 512) != 0)
                    //        {
                    //            w.mask.material.diffusemodulation[3] = 0x55;
                    //        }
                    //        else
                    //        {
                    //            w.mask.material.diffusemodulation[3] = 0xAA;
                    //        }
                    //    }
                    //}

                    if ((wal.cstat & 4) != 0)
                    {
                        yref = sec.ceilingz;
                    }
                    else
                    {
                        yref = nsec.ceilingz;
                    }

                    //if (wal.ypanning)
                    //{
                    //    // over
                    //    ypancoef = calc_ypancoef(wal.ypanning, curpicnum, wal.cstat & 4);
                    //}
                    //else
                    {
                        ypancoef = 0F;
                    }

                    i = 0;
                    while (i < 4)
                    {
                        if ((i == 0) || (i == 3))
                        {
                            dist = (float)xref;
                        }
                        else
                        {
                            dist = (float)((xref == 0) ? 1 : 0);
                        }

                        w.over.st[i].x = ((dist * 8.0f * wal.xrepeat) + wal.xpanning) / (float)(Engine.tilesizx[curpicnum]);
                        w.over.st[i].y = (-(float)(yref + (w.over.xyz[i].y * 16)) / ((Engine.tilesizy[curpicnum] * 2048.0f) / (float)(wal.yrepeat))) + ypancoef;

                        if ((wal.cstat & 256) != 0)
                        {
                            w.over.st[i].y = -w.over.st[i].y;
                        }

                        i++;
                    }

                    if (overwall != 0)
                    {
                        w.underover |= 2;
                    }

                    w.mask.xyz[2] = w.over.xyz[1]; //Bmemcpy(w.mask.buffer[2], w.over.buffer[1], sizeof(GLfloat) * 5);
                    w.mask.st[2] = w.over.st[1];

                    w.mask.xyz[3] = w.over.xyz[0]; //Bmemcpy(w.mask.buffer[3], w.over.buffer[0], sizeof(GLfloat) * 5);
                    w.mask.st[3] = w.over.st[0];

                    if ((wal.cstat & 16) != 0 || (wal.cstat & 32) != 0)
                    {
                        int botSwap = (wal.cstat & 4);

                        if ((wal.cstat & 32) != 0)
                        {
                            // 1-sided wall
                            if (nsec != null)
                            {
                                yref = botSwap != 0 ? sec.ceilingz : nsec.ceilingz;
                            }
                            else
                            {
                                yref = botSwap != 0 ? sec.floorz : sec.ceilingz;
                            }
                        }
                        else
                        {
                            // masked wall
                            if (botSwap != 0)
                            {
                                yref = Math.Min(sec.floorz, nsec.floorz);
                            }
                            else
                            {
                                yref = Math.Max(sec.ceilingz, nsec.ceilingz);
                            }
                        }

                        curpicnum = walloverpicnum;

                        //if (wal.ypanning)
                        //{
                        //    // mask / 1-way
                        //    ypancoef = calc_ypancoef(wal.ypanning, curpicnum, 0);
                        //}
                        //else
                        {
                            ypancoef = 0F;
                        }

                        i = 0;
                        while (i < 4)
                        {
                            if ((i == 0) || (i == 3))
                            {
                                dist = (float)xref;
                            }
                            else
                            {
                                dist = (float)((xref == 0) ? 1 : 0);
                            }

                            w.mask.st[i].x = ((dist * 8.0f * wal.xrepeat) + wal.xpanning) / (float)(Engine.tilesizx[curpicnum]);
                            w.mask.st[i].y = (-(float)(yref + (w.mask.xyz[i].y * 16)) / ((Engine.tilesizy[curpicnum] * 2048.0f) / (float)(wal.yrepeat))) + ypancoef;

                            if ((wal.cstat & 256) != 0)
                            {
                                w.mask.st[i].y = -w.mask.st[i].y;
                            }

                            i++;
                        }
                    }
                }
                else
                {
                    w.mask.xyz[2] = s.ceil.xyz[wal.point2 - sec.wallptr]; // Bmemcpy(w.mask.buffer[2], s.ceil.buffer[wal.point2 - sec.wallptr], sizeof(GLfloat) * 5);
                    w.mask.xyz[3] = s.ceil.xyz[wallnum - sec.wallptr]; //Bmemcpy(w.mask.buffer[3], s.ceil.buffer[wallnum - sec.wallptr], sizeof(GLfloat) * 5);
                }
            }

            // make sure shade color handling is correct below XXX
            if (wal.nextsector < 0)
            {
                for(int d = 0; d < 4; d++)
                {
                    w.mask.xyz[d] = w.wall.xyz[d];
                    w.mask.st[d] = w.wall.st[d]; // jmarshall: is this right?
                }
            }
        }

        private void InitSector(int sectnum)
        {
            sector3D[sectnum].verts = new float[board.sector[sectnum].wallnum * 3];
            sector3D[sectnum].floor.Init(board.sector[sectnum].wallnum * 5);
            sector3D[sectnum].ceil.Init(board.sector[sectnum].wallnum * 5);
        }

        private void buildfloor(short sectnum)
        {
            int i;
            Sector3D s;
            sectortype sec;

            sec = board.sector[sectnum];
            s = sector3D[sectnum];

            if(s.floor.indexes == null)
            {
                s.indicescount = (Mathf.Max(3, sec.wallnum) - 2) * 3;
                s.floor.indexes = new int[s.indicescount];
                s.ceil.indexes = new int[s.indicescount];
            }

            LibTessDotNet.Tess tess = new Tess();

            int numPoints = s.verts.Length / 3;
            var contour = new LibTessDotNet.ContourVertex[numPoints];

            i = 0;
            while (i < sec.wallnum)
            {
                contour[i].Position = new LibTessDotNet.Vec3(s.verts[(i * 3) + 0], s.verts[(i * 3) + 2], 0);

                i++;
            }

            tess.AddContour(contour, LibTessDotNet.ContourOrientation.Clockwise);
            tess.Tessellate(LibTessDotNet.WindingRule.Positive, LibTessDotNet.ElementType.Polygons, 3);

            s.ceil.indexes = tess.Elements;
            s.floor.indexes = new int[s.ceil.indexes.Length];

            i = 0;
            while (i < s.indicescount)
            {
                s.floor.indexes[s.indicescount - i - 1] = s.ceil.indexes[i];

                i++;
            }
        }

        private int UpdateSector(short sectnum)
        {
            Sector3D s;
            sectortype sec;
            walltype wal;
            int i;
            int j;
            int ceilz = 0;
            int florz = 0;
            int tex;
            int tey;
            int heidiff;
            float secangcos;
            float secangsin;
            float scalecoef;
            float xpancoef;
            float ypancoef;
            int ang;
            int needfloor;
            int wallinvalidate;
            short curstat;
            short curpicnum;
            short floorpicnum;
            short ceilingpicnum;
            byte curxpanning;
            byte curypanning;
            Plane3D curbuffer;

            s = sector3D[sectnum];
            sec = board.sector[sectnum];

            secangcos = secangsin = 2F;

            if (s == null)
            {
                return (-1);
            }

            needfloor = wallinvalidate = 0;

            // geometry
            i = 0;
            while (i < sec.wallnum)
            {
                wal = board.wall[sec.wallptr + i];
                if ((-wal.x != s.verts[(i * 3) + 2]))
                {
                    s.verts[(i * 3) + 2] = s.floor.xyz[i].z = s.ceil.xyz[i].z = -(float)wal.x;
                    needfloor = wallinvalidate = 1;
                }
                if ((wal.y != s.verts[i * 3]))
                {
                    s.verts[i * 3] = s.floor.xyz[i].x = s.ceil.xyz[i].x = (float)wal.y;
                    needfloor = wallinvalidate = 1;
                }

                i++;
            }

            if (/*(s.controlstate == 2) ||*/ (sec.floorz != s.floorz) || (sec.ceilingz != s.ceilingz) || (sec.floorheinum != s.floorheinum) || (sec.ceilingheinum != s.ceilingheinum))
            {
                wallinvalidate = 1;

                i = 0;
                while (i < sec.wallnum)
                {
                    wal = board.wall[sec.wallptr + i];

                    Engine.board.getzsofslope(sectnum, wal.x, wal.y, ref ceilz, ref florz);
                    s.floor.xyz[i].y = -(float)(florz) / 16.0f;
                    s.ceil.xyz[i].y = -(float)(ceilz) / 16.0f;

                    i++;                    
                }

                s.floorz = sec.floorz;
                s.ceilingz = sec.ceilingz;
                s.floorheinum = sec.floorheinum;
                s.ceilingheinum = sec.ceilingheinum;
            }

            floorpicnum = sec.floorpicnum;
            if ((Engine.picanm[floorpicnum] & 192) != 0)
            {
                floorpicnum += (short)Engine.animateoffs(floorpicnum, sectnum);
            }
            ceilingpicnum = sec.ceilingpicnum;
            if ((Engine.picanm[ceilingpicnum] & 192) != 0)
            {
                ceilingpicnum += (short)Engine.animateoffs(ceilingpicnum, sectnum);
            }

            //if ((s.controlstate != 2) && (needfloor == 0) && (sec.floorstat == s.floorstat) && (sec.ceilingstat == s.ceilingstat) && (floorpicnum == s.floorpicnum) && (ceilingpicnum == s.ceilingpicnum) && (sec.floorxpanning == s.floorxpanning) && (sec.ceilingxpanning == s.ceilingxpanning) && (sec.floorypanning == s.floorypanning) && (sec.ceilingypanning == s.ceilingypanning))
            //{
            //    goto attributes;
            //}

            wal = Engine.board.wall[sec.wallptr];
            i = 0;
            while (i < sec.wallnum)
            {
                j = 2;
                curstat = sec.floorstat;
                curbuffer = s.floor;
                curpicnum = floorpicnum;
                curxpanning = sec.floorxpanning;
                curypanning = sec.floorypanning;

                while (j != 0)
                {
                    if (j == 1)
                    {
                        curstat = sec.ceilingstat;
                        curbuffer = s.ceil;
                        curpicnum = ceilingpicnum;
                        curxpanning = sec.ceilingxpanning;
                        curypanning = sec.ceilingypanning;
                    }

                   // if (!waloff[curpicnum])
                   // {
                   //     loadtile(curpicnum);
                   // }

                    // relative texturing
                    if ((curstat & 64) != 0)
                    {
                        xpancoef = (float)(wal.x - board.wall[sec.wallptr].x);
                        ypancoef = (float)(board.wall[sec.wallptr].y - wal.y);

                        tex = (int)(xpancoef * secangsin + ypancoef * secangcos);
                        tey = (int)(xpancoef * secangcos - ypancoef * secangsin);
                    }
                    else
                    {
                        tex = wal.x;
                        tey = -wal.y;
                    }

                    if ((curstat & (2 + 64)) == (2 + 64))
                    {
                        heidiff = (int)(curbuffer.st[i].y - curbuffer.st[0].y);
                        tey = (int)Mathf.Sqrt((tey * tey) + (heidiff * heidiff));
                    }

                    if ((curstat & 4) != 0)
                    {
                        pragmas.swaplong(ref tex, ref tey);
                    }

                    if ((curstat & 16) != 0)
                    {
                        tex = -tex;
                    }
                    if ((curstat & 32) != 0)
                    {
                        tey = -tey;
                    }

                    scalecoef = (curstat & 8) != 0 ? 8.0f : 16.0f;

                    if (curxpanning != 0)
                    {
                        xpancoef = (float)(Engine.pow2long[Engine.picsiz[curpicnum] & 15]);
                        xpancoef *= (float)(curxpanning) / (256.0f * (float)(Engine.tilesizx[curpicnum]));
                    }
                    else
                    {
                        xpancoef = 0F;
                    }

                    if (curypanning != 0)
                    {
                        ypancoef = (float)(Engine.pow2long[Engine.picsiz[curpicnum] >> 4]);
                        ypancoef *= (float)(curypanning) / (256.0f * (float)(Engine.tilesizy[curpicnum]));
                    }
                    else
                    {
                        ypancoef = 0F;
                    }

                    curbuffer.st[i].x = ((float)(tex) / (scalecoef * Engine.tilesizx[curpicnum])) + xpancoef;
                    curbuffer.st[i].y = ((float)(tey) / (scalecoef * Engine.tilesizy[curpicnum])) + ypancoef;

                    j--;
                }
                i++;
                wal = Engine.board.wall[sec.wallptr + i];
            }

            s.floorstat = sec.floorstat;
            s.ceilingstat = sec.ceilingstat;
            s.floorxpanning = sec.floorxpanning;
            s.ceilingxpanning = sec.ceilingxpanning;
            s.floorypanning = sec.floorypanning;
            s.ceilingypanning = sec.ceilingypanning;

            i = -1;

           // attributes:
           // if ((pr_vbos > 0) && ((i == -1) || (wallinvalidate) != 0))
           // {
           //     bglBindBufferARB(GL_ARRAY_BUFFER_ARB, s.floor.vbo);
           //     bglBufferSubDataARB(GL_ARRAY_BUFFER_ARB, 0, sec.wallnum * sizeof(GLfloat) * 5, s.floor.buffer);
           //     bglBindBufferARB(GL_ARRAY_BUFFER_ARB, s.ceil.vbo);
           //     bglBufferSubDataARB(GL_ARRAY_BUFFER_ARB, 0, sec.wallnum * sizeof(GLfloat) * 5, s.ceil.buffer);
           //     bglBindBufferARB(GL_ARRAY_BUFFER_ARB, 0);
           // }
           //
           // if ((s.controlstate != 2) && (sec.floorshade == s.floorshade) && (sec.floorpal == s.floorpal) && (floorpicnum == s.floorpicnum) && (ceilingpicnum == s.ceilingpicnum))
           // {
           //     goto finish;
           // }
           //
           // polymer_getbuildmaterial(s.floor.material, floorpicnum, sec.floorpal, sec.floorshade);
           // polymer_getbuildmaterial(s.ceil.material, ceilingpicnum, sec.ceilingpal, sec.ceilingshade);

            s.floorshade = sec.floorshade;
            s.floorpal = sec.floorpal;
            s.floorpicnum = floorpicnum;
            s.ceilingpicnum = ceilingpicnum;

            if (needfloor != 0)
            {
                buildfloor(sectnum);
            }

            //finish:
            //
            //if (needfloor != 0)
            //{
            //    polymer_buildfloor(sectnum);
            //    if ((pr_vbos > 0))
            //    {
            //        if (s.oldindicescount < s.indicescount)
            //        {
            //            bglBindBufferARB(GL_ELEMENT_ARRAY_BUFFER_ARB, s.floor.ivbo);
            //            bglBufferDataARB(GL_ELEMENT_ARRAY_BUFFER_ARB, s.indicescount * sizeof(GLushort), null, mapvbousage);
            //            bglBindBufferARB(GL_ELEMENT_ARRAY_BUFFER_ARB, s.ceil.ivbo);
            //            bglBufferDataARB(GL_ELEMENT_ARRAY_BUFFER_ARB, s.indicescount * sizeof(GLushort), null, mapvbousage);
            //            s.oldindicescount = s.indicescount;
            //        }
            //        bglBindBufferARB(GL_ELEMENT_ARRAY_BUFFER_ARB, s.floor.ivbo);
            //        bglBufferSubDataARB(GL_ELEMENT_ARRAY_BUFFER_ARB, 0, s.indicescount * sizeof(GLushort), s.floor.indices);
            //        bglBindBufferARB(GL_ELEMENT_ARRAY_BUFFER_ARB, s.ceil.ivbo);
            //        bglBufferSubDataARB(GL_ELEMENT_ARRAY_BUFFER_ARB, 0, s.indicescount * sizeof(GLushort), s.ceil.indices);
            //        bglBindBufferARB(GL_ELEMENT_ARRAY_BUFFER_ARB, 0);
            //    }
            //}
            //
            //if (wallinvalidate != 0)
            //{
            //    s.invalidid++;
            //    polymer_buffertoplane(s.floor.buffer, s.floor.indices, s.indicescount, s.floor.plane);
            //    polymer_buffertoplane(s.ceil.buffer, s.ceil.indices, s.indicescount, s.ceil.plane);
            //}
            //
            //s.controlstate = 1;
            //
            //if (pr_verbosity >= 3)
            //{
            //    OSD_Printf("PR : Updated sector %i.\n", sectnum);
            //}

            return (0);
        }
    }
}