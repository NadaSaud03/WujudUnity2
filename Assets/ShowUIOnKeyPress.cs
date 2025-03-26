using UnityEngine;

public class ShowUIOnKeyPress : MonoBehaviour
{
    // Reference to the Canvas or UI Panel containing your UI elements
    public GameObject uiPanel;

    // Define the key you want to use to show/hide the UI (e.g., "C" key)
    public KeyCode toggleKey = KeyCode.C;

    // Update is called once per frame
    void Update()
    {
        // Check if the defined key is pressed
        if (Input.GetKeyDown(toggleKey))
        {
            // Toggle the UI visibility
            bool isActive = uiPanel.activeSelf;
            uiPanel.SetActive(!isActive);  // If the panel is active, it will be deactivated, and vice versa
        }
    }
}
