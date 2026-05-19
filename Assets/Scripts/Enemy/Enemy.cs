using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.ParticleSystem;

public class Enemy : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    bool activated;
    NavMeshAgent agent;
    [SerializeField]
    int hp = 100;

    [SerializeField]
    ParticleSystem[] particles;

    bool isStunned = false;

    bool giveParticles = true;

    enum state
    {
        Idle,
        Atack,
        Stuned,
        Die
    }

    state curState = Enemy.state.Idle;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        while (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
    }

    private void Update()
    {
        if (!activated) return;

        if (hp < 0)
        {
            curState = state.Die;
        }

        GetCurrentState();
        ChangeState();
    }

    private void ChangeState()
    {
            switch (curState)
            {
                case Enemy.state.Atack:
                    agent.destination = player.transform.position;
                    break;
                case Enemy.state.Stuned:
                    agent.destination = gameObject.transform.position;
                break;
                case Enemy.state.Idle:
                    agent.destination = gameObject.transform.position;
                    break;
                case Enemy.state.Die:
                    agent.enabled = false;
                break;
        }
        }

    private void GetCurrentState()
    {
        if (curState == state.Die)
        {
            return;
        }

        if (Vector3.Distance(player.transform.position, transform.position) < 1.5f)
        {
            if (!isStunned)
            {
                curState = Enemy.state.Stuned;
                StartCoroutine(StunEnemy());
            }
        }
        else
        {
            curState = Enemy.state.Atack;
        }
    }

    public void ActivateEnemy()
    {
        activated = true;
    }

    IEnumerator StunEnemy()
    {
        isStunned = true;

        player.GetComponent<PlayerScript>().AtackPlayer();
        activated = false;

        yield return new WaitForSeconds(1f);

        activated = true;
        isStunned = false;
    }

    public void AtackEnemy()
    {
        hp -= 40;

        foreach (var particle in particles)
        {
            particle.Play();
        }
    }

    public void OnParticleCollision(GameObject other)
    {

        if (hp < 0) return;

                hp -= 3;


        if(giveParticles){
            giveParticles = !giveParticles;
            particles[0].Play();
        } else {
            giveParticles = !giveParticles;
        }
    }
}
