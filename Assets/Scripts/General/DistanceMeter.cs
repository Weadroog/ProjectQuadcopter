using UnityEngine;

namespace Assets.Scripts
{
    public class DistanceMeter : MonoBehaviour
    {
        private float _distance;

        public string Distance { get; private set; }

        private void OnEnable() => UpdateService.OnUpdate += CalculateDistance;

        private void CalculateDistance()
        {
            _distance += Time.deltaTime * GlobalSpeedService.Speed;
            //Distance = $"{kilometers} {meters}"
        }

        private void OnDisable() => UpdateService.OnUpdate -= CalculateDistance;
    }
}