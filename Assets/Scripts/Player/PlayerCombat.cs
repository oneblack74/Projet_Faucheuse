using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform pointAttaque;
    public float porteeAttaque = 1f;
    public int degatsAttaque = 35;

    public LayerMask enemyLayers;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Axel il faudra que tu m'expliques l'autre manière de faire des inputs stp :D
        {
            Attaque();
        }
    }

    void Attaque()
    {
        // jouer l'animation d'attaque

        Collider2D[] ennemisTouches = Physics2D.OverlapCircleAll(pointAttaque.position, porteeAttaque, enemyLayers);
        foreach(Collider2D ennemi in ennemisTouches) {
            Debug.Log("Touché : " + ennemi.name);
            ennemi.GetComponent<Ennemi>().prendreDegats(degatsAttaque);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (pointAttaque == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(pointAttaque.position, porteeAttaque);
    }
}
