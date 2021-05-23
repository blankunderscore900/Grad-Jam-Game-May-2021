using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnSwitch : AbstractSwitchListener {

    public bool starts_hidden = true;

    private Vector3 position;

    void Awake() {
        position = gameObject.transform.position;
        if (starts_hidden) gameObject.transform.Translate(0.0f, -1000000.0f, 0.0f);
    }

    public override void onSwitchStateChange(bool status, GameObject switchObject) {
        if (starts_hidden) {
            gameObject.transform.position = position;
        }
        else {
            gameObject.transform.Translate(0.0f, -1000000.0f, 0.0f);
        }
    }
}
