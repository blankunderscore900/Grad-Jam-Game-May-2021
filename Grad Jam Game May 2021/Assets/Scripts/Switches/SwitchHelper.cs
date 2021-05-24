using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchHelper {
    private readonly string target_switch_id;

    public delegate void OnSwitchStateUpdated(bool state);
    private readonly OnSwitchStateUpdated action;

    public SwitchHelper(string _target_switch_id, OnSwitchStateUpdated _action) {
        target_switch_id = _target_switch_id;
        action = _action;
    }

    public SwitchHelper register() {
        SwitchEventManager.OnSwitchStateChanged += OnSwitchStateChange;
        return this;
    }

    public SwitchHelper unregister() {
        SwitchEventManager.OnSwitchStateChanged -= OnSwitchStateChange;
        return this;
    }

    private void OnSwitchStateChange(string switch_id, bool state, GameObject switchObject) {
        if (target_switch_id == switch_id) action(state);
    }
}
