using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class attaque2 : MonoBehaviour
{
    public int counter;        // Number of disabled cranes
    public int cranes = 10;         // Total number of cranes at the start
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
    public HighScorePersistant pointage;
    
    public float seuilVitesse = 1f;  

    private Vector2 previousPosition;
    private Vector3 previousPosition2;
    private float velocity;
    private float velocity2;

    public GameObject crane11;
    public GameObject crane12;
    public GameObject crane13;
    public GameObject crane14;
    public GameObject crane15;
    public GameObject crane16;
    public GameObject crane17;
    public GameObject crane18;
  

    public GameObject boss;
    public int vieBoss = 2;
    public bool bossHitWave2 = false;
    public bool bossHitWave3 = false;

    public finPartie finPartieScript;

    public AudioSource musiqueBoss;
    public AudioSource sonBoss;


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

        // Check if all cranes are inactive and show the treasure
        if (!lightActivated && AllCranesAreInactive())
        {
            tresor.SetActive(true);
            lightActivated = true;
            ambiance.Stop();
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

    void OnTriggerEnter(Collider other)
{
    if (other.tag == "epee")
    {
        if (velocity >= seuilVitesse || velocity2 >= seuilVitesse)
        {
            if (gameObject.CompareTag("crane"))
            {
                gameObject.SetActive(false);
                reussi.Play();
                GameManager.Instance.CraneDestroyed();
            }

            else if (gameObject.CompareTag("crane2"))
            {
                gameObject.SetActive(false);
                reussi.Play();
                GameManager.Instance.CraneDestroyed();
            }

            else if (gameObject.CompareTag("crane3"))
            {
                gameObject.SetActive(false);
                reussi.Play();
                GameManager.Instance.CraneDestroyed();
            }
            else if (gameObject == boss)
{
    if (cranesWave2Inactive() && !bossHitWave2)
    {
        reussi.Play();
        vieBoss = 1;
        bossHitWave2 = true;
        crane15.SetActive(true);
        crane16.SetActive(true);
        crane17.SetActive(true);
        crane18.SetActive(true);
    }
    else if (!cranesWave2Inactive())
    {
        rate.Play();
    }

    if (cranesWave2Inactive() && cranesWave3Inactive() && !bossHitWave3)
    {
        reussi.Play();
        vieBoss = 0;
        bossHitWave3 = true;
        boss.SetActive(false);
        finPartieScript.RestartScene();
        musiqueBoss.Stop();
        fin.Play();
    }
    else if (!cranesWave3Inactive())
    {
        rate.Play();
    }
}

        }
        else
        {
            rate.Play();
        }
    }
}

    bool cranesWave2Inactive()
    {
        GameObject[] cranes2 = GameObject.FindGameObjectsWithTag("crane2");
         foreach (GameObject crane2 in cranes2)
        {
            if (crane2.activeInHierarchy)
                return false;
        }
        sonBoss.Play();
        return true;
    }

    bool cranesWave3Inactive()
    {
        GameObject[] cranes3 = GameObject.FindGameObjectsWithTag("crane3");
         foreach (GameObject crane3 in cranes3)
        {
            if (crane3.activeInHierarchy)
                return false;
        }
        sonBoss.Play();
        return true;
    }

    public void BossFight() 
    {
        musiqueBoss.Play();
        boss.SetActive(true);
        crane11.SetActive(true);
        crane12.SetActive(true);
        crane13.SetActive(true);
        crane14.SetActive(true);
    }
}
