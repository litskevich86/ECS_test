using System;
using Game.Player;
using UniRx;
using UnityEngine;
using Zenject;

namespace Game.Input
{
    public class InputController : MonoBehaviour
    {
        private readonly Subject<Callback> _listeners = new Subject<Callback>();
        private CompositeDisposable _disposable = new CompositeDisposable();

        [Inject] private Camera _camera;

        public IObservable<Callback> Trigger => _listeners;

        public void Initialize()
        {
            Observable.EveryUpdate()
                .Where(_ => UnityEngine.Input.GetMouseButtonDown(0))
                .Subscribe(xs => BeginDrag())
                .AddTo(_disposable);

            Observable.EveryUpdate()
                .Where(_ => UnityEngine.Input.GetMouseButton(0))
                .Subscribe(xs => Drag())
                .AddTo(_disposable);

            Observable.EveryUpdate()
                .Where(_ => UnityEngine.Input.GetMouseButtonUp(0))
                .Subscribe(xs => EndDrag())
                .AddTo(_disposable);
        }

        private void BeginDrag()
        {
            GameObject obj = CheckRaycast();

            _listeners.OnNext(new Callback(KeyStorage.BeginDrag, obj));
        }

        private void EndDrag()
        {
            _listeners.OnNext(new Callback(KeyStorage.EndDrag, null));
        }

        private GameObject CheckRaycast()
        {
            Ray ray = _camera.ScreenPointToRay(UnityEngine.Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                return hit.collider.gameObject;
            }

            return null;
        }

        private void Drag()
        {
            _listeners.OnNext(new Callback(KeyStorage.Drag, null));
        }
    }
}
