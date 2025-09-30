using UnityEngine;

namespace PotatoGame.Player
{
    [CreateAssetMenu(menuName = "PotatoGame/Powers/Explosive Potato")]
    public class ExplosivePotatoPower : PotatoPower
    {
        [SerializeField] private float radius = 3f;
        [SerializeField] private float damage = 30f;
        [SerializeField] private GameObject projectilePrefab;

        public override void Activate(PlayerController player)
        {
            if (projectilePrefab == null)
            {
                Debug.LogWarning("ExplosivePotatoPower requires a projectile prefab.");
                return;
            }

            Object.Instantiate(projectilePrefab, player.transform.position, Quaternion.identity);
        }

        public override bool CanActivate(PlayerController player)
        {
            return projectilePrefab != null;
        }

        public float Radius => radius;
        public float Damage => damage;
    }
}
