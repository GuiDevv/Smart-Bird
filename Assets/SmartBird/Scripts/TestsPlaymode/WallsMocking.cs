using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallsMocking
{
    private float speed;// = new Vector2(-250f, 0f);
    private Vector3 initialPosition;
    private Transform transformObject;
    private IMovementDirection moveDirection = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public WallsMocking(Transform trans,float impulseForce, Vector3 position, IMovementDirection moveDir) //Adicionar parametro com Interface a ser mockada
    {
        
        speed = impulseForce;
        initialPosition = position;
        moveDirection = moveDir;
        transformObject = trans;
        transformObject.position = initialPosition;
    }

    public void Move()
    {
        //Adaptar algum valor recebido pela interface dentro da funcionalidade de movimentação
        // transformObject.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveDirection.x*force,moveDirection.y*force));
        Vector2 movement = new Vector2(moveDirection.x*speed, moveDirection.y*speed);
        transformObject.Translate(movement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public interface IMovementDirection{
    public float x {get;set;}
    public float y {get;set;}


}
