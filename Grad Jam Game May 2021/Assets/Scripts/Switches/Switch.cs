using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Switch : MonoBehaviour {
    [SavedValue]
    private bool switchStatus = false;
    public string switch_id = null;

    public bool isSwitchEnabled {
        get {
            return switchStatus;
        }
        set {
            switchStatus = value;
            SwitchEventManager.UpdateState(switch_id, switchStatus, gameObject);
        }
    }
}