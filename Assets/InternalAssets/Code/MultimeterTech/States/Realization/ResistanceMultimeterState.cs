public class ResistanceMultimeterState : IMultimeterState
{
    private InputData _data;
    public OutputData Calculate()
    {
        OutputData output = new OutputData(0, 0, _data.R, 0, 0, 0);
        output.SetDisplayOutput(_data.R.ToString());
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
