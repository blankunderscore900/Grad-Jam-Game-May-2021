using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Backslash)) {
            var player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = gameObject.transform.position;
        }
    }
}
