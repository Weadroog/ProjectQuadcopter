using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(menuName = "Config/PizzeriaGuy", fileName = "New Pizzeria Guy Config")]
    public class PizzeriaGuyConfig : ActorConfig<PizzeriaGuy>, ICanDetect, ICanMove
    {
        [SerializeField][Range(1,30)] private int _bypassOffset;

        public float DetectionDistance => _bypassOffset;
        public float SelfSpeed => 0;
    }
}


