using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public Camera cam;
    public Slider healthBar;

    Rigidbody2D rb;
    float v, h;
    protected Vector3 mousePosition;
    protected Vector3 lookDirection;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!onDeath.levelComplete)
        {
            Process();
            Move();
        }
    }

    private void FixedUpdate()
    {
        if (!onDeath.levelComplete)
        {
            Aiming();
        }
        
    }

    private void Aiming()
    {
        lookDirection = (mousePosition - rb.transform.position).normalized;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.transform.eulerAngles = new Vector3(0, 0, angle);
       // Debug.Log(rb.rotation);
    }

    private void Move()
    {
        rb.velocity = new Vector2(h * moveSpeed, v * moveSpeed);
        //AudioManager.instance.Play("playerWalk");
    }

    private void Process()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool inRange = collision.gameObject.CompareTag("meleEnemy");
        ;
        if (collision.gameObject.CompareTag("enemyBullet"))
        {
            healthBar.value -= 10f;
            Destroy(collision.gameObject);
        }
        
    }
}
