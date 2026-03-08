using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    float yRotation = 0;
    [SerializeField] float rotationSpeed = 10f;
    public Transform cameraTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AdjustRotation(float delta)
    {
        yRotation += delta *= rotationSpeed * Time.deltaTime;

        cameraTransform.localRotation = Quaternion.Euler(0,yRotation,0);
    }
}
