using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondNPCText : BaseText
{
    public static string D0_1 = "What happened just now?";

    public static string D1 = "You just collected a checkpoint...";

    public static string D2 = "So when you inevitably die you will continue from here!";

    protected override List<SingleDialogueWindow> FillDialogsList()
    {
        List<SingleDialogueWindow> output = new()
        {
            MultiChoiceWindow.CreateMultiChoiceWindowWithDefaultReturnOption(
                Dialogue.NOT_IN_DIALOGUE_INDEX,
                new Tuple<string, int>(D0_1, 1)
                ),

            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D1, 2         
                ),
            
            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D2, Dialogue.NOT_IN_DIALOGUE_INDEX
                ),


        };
        return output;
    }
}
