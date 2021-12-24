using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Buildable Zone",menuName = "Buildable Zone")]
    public class BuildableZone : ScriptableObject
    {
        public int requiredGold;
        public int requiredStone;
        public int requiredWood;
    }
}
