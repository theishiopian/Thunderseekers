using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MatchUp;
using MLAPI.Transports.UNET;
using MLAPI.Serialization;

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
        NetworkEventSystem.RegisterListner("start_join", OnJoinStart);
        matchmaker = NetworkManager.Singleton.GetComponent<Matchmaker>();
        matchmaker.GetMatchList(OnGetMatchList, 0, 10);
        transport = NetworkManager.Singleton.GetComponent<UNetTransport>();
    }

    /// <summary>
    /// Use this to join a game. The first parameter should be the index of the match array to use
    /// </summary>
    void OnJoinStart(ulong ID, bool isClient, INetworkSerializable eventData)
    {
        JoinEvent joinEventData = (JoinEvent)eventData;
        if(isClient && ID == NetworkManager.Singleton.LocalClientId)
        {
            Debug.Log("Attempting to join game");

            matchmaker.JoinMatch(matches[0]);
            
            Debug.Log(matches[joinEventData.INDEX].matchData["IP"].stringValue);
            transport.ConnectAddress = matches[joinEventData.INDEX].matchData["IP"].stringValue;
            NetworkManager.Singleton.StartClient();
        }
    }

    /// <summary>
    /// Called when theres a list to display
    /// </summary>
    /// <param name="success"></param>
    /// <param name="matches"></param>
    void OnGetMatchList(bool success, Match[] matches)
    {
        if (success && matches.Length > 0)
        {
            Debug.Log("Success");
            this.matches = matches;

            if(matches.Length > 0)
            {
                for(int index = 0; index != matches.Length; index++)
                {
                    Instantiate(matchPanelPrefab, panelParent).GetComponent<MatchPanel>().arrayIndex = index;
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

/// <summary>
/// This struct caries data about a join event
/// </summary>
public struct JoinEvent : INetworkSerializable
{
    private int index;

    public int INDEX
    {
        get => index;
        private set => index = value;
    }

    public JoinEvent(int index)
    {
        this.index = index;
    }

    public void NetworkSerialize(NetworkSerializer serializer)
    {
        serializer.Serialize(ref index);
    }
}