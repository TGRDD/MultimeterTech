using System.Collections.Generic;
using UnityEngine;

public class RaycastInteract : MonoBehaviour
{
    [SerializeField] private Camera _originCamera;

    private Vector3 _gizmoHitPosition = Vector3.zero;
    private Ray _chachedDirectRay;

    private IInteractable _currentInteractable = null;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_gizmoHitPosition, 0.3f);
    }


    private void OnValidate()
    {
        _originCamera ??= Camera.main;
    }

    private void Update()
    {
        _chachedDirectRay = _originCamera.ScreenPointToRay(Input.mousePosition);

        

        if (Physics.Raycast(_chachedDirectRay, out RaycastHit hit) && hit.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            Debug.DrawRay(_chachedDirectRay.origin, _chachedDirectRay.direction * Vector3.Distance(_chachedDirectRay.origin, _chachedDirectRay.direction), Color.yellow);
            _gizmoHitPosition = hit.point;

            InputHelper.TryGetInteractAction(out InteractAction action);

            _currentInteractable = interactable;
            interactable.Interact(action);
            
        }
        else
        {
            if (_currentInteractable != null)
            {
                _currentInteractable.LeaveInteraction();
                _currentInteractable = null;
            }
        }
        
    }
}

