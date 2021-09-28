using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MatchUp;
using MLAPI.Transports.UNET;
using MLAPI.Serialization;
using MLAPI.Puncher.Client;
using System.Net;

public class MatchmakingMenu : MonoBehaviour
{
    [SerializeField] GameObject matchPanelPrefab;
    [SerializeField] Transform panelParent;

    public static int indexToJoin = 0;

    private Match[] matches;
    private Matchmaker matchmaker;
    private UNetTransport transport;

    // Start is called before the first frame update
    void Start()
    {
        //NetworkEventSystem.RegisterListner("start_join", OnJoinStart);
        EventBus.AttemptJoinEvent += OnJoinStart;
        matchmaker = NetworkManager.Singleton.GetComponent<Matchmaker>();
        matchmaker.GetMatchList(OnGetMatchList, 0, 10);
        transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
    }

    /// <summary>
    /// Use this to join a game. The first parameter should be the index of the match array to use
    /// </summary>
    void OnJoinStart(ulong ID, params object[] p)
    {
        int i = (int)p[0];
        matchmaker.JoinMatch(matches[i]);
        Match m = matches[i];
        string ip = m.matchData["IP"].stringValue;
        
        

        // Get listener public IP address by means of a matchmaker or otherwise.
        string listenerAddress = ip;

        // Creates the connector with the address and port to the server.
        // Disposal stops everything and closes the connection.
        using (PuncherClient connector = new PuncherClient("puncher.midlevel.io", 6776))
        {
            // Punches and returns the result
            if (connector.TryPunch(IPAddress.Parse(listenerAddress), out IPEndPoint remoteEndPoint))
            {
                // NAT Punchthrough was successful. It can now be connected to using your normal connection logic.
                NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = remoteEndPoint.Address.ToString();

                NetworkManager.Singleton.StartClient();
                gameObject.SetActive(false);
            }
            else
            {
                // NAT Punchthrough failed.
                Debug.Log("punching failed");
            }
        }
        
    }

    /// <summary>
    /// Called when theres a list to display
    /// </summary>
    /// <param name="success"></param>
    /// <param name="matches"></param>
    void OnGetMatchList(bool success, Match[] matches)
    {
        if (success)
        {
            Debug.Log("Success");
            this.matches = matches;

            if(matches.Length > 0)
            {
                for(int index = 0; index != matches.Length; index++)
                {
                    GameObject b = Instantiate(matchPanelPrefab, panelParent);
                    MatchPanel p = b.GetComponent<MatchPanel>();
                    p.arrayIndex = index;
                    p.serverName.text = matches[index].matchData["IP"].stringValue;
                }
            }
            else
            {
                Debug.Log("Success but no matches");
            }
        }
        else
        {
            if (matches.Length > 0)
            {
                Debug.LogError("Failed to connect to: " + matches[0].matchData["IP"].stringValue);
            }
            else
            {
                Debug.LogError("Failed to connect");
            }
        }
    }
}