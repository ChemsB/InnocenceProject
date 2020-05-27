using Assets.Scenes;
using Assets.Scripts.ScriptsMenu.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.ScriptsMenu.Persist
{
    public class RankingDao
    {

        private List<Ranking> listWithRanking; //List with rankings
        private readonly static RankingDao rankingDao = new RankingDao();


        //Constructor singleton pattern
        private RankingDao()
        {
            loadRankings();
        }

        public static RankingDao Instance
        {
            get
            {
                return rankingDao;
            }
        }

       
        /// <summary>
        /// Load all rankings
        /// </summary>
        /// <returns>list with ranking data</returns>
        public List<Ranking> loadRankings()
        {
            try
            {
                listWithRanking = new List<Ranking>();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://localhost:60300/api/TodoRuns"));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string jsonResponse = fixJson(reader.ReadToEnd());

                Ranking[] rankings = JsonHelper.FromJson<Ranking>(jsonResponse);

                for (int i = 0; i < rankings.Length; i++)
                {
                    listWithRanking.Add(rankings[i]);
                }
                return listWithRanking;

            }
            catch (Exception ex)
            {
                listWithRanking = null;
            }
            return listWithRanking;

        }


        /// <summary>
        /// Change format to json values
        /// </summary>
        /// <param name="value">string in json format</param>
        /// <returns>sring with correct sintax for serialization</returns>
        string fixJson(string value)
        {
            value = "{\"Items\":" + value + "}";
            return value;
        }


    }
}
