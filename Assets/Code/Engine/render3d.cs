using System;
using System.Collections.Generic;
using UnityEngine;
using LibTessDotNet;

namespace Build
{
    public class Render3D
    {
        public List<Plane3D> planes = new List<Plane3D>();

        private static GameObject[] spriteGameObjects;

        public static void InitOnce()
        {
            if (spriteGameObjects != null)
                return;

            spriteGameObjects = new GameObject[bMap.MAXSPRITESONSCREEN];
            for(int i = 0; i < bMap.MAXSPRITESONSCREEN; i++)
            {
                spriteGameObjects[i] = new GameObject("tsprite " + i);
            }

            foreach(GameObject obj in spriteGameObjects)
            {
                MeshFilter mf = obj.AddComponent<MeshFilter>();
                UnityEngine.Mesh mesh = new UnityEngine.Mesh();
                mesh.vertices = new Vector3[] { new Vector3(-0.5f, 0.0f, 0.0f), new Vector3(0.5f, 0.0f, 0.0f), new Vector3(0.5f, 1.0f, 0.0f), new Vector3(-0.5f, 1.0f, 0.0f) };
                mesh.uv = new Vector2[] { new Vector2(0.0f, 1.0f), new Vector2(1.0f, 1.0f), new Vector2(1.0f, 0.0f), new Vector2(0.0f, 0.0f) };
                mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };                
                
                mf.mesh = mesh;

                MeshRenderer renderer = obj.AddComponent<MeshRenderer>();
                Material mat = new Material(Shader.Find("Unlit/Polymer"));                
                mat.SetTexture("_PaletteTex", Engine.palette.paletteTexture);
                mat.SetTexture("_LookupTex", Engine.palette.palookupTexture);

                //mat.SetTexture("_MainTex", texture);
                //mat.SetVector("_MaterialParams", new Vector4(visibility, shadeOffset, palette, curbasepa));

                renderer.material = mat;

                obj.SetActive(false);
            }
        }

        public class Plane3D
        {
            public Vector3[] xyz;
            public Vector2[] st;
            public int[] indexes;
            public GameObject planeGameObject;
            public Texture2D texture;
            private UnityEngine.Mesh mesh;
            private Render3D parent;
            private Material mat;
            private Vector4 _parms;
            public Plane3D(Render3D parent)
            {
                this.parent = parent;
                parent.planes.Add(this);
            }

            public void Destroy()
            {
                GameObject.Destroy(planeGameObject);
            }

            public void Hide()
            {
                if (!planeGameObject)
                    return;

                planeGameObject.SetActive(false);
            }

            public void Show()
            {
                if (!planeGameObject)
                    return;

                if (indexes == null)
                    return;

                planeGameObject.SetActive(true);
            }

            public void Init(int vertexcount)
            {
                xyz = new Vector3[vertexcount];
                st = new Vector2[vertexcount];                
            }

            public void InitTexture(int tileNum)
            {
                if (Engine.waloff[tileNum] == null)
                {
                    Engine.loadtile((short)tileNum);
                }

                if (Engine.waloff[tileNum] == null)
                    return;

                texture = Engine.waloff[tileNum].texture;
            }

            public void Update(float visibility, float shadeOffset, float palette, float curbasepal)
            {
                if (mesh == null)
                    return;

                mesh.uv = st;
                mesh.vertices = xyz;
                mesh.RecalculateBounds();

                Vector4 newParms = new Vector4(visibility / 30.0f, shadeOffset, palette, curbasepal);
                if (_parms == newParms)
                    return;

                _parms = newParms;


                mat.SetVector("_MaterialParams", new Vector4(visibility, shadeOffset, palette, curbasepal));
            }

            public void UpdateMaterial(float visibility, float shadeOffset, float palette, float curbasepal)
            {
                if (mat == null || mesh == null)
                    return;

                Vector4 newParms = new Vector4(visibility / 30.0f, shadeOffset, palette, curbasepal);
                if (_parms == newParms)
                    return;

                _parms = newParms;

                mat.SetVector("_MaterialParams", newParms);
            }

