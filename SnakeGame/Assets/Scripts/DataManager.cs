using System.IO;
using System.Text;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public static class DataManager
    {
        private static readonly string m_SaveDir = Application.persistentDataPath + "/SaveData";
        private const string m_SaveFile = "/InstanceData.json";

        public static SaveData LoadData()
        {
            string fullSavePath = m_SaveDir + m_SaveFile;

            if (File.Exists(fullSavePath))
            {
                string json = File.ReadAllText(fullSavePath);
                return JsonUtility.FromJson<SaveData>(json);
            }
            else
            {
                return new SaveData()
                {
                    SpeedMultiplier = 1f,
                    HighScore = 0,
                    IsFullScreen = false
                };
            }
        }

        public static void SaveData(SaveData data)
        {
            string json = JsonUtility.ToJson(data, true);
            StringBuilder pathMaker = new StringBuilder(m_SaveDir);
            pathMaker.Append("/InstanceData.json");

            if (!Directory.Exists(m_SaveDir))
            {
                Directory.CreateDirectory(m_SaveDir);
            }

            File.WriteAllText(pathMaker.ToString(), json);
        }
    }
}
