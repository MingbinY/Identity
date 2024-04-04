using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUIManager : MonoBehaviour
{
    Text coinText;

    private void Awake()
    {
        coinText = GetComponent<Text>();
    }

    private void Update()
    {
        coinText.text = GameManager.Instance.coins.ToString();
    }
}
