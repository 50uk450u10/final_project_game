using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeButton : MonoBehaviour
{
    Button escButton;
    private void OnEnable()
    {
        escButton = GetComponent<Button>();
        escButton.onClick.AddListener(OffloadScene);
    }

    private void OnDisable()
    {
        escButton.onClick.RemoveListener(OffloadScene);
    }

    void OffloadScene()
    {
        SceneManager.UnloadSceneAsync("Settings Overlay");
    }
}
