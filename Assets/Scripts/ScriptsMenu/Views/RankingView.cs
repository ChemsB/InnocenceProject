using Assets.Scripts;
using Assets.Scripts.ScriptsMenu.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingView : MonoBehaviour
{

    private Model model;
    private List<Player> listWithUsers = new List<Player>();
    List<Ranking> listWithRanking = new List<Ranking>();


    // Start is called before the first frame update
    void Start()
    {
        model = new Model();
        listWithRanking = model.loadAllRankings();
        listWithUsers = model.loadUsers();


        drawRanking();
        drawPosition();
    }

    private void drawPosition()
    {
        int index=0;
        Player player = new Player();

        foreach (Ranking pScore in listWithRanking)
        {
            if (2 == pScore.Id_user)
            {
                index = listWithRanking.IndexOf(pScore)+1;
            }
        }

        GameObject.Find("ActualPosition").GetComponent<TextMeshProUGUI>().text = "Your actual position: "+index.ToString();

    }

    private void drawRanking()
    {
        for (int i = 0; i <= 2; i++)
        {

            GameObject.Find("score" + i).GetComponent<TextMeshProUGUI>().text = listWithRanking[i].Score.ToString();

            foreach (Player player in listWithUsers)
            {
                if (player.Id == listWithRanking[i].Id_user)
                {
                    GameObject.Find("name" + i).GetComponent<TextMeshProUGUI>().text = player.Nick;
                }
            }

        }
    }



    public void openMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
