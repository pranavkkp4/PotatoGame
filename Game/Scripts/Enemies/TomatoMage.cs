using UnityEngine;

namespace PotatoGame.Enemies
{
    public class TomatoMage : EnemyBase
    {
        [SerializeField] private float castRange = 6f;
        [SerializeField] private float castCooldown = 4f;
        [SerializeField] private GameObject spellPrefab;

        private Transform player;
        private float cooldownTimer;

        private void Start()
        {
            var playerController = FindObjectOfType<Player.PlayerController>();
            if (playerController != null)
            {
                player = playerController.transform;
            }
        }

        protected override void Patrol()
        {
            if (player == null)
            {
                return;
            }

            cooldownTimer -= Time.deltaTime;
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= castRange && cooldownTimer <= 0f)
            {
                CastSpell();
                cooldownTimer = castCooldown;
            }
        }

        private void CastSpell()
        {
            if (spellPrefab == null)
            {
                return;
            }

            Instantiate(spellPrefab, transform.position, Quaternion.identity);
        }
    }
}
