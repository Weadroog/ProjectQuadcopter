using System;
using UnityEngine;

public class Lifer : MonoBehaviour
{
    public event Action OnDeath;
    public event Action<int> OnChanged;

    private int _maxLifes;
    private int _lifes;
    
    public int Lifes
    {
        get => _lifes;
        
        private set
        {
            if (value <= 0)
                OnDeath?.Invoke();

            _lifes = Mathf.Clamp(value, 0, _maxLifes);

            OnChanged?.Invoke(_lifes);
        }
    }

    public Lifer SetMaxLifes(int maxLives)
    {
        _maxLifes = maxLives;
        ResetHP();
        return this;
    }

    public void ResetHP() => Lifes = _maxLifes;

    public void Kill() => Lifes = 0;

    public void TakeDamage() => Lifes--;
}
