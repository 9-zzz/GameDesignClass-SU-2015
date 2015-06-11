using UnityEngine;
using System.Collections;

public class AutoRotate : MonoBehaviour
{

    public float x = 0;
    public float y = 0;
    public float z = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * (Time.deltaTime * x), Space.Self);
        transform.Rotate(Vector3.up * (Time.deltaTime * y), Space.Self);
        transform.Rotate(Vector3.forward * (Time.deltaTime * z), Space.Self);
    }

}