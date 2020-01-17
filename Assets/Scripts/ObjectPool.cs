using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectPool
{
    private static Dictionary<int, Queue<GameObject>> pool;
    private static GameObject poolsHolder;

    static ObjectPool()
    {
        pool = new Dictionary<int, Queue<GameObject>>();
        poolsHolder = new GameObject("ObjectPool");
        Object.DontDestroyOnLoad(poolsHolder);
        ObjectDespawner.DestructionPoint = DestructionPoint;
    }

    public static GameObject Spawn(GameObject prefab, Vector3 spawnPosition)
    {
        int poolKey = prefab.GetInstanceID();

        GameObject obj;

        if (pool.ContainsKey(poolKey))
        {
            var queue = pool[poolKey];
            var oldestObj = queue.Peek();

            //If all gameObjects are used instantiate a new one
            if (oldestObj.activeSelf)
            {
                obj = prefab.MyInstantiate(oldestObj.transform.parent)
                      .AddComponentAndEnqueue(spawnPosition, queue);
            }
            else
            {
                obj = queue.Dequeue()
                     .Enqueue(spawnPosition, queue);
            }
        }
        else
        {
            var queue = new Queue<GameObject>();
            pool.Add(poolKey, queue);

            var poolHolder = new GameObject(prefab.name + " pool");
            poolHolder.transform.SetParent(poolsHolder.transform, false);

            obj = prefab.MyInstantiate(poolHolder.transform)
                  .AddComponentAndEnqueue(spawnPosition, queue);
        }

        return obj;
    }

    public static void Reset()
    {
        foreach (var p in pool)
        {
            foreach (var g in p.Value)
            {
                g.SetActive(false);
            }
        }
    }

    private static GameObject Enqueue(this GameObject obj, Vector3 spawnPosition, Queue<GameObject> queue)
    {
        obj.SetActive(true);
        obj.transform.position = spawnPosition;
        queue.Enqueue(obj);

        return obj;
    }

    private static GameObject AddComponentAndEnqueue(this GameObject obj, Vector3 spawnPosition, Queue<GameObject> queue)
    {
        obj.Enqueue(spawnPosition, queue);
        obj.AddComponent<ObjectDespawner>();

        return obj;
    }

    private static GameObject MyInstantiate(this GameObject prefab, Transform parent)
    {
        return Object.Instantiate(prefab, Vector3.zero, Quaternion.identity, parent.transform);
    }

    private static Transform DestructionPoint
    {
        get
        {
            return new GameObject("DestructionPoint").AddComponent<DestructionPointController>().transform;
        }
    }
}
