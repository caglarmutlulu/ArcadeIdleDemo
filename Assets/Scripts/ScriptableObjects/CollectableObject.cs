using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Collectable Object", menuName = "Collectable Object")]
    public class CollectableObject : ScriptableObject
    {
        //public string objectType;//can be gold, tree or rock
        public float objectNum;
        public GameObject storedObject;
    }
}
