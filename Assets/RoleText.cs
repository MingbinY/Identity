using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleText : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Text>().text = GameManager.Instance.playerIdentity.ToString();
    }
}
