using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsationAnimation : MonoBehaviour
{
    float progress;
    Vector3 baseScale;
    MovingScript movingScript;
    void Start()
    {
        baseScale = transform.localScale;
        movingScript = gameObject.GetComponent<MovingScript>();
    }

    void Update()
    {
        progress += Time.deltaTime;
        transform.localScale = (movingScript.ChangePosition.magnitude * Mathf.Sin(progress) + 1) * baseScale;
    }
}
