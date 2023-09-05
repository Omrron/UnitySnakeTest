using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public static class DataManager
    {
        private static readonly string m_SaveDir = Application.persistentDataPath + "/SaveData";
        private const string m_SaveFile = "/InstanceData.json";
        private const string key = "Omri";

        public static SaveData LoadData()
        {
            string fullSavePath = m_SaveDir + m_SaveFile;

            if (File.Exists(fullSavePath))
            {
                string encryptedjson = File.ReadAllText(fullSavePath);
                string json = EncryptDecrypt(encryptedjson);

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
            string encryptedData = EncryptDecrypt(json);
            StringBuilder pathMaker = new StringBuilder(m_SaveDir);
            pathMaker.Append("/InstanceData.json");

            if (!Directory.Exists(m_SaveDir))
            {
                Directory.CreateDirectory(m_SaveDir);
            }

            File.WriteAllText(pathMaker.ToString(), encryptedData);
        }

        private static string EncryptDecrypt(string data)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                result.Append((char)(data[i] ^ key[i % key.Length]));
            }

            return result.ToString();
        }
    }
}
