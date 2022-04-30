using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealGenerator : MonoBehaviour
{
    GameObject newWall;
    public GameObject player;
    public GameObject wall;
    public List<GameObject> allWals = new List<GameObject>();
    float minimalDistance;
    float distanceBetweenWalls;

    // Start is called before the first frame update
    void Start()
    {
        SetSpawnDistance(10.5f - 7f);
        //StartCoroutine(SpawnWalls());
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < allWals.Count; i++)
        {
            if (allWals[i].transform.position.x < (player.transform.position.x - 10))
            {
                GameObject wall = allWals[i].gameObject;
                allWals.Remove(wall);                
                Destroy(wall);
            }
        }

        if (newWall != null)
        {
            if (newWall.transform.position.x < 10.5f - minimalDistance)
                SpawnWall();
        }
        else 
            SpawnWall();
        

    }

    public void SetSpawnDistance(float distance)
    {
        minimalDistance = distance;
    }

    public float CalculateDistance(float x1, float x2)
    {
        if (x2 - x1 < 0)
            return (x2 - x1) * -1;
        else
            return (x2 - x1);
    }

    public void resetWalls()
    {
        for (int i = 0; i < allWals.Count; i++)
        {
            Destroy(allWals[i]);
        }
        allWals.Clear();
    }

    public GameObject getNextPipe(GameObject bird)
    {
        for (int i = 0; i < allWals.Count; i++)
        {
            if (allWals[i].transform.position.x > bird.transform.position.x)
            {
                return allWals[i].gameObject;
            }
        }

        return null;
    }

    public void SpawnWall()
    {
        float inc = Random.Range(-1.9f, 1.9f);
        Vector3 position = new Vector3(10.5f, 1.0f + inc, 0.0f);
        newWall = Instantiate(wall, position, new Quaternion(0, 0, 0, 0));
        allWals.Add(newWall);
    }
}
