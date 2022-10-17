using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onDeath : MonoBehaviour
{
    Slider health;
    public static bool playerIsDead = false;
    public static bool levelComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.Find("healthBar").GetComponent<Slider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerIsDead)
        {
            if (health.value <= 0)
            {
                playerIsDead = true;
                Destroy(FindObjectOfType<playerController>().GetComponent<Rigidbody2D>().gameObject);
                FindObjectOfType<GameManager>().gameOver();
            }
        }
        
        
    }
}
