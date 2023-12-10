using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Snowball : MonoBehaviour
{
    public float knockbackForce = 1000f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1")|| collision.gameObject.CompareTag("Player2"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                // Calculate the knockback direction based on the collision
                Vector3 knockbackDirection = (collision.contacts[0].point - transform.position).normalized;

                // Apply the knockback force
                playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
            }
        }
    }
}