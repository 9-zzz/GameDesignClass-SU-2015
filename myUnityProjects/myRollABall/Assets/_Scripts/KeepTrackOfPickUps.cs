using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeepTrackOfPickUps : MonoBehaviour
{

    public Object[] pickUps;
    public bool collectedAllPickUps = false;
    public static int levelIndex = 2;

    // Use this for initialization
    void Start()
    {
        pickUps = GameObject.FindGameObjectsWithTag("PickUp");
        GetComponent<Slider>().maxValue = pickUps.Length;
    }

    // Update is called once per frame
    void Update()
    {
        checkIfAllEnemiesAreDead();
        this.GetComponent<Slider>().value = pickUps.Length;

        if (collectedAllPickUps)
        {
            Application.LoadLevel(levelIndex);
            levelIndex++;
        }
    }

    void checkIfAllEnemiesAreDead()
    {
        pickUps = GameObject.FindGameObjectsWithTag("PickUp");

        if (pickUps.Length == 0)
            collectedAllPickUps = true;
    }

}