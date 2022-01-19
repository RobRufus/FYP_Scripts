using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAnimResetScr : MonoBehaviour
{

    public void resetParamNext()
    {
        this.GetComponent<Animator>().SetBool("PageNext", false);
    }
    public void resetParamPrev()
    {
        this.GetComponent<Animator>().SetBool("PageBack", false);
    }



}
