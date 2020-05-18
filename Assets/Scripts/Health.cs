using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 100f;
    [SerializeField] GameObject destroyVFX;
    
    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDestroyVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDestroyVFX()
    {
        if (!destroyVFX) return;
        GameObject destroyVFXObject = Instantiate(destroyVFX, transform.position, transform.rotation);
        Destroy(destroyVFXObject, 2f);
    }

}
