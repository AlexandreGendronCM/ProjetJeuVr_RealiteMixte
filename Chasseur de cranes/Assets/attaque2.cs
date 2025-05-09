using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class attaque2 : MonoBehaviour
{
   
    public int counter;
    public int cranes;
    public TextMeshProUGUI score;
    public GameObject epee;
    public GameObject epee2;
    public GameObject joueur;
    public AudioSource rate;
    public AudioSource reussi;
    
    public float seuilVitesse = 1f;  

  
    private Vector2 previousPosition;
    private Vector3 previousPosition2;
    private float velocity;
    private float velocity2;
    void Start()
    {
       
        previousPosition = epee.transform.position;
        previousPosition2 = epee2.transform.position;
    }

    void Update()
    {
        
        Vector2 currentPosition = epee.transform.position;
        Vector3 currentPosition2 = epee2.transform.position;
        velocity = (currentPosition - previousPosition).magnitude / Time.deltaTime;
        velocity2 = (currentPosition2 - previousPosition2).magnitude / Time.deltaTime;
       
        previousPosition = currentPosition;
        previousPosition2 = currentPosition2;


       
        int currentScore = cranes - counter;
        score.text = "Score: " + currentScore;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "epee")
        {
            
            if (velocity >= seuilVitesse || velocity2 >= seuilVitesse)  
            {
                
                gameObject.SetActive(false);
                Debug.Log("Audio lance");
                reussi.Play();
                counter++;
                Debug.Log("Compteur: " + counter);
            }
            else
            {
                Debug.Log("Audio lance");
                rate.Play();
            }
        }

       
    }
}