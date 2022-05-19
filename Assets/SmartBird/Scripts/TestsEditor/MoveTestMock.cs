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
    public IEnumerator Test_MovingCorrectly()
    {
        var transform = new GameObject().transform;
        Vector3 dir = new Vector3(-1, 0, 0);
        Vector2 force = new Vector2(-250f, 0f);
        Vector3 pos = new Vector3(10.5f, 0, 0.0f);

        var mover = new WallsMocking(dir, force, pos);
        yield return null;
    }
}
