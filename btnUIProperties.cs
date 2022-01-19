using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class btnUIProperties : MonoBehaviour
{
    //properties of the book that the element represents
    private Book representedBook = null;
    private string representedFileName = null;
    private webComunicatorScr webComScr;
    private GameObject place;
    public GameObject bookPhysical;

    void Start()
    {
        webComScr = FindObjectOfType<webComunicatorScr>();
        place = GameObject.Find("BookSpawnLoc");

        if (representedFileName != null)
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = (representedFileName);
            //this.GetComponentInChildren<Image>().sprite = webComScr.getThumbnail();
        }
        else 
        {
            this.GetComponentInChildren<TextMeshProUGUI>().text = (representedBook.title + " \n" + representedBook.authors);
            this.GetComponentInChildren<Image>().sprite = webComScr.getThumbnail();
        }
        
    }

    public void openThisBook()
    {
        GameObject currBook = Instantiate(bookPhysical, place.transform.position, Quaternion.identity);

        if (representedFileName != null)
        {
            currBook.GetComponentInChildren<bookContentMgrScr>().setBookPath(representedFileName);
        }
        else
        {
            currBook.GetComponentInChildren<bookContentMgrScr>().setBookPath(representedBook.title);
        }

    }

    //move the element down the list based on its position
    public void moveThisDownList(int howManyTimes)
    {
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - (60 * (howManyTimes - 1)), this.transform.localPosition.z);
    }

    public void setPath(string parsedPath)
    {
        representedFileName = parsedPath;
    }

    public void setBook(Book parsedBook)
    {
        representedBook = parsedBook;
    }

}
