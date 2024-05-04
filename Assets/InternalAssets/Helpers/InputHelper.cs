using UnityEngine;

public static class InputHelper
{
    private const string _scrollWheelAxis = "Mouse ScrollWheel";
    private static float scrollAxis => Input.GetAxis(_scrollWheelAxis);
    public static bool TryGetInteractAction(out InteractAction action)
    {
        action = InteractAction.NoAction;

        if (Input.GetMouseButton(0)) { action = InteractAction.LeftClick; return true; }

        else if (scrollAxis > 0) { action = InteractAction.ScrollUp; return true; }

        else if (scrollAxis < 0) { action = InteractAction.ScrollDown; return true; }

        else { return false; }
    }
}
