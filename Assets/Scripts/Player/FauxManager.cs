using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxManager : MonoBehaviour
{
    private bool fixe;
    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        fixe = false;
    }

    private void Update()
    {
        if (!fixe){
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si l'objet faux entre en collision avec un autre objet, arrêter son mouvement
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        fixe = true;
    }
}
