using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class JsonSaveSystem : BaseDataSave, ISaveData
{
    private string path;

    public JsonSaveSystem(string path)
    {
        this.path = path;
    }

    public override T Load<T>(string key)
    {
        if (File.Exists(path))
        {
            Debug.Log("<color=green>File exists</color>");
            string json = File.ReadAllText(path + key);
            return JsonConvert.DeserializeObject<T>(json);
        }
        else
        {
            Debug.Log("<color=red>File does not exist</color>");
            return default;
        }
    }

    public override void Save(string key, object value)
    {
        if (File.Exists(path + key))
            Debug.Log("<color=orange>File is resave</color>");
        else
            Debug.Log("<color=green>File save</color>");
        string json = JsonConvert.SerializeObject(value);
        File.WriteAllText(path + key, json);
    }

    public override T GetData<T>(string key, object value)
    {
        string json = JsonConvert.SerializeObject(value);
        return JsonConvert.DeserializeObject<T>(json);
    }
}
