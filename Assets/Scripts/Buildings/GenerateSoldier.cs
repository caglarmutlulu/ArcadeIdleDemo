using Player;
using UnityEngine;

namespace Buildings
{
    public class GenerateSoldier : MonoBehaviour
    {
        public int requirementGold = 1;
        public int requirementWood = 1;
        public int requirementStone = 1;

        public bool isGeneratable = true;
            
        [SerializeField] private GameObject soldierObject;
        [SerializeField] private Transform generatePos;
        //[SerializeField] private int soldierCapacity = 2;
        
        public bool Check(PlayerInventory inventory)//Check inventory has required components
        {
            return requirementGold <= inventory.gold && 
                   requirementWood <= inventory.woods.Count&&
                   requirementStone <= inventory.stones.Count;
        }

        public void Generate()//Method to generate a soldier
        {
            if(!isGeneratable) return;
            
            var existSoldier = generatePos.childCount;
            Instantiate(soldierObject, generatePos.position + Vector3.right * existSoldier, Quaternion.identity, generatePos);
        }
    }
}
