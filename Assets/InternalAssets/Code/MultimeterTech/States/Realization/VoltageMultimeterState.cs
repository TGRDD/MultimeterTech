using System;

public class VoltageMultimeterState : IMultimeterState
{
    private InputData _data;
    private float _calculation;
    private bool _calcCompleted = false;
    public OutputData Calculate()
    {
        _calculation = MathF.Sqrt(_data.P / _data.R);
        _calcCompleted = true;
        return new OutputData(_calculation, 0, 0, 0, 0, 0);
    }

    public void Enter(InputData inputData)
    {
        _data = inputData;
    }

    public void Exit()
    {
        _calcCompleted = false;
        return;
    }

    public string ToDisplay()
    {
        if (_calcCompleted) return _calculation.ToString();
        else return "ERROR";
    }
}
