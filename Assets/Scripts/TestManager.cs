using MLAPI;
using MLAPI.Transports.UNET;
using UnityEngine;
using MatchUp;
using System.Collections.Generic;

public class TestManager : MonoBehaviour
{
    [SerializeField]GameObject toEnable;//temporary
    string serverIP = "test";//reset on the fly
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

    void StartButtons()
    {
        if (GUILayout.Button("Host"))
        {
            UNetTransport transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
            var matchData = new Dictionary<string, MatchData>() {
            { "IP", transport.ConnectAddress },};

            NetworkManager.Singleton.GetComponent<Matchmaker>().CreateMatch(12, matchData);
            NetworkManager.Singleton.StartHost();
        }
        if (GUILayout.Button("Look for match"))
        {
            toEnable.SetActive(true);
        }
        if (GUILayout.Button("Server"))
        {
            UNetTransport transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
            transport.ConnectAddress = "127.0.0.1";//TODO: get public IP
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
    
    static void StatusLabels()
    {
        var mode = NetworkManager.Singleton.IsHost ?
            "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

        GUILayout.Label("Transport: " +
            NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
        GUILayout.Label("Mode: " + mode);

        if (GUILayout.Button("Close")) Application.Quit();
    }

    private void Start()
    {
        NetworkEventSystem.RegisterListner("client_join", OnJoin);
    }

    private void OnJoin(ulong ID, bool isClient, AbstractEventData eventData)
    {
        Debug.Log("join " + isClient);
    }
}