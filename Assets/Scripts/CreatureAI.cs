using System.Collections;
using UnityEngine;

public class CreatureAI : MonoBehaviour
{
    public float patrolRange = 1.5f;
    public GameObject markerPrefab;
    public float sightRange = 5f;
    public float chaseRange = 12;
    IEnumerator currentState;
    public LayerMask sightMask;
    public Creature creature;
    public Player player;
    //public enum State {Idle, Wandering, Chasing, Attacking}
    //public State CurrentState;
    void Start()
    {
        //CurrentState = State.Wandering;
        //currentState = WanderingStateRoutine();
        StartCoroutine(WanderingStateRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ChangeState(IEnumerator newState)
    {
        if(currentState != null)
        {
            StopCoroutine(currentState);
        }
        currentState = newState;
        StartCoroutine(currentState);
    }
    IEnumerator ChaseStateRoutine()
    {
        while (true)
        {
            creature.MoveTowards(player.transform.position);
            if(Vector3.Distance(transform.position, player.transform.position) < creature.meleeRange-0.5)
            {
                creature.MeleeAttack();
                yield return new WaitForSeconds(0.75f);
            }
            yield return null;
        }
    }
    IEnumerator WanderingStateRoutine()
    {
        //The creature is wandering in the environment,
        //Moving to random positions nearby, wait, and then move again.
        Vector3 homePosition = transform.position;
        while (true)
        {
            Vector3 randomPosition = homePosition + new Vector3(Random.Range(-patrolRange, patrolRange),0,Random.Range(-patrolRange, patrolRange));
            //Instantiate(markerPrefab, randomPosition, Quaternion.identity);
            Debug.Log("Random Pos: " + randomPosition);
            while (Vector3.Distance(transform.position, randomPosition) > 1)
            {
                creature.MoveTowards(randomPosition);
                if(Vector3.Distance(transform.position, player.transform.position) < sightRange)
                {
                    ChangeState(ChaseStateRoutine());
                    yield break;
                }
                yield return null; 
            }

            creature.Move(Vector3.zero);

            yield return new WaitForSeconds(2);
        }

        //yield return null;
    }
}
