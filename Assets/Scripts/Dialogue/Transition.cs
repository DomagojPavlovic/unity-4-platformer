using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    private readonly KeyEnum key;
    private readonly int goTo;

    public Transition(KeyEnum key, int goTo)
    {
        this.key = key;
        this.goTo = goTo;
    }

    public KeyEnum GetKeyEnum()
    {
        return key;
    }

    public int GetGoTo()
    {
        return goTo;
    }
}
