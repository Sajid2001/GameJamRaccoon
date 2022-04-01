using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private float waitTime;
    private float sightTime;
    public float startWaitTime;
    public float startSightTime;
    public Transform[] moveSpots;
    private int nextPosition;
    [SerializeField]
    private int distance;
    private Vector3 direction;

    void Start() {
        waitTime = startWaitTime;
        sightTime = startSightTime;
        nextPosition = 1;
    }

    void Update() {
        Patrol();
        if(CanSeePlayer()){
            GameManager.isGameOver = true;
        }
    }

    void Patrol(){
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextPosition].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[nextPosition].position) < 0.5f)
        {
            if (waitTime <= 0){
                nextPosition = (nextPosition+1) % moveSpots.Length;
                direction = (moveSpots[nextPosition].position - transform.position).normalized;
                waitTime = startWaitTime;

            } 
            else{
                waitTime -= Time.deltaTime;
            }
                
        }
    }

    bool CanSeePlayer(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance);
        
        if(hit.collider != null && hit.collider.CompareTag("Player")){
            Debug.DrawLine(transform.position, hit.point, Color.red);
            if(sightTime <= 0){
                return true;
            }
            sightTime-= Time.deltaTime;

            

        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + direction * distance, Color.blue);
        }
        return false; 
        
    }


}
