using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;

    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;

    [SerializeField] private Transform playerCamera;
    [SerializeField] [Range(0.0f, 0.5f)] private float mouseSmoothTime = 0.03f;
    [SerializeField] private bool cursorLock = true;
    [SerializeField] private float mouseSensetivity = 3.5f;

    private float cameraCap;
    private Vector2 currentMouseDelta;
    private Vector2 currentMouseDeltaVelocity;

private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        inputManager = InputManager.Instance;

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
        }
    }

    void Update()
    {
        // Mouse Movement
        Vector2 targetMouseDelta = inputManager.GetMouseDelta();

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity,
            mouseSmoothTime);

        cameraCap -= currentMouseDelta.y * mouseSensetivity;
        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraCap;
        
        transform.Rotate(Vector3.up * (currentMouseDelta.x * mouseSensetivity));
        
        // Player Movement
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);

        float cameraYRotation = playerCamera.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, cameraYRotation, 0);
        move = rotation * move;
        
        controller.Move(move * (Time.deltaTime * playerSpeed));
        
        /*
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        */
        // Jump function has been removed here, Al doesn't jump

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
