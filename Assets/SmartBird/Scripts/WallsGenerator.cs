using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsGenerator : MonoBehaviour
{
    GameObject newWall;
    public GameObject player;
    public GameObject wall;
    List<GameObject> allWals = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
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
            if (newWall.transform.position.x < 10.5f - 7f)
                SpawnWall();
        }
        else 
            SpawnWall();
        

    }

    //IEnumerator SpawnWalls()
    //{
    //    while (enabled)
    //    {            
    //        yield return new WaitForSeconds(3);
    //        Vector3 position = new Vector3(10.5f, 2.3f, 0.0f);
    //        newWall = Instantiate(wall, position, new Quaternion(0, 0, 0, 0));
    //        allWals.Add(newWall);
    //    }

    //}

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
        Vector3 position = new Vector3(10.5f, 2.3f, 0.0f);
        newWall = Instantiate(wall, position, new Quaternion(0, 0, 0, 0));
        allWals.Add(newWall);
    }
}
