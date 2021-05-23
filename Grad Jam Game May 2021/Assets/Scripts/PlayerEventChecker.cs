using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventChecker : MonoBehaviour
{

    public Transform interactable;

    //Check for range of detecting interactables
    public float range;
    Vector2 rangeVector;
    public Vector2 RangeVector{get{return rangeVector;}}

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, new Vector2(range,range));
    }
}
