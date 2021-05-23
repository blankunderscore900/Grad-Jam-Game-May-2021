using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{

    //will want to change direction or stop if a certain "point" is hit
    [SavedValue]
    public float speed;

    [SavedValue]
    public bool isActive = true;

    public List<Transform> navPoints = new List<Transform>();

    [SavedValue]
    public Transform currentNavPoint;

    [SavedValue]
    public int navPointIndex;

    public Vector3 platVelocity = Vector3.zero;


    public void setActive(bool active){
        isActive = active;
    }


    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate(){
        
        if(isActive){

        float distance = Vector3.Distance(transform.position, currentNavPoint.position);

        if(distance < 0.1){
            navPointIndex += 1;
            if(navPointIndex >= navPoints.Count){
                navPointIndex = 0;
            }
            currentNavPoint = navPoints[navPointIndex];
        }

        Vector3 direction = currentNavPoint.position - transform.position;
        direction.Normalize();

        platVelocity = direction * speed;
        transform.position += platVelocity * Time.fixedDeltaTime;
        }
    }
}


