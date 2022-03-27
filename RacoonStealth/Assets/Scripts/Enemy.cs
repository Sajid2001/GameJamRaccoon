using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;
    private int nextPosition;
    [SerializeField]
    private int distance;
    private Vector3 direction;

    void Start() {
        waitTime = startWaitTime;
        nextPosition = 1;
    }

    void Update() {
        Patrol();
        if(CanSeePlayer()){
            Debug.Log("Game Over");
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
            return true;

        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + direction * distance, Color.blue);
        }
        return false; 
        
    }


}
