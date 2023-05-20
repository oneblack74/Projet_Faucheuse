using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    public float attaquePortee = 1f;
    public int attaqueDegats = 35;

    private GameObject attaquePoint;
    private Transform attaquePosition;
    private PointAttaquePositionnement pointAttaquePositionnement;
    
    public LayerMask enemyLayers;

    private PlayerInput inputs;
    private GameManager manager;
    private InputAction attackAction;

    void Start()
    {
        attaquePoint = GameObject.Find("PointAttaque");
        attaquePosition = attaquePoint.GetComponent<Transform>();
        pointAttaquePositionnement = attaquePoint.GetComponent<PointAttaquePositionnement>();

        // Input
        manager = GameManager.GetInstance();
        inputs = manager.GetInputs();
        attackAction = inputs.actions.FindAction("Attack");
    }

    void Update()
    {
        if (attackAction.triggered) {
            Attaque();
        }
    }

    void Attaque()
    {
        // jouer l'animation d'attaque

        pointAttaquePositionnement.actualiserPositionPointAttaque();

        Collider2D[] ennemisTouches = Physics2D.OverlapCircleAll(attaquePosition.position, attaquePortee, enemyLayers);
        foreach(Collider2D ennemi in ennemisTouches) {
            Debug.Log("Touché : " + ennemi.name);
            ennemi.GetComponent<Ennemi>().prendreDegats(attaqueDegats);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attaquePoint == null) {
            return;
        }
        Gizmos.DrawWireSphere(attaquePosition.position, attaquePortee);
    }
}
