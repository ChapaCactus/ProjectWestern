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
        private Ground _groundPrefab;
        [SerializeField]
        private Direction _nextRoundDirection = Direction.None;

        public RoundMaster RoundMaster => _roundMaster;
        public Ground GroundPrefab => _groundPrefab;
        public Direction NextRoundDirection => _nextRoundDirection;
    }
}