using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class attaque : MonoBehaviour
{
    // Variables publiques
    private int counter;
    public int cranes;
    public TextMeshProUGUI score;
    public int vies = 3;
    public GameObject epee;

    // Seuil de vélocité minimum pour que l'épée active la désactivation
    public float seuilVitesse = 1f;  // Par exemple, 1 unité par seconde

    // Variables privées pour suivre la position précédente
    private Vector3 previousPosition;
    private float velocity;

    void Start()
    {
        // Initialiser la position précédente
        previousPosition = epee.transform.position;
    }

    void Update()
    {
        // Calculer la vélocité de l'épée à partir de la position précédente
        Vector3 currentPosition = epee.transform.position;
        velocity = (currentPosition - previousPosition).magnitude / Time.deltaTime;

        // Mettre à jour la position précédente pour le prochain calcul
        previousPosition = currentPosition;

        // Afficher la vélocité pour déboguer
        Debug.Log("Vélocité de l'épée : " + velocity);

        int currentScore = cranes - counter;
        score.text = "Score: " + currentScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "epee")
        {
            // Vérifie si la vélocité dépasse le seuil
            if (velocity >= seuilVitesse)  // Si la vitesse est supérieure ou égale au seuil
            {
                // Si la vélocité est suffisante, désactive l'objet
                gameObject.SetActive(false);
                Debug.Log("Objet désactivé. Vitesse de l'épée : " + velocity);
                counter++;
                Debug.Log("Compteur: " + counter);
            }
            else
            {
                Debug.Log("Vitesse de l'épée trop faible pour désactiver l'objet");
            }
        }

        if (other.tag == "joueur")
        {
            vies--;
            Debug.Log("Vies restantes : " + vies);
        }
    }
}
