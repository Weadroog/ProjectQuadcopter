using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class PizzeriaDistrict : PieceOfChunk
    {
        [SerializeField] private PizzaDispensePoint _pizzaDispensePoint;

        public PizzaDispensePoint PizzaDispensePoint => _pizzaDispensePoint;

        protected override void Awake()
        {
            base.Awake();
            _pizzaDispensePoint = GetComponentInChildren<PizzaDispensePoint>();
        }
    }
}


