using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Item itemToPush, pickedItem;

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
        itemToPush = inventory.AddItem(itemToPush);
    }

    [ContextMenu("Test Pick")]
    public void Pick()
    {
        pickedItem = inventory.PickItem(1);
    }
}