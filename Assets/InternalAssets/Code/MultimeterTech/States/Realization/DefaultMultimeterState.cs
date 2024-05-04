public class DefaultMultimeterState : IMultimeterState
{
    private const string _displayString = "0";

    public OutputData Calculate()
    {
        return new OutputData();
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
        return _displayString;
    }
}
