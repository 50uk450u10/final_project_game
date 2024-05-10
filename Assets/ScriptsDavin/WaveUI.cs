using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveUI : MonoBehaviour
{
    TMP_Text waveText;
    WaveManager waveManager;
    private void Start()
    {
        waveText = GetComponentInChildren<TMP_Text>();
        WaveChange();
        waveManager = FindAnyObjectByType<WaveManager>();
        waveManager.waveChange.AddListener(WaveChange);
    }
    public void WaveChange()
    {
        waveText.text = "Wave: " + WaveCounter.waveCount;
    }
}
