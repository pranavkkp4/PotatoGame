using System.Collections;
using UnityEngine;

namespace PotatoGame.Enemies
{
    public class TomatoSpearThrower : EnemyBase
    {
        [SerializeField] private GameObject spearPrefab;
        [SerializeField] private Transform throwOrigin;
        [SerializeField] private float throwCooldown = 2f;

        private float cooldownTimer;

        protected override void Patrol()
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                ThrowSpear();
                cooldownTimer = throwCooldown;
            }
        }

        private void ThrowSpear()
        {
            if (spearPrefab == null || throwOrigin == null)
            {
                return;
            }

            Instantiate(spearPrefab, throwOrigin.position, Quaternion.identity);
        }
    }
}
