using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalItem : MonoBehaviour
{
    public int amount = 1; // Amount of coal to be collected

    // This method will be called when the player picks up the coal
    public void PickUp()
    {
        
        // Logic for collecting the coal (e.g., adding to inventory)
        Debug.Log("Picked up " + amount + " coal!");

        // Destroy the coal item after it has been collected
        Destroy(gameObject);
    }
}
