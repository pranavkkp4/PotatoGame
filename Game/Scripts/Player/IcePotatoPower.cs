using UnityEngine;

namespace PotatoGame.Player
{
    [CreateAssetMenu(menuName = "PotatoGame/Powers/Ice Potato")]
    public class IcePotatoPower : PotatoPower
    {
        [SerializeField] private float freezeDuration = 3f;
        [SerializeField] private GameObject projectilePrefab;

        public override void Activate(PlayerController player)
        {
            if (projectilePrefab == null)
            {
                Debug.LogWarning("IcePotatoPower requires a projectile prefab.");
                return;
            }

            Object.Instantiate(projectilePrefab, player.transform.position, Quaternion.identity);
        }

        public override bool CanActivate(PlayerController player)
        {
            return projectilePrefab != null;
        }

        public float FreezeDuration => freezeDuration;
    }
}
