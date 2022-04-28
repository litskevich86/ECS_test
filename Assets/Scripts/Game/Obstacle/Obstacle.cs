using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Obstacle
{
    public class Obstacle : MonoBehaviour, IElementId
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private int _id;

        public int ID => _id;
        public GameObject obj => gameObject;

        public void Initialize(int id)
        {
            _id = id;
        }

        public void SetColor()
        {
            _spriteRenderer.color = Color.red;
        }
    }
}
