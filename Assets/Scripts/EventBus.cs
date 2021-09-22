using MLAPI.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LogicalSide
{
    CLIENT,
    SERVER
}

public delegate void GameEvent(ulong callbackSourceID, LogicalSide sideCalledFrom); 
public class EventBus
{
    public static GameEvent testEvent;

    public static void Invoke(GameEvent toInvoke, ulong callbackSourceID)
    {
        ClientToServerRpc(toInvoke, callbackSourceID);
        ServerToClientRpc(toInvoke, callbackSourceID);
    }

    [ClientRpc]
    static void ServerToClientRpc(GameEvent toInvoke, ulong callbackSourceID)
    {
        toInvoke.Invoke(callbackSourceID, LogicalSide.CLIENT);//invoke on client
    }

    [ServerRpc]
    static void ClientToServerRpc(GameEvent toInvoke, ulong callbackSourceID)
    {
        toInvoke.Invoke(callbackSourceID, LogicalSide.SERVER);//invoke on server
    }
}
