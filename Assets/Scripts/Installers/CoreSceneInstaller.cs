using System;
using System.ComponentModel;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Installers
{
    public class CoreSceneInstaller : MonoInstaller
    {
        [SerializeField] private AssetReference _gameController;
        [SerializeField] private AssetReference _inputController;

        public override async void InstallBindings()
        {
            await BindInputController();
            await BindGameController();
        }

        private async UniTask BindGameController()
        {
            var result = Addressables.LoadAssetAsync<GameObject>(_gameController);

            await UniTask.WaitUntil(() => result.IsDone);

            GameController gameController = Container.InstantiatePrefabForComponent<GameController>(result.Result);

            Container
                .Bind<GameController>()
                .FromInstance(gameController)
                .AsCached();
        }
        
        private async UniTask BindInputController()
        {
            var result = Addressables.LoadAssetAsync<GameObject>(_gameController);

            await UniTask.WaitUntil(() => result.IsDone);

            InputController inputController = Container.InstantiatePrefabForComponent<InputController>(result.Result);

            Container
                .Bind<InputController>()
                .FromInstance(inputController)
                .AsCached();
        }
    }
}
