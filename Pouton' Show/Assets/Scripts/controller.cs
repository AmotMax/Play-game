using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    //ALL CONTROLS GAMEPLAY RELATED
    
    public Rigidbody rb;

    public float speed = 5f;
    public float turnSpeed = 360;
    public float speedRotation;
    public float jumpforce;

    private Vector3 input;

    public float DeathTime = 3;
    public float timer;
    public bool goTimer;
    public Transform spawnPoint;
    public TrailRenderer trail;
    public BoxCollider potiga;

    public GameObject pasNormal;

    public bool isGrounded, isWinded, isSawed, isTrapped;


    public void Start()
    {

    }

    public void Update()
    {
        GatherUpdate();
        Look();

        if (goTimer == true)
        {
            timer -= Time.deltaTime;
        }
        else if (goTimer == true)
        {
            timer = DeathTime;
        }
            
        if(isSawed)
        {
            transform.Rotate(0, speedRotation * Time.deltaTime, 0);

        }

        if(isWinded)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 15, transform.position.z);
        }

        
        if(timer <= 0)
        {
            transform.position =  new Vector3 (spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
            goTimer = false;
            timer = DeathTime;
            isTrapped = false;
            isWinded = false;
            isSawed = false;
            rb.velocity = new Vector3(0, 0, 0);
            trail.enabled = true;
            potiga.enabled = true;
            rb.isKinematic = false;

        }
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void GatherUpdate()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    public void Look()
    {
        if (input != Vector3.zero)
        {
            var relative = (transform.position + input) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
    }

    public void Move()
    {
        if (!isTrapped)
        {
            rb.MovePosition(transform.position + (transform.forward * input.magnitude) * speed * Time.deltaTime);
        }

       
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
             isGrounded = true;
        }

        if (other.gameObject.CompareTag("Wind"))
        {
            
            isWinded = true;
            isTrapped = true;
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Wind"))
        {
            goTimer = true;
            rb.velocity = new Vector3(0, 0, 0);
            potiga.enabled = false;
            isWinded = true;



        }

        if (other.gameObject.CompareTag("PasNormal"))
        {
            goTimer = true;
            rb.velocity = new Vector3(0, 0, 0);
            potiga.enabled = false;
            potiga.enabled = false;
            Instantiate(pasNormal, transform.position, Quaternion.identity);
        }

        
        if (other.gameObject.CompareTag("Saw"))
        {
            
                    
            rb.velocity = new Vector3(0, 0, 0);

            goTimer = true;

            isTrapped =true;
            isSawed = true;

            trail.enabled = false;
            rb.isKinematic = true;
            potiga.enabled = false;


        }

    }


    public void respawn()
    {
        transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        goTimer = false;
        timer = DeathTime;
        isTrapped = false;
        isWinded = false;
        isSawed = false;
        rb.velocity = new Vector3(0, 0, 0);
        trail.enabled = true;
        potiga.enabled = true;
        rb.isKinematic = false;
    }



    public void Quit()
    {
        Application.Quit();
    }
}
