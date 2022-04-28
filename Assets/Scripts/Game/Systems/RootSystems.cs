using Game.Player;
using Installers;
using UnityEngine;

namespace Game.Systems
{
    public sealed class RootSystems : Feature
    {
        public RootSystems(Contexts contexts)
        {
            Add(new PlayerMovementSystem(contexts));
            CollisionSystem collisionSystem = new CollisionSystem(contexts);
            Add(collisionSystem);
            CoreSceneInstaller.Context.Container.Inject(collisionSystem);
        }
    }
}
