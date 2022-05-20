using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Moq;

public class MoveTestMock
{
    // A Test behaves as an ordinary method
    [Test]
    public void MoveTestMockSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [Test]
    [TestCase(250f,1f)]
    [TestCase(200f,-1f)]
    [TestCase(10f,1f)]
    [TestCase(30f,-1f)]
    public void Test_MovingCorrectly(float sp, float dir)
    {
        var transf = new GameObject().transform;
        float speed = sp;
        Vector3 pos = new Vector3(0.0f, 0.0f, 0.0f);
        var movementDirection = new Mock<IMovementDirection>();
        movementDirection.Setup(x => x.x).Returns(dir);

        //Efetuar a mockagem da interface
        //Setar algum valor dentro dessa interface usando o Setup
        //Passar esse valor como parametro para o WallsMocking
        
        var mover = new WallsMocking(transf,speed, pos,movementDirection.Object);
        mover.Move();
        
       
        //Verificar se o comportamento de Move funcionou de acordo com o esperado,
        //mesmo recebendo como parametro um objeto simulado.
        Assert.AreEqual(transf.position,new Vector3(sp * dir,0f,0f));
    }
}
