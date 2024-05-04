using UnityEngine;

public class OutputViewCanvas : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _outputText;

    private void OnEnable() => MultimeterStateController.OnCalculateResult += UpdateView;
    private void OnDisable() => MultimeterStateController.OnCalculateResult -= UpdateView;

    private void Start()
    {
        UpdateView(new OutputData());
    }

    public void UpdateView(OutputData dataToDisplay)
    {
        _outputText.text = dataToDisplay.ToString();
    }
}
