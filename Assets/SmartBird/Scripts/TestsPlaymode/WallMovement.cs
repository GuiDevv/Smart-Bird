using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public Vector3 movement = new Vector3(-1, 0, 0);
    Vector2 force = new Vector2(-250f, 0f);
    public bool active = true;
    Vector3 initialPosition;
    GameObject gameObj;
    public float deltaTime;

    // Start is called before the first frame update
    void Start()
    {
        gameObj = GameObject.Find("SmartBird");
        initialPosition = transform.position;
        transform.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void resetPosition()
    {
        transform.position = initialPosition;
    }

}
