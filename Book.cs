using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book
{
    private int filledRecords = 0;

    public string id;
    public string type;
    public string issued;
    public string title;
    public string language;
    public string authors;
    public string subjects;
    public string locc;
    public string bookshelves;

    public void AddtoBook(string addMe)
    {
        if (filledRecords == 0)
        {
            id = addMe;
            filledRecords++;
        } 
        else if (filledRecords == 1)
        {
            type = addMe;
            filledRecords++;
        }
        else if (filledRecords == 2)
        {
            issued = addMe;
            filledRecords++;
        }
        else if (filledRecords == 3)
        {
            title = addMe;
            filledRecords++;
        }
        else if (filledRecords == 4)
        {
            language = addMe;
            filledRecords++;
        }
        else if (filledRecords == 5)
        {
            authors = addMe;
            filledRecords++;
        }
        else if (filledRecords == 6)
        {
            subjects = addMe;
            filledRecords++;
        }
        else if (filledRecords == 7)
        {
            locc = addMe;
            filledRecords++;
        }
        else if (filledRecords == 8)
        {
            bookshelves = addMe;
            filledRecords++;
        }
        
    }

}
