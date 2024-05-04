using System;

public class DCVoltageMultimeterState : IMultimeterState
{
    private InputData _data;
    private float _calculation;
    private bool _calcCompleted = false;
    public OutputData Calculate()
    {
        _calculation = MathF.Sqrt(_data.P * _data.R);
        _calcCompleted = true;

        OutputData output = new OutputData(0, 0, 0, 0, 0, _calculation);
        output.SetDisplayOutput(_calculation.ToString());
        return output;
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
