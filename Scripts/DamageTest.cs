using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTest : MonoBehaviour
{
    public PlayerHealth playerHealth;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerHealth.TakeDamage(10);
        }
    }
}