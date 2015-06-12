using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShieldBar : MonoBehaviour
{

    public Slider sb; // Shield Bar.
    public float depletionRate;
    public GameObject shield;
    public bool isDepleting = false;

    // Use this for initialization
    void Start()
    {
        transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(0, 0, true);
        sb = GetComponent<Slider>();
        //StartCoroutine(depleteShield());
    }

    // Update is called once per frame
    void Update()
    {

        if (sb.value <= 0)
        {
            transform.GetChild(0).GetComponent<Image>().CrossFadeAlpha(0, 0.25f, true);
        }
    }

    public void depShield()
    {
        StartCoroutine(depleteShield());
    }

    public IEnumerator depleteShield()
    {
        isDepleting = true;
        while (sb.value > 0)
        {
            yield return new WaitForSeconds(0.15f);
            sb.value -= depletionRate;
        }
        isDepleting = false;
    }

}