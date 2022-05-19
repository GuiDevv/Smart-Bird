using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class MovementTestScript
{
    // A Test behaves as an ordinary method

    GameObject player;

    //Solu��o: Carregar a Scene que cont�m o Player
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("SmartBird");
    }

    //Teste: Verificar se o Player existe na Scene
    [Test]
    public void Test_1_VerifyIfPlayerExistInScene()
    {
        //Arrange
        if (Object.FindObjectOfType<BirdAgent>())
            SetupPlayerInfo();

        //Assert
        Assert.That(Object.FindObjectOfType<BirdAgent>(), Is.Not.Null);

        
    }

    public void SetupPlayerInfo()
    {
        player = Object.FindObjectOfType<BirdAgent>().gameObject;
    }


    //Teste: Verifica se o Player possu� um RigidBody2D
    [Test]
    public void Test_2_VerifyIfPlayerHasRigidbody2D()
    {
        //Assert
        Assert.IsNotNull(player.GetComponents<Rigidbody2D>());
    }

    [Test]
    //Teste: Verifica se o Player est� �m�vel no in�cio do jogo
    public void Test_3_VerifyIfGravityIsEnabled()
    {
        //Act
        player.GetComponent<Rigidbody2D>().gravityScale = Object.FindObjectOfType<BirdAgent>().gameObject.GetComponent<Rigidbody2D>().gravityScale;
        
        //Assert
        Assert.That(player.GetComponent<Rigidbody2D>().gravityScale, Is.EqualTo(1));
    }

    //Teste: Verifica se foi poss�vel aterar a for�a do pulo
    [Test]
    [TestCase (300.0f)]
    public void Test_4_ChangeJumpForce(float expectedForce)
    {   //Arrange
        GameObject bird = GameObject.FindObjectOfType<BirdAgent>().gameObject;
            
        //Act
        bird.GetComponent<BirdAgent>().ChangeForce(expectedForce);
        
        //Assert
        Assert.AreEqual(expectedForce, GameObject.FindObjectOfType<BirdAgent>().gameObject.GetComponent<BirdAgent>().force.y);
    }

    //Teste: Verifica se o Player pula ao utilizar a a��o
    [UnityTest]
    public IEnumerator Test_5_VerifyIfPlayerIsJumping()
    {
        //Arrange
        GameObject bird = Object.FindObjectOfType<BirdAgent>().gameObject;
        Vector3 position = new Vector3();
        position = bird.transform.position;

        //Act
        bird.GetComponent<BirdAgent>().FlappyJump();
        yield return new WaitForSeconds(1f);

        //Assert
        Assert.AreNotEqual(position, bird.transform.position);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Test_0_ScriptWithEnumeratorPasses()
    {
        yield return null;
    }

}
