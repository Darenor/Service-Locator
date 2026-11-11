using UnityEngine;

public class PlayerPrefsSaver : ISaverService
{
    private readonly Score score;

    public PlayerPrefsSaver(Score score)
    {
        this.score = score;
    }

    public void SaveScore(string path = null)
    {
        PlayerPrefs.SetInt("PlayerScore", score.CurrentScore);
        PlayerPrefs.Save();

        Debug.Log($"Счёт сохранён в PlayerPrefs: {score.CurrentScore}");
    }
}
