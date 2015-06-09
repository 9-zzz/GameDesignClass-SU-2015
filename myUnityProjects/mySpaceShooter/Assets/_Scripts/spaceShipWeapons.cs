using UnityEngine;
using System.Collections;

public class spaceShipWeapons : MonoBehaviour
{

    public GameObject defaultBullet;
    public GameObject sp1;
    public GameObject sp2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.X))
        {
            Instantiate(defaultBullet, sp1.transform.position, transform.rotation);
            Instantiate(defaultBullet, sp2.transform.position, transform.rotation);
        }
    }

}