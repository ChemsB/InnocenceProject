

using Assets.Scripts;
using Assets.Scripts.Persist;
using Assets.Scripts.ScriptsMenu.Model;
using Assets.Scripts.ScriptsMenu.Persist;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Model
{

    LocalRun run;

    CharacterDao characterDao; //Character DAO
    UserDao userDao; //User DAO
    LocalRunDao gameDao; //Game DAO
    RankingDao rankingDao; //Ranking DAO

    List<Character> listWithCharacter; //List with characters
    List<Player> listWithPlayers; //List with users
    List<LocalRun> listWithGameData; //List with game data
    List<Ranking> listWithRanking; //List with ranking data



    //Constructor
    public Model()
    {
        listWithCharacter = new List<Character>();
        listWithPlayers = new List<Player>();
        listWithGameData = new List<LocalRun>();
        listWithRanking = new List<Ranking>();
        characterDao = CharacterDao.Instance;
        userDao = UserDao.Instance;
        gameDao = LocalRunDao.Instance;
        rankingDao = RankingDao.Instance;

    }


    /// <summary>
    /// Load all runs with score
    /// </summary>
    /// <returns>list with scores</returns>
    public List<Ranking> loadAllRankings()
    {
        listWithRanking = new List<Ranking>();
        listWithRanking = rankingDao.loadRankings();
        return listWithRanking;

    }

    /// <summary>
    /// Load saved games
    /// </summary>
    /// <returns>list with the saved data of each character </returns>
    public List<LocalRun> loadGame()
    {
        listWithGameData = new List<LocalRun>();
        listWithGameData=gameDao.loadGame();
        return listWithGameData;
    }

    /// <summary>
    /// Save game with attributes of the moment
    /// </summary>
    /// <param name="save">data to save</param>
    /// <returns>true if saved, false in other case</returns>
    public bool saveGame(LocalRun save)
    {
        bool res = false;
        gameDao.saveGame(save);
        return res;
    }


    /// <summary>
    /// Load characters with test attributes and default sprite
    /// </summary>
    /// <returns>List with characters</returns>
    public List<Character> loadCharacters()
    {
        listWithCharacter = characterDao.ListWithCharacters;
        return listWithCharacter;
    }

    /// <summary>
    /// Login user with nick and password
    /// </summary>
    /// <param name="nick">user nick</param>
    /// <param name="password">user password</param>
    /// <returns>true 0 exist user, 1 if not exist, 2 in case of server error</returns>
    internal int login(string nick, string password)
    {
        int res = 0;
        res = userDao.loginUser(nick, password);
        return res;
    }


    /// <summary>
    /// Load users with test data
    /// </summary>
    /// <returns>List with users</returns>
    public List<Player> loadUsers()
    {
        listWithPlayers = userDao.ListWithUsers;
        return listWithPlayers;
    }

    /// <summary>
    /// Check if nick is already used
    /// </summary>
    /// <param name="nick">nick to check</param>
    /// <returns>0 if exist, 1 if not exist, 2 in case of error with server</returns>
    public int checkNick(String nick)
    {

        int res = 0;
        res = userDao.checkIfExistNick(nick);
        return res;

    }


    /// <summary>
    /// Add new user into a list
    /// </summary>
    /// <param name="player">user to add</param>
    /// <returns>true in case of added, false in otherwise case</returns>
    public IEnumerator insertNewUser(Player player)
    {
        return userDao.addNewPlayer(player);
    }

    /// <summary>
    /// Change the nick of the user
    /// </summary>
    /// <param name="player">player to change nick</param>
    /// <param name="newNick">new nick to replace old nick</param>
    /// <returns>true in case of changed, false in case of exists new nick</returns>
    public bool changeNick(string oldNick, string newNick)
    {

        bool res;
        res = userDao.changeNick(oldNick, newNick);
        return res;

    }


    /// <summary>
    /// Load game data for one character
    /// </summary>
    /// <param name="characterId">character to load</param>
    /// <returns></returns>
    public LocalRun lastCharacetrRun(int characterId)
    {
        LocalRun lastRun = null;
        lastRun = gameDao.findRun(characterId);
        return lastRun;
    }

    /// <summary>
    /// Find character with id
    /// </summary>
    /// <param name="id">id to find</param>
    /// <returns>character with attributes</returns>
    public Character findCaharacterWithId(int id)
    {
        Character character = new Character();

        foreach (Character characters in loadCharacters())
        {

            if (characters.Id == id)
            {
                character = characters;
            }
        }
        return character;

    }

    /// <summary>
    /// Save the character and the coordinates of the game
    /// </summary>
    /// <param name="vector">coordinates</param>
    /// <param name="character">character attributes</param>
    /// <returns>true in case of saving, false in case of error</returns>
    public Boolean checkPoint(Vector3 vector, Character character)
    {
        bool res = false;
        res = gameDao.checkPoint(vector,character);
        return res;
    }



}
