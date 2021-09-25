using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameEvent(params object[] p);
/// <summary>
/// This class stores events and handles access to them
/// </summary>
public class EventBus
{
    private static Dictionary<string, GameEvent> events = new Dictionary<string, GameEvent>();

    public static void Invoke(string eventID, params object[] p)
    {
        events[eventID]?.Invoke(p);
    }

    public static void RegisterListner(string eventID, GameEvent @event)
    {
        if(events.ContainsKey(eventID))
        {
            events[eventID] += @event;
        }
        else
        {
            Debug.Log("Registering new event with ID: " + eventID);
            events.Add(eventID, new GameEvent(@event));
        }
    }
}
