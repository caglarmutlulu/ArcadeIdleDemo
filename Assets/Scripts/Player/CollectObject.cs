using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    public class CollectObject : MonoBehaviour
    {
        [SerializeField] private float collectTime = 0.5f;
        
        private PlayerInventory playerInventory;
        
        private bool isWait = true;

        private void Start()
        {
            playerInventory = GetComponent<PlayerInventory>();
        }
        
        private void CollectGold(CollectableObjectSetter collectableObjectSetter)//Collect golds from the source
        {
            if (collectableObjectSetter.objectNum > 0)
            {
                playerInventory.AddGold();
                collectableObjectSetter.DecreaseNum();
            }
        }
        
        private void CollectWood(CollectableObjectSetter collectableObjectSetter)//Collect woods from the tree
        {
            if (collectableObjectSetter.objectNum > 0)
            {
                playerInventory.AddWood(collectableObjectSetter.storedObject);
                collectableObjectSetter.DecreaseNum();
            }
        }
        
        private void CollectStone(CollectableObjectSetter collectableObjectSetter)//Collect woods from the rock
        {
            if (collectableObjectSetter.objectNum > 0)
            {
                playerInventory.AddRock(collectableObjectSetter.storedObject);
                collectableObjectSetter.DecreaseNum();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (isWait)
            {
                if (other.gameObject.CompareTag("Tree"))
                {
                    CollectWood(other.gameObject.GetComponent<CollectableObjectSetter>());
                    StartCoroutine(WaitASecond());//Wait a certain second and add component
                }
                else if (other.gameObject.CompareTag("Rock"))
                {
                    CollectStone(other.gameObject.GetComponent<CollectableObjectSetter>());
                    StartCoroutine(WaitASecond());//Wait a certain second and add component
                }
                else if (other.gameObject.CompareTag("Gold"))
                {
                    CollectGold(other.gameObject.GetComponent<CollectableObjectSetter>());
                    StartCoroutine(WaitASecond());//Wait a certain second and add component
                }
            }
        }

        private IEnumerator WaitASecond()
        {
            isWait = false;
            yield return new WaitForSeconds(collectTime);
            isWait = true;
        }
    }
}
