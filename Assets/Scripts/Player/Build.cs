using System;
using Buildings;
using UnityEngine;

namespace Player
{
    public class Build : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Building"))//Generating Buildings
            {
                var building = other.gameObject.transform.parent.GetComponent<BuildableZoneController>();
                var inventory = gameObject.GetComponent<PlayerInventory>();
                if (building.CheckBuildable(inventory) && !building.isBuilded)
                {
                    inventory.RemoveRequiredObjects(building.requiredGolds, building.requiredWoods, building.requiredStones, other.transform);
                    building.isBuilded = true;
                    building.BuildZone();
                }
                else
                {
                    Debug.Log("Inventory not enough");
                }
                
            }
            else if (other.gameObject.CompareTag("GeneratorBuildings"))//Generating Soldiers
            {
                var component = other.gameObject.GetComponent<GenerateSoldier>();
                var inventory = gameObject.GetComponent<PlayerInventory>();

                if (component.Check(inventory) && component.isGeneratable)
                {
                    inventory.RemoveRequiredObjects(component.requirementGold,component.requirementWood,component.requirementStone,other.transform);
                    component.Generate();
                    //Setting the boolean variable to generate one soldier once per trigger
                    component.isGeneratable = false;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("GeneratorBuildings"))
            {
                //Setting the boolean variable to generate one soldier once per trigger
                var component = other.gameObject.GetComponent<GenerateSoldier>();
                component.isGeneratable = true;
            }
        }
    }
}
