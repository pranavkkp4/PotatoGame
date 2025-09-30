using UnityEngine;

namespace PotatoGame.Enemies
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField] protected float maxHealth = 50f;
        [SerializeField] protected float moveSpeed = 2f;
        [SerializeField] protected int damage = 10;

        protected float currentHealth;
        protected bool isFrozen;
        protected float freezeTimer;

        protected virtual void Awake()
        {
            currentHealth = maxHealth;
        }

        protected virtual void Update()
        {
            if (isFrozen)
            {
                freezeTimer -= Time.deltaTime;
                if (freezeTimer <= 0f)
                {
                    isFrozen = false;
                }

                return;
            }

            Patrol();
        }

        protected abstract void Patrol();

        public virtual void TakeDamage(float amount)
        {
            currentHealth -= amount;
            if (currentHealth <= 0f)
            {
                Die();
            }
        }

        public virtual void ApplyFreeze(float duration)
        {
            isFrozen = true;
            freezeTimer = duration;
        }

        protected virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}
