using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArangeElements : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textElement;
    public Transform hand;
    void Start()
    {
        // transform.position+=hand.transform.position;
        if(textElement){
            Debug.Log(transform.localScale.x);
            Debug.Log(GetComponent<SphereCollider>().radius);
        CreateEnemiesAroundPoint(27,transform.position,GetComponent<SphereCollider>().radius);
        }
    }

 
 public void CreateEnemiesAroundPoint (int num, UnityEngine.Vector3 point, float radius) {
    List<string> alphabets =new List<string>(new string[] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","Clear"});//Space

   

        float increment = Mathf.PI * (3 - Mathf.Sqrt(5)); // golden angle increment
        float offset = 2f / num; // offset to center elements

        for (int i = 0; i < num; i++)
        {
            float y = i * offset - 1f + (offset / 2f); // y coordinate
            float r = Mathf.Sqrt(1f - y * y); // radius of x-z plane
            float phi = i * increment; // golden angle
            float x = Mathf.Cos(phi) * r * radius; // x coordinate
            float z = Mathf.Sin(phi) * r * radius; // z coordinate
            Vector3 spawnPos = new Vector3(x, y * radius, z);


            /* Now spawn */
            var elements = Instantiate (textElement, point+spawnPos, transform.rotation,transform) as GameObject;
       
            elements.SetActive(true);
            /* Rotate the enemy to face towards player */
            elements.transform.LookAt(point);
            elements.GetComponent<ChangeText>().textComponent.text=alphabets[i];
            elements.transform.SetParent(transform);
            /* Adjust height */
            //elements.transform.Translate (new Vector3 (0, elements.transform.localScale.y / 2, 0));
       }
       
        
         
         
 }
    // Helper function to calculate spherical coordinates
    private Vector3 GetSphericalCoordinates(float angle, float radius)
    {
        float x = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
        float y = 0;
        float z = Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        return new Vector3(x, y, z);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
