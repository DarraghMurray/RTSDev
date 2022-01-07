using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace RTSGame.Units.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerUnit : MonoBehaviour
    {

        private NavMeshAgent navAgent;

        public UnitStatTypes.Base baseStats;

        public GameObject unitStatsDisplay;

        public Image heathBar;

        public float currentHealth;

        private void OnEnable()
        {
            navAgent = GetComponent<NavMeshAgent>(); 
        }
         
        private void Start()
        {
            currentHealth = baseStats.health;
        }
        private void Update()
        {
            HandleHeath();
        }

        // Update is called once per frame
        public void MoveUnit(Vector3 _destination)
        {
            navAgent.SetDestination(_destination);
        }

        public void takeDamage(float damage)
        {
            float totalDamage = damage;
            currentHealth -= totalDamage;
        }

        private void HandleHeath()
        {
            Camera camera = Camera.main;
            unitStatsDisplay.transform.LookAt(unitStatsDisplay.transform.position +
                camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up  );

            heathBar.fillAmount = currentHealth / baseStats.health;
            if (currentHealth <= 0)
            {
                InputManager.InputHandler.instance.selectedUnits.Remove(gameObject.transform);
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
