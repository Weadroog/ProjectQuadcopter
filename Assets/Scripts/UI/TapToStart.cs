using UnityEngine;
using Services;

namespace UI
{
    public class TapToStart : MonoBehaviour
    {
        private void OnEnable() => GlobalSpeedService.OnStartup += () => gameObject.SetActive(false);

        private void OnDisable() => GlobalSpeedService.OnStartup -= () => gameObject?.SetActive(false);
    }
}
