using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventManager : MonoBehaviour {
    private Dictionary<Mail, UnityEvent> eventDictionary;
    private static EventManager eventManager;
    //Note: You must add enum for acceptable items in order to invoke particular option
    //      refer to Test1.cs & TriggerTest for Examples

    //  @Instance
    //  Note:   Check whether the event manager is null and if not initialize
    public static EventManager Instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script attached to a Game Object");
                }
                else
                {
                    eventManager.Init();
                }
            }
            return eventManager;
        }
    }
    //  @Init
    //  Note:   create a dictionary using enum Mail
    void Init()
    {
        if(eventDictionary == null)
        {
            eventDictionary = new Dictionary<Mail, UnityEvent>();
        }
    }
    //  @start Listening
    //  Note:   starts listening for mail enum and and sets up a listener
    public static void StartListening(Mail eventName, UnityAction listener)
    {
        UnityEvent ThisEvent = null;
        if(Instance.eventDictionary.TryGetValue (eventName, out ThisEvent))
        {
            ThisEvent.AddListener(listener);
        }
        else
        {
            ThisEvent = new UnityEvent();
            ThisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, ThisEvent);
        }
    }
    //  @StopListening
    //  Note:   Stops listening
    public static void StopListening(Mail eventName, UnityAction listener)
    {
        if (eventManager == null) return;
        UnityEvent thisEvent = null;
        if(!Instance.eventDictionary.TryGetValue(eventName,out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }
    //  @TriggerEvent
    //  Note:   Invokes the event name from the dictionary
    public static void TriggerEvent(Mail eventName)
    {
        UnityEvent thisEvent = null;
        if(Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
}
//  @Mail
//  Note:   Add to this enum for functions to listen to for certain actions to invoke
//          and if not then there will be a runtime issue.
//          There must be action to invoke based on list like "Take Damage", "Destroy",ect
public enum Mail : short {spawn, destroy, test};