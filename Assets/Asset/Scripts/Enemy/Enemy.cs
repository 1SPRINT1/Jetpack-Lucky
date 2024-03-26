using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy-Statisticks")]
    [SerializeField] private float _health = 1;
    private GameManager GM;
   // [SerializeField] private float _speed = 3f;

   private void Start()
   {
       GM = FindObjectOfType<GameManager>();
   }

   public void TakeDamage(float damage)
    {
        _health -= damage;
        GM.score += 100;
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
            GM.score += 300;
        }
     //   transform.Translate(-_speed * Time.deltaTime,0f,0f); 
    }
}
