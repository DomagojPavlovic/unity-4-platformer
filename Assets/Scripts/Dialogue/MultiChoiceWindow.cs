using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiChoiceWindow : SingleDialogueWindow
{
    public static string DEFAULT_RETURN_OPTION_TEXT = "nevermind...";

    private List<MultiChoicePanel> choices;

    private MultiChoiceWindow(List<MultiChoicePanel> choices, List<Transition> transitions)
    {
        this.choices = choices;
        this.transitions = transitions;
    }

    public static MultiChoiceWindow CreateMultiChoiceWindowWithDefaultReturnOption(int returnGoTo, params Tuple<string, int>[] optionsAndGoTos)
    {
        List<MultiChoicePanel> choices = new();
        List<Transition> transitions = new();

        for (int i = 0, max = optionsAndGoTos.Length; i < max; ++i)
        {
            choices.Add(new((KeyEnum) i, optionsAndGoTos[i].Item1));
            transitions.Add(new((KeyEnum)i, optionsAndGoTos[i].Item2));
        }

        choices.Add(new(KeyEnum.f, DEFAULT_RETURN_OPTION_TEXT));
        transitions.Add(new(KeyEnum.f, returnGoTo));

        choices.Reverse();

        return new(choices, transitions);
    }

    public List<MultiChoicePanel> GetChoices()
    {
        return choices;
    }
}


