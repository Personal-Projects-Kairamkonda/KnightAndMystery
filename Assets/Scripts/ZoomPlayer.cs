using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomPlayer : MonoBehaviour
{
    public CinemachineVirtualCamera cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            //Camera.main.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 2;
            cam.m_Lens.OrthographicSize = 3f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Camera.main.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 2;
            cam.m_Lens.OrthographicSize = 4f;
        }
    }
}
