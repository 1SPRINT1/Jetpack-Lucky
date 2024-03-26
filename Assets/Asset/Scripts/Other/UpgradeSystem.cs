using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
   [Header("Parametrs")]
   [SerializeField] private float jetPack;
   [SerializeField] private float stamina;
   [SerializeField] private float damage;
   [SerializeField] private float _allCoins;
   [Space(10)] 
   [Header("JetPack - Upgrade")] 
   [SerializeField] private GameObject[] blocksJet;

   [Space(10)] 
   [Header("Stamina - Upgrade")] 
   [SerializeField] private GameObject[] blocksStamina;

   [Space(10)]
   [Header("Damage - Upgrade")]
   [SerializeField] private GameObject[] blocksDamage;

   private void Start()
   {
       jetPack = PlayerPrefs.GetFloat("JetPack");
       stamina = PlayerPrefs.GetFloat("Stamina");
       damage = PlayerPrefs.GetFloat("Damage");
       _allCoins = PlayerPrefs.GetFloat("AllCoins");
   }

   private void Update()
   {
       jetPack = PlayerPrefs.GetFloat("JetPack");
       stamina = PlayerPrefs.GetFloat("Stamina");
       damage = PlayerPrefs.GetFloat("Damage");
       _allCoins = PlayerPrefs.GetFloat("AllCoins");
       if (jetPack >= 5)
       {
           jetPack = 5;
           PlayerPrefs.SetFloat("JetPack",jetPack);
       }

       if (stamina >= 5)
       {
           stamina = 5;
           PlayerPrefs.SetFloat("Stamina",stamina);
       }

       if (damage >= 5)
       {
           damage = 5;
           PlayerPrefs.SetFloat("Damage",damage);
       }
   }

   public void BuyJetPack()
   {
       if (_allCoins >= 1000)
       {
           jetPack++;
           _allCoins -= 1000f;
           PlayerPrefs.SetFloat("JetPack",jetPack);
           PlayerPrefs.SetFloat("AllCoins",_allCoins);
           for (int i = 0; i < blocksJet.Length; i++)
           {
               if (i < jetPack)
               {
                   blocksJet[i].SetActive(true);
               }
               else
               {
                   blocksJet[i].SetActive(false);
               }
           }
       }

   }
   public void BuyStamina()
   {
       if (_allCoins >= 1000)
       {
           stamina++;
           _allCoins -= 1000f;
           PlayerPrefs.SetFloat("JetPack",stamina);
           PlayerPrefs.SetFloat("AllCoins",_allCoins);
           for (int i = 0; i < blocksStamina.Length; i++)
           {
               if (i < stamina)
               {
                   blocksStamina[i].SetActive(true);
               }
               else
               {
                   blocksStamina[i].SetActive(false);
               }
           }
       }

   }
   public void BuyDamage()
   {
       if (_allCoins >= 1000)
       {
           damage++;
           _allCoins -= 1000f;
           PlayerPrefs.SetFloat("JetPack",damage);
           PlayerPrefs.SetFloat("AllCoins",_allCoins);
           for (int i = 0; i < blocksDamage.Length; i++)
           {
               if (i < damage)
               {
                   blocksDamage[i].SetActive(true);
               }
               else
               {
                   blocksDamage[i].SetActive(false);
               }
           }
       }

   }
}
