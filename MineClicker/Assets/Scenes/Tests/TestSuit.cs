using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuit
{

    // 1
    [UnityTest]
    public IEnumerator Is_Current_mones_int()
    {
        int curremt_money = PlayerPrefs.GetInt("Player_Current_Money");
        
        yield return new WaitForSeconds(0.1f);

        curremt_money = 1000;
        
    }






    //// A Test behaves as an ordinary method
    //[Test]
    //public void TestSuitSimplePasses()
    //{
    //    // Use the Assert class to test conditions
    //}

    //// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    //// `yield return null;` to skip a frame.
    //[UnityTest]
    //public IEnumerator TestSuitWithEnumeratorPasses()
    //{
    //    // Use the Assert class to test conditions.
    //    // Use yield to skip a frame.
    //    yield return null;
    //}
}
