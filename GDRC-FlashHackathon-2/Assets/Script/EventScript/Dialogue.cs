using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    public string text;
    public int index, type;
    public string[] choice;

    public Dialogue(string text, int index)
    {
        this.text = text;
        this.index = index;
        type = 0;
    }

    public Dialogue(string text, int index, string[] choice)
    {
        this.text = text;
        this.index = index;
        this.choice = choice;
        type = 1;
    }
}
