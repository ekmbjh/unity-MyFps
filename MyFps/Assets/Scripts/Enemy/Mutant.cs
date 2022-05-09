using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mutant : MonoBehaviour
{
    public Transform thePlayer;

    private NavMeshAgent agent;

    public Mutantstate mstate = Mutantstate.M_IDLE;
    [HideInInspector]
    public float health;
    public float startHealth = 20f;
    public bool isDead = false;

    public float damage = 5f;
    public float moveSpeed = 0.4f;
    public float attackRange = 1.5f;
    public float attackDamage = 5f;
    public float attackTimer = 2f;
    public float attackCountdown = 0f;

    public AudioSource bgm01;
    public AudioSource jumpScare;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();

        health = startHealth;
        ChangeState(Mutantstate.M_IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (health <= 0)
        {
            this.GetComponent<Animator>().SetInteger("mState", (int)zState.Z_DEAD);
        }

        //Vector3 target = new Vector3(thePlayer.position.x, transform.position.y, thePlayer.position.z);
        //Vector3 dir = target - transform.position;
        float distance = Vector3.Distance(thePlayer.position, transform.position);

        switch (mstate)
        {
            case Mutantstate.M_IDLE:
                if (distance <= attackRange)
                {
                    ChangeState(Mutantstate.M_ATTACK);
                    return;
                }
                break;
            case Mutantstate.M_WALK:
                if (distance <= attackRange)
                {
                    ChangeState(Mutantstate.M_ATTACK);
                    return;
                }
                agent.SetDestination(thePlayer.position);
                break;
            case Mutantstate.M_ATTACK:
                if (distance > attackRange)
                {
                    ChangeState(Mutantstate.M_WALK);
                    return;
                }
                break;
            case Mutantstate.M_DEAD:
                break;
        }
    }

    public void Attack()
    {
        thePlayer.GetComponent<Player>().TakeDamage(attackDamage);
    }
    public void ChangeState(Mutantstate _state)
    {
        if (_state == mstate)
        {
            return;
        }

        this.mstate = _state;
        this.GetComponent<Animator>().SetInteger("mState", (int)mstate);
        agent.ResetPath();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f && !isDead)
        {
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        ChangeState(Mutantstate.M_DEAD);

        agent.ResetPath();

        this.GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 5f);

        //AudioManager.instance.PlayBgm("SHAmb");

        //this.GetComponent<Rigidbody>().isKinematic = true;

    }
}

public enum Mutantstate
{
    M_IDLE, M_WALK, M_ATTACK, M_DEAD
}