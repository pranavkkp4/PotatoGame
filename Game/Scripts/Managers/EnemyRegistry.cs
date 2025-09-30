using System.Collections.Generic;
using UnityEngine;

namespace PotatoGame.Managers
{
    [CreateAssetMenu(menuName = "PotatoGame/Enemy Registry")]
    public class EnemyRegistry : ScriptableObject
    {
        [System.Serializable]
        public class Entry
        {
            public string id;
            public GameObject prefab;
        }

        [SerializeField] private List<Entry> entries = new List<Entry>();

        public GameObject Resolve(string id)
        {
            foreach (var entry in entries)
            {
                if (entry.id == id)
                {
                    return entry.prefab;
                }
            }

            return null;
        }
    }
}
