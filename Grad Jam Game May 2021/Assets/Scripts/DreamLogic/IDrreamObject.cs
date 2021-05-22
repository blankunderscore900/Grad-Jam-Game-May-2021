using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDreamObject {
    public bool isInDream {
        get;
        set;
    }

    public void onEnterDream();
    public void onExitDream();
}
