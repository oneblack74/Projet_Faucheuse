//Script de Clément
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    SoulCount soulCount = GameObject.Find("SoulCount").GetComponent<SoulCount>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this);
        }
    }
}
