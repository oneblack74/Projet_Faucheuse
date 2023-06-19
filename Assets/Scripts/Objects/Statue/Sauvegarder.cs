
using UnityEngine;
using UnityEngine.InputSystem;

public class Sauvegarder : MonoBehaviour
{
    [SerializeField] private PlayerInput inputs;
    [SerializeField] private int idStatue;
    private GameManager manager;
    private InputAction sauvegarderAction;

    private OpenInventory inventory;
    private SaveData saveData;

    void Start()
    {
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();
        sauvegarderAction = inputs.actions.FindAction("Sauvegarder");

        inventory = GetComponent<OpenInventory>();
        saveData = GameObject.Find("SaveManager").GetComponent<SaveData>();
    }

    
    void Update()
    {
        if (inventory.IsReach && sauvegarderAction.triggered)
        {
            saveData.GetData.IdStatue = idStatue;
            saveData.Sauvegarder();
        }
    }

    public int IdStatue
    {
        get{return idStatue;}
    }
}
