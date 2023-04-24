//Script de Clément

using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth = 100;
    [SerializeField] private HealthBar bar;
    void Start()
    {
        bar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        bar.setMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            removeHealth(10);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            addHealth(10);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            setFullHealth();
        }
    }

    void removeHealth(int health)
    {
        if (currentHealth - health > 0)
        {
            currentHealth -= health;
            bar.setHealth(currentHealth);
        }
        else if (currentHealth - health == 0)
        {
            //gérer la mort du perso
        }
    }

    void addHealth(int health)
    {
        if (currentHealth + health <= maxHealth)
        {
            currentHealth += health;
            bar.setHealth(currentHealth);
        }
    }

    void setFullHealth()
    {
        currentHealth = maxHealth;
        bar.setHealth(currentHealth);
    }
}
