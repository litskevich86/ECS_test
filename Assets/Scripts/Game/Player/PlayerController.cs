using System;
using UnityEngine;

namespace Game.Player
{
    public class PlayerController : UnityController, IElementId
    {
        [SerializeField] private PlayerView _playerView;

        private int _id;
        public int ID => _id;
        public GameObject obj => gameObject;

        public void Initialize(int id)
        {
            _id = id;
        }
        
        public void MoveToPoint(Vector3 point)
        {
            _playerView.MoveToPoint(point);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.collider.TryGetComponent(out IElementId element))
            {
                LinkedEntity.AddGameCollisionId(element.ID);
            }
            
        }
    }
}
