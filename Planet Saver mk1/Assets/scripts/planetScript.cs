using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetScript : MonoBehaviour
{
    //basic health stats
    public int maxHealth = 5; // health will go from 5 down to 0
    public int minHealth = 0; 
    public int minBuildingLevel = 0; // will go up to 5
    public int maxBuildingLevel = 5;

    //current stats
    public int currentHealth;
    public int currentLevel;

    public Collider2D colliderA;

    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
        currentLevel = minBuildingLevel;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //this code will make sure that the death event happens if the health is 0
        if (currentHealth <= minHealth)
        {
            Death();
        }

        if (currentLevel >= maxBuildingLevel)
        {
            Win();
        }

    }
    //the method to take damage
    public void TakeDamage()
    {
        // if there are buildings they will be taken down a level
        if (currentLevel > minBuildingLevel)
        {
            currentLevel = currentLevel - 1;
        }
        //if not then the planet will take damage
        if (currentHealth > minHealth)
        {
            currentHealth = currentHealth-1;

            Debug.Log("planet hurt");
        }
        //otherwise there must be something wrong
        else
        {
            currentHealth = minHealth;
            Debug.Log("why is the planet not dead");
        }
    }

    public void HealPlanet()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = currentHealth + 1;
            Debug.Log("planet healed");
        }
        else
        {
            currentHealth = maxHealth;
            Debug.Log("the planet is at full health");
        }

    }

    public void BuildUp()
    {
        if (currentLevel < maxBuildingLevel)
        {
            currentLevel = currentLevel +1;
            Debug.Log("built up!");
        }
        else
        {
            currentLevel = minBuildingLevel;
            Debug.Log("the planet is at full health");
        }
    }

    public void Death(){
        Debug.Log("You Dead!");
    }

    public void Win()
    {
        Debug.Log("You Won!");
    }
}
