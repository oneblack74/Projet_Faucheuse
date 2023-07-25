
using UnityEngine;
using UnityEngine.InputSystem;

public class Sauvegarder : MonoBehaviour
{
    [SerializeField] private PlayerInput inputs;
    [SerializeField] private int idStatue;
    private GameManager manager;
    private InputAction sauvegarderAction;
    private SaveData saveData;
    [SerializeField] private bool isReach;

    void Start()
    {
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();
        sauvegarderAction = inputs.actions.FindAction("Sauvegarder");

        saveData = GameObject.Find("SaveManager").GetComponent<SaveData>();
        isReach = false;
    }

    
    void Update()
    {
        if (isReach && sauvegarderAction.triggered)
        {
            saveData.GetData.IdStatue = idStatue;
            saveData.Sauvegarder();
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

    public int IdStatue
    {
        get{return idStatue;}
    }

    public bool IsReach
    {
        get{return isReach;}
    }
}
