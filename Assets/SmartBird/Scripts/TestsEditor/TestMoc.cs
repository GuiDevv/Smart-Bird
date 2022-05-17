using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestMoc
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestMockScoreCount(int pCount, int gMode, int expectedResult)
    {
        var pointCounter = new Mock<IPointCounter>();
       

        pointCounter.Setup(c => c.pipeCount).Returns(pCount);
        pointCounter.Setup(c => c.gamemode).Returns(gMode);

        var score = new ScoreMoc();

        var result = score.calculatePlayerPoints(pointCounter.Object);

        Assert.That(result, Is.EqualTo(expectedResult));

        pointCounter.VerifyGet(c => c.pipeCount);
        pointCounter.VerifyGet(c => c.gamemode);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestMocWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}



