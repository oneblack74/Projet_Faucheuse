using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxManager : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si l'objet faux entre en collision avec un autre objet, arrêter son mouvement
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
