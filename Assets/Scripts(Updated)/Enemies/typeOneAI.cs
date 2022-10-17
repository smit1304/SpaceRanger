using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
//normalOne
public class typeOneAI : MonoBehaviour
{
    private Animator anim;
    NavMeshAgent agent;
    Rigidbody2D rb;
    GameObject target;
    Slider health;
    float enemyHealth = 150;
    GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        health = GameObject.Find("healthBar").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!onDeath.playerIsDead && !onDeath.levelComplete)
        {
            facePlayer();
            if (enemyHealth <= 0)
            {
                
                AudioManager.instance.Play("enemyDie");

                //progress
                FindObjectOfType<spawning>().increaseProgress(10);

                //spwan item
                int ranNo = Random.Range(0, FindObjectOfType<spawning>().itemList.Length);
                item = FindObjectOfType<spawning>().itemList[ranNo];
                if (item != null)
                {
                    Instantiate(item, agent.transform.position, item.transform.rotation);
                }
                anim.SetTrigger("death");
                Destroy(rb.gameObject);
            }
            else
            {
                float distance = Vector3.Distance(target.transform.position, agent.transform.position);
                if (distance <= 3.5f)
                {
                    //attaking
                    agent.isStopped = true;
                    anim.SetTrigger("attack");
                }
                else
                {
                    //chasing
                    anim.SetBool("run", agent.isStopped == false);
                    agent.isStopped = false;
                    agent.SetDestination(target.transform.position);
                }
            }
               
        }
    }

    private void facePlayer()
    {
        Vector3 lookDirection = (target.transform.position - agent.transform.position).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    public void damagePlayer()
    {
        Debug.Log("damage.....");
        health.value -= 5f;
       // GetComponent<playerController>().PalyerDamage();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            anim.SetTrigger("hurt");
            enemyHealth -= 30f;
            Destroy(collision.gameObject);
        }
    }
}
