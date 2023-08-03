//Script d'Axel
using UnityEngine;

public class FauxManager : MonoBehaviour
{
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si l'objet faux entre en collision avec un autre objet, arrêter son mouvement
        rb.velocity = Vector2.zero;
    }
}
