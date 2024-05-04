public class DisabledMultimeterState : IMultimeterState
{
    private const string _displayString = "0";

    public OutputData Calculate()
    {
        OutputData output = new OutputData();
        output.SetDisplayOutput(_displayString);
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
