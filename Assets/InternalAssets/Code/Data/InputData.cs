public class InputData
{
    private float Resistance;
    private float Power;

    public float R => Resistance;
    public float P => Power;

    public InputData(float resistance, float power)
    {
        Resistance = resistance;
        Power = power;
    }

    public override string ToString()
    {
        return $"{this.GetType()}  " +
            $"Resistance [R] = {Resistance} " +
            $"Power [P] = {Power}";
    }
}
