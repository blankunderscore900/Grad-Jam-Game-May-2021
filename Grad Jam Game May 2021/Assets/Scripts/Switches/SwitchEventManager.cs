using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwitchEventManager {
    public delegate void SwitchStateChanged(string switch_id, bool state, GameObject switchObject);
    public static event SwitchStateChanged OnSwitchStateChanged;

    private static bool enabled = true;

    private static void Enable() {
        enabled = true;
    }

    private static void Disable() {
        enabled = false;
    }

    static SwitchEventManager() {
        TriggerManager.OnEnable += Enable;
        TriggerManager.OnDisable += Disable;
    }

    public static void UpdateState(string switch_id, bool state, GameObject switchObject) {
        if (OnSwitchStateChanged == null) return;
        if (!enabled) return;

        OnSwitchStateChanged(switch_id, state, switchObject);
    }
}