using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    ResourceRequest request;
    GameObject go;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(AsyncGetRes());
    }

    IEnumerator AsyncGetRes()
    {
        request = Resources.LoadAsync("Test");
        yield return request;
        go = request.asset as GameObject;
        if (go != null)
        {
            Instantiate(go);
        }
        else
        {
            Debug.Log("Load Fail");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (request != null)
        {
            if (go != null)
            {
                Debug.Log(request.progress);
            }
        }

    }
}
