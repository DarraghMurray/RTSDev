using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSGame.FSM
{
    public class MoveToStorageState : AbstractFSMState
    {
        private Interactables.IScavenger scavenger;

        public override void OnEnable()
        {
            base.OnEnable();
            StateType = FSMStateType.MoveToStorage;
        }

        public override bool EnterState()
        {
            EnteredState = false;
            if (base.EnterState())
            {
                scavenger = unit.GetComponent<Interactables.IScavenger>();
                if (scavenger != null)
                {
                    EnteredState = true;
                }
            }
            return EnteredState;
        }

        public override void UpdateState()
        {
            if (scavenger.GetStorage() != null)
            {
                unit.MoveUnit(scavenger.GetStorage().position, scavenger.GetStorage().GetComponent<Interactables.IBuilding>().offset, () => {
                    Player.PlayerManager.instance.playerResources[scavenger.GetResourceType()].AddAmount(scavenger.GetResourceAmount());
                    scavenger.SetResourceAmount(0);
                    if (scavenger.GetResource() != null)
                    {
                        fsm.EnterState(FSMStateType.MoveToResource);
                    }
                    else
                    {
                        fsm.EnterState(FSMStateType.Idle);
                    }
                });
            }
        }
    }
}
