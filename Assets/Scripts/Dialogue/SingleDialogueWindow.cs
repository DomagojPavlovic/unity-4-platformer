using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleDialogueWindow
{
    protected List<Transition> transitions;

    public List<Transition> GetTransitions() {  
        return transitions; 
    }

}
