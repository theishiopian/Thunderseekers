using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchButton : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI serverName;
    private string IP;
    private string Port;

    /// <summary>
    /// Used by the menu to init the button
    /// </summary>
    /// <param name="ip"></param>
    /// <param name="port"></param>
    /// <param name="name"></param>
    public void Init(string ip, string port, string name)
    {
        IP = ip;
        Port = port;
        serverName.text = name;
    }

    /// <summary>
    /// Callback for the button itself
    /// </summary>
    public void OnClick()
    {
        Menu.Singleton.IP = IP;
        Menu.Singleton.port = Port;
        Menu.Singleton.Connect(false);
    }
}
