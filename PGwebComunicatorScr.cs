using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


public class PGwebComunicatorScr : MonoBehaviour
{
    private List<Book> books = new List<Book>();
    private static Regex splitCSV = new Regex("(?:^|,)(\"(?:[^\"])*\"|[^,]*)", RegexOptions.Compiled);
    private bookshelf book_shelf = new bookshelf();

    public Transform elementStartPos;
    public GameObject elementParent;
    public GameObject uiElementPrefab;


    void Start()
    {
        //TestGet();
        getBookData();
        //populateMyBookList();     //reinstate this 
        getBookshelvesFromBooks();
    }




    public void getBookData()
    {
        TextAsset PJGCatalogue = Resources.Load<TextAsset>("pg_catalog");
        string data = PJGCatalogue.ToString();

        string[] breakByLine = data.Split(new[] { "\r\n" }, StringSplitOptions.None);

        for (int i = 1; i < breakByLine.Length-1; i++)
        {
            string[] datasplit = regexSplitStr(breakByLine[i]);

            Book b = new Book();
            for (int j = 0; j < datasplit.Length; j++)
            {
                if (datasplit[j] != null)
                {
                    b.AddtoBook(datasplit[j]);
                }
            }
            books.Add(b);
        }
    }



    public static string[] regexSplitStr(string input)
    {
        List<string> list = new List<string>();
        string curr = null;
        foreach (Match match in splitCSV.Matches(input))
        {
            curr = match.Value;
            if (0 == curr.Length)
            {
                list.Add("");
            }

            list.Add(curr.TrimStart(','));
        }

        return list.ToArray();
    }

    public void getBookshelvesFromBooks() 
    {
        //for every book in books, add bookshelf to bookshelf list if not already in list
        foreach  (Book b in books)
        {
            //if bookshelves record is readable and valid
            if (b.bookshelves != null && b.bookshelves != " ")
            {
                //remove " characters from tags
                string str_to_edit = b.bookshelves.Replace("\"", string.Empty);

                //split the bookshelves record into individual bookshelf tags
                string[] break_book_tags = str_to_edit.Split(new[] { ';', '-' }, StringSplitOptions.None);
                
                //if tags are not in the list of bookshelves, add to list
                foreach (string tag in break_book_tags)
                {
                    tag.TrimStart(' ', ',', '-');

                    book_shelf.AddBookByTag(tag);
                }
            }
            
        }
        for (int i = 0; i < book_shelf.getTagCount(); i++)
        {
            Debug.Log(book_shelf.getTagAt(i));
            Debug.Log(book_shelf.getCountByTag(book_shelf.getTagAt(i)));
        }

    }

    public void populateBookList() //TODO
    {
        //int indexNum = 0;

        //get thumbnail for book with index "indexNum"
        //var coverurl = "https://www.gutenberg.org/cache/epub/" + indexNum + "/pg" + indexNum + ".cover.medium.jpg";

        //get book list items
        //btnUIProperties d = new btnUIProperties(books[1]);

        //extend content field

        //from book list, construct new list item with book
    }

    public void populateMyBookList()
    {
        int fileCount = 0;

        //for every book
        foreach (string file in System.IO.Directory.GetFiles("Assets/Resources/books/"))
        {

            if (file.Substring(file.Length - 4) == ".txt")
            {
                Debug.Log(file);
                fileCount++;

                //instanciate a ui book element
                GameObject thisElement = Instantiate(uiElementPrefab, elementStartPos.position, Quaternion.identity, elementParent.transform);

                //feed it's script the file name
                thisElement.GetComponent<btnUIProperties>().setPath(file);

                //move book down list
                thisElement.GetComponent<btnUIProperties>().moveThisDownList(fileCount);

                //change content area box height
                if (fileCount > 4)
                {
                    RectTransform recTr = elementParent.GetComponent(typeof(RectTransform)) as RectTransform;
                    recTr.sizeDelta = new Vector2(recTr.sizeDelta.x, recTr.sizeDelta.y + 60);
                }

            }
        }

        //int indexNum = 0;

        //get thumbnail for book with index "indexNum"
        //var coverurl = "https://www.gutenberg.org/cache/epub/" + indexNum + "/pg" + indexNum + ".cover.medium.jpg";

        //get book list items
        

        //extend content field

        //from book list, construct new list item with book
    }

    public Sprite getThumbnail() //todo
    {
        Sprite returnSprite = null;
        //Todo
        return returnSprite;
    }
    
    public async void TestGet()
    {
        var url = "https://www.gutenberg.org/ebooks/bookshelf/";

        using var www = UnityWebRequest.Get(url);

        www.SetRequestHeader("Content-Type", "application/json");

        var operation = www.SendWebRequest();

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        if (www.result == UnityWebRequest.Result.Success)
        {
            Debug.Log($"Success: {www.downloadHandler.text}");
        }
        else
        {
            Debug.Log($"Failed: {www.error}");
        }

    }
    
}
