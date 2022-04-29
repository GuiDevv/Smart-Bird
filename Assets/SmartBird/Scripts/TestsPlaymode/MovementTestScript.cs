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

    //Solução: Carregar a Scene que contém o Player
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("SmartBird");
    }

    //Teste: Verificar se o Player existe na Scene
    [Test]
    public void Test_1_VerifyIfPlayerExistInScene()
    {
        Assert.That(Object.FindObjectOfType<BirdAgent>(), Is.Not.Null);

        if (Object.FindObjectOfType<BirdAgent>())
            SetupPlayerInfo();
    }

    public void SetupPlayerInfo()
    {
        player = Object.FindObjectOfType<BirdAgent>().gameObject;
    }


    //Teste: Verifica se o Player possuí um RigidBody2D
    [Test]
    public void Test_2_VerifyIfPlayerHasRigidbody2D()
    {
        Assert.IsNotNull(player.GetComponents<Rigidbody2D>());
    }

    [Test]
    //Teste: Verifica se o Player está ímóvel no início do jogo
    public void Test_3_VerifyIfGravityIsDisabled()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        Assert.That(player.GetComponent<Rigidbody2D>().gravityScale, Is.EqualTo(0));
    }

    //Teste: Verifica se foi possível aterar a força do pulo
    [Test]
    [TestCase (20)]
    public void Test_4_ChangeJumpForce(float expectedForce)
    {
        GameObject bird = GameObject.FindObjectOfType<BirdAgent>().gameObject;
        bird.GetComponent<BirdAgent>().ChangeForce(expectedForce);

        Assert.AreEqual(expectedForce, bird.GetComponent<BirdAgent>().force.y);
    }

    //Teste: Verifica se o Player pula ao utilizar a ação
    [UnityTest]
    public IEnumerator Test_5_VerifyIfPlayerIsJumping()
    {
        GameObject bird = Object.FindObjectOfType<BirdAgent>().gameObject;
        Vector3 position = new Vector3();
        position = bird.transform.position;

        bird.GetComponent<BirdAgent>().FlappyJump();

        yield return new WaitForSeconds(1f);
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
