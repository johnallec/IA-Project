using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        WaveSpawner.GameCompleted = false;
        WaveSpawner.EnemiesAlive = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exting game...");
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
