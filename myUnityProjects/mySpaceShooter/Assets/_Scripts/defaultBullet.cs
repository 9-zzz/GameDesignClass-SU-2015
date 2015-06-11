using UnityEngine;
using System.Collections;

public class defaultBullet : MonoBehaviour
{

    private Done_GameController gameController;

    public float lt;
    public float speed;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, lt); // Lifetime

        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<Done_GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }

        //if (explosion != null) Instantiate(explosion, transform.position, transform.rotation);

        if (other.tag == "Player")
        {
            //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        //gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}