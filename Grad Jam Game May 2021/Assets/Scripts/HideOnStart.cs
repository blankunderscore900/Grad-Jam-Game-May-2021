using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        gameObject.transform.Translate(0.0f, -10000.0f, 0.0f);
    }
}
