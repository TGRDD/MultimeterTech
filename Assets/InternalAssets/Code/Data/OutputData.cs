using Unity.VisualScripting;

public class OutputData
{
    private float Voltage;
    private float Amper;
    private float Resistance;
    private float Power;
    private float ACVoltage;
    private float DCVoltage;

    public float V => Voltage;
    public float A => Amper;
    public float R => Resistance;
    public float P => Power;
    public float D => DCVoltage;
    public float AC => ACVoltage;


    public OutputData(float voltage, float amper, float resistance, float power, float acVoltage, float dcVoltage)
    {
        Voltage = voltage;
        Amper = amper;
        Resistance = resistance;
        Power = power;
        ACVoltage = acVoltage;
        DCVoltage = dcVoltage;
    }

    public OutputData()
    {
        Voltage = 0;
        Amper = 0;
        Resistance = 0;
        Power = 0;
        ACVoltage = 0;
    }

    public override string ToString()
    {
        return $"{this.GetType()} " +
            $"Voltage [V] = {Voltage} " +
            $"Amper [A] = {Amper} " +
            $"Resistance [R] = {Resistance} " +
            $"Power [P] = {Power} " +
            $"AC Voltage [AC] = {ACVoltage}" +
            $"DC VOLTAGE [DC] = {DCVoltage}";
    }

}
