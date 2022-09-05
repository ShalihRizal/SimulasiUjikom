using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSet : MonoBehaviour
{
    public void SetTheme(string themeName)
    {
        PlayerPrefs.SetString("Theme", themeName);
    }
}
