using MLAPI.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LogicalSide
{
    CLIENT,
    SERVER
}

public delegate void GameEvent(object callbackSource, LogicalSide sideCalledFrom); 
public class EventBus
{
    public static GameEvent testEvent;

    public static void Invoke(GameEvent toInvoke, object callbackSource)
    {
        ClientToServerRpc(toInvoke, callbackSource);
        ServerToClientRpc(toInvoke, callbackSource);
    }

    [ClientRpc]
    static void ServerToClientRpc(GameEvent toInvoke, object callbackSource)
    {
        toInvoke.Invoke(callbackSource, LogicalSide.CLIENT);//invoke on client
    }

    [ServerRpc]
    static void ClientToServerRpc(GameEvent toInvoke, object callbackSource)
    {
        toInvoke.Invoke(callbackSource, LogicalSide.SERVER);//invoke on server
    }
}
