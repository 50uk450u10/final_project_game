using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(Play);
    }

    void Play()
    {
        SceneManager.LoadSceneAsync("DifficultyMenu", LoadSceneMode.Additive);
    }
}
