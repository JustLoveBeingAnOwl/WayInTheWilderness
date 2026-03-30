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
    public GameObject[] key; //unused for now
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
    public void OllisionEnter(Collision collision)
    {
        DoorInteract();
    }
    public void DoorInteract(){
        if (IsClosed && !IsLocked)
        {
            while (transform.position != openPos)
            {
                transform.position += 0.25f*transform.right;
            }
            IsClosed = false;
            Debug.Log("Door opened!");
        }
        else if (!IsLocked)
        {
            while (transform.position != closedPos)
            {
                transform.position -= 0.25f*transform.right;
            }
            IsClosed = true;
            Debug.Log("Door closed!");
        }
    }
}
