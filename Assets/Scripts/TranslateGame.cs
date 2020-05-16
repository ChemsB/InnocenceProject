using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslateGame : MonoBehaviour
{

    public TextMeshProUGUI PPlayText;
    public TextMeshProUGUI POptionsText;
    public TextMeshProUGUI PQuitText;


    public TextMeshProUGUI OTextNick;
    public TextMeshProUGUI OLenguageText;
    public TextMeshProUGUI OBloodText;
    public TextMeshProUGUI OSongText;
    public TextMeshProUGUI OBack;
    public TextMeshProUGUI OApply;
    public TextMeshProUGUI ORestore;


    public TextMeshProUGUI CReload;
    public TextMeshProUGUI CCapacity;
    public TextMeshProUGUI CHealth;
    public TextMeshProUGUI CSpeed;
    public TextMeshProUGUI CBack;





    public void english()
    {


        PPlayText.text = "Game";
        POptionsText.text = "Options";
        PQuitText.text = "Quit";



        OTextNick.text="Nick";
        OLenguageText.text = "Lenguage";
        OBloodText.text = "Blood";
        OSongText.text = "Song";
        OBack.text = "Back";
        OApply.text = "Apply";
        ORestore.text = "Restore";


        CReload.text = "Reload: ";
        CCapacity.text = "Capacity: ";
        CHealth.text = "Health: ";
        CSpeed.text = "Speed: ";
        CBack.text = "Back";

    }



    public void spanish()
    {
        PPlayText.text = "Jugar";
        POptionsText.text = "Opciones";
        PQuitText.text = "Salir";

        OTextNick.text = "Nick";
        OLenguageText.text = "Lenguaje";
        OBloodText.text = "Sangre";
        OSongText.text = "Canción";
        OBack.text = "Volver";
        OApply.text = "Aplicar";
        ORestore.text = "Restaurar";


        CReload.text = "Recarga: ";
        CCapacity.text = "Munición: ";
        CHealth.text = "Vida: ";
        CSpeed.text = "Velocidad: ";
        CBack.text = "Volver";
    }


}
