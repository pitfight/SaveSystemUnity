using System;
using UnityEngine;

public class SimpleDataSaveSystem : ISaveData
{
    public T Load<T>(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            var prefs = PlayerPrefs.GetString(key);
            return (T)Convert.ChangeType(prefs, typeof(T));
        }
        else
        {
            return default;
        }
    }

    public void Save(string key, object value)
    {
        var convertValue = (string)Convert.ChangeType(value, typeof(string));
        PlayerPrefs.SetString(key, convertValue);
    }
}
