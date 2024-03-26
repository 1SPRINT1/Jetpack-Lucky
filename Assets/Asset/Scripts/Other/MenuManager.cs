using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Texts")] 
    [SerializeField] private TextMeshProUGUI _allScoreText;
    [SerializeField] private TextMeshProUGUI _allDeathText;
    [SerializeField] private TextMeshProUGUI _allCollectCoinsText;
    [SerializeField] private TextMeshProUGUI _allKillsBossText;
    [SerializeField] private TextMeshProUGUI _allKillsText;
    [SerializeField] private TextMeshProUGUI _allBombsText;
    [SerializeField] private TextMeshProUGUI _allDoubleScoreText;
    [SerializeField] private TextMeshProUGUI _allMagnitText;
    [SerializeField] private TextMeshProUGUI _allCoins;
    [Header("Parametrs")] 
    [SerializeField] private float allScore;
    [SerializeField] private float allCollectCoins;
    [SerializeField] private float allDeath;
    [SerializeField] private float allKillsBoss;
    [SerializeField] private float allKills;
    [SerializeField] private float bombs;
    [SerializeField] private float magnit;
    [SerializeField] private float doubleCoins;
    [SerializeField] private float allCoins;

    private void Start()
    {
        allScore = PlayerPrefs.GetFloat("AllScore");
        allCollectCoins = PlayerPrefs.GetFloat("AllCollectCoins");
        allDeath = PlayerPrefs.GetFloat("AllDeath");
        allKillsBoss = PlayerPrefs.GetFloat("AllKillsBoss");
        allKills = PlayerPrefs.GetFloat("AllKills");
        allCoins = PlayerPrefs.GetFloat("AllCoins");
        bombs = PlayerPrefs.GetFloat("Bomb");
        magnit = PlayerPrefs.GetFloat("Magnit");
        doubleCoins = PlayerPrefs.GetFloat("DoubleCoin");
    }

    private void Update()
    {
        _allScoreText.text = allScore.ToString();
        _allCollectCoinsText.text = allCollectCoins.ToString();
        _allDeathText.text = allDeath.ToString();
        _allKillsBossText.text = allKillsBoss.ToString();
        _allKillsText.text = allKills.ToString();
        _allBombsText.text = bombs.ToString();
        _allMagnitText.text = magnit.ToString();
        _allDoubleScoreText.text = doubleCoins.ToString();
        _allCoins.text = allCoins.ToString();
    }

    public void GiveBomb()
   {
       bombs++;
   }

   public void GiveDoubleCoin()
   {
       doubleCoins++;
   }

   public void GiveMagnit()
   {
       magnit++;
   }

   public void StartGame()
   {
       SceneManager.LoadScene("Game");
   }
}
