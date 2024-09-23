using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    Animator anim;
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float force = 700.0f;
    public float jumpForce = 700.0f;
    public float gravity = 20.0f;

    public bool isGrounded = false;

    public bool isDie = false;
    public bool isDance = false;
    public bool isWalking = false;

    CharacterController controller;

    Vector3 inputDirection = Vector3.zero;
    Vector3 targetDirection = Vector3.zero;
    Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the animation controller parameters for the character
        anim.SetBool("isDie", false);  // Not dead initially
        anim.SetBool("isDance", false);
        anim.SetBool("isWalking", false);
        // Time to start the animation
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the input from the keyboard
        float x = -(Input.GetAxis("Vertical"));
        float z = Input.GetAxis("Horizontal");
        inputDirection = new Vector3(x, 0, z);

        // Check if the character is dead or not
        if (isDie)
        {
            // If the character is dead, stop all movement and animations except "die"
            anim.SetBool("isDie", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isDance", false);
            return;
        }

        // Handling input for animations and movement
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isDance", false);
            Debug.Log("W key is pressed: Walking");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isDance", false);
            Debug.Log("S key is pressed: Stopped Walking");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isDance", true);
            Debug.Log("D key is pressed: Dance");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isDance", false);
            Debug.Log("A key is pressed: Walking");
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("isDie", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isDance", false);
            Debug.Log("Z key is pressed: Die");
        }
        else
        {
            // If no keys are pressed, stop movement animations
            anim.SetBool("isWalking", false);
            anim.SetBool("isDance", false);
        }
    }
}
