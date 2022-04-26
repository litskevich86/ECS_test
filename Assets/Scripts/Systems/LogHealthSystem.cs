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
    
    // public class LogHealthSystem : IExecuteSystem
    // {
    //     private readonly IGroup<GameEntity> _entities;
    //
    //     public LogHealthSystem(Contexts contexts)
    //     {
    //         _entities = contexts.game.GetGroup(GameMatcher.ComponentsHealth);
    //     }
    //     
    //     public void Execute()
    //     {
    //         foreach (var e in _entities)
    //         {
    //             var health = e.componentsHealth.value;
    //             UnityEngine.Debug.Log("health = " + health);
    //         }
    //     }
    // }
}
