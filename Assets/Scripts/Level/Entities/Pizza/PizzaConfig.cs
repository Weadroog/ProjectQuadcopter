using UnityEngine;
using General;
using NaughtyAttributes;

namespace Entities
{
    [CreateAssetMenu(menuName = "Config/Pizza", fileName = "New Pizza Config")]
    public class PizzaConfig : Config
    {
        [SerializeField] private Pizza _pizzaPrefab;
        [SerializeField, Range(0.1f, 3)] private float _flightTime;

        public Pizza PizzaPrefab => _pizzaPrefab;
        public float FlightTime => _flightTime;
    }

}

