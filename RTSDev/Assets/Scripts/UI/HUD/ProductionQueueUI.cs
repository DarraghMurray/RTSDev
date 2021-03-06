using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RTSGame.UI.HUD
{
    public class ProductionQueueUI : MonoBehaviour
    {
        [SerializeField]
        private List<Image> images;
        [SerializeField] private Transform layoutGroup = null;
        [SerializeField] private Image productionImage = null;

        [SerializeField]
        private Image progressBar;

        private void Awake()
        {
            progressBar.fillAmount = 0;
        }

        public void AddToQueue(string name)
        {
            Image temp = Instantiate(productionImage, layoutGroup);
            temp.name = name.Substring(0, name.Length-1);
            images.Add(temp);
        }

        public void RemoveFromQueue()
        {
            images.RemoveAt(0);
            Destroy(layoutGroup.GetChild(0).gameObject);
        }

        public void ClearQueue()
        {
            images.Clear();
            foreach (Transform child in layoutGroup)
            {
                Destroy(child.gameObject);
            }
            
        }

        public void FillQueue(List<Buildings.SpawnableObject> queue)
        {
            ClearQueue();
            foreach(Buildings.SpawnableObject temp in queue)
            {
                AddToQueue(temp.order.unitName);
            }
        }

        public void SetProgressAmount(float amount)
        {
            progressBar.fillAmount = amount;
        }
    }
}

