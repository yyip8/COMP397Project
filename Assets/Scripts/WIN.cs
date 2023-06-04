using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIN : MonoBehaviour
{
    public GameObject wintext;
    public endGoal go;
    // Start is called before the first frame update
    void Start()
    {

        wintext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (go.collition)
        {
            wintext.SetActive(true);
        }
    }
}
