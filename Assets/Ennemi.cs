using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void prendreDegats(int degats) {
        currentHealth -= degats;
        Debug.Log("vie : " + currentHealth);
        if (currentHealth <= 0) {
            die();
        }
    }

    private void die() {
        Debug.Log(this.name + " est mort :'(");
    }
}
