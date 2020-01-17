using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System;

public class TerrainStructureTests
{
    [Test, Timeout(10000000)]
    public void Get_Terrain_Test()
    {
        //Arrange
        var terrainStructure = new TerrainStructure();

        var terrainModels = new List<TerrainModel>()
        { new TerrainModel() { Type = TerrainType.Grass },
          new TerrainModel() { Type = TerrainType.Road },
          new TerrainModel() { Type = TerrainType.Rail },
          new TerrainModel() { Type = TerrainType.Water }
        };

        terrainStructure.Construct(terrainModels);
        //Act
        var actual = new List<TerrainType>();

        for (int i = 0; i < 100000; i++)
        {
            actual.Add(terrainStructure.GetTerrain().Type);
        }

        //Assert
        CheckMaxRepetition(actual);
    }

    private void CheckMaxRepetition(List<TerrainType> actual)
    {
        int terrainTypeNumber = 0;
        TerrainType? previousTerrainType = null;

        foreach (var terrainType in actual)
        {
            if (terrainType == previousTerrainType)
            {
                terrainTypeNumber++;
                if (terrainTypeNumber > 6)
                {
                    Print(terrainType, terrainTypeNumber);
                    Assert.Fail();
                }
                continue;
            }

            if (terrainTypeNumber < 2 && terrainTypeNumber > 0 && previousTerrainType == TerrainType.Water)
            {
                Print(previousTerrainType, terrainTypeNumber);
                Assert.Fail();
            }

            previousTerrainType = terrainType;
            terrainTypeNumber = 1;
        }
    }

    private void Print(TerrainType? type, int typeNumber)
    {
        Debug.Log("Terrain Type " + type + " is repeated " + typeNumber + " times");
    }
}
