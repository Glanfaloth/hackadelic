using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public Vector3 ChangePosition;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += ChangePosition * Time.deltaTime;
    }
}
