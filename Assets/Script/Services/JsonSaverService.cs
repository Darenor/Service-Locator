using System;
using System.IO;
using UnityEngine;

public class JsonSaverService : ISaverService
{
    private readonly Score score;

    public JsonSaverService(Score score)
    {
        this.score = score;
    }

    [Serializable]
    private class ScoreData
    {
        public int score;
    }

    public void SaveScore(string path = null)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            Debug.LogError("Не указан путь для сохранения JSON!");
            return;
        }

        ScoreData data = new ScoreData
        {
            score = score.CurrentScore
        };

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(path, json);

        Debug.Log($"Счёт сохранён в JSON: {path}");
    }
}
