using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

/**
 * Class with characters attributes
 */
namespace Assets.Scripts
{
    public class Character
    {

        //Attributes
        private string name;
        private int reload;
        private int capacity;
        private int health;
        private int speed;
        private Sprite image;
   

        //Constructors
        public Character()
        {

        }

        public Character(String name, int reload, int capacity, int health, int speed, Sprite image) 
        {
            this.name = name;
            this.reload = reload;
            this.capacity = capacity;
            this.health = health;
            this.speed = speed;
            this.image = image;
        }

        //Accessors
        public int Reload { get => reload; set => reload = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public int Health { get => health; set => health = value; }
        public int Speed { get => speed; set => speed = value; }
        public string Name { get => name; set => name = value; }
        public Sprite Image { get => image; set => image = value; } //Character image
    }
}
