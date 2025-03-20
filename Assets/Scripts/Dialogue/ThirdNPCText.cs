using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdNPCText : BaseText
{
    public static string D0_1 = "Isn't this supposed to be an easter egg?";

    public static string D1 = "There are no easter eggs here, go away.";

    protected override List<SingleDialogueWindow> FillDialogsList()
    {
        List<SingleDialogueWindow> output = new()
        {
            MultiChoiceWindow.CreateMultiChoiceWindowWithDefaultReturnOption(
                Dialogue.NOT_IN_DIALOGUE_INDEX,
                new Tuple<string, int>(D0_1, 1)
                ),
            
            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D1, Dialogue.NOT_IN_DIALOGUE_INDEX
                ),

        };
        return output;
    }
}
