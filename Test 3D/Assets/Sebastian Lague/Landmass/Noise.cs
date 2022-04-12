using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise // Not applying to any object, so no reason to inherit from MonoBehaviour. It's also not going to need different instances of this class, so it's going to be static. 
{
    // The point of this class is to generate a grid of values for the Perlin Noise.
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale)
    {
        if (scale <= 0)
        {
            scale = 0.0001f;
        }


        float[,] noiseMap = new float[mapWidth, mapHeight];
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float sampleX = x / scale;
                float sampleY = y / scale;

                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                noiseMap[x, y] = perlinValue;
            }
        }

        return noiseMap;

    }



}
