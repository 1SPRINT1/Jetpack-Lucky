using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
   private PlayerController _pc;
   private float _speed;
   private float _magnitSpeed = 20f;
   public bool isMagint = false;

   private void Start()
   {
       _pc = FindObjectOfType<PlayerController>();
   }

   private void Update()
   {
       if (isMagint == true)
       {
           Vector3.MoveTowards(transform.position, _pc.transform.position, _magnitSpeed * Time.deltaTime);
       }
       else
       {
           transform.Translate(-_speed * Time.deltaTime,0f,0f);
       }
   }
}
