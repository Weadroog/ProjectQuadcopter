using System;
using UnityEngine;

public class Liver : MonoBehaviour
{
    public event Action OnDeath;

    private int _maxLives;
    private int _live;
    
    public int Lives
    {
        get => _live;
        
        private set
        {
            if (value <= 0)
                OnDeath?.Invoke();

            _live = Mathf.Clamp(value, 0, _maxLives);
        }
    }

    public void SetMaxLives(int maxLives) => _maxLives = maxLives;

    public void Kill() => Lives = 0;

    public void TakeDamage() => Lives--;

    public void ResetHP() => Lives = _maxLives;
}
