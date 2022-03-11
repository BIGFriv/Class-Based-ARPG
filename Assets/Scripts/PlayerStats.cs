using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BFM
{
    public class PlayerStats : MonoBehaviour
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public int staminaLevel = 10;
        public int maxStamina;
        public int currentStamina;

        public HealthBar healthbar;
        public StaminaBar staminaBar;

        AnimatorHandler animatorHandler;

        private void Awake()
        {
            healthbar = FindObjectOfType<HealthBar>();
            staminaBar = FindObjectOfType<StaminaBar>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        // Start is called before the first frame update
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthbar.SetMaxHealth(maxHealth);
            healthbar.SetCurrentHealth(currentHealth);


            maxStamina = SetMaxStaminaFromStaminaLevel();
            currentStamina = maxStamina;
            staminaBar.SetMaxStamina(maxStamina);
            staminaBar.SetCurrentStamina(currentStamina);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            // Health Formula - TO CHANGE LATER
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        private int SetMaxStaminaFromStaminaLevel()
        {
            // Health Formula - TO CHANGE LATER
            maxStamina = staminaLevel * 10;
            return maxStamina;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            healthbar.SetCurrentHealth(currentHealth);

            animatorHandler.PlayTargetAnimation("Damage_01", true);

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Dead_01", true);
                //Handle Player Death
            }
        }

        public void TakeStaminaDamage(int damage)
        {
            currentStamina = currentStamina - damage;
            staminaBar.SetCurrentStamina(currentStamina);
        }
    }
}

