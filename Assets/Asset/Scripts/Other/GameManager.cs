using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class GameManager : MonoBehaviour
{
    [Header("All-Text")]
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textAllScore;
    public TextMeshProUGUI textCoins;
    public TextMeshProUGUI textCoins2;
    public TextMeshProUGUI textBomb;
    public TextMeshProUGUI textDoubleCoin;
    public TextMeshProUGUI textMagnit;
    [Space(10)] 
    [Header("All-Variables")] 
    public float score = 0;
    public float coins = 0;
    [Space(10)] 
    [Header("Hide-Variables")] 
    private float _allScore;
    public float _allCoins;
    public float _allKills;
    public float _allBossKills;
    public float _allDeaths;
    private float _allBomb;
    private float _allMagnit;
    private float _allDoubleCoin;
    [Space(10)] 
    [Header("All-Upgrades")] 
    public float jetPack;
    public float stamina;
    public float damageBullet;
    [Space(10)] 
    [Header("Buffs")] 
    private bool isMagnits = false;
    public bool isX2Score = false;
    [SerializeField] private GameObject X2Image;
    [SerializeField] private GameObject _boomEffect;
    [Space(10)] 
    [Header("Acesses")] 
    [SerializeField] private PlayerController _pc;
    [SerializeField] private Enemy[] _enemys;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        _allCoins = PlayerPrefs.GetFloat("AllCollectCoins");
        _allKills = PlayerPrefs.GetFloat("AllKills");
        _allScore = PlayerPrefs.GetFloat("AllScore");
        _allBossKills = PlayerPrefs.GetFloat("AllKillsBoss");
        _allDeaths = PlayerPrefs.GetFloat("AllDeath");
        
        jetPack = PlayerPrefs.GetFloat("JetPack");
        stamina = PlayerPrefs.GetFloat("Stamina");
        damageBullet = PlayerPrefs.GetFloat("Damage");
        
        _allBomb = PlayerPrefs.GetFloat("Bomb");
        _allDoubleCoin = PlayerPrefs.GetFloat("DoubleCoin");
        _allMagnit = PlayerPrefs.GetFloat("Magnit");
        
        PlayerPrefs.SetFloat("AllScore",score);
        PlayerPrefs.SetFloat("AllKills", _allKills);
        PlayerPrefs.SetFloat("AllKillsBoss",_allBossKills);
        PlayerPrefs.SetFloat("AllDeath",_allDeaths);
        
        textScore.text = score.ToString();
        textCoins.text = coins.ToString();
        textAllScore.text = score.ToString();
        textCoins2.text = coins.ToString();
        
        textBomb.text = _allBomb.ToString();
        textMagnit.text = _allMagnit.ToString();
        textDoubleCoin.text = _allDoubleCoin.ToString();
        
        if (isX2Score == true)
        {
            X2Image.SetActive(true);
        }
        else
        {
            X2Image.SetActive(false);
        }

        _enemys = FindObjectsOfType<Enemy>();
    }

        
    public void BoomButton()
    {
        if (_allBomb > 0)
        {
            for (int i = 0; i < _enemys.Length; i++)
            {
                Destroy(_enemys[i]);
            }

            Instantiate(_boomEffect, _pc.transform.position, Quaternion.identity);
            _allBomb--;
            PlayerPrefs.SetFloat("Bomb",_allBomb);
        }
    }

    public void X2ScoreButton()
    {
        if (_allDoubleCoin > 0)
        {
            isX2Score = true;
            _allDoubleCoin--;
            PlayerPrefs.SetFloat("DoubleCoin",_allDoubleCoin);
        }
    }

    public void MagnitButton()
    {
        if (_allMagnit > 0)
        {
            isMagnits = true;
            _allMagnit--;
            PlayerPrefs.SetFloat("Magnit",_allMagnit);
        }
    }
}
