using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchEventManager : MonoBehaviour {
    public delegate void SwitchStateChanged(string switch_id, bool state, GameObject switchObject);
    public static event SwitchStateChanged OnSwitchStateChanged;

    public static void UpdateState(string switch_id, bool state, GameObject switchObject) {
        if (OnSwitchStateChanged == null) return;

        OnSwitchStateChanged(switch_id, state, switchObject);
    }
}