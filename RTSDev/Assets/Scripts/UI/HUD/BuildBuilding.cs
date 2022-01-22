using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTSGame.UI.HUD
{
    public class BuildBuilding : MonoBehaviour
    {
        public void OnClick()
        {
            Debug.Log(name);
            Buildings.BuildingPlacer.instance.SelectBuildingToPlace(name);
        }
    }

}