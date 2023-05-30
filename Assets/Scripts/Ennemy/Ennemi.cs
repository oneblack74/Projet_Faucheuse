//Script de Mathis
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] private int currentHealth;

    //Clément
    [SerializeField] private int nbSouldDrop;
    [SerializeField] private GameObject soulObject;
    //

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        //Clément
        if (Health <= 0)
        {
            die();
        }
        //
    }

    public void prendreDegats(int degats)
    {
        currentHealth -= degats;
        if (currentHealth <= 0)
        {
            die();
        }
    }

    private void die()
    {
        //Clément : on instancie nbSoulDrop soul qui drop de l'ennemi quand on le tue (à des positions aléatoire autour de lu)
        Destroy(transform.parent.gameObject);
        for (int i = 0; i < nbSouldDrop; i++)
        {
            float x = Random.Range(transform.position.x - 0.8f, transform.position.x + 0.8f);
            float y = Random.Range(transform.position.y - 0.1f, transform.position.y + 0.3f);
            Vector2 pos = new Vector2(x, y);
            transform.position = pos;
            GameObject soul = Instantiate(soulObject, transform.position, Quaternion.identity);
        }
        //
    }

    public int Health
    {
        get { return currentHealth; }
    }
}
