using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0.5f, 15f)] [SerializeField] float shootSpeed = 3f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * shootSpeed * Time.deltaTime);
    }
}
