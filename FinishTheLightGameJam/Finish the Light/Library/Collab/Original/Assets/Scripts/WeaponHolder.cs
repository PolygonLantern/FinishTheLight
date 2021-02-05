using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
   [SerializeField] private List<Gun> guns = new List<Gun>();
   private Gun _equippedGun;
   private GameObject _equippedGunPrefab;
   private Transform _cameraTransform;

   private void Start()
   {
     _cameraTransform = Camera.main.transform;
     _equippedGunPrefab = Instantiate(guns[0].gunPrefab, transform);
     _equippedGun = guns[0];
   }

   private void Update()
   {
      CheckForShooting();

      if (Input.GetKeyDown(KeyCode.Alpha1))
      {
         Destroy(_equippedGunPrefab);
         _equippedGunPrefab = Instantiate(guns[0].gunPrefab, transform);
         _equippedGun = guns[0];
      }
      else if (Input.GetKeyDown(KeyCode.Alpha2))
      {
         Destroy(_equippedGunPrefab);
         _equippedGunPrefab = Instantiate(guns[1].gunPrefab, transform);
         _equippedGun = guns[1];
      }
   }

   void CheckForShooting()
   {
      if (Input.GetMouseButtonDown(0))
      {
         RaycastHit raycastHit;
            
            
         if (Physics.Raycast(_cameraTransform.position, transform.forward, out raycastHit, Mathf.Infinity))
         {
            IDamagable damagable = raycastHit.collider.GetComponent<IDamagable>();
               
            if (damagable != null)
            {
               damagable.DealDamage(_equippedGun.maxDamage);
            }
         }
      }
   }
}
