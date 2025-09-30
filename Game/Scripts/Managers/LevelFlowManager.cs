using System.Collections.Generic;
using UnityEngine;

namespace PotatoGame.Managers
{
    public class LevelFlowManager : MonoBehaviour
    {
        [System.Serializable]
        public class LevelStage
        {
            public string levelName;
            public TextAsset waveConfig;
        }

        [SerializeField] private List<LevelStage> stages = new List<LevelStage>();
        [SerializeField] private WaveSpawner waveSpawner;

        private int currentStageIndex;

        private void Start()
        {
            if (stages.Count == 0)
            {
                Debug.LogWarning("No level stages defined for LevelFlowManager.");
                return;
            }

            LoadStage(0);
        }

        private void LoadStage(int index)
        {
            if (index < 0 || index >= stages.Count)
            {
                Debug.LogError("LevelFlowManager tried to load invalid stage index." );
                return;
            }

            currentStageIndex = index;
            var stage = stages[currentStageIndex];
            if (waveSpawner != null && stage.waveConfig != null)
            {
                waveSpawner.LoadConfig(stage.waveConfig);
            }
        }

        public void OnStageCompleted()
        {
            int nextIndex = currentStageIndex + 1;
            if (nextIndex >= stages.Count)
            {
                Debug.Log("Level complete!");
            }
            else
            {
                LoadStage(nextIndex);
            }
        }
    }
}
