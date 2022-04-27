using UnityEngine;

namespace Game.Player
{
    public class PlayerController : UnityController
    {
        [SerializeField] private PlayerView playerController;

        public void MoveToPoint(Vector3 point)
        {
            playerController.MoveToPoint(point);
        }
    }
}
