using UnityEngine;

[RequireComponent(typeof(MultimeterStateController))]
public class MultimeterSwitchStateSystem : MonoBehaviour
{
    [SerializeField, HideInInspector] private MultimeterStateController controller;

    private IMultimeterState disabledState;
    private IMultimeterState resistanceState;
    private IMultimeterState voltageState;
    private IMultimeterState acVoltageState;
    private IMultimeterState dcVoltageState;

    private void OnValidate()
    {
        controller ??= GetComponent<MultimeterStateController>();
    }

    private void OnEnable() => MultimeterScrollerInteractable.OnScrollStateChanged += SwitchState;
    private void OnDisable() => MultimeterScrollerInteractable.OnScrollStateChanged -= SwitchState;

    public void Start() //TODO: Change to boot
    {
        GenerateStates();
    }

    private void GenerateStates()
    {
        MultimeterStatesFactory factory = new MultimeterStatesFactory();

        disabledState = factory.GetMultimeterState(MultimeterStateType.Disabled);
        resistanceState = factory.GetMultimeterState(MultimeterStateType.Resistance);
        voltageState = factory.GetMultimeterState(MultimeterStateType.Voltage);
        acVoltageState = factory.GetMultimeterState(MultimeterStateType.ACVoltage);
        dcVoltageState = factory.GetMultimeterState(MultimeterStateType.DCVoltage);
    }

    public void SwitchState(int state)
    {
        switch (state)
        {
            case 0:
                { controller.ChangeState(disabledState); break; }
            case 1:
                { controller.ChangeState(voltageState); break; }
            case 2:
                { controller.ChangeState(acVoltageState); break; }
            case 3:
                { controller.ChangeState(dcVoltageState); break; }
            case 4: { controller.ChangeState(resistanceState); break; }
        }
    }
}