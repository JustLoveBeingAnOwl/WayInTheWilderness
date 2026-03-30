using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Vector3 closedPos;
    private Vector3 openPos;
    public float OpenDistance = 3.0f;
    public bool IsLocked = false;
    public bool IsClosed = true;
    public string key; //unused for now
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closedPos = transform.position;
        openPos = closedPos +  transform.right * OpenDistance;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DoorInteract(){
        if (IsClosed && !IsLocked)
        {
            while (transform.position != openPos)
            {
                transform.position += transform.right * 0.25f;
            }
            IsClosed = false;
            Debug.Log("Door opened!");
        }
        else if (!IsLocked)
        {
            while (transform.position != closedPos)
            {
                transform.position -= transform.right * 0.25f;
            }
            IsClosed = true;
            Debug.Log("Door closed!");
        }
    }
}
