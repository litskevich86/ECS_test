using System;
using Entitas.Unity;
using Game.Input;
using Game.Player;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private PlayerMovementSystem _playerMovementSystem;
        private CompositeDisposable _disposable = new CompositeDisposable();

        [Inject] private InputController _inputController;
        [Inject] private PlayerSpawner _playerSpawner;
        
        public async void Initialize()
        {
            var contexts = Contexts.sharedInstance;
            
            _playerMovementSystem = new PlayerMovementSystem(contexts);

            await _playerSpawner.CreatePlayer(contexts);

            _inputController.Initialize();

            Observable.EveryUpdate()
                .Subscribe(_ => UpdateManual())
                .AddTo(_disposable);
        }

        private void UpdateManual()
        {
            _playerMovementSystem.Execute();
        }
    }
}
