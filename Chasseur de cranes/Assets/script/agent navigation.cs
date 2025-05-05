using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentNavigation : MonoBehaviour
{
    public GameObject objetCible; // La cible à suivre (par exemple, le joueur ou la caméra)
    private NavMeshAgent agent; // L'agent NavMesh qui contrôlera le mouvement

    void Start()
    {
        // Récupère le NavMeshAgent attaché à l'objet ennemi
        agent = GetComponent<NavMeshAgent>();

        // Vérifie si la cible n'est pas assignée manuellement
        if (objetCible == null)
        {
            // Si aucune cible n'est définie, on utilise la caméra principale comme cible
            objetCible = GameObject.FindGameObjectWithTag("Player"); // Remplace "Player" par le tag approprié si nécessaire
        }

        // Assure-toi que le NavMeshAgent est bien configuré
        agent.speed = 3.5f; // Ajuste la vitesse selon tes besoins
        agent.angularSpeed = 120f; // Ajuste la vitesse de rotation pour un meilleur mouvement
        agent.acceleration = 8f; // Ajuste l'accélération pour un déplacement fluide
    }


    void Update()
    {
        // Si la cible est définie, l'agent se déplace vers la position de la cible
        if (objetCible != null)
        {
            // Met à jour la destination de l'agent à chaque frame pour s'assurer qu'il suit la cible
            if (Vector3.Distance(transform.position, objetCible.transform.position) > 0.1f)
            {
                // Si la cible est loin, on la suit
                agent.SetDestination(objetCible.transform.position);
            }

            // Optionnel : Affiche la position de la cible dans la console pour déboguer
            
        }
    }
}
