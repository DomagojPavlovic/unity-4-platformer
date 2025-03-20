using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseText : MonoBehaviour
{
    private readonly List<SingleDialogueWindow> dialogs;

    protected BaseText()
    {
        dialogs = FillDialogsList();
    }

    public List<SingleDialogueWindow> GetDialogs()
    {
        return dialogs;
    }

    protected abstract List<SingleDialogueWindow> FillDialogsList();
}
