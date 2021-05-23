using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : Switch {
    private static readonly KeyCode TARGET_KEY = KeyCode.E;

    private void OnTriggerStay2D(Collider2D collision) {
        Debug.Log($"Near the button:  {collision.gameObject.name}");
        if (collision.gameObject.tag != "Player") return;
        if (Input.GetKey(TARGET_KEY)) {
            Debug.Log("It Works");
            isSwitchEnabled = true;
            //Destroy(this);
        }
    }
}
