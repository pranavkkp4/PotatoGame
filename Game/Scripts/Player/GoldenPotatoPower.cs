using System.Collections;
using UnityEngine;

namespace PotatoGame.Player
{
    [CreateAssetMenu(menuName = "PotatoGame/Powers/Golden Potato")]
    public class GoldenPotatoPower : PotatoPower
    {
        [SerializeField] private float duration = 10f;

        public override void Activate(PlayerController player)
        {
            player.StartCoroutine(ApplyInvulnerability(player));
        }

        public override bool CanActivate(PlayerController player)
        {
            return true;
        }

        private IEnumerator ApplyInvulnerability(PlayerController player)
        {
            var invulnerable = player.GetComponent<PlayerInvulnerability>();
            if (invulnerable == null)
            {
                invulnerable = player.gameObject.AddComponent<PlayerInvulnerability>();
            }

            invulnerable.SetInvulnerable(duration);
            yield return new WaitForSeconds(duration);
        }
    }
}
