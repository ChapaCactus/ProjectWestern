using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
    [CreateAssetMenu]
    public class StageMaster : ScriptableObject
    {
        [SerializeField]
        private string _stageName = "";

        [SerializeField]
        private List<RoundMaster> _roundMasters;

        public string StageName => _stageName;
        public List<RoundMaster> Rounds => _roundMasters;
    }
}