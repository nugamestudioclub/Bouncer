using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    private string name;
    private int money;
    private List<Item> inventory;

    public string Name {
        get => name;
        set => name = value;
    }
    //change current money by given amount (can be negative to decrease money)
    public void changeMoney(int amount)
    {
        this.money += amount;
    }
}