using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressTest : MonoBehaviour
{
    int n = 0;
    public void OnButtonPress() {
        Debug.Log("helo world" + ++n);        
    }
}
