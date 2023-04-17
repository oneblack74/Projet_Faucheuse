using UnityEngine;
using UnityEngine.InputSystem;

public class OpenInventory : MonoBehaviour
{

    [SerializeField] private bool isReach;

    [SerializeField] private PlayerInput inputs;
    private GameManager manager;
    private InputAction interactAction;

    private GameObject inventoryUI;

    private bool inventoryOpen;
    

    // Start is called before the first frame update
    void Start()
    {
        isReach = false;
        inventoryOpen = false;

        inventoryUI = GameObject.Find("Inventory UI");

        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();
        interactAction = inputs.actions.FindAction("Interaction");
    }

    // Update is called once per frame
    void Update()
    {
        if (isReach && interactAction.triggered && !inventoryOpen)
        {
            
            inventoryUI.SetActive(true);
            inventoryOpen = true;
        }
        else if (isReach && interactAction.triggered && inventoryOpen)
        {
            inventoryUI.SetActive(false);
            inventoryOpen = false;
        }
        else if (!isReach && inventoryOpen)
        {
            inventoryUI.SetActive(false);
            inventoryOpen = false;
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
