using System.IO;
using UnityEngine;

public  class  SettingManager : MonoBehaviour
{
    public static SettingManager instance;

    [SerializeField] private SettingSO settingSO;
    private SettingJSON currentSettings;
    private string filePath;
    private string json;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        filePath = Path.Combine(Application.persistentDataPath, "settings.json");
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void Save()
    {
        json = JsonUtility.ToJson(currentSettings, true);
        File.WriteAllText(filePath, json);
    }

    private void Load()
    {
        if (File.Exists(filePath))
        {
            json = File.ReadAllText(filePath);
            currentSettings = JsonUtility.FromJson<SettingJSON>(json);
        }
        else
        {

        }
    }
}
