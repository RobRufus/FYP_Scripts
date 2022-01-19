using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pageTextPositionScr : MonoBehaviour
{
    public Transform pageToFollow, pageToFollowStatic;
    void Start()
    {
        this.transform.parent = pageToFollowStatic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
