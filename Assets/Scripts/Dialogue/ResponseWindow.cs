using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseWindow : SingleDialogueWindow
{
    public static string DEFAULT_CONTINUE_OPTION_TEXT = "continue...";

    private readonly string topText;
    private readonly MultiChoicePanel bottomPanel;

    public ResponseWindow(string topText, MultiChoicePanel bottomPanel, List<Transition> transitions)
    {
        this.topText = topText;
        this.bottomPanel = bottomPanel;
        this.transitions = transitions;
    }

    public static ResponseWindow CreateResponseWindowWithDefaultContinueOption(string reponseText, int goTo)
    {
        return CreateResponseWindowWithCustomContinueOption(reponseText, goTo, DEFAULT_CONTINUE_OPTION_TEXT);
    }

    public static ResponseWindow CreateResponseWindowWithCustomContinueOption(string reponseText, int goTo, string continueText)
    {
        string topText = reponseText;
        MultiChoicePanel bottomPanel = new(KeyEnum.f, continueText);
        List<Transition> transitions = new() { new(KeyEnum.f, goTo) };
        return new(topText, bottomPanel, transitions);
    }

    public string GetTopText()
    {
        return topText;
    }

    public MultiChoicePanel GetBottomPanel()
    {
        return bottomPanel;
    }

}
