using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCG.Master;
using DG.Tweening;

namespace CCG
{
    public class StageController : SceneContentBase
    {
        [SerializeField]
        private Transform _playerParent;
        [SerializeField]
        private Transform _enemiesParent;

        private StageMaster _stageMaster;
        private StageCanvas _stageCanvas;
        private CharacterManager _characterManager;
        private Coroutine _bornEnemyLoopCoroutine;
        private List<Ground> _grounds;

        public int RoundNum { get; private set; } = 0;
        public RoundMaster CurrentRoundData => _stageMaster.RoundSettings[RoundNum].RoundMaster;
        public Ground CurrentGround => _grounds[RoundNum];
        public PlayerController Player => _characterManager.Player;
        public List<EnemyController> Enemies => _characterManager.Enemies;

        public bool IsRunning { get; private set; } = false;

        private static readonly float GroundSizeBase = 700;
        private static readonly string PrefabPath = "Prefabs/Stage/Stage";

        public static void Create(Transform parent, Action<StageController> onCreate)
        {
            var prefab = Resources.Load(PrefabPath) as GameObject;
            var go = Instantiate(prefab, parent);

            var controller = go.GetComponent<StageController>();
            onCreate.SafeCall(controller);
        }

        public void Setup(StageMaster master)
        {
            DispatchEvent<Action<StageCanvas>>(StageEvents.RequestStageCanvas, c => _stageCanvas = c);
            DispatchEvent<Action<CharacterManager>>(StageEvents.RequestCharacterManager, c => _characterManager = c);
            _stageMaster = master;

            CreateGround(master.RoundSettings, () => CurrentGround.ActivationColliders(true));

            StartStage();
        }

        public void StartStage()
        {
            IsRunning = true;

            StartRound();
        }

        public void Restart()
        {
            _characterManager.ResetCharacters();

            Setup(_stageMaster);
        }

        protected override void Prepare()
        {
            AddDispatchEvents();
        }

        private void AddDispatchEvents()
        {
            AddDispatchEvent(StageEvents.RoundComplete, RoundComplete);
        }

        private void OnMoveToNextGround()
        {
            Player.SetCanMove(false);

            // 画面移動処理

            Player.SetCanMove(true);
        }

        private void StartRound()
        {
            _characterManager.ClearEnemies();

            _characterManager.CreateNewPlayer(_playerParent, OnCreatePlayer);
            _characterManager.CreateNewEnemy(_enemiesParent, CurrentRoundData, OnCreateEnemy);
            _characterManager.CreateNewEnemy(_enemiesParent, CurrentRoundData, OnCreateEnemy);
            _characterManager.CreateNewEnemy(_enemiesParent, CurrentRoundData, OnCreateEnemy);
            _characterManager.CreateNewEnemy(_enemiesParent, CurrentRoundData, OnCreateEnemy);

            StopBornEnemyCoroutine();
            _bornEnemyLoopCoroutine = StartCoroutine(BornEnemyLoop());

            Player.SetCanMove(true);

            _stageCanvas.RoundTimer.StartTimer(10, StopBornEnemyCoroutine);
        }

        private void StopBornEnemyCoroutine()
        {
            if (_bornEnemyLoopCoroutine == null) return;

            StopCoroutine(_bornEnemyLoopCoroutine);
            _bornEnemyLoopCoroutine = null;
        }

        private void RoundComplete()
        {
            Debug.Log($"Round [{RoundNum}] Complete!!");

            var beforeRoundNum = RoundNum;
            var beforeGround = CurrentGround;
            var nextDir = _stageMaster.RoundSettings[RoundNum].NextRoundDirection;
            beforeGround.OpenExit(nextDir);

            RoundNum++;
        }

        private void CompleteStage()
        {
        }

        private IEnumerator BornEnemyLoop()
        {
            while (IsRunning)
            {
                var random = UnityEngine.Random.Range(1.0f, 5.0f);
                var wait = new WaitForSeconds(random);
                yield return wait;

                _characterManager.CreateNewEnemy(_enemiesParent, CurrentRoundData, OnCreateEnemy);
            }

            yield break;
        }

        private void CreateGround(List<RoundSetting> rounds, Action onComplete)
        {
            DestroyAllGrounds();
            _grounds = new List<Ground>();

            var tempPos = Vector2.zero;
            foreach (var round in rounds)
            {
                var ground = Instantiate(round.GroundPrefab, transform).GetComponent<Ground>();
                ground.transform.localPosition = tempPos;
                var offset = DirectionConverter.ToVector2(round.NextRoundDirection) * GroundSizeBase;
                tempPos += offset;
                ground.ActivationColliders(false);

                _grounds.Add(ground);
            }

            onComplete.SafeCall();
        }

        private void DestroyAllGrounds()
        {
            if (_grounds == null) return;
            if (_grounds.Count == 0) return;

            _grounds.ForEach(ground => Destroy(ground.gameObject));
        }

        private void OnExitNextGround()
        {
            var cameraTo = CurrentGround.transform.position;
            MoveCamera(cameraTo, null);
        }

        private void MoveCamera(Vector3 to, Action onComplete)
        {
            Camera.main.transform.DOMove(to, 1);
        }

        private void OnCreatePlayer(PlayerController player)
        {
            var userData = GetUserData();
            player.Setup(userData);
            player.SetCallRestart(Restart);
            player.SetOnExitToNextGround(OnExitNextGround);
            player.SetInvincible(true);

            _characterManager.SetPlayer(player);
        }

        private void OnCreateEnemy(EnemyController enemy, EnemyMaster master)
        {
            var startPos = CurrentGround.GetRandomPosition();
            enemy.transform.localPosition = startPos;
            enemy.Setup(master);
            enemy.SetTarget(Player);

            Enemies.Add(enemy);
        }

        private UserData GetUserData()
        {
            var data = GameManager.UserData;
            return data;
        }

        private void OnDeadEnemy(EnemyModel model)
        {
            Debug.Log($"{model.Name} is Dead.");
        }
    }
}