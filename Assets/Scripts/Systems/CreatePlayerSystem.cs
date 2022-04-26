using Entitas;

namespace Systems
{
    public class CreatePlayerSystem : IInitializeSystem
    {
        private Contexts _contexts;

        public CreatePlayerSystem(Contexts contexts)
        {
            _contexts = contexts;
        }
        
        public void Initialize()
        {
            var e = _contexts.game.CreateEntity();
            e.AddComponentsHealth(100);
        }
    }
}