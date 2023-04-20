public interface ISaveData
{
    void Save(string key, object value);
    T Load<T>(string key);
}
