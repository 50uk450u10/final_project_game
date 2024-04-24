using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
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
        SceneManager.UnloadSceneAsync("Settings Overlay");
    }
}
