using UnityEngine;

public class Door : MonoBehaviour
{
    public bool is_locked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Interact(){
        Debug.Log("Door opened!");
    }
}
