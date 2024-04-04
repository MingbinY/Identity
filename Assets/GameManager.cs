using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerIdentity
{
    Police,
    Thug
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    float timer;
    public List<int> killWave;
    public List<int> saveWave;
    public int coins = 0;

    public GameObject gameoverUI;

    public PlayerIdentity playerIdentity;

    private void Awake()
    {
        Instance = this;
        timer = 0;
        coins = 0;

        int identityIndex = UnityEngine.Random.Range(0, Enum.GetNames(typeof(PlayerIdentity)).Length);
        playerIdentity = (PlayerIdentity)identityIndex;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void ActionPicked(bool isKill)
    {
        if (isKill)
        {
            killWave.Add(LevelManager.Instance.currentLevel);
        }
        else
        {
            saveWave.Add(LevelManager.Instance.currentLevel);
        }

        coins++;
        LevelManager.Instance.NextLevel();
    }

    public float GetGameTime()
    {
        return timer;
    }

    public void GameOver(bool isWin)
    {
        gameoverUI.SetActive(true);
        gameoverUI.GetComponentInChildren<GameStatsUI>().AssignStatsToUI(isWin);
        MusicManager.Instance.StopMusic();
        EnemyController[] enemies = FindObjectsOfType<EnemyController>();
        foreach (EnemyController enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }
    }
}
