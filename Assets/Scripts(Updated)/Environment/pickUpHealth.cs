using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickUpHealth : MonoBehaviour
{
    Slider health;
    // Start is called before the first frame update
    bool canCollect = false;
    bool isCollected = false;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GameObject.Find("healthBar").GetComponent<Slider>();
    }
    private void Update()
    {
        
        if (!isCollected && canCollect)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isCollected = true;
                health.value += 20f;
                Debug.Log("health collected");
                Destroy(rb.gameObject);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canCollect = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canCollect = false;
        }
    }
}
