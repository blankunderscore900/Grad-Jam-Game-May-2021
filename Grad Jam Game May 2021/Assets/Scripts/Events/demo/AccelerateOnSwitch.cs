using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateOnSwitch : AbstractSwitchListener {

    private bool isEnabled = false;

    public override void onSwitchStateChange(bool status, GameObject switchObject) {
        isEnabled = status;
    }

    // Update is called once per frame
    void Update() {
        if (!isEnabled) return;
        gameObject.transform.Translate(0, 0.05f, 0);
    }
}
