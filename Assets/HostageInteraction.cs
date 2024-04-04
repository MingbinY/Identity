using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageInteraction : MonoBehaviour
{
    public float saveDist = 2f;
    WaveManager waveManager;
    LevelManager levelManager;
    public bool playerNearby = false;
    GameObject playerObj;
    public GameObject interactionHint;

    private void Awake()
    {
        waveManager = FindObjectOfType<WaveManager>();
        playerObj = FindObjectOfType<PlayerHealth>().gameObject;
    }

    public void Kill()
    {
        GameManager.Instance.ActionPicked(true);
    }

    public void Save()
    {
        GameManager.Instance.ActionPicked(false);
    }

    void Update()
    {
        playerNearby = Vector3.Distance(playerObj.transform.position, transform.position) <= saveDist ? true : false;
        interactionHint.SetActive(playerNearby);
        if (playerNearby)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Save();
            }
        }
    }
}
