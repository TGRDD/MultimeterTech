using TMPro;
using UnityEngine;

public class DisplayViewSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _displayText;

    private void OnEnable() => MultimeterStateController.OnDisplayResult += UpdateView;
    private void OnDisable() => MultimeterStateController.OnDisplayResult -= UpdateView;

    public void UpdateView(string ToDisplay)
    {
        if (_displayText != null)
        _displayText.text = ToDisplay;
    }
}
