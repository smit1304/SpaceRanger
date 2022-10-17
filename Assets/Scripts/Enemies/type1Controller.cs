using UnityEngine;

public class type1Controller : MonoBehaviour
{
    private Animator anim;
    private GameObject player;
    private Rigidbody2D rb;
    private Vector3 playerDirection;
    private float moveSpeed = 5f;
    private float enemyHealthBar = 150f;
    private float demageDelt = 20f;
    private float minDist = 2f;
    private float approchingDist; //distance between player and eniemy
    private bool move = true;
    

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        facePlayer();
        Die();
        //distAttack();
        //if (move)
        //{
        //    moveAI(playerDirection);
        //}
        anim.SetBool("run", move == true);

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
    private void moveAI(Vector2 playerDirection)
    {
        playerDirection.Normalize();
        rb.MovePosition((Vector2)transform.position + (playerDirection * moveSpeed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            anim.SetTrigger("hurt");
            enemyHealthBar -= demageDelt;
            Destroy(collision.gameObject);
        }
    }
    
}
