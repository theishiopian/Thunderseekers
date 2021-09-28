using MLAPI;
using MLAPI.Transports.UNET;
using UnityEngine.Networking;
using UnityEngine;
using MatchUp;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;
using MLAPI.Puncher.Server;
using System.Net;
using MLAPI.Puncher.Client;

public class TestManager : MonoBehaviour
{
    bool hasIP = false;
    string IP;
    [SerializeField]GameObject toEnable;//temporary
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            StartButtons();
        }
        else
        {
            StatusLabels();
        }

        GUILayout.EndArea();
    }

    void StartMatch()
    {
        UNetTransport transport = NetworkManager.Singleton.GetComponent<UNetTransport>();

        var matchData = new Dictionary<string, MatchData>() {
                { "IP", transport.ConnectAddress },};

        NetworkManager.Singleton.GetComponent<Matchmaker>().CreateMatch(12, matchData);

        PuncherServer server = new PuncherServer();
        // 6776 is the port of the NAT server. Can be changed.
        server.Start(new IPEndPoint(IPAddress.Any, 6776));

        // Creates the listener with the address and port of the server.
        // Disposal stops everything and closes the connection.
        using (PuncherClient listener = new PuncherClient("puncher.midlevel.io", 6776))
        {
            // 1234 is the port where the other peer will connect and punch through.
            // That would be the port where your program is going to be listening after the punch is done.
            listener.ListenForSinglePunch(new IPEndPoint(IPAddress.Any, 1234));
        }
    }

    void StartButtons()
    {
        if(hasIP)
        {
            if (GUILayout.Button("Look for match"))
            {
                toEnable.SetActive(true);
            }
            if (GUILayout.Button("Host"))
            {
                StartMatch();
                NetworkManager.Singleton.StartHost();
            }
            if (GUILayout.Button("Server"))
            {
                StartMatch();
                NetworkManager.Singleton.StartServer();
            }
            if (GUILayout.Button("Close"))
            {
                Application.Quit();
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
        //GUILayout.Label("IP: " + NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress);
        //GUILayout.Label("PORT: " + NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectPort);

        if (GUILayout.Button("Close")) Application.Quit();
    }

    private void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += (ID) => EventBus.ClientConnectEvent?.Invoke(ID);
        EventBus.ClientConnectEvent += OnClientJoin;

        StartCoroutine(GetRequest("https://ident.me/"));
    }

    private void OnClientJoin(ulong ID, params object[] p)
    {
        Debug.Log("Client joined with ID: " + ID);
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    {
                        string ip = webRequest.downloadHandler.text;
                        var m = Regex.Match(ip, @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");

                        if(m.Success)
                        {
                            ip = m.Captures[0].Value;
                        }
                        
                        Debug.Log("Local IP is: " + ip);
                        NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = ip;
                        hasIP = true;
                    }
                    break;
            }
        }
    }
}