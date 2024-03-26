using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using Random = UnityEngine.Random;

public class FortuneWheel : MonoBehaviour
{
   private int numberOfTurns; //Кол-во оборотов
   private int WhatIsWin; // Что получаем?

   private float _speed;
   private bool canWeTurn; // Крутится?
   private bool isTurn = false; // Нажата ли кнопка вращения?
  [SerializeField] private GameObject BombWinning;
  [SerializeField] private GameObject MagnintWinning;
  [SerializeField] private GameObject X2ScoreWinning;

   private void Start()
   {
       canWeTurn = true;
   }

   private void Update()
   {
       if (isTurn == true && canWeTurn == true)
       {
           StartCoroutine(TurnToWheel());
       }
   }

   public void Turn()
   {
       isTurn = true;
   }

   private IEnumerator TurnToWheel()
   {
       canWeTurn = false;
       isTurn = false;
       numberOfTurns = Random.Range(5, 10);
       _speed = 0.01f;
       for (int i = 0; i < numberOfTurns; i++)
       {
           transform.Rotate(0,0,22.5f);
           if (i > Mathf.RoundToInt(numberOfTurns * 0.5f))
           {
               _speed = 0.02f;
           }
           if (i > Mathf.RoundToInt(numberOfTurns * 0.7f))
           {
               _speed = 0.07f;
           }
           if (i > Mathf.RoundToInt(numberOfTurns * 0.9f))
           {
               _speed = 0.01f;
           }
           yield return new WaitForSeconds(_speed);
       }

       if (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
       {
           transform.Rotate(0,0,22.5f);
       }

       WhatIsWin = Mathf.RoundToInt(transform.eulerAngles.z);

       switch (WhatIsWin)
       {
           case 0:
               BombWinning.SetActive(true);
               break;
           case 45:
               MagnintWinning.SetActive(true);
               break;
           case 90:
               X2ScoreWinning.SetActive(true);
               break;
           case 135:
               BombWinning.SetActive(true);
               break;
           case 180:
               MagnintWinning.SetActive(true);
               break;
           case 225:
               X2ScoreWinning.SetActive(true);
               break;
           case 270:
               BombWinning.SetActive(true);
               break;
           case 315:
               MagnintWinning.SetActive(true);
               break;
       }

       canWeTurn = true;
   } 
}
