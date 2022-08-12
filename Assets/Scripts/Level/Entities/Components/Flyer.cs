using UnityEngine;
using DG.Tweening;
using General;
using Services;
using Entities;

namespace Components
{
    public class Flyer : ConfigReceiver<PizzaConfig>
    {
        private Tweener _flightTweener;
        private Quadcopter _quadcopter;

        private void Awake() => _quadcopter = FindObjectOfType<Quadcopter>();

        private void OnEnable()
        {
            _flightTweener = transform.DOMove(_quadcopter.transform.position, _config.FlightTime).SetAutoKill(false);
            UpdateService.OnUpdate += SetTarget;
        }

        private void SetTarget() => _flightTweener.ChangeEndValue(_quadcopter.transform.position, true).Restart();

        private void OnDisable()
        {
            _flightTweener.Kill();
            UpdateService.OnUpdate -= SetTarget;
        }
    }
}