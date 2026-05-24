using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageCooldown : MonoBehaviour
{
    public int damageAmount = 10;       // Damage dealt
    public float cooldown = 1.5f;       // Seconds between damage
    private float lastDamageTime;       // Tracks last damage time

  void OnCollisionEnter(Collision collision)
{
    PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
    if (player != null)
    {
        player.TakeDamage(damageAmount);
    }
}
}
  