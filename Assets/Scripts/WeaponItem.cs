using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BFM
{
  [CreateAssetMenu(menuName = "Items/Weapon Item")]
  public class WeaponItem : Item
  {
      public GameObject modelPrefab;
      public bool isUnarmed;

      [Header("Idle Animations")]
      public string right_Hand_Idle;
      public string left_Hand_Idle;

      [Header("One Handed Attack Animations")]
      public string OH_Light_Attack_01;
      public string OH_Light_Attack_02;
      public string OH_Light_Attack_03;
      public string OH_Heavy_Attack_01;

        [Header("Stamina Costs")]
        public int baseStamina;
        public float lightAttackMultiplier;
        public float heavyAttackMultiplier;
      
  }
}
