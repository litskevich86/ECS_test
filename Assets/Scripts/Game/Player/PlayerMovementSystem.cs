using System.Collections.Generic;
using Entitas;

namespace Game.Player
{
    public class PlayerMovementSystem : ReactiveSystem<GameEntity>
    {
        public PlayerMovementSystem(Contexts contexts) : base(contexts.game){}

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.PlayerMovement);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPlayerMovement;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                var position = e.playerMovement._position;
                UnityEngine.Debug.Log("position = " + position);
            }
        }
    }
}
