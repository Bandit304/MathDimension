using UnityEngine;
using UnityEngine.InputSystem;

// TODO: Update namespace when moving file
namespace Assets._app.Scripts.UpdatedPlayer {
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour {

        // ===== Fields =====

        [Header("Player Movement")]
        public float movementSpeed;
        public float movementAcceleration;
        public float movementDrag;

        [Header("Player Components")]
        public Rigidbody rb { get; private set; }

        [Header("Player Input Values")]
        [SerializeField] private Vector3 movementVector;


        // ===== Unity Events =====

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start() {
            // Get RigidBody component
            rb = GetComponent<Rigidbody>();
            // Apply drag
            rb.linearDamping = movementDrag;
        }

        // Update is called once per frame
        void Update() {
            // Handle Player Movement
            HandleMovement();
        }

        // ===== Unity Input Events =====
        
        public void ReadMovement(InputAction.CallbackContext context) {
            // Read movement vector
            Vector2 move2d = context.ReadValue<Vector2>();
            // Convert movement vector to 3d
            movementVector = move2d.y * transform.forward + move2d.x * transform.right;
        }

        // ===== Methods =====

        private void HandleMovement() {
            // Add force
            rb.AddForce(movementVector * movementAcceleration);

            // Limit Horizontal Velocity
            Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

            if (horizontalVelocity.magnitude > movementSpeed) {
                // Limit horizontal velocity
                Vector3 limitedVelocity = horizontalVelocity.normalized * movementSpeed;
                // Get vertical velocity
                Vector3 verticalVelocity = new Vector3(0, rb.linearVelocity.y, 0);
                // Set new velocity
                rb.linearVelocity = limitedVelocity + verticalVelocity;
            }
        }
    }
}
