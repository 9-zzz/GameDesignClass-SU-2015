using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Boid : MonoBehaviour
{

    static public List<Boid> boids;

    public Vector3 velocity;
    public Vector3 newVelocity;
    public Vector3 newPosition;

    public List<Boid> neighbors;
    public List<Boid> collisionRisks;
    public Boid closest;
    // Use this for initialization
    void Awake()
    {

        if (boids == null)
        {
            boids = new List<Boid>();
        }
        boids.Add(this);

        Vector3 randPos = Random.insideUnitSphere * boidSpawner.S.spawnRadius;
        randPos.y = 0;
        this.transform.position = randPos;
        velocity = Random.onUnitSphere;
        velocity *= boidSpawner.S.spawnVelocity;

        neighbors = new List<Boid>();
        collisionRisks = new List<Boid>();
        this.transform.parent = GameObject.Find("Boids").transform;

        Color randColor = Color.black;
        while (randColor.r + randColor.g + randColor.b < 2.0f)
        {
            randColor = new Color(Random.value, Random.value, Random.value);
        }

        Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends)
        {
            r.material.color = randColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        List<Boid> neighbors = GetNeighbors(this);

        newVelocity = velocity;
        newPosition = this.transform.position;

        Vector3 neighborVel = GetAverageVelocity(neighbors);
        newVelocity += neighborVel * boidSpawner.S.velocityMatchingAmt;

        Vector3 neighborCenterOffset = GetAveragePosition(neighbors) - this.transform.position;
        newVelocity += neighborCenterOffset * boidSpawner.S.flockCenteringAmt;

        Vector3 dist;
        if (collisionRisks.Count > 0)
        {
            Vector3 collisionAveragePos = GetAveragePosition(collisionRisks);
            dist = collisionAveragePos - this.transform.position;
            newVelocity += dist * boidSpawner.S.collisionAvoidanceAmt;
        }

        dist = boidSpawner.S.mousePos - this.transform.position;
        if (dist.magnitude > boidSpawner.S.mouseAvoidanceDist)
        {
            newVelocity += dist * boidSpawner.S.mouseAttractionAmt;
        }
        else
        {
            newVelocity -= dist.normalized * boidSpawner.S.mouseAvoidanceDist * boidSpawner.S.mouseAvoidanceAmt;
        }

    }

    void LateUpdate()
    {
        velocity = (1 - boidSpawner.S.velocityLerpAmt) * velocity + boidSpawner.S.velocityLerpAmt * newVelocity;


        if (velocity.magnitude > boidSpawner.S.maxVelocity)
        {
            velocity = velocity.normalized * boidSpawner.S.maxVelocity;
        }

        if (velocity.magnitude < boidSpawner.S.maxVelocity)
        {
            velocity = velocity.normalized * boidSpawner.S.minVelocity;
        }

        newPosition = this.transform.position + velocity * Time.deltaTime;
        newPosition.y = 0;
        this.transform.LookAt(newPosition);
        this.transform.position = newPosition;

    }

    public List<Boid> GetNeighbors(Boid boi)
    {
        float closestDist = float.MaxValue;
        Vector3 delta;
        float dist;
        neighbors.Clear();
        collisionRisks.Clear();

        foreach (Boid b in boids)
        {

            if (b == boi)
                continue;
            delta = b.transform.position - boi.transform.position;
            dist = delta.magnitude;

            if (dist < closestDist)
            {
                closestDist = dist;
                closest = b;
            }

            if (dist < boidSpawner.S.nearDist)
            {
                neighbors.Add(b);
            }

            if (dist < boidSpawner.S.collisionDist)
            {
                collisionRisks.Add(b);
            }
        }

        if (neighbors.Count == 0)
        {
            neighbors.Add(closest);
        }

        return (neighbors);

    }

    public Vector3 GetAveragePosition(List<Boid> someBoids)
    {
        Vector3 sum = Vector3.zero;
        foreach (Boid b in someBoids)
        {
            sum += b.transform.position;
        }
        Vector3 center = sum / someBoids.Count;
        return (center);
    }

    public Vector3 GetAverageVelocity(List<Boid> someBoids)
    {
        Vector3 sum = Vector3.zero;
        foreach (Boid b in someBoids)
        {
            sum += b.velocity;
        }
        Vector3 avg = sum / someBoids.Count;
        return (avg);
    }
}