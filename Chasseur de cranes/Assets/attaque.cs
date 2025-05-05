using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class attaque : MonoBehaviour
{
    // Start is called before the first frame update
    private int counter;
    public int cranes;
    public TextMeshProUGUI score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         int currentScore = cranes - counter;
    score.text = "Score: " + currentScore;
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "epee") {
            gameObject.SetActive(false);
            Debug.Log("test");
            counter++;
        }
    }
}