using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private float _health = 1;
    [SerializeField] private float _speed;
    private GameManager GM;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.Translate(-_speed * Time.deltaTime,0f,0f);
        if (_health <= 0)
        {
            Destroy(gameObject);
            GM.score += 100;
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        GM.score += 100;
    } 
}
