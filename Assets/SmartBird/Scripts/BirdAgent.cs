using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class BirdAgent : Agent
{
    Rigidbody2D body;
    public WallMovement pipe;
    public RealGenerator generator;
    Vector2 force = new Vector2(0.0f, 300.0f);
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
    }

    public override void OnEpisodeBegin()
    {
        body.velocity = Vector3.zero;
        transform.position = initialPosition;
        counter = 0;
        pipe.resetPosition();
        generator.resetWalls();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Informações: Velocidade do Bird
        // Posição do Bird
        // Posição do Pipe
        // Informação da última ação

        float worldHeight = 11f;
        float birdNormalizedY = (transform.position.y + (worldHeight / 2f)) / worldHeight;
        sensor.AddObservation(transform.position.y);

        GameObject nextPipe = generator.getNextPipe(transform.gameObject);
        if (nextPipe != null)
        {
            sensor.AddObservation(nextPipe.transform.GetChild(2).position.x - transform.position.x);
            sensor.AddObservation(nextPipe.transform.GetChild(2).position.y - transform.position.y);
        }
        else
        {
            sensor.AddObservation(1f);
            sensor.AddObservation(1f);
        }

        sensor.AddObservation(body.velocity.y);        

    }

    public float forceMultiplier = 10;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        int press = Mathf.FloorToInt(actionBuffers.ContinuousActions[0]);

        if (press == 0)
            pressioned = false;
        if (press == 1 && !pressioned)
        {
            FlappyJump();
            pressioned = true;
        }

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetKey(KeyCode.Mouse0) ? 1f : 0f;
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PointZone")
        {
            SetReward(1f);
            PlayerInfo.score += 1;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            SetReward(-0.1f);
            PlayerInfo.score = 0;
            EndEpisode();
        }

    }

    void FlappyJump()
    {
        body.GetComponent<Rigidbody2D>().gravityScale = 0;
        body.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        body.GetComponent<Rigidbody2D>().AddForce(force);
        body.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
