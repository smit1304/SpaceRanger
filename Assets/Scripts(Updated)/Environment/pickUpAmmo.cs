using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpAmmo : MonoBehaviour
{
    bool canCollect = false;
    bool isCollected = false;
    private void Update()
    {

        if (!isCollected && canCollect)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isCollected = true;
                bulletfire.acssesAmmo += 40;
                Debug.Log("ammo collected");
                Destroy(gameObject);
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
