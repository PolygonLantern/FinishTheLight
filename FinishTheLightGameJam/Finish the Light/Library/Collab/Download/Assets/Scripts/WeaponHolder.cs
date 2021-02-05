using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponHolder : MonoBehaviour
{
   public Gun currentGun;
   

   private void Update()
   {
      CheckForShooting();
   }

   void CheckForShooting()
   {
        if (Input.GetMouseButtonDown(0))
            GetComponent<AudioSource>().Play();
        {
         RaycastHit raycastHit;
        
          
         if (Physics.Raycast(transform.position, transform.forward, out raycastHit, Mathf.Infinity))
         {
            IDamagable damagable = raycastHit.collider.GetComponent<IDamagable>();
               
            if (damagable != null)
            {
               damagable.DealDamage(currentGun.minDamage);
            }
         }
      }
   }
}
