using UnityEngine;

namespace PotatoGame.Player
{
    [CreateAssetMenu(menuName = "PotatoGame/Powers/Regular Potato")]
    public class RegularPotatoPower : PotatoPower
    {
        [SerializeField] private float damage = 10f;
        [SerializeField] private GameObject projectilePrefab;

        public override void Activate(PlayerController player)
        {
            if (projectilePrefab == null)
            {
                Debug.LogWarning("RegularPotatoPower requires a projectile prefab.");
                return;
            }

            Object.Instantiate(projectilePrefab, player.transform.position, Quaternion.identity);
        }

        public override bool CanActivate(PlayerController player)
        {
            return projectilePrefab != null;
        }
    }
}
