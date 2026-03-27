using NUnit.Framework.Internal.Filters;
using UnityEngine;
using UnityEngine.AI;

public class DogBehaviour : MonoBehaviour
{
    [SerializeField]
    public bool isActive = false;
    private GameObject player;
    private NavMeshAgent agent;
    private bool doingSomething = false;
    private GameObject dogsSpot;
    private GameObject dogsSpot2;
    [SerializeField] Animator animator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        dogsSpot = player.GetComponent<PlayerScript>().dogSpot;
        dogsSpot2 = player.GetComponent<PlayerScript>().dogSpot2;
    }

    void Update()
    {
        animator.SetBool("IsWalking", agent.velocity.magnitude > 0.1f);

        if (player != null)
        {
            if (!isActive || doingSomething) return;

            agent.destination = dogsSpot.transform.position;
            if (agent.remainingDistance > 5f)
            {
                agent.destination = dogsSpot2.transform.position;
            }
        }
        else
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    public void GoTowards(Vector3 destination)
    {
        if (!isActive) return;
        if(doingSomething)
        {
            doingSomething = false;
        } else
        {
            doingSomething = true;
            agent.destination = destination;
        }



    }
}
