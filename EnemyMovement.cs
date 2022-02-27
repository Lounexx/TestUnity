using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    
    public int damageOnHit = 20;

    public SpriteRenderer graphics; 

    public Transform[] waypoints;

    private Transform target;

    private int destPoint = 0;


    void Start(){
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Si ennemi est quasi arrivé
        if(Vector3.Distance(transform.position,target.position) < 0.3f){
            destPoint = (destPoint+1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.CompareTag("Player") || collision.transform.CompareTag("Bot")){
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.takeDamage(damageOnHit);
        }
    }
    
}
