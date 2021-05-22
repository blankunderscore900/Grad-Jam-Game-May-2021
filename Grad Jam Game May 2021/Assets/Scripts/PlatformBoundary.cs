using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBoundary : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    /*
    void OnCollisionEnter2D(Collision2D other)
    {
        MovingPlatformController platform = other.gameObject.GetComponent<MovingPlatformController>();
        if(platform != null){
            platform.Direction = platform.Direction * -1;
        }    
    }
*/     

}
