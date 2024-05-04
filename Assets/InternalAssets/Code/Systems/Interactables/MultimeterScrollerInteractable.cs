using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Transform))]
public class MultimeterScrollerInteractable : MonoBehaviour, IInteractable
{
    public static event Action<int> OnScrollStateChanged;
    public UnityEvent OnInteract;
    public UnityEvent OnInteractionLeft;
    public UnityEvent OnSwitchSucces;

    [SerializeField] private int _currentScrollState;

    [Space(20f)]

    [SerializeField] private Transform _scrollObjectTransform;
    [SerializeField] private float[] _scrollStatesZrotationArray;

    private int _maxScrollPosition => _scrollStatesZrotationArray.Length - 1;
    private Vector3 _currentRotation => _scrollObjectTransform.rotation.eulerAngles;
    private bool _clockwiseRotation;
    private bool isRotating;

    private void OnValidate()
    {
        _scrollObjectTransform ??= GetComponent<Transform>();
    }

    public void Interact(InteractAction action)
    {
        OnInteract?.Invoke();

        if (isRotating) { return; }
        switch (action)
        {
            case InteractAction.ScrollUp: _currentScrollState++; break;
            case InteractAction.ScrollDown: _currentScrollState--; break;

            default: return;
        }

        ClampIfOutOfRange();

        _clockwiseRotation = action == InteractAction.ScrollUp ? true : false;
        RotateScrollObject();

        OnSwitchSucces?.Invoke();
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
        StartCoroutine(RotateObjectCoroutine(_scrollStatesZrotationArray[_currentScrollState]));
    }

    System.Collections.IEnumerator RotateObjectCoroutine(float targetZ)
    {
        isRotating = true;
        float currentRotation = _currentRotation.z;

        for (int i = 0; i <= 10; i++)
        {

            currentRotation = Mathf.Lerp(currentRotation, targetZ, 0.5f);
            transform.rotation = Quaternion.Euler(_currentRotation.x, _currentRotation.y, currentRotation);
            yield return new WaitForEndOfFrame();
        }

        transform.rotation = Quaternion.Euler(_currentRotation.x, _currentRotation.y, targetZ);
        isRotating = false;

        OnScrollStateChanged?.Invoke(_currentScrollState);
    }
}
