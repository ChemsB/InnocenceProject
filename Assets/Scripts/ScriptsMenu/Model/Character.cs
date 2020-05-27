using System;
using UnityEngine;

/**
 * Class with characters attributes
 */
namespace Assets.Scripts
{
    public class Character
    {

        //Attributes
        private int id;
        private string name;
        private int health;
        private int speed;
        private Sprite image;
   

        //Constructors
        public Character()
        {

        }

        public Character(int id,String name, int health, int speed, Sprite image) 
        {
            this.id = id;
            this.name = name;
            this.health = health;
            this.speed = speed;
            this.image = image;
        }

        public Character(int id, String name, int reload, int capacity, int health, int speed)
        {
            this.id = id;
            this.name = name;
            this.health = health;
            this.speed = speed;
        }

        //Accessors
        public int Id { get => id; set => id = value; }
        public int Health { get => health; set => health = value; }
        public int Speed { get => speed; set => speed = value; }
        public string Name { get => name; set => name = value; }
        public Sprite Image { get => image; set => image = value; } //Character image

    }
}
