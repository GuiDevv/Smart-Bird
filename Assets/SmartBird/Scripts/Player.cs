using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject player;
    public Vector2 force = new Vector2(0.0f, 500.0f);
    Vector2 zero = new Vector2(0.0f, 0.0f);
    bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FlappyJump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            PlayerInfo.score = 0;
            SceneManager.LoadScene("SampleScene");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PointZone")
        {
            PlayerInfo.score += 1;
        }
    }

    void FlappyJump()
    {
        if (!start)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
            start = true;
        }
        //player.GetComponent<Rigidbody2D>().gravityScale = 0;
        //player.GetComponent<Rigidbody2D>().velocity = zero;
        //player.GetComponent<Rigidbody2D>().AddForce(force);
        //player.GetComponent<Rigidbody2D>().gravityScale = 1;

        player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 4f, ForceMode2D.Impulse);

    }
}
