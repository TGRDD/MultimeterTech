public class ACVoltageMultimeterState : IMultimeterState
{
    public OutputData Calculate()
    {
        return new OutputData(0, 0, 0, 0, 0.01f, 0);
    }

    public void Enter(InputData inputData)
    {
        return;
    }

    public void Exit()
    {
        return;
    }

    public string ToDisplay()
    {
        return "0.01";
    }
}
