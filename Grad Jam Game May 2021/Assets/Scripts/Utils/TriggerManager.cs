using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {
    public delegate void Disable();
    public delegate void Enable();

    public static event Disable OnDisable;
    public static event Enable OnEnable;

    public static void RunWithoutScriptTriggers(Action action) {
        OnDisable();
        action();
        OnEnable();
    }
}
