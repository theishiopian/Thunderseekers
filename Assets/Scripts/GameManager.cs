using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    MENU,
    PLAYING,
    ENDING
}

public class GameManager : GameManagerBehavior
{
    private NetworkManager manager;
    private void Start()
    {
        manager = NetworkManager.Instance;
        EventBus.serverStarted += () =>
        {
            //May need extra check to remove when server is done, idk
            Debug.Log(manager);
            Debug.Log(manager.Networker);
            manager.Networker.playerAccepted += OnPlayerAccepted;
        };
    }

    public void OnPlayerAccepted(NetworkingPlayer player, NetWorker serverNetworker)
    {
        MainThreadManager.Run(() => 
        {
            var behavior = NetworkManager.Instance.InstantiatePlayer(0, Vector3.zero, Quaternion.identity);

            // Let's also assign ownership to the player that just joined.
            behavior.networkObject.AssignOwnership(player);
        });
    }
}
