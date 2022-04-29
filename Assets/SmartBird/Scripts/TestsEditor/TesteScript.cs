using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TesteScript
{
    // A Test behaves as an ordinary method
    [Test]
    [TestCase(20, 1, 20)]
    public void TestMultiply(int value, int multiply, int expected)
    {
        int lastValue = value * multiply;
        // Use the Assert class to test conditions
        Assert.AreEqual(lastValue, expected);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TesteScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
