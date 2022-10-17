using System.Collections;
using UnityEngine;

public class DestoryBullet : MonoBehaviour
{
    float timerOne;
    float timerTwo;
    float delayTime;
    float timerThree;
    private void Start()
    {
        timerOne = 0f;
        timerTwo = 0f;
        timerThree = 0f;
        delayTime = 1f;
    }
    void Update()
    {
        timerOne = timerOne + 1f * Time.deltaTime;
        timerTwo = timerTwo + 1f * Time.deltaTime;
        timerThree = timerThree + 1f * Time.deltaTime;
        if (timerThree >= 6f)
        {
            if (bulletfire.bulletDeck.Count != 0 && timerOne >= delayTime)
            {
                Destroy(bulletfire.bulletDeck.Peek());
                bulletfire.bulletDeck.Dequeue();
                timerOne = 0;
            }
            if (typeTwoAI.bulletDeck.Count != 0 && timerTwo >= delayTime)
            {
                Destroy(typeTwoAI.bulletDeck.Peek());
                typeTwoAI.bulletDeck.Dequeue();
                timerTwo = 0;

            }
        }

    }

    //IEnumerator destroyBullet()
    //{
    //    while (bulletfire.bulletDeck.Count != 0 || typeTwoAI.bulletDeck.Count != 0)
    //    {
    //        yield return new WaitForSeconds(2.5f);
    //        if (bulletfire.bulletDeck.Count != 0)
    //        {
    //            Destroy(bulletfire.bulletDeck.Peek());
    //            bulletfire.bulletDeck.Dequeue();
    //        }
    //        else if(typeTwoAI.bulletDeck.Count != 0)
    //        {
    //            Destroy(typeTwoAI.bulletDeck.Peek());
    //            typeTwoAI.bulletDeck.Dequeue();

    //        }
    //    }
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy")
    //    {
    //        Destroy(collision.gameObject);
    //    }


    //}
}
