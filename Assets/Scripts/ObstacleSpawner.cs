using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabs;

    private static readonly List<int> possibleSpawnPoint = new List<int>() { -8, -6, -4, -2, 0, 2, 4, 6, 8 };
    private List<int> shuffledPossibleSpawnPoint;
    private int previousIndex;

    private GameObject RandomPrefab
    {
        get
        {
            var randIndex = Random.Range(0, prefabs.Count);
            return prefabs[randIndex];
        }
    }

    private void OnEnable()
    {
        shuffledPossibleSpawnPoint = possibleSpawnPoint.Shuffle();
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForEndOfFrame();

        var randNumberOfObstacles = Random.Range(1, 6);

        for (int i = 0; i < randNumberOfObstacles; i++)
        {
            ObjectPool.Spawn(RandomPrefab, RandomSpawnPoint());
        }
    }

    private Vector3 RandomSpawnPoint()
    {
        var n = shuffledPossibleSpawnPoint.Count - 1;
        var output = new Vector3(shuffledPossibleSpawnPoint[n], 0, transform.position.z);
        shuffledPossibleSpawnPoint.RemoveAt(n);

        return output;
    }
}
