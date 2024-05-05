using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    
    private void OnEnable()
    {
        InputManager.ia.SettingsMenu.Enable();
        InputManager.ia.SettingsMenu.Escape.performed += CloseMenu;
    }

    private void OnDisable()
    {
        InputManager.ia.SettingsMenu.Escape.performed -= CloseMenu;
        InputManager.ia.SettingsMenu.Disable();
    }

    void CloseMenu(InputAction.CallbackContext ctx)
    {
        if (!SceneManager.GetSceneByName("PauseMenu").isLoaded)
        {
            SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
            return;
        }
        else if (SceneManager.GetSceneByName("Settings Overlay").isLoaded)
        {
            SceneManager.UnloadSceneAsync("Settings Overlay");
            return;
        }
        else if (SceneManager.GetSceneByName("PauseMenu").isLoaded)
        {
            SceneManager.UnloadSceneAsync("PauseMenu");
            return;
        }
    }
}
