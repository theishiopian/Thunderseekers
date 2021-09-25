using MLAPI;
using MLAPI.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameEvent(ulong ID, bool isClient);

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
    private static event GameEvent startJoin;
    private static Dictionary<string, GameEvent> events = new Dictionary<string, GameEvent>()
    {
        {"start_join", startJoin}
    };

    private static NetworkEventSystem singleton;

    /// <summary>
    /// This method is used to invoke an event. Syncs across client and server, if it can.
    /// </summary>
    /// <param name="toInvoke">The key of the event to invoke.</param>
    /// <param name="ID">NetworkID to associate with your event. Can be a ClientID or an ObjectID.</param>
    public static void Invoke(string toInvoke, ulong ID)
    {
        singleton.DoInvoke(toInvoke, ID);
    }

    /// <summary>
    /// This method is used to make a method listen for an event. NOTE: make sure your event is registered with the dictionary!
    /// </summary>
    /// <param name="eventName">The key of the event you want to listen for</param>
    /// <param name="eventToRegister">A method that will listen for the specified event</param>
    public static void RegisterListner(string eventName, GameEvent listner)
    {
        events[eventName] += listner;
    }

    private void Awake()
    {
        singleton = this;
    }

    //common invoke for everyone
    private void DoInvoke(string toInvoke, ulong ID)
    {
        if (!IsServer)//is client
        {
            if (NetworkManager.Singleton.IsConnectedClient) ClientToServerRpc(toInvoke, ID, true);//this will send it back
            else
            {
                events[toInvoke]?.Invoke(ID, true);
            }
        }
        else if (IsHost)
        {
            events[toInvoke]?.Invoke(ID, false);

            if (NetworkManager.Singleton.ConnectedClients.Count > 0)
            {
                ServerToClientRpc(toInvoke, ID, true);
            }    
        }
        else//is server
        {
            events[toInvoke]?.Invoke(ID, false);

            if(NetworkManager.Singleton.ConnectedClients.Count > 0)
            {
                ServerToClientRpc(toInvoke, ID, true);//activate client event remotely
            }
        }
    }

    #region RPC
    [ClientRpc()]
    void ServerToClientRpc(string toInvoke, ulong ID, bool isClient)
    {
        events[toInvoke]?.Invoke(ID, isClient);
    }

    [ServerRpc(RequireOwnership = false)]
    void ClientToServerRpc(string toInvoke, ulong ID, bool isClient)
    {
        events[toInvoke]?.Invoke(ID, isClient);
        ServerToClientRpc("test", ID, isClient);
    }
    #endregion
}
