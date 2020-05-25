using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class save game attributes
/// </summary>
public class LocalRun
{

    private int id;
    private float x;
    private float y;
    private int health;
    private string scene;
    private string timer;
    private int id_character;

    //Constructors
    public LocalRun()
    {
    }

    public LocalRun(int id, float x, float y, int health, string scene, string timer,int id_character)
    {
        this.id = id;
        this.x = x;
        this.y = y;
        this.health = health;
        this.scene = scene;
        this.timer = timer;
        this.id_character = id_character;
    }

    public LocalRun( float x, float y, int health, string scene, string timer,int id_character)
    {
        this.x = x;
        this.y = y;
        this.health = health;
        this.scene = scene;
        this.timer = timer;
        this.id_character = id_character;
    }

    //Accessors
    public int Id { get => id; set => id = value; }
    public float X { get => x; set => x = value; }
    public float Y { get => y; set => y = value; }
    public int Health { get => health; set => health = value; }
    public string Scene { get => scene; set => scene = value; }
    public string Timer { get => timer; set => timer = value; }
    public int Id_character { get => id_character; set => id_character = value; }
}
