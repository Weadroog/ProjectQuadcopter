using UnityEngine;
using Services;

namespace UI
{
    public class TapToStart : MonoBehaviour
    {
        private void OnEnable() => GameFlowService.OnPlay += () => gameObject.SetActive(false);

        private void OnDisable() => GameFlowService.OnPlay -= () => gameObject?.SetActive(false);
    }
}
