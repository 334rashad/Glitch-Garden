using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0.5f, 15f)] [SerializeField] float shootSpeed = 3f;
    [SerializeField] float damage = 50f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * shootSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D enemyCollider)
    {
        var health = enemyCollider.GetComponent<Health>();
        health.DealDamage(damage);
    }
}
