using System.Collections.Generic;
using UnityEngine;

namespace PotatoGame.UI
{
    public class PowerWheelUI : MonoBehaviour
    {
        [SerializeField] private GameObject slotPrefab;
        [SerializeField] private Transform slotContainer;
        [SerializeField] private Player.PotatoPowerManager powerManager;

        private readonly List<GameObject> slots = new List<GameObject>();

        private void Start()
        {
            Refresh();
        }

        public void Refresh()
        {
            foreach (var slot in slots)
            {
                Destroy(slot);
            }
            slots.Clear();

            if (slotPrefab == null || slotContainer == null || powerManager == null)
            {
                return;
            }

            // Placeholder representation: create three slots regardless of assignment
            for (int i = 0; i < 3; i++)
            {
                var slot = Instantiate(slotPrefab, slotContainer);
                slots.Add(slot);
            }
        }
    }
}
