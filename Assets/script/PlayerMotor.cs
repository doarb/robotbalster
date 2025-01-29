using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private bool isGrounded;
    private Vector3 playerVelocity;
    public float playerSpeed = 5.0f;
    public float gravityValue = -9.81f;
    public float jumpHeight = 3.0f;
    Animator animator;
    public Camera playerCamera; // Ajoutez une référence à la caméra

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        if (playerCamera == null)
        {
            playerCamera = Camera.main; // Assurez-vous que la caméra principale est assignée
        }
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("IsSprinting", true);
            animator.SetBool("IsWalking", false);
            playerSpeed = 10.0f;
        }    else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))    
        {
            playerSpeed = 5.0f;
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsSprinting", false);
        }
        else
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsSprinting", false);
        }

        

        Debug.Log("Walking : " + animator.GetBool("IsWalking"));
        Debug.Log("Sprinting : " + animator.GetBool("IsSprinting"));
    }

    public void Move(Vector2 direction)
    {
        

        // Utilisez la rotation de la caméra pour calculer la direction du mouvement
        Vector3 move = playerCamera.transform.forward * direction.y + playerCamera.transform.right * direction.x;
        move.y = 0; // Assurez-vous que le mouvement est uniquement sur le plan XZ

        controller.Move(move * Time.deltaTime * playerSpeed);
        playerVelocity.y += gravityValue * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -1f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
    }
}

