using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Test1 : MonoBehaviour {
    private UnityAction someListener;
    // Note:    Sets the someLister to the dictionary
    //          You must have an OnEnable() & OnDisable for the objects to function in the game Manager
    void Awake()
    {
        someListener = new UnityAction(SomeFunc);
    }

    void OnEnable()
    {
        EventManager.StartListening(Mail.test, someListener);
    }
   void OnDisable()
    {
        EventManager.StopListening(Mail.test, someListener);
    }
    // @SomeFunc()
    // Note:    This will be method to invoke
    void SomeFunc()
    {
        Debug.Log("Some Funct was called");
    }
}
