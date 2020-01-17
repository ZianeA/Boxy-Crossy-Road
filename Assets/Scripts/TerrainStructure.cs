using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class TerrainStructure
{
    [SerializeField]
    private List<TerrainModel> terrainModels;

    private static System.Random rand = new System.Random();
    private int[] indexesNumber = new int[4];
    private bool regenerateRandomIndex;

    private int maxRoadNumber = 5;
    private int maxGrassNumber = 2;
    private int maxRailNumber = 2;
    private int maxWaterNumber = 6;

    private int minWaterNumber = 2;

    public void Construct(List<TerrainModel> terrainModels)
    {
        this.terrainModels = terrainModels;
    }

    public TerrainModel GetTerrain()
    {
        return terrainModels[RandomIndex()];
        //return terrainModels[1];
    }

    private int RandomIndex()
    {
        //0-Grass, 1-Road, 2-Rail, 3-Water ---> Index
        //50-road, 25-grass, 15-rail, 10-water ---> random percentage
        //5-road, 2-grass, 2-rail, 1-water ---> max number of the same terrain type

        int index = 0;

        if (indexesNumber[3] > 0 && indexesNumber[3] < minWaterNumber)
        {
            indexesNumber[3]++;

            return 3;
        }

        do
        {
            var randomNumber = rand.Next(100);

            if (randomNumber <= 50)
            {
                index = 1;
                ResetArray(index, maxRoadNumber);
            }
            else if (randomNumber <= 65)
            {
                index = 2;
                ResetArray(index, maxRailNumber);
            }
            else if (randomNumber <= 75)
            {
                index = 3;
                ResetArray(index, maxWaterNumber);
            }
            else
            {
                index = 0;
                ResetArray(index, maxGrassNumber);
            }

        } while (regenerateRandomIndex);

        return index;
    }

    private void ResetArray(int index, int maxRepetition)
    {
        indexesNumber[index]++;

        if (indexesNumber[index] > maxRepetition)
            regenerateRandomIndex = true;
        else
            regenerateRandomIndex = false;

        if (indexesNumber[index] > 1)
            return;

        for (int i = 0; i < indexesNumber.Length; i++)
        {
            if (i == index)
                continue;

            indexesNumber[i] = 0;
        }
    }
}
