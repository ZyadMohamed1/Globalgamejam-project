using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public  PlayerMovement PM;
    public bool Trap ;

public bool hasParticle;
public bool hasObject;

    public GameObject Particles;
    public ParticleSystem PS;

    public bool Inzone;

    public float Damageval;

    public GameObject Indicator;



    public GameObject TrapObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Trap == true)
        {
         Indicator.SetActive(true);
         if (Inzone ==true){
         PM.Health = PM.Health-Damageval*Time.deltaTime ;
         }
         if(hasObject == true){
         TrapObject.SetActive(true);
         }
         
         
         if(hasParticle == true){
         PS = Particles.GetComponent<ParticleSystem>();
         PS.Play();
         }
        



        }else{
            
            if(hasParticle == true){
            PS.Stop();
            }
            
            if(hasObject == true){
            TrapObject.SetActive(false);
            }
             Indicator.SetActive(false);

        }

        
        
    }

    private void OnTriggerEnter(Collider other){
    PM = other.gameObject.GetComponent<PlayerMovement>();
    Inzone = true;

    }
    private void OnTriggerExit(Collider other){
    Inzone = false;
    }

}
