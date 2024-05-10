using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndRunButton : MonoBehaviour
{
    Button endRunButton;
    private void OnEnable()
    {
        endRunButton = GetComponent<Button>();
        endRunButton.onClick.AddListener(EndRun);
    }
    private void OnDisable()
    {
        endRunButton.onClick.RemoveAllListeners();
    }

    void EndRun()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
