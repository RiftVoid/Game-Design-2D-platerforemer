using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movementv2 : MonoBehaviour
{

    public float movementSpeed = 5.0f;
    //public float jumpSpeed = 5f;
    //public float jumpHeight = 5f;
    //private float currentJumpSpeed = 0f;
    //private Vector3 playerVelocity;
    //private float gravityValue = -9.81f;
    public Rigidbody rb;
    public float jumpAmount = 5f;
    private float currentJumpAmount = 0;


    // Start is called before the first frame update
    void Start()
    {
        //currentJumpSpeed = jumpSpeed;
        currentJumpAmount = jumpAmount;
        Debug.Log("start jump set");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            //currentJumpSpeed = jumpSpeed;
            //jumpHeight = 5f;
            currentJumpAmount = jumpAmount;
            Debug.Log  ("jump reset");
        }
        
    }
        

    // Update is called once per frame
    void Update()
    {
        /////Vector3 cameraForward = cameraMovement.cameraForward;
        /////cameraForward.y = 0f;
        /////transform.forward = cameraForward;
        //if (Input.GetButtonDown("Jump"))
        //{
        //    playerVelocity.y += Mathf.Sqrt(jumpHeight * -6.0f * gravityValue);
        //    jumpHeight = 0f;
        //    Debug.Log("no more jump");
        //}

        //playerVelocity.y += gravityValue * Time.deltaTime;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{


        //transform.position += transform.up * Time.deltaTime * currentJumpSpeed * 20;
        //currentJumpSpeed = 0;
        //Debug.Log("no more jump");
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * currentJumpAmount, ForceMode.Impulse);
            currentJumpAmount = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * movementSpeed;
        }
    }
}
