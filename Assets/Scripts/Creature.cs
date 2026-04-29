using UnityEngine;

public class Creature: MonoBehaviour
{
    public string Name;
    public int MaxHealth = 20;
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
}