using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health;
    float startHealth;

    void Start()
    {
        startHealth = health;
    }

    void Update()
    {
        
    }

    public void AddHealth(int amount)
    {
        if(health == startHealth)                   // Als leven nog vol is
        {         
            return;                                 // Geen effect
        }
        else if(startHealth - health >= amount)     // Als leven meer is dan bijgekomen leven
        {
            health += amount;                       // Leven bijvullen met toegevoegde leven 
        }
        else if(startHealth - health < amount)      // Als leven minder is dan toegevoegde leven
        {
            health = startHealth;                   // Leven weer maximale hoeveelheid
        }
    }

    public void SubtractHealth(float amount)
    {
        health -= amount;                           // Leven min hoeveelheid schade

        if(health <= 0)                             // Leven weer maximale hoeveelheid
        {
            GameObject.Destroy(gameObject);
        }
    }
}
