using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/**
 * Data picker
 */
public class DataPicker : MonoBehaviour
{

    /**
     * This code manages birthDate
     * Increase or decrease values
     */

    private int day, month, year;
    //public TextMeshProUGUI dayText, monthText, yearText;
    private GameObject dayText, monthText,yearText;
    void Start()
    {
        dayText = GameObject.Find("Day");
        monthText = GameObject.Find("Month");
        yearText = GameObject.Find("Year");
        
        day = 1;
        month = 1;
        year = 1940;

    }


    //Increase Day
    public void upDay()
    {
        day++;

        if (month == 2 && day > 28)
        {
            day = 1;
        }else if((month==4 || month==6 ||month== 9 || month == 11 )&& day>30)
        {
            day = 1;
        }
        else if((month == 1 || month == 3 || month == 5 || month == 7 || month==8 || month==10 || month==12 ) && day > 31)
        {
            day = 1;
        }

        dayText.GetComponent<TextMeshProUGUI>().text = day.ToString();

    }


    //Decrease Day
    public void lessDay()
    {
        day--;

        if (day < 1)
        {
            day = 1;
        }
        dayText.GetComponent<TextMeshProUGUI>().text = day.ToString();


    }


    //Increase Month
    public void upMonth()
    {
        month++;
        if (month > 12)
        {
            month = 1;
        }
        monthText.GetComponent<TextMeshProUGUI>().text = month.ToString();

    }


    //Decrease Month
    public void lessMonth()
    {
        month--;
        if (month < 1)
        {
            month = 12;
        }
        monthText.GetComponent<TextMeshProUGUI>().text = month.ToString();

    }


    //Increase Year
    public void upYear()
    {
        year++;
        if (year > 2002)
        {
            year = 1940;
        }
        yearText.GetComponent<TextMeshProUGUI>().text = year.ToString();

    }


    //Decrease year
    public void lessYear()
    {
        year--;
        if (year < 1940)
        {
            year = 2002;
        }
        yearText.GetComponent<TextMeshProUGUI>().text = year.ToString();

    }




}
