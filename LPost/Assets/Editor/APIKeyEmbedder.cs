#if UNITY_EDITOR
using UnityEditor;
using System.IO;
using UnityEngine;

public static class APIKeyEmbedder
{
    private const string inputPath = "Assets/Secrets/keys.json";
    private const string outputPath = "Assets/Script/APIKeyHolder.cs";

    [MenuItem("Tools/Embed API Key")]
    public static void EmbedAPIKey()
    {
        if (!File.Exists(inputPath))
        {
            Debug.LogError("keys.json が見つかりません: " + inputPath);
            return;
        }

        string json = File.ReadAllText(inputPath);
        string apiKey = JsonUtility.FromJson<KeyData>(json).API_KEY;

        string code = $"public static class APIKeyHolder {{ public const string API_KEY = \"{apiKey}\"; }}";
        File.WriteAllText(outputPath, code);

        AssetDatabase.Refresh();
        Debug.Log("APIキーを埋め込みました！");
    }

    [System.Serializable]
    private class KeyData
    {
        public string API_KEY;
    }
}
#endif