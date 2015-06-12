using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShieldPickUp : MonoBehaviour
{

    public Slider shieldBar;

    // Use this for initialization
    void Start()
    {
        shieldBar = GameObject.Find("ShieldBar").GetComponent<Slider>();
        transform.parent.GetComponent<Rigidbody>().velocity = transform.forward * -5;
        Destroy(transform.parent.gameObject, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            shieldBar.value += 10;

            if (shieldBar.value > 0)
            {
                shieldBar.transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(1, 0.25f, true);

                if (!shieldBar.GetComponent<ShieldBar>().isDepleting)
                    shieldBar.GetComponent<ShieldBar>().depShield();
            }

            //ACTIVATE SHIELD
            print("shield");
            Destroy(transform.parent.gameObject);
        }
    }

}