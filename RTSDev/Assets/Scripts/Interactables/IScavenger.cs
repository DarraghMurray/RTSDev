using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSGame.Interactables
{
    public class IScavenger :IUnit
    {

        public RTSResources.ResourceType type;
        private float resourceAmt = 0;
        private float carryLimit = 10;

        private Transform resourceTransform;
        private Transform storageTransform;
        private Units.Player.PlayerUnit unit;

        private void Awake()
        {
            unit = GetComponent<Units.Player.PlayerUnit>();
        }

        public override void OnInteractEnter()
        {
            base.OnInteractEnter();
        }

        public override void OnInteractExit()
        {
            base.OnInteractExit();
        }

        public Transform GetResource()
        {
            return resourceTransform;
        }

        public Transform GetStorage()
        {
            return storageTransform;
        }

        public void SetResource(Transform tf)
        {
            RTSResources.ResourceSource source = tf.GetComponent<RTSResources.ResourceSource>();
            if (resourceAmt > 0 && type != source.GetResourceType())
            {
            } else
            {
                resourceTransform = tf;
                type = source.GetResourceType();
                unit.SetFiniteState(FSM.FSMStateType.MoveToResource);
            }
        }

        public void SetStorage(Transform tf)
        {
            storageTransform = tf;
            unit.SetFiniteState(FSM.FSMStateType.MoveToStorage);
        }

        public RTSResources.ResourceType GetResourceType()
        {
            return type;
        }

        public bool ExceededLimit()
        {
            if(resourceAmt > carryLimit - 1)
            {
                return true;
            }
            return false;
        }

        public float GetResourceAmount()
        {
            return resourceAmt;
        }

        public void SetResourceAmount(float amount)
        {
            resourceAmt = amount;
        }

        public void PlayAnimationMine(Vector3 position, float v, Action p)
        {
            p.Invoke();
        }
    }
}

