using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamBoundary : MonoBehaviour {

    public Player player;

    private static (IDreamObject, bool) GetState(Collider2D collsion) {
        var component = collsion.gameObject.GetComponent<IDreamObject>();
        return (component, component != null);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        (IDreamObject component, bool hasComponent) = GetState(collision);
        Debug.Log("this is working");
        player.extraJumps = 1;
        player.IsInDream = true;

    }

    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("Exit");
        (IDreamObject component, bool hasComponent) = GetState(collision);
        player.extraJumps = 0;
        player.IsInDream = false;

    }
}
