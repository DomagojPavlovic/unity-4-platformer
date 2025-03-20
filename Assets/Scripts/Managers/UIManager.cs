using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : Manager<UIManager>
{
    [SerializeField]
    private GameObject notificationPanel;

    private void Start()
    {
        notificationPanel.SetActive(false);
    }


    public void ShowNotification(string text, float duration)
    {
        notificationPanel.GetComponentInChildren<TextMeshProUGUI>().text = text;
        TurnOnPanelForDuration(notificationPanel, duration);
    }


    private void TurnOnPanelForDuration(GameObject panel, float duration)
    {
        panel.SetActive(true);

        StartCoroutine(TurnOffPanel(panel, duration));
    }

    private IEnumerator TurnOffPanel(GameObject panel, float duration)
    {
        yield return new WaitForSeconds(duration);

        panel.SetActive(false);
    }
}
