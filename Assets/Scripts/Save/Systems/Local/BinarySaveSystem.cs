using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;

public class BinarySaveSystem : BaseDataSave, ISaveData
{
    private string path;

    public BinarySaveSystem(string path)
    {
        this.path = path;
    }

    public override T Load<T>(string key)
    {
        var data = LoadData();

        if (data.ContainsKey(key))
        {
            return (T)data[key];
        }
        else
        {
            return default;
        }
    }

    public override void Save(string key, object value)
    {
        var data = LoadData();

        if (data.ContainsKey(key))
        {
            data[key] = value;
        }
        else
        {
            data.Add(key, value);
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            binaryFormatter.Serialize(fileStream, data);
        }
    }

    public override T GetData<T>(string key, object value)
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            var data = (Dictionary<string, object>)bf.Deserialize(ms);

            if (data.ContainsKey(key))
            {
                return (T)data[key];
            }
            else
            {
                return default;
            }
        }
    }

    private Dictionary<string, object> LoadData()
    {
        if (!File.Exists(path))
        {
            return new Dictionary<string, object>();
        }

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(path, FileMode.Open))
        {
            return (Dictionary<string, object>)binaryFormatter.Deserialize(fileStream);
        }
    }
}
