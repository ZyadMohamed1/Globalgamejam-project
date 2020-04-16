using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public GameObject[] TrapsArray ;
    public float currentnumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentnumber = Random.Range(0,1000);
        if (currentnumber == 100)
        {
        TrapsArray[0].GetComponent<Damage>().Trap = true;
        }else if (currentnumber == 500)
        {
           TrapsArray[1].GetComponent<Damage>().Trap = true; 
        }
    }
}
