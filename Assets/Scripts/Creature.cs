using UnityEngine;

public class Creature: MonoBehaviour
{
    public string Name;
    public int MaxHealth;
    public int CurrentHealth;
    public int Speed;
    public int Power;
    public enum State {Idle, Wandering, Chasing, Attacking}
    public State CurrentState;
    public bool IsAlly = false;
    void Start()
    {
        CurrentHealth = MaxHealth;
        CurrentState = State.Idle;
    }

    void Update()
    {
        
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
}