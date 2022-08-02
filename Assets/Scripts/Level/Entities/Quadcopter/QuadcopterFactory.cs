using UnityEngine;
using General;
using Services;
using Ads;
using UI;
using Components;
using Reactions;

namespace Entities
{
    public class QuadcopterFactory : EntityFactory<Quadcopter, QuadcopterConfig>
    {
        private LifeDisplayer _lifeCounter;
        private MoneyDisplayer _moneyCounter;
        private DefeatPanel _defeatPanel;
        private AdsRewardedButton _rewardedButton;

        public QuadcopterFactory(QuadcopterConfig config, Container container, LifeDisplayer lifeCounter, MoneyDisplayer moneyCounter, DefeatPanel defeatPanel, AdsRewardedButton rewardedButton)
            : base(config, container) 
        {
            _lifeCounter = lifeCounter;
            _moneyCounter = moneyCounter;
            _defeatPanel = defeatPanel;
            _rewardedButton = rewardedButton;
        }

        public override Quadcopter GetCreated()
        {
            Quadcopter quadcopter = Object.Instantiate(_config.Prefab, _container.transform);
            TakeDamageReaction takeDamageReaction = new(quadcopter, _config);

            SwipeController swipeController = quadcopter.gameObject.AddComponent<SwipeController>();
            swipeController.Receive(_config);
            swipeController.enabled = false;

            Lifer lifer = quadcopter.gameObject.AddComponent<Lifer>();
            lifer.OnChanged += _lifeCounter.Display;
            lifer.Receive(_config);
            lifer.Restore();
            lifer.OnDeath += () => _defeatPanel.gameObject.SetActive(true);

            Purse purse = quadcopter.gameObject.AddComponent<Purse>();
            purse.OnChanged += _moneyCounter.Display;
            purse.Receive(_config);
            purse.SetInitialAmount();

            Deliverer deliverer = quadcopter.gameObject.AddComponent<Deliverer>();
            deliverer.Receive(_config);
            deliverer.OnSuccessfulDelivery += () => purse.AddMoney(_config.SuccessfulDeliveryReward);
            deliverer.OnDeliverySequenceFailed += () => purse.SubtractMoney(_config.FineForFailedDelivery);

            Pizza pizza = quadcopter.GetComponentInChildren<Pizza>();
            pizza.gameObject.SetActive(false);

            deliverer.OnDeliverySequenceFailed += () => pizza.gameObject.SetActive(false);
            deliverer.OnSuccessfulDelivery += () => pizza.gameObject.SetActive(false);
            deliverer.OnPizzaGrabbed += () => pizza.gameObject.SetActive(true);

            quadcopter.AddReaction<CollisionDetector, Bird, Car, Net>(new PizzaFallenReaction(deliverer));
            quadcopter.AddReaction<CollisionDetector, Bird, Car, Net>(new TakeDamageReaction(quadcopter, _config));

            GlobalSpeedService.OnStartup += () =>
            {
                swipeController.enabled = true;
                new QuadcopterStartReaction(quadcopter).React();
            };
            

            quadcopter.GetComponentInChildren<Camera>().transform.SetParent(_container.transform);

            _rewardedButton.OnShowCompleted += () =>
            {
                lifer.Restore();
                new QuadcopterNextReaction(quadcopter, _config).React();
            };

            return quadcopter;
        }
    }
}
