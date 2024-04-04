using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Transform> spawnPoints;

    [SerializeField]
    public GameObject hostageParent;
    public GameObject enemyPrefab;
    public GameObject actionsHint;
    public GameObject store;

    public int killCount = 0;
    public bool levelEnded = true;

    private void Awake()
    {
        if (spawnPoints.Count <= 0)
        {
            Application.Quit();
        }

        killCount = 0;
    }

    private void Update()
    {
        if (killCount == 5)
        {
            levelEnded = true;
            LevelEnd();
        }
    }

    public void SpawnEnemy()
    {
        levelEnded = false;
        foreach (Transform t in spawnPoints)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, t.position, Quaternion.identity);
        }
    }

    public void LevelEnd()
    {
        killCount = 0;
        hostageParent.SetActive(true);
        actionsHint.SetActive(true);
        //store.SetActive(true);
    }

    public void EnemyKilled()
    {
        killCount++;
    }

    public void HideHostage()
    {
        hostageParent.SetActive(false);
        actionsHint.SetActive(false);
        //store.SetActive(false);
    }
}
