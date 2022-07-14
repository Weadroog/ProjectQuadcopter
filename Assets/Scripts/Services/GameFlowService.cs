using System;
using UnityEngine;

namespace Services
{
    public class GameFlowService : MonoBehaviour
    {
        private GlobalSpeedService _speedService;

        public static event Action OnStop;
        public static event Action OnPlay;
            
        private void Awake() => _speedService = FindObjectOfType<GlobalSpeedService>();

        public void Stop()
        {
            _speedService.enabled = false;
            Time.timeScale = 0;
            OnStop?.Invoke();
        }

        public void Play()
        {
            Time.timeScale = 1;
            _speedService.enabled = true;
            OnPlay?.Invoke();
        }
    }
}