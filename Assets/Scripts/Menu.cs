using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Unity;
using BeardedManStudios.SimpleJSON;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    #region INSPECTOR
    [Header("Objects")]
    public GameObject mainMenu;
    public GameObject manualConnect;
    public GameObject serverBrowser;
    public GameObject settingsMenu;
    public GameObject hostMenu;
    public RectTransform matchListAnchor;

    [Header("Input Objects")]
    public TMP_InputField ipInput;
    public TMP_InputField portInput;
    public TMP_InputField serverName;
    public Slider volumeSlider;
    public Scrollbar browseScroll;

    [Header("Network")]
    public string IP = "0.0.0.0";
    public string port = "15490";
    public string natIP = "108.166.222.106";
    public string natPort = "15491";
    public string matchmakerIP = "108.166.222.106";
    public string matchmakerPort;
    #endregion

    public static Menu Singleton { get; private set; }

    private List<MatchButton> matchList = new List<MatchButton>();
    private NetWorker server;
    private NetworkManager manager;

    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;
        mainMenu.SetActive(true);
        manualConnect.SetActive(false);
        serverBrowser.SetActive(false);
        settingsMenu.SetActive(false);
        hostMenu.SetActive(false);

        if(!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 1);
        }

        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        RefreshMatchList();
    }

    /// <summary>
    /// Used to connect to the currently stored IP
    /// </summary>
    public void Connect(bool read)
    {
        if(read)
        {
            IP = ipInput.text;
            this.port = portInput.text;
        }

        Debug.Log("Attemtping to connect to: " + IP + ":" + this.port);

        ushort port;
        if (!ushort.TryParse(this.port, out port))
        {
            Debug.LogError("The supplied port number is not within the allowed range 0-" + ushort.MaxValue);
            return;
        }

        NetWorker client = new UDPClient();

        ((UDPClient)client).Connect(IP, port, natIP, ushort.Parse(natPort));

        Connected(client);
    }

    /// <summary>
    /// Used to host a game
    /// </summary>
    public void Host()
    {
        Debug.Log("Hosting");

        server = new UDPServer(12);

        ushort port;
        if(!ushort.TryParse(this.port, out port))
        {
            Debug.Log("Invalid Port, Aborting");
            return;
        }

        ((UDPServer)server).Connect(port: port, natHost: natIP, natPort: ushort.Parse(natPort));

        server.playerTimeout += (player, sender) =>
        {
            Debug.Log("Player " + player.NetworkId + " timed out");
        };

        Connected(server);
    }

    private void Connected(NetWorker server)
    {
        if (!server.IsBound)
        {
            Debug.LogError("Server failed to bind, Aborting");
            return;
        }

        Debug.Log("Generating Network Manager");
        GameObject managerObject = new GameObject("Network Manager");
        manager = managerObject.AddComponent<NetworkManager>();

        // If we are using the master server we need to get the registration data
        //JSONNode masterServerData = manager.MasterServerRegisterData(server, "tsGame", serverName.te);
        //TODO: add master server

        manager.Initialize(server);

        if(server is IServer)
        {
            SceneManager.LoadScene(1);//load main world
        }
    }

    /// <summary>
    /// Used to get a list of matches and display them in the match browser
    /// </summary>
    public void RefreshMatchList()
    {
        Debug.Log("Refreshing Match List");
    }

    /// <summary>
    /// Changes the game volume
    /// </summary>
    public void ChangeVolume()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }

    /// <summary>
    /// Quits game
    /// </summary>
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
