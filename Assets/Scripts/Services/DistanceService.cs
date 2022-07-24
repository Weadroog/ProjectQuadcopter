using UnityEngine;
using Services;

namespace General
{
    public class DistanceService : MonoBehaviour
    {
        private float _distance;

        public string Distance { get; private set; }

        private void OnEnable() => UpdateService.OnUpdate += CountDistance;

        private void CountDistance()
        {
            _distance += Time.deltaTime * GlobalSpeedService.Speed;
            //Distance = $"{kilometers} {meters}"
        }

        private void OnDisable() => UpdateService.OnUpdate -= CountDistance;
    }
}