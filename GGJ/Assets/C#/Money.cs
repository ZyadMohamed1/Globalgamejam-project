using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public float score;
    public bool moneyinhand;
      public string nameee;
      public PlayerMovement PM ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(moneyinhand == true){
         score = score+ 100 ;
         Destroy(PM.tool);
         moneyinhand = false;
         print(score);

     }  
    }
     private void OnTriggerEnter(Collider other){
      PM = other.gameObject.GetComponent<PlayerMovement>();
      nameee = PM.namee;
      if(PM.namee == "Money"){
       moneyinhand = true;
      }else{
       moneyinhand = false;
       PM.name = null;
      }
     }
     private void OnTriggerExit(Collider other){
         moneyinhand = false;
         
     }
}
