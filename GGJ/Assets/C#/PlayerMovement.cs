using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public int playerId = 1;
    public float playerSpeed = 10f;
    public float rotateSpeed = 10f;
    
    [HideInInspector]
    public Rigidbody rb;

    public Transform Hand;
    public GameObject tool;
    public Tools toolScript;
    public string namee;
    public bool hold;
    public Animator AC;

public float Health;

    public bool rel = false;
    public AudioSource moveSound;
    public void Start()
    {
        
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
            Debug.Log("Rigidbody seted");
        }
    }

    private void Update()
    {
        RotatePlayer();

        if (hold)
        {
            tool.transform.position = Hand.position;
        }

        if (Input.GetButton("ToolRelease"+ playerId))
        {
            Relase();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        float x = Input.GetAxis("Horizontal" + playerId) * playerSpeed;
        float z = Input.GetAxis("Vertical" + playerId) * playerSpeed;
        float x2 = Input.GetAxis("Horizontal" + playerId) / 2 * playerSpeed;
        float z2 = Input.GetAxis("Vertical" + playerId) / 2 * playerSpeed;
        if (Input.GetAxis("Horizontal" + playerId) != 0 && Input.GetAxis("Vertical" + playerId) != 0 && rel)
        {
            rb.velocity = new Vector3(x2, rb.velocity.y, z2);
           
        }else
        {
            rb.velocity = new Vector3(x, rb.velocity.y, z);
            
        }

        if (Input.GetAxis("Horizontal" + playerId) != 0 || Input.GetAxis("Vertical" + playerId) != 0)
        {
            moveSound.Play();
             AC.SetBool("Run",true);
        }else
        {
            moveSound.Stop();
            AC.SetBool("Run",false);
        }
    }

    public void RotatePlayer()
    {
        if(Input.GetAxis("Horizontal" + playerId) > 0)//right
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 90f, 0f), rotateSpeed);
        }else if (Input.GetAxis("Horizontal" + playerId) < 0)//left
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, -90f, 0f), rotateSpeed);
        }

        if (Input.GetAxis("Vertical" + playerId) > 0)//up
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, 0f), rotateSpeed);
        }
        else if (Input.GetAxis("Vertical" + playerId) < 0)//down
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 180f, 0f), rotateSpeed);
        }

        if (Input.GetAxis("Horizontal" + playerId) > 0 && Input.GetAxis("Vertical" + playerId) > 0)//right up
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 45f, 0f), rotateSpeed);
        }
        else if (Input.GetAxis("Horizontal" + playerId) > 0 && Input.GetAxis("Vertical" + playerId) < 0)//right down
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 135f, 0f), rotateSpeed);
        }

        if (Input.GetAxis("Vertical" + playerId) > 0 && Input.GetAxis("Horizontal" + playerId) < 0)//up left
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, -45f, 0f), rotateSpeed);
        }
        else if (Input.GetAxis("Vertical" + playerId) < 0 && Input.GetAxis("Horizontal" + playerId) < 0)//down left
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 225f, 0f), rotateSpeed);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Tool"))
        {
            if (Input.GetButton("getTool" + playerId))
            {
                tool = other.gameObject;
                toolScript = other.GetComponent<Tools>();
                Take();
            }
        }
    }


    void Take()
    {
        namee = toolScript.toolName;
        hold = true;
    }

    void Relase()
    {
        namee = "none";
        hold = false;
    }
}
