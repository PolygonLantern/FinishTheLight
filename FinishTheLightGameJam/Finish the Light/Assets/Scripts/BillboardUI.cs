using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardUI : MonoBehaviour
{
   private Camera _playerCamera;

   private void Start()
   {
      _playerCamera = Camera.main;
   }

   private void LateUpdate()
   {
      LookAtPlayer();
   }

   void LookAtPlayer()
   {
      transform.LookAt(transform.position + _playerCamera.transform.forward);
   }
}
