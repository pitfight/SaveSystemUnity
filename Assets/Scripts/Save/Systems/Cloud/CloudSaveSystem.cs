using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class CloudSaveSystem<SystemType>: ISaveData where SystemType : BaseDataSave
{
    private string url;
    private SystemType saveData;

    public CloudSaveSystem(string url)
    {
        this.url = url;
    }

    public T Load<T>(string key)
    {
        var task = Download(key);
        var data = Convert.ChangeType(task.Result, typeof(object));
        var result = saveData.GetData<T>(key, data);
        return result;
    }

    private async Task<byte[]> Download(string key)
    {
        HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync(url + key);

        if (response.IsSuccessStatusCode)
        {
            byte[] result = await response.Content.ReadAsByteArrayAsync();
            Debug.Log("<color=green>File download</color>");
            return result;
        }
        else
        {
            Debug.Log($"<color=red>Error file didn't download: {response.StatusCode}</color>");
            return null;
        }
    }

    public async void Save(string key, object value)
    {
        BinaryFormatter bf = new BinaryFormatter();
        using (MemoryStream ms = new MemoryStream())
        {
            bf.Serialize(ms, value);
            await Upload(key, ms.ToArray());
        }
    }

    private async Task Upload(string key, byte[] data)
    {
        HttpClient client = new HttpClient();

        ByteArrayContent content = new ByteArrayContent(data);

        HttpResponseMessage response = await client.PostAsync(url + key, content);

        if (!response.IsSuccessStatusCode)
        {
            Debug.Log("<color=red>Error file didn't upload</color>");
        }
        else
        {
            Debug.Log("<color=green>File upload</color>");
        }
    }
}
