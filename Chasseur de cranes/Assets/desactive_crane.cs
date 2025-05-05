using UnityEngine;
using UnityEngine.AI;  // Si tu utilises le NavMeshAgent pour les ennemis

public class ZoneActivation : MonoBehaviour
{
    // Références aux ennemis de chaque zone
    public GameObject[] enemiesZone1; // Ennemis pour la zone de spawn (Zone 1)
    public GameObject[] enemiesZone2; // Ennemis pour la zone 2
    public GameObject[] enemiesZone3; // Ennemis pour la zone 3
    public GameObject[] enemiesZone4; // Ennemis pour la zone 4

    // Fonction appelée quand un objet entre dans la zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("joueur"))
        {
            if (gameObject.name == "zone_1")  // Zone de spawn
            {
                // Ne rien faire, ou mettre les ennemis de la Zone 1 en état inactif
                DeactivateEnemies(enemiesZone1);
            }
            else if (gameObject.name == "Zone_2")
            {
                ActivateEnemies(enemiesZone2);
            }
            else if (gameObject.name == "zone_3")
            {
                ActivateEnemies(enemiesZone3);
            }
            else if (gameObject.name == "zone_4")
            {
                ActivateEnemies(enemiesZone4);
            }
        }
    }

    // Fonction pour activer les ennemis dans la zone
    private void ActivateEnemies(GameObject[] enemies)
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.SetActive(true); // Active l'ennemi
                NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                if (agent != null)
                {
                    agent.isStopped = false; // Permet au NavMeshAgent de se déplacer
                }

                Debug.Log("Ennemi activé dans " + gameObject.name);
            }
        }
    }

    // Fonction pour désactiver les ennemis dans la zone
    private void DeactivateEnemies(GameObject[] enemies)
    {
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.SetActive(false); // Désactive l'ennemi
                NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
                if (agent != null)
                {
                    agent.isStopped = true; // Arrête le mouvement du NavMeshAgent
                }


                Debug.Log("Ennemi désactivé dans " + gameObject.name);
            }
        }
    }

    // Fonction appelée quand un objet quitte la zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("joueur"))
        {
            if (gameObject.name == "zone_1")
            {
                // Lorsque le joueur quitte la zone de spawn, on peut garder les ennemis figés ou désactivés
                DeactivateEnemies(enemiesZone1);
            }
            else if (gameObject.name == "zone_2")
            {
                // Quand le joueur quitte la zone 2, on peut décider si on doit désactiver les ennemis ou non
                DeactivateEnemies(enemiesZone2);
            }
            else if (gameObject.name == "zone_3")
            {
                DeactivateEnemies(enemiesZone3);
            }
            else if (gameObject.name == "zone_4")
            {
                DeactivateEnemies(enemiesZone4);
            }
        }
    }
}
