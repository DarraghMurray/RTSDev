using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSGame.Upgrades
{
    public class UpgradeHandler : MonoBehaviour
    {
        public static UpgradeHandler instance = null;

        private void Awake()
        {
            instance = this;
        }

        public void ApplyUpgrade(BasicUpgrade basicUpgrade)
        {
            foreach (Units.BasicUnit unit in basicUpgrade.units)
            {
                switch (basicUpgrade.upgradeType)
                {
                    case UpgradeType.Damage:
                        Debug.Log("made it");
                        unit.baseStats.damage *= (1 + basicUpgrade.size);
                        break;
                    case UpgradeType.Health:
                        unit.baseStats.health *= (1 + basicUpgrade.size);
                        break;
                    case UpgradeType.Range:
                        unit.baseStats.atkRange *= (1 + basicUpgrade.size);
                        break;
                    case UpgradeType.Speed:
                        unit.baseStats.atkSpeed *= (1 + basicUpgrade.size);
                        break;
                }
            }

            foreach (Buildings.BasicBuilding building in basicUpgrade.buildings)
            {
                switch (basicUpgrade.upgradeType)
                {
                    case UpgradeType.Damage:
                        building.baseStats.attack = building.baseStats.attack * (100 + basicUpgrade.size);
                        break;
                    case UpgradeType.Health:
                        building.baseStats.health = building.baseStats.health * (100 + basicUpgrade.size);
                        break;
                    case UpgradeType.Range:
                        building.baseStats.atkRange = building.baseStats.atkRange * (100 + basicUpgrade.size);
                        break;
                    case UpgradeType.Speed:
                        building.baseStats.atkSpeed = building.baseStats.atkSpeed * (100 + basicUpgrade.size);
                        break;
                }
                //Player.PlayerManager.instance.UpgradeActiveObjects(building.name);
            }
        }
    }
}
