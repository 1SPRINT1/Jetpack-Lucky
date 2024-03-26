using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField] private float _speed;
   [SerializeField] private float _lifetime;
   [SerializeField] private float _distance;
   [SerializeField][HideInInspector] private float _damage = 1;
   [SerializeField] private LayerMask WhatIs;
   [Header("Connetion-scripts")] 
   public GameManager GM;
   [SerializeField] private float damageUpgrade;

   private void Start()
   {
       damageUpgrade = PlayerPrefs.GetFloat("Damage");
       _damage += damageUpgrade;
   }

   private void Update()
   {
       RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, _distance, WhatIs);
       if (hitInfo.collider != null)
       {
           if (hitInfo.collider.CompareTag("Rock"))
           {
               hitInfo.collider.GetComponent<Rock>().TakeDamage(_damage);
           }

           if (hitInfo.collider.CompareTag("Enemy"))
           {
               hitInfo.collider.GetComponent<Enemy>().TakeDamage(_damage);
           }

           if (hitInfo.collider.CompareTag("Boss"))
           {
               hitInfo.collider.GetComponent<BossEnemy>().TakeDamage(_damage);
           }
           Destroy(gameObject);
       }

       transform.Translate(Vector3.right * _speed * Time.deltaTime);
   }
}
