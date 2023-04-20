//Script d'Axel

using UnityEngine;
using UnityEngine.InputSystem;

public class OpenInventory : MonoBehaviour
{

    [SerializeField] private bool isReach;

    [SerializeField] private PlayerInput inputs;
    private GameManager manager;
    private InputAction interactAction;

    private Inventory inventoryUI;

    private bool inventoryOpen;

    private CapaciteManager capaciteManager;


    // Start is called before the first frame update
    void Start()
    {
        isReach = false;
        inventoryOpen = false;

        capaciteManager = GameObject.FindWithTag("Player").GetComponent<CapaciteManager>();

        inventoryUI = GameObject.Find("Inventory UI").GetComponent<Inventory>();

        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();
        interactAction = inputs.actions.FindAction("Interaction");
    }

    // Update is called once per frame
    void Update()
    {
        if (isReach && interactAction.triggered && !inventoryOpen)
        {

            inventoryUI.Afficher();
            inventoryOpen = true;
        }
        else if (isReach && interactAction.triggered && inventoryOpen)
        {
            inventoryUI.Cacher();
            inventoryOpen = false;
            capaciteManager.modifierCapacite();
        }
        else if (!isReach && inventoryOpen)
        {
            inventoryUI.Cacher();
            inventoryOpen = false;
            capaciteManager.modifierCapacite();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReach = false;
        }
    }
}
