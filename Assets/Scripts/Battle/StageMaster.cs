using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG.Master
{
    [CreateAssetMenu]
    public class StageMaster : ScriptableObject
    {
        [SerializeField]
        private string _title = "";

        [SerializeField]
        private List<RoundMaster> _roundMasters;

        public string Title => _title;
        public List<RoundMaster> Rounds => _roundMasters;
    }
}