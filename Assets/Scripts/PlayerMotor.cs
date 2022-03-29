using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private float speed = 5.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    public float gravity;
    private float animationDuration = 4.0f;
    private bool isDead = false;
    private float startTime;
    public float jumpForce;
    private Animator myAnimator;
    
    // Start is called before the first frame update
    void Start()
    { 
        controller = GetComponent<CharacterController> ();
        startTime = Time.time;
        myAnimator = GetComponent<Animator> ();
        myAnimator.SetBool("Grounded", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if (Time.time - startTime < animationDuration)
        {
            controller.Move (Vector3.forward * speed * Time.deltaTime);
            return;
        }
        moveVector = Vector3.zero;

        
        
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                verticalVelocity = jumpForce;
                myAnimator.SetBool("Grounded", false);
            }
            else{
                verticalVelocity = -0.5f;
    
            }
        }

        else 
        {
            verticalVelocity -= gravity * Time.deltaTime;
            myAnimator.SetBool("Grounded", true);
        }
        // X - Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        // Y - Up and Down
        moveVector.y = verticalVelocity; 
        // Z - Forward and Backword
        moveVector.z = speed;
        controller.Move(moveVector * Time.deltaTime);
        if (myAnimator!= null)
        {
            Debug.Log("Animator is not Null");
        }
        else{
            Debug.Log("Animator is  Null");
        }

        Debug.Log("This is the value" + myAnimator.GetBool("Grounded"));

    }

    public void SetSpeed (float modifier)
    {
        speed = 5.0f + modifier;
    }

    // Called everytime player hits something
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        
        if (hit.moveDirection.z == 1 && hit.point.z > transform.position.z + controller.radius)
        {

 
            Debug.Log("I'm colliding with: " + hit.transform.name);
            Debug.Log("I'm colliding with: " + hit.transform.tag);
            Debug.Log("I impacted at: " + hit.point);
            Debug.Log(hit.moveDirection);
            if (hit.gameObject.CompareTag("Obstacle"))
                Death ();
        }
    }

    private void Death ()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }

}
