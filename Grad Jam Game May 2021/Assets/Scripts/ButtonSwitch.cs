using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : Switch {
    private static readonly KeyCode TARGET_KEY = KeyCode.E;

    private void OnTriggerStay2D(Collider2D collision) {
        Debug.Log("It Works");
        if (collision.gameObject.tag != "Player") return;
        if (Input.GetKeyDown(TARGET_KEY)) {
            isSwitchEnabled = true;
            Destroy(this);
        }
    }
}
