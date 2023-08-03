// script Axel
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

    // prefab
    [SerializeField] private GameObject fauxPrefab;
    [SerializeField] private float fauxSpeed = 10f;
    private GameObject lastFaux;
    [SerializeField] private float dureeTeleportation = 3f;
    private float timerTeleportation;

    



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
            timerTeleportation += Time.deltaTime;
            if (timerTeleportation >= dureeTeleportation)
            {
                timerTeleportation = 0f;
                if (lastFaux != null)
                {
                    lastFaux.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
                
            }

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
        GameObject faux = Instantiate(fauxPrefab, transform.position, Quaternion.identity);

        Vector3 mouseScreenPosition = Input.mousePosition;
        // Convertir la position de la souris en un point dans l'espace 2D
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, transform.position.z));
        mouseWorldPosition.z = 0;
        // Obtenir la direction entre le joueur et la position de la souris
        Vector3 launchDirection = (mouseWorldPosition - transform.position).normalized;

        faux.GetComponent<Rigidbody2D>().velocity = launchDirection * fauxSpeed;

        lastFaux = faux;
        
    }

    private void teleportation()
    {

        if (lastFaux != null)
        {
            // Déplacer le joueur à la position de l'objet faux créé précédemment
            transform.position = lastFaux.transform.position;

            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            // Détruire l'objet faux créé précédemment
            Destroy(lastFaux);
        }
    }

    private void ramenerFaux()
    {
        Debug.Log("ramener la faux");

        if (lastFaux != null)
        {
            Destroy(lastFaux);
        }
    }

}
