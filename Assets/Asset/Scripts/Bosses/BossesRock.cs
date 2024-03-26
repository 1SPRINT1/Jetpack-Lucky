using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossesRock : MonoBehaviour
{
    [SerializeField] private int _health = 1;
    [SerializeField] private float _speed;
    private GameManager GM;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.Translate(-_speed * Time.deltaTime,0f,0f);
        if (transform.position.x == 7f)
        {
            _speed = 0;
        }
        if (_health <= 0)
        {
            Destroy(gameObject);
            GM.score += 100;
            GM._allKills++;
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        GM.score += 100;
    }  
}
