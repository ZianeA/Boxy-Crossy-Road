using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform body;
    [SerializeField]
    private List<GameObject> prefabs;
    [SerializeField]
    private float minSpeed = 3;
    [SerializeField]
    private float maxSpeed = 6;
    [SerializeField]
    private float minDelay = 2;
    [SerializeField]
    private float maxDelay = 6;
    [SerializeField]
    private bool oppositeDirection;

    private float xPosition;
    private static int direction = 1;

    private void Awake()
    {
        xPosition = body.localScale.x / 2;
    }

    private void OnEnable()
    {
        var randIndex = Random.Range(0, prefabs.Count);
        var randDelay = Random.Range(minDelay, maxDelay);

        if (oppositeDirection)
            direction *= -1;
        else
            direction = MyRandom.RandomDirection();

        var randSpeed = Random.Range(minSpeed, maxSpeed) * direction;
        var randXPosition = -direction * xPosition;

        StartCoroutine(Spawn(prefabs[randIndex], randSpeed, randDelay, randXPosition));
    }

    private IEnumerator Spawn(GameObject prefab, float speed, float delay, float xPosition)
    {
        yield return new WaitForEndOfFrame();

        while (true)
        {
            var obj = ObjectPool.Spawn(prefab, new Vector3(xPosition, 0, transform.position.z));
            obj.GetComponent<MoverController>().Speed = speed;

            yield return new WaitForSeconds(delay);
        }
    }
}
