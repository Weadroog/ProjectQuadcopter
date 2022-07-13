using System;
using UnityEngine;
using General;
using Entities;

namespace Components
{
    public class Lifer : ConfigReceiver<QuadcopterConfig>
    {
        public event Action OnDeath;
        public event Action<int> OnChanged;

        private int _lives;

        public int Lives
        {
            get => _lives;

            private set
            {
                if (value <= 0)
                    OnDeath?.Invoke();

                _lives = Mathf.Clamp(value, 0, _config.MaxLives);

                OnChanged?.Invoke(_lives);
            }
        }

        public void Restore() => Lives = _config.MaxLives;

        public void Kill() => Lives = 0;

        public void TakeDamage() => Lives--;
    }
}