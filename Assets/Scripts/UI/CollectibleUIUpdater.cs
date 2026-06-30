using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CollectibleUIUpdater : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        textMeshPro = GetComponentInParent<TextMeshProUGUI>();
    }

    private void Start()
    {
        UpdateUICaller(null);
    }

    private void OnEnable()
    {
        Events.OnCollectibleCollected += UpdateUICaller;
    }

    private void OnDisable()
    {
        Events.OnCollectibleCollected -= UpdateUICaller;
    }

    private void UpdateUICaller(string _)
    {
        StartCoroutine(UpdateUI());
    }

    IEnumerator UpdateUI()
    {
        yield return null;

        var tracker = CollectibleTracker.Instance;

        var groupData = tracker.GroupData;

        if (groupData.Count <= 0)
        {
            textMeshPro.text = "";
            yield break;
        }
        
        int allCurrent = 0;
        int allMax = 0;
        
        string outputText = "";
        int currentIndex = 0;
        
        foreach (var kvp in groupData)
        {
            string group = kvp.Key;

            var collectible = kvp.Value;

            string displayName = collectible.displayName;
            int maxCount = collectible.totalAmountOfThisGroup;
            int currentCount = tracker.GetCount(group);
            
            allCurrent += currentCount;
            allMax += maxCount;

            outputText += $"{displayName}: {currentCount}/{maxCount}";
            
            if (currentIndex < groupData.Count - 1)
            {
                outputText += ", ";
            }
            currentIndex++;
        }

        string prefix = $"All: {allCurrent}/{allMax}, ";

        textMeshPro.text = prefix + outputText;
    }
}