using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{

    //will want to change direction or stop if a certain "point" is hit

    public float speed;

    public List<Transform> navPoints = new List<Transform>();
    public Transform currentNavPoint;
    public int navPointIndex;

    public Vector3 platVelocity = Vector3.zero;



    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate(){
        
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

/*
    public bool isVertical;
    public bool startsMovingRight;
    

    int direction;

    public int Direction {get {return direction;} set {direction = value;}} 
    
    //public float waitTime;
    [SerializeField]
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = (startsMovingRight) ? 1 : -1;

        if (isVertical){
            //rb.FreezePositionX = true;
        }
        else{}
            //rb.FreezePositionY = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){

        /*
        Vector2 position = rb.position;

        if(isVertical){
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else{
            position.x = position.x + Time.deltaTime * speed * direction;
        }

        rb.MovePosition(position);
}
        */
/*
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "PlatformBoundary"){
        direction = direction * -1;
        }
    }
    */

