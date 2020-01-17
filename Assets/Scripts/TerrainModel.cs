using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class TerrainModel
{
    [SerializeField]
    private List<GameObject> prefabs;

    private int index;

    public GameObject Prefab
    {
        get
        {
            if (prefabs.Count == 1)
                return prefabs[0];

            index ^= 1;
            return prefabs[index];
        }
    }

    [SerializeField]
    private TerrainType type;

    public TerrainType Type
    {
        get { return type; }
        set { type = value; }
    }
}
