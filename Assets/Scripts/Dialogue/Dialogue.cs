using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public static string DEFAULT_FIRST_INTERACTION_TEXT = "talk";

    [SerializeField]
    private GameObject firstPanel;

    [Space(10)]

    [SerializeField]
    private GameObject firstPanelFirst;
    [SerializeField]
    private GameObject firstPanelSecond;
    [SerializeField]
    private GameObject firstPanelThird;
    [SerializeField]
    private GameObject firstPanelFourth;

    private GameObject[] firstPanelPanels;

    [Space(20)]

    [SerializeField]
    private GameObject secondPanel;

    [Space(10)]

    [SerializeField]
    private GameObject secondPanelTop;
    [SerializeField]
    private GameObject secondPanelBot;

    [Space(20)]

    [SerializeField]
    private BaseText baseText;

    private bool inRadius;

    private bool initiallyEnteredRadius;

    private int currentDialogueIndex;

    private ResponseWindow firstInteractionWindow;

    public static int NOT_IN_DIALOGUE_INDEX = -1;

    private void Start()
    {
        inRadius = false;

        FullClearAll();

        firstPanel.SetActive(false);
        secondPanel.SetActive(false);

        currentDialogueIndex = NOT_IN_DIALOGUE_INDEX;

        firstInteractionWindow = ResponseWindow.CreateResponseWindowWithCustomContinueOption("", 0, DEFAULT_FIRST_INTERACTION_TEXT);
        firstPanelPanels = new GameObject[] { firstPanelFourth, firstPanelThird, firstPanelSecond, firstPanelFirst };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            inRadius = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            inRadius = false;
        }
    }


    void Update()
    {
        if (!inRadius)
        {
            currentDialogueIndex = NOT_IN_DIALOGUE_INDEX;
            FullClearAll();
            initiallyEnteredRadius = false;
            return;
        } else if(!initiallyEnteredRadius)
        {
            Draw();
            initiallyEnteredRadius = true;
        }

        List<Transition> transitions = GetCurrentDialogueWindow().GetTransitions();
        foreach (Transition transition in transitions)
        {
            if(KeyEnumMethods.GetKeyPressed(transition.GetKeyEnum())) {
                ChangeCurrentDialogueIndex(transition.GetGoTo());
                return;
            }
        }
        
    }

    private void ChangeCurrentDialogueIndex(int newIndex)
    {
        currentDialogueIndex = newIndex;
        Draw();
    }

    private SingleDialogueWindow GetCurrentDialogueWindow()
    {
        if (currentDialogueIndex == NOT_IN_DIALOGUE_INDEX)
        {
            return firstInteractionWindow;
        }
        else
        {
            return baseText.GetDialogs()[currentDialogueIndex];
        }
    }


    private void Draw()
    {
        SingleDialogueWindow currentDialogueWindow = GetCurrentDialogueWindow();

        if (currentDialogueWindow.GetType() == typeof(MultiChoiceWindow))
        {
            DrawMultiChoiceWindow((MultiChoiceWindow)currentDialogueWindow);
        }
        else
        {
            DrawResponseWindow((ResponseWindow)currentDialogueWindow);
        }
    }


    // 1 above lowest
    private void DrawMultiChoiceWindow(MultiChoiceWindow multiChoiceWindow)
    {
        FullClearAll();
        firstPanel.SetActive(true);
        secondPanel.SetActive(false);

        List<MultiChoicePanel> multiChoicePanels = multiChoiceWindow.GetChoices();

        for (int i = 0, max = multiChoicePanels.Count; i < max; ++i)
        {
            SetTextOnPanelWithKeyButton(firstPanelPanels[i], KeyEnumMethods.GetStringFromKey(multiChoicePanels[i].key), multiChoicePanels[i].text);
        }
    }


    // 1 above lowest
    private void DrawResponseWindow(ResponseWindow responseWindow)
    {
        FullClearAll();
        firstPanel.SetActive(false);
        secondPanel.SetActive(true);

        SetTextOnTextOnlyPanel(responseWindow.GetTopText());
        MultiChoicePanel multiChoicePanel = responseWindow.GetBottomPanel();
        SetTextOnPanelWithKeyButton(secondPanelBot, KeyEnumMethods.GetStringFromKey(multiChoicePanel.key), multiChoicePanel.text);
    }

    //lowest level
    private void FullClearAll()
    {
        SetTextOnTextOnlyPanel("", false);
        SetTextOnPanelWithKeyButton(firstPanelFirst, "", "", false);
        SetTextOnPanelWithKeyButton(firstPanelSecond, "", "", false);
        SetTextOnPanelWithKeyButton(firstPanelThird, "", "", false);
        SetTextOnPanelWithKeyButton(firstPanelFourth, "", "", false);
        SetTextOnPanelWithKeyButton(secondPanelBot, "", "", false);
    }

    //lowest level
    private void SetTextOnPanelWithKeyButton(GameObject panel, string key, string text, bool enable = true)
    {
        panel.SetActive(enable);
        panel.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = key;
        panel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = text;
        if(text != "")
        {
            FadePanelIn(panel);
        }
    }

    //lowest level
    private void SetTextOnTextOnlyPanel(string text, bool enable = true)
    {
        secondPanelTop.SetActive(enable);
        secondPanelTop.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        if (text != "")
        {
            FadePanelIn(secondPanelTop);
        }  
    }

    private void FadePanelIn(GameObject panel)
    {
        UIManager.instance.FadeIn(panel);
    }

}