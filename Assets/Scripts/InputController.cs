using UniRx;
using UnityEngine;
using Zenject;

public class InputController : MonoBehaviour
{
    private CompositeDisposable _disposable = new CompositeDisposable();
    private Vector3 _oldPoint;
    private Vector3 _newPoint;

    [Inject] private Camera _camera;
    
    private void Initialize()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(xs => BeginDrag())
            .AddTo(_disposable);
        
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButton(0))
            .Subscribe(xs => CheckRaycast())
            .AddTo(_disposable);
    }
    
    private void BeginDrag()
    {
        _oldPoint = Vector3.zero;
        _newPoint = Vector3.zero;
        
        _oldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void CheckRaycast()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.TryGetComponent(out GameEntity gameEntity))    
            {
                if (gameEntity.playerMovement != null)
                {
                    Vector3 newPos = gameEntity.playerMovement._position + CalculateDistance();

                    gameEntity.playerMovement._position = newPos;
                }
            }
        }
    }

    private Vector3 CalculateDistance()
    {
        _newPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 distance = _oldPoint - _newPoint;
        _oldPoint = _newPoint;

        return distance;
    }
}
