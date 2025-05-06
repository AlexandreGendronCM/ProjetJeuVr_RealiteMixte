using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class attaque : MonoBehaviour
{
    // Variables publiques
    public int counter;
    public int cranes;
    public TextMeshProUGUI score;
    public int vies = 3;
    public GameObject epee;
    public GameObject epee2;
    public GameObject joueur;
    public AudioSource rate;
    public AudioSource reussi;
    // Seuil de vélocité minimum pour que l'épée active la désactivation
    public float seuilVitesse = 1f;  // Par exemple, 1 unité par seconde

    // Variables privées pour suivre la position précédente
    private Vector2 previousPosition;
    private Vector3 previousPosition2;
    private float velocity;
    private float velocity2;
    void Start()
    {
        // Initialiser la position précédente
        previousPosition = epee.transform.position;
        previousPosition2 = epee2.transform.position;
    }

    void Update()
    {
        // Calculer la vélocité de l'épée à partir de la position précédente
        Vector2 currentPosition = epee.transform.position;
        Vector3 currentPosition2 = epee2.transform.position;
        velocity = (currentPosition - previousPosition).magnitude / Time.deltaTime;
        velocity2 = (currentPosition2 - previousPosition2).magnitude / Time.deltaTime;
        // Mettre à jour la position précédente pour le prochain calcul
        previousPosition = currentPosition;
        previousPosition2 = currentPosition2;



        int currentScore = cranes - counter;
        score.text = "Score: " + currentScore;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "epee")
        {
            // Vérifie si la vélocité dépasse le seuil
            if (velocity >= seuilVitesse || velocity2 >= seuilVitesse)  // Si la vitesse est supérieure ou égale au seuil
            {
                // Si la vélocité est suffisante, désactive l'objet
                gameObject.SetActive(false);
                reussi.Play();
                counter++;
                Debug.Log("Compteur: " + counter);
            }
            else
            {
                rate.Play();
            }
        }

       
    }
}
