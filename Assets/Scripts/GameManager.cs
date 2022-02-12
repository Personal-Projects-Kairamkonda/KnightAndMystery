using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject heroKnight;


    // Start is called before the first frame update
    void Start()
    {
        KnightDisableControls();
    }


    public void KnightDisableControls()
    {
        //heroKnight.enabled = false;
        heroKnight.GetComponent<HeroKnight>().enabled = false;
    }

    public void KnightEnableControls()
    {
        //heroKnight.enabled = true;
        heroKnight.GetComponent<HeroKnight>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        heroKnight.GetComponent<Animator>().SetInteger("AnimState", 0);
        KnightDisableControls();
    }
}
