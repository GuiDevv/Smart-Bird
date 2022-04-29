using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class PlayScript
{
    // A Test behaves as an ordinary method

    GameObject player;
    GameObject generator;
    Transform playerInitialTransform;

    //Solução: Carregar a Scene que contém o Player
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("SmartBird");
    }

    public void SetupPlayerInfo()
    {
        player = Object.FindObjectOfType<BirdAgent>().gameObject;
        playerInitialTransform = player.transform;
    }

    public void SetupGeneratorInfo()
    {
        generator = Object.FindObjectOfType<RealGenerator>().gameObject;
    }

    //Teste: Verificar se o Player existe na Scene
    [Test]
    public void Test_1_VerifyPlayerInScene()
    {
        Assert.That(Object.FindObjectOfType<BirdAgent>(), Is.Not.Null);

        if (Object.FindObjectOfType<BirdAgent>())
            SetupPlayerInfo();
    }

    [Test]
    public void Test_2_VerifyGeneratorInScene()
    {
        Assert.That(Object.FindObjectOfType<RealGenerator>(), Is.Not.Null);

        if (Object.FindObjectOfType<RealGenerator>())
            SetupGeneratorInfo();
    }

    [Test]
    //Teste: Verifica se o Player está ímóvel no início do jogo
    public void Test_3_VerifyIfGravityIsDisabled()
    {
        Assert.That(player.GetComponent<Rigidbody2D>().gravityScale, Is.EqualTo(0));
    }


    [UnityTest]
    public IEnumerator Test_4_VerifyIfPlayerIsJumping()
    {
       
        GameObject bird = Object.FindObjectOfType<BirdAgent>().gameObject;
        Transform transform = bird.transform;

        SetupPlayerInfo();

        bird.GetComponent<BirdAgent>().FlappyJump();
        //player.GetComponent<BirdAgent>().FlappyJump();
        //player.transform.position.y = 30;
        yield return new WaitForSeconds(0.3f);
        Assert.AreNotEqual(playerInitialTransform.position, bird.transform.position);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Test_0_BirdMovement()
    {
        yield return null;
    }

}
