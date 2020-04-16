using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timee : MonoBehaviour
{
   float timeLeft = 120f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         timeLeft -= Time.deltaTime;
         
         
         
         print(Mathf.Round(timeLeft));
         if(timeLeft < 0)
         {
            
         }
    }
}
