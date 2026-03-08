using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        Vector3 dummyPosition = transform.position;
        dummyPosition.x = followTransform.position.x; 
        dummyPosition.z = followTransform.position.z; 
        transform.position = dummyPosition;
        
    }
}
