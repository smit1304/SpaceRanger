using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bulletfire : MonoBehaviour
{
    public static Queue<GameObject> bulletDeck = new Queue<GameObject>();
    public Transform firepoint;
    public GameObject bulletPrefab;
    //public Transform player;
    public Text ammoCounter;
    float forceValue = 20f;
    float waitTillNextFire;
    GameObject bullet;
    bool reload = false;
    float reloadedAmmo = 30;
    public static float acssesAmmo = 120;
    //private void Start()
    //{
    //    ammoCounter = GameObject.Find("ammoCounter").GetComponent<Text>();
    //}
    void Update()
    {
        ammoCounter.text = reloadedAmmo.ToString("0") + " / " + acssesAmmo.ToString("0");
        if (Input.GetButton("Fire1"))
        {
            //debuging 
            if(reloadedAmmo <= 0)
            {
                Debug.Log("reload");
            }
            //shooting 
            if (waitTillNextFire <= 0 && reloadedAmmo > 0 )
            {
                 shoot();
            }
            waitTillNextFire -= Time.deltaTime * forceValue;
        } 
        //reloading
        if(reloadedAmmo < 30 && Input.GetKeyDown(KeyCode.R) && acssesAmmo > 0)
        {
            acssesAmmo -= (30 - reloadedAmmo);
            reloadedAmmo += (30-reloadedAmmo);
        }
    }
    private void FixedUpdate()
    {
        if (acssesAmmo <= 0)
        {
            acssesAmmo = 0;
        }
        if (acssesAmmo >= 120)
        {
            acssesAmmo = 120;
        }
    }
    private void shoot()
    {
        // Vector2 difference = firepoint.position - bullet.transform.position;
        bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        bulletDeck.Enqueue(bullet);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up *forceValue, ForceMode2D.Impulse);
        reloadedAmmo -= 1;
        waitTillNextFire = 3f;
        AudioManager.instance.Play("bulletFire");       
    }
}
