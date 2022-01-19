using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookshelf : MonoBehaviour
{
    private List<string> book_tags = new List<string>();
    private int[] tag_count;



    public int getCountByTag(string tag)
    {
        if (book_tags.Contains(tag))
        {
            return tag_count[book_tags.IndexOf(tag)];
        }
        else
        {
            return 0;
        }

    }

    public void AddBookByTag(string tag)
    {
        if (book_tags.Contains(tag))
        {
            tag_count[book_tags.IndexOf(tag)]++;
        }
        else
        {
            book_tags.Add(tag);
        }
    }

    public List<string> getTags()
    {
        return book_tags;
    }

    public string getTagAt(int index)
    {
        return book_tags[index];
    }

    public int getTagCount()
    {
        return book_tags.Count;

    }

}