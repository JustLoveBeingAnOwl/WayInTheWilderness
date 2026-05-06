using UnityEngine;

public class Creature: MonoBehaviour
{
    public string Name;
    public int MaxHealth;
    public int CurrentHealth;
    public float RotateSpeed = 10;
    public int MovementSpeed;
    public int Power;
    public bool IsAlly = false;
    public float meleeRange = 4f;
    CharacterController cc;
    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

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
        cc.Move(direction*MovementSpeed*Time.deltaTime);

        Vector3 flatDirection = new Vector3(direction.x, 0f, direction.z);
        if (flatDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                Quaternion.LookRotation(flatDirection),
                RotateSpeed * Time.deltaTime
            );
        }
    }
    public void MoveTowards(Vector3 destination)
    {
        Vector3 moveVector = destination - transform.position;
        Move(moveVector);
    }
    public void TakeDamage(int dam)
    {
        Debug.Log("Critter took damage!");
        CurrentHealth -= dam;
        if(CurrentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    public void MeleeAttack()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, meleeRange)){
            Debug.Log(hit.collider.gameObject.name + " was hit!");
            hit.collider.GetComponent<Player>()?.TakeDamage(Power);
        }
    }
}