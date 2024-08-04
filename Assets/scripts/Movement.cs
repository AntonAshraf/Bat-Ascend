using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MaximumSpeed = 10.0f;
    public CharacterController controller;
    public Camera cam;
    public float mass = 1.0f;
    public float maxJumpHeight = 10.0f;
    
    private float gravityY = 0.0f;
    public int lives = 3;
    
    public float flytimer = 0.0f;
    public bool win = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        
        float dX = Input.GetAxis("Horizontal");
        float dY = Input.GetAxis("Vertical");
        
        if (flytimer >= 0){
            flytimer -= Time.deltaTime;
        }
        float jumpHeight = maxJumpHeight * Time.deltaTime;  
        
        
        Vector3 moveVector = new Vector3(dX, 0, dY);
        moveVector = Quaternion.AngleAxis(cam.transform.rotation.eulerAngles.y, Vector3.up) * moveVector;

        moveVector.Normalize();

        if(Input.GetKey(KeyCode.LeftShift))
        {
            MaximumSpeed = 30.0f;
        }
        else
        {
            MaximumSpeed = 10.0f;
        }
        moveVector *= MaximumSpeed;
        

        print(gravityY);
        if(Input.GetKey(KeyCode.Space) && flytimer > 0.0f){
            gravityY = Mathf.Sqrt(2 * maxJumpHeight * -Physics.gravity.y);
        } else {
        gravityY = gravityY + Physics.gravity.y * Time.deltaTime;
        }
        
            

        // float mag = moveVector.magnitude;
        // print(mag);

        // moveVector *= MaximumSpeed;
        Vector3 newMoveVector = moveVector;
        newMoveVector.y = gravityY;

        // controller.SimpleMove(moveVector);
        Physics.SyncTransforms();
        controller.Move(newMoveVector * Time.deltaTime);

        if(moveVector != Vector3.zero)
        {
            // transform.forward = moveVector;
            Quaternion newRotation = Quaternion.LookRotation(moveVector, Vector3.up);
            // transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10.0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Time.deltaTime * 720);
            // transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 720 * Time.deltaTime);
            
        }
        if (flytimer > 0.0f)
        {
            transform.Find("Wings").gameObject.SetActive(true);
        }else{
            transform.Find("Wings").gameObject.SetActive(false);
        }
    }
    /* private void OnApplicationFocus(bool focusStatus) {
        if(focusStatus == false)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    } */
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "finish")
            win = true;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.gameObject.name == "Meteor")
        {
            Destroy(hit.gameObject);
            if(lives > 0){
                transform.position = new Vector3(480,10,65);
                lives--;
            }
            if (lives == 0){
                Destroy(gameObject);
            }
        }
        if (hit.gameObject.name == "redbull"){
            flytimer += 5.0f;
            Destroy(hit.gameObject);
        }
    }

}
