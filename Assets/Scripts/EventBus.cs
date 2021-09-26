using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameEvent(ulong objectID, params object[] p);

public class EventBus
{
    public static GameEvent AttemptJoinEvent;

    public static GameEvent ClientConnectEvent;
}
