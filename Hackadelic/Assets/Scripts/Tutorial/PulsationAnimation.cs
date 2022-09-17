using UnityEngine;

public class PulsationAnimation : MonoBehaviour
{
    float animationProgress;
    Vector3 baseScale;
    MovingScript movingScript;
    
    void Start()
    {
        baseScale = transform.localScale;
        movingScript = gameObject.GetComponent<MovingScript>();
    }

    void Update()
    {
        animationProgress += Time.deltaTime;
        transform.localScale = (movingScript.ChangePosition.magnitude *
            Mathf.Sin(animationProgress) + 1) * baseScale;
    }
}
