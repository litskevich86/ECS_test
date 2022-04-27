using Cysharp.Threading.Tasks;
using Game.Player;
using Installers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private AssetReference _playerControllerPrefab;

        private PlayerController _playerController;
        private PlayerMovementCallback _playerMovementCallback;

        public async UniTask CreatePlayer(Contexts contexts)
        {
            var result = Addressables.LoadAssetAsync<GameObject>(_playerControllerPrefab);

            await UniTask.WaitUntil(() => result.IsDone);

            if (result.Result.TryGetComponent(out PlayerController playerController))
            {
                _playerController = Instantiate(playerController, transform);
            }

            var e = contexts.game.CreateEntity();
            _playerController.Link(contexts, e);
            e.AddGameUnityController(_playerController);
            e.AddGamePosition(_playerController.transform.position);

            _playerMovementCallback = new PlayerMovementCallback();
            CoreSceneInstaller.Context.Container.Inject(_playerMovementCallback);
            _playerMovementCallback.Initialize();
        }
    }
}
