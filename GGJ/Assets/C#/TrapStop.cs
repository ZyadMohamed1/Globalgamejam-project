using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapStop : MonoBehaviour
{
    
    public Damage trap ;
    public bool inzone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(inzone== true && Input.GetKeyDown(KeyCode.F)){
         trap.Trap = false;
         
     }   
            
    }

    private void OnTriggerEnter(Collider other){
    inzone = true ;
    }
    private void OnTriggerExit(Collider other){
    inzone = false ;
    }

}
