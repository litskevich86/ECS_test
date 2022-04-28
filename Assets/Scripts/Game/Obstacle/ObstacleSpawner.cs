using System.Collections.Generic;
using Common;
using UnityEngine;
using Zenject;

namespace Game.Obstacle
{
    public class ObstacleSpawner : MonoBehaviour
    {
        private const int obstacleCount = 5; 
        
        [SerializeField] private Obstacle _obstaclePrefab;

        private List<Obstacle> _obstacles = new List<Obstacle>();

        [Inject] private GameArea _gameArea;
        [Inject] private IdProvider _idProvider;

        public void ObstaclesSpawn()
        {
            for (int i = 0; i < obstacleCount; i++)
            {
                Obstacle obstacle = Instantiate(_obstaclePrefab, transform);
                obstacle.transform.position = _gameArea.GetRandomPoint();
                _obstacles.Add(obstacle);
                
                obstacle.Initialize(_idProvider.GetId());
                _idProvider.AddElement(obstacle);
            }
        }
    }
}
