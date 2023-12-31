using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NameGenerator 
{
    //string filePath= "D:/UnityProject/GRDC-FlashHackathon-2/GDRC-FlashHackathon-2/Assets/name.txt";

    string[] fileLines;
    List<int> alreadyTaken = new List<int>();

    public NameGenerator()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("name");

        if (textAsset != null)
        {
            // Access the text content of the file
            string textContent = textAsset.text;
            fileLines = textContent.Split('\n');

        }
    }
    public string GetRandomName(){
        int randomIndex = Random.Range(0, fileLines.Length);
        if(alreadyTaken.Contains(randomIndex)){GetRandomName();}
        alreadyTaken.Add(randomIndex);
        string name = fileLines[randomIndex];
        return  name;
    } 
}
