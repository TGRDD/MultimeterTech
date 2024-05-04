public class ResistanceMultimeterState : IMultimeterState
{
    private InputData _data;
    public OutputData Calculate()
    {
        return new OutputData(0, 0, _data.R, 0, 0, 0);
    }

    public void Enter(InputData inputData)
    {
        _data = inputData;
    }

    public void Exit()
    {
        return;
    }

    public string ToDisplay()
    {
        return _data.R.ToString();
    }
}
