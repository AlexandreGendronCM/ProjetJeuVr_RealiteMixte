using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class finPartie : MonoBehaviour
{
    public Button rejouer_bouton;
    public Button quitter_bouton;
    public Button quitter_spawn;
    public GameObject canvas_fin;
    // Start is called before the first frame update
    void Start()
    {
         rejouer_bouton.onClick.AddListener(rejouer);
         quitter_bouton.onClick.AddListener(quitter);
         quitter_spawn.onClick.AddListener(quitter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartScene()
    {
        canvas_fin.SetActive(true);
    }

    void rejouer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void quitter()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
