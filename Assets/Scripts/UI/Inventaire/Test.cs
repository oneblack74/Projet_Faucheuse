using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Item itemToPush1, itemToPush2, itemToPush3;

    private Inventory inventory;

    void Start(){
        Add();
    }

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    [ContextMenu("Test Push")]
    public void Add()
    {
        itemToPush1 = inventory.AddItem(itemToPush1);
        itemToPush2 = inventory.AddItem(itemToPush2);
        itemToPush3 = inventory.AddItem(itemToPush3);
    }

}