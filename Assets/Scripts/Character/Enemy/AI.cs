using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
    public abstract class AI : ScriptableObject
    {
        public abstract void NextMove();
    }
}