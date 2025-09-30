using UnityEngine;

namespace PotatoGame.Enemies
{
    public class TomatoKing : EnemyBase
    {
        [SerializeField] private float stompCooldown = 6f;
        [SerializeField] private float stompRadius = 5f;
        [SerializeField] private int stompDamage = 30;

        private float stompTimer;

        protected override void Patrol()
        {
            stompTimer -= Time.deltaTime;
            if (stompTimer <= 0f)
            {
                PerformStomp();
                stompTimer = stompCooldown;
            }
        }

        private void PerformStomp()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, stompRadius);
            foreach (var hit in hits)
            {
                var player = hit.GetComponent<Player.PlayerController>();
                if (player != null)
                {
                    Debug.Log("Tomato King stomped the player!");
                }
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, stompRadius);
        }
#endif
    }
}
