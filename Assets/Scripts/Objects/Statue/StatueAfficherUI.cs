using UnityEngine;

public class StatueAfficherUI : MonoBehaviour
{
    private OpenInventory inventory;
    private GameObject statueUI;
    void Start()
    {
        inventory = GetComponent<OpenInventory>();
        statueUI = transform.GetChild(0).GetChild(0).gameObject;
    }

    void Update()
    {
        if (inventory.IsReach)
        {
            statueUI.SetActive(true);
        }
        else
        {
            statueUI.SetActive(false);
        }
    }
}
