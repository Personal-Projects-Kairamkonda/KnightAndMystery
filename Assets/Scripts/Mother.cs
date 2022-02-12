using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour
{
    public GameObject Panel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Panel.SetActive(true);
    }
}
