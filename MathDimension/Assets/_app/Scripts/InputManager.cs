using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // this is a singleton as we will only need one input manager
    private static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }
    
    private PlayerControls playerControls;

    private void Awake()
    {
        // playerControls manages input from the Player Input System
        if (_instance != null && _instance != this)
        {
            // this destroys the current instance if another one exists
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }
    
    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }
}
