using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class Ground : MonoBehaviour
    {
        [SerializeField]
        private List<PopPoint> _popPoints = new List<PopPoint>();

        private void Awake()
        {
            Assert.IsNotNull(_popPoints);
            Assert.AreNotEqual(_popPoints.Count, 0);
        }

        public Vector3 GetRandomPosition()
        {
            var random = Random.Range(0, _popPoints.Count);
            var point = _popPoints[random];
            return point.GetPosition();
        }
    }
}