using System.IO;
using UnityEngine;
using System.Threading.Tasks;

public sealed class LocalSaveTemplate
{
    private string _pathToData;

    public LocalSaveTemplate(string applicationPersistentData)
    {
        _pathToData = applicationPersistentData;
    }

    public async Task<T> GetData<T>(string fileName, string folder)
    {
        return await Task.Run(() => {
            string fullPath = $"{_pathToData}/{folder}/{fileName}.json";

            if (Directory.Exists(_pathToData))
            {
                if (File.Exists(fullPath))
                {
                    T data = JsonUtility.FromJson<T>(File.ReadAllText(fullPath));
                    return data;
                }
                throw new System.Exception("Cound't find file: " + fullPath);
            }
            throw new System.Exception("Cound't find directory: " + _pathToData);
        });
    }
        
    public async Task SaveData(object data, string fileName, string folder)
    {
        await Task.Run(() => {
            Task.Delay(1);
        });

        string fullPath = $"{_pathToData}/{folder}/{fileName}.json";
        if (!Directory.Exists($"{_pathToData}/{folder}"))
        {
            Directory.CreateDirectory($"{_pathToData}/{folder}");
        }

        File.WriteAllText(fullPath, JsonUtility.ToJson(data, true));
    }
        
    public bool HasData(string fileName, string folder)
    {
        string fullPath = $"{_pathToData}/{folder}/{fileName}.json";

        return Directory.Exists(_pathToData) && File.Exists(fullPath);
    }
}
