using System;
using UnityEngine;

public class MultimeterStateController : MonoBehaviour
{
    public static event Action<OutputData> OnCalculateResult;
    public static event Action<string> OnDisplayResult;

    private IMultimeterState _currentState = new DisabledMultimeterState();
    private InputData _inputData;

    public bool ShowLogs = false;

    public void InizializeInput(InputData data)
    {
        _inputData = data;
    }

    public void ChangeState(IMultimeterState state)
    {
        Debug.Log(state.ToString());

        if (_inputData == null)
        {
            Debug.LogError($"ERROR {this} - No InputData");
            return;
        }

        if (_currentState != null)
            _currentState.Exit();

        _currentState = state;

        _currentState.Enter(_inputData);

        Execute();

    }
    public void Execute()
    {
        OutputData resultData = _currentState.Calculate();
        OnCalculateResult?.Invoke(resultData);
        OnDisplayResult?.Invoke(resultData.ToDisplay);

        if (ShowLogs)
        {
            Debug.Log(resultData.ToString());
            Debug.Log(resultData.ToDisplay);
        }

    }
}
