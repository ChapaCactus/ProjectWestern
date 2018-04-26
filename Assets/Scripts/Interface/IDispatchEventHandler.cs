using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
    public interface IDispatchEventHandler
    {
        void AddDispatchEvent(string key, Action action);
        void AddDispatchEvent<T>(string key, Action<T> action);
        void AddDispatchEvent<T1, T2>(string key, Action<T1, T2> action);

        void DispatchEvent(string key);
        void DispatchEvent<T>(string key, T param);
        void DispatchEvent<T1, T2>(string key, T1 param1, T2 param2);
    }
}