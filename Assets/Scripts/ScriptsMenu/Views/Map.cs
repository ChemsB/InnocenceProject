using Assets.Scripts;
using UnityEngine;


//This class runs game
public class Map : MonoBehaviour
{

    private Model model;
    private int health; //Health vale
    private GameObject characterObject;
    public GameObject isSave;
    private Character characterAttributes;



    private void Awake()
    {
        model = new Model();

        
        int id = PlayerPrefs.GetInt("idSelectedCharacter"); // get selected chracater id
        LocalRun runData;


        characterAttributes = model.findCaharacterWithId(id); //Find character and save all attributes
        runData = model.lastCharacetrRun(id); //Find if selected character character has game data



        //If character has data, load
        if (runData != null)
        {
            characterObject = (GameObject)Instantiate(Resources.Load("Prefabs/Player")); //Draw selected character
            characterObject.transform.position = new Vector3(runData.X, runData.Y, 0); //move the character in the saved coordinates



        }
        else // if hasn't data
        {
            Debug.LogWarning("Te");
            runData = new LocalRun(-42,-13, characterAttributes.Health,this.name,"00:00", characterAttributes.Id); //Crete game with default data
            model.saveGame(runData); //save new game
            characterObject=(GameObject)Instantiate(Resources.Load("Prefabs/Player")); //draw character
            characterObject.transform.position = new Vector3(runData.X, runData.Y, 0);
        }

    }

    private void Update()
    {

        //if character is in save zone, save game
        if (isSave.activeSelf)
        {
           model.checkPoint(characterObject.transform.position, characterAttributes);
        }



    }

    /// <summary>
    /// Save game data
    /// </summary>
    /// <param name="local">game data to save</param>
    public void saveRun(LocalRun local)
    {
        model.saveGame(local);
    }



}

