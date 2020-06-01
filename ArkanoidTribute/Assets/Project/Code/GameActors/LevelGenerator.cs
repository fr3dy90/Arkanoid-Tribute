using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorTile[] tiles;
    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x,y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            return;
        }

        foreach (ColorTile colortile in tiles)
        {
            if (colortile.m_color.Equals(pixelColor))
            {
                Vector2 vPos = new Vector2((x*.5f)-((Camera.main.orthographicSize/2)-.25f)  , y*.25f);
                Instantiate(colortile.prefabTile, vPos, quaternion.identity);
            }
        }
    }
}

[System.Serializable]
public class ColorTile
{
    public Color m_color;
    public GameObject prefabTile;
}
