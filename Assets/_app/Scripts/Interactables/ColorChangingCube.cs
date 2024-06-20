using UnityEngine;

// This is a silly object meant to define how the interaction system works.
// Debating whether or not to make Interactable an interface or keep it
// inherited like it is now.
public class ColorChangingCube : Interactable
{
    // Define the two colors
    private Color colorRed = Color.red;
    private Color colorBlue = Color.blue;

    // Store the current color state
    private bool isRed = true;
    
    // Reference to the Renderer component of the cube
    private Renderer cubeRenderer;
    
    void Start()
    {
        // Get the Renderer component attached to the cube
        cubeRenderer = GetComponent<Renderer>();

        // Set the initial color of the cube to red
        cubeRenderer.material.color = colorRed;
    }

    // Method to toggle the cube's color
    protected override void Interact()
    {
        // Toggle the color state
        if (isRed)
        {
            cubeRenderer.material.color = colorBlue;
        }
        else
        {
            cubeRenderer.material.color = colorRed;
        }

        // Update the color state
        isRed = !isRed;
    }
}
