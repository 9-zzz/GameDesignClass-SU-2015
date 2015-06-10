using UnityEngine;
using System.Collections;

public class boidSpawner : MonoBehaviour
{

    static public boidSpawner S; // 1

    public int numBoids = 100;
    public GameObject boidPrefab;
    public float spawnRadius = 100f;
    public float spawnVelocity = 10f;
    public float minVelocity = 0f;
    public float maxVelocity = 30f;
    public float nearDist = 30f;
    public float collisionDist = 5f;
    public float velocityMatchingAmt = 0.01f;
    public float flockCenteringAmt = 0.15f;
    public float collisionAvoidanceAmt = -0.5f;
    public float mouseAttractionAmt = 0.01f;
    public float mouseAvoidanceAmt = 0.75f;
    public float mouseAvoidanceDist = 15f;
    public float velocityLerpAmt = 0.25f;

    public Vector3 mousePos;

    // Use this for initialization
    void Start()
    {
        S = this;

        for (int i = 0; i < numBoids; i++)
        {
            Instantiate(boidPrefab);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 mousePos2D = new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.y);
        mousePos = GetComponent<Camera>().ScreenToWorldPoint(mousePos2D);
        //mousePos = mousePos2D;
        //mousePos = GameObject.Find("spaceShip").transform.position;
    }

}