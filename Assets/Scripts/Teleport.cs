using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private AudioSource wooshAudio;
    public AudioClip audioClip;

    bool soundPlayed;

    public GameObject checkpointPanel;

    private void Awake()
    {
        wooshAudio = this.GetComponent<AudioSource>();
    }

    private void Start()
    {
        checkpointPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        checkpointPanel.SetActive(true);
        wooshAudio.PlayOneShot(audioClip, 0.3f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        checkpointPanel.SetActive(false);
       // wooshAudio.PlayOneShot(audioClip);
    }

}
