using UnityEngine;
using System;
using System.Collections;

namespace Assets.Scripts
{
    class Charger : MonoBehaviour
    {
        public Action<int> OnChanged;
        public Action OnDecreased;
        public Action OnDischarged;

        private int _maxCharge;
        private int _charge;
        private int _decreaseTime;
        private WaitForSeconds _waitForSeconds;
        private Coroutine _chargeDownRoutine;

        public int Charge
        {
            get => _charge;

            private set
            {
                _charge = value;
                OnChanged?.Invoke(_charge);
            }
        }

        public void SetMaxCharge(int maxCharge) => _maxCharge = maxCharge;

        public void SetDecreaseTime(int decreaseTime) 
        {
            _decreaseTime = decreaseTime;
            _waitForSeconds = new WaitForSeconds(_decreaseTime);
        }

        public void ChargeUp() 
        {
            Charge = _maxCharge;
            ResartChargeDowning();
        }

        public void ResartChargeDowning()
        {
            if (_chargeDownRoutine != null)
            {
                StopCoroutine(_chargeDownRoutine);
            }

            _chargeDownRoutine = StartCoroutine(ChargeDowning());
        }

        private IEnumerator ChargeDowning()
        {

            while(Charge > 0)
            {
                yield return _waitForSeconds;
                Charge--;
                OnDecreased?.Invoke();
            }

            OnDischarged?.Invoke();
            yield break;
        }
    }
}
