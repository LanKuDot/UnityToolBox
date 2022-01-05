using LanKuDot.UnityToolBox.EventManagement;
using LanKuDot.UnityToolBox.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LanKuDot.UnityToolBox.System
{
    public class LevelManager : MonoGameSingleton<LevelManager>
    {
        #region Enum/Message

        public enum LoadAction
        {
            Next,
            Reload
        }

        public struct LoadLevelMsg
        {
            public LoadAction action;
        }

        #endregion

        [SerializeField]
        private bool _singleLevelTest;
        [SerializeField]
        private string[] _levelNames;

        private string _curLevelName;
        private int _curLevelID = -1;

        private void Start()
        {
            if (_singleLevelTest)
                _curLevelName = SceneManager.GetActiveScene().name;

            EventManager.AddListener<LoadLevelMsg>(OnLoadLevelMsg);
        }

        private void OnDestroy()
        {
            EventManager.RemoveListener<LoadLevelMsg>(OnLoadLevelMsg);
        }

        private void OnLoadLevelMsg(LoadLevelMsg msg)
        {
            switch (msg.action) {
                case LoadAction.Next:
                    NextLevel();
                    break;
                case LoadAction.Reload:
                    ReloadLevel();
                    break;
            }
        }

        public void NextLevel()
        {
            if (_singleLevelTest) {
                LoadCurrentLevel();
                return;
            }

            _curLevelID = (int) Mathf.Repeat(_curLevelID + 1, _levelNames.Length);
            SceneManager.LoadScene(_levelNames[_curLevelID]);
        }

        public void ReloadLevel()
        {
            if (_singleLevelTest) {
                LoadCurrentLevel();
                return;
            }

            SceneManager.LoadScene(_levelNames[_curLevelID]);
        }

        private void LoadCurrentLevel()
        {
            SceneManager.LoadScene(_curLevelName);
        }
    }
}
