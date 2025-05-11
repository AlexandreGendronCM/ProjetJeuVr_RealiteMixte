using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int counter = 10;
    public int totalCranes = 10;
    public HighScorePersistant highScoreManager;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void CraneDestroyed()
    {
        counter++;
        int score = totalCranes - counter;

        if (highScoreManager != null)
        {
            highScoreManager.OnChangerPointage(score);
        }
        else
        {
            Debug.LogWarning("HighScorePersistant not assigned!");
        }
    }
}
