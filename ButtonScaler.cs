using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour
{
    public float scaleFactor = 0.9f; // Scale factor when the button is clicked
    public float animationDuration = 0.25f; // Duration of the scaling animation

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