            public void Build(float visibility, float shadeOffset, float palette, float curbasepa)
            {
                if (indexes == null)
                    return;

                planeGameObject = new GameObject();

                MeshFilter mf = planeGameObject.AddComponent<MeshFilter>();
                mesh = new UnityEngine.Mesh();
                mesh.vertices = xyz;
                mesh.uv = st;
                mesh.triangles = indexes;
                mesh.RecalculateBounds();

                mf.mesh = mesh;
                
                MeshRenderer renderer = planeGameObject.AddComponent<MeshRenderer>();

                // Each plane needs its own material.
                mat = new Material(Shader.Find("Unlit/Polymer"));
                mat.SetTexture("_MainTex", texture);
                mat.SetTexture("_PaletteTex", Engine.palette.paletteTexture);
                mat.SetTexture("_LookupTex", Engine.palette.palookupTexture);
                mat.SetVector("_MaterialParams", new Vector4(visibility, shadeOffset, palette, curbasepa));

                renderer.material = mat;

                planeGameObject.transform.localScale = new Vector3(-(1.0f / 1000.0f), 1.0f / 1000.0f, 1.0f / 1000.0f);
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

            public int indicescount;

            public Plane3D floor;
            public Plane3D ceil;
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


            public Plane3D wall;
            public Plane3D over;
            public Plane3D mask;
        }

        private bMap board;
        private Sector3D[] sector3D;
        private Wall3D[] wall3D;

        public void FreeBoard()
        {
            foreach (Plane3D p in planes)
            {
                p.Destroy();
            }
            planes.Clear();
        }

        public void LoadBoard(bMap board)
        {
            this.board = board;

            sector3D = new Sector3D[board.numsectors];

            for(int i = 0; i < board.numsectors; i++)
            {
                sectortype s = board.sector[i];

                InitSector(i);
                UpdateSector((short)i);

                sector3D[i].floor.Build(s.visibility, s.floorshade, s.floorpal, 0);
                sector3D[i].ceil.Build(s.visibility, s.ceilingshade, s.floorpal, 0);
            }

            wall3D = new Wall3D[board.numwalls];
            for (int i = 0; i < board.numwalls; i++)
            {
                int sectofwall = board.sectorofwall((short)i);
                sectortype s = board.sector[sectofwall];

                wall3D[i] = new Wall3D();
                wall3D[i].wall = new Plane3D(this);
                wall3D[i].over = new Plane3D(this);
                wall3D[i].mask = new Plane3D(this);


                wall3D[i].wall.Init(4);
                wall3D[i].over.Init(4);
                wall3D[i].mask.Init(4);
                UpdateWall((short)i);
                wall3D[i].wall.Build(s.visibility, board.wall[i].shade, board.wall[i].pal, 0);
                wall3D[i].over.Build(s.visibility, board.wall[i].shade, board.wall[i].pal, 0);
                wall3D[i].mask.Build(s.visibility, board.wall[i].shade, board.wall[i].pal, 0);
            }
        }

        private void DO_TILE_ANIM(ref short Picnum, int fakevar)
        {
            Picnum += (short)Engine.animateoffs(Picnum, (short)fakevar);
        }

