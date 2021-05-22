using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSwitchListener : MonoBehaviour {
    public string target_switch_id = null;
    private void OnEnable() {
        SwitchEventManager.OnSwitchStateChanged += onStateChange;
    }

    private void OnDisable() {
        SwitchEventManager.OnSwitchStateChanged -= onStateChange;
    }

    private void onStateChange(string switch_id, bool status, GameObject switchObject) {
        if (switch_id!=target_switch_id) return;
        onSwitchStateChange(status, switchObject);
    }

    public abstract void onSwitchStateChange(bool status, GameObject switchObject);
}
