using UnityEngine;
using System.Collections;

public class LowPolyAsteroid : MonoBehaviour
{
    public GameObject shieldPickUp;
    public float speed;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {

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

            //upon randomness
            if (Random.Range(0, 4) == 1)
                Instantiate(shieldPickUp, transform.position, Quaternion.identity);
        }

        //Destroy(other.gameObject);
        //Destroy(gameObject);
    }

}