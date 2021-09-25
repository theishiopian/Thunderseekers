using MLAPI;
using MLAPI.Transports.UNET;
using UnityEngine;
using MatchUp;
using System.Collections.Generic;

public class TestManager : MonoBehaviour
{
    string serverIP = "127.0.0.1";
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            serverIP = GUILayout.TextField(serverIP, 25);
            UNetTransport transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
            transport.ConnectAddress = serverIP;
            transport.ConnectPort = 7777;
            StartButtons();
        }
        else
        {
            StatusLabels();
        }

        GUILayout.EndArea();
    }

    static void StartButtons()
    {
        if (GUILayout.Button("Host"))
        {
            UNetTransport transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
            var matchData = new Dictionary<string, MatchData>() {
            { "IP", transport.ConnectAddress },};

            NetworkManager.Singleton.GetComponent<Matchmaker>().CreateMatch(12, matchData);
            NetworkManager.Singleton.StartHost();
        }
        if (GUILayout.Button("Client"))
        {
            Matchmaker matchmaker = NetworkManager.Singleton.GetComponent<Matchmaker>();

            matchmaker.GetMatchList(OnMatch, 0, 10);
        }
        if (GUILayout.Button("Server"))
        {
            UNetTransport transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
            var matchData = new Dictionary<string, MatchData>() {
            { "IP", transport.ConnectAddress },};

            NetworkManager.Singleton.GetComponent<Matchmaker>().CreateMatch(12, matchData);
            NetworkManager.Singleton.StartServer();
        }
        if (GUILayout.Button("Close"))
        {
            Application.Quit();
        }
    }

    static void OnMatch(bool success, Match[] matches)
    {
        if(success && matches.Length > 0)
        {
            NetworkManager.Singleton.GetComponent<Matchmaker>().JoinMatch(matches[0]);
            UNetTransport transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
            transport.ConnectAddress = matches[0].matchData["IP"].stringValue;
            NetworkManager.Singleton.StartClient();
        }
        else
        {
            if(matches.Length > 0)
            {
                Debug.LogError("Failed to connect to: " + matches[0].matchData["IP"].stringValue);
            }
            else
            {
                Debug.LogError("Failed to connect");
            }
        }
    }

    static void StatusLabels()
    {
        var mode = NetworkManager.Singleton.IsHost ?
            "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

        GUILayout.Label("Transport: " +
            NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
        GUILayout.Label("Mode: " + mode);

        if (GUILayout.Button("Close")) Application.Quit();
    }
}