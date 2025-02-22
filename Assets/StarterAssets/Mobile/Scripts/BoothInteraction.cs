using UnityEngine;
//using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UI;
using TMPro;
public class NewMonoBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI boothInfoText; // Assign in the Inspector

    public void ShowBoothInfo(string boothName, string description)
    {
        boothInfoText.text = $"Booth: {boothName}\n{description}";
    }
    [Header("Booth Information")]
    public string companyName;
    [TextArea] public string description;
    public string industry;
    public string region;
    public string size;  // Startup, Mid-size, Enterprise
    public bool seeksInvestment;
    public bool offersTraining;
    public bool isHiring;

    [Header("UI Elements")]
    public GameObject infoPanelPrefab;  // Assign the UI Panel prefab in Inspector
    private GameObject spawnedInfoPanel;

    void Start()
    {
        if (infoPanelPrefab != null)
        {
            spawnedInfoPanel = Instantiate(infoPanelPrefab, FindObjectOfType<Canvas>().transform);
            spawnedInfoPanel.SetActive(false); // Hide the panel initially
        }
    }

    void OnMouseDown()  // This is called when clicking on a booth
    {
        if (spawnedInfoPanel != null)
        {
            spawnedInfoPanel.SetActive(true);
            UpdateBoothInfo();
        }
    }

    void UpdateBoothInfo()
    {
        Text infoText = spawnedInfoPanel.GetComponentInChildren<Text>();
        if (infoText != null)
        {
            infoText.text = $"{companyName}\n{description}\nIndustry: {industry}\nRegion: {region}\nSize: {size}\n" +
                            $"Seeks Investment: {(seeksInvestment ? "Yes" : "No")}\n" +
                            $"Offers Training: {(offersTraining ? "Yes" : "No")}\n" +
                            $"Hiring: {(isHiring ? "Yes" : "No")}";
        }
    }

    public void ClosePanel()
    {
        if (spawnedInfoPanel != null)
        {
            spawnedInfoPanel.SetActive(false);
        }
    }
}
