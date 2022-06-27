using UnityEngine;

namespace Assets.Scripts
{
    public class TapToStart : MonoBehaviour
    {
        private void OnEnable() => GameStopper.OnPlay += Setup;

        private void Setup() => gameObject.SetActive(false);

        private void OnDisable() => GameStopper.OnPlay -= Setup;
    }
}
