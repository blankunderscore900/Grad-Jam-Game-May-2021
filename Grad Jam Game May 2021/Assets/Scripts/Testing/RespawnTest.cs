using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTest : MonoBehaviour {
        void Update() {
        if (Input.GetKeyDown(KeyCode.Delete)) {
            CheckpointManager.RestoreState();
        }
        else if (Input.GetKeyDown(KeyCode.Insert)) {
            CheckpointManager.SaveState();
        }
    }
}