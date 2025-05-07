using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vies : MonoBehaviour
{
    public int vie = 3;
    public int compteur = 0;
    public GameObject epee;
    public GameObject epee2;
    // Start is called before the first frame update
    private Vector2 previousPosition;
    private Vector3 previousPosition2;
    private float velocity;
    private float velocity2;
    public int inactiveCount = 0;
    void Start()
    {
        Debug.Log(vie);
        previousPosition = epee.transform.position;
        previousPosition2 = epee2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

       
    }
    public void OnTriggerEnter(Collider other)
    {
         
        
         if (other.tag == "crane") {
            if (vie > 0) {
                vie--;
                Debug.Log(vie);
            }else if(vie <=0)
            {
                Debug.Log("terminus");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }


    }

    
    
}