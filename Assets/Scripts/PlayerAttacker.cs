using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BFM
{
  public class PlayerAttacker : MonoBehaviour
  {
    AnimatorHandler animatorHandler;
        InputHandler inputHandler;
        WeaponSlotManager weaponSlotManager;
        public string lastAttack;


      public void Awake()
      {
        animatorHandler = GetComponentInChildren<AnimatorHandler>();
        weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        inputHandler = GetComponent<InputHandler>();
            
      }

        public void HandleWeaponCombo(WeaponItem weapon)
        {
            if(inputHandler.comboFlag)
            {
                Debug.Log("Stepping into Combo Method");
                animatorHandler.anim.SetBool("canDoCombo", false);

                if(lastAttack == weapon.OH_Light_Attack_01)
                {
                    animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_02, true);
                    lastAttack = weapon.OH_Light_Attack_02;
                }
                else if (lastAttack == weapon.OH_Light_Attack_02)
                {
                    animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_03, true);
                    lastAttack = weapon.OH_Light_Attack_03;
                }
            }
            
        }
      public void HandleLightAttack(WeaponItem weapon)
      {
            weaponSlotManager.attackingWeapon = weapon;
          animatorHandler.PlayTargetAnimation(weapon.OH_Light_Attack_01, true);
          lastAttack = weapon.OH_Light_Attack_01;
      }

      public void HandleHeavyAttack(WeaponItem weapon)
      {
            weaponSlotManager.attackingWeapon = weapon;
            animatorHandler.PlayTargetAnimation(weapon.OH_Heavy_Attack_01, true);
            lastAttack = weapon.OH_Heavy_Attack_01;
      }
  }
}
