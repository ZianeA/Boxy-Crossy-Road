using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInput
{
    public Vector2 MouseClickPosition { get; set; }
    public Vector2 MouseReleasePosition { get; set; }

    private float disX;
    private float disY;

    private int _mouseSwipeThreshold = 30;
    public int MouseSwipeThreshold
    {
        get
        {
            return _mouseSwipeThreshold;
        }

        set
        {
            _mouseSwipeThreshold = value;
        }
    }

    public SwipeInput(int mouseSwipeThreshold)
    {
        _mouseSwipeThreshold = mouseSwipeThreshold;
    }

    public SwipeInput() { }

    public bool IsSwipeLeft { get { return MouseClickPosition.x > MouseReleasePosition.x; } }

    public bool IsSwipeRight { get { return MouseClickPosition.x < MouseReleasePosition.x; } }

    public bool IsSwipeDown { get { return MouseClickPosition.y > MouseReleasePosition.y; } }

    public bool IsSwipeUp { get { return MouseClickPosition.y < MouseReleasePosition.y; } }

    /// <summary>
    /// Calculates the distance between the mouse click and release position, determines if it's a swipe according to the swipe threshold.
    /// </summary>
    public bool IsSwipe
    {
        get
        {
            disX = Mathf.Abs(MouseClickPosition.x - MouseReleasePosition.x);
            disY = Mathf.Abs(MouseClickPosition.y - MouseReleasePosition.y);

            return disX > _mouseSwipeThreshold || disY > _mouseSwipeThreshold;
        }
    }
    /// <summary>
    /// IsSwipe should be called first to update input.
    /// </summary>
    public bool IsSwipeHorizontal
    {
        get
        {
            return disX > disY;
        }
    }
}
