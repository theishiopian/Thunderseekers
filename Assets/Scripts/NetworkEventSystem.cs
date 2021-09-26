using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using MLAPI.NetworkVariable.Collections;
using MLAPI.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameEvent(ulong ID, bool isClient, AbstractEventData eventData);

/// <summary>
/// This system is used for communication across the server and the client
/// 
/// To Access it, use NetworkEventSystem.Invoke("Event Name", networkID)
/// 
/// This will fire off an event on both the client and server, with a boolean valyue for if the event is clientside
/// NOTE: on a host, the event will be fired twice, once for client, once for server
/// Keep this in mind when writing code that needs to run on a host
/// </summary>
[RequireComponent(typeof(NetworkObject))]
public class NetworkEventSystem : NetworkBehaviour
{
    private static event GameEvent onJoinPre;
    private static event GameEvent onJoinStart;
    private static event GameEvent onJoin;
    private static Dictionary<string, GameEvent> events = new Dictionary<string, GameEvent>()
    {
        {"start_join", onJoinPre},//client
        {"client_join", onJoinStart},//client
        {"client_join_success", onJoin}//both
    };

    private static NetworkEventSystem singleton;

    private void Awake()
    {
        singleton = this;

        NetworkManager.Singleton.OnClientConnectedCallback += (ID) =>
        {
            if(NetworkManager.Singleton.IsServer)
            {
                Invoke("client_join_success", ID);
            }
        };

        RegisterListner("client_join_success", OnJoinComplete);
    }

    void OnJoinComplete(ulong ID, bool isClient, AbstractEventData eventData)
    {
        Debug.Log(isClient);
    }

    /// <summary>
    /// This method is used to invoke an event. Syncs across client and server, if it can.
    /// </summary>
    /// <param name="toInvoke">The key of the event to invoke.</param>
    /// <param name="ID">NetworkID to associate with your event. Can be a ClientID or an ObjectID.</param>
    public static void Invoke(string toInvoke, ulong ID, AbstractEventData eventData = null)
    {
        singleton.DoInvoke(toInvoke, ID, eventData);
    }

    /// <summary>
    /// This method is used to make a method listen for an event. NOTE: make sure your event is registered with the dictionary!
    /// </summary>
    /// <param name="eventName">The key of the event you want to listen for</param>
    /// <param name="listner">A method that will listen for the specified event</param>
    public static void RegisterListner(string eventName, GameEvent listner)
    {
        events[eventName] += listner;
    }

    //common invoke for everyone
    private void DoInvoke(string toInvoke, ulong ID, AbstractEventData eventData)
    {
        if (!IsServer)//is client
        {
            if (NetworkManager.Singleton.IsConnectedClient)
            {
                if(eventData == null)
                {
                    ClientToServerRpc(toInvoke, ID);//this will send it back
                }
                else
                {
                    ClientToServerRpc(toInvoke, ID, eventData);
                }
            }
            else
            {
                events[toInvoke]?.Invoke(ID, true, eventData);
            }
        }
        else if (IsHost)
        {
            events[toInvoke]?.Invoke(ID, false, eventData);

            if (NetworkManager.Singleton.ConnectedClients.Count > 0)
            {
                if(eventData == null)ServerToClientRpc(toInvoke, ID);
                else ServerToClientRpc(toInvoke, ID, eventData);
            }    
        }
        else//is server
        {
            events[toInvoke]?.Invoke(ID, false, eventData);

            if(NetworkManager.Singleton.ConnectedClients.Count > 0)
            {
                if (eventData == null) ServerToClientRpc(toInvoke, ID);
                else ServerToClientRpc(toInvoke, ID, eventData);
            }
        }
    }

    #region RPC
    [ClientRpc()]
    void ServerToClientRpc(string toInvoke, ulong ID)
    {
        events[toInvoke]?.Invoke(ID, true, null);//invokes clientside
    }

    [ServerRpc(RequireOwnership = false)]
    void ClientToServerRpc(string toInvoke, ulong ID)
    {
        Debug.Log("RPC");
        events[toInvoke]?.Invoke(ID, false, null);//invokes serverside
        ServerToClientRpc(toInvoke, ID);//sends to client
    }

    [ClientRpc()]
    void ServerToClientRpc(string toInvoke, ulong ID, AbstractEventData eventData)
    {
        events[toInvoke]?.Invoke(ID, true, eventData);//invokes on client
    }

    [ServerRpc(RequireOwnership = false)]
    void ClientToServerRpc(string toInvoke, ulong ID, AbstractEventData eventData)
    {
        events[toInvoke]?.Invoke(ID, false, eventData);//invokes serverside
        ServerToClientRpc(toInvoke, ID, eventData);
    }
    #endregion
}