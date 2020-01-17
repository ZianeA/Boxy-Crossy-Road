using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static float Map(this float value, float inFrom, float inTo, float outFrom, float outTo)
    {
        return (value - inFrom) * (outTo - outFrom) / (inTo - inFrom) + outFrom;
    }

    public static int Map(this int value, int inFrom, int inTo, int outFrom, int outTo)
    {
        return (value - inFrom) * (outTo - outFrom) / (inTo - inFrom) + outFrom;
    }

    public static void ScaleGameObject(this GameObject gameObject, Vector3 scale)
    {
        gameObject.transform.localScale = scale;
    }

    public static List<T> Shuffle<T>(this List<T> list)
    {
        var copy = new List<T>(list);

        for (int i = 0; i < copy.Count - 1; i++)
        {
            int randomIndex = Random.Range(i, copy.Count);
            T tempItem = copy[randomIndex];
            copy[randomIndex] = copy[i];
            copy[i] = tempItem;
        }

        return copy;
    }

    public static float RoundToEven(this float value)
    {
        var valueRounded = Mathf.Round(value);

        return (valueRounded % 2 == 0) ? valueRounded : (valueRounded + 1);
    }
}
