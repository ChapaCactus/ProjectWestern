using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
    public class PopPoint : MonoBehaviour
    {
        public bool IsRunning { get; private set; } = true;

        private void Awake()
        {
            Reset();

            Run();
        }

        public void Reset()
        {
            Stop();
        }

        public void Run()
        {
            SetIsRunning(true);
        }

        public void Stop()
        {
            SetIsRunning(false);
        }

        public Vector2 GetPosition()
        {
            return transform.localPosition;
        }

        private void SetIsRunning(bool isRunning)
        {
            IsRunning = isRunning;
        }
    }
}