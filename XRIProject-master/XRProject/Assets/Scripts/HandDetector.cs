using UnityEngine;
using OculusSampleFramework;
using System.Diagnostics;

public class HandDetector : MonoBehaviour
{
    public OVRHand LHand;



    void OnTriggerEnter(Collider other)
    {
        if (LHand.IsTracked)
        {
        }
        else 
        {
           
        }
    }
}