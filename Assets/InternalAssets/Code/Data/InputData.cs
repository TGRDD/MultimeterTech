using System;
using UnityEngine;
[Serializable]
public class InputData
{
    [SerializeField] private float Resistance;
    [SerializeField] private float Power;

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
