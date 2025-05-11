using UnityEngine;

public class crane_score : MonoBehaviour
{
    public attaque2 gameManager;

    void OnDisable()
    {
        if (gameManager != null)
        {
            gameManager.CraneDisabled();
        }
        else
        {
            Debug.LogWarning("gameManager not assigned on " + gameObject.name);
        }
    }
}
