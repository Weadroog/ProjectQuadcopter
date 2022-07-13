using Components;

namespace Reactions
{
    class PushForwardReaction : Reaction
    {
        private Mover _mover;

        public PushForwardReaction(Mover mover) => _mover = mover;

        public override void React()
        {
            if (_detectableEntity.TryGetComponent(out Mover detectableEntityMover))
                _mover.Push(detectableEntityMover.SelfSpeed);
        }
    }
}
