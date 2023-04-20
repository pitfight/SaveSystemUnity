public class SaveData
{
    private ISaveData saveData;

    public SaveData(ISaveData saveData)
    {
        this.saveData = saveData;
    }

    public void Save(string key, object value)
    {
        saveData.Save(key, value);
    }

    public T Load<T>(string key)
    {
        return saveData.Load<T>(key);
    } 
}
