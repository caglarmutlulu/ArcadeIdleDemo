using System.Collections;
using Player;
using ScriptableObjects;
using UnityEngine;

namespace Buildings
{
    public class BuildableZoneController : MonoBehaviour
    {
        [SerializeField] private BuildableZone buildableZone;

        [SerializeField] private GameObject emptyZone;
        [SerializeField] private GameObject building;

        [SerializeField] private float buildingTime = 2f; 
    
        public bool isBuilded = false;

        public int requiredGolds;
        public int requiredWoods;
        public int requiredStones;
    
        private void Start()
        {
            requiredGolds = buildableZone.requiredGold;
            requiredWoods = buildableZone.requiredWood;
            requiredStones = buildableZone.requiredStone;
        }

   
        public bool CheckBuildable(PlayerInventory inventory)//Check for required components
        {

            return requiredGolds <= inventory.gold && 
                   requiredStones <= inventory.stones.Count &&
                   requiredWoods <= inventory.woods.Count;
        }

        public void BuildZone()//Build the building
        {
            StartCoroutine(WaitAndBuild());
        }

        private IEnumerator WaitAndBuild()
        {
            yield return new WaitForSeconds(buildingTime);
            emptyZone.SetActive(false);
            building.SetActive(true);
        }
    
    
    }
}
