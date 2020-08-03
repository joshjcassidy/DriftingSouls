using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
    idle,
    walk,
    interact,
    stagger
}

public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float moveSpeed = 5f;
    private Rigidbody2D myRigidbody;
    private Vector3 movement;
    private Animator animator; 
    public OnLoadPosition startingPosition;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;
    Transform pullable;

    void Start()
    {
        currentState = PlayerState.walk;
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //animator.setFloat("moveX", 0);
        //animator.setFloat("moveY", -1);
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);
        transform.position = startingPosition.initialValue;
    }
    
    void Update()
    {
        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(currentState == PlayerState.walk || currentState == PlayerState.idle){
            UpdateAnimationAndMove();
        }

        //PullBlock();
        
    }

    void UpdateAnimationAndMove(){
        if(movement != Vector3.zero){
            MoveCharacter();
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("moving", true);
        }
        else{
            animator.SetBool("moving", false);
        }
    }

    void MoveCharacter(){
        /*myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );*/
        movement.Normalize();
        myRigidbody.MovePosition(
            transform.position + movement * moveSpeed * Time.deltaTime
        );
    }
    
    
    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage){
        
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        
        if(currentHealth.RuntimeValue > 0){
            StartCoroutine(KnockCo(myRigidbody, knockTime, damage));
        }
        else{
            //this.gameObject.SetActive(false);
        }
    }

    private IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime, float damage){
        if(myRigidbody != null){
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    /*public void OnControllerColliderHit(ControllerColliderHit touch){
        if(touch.transform.tag = "blockPushable"){
            pullable = touch.transform;
        }

    }

    public void PullBlock(){
        if(pullable != null){
            Vector3 D = transform.position - pullable;
            float distance = D.magnitude;
            Vector3 pullDirection = D.normalized;

            if(distance > 50) 
            {
                pullable = null;
            }
            else if(distance > 3)
            {
                float pullForce = 10;

                pullable.GetComponent<Rigidbody>().velocity += pullDirection*(pullForce * Time.deltaTime);
            }
        }
    }*/
}
