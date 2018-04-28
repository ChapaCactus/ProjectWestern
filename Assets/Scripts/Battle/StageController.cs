using System;
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

        private Ground _currentGround;

        private Coroutine _bornEnemyLoopCoroutine;

        public int Round { get; private set; } = 0;
        public RoundMaster CurrentRoundData => _stageMaster.RoundSettings[Round].RoundMaster;

        public PlayerController Player { get; private set; }
        public List<EnemyController> Enemies { get; private set; }

        public bool IsRunning { get; private set; } = false;

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

            CreateGround();

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

        private void CreateGround()
        {
            if (_currentGround != null) Destroy(_currentGround.gameObject);

            var prefab = CurrentRoundData.GroundSettingPrefab;
            var go = Instantiate(prefab, transform);

            var ground = go.GetComponent<Ground>();
            _currentGround = ground;
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

            Player = player;
        }

        private void OnCreateEnemy(EnemyController enemy, EnemyMaster master)
        {
            var startPos = _currentGround.GetRandomPosition();
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