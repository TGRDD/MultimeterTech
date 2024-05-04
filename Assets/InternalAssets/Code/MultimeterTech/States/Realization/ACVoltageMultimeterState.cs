public class ACVoltageMultimeterState : IMultimeterState
{
    private const float constACVoltage = 0.01f;
    public OutputData Calculate()
    {
        OutputData output = new OutputData(0, 0, 0, 0, constACVoltage, 0);
        output.SetDisplayOutput(constACVoltage.ToString());
        return output;
        
    }

    public void Enter(InputData inputData)
    {
        return;
    }

    public void Exit()
    {
        return;
    }
}
