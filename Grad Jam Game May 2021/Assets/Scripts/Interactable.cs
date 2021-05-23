using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public UnityEvent onActivate;

    //List that keeps track of all interactables
    public static List<Interactable> interactables = new List<Interactable>(); 


    public static Interactable getInteractable(Vector2 playerPosition){
        Interactable toReturn = null;

        foreach (Interactable i in interactables)
        {
            if (toReturn == null){
                toReturn = i;
            }
            else if (Vector2.Distance(i.transform.position , playerPosition) < 
                    Vector2.Distance(toReturn.transform.position , playerPosition)){
                        toReturn = i;
                    }
        }
        return toReturn;
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        interactables.Add(this);
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        interactables.Remove(this);
    }

}
