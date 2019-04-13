using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Animator Ghost;
    private int health = 50;
    // Start is called before the first frame update
    void Start()
    {
        Ghost = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") < 0)
        {
            //Code for action on mouse moving left
            Ghost.SetBool("Strafe Left", true);
            
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            //Code for action on mouse moving right
            Ghost.SetBool("Strafe Right", true);
           
        }
        if (Input.GetAxis("Mouse X") == 0)
        {
            //Code for action on mouse moving right
            Ghost.SetBool("Strafe Right", false);
            Ghost.SetBool("Strafe Left", false);
        }
        if (Input.GetKeyDown("w"))
        {
            Ghost.SetBool("Fly Forward", true);
        }
        if (Input.GetKeyDown("s"))
        {
            Ghost.SetBool("Fly Backward", true);
        }
        if (!Input.GetKeyDown("w"))
        {
            Ghost.SetBool("Fly Forward", false);
        }
        if (!Input.GetKeyDown("s"))
        {
            Ghost.SetBool("Fly Backward", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ghost.SetTrigger("Melee Attack");
        }
        if (health <= 0)
        {
            Ghost.SetTrigger("Die");
            Destroy(gameObject, 2f);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy") // this string is your newly created tag
        {
            Ghost.SetTrigger("Take Damage");
            Debug.Log(health);
            health--;

        }
    }
    
}

