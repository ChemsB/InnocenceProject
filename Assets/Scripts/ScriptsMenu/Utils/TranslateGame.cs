using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslateGame : MonoBehaviour
{
    //This code recives all texts P: play Menu, O: OptionMenu, C: references CharacterMenu
    //Montar servei web restfull que retorne datos



    public TextMeshProUGUI PPlayText;
    public TextMeshProUGUI POptionsText;
    public TextMeshProUGUI PQuitText;

    public TextMeshProUGUI OTextNick;
    public TextMeshProUGUI OLenguageText;
    public TextMeshProUGUI OSongText;
    public TextMeshProUGUI OBack;
    public TextMeshProUGUI OApply;
    public TextMeshProUGUI ORestore;

    public TextMeshProUGUI CHealth;
    public TextMeshProUGUI CSpeed;
    public TextMeshProUGUI CBack;

    public TextMeshProUGUI CControls;
    public TextMeshProUGUI CPlayGame;

    public TextMeshProUGUI CcontrTextControls;
    public TextMeshProUGUI CcontrBack;
    public TextMeshProUGUI CcontrSapce;

    /// <summary>
    /// Translate in english
    /// </summary>
    public void english()
    {


        PPlayText.text = "Game";
        POptionsText.text = "Options";
        PQuitText.text = "Quit";


        OTextNick.text="Nick: ";
        OLenguageText.text = "Lenguage: ";
        OSongText.text = "Song: ";
        OBack.text = "Back";
        OApply.text = "Apply";
        ORestore.text = "Restore";


        CHealth.text = "Health: ";
        CSpeed.text = "Speed: ";
        CBack.text = "Back";

        CControls.text="Controls";
        CPlayGame.text="Play Game";

        CcontrTextControls.text="Controls";
        CcontrBack.text="Back";
        CcontrSapce.text="Active Dialog";


}


    /// <summary>
    /// Translate in spanish
    /// </summary>
    public void spanish()
    {
        PPlayText.text = "Jugar";
        POptionsText.text = "Opciones";
        PQuitText.text = "Salir";

        OTextNick.text = "Nick: ";
        OLenguageText.text = "Lenguaje: ";
        OSongText.text = "Canción: ";
        OBack.text = "Volver";
        OApply.text = "Aplicar";
        ORestore.text = "Restaurar";


        CHealth.text = "Vida: ";
        CSpeed.text = "Velocidad: ";
        CBack.text = "Volver";

        CControls.text = "Controles";
        CPlayGame.text = "Jugar";

        CcontrTextControls.text = "Controles";
        CcontrBack.text = "Volver";
        CcontrSapce.text = "Activar Dialogo";


    }


}
