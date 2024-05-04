using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Transform))]
public class MultimeterScrollerInteractable : MonoBehaviour, IInteractable
{
    public static event Action<int> OnScrollStateChanged;
    public UnityEvent OnInteract;
    public UnityEvent OnInteractionLeft;

    [SerializeField] private int _currentScrollState;

    [Space(20f)]

    [SerializeField] private Transform _scrollObjectTransform;
    [SerializeField] private float[] _scrollStatesZrotationArray;

    private int _maxScrollPosition => _scrollStatesZrotationArray.Length - 1;
    private Vector3 _currentRotation => _scrollObjectTransform.rotation.eulerAngles;
    private void OnValidate()
    {
        _scrollObjectTransform ??= GetComponent<Transform>();

        if (_scrollStatesZrotationArray.Length > 0)
        {
            ClampIfOutOfRange();
            RotateScrollObject();
        }
    }

    public void Interact(InteractAction action)
    {
        OnInteract?.Invoke();
        switch (action)
        {
            case InteractAction.ScrollUp: _currentScrollState++; break;
            case InteractAction.ScrollDown: _currentScrollState--; break;

            default: return;
        }

        ClampIfOutOfRange();
        RotateScrollObject();

        OnScrollStateChanged?.Invoke(_currentScrollState);
    }

    public void LeaveInteraction()
    {
        OnInteractionLeft?.Invoke();
    }


    private void ClampIfOutOfRange()
    {
        if (_currentScrollState < 0) _currentScrollState = _maxScrollPosition;
        else if (_currentScrollState > _maxScrollPosition) _currentScrollState = 0;
    }

    private void RotateScrollObject()
    {
        Vector3 newRotation = _currentRotation;
        newRotation.z = _scrollStatesZrotationArray[_currentScrollState];
        _scrollObjectTransform.rotation = Quaternion.Euler(newRotation);
    }
}
