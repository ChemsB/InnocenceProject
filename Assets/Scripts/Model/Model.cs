

using Assets.Scripts;
using Assets.Scripts.Persist;
using System;
using System.Collections.Generic;

public class Model
{

    CharacterDao characterDao; //Character DAO
    UserDao userDao; //User DAO

    List<Character> listWithCharacter; 
    List<Player> listWithPlayers;

    //Constructor
    public Model()
    {
        listWithCharacter = new List<Character>();
        listWithPlayers = new List<Player>();
        characterDao = CharacterDao.Instance;
        userDao = UserDao.Instance;

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
    /// <returns></returns>
    internal bool login(string nick, string password)
    {
        bool res = false;
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
    /// <returns>true in case of exists nick, false if not exist</returns>
    public Boolean checkNick(String nick)
    {

        bool res = false;
        res = userDao.checkIfExistNick(nick);
        return res;

    }


    /// <summary>
    /// Add new user into a list
    /// </summary>
    /// <param name="player">user to add</param>
    /// <returns>true in case of added, false in otherwise case</returns>
    public Boolean insertNewUser(Player player)
    {
        bool res;

        res = userDao.addNewPlayer(player);


        return res;
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

}
