using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamBoundary : MonoBehaviour {
    private static (IDreamObject, bool) GetState(Collider2D collsion) {
        var component = collsion.gameObject.GetComponent<IDreamObject>();
        return (component, component != null);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        (IDreamObject component, bool hasComponent) = GetState(collision);

        if (!hasComponent) return;

        component.isInDream = true;
        component.onEnterDream();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        (IDreamObject component, bool hasComponent) = GetState(collision);

        if (!hasComponent) return;

        component.isInDream = false;
        component.onExitDream();
    }
}
