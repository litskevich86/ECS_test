using Entitas;
using System.Collections.Generic;

namespace Systems
{
    public sealed class LogHealthSystem : ReactiveSystem<GameEntity>
    {
        public LogHealthSystem(Contexts contexts) : base(contexts.game){}
        
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ComponentsHealth);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasComponentsHealth;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                var health = e.componentsHealth.value;
                UnityEngine.Debug.Log("health = " + health);
            }
        }
    }
}
