using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveManager : MonoBehaviour
{
    SpawnEnemies spawner;
    int numDead;
    public UnityEvent waveChange;
    private void OnEnable()
    {
        spawner = GetComponent<SpawnEnemies>();
        WaveCounter.IncrementWave();
        DifficultyManager.SetDifficulty(3);
    }

    private void OnDisable()
    {
        WaveCounter.ResetWave();
    }

    public void CheckEnemies(int numDead1, int numOfEnemies)
    {
        Debug.Log(numOfEnemies);
        if (numDead1 == numOfEnemies)
        {
            WaveCounter.IncrementWave();
            waveChange.Invoke();
            numDead = 0;
            spawner.SpawnMonsterWithWave();
        }
    }

    public void MonsterDead(int numOfEnemies)
    {
        numDead++;
        Debug.Log(numDead);
        CheckEnemies(numDead, numOfEnemies);
    }
}
