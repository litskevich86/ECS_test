using System.Collections.Generic;
using Entitas;
using UnityEngine;
using Zenject;

namespace Game.Systems
{
    public class CollisionSystem : ReactiveSystem<GameEntity>
    {
        [Inject] private IdProvider _idProvider;
        
        public CollisionSystem(Contexts contexts) : base(contexts.game){}

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameCollisionId);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameCollisionId;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                IElementId element = _idProvider.GetElement(e.gameCollisionId.Id);

                if (element != null)
                {
                    if (element.obj.TryGetComponent(out Obstacle.Obstacle obstacle))
                    {
                        obstacle.SetColor();
                    }
                }
                
                e.RemoveGameCollisionId();
            }
        }
    }
}
