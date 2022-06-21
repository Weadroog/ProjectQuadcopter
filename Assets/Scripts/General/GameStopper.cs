using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameStopper : MonoBehaviour
    {
        private GlobalSpeedService _speedService;

        public event Action OnStop;
        public event Action OnPlay;

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


