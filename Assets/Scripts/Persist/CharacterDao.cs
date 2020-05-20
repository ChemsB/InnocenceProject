using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Persist
{
    public class CharacterDao
    {
        List<Character> listWithCharacters; //List with characters
        private readonly static CharacterDao characterDao = new CharacterDao();


        //Constructor singleton pattern
        private CharacterDao()
        {
            loadTestData();
        }

        public static CharacterDao Instance
        {
            get
            {
                return characterDao;
            }
        }


        /// <summary>
        /// load character list with test data
        /// </summary>
        private void loadTestData()
        {
            listWithCharacters = new List<Character>();
            listWithCharacters.Add(new Character("Ellie", 50, 73, 40, 56, Resources.Load<Sprite>("Character")));
            listWithCharacters.Add(new Character("Alex", 86, 68, 93, 51, Resources.Load<Sprite>("darkCharacter")));
            listWithCharacters.Add(new Character("Fox", 94, 56, 88, 97, Resources.Load<Sprite>("darkCharacter")));
        }

        //Accessors
        public List<Character> ListWithCharacters { get => listWithCharacters; set => listWithCharacters = value; }

    }
}
