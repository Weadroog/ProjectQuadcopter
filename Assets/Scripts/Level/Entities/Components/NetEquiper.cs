using System.Collections.Generic;
using UnityEngine;
using General;
using Entities;
using Reactions;

namespace Components
{
    public class NetEquiper : ConfigReceiver<NetGuyConfig>
    {
        private List<NetPoint> _netPoints = new();
        private List<Net> _nets = new();
        private Net _equipedNet;

        public Net EquipedNet
        {
            get => _equipedNet;

            private set 
            {
                _equipedNet?.gameObject.SetActive(false);
                value.gameObject.SetActive(true);
                _equipedNet = value;
            }
        }

        public override void Receive(NetGuyConfig config)
        {
            base.Receive(config);
            _netPoints.AddRange(GetComponentsInChildren<NetPoint>());

            for (int i = 0; i < _netPoints.Count; i++)
            {
                Net net = Instantiate(_config.NetPrefab, _netPoints[i].transform);
                net.AddReaction<CollisionDetector, Quadcopter>(new CatchReaction(GetComponent<NetGuy>(), config));
                _nets.Add(net);
            }
        }   

        public void Equip() => EquipedNet = _nets[Random.Range(0, _nets.Count)];
    }
}
