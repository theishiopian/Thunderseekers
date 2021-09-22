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

    public static void Invoke(GameEvent toInvoke, object callbackSource, LogicalSide sideCalledFrom)
    {
        toInvoke.Invoke(callbackSource, sideCalledFrom);

        if(sideCalledFrom == LogicalSide.CLIENT)
        {
            //invoke on server
            ClientToServerRpc(toInvoke, callbackSource);
        }
        else
        {
            //invoke on client
            ServerToClientRpc(toInvoke, callbackSource);
        }
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
