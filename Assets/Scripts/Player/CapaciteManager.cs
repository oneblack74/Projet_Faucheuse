using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CapaciteManager : MonoBehaviour
{
    [SerializeField] private PlayerInput inputs;
    private GameManager manager;
    private InputAction capa_01Action;
    private InputAction capa_02Action;
    private InputAction capa_03Action;

    [SerializeField] private Inventory inventory;
    private PlayerMoveManager player;

    private GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMoveManager>();
        inventory = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();


        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();
        capa_01Action = inputs.actions.FindAction("Capacite_01");
        capa_02Action = inputs.actions.FindAction("Capacite_02");
        capa_03Action = inputs.actions.FindAction("Capacite_03");

        inventoryUI = GameObject.Find("Inventory UI");
        inventoryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (capa_01Action.triggered)
        {
            Item item = inventory.GetItem(12);
            if (item.Data != null)
            {
                Capacite capacite = item.Data.getCapacite;
                capacite.activer();
            }
        }
        if (capa_02Action.triggered)
        {
            Item item = inventory.GetItem(13);
            if (item.Data != null)
            {
                Capacite capacite = item.Data.getCapacite;
                capacite.activer();
            }
        }
        if (capa_03Action.triggered)
        {
            Item item = inventory.GetItem(14);
            if (item.Data != null)
            {
                Capacite capacite = item.Data.getCapacite;
                capacite.activer();
            }
        }
    }
}
