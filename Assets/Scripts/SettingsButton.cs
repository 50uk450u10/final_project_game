using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] Button settingsButton;
    private void Start()
    {
        settingsButton.onClick.AddListener(SettingsButtonClick);
    }

    void SettingsButtonClick()
    {
        if (!SceneManager.GetSceneByBuildIndex(2).isLoaded)
        SceneManager.LoadSceneAsync("Settings Overlay", LoadSceneMode.Additive);
    }




}
