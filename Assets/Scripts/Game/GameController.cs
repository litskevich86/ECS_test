using System;
using Entitas.Unity;
using Game.Input;
using Game.Obstacle;
using Game.Player;
using Game.Systems;
using Installers;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private RootSystems _systems;
        private CompositeDisposable _disposable = new CompositeDisposable();

        [Inject] private InputController _inputController;
        [Inject] private ObstacleSpawner _obstacleSpawner;
        [Inject] private PlayerSpawner _playerSpawner;
        
        public async void Initialize()
        {
            var contexts = Contexts.sharedInstance;

            _systems = new RootSystems(contexts);
            CoreSceneInstaller.Context.Container.Inject(_systems);
            _systems.Initialize();

            _obstacleSpawner.ObstaclesSpawn();
            
            await _playerSpawner.CreatePlayer(contexts);

            _inputController.Initialize();

            Observable.EveryUpdate()
                .Subscribe(_ => UpdateManual())
                .AddTo(_disposable);
        }

        private void UpdateManual()
        {
            _systems.Execute();
        }
    }
}
