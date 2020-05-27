using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{

    /// <summary>
    /// Open character selector
    /// </summary>
    public void openCharacterMenu()
    {
        MenuManager.switchToMenu(3);
    }

}
