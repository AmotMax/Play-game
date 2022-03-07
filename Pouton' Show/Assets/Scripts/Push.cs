using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Push : MonoBehaviour
{
    //ALL PROPULSION MECHANIC RELATED
    
    public Slider force;
    public Vector3 pusho;
    public bool isGrounded;

    public GameObject expulseSound;
    public GameObject toggleFly;

    public bool isPaused;

    public bool canFly;

    public pause pauseScript;
    void OnMouseDown()
    {
    }


    public Rigidbody rb;
   

    void Start()
    {
        canFly = false; ;
        pauseScript = GetComponent<pause>();
    }

    void Update()
    {
        isPaused = pause.isPaused;
        

       if (canFly)
       {
            toggleFly.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Mouse0) && !isPaused)
            {
                rb.AddRelativeForce(pusho * (force.value * 150));
                Instantiate(expulseSound, transform.position, transform.rotation);

            }

            if (Input.GetKeyDown(KeyCode.Space) && !isPaused)
            {
                rb.AddRelativeForce(pusho * (force.value * 150));
                Instantiate(expulseSound, transform.position, transform.rotation);

            }
        }

        if (!canFly)
        {
            toggleFly.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded && !isPaused)
            {
                rb.AddRelativeForce(pusho * (force.value * 150));
                Instantiate(expulseSound, transform.position, transform.rotation);

            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isPaused)
            {
                rb.AddRelativeForce(pusho * (force.value * 150));
                Instantiate(expulseSound, transform.position, transform.rotation);

            }
        }

      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") )
        {
            Debug.Log("bab");
            rb.AddRelativeForce(new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5)) * (rb.velocity.magnitude * 2 ));
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }

    }

    public void EnableFlyingMode()
    {
        canFly = !canFly;
    }
}
