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
    public GameObject epee;
    public GameObject epee2;
    public GameObject joueur;
    public AudioSource rate;
    public AudioSource reussi;
    // Seuil de v�locit� minimum pour que l'�p�e active la d�sactivation
    public float seuilVitesse = 1f;  // Par exemple, 1 unit� par seconde

    // Variables priv�es pour suivre la position pr�c�dente
    private Vector2 previousPosition;
    private Vector3 previousPosition2;
    private float velocity;
    private float velocity2;
    void Start()
    {
        // Initialiser la position pr�c�dente
        previousPosition = epee.transform.position;
        previousPosition2 = epee2.transform.position;
    }

    void Update()
    {
        // Calculer la v�locit� de l'�p�e � partir de la position pr�c�dente
        Vector2 currentPosition = epee.transform.position;
        Vector3 currentPosition2 = epee2.transform.position;
        velocity = (currentPosition - previousPosition).magnitude / Time.deltaTime;
        velocity2 = (currentPosition2 - previousPosition2).magnitude / Time.deltaTime;
        // Mettre � jour la position pr�c�dente pour le prochain calcul
        previousPosition = currentPosition;
        previousPosition2 = currentPosition2;


       // Debug.Log(counter);
        int currentScore = cranes - counter;
        score.text = "Score: " + currentScore;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "epee")
        {
            // V�rifie si la v�locit� d�passe le seuil
            if (velocity >= seuilVitesse || velocity2 >= seuilVitesse)  // Si la vitesse est sup�rieure ou �gale au seuil
            {
                // Si la v�locit� est suffisante, d�sactive l'objet
                gameObject.SetActive(false);
                Debug.Log("Audio lanc�");
                reussi.Play();
                counter++;
                Debug.Log("Compteur: " + counter);
            }
            else
            {
                Debug.Log("Audio lanc�");
                rate.Play();
            }
        }

       
    }
}