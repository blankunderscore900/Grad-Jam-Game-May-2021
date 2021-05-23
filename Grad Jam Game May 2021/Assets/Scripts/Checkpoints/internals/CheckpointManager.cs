using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {
    public delegate void Save();
    public delegate void Restore();

    public static event Save OnSave;
    public static event Restore OnRestore;

    public static void SaveState() {
        TriggerManager.RunWithoutScriptTriggers(() => OnSave());
    }

    public static void RestoreState() {
        TriggerManager.RunWithoutScriptTriggers(() => OnRestore());
    }
}
