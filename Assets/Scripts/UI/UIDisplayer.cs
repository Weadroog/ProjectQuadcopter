using UnityEngine;
using TMPro;

namespace UI
{
    public class UIDisplayer : MonoBehaviour
    {
        private TextMeshProUGUI _value;

        private void Awake() => _value = GetComponent<TextMeshProUGUI>();

        public void Display(int value) => _value.text = value.ToString();

        public void Display(double value) => _value.text = value.ToString();
    }
}