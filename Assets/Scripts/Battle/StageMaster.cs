using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCG.Enums;

namespace CCG.Master
{
    [CreateAssetMenu]
    public class StageMaster : ScriptableObject
    {
        [SerializeField]
        private string _title = "";
        [SerializeField]
        private List<RoundSetting> _roundSettings;

        public string Title => _title;
        public List<RoundSetting> RoundSettings => _roundSettings;
    }

    [Serializable]
    public class RoundSetting
    {
        [SerializeField]
        private RoundMaster _roundMaster;
        [SerializeField]
        private Direction2D _nextRoundDirection = Direction2D.None;

        public RoundMaster RoundMaster => _roundMaster;
        public Direction2D NextRoundDirection => _nextRoundDirection;
    }
}