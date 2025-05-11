using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class attaque2 : MonoBehaviour
{
   
    public int counter;
    public int cranes = 10;
    public TextMeshProUGUI score;
    public GameObject epee;
    public GameObject epee2;
    public GameObject joueur;
    public AudioSource rate;
    public AudioSource reussi;
    public GameObject tresor; 
    public Light tresorLight; 
    public bool lightActivated = false;
    public AudioSource ambiance;
    public AudioSource fin;
    
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

        if (!lightActivated && AllCranesAreInactive())
        {
        tresor.SetActive(true);;
        lightActivated = true;
        ambiance.Stop();
        fin.Play();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "epee")
        {
            
            if (velocity >= seuilVitesse || velocity2 >= seuilVitesse)  
            {
                gameObject.SetActive(false);
                Debug.Log("Audio lance");
                reussi.Play();
            }
            else
            {
                Debug.Log("Audio lance");
                rate.Play();
            }
        }

       
    }

    bool AllCranesAreInactive()
    {
    GameObject[] cranes = GameObject.FindGameObjectsWithTag("crane");
    foreach (GameObject crane in cranes)
    {
        if (crane.activeInHierarchy)
            return false;
    }
    return true;
    }

    //score en bas

    public void CraneDisabled()
    {
    UpdateCounterFromCranes();
    }

    void UpdateScore()
    {
    int currentScore = cranes - counter;
    score.text = "Score: " + currentScore;
    }

    public void UpdateCounterFromCranes()
    {
    GameObject[] cranes = GameObject.FindGameObjectsWithTag("crane");
    counter = 0;

    foreach (GameObject crane in cranes)
    {
        if (!crane.activeInHierarchy)
        {
            counter++;
        }
    }

    UpdateScore(); 
    }
    
}