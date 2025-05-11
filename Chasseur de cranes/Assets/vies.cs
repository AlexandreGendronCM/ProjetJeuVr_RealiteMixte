using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class vies : MonoBehaviour
{
    public int vie = 3;
    public float invincibilityDuration = 2f;
    private bool isInvincible = false;

    public Image damageFlash;
    public AudioSource hitSound;
    public Slider lifeSlider; 

    void Start()
    {
        // Set slider max and current value
        if (lifeSlider != null)
        {
            lifeSlider.maxValue = 3;
            lifeSlider.value = vie;
            lifeSlider.minValue = 0;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("crane") && !isInvincible)
        {
            StartCoroutine(LoseLife());
        }
    }

    IEnumerator LoseLife()
    {
        vie--;
        Debug.Log("Collision with crane! Lives left: " + vie);

        if (lifeSlider != null)
            lifeSlider.value = vie;
            Debug.Log(lifeSlider.value);

        if (hitSound != null)
            hitSound.Play();

        if (damageFlash != null)
        {
            damageFlash.color = new Color(1f, 0f, 0f, 0.5f);
            yield return new WaitForSeconds(1f);
            damageFlash.color = new Color(1f, 0f, 0f, 0f);
        }

        if (vie <= 0)
        {
            Debug.Log("Game Over - Restarting Scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            isInvincible = true;
            yield return new WaitForSeconds(invincibilityDuration);
            isInvincible = false;
        }
    }

}
