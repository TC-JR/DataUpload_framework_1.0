using System;
using System.IO;
using System.Text.Json;

public class JsonConfigManager
{
    private readonly string _filePath;

    public JsonConfigManager(string filePath)
    {
        _filePath = filePath;
    }

    public T Read<T>()
    {
        if (!File.Exists(_filePath))
        {
            throw new FileNotFoundException($"配置文件不存在：{_filePath}");
        }

        string json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<T>(json);
    }

    public void Write<T>(T config)
    {
        string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}
