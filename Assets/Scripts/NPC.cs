using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC
{
    public string[] Texts { get; private set; }
    public RepEffect Effect { get; private set; }
    private int index = 0;
    public float Patience { get; private set; }

    public NPC(string[] texts, RepEffect effect, int patience)
    {
        Texts = texts;
        Effect = effect;
        Patience = patience;
    }
    public string getText()
    {
        index = (index + 1) % (Texts.Length);
        return Texts[index];
    }
}
