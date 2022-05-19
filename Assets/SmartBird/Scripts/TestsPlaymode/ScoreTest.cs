using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ScoreTest
{
    // A Test behaves as an ordinary method
    [Test]
    [TestCase(1,16,16)]
    [TestCase(2,24,48)]
    [TestCase(1,33,33)]
    [TestCase(2,8,16)]
    public void CalculateScore_Test(int gameMode, int wallsPassed, int expectedScore)
    {
        var scoreCalculator = new ScoreCalculator();
        

        var score = scoreCalculator.CalculateScore(gameMode,wallsPassed);

        Assert.That(score,Is.EqualTo(expectedScore));
    }

    [Test]
    public void CalculateScore_Test2()
    {
        var scoreCalculator = new ScoreCalculator();
        var expectedScore = 24 * 2;

        var score = scoreCalculator.CalculateScore(2,24);

        Assert.That(score,Is.EqualTo(expectedScore));
    }

    
}
