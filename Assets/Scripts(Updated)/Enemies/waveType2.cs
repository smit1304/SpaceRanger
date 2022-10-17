using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class waveType2 : MonoBehaviour
{
    // Start is called before the first frame update
    public static Queue<GameObject> bulletDeck = new Queue<GameObject>();
    public Transform firepoint;
    public GameObject bulletPrefab;

    Animator anim;
    float forceValue = 15f;
    float waitTillNextFire;
    GameObject bullet;
    Rigidbody2D rb;
    GameObject target;
    NavMeshAgent agent;
    float attackDelay = 1f;
    float time;
    float health = 150f;
    bool isDead = false;
    //spawning sp;
    GameObject item;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //sp = GetComponent<spawning>();
        anim = GetComponent<Animator>();
        time = 0f;
    }
    void Update()
    {
        //check if its dead or not player
        if (!onDeath.playerIsDead)
        {
            facePlayer();
            if (health <= 0)
            {
                isDead = true;
                //AudioManager.instance.Play("enemyDie");

                //progress
                FindObjectOfType<spawning>().increaseProgress(2);

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
                if (distance <= 10)
                {
                    agent.isStopped = true;
                    facePlayer();
                    //1sec pause
                    time = time + 1 * Time.deltaTime;
                    if (time >= attackDelay)
                    {
                        //attaking
                        if (waitTillNextFire <= 0)
                        {
                            anim.SetTrigger("attack");
                            attack();
                        }
                        waitTillNextFire -= Time.deltaTime * forceValue;
                    }
                    //agent.ne
                }
                //chasing
                if (distance > 10f)
                {
                    anim.SetTrigger("run");
                    agent.isStopped = false;
                    agent.SetDestination(target.transform.position);
                    //anim.SetBool("run", agent.isStopped = false);

                }
            }
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            anim.SetTrigger("hurt");
            health -= 25f;
            Destroy(collision.gameObject);
        }

    }
}
