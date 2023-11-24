using UnityEngine;
using UnityEngine.SceneManagement;

public class SecurityLevelWinLoseUI : MonoBehaviour 
{
    [SerializeField] Canvas levelFailedUI;
    [SerializeField] Canvas levelFinishedUI;

    [SerializeField] DecisionButton passButton;
    [SerializeField] DecisionButton dontPassButton;

    private void Awake() 
    {
        FindObjectOfType<LineManager>().OnLevelFinished += OpenSuccessCanvas;
        passButton.OnFalseDecisionMade += OpenFailedUI;   
        dontPassButton.OnFalseDecisionMade += OpenFailedUI;
    }

    private void OpenFailedUI()
    {
        Time.timeScale = 0;
        levelFailedUI.enabled = true;
    }

    private void OpenSuccessCanvas()
    {
        Time.timeScale = 0;
        levelFinishedUI.enabled = true;
    }


}