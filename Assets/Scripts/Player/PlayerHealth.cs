//Script de Clément

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth = 100;
    [SerializeField] private HealthBar bar;

    void Start()
    {
        currentHealth = maxHealth;
        bar.setMaxHealth(maxHealth);
    }

    void Update()
    {

    }
}
