using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AButtonSwitch : Switch {
    void Update() {
        if (Input.GetKeyDown("a")) {
            isSwitchEnabled = true;
        }
        else if (Input.GetKeyUp("a")) {
            isSwitchEnabled = false;
        }
    }
}
