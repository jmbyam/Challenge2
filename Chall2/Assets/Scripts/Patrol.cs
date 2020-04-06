using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float stopDistance;
    public float awarenessDistance;
    private float waitTime;
    public float startWaitTime;

    public Transform target;
    public Transform[] moveSpots;

    private int randomSpot;

    void Start(){
      waitTime = startWaitTime;
      randomSpot = Random.Range(0,moveSpots.Length);
      target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update(){

      if(Vector3.Distance(transform.position, target.position) > awarenessDistance){
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
      } else {
        if(Vector3.Distance(transform.position, target.position) > stopDistance){
          transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
          Vector3 pos = transform.position;
          pos.y = 0.25f;
          transform.position = pos;
        }
      }

      if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f){
        if(waitTime <= 0){
          randomSpot = Random.Range(0,moveSpots.Length);
          waitTime = startWaitTime;
        } else {
          waitTime -= Time.deltaTime;
        }
      }
    }
}
