using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform generationPoint;
    [SerializeField]
    private TerrainStructure terrainStructure;
    [SerializeField]
    private GameObject lanes;

    private int zPosition = GlobalScale.scale;
    private TerrainType previousTerrainType;

    private void Update()
    {
        if (zPosition < generationPoint.position.z)
        {
            zPosition += GlobalScale.scale;
            SpawnTerrain();
        }
    }

    private void SpawnTerrain()
    {
        var terrainModel = terrainStructure.GetTerrain();

        if (terrainModel.Type == TerrainType.Road && terrainModel.Type == previousTerrainType)
            ObjectPool.Spawn(lanes, Vector3.forward * (zPosition - 1));

        ObjectPool.Spawn(terrainModel.Prefab, Vector3.forward * zPosition);
        previousTerrainType = terrainModel.Type;
    }
}
