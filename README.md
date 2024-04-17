# Button Scaler

## Description
This script, `ButtonScaler.cs`, is designed for use in Unity projects to create a scaling effect for buttons when they are clicked. It allows buttons to visually respond to user interaction by scaling down when clicked and returning to their original size after a brief animation.

## Usage
1. Attach the `ButtonScaler.cs` script to any GameObject in your Unity project.
2. Set the desired parameters for scaling factor and animation duration in the Unity Inspector.
3. Ensure that the buttons you want to scale have the `Button` component attached to them in the Unity Inspector.

## Features
- Scales buttons down when clicked.
- Returns buttons to their original size after a brief animation.
- Supports customization of scaling factor and animation duration.

## Dependencies
- Requires the [LeanTween](https://assetstore.unity.com/packages/tools/animation/leantween-3595#description) library for smooth scaling animations. Ensure that LeanTween is installed in your Unity project.

## Instructions
1. Ensure that LeanTween is installed in your Unity project. If not, download and import it from the Unity Asset Store.
2. Attach the `ButtonScaler.cs` script to a GameObject that will manage button scaling.
3. Customize scaling factor and animation duration parameters in the Unity Inspector to suit your needs.
4. Attach the `Button` component to the buttons you want to scale in your scene.
5. Run your Unity project, and the buttons will scale down when clicked.

## Example
```csharp
// Attach this script to a GameObject in your Unity project
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour
{
    public float scaleFactor = 0.9f; // Scale factor when the button is clicked
    public float animationDuration = 0.1f; // Duration of the scaling animation

    void Update()
    {
        // Check if a button is being pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Get the GameObject that is currently being pressed
            GameObject clickedObject = EventSystem.current.currentSelectedGameObject;

            // Check if the currently pressed object is a button
            if (clickedObject != null && clickedObject.GetComponent<Button>() != null)
            {
                Button button = clickedObject.GetComponent<Button>();
                // Scale the clicked button
                ScaleButton(button);
            }
        }
    }

    void ScaleButton(Button button)
    {
        // Store the original scale of the button
        Vector3 originalScale = button.transform.localScale;

        // Scale down the button
        LeanTween.scale(button.gameObject, originalScale * scaleFactor, animationDuration)
            .setEase(LeanTweenType.easeInOutQuad)
            .setOnComplete(() =>
            {
                // Scale back to original size
                LeanTween.scale(button.gameObject, originalScale, animationDuration)
                    .setEase(LeanTweenType.easeInOutQuad);
            });
    }
}
