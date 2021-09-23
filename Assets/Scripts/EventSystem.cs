using MLAPI;
using MLAPI.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void GameEvent(ulong ID, bool isClient);

public class EventSystem : NetworkBehaviour
{
    private static event GameEvent testEvent;
    private static Dictionary<string, GameEvent> events = new Dictionary<string, GameEvent>()
    {
        {"test", testEvent}
    };

    private static EventSystem singleton;

    public static EventSystem Singleton
    {
        get
        {
            return singleton;
        }
        private set
        {

        }
    }

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

        if(IsServer && !IsHost && Input.GetKeyDown(KeyCode.RightShift))
        {
            Invoke("test", NetworkObjectId);
        }
    }

    //common invoke for everyone
    public void Invoke(string toInvoke, ulong ID)
    {
        if(!IsServer)//is client
        {
            ClientToServerRpc("test", ID, true);
        }
        else//is server or host
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
    }
}
