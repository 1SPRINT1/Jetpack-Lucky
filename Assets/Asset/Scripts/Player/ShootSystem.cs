using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
   [Header("Shoting-Setting")]
   [SerializeField] private GameObject _bullet;
   [SerializeField] private Transform _shootPosition;
   [Space(10)]
   [Header("Check-AutoShoot")]
   [SerializeField] private bool isAutoShoot;

   [Space(10)] [Header("Timer-Shoots")] 
   private float _startTimeShoots = 3f;
   private float _timeShoots;

   private void Update()
   {
      if (isAutoShoot == true)
      {
         Shoot();
      }
      _timeShoots -= Time.deltaTime;
   }

   public void Shoot()
   {
      if (_timeShoots <= 0)
      {
         Instantiate(_bullet, _shootPosition.transform.position, Quaternion.identity);
         _timeShoots = _startTimeShoots;
      }
   }
}
