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

    [Header("Input Objects")]
    public TMP_InputField ipInput;
    public TMP_InputField portInput;
    public Slider volumeSlider;

    [Header("Network")]
    public string natIP;
    public string natPort;
    public string matchmakerIP;
    public string matchmakerPort;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
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

    public void Connect()
    {
        Debug.Log("Connecting to: ");
    }

    public void RefreshMatchList()
    {
        Debug.Log("Refreshing Match List");
    }

    public void ChangeVolume()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
