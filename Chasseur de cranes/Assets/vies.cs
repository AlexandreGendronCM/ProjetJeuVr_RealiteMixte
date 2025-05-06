using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vies : MonoBehaviour
{
    public int vie = 3;
    public int conteur = 10;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(vie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "epee")
        {

            Debug.Log("epee");


        }
        else if (other.tag == "crane") {
            if (vie > 0) {
                vie--;
                Debug.Log(vie);
            }else if(vie <=0)
            {
                Debug.Log("terminus");
            }

        }


    }
}