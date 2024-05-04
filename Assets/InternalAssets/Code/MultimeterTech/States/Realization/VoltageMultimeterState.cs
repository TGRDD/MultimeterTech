using System;

public class VoltageMultimeterState : IMultimeterState
{
    private InputData _data;
    private float _calculation;

    public OutputData Calculate()
    {
        _calculation = MathF.Sqrt(_data.P / _data.R);
        _calculation = MathF.Round(_calculation, 2);
        OutputData output = new OutputData(_calculation, 0, 0, 0, 0, 0);
        output.SetDisplayOutput(_calculation.ToString());
        return output;
    }

    public void Enter(InputData inputData)
    {
        _data = inputData;
    }

    public void Exit()
    {
        return;
    }
}
