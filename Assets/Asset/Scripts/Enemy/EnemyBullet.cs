using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifetime;
    [SerializeField] private float _distance;
    [SerializeField][HideInInspector] private float _damage = 1;
    [SerializeField] private LayerMask WhatIs;

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, _distance, WhatIs);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<PlayerController>().TakeDamage(_damage);
            }
            
            Destroy(gameObject);
        }

        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    } 
}
