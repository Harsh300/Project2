using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy") // this string is your newly created tag
        {
            Debug.Log("DAMAGE");


            // Even you can get Bullet object
            //GameObject strikingBullet = collider.gameObject;
        }
    }
}
