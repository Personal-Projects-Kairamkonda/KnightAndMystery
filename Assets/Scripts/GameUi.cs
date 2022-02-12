using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUi : MonoBehaviour
{
    public GameObject[] disableObjects;

    public GameObject MainPanel;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < disableObjects.Length; i++)
        {
            disableObjects[i].SetActive(false);
        }

        MainPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
