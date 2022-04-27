using UnityEngine;

namespace Game.Player
{
    public class PlayerView : MonoBehaviour
    {
        public void MoveToPoint(Vector3 point)
        {
            transform.position = point;
        }
    }
}
