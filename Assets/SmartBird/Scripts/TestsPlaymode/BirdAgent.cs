using System.Collections.Generic;
using UnityEngine;

public class BirdAgent : MonoBehaviour
{
    Rigidbody2D body;
    public WallMovement pipe;
    public RealGenerator generator;
    public Vector2 force = new Vector2(0.0f, 300.0f);
    Vector3 initialPosition;
    bool pressioned;
    public float counter;

    //Precisamos da distância entre o chão e o top
    const float height = 4.5f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        counter += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            FlappyJump();
        }
    }

    public void ResetBird()
    {
        body.velocity = Vector3.zero;
        transform.position = initialPosition;
        counter = 0;
        pipe.resetPosition();
        generator.resetWalls();
    }

    public float forceMultiplier = 10;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PointZone")
        {
            PlayerInfo.score += 1;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            PlayerInfo.score = 0;
            ResetBird();
        }

    }

    public void FlappyJump()
    {
        body.GetComponent<Rigidbody2D>().gravityScale = 0;
        body.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        body.GetComponent<Rigidbody2D>().AddForce(force);
        body.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    public void ChangeForce(float newForce)
    {
        force.y = newForce;
    }
}
