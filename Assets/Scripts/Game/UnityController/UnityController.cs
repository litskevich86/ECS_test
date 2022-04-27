using Entitas.Unity;
using UnityEngine;

namespace Game
{
    public abstract class UnityController : MonoBehaviour
    {
        protected Contexts _contexts;
        
        public GameEntity LinkedEntity { get; set; }

        public void Link(Contexts contexts, GameEntity e)
        {
            _contexts = contexts;
            LinkedEntity = e;
            gameObject.Link(e);
        }
    }
}
