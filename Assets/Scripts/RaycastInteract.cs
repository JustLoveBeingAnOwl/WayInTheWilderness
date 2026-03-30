using UnityEngine;

public class RaycastInteract : MonoBehaviour
{
    public float interactDistance = 5.0f;
    Ray ray;
    public LayerMask interactLayers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PerformInteractRaycast()
    {
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayers)){
            Debug.Log(hit.collider.gameObject.name + " was hit!");
            if (hit.collider.gameObject.CompareTag("DoorTag"))
            {
                hit.collider.GetComponent<Door>().DoorInteract();
            }
        }
    }
    /*void CheckForColliders()
    {
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayers)){
            Debug.Log(hit.collider.gameObject.name + " was hit!");
        }
    }*/
}
