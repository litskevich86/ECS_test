using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game.Player
{
    public sealed class PlayerMovementSystem : ReactiveSystem<GameEntity>
    {
        public PlayerMovementSystem(Contexts contexts) : base(contexts.game) {}

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameEntityComponentPosition);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameEntityComponentPosition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                if (e.hasGameUnityController)
                {
                    if (e.gameUnityController.UnityController.TryGetComponent(out PlayerController playerController))
                    {
                        playerController.MoveToPoint(e.gameEntityComponentPosition.Position);
                    }
                }
            }
        }
    }
}
