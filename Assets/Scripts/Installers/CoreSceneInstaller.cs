using Common;
using Cysharp.Threading.Tasks;
using Game;
using Game.Input;
using Game.Obstacle;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers
{
    public class CoreSceneInstaller : MonoInstaller
    {
        public static Context Context { get; private set; }

        [SerializeField] private Context _context;
        [SerializeField] private AssetReference _gameController;
        [SerializeField] private AssetReference _inputController;
        [SerializeField] private AssetReference _playerSpawner;
        [SerializeField] private AssetReference _obstacleSpawner;
        [SerializeField] private Camera _camera;

        public override async void InstallBindings()
        {
            Context = _context;
            
            BindGameArea();
            BindIdProvider();
            BindAsCached(_camera);
            await BindObstacleSpawner();
            await BindPlayerSpawner();
            await BindInputController();
            await BindGameController();
        }

        private void BindGameArea()
        {
            GameArea gameArea = new GameArea();
            gameArea.Initialize(_camera);
            BindAsCached(gameArea);
        }
        
        private void BindIdProvider()
        {
            IdProvider idProvider = new IdProvider();
            BindAsCached(idProvider);
        }
        
        private async UniTask BindObstacleSpawner()
        {
            var result = Addressables.LoadAssetAsync<GameObject>(_obstacleSpawner);

            await UniTask.WaitUntil(() => result.IsDone);

            ObstacleSpawner obstacleSpawner = Container.InstantiatePrefabForComponent<ObstacleSpawner>(result.Result);

            BindAsCached(obstacleSpawner);
        }

        private async UniTask BindPlayerSpawner()
        {
            var result = Addressables.LoadAssetAsync<GameObject>(_playerSpawner);

            await UniTask.WaitUntil(() => result.IsDone);

            PlayerSpawner playerSpawner = Container.InstantiatePrefabForComponent<PlayerSpawner>(result.Result);

            BindAsCached(playerSpawner);
        }
        
        private async UniTask BindGameController()
        {
            var result = Addressables.LoadAssetAsync<GameObject>(_gameController);

            await UniTask.WaitUntil(() => result.IsDone);

            GameController gameController = Container.InstantiatePrefabForComponent<GameController>(result.Result);
            gameController.Initialize();

            BindAsCached(gameController);
        }
        
        private async UniTask BindInputController()
        {
            var result = Addressables.LoadAssetAsync<GameObject>(_inputController);

            await UniTask.WaitUntil(() => result.IsDone);

            InputController inputController = Container.InstantiatePrefabForComponent<InputController>(result.Result);

            BindAsCached(inputController);
        }

        private void BindAsCached<T>(T obj)
        {
            Container
                .Bind<T>()
                .FromInstance(obj)
                .AsCached();
        }
    }
}
