using System.IO;
using UnityEngine;

namespace PotatoGame.Managers
{
    public class SaveSystem : MonoBehaviour
    {
        private string SaveDirectory => Path.Combine(Application.persistentDataPath, "PotatoGame");
        private string SavePath => Path.Combine(SaveDirectory, "save.json");

        public void Save(GameState state)
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }

            string json = JsonUtility.ToJson(state, prettyPrint: true);
            File.WriteAllText(SavePath, json);
        }

        public GameState Load()
        {
            if (!File.Exists(SavePath))
            {
                return new GameState();
            }

            string json = File.ReadAllText(SavePath);
            return JsonUtility.FromJson<GameState>(json);
        }
    }

    [System.Serializable]
    public class GameState
    {
        public string currentWorldId;
        public string currentLevelId;
        public string[] equippedPowers;
    }
}
