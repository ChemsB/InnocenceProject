
using Assets.Scripts;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



/**
 * This code shows characters with attributes
 */
public class CharacterMenu : MonoBehaviour
{


    private List<Character> listWithCharacters; //list with characters
    private Model model;
    private Character character;

    private GameObject characterImage; //panel for display character image
    public Slider reloadBar, capacityBar, healthBar, speedBar; //Attribute bars
    public TextMeshProUGUI nameText; //Display character name


    private int index; //index in character list


    public void Start()
    {
        initComponents();
    }

    /// <summary>
    /// Inicialize components
    /// </summary>
    private void initComponents()
    {
        model = new Model();
        listWithCharacters = model.loadCharacters();

        index = 0;
        characterImage = GameObject.Find("ImageCharacter");
        changeAtributesBar(listWithCharacters[0]);
    }

    /**
     * Change character if user push right arrow
     */
    public void changeUpCharacter()
    {

        index++;

        if (index == listWithCharacters.Count)
        {
            index = 0;
            
        }

        changeAtributesBar(listWithCharacters[index]);

    }

    /**
    * Change character if user push left arrow
    */
    public void changeLessCharacter()
    {


        index--;
        

        if (index < 0)
        {
            index = listWithCharacters.Count-1;
        }

        changeAtributesBar(listWithCharacters[index]);

    }



    /// <summary>
    /// Show character with attributes
    /// </summary>
    /// <param name="character"> character to display</param>
    private void changeAtributesBar(Character character)
    {
        //Show name
        nameText.text = character.Name;
        //Show attributes with bars
        reloadBar.value = character.Reload;
        capacityBar.value = character.Capacity;
        healthBar.value = character.Health;
        speedBar.value = character.Speed;
        //Display character image
        characterImage.GetComponent<Image>().sprite = character.Image;

        this.character = character;

    }
    
    /// <summary>
    /// Open main menu
    /// </summary>
    public void openMainMenu()
    {
        MenuManager.switchToMenu(2);
    }

    /// <summary>
    /// Save selected character id and open game scene
    /// </summary>
    public void openGame()
    {
        PlayerPrefs.SetInt("idSelectedCharacter", character.Id);
        SceneManager.LoadScene("SampleScene");

    }



}
