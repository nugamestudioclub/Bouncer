using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character 
{
    private string[] texts;
    public string[] Texts { get { return this.texts; } }
    private RepEffect effect;
    public RepEffect Effect { get { return this.effect; } }
    private int index = 0;
    private float patience;
    
    public Character(string[] texts,RepEffect effect,int patience)
    {
        this.texts = texts;
        this.effect = effect;
        this.patience = patience;
        Debug.Log("");
    }
    public string getText()
    {
        index = (index + 1) % (this.texts.Length);
        return this.texts[index];
    }
    //0 is MAJOR PROBLEM (-20), 1 is MINOR PROBLEM(-5), 2 is Minor GOOD(+5), 3 is Major Good(+20)
    public int Admit()
    {
        switch (this.effect)
        {
            case RepEffect.MajorGood:
                return 3;
            case RepEffect.MinorGood:
                return 2;
            case RepEffect.MinorProblem:
                return 1;
            case RepEffect.MajorProblem:
                return 0;
        }
        return 0;
    }
    public int Bounce()
    {
        return 3 - Admit();
    }

    public float GetPatience()
    {
        return patience;
    }
}
