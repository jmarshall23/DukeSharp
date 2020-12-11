using System;
using UnityEngine;

namespace Build
{
    static class Tile
    {
        public static Texture2D LoadTile(int tileNum)
        {
            if (Engine.waloff[tileNum] == null)
                Engine.loadtile((short)tileNum);

            if (Engine.waloff[tileNum] == null)
                return null;

            byte[] tilebuffer = Engine.waloff[tileNum].memory;
            if (tilebuffer == null)
                return null;

            byte[] tempbuffer = new byte[Engine.tilesizx[tileNum] * Engine.tilesizy[tileNum]];
            int i, j, k;

            i = k = 0;
            while (i < Engine.tilesizy[tileNum])
            {
                j = 0;
                while (j < Engine.tilesizx[tileNum])
                {
                    tempbuffer[k] = tilebuffer[(j * Engine.tilesizy[tileNum]) + i];
                    k++;
                    j++;
                }
                i++;
            }

            Texture2D texture = new Texture2D(Engine.tilesizx[tileNum], Engine.tilesizy[tileNum], TextureFormat.R8, false);
            texture.filterMode = FilterMode.Point;
            texture.LoadRawTextureData(tempbuffer);
            texture.Apply();
            return texture;
        }

        public static void LoadTile(int tileNum, byte[] buffer, int width, int height)
        {
            if (Engine.waloff[tileNum] == null)
            {
                Engine.waloff[tileNum] = new Engine.tilecontainer();                
            }

            Engine.tilesizx[tileNum] = (short)width;
            Engine.tilesizy[tileNum] = (short)height;
            Engine.waloff[tileNum].memory = new byte[buffer.Length];
            Array.Copy(buffer, 0, Engine.waloff[tileNum].memory, 0, buffer.Length);

            byte[] tilebuffer = Engine.waloff[tileNum].memory;
            if (tilebuffer == null)
                return;

            byte[] tempbuffer = new byte[Engine.tilesizx[tileNum] * Engine.tilesizy[tileNum]];
            int i, j, k;

            i = k = 0;
            while (i < Engine.tilesizy[tileNum])
            {
                j = 0;
                while (j < Engine.tilesizx[tileNum])
                {
                    tempbuffer[k] = tilebuffer[(j * Engine.tilesizy[tileNum]) + i];
                    k++;
                    j++;
                }
                i++;
            }

            Texture2D texture = null;

            if (Engine.waloff[tileNum].texture == null)
            {
                texture = new Texture2D(Engine.tilesizx[tileNum], Engine.tilesizy[tileNum], TextureFormat.R8, false);
                Engine.waloff[tileNum].texture = texture;
            }
            else
            {
                texture = Engine.waloff[tileNum].texture;
                texture.Resize(width, height);
            }
            texture.filterMode = FilterMode.Point;
            texture.LoadRawTextureData(tempbuffer);
            texture.Apply();
        }
    }
}
