using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCG.Master;

namespace CCG
{
    public class StageController : SceneContentBase
    {
        [SerializeField]
        private Transform _playerParent;
        [SerializeField]
        private Transform _enemiesParent;

        private StageMaster _stageMaster;
        private Coroutine _bornEnemyLoopCoroutine;
        private List<Ground> _grounds;

        public int RoundNum { get; private set; } = 0;
        public RoundMaster CurrentRoundData => _stageMaster.RoundSettings[RoundNum].RoundMaster;
        public Ground CurrentGround => _grounds[RoundNum];

        public PlayerController Player { get; private set; }
        public List<EnemyController> Enemies { get; private set; }

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
            _stageMaster = master;

            CreateGround(master.RoundSettings, () => CurrentGround.ActivationColliders(true));

            StartStage();
        }

        public void StartStage()
        {
            IsRunning = true;

            ClearEnemies();

            CreateNewPlayer();
            CreateNewEnemy();
            CreateNewEnemy();
            CreateNewEnemy();
            CreateNewEnemy();

            if (_bornEnemyLoopCoroutine != null)
            {
                StopCoroutine(_bornEnemyLoopCoroutine);
            }
            _bornEnemyLoopCoroutine = StartCoroutine(BornEnemyLoop());

            Player.SetCanMove(true);
        }

        public void Restart()
        {
            Player.Kill();
            Enemies.ForEach(enemy => enemy.Kill());

            Player = null;
            Enemies = null;

            Setup(_stageMaster);
        }

        protected override void Prepare()
        {
            AddDispatchEvents();
        }

        private void AddDispatchEvents()
        {
        }

        private void OnMoveToNextGround()
        {
            Player.SetCanMove(false);

            // 画面移動処理

            Player.SetCanMove(true);
        }

        private void CompleteRound()
        {
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

                CreateNewEnemy();
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

        private void CreateNewPlayer()
        {
            PlayerController.Create(_playerParent, OnCreatePlayer);
        }

        private void CreateNewEnemy()
        {
            CurrentRoundData.GetEnemyMasterAtRandom(master =>
            {
                EnemyController.Create(_enemiesParent, enemy => OnCreateEnemy(enemy, master));
            });
        }

        private void OnCreatePlayer(PlayerController player)
        {
            var userData = GetUserData();
            player.Setup(userData);
            player.SetCallRestart(Restart);
            player.SetInvincible(true);

            Player = player;
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

        private void ClearEnemies()
        {
            Enemies?.ForEach(enemy => Destroy(enemy.gameObject));
            Enemies = new List<EnemyController>();
        }

        private void OnDeadEnemy(EnemyModel model)
        {
            Debug.Log($"{model.Name} is Dead.");
        }
    }
}