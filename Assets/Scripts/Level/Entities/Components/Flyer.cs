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
        private Deliverer _deliveryrer;

        private void Awake()
        {
            _quadcopter = FindObjectOfType<Quadcopter>();
            _deliveryrer = _quadcopter.GetComponent<Deliverer>();
        }

        private void OnEnable()
        {
            _flightTweener = transform
                .DOMove(_quadcopter.transform.position, _config.FlightTime)
                .SetEase(Ease.Linear)
                .SetAutoKill(false);

            UpdateService.OnUpdate += SetTarget;
        }

        private void SetTarget() => _flightTweener?.ChangeEndValue(_quadcopter.transform.position, true)?.Restart();

        private void OnDisable()
        {
            _flightTweener.Kill();
            UpdateService.OnUpdate -= SetTarget;
        }
    }
}