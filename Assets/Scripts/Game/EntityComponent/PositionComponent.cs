using Entitas;
using UnityEngine;

namespace Game.EntityComponent
{
    [Game]
    public class PositionComponent : IComponent
    {
        public Vector3 Position;
    }
}
