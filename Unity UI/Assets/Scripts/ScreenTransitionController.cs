using UnityEngine;

public class ScreenTransitionController : MonoBehaviour
{
    public Animator uiTransitionAnimator;

    public void ShowScreen(string screenBoolName)
    {
        ResetAllScreenBools();
        uiTransitionAnimator.SetBool(screenBoolName, true);
    }

    private void ResetAllScreenBools()
    {
        uiTransitionAnimator.SetBool("isMainMenuVisible", false);
        uiTransitionAnimator.SetBool("isSettingsVisible", false);
        uiTransitionAnimator.SetBool("isUnityPageVisible", false);
    }
}
