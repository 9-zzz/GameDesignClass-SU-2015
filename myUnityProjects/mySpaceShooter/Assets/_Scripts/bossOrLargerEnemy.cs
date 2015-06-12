using UnityEngine;
using System.Collections;

public class bossOrLargerEnemy : MonoBehaviour
{

    float speed = -2;

    public GameObject bullet;
    public Transform sp;
    public Transform sp2;
    public float fireRate;
    public bool enableWeapons = false;

    private float nextFire;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        StartCoroutine(weaponsSwitch());
    }

    IEnumerator weaponsSwitch()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            enableWeapons = false;
            yield return new WaitForSeconds(1.0f);
            enableWeapons = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enableWeapons)
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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (other.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }

        //Destroy(other.gameObject);
        //Destroy(gameObject);
    }

}