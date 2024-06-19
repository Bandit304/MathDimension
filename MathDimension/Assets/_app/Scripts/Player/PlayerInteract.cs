using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float rayDistance = 3f;
    [SerializeField] private LayerMask mask;
    private PlayerUI playerUI;
    [SerializeField] private InputManager inputs;
    void Start()
    {
        playerUI = GetComponent<PlayerUI>();
        //inputs = GetComponent<InputManager>();
    }

    void Update()
    {
        playerUI.UpdateText(string.Empty);
        // creates ray at the center of the camera, shoots forward
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance);
        RaycastHit hitInfo; // hitInfo will store collision information
        if (Physics.Raycast(ray, out hitInfo, rayDistance, mask))
        {
            // This statement sets the text in the UI when interacting with an object
            // both GetCompoent statements are very expensive, will need to figure out a different method
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (inputs != null && inputs.GetInteracting())
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
