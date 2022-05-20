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
    [UnityTest]
    [TestCase(-250f,1f, ExpectedResult = null)]
    public IEnumerator Test_MovingCorrectly(float forc, float dir)
    {
        var transform = new GameObject().transform;
        float force = forc;
        Vector3 pos = new Vector3(10.5f, 0, 0.0f);
        var movementDirection = new Mock<IMovementDirection>();
        movementDirection.Setup(x => x.x).Returns(dir);

        //Efetuar a mockagem da interface
        //Setar algum valor dentro dessa interface usando o Setup
        //Passar esse valor como parametro para o WallsMocking
        
        var mover = new WallsMocking(transform,force, pos,movementDirection.Object);
        mover.Move();
        
        yield return 1f;
        //Verificar se o comportamento de Move funcionou de acordo com o esperado,
        //mesmo recebendo um parametro simulado.
        Assert.AreEqual(transform.position,new Vector3(1.0f,0f,0f));
    }
}
