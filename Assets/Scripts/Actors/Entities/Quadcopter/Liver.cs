using System;
using UnityEngine;

public class Liver : MonoBehaviour
{
    public event Action OnDeath;
    public event Action<int> OnChanged;

    private int _maxLives;
    private int _lives;
    
    public int Lives
    {
        get => _lives;
        
        private set
        {
            if (value <= 0)
                OnDeath?.Invoke();

            _lives = Mathf.Clamp(value, 0, _maxLives);

            OnChanged.Invoke(_lives);
        }
    }

    public void SetMaxLives(int maxLives) => _maxLives = maxLives;

    public void Kill() => Lives = 0;

    public void TakeDamage() => Lives--;

    public void ResetHP() => Lives = _maxLives;
}
