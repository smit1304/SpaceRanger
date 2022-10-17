using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class type2Controller : MonoBehaviour
{
    private GameObject player;


    private Rigidbody2D rb;
    private Vector3 playerDirection;
    //private float moveSpeed = 10f;
    private float enemyHealthBar = 100f;
    private float demageDelt = 20f;
    private float minDist = 10f;
    private float approchingDist; //distance between player and eniemy
    private bool move = true;
    
    public static Queue<GameObject> bulletDeck = new Queue<GameObject>();
    public Transform firepoint;
    public GameObject bulletPrefab;


    private float forceValue = 15f;
    private float waitTillNextFire;
    private GameObject bullet;



    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Die();
        distAttack();
        if (waitTillNextFire <= 0 && !move)
        {
            facePlayer();
            shootPlayer();
        }
        waitTillNextFire -= Time.deltaTime * forceValue;
        

    }
    private void Die()
    {
        if (enemyHealthBar <= 0)
        {
            Destroy(rb.gameObject);
        }
    }

    private void FixedUpdate()
    {
        approchingDist = Vector3.Distance(rb.transform.position, player.transform.position);
        
    }

    private void distAttack()
    {
        if (approchingDist <= minDist)
        {
            move = false;
        }
        else
        {
            move = true;
        }

    }

    private void facePlayer()
    {
        playerDirection = (player.transform.position - rb.transform.position).normalized;
        float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    //private void moveAI(Vector2 playerDirection)
    //{
    //    playerDirection.Normalize();
    //    rb.MovePosition((Vector2)transform.position + (playerDirection * moveSpeed * Time.deltaTime));
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            enemyHealthBar -= demageDelt;
            Destroy(collision.gameObject);
        }
    }
    private void shootPlayer()
    {
        bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bulletDeck.Enqueue(bullet);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * forceValue, ForceMode2D.Impulse);
        waitTillNextFire = 6f;
    }

    IEnumerator DestoryBullet()
    {
        while (bulletDeck.Count != 0)
        {
            yield return new WaitForSeconds(2.5f);
            Destroy(bulletDeck.Peek());
            bulletDeck.Dequeue();
        }
    }
}
