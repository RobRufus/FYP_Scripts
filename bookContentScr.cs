using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class bookContentScr : MonoBehaviour
{

    string path = "Assets/Resources/test.txt";
    private string formatedBookText;
    private int consecutiveNewLineCount, pageCounter = 1;
    public TextMeshProUGUI txtBoxL, txtBoxR;
    private TextAsset bookData = null;

    void Start()
    {
        setBookPath("test");
    }

    public void setBookPath(string filename)
    {
        bookData = Resources.Load<TextAsset>("books/" + filename);
    }


    public void formatBookText()
    {

        //count consecutive new line chars, if enough insert page break tag
        string[] lines = bookData.text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);


        for (int i = 0; i < lines.Length; i++)
        {

            if (lines[i].Length == 0)
            {
                formatedBookText += "\n" + "\n";
                consecutiveNewLineCount++;
            }
            else if (consecutiveNewLineCount >= 3 && lines[i].Length != 0)   //if enough new line chars for new page and next char is not newline char, insert page tag
            {
                formatedBookText += " <page> " + lines[i];
                consecutiveNewLineCount = 0;
            }
            else
            {
                formatedBookText += " " + lines[i];
                consecutiveNewLineCount = 0;
            }

        }


        //Debug.Log("book : " + formatedBookText);
        txtBoxL.SetText(formatedBookText);
        txtBoxR.SetText(formatedBookText);
        nextPage();
    }

    public void nextPage()
    {
        txtBoxL.pageToDisplay = pageCounter;
        txtBoxR.pageToDisplay = pageCounter + 1;
        pageCounter += 2;
    }

    public void previousPage()
    {
        try
        {
            txtBoxL.pageToDisplay = pageCounter - 1;
            txtBoxR.pageToDisplay = pageCounter;
            pageCounter -= 2;
        }
        catch (Exception)
        {

            throw;
        }
        
    }


}
