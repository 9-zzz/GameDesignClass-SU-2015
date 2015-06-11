using UnityEngine;
using System.Collections;

public class bossOrLargerEnemy : MonoBehaviour
{

    float speed = -2;

    public GameObject bullet;
    public Transform sp;
    public Transform sp2;
    public float fireRate;

    private float nextFire;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, sp.position, sp.rotation);
            Instantiate(bullet, sp2.position, sp2.rotation);
            //GetComponent<AudioSource>().Play();
        }
    }

}