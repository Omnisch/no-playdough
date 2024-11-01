using System;
using UnityEngine;
using UnityEngine.UI;

namespace Omnis.Playdough
{
    public class StartupManager : MonoBehaviour
    {
        #region Serialized Fields
        [SerializeField] private Button startButton;
        #endregion

        #region Interfaces
        public void StartGame() => UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("MainScene");

        public void ToggleShapeToPool(string shapeName)
        {
            if (Enum.TryParse(typeof(PlaydoughShape), shapeName, out var result))
            {
                if (GameSettings.shapePool.Contains((PlaydoughShape)result))
                    GameSettings.shapePool.Remove((PlaydoughShape)result);
                else
                    GameSettings.shapePool.Add((PlaydoughShape)result);
                startButton.interactable = !IsShapePoolEmpty();
            }
        }
        #endregion

        #region Functions
        private bool IsShapePoolEmpty() => GameSettings.shapePool.Count == 0;
        #endregion

        #region Unity Methods
        private void Start()
        {
            GameSettings.RandomScale = false;
            GameSettings.RandomRotation = false;
            GameSettings.EnableCrosshair = false;
            GameSettings.EnablePhantoms = false;
            GameSettings.shapePool.Clear();
            startButton.interactable = !IsShapePoolEmpty();
        }
        #endregion
    }
}