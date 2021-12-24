using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private Transform woodStackPos;
        [SerializeField] private Transform stoneStackPos;

        [SerializeField] private Text goldNumText;
        
        public List<GameObject> woods = new List<GameObject>();
        public List<GameObject> stones = new List<GameObject>();
        public int gold;

        private float addedWoodPos;
        private float addedStonePos;
        
        private GameObject addedWood;
        private GameObject addedStone;

        [SerializeField] private float objectsOffset=0.05f;
        [SerializeField] private float removeTime = 0.2f;

        #region Adding Components To Inventory Methods

        public void AddGold()//Add a gold to the inventory
        {
            gold += 1;
            goldNumText.text = gold.ToString();

        }

        public void AddWood(GameObject wood)//Add a wood to the list
        {
            addedWoodPos = woods.Count * (wood.transform.localScale.y + objectsOffset);
            addedWood = Instantiate(wood, woodStackPos.position + Vector3.up * addedWoodPos, Quaternion.identity);
            addedWood.transform.parent = woodStackPos;
            woods.Add(addedWood);
        }
        
        public void AddRock(GameObject stone)//Add a stone to the list
        {
            addedStonePos = stones.Count * (stone.transform.localScale.y + objectsOffset);
            addedStone = Instantiate(stone, stoneStackPos.position + Vector3.up * addedStonePos, Quaternion.identity);
            addedStone.transform.parent = stoneStackPos;
            stones.Add(addedStone);
        }

        #endregion

        #region Remove Components Methods
        
        //Removing the required components from the inventory
        public void RemoveRequiredObjects(int requiredGolds,int requiredWoods,int requiredStones,Transform buildingPos)
        {
            //RemoveWoods
            for (var i = 1; i <= requiredWoods; i++)
            {
                StartCoroutine(AnimateObject(woods[woods.Count - i], buildingPos));
                woods.RemoveAt(woods.Count - i);
            }
            //Remove Stones
            for (var i = 1; i <= requiredStones; i++)
            {
                StartCoroutine(AnimateObject(stones[stones.Count - i], buildingPos));
                stones.RemoveAt(stones.Count - i);
            }
            //RemoveGolds
            gold -= requiredGolds;
            goldNumText.text = gold.ToString();
            
        }
        
        private IEnumerator AnimateObject(GameObject x,Transform targetPos)//Animate a game-object to certain target
        {
            x.transform.parent = null;
            LeanTween.move(x, targetPos.position, removeTime).setEaseOutQuad();
            yield return new WaitForSeconds(removeTime);
            Destroy(x);
        }

        #endregion

    }
}
