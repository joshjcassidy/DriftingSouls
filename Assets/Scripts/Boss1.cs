using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Enemy
{
    public Animator animator;
    private Rigidbody2D myRigidbody;
    //public bool bossActive;
    public BossTriggerTiles triggerTiles;

    public Transform[] path;
    public int currentPoint;
    public Transform currentGoal;
    public float roundingDistance;

    public BooleanValue bossDefeated;
    public GameObject gates;
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(triggerTiles.bossTriggered == true){
            activateMole();
        }
    }

    
    void activateMole(){
        /*if(Player touching X panels and mole not activated){
                boolean for ACTIVATE THE MOLE to be picked up by his movement script i guess?
                
                changeAnimation(temp - transform.position);
                myRigidbody.MovePosition(temp);
                
                ChangeState(EnemyState.walk);
                animator.SetBool("moving", true);
        }*/
        
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

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("spikesOn"))
        {
            bossDefeated.RuntimeValue = true;

            this.gameObject.SetActive(false);

            gates.SetActive(false);
        }
    }
}
