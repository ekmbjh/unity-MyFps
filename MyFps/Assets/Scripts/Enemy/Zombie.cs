using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public zState state = zState.Z_IDLE;

    public Transform thePlayer;

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
        this.GetComponent<Animator>().SetInteger("ZState", (int)zState.Z_IDLE);
        health = startHealth;
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
            this.GetComponent<Animator>().SetInteger("ZState", (int)zState.Z_DEAD);
        }

        Vector3 target = new Vector3(thePlayer.position.x, transform.position.y, thePlayer.position.z);
        Vector3 dir = target - transform.position;
       
        switch (state)
        {
            case zState.Z_IDLE:
                break;
            case zState.Z_WALK:
                transform.LookAt(target);
                transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
                break;
            case zState.Z_ATTACK:
                if (attackCountdown <= 0f)
                {
                    thePlayer.GetComponent<Player>().TakeDamage(attackDamage);
                    attackCountdown = attackTimer;
                }
                attackCountdown -= Time.deltaTime;
                break;
            case zState.Z_DEAD:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ChangeState(zState.Z_ATTACK);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ChangeState(zState.Z_WALK);
        }
    }

    public void ChangeState(zState _state)
    {
        if (_state == state)
        {
            return;
        }

        state = _state;
        this.GetComponent<Animator>().SetInteger("ZState", (int)state);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Zombie health: " + health);

        if (health <= 0f && !isDead)
        {
            Die();
        }
    }
    private void Die()
    {
        isDead = true;
        ChangeState(zState.Z_DEAD);

        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject, 5f);

        AudioManager.instance.PlayBgm("SHAmb");
    }
}

public enum zState
{
    Z_IDLE,
    Z_WALK,
    Z_ATTACK,
    Z_DEAD
}