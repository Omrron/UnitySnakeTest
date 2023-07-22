using UnityEngine;

namespace Assets.Scripts
{
    public class InstanceData : MonoBehaviour
    {
        public SaveData Data;
        public static InstanceData Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);

                return;
            }

            Data = DataManager.LoadData();

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void OnApplicationQuit()
        {
            DataManager.SaveData(Data);
        }
    }
}
