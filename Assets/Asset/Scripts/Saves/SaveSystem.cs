using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{     
    [Header("Stats")]
    public float allScore;
    public float allDeath;
    public float allKills;
    public float allKillsBoss;
    public float allCollectCoins;
    public float allCoins;
    [Space(10)] 
    [Header("Buffs")] 
    public float _bombs;
    public float _doubleCoins;
    public float _magnit;
    [Space(10)] 
    [Header("Upgrades")] 
    public float jetPack;
    public float stamina;
    public float damage;

    private void Start()
  {
      allScore = PlayerPrefs.GetFloat("AllScore");
      allDeath = PlayerPrefs.GetFloat("AllDeath");
      allKills = PlayerPrefs.GetFloat("AllKills");
      allKillsBoss = PlayerPrefs.GetFloat("AllKillsBoss");
      allCollectCoins = PlayerPrefs.GetFloat("AllCollectCoins");
      allCoins = PlayerPrefs.GetFloat("AllCoins");
      jetPack = PlayerPrefs.GetFloat("JetPack");
      _doubleCoins = PlayerPrefs.GetFloat("DoubleCoin");
      _magnit = PlayerPrefs.GetFloat("Magnit");
      _bombs = PlayerPrefs.GetFloat("Bomb");
      stamina = PlayerPrefs.GetFloat("Stamina");
      damage = PlayerPrefs.GetFloat("Damage");
  }

  private void Update()
  {
      allScore = PlayerPrefs.GetFloat("AllScore");
      allDeath = PlayerPrefs.GetFloat("AllDeath");
      allKills = PlayerPrefs.GetFloat("AllKills");
      allKillsBoss = PlayerPrefs.GetFloat("AllKillsBoss");
      allCollectCoins = PlayerPrefs.GetFloat("AllCollectCoins");
      allCoins = PlayerPrefs.GetFloat("AllCoins");
  }

  public void ResetSaves()
  {
      PlayerPrefs.DeleteAll();
  }
}
