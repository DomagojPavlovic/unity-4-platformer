using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UIManager : Manager<UIManager>
{
    [SerializeField]
    private GameObject notificationPanel;

    private readonly List<GameObject> list = new();

    private static readonly float FADE_IN_TIME_SECONDS = 0.3f;

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

    public void FadeIn(GameObject gameObject)
    {
        list.Add(gameObject);
        gameObject.GetComponent<CanvasGroup>().alpha = 0;
    }

    private void Update()
    {
        foreach (GameObject go in list) {
            print("before: " + go.GetComponent<CanvasGroup>().alpha);
            go.GetComponent<CanvasGroup>().alpha += (Time.deltaTime / FADE_IN_TIME_SECONDS);
            print("after: " + go.GetComponent<CanvasGroup>().alpha);

        }
        list.RemoveAll(x => x.GetComponent<CanvasGroup>().alpha >= 1);
    }
}
