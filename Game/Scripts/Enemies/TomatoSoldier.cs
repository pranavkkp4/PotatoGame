using UnityEngine;

namespace PotatoGame.Enemies
{
    public class TomatoSoldier : EnemyBase
    {
        [SerializeField] private Transform[] patrolPoints;
        private int patrolIndex;

        protected override void Patrol()
        {
            if (patrolPoints == null || patrolPoints.Length == 0)
            {
                return;
            }

            Transform target = patrolPoints[patrolIndex];
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

            if (Vector2.Distance(transform.position, target.position) < 0.1f)
            {
                patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
            }
        }
    }
}
