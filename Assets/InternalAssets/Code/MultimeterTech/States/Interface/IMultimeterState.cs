public interface IMultimeterState
{
    public void Enter(InputData inputData);

    public OutputData Calculate();
    public void Exit();
}
