using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float rotateSpeed = 360f;
    
void RotateSphere ()
{

if (Input.GetAxisRaw ("Vertical") > 0) {
// transform.Rotate (Vector3.right, rotateSpeed * Time.deltaTime);
} else if (Input.GetAxisRaw ("Vertical") < 0) {
// transform.Rotate (Vector3.left, rotateSpeed * Time.deltaTime);
} else if (Input.GetAxisRaw ("Horizontal") > 0) {
    RotateRight();
} else if (Input.GetAxisRaw ("Horizontal") < 0) {
    RotateLeft();
}
}
public void RotateRight(){
transform.Rotate (Vector3.down , rotateSpeed * Time.deltaTime);

}
public void RotateLeft(){
transform.Rotate (Vector3.up , rotateSpeed * Time.deltaTime);
}



    // Update is called once per frame
    void Update()
    {
        RotateSphere ();
       
        
    }
}
