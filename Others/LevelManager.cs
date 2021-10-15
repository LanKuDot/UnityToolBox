using UnityEngine;
using UnityEngine.SceneManagement;

namespace LanKuDot.UnityToolBox
{
    public class LevelManager : MonoGameSingleton<LevelManager>
    {
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
