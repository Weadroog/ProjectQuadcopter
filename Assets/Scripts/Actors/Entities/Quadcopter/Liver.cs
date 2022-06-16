using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Lifer : ConfigReceiver<QuadcopterConfig>
    {
        public event Action OnDeath;
        public event Action<int> OnChanged;

        private int _lifes;

        public int Lifes
        {
            get => _lifes;

            private set
            {
                if (value <= 0)
                    OnDeath?.Invoke();

                _lifes = Mathf.Clamp(value, 0, _config.MaxLives);

                OnChanged?.Invoke(_lifes);
            }
        }

        public void Restore() => Lifes = _config.MaxLives;

        public void Kill() => Lifes = 0;

        public void TakeDamage() => Lifes--;
    }
}