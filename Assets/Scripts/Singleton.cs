/*
     File Name: Singleton.cs
     Date : 01/27/2018
     Owner: George Wulfers
     ----------------------------------
     This is the base class for the Singleton Design patterns
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton Instance;
    public static Singleton instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = new Singleton();
            }
            return Instance;
        }
    }

    protected Singleton()
    {

    }

    
}
