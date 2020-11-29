using System;
using UnityEngine;

namespace Build
{
    static class Tile
    {
        public static Texture2D LoadTile(int tileNum)
        {
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
    }
}
