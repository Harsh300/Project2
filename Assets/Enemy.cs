using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Slider enemyHealth;
    Animator enemyAnimator;
    Transform Player;
    float aiSpeed = 2f;
    public float maxDistance = 10000f;
    public float minDistance = 20f;
    bool chasing = false;
    bool isAttacking = false;
    float distance = 0.0f;
    

    public int enemyTotalHealth = 100;
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        distance = Vector3.Distance(transform.position, Player.position);
        transform.LookAt(Player);
        if(chasing = true)
        {
            enemyAnimator.SetBool("chasing", true);
            transform.position += transform.forward * aiSpeed * Time.deltaTime;
        }
        //chase range only
        if (distance <= minDistance)
        {
            //enemyAnimator.SetBool("chasing", true);
            
            transform.position += transform.forward * aiSpeed * Time.deltaTime;
            enemyAnimator.SetBool("chasing", true);
            chasing = true;
            

        }
        //attack range
        if (distance <= 7)
        {
            
            enemyAnimator.SetTrigger("attack");

        }

    }
    public void takeDamage()
    {
        enemyTotalHealth -= 10;
        Debug.Log(enemyTotalHealth);
        enemyHealth.value -= 10;
        if (enemyTotalHealth <= 0)
        {
            enemyAnimator.SetTrigger("dead");


            Destroy(gameObject, 2f);
            killCount.Count += 1;
            
           // Destroy(gameObject);
        }
    }
    public int inflictDamage()
    {
        //Player player = hit.collider.GetComponent<Player>();
        //player.takeDamage();
        return 0;
    }
    
}