using System;
using UnityEngine;

public class MultimeterStateController : MonoBehaviour
{
    public static event Action<OutputData> OnCalculateResult;
    public static event Action<string> OnDisplayResult;

    private IMultimeterState _currentState = new DefaultMultimeterState();
    private InputData _inputData;

    public void InizializeInput(InputData data)
    {
        _inputData = data;
    }

    public void ChangeState(IMultimeterState state)
    {
        if (_currentState != null)

        _currentState.Exit();

        _currentState = state;

        _currentState.Enter(_inputData);

        Execute();
    }

    public void Execute()
    {
        OnCalculateResult?.Invoke(_currentState.Calculate());
        OnDisplayResult?.Invoke(_currentState.ToDisplay());
    }
}
