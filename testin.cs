using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testin : MonoBehaviour
{
    private GameObject[] books;

    public void bookClose()
    {
        getBooksInScene();

        for (int i = 0; i < books.Length; i++)
        {
            books[i].GetComponent<Animator>().SetBool("Open", false);
            books[i].transform.Find("BookUI").gameObject.SetActive(false);
        }
        
    }

    public void bookOpen()
    {
        getBooksInScene();
        Debug.Log("books Length = " + books.Length);
        for (int i = 0; i < books.Length; i++)
        {
            books[i].GetComponent<Animator>().SetBool("Open", true);
            books[i].transform.Find("BookUI").gameObject.SetActive(true);
        }
        
    }

    public void forwardOnePage()
    {
        for (int i = 0; i < books.Length; i++)
        {
            books[i].GetComponent<Animator>().SetBool("PageNext", true);
            books[i].GetComponent<bookContentMgrScr>().nextPage();
        }
    }

    public void backOnePage()
    {
        for (int i = 0; i < books.Length; i++)
        {
            books[i].GetComponent<Animator>().SetBool("PageBack", true);
        }
    }

    private void getBooksInScene()
    {
        xrGrabTwoHandCompatible[] getBooks = FindObjectsOfType<xrGrabTwoHandCompatible>();
        books = new GameObject[getBooks.Length];

        for (int i = 0; i < getBooks.Length; i++)
        {
            books[i] = getBooks[i].transform.Find("BookModel").gameObject;
        }
    }

}
