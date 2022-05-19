using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsMocking : MonoBehaviour
{
    private Vector3 movement;// = new Vector3(-1, 0, 0);
    private Vector2 force;// = new Vector2(-250f, 0f);
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public WallsMocking(Vector3 direction, Vector2 impulseForce, Vector3 position)
    {
        movement = direction;
        force = impulseForce;
        initialPosition = position;
    }

    public void Move()
    {
        transform.gameObject.GetComponent<Rigidbody2D>().AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
