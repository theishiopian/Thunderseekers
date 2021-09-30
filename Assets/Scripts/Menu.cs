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

    [Header("Input")]
    public TMP_InputField ipInput;
    public TMP_InputField portInput;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        manualConnect.SetActive(false);
        serverBrowser.SetActive(false);
        settingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
