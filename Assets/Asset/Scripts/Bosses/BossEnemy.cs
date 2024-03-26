using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{
    [Header("Enemy-Statisticks")] 
    [SerializeField] private float _health;
    private GameManager GM;
    [Header("Jobs - UI")] 
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _otherSlider;
    [SerializeField] private GameObject _coinsUI;
    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
        _slider.maxValue = _health;
        _slider.enabled = true;
        _otherSlider.SetActive(false);
        _coinsUI.SetActive(false);
        _health = Random.Range(7,15);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        GM.score += 300;
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
            GM.score += 1000;
            GM._allKills++;
            GM._allBossKills++;
            _otherSlider.SetActive(true);
            _coinsUI.SetActive(true);
            _slider.enabled = false;
        }
        _slider.value = _health;
    }
}
