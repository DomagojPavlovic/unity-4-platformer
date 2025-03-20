using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiChoicePanel
{
    public KeyEnum key;
    public string text;

    public MultiChoicePanel(KeyEnum key, string text)
    {
        this.key = key;
        this.text = text;
    }
}
