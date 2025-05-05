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

    // Seuil de v�locit� minimum pour que l'�p�e active la d�sactivation
    public float seuilVitesse = 1f;  // Par exemple, 1 unit� par seconde

    // Variables priv�es pour suivre la position pr�c�dente
    private Vector3 previousPosition;
    private float velocity;

    void Start()
    {
        // Initialiser la position pr�c�dente
        previousPosition = epee.transform.position;
    }

    void Update()
    {
        // Calculer la v�locit� de l'�p�e � partir de la position pr�c�dente
        Vector3 currentPosition = epee.transform.position;
        velocity = (currentPosition - previousPosition).magnitude / Time.deltaTime;

        // Mettre � jour la position pr�c�dente pour le prochain calcul
        previousPosition = currentPosition;

        // Afficher la v�locit� pour d�boguer
        Debug.Log("V�locit� de l'�p�e : " + velocity);

        int currentScore = cranes - counter;
        score.text = "Score: " + currentScore;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "epee")
        {
            // V�rifie si la v�locit� d�passe le seuil
            if (velocity >= seuilVitesse)  // Si la vitesse est sup�rieure ou �gale au seuil
            {
                // Si la v�locit� est suffisante, d�sactive l'objet
                gameObject.SetActive(false);
                Debug.Log("Objet d�sactiv�. Vitesse de l'�p�e : " + velocity);
                counter++;
                Debug.Log("Compteur: " + counter);
            }
            else
            {
                Debug.Log("Vitesse de l'�p�e trop faible pour d�sactiver l'objet");
            }
        }

        if (other.tag == "joueur")
        {
            vies--;
            Debug.Log("Vies restantes : " + vies);
        }
    }
}
