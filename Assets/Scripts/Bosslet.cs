using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosslet : Enemy
{
    public Animator animator;
    private Rigidbody2D myRigidbody;
    //public bool bossActive;
    public BossletsTriggerTiles triggerTiles;

    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    public BooleanValue bossDefeated;

    void Start()
    {
        currentState = EnemyState.idle;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        //this.gameObject.SetActive(false);
    }

    void Update()
    {
        if(triggerTiles.bossletsTriggered == true){
            this.gameObject.SetActive(true);
            activateBosslet();
        }
        /*else if(triggerTiles.bossletsTriggered == true && this.gameObject.active == false){
            this.gameObject.SetActive(true);
        }*/

        if(bossDefeated.RuntimeValue == true){
            this.gameObject.SetActive(false);
        }
    }

    void activateBosslet(){
        if(Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance){
            Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, moveSpeed * Time.deltaTime);
        
            changeAnimation(temp - transform.position);
            myRigidbody.MovePosition(temp);
            
            ChangeState(EnemyState.walk);
            animator.SetBool("moving", true);
        }
        else{
            ChangeGoal();
        }
    }

    private void ChangeGoal(){
        if(currentPoint == path.Length - 1){
            currentPoint = 0;
            currentGoal = path[0];
        }
        else{
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }

    private void SetAnimFloat(Vector2 setVector){
        animator.SetFloat("moveX", setVector.x);
        animator.SetFloat("moveY", setVector.y);
    }
    private void changeAnimation(Vector2 direction){
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
            if(direction.x > 0){
                SetAnimFloat(Vector2.right);
            }
            else if(direction.x < 0){
                SetAnimFloat(Vector2.left);
            }
        }
        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
            if(direction.y > 0){
                SetAnimFloat(Vector2.up);
            }
            else if(direction.y < 0){
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState newState){
        if(currentState != newState){
            currentState = newState;
        }
    }
}
