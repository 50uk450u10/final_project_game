using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DifficultyButtons : MonoBehaviour
{
    [SerializeField] Button easyButton;
    [SerializeField] Button mediumButton;
    [SerializeField] Button hardButton;
    private void OnEnable()
    {
        easyButton.onClick.AddListener(() => DifficultyManager.SetDifficulty(1));
        easyButton.onClick.AddListener(Play);
        mediumButton.onClick.AddListener(() => DifficultyManager.SetDifficulty(2));
        mediumButton.onClick.AddListener(Play);
        hardButton.onClick.AddListener(() => DifficultyManager.SetDifficulty(3));
        hardButton.onClick.AddListener(Play);
    }
    private void OnDisable()
    {
        easyButton.onClick.RemoveAllListeners();
        mediumButton.onClick.RemoveAllListeners();
        hardButton.onClick.RemoveAllListeners();
    }

    void Play()
    {
        SceneManager.LoadScene("GameplayTestScene 1");
    }
}