        private void UpdateWall(short wallnum, bool force = false)
        {
			short nwallnum;
            short nnwallnum;
            short curpicnum;
            short wallpicnum;
            short walloverpicnum;
            short nwallpicnum;
            char curxpanning;
            char curypanning;
            byte underwall;
            byte overwall;
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


            sectortype neighborsector = null;

            if (wal.nextsector >= 0)
            {
                neighborsector = board.sector[wal.nextsector];
            }

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

           // if ((wallpicnum == w.picnum_anim) && (walloverpicnum == w.overpicnum_anim) && ((nwallnum < 0 || nwallnum > board.numwalls) || ((nwallpicnum == w.nwallpicnum) && (board.wall[nwallnum].xpanning == w.nwallxpanning) && (board.wall[nwallnum].ypanning == w.nwallypanning) && (board.wall[nwallnum].cstat == w.nwallcstat) && (board.wall[nwallnum].shade == w.nwallshade))))
           // {
           //     //w.flags.uptodate = 1;
           //     return; // screw you guys I'm going home
           // }
           // else
            if(wal.changed == false /*&& (wallpicnum == w.picnum_anim) && (walloverpicnum == w.overpicnum_anim) && ((nwallnum < 0 || nwallnum > board.numwalls) || ((nwallpicnum == w.nwallpicnum) && (board.wall[nwallnum].xpanning == w.nwallxpanning) && (board.wall[nwallnum].ypanning == w.nwallypanning) && (board.wall[nwallnum].cstat == w.nwallcstat) && (board.wall[nwallnum].shade == w.nwallshade)))*/)
            {
                if (!force)
                {
                    w.wall.UpdateMaterial(sec.visibility, wal.shade, wal.pal, 0);
                    w.over.UpdateMaterial(sec.visibility, wal.shade, wal.pal, 0);
                    w.mask.UpdateMaterial(sec.visibility, wal.shade, wal.pal, 0);
                    return;
                }
            }
            wal.changed = false;
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

            w.underover = underwall = overwall = 0;

            if ((wal.cstat & 8) != 0)
            {
                xref = 1;
            }
            else
            {
                xref = 0;
            }

            bool parralaxFloor = (neighborsector != null && sec.IsFloorParalaxed() && neighborsector.IsFloorParalaxed());

            if (((uint)wal.nextsector >= (uint)board.numsectors || ns == null) && !parralaxFloor)
            {
                w.wall.xyz[0] = s.floor.xyz[wallnum - sec.wallptr];
                w.wall.xyz[1] = s.floor.xyz[wal.point2 - sec.wallptr];
                w.wall.xyz[2] = s.ceil.xyz[wal.point2 - sec.wallptr];
                w.wall.xyz[3] = s.ceil.xyz[wallnum - sec.wallptr];

                w.wall.indexes = new int[] { 0, 1, 2, 0, 2, 3 };

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


                w.wall.InitTexture(curpicnum);
                w.wall.indexes = new int[] { 0, 1, 2, 0, 2, 3 };
                w.wall.Update(sec.visibility, wal.shade, wal.pal, 0);

                w.underover |= 1;
            }
            else if(!parralaxFloor)
            {
                nnwallnum = board.wall[nwallnum].point2;

                // jmarshall: I didn't use this check in PolymerNG, needs evaluatioN!
                // if ((s.floor.xyz[wallnum - sec.wallptr].y < ns.floor.xyz[nnwallnum - nsec.wallptr].y) ||
                //     (s.floor.xyz[wal.point2 - sec.wallptr].y < ns.floor.xyz[nwallnum - nsec.wallptr].y))
                {
                    underwall = 1;
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

                    w.wall.InitTexture(curpicnum);
                    w.wall.indexes = new int[] { 0, 1, 2, 0, 2, 3 };
                    w.wall.Update(sec.visibility, wal.shade, wal.pal, 0);

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

               //     w.mask.indexes = new int[] { 0, 1, 2, 0, 2, 3 };

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
                  //  w.mask.indexes = new int[] { 0, 1, 2, 0, 2, 3 };

                    //Bmemcpy(w.mask.buffer, s.floor.buffer[wallnum - sec.wallptr], sizeof(GLfloat) * 5);
                    //Bmemcpy(w.mask.buffer[1], s.floor.buffer[wal.point2 - sec.wallptr], sizeof(GLfloat) * 5);
                }

                if ((s.ceil.xyz[wallnum - sec.wallptr].y > ns.ceil.xyz[nnwallnum - nsec.wallptr].y) || (s.ceil.xyz[wal.point2 - sec.wallptr].y > ns.ceil.xyz[nwallnum - nsec.wallptr].y))
                {
                    overwall = 1;
                }

                bool parralaxCeiling = (neighborsector != null && neighborsector.IsCeilParalaxed() && neighborsector.IsCeilParalaxed());
                if (((overwall != 0) || (wal.cstat & 48) != 0) && !parralaxCeiling)
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

                    if ((wal.cstat & 48) != 0)
                    {
                        w.mask.indexes = new int[] { 0, 1, 2, 0, 2, 3 };
                        w.mask.InitTexture(wal.overpicnum);
                        w.mask.Update(sec.visibility, wal.shade, wal.pal, 0);
                    }

                    w.over.indexes = new int[] { 0, 1, 2, 0, 2, 3 };
                    w.over.InitTexture(curpicnum);
                    w.over.Update(sec.visibility, wal.shade, wal.pal, 0);

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
            sector3D[sectnum] = new Sector3D();
            sector3D[sectnum].floor = new Plane3D(this);
            sector3D[sectnum].floor.Init(board.sector[sectnum].wallnum * 5);

            sector3D[sectnum].ceil = new Plane3D(this);
            sector3D[sectnum].ceil.Init(board.sector[sectnum].wallnum * 5);
        }

        private void buildfloor(short sectnum)
        {
            int i;
            Sector3D s;
            sectortype sec;

            sec = board.sector[sectnum];
            s = sector3D[sectnum];

           // if(s.floor.indexes == null)
           // {
           //     s.indicescount = (Mathf.Max(3, sec.wallnum) - 2) * 3;
           //     s.floor.indexes = new int[s.indicescount];
           //     s.ceil.indexes = new int[s.indicescount];
           // }

            LibTessDotNet.Tess tess = new Tess();
            List<LibTessDotNet.ContourVertex> contour = new List<ContourVertex>();

            i = 0;
            while (i < sec.wallnum)
            {
                LibTessDotNet.ContourVertex c = new ContourVertex();
                c.Position = new LibTessDotNet.Vec3();
                c.Position.X = s.floor.xyz[i].x;
                c.Position.Y = s.floor.xyz[i].z;
                contour.Add(c);

                if ((i != (sec.wallnum - 1)) && ((sec.wallptr + i) > board.wall[sec.wallptr + i].point2))
                {
                    tess.AddContour(contour.ToArray(), LibTessDotNet.ContourOrientation.Clockwise);
                    contour = new List<ContourVertex>();
                }

                i++;
            }

            tess.AddContour(contour.ToArray(), LibTessDotNet.ContourOrientation.Clockwise);
            tess.Tessellate(LibTessDotNet.WindingRule.EvenOdd, LibTessDotNet.ElementType.Polygons, 3);

            s.indicescount = tess.Elements.Length;

            if (!sec.IsCeilParalaxed())
            {
                s.ceil.indexes = new int[tess.Elements.Length];
            }

            if (!sec.IsFloorParalaxed())
            {
                s.floor.indexes = new int[tess.Elements.Length];
            }

            //for(int f = 0; f < tess.Vertices.Length; f++)
            //{
            //    s.floor.xyz[f].x = tess.Vertices[f].Position.X;
            //    s.floor.xyz[f].z = tess.Vertices[f].Position.Y;
            //    s.ceil.xyz[f].x = tess.Vertices[f].Position.X;
            //    s.ceil.xyz[f].z = tess.Vertices[f].Position.Y;
            //}
            // Vertex order changes, so we need to remap the new indexes to the old vertex layout.

            int[] _remap = new int[tess.Vertices.Length];
            for(int x = 0; x < tess.Vertices.Length; x++)
            {
                bool found = false;
                for (int y = 0; y <= s.floor.xyz.Length; y++)
                {                    
                    if(tess.Vertices[x].Position.X == s.floor.xyz[y].x && tess.Vertices[x].Position.Y == s.floor.xyz[y].z)
                    {
                        _remap[x] = y;
                        found = true;
                        break;
                    }                    
                }
                if (!found)
                    Debug.LogError("Tesselation had new random vertexes?");
            }


            i = 0;
            while (i < s.indicescount)
            {
                if (!sec.IsCeilParalaxed())
                {
                    s.ceil.indexes[i] = _remap[tess.Elements[i]];
                }

                if (!sec.IsFloorParalaxed())
                {
                    s.floor.indexes[s.indicescount - i - 1] = _remap[tess.Elements[i]];
                }

                i++;
            }
        }

        private void PokeSector(short sectnum)
        {
            sectortype sec = board.sector[sectnum];
            Sector3D s = sector3D[sectnum];
            walltype wal = board.wall[sec.wallptr];
            int i = 0;

            bool forceUpdate = sec.changed || sec.neighborChanged;
            bool neighborChanged = sec.neighborChanged;

            //if (!s->flags.uptodate)
            UpdateSector(sectnum);

            do
            {
                //if ((wal->nextsector >= 0) && (!prsectors[wal->nextsector]->flags.uptodate))
                if (wal.nextsector >= 0 && forceUpdate && !neighborChanged)
                    board.sector[wal.nextsector].neighborChanged = true;
                //    UpdateSector(wal.nextsector);
                //if (!prwalls[sec->wallptr + i]->flags.uptodate)
                    
                UpdateWall((short)(sec.wallptr + i), forceUpdate);

                i++;
                wal = board.wall[sec.wallptr + i];
            } while (i < sec.wallnum);
        }

        short[] sectorqueue = new short[bMap.MAXSECTORS];

        private void DisplaySectors(short dacursectnum)
        {
            int front = 0;
            int back = 1;
            int i;
            short[] drawingstate = new short[board.numsectors];
            Sector3D s;

            // Hide all the planes.
            foreach (Plane3D p in planes)
            {
                p.Hide();
            }

            sectortype sec;

            sectorqueue[0] = dacursectnum;
            drawingstate[dacursectnum] = 1;

            while (front != back)
            {
                sec = board.sector[sectorqueue[front]];
                s = sector3D[sectorqueue[front]];

                // Update the sector.                
                PokeSector(sectorqueue[front]);

                // Show the floor and ceiling.
                s.floor.Show();
                s.ceil.Show();

                i = sec.wallnum - 1;
                do
                {
                    if (board.wallvisible(board.globalposx, board.globalposy, sec.wallptr + i))
                    {
                        if (wall3D[sec.wallptr + i].wall != null)
                            wall3D[sec.wallptr + i].wall.Show();

                        if (wall3D[sec.wallptr + i].mask != null)
                            wall3D[sec.wallptr + i].mask.Show();

                        if (wall3D[sec.wallptr + i].over != null)
                            wall3D[sec.wallptr + i].over.Show();
                    }
                }
                while (--i >= 0);


                i = sec.wallnum - 1;
                do
                {
                    if (sec.wallptr + i >= board.wall.Length)
                        break;

                    if (board.wall[sec.wallptr + i].nextsector == -1)
                        continue;

                    if (drawingstate[board.wall[sec.wallptr + i].nextsector] == 0)
                    {
                        sectorqueue[back++] = board.wall[sec.wallptr + i].nextsector;
                        drawingstate[board.wall[sec.wallptr + i].nextsector] = 1;
                    }
                } while (--i >= 0);

                front++;
            }
        }

        public void DisplayRoom(short dacursectnum)
        {
            float M_1_PI = 0.318309886183790671538f;
            float horizang = -(float)Mathf.Atan2(pragmas.fix16_to_float(board.globalhoriz) - 100.0f, 128.0f) * (180.0f * (float)M_1_PI);

            // for (int i = 0; i < board.numsectors; i++)
            // {
            //     PokeSector((short)i);
            // }
            DisplaySectors(dacursectnum);

            foreach (GameObject obj in spriteGameObjects)
            {
                obj.SetActive(false);
            }

            for (int i = 0; i < board.framesortcnt; i++)
            {
                spritetype2 tsprite = board.tsprite[i];
                GameObject spriteObject = spriteGameObjects[i];
                float _ang = 0;

                const int SPR_ALIGN_MASK = 32 + 16;
                const int SPR_WALL = 16;
                const int SPR_FLOOR = 32;

                int alignmask = (tsprite.cstat & SPR_ALIGN_MASK);
                bool flooraligned = (alignmask == SPR_FLOOR);

                Matrix4x4 modelMatrix = Matrix4x4.identity;

                Vector3 spos = new Vector3(tsprite.y, -tsprite.z / 16.0f, -tsprite.x);

                Material mat = spriteObject.GetComponentInChildren<MeshRenderer>().material;

                if (Engine.waloff[tsprite.picnum] == null || Engine.waloff[tsprite.picnum].texture == null)
                {
                    Engine.loadtile(tsprite.picnum);
                }

                if (Engine.waloff[tsprite.picnum] == null || Engine.waloff[tsprite.picnum].texture == null)
                    continue;

                mat.SetTexture("_MainTex", Engine.waloff[tsprite.picnum].texture);

                Vector4 parms;
                if((tsprite.cstat & 4) != 0) // XFLIP
                    parms = new Vector4(board.sector[tsprite.sectnum].visibility, tsprite.shade, tsprite.pal, 1);
                else
                    parms = new Vector4(board.sector[tsprite.sectnum].visibility, tsprite.shade, tsprite.pal, -1);

                if(parms != board.tsprite[i].materialparms)
                {
                    board.tsprite[i].materialparms = parms;
                    mat.SetVector("_MaterialParams", parms);
                }
                //mat.SetVector("_MaterialParams2", new Vector4(board.sector[tsprite.sectnum].visibility, tsprite.shade, tsprite.pal, 0));

                float xsize = Engine.tilesizx[tsprite.picnum];
                float ysize = Engine.tilesizy[tsprite.picnum];

                float xratio, yratio;

                if (((tsprite.cstat >> 4) & 3) == 0)
                    xratio = (float)(tsprite.xrepeat) * 0.20f; // 32 / 160
                else
                    xratio = (float)(tsprite.xrepeat) * 0.25f;

                yratio = (float)(tsprite.yrepeat) * 0.25f;

                xsize = (int)(xsize * xratio);
                ysize = (int)(ysize * yratio);

                int tilexoff = tsprite.xoffset;
                int tileyoff = tsprite.yoffset;
              //  tilexoff += Engine.picanm[tsprite.picnum].xofs; // jmarshall: fixme?
              //  tileyoff += Engine.picanm[tsprite.picnum].yofs; // jmarshall: fixme?

                int xoff = (int)(tilexoff * xratio);
                int yoff = (int)(tileyoff * yratio);

                short viewangle = board.globalang;

                int centeryoff = 0;

                if ((tsprite.cstat & 128) != 0 && !flooraligned)
                {
                    if (alignmask == 0)
                        yoff -= (int)(ysize / 2);
                    else
                        centeryoff = (int)(ysize / 2);
                }

                Vector3 spriteRotation = Vector3.zero;

                // Do we need this shit anymore??
                bool stupidfloor = false;
                switch (tsprite.cstat & SPR_ALIGN_MASK)
                {
                    case 0:
                        _ang = (float)(viewangle & 2047) / (2048.0f / 360.0f);

                        modelMatrix = modelMatrix * Matrix4x4.Translate(spos);
                        _math_matrix_rotate(ref modelMatrix, -_ang, 0.0f, 1.0f, 0.0f);
                        _math_matrix_rotate(ref modelMatrix, -horizang, 1.0f, 0.0f, 0.0f);
                        modelMatrix = modelMatrix * Matrix4x4.Translate(new Vector3((float)(-xoff), (float)(yoff), 0.0f));
                        modelMatrix = modelMatrix * Matrix4x4.Scale(new Vector3((float)(xsize), (float)(ysize), 1.0f));
                        break;
                    case SPR_WALL:
                        _ang = (float)((tsprite.ang + 1024) & 2047) / (2048.0f / 360.0f);

                        modelMatrix = modelMatrix * Matrix4x4.Translate(spos);
                        _math_matrix_rotate(ref modelMatrix, -_ang, 0.0f, 1.0f, 0.0f);
                        modelMatrix = modelMatrix * Matrix4x4.Translate(new Vector3((float)(-xoff), (float)(yoff - centeryoff), 0.0f));
                        modelMatrix = modelMatrix * Matrix4x4.Scale(new Vector3((float)(xsize), (float)(ysize), 1.0f));
                        //sprite->isWallSprite = true;
                        break;
                    case SPR_FLOOR:
                        stupidfloor = true;
                        _ang = (float)((tsprite.ang + 1024) & 2047) / (2048.0f / 360.0f);

                        modelMatrix = modelMatrix * Matrix4x4.Translate(spos);
                        _math_matrix_rotate(ref modelMatrix, -_ang, 0.0f, 1.0f, 0.0f);
                        modelMatrix = modelMatrix * Matrix4x4.Translate(new Vector3((float)(-xoff), 1.0f, (float)(yoff)));
                        modelMatrix = modelMatrix * Matrix4x4.Scale(new Vector3((float)(xsize), 1.0f, (float)(ysize)));

                        //	sprite->isHorizsprite = true;
                        break;
                }
                modelMatrix = modelMatrix.transpose;
                Vector3 rot = pragmas.MatrixToRotation(modelMatrix).eulerAngles;

                if (!stupidfloor)
                {
                    spriteObject.transform.eulerAngles = new Vector3(0, _ang + 180, 0);
                }
                else
                {
                    spriteObject.transform.eulerAngles = new Vector3(rot.x, rot.y, rot.z);
                }

                modelMatrix = modelMatrix.transpose;
                Vector3 translation = pragmas.ExtractPosition(modelMatrix);
                Vector3 scale = pragmas.ExtractScale(modelMatrix);
                scale.x *= -(1.0f / 1000.0f);
                scale.y *= 1.0f / 1000.0f;
                scale.z *= 1.0f / 1000.0f;

                translation.x *= -(1.0f / 1000.0f);
                translation.y *= 1.0f / 1000.0f;
                translation.z *= 1.0f / 1000.0f;

                spriteObject.transform.position = translation;

                spriteObject.transform.localScale = scale;

                spriteObject.SetActive(true);
            }

            Matrix4x4 rotationMatrix = Matrix4x4.identity;
            float tiltang = 0; // (board.gtang * 90.0f);
            float ang = (board.globalang & 2047) * (360.0f / 2048.0f);

            //_math_matrix_rotate(ref rotationMatrix, tiltang, 0.0f, 0.0f, -1.0f);
            //_math_matrix_rotate(ref rotationMatrix, horizang, 1.0f, 0.0f, 0.0f);
            //_math_matrix_rotate(ref rotationMatrix, ang, 0.0f, 1.0f, 0.0f);            

            //Camera.main.transform.eulerAngles = pragmas.MatrixToRotation(rotationMatrix.transpose).eulerAngles;
            Camera.main.transform.eulerAngles = new Vector3(horizang * (360.0f / 2048.0f), ang + 180, -tiltang);
            Camera.main.transform.position = new Vector3(-board.globalposy * (1.0f / 1000.0f), (-board.globalposz / 16) * (1.0f / 1000.0f), -board.globalposx * (1.0f / 1000.0f));            
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
                if ((-wal.x != s.floor.xyz[i].z))
                {
                    s.floor.xyz[i].z = s.ceil.xyz[i].z = -(float)wal.x;
                    needfloor = wallinvalidate = 1;
                }
                if ((wal.y != s.floor.xyz[i].x))
                {
                    s.floor.xyz[i].x = s.ceil.xyz[i].x = (float)wal.y;
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

            if (sec.changed || sec.neighborChanged)
            {
                sec.changed = false;
                sec.neighborChanged = false;
                buildfloor(sectnum);

                s.ceil.Update(sec.visibility, sec.ceilingshade, sec.ceilingpal, 0);
                s.floor.Update(sec.visibility, sec.floorshade, sec.floorpal, 0);
            }
            else
            {
                s.ceil.UpdateMaterial(sec.visibility, sec.ceilingshade, sec.ceilingpal, 0);
                s.floor.UpdateMaterial(sec.visibility, sec.floorshade, sec.ceilingpal, 0);
            }

            s.ceil.InitTexture(sec.ceilingpicnum);
            s.floor.InitTexture(sec.floorpicnum);

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

        void _math_matrix_rotate(ref Matrix4x4 matrix, float angle, float x, float y, float z)
        {
            float xx, yy, zz, xy, yz, zx, xs, ys, zs, one_c, s, c;
            Matrix4x4 m;
            bool optimized;
            const float M_PI = 3.14159265358979323846f;
            s = Mathf.Sin((float)(angle * M_PI / 180.0));
            c = Mathf.Cos((float)(angle * M_PI / 180.0));

            m = Matrix4x4.identity;

            optimized = false;
           if (x == 0.0F)
            {
                if (y == 0.0F)
                {
                    if (z != 0.0F)
                    {
                        optimized = true;
                        /* rotate only around z-axis */
                        m[0, 0] = c;
                        m[1, 1] = c;
                        if (z < 0.0F)
                        {
                            m[0, 1] = s;
                            m[1, 0] = -s;
                        }
                        else
                        {
                            m[0, 1] = -s;
                            m[1, 0] = s;
                        }
                    }
                }
                else if (z == 0.0F)
                {
                    optimized = true;
                    /* rotate only around y-axis */
                    m[0, 0] = c;
                    m[2, 2] = c;
                    if (y < 0.0F)
                    {
                        m[0, 2] = -s;
                        m[2, 0] = s;
                    }
                    else
                    {
                        m[0, 2] = s;
                        m[2, 0] = -s;
                    }
                }
            }
            else if (y == 0.0F)
            {
                if (z == 0.0F)
                {
                    optimized = true;
                    /* rotate only around x-axis */
                    m[1, 1] = c;
                    m[2, 2] = c;
                    if (x < 0.0F)
                    {
                        m[1, 2] = s;
                        m[2, 1] = -s;
                    }
                    else
                    {
                        m[1, 2] = -s;
                        m[2, 1] = s;
                    }
                }
            }

            if (!optimized)
            {
                float mag = (float)Mathf.Sqrt(x * x + y * y + z * z);

                if (mag <= 1.0e-4F)
                {
                    /* no rotation, leave mat as-is */
                    return;
                }

                x /= mag;
                y /= mag;
                z /= mag;


                /*
                *     Arbitrary axis rotation matrix.
                *
                *  This is composed of 5 matrices, Rz, Ry, T, Ry', Rz', multiplied
                *  like so:  Rz * Ry * T * Ry' * Rz'.  T is the final rotation
                *  (which is about the X-axis), and the two composite transforms
                *  Ry' * Rz' and Rz * Ry are (respectively) the rotations necessary
                *  from the arbitrary axis to the X-axis then back.  They are
                *  all elementary rotations.
                *
                *  Rz' is a rotation about the Z-axis, to bring the axis vector
                *  into the x-z plane.  Then Ry' is applied, rotating about the
                *  Y-axis to bring the axis vector parallel with the X-axis.  The
                *  rotation about the X-axis is then performed.  Ry and Rz are
                *  simply the respective inverse transforms to bring the arbitrary
                *  axis back to its original orientation.  The first transforms
                *  Rz' and Ry' are considered inverses, since the data from the
                *  arbitrary axis gives you info on how to get to it, not how
                *  to get away from it, and an inverse must be applied.
                *
                *  The basic calculation used is to recognize that the arbitrary
                *  axis vector (x, y, z), since it is of unit length, actually
                *  represents the sines and cosines of the angles to rotate the
                *  X-axis to the same orientation, with theta being the angle about
                *  Z and phi the angle about Y (in the order described above)
                *  as follows:
                *
                *  cos ( theta ) = x / sqrt ( 1 - z^2 )
                *  sin ( theta ) = y / sqrt ( 1 - z^2 )
                *
                *  cos ( phi ) = sqrt ( 1 - z^2 )
                *  sin ( phi ) = z
                *
                *  Note that cos ( phi ) can further be inserted to the above
                *  formulas:
                *
                *  cos ( theta ) = x / cos ( phi )
                *  sin ( theta ) = y / sin ( phi )
                *
                *  ...etc.  Because of those relations and the standard trigonometric
                *  relations, it is pssible to reduce the transforms down to what
                *  is used below.  It may be that any primary axis chosen will give the
                *  same results (modulo a sign convention) using thie method.
                *
                *  Particularly nice is to notice that all divisions that might
                *  have caused trouble when parallel to certain planes or
                *  axis go away with care paid to reducing the expressions.
                *  After checking, it does perform correctly under all cases, since
                *  in all the cases of division where the denominator would have
                *  been zero, the numerator would have been zero as well, giving
                *  the expected result.
                */

                xx = x * x;
                yy = y * y;
                zz = z * z;
                xy = x * y;
                yz = y * z;
                zx = z * x;
                xs = x * s;
                ys = y * s;
                zs = z * s;
                one_c = 1.0F - c;

                /* We already hold the identity-matrix so we can skip some statements */
                m[0, 0] = (one_c * xx) + c;
                m[0, 1] = (one_c * xy) - zs;
                m[0, 2] = (one_c * zx) + ys;
                /*    M(0,3) = 0.0F; */

                m[1, 0] = (one_c * xy) + zs;
                m[1, 1] = (one_c * yy) + c;
                m[1, 2] = (one_c * yz) - xs;
                /*    M(1,3) = 0.0F; */

                m[2, 0] = (one_c * zx) - ys;
                m[2, 1] = (one_c * yz) + xs;
                m[2, 2] = (one_c * zz) + c;
                /*    M(2,3) = 0.0F; */

                /*
                M(3,0) = 0.0F;
                M(3,1) = 0.0F;
                M(3,2) = 0.0F;
                M(3,3) = 1.0F;
                */
            }

            matrix = matrix * m;

            //float4x4 _internalMatrix(&m[0]);
            //_internalMatrix.r[0] = XMVectorSet(m[0], m[1], m[2], m[3]);
            //_internalMatrix.r[1] = XMVectorSet(m[4], m[5], m[6], m[7]);
            //_internalMatrix.r[2] = XMVectorSet(m[8], m[9], m[10], m[11]);
            //_internalMatrix.r[3] = XMVectorSet(m[12], m[13], m[14], m[15]);
            //float4x4 temp = matrix * _internalMatrix;
            //matrix = temp;

            //matmul4(mat, mat, m);
            //matrix_multf(mat, m, MAT_FLAG_ROTATION);
        }
    }
}