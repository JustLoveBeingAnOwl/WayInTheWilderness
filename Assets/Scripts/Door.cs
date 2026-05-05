using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    private Vector3 closedPos;
    private Vector3 openPos;
    public float OpenDistance = 2.0f;
    public bool IsLocked = false;
    public bool IsClosed = true;
    // unused public Key key;

    void Start()
    {
        closedPos = transform.position;
        openPos = closedPos +  transform.right * OpenDistance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OllisionEnter(Collision collision)
    {
        DoorInteract();
    }
    public void DoorInteract(){
        GameManager.Instance.UseKeyDoor(this);
        if (IsClosed && !IsLocked)
        {
            transform.position = openPos;
            IsClosed = false;
            Debug.Log("Door opened!");
        }
        else if (!IsLocked)
        {
            transform.position = closedPos;
            IsClosed = true;
            Debug.Log("Door closed!");
        }
    }
}
