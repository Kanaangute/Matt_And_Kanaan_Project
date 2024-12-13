//Matthew Gocool  12/07/24
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        // No logic needed unless you want debug 
    }

    // Method to initialize or reset player states
    public void InitializePlayer()
    {
        controller = GetComponent<CharacterController>();
        playerVelocity = Vector3.zero;
        isGrounded = true; // Assume the player starts on the ground
    }

   
    public void ProcessMove(Vector2 input)
    {
        // Check if the player is on the ground
        isGrounded = controller.isGrounded;

        
        Vector3 moveDirection = Vector3.zero;

        // Use input.x for left/right movement and input.y for forward/backward movement
        moveDirection.x = input.x; 
        moveDirection.z = input.y; 

        // Transform the movement direction based on the player's rotation
        moveDirection = transform.TransformDirection(moveDirection);

        // Apply movement
        controller.Move(moveDirection * speed * Time.deltaTime);

        // gravity
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f; // Small value to keep the player grounded
        }
        else
        {
            playerVelocity.y += gravity * Time.deltaTime; // Apply gravity
        }

       
        controller.Move(playerVelocity * Time.deltaTime);

        
        Debug.Log(playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }

    // Reset player state when restarting the game
    public void ResetPlayer()
    {
        InitializePlayer();
        transform.position = Vector3.zero; // Reset player position to a default location
    }
}
