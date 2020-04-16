using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixing : MonoBehaviour
{
    // Start is called before the first frame update
   public PlayerMovement PM ;
   public float FixingVal = 0;
   public bool Fixed ;
   public string nameee;

   public bool gearinhand = false;
   public bool destroyedgear = false;

   public GameObject DoorGO;
    public GameObject Particles;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FixingVal >100){
            FixingVal = 100 ;
            Destroy(PM.tool.gameObject);
            Destroy(Particles);
            gearinhand = false;
            Fixed = true;
            StartCoroutine (Door());
        }else{
        if (gearinhand == true ){
        FixingVal = FixingVal + 5*Time.deltaTime ;
        }
        if (destroyedgear == false){
          if (FixingVal > 50 )
        {
           Destroy(PM.tool.gameObject);
           destroyedgear =true ;
           gearinhand = false;
        }
        }
        }
       
        

    }

IEnumerator Door( ){
    for (float ft = 0f; ft <= 90; ft += 1f){
    DoorGO.transform.rotation = new Quaternion (DoorGO.transform.rotation.x,DoorGO.transform.rotation.y+ft,DoorGO.transform.rotation.z,0);
   
     yield return new WaitForSeconds(.1f);

    }

}
   
    private void OnTriggerEnter(Collider other){
      PM = other.gameObject.GetComponent<PlayerMovement>();
      nameee = PM.namee;
      if(PM.namee == "Gear"){
       gearinhand = true;
      }else{
       gearinhand = false;
      }
    }
        private void OnTriggerExit(Collider other){
       gearinhand = false;
         }
    }


