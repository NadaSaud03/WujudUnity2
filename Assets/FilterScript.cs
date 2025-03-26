using UnityEngine;
using NaughtyAttributes;
using UnityEngine.UI; 
using System.Collections.Generic;

public class FilterScript : MonoBehaviour
{
    // Dropdown for company size
    [Dropdown("companySizeOptions")]
    public string selectedCompanySize;

    // Dropdown for industry
    [Dropdown("industryOptions")]
    public string selectedIndustry;

    // Toggle for seeking investment (Use Unity's UI Toggle for this in the Inspector)
    public bool seekingInvestment;

    // Toggle for hiring (Use Unity's UI Toggle for this in the Inspector)
    public bool hiring;

    // Text to display the filtered results
    public Text resultText;

    // Example booth data
    private List<BoothInfo> allBooths;

    // List of dropdown options
    private string[] companySizeOptions = { "Startup", "Mid-Size", "Enterprise" };
    private string[] industryOptions = { "Tech", "Finance", "Healthcare" };
    private string[] regionOptions = { "North", "South", "East", "West" };

    void Start()
    {
        // Example booth data (replace with actual data)
        allBooths = new List<BoothInfo>
        {
            new BoothInfo("Startup", "Tech", "North", true, false, "Booth A"),
            new BoothInfo("Enterprise", "Finance", "South", true, true, "Booth B"),
            new BoothInfo("Mid-Size", "Healthcare", "East", false, true, "Booth C"),
            new BoothInfo("Startup", "Tech", "West", false, false, "Booth D")
        };

        // Apply filtering logic
        FilterBooths();
    }

    void FilterBooths()
    {
        var filteredBooths = new List<BoothInfo>();

        foreach (var booth in allBooths)
        {
            if (booth.companySize == selectedCompanySize && booth.industry == selectedIndustry &&
                booth.seekingInvestment == seekingInvestment && booth.hiring == hiring)
            {
                filteredBooths.Add(booth);
            }
        }

        // Display the filtered results as text
        DisplayResults(filteredBooths);
    }

    void DisplayResults(List<BoothInfo> filteredBooths)
    {
        resultText.text = "Filtered Booths:\n";
        if (filteredBooths.Count == 0)
        {
            resultText.text += "No booths match the selected criteria.";
        }
        else
        {
            foreach (var booth in filteredBooths)
            {
                resultText.text += booth.boothName + "\n";
            }
        }
    }
}

[System.Serializable]
public class BoothInfo
{
    public string companySize;
    public string industry;
    public string region;
    public bool seekingInvestment;
    public bool hiring;
    public string boothName;

    public BoothInfo(string companySize, string industry, string region, bool seekingInvestment, bool hiring, string boothName)
    {
        this.companySize = companySize;
        this.industry = industry;
        this.region = region;
        this.seekingInvestment = seekingInvestment;
        this.hiring = hiring;
        this.boothName = boothName;
    }
}
