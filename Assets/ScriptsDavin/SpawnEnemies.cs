using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject gorgon;
    [SerializeField] GameObject demon;
    [SerializeField] GameObject dragon;
    WaveManager waves;
    float timer;
    Transform topOffset;
    List<GameObject> monsters = new List<GameObject>();
    int monsterCount;
    int scaler = 1;
    GameObject monster;
    int monsterCap;

    private void OnEnable()
    {
        waves = GetComponent<WaveManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        monsters.Add(dragon);
        monsters.Add(dragon);
        monsters.Add(dragon);
        monsters.Add(dragon);
        monsters.Add(dragon);
        monsters.Add(dragon);
        monsters.Add(dragon);
        monsters.Add(dragon);
        monsters.Add(gorgon);
        monsters.Add(gorgon);
        monsters.Add(gorgon);
        monsters.Add(gorgon);
        monsters.Add(gorgon);
        monsters.Add(demon);
        SpawnMonsterWithWave();
    }
    void SpawnMonster()
    {
        Vector2 topRange = new Vector2(Random.Range(-9, 9), Random.Range(6, 9));
        Vector2 leftRange = new Vector2(Random.Range(-12, -10), Random.Range(-5.5f, 5.5f));
        Vector2 bottomRange = new Vector2(Random.Range(-9, 9), Random.Range(-6, -9));
        int randomDirection = Random.Range(0, 3);
        int randomMonster = Random.Range(0, 14);
        monsterCount++;
        switch (randomDirection)
        {
            case 0:
                monster = Instantiate(monsters[randomMonster], topRange, transform.rotation);
                monster.GetComponent<Enemy>().deathCheck.AddListener(() => waves.MonsterDead(monsterCap));
                break;
            case 1:
                monster = Instantiate(monsters[randomMonster], leftRange, transform.rotation);
                monster.GetComponent<Enemy>().deathCheck.AddListener(() => waves.MonsterDead(monsterCap));
                break;
            case 2:
                monster = Instantiate(monsters[randomMonster], bottomRange, transform.rotation);
                monster.GetComponent<Enemy>().deathCheck.AddListener(() => waves.MonsterDead(monsterCap));
                break;
        }
        if (monsterCount == monsterCap)
        {
            monsterCount = 0;
            CancelInvoke("SpawnMonster");
        }
    }

    public void SpawnMonsterWithWave()
    {
        monsterCap = (5 * WaveCounter.waveCount) + scaler;
        InvokeRepeating("SpawnMonster", Mathf.CeilToInt(2 / DifficultyManager.difficultyMultiplier), Mathf.CeilToInt(2 / DifficultyManager.difficultyMultiplier));
    }
}
