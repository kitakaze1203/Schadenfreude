using System;
using UnityEngine;
[Serializable]
public enum Attribute { villager, devil, third }
public class Player
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int id { get; private set; }
    public string name { get; private set; }
    public JobData job { get; private set; }
    public bool alive { get; private set; }
    public bool possess_devil { get; private set; }
    public Attribute attribute { get; private set; }
    public string cod { get; private set; }
    public bool vote { get; set; }
    public int was_voted { get; set; }

    public Player(int my_id,string my_name,JobData get_job)
    {
        this.id = id;
        this.name = my_name;
        this.job = get_job;
        this.alive = true;
        this.attribute =get_job.third ? Attribute.third : Attribute.villager;
        this.vote = false;
        this.was_voted = 0;
    }

    public void ResetTurn()
    {
        this.vote = false;
        this.was_voted = -1;
    }

    public void Die(string couse)
    {
        this.alive = false;
        this.cod = couse;
        Debug.Log($"{name} is death");
    }

    public void SetDevil()
    {
        this.attribute = Attribute.devil;
    }
}
