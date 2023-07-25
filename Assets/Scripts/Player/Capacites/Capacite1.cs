// script Axel
using UnityEngine;
using UnityEngine.InputSystem;

public class Capacite1 : MonoBehaviour
{
    // recuperer l'input de l'action
    [SerializeField] private PlayerInput inputs;
    private GameManager manager;
    private InputAction capaAction;

    // les timer de la capacite
    [SerializeField] private float timerEtat0;
    [SerializeField] private float timerEtat1;
    private float timerEcoule;
    private bool spellCharge;
    // etat: 0 --> faux pas lancé | 1 --> faux lancé
    private int etat = 0;

    void Start()
    {
        //récupération de l'action de la capacité
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();
        capaAction = inputs.actions.FindAction("Capacite_01");
    }

    void Update()
    {
        if (capaAction.triggered)
        {
            if (spellCharge && etat == 0)
            {
                lancerFaux();
                timerEcoule = 0f;
                etat = 1;
            }
            else if (spellCharge && etat == 1)
            {
                teleportation();
                timerEcoule = 0f;
                etat = 0;
                spellCharge = false;
            }
        }

        timerEcoule += Time.deltaTime;
        if (etat == 0)
        {
            if (timerEcoule >= timerEtat0)
            {
                spellCharge = true;
            }
        }
        else if (etat == 1)
        {
            if (timerEcoule >= timerEtat1)
            {
                ramenerFaux();
                spellCharge = false;
                etat = 0;
                timerEcoule = 0f;
            }
        }
    }

    private void lancerFaux()
    {
        Debug.Log("lancer la faux");
    }

    private void teleportation()
    {
        Debug.Log("teleportation");
    }

    private void ramenerFaux()
    {
        Debug.Log("ramener la faux");
    }
}
