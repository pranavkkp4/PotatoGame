using System.Collections.Generic;
using UnityEngine;

namespace PotatoGame.Player
{
    public class PotatoPowerManager : MonoBehaviour
    {
        [SerializeField] private List<PotatoPower> equippedPowers = new List<PotatoPower>();
        private readonly Dictionary<PotatoPower, float> cooldownTimers = new Dictionary<PotatoPower, float>();

        private void Update()
        {
            UpdateCooldowns();
            HandleInput();
        }

        private void HandleInput()
        {
            for (int i = 0; i < equippedPowers.Count; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                {
                    TryActivatePower(equippedPowers[i]);
                }
            }
        }

        private void TryActivatePower(PotatoPower power)
        {
            if (power == null)
            {
                return;
            }

            if (!power.CanActivate(GetComponent<PlayerController>()))
            {
                return;
            }

            if (cooldownTimers.TryGetValue(power, out float timer) && timer > 0f)
            {
                return;
            }

            power.Activate(GetComponent<PlayerController>());
            cooldownTimers[power] = power.Cooldown;
        }

        private void UpdateCooldowns()
        {
            var keys = new List<PotatoPower>(cooldownTimers.Keys);
            foreach (var power in keys)
            {
                cooldownTimers[power] -= Time.deltaTime;
                if (cooldownTimers[power] <= 0f)
                {
                    cooldownTimers.Remove(power);
                }
            }
        }

        public void EquipPower(PotatoPower power)
        {
            if (equippedPowers.Count >= 3 || equippedPowers.Contains(power))
            {
                return;
            }

            equippedPowers.Add(power);
        }

        public void UnequipPower(PotatoPower power)
        {
            if (equippedPowers.Remove(power))
            {
                cooldownTimers.Remove(power);
            }
        }
    }
}
