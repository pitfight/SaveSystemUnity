using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDataSave
{
    public abstract T Load<T>(string key);
    public abstract void Save(string key, object value);
    public abstract T GetData<T>(string key, object value);
}
