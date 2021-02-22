using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float multiplier = 1.5f;
    public float duration = 2.0f;

    public GameObject pickupEffect;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);

        Player stats = player.GetComponent<Player>();

        stats.speed *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.speed /= multiplier;

        Destroy(gameObject);
    }
}
