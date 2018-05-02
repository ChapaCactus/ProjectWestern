using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using CCG.Enums;

namespace CCG
{
    public class Ground : MonoBehaviour
    {
        [SerializeField]
        private List<PopPoint> _popPoints = new List<PopPoint>();

        [SerializeField]
        private BoxCollider2D _playerStopNorth;
        [SerializeField]
        private BoxCollider2D _playerStopSouth;
        [SerializeField]
        private BoxCollider2D _playerStopWest;
        [SerializeField]
        private BoxCollider2D _playerStopEast;

        [SerializeField]
        private BoxCollider2D _colliderOfExitToNorth;
        [SerializeField]
        private BoxCollider2D _colliderOfExitToSouth;
        [SerializeField]
        private BoxCollider2D _colliderOfExitToWest;
        [SerializeField]
        private BoxCollider2D _colliderOfExitToEast;

        private void Awake()
        {
            Assert.IsNotNull(_popPoints);
            Assert.AreNotEqual(_popPoints.Count, 0);
            Assert.IsNotNull(_colliderOfExitToNorth);
            Assert.IsNotNull(_colliderOfExitToSouth);
            Assert.IsNotNull(_colliderOfExitToWest);
            Assert.IsNotNull(_colliderOfExitToEast);
        }

        public Vector3 GetRandomPosition()
        {
            var random = UnityEngine.Random.Range(0, _popPoints.Count);
            var point = _popPoints[random];
            return point.GetPosition();
        }

        public void ActivationColliders(bool active)
        {
            CollectAllBoxCollider2D(colliders => Array.ForEach(colliders, c => c.enabled = active));
        }

        public void OpenExit(Direction dir)
        {
            switch(dir)
            {
                case Direction.North:
                    _playerStopNorth.enabled = false;
                    _colliderOfExitToNorth.enabled = true;
                    break;
                case Direction.South:
                    _playerStopSouth.enabled = false;
                    _colliderOfExitToSouth.enabled = true;
                    break;
                case Direction.West:
                    _playerStopWest.enabled = false;
                    _colliderOfExitToWest.enabled = true;
                    break;
                case Direction.East:
                    _playerStopEast.enabled = false;
                    _colliderOfExitToEast.enabled = true;
                    break;
            }
        }

        private void CollectAllBoxCollider2D(Action<BoxCollider2D[]> resfunc)
        {
            var colliders = GetComponentsInChildren<BoxCollider2D>();
            resfunc(colliders);
        }
    }
}