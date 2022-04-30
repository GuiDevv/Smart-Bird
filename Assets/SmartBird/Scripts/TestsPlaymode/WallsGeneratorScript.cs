using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class WallsGeneratorScript
{
    [SetUp]
    public void SetUp()
    {
        SceneManager.LoadScene("SmartBirdNoBird");
    }

    // A Test behaves as an ordinary method
    [Test]
    public void Test_1_VerifyIfGeneratorExistInScene()
    {
        Assert.IsNotNull(GameObject.FindObjectOfType<RealGenerator>());
    }

    [UnityTest]
    [TestCase (3f, ExpectedResult = null)]
    public IEnumerator Test_2_VerifyDistanceBetweenWalls(float expectedDistance)
    {
        var generator = GameObject.FindObjectOfType<RealGenerator>();

        generator.SetSpawnDistance(expectedDistance);

        yield return new WaitForSeconds(3f);

        float wall1 = generator.allWals[0].transform.position.x;
        float wall2 = generator.allWals[1].transform.position.x;

        float result = generator.CalculateDistance(wall1, wall2);
        
        Assert.That(result, Is.InRange(expectedDistance - 0.01f, expectedDistance + 0.01f));

    }

    [UnityTest]
    [TestCase (-1f, 1f, ExpectedResult = null)]
    [TestCase(-2f, 1.5f, ExpectedResult = null)]
    [TestCase(-1.8f, 1.7f, ExpectedResult = null)]
    [TestCase(-0.3f, 0.8f, ExpectedResult = null)]

    public IEnumerator Test_3_VerifyWallsVerticalOffset(float minDistance, float maxDistance)
    {
        //Arrange
        var generator = GameObject.FindObjectOfType<RealGenerator>();

        //Act
        generator.SetSpawnDistance(3);
        generator.SetVerticalOffset(minDistance, maxDistance);

        yield return new WaitForSeconds(3f);

        //Assert
        for (int i = 1; i < generator.allWals.Count; i++)
        {            
            Assert.That(generator.GetWallVerticalPosition(i), Is.InRange(minDistance, maxDistance));            
        }

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator WallsGenerator1WithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
