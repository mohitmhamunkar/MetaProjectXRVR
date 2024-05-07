using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Translate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void translateForward(float yDirection)
    {
        transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y + (yDirection * 0.01f), transform.position.z);
    }
    private void translateVertical()
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0)
        {
            translateForward(OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        translateVertical();
    }
}
