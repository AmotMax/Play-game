using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potiga : MonoBehaviour
{
   // ALL ARTISTIC RELATED
    
    
    
    public bool isGrounded, isDead;
    public Animator anim, audience;
    public float timer = 3;

    public GameObject[] sounds, cadreSounds, sawSounds;
    public int randomSound;
    public GameObject sawReal, cheerSounds, onClick;

    public GameObject bloodParticle, bloodSpurt, toggleGored;

    public bool isGored;
    
    public float speed;

    public GameObject fxWall, fxFloor, fxFlower;



    // Start is called before the first frame update
    void Start()
    {
        isGored =false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGored)
        {
            toggleGored.SetActive(true);
        }
        else
        {
            toggleGored.SetActive(false);
        }


        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if(isGrounded)
        {
            anim.SetBool("isGrounded", true);
            

        }
        if (!isGrounded)
        {
            anim.SetBool("isGrounded", false);
            
        }

        if (isDead)
        {
            audience.SetBool("isWalking", true);
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            audience.SetBool("isWalking", false);
            isDead = false;
            timer = 5;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Instantiate(fxWall, transform.position, transform.rotation);
        }

        if (other.gameObject.CompareTag("Floor"))
        {
            Instantiate(fxFloor, transform.position, transform.rotation);
        }


        if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Wall"))
        {
            randomSound = Random.Range(0, sounds.Length);
            Instantiate(sounds[randomSound], transform.position, Quaternion.identity);
            Debug.Log(randomSound);

            if(isGored)
            {
                Instantiate(bloodParticle, transform.position, Quaternion.identity);
            }
        }

        if (other.gameObject.CompareTag("Wind"))
        {
            isDead = true;
            randomSound = Random.Range(0, cadreSounds.Length);
            Instantiate(cadreSounds[randomSound], transform.position, Quaternion.identity);
            Instantiate(cheerSounds, transform.position, Quaternion.identity);
            
        }

        if (other.gameObject.CompareTag("Saw"))
        {
            isDead = true;
            randomSound = Random.Range(0, sawSounds.Length);
            Instantiate(sawSounds[randomSound], transform.position, Quaternion.identity);
            Instantiate(sawReal, transform.position, Quaternion.identity);
            Instantiate(cheerSounds, transform.position, Quaternion.identity);
            
            if(isGored)
            {
                Instantiate(bloodParticle, transform.position, Quaternion.identity); 
                Instantiate(bloodSpurt, new Vector3 (transform.position.x, transform.position.y + 3, transform.position.z), bloodSpurt.transform.rotation);
            }

        }
    }

    public void GoreMode()
    {
        isGored = !isGored;
    }

    public void SoundOnClick()
    {
        Instantiate(onClick, transform.position, Quaternion.identity);
    }
}
