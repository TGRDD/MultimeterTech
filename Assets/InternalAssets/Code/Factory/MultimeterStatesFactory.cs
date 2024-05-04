public class MultimeterStatesFactory
{
    public IMultimeterState GetMultimeterState(MultimeterStateType type)
    {
        switch (type)
        {
            case MultimeterStateType.Resistance:
                return new ResistanceMultimeterState();

            case MultimeterStateType.Voltage:
                return new VoltageMultimeterState();

            case MultimeterStateType.ACVoltage:
                return new ACVoltageMultimeterState();

            case MultimeterStateType.DCVoltage:
                return new DCVoltageMultimeterState();

            default: return new DisabledMultimeterState();
        }
    }
}

public enum MultimeterStateType
{
    Disabled,
    Resistance,
    Voltage,
    DCVoltage,
    ACVoltage
}
