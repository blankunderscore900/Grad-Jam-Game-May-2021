using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransientObject : MonoBehaviour, IDreamObject {
    private static readonly Vector3 REMOVED = new Vector3(0.0f, 0.0f, 0.0f);

    public bool exists;

    private Vector3 scale;

    public bool isInDream { get; set; }

    // Start is called before the first frame update
    void Start() {
        scale = gameObject.transform.localScale;
    }

    private void setExistance(bool inDream) {
        gameObject.transform.localScale = (exists == inDream) ? REMOVED : scale;
    }

    public void onEnterDream() {
        Debug.Log("Vanish");
        setExistance(true);
    }


    public void onExitDream() {
        Debug.Log("Exist");
        setExistance(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Test");
    }
}
