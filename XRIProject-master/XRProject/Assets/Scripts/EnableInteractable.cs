using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableInteractable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   private bool intializeClick=false;

    public void setClick(){
        intializeClick=true;

    }
     public void resetClick(){
        intializeClick=false;
        
    }
    public bool acessClick(){
        return intializeClick;
        
    }
}
