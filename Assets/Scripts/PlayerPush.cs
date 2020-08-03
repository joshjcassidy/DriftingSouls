using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask boxMask;

    GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && Input.GetKeyDown(KeyCode.E))
        {
            box = hit.collider.gameObject;
        }

         /*if(collision.collider.tag == "boxPushable")
        {
            rigidbody.constraints = RigidbodyConstraints.None;
        }*/
    }

    /*void OnCollisionStay2D(Collision2D col){
        if (col.gameObject.tag == "boxPushable"){
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "boxPushable")
        {
            //other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            //GetComponent<Collider>().attachedRigidbody.RigidbodyConstraints.None;
        }
    }

        void OnDrawGizmos(){
            Gizmos.color = Color.yellow;

            Gizmos.DrawLine (transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
        }
}
