using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private float currentMoney = 0f; // Player's current money

    // Method to add money to the player
    public void AddMoney(float amount)
    {
        currentMoney += amount;
        Debug.Log("Current Money: " + currentMoney);
    }
    
    // Optionally, you can also get the current money
    public float GetCurrentMoney()
    {
        return currentMoney;
    }
}