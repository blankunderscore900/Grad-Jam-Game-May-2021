using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSwitch : Switch {
    private static readonly KeyCode TARGET_KEY = KeyCode.E;

    [SavedValue]
    private bool hasPlayer = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != "Player") return;

        hasPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag != "Player") return;

        hasPlayer = false;
    }

    private void Update() {
        if (hasPlayer && !isSwitchEnabled && Input.GetKeyDown(TARGET_KEY)) {
            isSwitchEnabled = true;
        }
    }
}
