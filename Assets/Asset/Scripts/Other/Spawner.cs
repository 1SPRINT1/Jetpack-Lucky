using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
   [SerializeField] private GameObject[] _objects;
   private Vector3 _spawnPosition;
   [Space(10)]
   [Header("Spawn-Timer")]
   [SerializeField] private float _timer;
   [SerializeField]private float _startTimer = 4f;
   [Space(10)] 
   [Header("TimeRate-timer")] 
   private float _timeTimer;
   private float _lateTimer = 10f;

   private void Start()
   {
      _timeTimer = _lateTimer;
   }

   private void Update()
   {
      _spawnPosition = new Vector3(10f,Random.Range(-4.3f,4.3f),0f);
      _timer -= Time.deltaTime;
      _timeTimer -= Time.deltaTime;
      if (_timer <= 0)
      {
         Spawners();
         _timer = _startTimer;
      }

      if (_startTimer <= 1f)
      {
         _startTimer = 1f;
      }

      if (_timeTimer <= 0f)
      {
         _startTimer -= 0.5f;
         _timeTimer = _lateTimer;
      }
   }

   private void Spawners()
   {
      Instantiate(_objects[Random.Range(0, _objects.Length)],_spawnPosition , Quaternion.identity);
   }
}
