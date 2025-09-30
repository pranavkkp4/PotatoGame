using UnityEngine;

namespace PotatoGame.Player
{
    [CreateAssetMenu(menuName = "PotatoGame/Powers/Bouncy Potato")]
    public class BouncyPotatoPower : PotatoPower
    {
        [SerializeField] private float launchVelocity = 20f;
        [SerializeField] private GameObject projectilePrefab;

        public override void Activate(PlayerController player)
        {
            if (projectilePrefab == null)
            {
                Debug.LogWarning("BouncyPotatoPower requires a projectile prefab.");
                return;
            }

            Object.Instantiate(projectilePrefab, player.transform.position, Quaternion.identity);
            var body = player.GetComponent<Rigidbody2D>();
            if (body != null)
            {
                body.velocity = new Vector2(body.velocity.x, launchVelocity);
            }
        }

        public override bool CanActivate(PlayerController player)
        {
            return projectilePrefab != null;
        }
    }
}
