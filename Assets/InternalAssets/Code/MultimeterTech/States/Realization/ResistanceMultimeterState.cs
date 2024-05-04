using System;

public class ResistanceMultimeterState : IMultimeterState
{
    private InputData _data;
    public OutputData Calculate()
    {
        float result = MathF.Round(_data.R, 2);
        OutputData output = new OutputData(0, 0, result, 0, 0, 0);
        output.SetDisplayOutput(result.ToString());
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
