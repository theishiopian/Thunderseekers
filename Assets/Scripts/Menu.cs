using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    #region INSPECTOR
    [Header("Objects")]
    public GameObject mainMenu;
    public GameObject manualConnect;
    public GameObject serverBrowser;
    public GameObject settingsMenu;
    public RectTransform matchListAnchor;

    [Header("Input Objects")]
    public TMP_InputField ipInput;
    public TMP_InputField portInput;
    public Slider volumeSlider;
    public Scrollbar browseScroll;

    [Header("Network")]
    public string IP;
    public string port;
    public string natIP;
    public string natPort;
    public string matchmakerIP;
    public string matchmakerPort;
    #endregion

    public static Menu Singleton { get; private set; }

    private List<MatchButton> matchList = new List<MatchButton>();

    // Start is called before the first frame update
    void Start()
    {
        Singleton = this;
        mainMenu.SetActive(true);
        manualConnect.SetActive(false);
        serverBrowser.SetActive(false);
        settingsMenu.SetActive(false);

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
            port = portInput.text;
        }

        Debug.Log("Attemtping to connect to: " + IP + ":" + port);
    }

    /// <summary>
    /// Used to host a game
    /// </summary>
    public void Host()
    {
        Debug.Log("Hosting");
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
