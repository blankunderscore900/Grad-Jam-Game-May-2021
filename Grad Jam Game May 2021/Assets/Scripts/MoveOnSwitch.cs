using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnSwitch : AbstractSwitchListener {
    public Transform target;
    public override void onSwitchStateChange(bool status, GameObject switchObject) {
        gameObject.transform.position = target.position;
        Destroy(this);
    }
}
