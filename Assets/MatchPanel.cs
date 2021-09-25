using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI;

public class MatchPanel : MonoBehaviour
{
    public Button JoinMatch;
    public Text serverName;
    public Text numberOfPlayers;

    public int arrayIndex = 0;

    // Start is called before the first frame update
    void OnEnable()
    {
        JoinMatch.onClick.AddListener(Join);
    }

    private void Join()
    {
        NetworkEventSystem.Invoke("start_join", NetworkManager.Singleton.LocalClientId, new JoinEventData(arrayIndex));
    }
}
