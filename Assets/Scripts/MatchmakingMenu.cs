using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class MatchmakingMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NetworkEventSystem.RegisterListner("start_join", OnJoinStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnJoinStart(ulong ID, bool isClient)
    {
        if(isClient && ID == NetworkManager.Singleton.LocalClientId)
        {
            Debug.Log("Attempting to join game");
        }
    }
}
