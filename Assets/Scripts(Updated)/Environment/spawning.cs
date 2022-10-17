using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawning : MonoBehaviour
{
    public Transform[] spwanPoints;
    public GameObject[] itemList;
    public GameObject[] enemyList;//NORMALS;
    public GameObject[] waveEnemyList; //SPECIAL
    public Slider levelBar;
    public static List<Transform> deadEnemyTransformList = new List<Transform>();
    public static bool playerIsDead = false;
    GameObject enemy;
    bool itsNotWave = true; 
    public int count = 10;
    int enemySelect;
    int positionSelect;// random generate index for spawnpoint list
    float time;
    float delay;
    private void Awake()
    {
        levelBar.value = 0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        delay = 3.5f;
        //while (!onDeath.playerIsDead && itsNotWave)
        //{
        //    StartCoroutine(regularSpawning());
        //}
    }
    void regularSpawning()
    {
        positionSelect = UnityEngine.Random.Range(0, spwanPoints.Length);
        enemySelect = UnityEngine.Random.Range(0, enemyList.Length);
        enemy = Instantiate(enemyList[enemySelect], spwanPoints[positionSelect].position, enemyList[enemySelect].transform.rotation);
    }
    public void increaseProgress(float v)
    {
        levelBar.value += v;
    }
    void Update()
    {
        time = time + 1 * Time.deltaTime;
        if(!onDeath.playerIsDead && itsNotWave && !onDeath.levelComplete)
        {
            if(time >= delay)
            {
                regularSpawning();
                time = 0;
            }
        }
       // Time.timeScale = 1;
        
        if (levelBar.value >= 150)
        {
            FindObjectOfType<GameManager>().LevelComplete();
            FindObjectOfType<playerController>().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            onDeath.levelComplete = true;
        }
        
        if (levelBar.value == 70f && itsNotWave)
        {
            //wave
            itsNotWave = false;
            wave(count);
        }
        
        if (levelBar.value >= 90f)
        {
            //delay
            itsNotWave = true;
        }
    }
    private void FixedUpdate()
    {
        
    }

    void wave(int count)
    {
        for(int i = count; i > 0; i--)
        {
            //enemey select 
            enemySelect = UnityEngine.Random.Range(0, waveEnemyList.Length);
            //position select
            positionSelect = UnityEngine.Random.Range(0, spwanPoints.Length);
            Instantiate(waveEnemyList[enemySelect], spwanPoints[positionSelect].position, waveEnemyList[enemySelect].transform.rotation);
        }
    }

    //void wave(int n1,int n2,int n3)
    //{
        
    //    while (n1!=0)
    //    {
    //        waveSpwanpoints = UnityEngine.Random.Range(0, spwanPoints.Length);
    //        Instantiate(bot1, spwanPoints[waveSpwanpoints].position, bot1.transform.rotation);
    //        n1--;
    //    }
    //    while (n2!=0)
    //    {
            
    //        waveSpwanpoints = UnityEngine.Random.Range(0, spwanPoints.Length);
    //        Instantiate(bot2, spwanPoints[waveSpwanpoints].position, bot2.transform.rotation);
    //        n2--;
    //    }
    //    while (n3!=0)
    //    {
    //        waveSpwanpoints = UnityEngine.Random.Range(0, spwanPoints.Length);
    //        Instantiate(bot3, spwanPoints[waveSpwanpoints].position, bot3.transform.rotation);
    //        n3--;
    //    }
    //    levelBar.value += 1f;
    //    wave1 = false;
    //}
    
   
}
