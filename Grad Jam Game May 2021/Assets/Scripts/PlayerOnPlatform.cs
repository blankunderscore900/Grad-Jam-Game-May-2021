using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnPlatform : MonoBehaviour
{

    public Player player;
    
    public Collider2D platCollider;

    // Start is called before the first frame update
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionStay2D(Collision2D other)
    {
        //Check if on platform
        Debug.Log("Touching: " + other.gameObject.name);

        MovingPlatformController platform = other.gameObject.GetComponent<MovingPlatformController>();

        if(platform != null){
        platCollider = other.collider;
        //player.platVelocity = platform.platVelocity;
        player.rb.transform.parent = transform;
        }

    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnCollisionExit2D(Collision2D other)
    {
      Debug.Log("Left: " + other.gameObject.name);

        if(other.collider == platCollider){
            player.platVelocity = Vector2.zero;
            player.rb.transform.parent = null;
        }
    }
}
