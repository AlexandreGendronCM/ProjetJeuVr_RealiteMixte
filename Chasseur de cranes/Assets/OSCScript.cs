using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;


public class OSCScript : MonoBehaviour
{
    public extOSC.OSCReceiver ReceveurOSC;
    public extOSC.OSCTransmitter TransmetteurOSC;


    public GameObject lumiereTorche;
    public GameObject feuTorche;

    private void Start()
    {
        ReceveurOSC.Bind("*", TraiterMessageOSC);
        
    }

    public void TestOSC (OSCMessage oscMessage){
        Debug.Log(oscMessage);

       
    }

    void TraiterMessageOSC(OSCMessage oscMessage)
    {
        // Récupérer une valeur numérique en tant que float
        // même si elle est de type float ou int :
        float value;

       

        if (oscMessage.Values[0].Type == OSCValueType.Int)
        {
            value = oscMessage.Values[0].IntValue;


            if (oscMessage.Address == "/testOSC")
            {

                Debug.Log("SIGMA SIGMA BOYY" + value);
               
            }

           

        }
        else if (oscMessage.Values[0].Type == OSCValueType.Float)
        {
            value = oscMessage.Values[0].FloatValue;

            
        }
        else
        {
            // Si la valeur n'est ni un foat ou int, on quitte la méthode :
            return;
        }


    }

}

