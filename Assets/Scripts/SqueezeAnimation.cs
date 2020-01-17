using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqueezeAnimation
{
    private float scalePercentage;
    private Transform _transform;
    private bool hasAnimationCompleted;

    public bool HasAnimationCompleted { get { return hasAnimationCompleted; } }

    public SqueezeAnimation(Transform transform)
    {
        _transform = transform.GetChild(0);
    }

    public void Animate(float minScale, float speed)
    {
        if (hasAnimationCompleted)
            return;

        scalePercentage += Time.deltaTime * speed;
        var newScale = Mathf.Lerp(1, minScale, Mathf.Pow(scalePercentage, 0.5f));
        _transform.localScale = new Vector3(_transform.localScale.x, newScale, _transform.localScale.z);

        if (scalePercentage >= 1.0f)
            hasAnimationCompleted = true;
    }

    public void Reset()
    {
        _transform.localScale = Vector3.one;
        scalePercentage = 0;
        hasAnimationCompleted = false;
    }
}
