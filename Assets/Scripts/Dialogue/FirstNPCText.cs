using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstNPCText : BaseText
{
    public static string D0_1 = "Tell me about the controls.";
    public static string D0_2 = "Tell me about the dangers.";
    public static string D0_3 = "Who are you?";

    public static string D1_1 = "How do I move?";
    public static string D1_2 = "How do I jump?";

    public static string D2 = "Use A to move left and D to move right.";

    public static string D3 = "Use SPACE to jump.";

    //unused
    public static string D4 = "Press T to restart the game.";

    public static string D5_1 = "How much health do I have?";
    public static string D5_2 = "Tell me about the enemies.";
    public static string D5_3 = "Tell me about environmental hazards.";

    public static string D6 = "You only have 1HP!";

    public static string D7 = "You can kill enemies by jumping on them.";

    public static string D8 = "But be careful, some of them can shoot you!";

    public static string D9 = "Beware of spikes and jets of flame!";

    public static string D10 = "You can also double jump!";

    public static string D11 = "It does not matter who we are...";

    public static string D12 = "What matters is our plan...";

    public static string D13_1 = "What?";
    public static string D13_2 = "Pepepains";

    public static string D14 = "...";

    public static string D15 = "The fire rises...";

    public static string D16 = "So be extra careful!";


    protected override List<SingleDialogueWindow> FillDialogsList()
    {
        List<SingleDialogueWindow> output = new()
        {
            MultiChoiceWindow.CreateMultiChoiceWindowWithDefaultReturnOption(
                Dialogue.NOT_IN_DIALOGUE_INDEX, 
                new(D0_1, 1),
                new(D0_2, 5),
                new(D0_3, 11)
                ),

            MultiChoiceWindow.CreateMultiChoiceWindowWithDefaultReturnOption(
                0,
                new(D1_1, 2),
                new(D1_2, 3)
                ),

            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D2, 1         
                ),

            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D3, 10
                ),

            //unused
            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D4, 1
                ),

            MultiChoiceWindow.CreateMultiChoiceWindowWithDefaultReturnOption(
                0,
                new(D5_1, 6),
                new(D5_2, 7),
                new(D5_3, 9)
                ),

            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D6, 16
                ),

            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D7, 8
                ),

            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D8, 5
                ),

            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D9, 5
                ),

            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D10, 1
                ),

            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D11, 12
                ),

            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D12, 13
                ),

            MultiChoiceWindow.CreateMultiChoiceWindowWithDefaultReturnOption(
                0,
                new(D13_1, 14),
                new(D13_2, 15)
                ),

            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D14, 0
                ),

            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D15, 0
                ),

            ResponseWindow.CreateResponseWindowWithDefaultContinueOption(
                D16, 5
                ),

        };
        return output;
    }
}
