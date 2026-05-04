using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("General Stats")]
    public int MaxHealth = 20;
    public int CurrentHealth = 20;
    public float Speed = 10f;
    [Header("Components")]
    CharacterController cc;
    public RangedWeapon currentGun; 
    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 direction)
    {
        if(direction == Vector3.zero)
        {
            return;
        }
        direction = direction.normalized;

        cc.Move(direction*Speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            item.PickUp(gameObject);
        }
    }
    public void RotateCreatureForCamera(Transform cameraTransform)
    {
        transform.rotation = cameraTransform.rotation;
    }

    public void FireWeapon()
    {
        currentGun.Shoot();
    }
    public void ReloadWeapon()
    {
        currentGun.Reload();
    }
    
}
