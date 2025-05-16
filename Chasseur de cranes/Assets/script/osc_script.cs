using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;


public class osc_script : MonoBehaviour
{
    public extOSC.OSCReceiver ReceveurOSC;
    public extOSC.OSCTransmitter TransmetteurOSC;


    public Light lumiereTorche1;
    public Light lumiereTorche2;
    public Light lumiereTorche3;
    public Light lumiereTorche4;
    public Light lumiereTorche5;
    public Light lumiereTorche6;
    public Light lumiereTorche7;
    public Light lumiereTorche8;
    public Light lumiereTorche9;
    public Light lumiereTorche10;
    public Light lumiereTorche11;

    public UnityEngine.AI.NavMeshAgent crane1;
    public UnityEngine.AI.NavMeshAgent crane2;
    public UnityEngine.AI.NavMeshAgent crane3;
    public UnityEngine.AI.NavMeshAgent crane4;
    public UnityEngine.AI.NavMeshAgent crane5;
    public UnityEngine.AI.NavMeshAgent crane6;
    public UnityEngine.AI.NavMeshAgent crane7;
    public UnityEngine.AI.NavMeshAgent crane8;
    public UnityEngine.AI.NavMeshAgent crane9;
    public UnityEngine.AI.NavMeshAgent crane10;
    public UnityEngine.AI.NavMeshAgent crane11;
    public UnityEngine.AI.NavMeshAgent crane12;
    public UnityEngine.AI.NavMeshAgent crane13;
    public UnityEngine.AI.NavMeshAgent crane14;
    public UnityEngine.AI.NavMeshAgent crane15;
    public UnityEngine.AI.NavMeshAgent crane16;
    public UnityEngine.AI.NavMeshAgent crane17;
    public UnityEngine.AI.NavMeshAgent crane18;

    private void Start()
    {
        ReceveurOSC.Bind("*", TraiterMessageOSC);

    }

    public void TestOSC (OSCMessage oscMessage){
        Debug.Log(oscMessage);


    }

    void TraiterMessageOSC(OSCMessage oscMessage)
    {
        // R�cup�rer une valeur num�rique en tant que float
        // m�me si elle est de type float ou int :
        float valueLumiere;
        float valueVitesse;



        if (oscMessage.Values[0].Type == OSCValueType.Int)
        {
            valueLumiere = oscMessage.Values[0].IntValue;

        }
        else if (oscMessage.Values[0].Type == OSCValueType.Float)
        {
            valueLumiere = oscMessage.Values[0].FloatValue;
            valueVitesse = oscMessage.Values[0].FloatValue;

             if (oscMessage.Address == "/lumiere")
            {

                if (lumiereTorche1 != null)
                {
                    lumiereTorche1.intensity = valueLumiere;
                }

                if (lumiereTorche2 != null)
                {
                    lumiereTorche2.intensity = valueLumiere;
                }

                if (lumiereTorche3 != null)
                {
                    lumiereTorche3.intensity = valueLumiere;
                }

                if (lumiereTorche4 != null)
                {
                    lumiereTorche4.intensity = valueLumiere;
                }

                if (lumiereTorche5 != null)
                {
                    lumiereTorche5.intensity = valueLumiere;
                }

                if (lumiereTorche6 != null)
                {
                    lumiereTorche6.intensity = valueLumiere;
                }

                if (lumiereTorche7 != null)
                {
                    lumiereTorche7.intensity = valueLumiere;
                }

                if (lumiereTorche8 != null)
                {
                    lumiereTorche8.intensity = valueLumiere;
                }

                if (lumiereTorche9 != null)
                {
                    lumiereTorche9.intensity = valueLumiere;
                }

                if (lumiereTorche10 != null)
                {
                    lumiereTorche10.intensity = valueLumiere;
                }

                if (lumiereTorche11 != null)
                {
                    lumiereTorche11.intensity = valueLumiere;
                }

            }


            if (oscMessage.Address == "/vitesse")
            {
                if (crane1 != null)
                {
                    crane1.speed = valueVitesse;
                }

                if (crane2 != null)
                {
                    crane2.speed = valueVitesse;
                }

                if (crane3 != null)
                {
                    crane3.speed = valueVitesse;
                }

                if (crane4 != null)
                {
                    crane4.speed = valueVitesse;
                }

                if (crane5 != null)
                {
                    crane5.speed = valueVitesse;
                }

                if (crane6 != null)
                {
                    crane6.speed = valueVitesse;
                }

                if (crane7 != null)
                {
                    crane7.speed = valueVitesse;
                }

                if (crane8 != null)
                {
                    crane8.speed = valueVitesse;
                }

                if (crane9 != null)
                {
                    crane9.speed = valueVitesse;
                }

                if (crane10 != null)
                {
                    crane10.speed = valueVitesse;
                }

                if (crane11 != null)
                {
                    crane1.speed = valueVitesse;
                }

                if (crane12 != null)
                {
                    crane1.speed = valueVitesse;
                }

                if (crane13 != null)
                {
                    crane1.speed = valueVitesse;
                }

                if (crane14 != null)
                {
                    crane1.speed = valueVitesse;
                }

                if (crane15 != null)
                {
                    crane1.speed = valueVitesse;
                }

                if (crane16 != null)
                {
                    crane1.speed = valueVitesse;
                }

                if (crane17 != null)
                {
                    crane1.speed = valueVitesse;
                }

                if (crane18 != null)
                {
                    crane1.speed = valueVitesse;
                }
            }
        }
        else
        {
            // Si la valeur n'est ni un foat ou int, on quitte la m�thode :
            return;
        }


    }

}