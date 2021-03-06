using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSGame.Interactables
{
    public class IPillbox : IBuilding
    {
        private Collider[] colliders;
        [SerializeField]private Transform target;
        private StatDisplay targetStatDisplay;

        private FSM.FiniteStateMachine FiniteStateMachine;

        private bool hasAggro = false;
        private float atkCooldown;
        private string targetTag;

        //get from base stats
        public float range = 10;
        public float damage = 25;
        public float atkSpeed = 4;

        private void Awake()
        {
            if(tag == "Enemy")
            {
                targetTag = "Player";
            } else if(tag == "Player")
            {
                targetTag = "Enemy";
            }
        }
        // Update is called once per frame
        void Update()
        {
            atkCooldown -= Time.deltaTime;
            if(!hasAggro)
            {
                checkForTarget();
            } else
            {
                float distance = Vector3.Distance(target.position, transform.position);
                if (atkCooldown <= 0 && distance <= range)
                {
                    Attack();
                } else if (distance > range + 1)
                {
                    targetStatDisplay.takeDamage(damage);
                    atkCooldown = atkSpeed;
                }
                else
                {
                    hasAggro = false;
                }
            }
        }

        public override void OnInteractEnter()
        {
            base.OnInteractEnter();
        }
        void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, range);
        }

        private void checkForTarget()
        {
            colliders = Physics.OverlapSphere(transform.position, range, Units.UnitHandler.instance.pUnitLayer);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.CompareTag(targetTag))
                {
                    target = colliders[i].gameObject.transform;
                    targetStatDisplay = target.gameObject.GetComponentInChildren<StatDisplay>();
                    hasAggro = true;
                    break;
                }
            }
        }

        private void Attack()
        {
                targetStatDisplay.takeDamage(damage);
                atkCooldown = atkSpeed;
        }
    }
}

