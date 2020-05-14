using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/**
 * This code shows characters attribute
 * 
 * PRIVATE ATTRIBUTES (TODO)
 */
public class NextCharacter : MonoBehaviour
{

    private Character characterOne, characterTwo, characterThree;

    public GameObject character1, character2, character3;
    public Slider reloadBar, capacityBar, healthBar, speedBar;
    public TextMeshProUGUI nameText;

    private int index;

    private List<GameObject> listWithCharacters = new List<GameObject>();
    private List<Character> listWithCharactersAttributes = new List<Character>();



    public void Start()
    {
        //string name, int reload, int capacity, int health, int speed
        characterOne = new Character("Ellie",50, 73, 40, 56);
        characterTwo = new Character("Alex", 86, 68, 93, 51);
        characterThree = new Character("Fox",94, 56, 88, 97);

        changeAtributesBar(characterOne);

        listWithCharactersAttributes.Add(characterOne);
        listWithCharactersAttributes.Add(characterTwo);
        listWithCharactersAttributes.Add(characterThree);

        
        character1 = character1.GetComponent<Image>().gameObject;
        character2 = character2.GetComponent<Image>().gameObject;
        character3 = character3.GetComponent<Image>().gameObject;

        listWithCharacters.Add(character1);
        listWithCharacters.Add(character2);
        listWithCharacters.Add(character3);


    }

    /**
     * Change character image
     */
    public void changeUpCharacter()
    {
        foreach (GameObject character in listWithCharacters)
        {
            if (character.GetComponent<Image>().IsActive())
            {

                index = listWithCharacters.IndexOf(character);
                listWithCharacters[index].SetActive(false);
                if (index >= 2)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
                changeAtributesBar(listWithCharactersAttributes[index]);
                listWithCharacters[index].SetActive(true);
                break;
            }
        }

    }

    /**
    * Change character image
    */
    public void changeLessCharacter()
    {

        foreach (GameObject character in listWithCharacters)
        {
            if (character.GetComponent<Image>().IsActive())
            {
                index = listWithCharacters.IndexOf(character);
                listWithCharacters[index].SetActive(false);
                if (index <= 0)
                {
                    index = 2;
                }
                else
                {
                    index--;
                }
                changeAtributesBar(listWithCharactersAttributes[index]);
                listWithCharacters[index].SetActive(true);
                break;
            }
        }

    }


    /**
     * Change bars with character attributes
     */
    private void changeAtributesBar(Character character)
    {

        nameText.text = character.Name;
        reloadBar.value = character.Reload;
        capacityBar.value = character.Capacity;
        healthBar.value = character.Health;
        speedBar.value = character.Speed;



    }

}
