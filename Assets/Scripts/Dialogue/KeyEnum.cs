using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum KeyEnum 
{
    one,
    two,
    three,
    f,
}

static class KeyEnumMethods
{
    public static bool GetKeyPressed(this KeyEnum key)
    {
        return key switch
        {
            KeyEnum.one => Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1),
            KeyEnum.two => Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2),
            KeyEnum.three => Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3),
            KeyEnum.f => Input.GetKeyDown(KeyCode.F),
            _ => false,
        };
    }

    public static string GetStringFromKey(this KeyEnum key)
    {
        return key switch
        {
            KeyEnum.one => "1",
            KeyEnum.two => "2",
            KeyEnum.three => "3",
            KeyEnum.f => "F",
            _ => "",
        };
    }
}
