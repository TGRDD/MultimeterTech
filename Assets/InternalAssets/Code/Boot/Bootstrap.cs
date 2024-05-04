using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private MultimeterStateController MultimeterStateController;

    [SerializeField, Space(10f)] private InputData inputData;

    private void OnValidate()
    {
        MultimeterStateController ??= FindObjectOfType<MultimeterStateController>();
    }

    private void Awake()
    {
        MultimeterStateController.InizializeInput(inputData);
    }

}
