using UnityEngine;

namespace PotatoGame.Player
{
    public enum PotatoPowerType
    {
        Regular,
        Ice,
        Explosive,
        Bouncy,
        Golden
    }

    public abstract class PotatoPower : ScriptableObject
    {
        public string DisplayName => displayName;
        public Sprite Icon => icon;
        public PotatoPowerType Type => type;
        public float Cooldown => cooldown;

        [SerializeField] private string displayName;
        [SerializeField] private Sprite icon;
        [SerializeField] private PotatoPowerType type;
        [SerializeField, Min(0f)] private float cooldown;

        public abstract void Activate(PlayerController player);
        public abstract bool CanActivate(PlayerController player);
    }
}
