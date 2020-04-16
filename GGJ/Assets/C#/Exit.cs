using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public bool P1inzone;
    public bool P2inzone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (P1inzone && P2inzone) 
       {
           Debug.Log("Win");
       }
    }

    private void OnTriggerEnter(Collider other){
    if(other.gameObject.GetComponent<PlayerMovement>().playerId == 1){
P1inzone = true ;
    }if(other.gameObject.GetComponent<PlayerMovement>().playerId == 2){
P2inzone = true ;
    
    }
    }
    private void OnTriggerExit(Collider other){
    if(other.gameObject.GetComponent<PlayerMovement>().playerId == 1){
P1inzone = true ;
    }if(other.gameObject.GetComponent<PlayerMovement>().playerId == 2){
P2inzone = true ;
    
    }
    }
}
