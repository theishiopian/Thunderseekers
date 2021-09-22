using MLAPI;
using MLAPI.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LogicalSide
{
    CLIENT,
    SERVER
}

public delegate void GameEvent(ulong callbackSourceID, LogicalSide side, LogicalSide sideCalledFrom); 
public class EventBus
{
    public static GameEvent testEvent;

    public static void Invoke(GameEvent toInvoke, ulong callbackSourceID, LogicalSide source)
    {
        ClientToServerRpc(toInvoke, callbackSourceID, source);
        ServerToClientRpc(toInvoke, callbackSourceID, source);
    }

    [ClientRpc]
    static void ServerToClientRpc(GameEvent toInvoke, ulong callbackSourceID, LogicalSide source)
    {
        toInvoke.Invoke(callbackSourceID, LogicalSide.CLIENT, source);//invoke on client
    }

    [ServerRpc]
    static void ClientToServerRpc(GameEvent toInvoke, ulong callbackSourceID, LogicalSide source)
    {
        toInvoke.Invoke(callbackSourceID, LogicalSide.SERVER, source);//invoke on server
    }
}
