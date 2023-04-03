using UnityEngine;
using UnityEngine.InputSystem;

public class Capacite_01Script : MonoBehaviour
{
    [SerializeField] private GameObject fauxPrefab; // Le prefab de l'objet faux
    private GameObject lastFaux;

    [SerializeField] private float fauxSpeed = 10f; // La vitesse de l'objet faux
    [SerializeField] private bool fauxSurPlayer = true;

    [SerializeField] private UIcapacite_01 uiCapacite_01;

    [SerializeField] private PlayerInput inputs;
    private GameManager manager;
    private InputAction capacite_01Action;

    [SerializeField] private float timeReloadCapacite_01 = 5f;
    private float timeReloadCapacite_01Ecoule;
    private bool capacite_01Charge = true;


    void Start()
    {
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();

        capacite_01Action = inputs.actions.FindAction("Capacite_01");
    }

    void Update()
    {
        if (capacite_01Action.triggered && fauxSurPlayer && capacite_01Charge)
        {
            // Créer une instance de l'objet faux à partir du prefab
            GameObject faux = Instantiate(fauxPrefab, transform.position, Quaternion.identity);

            // Obtenir la direction dans laquelle le joueur regarde
            Vector3 direction = GetMouseDirection();

            // Déplacer l'objet faux dans la direction donnée
            faux.GetComponent<Rigidbody2D>().velocity = direction * fauxSpeed;

            // Stocker une référence à l'objet faux créé
            lastFaux = faux;

            fauxSurPlayer = false;

            uiCapacite_01.CurrentTime = 100;
            timeReloadCapacite_01Ecoule = 0f;
            capacite_01Charge = false;

        }
        else if (capacite_01Action.triggered){
            fauxSurPlayer = true;
            // Vérifier s'il y a un objet faux créé précédemment
            if (lastFaux != null)
            {
                // Déplacer le joueur à la position de l'objet faux créé précédemment
                transform.position = lastFaux.transform.position;

                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                // Détruire l'objet faux créé précédemment
                Destroy(lastFaux);
            }
        }

        timeReloadCapacite_01Ecoule += Time.deltaTime;
        if (timeReloadCapacite_01Ecoule >= timeReloadCapacite_01){
            capacite_01Charge = true;
            uiCapacite_01.CurrentTime = 100;
        }
        if (!capacite_01Charge){
            uiCapacite_01.CurrentTime = (int)(timeReloadCapacite_01Ecoule * 100 / timeReloadCapacite_01);
        }
        
    }


    private Vector3 GetMouseDirection()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        direction.z = 0f;
        direction.Normalize();

        return direction;
    }

    public bool FauxSurPlayer 
    { 
        get 
        { 
            return fauxSurPlayer; 
        } 
        set 
        { 
            fauxSurPlayer = value; 
        } 
    }

}

