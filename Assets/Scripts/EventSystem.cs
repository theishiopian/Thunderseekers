using MLAPI;
using MLAPI.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameEvent(ulong ID, bool isClient);

/// <summary>
/// This system is used for communication across the server and the client
/// </summary>
public class EventSystem : NetworkBehaviour
{
    private static event GameEvent testEvent;
    private static Dictionary<string, GameEvent> events = new Dictionary<string, GameEvent>()
    {
        {"test", testEvent}
    };

    private static EventSystem singleton;

    public GameObject testOb;

    private void Awake()
    {
        singleton = this;
    }

    private void Start()
    {
        events["test"] += test;
    }

    private void Update()
    {
        if(IsClient && Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("test", NetworkObjectId);
        }

        if(IsServer && Input.GetKeyDown(KeyCode.RightShift))
        {
            Invoke("test", NetworkObjectId);
        }
    }

    public static void Invoke(string toInvoke, ulong ID)
    {
        singleton.DoInvoke(toInvoke, ID);
    }

    //common invoke for everyone
    private void DoInvoke(string toInvoke, ulong ID)
    {
        if(!IsServer )//is client
        {
            ClientToServerRpc("test", ID, true);
        }
        else if(IsHost)
        {
            events[toInvoke]?.Invoke(ID, false);
            ServerToClientRpc("test", ID, true);
        }
        else//is server
        {
            events[toInvoke]?.Invoke(ID, false);
            ServerToClientRpc("test", ID, true);//activate client event remotely
        }
    }

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

    private void test(ulong ID, bool isClient)
    {
        Debug.Log("Event from: " + ID + " " + isClient);
        Destroy(testOb);
    }
}
