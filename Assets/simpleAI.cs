using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class simpleAI : MonoBehaviour
{
    public static Queue<GameObject> bulletDeck = new Queue<GameObject>();
    public Transform firepoint;
    public GameObject bulletPrefab;

    float forceValue = 15f;
    float waitTillNextFire;
    GameObject bullet;
    Rigidbody2D rb;
    [SerializeField] GameObject target;
    NavMeshAgent agent;
    bool chasePlayer = true;
    float attackDelay = 1f;
    float time;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        time = 0f;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, agent.transform.position);
        if (distance <= 10)
        {
            agent.isStopped = true;
            chasePlayer = false;
            facePlayer();
            //1sec pause
            time = time + 1 * Time.deltaTime;
            if(time >= attackDelay)
            {
                //attaking
                if (waitTillNextFire <= 0)
                {
                    attack();
                }
                waitTillNextFire -= Time.deltaTime * forceValue;
            }
            
        }
        //chasing
        if (distance > 10)
        {
            agent.isStopped = false;
            agent.SetDestination(target.transform.position);
        }
    }

    private void attack()
    {
        bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bulletDeck.Enqueue(bullet);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * forceValue, ForceMode2D.Impulse);
        waitTillNextFire = 6f;
    }
    private void facePlayer()
    {
        Vector3 lookDirection = (target.transform.position - agent.transform.position).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
   
}
