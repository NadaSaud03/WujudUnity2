using UnityEngine;
using UnityEngine.UIElements;

public class ScheduleUIController : MonoBehaviour
{
    private VisualElement schedulePanel;  // Panel that contains the schedule
    private Button scheduleButton;  // Menu button (three bars)
    private Button closeButton;     // Close button (X)
    private Button attendButton1;
    private Button attendButton2;

    private string linkedInUrl = "https://www.linkedin.com/company/leapandinnovate/";

    void OnEnable()
    {
        // Load UI Document
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Get UI elements
        schedulePanel = root.Q<VisualElement>("schedulePanel"); // This should contain your schedule
        scheduleButton = root.Q<Button>("scheduleButton");  // This should be your three-bar menu button
        closeButton = root.Q<Button>("closeButton");       // This should be your X button
        attendButton1 = root.Q<Button>("attendButton1");
        attendButton2 = root.Q<Button>("attendButton2");

        // Check if elements were found
        if (schedulePanel == null || scheduleButton == null || closeButton == null)
        {
            UnityEngine.Debug.LogError("One or more UI elements not found!");
        }

        // Initially hide the schedule panel
        schedulePanel.style.display = DisplayStyle.None;

        // Add event listeners
        scheduleButton.clicked += ToggleSchedule;  // Menu button
        closeButton.clicked += CloseSchedule;     // Close button (X)
        attendButton1.clicked += OpenLinkedIn;
        attendButton2.clicked += OpenLinkedIn;
    }

    // Toggle the visibility of the schedule panel
    void ToggleSchedule()
    {
        UnityEngine.Debug.Log("Menu Button (Three Bars) Clicked!");  // Debugging log

        // Check if the schedule panel is visible, and toggle accordingly
        if (schedulePanel.style.display == DisplayStyle.None)
        {
            UnityEngine.Debug.Log("Showing schedule...");
            schedulePanel.style.display = DisplayStyle.Flex;  // Show the schedule
        }
        else
        {
            UnityEngine.Debug.Log("Hiding schedule...");
            schedulePanel.style.display = DisplayStyle.None;  // Hide the schedule
        }
    }

    // Close the schedule panel when the close button (X) is clicked
    void CloseSchedule()
    {
        UnityEngine.Debug.Log("Close Button (X) Clicked!");  // Debugging log
        schedulePanel.style.display = DisplayStyle.None;  // Hide the schedule
    }

    // Open LinkedIn when attend button is clicked
    void OpenLinkedIn()
    {
        UnityEngine.Debug.Log("Attend Button Clicked!");  // Debugging log
        UnityEngine.Application.OpenURL(linkedInUrl);
    }
}