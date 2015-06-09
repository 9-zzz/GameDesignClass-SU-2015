using UnityEngine;
using System.Collections;

public class defaultBullet : MonoBehaviour
{

    public float shootForce;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * shootForce;
        //transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * 100);
    }

}