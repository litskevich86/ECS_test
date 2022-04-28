using Game.Input;
using UniRx;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace Game.Player
{
    public class PlayerMovementCallback
    {
        private PlayerController _playerController;
        private CompositeDisposable _disposable = new CompositeDisposable();
        private Vector3 _oldPoint;
        private Vector3 _newPoint;
        
        [Inject] private Camera _camera;
        [Inject] private InputController _inputController;

        public void Initialize()
        {
            _inputController.Trigger
                .Where(result => result.Key == KeyStorage.BeginDrag)
                .Subscribe(BeginDrag)
                .AddTo(_disposable);
            
            _inputController.Trigger
                .Where(result => result.Key == KeyStorage.Drag)
                .Subscribe(Drag)
                .AddTo(_disposable);
            
            _inputController.Trigger
                .Where(result => result.Key == KeyStorage.EndDrag)
                .Subscribe(EndDrag)
                .AddTo(_disposable);
        }

        private void BeginDrag(Callback callback)
        {
            if (callback.Object != null)
            {
                if (callback.Object.TryGetComponent(out PlayerController playerController))
                {
                    if (playerController.LinkedEntity.hasGameEntityComponentPosition)
                    {
                        _playerController = playerController;
            
                        _oldPoint = Vector3.zero;
                        _newPoint = Vector3.zero;
            
                        _oldPoint = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
                    }
                }
            }
        }
        
        private void EndDrag(Callback callback)
        {
            _playerController = null;
        }

        private void Drag(Callback callback)
        {
            if (_playerController != null)
            {
                Vector3 newPos = _playerController.LinkedEntity.gameEntityComponentPosition.Position + CalculateDistance();
            
                _playerController.LinkedEntity.ReplaceGameEntityComponentPosition(newPos);
            }
        }
        
        private Vector3 CalculateDistance()
        {
            _newPoint = _camera.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
            Vector3 distance = _newPoint - _oldPoint;
            _oldPoint = _newPoint;

            return distance;
        }
    }
}
