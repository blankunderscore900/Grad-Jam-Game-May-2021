using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchedMovingPlatform : MovingPlatformController {
    [SavedValue]
    public bool isMoving;

    [SavedValue]
    public float off_speed;

    public string target_switch_id;

    private SwitchHelper helper;

    private SwitchedMovingPlatform flipSpeed() {
        var tmp = speed;
        speed = off_speed;
        off_speed = tmp;

        return this;
    }

    void Awake() {
        if (!isMoving) flipSpeed();
        helper = new SwitchHelper(target_switch_id, OnSwitchStateChanged);
    }

    

    private void OnEnable() {
        helper = new SwitchHelper(target_switch_id, OnSwitchStateChanged).register();
    }

    private void OnDisable() {
        helper.unregister();
    }

    private void OnSwitchStateChanged(bool state) {
        flipSpeed();
    }
}
