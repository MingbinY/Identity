using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameObject storeUI;
    public float interactionDist = 5f;
    public LayerMask rayIgnoreLayer;
    public UpgradeUI upgradeUI;

    private void Update()
    {
        bool showStoreUI =false;
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, interactionDist, ~rayIgnoreLayer);
        if (hit.collider)
        {
            if (hit.collider.gameObject.GetComponent<Store>())
            {
                //Show UI
                showStoreUI = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Buy
                    BuyUpgrade();
                }
            }
        }

        storeUI.SetActive(showStoreUI);
    }

    public void BuyUpgrade()
    {
        if (GameManager.Instance.coins == 0) return;

        GameManager.Instance.coins--;
        Gun gun = FindObjectOfType<Gun>();
        gun.Upgrade();
        upgradeUI.PlayerHitReaction();
    }
}
