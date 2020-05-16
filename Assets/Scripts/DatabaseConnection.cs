using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseConnection : MonoBehaviour
{
    // Start is called before the first frame update

    private List<string> nicks;

    public DatabaseConnection()
    {
        nicks = new List<string>();
        loadNicks();

    }


    private void loadNicks()
    {
      /*  try
        {*/
            /*string dataConnection = "Server=localhost;Database=innocence;Uid=root;Pwd=;";
            string consulta = "SELECT * FROM test";
            MySqlConnection conn = new MySqlConnection(dataConnection);
            MySqlCommand consola = new MySqlCommand(consulta, conn);
            conn.Open();


            MySqlDataReader datos = consola.ExecuteReader();

            while (datos.Read())
            {
                nicks.Add(datos.GetString(0));
            }


            conn.Close();
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Error+ " + ex);
        }*/
    }


    public bool CheckNick(string nickToCheck)
    {

        bool res = false;

        /*foreach (string nickInList in nicks)
        {
            if (nickInList.Equals(nickToCheck))
            {
                res = true;
            }
        }*/

        return res;
    }



}
